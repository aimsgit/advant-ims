<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptEmpMedicalDetails.aspx.vb"
    Inherits="FrmRptEmpMedicalDetails" Title="Employee Medical Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee Medical Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        EMPLOYEE MEDICAL DETAILS</h1>
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
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStdid" runat="server" SkinID="lblRsz" width="150px" Text="Employee Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="DdlEmp" runat="server" SkinID="ddlRsz" Width="200px" TabIndex="1"
                                    AppendDataBoundItems="true" DataValueField="EmpID" DataTextField="Emp_Code"
                                    DataSourceID="objEmp">
                                    <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objEmp" runat="server" SelectMethod="GetEmpcombo" TypeName="DLRptEmpMedicalDetails">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="2" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
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
                                        <asp:Label ID="msgin" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblSC" runat="server" SkinID="lblGreen"></asp:Label>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
