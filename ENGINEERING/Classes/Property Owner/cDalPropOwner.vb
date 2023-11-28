


#Region "Imports"

Imports System.Data.SqlClient

#End Region

Public Class cDalPropOwner


#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String
    Private Shared _mQuery As String = Nothing
    Private Shared _mApplicantType As String
    Private Shared _mPropKind As String
    Public Shared _nSelected As Boolean
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

    Public Shared Property _pPropKind() As String
        Get
            Return _mPropKind
        End Get
        Set(value As String)
            _mPropKind = value
        End Set
    End Property

    Public Shared Property _pApplicantType() As String
        Get
            Return _mApplicantType
        End Get
        Set(value As String)
            _mApplicantType = value
        End Set
    End Property

#End Region

#Region ""
    Private Shared _mFullName As String
#End Region

#Region ""

    Public Shared Property _pFullName() As String
        Get
            Return _mFullName
        End Get
        Set(value As String)
            _mFullName = value
        End Set
    End Property

#End Region


#Region "Routine"


    Public Shared Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCond As String = Nothing, Optional ByRef _nRecCount As Integer = 0, Optional _nPropKind As String = "")
        Try
            If _nColumns = Nothing Then _nColumns = "*"
            Dim _nCondition As String
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            If _nSelected = False Then
                _nCondition = "Where " & _nColumns & " = '" & _nCond & "' AND PropKind = '" & _nPropKind & "'"
                If _nCond = Nothing Then _nCondition = " WHERE PropKind = '" & _nPropKind & "'"
            Else
                _nCondition = _nCond + " AND PropKind = '" & _nPropKind & "'"
            End If

            '----------------------------------    
            _nQuery = "Select * from vw_PropertyOwnerInfo" & _nCondition

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
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region



End Class
