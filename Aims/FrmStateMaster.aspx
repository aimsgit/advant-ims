<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmStateMaster.aspx.vb"
    Inherits="FrmStateMaster" Title="State Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>State Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%= cmbCountry.ClientID %>"), 'Country');
            if (msg != "") {
                document.getElementById("<%= txtState.ClientID %>").focus();
                return msg;
            }

            msg = Field250(document.getElementById("<%= txtState.ClientID %>"), 'State');
            if (msg != "") {
                document.getElementById("<%= txtState.ClientID %>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {

            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
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
                        STATE MASTER</h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="StateTable">
                        <tbody>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcountry" runat="server" SkinID="lblRsz" Text="Country* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cmbCountry" runat="server" DataSourceID="objCountry" DataTextField="Country"
                                        SkinID="ddl" AutoPostBack="true" AppendDataBoundItems="true" DataValueField="CountryId"
                                        TabIndex="1">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblState" runat="server" SkinID="lblRsz" Text="State* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtState" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <br />
                                    <asp:Button ID="BtnSave" TabIndex="3" runat="server" Text="ADD" CausesValidation="True"
                                        SkinID="btn" OnClientClick="return Validate();" CssClass="ButtonClass"></asp:Button>
                                    &nbsp;<asp:Button ID="BtnDetails" TabIndex="4" runat="server" Text="VIEW" CausesValidation="False"
                                        SkinID="btn" CssClass="ButtonClass"></asp:Button>
                    </table>
                </center>
                <div>
                    &nbsp;</div>
                <center>
                    <div>
                        <asp:Label ID="msginfo" runat="server" EnableTheming="True" SkinID="lblRed"></asp:Label>
                        <asp:Label ID="lblmsg" runat="server" EnableTheming="true" SkinID="lblGreen"></asp:Label>
                    </div>
                    <div>
                        &nbsp;</div>
                    <div>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="300px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                                AllowPaging="True" PageSize="100">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit" Font-Underline="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Country">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Visible="False" Text='<%# Bind("CountryId") %>'></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Visible="False" Text='<%# Bind("StateId") %>'></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <asp:ObjectDataSource ID="objCountry" runat="server" TypeName="DLStateMaster" SelectMethod="GetCountry_Name">
                    </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
