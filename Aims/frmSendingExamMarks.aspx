<%@ Page Title="Sending marks" Language="VB"  AutoEventWireup="false"
    CodeFile="frmSendingExamMarks.aspx.vb" Inherits="frmSendingExamMarks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sending marks</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch No');
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlsemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=ddlsemester.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlass.ClientID %>"), 'Assessment Type');
            if (msg != "") {
                document.getElementById("<%=ddlass.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <a name="Top">
                    <div align="right">
                        <a href="#Bottom">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    </div>
                    <div>
                        <center>
                            <h1 class="headingTxt">
                                <asp:Label ID="LabelStdrc" runat="server" Text="PUBLISH EXAMINATION MARKS BY MAIL/ SMS"
                                    SkinID="lblRepRsz" Width="500" Visible="True"></asp:Label>
                            </h1>
                        </center>
                        <br />
                        <br />
                        <center>
                            <table class="custTable">
                                <tbody>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" Width="91px" Text="Batch*&nbsp:&nbsp&nbsp"
                                                SkinID="lbl"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                                DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="2"
                                                Width="240px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchsendmarksddl"
                                                TypeName="DLSendExamMarks"></asp:ObjectDataSource>
                                        </td>
                                        <td align="left" rowspan="2" valign="top">
                                            <asp:CheckBox ID="ChkMarks" runat="server" Text="Marks" Value="1" Font-Bold="true"
                                                Width="70px" />
                                            <br />
                                            <asp:CheckBox ID="CheckSMS" runat="server" Text="SMS" Value="3" Font-Bold="true"
                                                Width="50px" />
                                            <%--<br />--%>
                                        </td>
                                        <td align="left" rowspan="2" valign="top">
                                            <asp:CheckBox ID="ChkAttendance" runat="server" Text="Attendance" Value="2" Font-Bold="true"
                                                Width="130px" />
                                            <br />
                                            <asp:CheckBox ID="CheckEmail" runat="server" Text="Email" Value="4" Font-Bold="true"
                                                Width="100px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblsem" runat="server" Width="150px" Text="Semester*&nbsp:&nbsp&nbsp"
                                                SkinID="lblrsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlsemester" SkinID="ddlRsz" runat="server" DataSourceID="ObjSemester"
                                                DataTextField="SemName" DataValueField="SemCode" AutoPostBack="True" TabIndex="3"
                                                Width="240px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="GetSemesterSendMarks"
                                                TypeName="DLSendExamMarks">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                                        DbType="Int16" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblass" runat="server" Width="200px" Text="Assessment Type*&nbsp:&nbsp&nbsp"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:DropDownList ID="ddlass" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                                TabIndex="5" DataSourceID="Objass" DataTextField="AssessmentType" DataValueField="ID"
                                                Width="240">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="Objass" runat="server" SelectMethod="GetassessmentAllDDl"
                                                TypeName="DLSendExamMarks"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblPreMsg" runat="server" Width="200px" Text="Pre-fix Message&nbsp:&nbsp&nbsp"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtPreMsg" TabIndex="1" runat="server" Height="90px" TextMode="MultiLine" SkinID="txtRsz" Width="340px" >
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                  
                                </tbody>
                            </table>
                        </center>
                        <center>
                            <table>
                                <tbody>
                                    <tr>
                                        <td class="btnTd">
                                            <asp:LinkButton ID="LinkMsgHistory" runat="server" Text="MSG HISTORY" cssproperty="Btnclass"
                                                Font-Underline="true" Font-Bold="true"></asp:LinkButton>
                                            <asp:Button ID="btnViewMsg" runat="server" OnClientClick="return Validate();" Text="VIEW MSG"
                                                CommandName="VIEW" SkinID="btnRsz" Width="100px" CssClass="ButtonClass"></asp:Button>
                                            <asp:Button ID="btnSendMsg" CommandName="SEND" runat="server" Text="SEND MSG" SkinID="btnRsz"
                                                Width="100px" CssClass="ButtonClass"></asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </center>
                        <div>
                            <center>
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            Processing your request..please wait...
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </center>
                        </div>
                        </center>
                        <br />
                        <center>
                            <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                        </center>
                        <br />
                        <center>
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="700px" Height="350px">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" PageSize="100"
                                    SkinID="GridView" TabIndex="-1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                    Text="All" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkSelect" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblScode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <%--  <ItemStyle Wrap="false" />--%>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Student Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <%-- <ItemStyle Wrap="false" />--%>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSContact" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                                <asp:Label ID="lblFContact" runat="server" Text='<%# Bind("FatherContact") %>'></asp:Label>
                                            </ItemTemplate>
                                            <%--<ItemStyle Wrap="false" />--%>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="E-Mail">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSMail" runat="server" Text='<%# Bind("Std_email") %>'></asp:Label>
                                                <asp:Label ID="lblFMail" runat="server" Text='<%# Bind("FatherEmail") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Message" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSem" runat="server" Text='<%# Bind("Subject") %>' Visible="true"
                                                    Width="500px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="true" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </center>
                        <a name="Bottom">
                            <div align="right">
                                <a href="#Top">
                                    <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="Images/top.png" Width="30px" />
                                </a>
                            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>