<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmInvestmentReport.aspx.vb"
    Inherits="FrmInvestmentReport" Title="Endowment Deposit Master Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Endowment Deposit Master Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
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
            msg = ValidateDateMulN(document.getElementById("<%=txtfromdate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtfromdate.ClientID%>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMulN(document.getElementById("<%=txttodate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txttodate.ClientID%>").focus();
                a = document.getElementById("<%=Label2.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
        
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="Updatepanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <td align="center">
                                <h1 class="headingTxt">
                                <br />
                                    <asp:Label ID="LabelEdm" runat="server" Text="ENDOWMENT DEPOSIT MASTER" SkinID="lblRepRsz"
                                        Width="350" Visible="True"></asp:Label>
                                </h1>
                            </td>
                        </tr>
                    </table>
                    <%-- <center>
                        <h1 class="headingTxt">
                            ENDOWMENT DEPOSIT MASTER</h1>
                    </center>--%>
                    <br />
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblinvst" runat="server" SkinID="lblRsz" Text="Investment Type :"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp<asp:DropDownList ID="cmbInvest" runat="server" DataSourceID="ObjInvest" DataTextField="InvestmentType"
                                        SkinID="ddl" AutoPostBack="true" DataValueField="IMAutoID" TabIndex="1">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjInvest" runat="server" SelectMethod="GetInvestment"
                                        TypeName="DLInvestmentMaster"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBank" runat="server" SkinID="lbl" Text="Bank :"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp<asp:DropDownList ID="ddlBank" runat="server" DataSourceID="ObjBank" DataTextField="Bank_Name"
                                        DataValueField="Bank_IDAuto" AppendDataBoundItems="true" SkinID="ddl" TabIndex="2">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBank" runat="server" SelectMethod="GetBank" TypeName="DLInvestmentMasterReport">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Rate of Interest :"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp<asp:DropDownList ID="DdlRoi" runat="server" DataSourceID="ObjRoi" DataTextField="Rateofinterest"
                                        SkinID="ddl" AutoPostBack="true" DataValueField="IMAutoID" TabIndex="3" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjRoi" runat="server" SelectMethod="GetROI" TypeName="DLInvestmentMaster">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Balance Amount :"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp<asp:DropDownList ID="DdlbalAmt" runat="server" SkinID="ddl" TabIndex="4">
                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="0-5000"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="5001-25000"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="25001-50000"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="50001-200000"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="200001-500000"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="500001-1000000"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Width="200Px" Text="Start Date :" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp<asp:TextBox ID="txtfromdate" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="End Date :" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp<asp:TextBox ID="txttodate" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="btnTd">
                                    <asp:Button ID="btnReport" TabIndex="7" runat="server" Text="REPORT" SkinID="btn"
                                        CommandName="REPORT" CssClass="ButtonClass"></asp:Button>
                                    <asp:Button ID="btnBack" TabIndex="8" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass"
                                        CommandName="BACK"></asp:Button>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtfromdate"
                        Format="dd-MMM-yyyy" SkinID="Calendar">
                    </ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                        Format="dd-MMM-yyyy" SkinID="Calendar">
                    </ajaxToolkit:CalendarExtender>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
