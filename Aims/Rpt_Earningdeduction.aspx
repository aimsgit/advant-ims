<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_Earningdeduction.aspx.vb" Inherits="Rpt_Earningdeduction" title="MONTHLY DETAILS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MONTHLY DETAILS</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DdlBranchName.ClientID %>"), 'Branch Name');
            if (msg != "") {
                document.getElementById("<%=DdlBranchName.ClientID %>");
                return msg;
                msg = DropDownForZero(document.getElementById("<%=ddlYear.ClientID %>"), 'Year');
                if (msg != "") return msg;
                msg = DropDownForZero(document.getElementById("<%=ddlMonth.ClientID %>"), 'Month');
                if (msg != "") return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    MONTHLY DETAILS
                </h1>
                <br />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBranchName" runat="server" Text="Branch Name*&nbsp;:&nbsp;" SkinID="lbl"
                                Width="100px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlBranchName" TabIndex="1" runat="server" SkinID="ddlL" AutoPostBack="True"
                                DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode" >
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="SelectBranch" TypeName="DLBranchAccessLevel"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                DataValueField="DeptID" SkinID="ddlL" AutoPostBack="True" TabIndex="2">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLRptEarnDed"
                                SelectMethod="GetDepartment">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DdlBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                       <td align="right">
                                <asp:Label ID="lblEarnDedType" runat="server" SkinID="lblRsz" Text="Earn/Ded Type*&nbsp;:&nbsp;&nbsp;" Width="150px"></asp:Label>
                            </td>
                           <td align="left">
                                <asp:DropDownList ID="ddlEarnDed" runat="server" SkinID="ddl" TabIndex="4">
                                    <asp:ListItem Value ="E">E</asp:ListItem>
                                    <asp:ListItem value="D">D</asp:ListItem>
                                </asp:DropDownList>
                            </td> 
                    </tr>
                    
                    
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEmpName" runat="server" SkinID="lblRsz" Text="Employee Name :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlEmpName" runat="server" DataSourceID="ObjEmpName" DataTextField="Emp_Name"
                                DataValueField="EmpID" SkinID="ddlRsz" Width="200px" TabIndex="5">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjEmpName" runat="server" TypeName="DLRptEarnDed"
                                SelectMethod="GetEmpName">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DdlBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlDept" DefaultValue="0" Name="DeptId" PropertyName="SelectedValue"
                                        Type="String" />
                                   
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblyear" runat="server" SkinID="lblRSZ" Text="Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                            </asp:ObjectDataSource>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                            <asp:Label ID="lblmonth" runat="server" SkinID="lblRSZ" Text="Month&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlMonth" runat="server" SkinID="ddl" TabIndex="3">
                                <asp:ListItem Text="January" Value="January"></asp:ListItem>
                                <asp:ListItem Text="February" Value="February"></asp:ListItem>
                                <asp:ListItem Text="March" Value="March"></asp:ListItem>
                                <asp:ListItem Text="April" Value="April"></asp:ListItem>
                                <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                <asp:ListItem Text="June" Value="June"></asp:ListItem>
                                <asp:ListItem Text="July" Value="July"></asp:ListItem>
                                <asp:ListItem Text="August" Value="August"></asp:ListItem>
                                <asp:ListItem Text="September" Value="September"></asp:ListItem>
                                <asp:ListItem Text="October" Value="October"></asp:ListItem>
                                <asp:ListItem Text="November" Value="November"></asp:ListItem>
                                <asp:ListItem Text="December" Value="December"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                             
                    </tr>
                    </table>
                    <table >
       
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                Text="REPORT" SkinID="btn" TabIndex="6" CssClass="ButtonClass " />&nbsp;
                            <asp:Button ID="Btnback" runat="server" CausesValidation="True" SkinID="btn" TabIndex="7"
                                Text="BACK" CssClass="ButtonClass " />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

