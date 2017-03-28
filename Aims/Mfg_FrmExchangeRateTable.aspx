<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="Mfg_FrmExchangeRateTable.aspx.vb"
    Inherits="Mfg_FrmExchangeRateTable" Title="Exchange Rate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Exchange Rate</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%= Txtcname.ClientID %>"), 'Currency Name');
            if (msg != "") {
                document.getElementById("<%= Txtcname.ClientID %>").focus();
                return msg;
            }

            msg = FeesFieldAcceptDecimal(document.getElementById("<%= Txtbuyrate.ClientID %>"), 'Buy Rate');
            if (msg != "") {
                document.getElementById("<%= Txtbuyrate.ClientID %>").focus();
                return msg;
            }
            msg = FeesFieldAcceptDecimal(document.getElementById("<%= Txtsalerate.ClientID %>"), 'Sale Rate');
            if (msg != "") {
                document.getElementById("<%= Txtsalerate.ClientID %>").focus();
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

 <br />
        <br />
    <center>
        <div class="mainBlock">
            <center>
                <h1 class="headingTxt">
                    EXCHANGE RATE</h1>
            </center>
        </div>
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <a name="Top">
                    <div align="right">
                        <a href="#Bottom">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    </div>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" SkinID="lblRsz" Width="150" Text="Currency Name* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtcname" runat="server" AutoCompleteType="Disabled" TabIndex="1" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Symbol :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtsymbol" runat="server" AutoCompleteType="Disabled" TabIndex="2" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Buy Rate* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtbuyrate" runat="server" AutoCompleteType="Disabled" TabIndex="3" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Sale Rate* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtsalerate" runat="server" AutoCompleteType="Disabled" TabIndex="4" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" SkinID="lbl" Text="Currency One :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtcone" runat="server" AutoCompleteType="Disabled" TabIndex="5" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Currency Two :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtctwo" runat="server" AutoCompleteType="Disabled" TabIndex="6" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <tr align="center">
                                    <td class="btnTd" colspan="3">
                                        <br />
                                        <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CommandName="Update"
                                            CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="7"
                                            Text="ADD" ValidationGroup="edit" />
                                        &nbsp;<asp:Button ID="btnView" runat="server" CausesValidation="false" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="8" Text="VIEW" />
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <br />
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                        <br />
                        <br />
                    </center>
                    <div>
                        <center>
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GVExchangeRate" runat="server" SkinID="GridView" AllowPaging="True"
                                    AutoGenerateColumns="False" PageSize="100">
                                    <Columns>
                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Visible="false" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Currency Name" SortExpression="Currency Name">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="GID" runat="server" Value='<%# Bind("Currency_Code") %>' />
                                                <asp:Label ID="Lblcname" runat="server" Text='<%# Bind("Currency_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Symbol">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblsymbol" runat="server" Text='<%#Bind("Currency_Symbol") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Buy Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblbrate" runat="server" Text='<%#Bind("Buy_Conversion_Rate","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblsrate" runat="server" Text='<%#Bind("Sale_Conversion_Rate","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Currency One">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblcone" runat="server" Text='<%#Bind("Currency_One") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Currency Two">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblctwo" runat="server" Text='<%#Bind("Currency_Two") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
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
    </center>

</form>
</body>
</html>
