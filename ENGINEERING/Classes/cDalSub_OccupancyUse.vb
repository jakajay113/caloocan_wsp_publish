#Region "Imports"

Imports System.Data.SqlClient

#End Region
Public Class cDalSub_OccupancyUse
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String
    Private Shared _mQuery As String = Nothing
    Private Shared _mTableName As String = ""


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

    Public Shared Property _pTableName() As String
        Get
            Return _mTableName
        End Get
        Set(value As String)
            _mTableName = value
        End Set
    End Property

#End Region

#Region "Variable Field"

    Private Shared _mCode As String = Nothing

#End Region

#Region "Routine"



    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            If _nCondition <> "" Then
                _nCondition = " Where Occ_Code = '" & _nCondition & "'"
            End If
            '----------------------------------    
            _nQuery = "Select * from " & cDalSub_OccupancyUse._pTableName & "" & _nCondition & " order by Desc2 asc"

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCmd.Parameters


            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
            _mDataTable.Rows.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)
            _nRecCount = _mDataTable.Rows.Count
            _mSqlCmd.Dispose()
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception
            MsgBox("Error")

        End Try
    End Sub
#End Region
End Class
