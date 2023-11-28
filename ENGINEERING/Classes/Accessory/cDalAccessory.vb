Imports System.Data.SqlClient

Public Class cDalAccessory
#Region "Variable Object"

    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlConTemp As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String
    Private Shared _mQuery As String = Nothing
    Private Shared _mCondition As String = Nothing
    Private Shared _mSwitchName As String = Nothing
#End Region
#Region "Variable Field"


    Private Shared _mAdd As Boolean
    Private Shared _mCode As String
    Private Shared _mDesc1 As String
    Private Shared _mDesc2 As String
    Private Shared _mLinkCode As String
    Private Shared _mEffective_from As String
    Private Shared _mEffective_until As String
    Private Shared _morder As String
    Private Shared _mcolumn As String
    Private Shared _mEncoder As String
    Private Shared _mDateEncoded As String

#End Region

#Region "Property Field"
    Public Shared Property _pCode() As String
        Get
            Return _mCode
        End Get
        Set(value As String)
            _mCode = value
        End Set
    End Property

    Public Shared Property _pDesc1() As String
        Get
            Return _mDesc1
        End Get
        Set(value As String)
            _mDesc1 = value
        End Set
    End Property


    Public Shared Property _pDesc2() As String
        Get
            Return _mDesc2
        End Get
        Set(value As String)
            _mDesc2 = value
        End Set
    End Property

    Public Shared Property _PLinkCode() As String
        Get
            Return _mLinkCode
        End Get
        Set(value As String)
            _mLinkCode = value
        End Set
    End Property

    Public Shared Property _PEffective_from() As String
        Get
            Return _mEffective_from
        End Get
        Set(value As String)
            _mEffective_from = value
        End Set
    End Property

    Public Shared Property _PEffective_until() As String
        Get
            Return _mEffective_until
        End Get
        Set(value As String)
            _mEffective_until = value
        End Set
    End Property

    Public Shared Property _porder() As String
        Get
            Return _morder
        End Get
        Set(value As String)
            _morder = value
        End Set
    End Property

    Public Shared Property _pcolumn() As String
        Get
            Return _mcolumn
        End Get
        Set(value As String)
            _mcolumn = value
        End Set
    End Property

    Public Shared Property _pEncoder() As String
        Get
            Return _mEncoder
        End Get
        Set(value As String)
            _mEncoder = value
        End Set
    End Property

    Public Shared Property _pDateEncoded() As String
        Get
            Return _mDateEncoded
        End Get
        Set(value As String)
            _mDateEncoded = value
        End Set
    End Property


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

    Public Shared Property _pSqlConTemp() As SqlConnection
        Get
            Try
                Return _mSqlConTemp
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlConTemp = value
        End Set
    End Property

    Public Shared Property _pQuery() As String
        Get
            Return _mQuery
        End Get
        Set(value As String)
            _mQuery = value
        End Set
    End Property

    Public Shared Property _pCondition() As String
        Get
            Return _mCondition
        End Get
        Set(value As String)
            _mCondition = value
        End Set
    End Property
#End Region

#Region "Routine"

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

    Public Shared Property _pSwitchName() As String
        Get
            Return _mSwitchName
        End Get
        Set(value As String)
            _mSwitchName = value
        End Set
    End Property

    Public Shared Sub _pSubSelect(ByVal _nTableName As String, Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            If _nColumns = "" Then _nColumns = "*"
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    

            _mCondition = IIf(_nCondition = "", "", _nCondition)


            _mQuery = "Select * from J_Division2Code " & _mCondition & " order by Division"

            '----------------------------------
            '_mQuery = _nQuery


            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataReader As SqlDataReader = _mSqlCmd.ExecuteReader
            Dim _nDatatable As New DataTable

            _nDatatable.Clear()
            _nDatatable.Load(_nSqlDataReader)
            _mDataTable = _nDatatable

            _nSqlDataReader.Dispose()
            _mSqlCmd.Dispose()
            _nRecCount = _mDataTable.Rows.Count
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region
End Class
