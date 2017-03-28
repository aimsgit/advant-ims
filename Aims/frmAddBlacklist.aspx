<%@ Page Title="IP BlackList" Language="VB" AutoEventWireup="false" CodeFile="frmAddBlacklist.aspx.vb" Inherits="frmAddBlacklist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IP BlackList</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtblackip.ClientID %>"), 'IP No.');
            if (msg != "") {
                document.getElementById("<%=txtblackip.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<center>
        <h1 class="headingTxt">
            <asp:Label ID="Lblheading" runat="server" Text="IP BlackList"></asp:Label>
        </h1>
    </center>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table class="custtable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="IP Address* :  "></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtblackip" runat="server" SkinID="txt" MaxLength="50"
                                TabIndex="2" Width="164px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td colspan="2" align="center">
                            <br />
                            <asp:Button ID="btnadd" CausesValidation="true" runat="server" Text="ADD" CommandName="Update"
                                SkinID="btn" OnClientClick="return Validate()" TabIndex="4" CssClass="ButtonClass">
                            </asp:Button>
                            <asp:Button ID="btnview" runat="server" Text="VIEW" CommandName="Cancel" SkinID="btn"
                                TabIndex="5" CssClass="ButtonClass"></asp:Button>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <br />
                <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                <asp:Label ID="lblerrmsg" SkinID="lblRed" runat="server"></asp:Label>
                <br />
                <br />
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="400px" Height="300px">
                    <asp:GridView ID="GridView1" runat="server" SkinID="GridView" 
                        AllowPaging="True" Visible="True" AutoGenerateColumns="False" PageSize="100" >
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Wrap="False"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IP Address" SortExpression="IP_No">
                                <ItemTemplate>
                                    <asp:Label ID="id" Visible="false" runat="server" Text='<%#Bind("id") %>'></asp:Label>
                                    <asp:Label ID="lblIP_No" runat="server" Text='<%# Bind("IP_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" SortExpression="DateEntry">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateEntry" runat="server" Text='<%# Bind("DateEntry","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Code" SortExpression="UserCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserCode" runat="server" Text='<%#Bind("UserCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </center>
            </ContentTemplate>
            </asp:UpdatePanel>

</form>
</body>
</html>
