<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmTableMaster.aspx.vb"
    Inherits="frmTableMaster" Title="GLOBAL & LOCAL TABLE MAPS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>GLOBAL & LOCAL TABLE MAPS</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function ValidReport() {
            var msg;
            msg = DropDown(document.getElementById("<%=ddlHO.ClientID %>"), 'Institute');
            if (msg != "") return msg;
            msg = DropDown(document.getElementById("<%=DDLTableMaster.ClientID %>"), 'Table Name');
            if (msg != "") return msg;
            msg = DropDown(document.getElementById("<%=ddlPS.ClientID %>"), 'Table Access Level');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {

            var msg = ValidReport();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblgreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblgreen.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <center>
                    <table class="custTable">
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblHO" runat="server" Text="Institute* :&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHO" runat="server" DataSourceID="odsHO" DataTextField="BranchName"
                                    DataValueField="BranchCode" SkinID="ddlRsz" Width="250" TabIndex="1" AppendDataBoundItems="true"
                                    AutoPostBack="True">
                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsHO" runat="server" SelectMethod="FillHO" TypeName="BranchManager">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Table Name* :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLTableMaster" runat="server" DataSourceID="ObjectDataSource1"
                                    DataTextField="TableName" DataValueField="TableCode" SkinID="ddl" TabIndex="1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Width="200px" Text="Table Access Level* :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPS" runat="server" SkinID="ddl">
                                    <asp:ListItem>Local</asp:ListItem>
                                    <asp:ListItem>Global</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Btnadd" runat="server" OnClientClick="return Validate();" CssClass="ButtonClass"
                                    SkinID="btnRsz" Text="ADD" />
                            </td>
                            <td>
                                <asp:Button ID="BtnReport" runat="server" CssClass="ButtonClass " SkinID="btnRsz"
                                    Text="VIEW" />
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblgreen" runat="server" SkinID="lblgreen"></asp:Label>
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <div>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GVTableMaster" runat="server" SkinID="GridView" Visible="true"
                                AllowPaging="true" AutoGenerateColumns="False" PageSize="100">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <%--<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit"></asp:LinkButton>--%>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Table Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTN" runat="server" Text='<%#Bind("TableName") %>'></asp:Label>
                                            <asp:Label ID="Label5" Visible="false" runat="server" Text='<%#Bind("TableCode") %>'></asp:Label>
                                            <asp:Label ID="lblTable_ID" Visible="false" runat="server" Text='<%#Bind("Table_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Table Access Level">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTAL" runat="server" Text='<%#Bind("TableAccessLevel") %>'></asp:Label>
                                            <asp:Label ID="lblBranchCode" runat="server" Visible="false" Text='<%#Bind("BranchCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <br />
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetTableNames" TypeName="BLTableMaster">
                            <SelectParameters>
                                <asp:Parameter Name="p" Type="Object" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
