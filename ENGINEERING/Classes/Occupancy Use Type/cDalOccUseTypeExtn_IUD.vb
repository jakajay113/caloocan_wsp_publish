#Region "Imports"
Imports System.Data.SqlClient
#End Region

Public Class cDalOccUseTypeExtn_IUD

#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Private Shared _mQuery As String = ""

#End Region

#Region "Property Object"
    Public Shared ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                Return _mDataTable
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public Shared Property _pSqlCon() As SqlConnection
        Get
            Try
                Return _mSqlCon
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
#End Region

#Region "Variables"
    Private Shared _mAdd As Boolean = False

#End Region

#Region "Variable Field"

    Private Shared _mCode As String
    Private Shared _mPermitCode As String
    Private Shared _mAppNo As String
    Private Shared _mRemarks As String
    Private Shared _mDateProposed As String
    Private Shared _mEstimatedCost As String
    Private Shared _mExpectedDate As String
    Private Shared _mPreparedBy As String

#End Region

#Region "Property Field"

    Public Shared Property _pPreparedBy() As String
        Get
            Return _mPreparedBy
        End Get
        Set(value As String)
            _mPreparedBy = value
        End Set
    End Property

    Public Shared Property _pExpectedDate() As String
        Get
            Return _mExpectedDate
        End Get
        Set(value As String)
            _mExpectedDate = value
        End Set
    End Property

    Public Shared Property _pEstimatedCost() As String
        Get
            Return _mEstimatedCost
        End Get
        Set(value As String)
            _mEstimatedCost = value
        End Set
    End Property

    Public Shared Property _pDateProposed() As String
        Get
            Return _mDateProposed
        End Get
        Set(value As String)
            _mDateProposed = value
        End Set
    End Property

    Public Shared Property _pCode() As String
        Get
            Return _mCode
        End Get
        Set(value As String)
            _mCode = value
        End Set
    End Property

    Public Shared Property _pPermitCode() As String
        Get
            Return _mPermitCode
        End Get
        Set(value As String)
            _mPermitCode = value
        End Set
    End Property

    Public Shared Property _pAppNo() As String
        Get
            Return _mAppNo
        End Get
        Set(value As String)
            _mAppNo = value
        End Set
    End Property


    Public Shared Property _pRemarks() As String
        Get
            Return _mRemarks
        End Get
        Set(value As String)
            _mRemarks = value
        End Set
    End Property

#End Region

    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "Select " & _nColumns & " from occupancyusetypeextn " & _nCondition

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
            _mDataTable.Rows.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)
            _mSqlCmd.Dispose()
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pLoad(ByRef _nSuccessful As Boolean, ByVal _nCondition As String)
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "EXEC [sp_OccupancyUseTypeExtn_IUD] " & _
                            "@Action = 'SELECT' " & _
                            ",@SelectCond = N'" & _nSelectCond & "' " & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "


            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)
            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _mAppNo = _nSqlDr.Item("AppNo").ToString
                        _mCode = _nSqlDr.Item("Code").ToString
                        _mPermitCode = _nSqlDr.Item("PermitCode").ToString
                        _mRemarks = _nSqlDr.Item("Remarks").ToString
                    Loop
                End If
            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value
            _mSqlCmd.Dispose()

        Catch ex As Exception
            _nSuccessful = False
        End Try
    End Sub



#Region "Routine Data"
    Public Shared Sub _pAdd()
        Try
            _mAdd = True
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pEdit()
        Try
            _mAdd = False
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pSave(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            If _mAdd Then
                _nStrSql = "EXEC [sp_OccupancyUseTypeExtn_IUD] " & _
                            "@Action = 'INSERT' " & _
                            ",@Appno = N'" & _mAppNo & "'" & _
                            ",@Code = N'" & _mCode & "'" & _
                            ",@DateProposed = N'" & _mDateProposed & "'" & _
                            ",@EstimatedCost = N'" & _mEstimatedCost & "'" & _
                            ",@ExpectedDate = N'" & _mExpectedDate & "'" & _
                            ",@PermitCode = N'" & _mPermitCode & "'" & _
                            ",@PreparedBy = N'" & _mPreparedBy & "'" & _
                            ",@Remarks = N'" & _mRemarks & "'" & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "

            Else

                _nStrSql = "EXEC [sp_OccupancyUseTypeExtn_IUD] " & _
                            "@Action = 'UPDATE' " & _
                            ",@SelectCond = N'" & _nSelectCond & "'" & _
                            ",@Appno = N'" & _mAppNo & "'" & _
                            ",@Code = N'" & _mCode & "'" & _
                            ",@DateProposed = N'" & _mDateProposed & "'" & _
                            ",@EstimatedCost = N'" & _mEstimatedCost & "'" & _
                            ",@ExpectedDate = N'" & _mExpectedDate & "'" & _
                            ",@PermitCode = N'" & _mPermitCode & "'" & _
                            ",@PreparedBy = N'" & _mPreparedBy & "'" & _
                            ",@Remarks = N'" & _mRemarks & "'" & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "
            End If
            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content
            Using _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()
            _mAdd = False
        Catch ex As Exception
            _nSuccessful = False
        End Try
    End Sub

    Public Shared Sub _pDelete(ByRef _nSuccessful As Boolean, ByVal _nCondition As String)
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "EXEC [sp_OccupancyUseTypeExtn_IUD] " & _
                            "@Action = 'DELETE' " & _
                            ",@SelectCond = N'" & _nSelectCond & "'" & _
                            ",@Successful = @Successful output " & _
                            ",@ErrMsg = @ErrMsg output  "

            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute the Stored proc
            _mSqlCmd.ExecuteNonQuery()

            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()
            _mAdd = False
        Catch ex As Exception
            _nSuccessful = False
        End Try
    End Sub

#End Region


End Class
