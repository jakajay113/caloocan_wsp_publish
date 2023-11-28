<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Vaccination_Details.aspx.vb" Inherits="OBO.Vaccination_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="../CSS_JS_IMG/OS-JS-CSS/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <title runat="server" id="titleLGU">Vaccination Details</title>
    <link href="../CSS_JS_IMG/OS-JS-CSS/Css/Online-Services.css" rel="stylesheet" />
    <script src="../CSS_JS_IMG/OS-JS-CSS/Js/OS-Mobile-View.js"></script>
    <link href="../CSS_JS_IMG/css/Sticker.css" rel="stylesheet" />
</head>
<body style="width: 100% !Important">
    <div class="column col-lg-12">



        <nav class="navbar navbar-expand-lg row pt-3 pb-0 Main-Navbar">

            <%-- data-toggle="sticky-onscroll"--%>
            <table class="col-12">
                <tr style="width: 100%; background-color: transparent;">
                    <td>
                        <table class="col-12" style="background-color: transparent">

                            <tr style="color: white; background-color: transparent" class="mx-auto">
                                <td style="width: 10%; align-items: center" class="my-auto"></td>
                                <td class="my-auto justify-content-center align-content-center d-flex row">

                                    <%--<p class=" col-12" style="color: black !Important">as of April 15, 2021 </p>--%>

                                </td>

                                <td style="width: 10%;">
                                    <%--<div class="nav-item dropdown no-arrow col">
                                            <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                <asp:Label ID="_oLabelUserName" runat="server" CssClass="d-none d-lg-inline small Color-White" Text="" Style="text-align: right" />
                                                &nbsp
                                        
                                        
                                    <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>


                                            </a>
                                            <asp:Label ID="_oLabelEmail" runat="server" CssClass="d-none d-lg-inline small Color-White float-right mr-2" Text="" Style="text-align: right" />                                            
                                            <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
                                                <button type="button" runat="server" class="dropdown-item" href="#" id="_oBtnProfile">
                                                    <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>
                                                    Profile
                                                </button>
                                                <button type="button" runat="server" class="dropdown-item" href="#" id="_oBtnChangePass">
                                                    <i class="fas fa-cogs fa-sm fa-fw mr-2 text-gray-400"></i>
                                                    Change Password
                                                </button>                                                
                                                <div class="dropdown-divider"></div>
                                                <button type="button" runat="server" class="dropdown-item" href="#" data-toggle="modal" id="_oBtnLogout">
                                                    <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                                                    Logout
                                                </button>
                                            </div>

                                        </div>--%>

                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <%--<tr style="width: 100%; background-color: transparent;">
                        <td style="text-align: right">
                            <span id="_oTxtTime" class=" mr-3 small" ></span>
                        </td>
                        <script type="text/javascript">
                            function display_c() {
                                var refresh = 1000; // Refresh rate in milli seconds
                                mytime = setTimeout('display_ct()', refresh)
                            }

                            function display_ct() {
                                const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

                                const days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thrusday", "Friday", "Saturday"];
                                var x = new Date();
                                var hours = x.getHours();
                                var date = x.toDateString();
                                var minutes = x.getMinutes();
                                var seconds = x.getSeconds();
                                var ampm = hours >= 12 ? 'pm' : 'am';
                                hours = hours % 12;
                                hours = hours ? hours : 12; // the hour '0' should be '12'
                                minutes = minutes < 10 ? '0' + minutes : minutes;
                                var strTime = days[x.getDay()] + ' ' + months[x.getMonth()] + ' ' + x.getDate() + ', ' + x.getFullYear() + ' ' + hours + ':' + minutes + ':' + seconds + ' ' + ampm;
                                document.getElementById('_oTxtTime').innerHTML = strTime;
                                display_c();
                            }


                            //window.setInterval(updateTime, 1000);

                            //addLoadEvent(display_ct);
                        </script>
                    </tr>--%>
            </table>
            <!-- Nav Item - Messages -->

            <!-- Nav Item - User Information -->


            <script>
                var myVar = setInterval(myTimer, 1000);
                const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

                const days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thrusday", "Friday", "Saturday"];
                var x = new Date();
                var hours = x.getHours();
                var date = x.toDateString();
                var minutes = x.getMinutes();
                var seconds = x.getSeconds();
                var ampm = hours >= 12 ? 'pm' : 'am';
                hours = hours % 12;
                hours = hours ? hours : 12; // the hour '0' should be '12'
                minutes = minutes < 10 ? '0' + minutes : minutes;
                var strTime = days[x.getDay()] + ' ' + months[x.getMonth()] + ' ' + x.getDate() + ', ' + x.getFullYear() + ' ';
                function myTimer() {
                    var d = new Date();
                    var t = d.toLocaleTimeString();
                    document.getElementById("_oTxtTime").innerHTML = strTime + ' ' + t;
                }
            </script>


        </nav>
    </div>
    <form id="form1" runat="server" class="col-lg-12 d-flex justify-content-center">

        <div class="col-sm-11 justify-content-center card mt-2">
            <div class="col-lg-12 mt-2">
                <div class="col-lg-12 row mt-4 px-0">
                    <div class=" col-lg-12 row ">
                        <div class="col-lg-12 form-group m-2">
                            <h5 style="font-weight: bold; color: black;" class="my-auto col-12 mx-auto border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 pb-3" runat="server" id="lguname">COVID-19 Vaccination Card
                            </h5>
                            <p class=" col-12" style="color: black !Important">Please keep this record card, which includes medical
                                <br>
                                information about the vaccines you have received.</p>
                        </div>
                        <div class="col-lg-12 form-group row m-2 pb-0">
                            <%--<label class="input-txt input-txt-active2"><span><span class="m-2">Last Name</span></span></label>--%>
                            <input type="text" class=" col-4 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text1" placeholder="" runat="server" value="Escober" />
                            <input type="text" class="col-4 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text2" placeholder="" runat="server" value="Archie" />
                            <input type="text" class="col-2 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text3" placeholder="" runat="server" value="L." />
                            <input type="text" class="col-2 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text4" placeholder="" runat="server" value="" />
                        </div>
                        <div class="col-lg-12 form-group row mx-2 my-0">
                            <%--<label class="input-txt input-txt-active2"><span><span class="m-2">Last Name</span></span></label>--%>
                            <input type="text" class=" col-4 form-control border-0 w-50 pt-0" name="" id="Text5" placeholder="" runat="server" value="Last Name" />
                            <input type="text" class="col-4 form-control border-0 w-50 pt-0" name="" id="Text6" placeholder="" runat="server" value="First Name" />
                            <input type="text" class="col-2 form-control border-0 w-25 pt-0" name="" id="Text7" placeholder="" runat="server" value="M.I." />
                            <input type="text" class="col-2 form-control border-0 w-25 pt-0" name="" id="Text8" placeholder="" runat="server" value="Suffix" />
                        </div>
                        <div class="col-lg-12 form-group row m-2 pb-0">
                            <input type="text" class=" col-1 form-control border-0 w-50 pt-0" name="" id="Text10" placeholder="" runat="server" value="Address" />
                            <input type="text" class=" col-6 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text9" placeholder="" runat="server" value="Address: 323 B. Ramos Bagbaguin Sta. Maria Bulacan" />
                            <input type="text" class=" col-2 form-control border-0 w-50 pt-0 justify-content-center" name="" id="Text11" placeholder="" runat="server" value="Contact Number" />
                            <input type="text" class=" col-3 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text12" placeholder="" runat="server" value="09653287384" />
                        </div>

                        <div class="col-lg-12 form-group row m-2 pb-0">
                            <input type="text" class=" col-2 form-control border-0 w-50 pt-0" name="" id="Text13" placeholder="" runat="server" value="Date of Birth" />
                            <input type="text" class=" col-2 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text14" placeholder="" runat="server" value="07/27/1999" />
                            <input type="text" class=" col-1 form-control border-0 w-50 pt-0 justify-content-center" name="" id="Text15" placeholder="" runat="server" value="Sex" />
                            <input type="text" class=" col-1 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text20" placeholder="" runat="server" value="Male" />
                            <input type="text" class=" col-2 form-control border-0 rounded-0 " name="" id="Text16" placeholder="" runat="server" value="Philhealth No." />
                            <input type="text" class=" col-2 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text17" placeholder="" runat="server" value="" />
                            <input type="text" class=" col-1 form-control border-0 rounded-0 " name="" id="Text18" placeholder="" runat="server" value="Category" />
                            <input type="text" class=" col-1 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text19" placeholder="" runat="server" value="" />
                        </div>
                        <div class="col-lg-12 form-group m-2">
                            <table class="table ">
                                <thead class="bg-dark">
                                    <tr>
                                        <th scope="col">Dosage Seq.</th>
                                        <th scope="col">Date</th>
                                        <th scope="col">Vaccine Manufacturer</th>                                        
                                        <th scope="col">Batch No.</th>
                                        <th scope="col">Lot No.</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th scope="row">1st Dose</th>
                                        <td>07/21/21</td>
                                        <td>Moderna</td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <th scope="row"></th>
                                        <td>Vaccinator Name:</td>
                                        <td>Erika Regalado</td>
                                        <td>Signature:</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <th scope="row">2nd Dose</th>
                                        <td>08/20/21</td>
                                        <td>Moderna</td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <th scope="row"></th>
                                        <td>Vaccinator Name:</td>
                                        <td>Christine Delight S. RUZ</td>
                                        <td>Signature:</td>
                                        <td></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-lg-12 form-group row m-2 pb-0">
                            <input type="text" class=" col-2 form-control border-0 w-50 pt-0" name="" id="Text21" placeholder="" runat="server" value="Health Facility Name:" />
                            <input type="text" class=" col-4 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text22" placeholder="" runat="server" value="" />
                            <input type="text" class=" col-2 form-control border-0 w-50 pt-0 justify-content-center" name="" id="Text23" placeholder="" runat="server" value="Contact Number" />
                            <input type="text" class=" col-4 form-control border border-top-0 border-left-0 border-right-0 border-bottom-dark rounded-0 " name="" id="Text24" placeholder="" runat="server" value="" />                            
                        </div>
                        <%--<div class="col-lg-3 form-group">
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Last Name</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtLName" placeholder="" runat="server" />
                        </div>
                        <div class="col-lg-3 form-group">
                            <label class="input-txt input-txt-active2"><span><span class="m-2">First Name</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtFName" placeholder="" runat="server" />
                        </div>
                        <div class="col-lg-2 form-group">
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Middle Name</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtMName" placeholder="" runat="server" />
                        </div>
                        <div class="col-lg-2 form-group">
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Birthdate</span></span></label>
                            <input type="date" class="form-control CH-Size-new" name="" id="_oTxtBirthdate" placeholder="" runat="server" />
                        </div>
                        <div class="col-lg-2 form-group">
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Sex</span></span></label>
                            <select class="form-control CH-Size-new">
                                <option>Male</option>
                                <option>Female</option>
                            </select>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../CSS_JS_IMG/js/newjs//SPIDC-ARC-JS.js"></script>
    <script src="../CSS_JS_IMG/js/newjs/SPIDC-ARC-JS.min.js"></script>
    <script src="../CSS_JS_IMG/OS-JS-CSS/jquery/jquery.min.js"></script>
    <script src="../CSS_JS_IMG/OS-JS-CSS/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="../CSS_JS_IMG/OS-JS-CSS/jquery-easing/jquery.easing.min.js"></script>
    <%--<script src="../CSS_JS_IMG/js/newjs/sb-admin-2.min.js"></script>--%>
    <script src="../CSS_JS_IMG/OS-JS-CSS/Js/Online-Services.js"></script>
    <script src="../CSS_JS_IMG/OS-JS-CSS/Js/OS-MainPage.js"></script>
</body>
</html>
