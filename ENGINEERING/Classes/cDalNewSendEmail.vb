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
Imports System.Net.Mime

#End Region


Public Class cDalNewSendEmail

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
    Private _mSenderEmailAddress As String
    Private _mSenderEmailPassword As String
    Private _mReceiverEmailAddress As String
    Private _mHost As String
    Private _mPort As String
    Private _mCC As String
    Private _mBCC As String
    Private _mAltEmail As String
    Public Shared _mDatabaseName As String
    Public Shared _mTIMSDatabaseName As String
    Public Shared _mBPDatabaseName As String
    Public Shared _mRPTDatabaseName As String
    Public Shared _mOAIMSDatabaseName As String
    Public Shared _mCRDatabaseName As String
#End Region

#Region "Properties Field"
    Public Property _pSenderEmailAddress() As String
        Get
            Return _mSenderEmailAddress
        End Get
        Set(ByVal value As String)
            _mSenderEmailAddress = value
        End Set
    End Property
    Public Property _pSenderEmailPassword() As String
        Get
            Return _mSenderEmailPassword
        End Get
        Set(ByVal value As String)
            _mSenderEmailPassword = value
        End Set
    End Property
    Public Property _pReceiverEmailAddress() As String
        Get
            Return _mReceiverEmailAddress
        End Get
        Set(ByVal value As String)
            _mReceiverEmailAddress = value
        End Set
    End Property
    Public Property _pHost() As String
        Get
            Return _mHost
        End Get
        Set(ByVal value As String)
            _mHost = value
        End Set
    End Property
    Public Property _pPort() As String
        Get
            Return _mPort
        End Get
        Set(ByVal value As String)
            _mPort = value
        End Set
    End Property

    Public Property _pCC() As String
        Get
            Return _mCC
        End Get
        Set(ByVal value As String)
            _mCC = value
        End Set
    End Property

    Public Property _pBCC() As String
        Get
            Return _mBCC
        End Get
        Set(ByVal value As String)
            _mBCC = value
        End Set
    End Property

    Public Property _pAltEmail() As String
        Get
            Return _mAltEmail
        End Get
        Set(ByVal value As String)
            _mAltEmail = value
        End Set
    End Property

    Public Property _pDatabaseName As String

        Get

            Return _mDatabaseName

        End Get

        Set(ByVal value As String)

            _mDatabaseName = value

        End Set

    End Property
    Public Property _pTIMSDatabaseName As String

        Get

            Return _mTIMSDatabaseName

        End Get

        Set(ByVal value As String)

            _mTIMSDatabaseName = value

        End Set

    End Property
    Public Property _pBPDatabaseName As String

        Get

            Return _mBPDatabaseName

        End Get

        Set(ByVal value As String)

            _mBPDatabaseName = value

        End Set

    End Property
    Public Property _pRPTDatabaseName As String

        Get

            Return _mRPTDatabaseName

        End Get

        Set(ByVal value As String)

            _mRPTDatabaseName = value

        End Set

    End Property
    Public Property _pOAIMSDatabaseName As String

        Get

            Return _mOAIMSDatabaseName

        End Get

        Set(ByVal value As String)

            _mOAIMSDatabaseName = value

        End Set

    End Property
    Public Property _pCRDatabaseName As String

        Get

            Return _mCRDatabaseName

        End Get

        Set(ByVal value As String)

            _mCRDatabaseName = value

        End Set

    End Property

#End Region

#Region "Routine Command"

    Public Sub _pSubSelectGetEmailMaster()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
           "select *,(select AlternateEmail from [" & _mOAIMSDatabaseName & "].[dbo].[Registered] where UserID='" & cSessionUser._pUserID & "') as AlternateEmail from [" & _mCRDatabaseName & "].[dbo].[SetupWebEmailMaster]"

            '   "select * from SetupWebEmailMaster"



            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetEmailMaster()
        Try
            _pSubSelectGetEmailMaster()
            Dim _nDRead As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nDRead
                Dim _iEmailMaster As Integer = .GetOrdinal("EmailAddress")
                Dim _iPassword As Integer = .GetOrdinal("Password")
                Dim _iPort As Integer = .GetOrdinal("Port")
                Dim _iHost As Integer = .GetOrdinal("Host")
                Dim _iCC As Integer = .GetOrdinal("EmailCC")
                Dim _iBCC As Integer = .GetOrdinal("EmailBCC")
                Dim _iAltEmail As Integer = .GetOrdinal("AlternateEmail")
                Dim _nClassReturnTypes As New ClassReturnTypes
                With _nClassReturnTypes
                    If _nDRead.HasRows Then
                        Do While _nDRead.Read
                            _mSenderEmailAddress = (._pReturnString(_nDRead(_iEmailMaster)))
                            _mSenderEmailPassword = (._pReturnString(_nDRead(_iPassword)))
                            _mPort = (._pReturnString(_nDRead(_iPort)))
                            _mHost = (._pReturnString(_nDRead(_iHost)))
                            _mCC = (._pReturnString(_nDRead(_iCC)))
                            _mBCC = (._pReturnString(_nDRead(_iBCC)))
                            _mAltEmail = (._pReturnString(_nDRead(_iAltEmail)))


                        Loop
                    End If
                End With
            End With
            _nDRead.Close()
            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub SendEmail(ByVal ReceiverEmail As String, _
                       ByVal Subject As String, _
                       ByVal Body As String, _
                       ByRef Sent As Boolean)
        Try

            Dim _nClass2 As New cHardwareInformation
            Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
            Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim clr, lguLink, portalLink, LGU As String
            Select Case _nMachineName
                Case "GRACEVILLE"
                    clr = "#CD387C" 'pink
                    lguLink = "https://csjdm.gov.ph/"
                    portalLink = "https://csjdmpermits.spidc.com.ph/"
                    LGU = "CSJDM"
                Case "WEBSVRMANDAUE"
                    clr = "#4D75C1" 'blue
                    lguLink = "https://csjdm.gov.ph/"
                    portalLink = "http://122.53.27.82/"
                    LGU = "Mandaue"
                Case "WEBSVRCALOOCAN"
                    clr = "#F35627" 'orange
                    lguLink = "http://www.caloocancity.gov.ph/"
                    portalLink = "https://online.caloocancity.gov.ph/"
                    LGU = "CALOOCAN"
                Case Else
                    clr = "#4D75C1"
                    lguLink = "https://spidc.com.ph/"
                    portalLink = ""
                    LGU = _nMachineName
            End Select



            Body = "<center style='font-size:x-large;'> " & _
