<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_frmBudgetVariance.aspx.vb" Inherits="Rpt_frmBudgetVariance" title="budget Variance Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>budget Variance Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<center>        
                <br />
               <h1 class="headingTxt">
                   BUDGET VARIANCE REPORT
              </h1>
       </center>
                <br />
                <br />
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblProjectName" runat="server" Text="Project Name* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCompany" runat="server" DataTextField="Project_Name" DataSourceID="ObjProject"
                                        DataValueField="ProjectID_Auto" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true" Width ="250px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjProject" runat="server" SelectMethod="Get_ProjectName" TypeName="DLBudgetVariance">
                                     </asp:ObjectDataSource>
                                </td>
                          </tr>
                          <tr>
                                <td align="right">
                                    <asp:Label ID="lblRptDate" runat="server" Text="Report Date* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtStartDate" TabIndex="2" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="StartDate" runat="server" TargetControlID="txtStartDate" Format="dd-MMM-yyyy">
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
                                  
                                    <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="11"
                                        Text="BACK" Width="100px"/>
                                    
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                    </center>

</form>
</body>
</html>

