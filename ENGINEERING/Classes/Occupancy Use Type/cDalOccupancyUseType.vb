#Region "Imports"

Imports System.Data.SqlClient

#End Region


Public Class cDalOccupancyUseType
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable



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
            Dim i = 0
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            'Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            _nSelectCond = Replace(_nCondition, "'", "''")
            Dim _mStrSql As String
            _mStrSql = " EXEC [sp_OccupancyUseType_IUD] " & _
                        " @Action = 'SELECT' " & _
                        " ,@SelectCond = N'" & _nSelectCond & "'" & _
                        " ,@SelectField='' " & _
                        " ,@Successful = @Successful output " & _
                        " ,@ErrMsg = @ErrMsg output,@Code = @Code "

            _mSqlCmd = New SqlCommand(_mStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error Msg
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            _mSqlCmd.Parameters.Add("@Code", SqlDbType.NVarChar, 50)
            _mSqlCmd.Parameters("@Code").Direction = ParameterDirection.Output

            'Execute and Read the content with datareader
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then

                    _mDataTable.Clear() 'clear datatable content
                    _mDataTable.Columns.Clear() 'clear datatable columns

                    'Loading Record from datareader to datatable
                    _mDataTable.Load(_nSqlDr)
                    Dim _nRowNum As Integer = 0

                    While _mDataTable.Rows.Count >= i
                        If IsDBNull(_mDataTable.Rows(i).Item("Desc1")) Then
                            _mCode = ""
                        Else
                            _mCode = _mDataTable.Rows(i).Item("Desc1")
                        End If
                        i += 1
                    End While

                End If
            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value
            _nSqlDr.Dispose()
            _mSqlCmd.Dispose()
            _nSqlDr.Close()


        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class
