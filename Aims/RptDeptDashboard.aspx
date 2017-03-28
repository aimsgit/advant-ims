<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="RptDeptDashboard.aspx.vb"
    Inherits="RptDeptDashboard" Title="DEPARTMENT DASHBOARD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DEPARTMENT DASHBOARD</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        DEPARTMENT DASHBOARD</h1>
                    <br />
                    <br />
                </center>
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDept" runat="server" SkinID="lbl" Text="Department* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" AutoPostBack="true"
                                        DataTextField="DeptName" DataValueField="DeptID" SkinID="ddlRsz" TabIndex="1"
                                        AppendDataBoundItems="False" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjDept" runat="server" SelectMethod="GetDept" TypeName="BLDeptDashboard">
                                    </asp:ObjectDataSource>
                            </tr>
                        </table>
                        <br />
                        <table>
                            <tr>
                                <td colspan="4" class="btnTd">
                                    <asp:Button ID="Btnreport" runat="server" CausesValidation="True" CommandName="Report"
                                        Text="REPORT" SkinID="btn" TabIndex="4" CssClass="ButtonClass " />
                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn"
                                        TabIndex="5" Text="BACK" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </center>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
