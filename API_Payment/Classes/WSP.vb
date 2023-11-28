
#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Web.HttpContext

#End Region

Public Class WSP
#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader


#End Region

#Region "Variables Field"
    '---------For Entry---------------------
    Private _mPublicKey_XML As String
    Private _mPrivateKey_XML As String
    Private _mPublicKey_PEM As String
    Private _mPrivateKey_PEM As String
    Private _mClientId As String 'added by Archie 20220310
    Private _mClientSecret As String
    Private _mMerchantID As String
    Private _mProductCode As String
    Private _mGCASH_PublicKey_PEM As String

#End Region
#Region "Properties Field"
    Public Property _pPublicKey_XML As String
        Get
            Return _mPublicKey_XML
        End Get
        Set(value As String)
            _mPublicKey_XML = value
        End Set
    End Property


    Public Property _pPrivateKey_XML As String
        Get
            Return _mPrivateKey_XML
        End Get
        Set(value As String)
            _mPrivateKey_XML = value
        End Set
    End Property
    Public Property _pPrivateKey_PEM As String
        Get
            Return _mPrivateKey_PEM
        End Get
        Set(value As String)
            _mPrivateKey_PEM = value
        End Set
    End Property
    Public Property _pPublicKey_PEM As String
        Get
            Return _mPublicKey_PEM
        End Get
        Set(value As String)
            _mPublicKey_PEM = value
        End Set
    End Property
    Public Property _pClientId As String
        Get
            Return _mClientId
        End Get
        Set(value As String)
            _mClientId = value
        End Set
    End Property
    Public Property _pClientSecret As String
        Get
            Return _mClientSecret
        End Get
        Set(value As String)
            _mClientSecret = value
        End Set
    End Property
    Public Property _pMerchantID As String
        Get
            Return _mMerchantID
        End Get
        Set(value As String)
            _mMerchantID = value
        End Set
    End Property

    Public Property _pProductCode As String
        Get
            Return _mProductCode
        End Get
        Set(value As String)
            _mProductCode = value
        End Set
    End Property
    Public Property _pGCASH_PublicKey_PEM As String
        Get
            Return _mGCASH_PublicKey_PEM
        End Get
        Set(value As String)
            _mGCASH_PublicKey_PEM = value
        End Set
    End Property
