<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmPayrollMaster_New.aspx.vb" Inherits="FrmPayrollMaster_New" title="Payroll Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payroll Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        //Function for Multilingual Validations
        //Created By Niraj
        function ErrorMessage(msg) {
            var SesVar = '<%= Session("Validation") %>';
            var ValidationArray = new Array();
            ValidationArray = SesVar.split(":");
            for (var i = 0; i < ValidationArray.length - 1; i++) {
                if (ValidationArray[i] == msg) {
                    return ValidationArray[i + 1];
                }
            }
        }


        function Spliter(a) {
            var str = a;
            var n = str.indexOf("*");
            if (n != 0 && n != -1) {
                a = a.split("*");
                return a[0];
            }
            var n = str.indexOf("^");
            if (n != 0 && n != -1) {
                a = a.split("^");
                return a[0];
            }
            var n = str.indexOf(":");
            if (n != 0 && n != -1) {
                a = a.split(":");
                return a[0];
            }
        }

      
        function Valid() {
            var msg;

            msg = AutoCompleteExtenderForThreeMul(document.getElementById("<%=txtEmp.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtEmp.ClientID %>").focus();
                a = document.getElementById("<%=Label12.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMulN(document.getElementById("<%=TxtSRDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtSRDate.ClientID %>").focus();
                a = document.getElementById("<%=Label14.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            //            msg = NameField100(document.getElementById("<%=Txtbasicpay.ClientID %>"), 'Basic Pay');
            //            if (msg != "") {
            //                document.getElementById("<%=Txtbasicpay.ClientID %>").focus();
            //                return msg;
            //            }
            msg = FeesFieldMul(document.getElementById("<%=Txtbasicpay.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Txtbasicpay.ClientID %>").focus();
                a = document.getElementById("<%=Label17.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=TxtdearAllw.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=TxtdearAllw.ClientID %>").focus();
                a = document.getElementById("<%=Label13.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=TxtSpecialAllowance.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=TxtSpecialAllowance.ClientID %>").focus();
                a = document.getElementById("<%=Label18.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=TxtHouseRentAllw.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=TxtHouseRentAllw.ClientID %>").focus();
                a = document.getElementById("<%=Label15.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=TxtmedicalAllw.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=TxtmedicalAllw.ClientID %>").focus();
                a = document.getElementById("<%=Label19.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=TxtTransportAllowance.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtTransportAllowance.ClientID %>").focus();
                a = document.getElementById("<%=Label16.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=TxtfixedIncentive.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtfixedIncentive.ClientID %>").focus();
                a = document.getElementById("<%=Label20.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtMiscAllw1.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMiscAllw1.ClientID %>").focus();
                a = document.getElementById("<%=Label22.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtMiscAllw2.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMiscAllw2.ClientID %>").focus();
                a = document.getElementById("<%=Label23.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtMiscAllw3.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMiscAllw3.ClientID %>").focus();
                a = document.getElementById("<%=Label24.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtMiscAllw4.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMiscAllw4.ClientID %>").focus();
                a = document.getElementById("<%=Label25.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtMiscAllw5.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMiscAllw5.ClientID %>").focus();
                a = document.getElementById("<%=Label26.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtMiscAllw6.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMiscAllw6.ClientID %>").focus();
                a = document.getElementById("<%=Label27.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtMiscAllw7.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMiscAllw7.ClientID %>").focus();
                a = document.getElementById("<%=Label49.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtMiscAllw8.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMiscAllw8.ClientID %>").focus();
                a = document.getElementById("<%=Label51.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtMiscAllw9.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMiscAllw9.ClientID %>").focus();
                a = document.getElementById("<%=Label52.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtCityCompAllw.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtCityCompAllw.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtOverTime.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtOverTime.ClientID %>").focus();
                a = document.getElementById("<%=Label11.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtHonorary.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtHonorary.ClientID %>").focus();
                a = document.getElementById("<%=Label21.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtpfdeduction.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtpfdeduction.ClientID %>").focus();
                a = document.getElementById("<%=Label45.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded1.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded1.ClientID %>").focus();
                a = document.getElementById("<%=Label31.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded2.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded2.ClientID %>").focus();
                a = document.getElementById("<%=Label32.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded3.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded3.ClientID %>").focus();
                a = document.getElementById("<%=Label33.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded4.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded4.ClientID %>").focus();
                a = document.getElementById("<%=Label34.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded5.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded5.ClientID %>").focus();
                a = document.getElementById("<%=Label35.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded6.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded6.ClientID %>").focus();
                a = document.getElementById("<%=Label36.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded7.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded7.ClientID %>").focus();
                a = document.getElementById("<%=Label37.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded8.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded8.ClientID %>").focus();
                a = document.getElementById("<%=Label38.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded9.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded9.ClientID %>").focus();
                a = document.getElementById("<%=Label39.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded10.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded10.ClientID %>").focus();
                a = document.getElementById("<%=Label40.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded11.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded11.ClientID %>").focus();
                a = document.getElementById("<%=Label41.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded12.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded12.ClientID %>").focus();
                a = document.getElementById("<%=Label42.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded13.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded13.ClientID %>").focus();
                a = document.getElementById("<%=Label43.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded14.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=Miscded14.ClientID %>").focus();
                a = document.getElementById("<%=Label44.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }

            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded15.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded15.ClientID %>").focus();
                a = document.getElementById("<%=Label10.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=Miscded16.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Miscded16.ClientID %>").focus();
                a = document.getElementById("<%=Label50.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg); 
                return msg;
            }

            //            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=txtFestAdvance.ClientID %>"), 'Festival Advance');
            //            if (msg != "") {
            //                document.getElementById("<%=txtFestAdvance.ClientID %>").focus();
            //                return msg;
            //            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }


        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtEmp.ClientID%>"));
        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtEmp.ClientID%>"));
        }

        //        function SplitName() {
        //            var text = document.getElementById("<%=txtEmp.ClientID%>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=txtEmp.ClientID%>").innerText = split[0];
        //                document.getElementById("<%=txtEmpName.ClientID%>").innerText = split[1];
        //                document.getElementById("<%=HidempId.ClientID%>").innerText = split[2];
        //            }
        //        }
        //   
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--  <center>
                    <h1 class="headingTxt">
                        PAYROLL DETAILS</h1>
                    <br />
                    <br />
                </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                        <br />
                        <br />
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" Text="Employee Code*^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="180px"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtEmp" runat="server" AutoPostBack="True" TabIndex="1" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtEmp">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" TargetControlID="txtEmp"
                                        EnableCaching="True" MinimumPrefixLength="3" ServiceMethod="getEmpCodeExt1" ServicePath="TextBoxExt.asmx"
                                        OnClientPopulated="HideImage" OnClientPopulating="ShowImage" CompletionListCssClass="completeListStyle"
                                        CompletionInterval="2000" FirstRowSelected="true">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                    SkinID="watermark" TargetControlID="txtEmp" WatermarkText="Type first 3 characters">
                                </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label45" runat="server" Text="PF Deduction :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpfdeduction" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="21"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:HiddenField ID="HidempId" runat="server" />
                                    <asp:Label ID="Label46" runat="server" Text="Employee Name :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpName" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                        Enabled="false" TabIndex="2"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label28" runat="server" Text="VPF :&nbsp;&nbsp;" SkinID="lblRsz" Width="175px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtvpf" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="22"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label14" SkinID="lblRsz" runat="server" Text="Salary Rev Date :&nbsp;&nbsp;"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtSRDate" SkinID="txt" runat="server" AutoCompleteType="disabled"
                                        TabIndex="3"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label29" runat="server" Text="Prof Tax Deduction :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtproftaxdedc" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="23" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" Text="Basic Pay* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtbasicpay" AutoCompleteType="disabled" runat="server" SkinID="txt"
                                        TabIndex="4"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label31" runat="server" Text="Misc Deduction 1 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded1" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="24"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" Text="Dearness Allw :&nbsp;&nbsp;" Width="150px"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtdearAllw" AutoCompleteType="disabled" runat="server" SkinID="txt"
                                        TabIndex="5"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label32" runat="server" Text="Misc Deduction 2 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded2" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="25"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" Text="Special Allowance :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtSpecialAllowance" AutoCompleteType="disabled" runat="server"
                                        SkinID="txt" TabIndex="6"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label33" runat="server" Text="Misc Deduction 3 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded3" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="26"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" Text="House Rent Allw :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtHouseRentAllw" AutoCompleteType="disabled" runat="server" SkinID="txt"
                                        TabIndex="7"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label34" runat="server" Text="Misc Deduction 4 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded4" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="27"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" Text="Medical Allw :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtmedicalAllw" AutoCompleteType="disabled" runat="server" SkinID="txt"
                                        TabIndex="8"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label35" runat="server" Text="Misc Deduction 5 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded5" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="28"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" Text="Transport Allowance :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="165px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtTransportAllowance" AutoCompleteType="disabled" runat="server"
                                        SkinID="txt" TabIndex="9"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label36" runat="server" Text="Misc Deduction 6 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded6" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="29"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label20" runat="server" Text="Fixed Incentive :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtfixedIncentive" AutoCompleteType="disabled" runat="server" SkinID="txt"
                                        TabIndex="10"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label37" runat="server" Text="Misc Deduction 7 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded7" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="30"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="City Comp Allw :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCityCompAllw" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="11"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label38" runat="server" Text="Misc Deduction 8 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded8" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="31"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label11" runat="server" Text="Over Time :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOverTime" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="12"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label39" runat="server" Text="Misc Deduction 9 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded9" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="32"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label21" runat="server" Text="Honorary :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHonorary" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="13"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label40" runat="server" Text="Misc Deduction 10 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded10" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="33"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label22" runat="server" Text="Misc Allw 1 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiscAllw1" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="14"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label41" runat="server" Text="Misc Deduction 11 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded11" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="34"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label23" runat="server" Text="Misc Allw 2 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiscAllw2" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="15"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label42" runat="server" Text="Misc Deduction 12 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded12" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="35"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label24" runat="server" Text="Misc Allw 3 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiscAllw3" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="16"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label43" runat="server" Text="Misc Deduction 13 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded13" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="36"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label25" runat="server" Text="Misc Allw 4 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiscAllw4" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="17"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label44" runat="server" Text="Misc Deduction 14 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded14" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="37"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label26" runat="server" Text="Misc Allw 5 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiscAllw5" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="18"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label10" runat="server" Text="Misc Deduction 15 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded15" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="38"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label27" runat="server" Text="Misc Allw 6 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiscAllw6" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="19"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label50" runat="server" Text="Misc Deduction 16 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Miscded16" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="39"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label49" runat="server" Text="Misc Allw 7 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiscAllw7" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="19"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblPFAcct" runat="server" Text="PF/ACC No :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPFAcctNo" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="40"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label51" runat="server" Text="Misc Allw 8 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiscAllw8" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="19"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox1" runat="server" SkinID="CHK" Text="Settlement" TabIndex="41" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label52" runat="server" Text="Misc Allw 9 :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiscAllw9" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TabIndex="19"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label48" runat="server" Text="Mode Of Payment :&nbsp;&nbsp" SkinID="lblRSz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlpaymentmethod" runat="server" SkinID="ddl" DataTextField="Payment_Method"
                                        DataValueField="PaymentMethodID" TabIndex="20" DataSourceID="cmbpaymentmethod">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="cmbpaymentmethod" runat="server" SelectMethod="GetPaymentMethodcombo1"
                                        TypeName="AssetDetailsDB"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSubTot" runat="server" Text="SUB TOTAL :&nbsp;&nbsp;" Width="150px"
                                        SkinID="lblRsz" Visible="false"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblTotAllow" runat="server" SkinID="lblRsz" Visible="false"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label47" runat="server" SkinID="lblRsz" Width="350px" Visible="false"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblTotDeduc" runat="server" Width="150px" SkinID="lblRsz" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <ajaxToolkit:CalendarExtender ID="SRDate1" TargetControlID="txtSRDate" runat="server"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label30" runat="server" Visible="false" Text="Festival Advance :&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFestAdvance" runat="server" Visible="false" AutoCompleteType="Disabled"
                                        SkinID="txt" TabIndex="23"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtid" runat="server" Visible="false"></asp:TextBox><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="4" align="center">
                                    <asp:Button ID="BtnSave" runat="server" Text="ADD" CausesValidation="true" SkinID="btnRsz"
                                        TabIndex="42" OnClientClick="return Validate();" CssClass="ButtonClass" />
                                    &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CommandName="Details"
                                        SkinID="btnRsz" Text="VIEW" TabIndex="43" CssClass="ButtonClass" />
                                    <!--<asp:Button ID="BtnRecover" runat="server" CausesValidation="False" OnClick="BtnRecover_Click"
                                                SkinID="btn" Text="RECOVER" TabIndex="39" CssClass="btnStyle" />-->
                                    &nbsp;<%--<asp:Button ID="BtnReport" runat="server" Text="REPORT" CommandName="Preview" OnClick="preview"
                                                CausesValidation="true" SkinID="btn" TabIndex="38" CssClass="btnStyle" onClientClick="return ValidateReport();" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </center>
            </a><a name="bottom">
                <center>
                    <div>
                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                            <ProgressTemplate>
                                <div class="PleaseWait">
                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                        <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                    </div>
                </center>
                <div>
                    <br />
                </div>
                <div>
                    <center>
                        <asp:Panel ID="pnl1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="delete"
                                                Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="TxtHdnFld" runat="server" Value='<%# Bind("PM_ID") %>' />
                                            <asp:HiddenField ID="empid" runat="server" Value='<%# Bind("EmpID") %>' />
                                            <asp:Label ID="Label2" runat="server" Text='<% #bind("Emp_Code" )%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3023" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mode Of Payment">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaymentId" runat="server" Text='<%# Bind("PaymentMethodIDAuto") %>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblPayment" runat="server" Text='<%# Bind("Payment_Method") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PF/ACCT No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPFAcct" runat="server" Text='<%# Bind("PFAcct") %>'></asp:Label>
                                            <asp:Label ID="lblSettlement" runat="server" Text='<%# Bind("Settlement") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Salary Rev Date" SortExpression="SalaryRevDate">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("SalaryRevDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Basic Pay">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("BasicPay","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dearness Allowance">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("DearnessAllw","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Special Allowance">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("SpecialAllw","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="House Rent Allowance">
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("HouseRentAllw","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medical Allowance">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("MedicalAllw","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transport Allowance">
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("TransportAllw","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Fixed Incentive">
                                        <ItemTemplate>
                                            <asp:Label ID="Label101" runat="server" Text='<%# Bind("FixedIncentive","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City Comp Allw">
                                        <ItemTemplate>
                                            <asp:Label ID="Label108" runat="server" Text='<%# Bind("CityCompAllw","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Over Time">
                                        <ItemTemplate>
                                            <asp:Label ID="Label109" runat="server" Text='<%# Bind("OverTime","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Honorary">
                                        <ItemTemplate>
                                            <asp:Label ID="Label110" runat="server" Text='<%# Bind("Honorary","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Allw 1">
                                        <ItemTemplate>
                                            <asp:Label ID="Label102" runat="server" Text='<%# Bind("MiscAllw1","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Allw 2">
                                        <ItemTemplate>
                                            <asp:Label ID="Label103" runat="server" Text='<%# Bind("MiscAllw2","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Allw 3">
                                        <ItemTemplate>
                                            <asp:Label ID="Label104" runat="server" Text='<%# Bind("MiscAllw3","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Allw 4">
                                        <ItemTemplate>
                                            <asp:Label ID="Label105" runat="server" Text='<%# Bind("MiscAllw4","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Allw 5">
                                        <ItemTemplate>
                                            <asp:Label ID="Label106" runat="server" Text='<%# Bind("MiscAllw5","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Allw 6">
                                        <ItemTemplate>
                                            <asp:Label ID="Label107" runat="server" Text='<%# Bind("MiscAllw6","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Allw 7">
                                        <ItemTemplate>
                                            <asp:Label ID="Label130" runat="server" Text='<%# Bind("MiscAllw7","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Allw 8">
                                        <ItemTemplate>
                                            <asp:Label ID="Label131" runat="server" Text='<%# Bind("MiscAllw8","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Allw 9">
                                        <ItemTemplate>
                                            <asp:Label ID="Label132" runat="server" Text='<%# Bind("MiscAllw9","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PF Deduction">
                                        <ItemTemplate>
                                            <asp:Label ID="Label111" runat="server" Text='<%# Bind("PFDed","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="VPF">
                                        <ItemTemplate>
                                            <asp:Label ID="Label112334" runat="server" Text='<%# Bind("VPF","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prof Tax Deduction">
                                        <ItemTemplate>
                                            <asp:Label ID="Label112" runat="server" Text='<%# Bind("ProfTaxDed","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Festival Advance" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="Label128" runat="server" Text='<%# Bind("FestAdvance","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 1">
                                        <ItemTemplate>
                                            <asp:Label ID="Label113" runat="server" Text='<%# Bind("MiscDed1","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 2">
                                        <ItemTemplate>
                                            <asp:Label ID="Label114" runat="server" Text='<%# Bind("MiscDed2","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 3">
                                        <ItemTemplate>
                                            <asp:Label ID="Label115" runat="server" Text='<%# Bind("MiscDed3","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 4">
                                        <ItemTemplate>
                                            <asp:Label ID="Label116" runat="server" Text='<%# Bind("MiscDed4","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 5">
                                        <ItemTemplate>
                                            <asp:Label ID="Label117" runat="server" Text='<%# Bind("MiscDed5","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 6">
                                        <ItemTemplate>
                                            <asp:Label ID="Label118" runat="server" Text='<%# Bind("MiscDed6","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 7">
                                        <ItemTemplate>
                                            <asp:Label ID="Label119" runat="server" Text='<%# Bind("MiscDed7","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 8">
                                        <ItemTemplate>
                                            <asp:Label ID="Label120" runat="server" Text='<%# Bind("MiscDed8","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 9">
                                        <ItemTemplate>
                                            <asp:Label ID="Label121" runat="server" Text='<%# Bind("MiscDed9","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 10">
                                        <ItemTemplate>
                                            <asp:Label ID="Label122" runat="server" Text='<%# Bind("MiscDed10","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 11">
                                        <ItemTemplate>
                                            <asp:Label ID="Label123" runat="server" Text='<%# Bind("MiscDed11","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 12">
                                        <ItemTemplate>
                                            <asp:Label ID="Label124" runat="server" Text='<%# Bind("MiscDed12","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 13">
                                        <ItemTemplate>
                                            <asp:Label ID="Label125" runat="server" Text='<%# Bind("MiscDed13","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 14">
                                        <ItemTemplate>
                                            <asp:Label ID="Label126" runat="server" Text='<%# Bind("MiscDed14","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 15">
                                        <ItemTemplate>
                                            <asp:Label ID="Label127" runat="server" Text='<%# Bind("MiscDed15","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Misc Deduction 16">
                                        <ItemTemplate>
                                            <asp:Label ID="Label133" runat="server" Text='<%# Bind("MiscDed16","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </div>
                <div>
                    <%--<asp:ObjectDataSource ID="OdsEmp" TypeName="EmployeeManager" SelectMethod="GetEmpComboUser"
                            runat="server" OldValuesParameterFormatString="original_{0}">--%>
                    <%--<SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="id" SessionField="EMPID" Type="Int64" />
                            </SelectParameters>--%>
                    <%--  </asp:ObjectDataSource>--%>
                    <%--<asp:ObjectDataSource ID="OdsPayroll" runat="server" TypeName="BLPayroll" SelectMethod="GetPayroll"
                        DeleteMethod="ChangeFlag" DataObjectTypeName="EntPayroll" OldValuesParameterFormatString="original_{0}">
                    </asp:ObjectDataSource>--%>
                </div>
                <style type="text/css">
                    .completeListStyle
                    {
                        height: 100px;
                        width: 50px;
                        overflow: auto;
                        list-style-type: disc;
                        padding-left: 17px;
                        background-color: #FFF;
                        border: 1px solid DarkGray;
                        text-align: left;
                        font-size: small;
                        color: black;
                    }
                </style>
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

