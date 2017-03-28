<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLessonPlan.aspx.vb"
    Inherits="frmLessonPlan" Title="Lesson Plan" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Lesson Plan</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlCourse.ClientID%>"), 'Course');
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>");
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlSemester.ClientID%>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=ddlSemester.ClientID%>");
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlSubject.ClientID%>"), 'Subject');
            if (msg != "") {
                document.getElementById("<%=ddlSubject.ClientID%>");
                return msg;
            }
            msg = NameField250E(document.getElementById("<%=txtTopic.ClientID%>"), 'Topic');
            if (msg != "") {
                document.getElementById("<%=txtTopic.ClientID%>").focus();
                return msg;
            }
            msg = FeesField(document.getElementById("<%=txtTopicHours.ClientID%>"), 'Topic Hours');
            if (msg != "") {
                document.getElementById("<%=txtTopicHours.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtFromDate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtToDate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
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
            </a>
            <div>
                <center>
                    <h1 class="headingTxt">
                        LESSON PLAN</h1>
                </center>
                <br />
                <center>
                    <table>
                        <%--  <tr>
                            <td align="right">
                                <asp:Label ID="lblEmployee" runat="server" SkinID="lblRsz" Text="Employee Name*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEmployeeName" runat="server" AppendDataBoundItems="true"
                                    AutoPostBack="true" DataSourceID="ObjEmployee" DataTextField="EmpName" DataValueField="EmpID"
                                    SkinID="ddlRsz" TabIndex="1" Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmployee" runat="server" SelectMethod="GetEmployeeCombo"
                                    TypeName="LessonPlanDL"></asp:ObjectDataSource>
                            </td>
                        </tr>--%>
                        <%--<tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBatchName" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="LessonPlanDL">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcourse" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourse" runat="server" SkinID="ddlRsz" Width="250 px" DataSourceID="objCourse"
                                    TabIndex="1" DataTextField="CourseName" DataValueField="CourseCode" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseCombo1"
                                    TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="right">
                                <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" DataSourceID="ObjSemester"
                                    DataTextField="SemName" DataValueField="SemCode" SkinID="ddlRsz" TabIndex="3"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboD1"
                                    TypeName="LessonPlanDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                        </tr>--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSemester" runat="server" DataSourceID="ObjSemester" DataTextField="SemName"
                                    DataValueField="SemCode" SkinID="ddlRsz" TabIndex="2" Width="250" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboD2"
                                    TypeName="LessonPlanDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCourse" PropertyName="SelectedValue" Name="Course"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" DataSourceID="ObjSubject"
                                    DataTextField="Subject_Name" DataValueField="Subjectid" SkinID="ddlRsz" TabIndex="3"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject1" TypeName="LessonPlanDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCourse" PropertyName="SelectedValue" Name="Course"
                                            DbType="Int16" />
                                    </SelectParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSemester" PropertyName="SelectedValue" Name="Sem"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblUnit" runat="server" Text="Unit :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUnit" runat="server" SkinID="txtRsz" Width="250" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTopic" runat="server" Text="Topic* :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTopic" runat="server" TextMode="MultiLine" SkinID="txtRsz" TabIndex="5"
                                    Width="250px" Height="50px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblWeek" runat="server" Text="Week :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWeek" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblTopicHours" runat="server" Text="Topic Hours* :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTopicHours" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFromDate" runat="server" Text="From Date :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblToDate" runat="server" Text="To Date :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPortion" runat="server" Text="% Of Portion :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPortion" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtPortion" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="BtnAdd" runat="server" SkinID="btn" Text="ADD" OnClientClick="return Validate();"
                        TabIndex="10" CssClass="ButtonClass" />
                    <asp:Button ID="BtnView" runat="server" SkinID="btn" Text="VIEW" TabIndex="11" CssClass="ButtonClass" />
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
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
                    <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"> </asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"> </asp:Label>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="True"
                            AutoGenerateColumns="False" PageSize="100" AllowSorting="True">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            TabIndex="10" Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            TabIndex="11" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Week" SortExpression="week" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWeek" Width="100" runat="server" Text='<%# Bind("Week") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="From Date" SortExpression="FromDate" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFromDate" runat="server" Width="100" Text='<%# Bind("FromDate","{0:dd-MMM-yyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To Date" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblToDate" runat="server" Width="100" Text='<%# Bind("ToDate","{0:dd-MMM-yyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Topic" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTopic" runat="server" Width="200" Text='<%# Bind("Topic") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="left" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Topic Hours" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHours" runat="server" Text='<%# Bind("Hours","{0:0.00}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Portion" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPortion" runat="server" Text='<%# Bind("Portion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Batch"  HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCourseCode" runat="server" Width="100" Text='<%# Bind("CourseName") %>'></asp:Label>
                                        <asp:Label ID="lblcourse" runat="server" Visible="false" Text='<%# Bind("coursid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Semester" SortExpression="SemName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSem" runat="server" Width="100" Text='<%# Bind("SemName") %>'></asp:Label>
                                        <asp:Label ID="lblSemID" runat="server" Visible="false" Text='<%# Bind("SemID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name" Visible="false"
                                    HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="LPID" runat="server" Visible="false" Text='<%# Bind("LPAutoID") %>'></asp:Label>
                                        <%--<asp:Label ID="lblEmpName" runat="server" Width="175" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        <asp:Label ID="lblEmpID" runat="server" Visible="false" Text='<%# Bind("EmpID") %>'></asp:Label>--%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="True" />
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code" Visible="false" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>                                        
                                        <asp:Label ID="lblEmpCode" width="100" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>                                        
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="false" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Subject" SortExpression="Subject_Name" Visible="false"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                        <asp:Label ID="lblSubjectID" runat="server" Visible="false" Text='<%# Bind("SubjectID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="true" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image3" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
