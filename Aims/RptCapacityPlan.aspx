<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptCapacityPlan.aspx.vb" Inherits="RptCapacityPlan" title="Capacity Plan" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Capacity Plan</title>
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
                         CAPACITY PLAN
                        </h1>
                        <br />
                    </center>
                    <br />
                    <br />
                    <center>
                     <%--<center>
                          <h1 class="headingTxt">
                                CAPACITY PLAN
                           </h1>
                     </center>--%>
                        <table>
                         <tr>
                            <td align="right">
                                <asp:Label ID="lblBranch" runat="server" SkinID="lblRsz" Text="Branch Name*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align ="left" >
                                <asp:DropDownList ID="ddlBrch" runat="server" AutoPostBack="True" DataSourceID="ObjBranch"
                                    DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="5"
                                    Width="250px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetBranchTypecombo1" TypeName="EmpTranferB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        
                         <tr>
                            <td align="right">
                                <asp:Label ID="lblYear" runat="server" Text="Year* :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtYearRelease" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                            </td>--%>
                            <td align ="left" >
                                <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                    DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="5" Width="160px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear1" TypeName="BLClientContractMaster">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                             <tr>
                                <td align="right">
                                    <asp:Label ID="lbldept" runat="server" Text="Department :&nbsp;&nbsp;" SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddldept" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="2" AppendDataBoundItems="true" DataValueField="DeptID" DataTextField="DeptName"
                                        DataSourceID="objDepartment" Width="200">
                                       </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objDepartment" runat="server" TypeName="SubjectDB" SelectMethod="Getdeptcombo2">
                                </asp:ObjectDataSource>
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
                                    <asp:Button ID="btnAdd" TabIndex="11" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                    </table>
                    <br />
                    <center>
                       <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />   
                    
                   <%--  <asp:ObjectDataSource ID="ObjBrach" runat="server" SelectMethod="GetBranchTypecombo" TypeName="EmpTranferB">
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                        </asp:ObjectDataSource>
                      <asp:ObjectDataSource ID="objDepart" runat="server" SelectMethod="SubjectDB" TypeName="Getdeptcombo"> 
                      </asp:ObjectDataSource> --%>
                         
                       
                     </ContentTemplate>
        </asp:UpdatePanel>
    </center>
                            

</form>
</body>
</html>
