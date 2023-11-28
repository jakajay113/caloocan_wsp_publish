<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="Permits.aspx.vb" Inherits="OBO.Permits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class=" col-lg-12">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="card col-lg-12 px-0">
                    <div class="card-header ">
                        <h5 class="m-2 font-weight-bold text-primary">Issued Permits</h5>
                    </div>
                    <div class="card-body col-lg-12 row table-responsive mx-auto px-auto">

                        <h6 class="m-2 font-weight-bold text-primary">Building Permit</h6>
                        <asp:GridView ID="_oGVPermits" Visible="false" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                            PageSize="5" OnPageIndexChanging="_oGVPermits_PageIndexChanging">
                            <PagerSettings Mode="NumericFirstLast"
                                FirstPageText="First"
                                LastPageText="Last"
                                PageButtonCount="3"
                                Position="Bottom"
                                Visible="true" />
                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="Date/Time" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelDateTime" runat="server" Text='<%# Eval("AppDate")%>' />
                                        <%--<%# Eval("Date", "{0:MMM dd, yyyy HH:mm:ss}")%>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name of Applicant" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelAppName" runat="server" Text='<%# Eval("FirstName") + " " + Eval("MiddleName") + " " + Eval("LastName")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location of Construction" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelLocCons" runat="server" Text='<%# Eval("LotNoLOC") + " " + Eval("BlkNoLOC") + " " + Eval("StreetLOC") + " " + _
                                        Eval("BrgyLOC") + " " + Eval("City") + " " + Eval("Province") + " " + Eval("ZIPCode")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type of Service" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTypeSevice" runat="server" Text='<%# Eval("ServiceType")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransNo" runat="server" Text='<%# Eval("TransNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Application No." Visible="false" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransNo" runat="server" Text='<%# Eval("AppNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a href="#" data-toggle="modal" data-target="#InformationModal" onclick="__doPostBack('RetrieveInfo','<%# Eval("AppNo")%>')">Information</a>
                                        <a href="#" data-toggle="modal" onclick="ViewSPA_IP('FileName','FileExtn','ImageData','<%# Eval("TransNo")%>');">Print Permit</a>
                                        <a href="#" data-toggle="modal" onclick="ViewSPA_IP('ORFileName','ORFileExtn','ORImageData','<%# Eval("TransNo")%>');">Print OR</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                       <asp:GridView ID="_oGVIssuedPermits" runat="server" CssClass="mGrid Table-MobileView Table-Fullrowselect" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                            PageSize="5" OnPageIndexChanging="_oGVIssuedPermits_PageIndexChanging">
                            <PagerSettings Mode="NumericFirstLast"
                                FirstPageText="First"
                                LastPageText="Last"
                                PageButtonCount="3"
                                Position="Bottom"
                                Visible="true" />
                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="Date/Time" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelDateTime" runat="server" Text='<%# Eval("AppDate")%>' />
                                        <%--<%# Eval("Date", "{0:MMM dd, yyyy HH:mm:ss}")%>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name of Applicant" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransNo" runat="server" Text='<%# Eval("FirstName") + " " + Eval("MiddleName") + " " + Eval("LastName")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location of Construction" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelACCTNO" runat="server" Text='<%# Eval("LotNoLOC") + " " + Eval("BlkNoLOC") + " " + Eval("StreetLOC") + " " + _
                                        Eval("BrgyLOC") + " " + Eval("City") + " " + Eval("Province") + " " + Eval("ZIPCode")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type of Service" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransType" runat="server" Text='<%# Eval("ServiceType")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransDescription" runat="server" Text='<%# Eval("TransNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Permit No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelPermitNo" runat="server" Text='<%# Eval("PermitNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                       <%-- <a href="#" data-toggle="modal" data-target="#InformationModal" onclick="__doPostBack('RetrieveInfo','<%# Eval("AppNo")%>')">Information</a>--%>
                                        <a name="btndownload" download="<%# Eval("FileName")%>" href="<%# Eval("File64")%>"    target="_blank"  style="font-size: 14px !Important; height: 30px !Important; max-width:100px !Important;" >  Download Billing  </a>
                                         &nbsp | &nbsp
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>




                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="modal fade" id="InformationModal">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;">Information</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" align="center">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
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
                                        <h6 class="font-weight-bold text-primary mt-2">Form of Ownership: </h6>
                                    </div>
                                    <div class="col-lg-3 form-group">
                                        <select class="form-control CH-Size-new" id="_oTxtFormofOwnership" runat="server" disabled>
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
                                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTINNo" placeholder="" runat="server" readonly />
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
                                    <div class="col-lg-6 form-group">
                                        <label class="input-txt input-txt-active2"><span><span class="m-2">Email</span></span></label>
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
                                <asp:GridView ID="_oGvUpload" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Transaction ID" Visible="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="_oLblCodeReq" runat="server" Text='<%# Eval("TransID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requirements" Visible="false" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40%">
                                            <ItemTemplate>
                                                <asp:Label ID="_oLblDesc1Req" runat="server" Text='<%# Eval("ReqCode")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requirements" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40%">
                                            <ItemTemplate>
                                                <asp:Label ID="_oLblDesc2Req" runat="server" Text='<%# Eval("ReqDesc")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="_oLblStatus" runat="server" Text='<%# Eval("Status")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="_oLblRemarks" runat="server" Text='<%# Eval("Remarks")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <%--<a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab();ViewSPA('ReqDesc','AttType','AttFile','<%# Eval("ReqCode")%>');">View</a>--%>
                                                <a href="#" onclick="ViewSPA('ReqDesc','AttType','AttFile','<%# Eval("ReqCode")%>','<%# Eval("TransID")%>');" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary">View</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-primary btn-sm pull-center" data-dismiss="modal" id="_obtnProceed" runat="server" onclick="__doPostBack('Update','')">Update</button>--%>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
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
                        </div>
                        <%--<div class="modal-footer" style="text-align: center">
                        <span>Remarks</span>
                        <asp:UpdatePanel runat="server" class="w-100">
                            <ContentTemplate>
                                <textarea id="_oTxtRemarks" runat="server" class="form-control"></textarea>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <button type="button" class="btn btn-danger" data-target="#Confirmation" data-toggle="modal" onclick="document.getElementById('<%=hdnaction.ClientID%>').value = 'Rejected';">Reject</button>
                        <button type="button" class="btn btn-success" data-target="#Confirmation" data-toggle="modal" onclick="document.getElementById('<%=hdnaction.ClientID%>').value = 'Approved';">Approve</button>
                    </div>--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <input type="hidden" runat="server" id="hdnName" />
    <input type="hidden" runat="server" id="hdnType" />
    <input type="hidden" runat="server" id="hdnData" />
    <input type="hidden" runat="server" id="hdnaction" />
    <input type="hidden" runat="server" id="hdnTransID" />
    <input type="hidden" runat="server" id="hdnReqCode" />
    <input type="hidden" runat="server" id="hdnAppNo" />
    <input type="hidden" runat="server" id="hdnISFileName" />
    <input type="hidden" runat="server" id="hdnISFileData" />
    <input type="hidden" runat="server" id="hdnISFileType" />
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
        function ViewSPA_IP(Name, Type, Data, transid) {

            document.getElementById('<%=hdnName.ClientID%>').value = Name;
                document.getElementById('<%=hdnType.ClientID%>').value = Type;
                document.getElementById('<%=hdnData.ClientID%>').value = Data;
                document.getElementById('<%=hdnTransID.ClientID%>').value = transid;
                __doPostBack('DownloadFiles_IP', '');
            }
            function openModalChecklist() {
                $('#ModalChecklist').modal('show');
            }
    </script>
</asp:Content>
