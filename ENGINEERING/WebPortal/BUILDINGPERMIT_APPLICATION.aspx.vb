Imports System.Data.SqlClient
Imports System.IO

Public Class BUILDINGPERMIT_APPLICATION
    Inherits System.Web.UI.Page
    Dim _mCondWhere As String = ""
    Dim _mRecCnt As Integer
    Private _mDTOwnCode As New DataTable
    Dim _nSuccessful As Boolean
    Dim _nSubtbl As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then

                'cDalGetSpecificValue._FnGetRecCount("","")

                If SubCheckExistingApp(Session("UserID")) = "" And cSessionLoader._pIsUpdateReject = False Then
                    _mSubLoadOwnershipTypeComboboxData()
                    SubLoadRequirements(False)
                    _oTxtHdnEdit.Value = ""
                    Session("Edit") = ""


                Else

                    If cSessionLoader._pIsUpdateReject = True Then
                        Session("AppNo") = cSessionLoader._pAppNo
                    End If

                    _mSubLoadOwnershipTypeComboboxData()
                    LoadTextFields(Session("AppNo"))
                    SubLoadRequirements(True)

                    SubCheckRequirements()
                    _oTxtHdnEdit.Value = "Edit"
                    Session("Edit") = "Edit"

                    _oBtnEdit.Disabled = False
                    _oTxtFName.Disabled = True
                    _oTxtLName.Disabled = True
                    _oTxtMName.Disabled = True
                    _oTxtFormofOwnership.Disabled = True
                    _oTxtTINNo.Disabled = True
                    _oTxtNoStrt.Disabled = True
                    _oTxtBrgy.Disabled = True
                    _oTxtCity.Disabled = True
                    _oTxtProvince.Disabled = True
                    _oTxtZIPCode.Disabled = True
                    _oTxtEmail.Disabled = True
                    _oTxtTelNo.Disabled = True
                    _oTxtLotNoLOC.Disabled = True
                    _oTxtBlkNoLOC.Disabled = True
                    _oTxtStreetLOC.Disabled = True
                    _oTxtBrgyLOC.Disabled = True
                    _oTxtCityLOC.Disabled = True
                    _oTxtTCTNo.Disabled = True
                    _oTxtTDN.Disabled = True
                    _oTxtTotArea.Disabled = True
            End If
                _InitAppInfoReadOnly(cSessionLoader._pIsUpdateReject)
                ' If cSessionLoader._pIsUpdateReject = True Then Div_AppInfo.Disabled = True : _oBtnSaveAppInfo.Visible = False : _oBtnEdit.Visible = False Else Div_AppInfo.Disabled = False : _oBtnSaveAppInfo.Visible = True : _oBtnEdit.Visible = True

            Else
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "SaveApplication" Then
                PassValueToSession()
                _oBtnEdit.Disabled = False
                _oTxtFName.Disabled = True
                _oTxtLName.Disabled = True
                _oTxtMName.Disabled = True
                _oTxtFormofOwnership.Disabled = True
                _oTxtTINNo.Disabled = True
                _oTxtNoStrt.Disabled = True
                _oTxtBrgy.Disabled = True
                _oTxtCity.Disabled = True
                _oTxtProvince.Disabled = True
                _oTxtZIPCode.Disabled = True
                _oTxtEmail.Disabled = True
                _oTxtTelNo.Disabled = True
                _oTxtLotNoLOC.Disabled = True
                _oTxtBlkNoLOC.Disabled = True
                _oTxtStreetLOC.Disabled = True
                _oTxtBrgyLOC.Disabled = True
                _oTxtCityLOC.Disabled = True
                _oTxtTCTNo.Disabled = True
                _oTxtTDN.Disabled = True
                _oTxtTotArea.Disabled = True
                SaveApplication(Session("Edit"))
                SubLoadRequirements(True)
                Session("Edit") = "Edit"
                'cDalTransLog._pSubInsertTransLog(Session("TransNo"), Session("Status"), Session("ServiceType"), Session("ServiceDescription"), cSessionUser._pUserID)
                'SubInsertHistory(Session("AppDate"), Session("TransNo"), Session("ServiceDescription"), Session("ServiceType"), Session("Status"), cSessionUser._pUserID)
            End If
            If action = "UploadRequirements" Then
                UploadRequirements()
                SubLoadRequirements(True)
                SubCheckRequirements()
                'cDalTransLog._pSubInsertTransLog(Session("TransNo"), Session("Status"), Session("ServiceType"), Session("ServiceDescription"), cSessionUser._pUserID)
                '  SubInsertHistory(Session("AppDate"), Session("TransNo"), Session("ServiceDescription"), Session("ServiceType"), Session("Status"), cSessionUser._pUserID)
            End If

            If action = "Submit" Then

                _mSubUpdateDone(Session("AppNo"))
                If cSessionLoader._pIsUpdateReject = True Then
                    _mSubUpdateRejectStatus(Session("AppNo"))
                End If
                _pSubNotifyEmail_LGU() '' -- Notify BPLO
                _pSubNotifyEmail_Client()  '' -- Notify Client User
                cDalTransLog._pSubInsertTransLog(Session("TransNo"), Session("Status"), Session("ServiceType"), Session("ServiceDescription"), cSessionUser._pUserID)
                'SubInsertHistory(Session("AppDate"), Session("TransNo"), Session("ServiceDescription"), Session("ServiceType"), Session("Status"), cSessionUser._pUserID)
                'snackbar("green", "Your application is successfully submitted!")
                _mSubClear()
                Response.Redirect("Success.aspx")
                End If
                _InitAppInfoReadOnly(cSessionLoader._pIsUpdateReject)
                ' If cSessionLoader._pIsUpdateReject = True Then Div_AppInfo.Disabled = True : _oBtnSaveAppInfo.Visible = False : _oBtnEdit.Visible = False Else Div_AppInfo.Disabled = False : _oBtnSaveAppInfo.Visible = True : _oBtnEdit.Visible = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _InitAppInfoReadOnly(_nReadOnly As Boolean)
        Try
            _oTxtFName.Disabled = _nReadOnly
            _oTxtLName.Disabled = _nReadOnly
            _oTxtMName.Disabled = _nReadOnly
            _oTxtFormofOwnership.Disabled = _nReadOnly
            _oTxtTINNo.Disabled = _nReadOnly
            _oTxtNoStrt.Disabled = _nReadOnly
            _oTxtBrgy.Disabled = _nReadOnly
            _oTxtCity.Disabled = _nReadOnly
            _oTxtProvince.Disabled = _nReadOnly
            _oTxtZIPCode.Disabled = _nReadOnly
            _oTxtEmail.Disabled = _nReadOnly
            _oTxtTelNo.Disabled = _nReadOnly
            _oTxtLotNoLOC.Disabled = _nReadOnly
            _oTxtBlkNoLOC.Disabled = _nReadOnly
            _oTxtStreetLOC.Disabled = _nReadOnly
            _oTxtBrgyLOC.Disabled = _nReadOnly
            _oTxtCityLOC.Disabled = _nReadOnly
            _oTxtTCTNo.Disabled = _nReadOnly
            _oTxtTDN.Disabled = _nReadOnly
            _oTxtTotArea.Disabled = _nReadOnly
            _oTxtCTCNo.Disabled = _nReadOnly
            _oTxtCTCDateIssued.Disabled = _nReadOnly
            _oTxtCTCPlaceIssued.Disabled = _nReadOnly

            If _nReadOnly = True Then
                _oBtnSaveAppInfo.Visible = False
                _oBtnEdit.Visible = False
            Else
                _oBtnSaveAppInfo.Visible = True
                _oBtnEdit.Visible = True
            End If
           
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _pSubNotifyEmail_Client()
        Try
            cDalSendSystemGeneratedEmail._pTransNo = Session("TransNo")
            cDalSendSystemGeneratedEmail._pFnNotify_Applicant("BUILDING PERMIT", "FOR REVIEW", cSessionUser._pUserID)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _pSubNotifyEmail_LGU()
        Try
            cDalSendSystemGeneratedEmail._pTransNo = Session("TransNo")
            cDalSendSystemGeneratedEmail._FnNotify_LGU("BUILDING PERMIT", "FOR REVIEW", "OBO")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _mSubClear()
        Try
            _oTxtLName.Value = ""
            _oTxtFName.Value = ""
            _oTxtMName.Value = ""
            _oTxtFormofOwnership.Value = ""
            _oTxtTINNo.Value = ""
            _oTxtNoStrt.Value = ""
            _oTxtBrgy.Value = ""
            _oTxtCity.Value = ""
            _oTxtProvince.Value = ""
            _oTxtZIPCode.Value = ""
            _oTxtEmail.Value = ""
            _oTxtTelNo.Value = ""
            _oTxtBlkNoLOC.Value = ""
            _oTxtLotNoLOC.Value = ""
            _oTxtStreetLOC.Value = ""
            _oTxtBrgyLOC.Value = ""
            _oTxtCityLOC.Value = ""
            _oTxtTCTNo.Value = ""
            _oTxtTDN.Value = ""
            _oTxtCTCNo.Value = ""
            _oTxtCTCDateIssued.Value = ""
            _oTxtCTCPlaceIssued.Value = ""
            _oTxtTotArea.Value = ""
            Session("AppNo") = ""
            SubLoadRequirements(True)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub _mSubUpdateDone(ByVal _nAppNo As String)
        Try

            Dim _nSqlCmd As SqlCommand = New SqlCommand("UPDATE ApplicationPermit set Done = 1 , LockForReview = 1 where UserID = '" & Session("UserID") & "' and AppNo = '" & _nAppNo & "'", cGlobalConnections._pSqlCxn_EIMS)
            _nSqlCmd.ExecuteNonQuery()
            _nSqlCmd.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _mSubUpdateRejectStatus(ByVal _nAppNo As String)
        Try

            Dim _nSqlCmd As SqlCommand = New SqlCommand("UPDATE ApplicationPermit set Updated = 1 where UserID = '" & Session("UserID") & "' and AppNo = '" & _nAppNo & "'", cGlobalConnections._pSqlCxn_EIMS)
            _nSqlCmd.ExecuteNonQuery()
            _nSqlCmd.Dispose()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SubCheckRequirements()
        Try
            Dim x As String
            For Each row As GridViewRow In _oGvUpload.Rows


                x = DirectCast(row.FindControl("_oLblStatus"), Label).Text()
                If x = "" Or x = "Rejected" Then
                    GoTo SkipLoop
                End If
            Next
            _oBtnSubmit.Disabled = False
            Exit Sub
