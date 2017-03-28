<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmManufacturer.aspx.vb"
    Inherits="Mfg_frmManufacturer" Title="Manufacture Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manufacture Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%= txtmanufacturer.ClientID %>"), 'Manufacturer');
            if (msg != "") {
                document.getElementById("<%= txtmanufacturer.ClientID %>").focus();
                return msg;
            }
            msg = Field50(document.getElementById("<%= txtcountry.ClientID %>"), 'Country');
            if (msg != "") {
                document.getElementById("<%= txtcountry.ClientID %>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {

            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
               <div>
                               <center>
                    <h1 class="headingTxt">
                        MANUFACTURER/COMPANY
                    </h1>
                </center>
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Manufacturer*^&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="200"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtmanufacturer" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Country*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtcountry" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Discount Lock&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="Chkdislock" runat="server" AutoPostBack="true" TabIndex="3" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:RadioButtonList ID="RbTYPE" runat="server" TabIndex="4" AutoPostBack="true"
                                    RepeatDirection="Horizontal" SkinID="Themes1">
                                    <asp:ListItem Selected="True" Value="1" Text="MFG TYPE "></asp:ListItem>
                                    <asp:ListItem Value="2" Text="MKT TYPE"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="5"
                                    Text="ADD" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="6" Text="VIEW" />
                            </td>
                    </table>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:GridView ID="GridManufacturer" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField  ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="7"
                                                        CommandName="Edit" Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="8"
                                                        CommandName="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Manufacturer" Visible="true">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="Label5" runat="server" Value='<%# Bind("ManufAutoNo") %>'></asp:HiddenField>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Manufaturer_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Country">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Discount Lock">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDiscount" runat="server" Text='<%# Bind("DiscountLockYesNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MFG/MKT Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblType" runat="server" Text='<%# Bind("MfgMkt_Type") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                    </asp:Panel>
                </center>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>


