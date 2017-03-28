<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_ReturnedChequeBalancReport.aspx.vb"
    Inherits="Rpt_ReturnedChequeBalancReport" Title="RETURNED CHEQUE BALANCE REPORT" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RETURNED CHEQUE BALANCE REPORT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel runat="Server">
        <ContentTemplate>
            <center>
            <br />
                <h1 class="headingTxt">
                    RETURNED CHEQUE REPORT
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBank" runat="server" Text="Bank :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlBank" runat="server" DataTextField="Bank_Name" DataSourceID="ObjBank"
                                DataValueField="Bank_IDAuto" SkinID="ddl" TabIndex="1" AppendDataBoundItems="True"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBank" runat="server" SelectMethod="Get_BankName" TypeName="PostDatedChequeRegister">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStartDate" runat="server" Text="Start Date :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150px"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txtStartDate" TabIndex="2" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="StartDate" runat="server" TargetControlID="txtStartDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEndDate" runat="server" Text="End Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" TabIndex="3" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="EndDate" runat="server" TargetControlID="txtEndDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </center>
            </br>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="9" Text="REPORT" Width="100px" />
                            &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="11"
                                Text="BACK" Width="100px" />
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
