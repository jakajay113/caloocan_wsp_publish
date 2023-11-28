<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="ApplicationPermit.aspx.vb" Inherits="OBO.ApplicationPermit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

      <style type="text/css">
        .uppercase {
            text-transform: uppercase;
        } 
        .lowercase {
            text-transform: lowercase;
        } 
        .capitalize {
            text-transform: capitalize;
        }
    </style>


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
        function Capitalize(text) {
            var split = text.split(" ");
            var result = "";
            for (var i = 0; i < split.length; i++) {
                if (split[i] != "") {
                    var currentSplit = split[i];
                    var lng = currentSplit.length;
                    result = result + currentSplit[0].toUpperCase() + currentSplit.substring(1) + " ";
                }
            }
            return result;
        }
    </script>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="snackbar" style="position: absolute">
                <asp:Label runat="server" ID="_oLabelSnackbar" />
            </div>
            <div id="snackbargreen" style="position: absolute">
                <asp:Label runat="server" ID="_oLabelSnackbargreen" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <div class=" col-lg-12">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="card col-lg-12 px-0">
                    <div class="card-header ">
                        <h5 class="m-2 font-weight-bold text-primary">Account Information</h5>
                    </div>
                    <div class="card-body col-lg-12 row table-responsive mx-auto px-auto">

                        <%--New Application (For Review)--%>
                        <h6 class="m-2 font-weight-bold text-primary">New Application (For Review)</h6>
                        <asp:GridView ID="_oGVNewApplication" runat="server" CssClass="mGrid Table-MobileView Table-Fullrowselect" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                            PageSize="5" OnPageIndexChanging="_oGVNewApplication_PageIndexChanging">
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

                                        <a href="#" onclick="Follow_UP_dpb('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>')">Follow-up</a>


                                        <a href="#" data-target="#Confirmation" data-toggle="modal" onclick="CancelApplciation('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>','<%# Eval("ServiceDescription")%>','<%# Eval("ServiceType")%>');">Cancel</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                           <h6 class="m-2 font-weight-bold text-primary">Disapproved Application</h6>
                        <asp:GridView ID="_oGVDisapproved" runat="server" CssClass="mGrid Table-MobileView Table-Fullrowselect" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                            PageSize="5" OnPageIndexChanging="_oGVDisapproved_PageIndexChanging">
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
                                        <a href="#" onclick="UpdateApplication('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>')">Update</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                        <%--Approved Application (For Payment)--%>
                        <h6 class="m-2 font-weight-bold text-primary">Approved Application (For Payment)</h6>
                        <asp:GridView ID="_oGVNewPayment" runat="server" CssClass="mGrid Table-MobileView Table-Fullrowselect" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                            PageSize="5" OnPageIndexChanging="_oGVNewPayment_PageIndexChanging">
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
                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                       <%-- <a href="#" data-toggle="modal" data-target="#InformationModal" onclick="__doPostBack('RetrieveInfo','<%# Eval("AppNo")%>')">Information</a>--%>
                                        <a name="btndownload" download="<%# Eval("FileName")%>" href="<%# Eval("File64")%>"    target="_blank"  style="font-size: 14px !Important; height: 30px !Important; max-width:100px !Important;" >  Download Billing  </a>
                                         &nbsp | &nbsp
                                       <%-- <a href="#" onclick="ViewBilling('<%# Eval("TransNo")%>','<%# Eval("AppNo")%>');" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" >View Billing</a>
                                        &nbsp | &nbsp--%>
                                        <a href="#" onclick="Payment('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>','<%# Eval("FirstName") + " " + Eval("MiddleName") + " " + _
                                        Eval("LastName")%>','<%# Eval("LotNoLOC") + " " + Eval("BlkNoLOC") + " " + Eval("StreetLOC") + " " + _
                                        Eval("BrgyLOC") + " " + Eval("City") + " " + Eval("Province") + " " + Eval("ZIPCode")%>');">Payment</a>
                                       <%-- <a href="#" data-target="#Confirmation" data-toggle="modal" onclick="CancelApplciation('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>','<%# Eval("ServiceDescription")%>','<%# Eval("ServiceType")%>');">Cancel</a>--%>
                                     
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>



                        <%--Transaction History--%>
                        <h6 class="m-2 font-weight-bold text-primary">Transaction History</h6>
                        <asp:GridView ID="_oGVTransactions" runat="server" CssClass="mGrid Table-MobileView Table-Fullrowselect" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                            PageSize="5" OnPageIndexChanging="_oGVTransactions_PageIndexChanging">
                            <PagerSettings Mode="NumericFirstLast"
                                FirstPageText="First"
                                LastPageText="Last"
                                PageButtonCount="3"
                                Position="Bottom"
                                Visible="true" />
                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransDescription" runat="server" Text='<%# Eval("TransNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date/Time" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelDateTime" runat="server" Text='<%# Eval("AppDate")%>' />
                                        <%--<%# Eval("Date", "{0:MMM dd, yyyy HH:mm:ss}")%>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type of Service" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransType" runat="server" Text='<%# Eval("ServiceType")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransDescription" runat="server" Text='<%# Eval("ServiceDescription")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransDescription" runat="server" Text='<%# Eval("Status")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <a href="#">Information</a>
                                <a href="#">Payment</a>
                                <a href="#">Cancel</a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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
                                        <select class="form-control CH-Size-new" id="_oDLL_FormofOwnership" runat="server" disabled>
                                             <option value="C">CORPORATION</option>
                                              <option value="DS">AD</option>
                                              <option value="G">GOVERNMENT OWNED</option>
                                              <option value="J">CONJUGAL</option>
                                              <option value="P">PARTNERSHIP</option>
                                              <option value="S">SINGLE</option>
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

                             <%--GRIDVIEW--%>
                            <div class="col-lg-12 row table-responsive">
                                <%--GRIDVIEW UPLOAD--%>
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
                                        <asp:TemplateField HeaderText="Requirement Description" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="40%" >
                                            <ItemTemplate>
                                                <asp:Label ID="_oLblDesc2Req" runat="server" Text='<%# Eval("Desc2")%>'   TextChanged="function(s,e){s.SetText(Capitalize(s.GetText()));}" />
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
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:FileUpload ID="_oFileUploadRequirements" runat="server" Multiple="Multiple" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                <%--GRIDVIEW UPLOAD VIEW ONLY--%>
                                <asp:GridView ID="_oGvUploadViewOnly" Visible="false" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
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
                                       <asp:TemplateField HeaderText="Requirement Description" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="40%" >
                                            <ItemTemplate>
                                                <asp:Label ID="_oLblDesc2Req" runat="server" Text='<%# Eval("Desc2")%>'   TextChanged="function(s,e){s.SetText(Capitalize(s.GetText()));}" />
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
                                    </Columns>
                                </asp:GridView>
                            </div>
                               <div class="modal-footer">
                                <button type="button" class="btn btn-primary btn-sm pull-center" data-dismiss="modal"  id="_oBtnUploadRequirements"  runat="server" onclientClick="NextPage();" >Update</button>
                            </div>
              
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger  ControlID="_oBtnUploadRequirements"/>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
               
            </div>
        </div>
    </div>

    <div class="modal fade" id="Confirmation">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header bg-warning">
                    <a class="text-white float-right" style="font-size: 20px;">Cancel Permit Request</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body align-content-center align-items-center " style="text-align: center"><span>Do you want to continue?</span> </div>
                <div class="modal-footer align-content-center align-items-center justify-content-center" style="text-align: center">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <%--<asp:Button runat="server" class="btn btn-danger" Text="No" OnClick="SubApproveAction_Click"/>--%>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                            <asp:Button runat="server" class="btn btn-success" Text="Yes" OnClick="CancelApplication_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <%--<button type="button" class="btn btn-danger w-25" data-dismiss="modal"> No </button>   
                    <button type="button" class="btn btn-success w-25" data-dismiss="modal"> Yes </button>--%>
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id="ModalChecklist">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;"></a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"> Billing Preview </h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" align="center" runat="server" id="div1">
                    <asp:Literal ID="ltEmbed" runat="server" />
                    <asp:Image ID="Image1" runat="server" style="height:100vh;min-width:100%" />
                    <%--<embed id="" runat=""/>--%>
