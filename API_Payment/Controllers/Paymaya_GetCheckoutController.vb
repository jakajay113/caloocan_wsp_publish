Imports System
Imports System.Net
Imports System.Linq
Imports System.Net.Http
Imports System.Web.Http
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports VB.NET.Methods
Imports API.GetCheckoutAPI


Public Class Paymaya_GetCheckoutController
    Inherits ApiController
    Dim _mSqlCommand As SqlCommand
    Dim _mSqlCon As New SqlConnection
    Dim _nQuery As String = Nothing
    Dim ExistsOn_OnlinePaymentRefNo As Boolean = Nothing
    Dim ExistsOn_Paymaya_GetCheckout As Boolean = Nothing
    Dim _JSON As String = Nothing

    <HttpPost>
    Public Function Post(<FromBody> ByVal GetCheckout As GetCheckoutModel)
        Dim response = Request.CreateResponse(Of GetCheckoutModel)(System.Net.HttpStatusCode.Created, GetCheckout)

        Try

            _JSON = Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetCheckout})
            Dim _nWSP As New WSP
            _nWSP._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nWSP.Check_OnlinePaymentRefNo(GetCheckout.id, GetCheckout.requestReferenceNumber, ExistsOn_OnlinePaymentRefNo, "Paymaya")
            If ExistsOn_OnlinePaymentRefNo = False Then
                Return "HTTP 204 No Content"
                Exit Function
            End If

            _nWSP.Check_PayMaya_GetCheckout(_JSON, ExistsOn_Paymaya_GetCheckout)
            If ExistsOn_Paymaya_GetCheckout = True Then
                Return "HTTP 202 Accepted"
                Exit Function
            Else
                Try
                    _nQuery = "Insert into Paymaya_GetCheckout values(" & _
       "'" & Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetCheckout}) & "'" & _
       ",'" & GetCheckout.id & "'" & _
       ",'" & Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetCheckout.items}) & "'" & _
       ",'" & GetCheckout.requestReferenceNumber & "'" & _
       ",'" & GetCheckout.receiptNumber & "'" & _
       ",'" & GetCheckout.createdAt & "'" & _
       ",'" & GetCheckout.updatedAt & "'" & _
       ",'" & GetCheckout.expiredAt & "'" & _
       ",'" & GetCheckout.paymentScheme & "'" & _
       ",'" & GetCheckout.expressCheckout & "'" & _
       ",'" & GetCheckout.refundedAmount & "'" & _
       ",'" & GetCheckout.canPayPal & "'" & _
       ",'" & GetCheckout.status & "'" & _
       ",'" & GetCheckout.paymentStatus & "'" & _
       ",'" & Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetCheckout.paymentDetails}) & "'" & _
       ",'" & Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetCheckout.buyer}) & "'" & _
       ",'" & Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetCheckout.merchant}) & "'" & _
       ",'" & Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetCheckout.totalAmount}) & "'" & _
       ",'" & Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetCheckout.redirectUrl}) & "'" & _
       ",'" & GetCheckout.transactionReferenceNumber & "'" & _
       ",'" & Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetCheckout.metadata}) & "')"

                    Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
                    '----------------------------------
                    _nSqlCommand.ExecuteNonQuery()
                    '----------------------------------

                    Dim _StatusID As String = Nothing
                    Dim _Status As String = Nothing

                    Select Case (GetCheckout.paymentStatus)
                        Case "PAYMENT_SUCCESS"
                            _StatusID = "SUCCESS"
                            _Status = "Successful Payment"
                        Case "PAYMENT_FAILED"
                            _StatusID = "FAILED"
                            _Status = "Payment Failed"
                        Case "PAYMENT_EXPIRED"
                            _StatusID = "EXPIRED"
                            _Status = "Payment Expired"
                    End Select
                    _nWSP.Update_OnlinePaymentRefno(GetCheckout.transactionReferenceNumber, GetCheckout.id, _StatusID, _Status, GetCheckout.receiptNumber)


                    Return "HTTP 200 Ok"
                    Exit Function
                Catch ex As Exception

                End Try

            End If


        Catch ex As Exception
            Return response.StatusCode

        End Try

    End Function


End Class