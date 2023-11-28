<%@ Page MaintainScrollPositionOnPostback="true" ClientIDMode="Static" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPages/EIMS_MASTER.Master" CodeBehind="BUILDING_PERMIT_APPLICATION.aspx.vb" Inherits="EIMS_WEB.BUILDING_PERMIT_APPLICATION" %>

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


    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>

    <div class="col-lg-12 form-group">
        <button name="_oBtnNew" runat="server" id="_oBtnNew" onclick="DoNew('')" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 95px !Important;">
            <span class="text">New</span>
            <span class="icon text-white-50">
                <i class="fas fa-plus mt-1"></i>
            </span>
        </button>
        <button name="_oBtnEdit" runat="server" id="_oBtnEdit" type="button" class="btn btn-warning btn-icon-split col-md-5 m-1" style="max-width: 95px !Important;">
            <span class="text">Edit</span>
            <span class="icon text-white-50">
                <i class="fas fa-edit mt-1"></i>
            </span>
        </button>
        <button name="_oBtnDeleteApplication" runat="server" id="_oBtnDeleteApplication" type="button" class="btn btn-danger btn-icon-split col-md-5 m-1" style="max-width: 100px !Important;">
            <span class="text">Delete</span>
            <span class="icon text-white-50">
                <i class="fas fa-trash mt-1"></i>
            </span>
        </button>
        <button name="_oBtnSaveApplication" runat="server" id="_oBtnSaveApplication" onclick="__doPostBack('SaveApplication','')" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 95px !Important;">
            <span class="text">Save</span>
            <span class="icon text-white-50">
                <i class="fas fa-save mt-1"></i>
            </span>
        </button>
        <button name="_oBtnCancel" runat="server" id="_oBtnCancel" type="button" class="btn btn-danger btn-icon-split col-md-5 m-1" style="max-width: 95px !Important;">
            <span class="text">Cancel</span>
            <%--<span class="icon text-white-50">
                    <i class="fas fa-plus mt-1"></i>
                </span>--%>
        </button>
        <button name="_oBtnBrowse" runat="server" id="_oBtnBrowse" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 110px !Important;">
            <span class="text">Browse</span>
            <span class="icon text-white-50">
                <i class="fas fa-folder mt-1"></i>
            </span>
        </button>
        <button name="_oBtnRequirements" runat="server" id="_oBtnRequirements" type="button" class="btn btn-primary btn-icon-split col-md-5 m-1" style="max-width: 150px !Important;">
            <span class="text">Requirements</span>
            <span class="icon text-white-50">
                <i class="fas fa-file mt-1"></i>
            </span>
        </button>
        <button name="_oBtnPrint" runat="server" id="_oBtnPrint" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 90px !Important;">
            <span class="text">Print</span>
            <span class="icon text-white-50">
                <i class="fas fa-print mt-1"></i>
            </span>
        </button>
    </div>
    <div class="col-lg-12 card px-0 row">
        <div class="card-header col-lg-12">
            <h4 class="font-weight-bold text-primary ">Application for Building Permit Setup</h4>
        </div>
        <div class="card-body row">
            <div class="col-lg-4 form-group ">
                <div>
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Application No.</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtAppNo" placeholder="" runat="server" readonly />
                </div>
            </div>
            <div class="col-lg-4 form-group ">
            </div>
            <div class="col-lg-4 form-group ">
                <div>
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Area No.</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtAreaNo" placeholder="" runat="server" readonly />
                </div>
            </div>
        </div>
        <div class="card-header col-lg-12">
            <h5 class="font-weight-bold text-primary ">Box 1 (To Be Accomplished in print by Owner/Applicant)</h5>
        </div>
        <div class="col-lg-12">
            <h6 class="font-weight-bold text-primary mt-2">Owner/Applicant</h6>
            <button type="button" id="_oBtnApplicantSearch" runat="server" class="btn btn-primary btn-icon-split" onclick="OpenModal()">
                <span class="icon text-white">
                    <i class="fas fa-plus"></i>
                </span>
            </button>
        </div>
        <div id="ApplicationContent">
            <div class="card-body row">
                <div class="col-lg-2 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Applicant Type</span></span></label>
                        <select class="form-control CH-Size-new" runat="server" id="_oTxtApplicantType" onchange="DoNew('ApplicationContent')">
                            <option>Sample</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-3 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Last Name</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLName" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-3 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">First Name</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtFName" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-2 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Middle Name</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtMName" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-2 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">TIN No.</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTINNo" placeholder="" runat="server" readonly />
                    </div>
                </div>

            </div>
            <div class="col-lg-12">
                <h6 class="font-weight-bold text-primary mt-2">For Construction Owned by Enterprise.</h6>
            </div>
            <div class="card-body row">
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Form of Ownership</span></span></label>
                        <select class="form-control CH-Size-new" id="_oTxtFormofOwnership" runat="server">
                            <option>Sample</option>
                        </select>
                    </div>
                </div>
            </div>

            <div class="col-lg-12">
                <h6 class="font-weight-bold text-primary mt-2">Address</h6>
            </div>
            <div class="card-body row">
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">No./Street </span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtNoStreet" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Village</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtVillage" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Barangay</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBarangay" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCityMunicipality" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Province</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtProvince" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Zip Code</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtZipCode" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Telephone No.</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTelephoneNo" runat="server" placeholder="" readonly />
                    </div>
                </div>
            </div>

            <div class="col-lg-12">
                <h6 class="font-weight-bold text-primary mt-2">Location of Construction</h6>
            </div>

            <div class="col-lg-12">
                <button type="button" id="_oBtnLOCSearch" runat="server" class="btn btn-primary btn-icon-split" onclick="OpenModalLOC()">
                    <span class="icon text-white">
                        <i class="fas fa-plus"></i>
                    </span>
                </button>
            </div>

            <div class="card-body row">
                <div class="col-lg-3 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Lot No.</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLotNoLOC" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-3 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Blk No.</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBlkNoLOC" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-3 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">TCT No.</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTCTNoLOC" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-3 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Tax Declaration No.</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTDNLOC" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Street</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtStrtLOC" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Barangay</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtBrgyLOC" placeholder="" runat="server" readonly />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtCityLOC" runat="server" placeholder="" readonly />
                    </div>
                </div>
            </div>
            <input type="hidden" id="_oHdnSelectedScope" runat="server" />
            <div class="col-lg-12">
                <h6 class="font-weight-bold text-primary mt-2">Scope of Work</h6>
            </div>
            <div class=" table-responsive col-lg-12">


                <asp:GridView ID="_oGvScopeofWork" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Code" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblDesc1Scope" runat="server" Text='<%# Eval("Desc1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <input type="checkbox" id="_oChkScope" value="'<%# Eval("Desc1")%>'" onchange="GetScopeCode(this.value, this.checked)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblDesc2Scope" runat="server" Text='<%# Eval("Desc2")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle></FooterStyle>


                </asp:GridView>

                <input type="hidden" id="hdnCode" runat="server" />
                <input type="hidden" id="hdnDesc1" runat="server" />
                <input type="hidden" id="hdnDesc2" runat="server" />
                <input type="hidden" id="hdnAction" runat="server" />
                <input type="hidden" id="hdnVal" runat="server" />
            </div>
            <div class="col-lg-12">
                <h6 class="font-weight-bold text-primary mt-2">Use or Character Occupancy</h6>
            </div>
            <div class="col-lg-12">
                <div class="col-lg-4 form-group ">
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Use or Character of Occupancy </span></span></label>
                        <select class="form-control CH-Size-new" runat="server" id="_oTxtOccupancyUse" onchange="filter()">
                            <option>Sample</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Division </span></span></label>
                        <select class="form-control CH-Size-new" runat="server" id="_oTxtDivision">
                            <option>Sample</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                </div>
            </div>
            <div class=" table-responsive col-lg-12">

                <asp:GridView ID="_oGvAccessory" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="Code" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblDesc1Accessory" runat="server" Text='<%# Eval("Desc1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <input type="checkbox" id="_oChkAccessory" value="'<%# Eval("Desc1")%>'" onchange="GetAccessoryCode(this.value, this.checked)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Accessories" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80%">
                            <ItemTemplate>
                                <asp:Label ID="_oLblDesc2Accessory" runat="server" Text='<%# Eval("Desc2")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle></FooterStyle>
                </asp:GridView>
                <input type="hidden" id="_oHdnSelectedAccessory" runat="server" />
            </div>
            <div class="col-lg-12">
                <div class="col-lg-4 form-group ">
                </div>
                <div id="DivTowerSS" class="col-lg-4 form-group" style="display: none">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">TOWERS(SELF SUPPORTING)</span></span></label>
                        <input type="checkbox" id="_oChkTowersSS" runat="server" />
                    </div>
                </div>
                <div id="DivTowerTG" class="col-lg-4 form-group " style="display: none">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">TOWERS(TRILON GUYED)</span></span></label>
                        <input type="checkbox" id="_oChkTowersTG" runat="server" />
                    </div>
                </div>
                <div class="col-lg-4 form-group ">
                </div>
            </div>


            <div class="card-body row">
                <div class="col-lg-6 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Occupancy </span></span></label>
                        <select class="form-control CH-Size-new" runat="server" id="_oTxtOccupancy">
                            <option>Sample</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-6 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Number of Units </span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtNumberofUnits" runat="server" placeholder="" />
                    </div>
                </div>
                <div class="col-lg-6 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Number of Floor </span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtNumberofFloor" runat="server" placeholder="" />
                    </div>
                </div>
                <div class="col-lg-6 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Per Floor Area </span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtPerFloorArea" runat="server" placeholder="" />
                    </div>
                </div>
                <div class="col-lg-6 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Total Floor Area (SQM)</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTotalFloorArea" runat="server" placeholder="" />
                    </div>
                </div>
                <div class="col-lg-6 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Total Estimated Cost (PHP)</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTotalEstimatedCost" runat="server" placeholder="" />
                    </div>
                </div>
                <div class="col-lg-6 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Proposed Date of Completion</span></span></label>
                        <input type="date" class="form-control CH-Size-new" name="" id="_oTxtProposedDateof" runat="server" placeholder="" />
                    </div>
                </div>
                <div class="col-lg-6 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Estimated Date of Completion</span></span></label>
                        <input type="date" class="form-control CH-Size-new" name="" id="_oTxtEstimatedDateof" runat="server" placeholder="" />
                    </div>
                </div>
                <div class="col-lg-6 form-group ">
                    <div>
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Prepared By</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtPreparedBy" runat="server" placeholder="" readonly />
                    </div>
                </div>
            </div>
            <div class="card-header col-lg-12">
                <h5 class="font-weight-bold text-primary mt-2">Box 2</h5>
                <h6 class="font-weight-bold text-primary mt-2">Full-time Inspector and Supervisor of Construction Works (Representing The Owner)</h6>
                <button type="button" id="_oBtnFISearch" runat="server" class="btn btn-primary btn-icon-split" onclick="OpenModalFI()">
                    <span class="icon text-white">
                        <i class="fas fa-plus"></i>
                    </span>
                </button>
            </div>
            <div class="card-body row">
                <div class="col-lg-12 form-group row">
                    <div class="col-lg-6 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Architect or Civil Engineer</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtArchitectEngineer" placeholder="" runat="server" readonly />
                        </div>
                    </div>
                    <div class="col-lg-6 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Date Signed</span></span></label>
                            <input type="date" class="form-control CH-Size-new" name="" id="_oTxtArchitectDateSigned" placeholder="" runat="server" />
                        </div>
                    </div>
                    <div class="col-lg-12 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Address</span></span></label>
                            <textarea class="form-control CH-Size-new" name="" id="_oTxtArchitectAddress" runat="server" readonly></textarea>
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">PTR No. </span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtArchitectPTRNo" placeholder="" runat="server" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">PRC No. </span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtArchitectPRCNo" placeholder="" runat="server" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Validity </span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtArchitectValidity" runat="server" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">TIN</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtArchitectTIN" placeholder="" runat="server" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Issued At</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtArchitectIssuedAt" placeholder="" runat="server" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Date Issued</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtArchitectDateIssued" runat="server" readonly />
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-header col-lg-12">
                <h5 class="font-weight-bold text-primary mt-2">Box 3</h5>
            </div>
            <div class="card-body row">
                <h6 class="font-weight-bold text-primary mb-4">Applicant</h6>
                <div class="col-lg-12 form-group row">
                    <div class="col-lg-8 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Fullname</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtApplicantFullname" runat="server" placeholder="" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Date Signed</span></span></label>
                            <input type="date" class="form-control CH-Size-new" name="" id="_oTxtApplicantDateSigned" runat="server" />
                        </div>
                    </div>
                    <div class="col-lg-12 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Address</span></span></label>
                            <textarea class="form-control CH-Size-new" name="" id="_oTxtApplicantAddress" runat="server" readonly></textarea>
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">C.T.C </span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtApplicantCTC" placeholder="" runat="server" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Issued At</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtApplicantPlaceIssued" placeholder="" runat="server" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Date Issued</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtApplicantDateIssued" placeholder="mm/dd/yyyy" runat="server" readonly />
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-header col-lg-12">
                <h5 class="font-weight-bold text-primary mt-2">Box 4</h5>
            </div>
            <div class="card-body row">
                <h6 class="font-weight-bold text-primary mb-4">With My Consent: Lot Owner</h6>
                <br />
                <button type="button" id="_oBtnLOConsentSearch" runat="server" class="btn btn-primary btn-icon-split" onclick="OpenModalLOConsent()" hidden="hidden">
                    <span class="icon text-white">
                        <i class="fas fa-plus"></i>
                    </span>
                </button>
                <div class="col-lg-12 form-group row">
                    <div class="col-lg-8 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Fullname</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLotOwnerFullname" placeholder="" runat="server" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Date Signed</span></span></label>
                            <input type="date" class="form-control CH-Size-new" name="" id="_oTxtLotOwnerDateSigned" runat="server" />
                        </div>
                    </div>
                    <div class="col-lg-12 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Address</span></span></label>
                            <textarea class="form-control CH-Size-new" name="" id="_oTxtLotOwnerAddress" runat="server" readonly></textarea>
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">C.T.C </span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLotOwnerCTC" runat="server" placeholder="" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Issued At</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLotOwnerPlaceIssued" runat="server" placeholder="" readonly />
                        </div>
                    </div>
                    <div class="col-lg-4 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Date Issued</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLotOwnerDateIssued" runat="server" readonly />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

        <div class="modal fade" id="myBrowseModal" runat="server" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <%--<i class="fas fa-edit text-white float-right" style="font-size: 30px;"></i>--%>
                    <h4 class="modal-title text-white" id="myBrowseLabel">Upload Requirements</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:GridView ID="_oGvBrowse" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="Code" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblCodeBrowse" runat="server" Text='<%# Eval("AppNo")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Desc1" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblLNameBrowse" runat="server" Text='<%# Eval("LName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblFNameBrowse" runat="server" Text='<%# Eval("FName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LinkCode" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblMNameBrowse" runat="server" Text='<%# Eval("MName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LinkCode" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblOwner_AddressBrowse" runat="server" Text='<%# Eval("Owner_Address")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LinkCode" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblTDNBrowse" runat="server" Text='<%# Eval("TDN")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LinkCode" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblIDCodeBrowse" runat="server" Text='<%# Eval("IDCode")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="">
                                <ItemTemplate>
                                    <a href="#" onclick="GetInfo('GetApplicationInfo', '<%# Eval("AppNo")%>');">Select</a>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle></FooterStyle>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myUploadModal" runat="server" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <%--<i class="fas fa-edit text-white float-right" style="font-size: 30px;"></i>--%>
                    <h4 class="modal-title text-white" id="myUploadLabel">Upload Requirements</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="card-body col-lg-12 row">
                        <div class="col-md-3 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Filter by:</span></span></label>
                                <select id="_oCbApplication" runat="server" class="form-control CH-Size-new">
                                    <option value="IDCode">ID Code</option>
                                    <option value="AppNo">Application No</option>
                                    <option value="LName">Last Name</option>
                                    <option value="FName">First Name</option>                                   
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Search Key:</span></span></label>
                                <input type="text" runat="server" class="form-control CH-Size-new" name="_oTxtSearchApplication" id="_oTxtSearchApplication" />
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <button name="_oBtnSearchApplication" runat="server" id="_oBtnSearchApplication" type="button" class="btn btn-primary btn-icon-split col-md-4" style="max-width: 100px !Important;" onclick="SearchApplication()">
                                <span class="text">Search</span>
                                <span class="icon text-white-50">
                                    <i class="fas fa-search mt-1"></i>
                                </span>
                            </button>
                        </div>
                    </div>
                    <asp:GridView ID="_oGvUpload" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="Code" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblCodeReq" runat="server" Text='<%# Eval("Code")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Desc1" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblDesc1Req" runat="server" Text='<%# Eval("Desc1")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblDesc2Req" runat="server" Text='<%# Eval("Desc2")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LinkCode" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblLinkCodeReq" runat="server" Text='<%# Eval("LinkCode")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="">
                                <ItemTemplate>
                                    <button id="_oBtnUpload" type="button" runat="server"></button>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle></FooterStyle>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myApplicantModal" runat="server" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <%--<i class="fas fa-edit text-white float-right" style="font-size: 30px;"></i>--%>
                    <h4 class="modal-title text-white" id="myApplicantLabel">Applicant</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="card-body col-lg-12 row">
                        <div class="col-md-3 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Filter by:</span></span></label>
                                <select id="_oCbFilterApplicant" runat="server" class="form-control CH-Size-new">
                                    <option value="LName">Last Name</option>
                                    <option value="FName">First Name</option>
                                    <option value="MName">Middle Name</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Search Key:</span></span></label>
                                <input type="text" runat="server" class="form-control CH-Size-new" name="_oTxtSearchApplicant" id="_oTxtSearchApplicant" />
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <button name="_oBtnSearchApplicant" runat="server" id="_oBtnSearchApplicant" type="button" class="btn btn-primary btn-icon-split col-md-4" style="max-width: 100px !Important;" onclick="SearchApplicant()">
                                <span class="text">Search</span>
                                <span class="icon text-white-50">
                                    <i class="fas fa-search mt-1"></i>
                                </span>
                            </button>
                        </div>
                    </div>
                    <asp:GridView ID="_oGvApplicant" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                        <Columns>

                            <asp:TemplateField HeaderText="Application No" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblIDCodeApp" runat="server" Text='<%# Eval("IDCode")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblFullNameApp" runat="server" Text='<%# Eval("FullName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblAddressApp" runat="server" Text='<%# Eval("Address")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Middle Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblTINApp" runat="server" Text='<%# Eval("TIN")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="">
                                <ItemTemplate>
                                    <a href="#" onclick="GetInfo('GetApplicantInfo', '<%# Eval("IDCode")%>');">Select</a>
                                    <a href="#" onclick="LoadInfo('LoadApplicantInfo','<%# Eval("IDCode")%>');">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle></FooterStyle>


                    </asp:GridView>

                    <div class="form-row">
                        <button id="_oBtnCollapseApplicant" class="btn btn-primary btn-circle" data-toggle="collapse" data-dismiss="collapse" data-target="#LeaveApplicant" data-ticket-type="standard-access" style="float: left; font-size: medium; border: none; background-color: #4975c3" onclick="return false;">
                            <i id="Switch1" runat="server" class="fas fa-plus-circle" onclick="buttonSwitch(this.id)"></i>
                        </button>
                    </div>

                    <div id="LeaveApplicant" class="collapse" runat="server">

                        <button name="_oBtnNewApplicant" runat="server" id="_oBtnNewApplicant" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 95px !Important;" onclick="DoNew('LeaveApplicant')">
                            <span class="text">New</span>
                            <span class="icon text-white-50">
                                <i class="fas fa-plus mt-1"></i>
                            </span>
                        </button>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Last Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLNameApplicant" name="_oTxtLastName" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">First Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtFNameApplicant" name="_oTxtFirstName" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Middle Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtMNameApplicant" name="_oTxtMiddleName" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">TIN No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTINNoApplicant" name="_oTxtTINNo" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Tel No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTelNoApplicant" name="_oTxtTelNo" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtNoApplicant" name="_oTxtNoApplicant" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Lot No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLotNoApplicant" name="_oTxtLotNoApplicant" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Blk No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBlkNoApplicant" name="_oTxtBlkNoApplicant" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Phase/Zone:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPhaseZoneApplicant" name="_oTxtPhaseZoneApplicant" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Street:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtStreetApplicant" name="_oTxtStreetApplicant" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Subdivision/Village:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtSubdVillApplicant" name="_oTxtSubdVillApplicant" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Barangay:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBrgyApplicant" name="_oTxtBrgyApplicant" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">City/Municipality:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCityApplicant" name="_oTxtCityApplicant" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Province:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtProvinceApplicant" name="_oTxtProvinceApplicant" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Region:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtRegionApplicant" name="_oTxtRegionApplicant" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">ZipCode:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtZipCodeApplicant" name="_oTxtZipCodeApplicant" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">CTC No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCNoApplicant" name="_oTxtCTCNoApplicant" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Place Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPlaceIssuedApplicant" name="_oTxtPlaceIssuedApplicant" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Date Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtDateIssuedApplicant" name="_oTxtDateIssuedApplicant" placeholder="mm/dd/yyyy" onfocus="this.type='date'" />
                                </div>
                            </div>
                        </div>
                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <button type="button" runat="server" id="_oBtnSaveApplicantInfo" class="btn btn-success btn-icon-split ml-2" onclick="SaveInfo('SaveApplicant')">
                                        <%--data-toggle="modal" data-target="#SearchRecord">--%>
                                        <span class="icon text-white">
                                            <i class="fas fa-save mt-1"></i>
                                        </span>
                                        <span class="text">Save Record</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%--<div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>
                    <button class="btn btn-success btn-sm" id="_oBtnSaveChanges" runat="server" style="display: none" onclick="SaveChanges(document.getElementById('<%=hdnAction.ClientID%>').value, document.getElementById('<%=hdnVal.ClientID%>').value)">Save changes</button>
                    <input type="submit" class="btn btn-success btn-sm" value="Save changes" />
                </div>
                <input type="hidden" id="hdnSubmit" name="hdnSubmit" value="0" />--%>


                <%--                    <input type="file" runat="server" class="form-control CH-Size-New" style="display:none" id="_oFileSPA" onchange=" here('file2');" />
                        <input type="file" runat="server" class="form-control CH-Size-New" style="display:none" id="_oFileGovernmentID" onchange=" here('file1');"/>
                        <input type="file" runat="server" class="form-control CH-Size-New" style="display:none" id="_oFileBRSec" onchange=" here('file3');"/>--%>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myProfessionalModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <%--<i class="fas fa-edit text-white float-right" style="font-size: 30px;"></i>--%>
                    <h4 class="modal-title text-white" id="myProfessionalLabel">Professional Search</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>

                <div class="modal-body">
                    <div class="card-body col-lg-12 row">
                        <div class="col-md-3 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Filter by:</span></span></label>
                                <select id="_oCbFilterProfessional" runat="server" class="form-control CH-Size-new">
                                    <option value="LName">Last Name</option>
                                    <option value="FName">First Name</option>
                                    <option value="MName">Middle Name</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Search Key:</span></span></label>
                                <input type="text" runat="server" class="form-control CH-Size-new" name="_oTxtSearchApplicant" id="_oTxtSearchProfessional" />
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <button name="_oBtnSearchProfessional" runat="server" id="_oBtnSearchProfessional" type="button" class="btn btn-primary btn-icon-split col-md-4" style="max-width: 100px !Important;" onclick="SearchProfessional()">
                                <span class="text">Search</span>
                                <span class="icon text-white-50">
                                    <i class="fas fa-search mt-1"></i>
                                </span>
                            </button>
                        </div>
                    </div>

                    <asp:GridView ID="_oGvProfessional" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="Application No" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblIDCodeProf" runat="server" Text='<%# Eval("IDCode")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblFullNameProf" runat="server" Text='<%# Eval("FullName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblTitleProf" runat="server" Text='<%# Eval("Prof_Title")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Middle Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblAddressProf" runat="server" Text='<%# Eval("Address")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner Address" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblTINProf" runat="server" Text='<%# Eval("TINNo")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="">
                                <ItemTemplate>
                                    <a href="#" onclick="GetInfo('GetProfessionalInfo', '<%# Eval("IDCode")%>');">Select</a>
                                    <a href="#" onclick="LoadInfo('LoadProfessionalInfo','<%# Eval("IDCode")%>');">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle></FooterStyle>
                    </asp:GridView>

                    <div class="form-row">
                        <button id="_oBtnCollapseProfessional" class="btn btn-primary btn-circle" data-toggle="collapse" data-dismiss="collapse" data-target="#LeaveProfessional" data-ticket-type="standard-access" style="float: left; font-size: medium; border: none; background-color: #4975c3" onclick="return false;">
                            <i id="Switch2" runat="server" class="fas fa-plus-circle" onclick="buttonSwitch(this.id)"></i>
                        </button>
                    </div>
                    <div id="LeaveProfessional" class="collapse" runat="server">
                        <button name="_oBtnNewProfessional" runat="server" id="_oBtnNewProfessional" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 95px !Important;" onclick="DoNew('LeaveProfessional')">
                            <span class="text">New</span>
                            <span class="icon text-white-50">
                                <i class="fas fa-plus mt-1"></i>
                            </span>
                        </button>
                        <div class="card-body col-lg-12 row">
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Last Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLastNameProf" name="_oTxtLastName" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">First Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtFirstNameProf" name="_oTxtFirstName" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Middle Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtMiddleNameProf" name="_oTxtMiddleName" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtNoProf" name="_oTxtNoProf" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Lot No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLotNoProf" name="_oTxtLotNoProf" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Blk No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBlkNoProf" name="_oTxtBlkNoProf" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Phase/Zone:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPhaseZoneProf" name="_oTxtPhaseZoneProf" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Street:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtStreetProf" name="_oTxtStreetProf" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Subdivision/Village:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtSubdVillProf" name="_oTxtSubdVillProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Barangay:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBrgyProf" name="_oTxtBrgyProf" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">City/Municipality:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCityProf" name="_oTxtCityProf" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Province:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtProvinceProf" name="_oTxtProvinceProf" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Region:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtRegionProf" name="_oTxtRegionProf" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">ZipCode:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtZipCodeProf" name="_oTxtZipCodeProf" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Professional Title:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtProfessionalTitle" name="_oTxtProfessionalTitle" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Liscence No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLiscenceNoProf" name="_oTxtLiscenceNoProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Validity:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtValidity" name="_oTxtValidity" onfocus="this.type='date'" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Mobile No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtMobileNo" name="_oTxtMobileNo" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Tel No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTelNoProf" name="_oTxtTelNoProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">TIN No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTINNoProf" name="_oTxtTINNoProf" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">PTR No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPTRNoProf" name="_oTxtPTRNoProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Date Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPTRDateIssProf" name="_oTxtPTRDateIssProf" onfocus="this.type='date'" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Issued At:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPTRIssuedAtProf" name="_oTxtPTRIssuedAtProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">POA O.R. No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPOAORNoProf" name="_oTxtPOAORNoProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">POA No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPOANoProf" name="_oTxtPOANoProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Date Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPOADateIssProf" name="_oTxtPOADateIssProf" onfocus="this.type='date'" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">PRC No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPRCNoProf" name="_oTxtPRCNoProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Date Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPRCDateIssuedProf" name="_oTxtPRCDateIssuedProf" onfocus="this.type='date'" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Issued At:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPRCIssuedAtProf" name="_oTxtPRCIssuedAtProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">CTC No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCNoProf" name="_oTxtCTCNoProf" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Date Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCDateIssuedProf" name="_oTxtCTCDateIssuedProf" onfocus="this.type='date'" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Issued At:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCIssuedAtProf" name="_oTxtCTCIssuedAtProf" />
                                </div>
                            </div>
                        </div>
                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <button type="button" runat="server" id="_oBtnProfessionalInfo" class="btn btn-success btn-icon-split ml-2" onclick="SaveInfo('SaveProfessional')">
                                        <%--data-toggle="modal" data-target="#SearchRecord">--%>
                                        <span class="icon text-white">
                                            <i class="fas fa-save mt-1"></i>
                                        </span>
                                        <span class="text">Save Record</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myLotOwnerModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <%--<i class="fas fa-edit text-white float-right" style="font-size: 30px;"></i>--%>
                    <h4 class="modal-title text-white" id="myLotOwnerLabel">Lot Owner Search</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>

                <div class="modal-body">

                    <div class="card-body col-lg-12 row">
                        <div class="col-md-3 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Filter by:</span></span></label>
                                <select id="_oCbFilterLotOwner" runat="server" class="form-control CH-Size-new">
                                    <option value="LName">Last Name</option>
                                    <option value="FName">First Name</option>
                                    <option value="MName">Middle Name</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Search Key:</span></span></label>
                                <input type="text" runat="server" class="form-control CH-Size-new" name="_oTxtSearchLotOwner" id="_oTxtSearchLotOwner" />
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <button name="_oBtnSearchLotOwner" runat="server" id="_oBtnSearchLotOwner" type="button" class="btn btn-primary btn-icon-split col-md-4" style="max-width: 100px !Important;" onclick="SearchLotOwner()">
                                <span class="text">Search</span>
                                <span class="icon text-white-50">
                                    <i class="fas fa-search mt-1"></i>
                                </span>
                            </button>
                        </div>
                    </div>

                    <asp:GridView ID="_oGvLotOwner" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="Application No" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblIDCodeLO" runat="server" Text='<%# Eval("IDCode")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblFullNameLO" runat="server" Text='<%# Eval("FullName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Middle Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblAddressLO" runat="server" Text='<%# Eval("Address")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner Address" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblTINLO" runat="server" Text='<%# Eval("TIN")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="">
                                <ItemTemplate>
                                    <a href="#" onclick="GetLotOwnerInfo('<%# Eval("IDCode")%>');">Select</a>
                                    <a href="#" onclick="LoadInfo('LoadLotOwnerInfo','<%# Eval("IDCode")%>');">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle></FooterStyle>
                    </asp:GridView>

                    <div class="form-row">
                        <button id="_oBtnCollapseLotOwner" class="btn btn-primary btn-circle" data-toggle="collapse" data-dismiss="collapse" data-target="#LeaveLotOwner" data-ticket-type="standard-access" style="float: left; font-size: medium; border: none; background-color: #4975c3" onclick="return false;">
                            <i id="Switch4" runat="server" class="fas fa-plus-circle" onclick="buttonSwitch(this.id)"></i>
                        </button>
                    </div>

                    <div id="LeaveLotOwner" class="collapse" runat="server">

                        <button name="_oBtnNewLotOwner" runat="server" id="_oBtnNewLotOwner" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 95px !Important;" onclick="DoNew('LeaveLotOwner')">
                            <span class="text">New</span>
                            <span class="icon text-white-50">
                                <i class="fas fa-plus mt-1"></i>
                            </span>
                        </button>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Last Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLastNameLO" name="_oTxtLastNameLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">First Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtFirstNameLO" name="_oTxtFirstNameLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Middle Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtMiddleNameLO" name="_oTxtMiddleNameLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">TIN No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTINNoLO" name="_oTxtTINNoLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Tel No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTelNoLO" name="_oTxtTelNoLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtNoLO" name="_oTxtNoLO" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Lot No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLotNoLO" name="_oTxtLotNoLO" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Blk No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBlkNoLO" name="_oTxtBlkNoLO" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Phase/Zone:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPhaseZoneLO" name="_oTxtPhaseZoneLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Street:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtStreetLO" name="_oTxtStreetLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Subdivision/Village:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtSubdVillLO" name="_oTxtSubdVillLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Barangay:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBrgyLO" name="_oTxtBrgyLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">City/Municipality:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCityLO" name="_oTxtCityLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Province:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtProvinceLO" name="_oTxtProvinceLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Region:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtRegionLO" name="_oTxtRegionLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">ZipCode:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtZipCodeLO" name="_oTxtZipCodeLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Lot No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLotNoLOCLO" name="_oTxtLotNoLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Blk No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBlkNoLOCLO" name="_oTxtBlkNoLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">TCT No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTCTNoLOCLO" name="_oTxtTCTNoLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Tax Declaration No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTDNLOCLO" name="_oTxtTDNLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">PIN:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPINLOCLO" name="_oTxtPINLOCLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Street:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtStrtLOCLO" name="_oTxtStrtLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Barangay:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBrgyLOCLO" name="_oTxtBrgyLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">City/Municipality:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCityLOCLO" name="_oTxtCityLOCLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">CTC No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCLO" name="_oTxtCTCLO" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Place Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCPlaceIssLO" name="_oTxtCTCPlaceIssLO" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Date Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCDateIssLO" name="_oTxtCTCDateIssLO" onfocus="this.type='date'" />
                                </div>
                            </div>
                        </div>
                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <button type="button" runat="server" id="_oBtnSaveLotOwner" class="btn btn-success btn-icon-split ml-2" onclick="SaveInfo('SaveLotOwner')">
                                        <%--data-toggle="modal" data-target="#SearchRecord">--%>
                                        <span class="icon text-white">
                                            <i class="fas fa-save mt-1"></i>
                                        </span>
                                        <span class="text">Save Record</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myBldgOwnerModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <%--<i class="fas fa-edit text-white float-right" style="font-size: 30px;"></i>--%>
                    <h4 class="modal-title text-white" id="myBldgOwnerLabel">Building Owner Search</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>

                <div class="modal-body">
                    <div class="card-body col-lg-12 row">
                        <div class="col-md-3 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Filter by:</span></span></label>
                                <select id="_oCbFilterBldgOwner" runat="server" class="form-control CH-Size-new">
                                    <option value="LName">Last Name</option>
                                    <option value="FName">First Name</option>
                                    <option value="MName">Middle Name</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <div>
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Search Key:</span></span></label>
                                <input type="text" runat="server" class="form-control CH-Size-new" name="_oTxtSearchLotOwner" id="_oTxtSearchBldgOwner" />
                            </div>
                        </div>
                        <div class="col-md-4 form-group ">
                            <button name="_oBtnSearchBldgOwner" runat="server" id="_oBtnSearchBldgOwner" type="button" class="btn btn-primary btn-icon-split col-md-4" style="max-width: 100px !Important;" onclick="SearchBldgOwner()">
                                <span class="text">Search</span>
                                <span class="icon text-white-50">
                                    <i class="fas fa-search mt-1"></i>
                                </span>
                            </button>
                        </div>
                    </div>

                    <asp:GridView ID="_oGvBldgOwner" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="Application No" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblIDCodeBO" runat="server" Text='<%# Eval("IDCode")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblFullNameBO" runat="server" Text='<%# Eval("FullName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Middle Name" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblAddressBO" runat="server" Text='<%# Eval("Address")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner Address" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="_oLblTINBO" runat="server" Text='<%# Eval("TIN")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="">
                                <ItemTemplate>
                                    <a href="#" onclick="GetBldgOwnerInfo('<%# Eval("IDCode")%>');">Select</a>
                                    <a href="#" onclick="LoadInfo('LoadBldgOwnerInfo','<%# Eval("IDCode")%>');">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle></FooterStyle>
                    </asp:GridView>

                    <div class="form-row">
                        <button id="_oBtnCollapseBldgOwner" class="btn btn-primary btn-circle" data-toggle="collapse" data-dismiss="collapse" data-target="#LeaveBldgOwner" data-ticket-type="standard-access" style="float: left; font-size: medium; border: none; background-color: #4975c3" onclick="return false;">
                            <i id="Switch3" runat="server" class="fas fa-plus-circle" onclick="buttonSwitch(this.id)"></i>
                        </button>
                    </div>

                    <div id="LeaveBldgOwner" class="collapse" runat="server">

                        <button name="_oBtnNewBldgOwner" runat="server" id="_oBtnNewBldgOwner" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 95px !Important;" onclick="DoNew('LeaveBldgOwner')">
                            <span class="text">New</span>
                            <span class="icon text-white-50">
                                <i class="fas fa-plus mt-1"></i>
                            </span>
                        </button>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Last Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLastNameBO" name="_oTxtLastNameLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">First Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtFirstNameBO" name="_oTxtFirstNameLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Middle Name:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtMiddleNameBO" name="_oTxtMiddleNameLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">TIN No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTINNoBO" name="_oTxtTINNoLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Tel No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTelNoBO" name="_oTxtTelNoLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtNoBO" name="_oTxtNoLO" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Lot No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLotNoBO" name="_oTxtLotNoLO" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Blk No:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBlkNoBO" name="_oTxtBlkNoLO" />
                                </div>
                            </div>
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Phase/Zone:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPhaseZoneBO" name="_oTxtPhaseZoneLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Street:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtStreetBO" name="_oTxtStreetLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Subdivision/Village:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtSubdVillBO" name="_oTxtSubdVillLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Barangay:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBrgyBO" name="_oTxtBrgyLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">City/Municipality:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCityBO" name="_oTxtCityLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Province:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtProvinceBO" name="_oTxtProvinceLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Region:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtRegionBO" name="_oTxtRegionLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">ZipCode:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtZipCodeBO" name="_oTxtZipCodeLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-1 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Lot No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtLotNoLOCBO" name="_oTxtLotNoLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-2 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Blk No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBlkNoLOCBO" name="_oTxtBlkNoLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">TCT No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTCTNoLOCBO" name="_oTxtTCTNoLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Tax Declaration No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTDNLOCBO" name="_oTxtTDNLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">PIN:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPINLOCBO" name="_oTxtPINLOCLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Street:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtStrtLOCBO" name="_oTxtStrtLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Barangay:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBrgyLOCBO" name="_oTxtBrgyLOCLO" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">City/Municipality:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCityLOCBO" name="_oTxtCityLOCLO" />
                                </div>
                            </div>
                        </div>

                        <div class="card-body col-lg-12 row">
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">CTC No.:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCBO" name="_oTxtCTCLO" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Place Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCPlaceIssBO" name="_oTxtCTCPlaceIssLO" />
                                </div>
                            </div>
                            <div class="col-md-4 form-group ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Date Issued:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCTCDateIssBO" name="_oTxtCTCDateIssLO" onfocus="this.type='date'" />
                                </div>
                            </div>
                        </div>
                        <div class="card-body col-lg-12 row">
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                            </div>
                            <div class="col-md-3 form-group ">
                                <div>
                                    <button type="button" runat="server" id="_oBtnSaveBldgOwner" class="btn btn-success btn-icon-split ml-2" onclick="SaveInfo('SaveBldgOwner')">
                                        <%--data-toggle="modal" data-target="#SearchRecord">--%>
                                        <span class="icon text-white">
                                            <i class="fas fa-save mt-1"></i>
                                        </span>
                                        <span class="text">Save Record</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input type="hidden" runat="server" id="_oTxtHdnSearchMode" />
        <input type="hidden" runat="server" id="_oTxtHdnSaveModeApplicant" value="New" />
        <input type="hidden" runat="server" id="_oTxtHdnIDCodeApplicant" />
        <input type="hidden" runat="server" id="_oTxtHdnSaveModeProfessional" value="New" />
        <input type="hidden" runat="server" id="_oTxtHdnIDCodeProfessional" />
        <input type="hidden" runat="server" id="_oTxtHdnSaveModePropOwner" value="New" />
        <input type="hidden" runat="server" id="_oTxtHdnIDCodeBldgOwner" />
        <input type="hidden" runat="server" id="_oTxtHdnIDCodeLotOwner" />
        <input type="hidden" runat="server" id="_oTxtActiveModal" />
        <input type="hidden" runat="server" id="_oTxtHdnSaveModeApplication" value="New" />
    </div>

    <script>
        document.getElementById('<%= _oTxtDivision.ClientID%>').disabled = true;

        function filter() {
            var cmb1 = document.getElementById('<%= _oTxtOccupancyUse.ClientID%>').value;
            var cmb2 = document.getElementById('<%= _oTxtDivision.ClientID%>');
            var cmb3 = document.getElementById('<%= _oTxtOccupancy.ClientID%>');

            if (document.getElementById('<%= _oTxtOccupancyUse.ClientID%>').value != '') {
                document.getElementById('<%= _oTxtDivision.ClientID%>').disabled = false;
                for (var i = 0; i < cmb2.length; i++) {
                    var txt = String(cmb2.options[i].value).substring(0, 2);
                    if (!txt.match(cmb1)) {
                        $(cmb2.options[i]).attr('disabled', 'disabled').hide();
                    }
                    else {
                        $(cmb2.options[i]).removeAttr('disabled').show();
                    }
                }
            }
            else {
                document.getElementById('<%= _oTxtDivision.ClientID%>').disabled = true;
                document.getElementById('<%= _oTxtDivision.ClientID%>').value = "";
            }

            if (document.getElementById('<%= _oTxtOccupancyUse.ClientID%>').value != '') {
                document.getElementById('<%= _oTxtOccupancy.ClientID%>').disabled = false;
                for (var i = 0; i < cmb3.length; i++) {
                    var txt = String(cmb3.options[i].value).substring(0, 2);
                    if (!txt.match(cmb1)) {
                        $(cmb3.options[i]).attr('disabled', 'disabled').hide();
                    }
                    else {
                        $(cmb3.options[i]).removeAttr('disabled').show();
                    }
                }
            }
            else {
                document.getElementById('<%= _oTxtOccupancy.ClientID%>').disabled = true;
                document.getElementById('<%= _oTxtOccupancy.ClientID%>').value = "";
            }
            document.getElementById('<%= _oTxtDivision.ClientID%>').value = "";
            document.getElementById('<%= _oTxtOccupancy.ClientID%>').value = "";
        }

        function GetScopeCode(ScopeCode, ifchk) {
            if (ifchk == true) {
                document.getElementById('<%=_oHdnSelectedScope.ClientID%>').value = document.getElementById('<%=_oHdnSelectedScope.ClientID%>').value + ScopeCode + ";";
                document.getElementById('<%=_oHdnSelectedScope.ClientID%>').value = String(document.getElementById('<%=_oHdnSelectedScope.ClientID%>').value).replace("'", "");
                document.getElementById('<%=_oHdnSelectedScope.ClientID%>').value = String(document.getElementById('<%=_oHdnSelectedScope.ClientID%>').value).replace("'", "");
            }
            if (ifchk == false) {
                ScopeCode = String(ScopeCode).replace("'", "");
                ScopeCode = String(ScopeCode).replace("'", "");
                document.getElementById('<%=_oHdnSelectedScope.ClientID%>').value = String(document.getElementById('<%=_oHdnSelectedScope.ClientID%>').value).replace(ScopeCode + ";", "")
            }
        }
        function GetAccessoryCode(AccessoryCode, ifchk) {

            if (ifchk == true) {

                document.getElementById('<%=_oHdnSelectedAccessory.ClientID%>').value = document.getElementById('<%=_oHdnSelectedAccessory.ClientID%>').value + AccessoryCode + ";";
                document.getElementById('<%=_oHdnSelectedAccessory.ClientID%>').value = String(document.getElementById('<%=_oHdnSelectedAccessory.ClientID%>').value).replace("'", "");
                document.getElementById('<%=_oHdnSelectedAccessory.ClientID%>').value = String(document.getElementById('<%=_oHdnSelectedAccessory.ClientID%>').value).replace("'", "");
                AccessoryCode = String(AccessoryCode).replace("'", "");
                AccessoryCode = String(AccessoryCode).replace("'", "");
                if (AccessoryCode == "TOW") {
                    document.getElementById("DivTowerSS").style.display = "block";
                    document.getElementById("DivTowerTG").style.display = "block";
                }
            }
            if (ifchk == false) {
                AccessoryCode = String(AccessoryCode).replace("'", "");
                AccessoryCode = String(AccessoryCode).replace("'", "");
                document.getElementById('<%=_oHdnSelectedAccessory.ClientID%>').value = String(document.getElementById('<%=_oHdnSelectedAccessory.ClientID%>').value).replace(AccessoryCode + ";", "")
                if (AccessoryCode == "TOW") {
                    document.getElementById("DivTowerSS").style.display = "none";
                    document.getElementById("DivTowerTG").style.display = "none";
                }
            }
        }

        function DoNew(DivName) {
            $('#' + DivName).find(':input').each(function () {
                switch (this.type) {
                    case 'text':
                        this.value = '';
                    case 'date':
                        this.value = '';
                }
            });
            if (DivName == 'LeaveApplicant') {
                document.getElementById('<%=_oTxtHdnSaveModeApplicant.ClientID%>').value = 'New';
            }
            if (DivName == 'LeaveProfessional') {
                document.getElementById('<%=_oTxtHdnSaveModeProfessional.ClientID%>').value = 'New';
            }
            if (DivName == 'LeaveBldgOwner') {
                document.getElementById('<%=_oTxtHdnSaveModeProfessional.ClientID%>').value = 'New';
            }
            if (DivName == 'LeaveLotOwner') {
                document.getElementById('<%=_oTxtHdnSaveModeProfessional.ClientID%>').value = 'New';
            }
            if (DivName == 'ApplicationContent') {
                document.getElementById('<%=_oTxtHdnSaveModeApplication.ClientID%>').value = 'New';
            }
            if (document.getElementById('<%=_oTxtApplicantType.ClientID%>').value == "A") {
                document.getElementById('<%=_oBtnLOConsentSearch.ClientID%>').hidden = true;
            }
            if (document.getElementById('<%=_oTxtApplicantType.ClientID%>').value == "B") {
                document.getElementById('<%=_oBtnLOConsentSearch.ClientID%>').hidden = false;
            }
            if (document.getElementById('<%=_oTxtApplicantType.ClientID%>').value == "C") {
                document.getElementById('<%=_oBtnLOConsentSearch.ClientID%>').hidden = true;
            }
            if (document.getElementById('<%=_oTxtApplicantType.ClientID%>').value == "O") {
                document.getElementById('<%=_oBtnLOConsentSearch.ClientID%>').hidden = true;
            }
        }


        function SaveInfo(Mode) {
            if (Mode == 'SaveApplicant') {
                __doPostBack(Mode, document.getElementById('<%=_oTxtHdnIDCodeApplicant.ClientID%>').value)
            }
            if (Mode == 'SaveProfessional') {
                __doPostBack(Mode, document.getElementById('<%=_oTxtHdnIDCodeProfessional.ClientID%>').value)
            }
            if (Mode == 'SaveBldgOwner') {
                __doPostBack(Mode, document.getElementById('<%=_oTxtHdnIDCodeBldgOwner.ClientID%>').value)
            }
            if (Mode == 'SaveLotOwner') {
                __doPostBack(Mode, document.getElementById('<%=_oTxtHdnIDCodeLotOwner.ClientID%>').value)
            }
        }

        function buttonSwitch(switchid) {
            var element = switchid

            if (element.classList.value == "fas fa-minus-circle" || element.classList.value == "fas fa-minus-circle collapsed") {
                element.classList.add("fa-minus-circle");
                element.classList.add("fas");
                element.classList.remove("fa-plus-circle")
                element.classList.value = "fas fa-minus-circle"
                document.getElementById(id).title = "Expand"
            } else {
                element.classList.add("fa-plus-circle");
                element.classList.add("fas");
                element.classList.remove("fa-minus-circle")
                element.classList.value = "fas fa-plus-circle"
                document.getElementById(id).title = "Collapsed"
            }
        }

        function GetInfo(ApplicantType, IDCode) {
            if (ApplicantType == 'GetApplicantInfo') {
                __doPostBack('GetApplicantInfo', IDCode);
            }
            if (ApplicantType == 'GetProfessionalInfo') {
                __doPostBack('GetProfessionalInfo', IDCode);
            }
            if (ApplicantType == 'GetBldgOwner') {
                __doPostBack('GetBldgOwner', IDCode);
            }
            if (ApplicantType == 'GetApplicationInfo') {
                __doPostBack('GetApplicationInfo', IDCode);
            }
        }

        function LoadInfo(ApplicantType, IDCode) {
            if (ApplicantType == 'LoadApplicantInfo') {
                document.getElementById('<%=_oTxtHdnIDCodeApplicant.ClientID%>').value = IDCode;
                document.getElementById('<%=_oTxtHdnSaveModeApplicant.ClientID%>').value = "Edit"
                __doPostBack('LoadApplicantInfo', IDCode);
            }
            if (ApplicantType == 'LoadProfessionalInfo') {
                document.getElementById('<%=_oTxtHdnIDCodeProfessional.ClientID%>').value = IDCode;
                document.getElementById('<%=_oTxtHdnSaveModeProfessional.ClientID%>').value = "Edit"
                __doPostBack('LoadProfessionalInfo', IDCode);
            }
            if (ApplicantType == 'LoadBldgOwnerInfo') {
                document.getElementById('<%=_oTxtHdnIDCodeBldgOwner.ClientID%>').value = IDCode;
                document.getElementById('<%=_oTxtHdnSaveModePropOwner.ClientID%>').value = "Edit"
                __doPostBack('LoadBldgOwnerInfo', IDCode);
            }
            if (ApplicantType == 'LoadLotOwnerInfo') {
                document.getElementById('<%=_oTxtHdnIDCodeLotOwner.ClientID%>').value = IDCode;
                document.getElementById('<%=_oTxtHdnSaveModePropOwner.ClientID%>').value = "Edit"
                __doPostBack('LoadLotOwnerInfo', IDCode);
            }
        }

        function GetLotOwnerInfo(IDCode) {
            if (document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value == 'LOC') {
                document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value = 'LOC';
            }
            __doPostBack('GetLotOwnerInfo', IDCode);
        }

        function GetBldgOwnerInfo(IDCode) {
            __doPostBack('GetBldgOwnerInfo', IDCode);
        }

        function SearchApplicant() {
            __doPostBack('SearchApplicant', '');
        }

        function SearchApplication() {
            __doPostBack('SearchApplication', '');
        }
        function SearchProfessional() {
            if (document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value == 'FI') {
                document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value = 'FI';
            }
            __doPostBack('SearchProfessional', '');
        }
        function SearchLotOwner() {
            if (document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value == 'LOC') {
                document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value = 'LOC';
            }
            __doPostBack('SearchLotOwner', '');
        }
        function SearchBldgOwner() {
            __doPostBack('SearchBldgOwner', '');
        }

        function OpenModal() {
            if (document.getElementById('<%=_oTxtApplicantType.ClientID%>').value == 'A') {
                document.getElementById('<%=_oTxtActiveModal.ClientID%>').value = "Applicant"
                $('#myApplicantModal').modal('show');
            }
            if (document.getElementById('<%=_oTxtApplicantType.ClientID%>').value == 'C') {
                document.getElementById('<%=_oTxtActiveModal.ClientID%>').value = "Professional"
                document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value = 'APP';
                $('#myProfessionalModal').modal('show');
            }
            if (document.getElementById('<%=_oTxtApplicantType.ClientID%>').value == 'O') {
                document.getElementById('<%=_oTxtActiveModal.ClientID%>').value = "LotOwner"
                document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value = 'APP';
                $('#myLotOwnerModal').modal('show');
            }
            if (document.getElementById('<%=_oTxtApplicantType.ClientID%>').value == 'B') {
                document.getElementById('<%=_oTxtActiveModal.ClientID%>').value = "BldgOwner"
                $('#myBldgOwnerModal').modal('show');
            }
        }

        function OpenModalLOC() {
            document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value = 'LOC';
            $('#myLotOwnerModal').modal('show');
        }
        function OpenModalFI() {
            document.getElementById('<%=_oTxtHdnSearchMode.ClientID%>').value = 'FI';
            $('#myProfessionalModal').modal('show');
        }
    </script>
</asp:Content>
