<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStudentExamSubject.aspx.vb"
    Inherits="frmStudentExamSubject" Title="Student Exam Subject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Exam Subject</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <asp:Panel ID="Panel3" runat="server" Visible="True">
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstdcode" runat="server" Text="Student Code :&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblstdcode1" runat="server" SkinID="lblrsz" Width="300px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstdname" runat="server" Text="Student Name :&nbsp;" SkinID="lblRsz"
                                    Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblstdname1" runat="server" SkinID="lblrsz" Width="300px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </asp:Panel>
            <br />
            <br />
            <center>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnview" runat="server" Text="VIEW" CssClass="ButtonClass" SkinID="btn"
                                TabIndex="3" />
                            <asp:Button ID="btnupdate" runat="server" Text="UPDATE" CssClass="ButtonClass" SkinID="btn"
                                TabIndex="4" />
                            <asp:Button ID="btnhall" runat="server" Text="HALL TICKET" CssClass="ButtonClass"
                                SkinID="btnrsz" TabIndex="5" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
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
            <br />
            <center>
                <div>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Height="300px" Width="750px">
                        <asp:GridView ID="GvSubjects" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100">
                            <Columns>
                                <asp:TemplateField HeaderText="Subject Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubjectid" Visible="false" runat="server" Text='<%# Bind("Subject_Id") %>'></asp:Label>
                                        <asp:Label ID="lblsubjectcode" runat="server" Text='<%# Bind("Subject_Code") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="250px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExamBatch" Visible="false" runat="server" Text='<%# Bind("Exam_Batch") %>'></asp:Label>
                                        <asp:Label ID="lblsubjectname" Visible="True" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="250px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <%--  <asp:CheckBox ID="ChkAll1" runat="server" AutoPostBack="true" TabIndex="3" OnCheckedChanged="CheckAllGv1" />--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSelect1" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>
                                        <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <br />
                </div>
            </center>
            <a name="Bottom">
                <div align="right">
                    <a href="#Top">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
