<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmInvestmentForm.aspx.vb"
    Inherits="FrmCompnyName" Title="Investment Form" ValidateRequest="false"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Investment Form</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtLICP.ClientID %>"), 'LIC Premium');
            document.getElementById("<%=TxtLICP.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtPPF.ClientID %>"), 'PPF');
            document.getElementById("<%=TxtPPF.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtNSCs.ClientID %>"), 'NSCs');
            document.getElementById("<%=TxtNSCs.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=Txtintersternnc.ClientID %>"), 'Interest on NSCs');
            document.getElementById("<%=Txtintersternnc.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TXTULIP.ClientID %>"), 'ULIP');
            document.getElementById("<%=TXTULIP.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TXTELLS.ClientID %>"), 'ELLS');
            document.getElementById("<%=TXTELLS.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtnotifiedMF.ClientID %>"), 'Notified Mutual Fund');
            document.getElementById("<%=TxtnotifiedMF.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtPHL.ClientID %>"), 'Principal on Housing Loan');
            document.getElementById("<%=TxtPHL.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtCEF.ClientID %>"), 'Child Education Fees');
            document.getElementById("<%=TxtCEF.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtTDFP.ClientID %>"), 'Term for a Fixed Deposit');
            document.getElementById("<%=TxtTDFP.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=txtNewjeevan.ClientID %>"), 'Notified Annuity Plan of LIC');
            document.getElementById("<%=txtNewjeevan.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtSSS.ClientID %>"), 'Salary Saving Scheme');
            document.getElementById("<%=TxtSSS.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtOthers.ClientID %>"), 'Others');
            document.getElementById("<%=TxtOthers.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TextBox1.ClientID %>"), 'Pension Scheme Investment');
            document.getElementById("<%=TextBox1.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtmedicalhealthChkp.ClientID %>"), 'Medical/Health Insurance Premium');
            document.getElementById("<%=TxtmedicalhealthChkp.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtMIMT.ClientID %>"), 'Maintenance Including Medical Treatment');
            document.getElementById("<%=TxtMIMT.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtIEL.ClientID %>"), 'Interest on Education Loan');
            document.getElementById("<%=TxtIEL.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtDeuctioRes.ClientID %>"), 'Deduction in Eespect of Disability');
            document.getElementById("<%=TxtDeuctioRes.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=txtsectopm80G.ClientID %>"), 'Section 80G');
            document.getElementById("<%=txtsectopm80G.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=Txtrent.ClientID %>"), 'Rent');
            document.getElementById("<%=Txtrent.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtIntrstOnHouse.ClientID %>"), 'Interest on housing loan');
            document.getElementById("<%=TxtIntrstOnHouse.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=Txtonemonthbasic.ClientID %>"), 'LTA');
            document.getElementById("<%=Txtonemonthbasic.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtMedRemb.ClientID %>"), 'Medical Reimbursement');
            document.getElementById("<%=TxtMedRemb.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtIntrntExpns.ClientID %>"), 'Internet Expenses');
            document.getElementById("<%=TxtIntrntExpns.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtTelExpns.ClientID %>"), 'Telephone Expenses');
            document.getElementById("<%=TxtTelExpns.ClientID %>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=txtpetroldsl.ClientID %>"), 'Petrol/Diesel Expenses');
            document.getElementById("<%=txtpetroldsl.ClientID %>").focus();
            if (msg != "") return msg;
            return true

        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
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
        function SplitName() {
            var text = document.getElementById("<%=txtEmp.ClientID%>").value;
            var split = text.split(':');
            if (split.length > 0) {
                document.getElementById("<%=txtEmp.ClientID%>").innerText = split[0];
                document.getElementById("<%=txtempc.ClientID%>").innerText = split[1];
                document.getElementById("<%=HidempId.ClientID%>").innerText = split[2];
            }
        }
   
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
                    <%--   <center>
                    <h2 class="headingTxt" style="width: 587px">
                        INVESTMENT &amp; INCOME DECLARATION FORM
                        <br />
                    </h2>
                </center>--%>
                    <center>
                        <h2 class="headingTxt" style="width: 587px">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h2>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="ErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>SECTION-I</b>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <b>PERSONAL INFORMATION </b>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="left" style="width: 478px">
                                    FINANCIAL YEAR
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfinanceyrs" runat="server" TabIndex="1" SkinID='txt' Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 478px">
                                    EMPLOYEE CODE
                                    <asp:HiddenField ID="HidII_ID" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmp" runat="server" TabIndex="1" SkinID='txt' Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 478px">
                                    ADDRESS
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtADDRESS" runat="server" SkinID="txt" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 478px">
                                    <asp:HiddenField ID="HidempId" runat="server" />
                                    NAME OF EMPLOYEE
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtempc" runat="server" Enabled="false" SkinID="txt" AutoCompleteType="Disabled"
                                        TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 478px">
                                    PAN NO.
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtpannum" runat="server" Enabled="false" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 478px">
                                    DATE OF JOINING(REQUIRED ONLY<br />
                                    IF JOINED ON OR AFTER 1ST APRIL 2012)
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtdoj" runat="server" Enabled="false" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 478px">
                                    CELL NO.
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtcellnum" Enabled="false" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 478px">
                                    E-MAIL ID
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtemail" Enabled="false" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 478px">
                                    BANK ACCOUNT NUMBER(BANK NAME)
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtbankacct" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 478px">
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="center" style="width: 430px">
                                    <b>SECTION-II </b>
                                </td>
                                <td style="width: 130px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="center" style="width: 430px">
                                    &nbsp;&nbsp;&nbsp;<b>INVESTMENT PROFILE</b>
                                </td>
                                <td style="width: 130px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                    <b>Sl.No. </b>
                                </td>
                                <td align="center" style="width: 430px">
                                    <b>Description </b>
                                </td>
                                <td style="width: 130px">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 50px">
                                    1
                                </td>
                                <td align="left" style="width: 430px">
                                    <b>SECTION 80C-(Max of Rs. 100,000 for 80C and 80CCC) </b>
                                </td>
                                <td style="width: 130px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    LIC Premium
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TxtLICP" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    PPF
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TxtPPF" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    NSCs
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TxtNSCs" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    Interest on NSCs
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="Txtintersternnc" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    ULIP
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TXTULIP" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    ELSS
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TXTELLS" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    Notified Mutual Fund
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TxtnotifiedMF" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    Principal on Housing Loan(including stamp duty, registration fees & other Expenses
                                    incurred for the purpose of transfer of property
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TxtPHL" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    Child Education Fees-Tution Fees for full time education to Indian School, University
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TxtCEF" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    Term Deposit for a fix period of not less than 5 year with a Scheduled Bank
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TxtTDFP" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 442px">
                                    Notified Annuity Plan of LIC or any other Insurer(New Jeevan dhara, New Jeevan Dhara-I,
                                    New Jeevan akshay, New Jeevan Akshay-I and New Jeevan Akshay-II)
                                </td>
                                <td style="width: 152px">
                                    <asp:TextBox ID="txtNewjeevan" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px; height: 6px;">
                                </td>
                                <td align="left" style="width: 430px; height: 6px;">
                                    CPF/GPF/LIC(Salary Saving Scheme)
                                </td>
                                <td style="width: 130px; height: 6px;">
                                    <asp:TextBox ID="TxtSSS" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px">
                                </td>
                                <td align="left" style="width: 430px">
                                    Others
                                </td>
                                <td style="width: 130px">
                                    <asp:TextBox ID="TxtOthers" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 50px">
                                    2
                                </td>
                                <td align="left" style="width: 430px">
                                    <b>SECTION 80CCC </b>
                                </td>
                                <td style="width: 130px">
                                    &nbsp;
                                </td>
                            </tr>
            </a>
            <tr>
                <td align="center" style="width: 50px">
                    &nbsp;
                </td>
                <td align="left" style="width: 430px">
                    Pension Scheme Investement
                </td>
                <td style="width: 130px">
                    <asp:TextBox ID="TextBox1" runat="server" SkinID="txt" TabIndex="14"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    3
                </td>
                <td align="left" style="width: 430px; font-weight: 700;">
                    SECTION 80D(Max Rs.35,000)
                </td>
                <td style="width: 130px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    &nbsp;
                </td>
                <td align="left" style="width: 430px">
                    Medical/Health Insurance Premium/Annual Health Checkup
                </td>
                <td style="width: 130px">
                    <asp:TextBox ID="TxtmedicalhealthChkp" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 23px;">
                    4
                </td>
                <td align="left" style="height: 23px; width: 430px; font-weight: 700;">
                    SECTION 80DD
                </td>
                <td style="width: 130px; height: 23px;">
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px; height: 24px;">
                    &nbsp;
                </td>
                <td align="left" style="height: 24px; width: 430px;">
                    Maintenance Including Medical Treatment Of Handicapped Dependent
                </td>
                <td style="width: 130px; height: 24px;">
                    <asp:TextBox ID="TxtMIMT" runat="server" SkinID="txt" TabIndex="16"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    5
                </td>
                <td align="left" style="width: 430px; font-weight: 700;">
                    SECTION 80E
                </td>
                <td style="width: 130px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    &nbsp;
                </td>
                <td align="left" style="width: 430px">
                    Interest on Education Loan(No limit)
                </td>
                <td style="width: 130px">
                    <asp:TextBox ID="TxtIEL" runat="server" SkinID="txt" TabIndex="17"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    6
                </td>
                <td align="left" style="width: 430px; font-weight: 700;">
                    SECTION 80U
                </td>
                <td style="width: 130px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    &nbsp;
                </td>
                <td align="left" style="width: 430px">
                    Deducation in respect of Disability
                </td>
                <td style="width: 130px">
                    <asp:TextBox ID="txtsectopm80G" runat="server" SkinID="txt" TabIndex="18"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    7
                </td>
                <td align="left" style="width: 430px">
                    <h4>
                        SECTION 80G
                    </h4>
                </td>
                <td style="width: 130px">
                    <asp:TextBox ID="TxtDeuctioRes" runat="server" SkinID="txt" TabIndex="19"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
                    <br />
                </td>
            </tr>
            <%--</table>
                    <table>--%>
            <tr>
                <td style="width: 50px">
                </td>
                <td align="center" style="width: 430px">
                    <b>SECTION-III </b>
                </td>
                <td style="width: 130px">
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
                </td>
                <td align="center" style="width: 430px">
                    <b>DECLARATION OF RENT FOR THE PURPOSE OF EXEMPTION U/S 10(13A) </b>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    1
                </td>
                <td align="left" style="width: 430px">
                    Rent[Per Month]
                </td>
                <td style="width: 130px">
                    <asp:TextBox ID="Txtrent" runat="server" SkinID="txt" TabIndex="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    2
                </td>
                <td align="left" style="width: 430px">
                    Location of Property taken on rent with Landlord name
                </td>
                <td style="width: 130px">
                    <asp:TextBox ID="Txtlocationofprop" runat="server" SkinID="txt" TabIndex="21"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
                </td>
                <td align="center" style="width: 430px">
                    <b>SECTION-IV </b>
                </td>
                <td style="width: 130px">
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
                </td>
                <td align="center" style="width: 430px">
                    <b>DECLARATION FOR THE PURPOSE OF DEDUCATION U/S 24 OF INCOME TAX ACT, 1961 </b>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 50px">
                    1
                </td>
                <td align="left" style="width: 430px">
                    Interest on housing loan repaid during the year
                </td>
                <td style="width: 130px">
                    <asp:TextBox ID="TxtIntrstOnHouse" runat="server" SkinID="txt" TabIndex="22"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
                    <br />
                </td>
            </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 79px">
                    </td>
                    <td align="center" colspan="2">
                        <b>SECTION-V </b>
                    </td>
                    <%-- <td style="width: 130px">
                            </td>--%>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 79px">
                    </td>
                    <td align="center" colspan="2">
                        <b>Breakup of Flexible Benifit Plan and other information </b>
                    </td>
                    <td style="width: 130px">
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 79px; height: 23px;">
                    </td>
                    <td style="height: 23px;">
                    </td>
                    <td style="width: 101px; height: 23px;">
                        Max per year
                    </td>
                    <td style="height: 23px">
                        Amt for 12-13
                    </td>
                </tr>
                <tr>
                    <td style="width: 79px">
                    </td>
                    <td>
                    </td>
                    <td style="width: 101px" class="style2">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 79px">
                        1
                    </td>
                    <td>
                        LTA
                    </td>
                    <td style="width: 101px" class="style2">
                        One month basic
                    </td>
                    <td style="width: 130px">
                        <asp:TextBox ID="Txtonemonthbasic" runat="server" SkinID="txt" TabIndex="23"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 79px">
                        2
                    </td>
                    <td>
                        Medical Reimbursement
                    </td>
                    <td style="width: 101px" class="style2">
                        15000
                    </td>
                    <td>
                        <asp:TextBox ID="TxtMedRemb" runat="server" SkinID="txt" TabIndex="24"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 79px">
                        3
                    </td>
                    <td>
                        Internet Expenses
                    </td>
                    <td style="width: 101px" class="style2">
                        12000
                    </td>
                    <td>
                        <asp:TextBox ID="TxtIntrntExpns" runat="server" SkinID="txt" TabIndex="25"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 79px">
                        4
                    </td>
                    <td>
                        Telephone Expenses
                    </td>
                    <td style="width: 101px" class="style2">
                        12000
                    </td>
                    <td>
                        <asp:TextBox ID="TxtTelExpns" runat="server" SkinID="txt" TabIndex="26"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 79px">
                        5
                    </td>
                    <td>
                        Petrol/diesel reimbursement
                    </td>
                    <td style="width: 101px" class="style2">
                        21600
                    </td>
                    <td>
                        <asp:TextBox ID="txtpetroldsl" runat="server" SkinID="txt" TabIndex="27"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 79px">
                        <br />
                    </td>
                </tr>
                </tdstyle="width:> </caption>
                <tr>
                    <td style="width: 79px">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td align="center">
                        <b>Following are my dependants for claiming reimbursements </b>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td align="center" style="width: 107px">
                        &nbsp;
                    </td>
                    <td>
                        Dependants
                    </td>
                    <td>
                        Relationship
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 107px">
                        1
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" SkinID="txtRsz" Style="margin-left: 0px"
                            TabIndex="28"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox ID="TextBox4" runat="server" SkinID="txt" TabIndex="29"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 107px">
                        2
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" SkinID="txtRsz" TabIndex="30"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox ID="TextBox6" runat="server" SkinID="txt" TabIndex="31"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 107px">
                        3
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" SkinID="txtRsz" TabIndex="32"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox ID="TextBox8" runat="server" SkinID="txt" TabIndex="33"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 107px">
                        4
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server" SkinID="txtRsz" TabIndex="34"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox ID="TextBox10" runat="server" SkinID="txt" TabIndex="35"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        5
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox11" runat="server" SkinID="txtRsz" TabIndex="36"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox ID="TextBox12" runat="server" SkinID="txt" TabIndex="37"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 107px">
                        6
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox13" runat="server" SkinID="txtRsz" TabIndex="38"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox ID="TextBox14" runat="server" SkinID="txt" TabIndex="39"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 107px">
                        7<br />
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox15" runat="server" SkinID="txtRsz" TabIndex="40"></asp:TextBox>
                    </td>
                    <td style="width: 3px">
                        <asp:TextBox ID="TextBox16" runat="server" SkinID="txt" TabIndex="41"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td align="center">
                        <br />
                        <b>DECLARATION </b>
                    </td>
                </tr>
                <tr>
                    <td align="justify">
                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" Text="   I,do here by declare that the aforesaid information is true and correct to the
                                best of my information and belief and I shall indemnify the company against all
                                costs and consequences if any information is later on found to be incorrect."
                            Width="400px" TabIndex="42" SkinID="chk" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        (Signature of Employee)
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Place :
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Date&nbsp; :
                    </td>
                </tr>
                <tr>
                    <td align="center" class="btnTd">
                        <asp:Button ID="BtnSave" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                            CssClass="ButtonClass" SkinID="btn" TabIndex="43" Text="SUBMIT" />
                    </td>
                </tr>
            </table>
            <a name="bottom">
                <br />
                <center>
                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                    <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                </center>
                <br />
                </center> </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>