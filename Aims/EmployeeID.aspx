<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EmployeeID.aspx.vb"
    Inherits="EmployeeID" Title="Employee ID Card" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee ID Card</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=CmbBranch.ClientID %>"), 'Branch Name');
            if (msg != "") return msg;

        }


        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;

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
            <div>
                <center>
                    <h1 class="headingTxt">
                        EMPLOYEE ID CARD
                    </h1>
                    <br />
                    <br />
                </center>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblbranch" runat="server" SkinID="lbl" Text="Branch Name* :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="CmbBranch" TabIndex="2" runat="server" SkinID="ddlRsz" Width="250"
                                    AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBranch" runat="server" SelectMethod="SelectBranch" TypeName="DLBranchAccessLevel">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="250" TabIndex="1" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" SelectMethod="DeptCombo" TypeName="EmployeeDB">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmpName" runat="server" SkinID="lblRsz" Width="150" Text="Employee Name :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEmpname" TabIndex="2" runat="server" SkinID="ddlRsz" Width="250"
                                    DataSourceID="ObjEmpName" DataTextField="Emp_Name" DataValueField="EmpID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmpName" runat="server" SelectMethod="EmpIDCombo" TypeName="EmployeeDB">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="CmbBranch" PropertyName="SelectedValue" Name="BranchCode" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnReport" runat="server" Text="REPORT" SkinID="btn" TabIndex="4"
                                    ValidationGroup="Submit" CssClass="ButtonClass" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnBack" runat="Server" Text="BACK" SkinID="btn" TabIndex="3" CssClass="ButtonClass" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
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
