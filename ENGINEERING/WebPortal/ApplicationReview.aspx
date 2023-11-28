<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUPermitMaster.Master" CodeBehind="ApplicationReview.aspx.vb" Inherits="OBO.ApplicationReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="script_manager"></asp:ScriptManager>
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
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <div class=" col-lg-12">
        <div class="card col-lg-12 px-0">
            <div class="card-header ">
                <h5 class="m-2 font-weight-bold text-primary">Account Enrollment transaction</h5>
            </div>

            <%--Updated Applicatio--%>
            <div class="card-body col-lg-12 row table-responsive mx-auto px-auto mb-0">
                <h6 class="m-2 font-weight-bold text-primary" id="_oHUpdatedApp">Updated Application</h6>
                <asp:GridView ID="_oGvUpdated" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                    PageSize="5" OnPageIndexChanging="_oGvUpdated_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTransNo" runat="server" Text='<%# Eval("TransNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Service Type." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelServiceType" runat="server" Text='<%# Eval("ServiceType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Location of Construction" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelLocCons" runat="server" Text='<%# Eval("LotNoLOC") + " " + Eval("BlkNoLOC") + " " + Eval("StreetLOC") + " " + _
                                        Eval("BrgyLOC") + " " + Eval("City") + " " + Eval("Province") + " " + Eval("ZIPCode")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <button type="button" class="btn btn-link p-0 m-0" onclick="do_ViewProcess('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>')">Review</button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <%--For Review--%>
            <div class="card-body col-lg-12 row table-responsive mt-0 mx-auto px-auto">
                <h6 class="m-2 font-weight-bold text-primary" id="_oHPermit"><a id="_oLblReviewTittle"> </a>For Review</h6>
                <asp:GridView ID="_oGVReview" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                    PageSize="5" OnPageIndexChanging="_oGVReview_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTransNo" runat="server" Text='<%# Eval("TransNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Service Type." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelServiceType" runat="server" Text='<%# Eval("ServiceType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location of Construction" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelLocCons" runat="server" Text='<%# Eval("LotNoLOC") + " " + Eval("BlkNoLOC") + " " + Eval("StreetLOC") + " " + _
                                        Eval("BrgyLOC") + " " + Eval("City") + " " + Eval("Province") + " " + Eval("ZIPCode")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <button type="button" class="btn btn-link p-0 m-0" onclick="do_ViewProcess('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>')">Review</button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <%--For Assessment/Billing--%>
                <h6 class="m-2 font-weight-bold text-primary" id="_oHAssessment" ><a id="_oLblAssessTittle"> </a>For Assessment/Billing</h6>
                <asp:GridView ID="_oGVAssessment" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                    PageSize="5" OnPageIndexChanging="_oGVAssessment_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTransDescription" runat="server" Text='<%# Eval("TransNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Service Type." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelServiceType" runat="server" Text='<%# Eval("ServiceType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Reviewed By" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelReviewedBy" runat="server" Text='<%# Eval("ReviewedBy")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Date Reviewed" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDateReviewed" runat="server" Text='<%# Eval("DateReviewed")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Applciation No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelApplciation" runat="server" Text='<%# Eval("AppNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("UserID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <button type="button" class="btn btn-link p-0 m-0" onclick="assess('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>','<%# Eval("UserID")%>')")>Upload Billing</button>
                                <%--<a href="#">View/Edit</a>   --%>
                                <%--<asp:Button ID="_obtnForBilling" runat="server" CommandArgument="<%# Eval("AppNo")%>" CommandName="sa" OnClick="SubAssessment_Click" Text="View/Edit" CssClass="btn btn-link" />                                    --%>
                                <%--<button type="button" class="btn btn-link p-0 m-0" onclick="assess('<%# Eval("AppNo")%>','<%# Eval("UserID")%>')">Upload & Send Assessment billing</button>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

              
                <%--For OR Release--%>
                <h6 class="m-2 font-weight-bold text-primary" id="_oHORRelease" ><a id="_oLblORTittle"> </a>For OR Release</h6>
                <asp:GridView ID="_oGVORRelease" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                    PageSize="5" OnPageIndexChanging="_oGVORRelease_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTransDescription" runat="server" Text='<%# Eval("TransNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Service Type." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelServiceType" runat="server" Text='<%# Eval("ServiceType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Applciation No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelApplciation" runat="server" Text='<%# Eval("AppNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("UserID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <button type="button" class="btn btn-link p-0 m-0" onclick="ReleaseOR('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>','<%# Eval("UserID")%>')")>Upload Official Reciept</button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                   <%--For Permit Release--%>
                <h6 class="m-2 font-weight-bold text-primary" id="_oHPermitRelease" ><a id="_oLblPermitTittle"> </a>For Permit Release</h6>
                <asp:GridView ID="_oGVPermitRelease" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                    PageSize="5" OnPageIndexChanging="_oGVPermitRelease_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTransDescription" runat="server" Text='<%# Eval("TransNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                       <asp:TemplateField HeaderText="Service Type." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelServiceType" runat="server" Text='<%# Eval("ServiceType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Applciation No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelApplciation" runat="server" Text='<%# Eval("AppNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("UserID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <button type="button" class="btn btn-link p-0 m-0" onclick="ReleasePermit('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>','<%# Eval("UserID")%>')")>Upload Permit</button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



                <%--Follow Up Applications--%>
                <h6 class="m-2 font-weight-bold text-primary" id="_oHFollow_Up"><a id="_oLblFUTittle"> </a>Follow Up Applications</h6>
                <asp:GridView ID="_oGVFollowUp" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                    PageSize="5" OnPageIndexChanging="_oGVFollowUp_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTransDescription" runat="server" Text='<%# Eval("TransNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Applciation No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelApplciation" runat="server" Text='<%# Eval("AppNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("UserID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <%--<a href="#">View/Edit</a>   --%>
                                <%--<asp:Button ID="_obtnForBilling" runat="server" CommandArgument="<%# Eval("AppNo")%>" CommandName="sa" OnClick="SubAssessment_Click" Text="View/Edit" CssClass="btn btn-link" />                                    --%>                                
                                        <a href="#" data-toggle="modal" data-target="#InformationModal" onclick="information_data('Information','<%# Eval("AppNo")%>')">Information</a> 
                                

                                <a href="#" data-target="#ModalChecklist" data-toggle="modal" 
                                    onclick="follow_up('<%# Eval("AppNo")%>','<%# Eval("TransNo")%>','<%# Eval("Email")%>')">Response</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <%--List of cancelled application--%>
                <h6 class="m-2 font-weight-bold text-primary" id="_oHCancelledApp">List of cancelled application</h6>
                 <asp:GridView ID="_oGVCancelApp" runat="server" CssClass="mGrid Table-MobileView Table-Fullrowselect" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                            PageSize="5" OnPageIndexChanging="_oGVCancelApp_PageIndexChanging">
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
    </div>

        </ContentTemplate></asp:UpdatePanel>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
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
                                        <input type="text" class="form-control CH-Size-new" name="" id="_oTxtEmailInfo" placeholder="" runat="server" readonly />
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
                                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtPINNo" placeholder="" runat="server" />
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

                            <%--<div class="col-lg-12 row table-responsive">
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
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:FileUpload ID="_oFileUploadRequirements" runat="server" Multiple="Multiple" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary btn-sm pull-center" data-dismiss="modal" id="_obtnProceed" runat="server" onclick="__doPostBack('Update','')">Update</button>
                </div>
            </div>
        </div>
    </div>
        </ContentTemplate>
        </asp:UpdatePanel> 
    



    <div class="modal fade" id="ModalChecklist">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;"></a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white">Remarks</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" align="center" runat="server" id="div1">
                    <div class="col-lg-12 form-group mx-0 px-0">
                        <label class="input-txt input-txt-active2"><span><span class="m-2">Email</span></span></label>
                        <input type="text" class="form-control CH-Size-new" name="" id="_otxtEmail" placeholder="" runat="server" />
                    </div>
                    <asp:UpdatePanel runat="server" class="w-100 h-100">
                        <ContentTemplate>
                            <div class="col-lg-12 form-group mx-0 px-0">
                                <label class="input-txt input-txt-active2"><span><span class="m-2">Remarks</span></span></label>
                                <textarea id="_oTxtRemarks" runat="server" class="form-control" style="height:100px"></textarea>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-success" data-target="#Confirmation" data-toggle="modal" onclick="__doPostBack('', 'Follow-Up')">Send</button>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" runat="server" id="param1" />
    <input type="hidden" runat="server" id="param2" />
    <input type="hidden" runat="server" id="param3" />
    <input type="hidden" runat="server" id="hdnemail" />
    <input type="hidden" runat="server" id="hdntransno" />
    <input type="hidden" runat="server" id="hdnappno" />
    <input type="button" hidden runat="server" id="btnTest" />
    <input type="button" style="display:none;" runat="server" id="btnViewProcess" />
    <script>
        function assess(code, TransNo, UserID) {
            document.getElementById('<%= param1.ClientID%>').value = code;
            document.getElementById('<%= param2.ClientID%>').value = TransNo;
            document.getElementById('<%= param3.ClientID%>').value = UserID;
            //__doPostBack('', 'ForPayment')  '@REMARKED |20221010 | LOUIE
            __doPostBack('', 'ForPayment')
            
        }

        function ReleasePermit(code, TransNo, UserID) {
            document.getElementById('<%= param1.ClientID%>').value = code;
                    document.getElementById('<%= param2.ClientID%>').value = TransNo;
                    document.getElementById('<%= param3.ClientID%>').value = UserID;
                    __doPostBack('', 'EPermitRelease')

        }

        function ReleaseOR(code, TransNo, UserID) {
            document.getElementById('<%= param1.ClientID%>').value = code;
                    document.getElementById('<%= param2.ClientID%>').value = TransNo;
                    document.getElementById('<%= param3.ClientID%>').value = UserID;
                    __doPostBack('', 'ORRelease')

        }

        function follow_up(appno, transno, email) {
            document.getElementById('<%= hdnemail.ClientID%>').value = email;
            document.getElementById('<%= hdntransno.ClientID%>').value = transno;
            document.getElementById('<%= hdnappno.ClientID%>').value = appno;  
            document.getElementById('<%= _otxtEmail.ClientID%>').value = email;
            //__doPostBack('', 'Follow-Up')
        }
        function information_data(action, appno) {

            __doPostBack(appno, action)

        }
        function do_ViewProcess(AppNo, TransNO) {
            
            document.getElementById('<%= hdntransno.ClientID%>').value = TransNO;
            document.getElementById('<%= hdnappno.ClientID%>').value = AppNo;
            document.getElementById('<%= btnViewProcess.ClientID%>').click();

        }
    </script>   
</asp:Content>
