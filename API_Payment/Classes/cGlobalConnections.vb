
#Region "Imports"

Imports System.Data.SqlClient
'Imports VS2014.CL.CR.cEventLog
Imports System.Reflection.MethodBase

#End Region

Public Class cGlobalConnections
#Region "Variable"
    Private Shared _mStrCxn_CR As String
    Private Shared _mSqlCxn_CR As New SqlConnection
    Private Shared _mStrCxn_OAIMS As String
    Private Shared _mSqlCxn_OAIMS As New SqlConnection

    Private Shared _mStrCR_ServerName As String
    Private Shared _mStrCR_ID As String
    Private Shared _mStrCR_Pass As String
    Private Shared _mStrCR_DBName As String

#End Region
#Region "Property OAIMS"

    Public Shared ReadOnly Property _pStrCxn_OAIMS() As String
        Get
            Return _mSubGetConnectionString("OAIMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_OAIMS() As SqlConnection
        Get
            Try

                If _mSqlCxn_OAIMS.State = ConnectionState.Closed Then
                    _mSqlCxn_OAIMS.ConnectionString = _pStrCxn_OAIMS
                    _mSqlCxn_OAIMS.Open()
                End If

                Return _mSqlCxn_OAIMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property
#End Region


#Region "Routine"
    
    
    Private Shared Function _mSubGetConnectionString(_nCode As String)
        Try
            '----------------------------------

            Dim _nConnectionString As String = Nothing

            Dim _nClass As New cDalGlobalConnectionsDefault

            Select Case System.Environment.MachineName
                Case "HAVANA"
                    _nConnectionString =
                    "Data Source=HAVANA\MSSQL2019" & _
                    ";Initial Catalog=SOS_OAIMS_CAINTA" & _
                    ";User ID=sa" & _
                    ";Password=P@ssw0rd" & _
                    ";MultipleActiveResultSets=True"

                Case "WEBSVRCALOOCAN"
                    Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                    If curr_url.ToUpper.Contains("TEST") = True Then
                        _nConnectionString =
                        "Data Source=WEBSVRCALOOCAN\MSSQL2014" & _
                        ";Initial Catalog=SOS_OAIMS_CALOOCAN_WEB_TEST" & _
                        ";User ID=sa" & _
                        ";Password=P@ssw0rd" & _
                        ";MultipleActiveResultSets=True"
                    Else
                        _nConnectionString =
                        "Data Source=WEBSVRCALOOCAN\MSSQL2014" & _
                        ";Initial Catalog=SOS_OAIMS_CALOOCAN" & _
                        ";User ID=sa" & _
                        ";Password=P@ssw0rd" & _
                        ";MultipleActiveResultSets=True"
                    End If
                Case Else
                    _nConnectionString =
                    "Data Source=HAVANA\MSSQL2019" & _
                    ";Initial Catalog=SOS_OAIMS_CAINTA" & _
                    ";User ID=sa" & _
                    ";Password=P@ssw0rd" & _
                    ";MultipleActiveResultSets=True"

            End Select
            Return _nConnectionString
            '----------------------------------
        Catch ex As Exception
            ''_pSubEventLog(ex, 2)
            Return Nothing
        End Try
    End Function
#End Region

End Class