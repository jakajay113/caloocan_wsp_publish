<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUPermitMaster.Master" CodeBehind="ASSESSMENT_OBO.aspx.vb" Inherits="OBO.ASSESSMENT_OBO" %>

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
    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class=" col-lg-12 row">
                <div class="col-lg-1 form-group">
                    <h6 class="font-weight-bold text-primary mt-2">Assessment: </h6>
                </div>
                <%--<div class="col-lg-3 form-group">

                    <asp:DropDownList class="form-control CH-Size-new " ID="_oCbDivision" runat="server" AutoPostBack="true" OnSelectedIndexChanged="_oCbDivision_SelectedIndexChanged"></asp:DropDownList>--%>
                <%--<select class="form-control CH-Size-new " id="_oCbDivision" runat="server" onserverchange="_mSubLoadGridView">
                        <option>Sample</option>
                    </select>--%>
                <%--</div>--%>
            </div>
        </div>
    </div>

    <%--<div class="col-lg-12 row table-responsive">
        <%--<asp:GridView ID="_oGvAssessment" runat="server" CssClass="Grid" AutoGenerateColumns="false"
            EmptyDataText="No records has been added.">
            <Columns>
                <asp:textbox DataField="Name" HeaderText="Name" ItemStyle-Width="120" />
                <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="120" />
            </Columns>
        </asp:GridView>--%>
    <%--<div class="col-lg-12">
            <asp:GridView ID="_oGvAssessment" runat="server" CssClass="mGrid" AutoGenerateColumns="false"
                EmptyDataText="No records has been added." Width="50%" HeaderStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox DataField="Name" ID="_oTxtDescription" runat="server" CssClass="txt-alignment-right form-control" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox DataField="Country" ID="_oTxtAmount" runat="server" AutoPostBack="true" OnTextChanged="_oTxtAmount_TextChanged" CssClass="txt-alignment-right form-control" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
        </div>
    </div>--%>
    <div class="col-lg-12 row">
        <div class="col-lg-6 table-responsive">
            <asp:GridView ID="_oGvBldgPermit_OccUse" runat="server" CssClass="mGrid Table-MobileView Table-Cb" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <input type="checkbox" id="_oLblCheck" class="btn-cb" name="cb-control" onclick="Saveonsession(this.className.replace('btn-cb ',''));CheckSingleCheckbox(this, '<%# Eval("Desc1")%>    ')" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="_oLblCodeOccUse" runat="server" Text='<%# Eval("Desc1")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Label ID="_oLblDescOccUse" runat="server" Text='<%# Eval("Desc2")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Label ID="_oLblLinkOcc" runat="server" Text='<%# Eval("LinkOcc")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <input type="button" hidden runat="server" id="btnTest" />
            <br />
            <asp:DropDownList class="form-control CH-Size-new " ID="_oCbDivision" runat="server" AutoPostBack="true"></asp:DropDownList>
            <br />
            <asp:DropDownList class="form-control CH-Size-new " ID="_oCbOccuClass" runat="server" AutoPostBack="true"></asp:DropDownList>
            <br />
            <label class="input-txt input-txt-active2"><span><span class="m-2">Total Floor Area</span></span></label>
            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtFlrArea" placeholder="" runat="server" />
        </div>

        <div class="col-lg-6 table-responsive">
            <asp:GridView ID="_oGvAccessory" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:CheckBox ID="_oLblCheckAccessory" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="_oLblCodeAccessory" runat="server" Text='<%# Eval("Desc1")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Label ID="_oLblDescAccessory" runat="server" Text='<%# Eval("Desc2")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <%--<div class="col-lg-12 row mt-1">
        <div class="col-lg-3">Total Amount:</div>
        <div class="col-lg-3 p-0">

            <input type="text" runat="server" id="_oTbTotal" class="txt-alignment-right justify-content-end align-content-end d-flex form-control" />
        </div>
        <div class="col-lg-4"></div>
    </div>--%>
    <style>
        .txt-alignment-right {
            text-align: right !Important;
        }
    </style>



    <div class="col-lg-12 row">
        <div class=" col-lg-12 row">
            <div class="col-lg-2 form-group">
                <button name="_oBtnSaveAssessment" runat="server" id="_oBtnSaveAssessment" onclick="__doPostBack('SaveAssessment','')" type="button" class="btn btn-success btn-icon-split mt-2" style="max-width: 120px !Important;">
                    <span class="text">Save</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>
                </button>
            </div>
            <div class="col-lg-5 form-group">
                <button name="_oBtnApprovePayment" runat="server" id="_oBtnApprovePayment" onclick="__doPostBack('ApproveAssessment','')" type="button" class="btn btn-success btn-icon-split mt-2">
                    <span class="text">Approve for Assessment</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>
                </button>
            </div>
        </div>
    </div>



    <input type="hidden" runat="server" id="param1" />
    <input type="hidden" runat="server" id="param2" />


    <%--<asp:GridView ID="_oGvAssessment" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
            <Columns>
                <asp:TemplateField HeaderText="Transaction ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:TextBox ID="_oTxtTaxCode" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transaction ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:DropDownList ID="_oCbTaxCodeDesc" runat="server" DataTextField='<%# Eval("Description")%>' DataValueField ='<%# Eval("TaxCode")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transaction ID" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:TextBox ID="_oTxtAmount" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>



    <script type="text/javascript">
        function CheckSingleCheckbox(ob, code, linkocc) {
            var grid = ob.parentNode.parentNode.parentNode.parentNode;                      
            var inputs = grid.getElementsByTagName('input');
            for (var i = 0; i < inputs.length; i++) if (inputs[i].classList.contains(sessionStorage.getItem('CheckBox'))) inputs[i].checked = true; else inputs[i].checked = false;              
            document.getElementById('<%= param1.ClientID%>').value=code;
            document.getElementById('<%= param2.ClientID%>').value = linkocc;                  
        }
    </script>
    <script>

        function Saveonsession(no)
        {                       
            SetActiveCB(no);
        }
        function SetActiveCB(no)
        {            
            var table = document.getElementsByClassName('Table-Cb');
            for (var i = 0; i < table.length; i++) {                
                var newtable = document.getElementById(table[i].id);                
                var ALLCB = newtable.getElementsByTagName('input');                         
                for (var a = 0; a < ALLCB.length; a++) {                            
                    if (ALLCB[a].className) {                                                          
                        if (ALLCB[a].classList.contains(no)) {      
                            ALLCB[a].checked = true;
                            sessionStorage.setItem('CheckBox', no);                                                                                                               
                        }
                    }                                                        
                }
            }            
        }
        addLoadEvent(SetValue);        
        function SetValue() {
            var table = document.getElementsByClassName('Table-Cb');
            for (var i = 0; i < table.length; i++) {
                var newtable = document.getElementById(table[i].id);
                var ALLCB = newtable.getElementsByTagName('input');                
                for (var a = 0; a < ALLCB.length; a++) {
                    if (ALLCB[a].classList.contains("btn-cb")) {
                        ALLCB[a].classList.add(a);                        
                    }
                }                
            }        
            SetActiveCB(sessionStorage.getItem('CheckBox'));
        }                
    </script>
</asp:Content>
