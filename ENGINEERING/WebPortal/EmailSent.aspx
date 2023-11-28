<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="ASSESSMENT_OBO.aspx.vb" Inherits="OBO.ASSESSMENT_OBO" %>

<!DOCTYPE html>
<html>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">


<body class="w3-theme-l5">
    <!-- Page Container -->
    <div class="w3-container w3-content" style="max-width: 1400px; margin-top: 80px">
        <!-- The Grid -->

        <div class="w3-row">
            <!-- Left Column -->
            <div class="w3-col m12">
                <!-- Profile -->
                <div class="w3-card w3-round w3-white">
                    <div class="w3-container w3-center">
                        <br>
                        <br>
                        <br>
                        <h2>
                            <asp:Label ID="lblHeader" runat="server" Text="Applicant successfully notified"></asp:Label></h2>
                        <div id="OK">
                            <br />
                            <img src="../CSS_JS_IMG/img/email%20sent.png" />
                            <br />
                            <br />
                             <a href="Register.aspx">SIGN OUT</a>
                             &nbsp &nbsp &nbsp &nbsp
                            <a href="ApplicationReview.aspx">REVIEW ANOTHER TRANSACTION</a>
                        </div>

                        <br>
                    </div>
                </div>
                <br>


                <!-- End Grid -->
            </div>

            <!-- End Page Container -->
        </div>
    </div>
    <br>
</body>
</html>