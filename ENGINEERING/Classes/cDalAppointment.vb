

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Web.HttpContext

#End Region

Public Class cDalAppointment

#Region "Variables Data"

    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mSqlDataReader As SqlDataReader
    Public Shared _mCertType As String
    Public Shared _mDataTable As DataTable
    Public Shared _mDepartment As String
    Public Shared _mDepartmentAbbrev As String
    Public Shared _mTransType As String
    Public Shared _mPurpose As String



    Private _mDataSet As DataSet
    Private Shared _mDbCon As New SqlConnection
    Public Shared _mSqlCon As SqlConnection

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

    Public ReadOnly Property _pDataSet() As DataSet
        Get
            Try
                '----------------------------------

                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataSet = New DataSet
                _nSqlDataAdapter.Fill(_mDataSet)
                Return _mDataSet
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
    Private _mEventID As String
    Private _mEventTime As String
   


    Private Const _sscPrefix As String = "cDalAppointment."
    Private Const _sscFile001 As String = _sscPrefix & "_sscFile001"
    Private Const _sscFile002 As String = _sscPrefix & "_sscFile002"
    Private Const _sscFile003 As String = _sscPrefix & "_sscFile003"
    Private Const _sscFile004 As String = _sscPrefix & "_sscFile004"
    Private Const _sscFile005 As String = _sscPrefix & "_sscFile005"
    Private Const _sscModuleID As String = _sscPrefix & "_sscModuleID"


#End Region

#Region "Properties Field"

    Shared Property _pModuleID() As String
        Get
            Return Current.Session(_sscModuleID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscModuleID) = value
        End Set
    End Property
    Shared Property _pFile001() As String
        Get
            Return Current.Session(_sscFile001)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile001) = value
        End Set
    End Property

    Shared Property _pFile002() As String
        Get
            Return Current.Session(_sscFile002)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile002) = value
        End Set
    End Property

    Shared Property _pFile003() As String
        Get
            Return Current.Session(_sscFile003)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile003) = value
        End Set
    End Property

    Shared Property _pFile004() As String
        Get
            Return Current.Session(_sscFile004)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile004) = value
        End Set
    End Property

    Shared Property _pFile005() As String
        Get
            Return Current.Session(_sscFile005)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile005) = value
        End Set
    End Property
    Public Property _pEventID As String
        Get
            Return _mEventID
        End Get
        Set(value As String)
            _mEventID = value
        End Set
    End Property

    Public Property _pEventTime As String
        Get
            Return _mEventTime
        End Get
        Set(value As String)
            _mEventTime = value
        End Set
    End Property

#End Region

#Region "Properties Field Original"

#End Region

