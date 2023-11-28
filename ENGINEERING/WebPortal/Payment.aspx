<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="Payment.aspx.vb" Inherits="OBO.Payment" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
        <div class="card col-lg-12 px-0">
            <div class="card-header ">
                <h5 class="m-2 font-weight-bold text-primary">Tax Order of Payment</h5>
            </div>
            <%--<div class="col-lg-2 form-group">
                <h6 class="font-weight-bold text-primary mt-2">Owner/Applicant: </h6>
            </div--%>
            <div class="col-lg-12 row m-2 mt-3">
                <div class="col-lg-3 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Transaction No.</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTransNo" placeholder="" runat="server" disabled />
                </div>
                <div class="col-lg-6 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Applicant/Owner Name</span></span></label>
                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtName" placeholder="" runat="server" disabled />
                </div>
                <div class="col-lg-9 form-group">
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Location of Construction</span></span></label>
                    <textarea class="form-control CH-Size-new" name="" id="_oTxtLocation" placeholder="" runat="server" disabled></textarea>
                </div>
            </div>
            <div class="card-body col-lg-12 row table-responsive mx-auto px-auto">
                <%--<h6 class="m-2 font-weight-bold text-primary">New Application (For Review)</h6>--%>
                <asp:GridView ID="_oGVTOP" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                    OnPageIndexChanging="_oGVTOP_PageIndexChanging">
                    <PagerSettings Mode="NumericFirstLast"
                        FirstPageText="First"
                        LastPageText="Last"
                        PageButtonCount="3"
                        Position="Bottom"
                        Visible="true" />
                    <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Code" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("TRANSTYPE")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDescription" runat="server" Text='<%# Eval("DESC1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelAmount" runat="server" Text='<%# Eval("TAXDUE")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Penalty" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelPenalty" runat="server" Text='<%# Eval("PENDUE")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Total" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTotal" runat="server" Text='<%# Eval("TOTDUE")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--<h6 class="m-2 font-weight-bold text-primary">Approved Application (For Payment)</h6>--%>
                <div class="col-lg-12 row m-3">
                    <div class="col-lg-3">
                    </div>
                    <div class="col-lg-3">
                    </div>
                    <div class="col-lg-3 align-content-end justify-content-end">
                        <label class="d-flex justify-content-end font-weight-bold">Total Amount</label>
                    </div>
                    <div class="col-lg-3">
                        <input type="text" class="form-control CH-Size-new " name="" id="_oTxtTotalAmount" placeholder="" runat="server" disabled style="text-align: right !Important; font-size: 16px !Important;" />
                    </div>
                    <%--₱--%>
                </div>
            </div>
        </div>
        <div class="col-lg-12 row">
            <div class=" col-lg-12 row mt-2 align-content-end justify-content-end">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <button name="_oBtnUploadRequirements" visible="false" runat="server" id="_oBtnUploadRequirements" type="button" class="btn btn-primary btn-icon-split m-2" style="" onserverclick="DownloadPDF_Click">
                            <span class="text">Download PDF</span>
                            <span class="icon text-white-50">
                                <i class="fas fa-save mt-1"></i>
                            </span>
                        </button>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <button name="_oBtnSubmit" runat="server" id="_oBtnSubmit" type="button" class="btn btn-success btn-icon-split m-2" style="" onserverclick="ProceedtoPayment_NEW_Click">
                    <span class="text">Proceed to Payment</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-cash-register mt-1"></i>
                    </span>
                </button>
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
