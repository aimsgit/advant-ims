<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Recover.aspx.vb" Inherits="Recover"
    Title="Recover" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recover</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <caption>
                    <h1 unselectable="on" tabindex="-1">
                        RECOVER</h1>
                </caption>
                <tr>
                    <td style="width: 100px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 10px">
                        <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" BackColor="#CCCCCC"
                            AllowPaging="true" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px"
                            CellPadding="4" CellSpacing="2" ForeColor="Black" EmptyDataText="There are no records to display."
                            meta:resourcekey="GridView1Resource1">
                            <Columns>
                                <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Recover" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                                        <asp:HiddenField ID="Cid" Value='<%# DataBinder.Eval(Container.Dataitem,"ID") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Font-Underline="True" Font-Bold="True" ForeColor="Black" />
                                    <ItemStyle ForeColor="#404040" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        </asp:GridView>
                        <br />
                        <br />
                        <asp:Label runat="server" Text="BookAsset" ID="label2" SkinID="lbl" Visible="False"></asp:Label>
                        <br />
                        <asp:GridView ID="GridView2" runat="server" meta:resourcekey="GridView1Resource1"
                            EmptyDataText="There are no records to display." ForeColor="Black" CellSpacing="2"
                            CellPadding="4" BorderWidth="3px" BorderStyle="Solid" BorderColor="#999999" AllowPaging="true"
                            BackColor="#CCCCCC" DataKeyNames="ID" Visible="false">
                            <Columns>
                                <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Recover" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                                        <asp:HiddenField ID="Cid" Value='<%# DataBinder.Eval(Container.Dataitem,"ID") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Font-Underline="True" Font-Bold="True" ForeColor="Black" />
                                    <ItemStyle ForeColor="#404040" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 10px">
                        <asp:Button ID="Back" runat="server" Text="BACK" OnClick="CallForm" SkinID="btn"
                            meta:resourcekey="BackResource1" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