<%--                    <button type="button" class="btn btn-primary"onclick="opennewtab('');ViewSPA_2();">Open in new Tab</button>--%>
                </div>

            </div>
        </div>
    </div>
    


    <input type="hidden" runat="server" id="hdnAppNo" />
    <input type="hidden" runat="server" id="hdntransno" />
    <input type="hidden" runat="server" id="hdnsvcdesc" />
    <input type="hidden" runat="server" id="hdnsvctype" />
    <input type="hidden" runat="server" id="hdnappname" />

      <input type="hidden" runat="server" id="hdnName" />
      <input type="hidden" runat="server" id="hdnType" />
      <input type="hidden" runat="server" id="hdnData" />
      <input type="hidden" runat="server" id="hdnTransID" />

    <input type="hidden" runat="server" id="hdnloc" />
    <script>

        function CancelApplciation(appno, transno, svcdesc, svctype) {
            document.getElementById('<%=hdnAppNo.ClientID%>').value = appno;
            document.getElementById('<%=hdntransno.ClientID%>').value = transno;
            document.getElementById('<%=hdnsvcdesc.ClientID%>').value = svcdesc;
            document.getElementById('<%=hdnsvctype.ClientID%>').value = svctype;
        }
        function Payment(appno, transno, appname, location) {
            document.getElementById('<%=hdnAppNo.ClientID%>').value = appno;
            document.getElementById('<%=hdntransno.ClientID%>').value = transno;
            document.getElementById('<%=hdnappname.ClientID%>').value = appname;
            document.getElementById('<%=hdnloc.ClientID%>').value = location;
            __doPostBack('Payment', '');
        }

        function Follow_UP_dpb(appno, transno) {
            document.getElementById('<%=hdnAppNo.ClientID%>').value = appno;
            document.getElementById('<%=hdntransno.ClientID%>').value = transno;
            __doPostBack('Follow_UP', '');
        }

        function UpdateApplication(appno, transno) {
            document.getElementById('<%=hdnAppNo.ClientID%>').value = appno;
            document.getElementById('<%=hdntransno.ClientID%>').value = transno;
            __doPostBack('UpdateApplication', '');
        }

        function ViewBilling(transNo, AppNo) {
            document.getElementById('<%=hdnAppNo.ClientID%>').value = AppNo;
            document.getElementById('<%=hdntransno.ClientID%>').value = transNo;
            __doPostBack('DownloadFiles', transNo);
         }

        function openModalChecklist() {
            $('#ModalChecklist').modal('show');
        }

    </script>
     

</asp:Content>
