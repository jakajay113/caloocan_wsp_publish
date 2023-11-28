<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUPermitMaster.Master" CodeBehind="BUILDINGPERMIT_OBO.aspx.vb" Inherits="OBO.BUILDINGPERMIT_OBO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="snackbar" style="position: absolute; z-index: 2000 !Important;">
                <asp:Label runat="server" ID="_oLabelSnackbar" />
            </div>
            <div id="snackbargreen" style="position: absolute; z-index: 2000 !Important;">
                <asp:Label runat="server" ID="_oLabelSnackbargreen" />
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    


     <script type="text/javascript">
         var grid_modal_options = {
             height: 200,
             width: 500,
             resizable: false,
             modal: true
         };

         function shopModalPopupIWait() {
             $("#dialog-form").dialog(grid_modal_options);
             $("#dialog-form").parent().appendTo('form:first');
         }
     </script>
    <script>    
        //SNACKBAR - Welcome       
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }
        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }
    </script>

    <script type="text/javascript">
        function TrapAssessment_xx() {
            var SelPrt = 0;
            $("#<%=_oGvUpload.ClientID%> input[id*='mycheckbox']:checkbox").each(function (index) {
                if ($(this).is(':checked'))
                    SelPrt++;
            });
            if (SelPrt > 0) {
                alert('Cannot proceed, \n (' + SelPrt + ') reject requirement/s detected.');
                // do procedure here
            } else {

                document.getElementById('<%=hdnaction.ClientID%>').value = 'APPROVE FOR ASSESSMENT';
                document.getElementById("_obtnApprove").click();
            }
           
        }

        function TrapDisapprove_x() {
            var SelPrt = 0;
            $("#<%=_oGvUpload.ClientID%> input[id*='mycheckbox']:checkbox").each(function (index) {
                if ($(this).is(':checked'))
                    SelPrt++;
            });
            if (SelPrt > 0) {
                document.getElementById('<%=hdnaction.ClientID%>').value = 'DECLINE';
                document.getElementById("_oBtn_Decline").click();
                // do procedure here
            } else {
                alert('Cannot proceed, no reject requirement detected');
            }

        }

        function TrapAssessment() {
            //alert('Hi');
            // debugger;
            var gv = document.getElementById("<%=_oGvUpload.ClientID%>");
            var gvRowCount = gv.rows.length;
            var rwIndex = 1;
            var ForReview = 0
            for (rwIndex; rwIndex <= gvRowCount - 1; rwIndex++) {
   
                if (gv.rows[rwIndex].cells[2].childNodes[1].innerHTML == 'For Review') {
                    ForReview++
                }

            }
            if (ForReview > 0) {
                alert('Cannot proceed, please review all the requirements submitted');
                return false;

            } else {
                var SelPrt = 0;
                $("#<%=_oGvUpload.ClientID%> input[id*='mycheckbox']:checkbox").each(function (index) {
                    if ($(this).is(':checked'))
                       SelPrt++;
               });
               if (SelPrt > 0) {
                   alert('Cannot proceed, \n (' + SelPrt + ') reject requirement/s detected.');
                   // do procedure here
               } else {

                   if (confirm('Confirm Approve for Assessment?')) {
                       document.getElementById('<%=hdnaction.ClientID%>').value = 'APPROVE FOR ASSESSMENT';
                       document.getElementById("<%=_obtnConfirmStatus.ClientID%>").click();
                   };
            }

           }

       }

        function TrapDisapprove() {
            //alert('Hi');
            // debugger;
            var gv = document.getElementById("<%=_oGvUpload.ClientID%>");
              var gvRowCount = gv.rows.length;
              var rwIndex = 1;
              var ForReview = 0
              for (rwIndex; rwIndex <= gvRowCount - 1; rwIndex++) {
                  if (gv.rows[rwIndex].cells[2].childNodes[1].innerHTML == 'For Review') {
                      ForReview++
                  }

              }
              if (ForReview > 0) {
                  alert('Cannot proceed, please review all the requirements submitted.');
                  return false;
              } else {

                  var SelPrt = 0;
                  $("#<%=_oGvUpload.ClientID%> input[id*='mycheckbox']:checkbox").each(function (index) {
                   if ($(this).is(':checked'))
                       SelPrt++;
               });
                  if (SelPrt > 0) {

                      if (confirm('Confirm disapprove application?')) {
                          document.getElementById('<%=hdnaction.ClientID%>').value = 'DECLINE';
                           document.getElementById("<%=_obtnConfirmStatus.ClientID%>").click();
                       };
                        // do procedure here
                    } else {
                        alert('Cannot proceed, no reject requirement detected');
                    }

                }

        }

        function ConfirmSaveReqStatus() {
            if (confirm('Confirm Save requirement status?')) {
                document.getElementById("_oBtnSaveReqStatus").click();
             };

        }
