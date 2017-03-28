<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmExamSubjective.aspx.vb"
    Inherits="FrmExamSubjective" Title="Untitled Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlCourse.ClientID%>"), 'Course');

            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlSubject.ClientID%>"), 'Subject');

            if (msg != "") {
                document.getElementById("<%=ddlSubject.ClientID%>").focus();
                return msg;
            }

            msg = Field1(document.getElementById("<%=txtDuration.ClientID%>"), 'Duration');

            if (msg != "") {
                document.getElementById("<%=txtDuration.ClientID%>").focus();
                return msg;
            }
            msg = Field1(document.getElementById("<%=txtmins.ClientID%>"), 'Minute');

            if (msg != "") {
                document.getElementById("<%=txtmins.ClientID%>").focus();
                return msg;
            }
            msg = Field250(document.getElementById("<%=txtAnswerLength.ClientID%>"), 'Answer Length');
            if (msg != "") {
                document.getElementById("<%=txtAnswerLength.ClientID%>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtQName.ClientID%>"), 'Questions Name');
            if (msg != "") {
                document.getElementById("<%=txtQName.ClientID%>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtAnswer.ClientID%>"), 'Answer');
            if (msg != "") {
                document.getElementById("<%=txtAnswer.ClientID%>").focus();
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
                return true;
            }
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    Exam
                </h1>
            </center>
            &nbsp;
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblCourse" runat="server" Text="Course*  :&nbsp;&nbsp;" SkinID="lbl" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCourse" runat="server" DataTextField="CourseName" DataValueField="CourseCode"
                                DataSourceID="objCourse" AutoPostBack="true" SkinID="ddl" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseCombo"
                                TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSubject" runat="server" Text="Subject* :&nbsp;&nbsp;" SkinID="lbl" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSubject" runat="server" DataTextField="Subject_Name" DataSourceID="SubjectSelect"
                                DataValueField="Subjectid" SkinID="ddl">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="SubjectSelect" runat="server" SelectMethod="GetSubjectCombo"
                                TypeName="AdminExamDL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlCourse" PropertyName="SelectedValue" Name="Courseid" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDuration" runat="server" Text="Time*:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDuration" runat="server" SkinID="txtRsz" MaxLength ="2" Width ="42"></asp:TextBox>
                            Hrs
                            <asp:TextBox ID="txtmins" runat="server" SkinID="txtRsz" MaxLength ="2" 
                                Width ="42"></asp:TextBox>Mins
                              <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtDuration">
                    </ajaxToolkit:FilteredTextBoxExtender>
                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtmins">
                    </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblAnswerLength" runat="server" Text="Answer Length* :&nbsp;&nbsp;" width="180" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAnswerLength" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAnswerLength">
                    </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblQName" runat="server" Text="Questions Name* :&nbsp;&nbsp;" width="180" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtQName" runat="server" SkinID="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblAnswer" runat="server" Text="Answer* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" SkinID="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="btnTd" colspan="2">
                            <center>
                                <asp:Button ID="InsertButton" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                    SkinID="btn" Text="ADD" TabIndex="3" ValidationGroup="ADD" />
                                &nbsp;<asp:Button ID="btnDet" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="4" Text="VIEW" />
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
            </center>
            <br />
            <center>
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Edit"
                                                    Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                                    Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                <br />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Course">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCourse" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                                <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Bind("SubjectQues_AutoId") %>'></asp:Label>
                                                <asp:Label ID="lblCourseID" Visible="false" runat="server" Text='<%# Bind("Course") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubjectID" runat="server" Visible="false" Text='<%# Bind("Subject") %>'></asp:Label>
                                                <asp:Label ID="lblSubName" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Duration">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                                                :<asp:Label ID="lblMin" runat="server" Text='<%# Bind("Minute") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AnswerLength">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAnswerLength" runat="server" Text='<%# Bind("Ans_Length") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="QName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQName" runat="server" Text='<%# Bind("Ques_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Answer">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAnswer" runat="server" Text='<%# Bind("Answer") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </center>
            
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>