#Region "Routine Command"

    Public Sub _pSubInsertAttachFiles(Email, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType, ReqDesc, Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO Attachment VALUES(@Email,@RefNo,@ModuleID,@AcctID,@SeqID,@FileData,@FileName,@FileType,@ReqDesc,@Office)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Email", Email)
                .AddWithValue("@RefNo", RefNo)
                .AddWithValue("@ModuleID", ModuleID)
                .AddWithValue("@AcctID", AcctID)
                .AddWithValue("@SeqID", SeqID)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
                .AddWithValue("@ReqDesc", ReqDesc)
                .AddWithValue("@Office", Office)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertAAppointment(dateFrom, dateTo, dateTime, Department, Beg_AM_Slot, AM_Slot, Beg_PM_Slot, PM_Slot, DayCondition)
        Try
            Dim _nQuery As String = Nothing
            Dim where As String = Nothing
            _nQuery = "" & _
                " DECLARE" & _
                " @FirstDateOfYear DATETIME," & _
                " @LastDateOfYear DATETIME " & _
                " SELECT @FirstDateOfYear = dateadd(d,-1,'" & dateFrom & "')                                                                                                     " & _
                " SELECT @LastDateOfYear = dateadd(d,1,'" & dateTo & "')                                                                                                      " & _
                " ;WITH cte AS (                                                                                                                                 " & _
                " SELECT 1 AS DayID,                                                                                                                             " & _
                " @FirstDateOfYear AS FromDate,                                                                                                                  " & _
                " DATENAME(dw, @FirstDateOfYear) AS Dayname                                                                                                      " & _
                " UNION ALL                                                                                                                                      " & _
                " SELECT cte.DayID + 1 AS DayID,                                                                                                                 " & _
                " DATEADD(d, 1 ,cte.FromDate),                                                                                                                   " & _
                " DATENAME(dw, DATEADD(d, 1 ,cte.FromDate)) AS Dayname                                                                                           " & _
                " FROM cte                                                                                                                                       " & _
                " WHERE DATEADD(d,1,cte.FromDate) < @LastDateOfYear                                                                                              " & _
                " )                                                                                                                                              " & _
                " Insert into AppointmentSlot                                                                                                                    " & _
                " SELECT  FromDate as AppDate,'" & Beg_AM_Slot & "' as Beg_AM_Slot,'" & AM_Slot & "' as AM_Slot,'" & Beg_PM_Slot & "' as Beg_PM_Slot,'" & PM_Slot & "' as PM_Slot, '#5070DA' as Color,'" & Department & "' as Office           " & _
                " FROM CTE  " & _
                " WHERE FromDate not IN (select AppDate from AppointmentSlot where Office = '" & Department & "')"
            Select Case DayCondition
                Case "on"
                    'do nothing
                Case Else
                    where = " and DayName not IN ('Saturday','Sunday')"
            End Select
        
            Dim _nSqlCommand As New SqlCommand(_nQuery & where, _mSqlCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

  
    Public Sub _pSubUpdateAttachFiles(Email, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update Attachment SET FileData = @FileData, FileName = @FileName, FileType = @FileType " & _
                      " where Email=@Email and ModuleID=@ModuleID and AcctID=@AcctID and SeqID=@SeqID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Email", Email)
                .AddWithValue("@RefNo", RefNo)
                .AddWithValue("@ModuleID", ModuleID)
                .AddWithValue("@AcctID", AcctID)
                .AddWithValue("@SeqID", SeqID)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateAttachRefNo(Email, RefNo, ModuleID, AcctID, AppDate, Slot)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update Attachment SET RefNo = '" & RefNo & "' " & _
                ",ModuleID='" & ModuleID & "' " & _
                " where Email='" & Email & "' and AcctID='" & AcctID & "' and " & _
                " [RefNo]='-00001' and  [ModuleID]=''"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)


            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateAppointmentCode(Email, Code)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update Appointment SET CodeUsed = 1 " & _
                " where Email='" & Email & "' and Code='" & Code & "' 
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetDepartment()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Department] "
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetDepartmentAppointmentType()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Department]"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetEnrolledAccounts(ByVal Department As String, ByRef Enrolled_Accounts As Integer)
        Try
            Dim _nQuery As String = Nothing
            Select Case Department
                Case "BPLO"
                    _nQuery = " SELECT COUNT(*) AS CTR from [BUSDETAIL] where EMAIL2='" & cSessionUser._pUserID & "' AND VERIFIED = 1  "

                Case "CAO"
                    _nQuery = " SELECT COUNT(*) AS CTR  from [RPTDETAIL] where EMAIL2='" & cSessionUser._pUserID & "' AND VERIFIED = 1 "

            End Select

            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        Enrolled_Accounts = _nSqlDr("CTR").ToString()
                    Loop
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetCodeParameters(ByVal Code As String, ByRef isValid As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Appointment] where Code='" & Code & "' and email='" & cSessionUser._pUserID & "' and CodeUsed=0"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        cDalAppointment._mDepartment = _nSqlDr("Office").ToString()
                        cDalAppointment._mTransType = _nSqlDr("TransType").ToString()
                        cDalAppointment._mPurpose = _nSqlDr("Purpose").ToString()
                        isValid = True
                    Loop
                Else
                    isValid = False
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetDepartmentAppointment()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Department] where Usertype in (select OFfice from [AppointmentSlot]  where AppDate >= getdate())"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetRequirements(Department)
        Try
            Dim _nQuery As String = Nothing
            ' _nQuery = " SELECT Type,(Header + Body + footer) as Content from [AppointmentRequirements] where Department = '" & Department & "' order by Type asc"
            ' _nQuery = "SELECT Type,(Header + Body + isnull(Footer,''))  as Content ,case when [type]='Others' then 2 else 1 end WWW  FROM [AppointmentRequirements] where Department = '" & Department & "' and Availability = 1  order by www,[type]"

            _nQuery = "" & _
