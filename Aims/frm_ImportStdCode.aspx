<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_ImportStdCode.aspx.vb"
    Inherits="frm_ImportStdCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IMPORT STUDENT CODE</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
    <body>
        <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
        <asp:UpdatePanel ID="Updatepanel1" runat="server">
            <ContentTemplate>
                <a name="Top">
                    <div align="right">
                        <a href="#Bottom">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" />
                        </a>
                    </div>
                </a>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <td align="right">
                                <asp:TextBox ID="txtData" runat="server" Enabled="True" TextMode="MultiLine" Width="300px"
                                    Height="300px"></asp:TextBox>
                            </td>
                        </table>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <center>
                                        <asp:Button ID="btnimport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="IMPORT"
                                            CommandName="IMPORT" TabIndex="1" />
                                        &nbsp;<asp:Button ID="btnclear" runat="server" SkinID="btn" CssClass="ButtonClass"
                                            TabIndex="2" CommandName="CLEAR" Text="CLEAR" />
                                        &nbsp;<asp:Button ID="btnupdate" runat="server" SkinID="btn" CssClass="ButtonClass"
                                            TabIndex="3" CommandName="UPDATE" Text="UPDATE" />
                                        <br />
                                        <br />
                                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                            <ProgressTemplate>
                                                <div class="PleaseWait">
                                                    <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <br />
                                        <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                                        <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                                    </center>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <center>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GVImport" runat="server" SkinID="GridView" Visible="True" Width="256px"
                                        PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Width="250px" Text='<%# Bind("Name") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Academic Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Batch Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Width="150px" Text='<%# Bind("Batch") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Temporary Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelStdCode" runat="server" Text='<%# Bind("TemporaryNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="University Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelStdname" runat="server" Text='<%# Bind("UniversityNumber") %>'></asp:Label>
                                                    <itemstyle wrap="false" horizontalalign="left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" Width="256px"
                                        PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Academic Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Width="250px" Text='<%# Bind("A_Code") %>' />
                                                    <itemstyle wrap="True" horizontalalign="left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Batch No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Width="150px" Text='<%# Bind("StdName") %>'></asp:Label>
                                                    <itemstyle wrap="True" horizontalalign="left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Temporary Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelStdCode" runat="server" Text='<%# Bind("TemporaryNumber1") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="University Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelStdname" runat="server" Text='<%# Bind("UniversityNumber2") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                            <a name="bottom">
                                <div align="right">
                                    <a href="#top">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                                </div>
                            </a>
                        </div>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </form>
    </body>
</html>
