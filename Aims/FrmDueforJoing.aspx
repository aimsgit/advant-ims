<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmDueforJoing.aspx.vb"
    Inherits="FrmDueforJoing" Title="EMPLOYEE ELIGIBILITY REPORT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>EMPLOYEE ELIGIBILITY REPORT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <%--<script type="text/javascript" language="javascript">
        function ValidReport() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=Ddlmonth.ClientID %>"), 'Month');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlYear.ClientID %>"), 'Year');
            if (msg != "") return msg;

            return true;
        }
        function ValidateReport() {

            var msg = ValidReport();
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
    </script>--%>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <h1 class="headingTxt">
                    EMPLOYEE ELIGIBILITY REPORT
                </h1>
                <br />
                <br />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" SkinID="lblRSZ" Text="Month&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="Ddlmonth" runat="server" SkinID="ddlRsz" Width="160px" TabIndex="1">
                                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                <asp:ListItem Text="December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" SkinID="lblRSZ" Text="Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="2" Width="160px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="DLDueJoining">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" SkinID="lblRSZ" Text="Eligibility For&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="Ddlbased" runat="server" SkinID="ddlRsz" TabIndex="3" Width="160px"
                                AutoPostBack="true">
                                <asp:ListItem Text="Joining Date" Value="A"></asp:ListItem>
                                <asp:ListItem Text="Revised Date" Value="B"></asp:ListItem>
                                <asp:ListItem Text="Retirement Date" Value="C"></asp:ListItem>
                                <asp:ListItem Text="Gratuity" Value="D"></asp:ListItem>
                                <asp:ListItem Text="Increment" Value="E"></asp:ListItem>
                                <asp:ListItem Text="Promotion" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Pension" Value="G"></asp:ListItem>
                                <asp:ListItem Text="Uniform" Value="H"></asp:ListItem>
                                <asp:ListItem Text="Age" Value="I"></asp:ListItem>
                                <asp:ListItem Text="Service Period" Value="J"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblcriteria" runat="server" SkinID="lblRSZ" Text="Criteria(In Years)&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtcriteria" runat="server" SkinID="txtRSZ" TabIndex="4" Width="155px"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="'0123456789" TargetControlID="txtcriteria">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" SkinID="lblRSZ" Text="Criteria for Age & Service Period."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="3">
                            <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                TabIndex="5" />&nbsp;
                            <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="6"
                                Text="BACK" Visible="true" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr align="center">
                        <td>
                            <asp:Label ID="lblRed" runat="server" SkinID="lblRed" />
                            <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </center>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>