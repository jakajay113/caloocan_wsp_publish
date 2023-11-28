<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master"  ViewStatemode="Enabled" CodeBehind="ApplyApplication.aspx.vb" Inherits="OBO.ApplyApplication" %>
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
    <div class="col-lg-12 card px-0 row align-content-center justify-content-center">
        <div class="card-header col-lg-12">
            <h4 class="font-weight-bold text-primary ">Application for <asp:Label runat="server" ID="_oLabelFormType" /> Permit</h4>
        </div>
    </div>

    <div class="col-lg-12 row mt-4">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Owner/Applicant: </h6>
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Last Name</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLName" 
 placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">First Name</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtFName" onkeypress="return /[a-z]/i.test(event.key)" 
 placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Middle Name</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtMName" onkeypress="return /[a-z]/i.test(event.key)" 
 placeholder="" runat="server" />
            </div>
        </div>
    </div>

    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Form of Ownership: </h6>
            </div>
            <div class="col-lg-3 form-group">
                <select class="form-control CH-Size-new" id="_oTxtFormofOwnership" runat="server">
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
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTINNo" placeholder="" runat="server" />
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
                <label class="input-txt input-txt-active2"><span><span class="m-2">Barangay</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBrgy" onkeypress="return /[a-z]/i.test(event.key)" 
 placeholder="" runat="server" />
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCity" onkeypress="return /[a-z]/i.test(event.key)" 
 placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Province</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtProvince" onkeypress="return /[a-z]/i.test(event.key)" 
 placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">ZIP Code</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtZIPCode" onkeypress="limitKeypress(event,this.value,4)" placeholder="" runat="server" />
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Contact: </h6>
            </div>
            <div class="col-lg-6 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Email</span></span></label>
                <input type="text" class="form-control CH-Size-new" name="" id="_oTxtEmail" placeholder="" runat="server" />
            </div>
            <div class="col-lg-3 form-group">
                <label class="input-txt input-txt-active2"><span><span class="m-2">Telephone/Mobile No.</span></span></label>
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
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Street</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtStreetLOC" placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Barangay</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBrgyLOC" onkeypress="return /[a-z]/i.test(event.key)" 
 placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCityLOC" onkeypress="return /[a-z]/i.test(event.key)" 
 placeholder="" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class=" col-lg-12 row">
                <div class="col-lg-2 form-group">
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">TCT No.</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTCTNo" placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Tax Declaration No.</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTDN" placeholder="" runat="server" />
                </div>
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Total Area</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTotArea" placeholder="" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-8 form-group">
            </div>
            <div class="col-lg-2 form-group">
                <button name="_oBtnSaveApplication" runat="server" id="_oBtnSaveApplication" onclick="__doPostBack('SaveApplication','')" type="button" class="btn btn-success btn-icon-split" style="max-width: 120px !Important;">
                    <span class="text">Save</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>
                </button>
            </div>
            <div class="col-lg-2 form-group">
                <button name="_oBtnEdit" runat="server" id="_oBtnEdit" disabled type="button" class="btn btn-warning btn-icon-split" style="max-width: 120px !Important;" onclick="Edit()">
                    <span class="text">Edit</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-edit mt-1"></i>
                    </span>
                </button>
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
                                <asp:Label ID="_oLblDesc2Req" runat="server" Text='<%# Eval("Desc2")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderText="File Uploaded">
                            <ItemTemplate>
                                <asp:HyperLink ID="_oHyperLinkReqSubmitted" runat="server" Target="_blank" Enabled="True" Text='<%# Eval("ReqDesc")%>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderText="Action">
                            <ItemTemplate>
                                <asp:FileUpload ID="_oFileUploadRequirements" runat="server" Multiple="Multiple" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row mt-2">
            <div class="col-lg-8 form-group">
            </div>
            <div class="col-lg-2 form-group">
                <button name="_oBtnUploadRequirements" runat="server" id="_oBtnUploadRequirements" type="button" class="btn btn-success btn-icon-split" style="max-width: 120px !Important;">
                    <span class="text">Save</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>
                </button>
            </div>
            <div class="col-lg-2 form-group">
                <button name="_oBtnSubmit" runat="server" id="_oBtnSubmit" type="button" class="btn btn-warning btn-icon-split" style="max-width: 120px !Important;" disabled onclick="Submit()">
                    <span class="text">Submit</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-edit mt-1"></i>
                    </span>
                </button>
            </div>
        </div>
    </div>
    <input type="hidden" runat="server" id="_oTxtHdnEdit" />
    <input type="hidden" runat="server" name="__VIEWSTATE"  id="__VIEWSTATE"  />
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


        function alphaOnly(event) {
            var key = event.keyCode;
            return ((key >= 65 && key <= 90) || key == 8);
        };

        //install input filter function 
        function setInputFilter(textbox, inputFilter) {
            ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function (event) {
                textbox.addEventListener(event, function () {
                    if (inputFilter(this.value)) {
                        this.oldValue = this.value;
                        this.oldSelectionStart = this.selectionStart;
                        this.oldSelectionEnd = this.selectionEnd;
                    } else if (this.hasOwnProperty("oldValue")) {
                        this.value = this.oldValue;
                        this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
                    } else {
                        this.value = "";
                    }
                });
            });
        }


        // Install input filters.
        //INTEGER
        setInputFilter(document.getElementById('<%=_oTxtLotNoLOC.ClientID%>'), function (value) { return /^-?\d*$/.test(value); });
      setInputFilter(document.getElementById('<%=_oTxtBlkNoLOC.ClientID%>'), function (value) { return /^-?\d*$/.test(value); });
        setInputFilter(document.getElementById('<%=_oTxtTotArea.ClientID%>'), function (value) { return /^-?\d*$/.test(value); });
        setInputFilter(document.getElementById('<%=_oTxtZIPCode.ClientID%>'), function (value) { return /^-?\d*$/.test(value); });
        //HAVE - IN NUMBER
        setInputFilter(document.getElementById('<%=_oTxtTINNo.ClientID%>'), function (value) { return /^[0-9\.\-\/]+$/.test(value); });
        setInputFilter(document.getElementById('<%=_oTxtTDN.ClientID%>'), function (value) { return /^[0-9\.\-\/]+$/.test(value); });
        setInputFilter(document.getElementById('<%=_oTxtTCTNo.ClientID%>'), function (value) { return /^[0-9\.\-\/]+$/.test(value); });
       <%-- setInputFilter(document.getElementById('<%=_oTxtTCTNo.ClientID%>'), function (value) { return /^[0-9\.\-\/]+$/.test(value); });--%>


        //LIMIT FIELD INPUT 
        function limitKeypress(event, value, maxLength) {
            if (value != undefined && value.toString().length >= maxLength) {
                event.preventDefault();
            }
        }



    </script>






</asp:Content>