"  <div style='border:2px solid white;background-color:#EAEAEA;font-family:calibri;padding:20px';>" & _
"  <div style='color:black;width:70%'>" & _
"  <h3 style='color:" & clr & "'>" & LGU & " WEB SERVICE PORTAL</h3>" & _
"  <div style='font-size:large;padding:5px;border:2px solid white;color:white;background-color:" & clr & "'>" & _
"  <p><strong>" & _
Subject & _
"  </strong> </p>" & _
"  <div style='text-align:left;padding:10px;background-color:white;color:black;'>" & _
Body & _
"  </div><div></div></div></center>"

            Dim _nclass As New cDalNewSendEmail
            _nclass._pOAIMSDatabaseName = cGlobalConnections._pSqlCxn_OAIMS.Database
            _nclass._pCRDatabaseName = cGlobalConnections._pSqlCxn_CR.Database
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nclass._pSubGetEmailMaster()

            Using mm As New MailMessage(_nclass._pSenderEmailAddress, ReceiverEmail)
                mm.Subject = Subject
                mm.Body = Body

                If _nclass._pBCC <> Nothing Then
                    Dim BlindCarbonCopy As MailAddress = New MailAddress(_nclass._pBCC)
                    mm.Bcc.Add(BlindCarbonCopy)
                End If

                If _nclass._pCC <> Nothing Then
                    Dim CarbonCopy As MailAddress = New MailAddress(_nclass._pCC)
                    mm.CC.Add(CarbonCopy)
                End If

                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient()
                smtp.Host = _nclass._pHost
                smtp.EnableSsl = True
                Dim NetworkCred As New NetworkCredential(_nclass._pSenderEmailAddress, _nclass._pSenderEmailPassword)
                smtp.UseDefaultCredentials = False
                smtp.Credentials = NetworkCred
                smtp.Port = _nclass._pPort
                smtp.Send(mm)
                Sent = True
            End Using
        Catch ex As Exception
            Sent = False
        End Try
    End Sub

    Public Sub _pSubGetDateProcessed(ByRef DateProcessed As String, ByRef strDate As String)
        Try
            '----------------------------------      
            Dim _nQuery As String = "select GETDATE() as 'DateProcessed', (SELECT CONVERT(VARCHAR(6),GETDATE(),12) )as 'strDate'"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader

            Do Until _mSqlDataReader.Read = False
                DateProcessed = (_mSqlDataReader("DateProcessed"))
                strDate = (_mSqlDataReader("strDate"))
            Loop

            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub
    Public Sub _pSubGetAutoFileID(ByRef FileID As String, ByVal strDate As String)
        Try
            '----------------------------------    
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from Documents where strDate =  (SELECT CONVERT(VARCHAR(6),GETDATE(),12))"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()



            Using _nSqlDataReader As SqlDataReader = _nSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _istrDate As Integer = .GetOrdinal("strDate")
                    Dim _ictr As Integer = 1

                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _ictr = _ictr + 1
                            Loop
                            FileID = strDate & "-" & _ictr.ToString().PadLeft(5, "0"c)
                        Else
                            FileID = strDate & "-" & "00001"

                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub SendEmailWithQR(ByVal ReceiverEmail As String, _
                      ByVal Subject As String, _
                      ByVal Body As String, _
                      ByVal imgUrl As String, _
                      ByRef Sent As Boolean)
        Try


            Dim _nClass2 As New cHardwareInformation
            Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
            Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim clr, lguLink, portalLink, LGU As String
            Select Case _nMachineName
                Case "GRACEVILLE"
                    clr = "#CD387C" 'pink
                    lguLink = "https://csjdm.gov.ph/"
                    portalLink = "https://csjdmpermits.spidc.com.ph/"
                    LGU = "CSJDM"
                Case "WEBSVRMANDAUE"
                    clr = "#4D75C1" 'blue
                    lguLink = "https://csjdm.gov.ph/"
                    portalLink = "http://122.53.27.82/"
                    LGU = "Mandaue"
                Case "WEBSVRCALOOCAN"
                    clr = "#F35627" 'orange
                    lguLink = "http://www.caloocancity.gov.ph/"
                    portalLink = "https://online.caloocancity.gov.ph/"
                    LGU = "CALOOCAN"
                Case Else
                    clr = "#4D75C1"
                    lguLink = "https://spidc.com.ph/"
                    portalLink = ""
                    LGU = _nMachineName
            End Select


            Dim iconBytes As Byte() = Convert.FromBase64String(Replace(imgUrl, "data:image/png;base64,", ""))
            Dim iconBitmap As System.IO.MemoryStream = New System.IO.MemoryStream(iconBytes)
            Dim iconResource As LinkedResource = New LinkedResource(iconBitmap, MediaTypeNames.Image.Jpeg)
            iconResource.ContentId = "Icon"

            Dim _nclass As New cDalNewSendEmail
            _nclass._pOAIMSDatabaseName = cGlobalConnections._pSqlCxn_OAIMS.Database
            _nclass._pCRDatabaseName = cGlobalConnections._pSqlCxn_CR.Database
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nclass._pSubGetEmailMaster()

            Using mm As New MailMessage(_nclass._pSenderEmailAddress, ReceiverEmail)
                mm.Subject = Subject

                Body = "<style>.panel1{color:black; width:70%;} @media screen and (max-width: 720px) {.panel1 {width:100%;}}</style>" & _
                    "<center style='font-size:x-large;'> " & _
