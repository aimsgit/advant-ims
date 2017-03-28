<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmQuestionBank.aspx.vb"
    Inherits="FrmQuestionBank" Title="Question Bank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Question Bank</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }

        function Valid() {

            var msg, a;
            msg = ValidateDateMul(document.getElementById("<%=txtDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtDate.ClientID %>").focus();
                a = document.getElementById("<%=lbldate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourse.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID %>").focus();
                a = document.getElementById("<%=lblcourse.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSubject.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlSubject.ClientID %>").focus();
                a = document.getElementById("<%=lblSubject.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownMul(document.getElementById("<%=ddlQType.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlQType.ClientID %>").focus();
                a = document.getElementById("<%=lblQType.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = OneCharMul(document.getElementById("<%=txtQNo.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtQNo.ClientID %>").focus();
                a = document.getElementById("<%=lblQNo.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField250Mul(document.getElementById("<%=txtQuestion.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtQuestion.ClientID %>").focus();
                a = document.getElementById("<%=lblQuestion.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }

        function ErrorMessage(msg) {
            var SesVar = '<%= Session("Validation") %>';
            var ValidationArray = new Array();
            ValidationArray = SesVar.split(":");
            for (var i = 0; i < ValidationArray.length - 1; i++) {
                if (ValidationArray[i] == msg) {
                    return ValidationArray[i + 1];
                }
            }
        }


        function Spliter(a) {
            var str = a;
            var n = str.indexOf("*");
            if (n != 0 && n != -1) {
                a = a.split("*");
                return a[0];
            }
            var n = str.indexOf("^");
            if (n != 0 && n != -1) {
                a = a.split("^");
                return a[0];
            }
            var n = str.indexOf(":");
            if (n != 0 && n != -1) {
                a = a.split(":");
                return a[0];
            }
        }
        
        
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <div>
        <center>
            <h1 class="headingTxt">
                <asp:Label ID="Lblheading" runat="server"></asp:Label>
            </h1>
        </center>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="Upload" />
                <asp:AsyncPostBackTrigger ControlID="Btnadd" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbldate" runat="server" Text="Date* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate" TabIndex="1" runat="server" SkinID="txt" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtDate" Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcourse" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourse" runat="server" SkinID="ddlRsz" Width="250 px" DataSourceID="objCourse"
                                    TabIndex="2" DataTextField="CourseName" DataValueField="CourseCode" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseCombo1"
                                    TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" DataSourceID="ObjSubject"
                                    DataTextField="Subject_Name" DataValueField="Subjectid" SkinID="ddlRsz" TabIndex="3"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject12"
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
                                <asp:Label ID="lblQType" runat="server" SkinID="lbl" Text="Question Type* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlQType" runat="server" SkinID="ddl" TabIndex="4">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="Subjective">Subjective</asp:ListItem>
                                    <asp:ListItem Value="Objective">Objective</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblQNo" runat="server" Text="Question Number* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="120px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtQNo" runat="server" SkinID="txtRsz" TabIndex="5" Width="105"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSubQuesNo" runat="server" SkinID="txtRsz" TabIndex="5" Width="105"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </center>
                <hr />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblQuestion" runat="server" Text="Question* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtQuestion" runat="server" SkinID="txtRsz" TabIndex="6" Width="250"
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td align="right" rowspan="4">
                                <asp:Label ID="lblImage" runat="server" Text="Q_Pic :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                <br />
                                <asp:Button ID="Upload" runat="server" CssClass="ButtonClass" SkinID="btn" Text="UPLOAD"
                                     CommandName="UPLOAD" />
                            </td>
                            <td align="left" rowspan="4">
                                <asp:Image ID="ImageMap1" runat="server" ImageUrl="~/Images/imageupload.gif" Style="width: 100px;
                                    height: 100px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAnswer" runat="server" Text="Answer* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAnswer" runat="server" SkinID="txtRsz" TabIndex="7" Width="250"
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="right">
                                <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="White" SkinID="btn" />
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtpath" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
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
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnadd" runat="server" Text="ADD" SkinID="btn" CausesValidation="true"
                                    CommandName="ADD" TabIndex="8" OnClientClick="return Validate();" CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="btnDet" runat="server" Text="VIEW" SkinID="btn" CausesValidation="False"
                                    CommandName="VIEW" TabIndex="9" CssClass="ButtonClass" />
                                <asp:Button ID="Btnposttostock" runat="server" Text="POST" CssClass="ButtonClass "
                                    CausesValidation="true" SkinID="btn" TabIndex="10" CommandName="POST" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <center>
                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <asp:GridView ID="GvQuesbank" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            SkinID="GridView" Width="300px" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editbutton" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" />
                                        <asp:LinkButton ID="deletebutton" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="center">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                            Width="50px" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkRL" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPostStatus" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("QuesBank_AutoId") %>'>
                                        </asp:HiddenField>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Q_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Course">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCourseId" runat="server" Text='<%# Bind("Course") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubjectId" runat="server" Text='<%# Bind("Subject") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblSubjectname" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ques Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuesType" runat="server" Text='<%# Bind("Ques_Type") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ques No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuesNo" runat="server" Text='<%# Bind("Question_No") %>' Width="20"></asp:Label>
                                        <asp:Label ID="lblSubQuesNo" runat="server" Text='<%# Bind("SubQuesNo") %>' Width="20"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Question">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuestion" runat="server" Text='<%# Bind("Question") %>' Width="150"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Diagram" ControlStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Image ID="LabelPhotos" ImageUrl='<%# Bind("Diagram") %>' runat="server"></asp:Image>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Answer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAnswer" runat="server" Text='<%# Bind("Answer") %>' Width="150"></asp:Label>
                                        <asp:Label ID="LabelPhotos1" runat="server" Text='<%# Bind("Diagram") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                    </div>
                </a>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</form>
</body>
</html>
