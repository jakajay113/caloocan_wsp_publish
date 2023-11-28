#Region "Imports"

Imports System.Data.SqlClient

#End Region


Public Class cDalOccupancyUse
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable

    Private Shared _mDataTableDisp As New DataTable
    Private Shared _mDataTableSign As New DataTable
    Private Shared _mDataTableInst As New DataTable

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
    Public Shared ReadOnly Property _pDataTableDisp() As DataTable
        Get
            Try
                Return _mDataTableDisp
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property _pDataTableSign() As DataTable
        Get
            Try
                Return _mDataTableSign
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property _pDataTableInst() As DataTable
        Get
            Try
                Return _mDataTableInst
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region

#Region "Variable Field"

    Private Shared _mCode As String
    Private Shared _mDescription As String
    Private Shared _mLinkCode As String

#End Region

#Region "Routine"

    Public Shared Sub _pSubSelect(ByRef _nSuccessful As Boolean, _
                              Optional _nCondition As String = "", _
                                Optional _nSortField As String = "", _
                                Optional _nSortDesc As Boolean = False
                        )

        Try

            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            'Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            Dim _mStrSql As String
            _mStrSql = "EXEC [sp_OccupancyUse_IUD] " & _
                        "@Action = 'SELECT' " & _
                        ",@SelectCond = N'" & _nSelectCond & "'" & _
                        ",@Successful = @Successful output " & _
                        ",@ErrMsg = @ErrMsg output,@Code=@Code "

            _mSqlCmd = New SqlCommand(_mStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error Msg
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output
            'set paramater Error Msg
            _mSqlCmd.Parameters.Add("@Code", SqlDbType.NVarChar, 50)
            _mSqlCmd.Parameters("@Code").Direction = ParameterDirection.Output

            'Execute and Read the content with datareader
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then

                    _mDataTableDisp.Clear() 'clear datatable content
                    _mDataTableDisp.Columns.Clear() 'clear datatable columns

                    'Loading Record from datareader to datatable
                    _mDataTableDisp.Load(_nSqlDr)
                    Dim _nRowNum As Integer = 0

                    If _mDataTableDisp.Rows.Count > 0 Then
                        If IsDBNull(_mDataTableDisp.Rows(0).Item("Desc1")) Then
                            _mCode = ""
                        Else
                            _mCode = _mDataTableDisp.Rows(0).Item("Desc1")
                        End If

                    End If

                End If
            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()


        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pLoad(ByRef _nSuccessful As Boolean, _
                          Optional _nCondition As String = "", _
                            Optional _nSortField As String = "", _
                            Optional _nSortDesc As Boolean = False
                    )

        Try

            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            'Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            Dim _mStrSql As String
            _mStrSql = "EXEC [sp_OccupancyUse_IUD] " & _
                        "@Action = 'SELECT' " & _
                        ",@SelectCond = N'" & _nSelectCond & "'" & _
                        ",@Successful = @Successful output " & _
                        ",@ErrMsg = @ErrMsg output,@Code=@Code "

            _mSqlCmd = New SqlCommand(_mStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error Msg
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output
            'set paramater Error Msg
            _mSqlCmd.Parameters.Add("@Code", SqlDbType.NVarChar, 50)
            _mSqlCmd.Parameters("@Code").Direction = ParameterDirection.Output

            'Execute and Read the content with datareader
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then

                    _mDataTableSign.Clear() 'clear datatable content
                    _mDataTableSign.Columns.Clear() 'clear datatable columns

                    'Loading Record from datareader to datatable
                    _mDataTableSign.Load(_nSqlDr)
                    Dim _nRowNum As Integer = 0

                    If _mDataTableSign.Rows.Count > 0 Then
                        If IsDBNull(_mDataTableSign.Rows(0).Item("Desc1")) Then
                            _mCode = ""
                        Else
                            _mCode = _mDataTableSign.Rows(0).Item("Desc1")
                        End If

                    End If

                End If
            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()


        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pSubLoad(ByRef _nSuccessful As Boolean, _
                      Optional _nCondition As String = "", _
                        Optional _nSortField As String = "", _
                        Optional _nSortDesc As Boolean = False
                )

        Try

            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            'Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            Dim _mStrSql As String
            _mStrSql = "EXEC [sp_OccupancyUse_IUD] " & _
                        "@Action = 'SELECT' " & _
                        ",@SelectCond = N'" & _nSelectCond & "'" & _
                        ",@Successful = @Successful output " & _
                        ",@ErrMsg = @ErrMsg output,@Code=@Code "

            _mSqlCmd = New SqlCommand(_mStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error Msg
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output
            'set paramater Error Msg
            _mSqlCmd.Parameters.Add("@Code", SqlDbType.NVarChar, 50)
            _mSqlCmd.Parameters("@Code").Direction = ParameterDirection.Output

            'Execute and Read the content with datareader
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then

                    _mDataTableInst.Clear() 'clear datatable content
                    _mDataTableInst.Columns.Clear() 'clear datatable columns

                    'Loading Record from datareader to datatable
                    _mDataTableInst.Load(_nSqlDr)
                    Dim _nRowNum As Integer = 0

                    If _mDataTableInst.Rows.Count > 0 Then
                        If IsDBNull(_mDataTableInst.Rows(0).Item("Desc1")) Then
                            _mCode = ""
                        Else
                            _mCode = _mDataTableInst.Rows(0).Item("Desc1")
                        End If

                    End If

                End If
            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()


        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class