"  <div style='border:2px solid white;background-color:#EAEAEA;font-family:calibri;padding:20px';>" & _
"  <div class='panel1'>" & _
"  <h3 style='color:" & clr & "'>" & LGU & " WEB SERVICE PORTAL</h3>" & _
"  <div style='font-size:large;padding:5px;border:2px solid white;color:white;background-color:" & clr & "'>" & _
"  <p><strong>" & _
Subject & _
"  </strong> </p>" & _
"  <div style='text-align:left;padding:10px;background-color:white;color:black;'>" & _
"<br><center><img  width='250px' height='250px' src='cid:" & iconResource.ContentId & "'/></center><br>" & _
Body & _
"  </div><div></div></div></center>"
                mm.Body = Body

                Dim alternativeView As AlternateView = AlternateView.CreateAlternateViewFromString(Body, Nothing, MediaTypeNames.Text.Html)
                alternativeView.LinkedResources.Add(iconResource)
                mm.AlternateViews.Add(alternativeView)

                If _nclass._pBCC <> Nothing Then
                    Dim BlindCarbonCopy As MailAddress = New MailAddress(_nclass._pBCC)
                    mm.Bcc.Add(BlindCarbonCopy)
                End If

                If _nclass._pCC <> Nothing Then
                    Dim CarbonCopy As MailAddress = New MailAddress(_nclass._pCC)
                    mm.CC.Add(CarbonCopy)
                End If

                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient()
                smtp.Host = _nclass._pHost
                smtp.EnableSsl = True
                Dim NetworkCred As New NetworkCredential(_nclass._pSenderEmailAddress, _nclass._pSenderEmailPassword)
                smtp.UseDefaultCredentials = False
                smtp.Credentials = NetworkCred
                smtp.Port = _nclass._pPort
                smtp.Send(mm)
                Sent = True
            End Using
        Catch ex As Exception
            Sent = False
        End Try
    End Sub

    Public Sub _pSubInsertDocuments(FileID, BIN_ASSESSNO, EMAIL, FileName, FileType, FileData, FileExt, DateProcessed, Hash, strDate)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO Documents VALUES(@FileID,@BIN_ASSESSNO,@EMAIL,@FileName,@FileType,@FileData,@FileExt,@DateProcessed,@Hash,@strDate)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@FileID", FileID)
                .AddWithValue("@BIN_ASSESSNO", BIN_ASSESSNO)
                .AddWithValue("@EMAIL", EMAIL)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileExt", FileExt)
                .AddWithValue("@DateProcessed", DateProcessed)
                .AddWithValue("@Hash", Hash)
                .AddWithValue("@strDate", strDate)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Function Mail_Body(ByVal imgUrl As String) As AlternateView
        Dim path As String = imgUrl
        Dim Img As LinkedResource = New LinkedResource(path, MediaTypeNames.Image.Jpeg)
        Img.ContentId = "MyImage"
        Dim str As String = " <img src=cid:MyImage  id='img' alt='' width='100px' height='100px'/>"
        Dim AV As AlternateView = AlternateView.CreateAlternateViewFromString(str, Nothing, MediaTypeNames.Text.Html)
        AV.LinkedResources.Add(Img)
        Return AV
    End Function



#End Region
End Class
