<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="Account.aspx.vb" Inherits="OBO.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <textarea id="txarea" name="txarea" style="visibility: hidden; display: none;"></textarea><br>
    <textarea id="txareaall" name="txareaall" style="visibility: hidden; display: none;"></textarea><br>
    <input id="ifchckall" type="hidden" runat="server" />
    <input type="hidden" id="hdnMerchantCode" />
    <script>
        var MD5 = function (d) { var r = M(V(Y(X(d), 8 * d.length))); return r.toLowerCase() }; function M(d) { for (var _, m = "0123456789ABCDEF", f = "", r = 0; r < d.length; r++) _ = d.charCodeAt(r), f += m.charAt(_ >>> 4 & 15) + m.charAt(15 & _); return f } function X(d) { for (var _ = Array(d.length >> 2), m = 0; m < _.length; m++) _[m] = 0; for (m = 0; m < 8 * d.length; m += 8) _[m >> 5] |= (255 & d.charCodeAt(m / 8)) << m % 32; return _ } function V(d) { for (var _ = "", m = 0; m < 32 * d.length; m += 8) _ += String.fromCharCode(d[m >> 5] >>> m % 32 & 255); return _ } function Y(d, _) { d[_ >> 5] |= 128 << _ % 32, d[14 + (_ + 64 >>> 9 << 4)] = _; for (var m = 1732584193, f = -271733879, r = -1732584194, i = 271733878, n = 0; n < d.length; n += 16) { var h = m, t = f, g = r, e = i; f = md5_ii(f = md5_ii(f = md5_ii(f = md5_ii(f = md5_hh(f = md5_hh(f = md5_hh(f = md5_hh(f = md5_gg(f = md5_gg(f = md5_gg(f = md5_gg(f = md5_ff(f = md5_ff(f = md5_ff(f = md5_ff(f, r = md5_ff(r, i = md5_ff(i, m = md5_ff(m, f, r, i, d[n + 0], 7, -680876936), f, r, d[n + 1], 12, -389564586), m, f, d[n + 2], 17, 606105819), i, m, d[n + 3], 22, -1044525330), r = md5_ff(r, i = md5_ff(i, m = md5_ff(m, f, r, i, d[n + 4], 7, -176418897), f, r, d[n + 5], 12, 1200080426), m, f, d[n + 6], 17, -1473231341), i, m, d[n + 7], 22, -45705983), r = md5_ff(r, i = md5_ff(i, m = md5_ff(m, f, r, i, d[n + 8], 7, 1770035416), f, r, d[n + 9], 12, -1958414417), m, f, d[n + 10], 17, -42063), i, m, d[n + 11], 22, -1990404162), r = md5_ff(r, i = md5_ff(i, m = md5_ff(m, f, r, i, d[n + 12], 7, 1804603682), f, r, d[n + 13], 12, -40341101), m, f, d[n + 14], 17, -1502002290), i, m, d[n + 15], 22, 1236535329), r = md5_gg(r, i = md5_gg(i, m = md5_gg(m, f, r, i, d[n + 1], 5, -165796510), f, r, d[n + 6], 9, -1069501632), m, f, d[n + 11], 14, 643717713), i, m, d[n + 0], 20, -373897302), r = md5_gg(r, i = md5_gg(i, m = md5_gg(m, f, r, i, d[n + 5], 5, -701558691), f, r, d[n + 10], 9, 38016083), m, f, d[n + 15], 14, -660478335), i, m, d[n + 4], 20, -405537848), r = md5_gg(r, i = md5_gg(i, m = md5_gg(m, f, r, i, d[n + 9], 5, 568446438), f, r, d[n + 14], 9, -1019803690), m, f, d[n + 3], 14, -187363961), i, m, d[n + 8], 20, 1163531501), r = md5_gg(r, i = md5_gg(i, m = md5_gg(m, f, r, i, d[n + 13], 5, -1444681467), f, r, d[n + 2], 9, -51403784), m, f, d[n + 7], 14, 1735328473), i, m, d[n + 12], 20, -1926607734), r = md5_hh(r, i = md5_hh(i, m = md5_hh(m, f, r, i, d[n + 5], 4, -378558), f, r, d[n + 8], 11, -2022574463), m, f, d[n + 11], 16, 1839030562), i, m, d[n + 14], 23, -35309556), r = md5_hh(r, i = md5_hh(i, m = md5_hh(m, f, r, i, d[n + 1], 4, -1530992060), f, r, d[n + 4], 11, 1272893353), m, f, d[n + 7], 16, -155497632), i, m, d[n + 10], 23, -1094730640), r = md5_hh(r, i = md5_hh(i, m = md5_hh(m, f, r, i, d[n + 13], 4, 681279174), f, r, d[n + 0], 11, -358537222), m, f, d[n + 3], 16, -722521979), i, m, d[n + 6], 23, 76029189), r = md5_hh(r, i = md5_hh(i, m = md5_hh(m, f, r, i, d[n + 9], 4, -640364487), f, r, d[n + 12], 11, -421815835), m, f, d[n + 15], 16, 530742520), i, m, d[n + 2], 23, -995338651), r = md5_ii(r, i = md5_ii(i, m = md5_ii(m, f, r, i, d[n + 0], 6, -198630844), f, r, d[n + 7], 10, 1126891415), m, f, d[n + 14], 15, -1416354905), i, m, d[n + 5], 21, -57434055), r = md5_ii(r, i = md5_ii(i, m = md5_ii(m, f, r, i, d[n + 12], 6, 1700485571), f, r, d[n + 3], 10, -1894986606), m, f, d[n + 10], 15, -1051523), i, m, d[n + 1], 21, -2054922799), r = md5_ii(r, i = md5_ii(i, m = md5_ii(m, f, r, i, d[n + 8], 6, 1873313359), f, r, d[n + 15], 10, -30611744), m, f, d[n + 6], 15, -1560198380), i, m, d[n + 13], 21, 1309151649), r = md5_ii(r, i = md5_ii(i, m = md5_ii(m, f, r, i, d[n + 4], 6, -145523070), f, r, d[n + 11], 10, -1120210379), m, f, d[n + 2], 15, 718787259), i, m, d[n + 9], 21, -343485551), m = safe_add(m, h), f = safe_add(f, t), r = safe_add(r, g), i = safe_add(i, e) } return Array(m, f, r, i) } function md5_cmn(d, _, m, f, r, i) { return safe_add(bit_rol(safe_add(safe_add(_, d), safe_add(f, i)), r), m) } function md5_ff(d, _, m, f, r, i, n) { return md5_cmn(_ & m | ~_ & f, d, _, r, i, n) } function md5_gg(d, _, m, f, r, i, n) { return md5_cmn(_ & f | m & ~f, d, _, r, i, n) } function md5_hh(d, _, m, f, r, i, n) { return md5_cmn(_ ^ m ^ f, d, _, r, i, n) } function md5_ii(d, _, m, f, r, i, n) { return md5_cmn(m ^ (_ | ~f), d, _, r, i, n) } function safe_add(d, _) { var m = (65535 & d) + (65535 & _); return (d >> 16) + (_ >> 16) + (m >> 16) << 16 | 65535 & m } function bit_rol(d, _) { return d << _ | d >>> 32 - _ }
    </script>
    <script>

     
     

        function MULTITDN(TDN, ifchk) {
          //  alert("w");
            if (document.getElementById('<%= ifchckall.ClientID%>').value == "1" || document.getElementById('<%= ifchckall.ClientID%>').value == "3") {
                document.getElementById('<%= ifchckall.ClientID%>').value = "3"
            }
            else {
          
                document.getElementById('<%= ifchckall.ClientID%>').value = "4";
              
            }


            document.getElementById("chkSelect").checked = false;
            document.getElementById("txarea").value = document.getElementById("txarea").value + ifchk + ":" + TDN + ";";
         //   alert(document.getElementById("txarea").value);
            //document.getElementById("txarea").value = id;
            //alert(gross + " - " + uniqueID);


        }
        function chkindicator(chk) {
            if (chk == true) {
                document.getElementById("txarea").value = ""
                document.getElementById('<%= ifchckall.ClientID%>').value = "1";
                    }
                    if (chk == false) {
                        document.getElementById("txarea").value = ""
                        document.getElementById('<%= ifchckall.ClientID%>').value = "2";
                    }


                }
    </script>

    <script>
        function SELECTALLTDN(IFCHK) {
            //alert(IFCHK)
            //alert(document.getElementByName("_oCBSelectProperty").checked)

            //document.getElementById("_oCBSelectProperty").checked = IFCHK


            var ele = document.getElementsByName("_oCBSelectProperty");
            //alert(IFCHK)
            for (var i = 0; i < ele.length; i++) {
                ele[i].checked = IFCHK
            }

        }

    </script>
    <script>

        //SNACKBAR - Welcome       
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };



    </script>

   
    <form id="frmNone"></form>
    <%--<asp:ScriptManager></asp:ScriptManager>--%>

    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>

    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Account Information</h5>
    </div>
    <div class="row justify-content-center align-items-center mb-0 m-1">
        <div class=" col-lg-12" style="padding-left: 0; padding-right: 0;">
            <div class="row m-2" style="background-color: white">

                <div class="col-md-6 row " runat="server" id="div_BP_enroll">
                    <div class="col-lg-12 m-2 mb-3">
                        <h6 class="m-0 font-weight-bold text-primary">Enroll Business:<span class="text-xs" style="color: red; display: none;" id="invalid">Please complete fields before proceeding</span></h6>

                    </div>
                    <div class="form-group col">
                        <div>

                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Enter Bin </span></span>

                            </label>
                            <input id="_otxtEnterBusinessBIN" required type="text" class="form-control CH-Size-New" runat="server" />
                            <%--<asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="_otxtEnterBusinessBIN" errormessage="Please enter your name!" />--%>
                        </div>
                    </div>

                    <div class="form-group col">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Enter OR No.</span></span>
                            </label>
                            <input id="_otxtEnterBusinessORNo" required type="text" class="form-control CH-Size-New" runat="server" />
                        </div>

                    </div>
                    <div class="form-group col-md-5">
                        <button name="btnEnroll" id="btnEnroll" type="button" class="btn btn-primary btn-sm col right" runat="server" onclick="BusinessEnrollment('BusinessEnroll','');">Enroll</button>

                    </div>

                    <i style="font-size: small; color: cornflowerblue;">* Registered Business wanting to apply for renewal or pay their quarterly dues, enroll your business account number(BIN) and latest Official Receipt Number(O.R) for verification
                    </i>

                </div>



                <div class="col-md-6 row " runat="server" id="div_RPT_enroll">
                    <div class="col-lg-12 m-2 mb-3">
                        <h6 class="m-0 font-weight-bold text-primary">Enroll Property:<span class="text-xs" style="color: red; display: none;" id="invalid1">Please complete fields before proceeding</span></h6>
                    </div>
                    <div class="form-group col">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Enter TDN </span></span>
                            </label>
                            <input id="_otxtEnterPropTDN" type="text" class="form-control CH-Size-New" required autocomplete="off" runat="server">
                        </div>
                    </div>
                    <div class="form-group col">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Enter OR No.</span></span>
                            </label>
                            <input id="_otxtEnterPropORNo" type="text" class="form-control CH-Size-New" required autocomplete="off" runat="server">
                        </div>
                    </div>
                    <div class="form-group col-md-5">
                        <button name="btnEnrollProp" id="btnEnrollProp" type="button" class="btn btn-primary btn-sm col right" runat="server" onclick="PropertyEnrollment('PropertyEnroll','');">Enroll</button>
                    </div>

                    <i style="font-size: small; color: cornflowerblue">* Registered / Declared Property(ies) wanting to pay annual & quarterly dues, enroll your Tax Declaration number(TDN) and latest Official Receipt Number(O.R) for verification</i>
                </div>


            </div>
            <div class="card shadow m-2">
                <%-- Business Permit --%>
                <div class="mb-2" runat="server" id="div_BP_Renewal">
                    <script>
                        function GridCollapse(val) {
                            if (document.getElementById(val).classList.contains("fa-minus-circle")) {
                                document.getElementById(val).classList.remove("fa-minus-circle");
                                document.getElementById(val).classList.add("fa-plus-circle");
                            }
                            else {
                                document.getElementById(val).classList.remove("fa-plus-circle");
                                document.getElementById(val).classList.add("fa-minus-circle");
                            }
                        }
                    </script>
                    <a class="nav-link font-weight-bold text-primary" data-toggle="collapse" href="#_oPNGrid1" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('_oGIco1')">Business Permit Account (for Renewal)<i class="fas fa-minus-circle fa-fw" id="_oGIco1"></i>
                    </a>
                    <!-- Dropdown - Messages -->
                    <div class="collapse show" id="_oPNGrid1">
                        <asp:GridView ID="GridView1" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_BP"
                        PageSize="5">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />

                            <%--<FooterStyle CssClass="GridViewFooterStyle" />
                     <RowStyle CssClass="GridViewRowStyle"  />
                     <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                     <PagerStyle CssClass="GridViewPagerStyle" />
                     <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                     <HeaderStyle CssClass="GridViewHeaderStyle" />--%>

                            <Columns>

                                <asp:TemplateField HeaderText="Business ID" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusIDNumber" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Bus. Owner/Manager" HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# Eval("OWNER")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Business Name" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Eval("BUSNAME")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Business Address" HeaderStyle-Width="17%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# Eval("BUSADDRESS")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Category" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusCategory" runat="server" Text='<%# Eval("CATEGORY")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="18%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>

                                        <a href="#" onclick="Select('Information','<%# Eval("ACCTNO")%>')" title="Information">Information</a>
                                        &nbsp
                                        <a href="#" style="display: none;" onclick="Select('Other Trans','<%# Eval("ACCTNO")%>')" title="Other Trans">Other Transaction </a>
                                        <%--<a href="#"  onclick="window.location.replace('AccountOtherTransaction.aspx')" title="Other Trans">Other Trans </a>--%>
                                    &nbsp
                                        <a href="#" data-toggle="modal" data-target="#loading" data-ticket-type="standard-access" onclick="Select('Renew','<%# Eval("ACCTNO")%>')" title="Renew">Renew </a>
                                    </ItemTemplate>
                                </asp:TemplateField>





                            </Columns>

                        </asp:GridView>


                        <script>
                            function Select(Action, Val) {
                                __doPostBack(Action, Val);
                            }



                            function BusinessEnrollment(Action, Val) {

                                var bin = document.getElementById('<%= _otxtEnterBusinessBIN.ClientID%>');
                                var orno = document.getElementById('<%= _otxtEnterBusinessORNo.ClientID%>');
                                var inv = document.getElementById('invalid');
                                if (bin.value !== "" && orno.value !== "") {

                                    __doPostBack(Action, Val);
                                } else {

                                    inv.style.display = 'block';
                                    bin.style.borderColor = 'red';
                                    orno.style.borderColor = 'red';


                                }

                            }

                            function PropertyEnrollment(Action, Val) {

                                var tdn = document.getElementById('<%= _otxtEnterPropTDN.ClientID%>');
                                var orno = document.getElementById('<%= _otxtEnterPropORNo.ClientID%>');
                                var inv = document.getElementById('invalid1');

                                if (tdn.value !== "" && orno.value !== "") {
                                    __doPostBack(Action, Val);
                                } else {
                                    inv.style.display = 'block';
                                    tdn.style.borderColor = 'red';
                                    orno.style.borderColor = 'red';
                                }
                            }




                        </script>


                    </div>
                </div>


                <div class="mb-2" runat="server" id="div_BP_Payment">

                    <a class="nav-link font-weight-bold text-primary" data-toggle="collapse" href="#_oPNGrid2" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('_oGIco2')">Business Permit Account (for Payment)<i class="fas fa-minus-circle fa-fw" id="_oGIco2"></i>
                    </a>
                    <!-- Dropdown - Messages -->
                    <div class="collapse show" id="_oPNGrid2">
                        <asp:GridView ID="_oGVBusinessPayment" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_BPP"
                        PageSize="5">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />


                            <Columns>

                                <asp:TemplateField HeaderText="Business ID" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusIDNumber" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Bus. Owner/Manager" HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# Eval("OWNER")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Business Name" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Eval("BUSNAME")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Business Address" HeaderStyle-Width="17%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# Eval("BUSADDRESS")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Category" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusCategory" runat="server" Text='<%# Eval("CATEGORY")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelStatus" runat="server" Text='<%# Eval("STATUS")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="18%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a href="#" onclick="Select('Information','<%# Eval("ACCTNO")%>')" title="Information">Information</a>
                                        &nbsp
                                        <a href="#" style="display: none;" onclick="Select('Other Trans','<%# Eval("ACCTNO")%>')" title="Other Trans">Other Transaction </a>
                                        &nbsp
                                        <a href="#" onclick="Select('Payment','<%# Eval("ACCTNO")%>' + ':' + '<%# Eval("STATUS")%>')" title="Payment">Payment</a>
                                    </ItemTemplate>
                                </asp:TemplateField>





                            </Columns>

                        </asp:GridView>


                        <script>
                            function Select(Action, Val) {
                                __doPostBack(Action, Val);
                            }

                            function BusinessEnrollment(Action, Val) {
                                var bin = document.getElementById('<%= _otxtEnterBusinessBIN.ClientID%>');
                                var orno = document.getElementById('<%= _otxtEnterBusinessORNo.ClientID%>');
                                var inv = document.getElementById('invalid');

                                if (bin.value !== "" && orno.value !== "") {
                                    __doPostBack(Action, Val);
                                } else {
                                    inv.style.display = 'block';
                                    bin.style.borderColor = 'red';
                                    orno.style.borderColor = 'red';
                                }
                            }

                            function PropertyEnrollment(Action, Val) {
                                var tdn = document.getElementById('<%= _otxtEnterPropTDN.ClientID%>');
                                var orno = document.getElementById('<%= _otxtEnterPropORNo.ClientID%>');
                                var inv = document.getElementById('invalid1');

                                if (tdn.value !== "" && orno.value !== "") {
                                    __doPostBack(Action, Val);
                                } else {
                                    inv.style.display = 'block';
                                    tdn.style.borderColor = 'red';
                                    orno.style.borderColor = 'red';
                                }
                            }
                        </script>

                    </div>
                </div>

                <%-- Real Property --%>
                <div class="mb-2" runat="server" id="div_RPT">

                    <a class="nav-link font-weight-bold text-primary" data-toggle="collapse" href="#_oPNGrid3" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('_oGIco3')">Real Property Account<i class="fas fa-minus-circle fa-fw" id="_oGIco3"></i>
                    </a>
                    <!-- Dropdown - Messages -->
                    <div class="collapse show" id="_oPNGrid3">
                        <asp:GridView ID="GridView2" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_RPTAcc"
                        PageSize="5">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />




                            <Columns>

                                <asp:TemplateField HeaderText="Tax. Dec. No" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelPropTaxDecNo" runat="server" Text='<%# Eval("TDN")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PIN" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelPropPIN" runat="server" Text='<%# Eval("PIN")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Kind" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelPropKind" runat="server" Text='<%# Eval("KIND")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Declared Owner" HeaderStyle-Width="12%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelPropDeclaredOwner" runat="server" Text='<%# Eval("OWNERNAME")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Property Location" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelPropLocation" runat="server" Text='<%# Eval("LOCATION")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a href="#" onclick="Select('RPTINFORMATION','<%# Eval("TDN")%>')" title="Select">Information</a>
                                        &nbsp                                                                            
                        <a href="#" style="display: none" onclick="RPTOtherTransaction('<%# Eval("TDN")%>','<%# Eval("PIN")%>','<%# Eval("KIND")%>','<%# Eval("OWNERNAME")%>','<%# Eval("LOCATION")%>')" title="Other Trans">Other Transaction </a>
                                        &nbsp 
                              <a href="#" data-toggle="modal" data-target="#loading" data-ticket-type="standard-access" onclick="Select('RPTBILLING','<%# Eval("TDN")%>')">Payment</a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>
                        <input type="hidden" runat="server" id="hdntdn" />
                        <input type="hidden" runat="server" id="hdnpin" />
                        <input type="hidden" runat="server" id="hdnkind" />
                        <input type="hidden" runat="server" id="hdnownername" />
                        <input type="hidden" runat="server" id="hdnlocation" />

                        <script>
                            function RPTOtherTransaction(tdn, pin, kind, ownername, location) {
                                document.getElementById('<%=hdntdn.ClientID%>').value = tdn;
                                document.getElementById('<%=hdnpin.ClientID%>').value = pin;
                                document.getElementById('<%=hdnkind.ClientID%>').value = kind;
                                document.getElementById('<%=hdnownername.ClientID%>').value = ownername;
                                document.getElementById('<%=hdnlocation.ClientID%>').value = location;
                                __doPostBack('RPTOtherTransaction', 'aa');
                            }


                        </script>

                        <br>
                        <div class="col-md-12 d-flex justify-content-end align-content-end">
                            <button id="_obtnMTDN" class="btn btn-primary" type="button" data-toggle="modal" data-dismiss="modal" data-target="#SelectPropertyModal" data-ticket-type="standard-access">Select Multiple Property</button>
                        </div>

                    </div>

                </div>
                <div class="modal fade" id="SelectPropertyModal">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header bg-primary">
                                <a class="text-white float-right" style="font-size: 20px;">Select Multiple Property</a>
                                &nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                                <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body" align="center">
                                <div class="collapse show">
                                    <asp:GridView ID="_oGVSelectProperty" runat="server" CssClass="mGrid " AllowSorting="true"
                                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">

                                        <Columns>

                                            <asp:TemplateField HeaderText="Tax. Dec. No" ItemStyle-CssClass="" HeaderStyle-CssClass="" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLabelPropTaxDecNo" runat="server" Text='<%# Eval("TDN")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Property Location" ItemStyle-CssClass="" HeaderStyle-CssClass="" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLabelPropLocation" runat="server" Text='<%# Eval("LOCATION")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="" HeaderStyle-CssClass="" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <div class="col-lg-12 ml-2">
                                                        <div class="row">
                                                            <input type="checkbox" class="m-1" value='<%# Eval("TDN")%>' id="_oCBSelectProperty" name="_oCBSelectProperty" onchange="MULTITDN(this.checked,this.value);" />
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                    </asp:GridView>

                                    <div class="form-group mt-2 col-lg-12 d-flex justify-content-end align-content-end">
                                        <input type="checkbox" id="chkSelect" name="chkSelect" class="m-1" onchange="SELECTALLTDN(this.checked);chkindicator(this.checked)" />
                                        &nbsp  Select All
                        
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary btn-sm pull-center" data-dismiss="modal" id="_obtnProceed" runat="server">Proceed</button>
                            </div>
                        </div>
                    </div>
                </div>

                <%-- Transactions --%>
                <div class="mb-2">

                    <a class="nav-link font-weight-bold text-primary" data-toggle="collapse" href="#_oPNGrid4" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('_oGIco4')">Transactions<i class="fas fa-minus-circle fa-fw" id="_oGIco4"></i>
                    </a>

                    <!-- Dropdown - Messages -->
                    <div class="collapse show" id="_oPNGrid4">
                        <i style="font-size: small; color: cornflowerblue">Note: Here you will see your every account detailed transaction history</i>

                        <asp:GridView ID="_oGVTransaction" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_RPTTran"
                        PageSize="5">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />



                            <Columns>

                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransDate" runat="server" Text='<%# Eval("Date", "{0:MMM dd, yyyy HH:mm:ss}")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ID" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransNo" runat="server" Text='<%# Eval("ID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Service" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelACCTNO" runat="server" Text='<%# Eval("Module")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Type" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransType" runat="server" Text='<%# Eval("Type")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Description" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransDescription" runat="server" Text='<%# Eval("Description")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransStat" runat="server" Text='<%# Eval("Status")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Particulars" Visible="false" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelParticulars" runat="server" Text='<%# Eval("Particulars")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10.8%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a href="#" data-toggle="modal" onclick="show_details(
                                            '<%# Eval("[ID]")%>',
                                            '<%# Eval("[Email]")%>',
                                            '<%# Eval("[Module]")%>',
                                            '<%# Eval("[Type]")%>',
                                            '<%# Eval("[Description]")%>',
                                            '<%# Eval("[Particulars]")%>',
                                            '<%# Eval("[Date]")%>',
                                            '<%# Eval("[Status]")%>');"
                                   data-dismiss="modal" data-target="#TransactionDetails" data-ticket-type="standard-access">Details</a>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        <script>

                            function filterGrid(value) {
                                var grid = document.getElementById('<%= _oGVTransaction.ClientID%>');

                                if (grid != null) {
                                    var rows = grid.getElementsByTagName("tr");

                                    for (var i = 0; i < rows.length; ++i) {
                                        var cells = rows[i].getElementsByTagName("td");

                                        if (cells.length > 0) {
                                            if (cells[0].innerText === value)
                                                rows[i].style.display = 'table-row';
                                            else
                                                rows[i].style.display = 'none';
                                        }
                                    }
                                }
                            }
                            function show_details(ID, Email, Module, Type, Description, Particulars, Date, Status) {
                                
                                document.getElementById("myTable").innerHTML = '';
                                var str = Particulars.split(";");
                                var i;
                                for (i = Particulars.split(";").length - 2; i > -1; i--) {
                                    var row = document.getElementById("myTable").insertRow(0);
                                    var cell1 = row.insertCell(0);
                                    var cell2 = row.insertCell(1);
                                    var cell3 = row.insertCell(2);
                                    var str2 = str[i].split("=")
                                    cell1.innerHTML = str2[0];                        
                                    cell2.innerHTML = ":";
                                    cell3.innerHTML = str2[1];
                                }
    
                             
                                }    
                            
                        </script>

                    </div>
                </div>
            </div>
        </div>

    </div>
    <asp:HiddenField runat="server" ID="successEnrollment" />

    <!-- Enrollment Modal -->
    <div class="modal fade" id="enrollmentModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-exclamation-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" id="myModalLabel"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" align="center">
                    <label class="font-weight-light text-gray mb-1" id="mess"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary btn-sm pull-center" data-dismiss="modal" id="_oBtnOkay" runat="server">Okay</button>
                </div>
            </div>
        </div>
    </div>



    <!-- Modal TransactionDetails -->
    <div id="TransactionDetails" class="modal fade">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Transaction Details</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <div class="card-footer">                     
                              <div id="TransDetails">
                                  <table id="myTable">                                     
                                  </table>
                                  </div>
                                                
                            <div id="forPaymentLBP_Verify" style="display: none">

                                <div class="row">
                                    <div class="col-sm-12" align="center">
                                        <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Payment Channel</p>
                                        <label class="h6 font-weight-light" id="modalPaymentChannel_Verify"></label>
                                        <br />
                                    </div>
                                    <div class="col-sm-12" align="center">
                                        <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Transaction RefNo</p>
                                        <label class="h6 font-weight-light" id="modalTXNREFNO_Verify"></label>
                                        <br />
                                    </div>

                                    <div class="col-sm-12" align="center">
                                        <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Amount</p>
                                        <label class="h6 font-weight-light" id="modalrawAmount_Verify"></label>
                                        <br />
                                    </div>
                                    <form name="chk_LBP" id="chk_LBP" onsubmit="return setAction(this)" method="POST">
                                        <input type="hidden" name="Hash" id="Hash" />
                                        <input type="hidden" name="MerchantCode" id="MerchantCode" />
                                        <input type="hidden" name="MerchantRefNo" id="MerchantRefNo" />
                                        <input type="submit" style="display: none" value="Check Status" />
                                    </form>

                                </div>

                            </div>

                            <div id="forOTC" style="display: none">
                                <div class="row">
                                    <div class="col-sm-12" align="center">
                                        <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Payment Channel</p>
                                        <label class="h6 font-weight-light" id="modalPaymentChannelOTC"></label>
                                        <br />
                                    </div>
                                    <div class="col-sm-6" align="center">
                                        <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Transaction RefNo</p>
                                        <label class="h6 font-weight-light" id="modalTXNREFNOOTC"></label>
                                        <br />
                                    </div>


                                    <div class="col-sm-6" align="center">
                                        <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Amount to Pay</p>
                                        <label class="h6 font-weight-light" id="modalTotAmountOTC"></label>
                                        <br />
                                    </div>

                                    <br />
                                    <i class="text-xs mb-1 text-primary" id="OTC_NOTE" runat="server"></i>

                                </div>
                            </div>

                        </div>
                    </div>

                </div>



            </div>
        </div>
        <!-- /.modal-content -->

        <script>
            function openModal(swtch) {
                if (swtch == 'BP') {
                    document.getElementById('myModalLabel').innerText = 'Business Account Enrollment';
                    document.getElementById('mess').innerText = 'Your business account enrollment has been successfully submitted for verification. Please check your email.';
                    $('#enrollmentModal').modal('show');
                } else if (swtch = 'RPT') {
                    document.getElementById('myModalLabel').innerText = 'Real Property Account Enrollment';
                    document.getElementById('mess').innerText = 'Your property account enrollment has been successfully submitted for verification. Please check your email.';
                    $('#enrollmentModal').modal('show');
                }
            }

            function do_verify() {

            }
        </script>


    </div>
</asp:Content>

