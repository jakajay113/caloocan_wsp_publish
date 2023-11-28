Imports System
Imports System.Net
Imports System.Linq
Imports System.Net.Http
Imports System.Web.Http
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports VB.NET.Methods
Imports API.gc_Notify
Imports API.gc_Response
Imports System.Security.Cryptography
Imports System.IO
Imports Newtonsoft.Json
Imports System.Threading.Tasks
Imports System.Net.Mail
Imports Newtonsoft.Json.Linq
Imports Org.BouncyCastle.Crypto
Imports Org.BouncyCastle.Crypto.Parameters
Imports Org.BouncyCastle.OpenSsl
Imports Org.BouncyCastle.Security
Imports Org.BouncyCastle.Asn1.X509
Imports Org.BouncyCastle.Asn1.Pkcs
Imports Org.BouncyCastle.Pkcs
Imports Org.BouncyCastle.X509
Imports RestSharp

Public Class GCASH_NotifyController
    Inherits ApiController
    Dim _mSqlCommand As SqlCommand
    Dim _mSqlCon As New SqlConnection
    Dim _nQuery As String = Nothing
    Dim ExistsOn_OnlinePaymentRefNo As Boolean = Nothing
    Dim ExistsOn_GCASH_Transaction As Boolean = Nothing
    Dim _JSON As String = Nothing
    Dim GCASH_PubKey As String
    Private PublicKey_XML As String
    Private PrivateKey_XML As String
    Private PublicKey_PEM As String
    Private PrivateKey_PEM As String
    Private ClientId As String
    Private ClientSecret As String
    Private MerchantID As String
    Private ProductCode As String
    Private GCASH_PublicKey_PEM As String
    Private ReqMsgID As String

    '--------for PostResponse
    Dim encoder As New UTF8Encoding
    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer()
    '-Head
    Dim _version, _function, _clientId, _reqMsgId, _respTime As String
    Dim _transactionId, _acquirementStatus, _merchantTransId, _request, _signature As String
    '-body
    Dim _resultStatus, _resultCodeId, _resultCode, _resultMsg As String

    <HttpPost>
    Public Function Post(<FromBody> ByVal _RootObject As gc_Notify.RootObject)
        Dim response = Request.CreateResponse(Of gc_Notify.RootObject)(System.Net.HttpStatusCode.Created, _RootObject)
        Try
            _JSON = Newtonsoft.Json.JsonConvert.SerializeObject(New With {_RootObject})

            Dim _nWSP As New WSP
            _nWSP._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nWSP.Check_OnlinePaymentRefNo(_RootObject.request.body.transactionId, _RootObject.request.body.merchantTransId, ExistsOn_OnlinePaymentRefNo, "GCASH")
            _nWSP.loadcredentials()
            PublicKey_XML = _nWSP._pPublicKey_XML
            PrivateKey_XML = _nWSP._pPrivateKey_XML
            PublicKey_PEM = _nWSP._pPublicKey_PEM
            PrivateKey_PEM = _nWSP._pPrivateKey_PEM
            ClientId = _nWSP._pClientId
            ClientSecret = _nWSP._pClientId
            MerchantID = _nWSP._pMerchantID
            ProductCode = _nWSP._pProductCode
            GCASH_PubKey = "-----BEGIN PUBLIC KEY-----" & vbCrLf & _nWSP._pGCASH_PublicKey_PEM & vbCrLf & "-----END PUBLIC KEY-----"

            'If ExistsOn_OnlinePaymentRefNo = False Then
            '    Return "HTTP 204 No Content"
            '    Exit Function
            'End If

            _nWSP.Check_GCASH_Transaction(_JSON, ExistsOn_GCASH_Transaction)
            'If ExistsOn_GCASH_Transaction = True Then
            '    Return "HTTP 202 Accepted"
            '    Exit Function
            'Else
            '==FILL RESPONSE HEAD
            _version = _RootObject.request.head.version
            _clientId = _RootObject.request.head.clientId
            _reqMsgId = _RootObject.request.head.reqMsgId
            _respTime = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssK")

            _function = _RootObject.request.head.function
            _transactionId = _RootObject.request.body.transactionId
            _merchantTransId = _RootObject.request.body.merchantTransId
            _acquirementStatus = _RootObject.request.body.acquirementStatus
            _signature = _RootObject.signature


            '==Insert to Table
            _nWSP.Insert_Gcash_GetPayment(_function, _transactionId, _merchantTransId, _JSON, "Request from GCASH", _acquirementStatus, _signature)

            '==FILL RESPONSE BODY             
            Dim _StatusID As String = _RootObject.request.body.acquirementStatus
            Dim _Status As String = Nothing
            Select Case (_StatusID)
                Case "SUCCESS"
                    _Status = "Successful Payment"
                Case "CLOSE"
                    _Status = "Payment Failed"
            End Select
            _resultStatus = "S"
            _resultCodeId = "00000000"
            _resultCode = "SUCCESS"
            _resultMsg = _StatusID

            '  _nWSP.Update_OnlinePaymentRefno(_RootObject.request.body.merchantTransId, _RootObject.request.body.transactionId, _StatusID, _Status, _RootObject.request.body.acquirementId)

            ' If do_verifyRequest(_JSON) = True Then
            '     Dim ResponseString As String = Create_responseString()
            '     Return ResponseString
            ' End If

            ' End If

            Dim OriginalString As String
            OriginalString = _JSON.Replace("{""_RootObject"":{""request"":", "")
            OriginalString = OriginalString.Replace(",""signature"":""" & _RootObject.signature & """", "")
            OriginalString = OriginalString.Remove(OriginalString.Length - 2)

            If VerifySignature(OriginalString, _RootObject.signature) = True Then
                Dim Result As String = Nothing
                Dim objReq As New gc_Response.RootObject()
                objReq.response = New gc_Response.Response()
                objReq.response.head = New gc_Response.Head()
                objReq.response.body = New gc_Response.Body()
                objReq.response.body.resultInfo = New gc_Response.ResultInfo()

                objReq.response.head.version = _version
                objReq.response.head.function = _function
                objReq.response.head.clientId = _clientId
                objReq.response.head.reqMsgId = _reqMsgId
                objReq.response.head.respTime = _respTime

                objReq.response.body.resultInfo.resultStatus = _resultStatus
                objReq.response.body.resultInfo.resultCodeId = _resultCodeId
                objReq.response.body.resultInfo.resultCode = _resultCode
                objReq.response.body.resultInfo.resultMsg = _resultMsg

                objReq.signature = "signature string"
                Dim body = Newtonsoft.Json.JsonConvert.SerializeObject(objReq) 'serializer.Serialize(objReq)

                Dim StringToSign As String = Nothing
                StringToSign = body.Remove(0, 12) ' Remove "response":
                StringToSign = StringToSign.Replace(",""signature"":""signature string""}", "")
                body = body.Replace("signature string", Do_Sign(StringToSign))

                Dim responseX = Me.Request.CreateResponse(HttpStatusCode.OK)
                responseX.Content = New StringContent(body, Encoding.UTF8, "application/json")

                '==Insert to Table
                _nWSP.Insert_Gcash_GetPayment(_function, _transactionId, _merchantTransId, body, "Response from SPIDC", _acquirementStatus, Do_Sign(StringToSign))


                Return responseX
            Else
                Return "Invalid Signature"
            End If

        Catch ex As Exception

        End Try
    End Function

    '  Public Function [Get](ByVal json As String) As HttpResponseMessage
    '    
    '  End Function

    Function VerifySignature(ByVal OriginalString As String, ByVal SignedString As String) As Boolean
        Try
            Dim initialProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            Dim privateKey As String = ExportPrivateKey(initialProvider)
            Dim publicKey As String = ExportPublicKey(initialProvider)

            Dim importedProvider As RSACryptoServiceProvider = ImportPublicKey(GCASH_PubKey)
            publicKey = ExportPublicKey(importedProvider)

            Dim pubKey As RSAParameters = importedProvider.ExportParameters(False)

            Dim encoder = New UTF8Encoding()
            Dim bytesToVerify As Byte() = encoder.GetBytes(OriginalString)
            Dim signedBytes As Byte() = Convert.FromBase64String(SignedString)

            Return importedProvider.VerifyData(bytesToVerify, SHA256.Create(), signedBytes)


        Catch ex As Exception

        End Try
    End Function
    Public Shared Function ImportPublicKey(ByVal pem As String) As RSACryptoServiceProvider
        Dim pr As PemReader = New PemReader(New StringReader(pem))
        Dim publicKey As AsymmetricKeyParameter = CType(pr.ReadObject(), AsymmetricKeyParameter)
        Dim rsaParams As RSAParameters = DotNetUtilities.ToRSAParameters(CType(publicKey, RsaKeyParameters))
        Dim csp As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        csp.ImportParameters(rsaParams)
        Return csp
    End Function

  
    Private Shared Sub EncodeLength(ByVal stream As BinaryWriter, ByVal length As Integer)
        If length < 0 Then Throw New ArgumentOutOfRangeException("length", "Length must be non-negative")

        If length < &H80 Then
            stream.Write(CByte(length))
        Else
            Dim temp = length
            Dim bytesRequired = 0

            While temp > 0
                temp >>= 8
                bytesRequired += 1
            End While

            stream.Write(CByte((bytesRequired Or &H80)))

            For i = bytesRequired - 1 To 0
                stream.Write(CByte((length >> (8 * i) & &HFF)))
            Next
        End If
    End Sub

    Public Shared Function ExportPublicKey(ByVal csp As RSACryptoServiceProvider) As String
        Dim outputStream As StringWriter = New StringWriter()
        Dim parameters = csp.ExportParameters(False)

        Using stream = New MemoryStream()
            Dim writer = New BinaryWriter(stream)
            writer.Write(CByte(&H30))

            Using innerStream = New MemoryStream()
                Dim innerWriter = New BinaryWriter(innerStream)
                innerWriter.Write(CByte(&H30))
                EncodeLength(innerWriter, 13)
                innerWriter.Write(CByte(&H6))
                Dim rsaEncryptionOid = New Byte() {&H2A, &H86, &H48, &H86, &HF7, &HD, &H1, &H1, &H1}
                EncodeLength(innerWriter, rsaEncryptionOid.Length)
                innerWriter.Write(rsaEncryptionOid)
                innerWriter.Write(CByte(&H5))
                EncodeLength(innerWriter, 0)
                innerWriter.Write(CByte(&H3))

                Using bitStringStream = New MemoryStream()
                    Dim bitStringWriter = New BinaryWriter(bitStringStream)
                    bitStringWriter.Write(CByte(&H0))
                    bitStringWriter.Write(CByte(&H30))

                    Using paramsStream = New MemoryStream()
                        Dim paramsWriter = New BinaryWriter(paramsStream)
                        EncodeIntegerBigEndian(paramsWriter, parameters.Modulus)
                        EncodeIntegerBigEndian(paramsWriter, parameters.Exponent)
                        Dim paramsLength = CInt(paramsStream.Length)
                        EncodeLength(bitStringWriter, paramsLength)
                        bitStringWriter.Write(paramsStream.GetBuffer(), 0, paramsLength)
                    End Using

                    Dim bitStringLength = CInt(bitStringStream.Length)
                    EncodeLength(innerWriter, bitStringLength)
                    innerWriter.Write(bitStringStream.GetBuffer(), 0, bitStringLength)
                End Using

                Dim length = CInt(innerStream.Length)
                EncodeLength(writer, length)
                writer.Write(innerStream.GetBuffer(), 0, length)
            End Using

            Dim base64 = Convert.ToBase64String(stream.GetBuffer(), 0, CInt(stream.Length)).ToCharArray()
            outputStream.Write("-----BEGIN PUBLIC KEY-----" & vbLf)

            For i = 0 To base64.Length - 1 Step 64
                outputStream.Write(base64, i, Math.Min(64, base64.Length - i))
                outputStream.Write(vbLf)
            Next

            outputStream.Write("-----END PUBLIC KEY-----")
        End Using

        Return outputStream.ToString()
    End Function
    Public Shared Function ExportPrivateKey(ByVal csp As RSACryptoServiceProvider) As String
        Dim outputStream As StringWriter = New StringWriter()
        If csp.PublicOnly Then Throw New ArgumentException("CSP does not contain a private key", "csp")
        Dim parameters = csp.ExportParameters(True)

        Using stream = New MemoryStream()
            Dim writer = New BinaryWriter(stream)
            writer.Write(CByte(&H30))

            Using innerStream = New MemoryStream()
                Dim innerWriter = New BinaryWriter(innerStream)
                EncodeIntegerBigEndian(innerWriter, New Byte() {&H0})
                EncodeIntegerBigEndian(innerWriter, parameters.Modulus)
                EncodeIntegerBigEndian(innerWriter, parameters.Exponent)
                EncodeIntegerBigEndian(innerWriter, parameters.D)
                EncodeIntegerBigEndian(innerWriter, parameters.P)
                EncodeIntegerBigEndian(innerWriter, parameters.Q)
                EncodeIntegerBigEndian(innerWriter, parameters.DP)
                EncodeIntegerBigEndian(innerWriter, parameters.DQ)
                EncodeIntegerBigEndian(innerWriter, parameters.InverseQ)
                Dim length = CInt(innerStream.Length)
                EncodeLength(writer, length)
                writer.Write(innerStream.GetBuffer(), 0, length)
            End Using

            Dim base64 = Convert.ToBase64String(stream.GetBuffer(), 0, CInt(stream.Length)).ToCharArray()
            outputStream.Write("-----BEGIN RSA PRIVATE KEY-----" & vbLf)

            For i = 0 To base64.Length - 1 Step 64
                outputStream.Write(base64, i, Math.Min(64, base64.Length - i))
                outputStream.Write(vbLf)
            Next

            outputStream.Write("-----END RSA PRIVATE KEY-----")
        End Using

        Return outputStream.ToString()
    End Function
    Function do_verifyRequest(ByVal JSON As String) As Boolean

        Return True
    End Function


    Function Do_Sign(ByVal StringToSign As String) As String
        Try
            Dim originalData As Byte() = encoder.GetBytes(StringToSign)
            Dim signedData As Byte()
            Dim rsa As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            Dim XML_PrivateKey As String = PrivateKey_XML
            rsa.FromXmlString(XML_PrivateKey)
            Dim key As RSAParameters = rsa.ExportParameters(True)
            signedData = HashAndSignBytes(originalData, key)
            Return Convert.ToBase64String(signedData)
        Catch ex As Exception

        End Try
    End Function
    Public Shared Function HashAndSignBytes(ByVal DataToSign As Byte(), ByVal Key As RSAParameters) As Byte()
        Try
            Dim RSAalg As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            RSAalg.ImportParameters(Key)
            Return RSAalg.SignData(DataToSign, SHA256.Create())
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
            Return Nothing
        End Try
    End Function
    Private Shared Sub EncodeIntegerBigEndian(ByVal stream As BinaryWriter, ByVal value As Byte(), Optional ByVal forceUnsigned As Boolean = True)
        stream.Write(CByte(&H2))
        Dim prefixZeros = 0

        For i = 0 To value.Length - 1
            If value(i) <> 0 Then Exit For
            prefixZeros += 1
        Next

        If value.Length - prefixZeros = 0 Then
            EncodeLength(stream, 1)
            stream.Write(CByte(0))
        Else

            If forceUnsigned AndAlso value(prefixZeros) > &H7F Then
                EncodeLength(stream, value.Length - prefixZeros + 1)
                stream.Write(CByte(0))
            Else
                EncodeLength(stream, value.Length - prefixZeros)
            End If

            For i = prefixZeros To value.Length - 1
                stream.Write(value(i))
            Next
        End If
    End Sub

End Class