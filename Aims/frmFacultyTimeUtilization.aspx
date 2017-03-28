<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmFacultyTimeUtilization.aspx.vb"
    Inherits="frmFacultyTimeUtilization" Title="Faculty Time Utilization " ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Faculty Time Utilization</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%= txtFaculity.ClientID %>"), 'Faculty');
            if (msg != "") {
                document.getElementById("<%= txtFaculity.ClientID %>").focus();
                return msg;
            }


            msg = ValidateDate(document.getElementById("<%= txtDate.ClientID %>"), 'Date');
            if (msg != "") {
                document.getElementById("<%= txtDate.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%= ddlCourseName.ClientID %>"), 'Course');
            if (msg != "") {
                document.getElementById("<%= ddlCourseName.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%= ddlBatchName.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%= ddlBatchName.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%= ddlSemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%= ddlSemester.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%= ddlSubject.ClientID %>"), 'Subject');
            if (msg != "") {
                document.getElementById("<%= ddlSubject.ClientID %>").focus();
                return msg;
            }


            msg = FeesField(document.getElementById("<%= txtHours.ClientID %>"), 'Hours');
            if (msg != "") {
                document.getElementById("<%= txtHours.ClientID %>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {

            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <%--      <center>
                    <h1 class="headingTxt">
                        FACULTY TIME UTILIZATION
                    </h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" Width="150px" runat="server" Text="Faculty* :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFaculity" runat="server" Enabled="false" SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="Date* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate" runat="server" MaxLength="11" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                            <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion" runat="server" TargetControlID="txtDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCoursegui" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCourseName" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                    DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="Courseid"
                                    SkinID="ddlRsz" Width="240 px" TabIndex="3">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblbatchgui" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBatchName" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="4"
                                    AppendDataBoundItems="false" Width="240">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSemestergui" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" DataSourceID="ObjSemester"
                                    DataTextField="SemName" DataValueField="SemCode" SkinID="ddlRsz" Width="240px"
                                    AppendDataBoundItems="false" TabIndex="5">
                                    <%--<asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblsubject" runat="server" Text="Subject*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubject" runat="server" DataSourceID="ObjSubject" AppendDataBoundItems="false"
                                    DataTextField="Subject_Name" DataValueField="Subject_Code" SkinID="ddlRsz" Width="240 px"
                                    TabIndex="6">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Text="Hours* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtHours" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                            </td>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterMode="validChars" FilterType="Custom" TargetControlID="txtHours" ValidChars=".0123456789">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="8"
                                    Text="ADD" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="9" Text="VIEW" />
                            </td>
                    </table>
                </center>
            </a><a name="bottom">
                <center>
                    <table>
                        <tr>
                            <td>
                                <br />
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
                </center>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <center>
                    <br />
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridFaculity" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="10"
                                                        CommandName="Edit" Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="11"
                                                        CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Employee Name" Visible="true">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="Label5" runat="server" Value='<%# Bind("FTUIDAuto") %>'></asp:HiddenField>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee code" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="Label21" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="Label5" runat="server" Value='<%# Bind("FTUIDAuto") %>'></asp:HiddenField>
                                                    <asp:Label ID="lbloffer" runat="server" Text='<%# Bind("Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course" SortExpression="CourseName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCourseID" runat="server" Text='<%# Bind("CourseID") %>' Visible="false" />
                                                    <asp:Label ID="lblCourse" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Batch" SortExpression="Batch_No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBatchid" runat="server" Text='<%# Bind("BatchID") %>' Visible="false" />
                                                    <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Semester" SortExpression="SemName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSemesterID" runat="server" Text='<%# Bind("semesterID") %>' Visible="false" />
                                                    <asp:Label ID="lblSemester" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject" SortExpression="Subject_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsubjectid" runat="server" Text='<%# Bind("Subject_Code") %>' Visible="false" />
                                                    <asp:Label ID="lblsubject" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hours" SortExpression="Hours">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHours" runat="server" Text='<%# Bind("Hours") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject" TypeName="TimeTableDl">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlBatchName" Name="Batchid" PropertyName="SelectedValue"
                                Type="Int16" />
                            <asp:ControlParameter ControlID="ddlSemester" Name="SemId" PropertyName="SelectedValue"
                                Type="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourse" TypeName="CourseDB">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="TimeTableDl">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                        TypeName="FeeCollectionBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                DbType="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </center>
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
