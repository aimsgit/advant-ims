<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PopFile.aspx.vb" Inherits="PopFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Selection</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="height: 400px; width: 500px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<script src="js/Tvalidate.js" type="text/javascript"> </script>
            <script language="javascript">
                function changeparent(checkedCheckBox) {
                    if (window.opener != null && !window.opener.closed) {
                        try {
                            window.opener.setValue(checkedCheckBox);
                        }
                        catch (e) { alert(e.description); }
                    }
                    self.close();
                }
                function closechild() {
                    window.returnValue = "";
                    window.close();
                } 
            </script>

            <center>
                <br />
                <h1 class="headingPop">
                    <%--<asp:Label ID="Lblheading" runat="server"></asp:Label>--%>
                    File Selection
                </h1>
            </center>
            <center>
                <center>
                    <br />
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbldesc" runat="server" Text="Description^  :&nbsp;" SkinID="lblRsz"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtdesc" runat="server" SkinID="txtRsz" Width="200px" TextMode="MultiLine"
                                    TabIndex="2"></asp:TextBox>
                                <asp:HiddenField ID="HidtxtId" runat="server"></asp:HiddenField>
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
                        <tr>
                            <td class="btnTd" align="center">
                                <asp:Button ID="btnsearch" runat="server" CssClass="ButtonClass" SkinID="btn" Text="SEARCH"
                                    TabIndex="8" />
                            </td>
                        </tr>
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
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblR" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblG" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tbody>
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="450px" Height="150px">
                                        <asp:GridView ID="gvdoc" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                            PageSize="100" SkinID="GridView" Style="overflow: auto; width: 250px" Visible="True"
                                            Width="450px">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="false">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkBx" runat="server" TabIndex="4" AutoPostBack="true"></asp:CheckBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsemname" runat="server" Text='<%# Bind("Description") %>' Width="250px"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="True" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Link">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFid" Visible="false" runat="server" Text='<%# Bind("FID") %>' />
                                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("Link") %>' Text='<%# Eval("Link") %>'></asp:HyperLink>
                                                        <asp:HiddenField ID="lbllink" runat="server" Value='<%# Bind("Link") %>'></asp:HiddenField>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td class="btnTd" align="center">
                                <asp:Button ID="btnOK" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                                    TabIndex="8" />
                                &nbsp
                                <asp:Button ID="btnClose" runat="server" CssClass="ButtonClass" SkinID="btn" Text="CLOSE"
                                    OnClientClick="javascript:closechild();" TabIndex="8" />
                            </td>
                        </tr>
                    </table>
                </center>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
