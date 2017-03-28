<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmFacultyAllocation.aspx.vb"
    Inherits="FrmFacultyAllocation" Title="Faculty Allocation" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Faculty Allocation</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlCourse.ClientID%>"), 'Course');
            document.getElementById("<%=ddlCourse.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlBatch.ClientID%>"), 'Batch');
            document.getElementById("<%=ddlBatch.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=cmbSemester.ClientID%>"), 'Semester');
            document.getElementById("<%=cmbSemester.ClientID%>").focus();
            if (msg != "") return msg;

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerror.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerror.ClientID %>").textContent = msg;
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <%--<center>
                <h1 class="headingTxt">
                    FACULTY ALLOCATION
                </h1>
            </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table class="custTable">
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text="Course*&nbsp;:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <tr>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlCourse" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                            DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="Courseid"
                                            SkinID="ddlRsz" Width="240 px" TabIndex="1">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                            DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                            Width="190">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cmbSemester" runat="server" AutoPostBack="true" DataSourceID="ObjSemester"
                                            DataTextField="SemName" DataValueField="SemCode" SkinID="ddl" TabIndex="3">
                                        </asp:DropDownList>
                                    </td>
                                    <tr>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btngenerate" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            TabIndex="4" Text="GENERATE" Width="120px" OnClientClick="return Validate();" />
                                        <asp:Button ID="btnview" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            TabIndex="5" OnClientClick="return Validate();" SkinID="btn" Text="VIEW" />
                                        <asp:Button ID="btnclear" runat="server" CssClass="ButtonClass" SkinID="btn" Text="CLEAR"
                                            TabIndex="6" OnClientClick="return confirm('Do you want to delete the selected record(s)?')" />
                                        <%--<asp:Button ID="BTNUPDATE" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="7" Text="UPDATE" Width="120px" />--%>
                                        <asp:Button ID="BTNLOCK" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            TabIndex="8" OnClientClick="return Validate();" SkinID="btnRsz" Text="LOCK/UNLOCK"
                                            Width="150px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
                                <tr align="center">
                                    <td>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                        <asp:Label ID="lblerror" runat="server" SkinID="lblRed" />
                                        <asp:ObjectDataSource ID="objTeacher" runat="server" SelectMethod="GetLecturercombo"
                                            TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourse" TypeName="CourseDB">
                                        </asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="TimeTableDl">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlCourse" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                            TypeName="FeeCollectionBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlBatch" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
            </a><a name="bottom">
                <center>
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                                            AllowPaging="true" EnableViewState="true" EnableSortingAndPagingCallbacks="false"
                                            PageSize="100">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Update"
                                                            Font-Underline="False" Text="Update" TabIndex="3"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subject">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PKID") %>' Visible="False"></asp:Label>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("SemesterID") %>' Visible="False"></asp:Label>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("BatchID") %>' Visible="False"></asp:Label>
                                                        <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Hours">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbltotalhours" runat="server" Text='<%# Bind("TotalHours") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lock Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblLockStatus" runat="server" Text='<%# Bind("LockStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Faculty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabLrecturer1" runat="server" Text='<%# Bind("TeacherID1") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="L1" runat="server" Text='<%# Bind("Emp_Name1") %>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="DdlLecture1" runat="server" AppendDataBoundItems="true" DataSourceID="objTeacher"
                                                            DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Width="200px">
                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hours">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Hours1" runat="server" SkinID="lblRsz" Width="50px" Text='<%# Bind("Hour1") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Faculty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabLrecturer2" runat="server" Text='<%# Bind("TeacherID2") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="L2" runat="server" Text='<%# Bind("Emp_Name2") %>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="DdlLecture2" runat="server" AppendDataBoundItems="true" DataSourceID="objTeacher"
                                                            DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Width="200px">
                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hours">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Hours2" runat="server" SkinID="lblRsz" Width="50px" Text='<%# Bind("Hour2") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Faculty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabLrecturer3" runat="server" Text='<%# Bind("TeacherID3") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="L3" runat="server" Text='<%# Bind("Emp_Name3") %>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="DdlLecture3" runat="server" AppendDataBoundItems="true" DataSourceID="objTeacher"
                                                            DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Width="200px">
                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hours">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Hours3" runat="server" SkinID="lblRsz" Width="50px" Text='<%# Bind("Hour3") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Faculty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabLrecturer4" runat="server" Text='<%# Bind("TeacherID4") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="L4" runat="server" Text='<%# Bind("Emp_Name4") %>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="DdlLecture4" runat="server" AppendDataBoundItems="true" DataSourceID="objTeacher"
                                                            DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Width="200px">
                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hours">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Hours4" runat="server" SkinID="lblRsz" Width="50px" Text='<%# Bind("Hour4") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </center>
                </asp:Panel>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" OnTextChanged="btnPassword_click"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                                            OnClientClick="btnPassword_click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblpassError" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                </asp:Panel>
                <br />
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
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
