<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSelectElective.aspx.vb"
    Inherits="frmSelectElective" Title="Select Elective" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Select Elective</title>
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
                                <asp:Label ID="lblstdname" runat="server" Text="Student Name :&nbsp;" SkinID="lblRsz"
                                    Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblstdname1" runat="server" SkinID="lblRsz" Width="300px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstdcode" runat="server" Text="Student Code :&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblstdcode1" runat="server" SkinID="lblRsz"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcourse" runat="server" Text="Course :&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblcourse1" runat="server" SkinID="lblRsz" Width="300px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblbatch" runat="server" Text="Batch :&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblbatch1" runat="server" SkinID="lblRsz" Width="300px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblsem" runat="server" Text="Semester :&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblsem1" runat="server" SkinID="lblRsz" Width="300px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <br />
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Table" AutoPostBack="True">
                                    <asp:ListItem Text="Options Only   " Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Electives and Options" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
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
                            <asp:Button ID="btnview" runat="server" Text="SUBMIT" CssClass="ButtonClass" CausesValidation="true"
                                SkinID="btn" TabIndex="4" />
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
                <%-- <div style="float: right; width: 50px">--%>
                <table width="750px">
                    <tr align="right">
                        <td align="right">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblcredit" runat="server" Text="Total Credit:&nbsp;&nbsp;" SkinID="lbl" Visible="false"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtGrade" runat="server" TabIndex="2" Width="60px" Visible="false" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div>--%>
                <div>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Height="300px" Width="750px">
                        <asp:GridView ID="GvOptions" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <%--<asp:CheckBox ID="ChkAll1" runat="server" AutoPostBack="true" TabIndex="3" OnCheckedChanged="CheckAllGv1" />--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSelect1" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>
                                        <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4" OnCheckedChanged="AddCredit"
                                            AutoPostBack="true"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubjectid" runat="server" Text='<%# Bind("Subjectid") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblsubjectname" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="250px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pre-Requisite">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpre" Visible="True" runat="server" Text='<%# Bind("Pre_Requisites") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="250px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Credit Point">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcredit" runat="server" SkinID="txtRsz" Width="60px" MaxLength="3"
                                            TabIndex="20" Text='<%# Bind("Credit") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100">
                            <Columns>
                                <asp:TemplateField HeaderText="Elective">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="Labelective" Visible="false" runat="server" Text='<%# Bind("Subjectid") %>'></asp:Label>--%>
                                        <%--<asp:Label ID="lblelective" Visible="false" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>--%>
                                        <asp:DropDownList ID="ddlelective" runat="server" SkinID="ddlRsz" Width="240" TabIndex="25"
                                            AppendDataBoundItems="true" DataValueField="Subjectid" DataTextField="Subject_Name"
                                            DataSourceID="objelective">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" Visible="false" runat="server" Text='<%# Bind("ElectiveID") %>'></asp:Label>
                                        <%--<asp:Label ID="Laboption" Visible="false" runat="server" Text='<%# Bind("Subjectid") %>'></asp:Label>--%>
                                        <%--<asp:Label ID="lbloption" Visible="false" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>--%>
                                        <asp:DropDownList ID="ddloption" runat="server" SkinID="ddlRsz" Width="240" TabIndex="25"
                                            AppendDataBoundItems="true" DataValueField="Subjectid" DataTextField="Subject_Name"
                                            DataSourceID="objoption" OnSelectedIndexChanged="optionchanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pre-Requisite">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprequ" Visible="True" runat="server" Text=''></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="250px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Credit Point">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcred" runat="server" SkinID="txtRsz" Text='' Width="60px" MaxLength="3"
                                            TabIndex="20"></asp:Label>
                                        <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtSequence">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="objelective" runat="server" SelectMethod="ddlelective"
                        TypeName="DLSelectElective"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="objoption" runat="server" SelectMethod="ddloption" TypeName="DLSelectElective">
                    </asp:ObjectDataSource>
                    <br />
            </center>
            </div> <a name="Bottom">
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