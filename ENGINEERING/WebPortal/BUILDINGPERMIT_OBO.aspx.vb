Imports System.Data.SqlClient
Imports System.IO
Imports Ionic.Zip
Imports System.Collections.Generic
Imports System.Drawing.Imaging

Public Class BUILDINGPERMIT_OBO
    Inherits System.Web.UI.Page

    Public _pApplicantUserID As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cSessionLoader._pAppNo = Session.Item("ReviewAppNo")
            cSessionLoader._pTransNo = Session.Item("ReviewTransNo")
            _mSubLoadOwnershipTypeComboboxData()
            LoadTextFields(Session.Item("ReviewAppNo"))
            'LoadAppMasterData(Session.Item("ReviewAppNo"))
            LoadUploadedReq(Session.Item("ReviewTransNo"), Session.Item("ReviewAppNo"), Session.Item("PermitType"))

            'LoadTextFields("2021-06-00002-B-01")
            'LoadUploadedReq("B0120210600002")
            'If FnLoadRejectedRequirements(Session("TransNo"), Session("ReviewAppNo"), "B-01") = Nothing Then
            '    _oBtn_Decline.Disabled = True
            'Else
            '    _oBtn_Decline.Disabled = False
            'End If
        Else
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "DownloadFiles" Then
                Download_Selected(val, Session("TransNo"))
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalChecklist();", True)
            End If
            If action = "DownloadFilesNewTab" Then
                Download_Selected_NewTab(val, Session("TransNo"))
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalChecklist();", True)
            End If
            If action = "Save" Then
                CheckIfComp(Session.Item("ReviewAppNo"))
            End If
            If action = "SaveReqStatus" Then
                _Init_UpdateReqStatuses(_oGvUpload)
            End If


        End If
    End Sub

    Private Sub _Init_UpdateReqStatuses(_nGridview As GridView)
        Try

            Dim _nReCode As String = Nothing
            Dim _nRemarks As String = Nothing
            Dim _nLabelStatus As String = Nothing
            Dim _nReject As Boolean

            If _nGridview.Rows.Count > 0 Then
                For Each row As GridViewRow In _nGridview.Rows

                    _nReCode = DirectCast(row.FindControl("_oLblCodeReq"), Label).Text
                    _nLabelStatus = DirectCast(row.FindControl("_oLblStatus"), Label).Text
                    _nRemarks = DirectCast(row.FindControl("_oTxtRemarks"), TextBox).Text
                    _nReject = DirectCast(row.FindControl("mycheckbox"), CheckBox).Checked

                    If _nReject = True Then
                        _nLabelStatus = "Rejected"
                        _pSubUpdateReqStatus(_nReCode, _nLabelStatus, _nRemarks, IIf(_nReject = True, 1, 0))
                    Else
                        _nLabelStatus = "Approved"
                        _pSubUpdateReqStatus(_nReCode, _nLabelStatus, "", IIf(_nReject = True, 1, 0))
                    End If

                Next

                LoadUploadedReq(Session.Item("ReviewTransNo"), Session.Item("ReviewAppNo"), Session.Item("PermitType"))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _pSubUpdateReqStatus(ByVal _nReCode As String, ByVal _nLabelStatus As String, ByVal _nRemarks As String, ByVal _nReject As Boolean)
        Try
            Dim _nSqlCmd As SqlCommand

            _nSqlCmd = New SqlCommand("UPDATE UploadedReq set IsReject = " & IIf(_nReject = True, 1, 0) & ", Status = '" & _nLabelStatus & "' , Remarks = '" & _nRemarks & "' " & _
                                      " where AppNo = '" & cSessionLoader._pAppNo & "' AND TransID = '" & cSessionLoader._pTransNo & "' AND ReqCode = '" & _nReCode & "' ", cGlobalConnections._pSqlCxn_EIMS)
            _nSqlCmd.ExecuteNonQuery()
            _nSqlCmd.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _mSubLoadOwnershipTypeComboboxData()

        Try
            Dim _nDaTable As New DataTable
            Dim _nSuccessful As Boolean
            _mSubLoadOwnershipType(_nDaTable, _nSuccessful)

            If cDalOwnershipType._pDataTable.Columns.Count > 0 Then

                _oTxtFormofOwnership.DataSource = _nDaTable
                _oTxtFormofOwnership.DataTextField = "Desc2"
                _oTxtFormofOwnership.DataValueField = "Desc1"
                _oTxtFormofOwnership.DataBind()

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub _mSubLoadOwnershipType(ByRef _mDTOwnCode As DataTable, ByVal _nBool As Boolean, Optional _nCondition As String = Nothing)

        Try

            cDalOwnershipType._pSqlCon = cGlobalConnections._pSqlCxn_EIMS 'set the connection of class
            cDalOwnershipType._pSubSelect(True, _nCondition) 'load record
            _mDTOwnCode = cDalOwnershipType._pDataTable 'transfer/clone class datatable to your data table
            cDalOwnershipType._pDataTable.Dispose() 'dispose the class datatable

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckIfComp(ByVal _nAppNo As String)
        Try
            Dim _nSqlCmd As SqlCommand
            For Each row As GridViewRow In _oGvUpload.Rows
                Dim Status = DirectCast(row.FindControl("_oLblStatus"), Label).Text
                If Status = "For Review" Then GoTo UpdateIncomplete
            Next
            _nSqlCmd = New SqlCommand("UPDATE ApplicationPermit set Updated = 0, Done = 1 where AppNo = '" & _nAppNo & "'", cGlobalConnections._pSqlCxn_EIMS)
            _nSqlCmd.ExecuteNonQuery()
            _nSqlCmd.Dispose()
            Exit Sub
