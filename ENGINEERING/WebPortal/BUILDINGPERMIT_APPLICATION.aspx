<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="~/WebPortal/BUILDINGPERMIT_APPLICATION.aspx.vb" Inherits="OBO.BUILDINGPERMIT_APPLICATION" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

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

   <script>
       function addHyphen(element) {
           let ele = document.getElementById(element.id);
           ele = ele.value.split('-').join('');    // Remove dash (-) if mistakenly entered.

           let finalVal = ele.match(/.{1,3}/g).join('-');
           document.getElementById(element.id).value = finalVal;
       }

       function addHyphenCTC(element) {
           let ele = document.getElementById(element.id);
           ele = ele.value.split('-').join('');    // Remove dash (-) if mistakenly entered.

           let finalVal = ele.match(/.{1,3}/g).join('-');
           document.getElementById(element.id).value = finalVal;
       }


    </script>


    <script>

        function getSelected(sel) {
            switch (sel) {
                case "Slide_07_Brgy":
                    var sel = document.getElementById('<%=Slide_07_Brgy.ClientID%>')
                    var DistCode_BrgyCode = document.getElementById('<%=Slide_07_Brgy.ClientID%>').value
                    var parts = DistCode_BrgyCode.split('_', 2);
                    var DistCode = parts[0];
                    var BrgyCode = parts[1];

                    var selectedText = sel.options[sel.selectedIndex].innerHTML;
                    document.getElementById('<%=_oTxtBrgyLOC.ClientID%>').value = selectedText
                    var selectedValue = DistCode_BrgyCode.value;

                    localStorage.setItem("Slide_07_Brgy", sel.options[sel.selectedIndex].text);

                    document.getElementById('<%=Slide_07_SelectedDistCode.ClientID%>').value = DistCode;
                    document.getElementById('<%=Slide_07_SelectedBrgy.ClientID%>').value = BrgyCode;

                    var filter = BrgyCode;
                    $('#Slide_07_Street option').each(function () {
                        if ($(this).val() == filter) {
                            $(this).show();
                        } else {
                            $(this).hide();
                        }
                        $('#Slide_07_Street').val(filter);
                    });
                    break;

                case "Slide_07_Street":
                    var sel = document.getElementById('<%=Slide_07_Street.ClientID%>')
                    localStorage.setItem("Slide_07_Street", sel.options[sel.selectedIndex].text);

                    var selectedText = sel.options[sel.selectedIndex].innerHTML;
                    document.getElementById('<%=_oTxtStreetLOC.ClientID%>').value = selectedText;
                    document.getElementById('<%=Slide_07_SelectedStreet.ClientID%>').value = sel.value;
                    var STR = document.getElementById('<%=Slide_07_Street.ClientID%>');
                    document.getElementById('<%=Slide_07_SelectedStreet.ClientID%>').value = STR.options[STR.selectedIndex].value;


            }
        };

    </script>
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>

    <div class="col-lg-12 card px-0 row align-content-center justify-content-center">
        <div class="card-header col-lg-12">
            <h4 class="font-weight-bold text-primary ">APPLICATION FOR PERMITS AND CLEARANCES </h4>
            <label runat="server" class="font-weight-bold text-primary "  id="_oLblFormHeader"> </label> 
        </div>
    </div>
  
    <div runat="server" id="Div_AppInfo">
          <div class="col-lg-12 row mt-4">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Owner/Applicant: </h6>
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2" ><span><span class="m-2">Last Name <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLName" placeholder="" runat="server" required />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">First Name <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtFName" placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Middle Name  </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtMName" placeholder="" runat="server" />
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
                <label class="input-txt input-txt-active2"><span><span class="m-2">Select Form of Ownership <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                <select class="form-control CH-Size-new" id="_oTxtFormofOwnership" runat="server">
                    <option>Sample</option>
                </select>
            </div>

             <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Select Occupancy Classification <b> <span style="color:red"> &nbsp  </span> </b> </span></span></label>
                <select class="form-control CH-Size-new" id="_oDropDownClassification" runat="server">
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
               <label class="input-txt input-txt-active2"><span><span class="m-2">TIN Number <b> <span style="color:red"> &nbsp  </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTINNo" placeholder="XXX-XXX-XXX-XXX" onkeypress="addHyphen(this); return onlyNumbers();"  maxlength="15"  runat="server" />
            </div>
        </div>
    </div>

    <div class="col-lg-12 row" ">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">CTC: </h6>
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">CTC No.  <b> <span style="color:red"> &nbsp  </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCTCNo" autocomplete="cc-number"  placeholder="###-###-###-####" onkeypress="addHyphenCTC(this); return onlyNumbers();"  maxlength="16" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Date Issued  <b> <span style="color:red"> &nbsp  </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCTCDateIssued" autocomplete="cc-number"  onfocus="(this.type='date')" placeholder=""  runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Place Issued  <b> <span style="color:red"> &nbsp  </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCTCPlaceIssued" placeholder="" runat="server" />
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
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtNoStrt" placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Barangay  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBrgy" placeholder="" runat="server" />
            </div>
        </div>
    </div>

    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCity" placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Province  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtProvince" placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">ZIP Code  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtZIPCode" placeholder="" runat="server" />
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
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtUserID" placeholder="" runat="server" readonly />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Alternate Email</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtEmail" placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Telephone/Mobile No.  <b> <span style="color:red"> &nbsp * </span> </b></span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTelNo" placeholder="" runat="server" />
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
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLotNoLOC" placeholder="" runat="server" />
                </div>
                <div class="col-lg-1 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Blk No.</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBlkNoLOC" placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">

                       <label  class="input-txt input-txt-active2"><span><span class="m-2">Street  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                       <input type="hidden" runat="server" id="Slide_07_SelectedStreet" /> 
                          <select required runat="server" id="Slide_07_Street"  class="form-control CH-Size-new"  onchange="getSelected(this.id);">                           
                       </select>                   

                    <label style="display:none;" class="input-txt input-txt-active2"><span><span class="m-2">Street  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                    <input  style="display:none;" type="text" class="form-control CH-Size-new" name="" id="_oTxtStreetLOC" placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">

                 
                   <label  class="input-txt input-txt-active2"><span><span class="m-2">Barangay  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                      <input type="hidden" runat="server" id="Slide_07_SelectedBrgy" />
                       <input type="hidden" runat="server" id="Slide_07_SelectedDistCode"  />
                      <select required runat="server" id="Slide_07_Brgy" class="form-control CH-Size-new" onchange="getSelected(this.id);">  
                          <option value="BRGY_001" >Sample BRGY 001</option>  
                          <option value="BRGY_002">Sample BRGY 002</option>                               
                     </select>    

                    <label style="display:none;" class="input-txt input-txt-active2"><span><span class="m-2">Barangay  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                    <input  style="display:none;" type="text" class="form-control CH-Size-new" name="" id="_oTxtBrgyLOC" placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCityLOC" placeholder="" runat="server" readonly />
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class=" col-lg-12 row">
                <div class="col-lg-2 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">PIN <b> <span style="color:red"> &nbsp  </span> </b> </span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtPIN" placeholder="" runat="server" />
                </div>
               
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">TCT No.  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTCTNo" placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Tax Declaration No.  <b> <span style="color:red"> &nbsp * </span> </b> </span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTDN" placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Total Lot Area (sqm.) <b> <span style="color:red"> &nbsp * </span> </b></span  ></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTotArea" placeholder="" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-12 row">
         <div class=" col-lg-6 row"></div>
          <div class=" col-lg-3 row"></div>
        <div class=" col-lg-3 row">

            <div class="col-lg-6 form-group">
                <button   runat="server"   onclick="TrapIncompleteInfo()" id="_oBtnSaveAppInfo"  type="button" class="btn btn-primary btn-icon-split" >
                    <span class="text">Save</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>
                </button>

                <button name="_oBtnSaveApplication" style="display:none" runat="server" id="_oBtnSaveApplication" onclick="__doPostBack('SaveApplication','')" type="button" class="btn btn-primary btn-icon-split" >
                    <span class="text">Save</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>
                </button>
            </div>
            <div class="col-lg-6 form-group">
                <button name="_oBtnEdit" runat="server" id="_oBtnEdit" disabled type="button" class="btn btn-warning btn-icon-split" onclick="Edit()">
                    <span class="text">Edit</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-edit mt-1"></i>
                    </span>
                </button>
            </div>
        </div>
    </div>
    </div>

  
   
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-12 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Upload Requirements(PDF Format)</h6>
            </div>
          
        </div>
    </div>

    <asp:UpdatePanel runat="server" ID="UPUpload">
        <ContentTemplate>
            <div class="col-lg-12 row table-responsive">
                <b>
                     <i><p>Note: Red labeled requirement/s is/are mandatory.</p></i>
                </b>
                 
                <%--_oGvUpload--%>
                <asp:GridView ID="_oGvUpload" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                    <Columns>
                        <asp:TemplateField HeaderText="Code" Visible="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblCodeReq" runat="server" Text='<%# Eval("Code")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Requirements" Visible="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblDesc1Req" runat="server" Text='<%# Eval("Desc1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Requirements" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblDesc2" runat="server" Text='<%# Eval("Desc2")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderText="File Uploaded">
                            <ItemTemplate>
                                <asp:HyperLink ID="_oHyperLinkReqSubmitted" runat="server" Target="_blank" Enabled="True" Text='<%# Eval("ReqDesc")%>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblStatus" runat="server" Text='<%# Eval("Status")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblRemarks" runat="server" Text='<%# Eval("Remarks")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderText="Action">
                            <ItemTemplate>
                                <asp:FileUpload ID="_oFileUploadRequirements" runat="server" Multiple="Multiple" />
                            </ItemTemplate>
                        </asp:TemplateField>

                       <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="View">
                            <ItemTemplate>
                               <%-- <asp:LinkButton id="_oLinkPreview"  href="ViewImage.aspx?ReqCode=<%# Eval("Code")%>"  target="_blank"  runat="server"  > View uploaded </asp:LinkButton>--%>

                                <a id="_oLinkPreview" href="ViewImage.aspx?ReqCode=<%# Eval("Code")%>" target="_blank"  > View</a>
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
            </div>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="col-lg-12 row">

        <div class=" col-lg-12 row">
            <br />
            <div class=" col-lg-6 row"></div>
             <div class=" col-lg-3 row"></div>
             <div class=" col-lg-3 row">
             <div class="col-lg-6 form-group">
                <button name="_oBtnUploadRequirements" runat="server" id="_oBtnUploadRequirements" type="button" class="btn btn-primary btn-icon-split" style="max-width: 120px !Important;">
                    <span class="text">Upload</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>
                </button>
            </div>
            <div class="col-lg-6 form-group">
                <button name="_oBtnSubmit" runat="server" id="_oBtnSubmit" type="button" class="btn btn-success btn-icon-split" style="max-width: 120px !Important;" disabled onclick="Submit()">
                    <span class="text">Submit</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-edit mt-1"></i>
                    </span>
                </button>
            </div>
             </div>

        </div>
    </div>

    <input type="hidden" runat="server" id="_oTxtHdnEdit" />

    <script>
        function Edit() {
            document.getElementById('<%=_oTxtFName.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtLName.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtMName.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtFormofOwnership.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtTINNo.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtNoStrt.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtBrgy.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtCity.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtProvince.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtZIPCode.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtEmail.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtTelNo.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtLotNoLOC.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtBlkNoLOC.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtStreetLOC.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtBrgyLOC.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtCityLOC.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtTCTNo.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtTDN.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtTotArea.ClientID%>').disabled = false;
            document.getElementById('<%=_oTxtHdnEdit.ClientID%>').innerText = 'Edit';
        }

        function Submit() {
            __doPostBack('Submit', '')
        }
    </script>

    <script>
        function TrapIncompleteInfo() {
            var Incomplete = 0;
            if (document.getElementById('<%=_oTxtLName.ClientID%>').value == '' || document.getElementById('<%=_oTxtLName.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtFName.ClientID%>').value == '' || document.getElementById('<%=_oTxtFName.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtFormofOwnership.ClientID%>').value == '' || document.getElementById('<%=_oTxtFormofOwnership.ClientID%>').value == '-- SELECT --' || document.getElementById('<%=_oTxtFormofOwnership.ClientID%>').value == null) { Incomplete = 1; };
            //alert(document.getElementById('<%=_oTxtFormofOwnership.ClientID%>').value);
            //if (document.getElementById('<%=_oTxtTINNo.ClientID%>').value == '' || document.getElementById('<%=_oTxtTINNo.ClientID%>').value == null) { Incomplete = 1; };
            //if (document.getElementById('<%=_oTxtCTCNo.ClientID%>').value == '' || document.getElementById('<%=_oTxtCTCNo.ClientID%>').value == null) { Incomplete = 1; };
            //if (document.getElementById('<%=_oTxtCTCDateIssued.ClientID%>').value == '' || document.getElementById('<%=_oTxtCTCDateIssued.ClientID%>').value == null) { Incomplete = 1; };
            //if (document.getElementById('<%=_oTxtCTCPlaceIssued.ClientID%>').value == '' || document.getElementById('<%=_oTxtCTCPlaceIssued.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtBrgy.ClientID%>').value == '' || document.getElementById('<%=_oTxtBrgy.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtCity.ClientID%>').value == '' || document.getElementById('<%=_oTxtCity.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtProvince.ClientID%>').value == '' || document.getElementById('<%=_oTxtProvince.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtZIPCode.ClientID%>').value == '' || document.getElementById('<%=_oTxtZIPCode.ClientID%>').value == null) { Incomplete = 1; };
            //if (document.getElementById('<%=_oTxtStreetLOC.ClientID%>').value == '' || document.getElementById('<%=_oTxtStreetLOC.ClientID%>').value == null) { Incomplete = 1; };
            //if (document.getElementById('<%=_oTxtBrgyLOC.ClientID%>').value == '' || document.getElementById('<%=_oTxtBrgyLOC.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtTDN.ClientID%>').value == '' || document.getElementById('<%=_oTxtTDN.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtTCTNo.ClientID%>').value == '' || document.getElementById('<%=_oTxtTCTNo.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtTotArea.ClientID%>').value == '' || document.getElementById('<%=_oTxtTotArea.ClientID%>').value == null) { Incomplete = 1; };
            if (document.getElementById('<%=_oTxtTelNo.ClientID%>').value == '' || document.getElementById('<%=_oTxtTelNo.ClientID%>').value == null) { Incomplete = 1; }; 
            var barangay = document.getElementById('<%=Slide_07_Brgy.ClientID%>').options[document.getElementById('<%=Slide_07_Brgy.ClientID%>').selectedIndex].innerHTML;
            if (barangay == '' || barangay == '-- SELECT --' || barangay == null ) { Incomplete = 1; };
            var street = document.getElementById('<%=Slide_07_Street.ClientID%>').options[document.getElementById('<%=Slide_07_Street.ClientID%>').selectedIndex].innerHTML;
            if (street == '' || street == '-- SELECT --' || street == null) { Incomplete = 1; };
            
            if (Incomplete > 0) {
                alert('Cannot proceed, Please fill-up all required information.');
            } else {
                if (confirm('Confirm Save Information')) {
                    document.getElementById("<%=_oBtnSaveApplication.ClientID%>").click();
                }
            }
        }
    </script>

</asp:Content>
