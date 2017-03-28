<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptProjectMaster.aspx.vb"
    Inherits="FrmRptProjectMaster" Title="Project Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Project Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = ValidateDateN(document.getElementById("<%=txtfromdate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtfromdate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txttodate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txttodate.ClientID%>").focus();
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
                return true;
            }
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <br />
                    <h1 class="headingTxt">
                        PROJECT MASTER</h1>
                        <br />
                        <br />
                </center>
                <%--<table>
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
                </table>--%>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server"  width="100px" Text="From Date:" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtfromdate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="To Date:" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txttodate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="3" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="4" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
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

</form>
</body>
</html>
