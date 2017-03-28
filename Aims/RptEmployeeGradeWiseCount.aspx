<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptEmployeeGradeWiseCount.aspx.vb" Inherits="RptEmployeeGradeWiseCount" title="Employee Grade Wise Count" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee Grade Wise Count</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<center>
           <%-- By JINAPRIYA S --%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <br />
                        <h1 class="headingTxt">
                         EMPLOYEE GRADE WISE SUMMARY COUNT 
                        </h1>
                        <br />
                        <br />
                    </center>
                    <center>
                     <%--<center>
                          <h1 class="headingTxt">
                                  EMPLOYEE GRADE WISE SUMMARY COUNT 
                           </h1>
                     </center>--%>
                        <table>
                         <tr>
                            <td align="right">
                                <asp:Label ID="lblBranch" runat="server" SkinID="lblRsz" Text="Branch Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align ="left" >
                                <asp:DropDownList ID="ddlBrch" runat="server" AutoPostBack="True" DataSourceID="ObjBranch"
                                    DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="5"
                                    Width="250px">
                                    <asp:ListItem Text="ALL" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetBranchAllcombo" TypeName="EmpDesgB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                          <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                       <tr>
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="9" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnBack" TabIndex="11" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                     </table>
                    <br />
                    <center>
                       <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />          
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
                            
</form>
</body>
</html>
