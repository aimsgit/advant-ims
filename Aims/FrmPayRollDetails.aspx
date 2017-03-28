<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmPayRollDetails.aspx.vb"
    Inherits="FrmPayRollDetails" Title="New Payroll Details" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>New Payroll Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
        </a>
        <div class="mainBlock">
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
        </div>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmployee" runat="server" SkinID="lblRsz" Width="200" Text="Employee*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbEmployee" runat="server" DataTextField="Emp_Name" AutoPostBack="True"
                                    DataSourceID="ObjEmployee" DataValueField="EmpID" TabIndex="1" AppendDataBoundItems="true"
                                    SkinID="ddlRsz" Width="220px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblED" runat="server" Text="Earning/ Deduction*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="200"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbEarDed" TabIndex="2" runat="server" DataValueField="LookUpAutoID"
                                    DataTextField="Data" DataSourceID="ObjEarningDeduction" SkinID="ddlRsz" Width="220px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAmount" runat="server" Text="Amount*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="200"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAmount" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            </td>
                            </tr>
                            
                        <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="From Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtStartDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text=" To Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="EDate" runat="server" TargetControlID="txtEndDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                            <td></td>
                             <td align="left">
                                                <asp:CheckBox ID="ChkBoxHeader" SkinID="chk" TabIndex="11" Text="Stop Salary" runat="server" Checked="false" />
                                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" align="center">
                               &nbsp; <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                    CommandName="ADD" OnClientClick="return Validate();" SkinID="btn" TabIndex="4"
                                    Text="ADD" />
                               &nbsp; <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                    Text="VIEW" CommandName="VIEW" Visible="true" />
                               &nbsp; <asp:Button ID="btnReport" TabIndex="6" runat="server" Text="VIEW ALL" SkinID="btnRsz"
                                        CssClass="ButtonClass" Width="100"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="center">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                            </td>
                        </tr>
                        <div>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                    </table>
                    </a> <a name="bottom">
                              <hr />
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="800px" Height="300px">
                            <div>
                                <table>
                                    <tr>
                                        <td valign ="top" >
                                            <asp:GridView ID="GVPayRollDetails1" runat="server" Width="350px" SkinID="GridView"
                                                AllowPaging="true" AutoGenerateColumns="False" Visible="true" PageSize="100"
                                                AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                Text="Edit" SkinID="btn" />
                                                            <asp:LinkButton ID="btndel" runat="server" CausesValidation="false" CommandName="Delete"
                                                                Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                                        <itemstyle wrap="False"/ >
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Earning Code" SortExpression ="Code" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                        <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Bind("PayrollAutoId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" SortExpression ="Data" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("Data") %>' />
                                                              <asp:Label ID="lbldat" runat="server" Visible="false" Text='<%# Bind("LookUpAutoID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("Amount","{0:n2}") %>' />
                                                            <asp:Label ID="lblEmp" runat="server" Visible="false" Text='<%# Bind("EmpID") %>' />
                                                           <%--  <asp:Label ID="lblFromdate" runat="server" Visible="false" Text='<%# Bind("FromDate","{0:dd-MMM-yyyy}") %>' />
                                                              <asp:Label ID="lblTodate" runat="server" Visible="false" Text='<%# Bind("ToDate","{0:dd-MMM-yyyy}") %>' />--%>
                                                               <asp:Label ID="lblsalaryStop" runat="server" Visible="false" Text='<%# Bind("StopSalary") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="FromDate" ControlStyle-Width="75px">
                                                        <ItemTemplate>
                                                           
                                                             <asp:Label ID="lblFromdate" runat="server" Visible="True" Text='<%# Bind("FromDate", "{0:dd-MMM-yyyy}") %>' />
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="ToDate" ControlStyle-Width="75px">
                                                        <ItemTemplate>
                                                           
                                                           
                                                              <asp:Label ID="lblTodate" runat="server" Visible="True" Text='<%# Bind("ToDate", "{0:dd-MMM-yyyy}") %>' />
                                                             
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                
                            </td>
                                        <td valign ="top">
                                            <asp:GridView ID="GVPayRollDetails2" runat="server" Width="350px" SkinID="GridView"
                                                AllowPaging="true" AutoGenerateColumns="False" Visible="true" PageSize="100"
                                                AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                Text="Edit" SkinID="btn" />
                                                            <asp:LinkButton ID="btndel" runat="server" CausesValidation="false" CommandName="Delete"
                                                                Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                                 <itemstyle wrap="False"/ >
                                               
                                                        </ItemTemplate >
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Deduction Code" SortExpression="Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                        <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Bind("PayrollAutoId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" SortExpression="Data">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("Data") %>' />
                                                              <asp:Label ID="lbldat" runat="server" Visible="false" Text='<%# Bind("LookUpAutoID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("Amount","{0:n2}") %>' />
                                                            <asp:Label ID="lblEmp" runat="server" Visible="false" Text='<%# Bind("EmpID") %>' />
                                                             <%--<asp:Label ID="lblFromdate1" runat="server" Visible="false" Text='<%# Bind("FromDate","{0:dd-MMM-yyyy}") %>' />
                                                              <asp:Label ID="lblTodate1" runat="server" Visible="false" Text='<%# Bind("ToDate","{0:dd-MMM-yyyy}") %>' />--%>
                                                               <asp:Label ID="lblsalaryStop1" runat="server" Visible="false" Text='<%# Bind("StopSalary") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="FromDate">
                                                        <ItemTemplate>
                                                           
                                                             <asp:Label ID="lblFromdate1" runat="server" Visible="True" Text='<%# Bind("FromDate", "{0:dd-MMM-yyyy}") %>' />
                                                             
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="ToDate">
                                                        <ItemTemplate>
                                                           
                                                              <asp:Label ID="lblTodate1" runat="server" Visible="True" Text='<%# Bind("ToDate", "{0:dd-MMM-yyyy}") %>' />
                                                             
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <asp:ObjectDataSource ID="ObjEmployee" runat="server" SelectMethod="EmployeeCombo"
                            TypeName="PayRollNewDL"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjEarningDeduction" runat="server" SelectMethod="EarningDeduction"
                            TypeName="PayRollNewDL"></asp:ObjectDataSource>
                </center>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                </a>
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</form>
</body>
</html>
