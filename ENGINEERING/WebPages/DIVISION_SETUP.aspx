<%@ Page MaintainScrollPositionOnPostback="true" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPages/EIMS_MASTER.Master" CodeBehind="DIVISION_SETUP.aspx.vb" Inherits="EIMS_WEB.DIVISION_SETUP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <form id="frmNone"></form>
  
   
    <div class="col-lg-12 card px-0">   
        <div class="card-header col-lg-12">
            <h4 class="font-weight-bold text-primary ">Department Setup</h4>
        </div>
        <div class="card-body row"> 
            <label class="col-lg-1">Find</label>
            <div class=" col-lg-3  form-group ">                
                <div>                    
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Sort By:</span></span></label>
                    <select class="form-control CH-Size-new" >
                        <option>Sample</option>
                    </select>
                </div>
            </div>            
            <div class="col-lg-4 form-group ">
                <div>
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Search Key:</span></span></label>
                    <input  type="text" class="form-control CH-Size-new" name="" id="_oTextSearchKey" placeholder=""/>
                </div>
            </div>
            <div class="col-lg-3 form-group">
                <button name="_obtnPrint" runat="server" id="_obtnSearch" type="button" class="btn btn-primary btn-icon-split col-md-5" style="max-width: 100px !Important;">                           
                    <span class="text">Search</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-search mt-1"></i>
                    </span>
                </button>
            </div>

            <div class=" table-responsive col-lg-12">


                <asp:GridView ID="_oGvDivisionSetup" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                    <Columns>

                        <asp:TemplateField HeaderText="Code" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("Code")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acronym" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDesc1" runat="server" Text='<%# Eval("Desc1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDesc2" runat="server" Text='<%# Eval("Desc2")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>                        

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="">
                            <ItemTemplate>     
                                 <form id="frm1" method="post" onsubmit="do_delete('<%# Eval("Code")%>','<%# Eval("Desc1")%>','<%# Eval("Desc2")%>');">                                                                              
                                    <a href="#" onclick="do_something('<%# Eval("Code")%>','<%# Eval("Desc1")%>','<%# Eval("Desc2")%>')"  data-target="#myModal" data-toggle="modal">Edit</a>
                                    <a href="#" onclick="do_delete('<%# Eval("Code")%>','<%# Eval("Desc1")%>','<%# Eval("Desc2")%>')" data-target="#ModalConfirmation" data-toggle="modal">Delete</a>
                                     <a href="#" onclick="__doPostBack('asd','')" runat="server">Next</a>
                             <%--  <a href="#" onclick="do_delete('<%# Eval("Code")%>','<%# Eval("Desc1")%>','<%# Eval("Desc2")%>')" >Delete</a>--%>
                             </form>
                                   </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle></FooterStyle>
                

                </asp:GridView>

                <input type="hidden" id="hdnCode" runat="server"/>
                 <input type="hidden" id="hdnDesc1" runat="server"/>
                 <input type="hidden" id="hdnDesc2" runat="server"/>
                <input type="hidden" id="hdnAction" runat="server"/>
                <input type="hidden" id="hdnVal" runat="server"/>
                          </div>   
        </div>
        <div class="card-header col-lg-12">
            <button name="_obtnNew" runat="server" id="_obtnNew" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" onclick="New()"
                 style="max-width: 90px !Important;" data-target="#myModal" data-toggle="modal">  
                    <span class="text">New</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-plus mt-1"></i>
                    </span>
                </button>
            <%--<button name="_obtnEdit" runat="server" id="_obtnEdit" type="button" class="btn btn-warning btn-icon-split col-md-5 m-1"
                 style="max-width: 90px !Important;"> --%>  <%--data-target="#myModal" data-toggle="modal"--%>            
                    <%--<span class="text">Edit</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-edit mt-1"></i>
                    </span>
                </button>--%>
            <button name="_obtnDelete" runat="server" id="_obtnDelete" type="button" class="btn btn-danger btn-icon-split col-md-5 m-1"
                data-target="#ModalConfirmation" data-toggle="modal" style="max-width: 100px !Important;">                           
                    <span class="text">Delete</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-trash mt-1"></i>
                    </span>
            </button>
            <button name="_obtnPrev" runat="server" id="_obtnPrev" type="button" class="btn btn-secondary btn-icon-split col-md-5 m-1" style="max-width: 90px !Important;">                           
                    <span class="text">Prev</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-arrow-alt-circle-left mt-1"></i>
                    </span>
            </button>
            <label id="_oLblPrev" class="mr-1">Prev Label</label>
            <label id="_oLblNext" class="ml-1">Next Label</label>
            <button name="_obtnNext" runat="server" id="_obtnNext" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 90px !Important;">                           
                    <span class="text">Next</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-arrow-alt-circle-right mt-1"></i>
                    </span>
            </button>            
            <button name="_obtnSave" hidden="hidden" runat="server" id="_obtnSave" type="button" class="btn btn-success btn-icon-split col-md-5 m-1" style="max-width: 90px !Important;">                           
                    <span class="text">Save</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-save mt-1"></i>
                    </span>
            </button>
            <button name="_obtnCancel" runat="server" id="_obtnCancel" hidden="hidden" type="button" class="btn btn-danger btn-icon-split col-md-5 m-1" style="max-width: 90px !Important;" onclick="Cancel()">                           
                    <span class="text">Cancel</span>
                    <%--<span class="icon text-white-50">
                        <i class="fas  mt-1"></i>
                    </span>--%>
            </button>

            
        </div>     
                  
    </div> 
    
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header bg-primary">
                            <i class="fas fa-edit text-white float-right" style="font-size: 30px;"></i>
                            <h4 class="modal-title text-white" id="myModalLabel">Title of Action</h4>
                            <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>                        
                                  <div class="modal-body">
                                    <div class="card-body col-lg-12 row">
            <div class="col-md-12 form-group ">
                <div>
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Code</span></span></label>
                    <input  type="text" runat="server" class="form-control CH-Size-new" name="_oTextCode" id="_oTextCode"  />                                        
                </div>
            </div>
            <div class="col-md-12 form-group ">
                <div>
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Acronym</span></span></label>
                    <input  type="text" runat="server" class="form-control CH-Size-new" name="_oTextAcronym" id="_oTextAcronym"  />
                </div>
            </div>
            <div class="col-md-12 form-group ">
                <div>
                    <label class="input-txt input-txt-active2"><span><span class="m-2">Description</span></span></label>
                    <input type="text" runat="server" class="form-control CH-Size-new" name="_oTextDescription" id="_oTextDescription"  />
                </div>
            </div>            
        </div> 
                        </div>
                               
                                  <div class="modal-footer">
                            <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>
                      <button  class="btn btn-success btn-sm" id="_oBtnSaveChanges" runat="server" style="display:none" onclick="SaveChanges(document.getElementById('<%=hdnAction.ClientID%>').value, document.getElementById('<%=hdnVal.ClientID%>').value)">Save changes</button>
                       <input type="submit" class="btn btn-success btn-sm" value="Save changes"/>
                                       </div>
                       <input type="hidden" id="hdnSubmit" name="hdnSubmit" value="0"/>
                                 
                        
                        <%--                    <input type="file" runat="server" class="form-control CH-Size-New" style="display:none" id="_oFileSPA" onchange=" here('file2');" />
                        <input type="file" runat="server" class="form-control CH-Size-New" style="display:none" id="_oFileGovernmentID" onchange=" here('file1');"/>
                        <input type="file" runat="server" class="form-control CH-Size-New" style="display:none" id="_oFileBRSec" onchange=" here('file3');"/>--%>
                                        
                    </div>
                </div>
            </div>

    <div class="modal fade" id="ModalConfirmation" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-md">
                <div class="modal-content">

                    <div class="modal-header bg-primary">
                        <i class="text-white float-right" style="font-size: 30px;"></i>
                        <h4 class="modal-title text-white" id="myConModalLabel">Delete Confirmation</h4>
                        <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                    </div>  
                                          
                    <div class="modal-body">
                        <div class="row">
                                <h6>Are you sure you want to delete</h6>&nbsp<h6 id="_oTxtDescription" runat="server"></h6><h6>?</h6>                                                                                                                                                                                  
                        </div>
                    </div>
                               
                     <div class="modal-footer">                            
                        <button  class="btn btn-success btn-sm" id="_obtnYes" runat="server" onclick="__doPostBack(Action, Val)">   Yes   </button>
                        <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" id="_obtnNo">   No   </button>                                        
                    </div>

                </div>
            </div>
        </div>

    <script>
        function New() {
            document.getElementById('<%=_oTextCode.ClientID%>').disabled = true;
            document.getElementById('<%=_oTextAcronym.ClientID%>').disabled = false;
            document.getElementById('<%=_oTextDescription.ClientID%>').disabled = false;
            document.getElementById('<%=_oTextCode.ClientID%>').value = "";
            document.getElementById('<%=_oTextAcronym.ClientID%>').value = "";
            document.getElementById('<%=_oTextDescription.ClientID%>').value = "";
            document.getElementById('<%=hdnAction.ClientID%>').value = "SaveNew";
            document.getElementById('<%=hdnVal.ClientID%>').value = "";
            <%--document.getElementById('<%=_obtnNew.ClientID%>').disabled = true
            document.getElementById('<%=_obtnDelete.ClientID%>').disabled = true
            document.getElementById('<%=_obtnPrev.ClientID%>').disabled = true
            document.getElementById('<%=_obtnNext.ClientID%>').disabled = true
            document.getElementById('<%=_obtnSave.ClientID%>').disabled = false
            document.getElementById('<%=_obtnCancel.ClientID%>').disabled = false
            document.getElementById('<%=_oTextCode.ClientID%>').disabled = false
            document.getElementById('<%=_oTextAcronym.ClientID%>').disabled = false
            document.getElementById('<%=_oTextDescription.ClientID%>').disabled = false--%>
        }

        function do_something(Code, Desc1, Desc2) {
            document.getElementById('<%=hdnCode.ClientID%>').value = Code;
            document.getElementById('<%=hdnDesc1.ClientID%>').value = Desc1;
            document.getElementById('<%=hdnDesc2.ClientID%>').value = Desc2;
            document.getElementById('<%=_oTextCode.ClientID%>').disabled = true;
            document.getElementById('<%=_oTextAcronym.ClientID%>').disabled = false;
            document.getElementById('<%=_oTextDescription.ClientID%>').disabled = false;
            document.getElementById('<%=_oTextCode.ClientID%>').value = Code;
            document.getElementById('<%=_oTextAcronym.ClientID%>').value = Desc1;
            document.getElementById('<%=_oTextDescription.ClientID%>').value = Desc2;
            document.getElementById('<%=hdnAction.ClientID%>').value = "SaveEdit";
            document.getElementById('<%=hdnVal.ClientID%>').value = Code;
            <%--document.getElementById('<%=_obtnCancel.ClientID%>').disabled = false
            document.getElementById('<%=_obtnNew.ClientID%>').disabled = true
            document.getElementById('<%=_obtnPrev.ClientID%>').disabled = true
            document.getElementById('<%=_obtnNext.ClientID%>').disabled = true
            document.getElementById('<%=_obtnSave.ClientID%>').disabled = false            
            document.getElementById('<%=_oTextCode.ClientID%>').disabled = false
            document.getElementById('<%=_oTextAcronym.ClientID%>').disabled = false
            document.getElementById('<%=_oTextDescription.ClientID%>').disabled = false--%>
        }

        function do_delete(Code, Desc1, Desc2) {
            document.getElementById('<%=hdnCode.ClientID%>').value = Code;
            document.getElementById('<%=hdnDesc1.ClientID%>').value = Desc1;
            document.getElementById('<%=hdnDesc2.ClientID%>').value = Desc2;
            document.getElementById('<%=_oTxtDescription.ClientID%>').innerText = Desc2;
            document.getElementById('<%=hdnAction.ClientID%>').value = "Delete";
            document.getElementById('<%=hdnVal.ClientID%>').value = Code;
        }

        function Edit() {
            __doPostBack('Edit', '');
        }

        function Cancel() {
            document.getElementById('<%=_obtnNew.ClientID%>').disabled = true

            document.getElementById('<%=_obtnDelete.ClientID%>').disabled = true
            document.getElementById('<%=_obtnPrev.ClientID%>').disabled = true
            document.getElementById('<%=_obtnNext.ClientID%>').disabled = true
            document.getElementById('<%=_obtnSave.ClientID%>').disabled = false
            document.getElementById('<%=_obtnCancel.ClientID%>').disabled = false
            document.getElementById('<%=_oTextCode.ClientID%>').disabled = false
            document.getElementById('<%=_oTextAcronym.ClientID%>').disabled = false
            document.getElementById('<%=_oTextDescription.ClientID%>').disabled = false
        }

        function SaveChanges(Action, Val) {

        }
    </script>

</asp:Content>
