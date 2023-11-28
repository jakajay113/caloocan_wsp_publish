<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Vaccination_Registry.aspx.vb" Inherits="OBO.Vaccination_Registry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="../CSS_JS_IMG/OS-JS-CSS/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <title runat="server" id="titleLGU">Vaccination Registry</title>
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
                            <table class="col-12" style=" background-color: transparent">

                                <tr style="color: white; background-color: transparent" class="mx-auto">
                                    <td style="width: 10%; align-items: center" class="my-auto">                                        

                                    </td>
                                    <td class="my-auto justify-content-center align-content-center d-flex row">                                        
                                        <h5 style="font-weight: bold; color: black; " class="my-auto col-12 mx-auto" runat="server" id="lguname">
                                            INFORMED CONSENT FORM FOR THE PFIZER-BIONTECH COVID-19 VACCINE
                                        </h5>
                                        <p class=" col-12" style="color:black !Important"> of the Philippine National COVID-19 Vaccine Deployment andn Vaccination Program </p>
                                        <p class=" col-12" style="color:black !Important"> as of April 15, 2021 </p>

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
        
        <div class="col-sm-10 justify-content-center card mt-4">
            <div class="col-lg-12 mt-3">
                <div class="col-lg-12 row mt-4">
                    <div class=" col-lg-12 row ">
                        <%--<div class="col-lg-12 form-group">
                            <h6 class="font-weight-bold text-primary mt-2">Name: </h6>
                        </div>--%>
                        <div class="col-lg-3 form-group">
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
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 row">
                    <div class=" col-lg-12 row">
                        <div class="col-lg-12 form-group">
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Address</span></span></label>
                            <textarea class="form-control CH-Size-new" name="" id="_oTxtAddress" placeholder="" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 row">
                    <div class=" col-lg-12 row">
                        <%--<div class="col-lg-12 form-group">
                            <h6 class="font-weight-bold text-primary mt-2">Contact: </h6>
                        </div>--%>
                        <div class="col-lg-6 form-group">
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Occupation</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtOccupation" placeholder="" runat="server" />
                        </div>
                        <div class="col-lg-6 form-group">
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Contact Number</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtContactNumber" placeholder="" runat="server" />
                        </div>
                        <div class="col-lg-12 form-group">
                            <label class="input-txt input-txt-active2"><span><span class="m-2">Health Facility</span></span></label>
                            <input type="text" class="form-control CH-Size-new" name="" id="_oTxtHealthFacility" placeholder="" runat="server" />
                        </div>
                    </div>
                </div>
                
                <div class="col-lg-12 form-group">
                    <h6 class="font-weight-bold text-primary mt-2">Informed Consent</h6>
                </div>
                <div class=" col-lg-12 row">
                    <div class=" col-lg-6">                       
                            I confirm that I have been provided with and have read the Pfizer BioNTech COVID-19 vaccine and Emergency Use Authorization (EUA) Information Sheet and the same has been explained to me. The FDA has authorized the use of the Pfizer BioNTech COVID-19 vaccine under an EUA since the gathering of scientific evidence for the approval of the said Vaccine and any other COVID-19 vaccine is still ongoing. <br><br>
I confirm that I have been screened for conditions that may merit deferment or special precautions during vaccination as indicated in the Health Screening Questionnaire.<br><br>
I have received sufficient information on the benefits and risks of COVID-19 vaccines and I understand the possible risks if I am not vaccinated. <br><br>
I was provided an opportunity to ask questions, all of which were adequately and clearly answered therefore, voluntarily release the Government of the Philippines, the vaccine manufacturer, their agents and employees, as well as the hospital, the medical doctors and vaccinators, from all claims relating to the results of the use and administration of, or the ineffectiveness of the Pfizer BioNTech COVID-19 Vaccine.<br><br>
I understand that while most side effects are minor and resolve on their own, there is a small risk of severe adverse reactions, such as, but not limited to allergies, and that should prompt medical attention be needed, referral to the nearest hospital shall be provided immediately by the Government of the Philippines. I have been given contact information for follow up for any symptoms which I may experience after vaccination.<br><br>
I understand that by signing this Form, I have a right to health benefit packages under the Philippine Health Insurance Corporation (PhilHealth), in case I suffer a severe and/or serious adverse event, which is found to be associated with the Pfizer BioNTech COVID-19 vaccine or its administration. I understand that the right to claim compensation is subject to the guidelines of the Philhealth.
                        
                    </div>
                    <div class=" col-lg-6 ">
                        I authorize releasing all information needed for public health purposes including reporting to applicable national vaccine registries, consistent with personal and health information storage protocols of the Data Privacy Act of 2012.<br><br>
I hereby give my consent to be vaccinated with the Pfizer BioNTech COVID-19 Vaccine.<br><br><br><br>
                        Signature over Printed Name            &nbsp&nbsp&nbsp&nbsp&nbsp             Date<br><br><br><br>
In case eligible individual is unable to sign: <br><br>
I have witnessed the accurate reading of the consent form and liability waiver to the eligible individual sufficient information was given and queries raised were adequately answered. I hereby confirm that he/she has given his/her consent to be vaccinated with the Pfizer BioNTech COVID-19 Vaccine.<br><br><br><br>
                        Signature over Printed Name &nbsp&nbsp&nbsp&nbsp Date<br><br><br><br>
If you chose not to get vaccinated, please list down your reason/s:
                        <div class="col-lg-12 form-group mx-0 px-0">
                            <%--<label class="input-txt input-txt-active2"><span><span class="m-2">Address</span></span></label>--%>
                            <textarea class="form-control CH-Size-new h-75" name="" id="_oTxtReasons" placeholder="" runat="server" />
                        </div>
                    </div>
                    
                </div>
                <div class="col-lg-12 row">
                    <div class=" col-lg-12 row justify-content-end d-flex">                        
                        <div class="col-lg-2 form-group justify-content-end d-flex">
                            <button name="_oBtnSaveApplication" runat="server" id="_oBtnSaveApplication" onclick="__doPostBack('SaveApplication','')" type="button" class="btn btn-success btn-icon-split">
                                <span class="text">Submit</span>
                                <span class="icon text-white-50">
                                    <i class="fas fa-save mt-1"></i>
                                </span>
                            </button>
                        </div>                        
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
