<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Billing_OBO.aspx.vb" Inherits="OBO.Billing_OBO" MasterPageFile="~/WebPortal/LGUPermitMaster.Master" %>

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

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class=" col-lg-12">

                <div class="card col-lg-12 px-0">
                    <div class="card-body col-lg-12 row table-responsive mt-0 mx-auto px-auto">
                        <h6 class="m-2 font-weight-bold text-primary" ><a id="_oLblFUTittle"> Upload and Notify Billing </a></h6>

                        <br />
                          <div class="row">
                              <div class="col-lg-4  form-group">

                                <div class="col-lg-12 form-group">
                                    <label class="input-txt input-txt-active2"><span><span class="m-2">Application No.</span></span></label>
                                    <input type="text" class="form-control CH-Size-new" name="" style="font-size:xx-large" id="_oTxtAppNo" placeholder="" runat="server" disabled />
                                </div>

                                <div class="col-lg-12 form-group">
                                    <label class="input-txt input-txt-active2"><span><span class="m-2">Assessment No.</span></span></label>
                                    <input type="text" class="form-control CH-Size-new" name=""  style="font-size:xx-large" id="_oTxtAssessmentNo"  placeholder="" runat="server" disabled />
                                </div>

                                <div class="col-lg-12 form-group">
                                    <label class="input-txt input-txt-active2"><span><span class="m-2">Total Amount Due</span></span></label>
                                    <input type="text" class="form-control CH-Size-new" name=""  style="font-size:xx-large" id="_oTxtTotalDue" placeholder="" runat="server" disabled />
                                </div>

                                <br />

                                <div class="col-lg-12 form-group">
                                    <label class="input-txt input-txt-active2"><span><span class="m-2">Transaction No.</span></span></label>
                                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtTransNo" placeholder="" runat="server" disabled />
                                </div>

                                <div class="col-lg-12 form-group">
                                    <label class="input-txt input-txt-active2"><span><span class="m-2">Applicant/Owner Name</span></span></label>
                                    <input type="text" class="form-control CH-Size-new" name="" id="_oTxtFullName" placeholder="" runat="server" disabled />
                                </div>

                                <div class="col-lg-12 form-group">
                                    <label class="input-txt input-txt-active2"><span><span class="m-2">Permit Type</span></span></label>
                                    <input class="form-control CH-Size-new" name="" id="_oTxtPermitType" placeholder="" runat="server" disabled ></input>
                                </div>

                                <div class="col-lg-12 form-group">
                                    <label class="input-txt input-txt-active2"><span><span class="m-2">Email Address</span></span></label>
                                    <input class="form-control CH-Size-new" name="" id="_oTxtEmailAddress" placeholder="" runat="server" disabled></input>
                                </div>

                            
                                <div class="col-lg-12 form-group">
                                    <input id="uploadPDF" type="file" name="myPDF"   onchange="PreviewImage()" />&nbsp;
                                </div>

                                <div class="col-lg-12 form-group">
                                    <asp:Button ID="Button1" Text="Upload" Visible="false" CssClass="m-2 btn btn-success btn-icon-split" runat="server" OnClick="Upload" /> 
                                      
                                    <button name="_oBtnSaveApplication" id="_obtnApprove" type="button" onclick="ConfirmUploadNotify();" class="m-2 btn btn-primary btn-icon-split"    >
                                        <span class="text">Upload and Notify</span>
                                        <span class="icon text-white-50">
                                            <i class="fas fa-upload mt-1"></i>
                                        </span>
                                    </button>
                                </div>

                            </div>

                            <div class="col-lg-8  form-group">
                                <center>
                                    <div style="clear:both">
                                    <iframe id="viewer" frameborder="0" style="height:100vh;min-width:100%"></iframe>
                                   </div>
                                </center>
        
                            </div>

                           <%--   POPUP CONFIRMATION MODAL--%>
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
                                                      <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                                                      <asp:Button runat="server" ID="_oBtnConfirmUpload" class="btn btn-success" Text="Yes" OnClientClick="DisplayLoadingFromMaster();"  OnClick="Upload" />
                                                  </ContentTemplate>
                                              </asp:UpdatePanel>
                                          </div>
                                      </div>
                                  </div>
                              </div>

                        </div>


                        <asp:GridView ID="_oGvBilling"  Visible="false"  runat="server" CssClass="mGrid Table-MobileView" 
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"
                            PageSize="5" >
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
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Transaction No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransNo" runat="server" Text='<%# Eval("TransNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Applciation No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelAppNo" runat="server" Text='<%# Eval("AppNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name of Applicant" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelFullName" runat="server" Text='<%# Eval("FirstName") + " " + Eval("MiddleName") + " " + Eval("LastName")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("UserID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Permit type" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelPermitType" runat="server" Text='<%# Eval("PermitType")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Permit type" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:FileUpload ID="_oFileUploadBiling" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Permit type" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <a> View </a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Permit type" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <a> Send Notification </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

        
       
           <br />
        

</div>

<c1-pdf-viewer width="100%" id="pdfViewer"></c1-pdf-viewer>
        </ContentTemplate>
        <Triggers>
           
            <asp:PostBackTrigger ControlID="_oBtnConfirmUpload" />
                <asp:PostBackTrigger ControlID="Button1" />
         <%--   <asp:AsyncPostBackTrigger  ControlID="Button1"/>--%>
        </Triggers>
    </asp:UpdatePanel>

        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
        <script type="text/javascript">
            function PreviewImage() {
                pdffile = document.getElementById("uploadPDF").files[0];
                pdffile_url = URL.createObjectURL(pdffile);
                $('#viewer').attr('src', pdffile_url);
            }
        </script>

       <script type="text/javascript">
           function ConfirmUploadNotify() {
               if (confirm('Confirm upload and notify Billing?')) {
                   document.getElementById("<%=_oBtnConfirmUpload.ClientID%>").click();
                };
           }

       </script>
</asp:Content>
