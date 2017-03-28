<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmTreeviewRefresh.aspx.vb"
    Inherits="frmTreeviewRefresh" Title="Treeview Refresh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Treeview Refresh</title>
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
                            TREEVIEW REFRESH</h1>
                    </center>
                    <center>
                        <table class="custTable">
                            <tbody>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblmodule" runat="server" SkinID="lbl" Text="Module*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DDLmodule" runat="server" DataSourceID="objuserrole" SkinID="ddlRsz"
                                            DataValueField="MNIDAuto" AutoPostBack="true" DataTextField="ModuleName" TabIndex="1"
                                            Width="260px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <hr />
                                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                                <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Module Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblModule" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Form Name">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="MNIDAuto" runat="server" Value='<%# Bind("MNIDAuto") %>' />
                                                                <asp:HiddenField ID="CNIDAuto" runat="server" Value='<%# Bind("CNIDAuto") %>' />
                                                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("ChildName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" TabIndex="3" OnCheckedChanged="CheckAll"/>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkBx" runat="server" TabIndex="4"></asp:CheckBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:ObjectDataSource ID="objuserrole" runat="server" TypeName="TreeviewRefresh" SelectMethod="Getuserroleddl"
                                                    OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                                            </asp:Panel>
                                            <hr />
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="LblselectClient" runat="server" SkinID="lblRSZ" Text="Institute&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlSelectClient" runat="server" AutoPostBack="True" DataSourceID="ObjSelectClient"
                                            AppendDataBoundItems="true" DataTextField="MyCo_Name" DataValueField="MyCo_Code"
                                            SkinID="ddlRsz" TabIndex="1" Width="260px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSelectClient" runat="server" SelectMethod="GetClientCombo"
                                            TypeName="TreeviewRefresh"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                    <br />
                                        <asp:Button ID="btnupdate" runat="server" Text="ASSIGN" SkinID="btn" TabIndex="5"
                                            CssClass="ButtonClass " />
                                        <asp:Button ID="btnrefresh" runat="server" Text="REFRESH" SkinID="btn" TabIndex="5"
                                            CssClass="ButtonClass " />
                                        <asp:Button ID="btnview" runat="server" Text="CLOSE" SkinID="btn" TabIndex="2" CssClass="ButtonClass " />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                            <asp:Label ID="lblgreen" runat="server" SkinID="lblGreen"></asp:Label>
                                        </center>
                                    </td>
                                </tr>
                            </tbody>
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
                    <br />
                    <br />
                    <table>
                        <tbody>
                        </tbody>
                    </table>
                    </center>
                </div>
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