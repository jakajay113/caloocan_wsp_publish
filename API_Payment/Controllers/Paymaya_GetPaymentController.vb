Imports System
Imports System.Net
Imports System.Linq
Imports System.Net.Http
Imports System.Web.Http
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports VB.NET.Methods
Imports API.GetPaymentAPI
Public Class Paymaya_GetPaymentController
    Inherits ApiController
    Dim _mSqlCommand As SqlCommand
    Dim _mSqlCon As New SqlConnection
    Dim _nQuery As String = Nothing
    Dim ExistsOn_OnlinePaymentRefNo As Boolean = Nothing
    Dim ExistsOn_Paymaya_GetPayment As Boolean = Nothing
    Dim _JSON As String = Nothing

    <HttpPost>
    Public Function Post(<FromBody> ByVal GetPayment As GetPaymentClass)
        Dim response = Request.CreateResponse(Of GetPaymentClass)(System.Net.HttpStatusCode.Created, GetPayment)
        Try
            _JSON = Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetPayment})

            Dim _nWSP As New WSP
            _nWSP._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nWSP.Check_OnlinePaymentRefNo(GetPayment.id, GetPayment.requestReferenceNumber, ExistsOn_OnlinePaymentRefNo, "Paymaya")

            If ExistsOn_OnlinePaymentRefNo = False Then
                Return "HTTP 204 No Content"
                Exit Function
            End If

            _nWSP.Check_PayMaya_GetPayment(_JSON, ExistsOn_Paymaya_GetPayment)
            If ExistsOn_Paymaya_GetPayment = True Then
                Return "HTTP 202 Accepted"
                Exit Function
            Else
                Insert_GetPayment.id = GetPayment.id
                Insert_GetPayment.isPaid = GetPayment.isPaid
                Insert_GetPayment.status = GetPayment.status
                Insert_GetPayment.amount = GetPayment.amount
                Insert_GetPayment.currency = GetPayment.currency
                Insert_GetPayment.canVoid = GetPayment.canVoid
                Insert_GetPayment.canRefund = GetPayment.canRefund
                Insert_GetPayment.canCapture = GetPayment.canCapture
                Insert_GetPayment.createdAt = GetPayment.createdAt
                Insert_GetPayment.updatedAt = GetPayment.updatedAt
                Insert_GetPayment.description = GetPayment.description
                Insert_GetPayment.paymentTokenId = GetPayment.paymentTokenId
                Insert_GetPayment.fundSource = Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetPayment.fundSource})
                Insert_GetPayment.receipt = Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetPayment.receipt})
                Insert_GetPayment.metadata = Newtonsoft.Json.JsonConvert.SerializeObject(New With {GetPayment.metadata})
                Insert_GetPayment.approvalCode = GetPayment.approvalCode
                Insert_GetPayment.receiptNumber = GetPayment.receiptNumber
                Insert_GetPayment.requestReferenceNumber = GetPayment.requestReferenceNumber
                _nWSP.Insert_PayMaya_GetPayment(_JSON)

                Dim _StatusID As String = Nothing
                Dim _Status As String = Nothing

                Select Case (GetPayment.status)
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
                _nWSP.Update_OnlinePaymentRefno(GetPayment.requestReferenceNumber, GetPayment.id, _StatusID, _Status, GetPayment.receiptNumber)
                Return "HTTP 200 Ok"
            End If


        Catch ex As Exception
            Return response.StatusCode

        End Try

    End Function


End Class