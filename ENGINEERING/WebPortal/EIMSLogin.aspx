<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="~/WebPortal/EIMSLogin.aspx.vb" Inherits="OBO.EIMSLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link href="../OS-JS-CSS/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <title>SPIDC System</title>
    <link href="../OS-JS-CSS/Css/Online-Services.css" rel="stylesheet" />
    <%--<script src="/OS-JS-CSS/Js/OS-Mobile-View.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div class="container-center col-lg-12">

            <div class="col-sm-12 d-flex align-content-center justify-content-center">
                <h1 class="text-primary font-weight-bold">Engineering Information Management System</h1>
            </div>
            <br />
            <br />
            <center>
            <div class="col-lg-5 ">
                <div class="form-group col-lg-12" style = "max-width:303px !Important">
    
                    <div>
                          
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Username</span></span>
                        </label>
                        <asp:TextBox class="form-control CH-Size-New" runat="server" required ID="_oTxtUsername" />
                            <label class="input-txt input-txt-active2" id="lblusererror" runat="server" style="font-style:italic;color:red" visible="false">
                            <span><span class="m-2"></span></span>
                        </label>
                    </div>
                </div>                
                <div class="form-group col-lg-12" style = "max-width:303px !Important">
                    <label class="input-txt input-txt-active2" style="z-index:100 !Important">
                            <span><span class="m-2">Password</span></span>
                                    
                        </label>
       
                    <div class="input-group mb-3 CH-Size-New">
                        <input type="password" class="form-control" runat="server"  required ID="_oTxtPassword"/>
                         
                            <div class="input-group-append">
                                <button type="button" class="input-group-text btn-primary" onclick="_NextPage();" title="Sign In">LOGIN</button>
                            </div>
                        
                        </div>
                    <label class="input-txt input-txt-active2" id="lblpasserr" runat="server" style="font-style:italic;color:red" visible="false">
                            <span><span class="m-2"></span></span>
                        </label>
                    </div>
                </div> 
                
                </center>
        </div>
        <script>

            function _NextPage() {
                __doPostBack('login');
            }

        </script>
        <style>
            .container-center {
                width: 100%;
                height: 50%;
                margin: auto;
                position: absolute;
                top: 0;
                left: 0;
                bottom: 0;
                right: 0;
            }
        </style>

    </form>
    <script src="../OS-JS-CSS/jquery/jquery.min.js"></script>
    <script src="../OS-JS-CSS/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="../OS-JS-CSS/jquery-easing/jquery.easing.min.js"></script>
    <script src="../OS-JS-CSS/Js/Online-Services.js"></script>
    <%--<script src="/OS-JS-CSS/Js/OS-MainPage.js"></script>--%>
</body>
</html>
