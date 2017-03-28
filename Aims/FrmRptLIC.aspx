<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptLIC.aspx.vb"
    Inherits="FrmRptLIC" Title="Local Inspection Committee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Local Inspection Committee</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                <br />
                    <h1 class="headingTxt">
                        LOCAL INSPECTION COMMITTEE </h1>
                </center>
                <table>
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
                </table>
                <center>
                <table>
           <%--         <table class="custTable">--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department :" SkinID="lblRsz" ></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" width = "150" TabIndex="1">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="4" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass"></asp:Button>
                                &nbsp;<asp:Button ID="btnBack" TabIndex="5" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
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
                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLLIC" SelectMethod="GetDeptTypeAllN">
                                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
