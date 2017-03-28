<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmTimeTableCalender.aspx.vb"
    Inherits="frmTimeTableCalender" Title="TIME TABLE CALENDAR" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TIME TABLE CALENDAR</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlCourseName.ClientID%>"), 'Course');
            document.getElementById("<%=ddlCourseName.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID%>"), 'Batch');
            document.getElementById("<%=ddlBatchName.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlSemester.ClientID%>"), 'Semester');
            document.getElementById("<%=ddlSemester.ClientID%>").focus();
            if (msg != "") return msg;

            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <%--   <center>
                <h1 class="headingTxt">
                    TIME TABLE CALENDAR</h1>
               
            </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                    <br />
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblCourse" runat="server" SkinID="lblRsz" Text="Course*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:DropDownList ID="ddlCourseName" runat="server" DataSourceID="ObjCourse" AutoPostBack="true"
                                    DataTextField="CourseName" DataValueField="Courseid" SkinID="ddlRsz" Width="250px"
                                    AppendDataBoundItems="true" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourse" TypeName="CourseDB">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" Width="200px"
                                    TabIndex="2">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="TimeTableDl">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSemester" runat="server" DataSourceID="ObjSemester" DataTextField="SemName"
                                    DataValueField="SemCode" SkinID="ddlRsz" Width="180px" TabIndex="3" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                    TypeName="FeeCollectionBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblTeacher" runat="server" SkinID="lbl" Text="Teaching Staff&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:DropDownList ID="ddlTeacher" runat="server" DataSourceID="objTeacher" DataTextField="Emp_Name"
                                    DataValueField="Emp_Code" SkinID="ddlRsz" Width="220px" TabIndex="4" AppendDataBoundItems="true">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objTeacher" runat="server" SelectMethod="GetLecturercombo"
                                    TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSubject" runat="server" DataTextField="Subject_Name" DataValueField="Subject_Code"
                                    DataSourceID="ObjSubject" SkinID="ddlRsz" Width="250px" TabIndex="5">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject" TypeName="TimeTableDl">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" Name="Batchid" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="ddlSemester" Name="SemId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Button ID="BtnView" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="6" Text="VIEW" OnClientClick=" return Validate()" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
            </a><a name="bottom">
                <center>
                    <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                </center>
                <%-- <asp:Panel ID="GVPanel" runat="server" ScrollBars="Horizontal" Width="680px">--%>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Calendar ID="Calender1" runat="server" BackColor="White" BorderColor="Black"
                                OnDayRender="Calendar1_DayRender" BorderWidth="1px" FirstDayOfWeek="Monday" Font-Names="Verdana"
                                Font-Size="Medium" ForeColor="#663399" Height="261px" ShowGridLines="True" Width="625px"
                                BorderStyle="Double" CellSpacing="1">
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="false" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <WeekendDayStyle BackColor="Silver" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                <TodayDayStyle BackColor="#33CCFF" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <DayHeaderStyle BackColor="#FFFF99" Font-Bold="True" Height="1px" />
                                <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr align="left">
                        <td class="btnTd">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px"
                                Font-Bold="False" CellPadding="3" Font-Size="0.7em" ForeColor="Black" GridLines="Vertical"
                                Width="580px" Font-Italic="False" Font-Names="Arial" Height="19px" PageSize="100">
                                <HeaderStyle BackColor="#914800" BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px"
                                    Font-Bold="false" Font-Size="1.0em" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#D1BAAB" BorderColor="#914800" BorderStyle="Groove"
                                    BorderWidth="3px" Font-Size="1.0em" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Period">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeriod" runat="server" SkinID="lblG" Width="50px" Text='<%# Bind("Period") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day 1">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="SubId1" runat="server" Value='<%# Bind("SubjectID1") %>' />
                                            <asp:HiddenField ID="EmpId1" runat="server" Value='<%# Bind("TeacherID1") %>' />
                                            <asp:Label ID="Label2" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Subject_Name1") %>'></asp:Label>
                                            <asp:Label ID="Label3" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("TeacherName1") %>'></asp:Label>
                                            <asp:Label ID="Label37" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Remarks1") %>'></asp:Label>
                                            <asp:Label ID="Label30" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("ResourceName1") %>'></asp:Label>
                                            <asp:Label ID="Label4" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("StartTime1") %>'></asp:Label>
                                            <asp:Label ID="Label5" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("EndTime1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day 2">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="SubId2" runat="server" Value='<%# Bind("SubjectID2") %>' />
                                            <asp:HiddenField ID="EmpId2" runat="server" Value='<%# Bind("TeacherID2") %>' />
                                            <asp:Label ID="Label6" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Subject_Name2") %>'></asp:Label>
                                            <asp:Label ID="Label7" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("TeacherName2") %>'></asp:Label>
                                            <asp:Label ID="Label38" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Remarks2") %>'></asp:Label>
                                            <asp:Label ID="Label31" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("ResourceName2") %>'></asp:Label>
                                            <asp:Label ID="Label8" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("StartTime2")%>'></asp:Label>
                                            <asp:Label ID="Label9" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("EndTime2") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day 3">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="SubId3" runat="server" Value='<%# Bind("SubjectID3") %>' />
                                            <asp:HiddenField ID="EmpId3" runat="server" Value='<%# Bind("TeacherID3") %>' />
                                            <asp:Label ID="Label10" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Subject_Name3") %>'></asp:Label>
                                            <asp:Label ID="Label11" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("TeacherName3") %>'></asp:Label>
                                            <asp:Label ID="Label43" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Remarks3") %>'></asp:Label>
                                            <asp:Label ID="Label32" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("ResourceName3") %>'></asp:Label>
                                            <asp:Label ID="Label12" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("StartTime3") %>'></asp:Label>
                                            <asp:Label ID="Label13" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("EndTime3") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day 4">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="SubId4" runat="server" Value='<%# Bind("SubjectID4") %>' />
                                            <asp:HiddenField ID="EmpId4" runat="server" Value='<%# Bind("TeacherID4") %>' />
                                            <asp:Label ID="Label14" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Subject_Name4") %>'></asp:Label>
                                            <asp:Label ID="Label15" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("TeacherName4") %>'></asp:Label>
                                            <asp:Label ID="Label39" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Remarks4") %>'></asp:Label>
                                            <asp:Label ID="Label33" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("ResourceName4") %>'></asp:Label>
                                            <asp:Label ID="Label16" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("StartTime4") %>'></asp:Label>
                                            <asp:Label ID="Label17" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("EndTime4") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day 5">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="SubId5" runat="server" Value='<%# Bind("SubjectID5") %>' />
                                            <asp:HiddenField ID="EmpId5" runat="server" Value='<%# Bind("TeacherID5") %>' />
                                            <asp:Label ID="Label18" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Subject_Name5") %>'></asp:Label>
                                            <asp:Label ID="Label19" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("TeacherName5") %>'></asp:Label>
                                            <asp:Label ID="Label40" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Remarks5") %>'></asp:Label>
                                            <asp:Label ID="Label34" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("ResourceName5") %>'></asp:Label>
                                            <asp:Label ID="Label20" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("StartTime5") %>'></asp:Label>
                                            <asp:Label ID="Label21" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("EndTime5") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day 6">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="SubId6" runat="server" Value='<%# Bind("SubjectID6") %>' />
                                            <asp:HiddenField ID="EmpId6" runat="server" Value='<%# Bind("TeacherID6") %>' />
                                            <asp:Label ID="Label22" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Subject_Name6") %>'></asp:Label>
                                            <asp:Label ID="Label23" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("TeacherName6") %>'></asp:Label>
                                            <asp:Label ID="Label41" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Remarks6") %>'></asp:Label>
                                            <asp:Label ID="Label35" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("ResourceName6") %>'></asp:Label>
                                            <asp:Label ID="Label24" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("StartTime6") %>'></asp:Label>
                                            <asp:Label ID="Label25" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("EndTime6") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day 7">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="SubId7" runat="server" Value='<%# Bind("SubjectID7") %>' />
                                            <asp:HiddenField ID="EmpId7" runat="server" Value='<%# Bind("TeacherID7") %>' />
                                            <asp:Label ID="Label26" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Subject_Name7") %>'></asp:Label>
                                            <asp:Label ID="Label27" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("TeacherName7") %>'></asp:Label>
                                            <asp:Label ID="Label42" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("Remarks7") %>'></asp:Label>
                                            <asp:Label ID="Label36" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("ResourceName") %>'></asp:Label>
                                            <asp:Label ID="Label28" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("StartTime7") %>'></asp:Label>
                                            <asp:Label ID="Label29" runat="server" SkinID="lblG" Width="80px" Text='<%# Bind("EndTime7") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
            <%--  </asp:Panel>--%>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
