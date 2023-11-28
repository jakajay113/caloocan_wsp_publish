#Region "Imports"
Imports System.Data.SqlClient
#End Region

Public Class cDalGetSpecificValue
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Private Shared _mQuery As String = Nothing
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
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property
#End Region

#Region "Routines"

    Public Shared Function _FnGetSpecificValue(ByVal _nTable As String, ByVal _nField As String, Optional _nCondition As String = Nothing) As String
        _FnGetSpecificValue = Nothing
        Dim _nSubAskHdg As String = ""
        Try

            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing

            '---------------------------------- 
            If _nTable = "GrAskHdg" Then _nSubAskHdg = "AskHdg,"

            _nQuery = "SELECT " & _nSubAskHdg & _nField & " as xResult  FROM " & _nTable & _nCondition
            '----------------------------------   
            _mQuery = _nQuery

            Dim _nDatatable As New DataTable
            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            _nDatatable.Rows.Clear()
            _nDatatable.Load(_nSqlDr)
            _mDataTable = _nDatatable
            'set paramater Success
            '_mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            '_mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            '_mSqlCmd.Parameters.Add("@output", SqlDbType.NVarChar, 2000)
            '_mSqlCmd.Parameters("@output").Direction = ParameterDirection.Output

            'Execute and Read the content
            '    Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '   _mDataTable.Clear()
            '   _nSqlDataAdapter.Fill(_mDataTable)



            '  Using _nSqlDr
            If _mDataTable.Rows.Count <> 0 Then
                'Getting Record using reader
                ' _nSqlDr.Read()
                _FnGetSpecificValue = _mDataTable.Rows(0).Item("xResult").ToString
                ' Loop
            End If
            '   End Using

            _nSqlDr.Dispose()

            If _FnGetSpecificValue <> "" Then Return True
            '----------------------------------

        Catch ex As Exception
            _FnGetSpecificValue = Nothing
        End Try

    End Function

    Public Shared Function _FnGetServerDate() As String
        _FnGetServerDate = Nothing
        Try

            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT GETDATE() as xResult "
            '----------------------------------   
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)
            'set paramater Success
            '_mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            '_mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCmd.Parameters.Add("@output", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@output").Direction = ParameterDirection.Output

            'Execute and Read the content
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)

            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _FnGetServerDate = _nSqlDr.Item("xResult").ToString
                    Loop
                End If
            End Using

            _nSqlDataAdapter.Dispose()

            '----------------------------------

        Catch ex As Exception
            _FnGetServerDate = Nothing
        End Try

    End Function

    Public Shared Function _FnGetRecCount(ByVal _nTable As String, Optional _nCondition As String = Nothing) As Integer
        _FnGetRecCount = Nothing
        Try

            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing

            '----------------------------------    
            _nQuery = _
           " Select COUNT(*) as xResult FROM " & _nTable & " "
            '----------------------------------   
            _mQuery = _nQuery & _nCondition

            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)
            'set paramater Success
            '_mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            '_mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            '_mSqlCmd.Parameters.Add("@output", SqlDbType.NVarChar, 2000)
            '_mSqlCmd.Parameters("@output").Direction = ParameterDirection.Output

            'Execute and Read the content
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '   _mDataTable.Clear()
            '   _nSqlDataAdapter.Fill(_mDataTable)

            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        Return _nSqlDr.Item("xResult").ToString
                    Loop
                End If
            End Using

            _nSqlDataAdapter.Dispose()

            '----------------------------------

        Catch ex As Exception
            _FnGetRecCount = Nothing
        End Try
        Return _FnGetRecCount
    End Function

#End Region



End Class
