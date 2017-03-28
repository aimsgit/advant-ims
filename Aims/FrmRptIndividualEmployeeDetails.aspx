<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptIndividualEmployeeDetails.aspx.vb"
    Inherits="FrmRptIndividualEmployeeDetails" Title="Individual Employee Details Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Individual Employee Details Report</title>
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
                    INDIVIDUAL EMPLOYEE DETAILS
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
                                DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
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
                            <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept1" DataTextField="DeptName"
                                DataValueField="DeptID" SkinID="ddlL" AutoPostBack="True" TabIndex="2">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjDept1" runat="server" TypeName="DLRptIndividualEmployeeDetails"
                                SelectMethod="GetDepartment1">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DdlBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEmpType" runat="server" Text="Employment Type :&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlEmpType" runat="server" SkinID="ddlRsz" Width="200px" TabIndex="2"
                                AutoPostBack="True">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                <asp:ListItem Value="Permanent" Text="Permanent"></asp:ListItem>
                                                <asp:ListItem Value="Temporary" Text="Temporary"></asp:ListItem> 
                                                <asp:ListItem Value="Contract Basis" Text="Contract Basis"></asp:ListItem>
                                                <asp:ListItem Value="Casual" Text="Casual"></asp:ListItem>
                                                <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                                                <asp:ListItem Value="Fulltime" Text="Fulltime"></asp:ListItem>
                                                <asp:ListItem Value="Parttime" Text="Parttime"></asp:ListItem>
                                                <asp:ListItem Value="Visiting" Text="Visiting"></asp:ListItem>
                                                 <asp:ListItem Value="Honorary" Text="Honorary"></asp:ListItem>
						 <asp:ListItem Value="Assignment Basis" Text="Assignment Basis"></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblempcategory" runat="server" Width="180px" Text="Employee Category :&nbsp;"
                                SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlempcategory" runat="server" SkinID="ddlRsz" Width="200px"
                                TabIndex="3" AutoPostBack="True">
                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                <asp:ListItem Value="ACADEMIC" Text="ACADEMIC"></asp:ListItem>
                                <asp:ListItem Value="ACADEMIC SUPPORT" Text="ACADEMIC SUPPORT"></asp:ListItem>
                                <asp:ListItem Value="UNIVERSITY MEDICAL OFFICER" Text="UNIVERSITY MEDICAL OFFICER"></asp:ListItem>
                                <asp:ListItem Value="SENIOR EXECUTIVES" Text="SENIOR EXECUTIVES"></asp:ListItem>
                                <asp:ListItem Value="MIDDLE LEVEL EXECUTIVES" Text="MIDDLE LEVEL EXECUTIVES"></asp:ListItem>
                                <asp:ListItem Value="JUNIOR EXECUTIVES" Text="JUNIOR EXECUTIVES"></asp:ListItem>
                                <asp:ListItem Value="MANAGEMENT ASSISTANT (TECHNICAL/NON TECHNICAL)" Text="MANAGEMENT ASSISTANT (TECHNICAL/NON TECHNICAL)"></asp:ListItem>
                                <asp:ListItem Value="ASSOCIATE OFFICERS" Text="ASSOCIATE OFFICERS"></asp:ListItem>
                                <asp:ListItem Value="MANAGEMENT ASSISTANTS (NON TECHNICAL)" Text="MANAGEMENT ASSISTANTS (NON TECHNICAL)"></asp:ListItem>
                                <asp:ListItem Value="MANAGEMENT ASSISTANTS (TECHNICAL)" Text="MANAGEMENT ASSISTANTS (TECHNICAL)"></asp:ListItem>
                                <asp:ListItem Value="PRIMARY LEVEL (SKILLED)" Text="PRIMARY LEVEL (SKILLED)"></asp:ListItem>
                                <asp:ListItem Value="PRIMARY LEVEL (UN-SKILLED)" Text="PRIMARY LEVEL (UN-SKILLED)"></asp:ListItem>
                                <asp:ListItem Value="General" Text="General"></asp:ListItem>
                                <asp:ListItem Value="Faculty" Text="Faculty"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDesignation" runat="server" SkinID="lblRsz" Text="Designation :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlDesignation" runat="server" DataSourceID="ObjDesignation"
                                DataTextField="Designation" DataValueField="DesignationCode" SkinID="ddlRsz"
                                Width="200px" TabIndex="5">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjDesignation" runat="server" TypeName="DLRptIndividualEmployeeDetails"
                                SelectMethod="GetDesignation"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblQualification" runat="server" SkinID="lblRsz" Text="Qualification :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlQualification" runat="server" DataSourceID="ObjQualification"
                                DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddlRsz" Width="200px"
                                TabIndex="5">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjQualification" runat="server" TypeName="DLRptIndividualEmployeeDetails"
                                SelectMethod="GetQualification"></asp:ObjectDataSource>
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
                            <asp:ObjectDataSource ID="ObjEmpName" runat="server" TypeName="DLRptIndividualEmployeeDetails"
                                SelectMethod="GetEmpName1">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DdlBranchName" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                    <asp:ControlParameter ControlID="ddlDept" DefaultValue="0" Name="DeptId" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlEmpType" DefaultValue="0" Name="EmpType" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="ddlempcategory" DefaultValue="0" Name="EmpCat" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="ChkOhter" runat="server" TabIndex="6" 
                                Text=" Include Other Details like Qualification,&lt;br /&gt; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Experience,Research and Medical Details." />
                            <br />
                        </td>
                        <tr>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="Btnreport" runat="server" CausesValidation="True" 
                                    CssClass="ButtonClass " OnClientClick="return Validate();" SkinID="btn" 
                                    TabIndex="6" Text="REPORT" />
                                &nbsp;
                                <asp:Button ID="Btnback" runat="server" CausesValidation="True" 
                                    CssClass="ButtonClass " SkinID="btn" TabIndex="7" Text="BACK" />
                            </td>
                        </tr>
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
