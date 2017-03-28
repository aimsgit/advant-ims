<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmCreateExamCalendar.aspx.vb"
    Inherits="frmCreateExamCalendar" Title="Create Exam Calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Create Exam Calendar</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%= ddlExamBatch.ClientID %>"), 'Exam Batch');
            if (msg != "") {
                document.getElementById("<%= ddlExamBatch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%= ddlSubject.ClientID %>"), 'Subject');
            if (msg != "") {
                document.getElementById("<%= ddlSubject.ClientID %>").focus();
                return msg;
            }

            msg = ValidateDate(document.getElementById("<%= txtExamDate.ClientID %>"), 'Date of Exam');
            if (msg != "") {
                document.getElementById("<%= txtExamDate.ClientID %>").focus();
                return msg;
            }

            msg = Field50(document.getElementById("<%= txtExamTime.ClientID %>"), 'Time of Exam');
            if (msg != "") {
                document.getElementById("<%= txtExamTime.ClientID %>").focus();
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
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        function ValidView() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%= ddlExamBatch.ClientID %>"), 'Exam Batch');
            if (msg != "") {
                document.getElementById("<%= ddlExamBatch.ClientID %>").focus();
                return msg;
            }
            return true;
        }



        function ValidateView() {

            var msg = ValidView();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
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
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <%--   <center>
                    <h1 class="headingTxt">
                        ENTER STUDENT ATTENDANCE</h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
            </div>
            <br />
           
            <asp:Panel ID="ControlsPanel" runat="server">
             <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" Text="Exam Batch*^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                Style="margin-left: 0px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:DropDownList ID="ddlExamBatch" TabIndex="1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                DataValueField="ExamBatch_Autoid" DataTextField="ExamBatch" DataSourceID="ObjExamBatch"
                                Width="240">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjExamBatch" runat="server" SelectMethod="GetExamBatch"
                                TypeName="DLCreateExamCalendar"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label9" runat="server" Text="Subject* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="Date of Exam* :&nbsp;&nbsp;" SkinID="lblRsz"
                                meta:resourcekey="Label8Resource1"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Text="Time of Exam* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:DropDownList ID="ddlSubject" runat="server" SkinID="ddlRsz" DataSourceID="ObjSubject"
                                DataTextField="Subject_Name" DataValueField="Subject_Code" Width="250px" TabIndex="2">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboExam"
                                TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtExamDate" TabIndex="3" MaxLength="11" runat="server" SkinID="txt"
                                AutoPostBack="true"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtExamDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtExamTime" TabIndex="4" runat="server" MaxLength="50" SkinID="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <table>
                    <tr>
                        <td colspan="2" class="btnTd" style="height: 9px" align="center">
                           &nbsp; <asp:Button ID="btnSubmit" runat="server" TabIndex="5" CausesValidation="true" CssClass="ButtonClass"
                                OnClientClick="return Validate();" SkinID="btnRsz" Text="ADD" Width="75px" />
                           &nbsp; <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" TabIndex="6"
                                SkinID="btnrsz" Text="VIEW" Visible="true" Width="75px"/>
                           &nbsp; <asp:Button ID="btnPublish" runat="server" CssClass="ButtonClass" TabIndex="7" SkinID="btnRsz"
                                Text="PUBLISH" OnClientClick="return ValidateView();" Width="90px" />
                            &nbsp; <asp:Button ID="btnLockunlk" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btnRsz" Width="120" TabIndex="8" Text="LOCK/UNLOCK" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </center>
            <center>
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="770px" Height="300px">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:GridView ID="GridCreateExamCalendar" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="8"
                                                    CommandName="Edit" Text="Edit" />
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="9"
                                                    CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                    Text="Delete" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Batch" Visible="true" SortExpression ="Exam_Batch">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="lblID" runat="server" Value='<%# Bind("CreateExamCalendar_Auto_id") %>'>
                                                </asp:HiddenField>
                                                <asp:Label ID="lblGVBatchName" runat="server" Width="150px" Text='<%# Bind("ExamBatch") %>'></asp:Label>
                                                <asp:Label ID="lblGVBatch_ID" runat="server" Visible="false" Text='<%# Bind("Exam_Batch") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject Code" SortExpression="Subject_Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGVSubjectCode" runat="server" Text='<%# Bind("Subject_Code") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject Name" SortExpression="Subject_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGVSubject" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                                <asp:Label ID="lblGVSubject_Id" runat="server" Visible="false" Text='<%# Bind("Subject_Id")  %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date of Exam" SortExpression="DOE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGVDOE" runat="server" Text='<%# Bind("DOE","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Time of Exam">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGVTOE" Width="150px" runat="server" Text='<%# Bind("TOE") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText=" Lock Status" SortExpression="LockFlag">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLockFlag" runat="server" Text='<%# Bind("LockFlag") %>' Width="100"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="center" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </center>
            </asp:Panel> 
            <center>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false" DefaultButton="btnPassword" >
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password"></asp:TextBox>
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
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>