"Select [Type]," & _
"    case when (select count(*) from appointment where [Email] = '" & cSessionUser._pUserID & "' and [AppDate] >= getdate() and [TransType]=[AppointmentRequirements].Type) > 0 " & _
"  		then   " & _
"			case when" & _
"                  [Type] = [AppointmentRequirements].[Type]" & _
"			then" & _
"				(Header + Body + isnull(Footer,'') + " & _
"                  '<div style=""background-color:lightgray;padding:5px;text-align:center"">" & _
"					<h4 style=""color:red"">You still have PENDING Appointment</h4>" & _
"					<center>" & _
"					<table style=""text-align:justify;border:solid black 1px;background-color:white"">" & _
"					<tr><td>Office </td><td> : </td><td>BPLO</td></tr>" & _
"					<tr><td>Transaction Type </td><td> : </td><td>'" & _
"						+[AppointmentRequirements].Type+'</td></tr>" & _
"					<tr><td>Appointment ID </td><td> : </td><td>" & _
"                  '+(SELECT AppID FROM [Appointment] where AppDate >= getdate() and Email='" & cSessionUser._pUserID & "'and status='PENDING')+'" & _
"					</td></tr>" & _
"					<tr><td>Appointment Date </td><td> : </td><td>" & _
"                  '+ CAST((SELECT AppDate FROM [Appointment] where AppDate >= getdate() and Email='" & cSessionUser._pUserID & "' and status='PENDING') as nvarchar(MAX))+'" & _
"					</td></tr>" & _
"					<tr><td>Appointment Time </td><td> : </td><td>" & _
"                  '+(SELECT Slot FROM [Appointment] where AppDate >= getdate() and Email='" & cSessionUser._pUserID & "'and status='PENDING')+'" & _
"					</td></tr>" & _
"					</table>" & _
"					</center>" & _
"					</div>') " & _
"			else	" & _
"				(Header + Body + isnull(Footer,''))" & _
"                  End" & _
"			else " & _
"			(Header + Body + isnull(Footer,''))" & _
"  end Content" & _
"                  FROM [AppointmentRequirements]" & _
"  where Department = '" & Department & "' and Availability = 1  order by case when [type]='Others' then 2 else 1 end "



            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetRequirementsNewBPonly()
        Try
            Dim _nQuery As String = Nothing

            _nQuery = "select [Type],(Header + Body + isnull(Footer,'')) as Content from [AppointmentRequirements] where Department = 'BPLO' and Type like '%New Business%'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetRequirementsTEST()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT Type, Department FROM [AppointmentRequirements]"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetAppType(Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT distinct(TransType) from [Appointment] where [Office] = '" & Office & "'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetDepartmentDesc(ByVal Department As String, ByRef Description As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Department] where Abbrev = '" & Department & "' or UserType='" & Department & "' "
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        Description = _nSqlDr("Department").ToString()
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectImage(ByVal Email As String, ByVal ModuleID As String, ByVal AcctID As String, ByVal SeqID As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [Attachment] "
            _nWhere = " where Email =  '" & cSessionUser._pUserID & "' and ModuleID='" & ModuleID & "' and AcctID='" & AcctID & "' and SeqID= '" & SeqID & "'"

            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Exists = True
                Else
                    Exists = False

                End If
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectSpecificAppDate(ByVal AppDate As String, ByVal Slot As String, ByVal Office As String)
        Try
            Dim _nQuery As String = Nothing
            _mQuery = " select Email,upper(registered.FirstName + ' ' + Registered.LastName) as Name,[TransDate],[AppDate],Slot, AppID, AcctID, TransType,Purpose, [Status],ServedBy,Remarks from Appointment INNER JOIN registered ON appointment.email = registered.[UserID] where Appointment.office='" & cSessionUser._pOffice & "' and Appointment.AppDate='" & cSessionLoader._pSelectedEventDate & "' and Appointment.Slot = '" & cSessionLoader._pSelectedEventTime & "' order by Appointment.appid asc"
            '----------------------------------  
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectAllRequest(ByVal Office As String)
        Try
            Dim _nQuery As String = Nothing
            _mQuery = "Select * from Appointment where Office='" & Office & "' and Approved=0 and Status='Request Pending' order by transDate asc"
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGenCode(ByRef GenCode As String)
        Try
            Dim _nQuery As String = Nothing
            Dim CTR As String
            Dim MonthNo As String
            _mQuery = "  select  top 1 Month(getdate()) AS MonthNo, (SELECT COUNT(Month(transdate))   FROM [Appointment] WHERE Month(transdate) = 12) as CTR FROM [Appointment]"
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        MonthNo = _nSqlDr("MonthNo").ToString()
                        CTR = _nSqlDr("CTR").ToString().PadLeft(3, "0"c)
                    Loop
                Else

                End If
            End Using
            If CTR = 0 Then CTR = "001"
            If MonthNo < 10 Then MonthNo = "0" & MonthNo
            GenCode = "BPLOCSJDM" & CTR & "-" & MonthNo
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    ' Public Sub _pSubGenerateCode(code)
    '     Try
    '         Dim _nQuery As String = Nothing
    '         _nQuery = _
    '            "SELECT * from [Appointment] where Email='" & Email & "' order by [Date] desc"
    '         _mQuery = _nQuery
    '         _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
    '
    '     Catch ex As Exception
    '
    '     End Try
    '
    ' End Sub



    Public Sub _pSubAppointmentRequest(Status, Type, Email, Code, Remarks)
        Try
            Dim _nQuery As String = Nothing
            Select Case Status
                Case "Download"
                Case "Approve"
                    _nQuery = "update [Appointment] set  Status = 'Approved', Approved = 1, CodeUsed=0, Code='" & Code & "', Remarks='" & Remarks & "' where Email='" & Email & "' and TransType = '" & Type & "' "
                Case "Deny"
                    _nQuery = "update [Appointment] set  Status = 'Denied', Approved = 0, CodeUsed=0, Remarks='" & Remarks & "' where Email='" & Email & "' and TransType = '" & Type & "' "

            End Select
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectSpecificAttachment(ByVal Email As String, ByVal ReqDesc As String, ByVal AcctID As String, ByVal SeqID As String, ByRef FileData As Byte(), ByRef FileType As String, ByRef FileName As String)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [Attachment] "
            _nWhere = " where Email =  '" & Email & "' and ReqDesc='" & ReqDesc & "' and AcctID='" & AcctID & "' and SeqID='" & SeqID & "' "
            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        FileData = DirectCast(_nSqlDr("FileData"), Byte())
                        FileType = _nSqlDr("FileType").ToString()
                        FileName = _nSqlDr("FileName").ToString()
                    Loop
                End If
            End Using




            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectAttachments(Office)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [Attachment] where office='" & Office & "' and ModuleID = '" & cSessionLoader._pSelectedEventID & "'"
            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectIdNo(EventDate, EventTime)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " SELECT * from [Appointment] where APPDATE =  '" & EventDate & "' and Slot='" & EventTime & "' "
            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectCertAppointment(ByVal Office As String)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing

            _nQuery = "select [Email],registered.FirstName + ' ' + Registered.LastName as Name,convert(varchar, cast([TransDate] as datetime), 1) as [TransDate],convert(varchar, cast([AppDate] as datetime), 1) as [AppDate] ,Slot, AppID, AcctID, Owner, TransType,'' as [Action], [Status] from Appointment INNER JOIN registered ON appointment.email = registered.[UserID] where Appointment.office='" & Office & "' order by Appointment.[TransDate] desc"
     
            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

         





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubValidateAppointment(ByVal EventDate As String, _
                                        ByVal EventTime As String, _
                                        ByVal Office As String, _
                                        ByRef valid As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            If EventTime = "AM" Then EventTime = "AM_Slot"
            If EventTime = "PM" Then EventTime = "PM_Slot"
            _nQuery = "SELECT AppDate, Beg_AM_Slot, case when AppDate =convert(varchar, getdate(), 1) and datepart(hour,getdate())>12 then 0   else  AM_Slot end as 'AM_Slot' , Beg_PM_Slot, case when AppDate =convert(varchar, getdate(), 1) and datepart(hour,getdate())>=17 then 0   else  PM_Slot end as 'PM_Slot', Color, Office FROM AppointmentSlot WHERE        (Office = '" & Office & "') AND (DATEADD(d, 1, AppDate) >= (SELECT        GETDATE() AS Expr1)) " & _
                " and Appdate = '" & EventDate & "' and " & EventTime & " >= 1"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        valid = True
                    Else
                        valid = False
                    End If
                End With

                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubAutoID(EventDate, EventTime)
        Try
            '----------------------------------       
            _pSubSelectIdNo(EventDate, EventTime)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iTime As Integer = .GetOrdinal("Slot")
                    Dim _iDate As Integer = .GetOrdinal("AppDate")
                    Dim _ictr As Integer = 1

                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _ictr = _ictr + 1
                            Loop
                            _mEventID = EventDate.Replace("-", "") & "-" & _ictr.ToString().PadLeft(5, "0"c)
                        Else
                            _mEventID = EventDate.Replace("-", "") & "-" & "00001"
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertAppointment(Email, TransType, AppDate, AppTime, AppId, Owner, AcctID, Status, Remarks, Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO [Appointment]([Email], [TransType], [AppDate], [Slot], [Remarks],[AppID],[Owner],[AcctID],[Status],[Office],[TransDate]) VALUES('" & Email & "','" & TransType & "','" & AppDate & "','" & AppTime & "','" & Remarks & "','" & AppId & "','" & Owner & "','" & AcctID & "','" & Status & "','" & Office & "',(SELECT GETDATE()))"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertAppointmentOTHERS(Email, TransType, AppDate, AppTime, AppId, Owner, AcctID, Status, Remarks, Office, Purpose, Hash)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO [Appointment]([Email], [TransType], [AppDate], [Slot], [Remarks],[AppID],[Owner],[AcctID],[Status],[Office],[TransDate],[Purpose],[Hash]) VALUES('" & Email & "','" & TransType & "','" & AppDate & "','" & AppTime & "','" & Remarks & "','" & AppId & "','" & Owner & "','" & AcctID & "','" & Status & "','" & Office & "',(SELECT GETDATE()),'" & Purpose & "','" & Hash & "')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertAppointmentRequest(Email, TransType, Office, Purpose)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO [Appointment]([Email], [TransType],[Office],[Purpose],[TransDate],[Approved],[Status]) VALUES('" & Email & "','" & TransType & "','" & Office & "','" & Purpose & "', (SELECT GETDATE()) ,0,'Request Pending')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubIfAlreadyRequested(ByVal Email As String, ByVal TransType As String, ByVal Office As String, ByVal Purpose As String, ByRef isOK As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = "Select * from [Appointment] where " & _
                "Email='" & Email & "' and " & _
                "TransType='" & TransType & "' and " & _
                "Office='" & Office & "' and " & _
                "Purpose='" & Purpose & "' and " & _
                "CodeUsed is null"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        isOK = False
                    Else
                        isOK = True
                    End If
                End With

                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubUpdateAppointmentSlot(AppDate, AppTime, Office)
        Try
            Dim _nQuery As String = Nothing
            If AppTime = "AM" Then
                _nQuery = "update [AppointmentSlot] set " _
                                   & " AM_Slot = (AM_Slot - 1) " _
                                   & " where AppDate='" & AppDate & "' and office='" & Office & "'"
            Else
                _nQuery = "update [AppointmentSlot] set " _
                                   & " PM_Slot = (PM_Slot - 1) " _
                                   & " where AppDate='" & AppDate & "' and office='" & Office & "'"
            End If
            cSessionLoader._pSelectedEventID = ""
            cSessionLoader._pSelectedEventDate = ""
            cSessionLoader._pSelectedEventTime = ""
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateAppStatus(Status, AppID, ServedBy, Remarks)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update [Appointment] set  Status = '" & Status & "', ServedBy = '" & ServedBy & "', Remarks = '" & Remarks & "' where AppID='" & AppID & "'"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSetFlag(Email, msg, errID)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update [Registered] set  Barangay = 'Flagged:" & errID & ":" & msg & "' where UserID='" & Email & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectAppointmentReport(Office, AppType, AppStatus, AppFrom, AppTo, SortName) 'Gimay 20201027
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing

            If SortName = Nothing Then
                SortName = "Name"
            ElseIf SortName = "Appointment Type" Then
                SortName = "TransType"
            ElseIf SortName = "Appointment Date" Then
                SortName = "AppDateSlot"
            End If

            If AppType <> "All" Then

                If AppStatus = "All" Then
                    _nQuery = "Select * from (select (select FirstName + ' ' + MiddleName + ' ' + LastName from Registered where UserID=a.Email) as Name, TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot , AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "' And AppDate   between '" & Trim(AppFrom) & "'   And '" & AppTo & "') xtb  order by xtb." & SortName

                ElseIf AppStatus = "Served" Then
                    _nQuery = " Select * from (select (select FirstName + ' ' + MiddleName + ' ' + LastName from Registered where UserID=a.Email) as Name, TransType, (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "'And  [Status]='Served' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb order by xtb." & SortName

                ElseIf AppStatus = "Pending" Then
                    _nQuery = " Select * from (select (select FirstName + ' ' + MiddleName + ' ' + LastName from Registered where UserID=a.Email) as Name, TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                 " And Transtype='" & AppType & "' And  [Status]='Pending' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb order by xtb." & SortName

                ElseIf AppStatus = "NoShow" Then
                    _nQuery = " Select * from (select (select FirstName + ' ' + MiddleName + ' ' + LastName from Registered where UserID=a.Email) as Name, TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "' And  [Status]='NoShow' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb order xtb." & SortName

                End If

            Else
                If AppStatus = "All" Then
                    _nQuery = "select * from (select (select FirstName + ' ' + MiddleName + ' ' + LastName from Registered where UserID=a.Email) as Name, TransType, (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    "  And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb  order by xtb." & SortName

                ElseIf AppStatus = "Served" Then
                    _nQuery = "select * from (select (select FirstName + ' ' + MiddleName + ' ' + LastName from Registered where UserID=a.Email) as Name, TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot , AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "' And  [Status]='Served' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb  order xtb." & SortName

                ElseIf AppStatus = "Pending" Then
                    _nQuery = "select * from (select (select FirstName + ' ' + MiddleName + ' ' + LastName from Registered where UserID=a.Email) as Name, TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                 " And Transtype='" & AppType & "' And  [Status]='Pending' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb  order xtb." & SortName

                ElseIf AppStatus = "NoShow" Then
                    _nQuery = "select * from (select (select FirstName + ' ' + MiddleName + ' ' + LastName from Registered where UserID=a.Email) as Name, TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "' And  [Status]='NoShow' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb  order xtb." & SortName

                End If
            End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)







            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region

End Class
