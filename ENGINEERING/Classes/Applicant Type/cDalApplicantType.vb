#Region "Imports"

Imports System.Data.SqlClient

#End Region

Public Class cDalApplicantType



#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String
    Private Shared _mQuery As String = Nothing

#End Region

#Region "Variables"
    Private Shared _mApplType As String
#End Region

#Region "Property Object"

#Region "Public Property"
    Public Shared Property _pAppltype As String
        Get
            Return _mApplType
        End Get
        Set(value As String)
            _mApplType = value
        End Set
    End Property
#End Region
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

#Region "Routine"

#End Region
    Public Shared Sub _pSubSelect(ByRef _nSuccessful As Boolean, _
                              Optional _nCondition As String = "", _
                                Optional _nSortField As String = "", _
                                Optional _nSortDesc As Boolean = False
                                 )
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "SELECT * FROM ApplicantType " & _nCondition

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            '_mDataTable.Clear()
            '_nSqlDataAdapter.Fill(_mDataTable)

            'If _mDataTable.Rows.Count > 0 Then
            '    _mdata = True
            'Else
            '    _mdata = False
            'End If

            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

End Class
