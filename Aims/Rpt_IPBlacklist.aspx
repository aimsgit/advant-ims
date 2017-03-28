<%@ Page Title="IP Tracking Report" Language="VB" AutoEventWireup="false" CodeFile="Rpt_IPBlacklist.aspx.vb" Inherits="Rpt_IPBlacklist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IP Tracking Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
  <script src="js/Tvalidate.js" type="text/javascript"> </script>  
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

        <center>
            <h1 class="headingTxt">
                IP TRACKING REPORT
            </h1>
        </center>
        <br />
        <br />
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCountry" runat="server" Text="Country :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCountry" TabIndex="1" runat="server" SkinID="ddlRsz" Width="200"
                                DataSourceID="ObjCountry" AppendDataBoundItems="true" 
                                DataTextField="Country">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCountry" runat="server" SelectMethod="GetCountry"
                                TypeName="DL_IP"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="IblUser" runat="server" Text="User :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlUser" runat="server" SkinID="ddl" TabIndex="4" Width="80">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="Y">Y</asp:ListItem>
                                    <asp:ListItem Value="N">N</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFdate" runat="server" Text="Start Date :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                             <asp:TextBox ID="txtSdate" runat="server" SkinID="txt" TabIndex="1" ></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="cltxtAttdDate1" runat="server" TargetControlID="txtSdate"
                                        Format="dd-MMM-yyyy" SkinID=" ">
                                    </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEDate" runat="server" SkinID="lbl" Text="End Date :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                             <asp:TextBox ID="txtEdate" runat="server" SkinID="txt" TabIndex="1" ></asp:TextBox>
                               <ajaxToolkit:CalendarExtender ID="cltxtAttdDate" runat="server" TargetControlID="txtEdate"
                                        Format="dd-MMM-yyyy" SkinID=" ">
                                    </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnreport" runat="server" Text="REPORT" SkinID="btn" CausesValidation="true"
                                    TabIndex="5"  CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="btnBack" runat="server" Text="BACK" SkinID="btn" CausesValidation="False"
                                    TabIndex="6" CssClass="ButtonClass" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <center>
                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</form>
</body>
</html>


