#Region "Imports"

Imports System.Data.SqlClient

#End Region


Public Class cDalEmployees

#Region "Variable Object"
    Private Shared _mDataTable As New DataTable
    Private Shared _mDbCon As SqlConnection

    Dim _mStrSql As String
    Dim _mSqlCmd As SqlCommand
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

    Public Shared Property _pDbCon() As SqlConnection
        Get
            Try
                Return _mDbCon
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mDbCon = value
        End Set
    End Property
#End Region

#Region "Variable Field"
    Private Shared Property _mTitle As String
    Private Shared _mFormTitle As String = Nothing
    Private Shared _mTableName As String = Nothing
#End Region

#Region "Property Field"
    Public Shared Property _pTitle() As String
        Get
            Return _mTitle
        End Get
        Set(value As String)
            _mTitle = value
        End Set
    End Property

    Public Shared Property _pFormTitle() As String
        Get
            Try
                Return _mFormTitle
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As String)
            _mFormTitle = value
        End Set
    End Property

    Public Shared Property _pTableName() As String
        Get
            Try
                Return _mTableName
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As String)
            _mTableName = value
        End Set
    End Property
#End Region


#Region "Routine Data"
    Public Sub _pSubSelect(ByRef _nSuccessful As Boolean, _
                           ByRef _nTotRecCount As Long, _
                           Optional _nCond As String = "", _
                           Optional _nSortBy As String = "", _
                           Optional _nSortMode As Integer = 0
                        )

        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            '_mStrSql = Nothing
            Dim _nStrSql As String = ""
            Dim _nSelectCond As String
            'Dim _nCntQuery As String = Nothing
            Dim _nQuery As String = Nothing
            'Dim _nStartRowIndex As Integer
            '_nStartRowIndex = (_nPageIndex * _nPageSize) + 1

            _nSelectCond = Replace(_nCond, "'", "''")


            _nStrSql = " EXEC [sp_Employees] " & _
                        "@SelectCond = N'" & _nSelectCond & "'" & _
                        ",@Successful = @Successful output " & _
                        ",@ErrMsg = @ErrMsg output  "

            _mSqlCmd = New SqlCommand(_nStrSql, _mDbCon)
            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error Msg
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content with datareader
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                'If _nSqlDr.HasRows Then

                Dim _nDatatable As New DataTable
                _nDatatable.Clear() 'clear datatable content
                _nDatatable.Columns.Clear() 'clear datatable columns

                'Loading Record from datareader to datatable

                _nDatatable.Load(_nSqlDr)
                _mDataTable = _nDatatable
                _nTotRecCount = _nDatatable.Rows.Count
                'End If
            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()
            _nSqlDr.Dispose()
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
