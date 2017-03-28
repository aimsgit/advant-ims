<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptEmpAttenRegister.aspx.vb"
    Inherits="RptEmpAttenRegister" Title="EMPLOYEE ATTENDANCE REGISTER" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>EMPLOYEE ATTENDANCE REGISTER</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <br />
                    <h1 class="headingTxt">
                        EMPLOYEE ATTENDANCE REGISTER</h1>
                </center>
                <center>
                    <br />
                    <br />
                    <table id="table1" class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Department&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="200" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" SelectMethod="DeptCombo" TypeName="EmployeeDB">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Employee&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEmp" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="EmpID" DataTextField="Emp_Name" DataSourceID="ObjEmp" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmp" runat="server" SelectMethod="ddlEmp" TypeName="EmployeeDB">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMonth" runat="server" Text="From Month&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFrmMonth" TabIndex="8" runat="server" AutoPostBack="True"
                                    SkinID="ddlRsz" AppendDataBoundItems="False" Width="160">
                                    <%--   <asp:ListItem Text="All" Value="0"></asp:ListItem>--%>
                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="To Month&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlToMonth" TabIndex="8" runat="server" AutoPostBack="True"
                                    SkinID="ddlRsz" AppendDataBoundItems="False" Width="160">
                                    <%--   <asp:ListItem Text="All" Value="0"></asp:ListItem>--%>
                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lblRSZ" Text=" From Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFromYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                    DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" SkinID="lblRSZ" Text=" To Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlToYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                    DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td class="btnTd" align="center">
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="11"
                                    Text="REPORT FOR ATTENDANCE" Visible="true" Width="250"/>
                                     <asp:Button ID="BtnWorking" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="11"
                                    Text="REPORT FOR WORKINGHOURS" Visible="true" Width="250"/>
                                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="12" Text="BACK" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" BackColor="Green" ForeColor="White"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <div>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </div>
                        <caption>
                            &nbsp;<%--<asp:RequiredFieldValidator id="RequiredFieldValidator1" tabIndex="1" runat="server" ValidationGroup="Submit" ErrorMessage="Subject Field Null" ControlToValidate="cmbBatch">*</asp:RequiredFieldValidator>--%>
                            <%--<tr>
                                <td>
                                    <center>
                                        <div>
                                            <asp:ValidationSummary ID="ValidationSummary4" runat="server" DisplayMode="List"
                                                EnableTheming="false" EnableViewState="false" ShowMessageBox="true" ShowSummary="false"
                                                TabIndex="1" ValidationGroup="Save" />
                                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" EnableViewState="False"
                                                TabIndex="-1" ValidationGroup="Submit" />
                                        </div>
                                    </center>
                                </td>
                            </tr>--%>
                        </caption>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>