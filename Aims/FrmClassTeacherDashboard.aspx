<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmClassTeacherDashboard.aspx.vb"
    Inherits="FrmClassTeacherDashboard" Title="Faculty/Class Teacher Dashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Faculty/Class Teacher Dashboard</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

   <%-- <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlEmpname.ClientID %>"), 'Employee Name');
            if (msg != "") {
                document.getElementById("<%=ddlEmpname.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>--%>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmpName" runat="server" SkinID="lblRsz" Width="150" Text="Employee Name :&nbsp;"></asp:Label>
                            </td>
                            <%--<td>
                                <asp:DropDownList ID="ddlEmpname" TabIndex="2" runat="server" SkinID="ddlRsz" Width="200"
                                    DataSourceID="ObjEmpName" DataTextField="Emp_Name" DataValueField="EmpID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmpName" runat="server" SelectMethod="NewEmployeeComboforClassDashboard"
                                    TypeName="EmployeeDB"></asp:ObjectDataSource>
                            </td>--%>
                              <td align="left">
                                <asp:Label ID="lblempname1" runat="server" SkinID="lblRszB" style="background :white;" BorderStyle ="solid" BorderWidth ="1px" BorderColor ="#7F9DB9" Font-Bold="false" ForeColor ="Black"      Width="150"  ></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td class="btnTd" colspan="4">
                                <asp:Button ID="btnGenerate" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                     SkinID="btnRsz" TabIndex="4" Text="GENERATE" />
                                &nbsp;
                                <asp:Button ID="BtnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                    Text="BACK" />
                                &nbsp;
                            </td>
                        </tr>
                        <br />
                    </table>
                </center>
                </a>
                <br />
                <div>
                    <center>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                            <ProgressTemplate>
                                <div class="PleaseWait">
                                    Processing your request..please wait...
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </center>
                </div>
                <br />
                
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <asp:Label ID="lblStudentsta" runat="server" SkinID="lblRsz" Text="Student Statistics for the Class"></asp:Label>
                <br/><br/>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="100px">
                        <asp:GridView ID="GridclassTeacherDashBoard" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="100" SkinID="GridView" Width="368px">
                            <Columns>
                                <asp:TemplateField HeaderText="Course" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCoursename" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Batch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbatchNo" runat="server" Text='<%# Bind("Batch_No")  %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No Of Boys">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaleCount" runat="server" Text='<%# Bind("MaleCount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No Of Girls">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFemalecount" runat="server" Text='<%# Bind("FemaleCount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total No.Of Student">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalstudent" runat="server" Text='<%# Bind("TotalStudent") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <br/><br/>
                <asp:Label ID="lblList" runat="server" SkinID="lblRsz" Text="Subject Assigned to Teacher/Faculty"></asp:Label>
                <center>
                 <br/>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="100px">
                        <asp:GridView ID="GVSubjectHours" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="100" SkinID="GridView" Width="368px">
                            <Columns>
                                <asp:TemplateField HeaderText="Batch" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbatch" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Semester">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsemname" runat="server" Text='<%# Bind("SemName")  %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hours">
                                    <ItemTemplate>
                                        <asp:Label ID="lblhours" runat="server" Text='<%# Bind("TotalHours") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <asp:Label ID="lblTimetable" runat="server" SkinID="lblRsz" Text="Teacher/Faculty Time Table for Week"></asp:Label>
                <center>
                    <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <asp:GridView ID="GvTimeTable" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            AllowSorting="True" EnableSortingAndPagingCallbacks="True" BackColor="White"
                            BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" CellPadding="3"
                            Font-Size="0.8em" ForeColor="Black" GridLines="Vertical" PageSize="100">
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle BackColor="#914800" BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px"
                                Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#D1BAAB" BorderColor="#914800" BorderStyle="Groove"
                                BorderWidth="3px" Font-Size="1.0em" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False" Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Font-Underline="False" Text="Edit" Visible="false"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" Visible="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Period" SortExpression="Period">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Period") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 1 - Mon">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Subject_Name1") %>'></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("TeacherName1") %>'></asp:Label>
                                        <asp:Label ID="Label31" runat="server" Text='<%# Bind("ResourceName1") %>'></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("StartTime1") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("EndTime1") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 2 - Tue">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Subject_Name2") %>'></asp:Label>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("TeacherName2") %>'></asp:Label>
                                        <asp:Label ID="Label32" runat="server" Text='<%# Bind("ResourceName2") %>'></asp:Label>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("StartTime2")%>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("EndTime2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 3 - Wed">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Subject_Name3") %>'></asp:Label>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("TeacherName3") %>'></asp:Label>
                                        <asp:Label ID="Label33" runat="server" Text='<%# Bind("ResourceName3") %>'></asp:Label>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("StartTime3") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("EndTime3") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 4 - Thu">
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("Subject_Name4") %>'></asp:Label>
                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("TeacherName4") %>'></asp:Label>
                                        <asp:Label ID="Label34" runat="server" Text='<%# Bind("ResourceName4") %>'></asp:Label>
                                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("StartTime4") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("EndTime4") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 5 - Fri">
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("Subject_Name5") %>'></asp:Label>
                                        <asp:Label ID="Label19" runat="server" Text='<%# Bind("TeacherName5") %>'></asp:Label>
                                        <asp:Label ID="Label35" runat="server" Text='<%# Bind("ResourceName5") %>'></asp:Label>
                                        <asp:Label ID="Label20" runat="server" Text='<%# Bind("StartTime5") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label21" runat="server" Text='<%# Bind("EndTime5") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 6 - Sat">
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text='<%# Bind("Subject_Name6") %>'></asp:Label>
                                        <asp:Label ID="Label23" runat="server" Text='<%# Bind("TeacherName6") %>'></asp:Label>
                                        <asp:Label ID="Label36" runat="server" Text='<%# Bind("ResourceName6") %>'></asp:Label>
                                        <asp:Label ID="Label24" runat="server" Text='<%# Bind("StartTime6") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label25" runat="server" Text='<%# Bind("EndTime6") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 7 - Sun">
                                    <ItemTemplate>
                                        <asp:Label ID="Label26" runat="server" Text='<%# Bind("Subject_Name7") %>'></asp:Label>
                                        <asp:Label ID="Label27" runat="server" Text='<%# Bind("TeacherName7") %>'></asp:Label>
                                        <asp:Label ID="Label37" runat="server" Text='<%# Bind("ResourceName") %>'></asp:Label>
                                        <asp:Label ID="Label28" runat="server" Text='<%# Bind("StartTime7") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label29" runat="server" Text='<%# Bind("EndTime7") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>