#End Region
#Region "Properties Data"
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property
    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property
    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region


    Public Sub loadcredentials()
        Try
            Dim _nQuery As String

            _nQuery = "SELECT [PublicKey_XML],[PrivateKey_XML],[PublicKey_PEM],[PrivateKey_PEM],[clientId],[clientSecret],[merchantID],[productCode],[GCASH_PublicKey_PEM] FROM GCASH_Credentials"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _mSqlCommand.ExecuteReader()

            Do Until _mSqlDataReader.Read = False
                _pPublicKey_XML = _mSqlDataReader.Item(0).ToString()
                _pPrivateKey_XML = _mSqlDataReader.Item(1).ToString()
                _pPublicKey_PEM = _mSqlDataReader.Item(2).ToString()
                _pPrivateKey_PEM = _mSqlDataReader.Item(3).ToString()
                _pClientId = _mSqlDataReader.Item(4).ToString()
                _pClientSecret = _mSqlDataReader.Item(5).ToString()
                _pMerchantID = _mSqlDataReader.Item(6).ToString()
                _pProductCode = _mSqlDataReader.Item(7).ToString()
                _pGCASH_PublicKey_PEM = _mSqlDataReader.Item(8).ToString()
            Loop

            _mSqlCommand.Dispose()
            _mSqlDataReader.Close()
        Catch ex As Exception

        End Try

    End Sub




    Public Sub Check_OnlinePaymentRefNo(ByVal CheckoutID As String, ByVal RRN As String, ByRef Exists As Boolean, ByVal PaymentChannel As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from OnlinePaymentRefNo where " & _
           " GateWayRefNo='" & CheckoutID & "' " & _
           "  and TXNREFNO='" & RRN & "' " & _
           "  and PaymentChannel='" & PaymentChannel & "' "
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            Exists = 1
                        Loop
                    Else
                        Exists = 0
                    End If
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Insert_Gcash_GetPayment(ByVal _function As String,
                                       ByVal _transacstionID As String,
                                       ByVal _merchantTransId As String,
                                       ByVal _JSON As String,
                                       ByVal _request As String,
                                       ByVal _acquirementStatus As String,
                                       ByVal _signature As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Insert into Gcash_Transactions  values(" & _
                        "'" & _function & "'" & _
                        ",'" & _transacstionID & "'" & _
                        ",'" & _merchantTransId & "'" & _
                        ",'" & _JSON & "'" & _
                        ",'" & _request & "'" & _
                        ",'" & _signature & "'" & _
                        ",'" & _acquirementStatus & "'" & _
                        ",getdate())"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------


            Exit Sub
        Catch ex As Exception

        End Try



    End Sub

    Public Sub Check_GCASH_Transaction(ByVal _Json As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select top 1 * from GCASH_Transactions where " & _
           " JSON='" & _Json & "' " & _
           " order by ctr desc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            Exists = 1
                        Loop
                    Else
                        Exists = 0
                    End If
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try

    End Sub


    Public Sub Insert_PayMaya_GetPayment(ByVal _Json As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Insert into PayMaya_GetPayment values(" & _
                        "'" & _Json & "'" & _
                        ",'" & Insert_GetPayment.id & "'" & _
                        ",'" & Insert_GetPayment.isPaid & "'" & _
                        ",'" & Insert_GetPayment.status & "'" & _
                        ",'" & Insert_GetPayment.amount & "'" & _
                        ",'" & Insert_GetPayment.currency & "'" & _
                        ",'" & Insert_GetPayment.canVoid & "'" & _
                        ",'" & Insert_GetPayment.canRefund & "'" & _
                        ",'" & Insert_GetPayment.canCapture & "'" & _
                        ",'" & Insert_GetPayment.createdAt & "'" & _
                        ",'" & Insert_GetPayment.updatedAt & "'" & _
                        ",'" & Insert_GetPayment.description & "'" & _
                        ",'" & Insert_GetPayment.paymentTokenId & "'" & _
                        ",'" & Insert_GetPayment.fundSource & "'" & _
                        ",'" & Insert_GetPayment.receipt & "'" & _
                        ",'" & Insert_GetPayment.metadata & "'" & _
                        ",'" & Insert_GetPayment.approvalCode & "'" & _
                        ",'" & Insert_GetPayment.receiptNumber & "'" & _
                        ",'" & Insert_GetPayment.requestReferenceNumber & "')"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------


            Exit Sub
        Catch ex As Exception

        End Try



    End Sub
    Public Sub Check_PayMaya_GetPayment(ByVal _Json As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select top 1 * from PayMaya_GetPayment where " & _
           " JSON='" & _Json & "' " & _
           " order by ctr desc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            Exists = 1
                        Loop
                    Else
                        Exists = 0
                    End If
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Check_PayMaya_GetCheckout(ByVal _Json As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select top 1 * from Paymaya_GetCheckout where " & _
           " JSON='" & _Json & "' " & _
           " order by ctr desc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            Exists = 1
                        Loop
                    Else
                        Exists = 0
                    End If
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Update_OnlinePaymentRefno(ByVal TXNREFNO As String, ByVal GateWayRefNo As String, ByVal StatusID As String, ByVal Status As String, ByVal receiptNumber As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update OnlinePaymentRefNo set " & _
                " StatusID='" & StatusID & "'," & _
                " Status='" & Status & "'," & _
                " Security='" & receiptNumber & "'" & _
                " where TXNREFNO='" & TXNREFNO & "'" & _
                " and GateWayRefNo='" & GateWayRefNo & "'"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try

    End Sub
End Class


Public Class Insert_GetPayment
    Public Shared id As String
    Public Shared isPaid As Boolean
    Public Shared status As String
    Public Shared amount As String
    Public Shared currency As String
    Public Shared canVoid As Boolean
    Public Shared canRefund As Boolean
    Public Shared canCapture As Boolean
    Public Shared createdAt As DateTime
    Public Shared updatedAt As DateTime
    Public Shared description As String
    Public Shared paymentTokenId As String
    Public Shared fundSource As String
    Public Shared receipt As String
    Public Shared metadata As String
    Public Shared approvalCode As String
    Public Shared receiptNumber As String
    Public Shared requestReferenceNumber As String
End Class