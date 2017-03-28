<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptPaid_UnpaidLeaveAppliction.aspx.vb" Inherits="RptPaid_UnpaidLeaveAppliction" title="EMPLOYEE LEAVE DETAILS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>EMPLOYEE LEAVE DETAILS</title>
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
                        EMPLOYEE LEAVE DETAILS</h1>
                </center>
                <center>
                    <br />
                    <br />
                    <table id="table1" class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="200" TabIndex="1" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" SelectMethod="DeptCombo" TypeName="EmployeeDB">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmp" runat="server" Text="Employee :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEmp" TabIndex="2" runat="server" SkinID="ddlRsz" DataValueField="EmpID"
                                    DataTextField="Emp_Name" DataSourceID="ObjEmp" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmp" runat="server" SelectMethod="ddlEmpDeptwise" TypeName="EmployeeDB">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlDept" PropertyName="SelectedValue" Name="DeptID"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                      
                       
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFrmDate" runat="server" SkinID="lblRSZ" Text=" From Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFrmDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFrmDate"
                                    Format="dd-MMM-yyyy" Animated="False">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblToDate" runat="server" SkinID="lblRSZ" Text=" To Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTodate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTodate"
                                    Format="dd-MMM-yyyy" Animated="False">
                                </ajaxToolkit:CalendarExtender>
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
                                <asp:Button ID="btnSumRpt" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="11" Text="REPORT" Visible="true"  />
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
                            &nbsp;
                        </caption>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>


