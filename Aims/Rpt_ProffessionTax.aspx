<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_ProffessionTax.aspx.vb" Inherits="Rpt_ProffessionTax" title="Professional Tax Report" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Professional Tax Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
        <%--<ContentTemplate>--%>
            <%--<a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>--%>
                <center>
                <br />
                <h1 class="headingTxt">
                   PROFESSIONAL TAX STATEMENT
                </h1>
                <br />
            </center>
           
            <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                        <asp:HiddenField ID="Hidyear" runat="server" />
                                        <asp:Label ID="lblLoanType" SkinID="lbl" runat="server" Text="Year*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        <asp:DropDownList ID="ddlYear" runat="server" DataTextField="Data" DataSourceID="ObjLoanType"
                                            DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="1" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjLoanType" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetYearDDL" TypeName="DLProffessionTax">
                                            </asp:ObjectDataSource>
                                   </tr>
                                    <tr>
                                    <td align="right">
                                        <asp:Label ID="lblMonth" runat="server" Text="Month*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                         <asp:DropDownList ID="ddlMonth" runat="server" SkinID="ddl" TabIndex="2" AutoPostBack="true">
                                         <asp:ListItem Text ="Select" Value ="Select"></asp:ListItem>
                                         <asp:ListItem Text ="January" Value ="January"></asp:ListItem>
                                          <asp:ListItem Text ="February" Value ="February"></asp:ListItem>
                                           <asp:ListItem Text ="March" Value ="March"></asp:ListItem>
                                            <asp:ListItem Text ="April" Value ="April"></asp:ListItem>
                                             <asp:ListItem Text ="May" Value ="May"></asp:ListItem>
                                              <asp:ListItem Text ="June" Value ="June"></asp:ListItem>
                                               <asp:ListItem Text ="July" Value ="July"></asp:ListItem>
                                                <asp:ListItem Text ="August" Value ="August"></asp:ListItem>
                                                 <asp:ListItem Text ="September" Value ="September"></asp:ListItem>
                                                  <asp:ListItem Text ="October" Value ="October"></asp:ListItem>
                                                   <asp:ListItem Text ="November" Value ="November"></asp:ListItem>
                                                    <asp:ListItem Text ="December" Value ="December"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                               </table>
                                </center>
                                <br />
                                <center>
                                <table>
                                <tr align="center">
                                    <td class="btnTd" style="height: 9px" align="center">
                                        <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="3" Text="REPORT"/>
                                        &nbsp; <asp:Button ID="btnBack" TabIndex="4" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                        </asp:Button>
                                    </td>
                                </tr>
                            </table>
                            </center> 
                            <center>
                            <table>
                                <tr align="center" >
                                    <td>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                               
                            </table>   
                  </center>
    </asp:Panel>               
  <%--  </ContentTemplate>               
  </asp:UpdatePanel> --%> 


</form>
</body>
</html>

