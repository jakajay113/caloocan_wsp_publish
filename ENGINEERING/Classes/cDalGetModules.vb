#Region "Imports"
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Mail
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region


Public Class cDalGetModules

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
    Private _mModuleID As String
    Private _mModuleName As String
    Private _mModuleFor As String
    Private _mUserLevel As String
    Private _mModuleStatus As String
#End Region

#Region "Properties Field"
    Public Property _pModuleID() As String
        Get
            Return _mModuleID
        End Get
        Set(ByVal value As String)
            _mModuleID = value
        End Set
    End Property
    Public Property _pModuleName() As String
        Get
            Return _mModuleName
        End Get
        Set(ByVal value As String)
            _mModuleName = value
        End Set
    End Property
    Public Property _pModuleFor() As String
        Get
            Return _mModuleFor
        End Get
        Set(ByVal value As String)
            _mModuleFor = value
        End Set
    End Property
    Public Property _pHUserLevel() As String
        Get
            Return _mUserLevel
        End Get
        Set(ByVal value As String)
            _mUserLevel = value
        End Set
    End Property
    Public Property _pModuleStatus() As String
        Get
            Return _mModuleStatus
        End Get
        Set(ByVal value As String)
            _mModuleStatus = value
        End Set
    End Property


#End Region

#Region "Routine Command"

    Public Sub _pSubGetAvailableModules(ByVal UserType As String, ByVal UserLevel As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
           "select * from ModuleSetup where ModuleFor='" & UserType & "' and ModuleStatus = 1"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    ' Public Sub _pSubGetEmailMaster()
    '     Try
    '         _pSubSelectGetEmailMaster()
    '         Dim _nDRead As SqlDataReader = _mSqlCommand.ExecuteReader
    '         With _nDRead
    '             Dim _iEmailMaster As Integer = .GetOrdinal("EmailAddress")
    '             Dim _iPassword As Integer = .GetOrdinal("Password")
    '             Dim _iPort As Integer = .GetOrdinal("Port")
    '             Dim _iHost As Integer = .GetOrdinal("Host")
    '             Dim _iCC As Integer = .GetOrdinal("EmailCC")
    '             Dim _iBCC As Integer = .GetOrdinal("EmailBCC")
    '             Dim _iAltEmail As Integer = .GetOrdinal("AlternateEmail")
    '             Dim _nClassReturnTypes As New ClassReturnTypes
    '             With _nClassReturnTypes
    '                 If _nDRead.HasRows Then
    '                     Do While _nDRead.Read
    '                         _mSenderEmailAddress = (._pReturnString(_nDRead(_iEmailMaster)))
    '                         _mSenderEmailPassword = (._pReturnString(_nDRead(_iPassword)))
    '                         _mPort = (._pReturnString(_nDRead(_iPort)))
    '                         _mHost = (._pReturnString(_nDRead(_iHost)))
    '                         _mCC = (._pReturnString(_nDRead(_iCC)))
    '                         _mBCC = (._pReturnString(_nDRead(_iBCC)))
    '                         _mAltEmail = (._pReturnString(_nDRead(_iAltEmail)))
    '
    '
    '                     Loop
    '                 End If
    '             End With
    '         End With
    '         _nDRead.Close()
    '         _mSqlCommand.Dispose()
    '     Catch ex As Exception
    '
    '     End Try
    ' End Sub

  

#End Region
End Class