UpdateIncomplete:
            _nSqlCmd = New SqlCommand("UPDATE ApplicationPermit set Updated = 1, Done = 1 where AppNo = '" & _nAppNo & "'", cGlobalConnections._pSqlCxn_EIMS)
            _nSqlCmd.ExecuteNonQuery()
            _nSqlCmd.Dispose()

        Catch ex As Exception

        End Try

    End Sub
    Sub Download_Selected(seqid, userid)
        Try

            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim bytes As Byte()
            Dim _nFileExtn As String = ""
            Dim _mFilename As String = ""
            _nQuery = "select * from UploadedReq where ReqCode ='" & seqid & "' and TransID ='" & userid & "' and AppNo = '" & Session.Item("ReviewAppNo") & "'"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_EIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))
                    Session("FileData") = Convert.ToBase64String(bytes, 0, bytes.Length)
                End If
                If _nFileExtn = ".PDF" Then
                    Session("FileData") = "data:application/pdf;base64," & Convert.ToBase64String(bytes)
                    ltEmbed.Visible = True
                    Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""100%"" height=""600px"">"
                    embed += ""
                    embed += "</object>"
                    ltEmbed.Text = ""
                    ltEmbed.Text = String.Format(embed, ResolveUrl(Session("FileData")))
                    Image1.Visible = False
                    'Response.Clear()
                    'Response.ContentType = "application/pdf"
                    'HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    'Response.BinaryWrite(bytes)
                    'Response.Flush()
                    'Response.End()

                    ''ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    ''Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".TXT" Then
                    'Response.Clear()
                    'Response.ContentType = "text/plain"
                    'HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    'Response.BinaryWrite(bytes)
                    'Response.Flush()
                    'Response.End()
                    ''ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    ''Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".PNG" Then
                    Image1.ImageUrl = "data:image/jpeg;base64, " + Session("FileData")
                    Image1.Visible = True
                    ltEmbed.Visible = False
                    'Response.Clear()
                    'Response.ContentType = "image/png"
                    'HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    'Response.BinaryWrite(bytes)
                    'Response.Flush()
                    'Response.End()
                    ''ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If

                If _nFileExtn = ".JPG" Or _nFileExtn = ".JPEG" Then
                    Image1.ImageUrl = "data:image/jpeg;base64, " + Session("FileData")
                    Image1.Visible = True
                    ltEmbed.Visible = False
                    'Response.Clear()
                    'Response.ContentType = "image/jpeg"
                    'HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    'Response.BinaryWrite(bytes)
                    'Response.Flush()
                    'Response.End()
                    ''ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Sub Download_Selected_NewTab(seqid, userid)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim bytes As Byte()
            Dim _nFileExtn As String = ""
            Dim _mFilename As String = ""
            _nQuery = "select * from UploadedReq where ReqCode ='" & seqid & "' and TransID ='" & userid & "' and AppNo = '" & Session.Item("ReviewAppNo") & "'"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_EIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))

                    If _nFileExtn = "TEXT/PLAIN" Then
                        _nFileExtn = ".TXT"
                    End If
                    If _nFileExtn = "APPLICATION/PDF" Then
                        _nFileExtn = ".PDF"
                    End If
                    If _nFileExtn = "IMAGE/PNG" Then
                        _nFileExtn = ".PNG"
                    End If
                    If _nFileExtn = "IMAGE/JPEG" Then
                        _nFileExtn = ".JPG"
                    End If

                End If
                If _nFileExtn = ".PDF" Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()

                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".TXT" Then
                    Response.Clear()
                    Response.ContentType = "text/plain"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStart upScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".PNG" Then
                    Response.Clear()
                    Response.ContentType = "image/png"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If

                If _nFileExtn = ".JPG" Then
                    Response.Clear()
                    Response.ContentType = "image/jpeg"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadUploadedReq(ByVal _nTransID As String, ByVal _nAppno As String, Optional _PermitType As String = Nothing)
        Try
            Dim _nSqlCmd As SqlCommand
            Dim _nSqlAdp As SqlDataAdapter
            Dim _nSubtbl As New DataTable

            _nSqlCmd = New SqlCommand("select *  " & _
                                        " , TransID + '-' + ReqCode  as FileName   " & _
                                        " , concat('data:',      " & _
                                        " CASE WHEN LOWER(AttType) = '.pdf'  " & _
                                        " then             'application/pdf'  " & _
                                        " when LOWER(AttType) = '.jpg'  then ' image/jpeg'  " & _
                                        " else             'image/' + REPLACE(AttType, '.', '')           " & _
                                        " End  " & _
                                        " ,';base64,',baze64) File64 " & _
                                      " from (select dbo.Fn_InitCapsEachWord(RC.desc2) desc2 , UR.* from UploadedReq UR" & _
                                      " inner join [ReqCode] RC " & _
                                      " on RC.code = UR.reqcode  and RC.LinkCode = '" & IIf(cReturnDataType._pYieldStringChecker(_PermitType), _PermitType, "B-01") & "' and UR.TransID = '" &
                                      _nTransID & "' AND UR.AppNo = '" & _nAppno & "' ) FnlTbl" & _
                                      " cross apply (select AttFile as '*' for xml path('')) T (baze64)    ", cGlobalConnections._pSqlCxn_EIMS)
            _nSqlAdp = New SqlDataAdapter(_nSqlCmd)
            _nSqlAdp.Fill(_nSubtbl)
            _nSqlCmd.Dispose()
            _nSqlAdp.Dispose()
            _oGvUpload.DataSource = Nothing
            _oGvUpload.DataBind()
            _oGvUpload.DataSource = _nSubtbl
            _oGvUpload.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadTextFields(ByVal _nAppNo As String)
        Try
            Dim _nSqlCmd As SqlCommand
            Dim _mRdr As SqlDataReader

            _nSqlCmd = New SqlCommand("SELECT * FROM ApplicationPermit Where AppNo = '" & cSessionLoader._pAppNo & "' and TransNo = '" & cSessionLoader._pTransNo & "'", cGlobalConnections._pSqlCxn_EIMS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
                Session("TransNo") = _mRdr.Item("TransNo").ToString
                Session("Done") = _mRdr.Item("Done")
                Session("Assessment") = _mRdr.Item("Assessment")
                Session("Payment") = _mRdr.Item("Payment")
                Session("Updated") = _mRdr.Item("Updated")
                Session("PermitType") = _mRdr.Item("PermitType")
                _oTxtLName.Value = _mRdr.Item("LastName").ToString
                _oTxtFName.Value = _mRdr.Item("FirstName").ToString
                _oTxtMName.Value = _mRdr.Item("MiddleName").ToString
                _oTxtFormofOwnership.Value = _mRdr.Item("OwnershipType").ToString
                _oTxtTINNo.Value = _mRdr.Item("TIN").ToString
                _oTxtNoStrt.Value = _mRdr.Item("NoStrtVillage").ToString
                _oTxtBrgy.Value = _mRdr.Item("Brgy").ToString
                _oTxtCity.Value = _mRdr.Item("City").ToString
                _oTxtProvince.Value = _mRdr.Item("Province").ToString
                _oTxtZIPCode.Value = _mRdr.Item("ZIPCode").ToString
                _oTxtEmail.Value = _mRdr.Item("Email").ToString
                _oTxtTelNo.Value = _mRdr.Item("TelNo").ToString
                _oTxtBlkNoLOC.Value = _mRdr.Item("BlkNoLOC").ToString
                _oTxtLotNoLOC.Value = _mRdr.Item("LotNoLOC").ToString
                _oTxtStreetLOC.Value = _mRdr.Item("StreetLOC").ToString
                _oTxtBrgyLOC.Value = _mRdr.Item("BrgyLOC").ToString
                _oTxtCityLOC.Value = _mRdr.Item("CityLOC").ToString
                _oTxtTCTNo.Value = _mRdr.Item("TCTNo").ToString
                _oTxtTDN.Value = _mRdr.Item("TDN").ToString
                _oTxtCTCNo.Value = _mRdr.Item("CTC_No").ToString
                Dim _nDateIssued As String = Format(CDate(_mRdr.Item("CTC_DateIssued").ToString), "yyyy-MM-dd").ToString
                _oTxtCTCDateIssued.Value = _nDateIssued
                _oTxtCTCPlaceIssued.Value = _mRdr.Item("CTC_PlaceIssued").ToString
                _oTxtTotArea.Value = _mRdr.Item("Tot_Area").ToString
                cLoader._pApplicantUserID = _mRdr.Item("UserID").ToString ' @ADDED |20221007 | LOUIE
            End If
            _nSqlCmd.Dispose()
            _mRdr.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    '@ADDED | 20221006 |LOUIE

    Protected Sub OnDownload(sender As Object, e As EventArgs)
        Dim filePath As String = Path.Combine(Server.MapPath("~/Temp/"))


        Using zip As New ZipFile()
            zip.AlternateEncodingUsage = ZipOption.AsNecessary
            zip.AddDirectoryByName("_oLblDesc2Req")
            For Each row As GridViewRow In _oGvUpload.Rows
                'If TryCast(row.FindControl("_oLblDesc2Req"), CheckBox).Checked Then
                'filePath = TryCast(row.FindControl("lblFilePath"), Label).Text
                zip.AddFile(filePath)
                    ' End If
            Next

            Response.Clear()
            Response.BufferOutput = False
            Dim zipName As String = [String].Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"))
            Response.ContentType = "application/zip"
            Response.AddHeader("content-disposition", Convert.ToString("attachment; filename=") & zipName)
            zip.Save(Response.OutputStream)
            Response.[End]()
        End Using
    End Sub

    Public Function FilePath(fileData As Object) As String
        Dim bytes As Byte() = DirectCast(fileData, Byte())
        Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
        Dim ms As New MemoryStream(bytes, 0, bytes.Length)
        ms.Write(bytes, 0, bytes.Length)
        Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(ms, True)
        Dim newFile As String = Guid.NewGuid().ToString() + ".jpeg"
        Dim filePath__1 As String = Path.Combine(Server.MapPath("~/Files/"), newFile)
        image.Save(filePath__1, ImageFormat.Jpeg)
        Return filePath__1
    End Function

    Private Sub LoadAppMasterData(ByVal _nAppNo As String)
        Try
            Dim _nSqlCmd As SqlCommand
            Dim _mRdr As SqlDataReader

            _nSqlCmd = New SqlCommand("SELECT * FROM ApplicationMaster Where AppNo = '" & _nAppNo & "'", cGlobalConnections._pSqlCxn_EIMS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
                Session("PermitType") = _mRdr.Item("PermitType")
            End If
            _nSqlCmd.Dispose()
            _mRdr.Dispose()

        Catch ex As Exception

        End Try
    End Sub


    Public Sub SubInsertAttachFiles(TransID, AttCode, Status, Remarks)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "UPDATE UploadedReq SET STATUS = @Status" & _
                IIf(UCase(Status) = "REJECTED", " , REMARKS =  @Remarks ", " , Remarks = null ") & _
                " WHERE TransID = @TransID AND ReqCode = @AttCode; " & _
                "  "
            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)

            With _nSqlCommand.Parameters
                .AddWithValue("@TransID", TransID)
                .AddWithValue("@AttCode", AttCode)
                .AddWithValue("@Status", Status)
                If UCase(Status) = "REJECTED" Then .AddWithValue("@Remarks", Remarks)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub SubApproveAction_Click(sender As Object, e As EventArgs)
        'Dim btn As Button = CType(sender, Button)
        'btn.CommandArgument
        If UCase(hdnaction.Value) = "REJECTED" And Not cReturnDataType._pYieldStringChecker(_oTxtRemarks.Value) _
            Then ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "$('#Confirmation').modal('hide');", True) _
            : snackbar("red", "Please fill in the Remarks") _
            : Exit Sub
        SubInsertAttachFiles(hdnTransID.Value, hdnReqCode.Value, hdnaction.Value, _oTxtRemarks.Value)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "$('#ModalChecklist').modal('hide');$('#Confirmation').modal('hide');", True)
        If UCase(hdnaction.Value) = "APPROVED" Then
            snackbar("green", "Requirements Approved")
        Else
            snackbar("red", "Requirements Rejected")
        End If

        SubInsertHistory(Session("AppDate"), Session("TransNo"), Session("ServiceDescription"), Session("ServiceType"), Session("Status"), "")

        LoadTextFields(Session.Item("ReviewAppNo"))
        LoadUploadedReq(Session.Item("ReviewTransNo"), Session.Item("ReviewAppNo"), Session.Item("PermitType"))

        'If FnLoadRejectedRequirements(Session("TransNo"), Session("ReviewAppNo"), "B-01") = Nothing Then
        '    _oBtn_Decline.Disabled = True
        'Else
        '    _oBtn_Decline.Disabled = False
        'End If
        _oTxtRemarks.Value = Nothing
        hdnaction.Value = Nothing
    End Sub

    Protected Sub _SubConfirmAction(sender As Object, e As EventArgs)
        Select Case UCase(hdnaction.Value).ToString
            Case "DECLINE"
                SubDecline_Click()
            Case "APPROVE FOR ASSESSMENT"
                SubAssessment_Click()
        End Select
    End Sub

    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub


    Public Sub SubInsertHistory(AppDate, TransID, AttDesc, AttType, Status, Userid)
        Try

            SaveSession(Session("ReviewAppNo"))
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO transaction_history VALUES(@TransID,@Date,@Status,@AttType,@AttDesc,@UserId)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)

            With _nSqlCommand.Parameters
                .AddWithValue("@TransID", Session.Item("ReviewTransNo"))
                .AddWithValue("@Date", Session.Item("ReviewAppDate"))
                .AddWithValue("@AttDesc", Session.Item("ReviewServiceDescription"))
                .AddWithValue("@AttType", Session.Item("ReviewServiceType"))
                .AddWithValue("@Status", hdnaction.Value)
                .AddWithValue("@Userid", Session.Item("Reviewuserid"))
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetUserID(AppNo) As String
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select userid from ApplicationPermit where AppNo = @AppNo"
            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)
            With _nSqlCommand.Parameters
                .AddWithValue("@AppNo", AppNo)
            End With
            Dim getid As String = _nSqlCommand.ExecuteScalar()
            Return getid
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Sub SaveSession(AppNo)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from ApplicationPermit where AppNo = '" & AppNo & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_EIMS) '_gDBCon
            Dim _mDataTable = New DataTable
            With _nSqlCommand.Parameters
                .AddWithValue("@AppNo", AppNo)
            End With
            _nSqlCommand.ExecuteNonQuery()
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    Session.Item("ReviewTransNo") = _nSqlDr.GetValue(_nSqlDr.GetOrdinal("TransNo"))
                    Session.Item("ReviewAppDate") = _nSqlDr.GetValue(_nSqlDr.GetOrdinal("AppDate"))
                    Session.Item("ReviewStatus") = _nSqlDr.GetValue(_nSqlDr.GetOrdinal("Status"))
                    Session.Item("ReviewServiceType") = _nSqlDr.GetValue(_nSqlDr.GetOrdinal("ServiceType"))
                    Session.Item("ReviewServiceDescription") = _nSqlDr.GetValue(_nSqlDr.GetOrdinal("ServiceDescription"))
                    Session.Item("Reviewuserid") = _nSqlDr.GetValue(_nSqlDr.GetOrdinal("userid"))
                End If
            End Using
            '----------------------------------

            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub SubNotifyClient_Click(sender As Object, e As EventArgs)
        SaveSession(Session("ReviewAppNo"))
        'SubNotifyTaxpayer()
        SubNotifyTaxpayer_Comment()
    End Sub


    Private Function FnLoadRejectedRequirements(ByVal _nTransID As String, ByVal _nAppno As String, ByVal _PermitType As String) As String
        Try
            FnLoadRejectedRequirements = Nothing
            Dim _nSuccess As Boolean
            Dim _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD

            With _nClass

                ._pSqlCon = cGlobalConnections._pSqlCxn_EIMS
                ._pAction = "SELECT"
                ._pSelect = " select  Desc2, Remarks from " & _
                            " (select dbo.Fn_InitCapsEachWord(RC.desc2) desc2 , UR.* from UploadedReq UR " & _
                            " inner join [ReqCode] RC  " & _
                               " on RC.code = UR.reqcode and RC.LinkCode = ''" & _PermitType & "'' and UR.TransID = ''" &
                             _nTransID & "'' AND UR.AppNo = ''" & _nAppno & "'' and Status = ''Rejected'') FnlTbl"
                ._pCondition = Nothing
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable
                Dim sb As New StringBuilder
                If _nDataTable.Rows.Count > 0 Then
                    'Table start.
                    sb.Clear()
                    sb.Append("</br>")
                    sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:arial'>")

                    'Adding HeaderRow. 
                    sb.Append("<tr>")
                    sb.Append("<th style='with:50%; border: 1px solid #ccc'> Disapproved requirement/s </th>") ''  ===  Requirment Descrition 
                    sb.Append("<th style='with:50%; border: 1px solid #ccc'> Remarks </th>")  '  ===  Remarks
                    sb.Append("</tr>")

                    Dim i As Integer = 0
                    Do Until i = _nDataTable.Rows.Count
                        Dim _nReq As String = Nothing
                        Dim _nRem As String = Nothing
                        _nReq = _nDataTable.Rows(i).Item("Desc2")
                        _nRem = _nDataTable.Rows(i).Item("Remarks")
                        sb.Append("<tr>")
                        sb.Append("<td style='border: 1px solid #ccc'>" & _nReq & "</td>")
                        sb.Append("<td style='border: 1px solid #ccc'>" & _nRem & "</td>")
                        sb.Append("</tr>")
                        i = i + 1
                    Loop

                    'TABLE END
                    sb.Append("</table>")
                    sb.Append("</br>")

                    Return sb.ToString
                End If

            End With

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Protected Sub SubDecline_Click()
        Try


            '' # 1 Update Application Status to Decline
            cDalSendSystemGeneratedEmail._pRejectedReq = FnLoadRejectedRequirements(Session("TransNo"), Session("ReviewAppNo"), "B-01")
            If cDalSendSystemGeneratedEmail._pRejectedReq = Nothing Then snackbar("red", "No rejected requierment was found </br> Please review all requirements first.") : Exit Sub
            'Response.Write("<script> alert('No rejected requierment was found </br> Please review all requirements first.') </script>")
            Try
                Dim _nQuery As String = Nothing
                Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)
                _nSqlCommand.CommandText = "UPDATE ApplicationPermit set LockForReview = 0 , updated = 0 where AppNo = '" & Session("ReviewAppNo") & "'"
                _nSqlCommand.ExecuteNonQuery()
                _nSqlCommand.Dispose()

            Catch ex As Exception
                snackbar("red", ex.Message)
                Exit Sub
            End Try

            '' # 2 Notify Applicant
            cDalSendSystemGeneratedEmail._pTransNo = Session("TransNo")
            cDalSendSystemGeneratedEmail._pComment = _oTxtComments.Value

            cDalSendSystemGeneratedEmail._pFnNotify_Applicant("BUILDING PERMIT", "DECLINE", cLoader._pApplicantUserID)
            cDalSendSystemGeneratedEmail._FnNotify_LGU("BUILDING PERMIT", "DECLINE", "OBO")
            '' # 3 Log Transaction
            cDalTransLog._pSubInsertTransLog(Session("TransNo"), "Appication Decline", "Building Permit", "New Application", cLoader._pApplicantUserID)
            Response.Redirect("EmailSent.aspx")

        Catch ex As Exception

        End Try

        'SubNotifyTaxpayer()
        'SubNotifyTaxpayer_Comment()
    End Sub

    Protected Sub SubAssessment_Click()
        'Dim btn As Button = CType(sender, Button)
        'btn.CommandArgument

        Dim _nQuery As String = Nothing
        _nQuery = "select * from UploadedReq where [status] like '%Rejected%' and AppNo = '" & Session("ReviewAppNo") & "'"
        Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)
        Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_EIMS) '_gDBCon                   
        Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
            _nSqlDr.Read()
            If _nSqlDr.HasRows Then
                snackbar("red", "Cannot approve, Rejected requirement/s detected.")
                Exit Sub
            End If
        End Using


        Try
            _nSqlCommand.CommandText = "UPDATE ApplicationPermit set assessment = 1 , updated = 0 where AppNo = '" & Session("ReviewAppNo") & "'"
            _nSqlCommand.Connection = cGlobalConnections._pSqlCxn_EIMS
            _nSqlCommand.ExecuteNonQuery()
            _nSqlCommand.Dispose()
        Catch ex As Exception
            snackbar("red", ex.Message)
            Exit Sub
        End Try

        cDalSendSystemGeneratedEmail._pTransNo = Session("TransNo")
        cDalSendSystemGeneratedEmail._pFnNotify_Applicant("BUILDING PERMIT", "APPROVE FOR ASSESSMENT", cLoader._pApplicantUserID)
        cDalSendSystemGeneratedEmail._FnNotify_LGU("BUILDING PERMIT", "APPROVE FOR ASSESSMENT", "OBO")

        Response.Redirect("EmailSent.aspx")

    End Sub

    Public Sub SubNotifyTaxpayer()
        Dim Body As String
        Dim Sent As Boolean
        Dim Subject As String = "Office of the Building Official - Web Portal"


        Body = "" _
                    & "Application Appoved!<br/>" _
                    & "" _
                    & " <br>Your online Building application for Application No.: " & Session("ReviewAppNo").ToString() & " is now approved!" & _
                    "<br>Your application is now sent to Office of the Building Official for further verification and assessment " & _
                    "<br>We strongly suggest to regularly check your email for more updates.<br>Thank you for using our Web Service portal." & _
                     ""
        Try
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "alert", "document.getElementById('clickhere').click();", True)
            cDalNewSendEmail.SendEmail(Session.Item("Reviewuserid"), Subject, Body, Sent)
            snackbar("green", "Email Sent!")
            '_nMsg = "Email Verification has been sent."
            '_nColor = "green"
        Catch ex As Exception
            snackbar("red", ex.Message)
            '_nColor = "red"
            '_nMsg = ex.Message           
        End Try
    End Sub

    Public Sub SubNotifyTaxpayer_Comment()
        Dim Body As String
        Dim Sent As Boolean
        Dim Subject As String = "Office of the Building Official - Web Portal"


        Body = "" _
                    & "Application Rejected!<br/>" _
                    & "<ol type='1'>" _
                    & " <br> Findings: " & _oCbFindings.Value & "" _
                    & " <br> " & _oTxtComments.Value & " " _
                    & "</ol>"
        Try
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "alert", "document.getElementById('clickhere').click();", True)
            cDalNewSendEmail.SendEmail(Session.Item("Reviewuserid"), Subject, Body, Sent)
            snackbar("green", "Email Sent!")
            '_nMsg = "Email Verification has been sent."
            '_nColor = "green"
        Catch ex As Exception
            snackbar("red", ex.Message)
            '_nColor = "red"
            '_nMsg = ex.Message           
        End Try
    End Sub

    'Protected Sub _oGVTransactions_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
    '    _oGVTransactions.PageIndex = e.NewPageIndex
    '    _oGVTransactions.DataSource = PopulateHistory(" " & IIf(cReturnDataType._pYieldStringChecker(cSessionUser._pUserID), " UserID = '" & cSessionUser._pUserID & "' ", ""))
    '    '_oGVTransactions.AutoGenerateColumns = False        
    '    _oGVTransactions.DataBind()
    '    'LoadRecords(10, e.NewPageIndex, Session("_nPageTotal"), Session("_nTotRecCount"))
    'End Sub

End Class