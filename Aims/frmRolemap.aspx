<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmRolemap.aspx.vb"
    Inherits="frmRolemap" Title="Role Map" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Role Map</title>
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
                <div>
                    <center>
                        <h1 class="headingTxt">
                            ROLE MAP</h1>
                    </center>
                    <center>
                        <table class="custTable">
                            <tbody>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtRFID" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lbluserrole" runat="server" SkinID="lbl" Text="User Role :&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLuserrole" runat="server" DataSourceID="objuserrole" SkinID="ddl"
                                            DataValueField="RoleCode" AutoPostBack="true" DataTextField="UserRole" TabIndex="1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnupdate" runat="server" Text="UPDATE" SkinID="btn" TabIndex="5"
                                            CssClass="ButtonClass " />
                                        <asp:Button ID="btnview" runat="server" Text="VIEW" SkinID="btn" TabIndex="2" CssClass="ButtonClass " />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                    <center>
                        <br />
                        <table>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblgreen" runat="server" SkinID="lblGreen"></asp:Label>
                                    </center>
                                </td>
                            </tr>
                        </table>
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
                        <br />
                        <table>
                            <tbody>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                                <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Module Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblModule" runat="server" Text='<%# Bind("Parent_Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Form Name">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hidCode" runat="server" Value='<%# Bind("Code") %>' />
                                                                <asp:HiddenField ID="hidChkbox" runat="server" Value='<%# Bind("Selected") %>' />
                                                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" TabIndex="3" OnCheckedChanged="CheckAll" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkBx" runat="server" TabIndex="4"></asp:CheckBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:ObjectDataSource ID="objuserrole" runat="server" TypeName="BLRolemap" SelectMethod="Getuserroleddl"
                                                    OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                            </asp:Panel>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                </div>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" Visible="true" runat="server" SkinID="lblRsz" Width="720px"></asp:Label>
                            </td>
                        </tr>
                    </table>
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
    <center>
        <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
            SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
    </center>

</form>
</body>
</html>
