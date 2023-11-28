

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Web.HttpContext


#End Region

Public Class cDalTransactionHistory

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader


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

#Region "Variables Field"
    Private _mEmail As String
    Private _mTransDate As Date
    Private _mTransNo As String
    Private _mAcctNo As String
    Private _mTransType As String
    Private _mStatus As String
#End Region

#Region "Properties Field"
  
    Public Property _pEmail As String
        Get
            Return _mEmail
        End Get
        Set(value As String)
            _mEmail = value
        End Set
    End Property

    Public Property _pTransDate As Date
        Get
            Return _mTransDate
        End Get
        Set(value As Date)
            _mTransDate = value
        End Set
    End Property
    Public Property _pTransNo As String
        Get
            Return _mTransNo
        End Get
        Set(value As String)
            _mTransNo = value
        End Set
    End Property
    Public Property _pAcctNo As String
        Get
            Return _mAcctNo
        End Get
        Set(value As String)
            _mAcctNo = value
        End Set
    End Property

    Public Property _pTransType As String
        Get
            Return _mTransType
        End Get
        Set(value As String)
            _mTransType = value
        End Set
    End Property
    Public Property _pStatus As String
        Get
            Return _mStatus
        End Get
        Set(value As String)
            _mStatus = value
        End Set
    End Property
 

#End Region

#Region "Properties Field Original"

#End Region

#Region "Routine Command"

    Public Sub _pSubSelectHistory(Email)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
               "SELECT * from [History] where Email='" & Email & "' order by [Date] desc"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try

    End Sub


    Public Sub _pSubInsertHistory(ByVal [ID] As String, _
                                  ByVal [Email] As String, _
                                  ByVal [Module] As String, _
                                  ByVal [Type] As String, _
                                  ByVal [Description] As String, _
                                  ByVal [Particulars] As String, _
                                  ByVal [Status] As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO [dbo].[History] VALUES" & _
           "('" & [ID] & "','" & [Email] & "','" & [Module] & "','" & [Type] & "','" & _
           [Description] & "','" & [Particulars] & "',getdate(),'" & [Status] & "')"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectBUSDETAIL(ByVal Email As String, ByVal BIN As String, ByRef Particulars As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
"select  top 1" & _
"iif ((Select verified from [BUSDETAIL] where ACCTNO='" & BIN & "') = '1'" & _
", (   SELECT 'BIN=' + [ACCTNO]      " & _
"	  +';ORno=' +  [ORNo]   " & _
"	  +';Owner Name=' + [Owner]  " & _
"	  +';Business Name=' + [BUSNAME]   " & _
"	  +';Business Address=' +[BUSADDRESS]     " & _
"	  +';Checked By=' +[VerifiedBy]      " & _
"	  +';Remarks=' +[Remarks]+';' )" & _
",(   SELECT 'BIN=' + [ACCTNO]      " & _
"	  +';ORno=' +  [ORNo]   	" & _
"	  +';Status=' +  Upper([Status])" & _
"	  +';Checked By=' +[VerifiedBy]      " & _
"	  +';Remarks=' +[Remarks]+';' )" & _
") as 'Particulars'  FROM [BUSDETAIL] where ACCTNO='" & BIN & "' and email2='" & Email & "'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        Particulars = _nSqlDr("Particulars").ToString()
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _pSubSelectRPTDETAIL(ByVal Email As String, ByVal TDN As String, ByRef Particulars As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
        " select  top 1" & _
        "    iif ((Select verified from [RPTDETAIL] where tdn='" & TDN & "') = '1'" & _
        "    , ( SELECT 'TDN=' + [TDN]     " & _
        "                   +';ORno=' +  [ORNo]" & _
        "                   +';PIN=' +  [PIN] " & _
        "                   +';Owner Name=' + replace([OwnerName],';',',')" & _
        "                   +';Kind=' + [KIND]" & _
        "                   +';Location=' + replace([LOCATION],';',',') " & _
        "    			   +';Status=' +  Upper([Status])" & _
        "                   +';Checked By=' +[VerifiedBy]  " & _
        "                   +';Remarks=' +[Remarks]+ ';')" & _
        "    ,( SELECT 'TDN=' + [TDN]     " & _
        "                   +';ORno=' +  [ORNo]    " & _
        "    			   +';Status=' +  Upper([Status])" & _
        "                   +';Checked By=' +[VerifiedBy] " & _
        "                   +';Remarks=' +[Remarks]+ ';')" & _
        "    )			 " & _
        "as 'Particulars'  FROM [RPTDETAIL] where tdn='" & TDN & "' and email2='" & Email & "'"

            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        Particulars = _nSqlDr("Particulars").ToString()
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _pSubSelectRPTDETAIL(ByVal Email As String, ByRef Particulars As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
           "   SELECT 'BIN=' + [ACCTNO]        " &
           "      +';ORno=' +  [ORNo]  " &
           "      +';Owner Name=' + [Owner] " &
           "      +';Business Name=' + [BUSNAME]" &
           "      +';Business Address=' +[BUSADDRESS]   " &
           "      +';Checked By=' +[VerifiedBy]   " &
           "      +';Remarks=' +[Remarks] as 'Particulars" &
           " FROM [BUSDETAIL] where email2=" & Email
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        Particulars = _nSqlDr("Particulars").ToString()
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try

    End Sub

#End Region

End Class
