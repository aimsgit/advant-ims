<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptLogin.aspx.vb"
    Inherits="RptLogin" Title="Login Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<body style="width: 800px; height: 800px">

    &nbsp;<script type="text/javascript" language="javascript">
              function Valid() {
                  var msg;

                  msg = ValidateDate(document.getElementById("<%=txtFrmDate.ClientID %>"), 'From Date');
                  if (msg != "") return msg;
                  msg = ValidateDate(document.getElementById("<%=txtToDate.ClientID %>"), 'To Date');
                  if (msg != "") return msg;
                  return true;
              }
              function Validate() {
                  var msg = Valid();
                  if (msg != true) {
                      if (navigator.appName == "Microsoft Internet Explorer") {
                          document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                          document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                          return false;
                      }
                      else if (navigator.appName == "Netscape") {
                          document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
                          document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                          return false;
                      }
                  }
                  return true;
              }
                  
     
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            LOGIN DETAILS
                        </h1>
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblInstitute" runat="server" SkinID="lblRsz" Text="Institute :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlInstitute" runat="server" AppendDataBoundItems="true" DataSourceID="objInstitute"
                                        DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="1"
                                        AutoPostBack="true" Width="250px">
                                        <%--<asp:ListItem Text="ALL" Value="0"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranch" runat="server" SkinID="lblRsz" Text="Branch :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="objBranch" AutoPostBack="false" SkinID="ddlRsz"
                                        DataTextField="CenterBranchName" Width="250px" DataValueField="CenterBranchCode">
                                        <asp:ListItem Value="0" Selected="True">All</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFrmDate" runat="server" SkinID="lblRsz" Text="From Date* :&nbsp;&nbsp;"
                                        EnableViewState="False" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFrmDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="calFrmDate" runat="server" TargetControlID="txtFrmDate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblToDate" runat="server" SkinID="lblRsz" Text="To Date* :&nbsp;&nbsp;"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalToDate" runat="server" TargetControlID="txtToDate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="2" runat="server" Text="REPORT" SkinID="btn"
                                        OnClientClick="return Validate();" CssClass="ButtonClass"></asp:Button>
                                    <asp:Button ID="btnAdd" TabIndex="2" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <center>
                            <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                        </center>
                        <asp:ObjectDataSource ID="objInstitute" runat="server" SelectMethod="InstCombo" TypeName="DlLoginReport">
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="objBranch" runat="server" SelectMethod="BranchCombo" TypeName="DlLoginReport">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlInstitute" Name="BranchCode" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>