SkipLoop:
            _oBtnSubmit.Disabled = True
            Exit Sub
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadTextFields(ByVal _nAppNo As String)
        Try
            Dim _nSqlCmd As SqlCommand
            Dim _mRdr As SqlDataReader

            _nSqlCmd = New SqlCommand("SELECT * FROM ApplicationPermit Where AppNo = '" & _nAppNo & "'", cGlobalConnections._pSqlCxn_EIMS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
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
                _oTxtUserID.Value = cSessionUser._pUserID
                _oTxtTelNo.Value = _mRdr.Item("TelNo").ToString
                _oTxtBlkNoLOC.Value = _mRdr.Item("BlkNoLOC").ToString
                _oTxtLotNoLOC.Value = _mRdr.Item("LotNoLOC").ToString
                _oTxtStreetLOC.Value = _mRdr.Item("StreetLOC").ToString
                _oTxtBrgyLOC.Value = _mRdr.Item("BrgyLOC").ToString
                _oTxtCityLOC.Value = _mRdr.Item("CityLOC").ToString
                _oTxtTCTNo.Value = _mRdr.Item("TCTNo").ToString
                _oTxtTDN.Value = _mRdr.Item("TDN").ToString
                _oTxtTotArea.Value = _mRdr.Item("Tot_Area").ToString
                Session("TransNo") = _mRdr.Item("TransNo").ToString
                Session("LastName") = _oTxtLName.Value
                Session("FirstName") = _oTxtFName.Value
                Session("MiddleName") = _oTxtMName.Value
                Session("OwnershipType") = _oTxtFormofOwnership.Value
                Session("TIN") = _oTxtTINNo.Value
                Session("NoStrtVillage") = _oTxtNoStrt.Value
                Session("Brgy") = _oTxtBrgy.Value
                Session("City") = _oTxtCity.Value
                Session("Province") = _oTxtProvince.Value
                Session("ZIPCode") = _oTxtZIPCode.Value
                Session("Email") = _oTxtEmail.Value
                Session("TelNo") = _oTxtTelNo.Value
                Session("LotNoLOC") = _oTxtLotNoLOC.Value
                Session("BlkNoLOC") = _oTxtBlkNoLOC.Value
                Session("StreetLOC") = _oTxtStreetLOC.Value
                Session("BrgyLOC") = _oTxtBrgyLOC.Value
                Session("CityLOC") = _oTxtCityLOC.Value
                Session("TCTNo") = _oTxtTCTNo.Value
                Session("TDN") = _oTxtTDN.Value
                Session("Tot_Area") = _oTxtTotArea.Value
                Session("PermitType") = _mRdr.Item("PermitType").ToString
                Session("AppDate") = _mRdr.Item("AppDate").ToString
                Session("Status") = _mRdr.Item("Status").ToString
                Session("ServiceType") = _mRdr.Item("ServiceType").ToString
                _oTxtCTCNo.Value = _mRdr.Item("CTC_No").ToString
                Dim _nDateIssued As String = Format(CDate(_mRdr.Item("CTC_DateIssued").ToString), "yyyy-MM-dd").ToString
                _oTxtCTCDateIssued.Value = _nDateIssued
                _oTxtCTCPlaceIssued.Value = _mRdr.Item("CTC_PlaceIssued").ToString
                Session("Done") = _mRdr.Item("Done")
                Session("Assessment") = _mRdr.Item("Assessment")
                Session("Payment") = _mRdr.Item("Payment")
                Session("Updated") = _mRdr.Item("Updated")

            End If
            _nSqlCmd.Dispose()
            _mRdr.Dispose()

        Catch ex As Exception

        End Try
    End Sub
    Private Function SubCheckExistingApp(ByVal _nUserID As String) As String
        Try
            Dim _nSqlCmd As SqlCommand
            Dim _mRdr As SqlDataReader
            _nSqlCmd = New SqlCommand("SELECT * FROM ApplicationPermit where UserID = '" & _nUserID & "' and Done = 0", cGlobalConnections._pSqlCxn_EIMS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
                Session("AppNo") = _mRdr.Item("AppNo").ToString
                Return _mRdr.Item("AppNo").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub SubLoadRequirements(ByVal _nBool As Boolean)
        Try
            'If _nBool = False Then
            '    _mCondWhere = " where LinkCode = 'B-01'"
            'Else
            '    _mCondWhere = " where LinkCode = 'B-01' and AppNo='" & Session("AppNo") & "'"
            'End If
            If Session("AppNo") = "" Then
                _oBtnUploadRequirements.Disabled = True
            Else
                _oBtnUploadRequirements.Disabled = False
            End If

            _oGvUpload.Visible = True
            CDalReqDocExtn_IUD._pSqlCon = cGlobalConnections._pSqlCxn_EIMS
            CDalReqDocExtn_IUD._pSubSelectReq(_nBool, Session("AppNo"), "B-01", Nothing, _mCondWhere, _mRecCnt)
            _nSubtbl = CDalReqDocExtn_IUD._pDataTable
            _oGvUpload.DataSource = Nothing
            _oGvUpload.DataBind()
            _oGvUpload.DataSource = _nSubtbl
            _oGvUpload.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _oBtnUploadRequirements_ServerClick(sender As Object, e As EventArgs) Handles _oBtnUploadRequirements.ServerClick
        Try
            Try
                If Session("AppNo") = "" Then Exit Sub
                Dim xHasFile As Boolean = False
                For Each row As GridViewRow In _oGvUpload.Rows
                    Dim file As FileUpload = CType(row.FindControl("_oFileUploadRequirements"), FileUpload)
                    If file.HasFile Then
                        Dim SeqID As String = "001" 'image ID
                        Dim _nFilename = Path.GetFileName(file.FileName)
                        Dim _nFileExtension As String = Path.GetExtension(_nFilename)
                        Dim nDescription = DirectCast(row.FindControl("_oLblDesc2Req"), Label).Text
                        Dim _nReqCode As String = DirectCast(row.FindControl("_oLblCodeReq"), Label).Text
                        Dim FileData As HttpPostedFile = file.PostedFile
                        Dim fs As Stream = FileData.InputStream
                        Dim br As New BinaryReader(fs)
                        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                        Dim _nStatus As String = "For Review"
                        SubDeleteAttachedFiles(_nReqCode, Session("AppNo"))
                        SubInsertAttachFiles(Session("TransNo"), Session("AppNo"), _nReqCode, _nFilename, bytes, _nFileExtension, _nStatus)
                        xHasFile = True
                    End If

                Next
                SubLoadRequirements(True)
                SubCheckRequirements()
                If xHasFile = False Then snackbar("red", "No file uploaded.") : Exit Sub
                snackbar("green", "Successfully saved!")
            Catch ex As Exception
                snackbar("red", ex.ToString())

            End Try
        Catch ex As Exception

        End Try

    End Sub

    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub
    Private Sub UploadRequirements()
        Try
            If Session("AppNo") = "" Then Exit Sub
            For Each row As GridViewRow In _oGvUpload.Rows
                Dim file As FileUpload = CType(row.FindControl("_oFileUploadRequirements"), FileUpload)
                If file.HasFile Then
                    Dim SeqID As String = "001" 'image ID
                    Dim _nFilename = Path.GetFileName(file.FileName)
                    Dim _nFileExtension As String = Path.GetExtension(_nFilename)
                    Dim nDescription = DirectCast(row.FindControl("_oLblDesc2Req"), Label).Text
                    Dim _nReqCode As String = DirectCast(row.FindControl("_oLblCodeReq"), Label).Text
                    Dim FileData As HttpPostedFile = file.PostedFile
                    Dim fs As Stream = FileData.InputStream
                    Dim br As New BinaryReader(fs)
                    Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                    Dim _nStatus As String = "For Review"
                    cDalRequirements_OBO.SubDeleteAttachedFiles(_nReqCode, Session("AppNo"), Session("TransNo"))
                    cDalRequirements_OBO.SubInsertAttachFiles(Session("TransNo"), Session("AppNo"), _nReqCode, _nFilename, bytes, _nFileExtension, _nStatus)
                End If

            Next

            snackbar("green", "Successfully saved!")
        Catch ex As Exception
            snackbar("red", ex.ToString())

        End Try
    End Sub
    Private Sub SubDeleteAttachedFiles(ByVal _nReqCode As String, ByVal _nAppNo As String)
        Try

            Dim _nSqlCmd As SqlCommand
            _nSqlCmd = New SqlCommand("Delete from UploadedReq where AppNo = '" & _nAppNo & "' and ReqCode = '" & _nReqCode & "'", cGlobalConnections._pSqlCxn_EIMS)
            _nSqlCmd.ExecuteNonQuery()
            _nSqlCmd.Dispose()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub SubInsertAttachFiles(TransID, AppNo, AttCode, AttDesc, AttFile, AttType, Status)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO UploadedReq" & _
                "(TransID, ReqCode, AppNo, ReqDesc, AttFile, AttType, Status, Remarks,IsReject)" & _
                " VALUES(@TransID,@AttCode,@AppNo,@AttDesc,@AttFile,@AttType,@Status,null,0) "
            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)

            With _nSqlCommand.Parameters
                .AddWithValue("@TransID", TransID)
                .AddWithValue("@AttCode", AttCode)
                .AddWithValue("@AppNo", AppNo)
                .AddWithValue("@AttDesc", AttDesc)
                .AddWithValue("@AttFile", AttFile)
                .AddWithValue("@AttType", AttType)
                .AddWithValue("@Status", Status)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Private Sub PassValueToSession()
        Try

            cDalAutoGenID._pSqlCon = cGlobalConnections._pSqlCxn_EIMS
            cDalGetSpecificValue._pSqlCon = cGlobalConnections._pSqlCxn_EIMS
            If Session("Edit") = "" Or Session("Edit") = Nothing Then
                Session("AppNo") = cDalAutoGenID._FnAutoGenID("AppNo", cDalGetServer._FnServerHHmmss & "-" & "B-01-WEB") ''cDalAutoGenID._FnAutoGenID("AppNo", "B-01")
                Session("TransNo") = cDalAutoGenID._FnAutoGenID("TransNo", "B01")
            End If

            Session("LastName") = _oTxtLName.Value
            Session("FirstName") = _oTxtFName.Value
            Session("MiddleName") = _oTxtMName.Value
            Session("OwnershipType") = _oTxtFormofOwnership.Value
            Session("TIN") = _oTxtTINNo.Value
            Session("NoStrtVillage") = _oTxtNoStrt.Value
            Session("Brgy") = _oTxtBrgy.Value
            Session("City") = _oTxtCity.Value
            Session("Province") = _oTxtProvince.Value
            Session("ZIPCode") = _oTxtZIPCode.Value
            Session("Email") = _oTxtEmail.Value
            Session("TelNo") = _oTxtTelNo.Value
            Session("LotNoLOC") = _oTxtLotNoLOC.Value
            Session("BlkNoLOC") = _oTxtBlkNoLOC.Value
            Session("StreetLOC") = _oTxtStreetLOC.Value
            Session("BrgyLOC") = _oTxtBrgyLOC.Value
            Session("CityLOC") = _oTxtCityLOC.Value
            Session("TCTNo") = _oTxtTCTNo.Value
            Session("TDN") = _oTxtTDN.Value
            Session("Tot_Area") = _oTxtTotArea.Value
            Session("PermitType") = "B-01"
            Session("AppDate") = cDalGetSpecificValue._FnGetServerDate
            Session("Status") = "For Review"
            Session("ServiceType") = "Building Permit"
            Session("ServiceDescription") = "New Application"
            Session("CTC_No") = _oTxtCTCNo.Value
            Session("CTC_DateIssued") = _oTxtCTCDateIssued.Value
            Session("CTC_PlaceIssued") = _oTxtCTCPlaceIssued.Value
            Session("Done") = 0

            Session("EMS_AcctNo") = ""
            Session("EMS_SubAcctNo") = ""
            Session("Bldg_PermitNo") = ""
            Session("PermitType") = "B-01"
            'Session("AppNo") = Session("AppNo")
            Session("AreaNo") = ""
            Session("OAPCode") = ""
            Session("IDCode") = ""
            Session("LName") = _oTxtLName.Value
            Session("FName") = _oTxtFName.Value
            Session("MName") = _oTxtMName.Value
            Session("TIN") = _oTxtTINNo.Value
            Session("OwnCode") = _oTxtFormofOwnership.Value
            Session("Owner_Address") = ""
            Session("LotNo") = _oTxtLotNoLOC.Value
            Session("BlkNo") = _oTxtBlkNoLOC.Value
            Session("StrtCode") = _oTxtStreetLOC.Value
            Session("BrgyCode") = _oTxtBrgyLOC.Value
            Session("MuniCityCode") = _oTxtCityLOC.Value
            Session("TCTNo") = _oTxtTCTNo.Value
            Session("TDN") = _oTxtTDN.Value
            Session("PIN") = ""
            'Session("ZipCode") = ""
            Session("TellNo") = ""
            Session("CellNo") = ""
            Session("AppDate") = cDalGetSpecificValue._FnGetServerDate
            Session("NoOfStorey") = "0"
            Session("NoOfUnits") = "0"
            Session("SW_Scope") = "0"
            Session("SW_UseCode") = "0"
            Session("AppDateSigned") = cDalGetSpecificValue._FnGetServerDate
            Session("Lot_IDCode") = "0"
            Session("Lot_ConsentDate") = cDalGetSpecificValue._FnGetServerDate
            Session("BldgIDCode") = ""
            Session("Bldg_ConsentDate") = cDalGetSpecificValue._FnGetServerDate
            Session("InspSup_Code") = ""
            Session("SW_Assess") = "0"
            Session("SW_Approved") = "0"
            Session("SW_Compl") = "0"
            Session("SW_Paid") = "0"
            Session("EncoderName") = ""
            Session("Subd_Village") = ""
            Session("SW_Billing") = "0"

        Catch ex As Exception

        End Try
    End Sub


    Private Sub SaveApplication(ByVal _nEdit As String)
        Try
            Dim _nSqlCmd As SqlCommand
            Dim _mRdr As SqlDataReader

            _nSqlCmd = New SqlCommand("SELECT IDCode from Applicant where EmailAddr = '" & Session.Item("UserID") & "'", cGlobalConnections._pSqlCxn_EIMS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
                Session("IDCode") = _mRdr.Item("IDCode").ToString
            Else
                Session("IDCode") = cDalAutoGenID._FnAutoGenID("PropertyOwnerIDCode") & "PROP"
            End If
            _nSqlCmd.Dispose()
            _mRdr.Dispose()
            If _nEdit = "" Then
                _nSqlCmd = New SqlCommand("INSERT INTO ApplicationPermit " & _
                                      "( AppNo,TransNo,UserID,LastName,FirstName,MiddleName,OwnershipType,TIN,NoStrtVillage,Brgy,City,Province,ZIPCode,Email,TelNo,LotNoLOC,BlkNoLOC,StreetLOC,BrgyLOC,CityLOC,TCTNo,TDN,Tot_Area,PermitType,AppDate,Status,ServiceType,ServiceDescription,CTC_No, CTC_DateIssued, CTC_PlaceIssued, Done, Assessment, Payment, Updated, Follow_Up_Date ) " & _
                                      " VALUES(" &
                                      "'" & Session("AppNo") & "'," &
                                      "'" & Session("TransNo") & "'," &
                                      "'" & Session("UserID") & "'," &
                                      "'" & Session("LastName") & "'," &
                                      "'" & Session("FirstName") & "'," &
                                      "'" & Session("MiddleName") & "'," &
                                      "'" & Session("OwnershipType") & "'," &
                                      "'" & Session("TIN") & "'," &
                                      "'" & Session("NoStrtVillage") & "'," &
                                      "'" & Session("Brgy") & "'," &
                                      "'" & Session("City") & "'," &
                                      "'" & Session("Province") & "'," &
                                      "'" & Session("ZIPCode") & "'," &
                                      "'" & Session("Email") & "'," &
                                      "'" & Session("TelNo") & "'," &
                                      "'" & Session("LotNoLOC") & "'," &
                                      "'" & Session("BlkNoLOC") & "'," &
                                      "'" & Session("StreetLOC") & "'," &
                                      "'" & Session("BrgyLOC") & "'," &
                                      "'" & Session("CityLOC") & "'," &
                                      "'" & Session("TCTNo") & "'," &
                                      "'" & Session("TDN") & "'," &
                                      "'" & Session("Tot_Area") & "'," &
                                      "'" & Session("PermitType") & "'," &
                                      "'" & Session("AppDate") & "'," &
                                      "'" & Session("Status") & "'," &
                                      "'" & Session("ServiceType") & "'," &
                                      "'" & Session("ServiceDescription") & "'," &
                                      "'" & Session("CTC_No") & "'," &
                                      "'" & Session("CTC_DateIssued") & "'," &
                                      "'" & Session("CTC_PlaceIssued") & "'," &
                                      "" & 0 & "," &
                                      "" & 0 & "," &
                                      "" & 0 & "," &
                                      "" & 0 & "," &
                                      " null " &
                                      ")", cGlobalConnections._pSqlCxn_EIMS)
                _nSqlCmd.ExecuteNonQuery()
                _nSqlCmd.Dispose()
                snackbar("green", "Successfully saved!")
            Else
                _nSqlCmd = New SqlCommand("Update ApplicationPermit " &
                                      "set AppNo = '" & Session("AppNo") & "'," &
                                      " TransNo = '" & Session("TransNo") & "'," &
                                      " UserID = '" & Session("UserID") & "'," &
                                      " LastName = '" & Session("LastName") & "'," &
                                      " FirstName = '" & Session("FirstName") & "'," &
                                      " MiddleName = '" & Session("MiddleName") & "'," &
                                      " OwnershipType = '" & Session("OwnershipType") & "'," &
                                      " TIN = '" & Session("TIN") & "'," &
                                      " NoStrtVillage = '" & Session("NoStrtVillage") & "'," &
                                      " Brgy = '" & Session("Brgy") & "'," &
                                      " City = '" & Session("City") & "'," &
                                      " Province = '" & Session("Province") & "'," &
                                      " ZIPCode = '" & Session("ZIPCode") & "'," &
                                      " Email = '" & Session("Email") & "'," &
                                      " TelNo = '" & Session("TelNo") & "'," &
                                      " LotNoLOC = '" & Session("LotNoLOC") & "'," &
                                      " BlkNoLOC = '" & Session("BlkNoLOC") & "'," &
                                      " StreetLOC = '" & Session("StreetLOC") & "'," &
                                      " BrgyLOC = '" & Session("BrgyLOC") & "'," &
                                      " CityLOC = '" & Session("CityLOC") & "'," &
                                      " TCTNo = '" & Session("TCTNo") & "'," &
                                      " TDN = '" & Session("TDN") & "'," &
                                      " Tot_Area = '" & Session("Tot_Area") & "'," &
                                      " PermitType = '" & Session("PermitType") & "'," &
                                      " AppDate = '" & Session("AppDate") & "'," &
                                      " Status = '" & Session("Status") & "'," &
                                      " ServiceType = '" & Session("ServiceType") & "'," &
                                      " ServiceDescription = '" & Session("ServiceDescription") & "'," &
                                      " CTC_No = '" & Session("CTC_No") & "'," &
                                      " CTC_DateIssued = '" & Session("CTC_DateIssued") & "'," &
                                      " CTC_PlaceIssued = '" & Session("CTC_PlaceIssued") & "'," &
                                      " Done = " & IIf(Session("Done").ToString = "", 1, 0) & "," &
                                      " Assessment = " & IIf(Session("Assessment").ToString = "", 1, 0) & "," &
                                      " Payment = " & IIf(Session("Payment").ToString = "", 1, 0) & "," &
                                      " Updated = " & IIf(Session("Updated").ToString = "", 1, 0) & "" &
                                      " where AppNo = '" & Session("AppNo") & "'", cGlobalConnections._pSqlCxn_EIMS)
                _nSqlCmd.ExecuteNonQuery()
                _nSqlCmd.Dispose()
                snackbar("green", "Successfully saved!")
            End If

            '_nSqlCmd = New SqlCommand("INSERT INTO Applicant " & _
            '                          "( IDCode, FName, MName, LName, TIN , EmailAddr , ApplCode,  encoderID )" &
            '                          " VALUES " &
            '                          " ( " &
            '                              " '" & Session("IDCode") & "' ," &
            '                              " '" & Session("FirstName") & "'," &
            '                              " '" & Session("LastName") & "'," &
            '                              " '" & Session("MiddleName") & "'," &
            '                               "'" & Session("TIN") & "'," &
            '                             "'" & cSessionUser._pUserID & "', " &
            '                            "'O'," &
            '                            "'x'" &
            '                          ")", cGlobalConnections._pSqlCxn_EIMS)
            '_nSqlCmd.ExecuteNonQuery()
            '_nSqlCmd.Dispose()

            '_nSqlCmd = New SqlCommand("INSERT INTO ApplicationMaster " & _
            '                          "(  EMS_AcctNo " & _
            '                          ",EMS_SubAcctNo " & _
            '                          ",Bldg_PermitNo " & _
            '                          ",PermitType " & _
            '                          ",AppNo " & _
            '                          ",AreaNo " & _
            '                          ",OAPCode " & _
            '                          ",IDCode " & _
            '                          ",LName " & _
            '                          ",FName " & _
            '                          ",MName " & _
            '                          ",TIN " & _
            '                          ",OwnCode " & _
            '                          ",Owner_Address " & _
            '                          ",LotNo " & _
            '                          ",BlkNo " & _
            '                          ",StrtCode " & _
            '                          ",BrgyCode " & _
            '                          ",MuniCityCode " & _
            '                          ",TCTNo " & _
            '                          ",TDN " & _
            '                          ",PIN " & _
            '                          ",ZipCode " & _
            '                          ",TellNo " & _
            '                          ",CellNo " & _
            '                          ",AppDate " & _
            '                          ",NoOfStorey " & _
            '                          ",NoOfUnits " & _
            '                          ",SW_Scope " & _
            '                          ",SW_UseCode " & _
            '                          ",AppDateSigned " & _
            '                          ",Lot_IDCode " & _
            '                          ",Lot_ConsentDate " & _
            '                          ",Bldg_IDCode " & _
            '                          ",Bldg_ConsentDate " & _
            '                          ",InspSup_Code " & _
            '                          ",SW_Assess " & _
            '                          ",SW_Approved " & _
            '                          ",SW_Compl " & _
            '                          ",SW_Paid " & _
            '                          ",EncoderName " & _
            '                          ",Subd_Village " & _
            '                          ",SW_Billing )" & _
            '                          " VALUES  " & _
            '                          " ( '" & Session("EMS_AcctNo") & "'," &
            '                          "'" & Session("EMS_SubAcctNo") & "'," &
            '                          "'" & Session("Bldg_PermitNo") & "'," &
            '                          "'" & Session("PermitType") & "'," &
            '                          "'" & Session("AppNo") & "'," &
            '                          "'" & Session("AreaNo") & "'," &
            '                          "'" & Session("OAPCode") & "'," &
            '                          "'" & Session("IDCode") & "'," &
            '                          "'" & Session("LName") & "'," &
            '                          "'" & Session("FName") & "'," &
            '                          "'" & Session("MName") & "'," &
            '                          "'" & Session("TIN") & "'," &
            '                          "'" & Session("OwnCode") & "'," &
            '                          "'" & Session("Owner_Address") & "'," &
            '                          "'" & Session("LotNo") & "'," &
            '                          "'" & Session("BlkNo") & "'," &
            '                          "'" & Session("StrtCode") & "'," &
            '                          "'" & Session("BrgyCode") & "'," &
            '                          "'" & Session("MuniCityCode") & "'," &
            '                          "'" & Session("TCTNo") & "'," &
            '                          "'" & Session("TDN") & "'," &
            '                          "'" & Session("PIN") & "'," &
            '                          "'" & Session("ZipCode") & "'," &
            '                          "'" & Session("TellNo") & "'," &
            '                          "'" & Session("CellNo") & "'," &
            '                          "'" & Session("AppDate") & "'," &
            '                          "'" & Session("NoOfStorey") & "'," &
            '                          "'" & Session("NoOfUnits") & "'," &
            '                          "'" & Session("SW_Scope") & "'," &
            '                          "'" & Session("SW_UseCode") & "'," &
            '                          "'" & Session("AppDateSigned") & "'," &
            '                          "'" & Session("Lot_IDCode") & "'," &
            '                          "'" & Session("Lot_ConsentDate") & "'," &
            '                          "'" & Session("Bldg_IDCode") & "'," &
            '                          "'" & Session("Bldg_ConsentDate") & "'," &
            '                          "'" & Session("InspSup_Code") & "'," &
            '                          "'" & Session("SW_Assess") & "'," &
            '                          "'" & 1 & "'," &
            '                          "'" & Session("SW_Compl") & "'," &
            '                          "'" & Session("SW_Paid") & "'," &
            '                          "'" & Session("EncoderName") & "'," &
            '                          "'" & Session("Subd_Village") & "'," &
            '                          "'" & Session("SW_Billing") & "'" &
            '                          ")", cGlobalConnections._pSqlCxn_EIMS)
            '_nSqlCmd.ExecuteNonQuery()
            '_nSqlCmd.Dispose()
            If _nEdit = "" Then
                'SaveApplication_extn()
            End If
        Catch ex As Exception
            snackbar("red", ex.ToString())
        End Try
    End Sub
    Private Sub SaveApplication_extn()
        Try
            cDalGetSpecificValue._pSqlCon = cGlobalConnections._pSqlCxn_EIMS

            Dim _nSqlCmd As SqlCommand
            Dim _mRdr As SqlDataReader
            _nSqlCmd = New SqlCommand("SELECT IDCode from Applicant where EmailAddr = '" & Session.Item("UserID") & "'", cGlobalConnections._pSqlCxn_EIMS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
                Session("IDCode") = _mRdr.Item("IDCode").ToString
            End If
            _nSqlCmd.Dispose()
            _mRdr.Dispose()
            _nSqlCmd = New SqlCommand("INSERT INTO applicant_extn VALUES(" &
                                      "'" & Session("IDCode") & "'," &
                                      "'" & Session("AppNo") & "'," &
                                      "'A'," &
                                      "CONVERT(varchar,GETDATE(),1)," &
                                      "CONVERT(varchar,GETDATE(),1)," &
                                      "''," &
                                      "CONVERT(varchar,GETDATE(),1)" &
                                  ")", cGlobalConnections._pSqlCxn_EIMS)
            _nSqlCmd.ExecuteNonQuery()
            _nSqlCmd.Dispose()
            'snackbar("green", "Successfully saved!")                        
        Catch ex As Exception
            snackbar("red", ex.ToString())
        End Try
    End Sub
    Private Sub _mSubLoadOwnershipTypeComboboxData()

        Try
            _mSubLoadOwnershipType(_nSuccessful)

            If cDalOwnershipType._pDataTable.Columns.Count > 0 Then

                _oTxtFormofOwnership.DataSource = _mDTOwnCode
                _oTxtFormofOwnership.DataTextField = "Desc2"
                _oTxtFormofOwnership.DataValueField = "Desc1"
                _oTxtFormofOwnership.DataBind()

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub _mSubLoadOwnershipType(ByVal _nBool As Boolean, Optional _nCondition As String = Nothing)

        Try

            cDalOwnershipType._pSqlCon = cGlobalConnections._pSqlCxn_EIMS 'set the connection of class
            cDalOwnershipType._pSubSelect(True, _nCondition) 'load record
            _mDTOwnCode = cDalOwnershipType._pDataTable 'transfer/clone class datatable to your data table
            cDalOwnershipType._pDataTable.Dispose() 'dispose the class datatable

        Catch ex As Exception

        End Try

    End Sub
    'Public Sub SubInsertHistory(AppDate, TransID, AttDesc, AttType, Status, Userid)
    '    Try
    '        Dim _nQuery As String = Nothing
    '        _nQuery = "INSERT INTO transaction_history VALUES(@TransID,@Date,@Status,@AttType,@AttDesc,@UserId)"
    '        Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_EIMS)

    '        With _nSqlCommand.Parameters
    '            .AddWithValue("@TransID", TransID)
    '            .AddWithValue("@Date", AppDate)
    '            .AddWithValue("@AttDesc", AttDesc)
    '            .AddWithValue("@AttType", AttType)
    '            .AddWithValue("@Status", Status)
    '            .AddWithValue("@Userid", Userid)
    '        End With
    '        '----------------------------------
    '        _nSqlCommand.ExecuteNonQuery()
    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try
    'End Sub

End Class