</script>


   

    <div class="col-lg-12 card px-0 row">
        <div class="card-header col-lg-12">
            <h4 class="font-weight-bold text-primary ">APPLICATION & REQUIREMENT VALIDATION</h4>
        </div>
    </div>

    <div class="col-lg-12 row mt-4">
         <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Transaction Number: </h6>
            </div>
           
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2"> </span></span></label>
                <input type="text" style="font-size:larger" class="form-control CH-Size-new" name=""  id="_oTxtTransNo" placeholder="" runat="server" readonly />
            </div>

               <div class="col-lg-1 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Service type: </h6>
            </div>
           
            <div class="col-lg-5 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2"> </span></span></label>
                <input type="text" style="font-size:larger" class="form-control CH-Size-new" name=""  id="_oTxtServiceType" placeholder="" runat="server" readonly />
            </div>

         </div>
      
    </div>

    <div class="col-lg-12 row mt-4">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Owner/Applicant: </h6>
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Last Name</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLName" placeholder="" runat="server" readonly />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">First Name</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtFName" placeholder="" runat="server" readonly />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Middle Name</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtMName" placeholder="" runat="server" readonly />
            </div>
        </div>
    </div>

    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">
                    <%--Form of Ownership:--%> 
                </h6>
            </div>
            <div class="col-lg-3 form-group">
                   <label class="input-txt input-txt-active2"><span> <span class="m-2">Form of Ownership <b> <span style="color:red"> &nbsp  </span> </b> </span></span></label>
                <select class="form-control CH-Size-new" id="_oTxtFormofOwnership" runat="server" disabled>
                    <option>Sample</option>
                </select>
            </div>

             <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span> <span class="m-2">Occupancy Classification <b> <span style="color:red"> &nbsp  </span> </b> </span></span></label>
                <select class="form-control CH-Size-new" id="_oDropDownClassification" runat="server" disabled>
                    <option>Sample</option>
                </select>
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">TIN: </h6>
            </div>
            <div class="col-lg-3 form-group">
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTINNo" runat="server" placeholder="XXX-XXX-XXX-XXX"    maxlength="15" readonly />
            </div>
        </div>
    </div>

         <div class="col-lg-12 row" ">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">CTC: </h6>
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">CTC No.</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCTCNo" placeholder=""  runat="server" readonly/>
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Date Issued</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCTCDateIssued"   onfocus="(this.type='date')" placeholder="" runat="server" readonly/>
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Place Issued</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCTCPlaceIssued" placeholder="" runat="server" readonly/>
            </div>
        </div>
    </div>

    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Address: </h6>
            </div>
            <div class="col-lg-6 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">No/Street & Village</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtNoStrt" placeholder="" runat="server" readonly />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Barangay</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBrgy" placeholder="" runat="server" readonly />
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCity" placeholder="" runat="server" readonly />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Province</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtProvince" placeholder="" runat="server" readonly />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">ZIP Code</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtZIPCode" placeholder="" runat="server" readonly />
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Contact: </h6>
            </div>
              <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Registered Email</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtRegEmail" placeholder="" runat="server" readonly />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Alternate Email</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtEmail" placeholder="" runat="server" readonly />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Telephone/Mobile No.</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTelNo" placeholder="" runat="server" readonly />
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-12 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Location of Construction: </h6>
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class=" col-lg-12 row">
                <div class="col-lg-1 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Lot No</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLotNoLOC" placeholder="" runat="server" readonly />
                </div>
                <div class="col-lg-1 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Blk No.</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBlkNoLOC" placeholder="" runat="server" readonly />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Street</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtStreetLOC" placeholder="" runat="server" readonly />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Barangay</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBrgyLOC" placeholder="" runat="server" readonly />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCityLOC" placeholder="" runat="server" readonly />
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class=" col-lg-12 row">
                <div class="col-lg-2 form-group">
                     <label class="input-txt input-txt-active2"><span><span class="m-2">PIN No.  <b> <span style="color:red"> &nbsp  </span> </b> </span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtPIN" placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">TCT No.</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTCTNo" placeholder="" runat="server" readonly />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Tax Declaration No.</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTDN" placeholder="" runat="server" readonly />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Total Area</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTotArea" placeholder="" runat="server" readonly />
                </div>
            </div>
        </div>
    </div>



    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-12 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Submitted Requirement</h6>
            </div>
        </div>
    </div>
    <div class="col-lg-12 row table-responsive">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="_oGvUpload" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                    <Columns>
                        <asp:TemplateField HeaderText="Transaction ID" Visible="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblTansId" runat="server" Text='<%# Eval("TransID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code"  ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblCodeReq" runat="server" Text='<%# Eval("ReqCode")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Requirement Description" Visible="true" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblDesc2" runat="server" Text='<%# Eval("desc2")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField Visible="false" HeaderText="Filename" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="30%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblReqDesc" runat="server" Text='<%# Eval("ReqDesc")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblStatus" runat="server" Text='<%# Eval("Status")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                            <ItemTemplate>
                                <asp:TextBox ID="_oTxtRemarks" Width="95%" runat="server" Text='<%# Eval("Remarks")%>' > </asp:TextBox>
                             <%--   <asp:Label ID="_oLblRemarks" runat="server" Text='<%# Eval("Remarks")%>' />--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reject" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%">
                            <ItemTemplate>
                                 <asp:CheckBox ID="mycheckbox" runat="server" CssClass="checkmark"  Checked='<%#Convert.ToBoolean(Eval("IsReject"))%>'   />
                                <%--Checked='<%#Eval("APPR")==DBNull.Value?  false:Eval("APPR") %>'--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <%--<a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab();ViewSPA('ReqDesc','AttType','AttFile','<%# Eval("ReqCode")%>');">View</a>--%>
                                <%--<a href="#" onclick="ViewSPA('ReqDesc','AttType','AttFile','<%# Eval("ReqCode")%>','<%# Eval("TransID")%>');" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" >View</a>--%>
                                <%--&nbsp |   &nbsp --%>
                                <a name="btndownload" download="<%# Eval("FileName")%>" href="<%# Eval("File64")%>"    target="_blank"  style="font-size: 14px !Important; height: 30px !Important; max-width:100px !Important;" >  Download  </a>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Mandatory" Visible="false">
                            <ItemTemplate>
                               <%-- <asp:LinkButton id="_oLinkPreview"  href="ViewImage.aspx?ReqCode=<%# Eval("Code")%>"  target="_blank"  runat="server"  > View uploaded </asp:LinkButton>--%>
                                   <asp:Label ID="_oLblMandatory" runat="server" Text='<%# Eval("Mandatory")%>' />
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button class="btn btn-success" Visible="false" ID="btnDownloadAll" runat="server" Text="Download" OnClientClick="Test();"   />
                <div class="col-lg-12 row">

                    <div class=" col-lg-12 row justify-content-end d-flex">
                        

                    <button type="button" class="btn btn-primary btn-icon-split"  onclick="ConfirmSaveReqStatus();" >
                         <span class="text">Save requirement status</span>
                            <span class="icon text-white-50">
                                <i class="fas fa-save mt-1"></i>
                            </span>
                    </button> 

                    <button type="button" style="display:none;" id="_oBtnSaveReqStatus" class="btn btn-primary btn-icon-split"  onclick="DisplayLoadingFromMaster();SaveReqStatus();" >
                         <span class="text">Save requirement status</span>
                            <span class="icon text-white-50">
                                <i class="fas fa-save mt-1"></i>
                            </span>
                    </button> 

                    &nbsp          &nbsp          &nbsp
                    <button type="button" class="btn btn-primary btn-icon-split"  onclick="DownloadAllFiles();" >
                         <span class="text">Download All</span>
                            <span class="icon text-white-50">
                                <i class="fas fa-download mt-1"></i>
                            </span>
                    </button>

                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="col-lg-12 row" style="display:none;" >





        <div class=" col-lg-12 row">
            <div class="col-lg-1 form-group">
                <label class="mt-4">Findings: </label>
            </div>
            <div class="col-lg-4 form-group">
                <select class="form-control CH-Size-new mt-3" id="_oCbFindings" runat="server">
                    <option>...</option>
                    <option>Incomplete Requirements</option>
                </select>
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-12 form-group">
                <textarea class="form-control CH-Size mt-2" placeholder="Comments" runat="server" id="_oTxtComments" style="height: 100px;"></textarea>
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row justify-content-end d-flex">            
            <%--<div class="col-lg-3 form-group">
                <button name="_oBtnSaveApplication" runat="server" id="_oBtnSend" type="button" class="btn btn-success btn-icon-split">
                    <span class="text">Send Notification</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>

                </button>

            </div>--%>

                            <button name="_oBtnEdit" visible="false" runat="server" id="_oBtnSave" type="button" class="m-2 btn btn-warning btn-icon-split" onclick="__doPostBack('Save', '')">
                    <span class="text">Save</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>
                </button>
                      

            <asp:UpdatePanel runat="server" class="m-2">
                <ContentTemplate>
                    <%--<asp:Button runat="server" class="btn btn-danger" Text="No" OnClick="SubApproveAction_Click"/>--%>
                    <button visible="false" name="_oBtnSaveApplication" runat="server" id="_obtnNotifyClient" type="button" class="btn btn-success btn-icon-split"  onserverclick="SubNotifyClient_Click">
                        <span class="text">Send Notification</span>
                        <span class="icon text-white-50">
                            <i class="fas fa-cross mt-1"></i>
                        </span>

                    </button>

                    <button  type="button" class="btn btn-danger btn-icon-split"   onclick="TrapDisapprove()" >
                         <span class="text"> Disapprove application </span>
                        <span class="icon text-white-50">
                            <i class="fas fa-thumbs-down mt-1"></i>
                        </span>

                    </button>
                     <button  name="_oBtnDecline" id="_oBtn_Decline" type="button" class="btn btn-danger btn-icon-split" data-target="#PopupConfirmation" data-toggle="modal"   >
                       
                    </button>

                    <%--<asp:Button runat="server" class="btn btn-success" Text="Yes" OnClick="SubApproveAction_Click" />--%>
                </ContentTemplate>
            </asp:UpdatePanel>
            
               <button type="button" class="m-2 btn btn-success btn-icon-split"  onclick="TrapAssessment()" >
                    <span class="text">Approve for assessment</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-thumbs-up mt-1"></i>
                    </span>
               </button>

                <button name="_oBtnSaveApplication" style="display:none" id="_obtnApprove" type="button" class="m-2 btn btn-success btn-icon-split" data-target="#PopupConfirmation" data-toggle="modal"    >
                   
                </button>
            
        </div>
    </div>

    <div class="modal fade" id="ModalChecklist">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;"></a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" align="center" runat="server" id="div1">
                    <asp:Literal ID="ltEmbed" runat="server" />
                    <asp:Image ID="Image1" runat="server" Width="100%" Height="600px" />
                    <%--<embed id="" runat=""/>--%>
                    <button type="button" class="btn btn-primary"onclick="opennewtab('');ViewSPA_2();">Open in new Tab</button>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <span>Remarks</span>
                    <asp:UpdatePanel runat="server" class="w-100">
                        <ContentTemplate>
                            <textarea id="_oTxtRemarks" runat="server" class="form-control"></textarea>
                        </ContentTemplate>
                    </asp:UpdatePanel>     
                    <%--<a id="" onclick="opennewtab('');ViewSPA_2();" href="#" class="text-primary h4">Open in new Tab</a>--%>                    
                    <button type="button" class="btn btn-danger" data-target="#Confirmation" data-toggle="modal" onclick="document.getElementById('<%=hdnaction.ClientID%>').value = 'Rejected';">Reject</button>
                    <button type="button" class="btn btn-success" data-target="#Confirmation" data-toggle="modal"  onclick="document.getElementById('<%=hdnaction.ClientID%>').value = 'Approved';">Approve</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="Confirmation">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header bg-warning">
                    <a class="text-white float-right" style="font-size: 20px;">Confirmation</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body align-content-center align-items-center " style="text-align: center"><span>Do you want to continue?</span> </div>
                <div class="modal-footer align-content-center align-items-center justify-content-center" style="text-align: center">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <%--<asp:Button runat="server" class="btn btn-danger" Text="No" OnClick="SubApproveAction_Click"/>--%>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                            <asp:Button runat="server" class="btn btn-success" Text="Yes"  OnClick="SubApproveAction_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <%--<button type="button" class="btn btn-danger w-25" data-dismiss="modal"> No </button>   
                    <button type="button" class="btn btn-success w-25" data-dismiss="modal"> Yes </button>--%>
                </div>
            </div>
        </div>
    </div>

      <div class="modal fade" id="PopupConfirmation">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header bg-warning">
                    <a class="text-white float-right" style="font-size: 20px;">Confirmation</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body align-content-center align-items-center " style="text-align: center"><span>Do you want to continue?</span> </div>
                <div class="modal-footer align-content-center align-items-center justify-content-center" style="text-align: center">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <%--<asp:Button runat="server" class="btn btn-danger" Text="No" OnClick="SubApproveAction_Click"/>--%>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                            <asp:Button runat="server" ID="_obtnConfirmStatus" class="btn btn-success" Text="Yes" OnClientClick="DisplayLoadingFromMaster();" OnClick="_SubConfirmAction" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="_obtnConfirmStatus" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <%--<button type="button" class="btn btn-danger w-25" data-dismiss="modal"> No </button>   
                    <button type="button" class="btn btn-success w-25" data-dismiss="modal"> Yes </button>--%>
                </div>
            </div>
        </div>
    </div>

    <input type="hidden" runat="server" id="hdnName" />
    <input type="hidden" runat="server" id="hdnType" />
    <input type="hidden" runat="server" id="hdnData" />
    <input type="hidden" runat="server" id="hdnaction" />
    <input type="hidden" runat="server" id="hdnTransID" />
    <input type="hidden" runat="server" id="hdnReqCode" />
    <input type="hidden" runat="server" id="hdnAppNo" />
    <input type="hidden" runat="server" id="hdnseqid" />



    <script>
        function GetReqid(hdnTransID, hdnReqCode) {


        }

        function opennewtab() {
            window.document.forms[0].target = '_blank';
            setTimeout(function () { window.document.forms[0].target = ''; }, 0);
        }
        function ViewSPA(Name, Type, Data, seqid, transid) {

            document.getElementById('<%=hdnName.ClientID%>').value = Name;
            document.getElementById('<%=hdnType.ClientID%>').value = Type;
            document.getElementById('<%=hdnData.ClientID%>').value = Data;
            document.getElementById('<%=hdnTransID.ClientID%>').value = transid;
            document.getElementById('<%=hdnReqCode.ClientID%>').value = seqid;
            __doPostBack('DownloadFiles', seqid);
        }
        function ViewSPA_2()
        {
            __doPostBack('DownloadFilesNewTab', document.getElementById('<%=hdnReqCode.ClientID%>').value);
        }
        function openModalChecklist() {
            $('#ModalChecklist').modal('show');
        }


        function SaveReqStatus() {
            __doPostBack('SaveReqStatus');
         }


      
      
   
    </script>

    <script>
        function DownloadAllFiles() {

            if (confirm('Confirm download all submitted files?')) {
                for (var i = 0; i < document.getElementsByName('btndownload').length; i++) {
                    document.getElementsByName('btndownload')[i].click();
                }
            };
        }
       
    </script>
</asp:Content>
