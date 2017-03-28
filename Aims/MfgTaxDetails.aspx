<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MfgTaxDetails.aspx.vb"
    Inherits="MfgTaxDetails" Title="Tax Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Tax Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=TxtTaxdescrptn.ClientID%>"), 'Tax Description');

            if (msg != "") {
                document.getElementById("<%=TxtTaxdescrptn.ClientID%>").focus();
                return msg;

            }
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=txtvat.ClientID%>"), 'VAT %');

            if (msg != "") {
                document.getElementById("<%=txtvat.ClientID%>").focus();
                return msg;

            }
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=TxtCST.ClientID%>"), 'CST');

            if (msg != "") {
                document.getElementById("<%=TxtCST.ClientID%>").focus();
                return msg;

            }

            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }
    </script>

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
                            TAX DETAILS</h1>
                    </center>
                    <br />
                    <br />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblTd" runat="server" Text="Tax Description* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtTaxdescrptn" runat="server" SkinID="txtRsz" Width="200" TabIndex="1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblvat" runat="server" Text="VAT % :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtvat" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Lblcst" runat="server" SkinID="lbl" Text="CST % :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtCST" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="right">
                                <td>
                                    <asp:Label ID="LblIE" runat="server" Text="Inclusive/Exclusive(I/E):&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="250"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIE" runat="server" SkinID="ddlRsz" Width="155" TabIndex="4">
                                        <asp:ListItem Text="I" Value="I"></asp:ListItem>
                                        <asp:ListItem Text="E" Value="E"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblEvat" runat="server" Text="Effective VAT % :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEvat" runat="server" ReadOnly="true" SkinID="txt"></asp:TextBox>
                                </td>
                                <td>
                                    <b>(AutoCalculated)</b>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblEcst" runat="server" Text="Effective CST % :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TEcst" runat="server" ReadOnly="true" SkinID="txt"> </asp:TextBox>
                                </td>
                                <td>
                                    <b>(AutoCalculated)</b>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" TabIndex="5" Text="ADD" />
                                        &nbsp;<asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="6"
                                            Text="VIEW" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                    </center>
                    </table>
                    <center>
                        <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GrdTaxDetails" runat="server" SkinID="GridView" AllowPaging="true"
                                AutoGenerateColumns="False" PageSize="100">
                                <Columns>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit" />
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                Visible="false" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax Description" meta:resourcekey="TemplateFieldResource2" >
                                        <ItemTemplate>
                                            <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Tax_ID") %>' />
                                            <asp:HiddenField ID="H1" runat="server" Value='<%# Eval("TaxAutoNo") %>' />
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("Tax_Description") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" ></ItemStyle>
                                         <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="VAT %">
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("State_VAT","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center" />
                                         <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CST %">
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("CST","{0:0.00}") %>' />
                                        </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center" />
                                         <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inclusive/Exclusive">
                                        <ItemStyle Wrap="true" />
                                        <ItemTemplate>
                                         <itemstyle wrap="true" />
                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("Inclusive_Exclusive") %>' />
                                        </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center" />
                                         <ItemStyle HorizontalAlign ="Center" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Effective VAT %">
                                     <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("VAT_Tax_Percent","{0:0.00}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign ="Center" />
                                         <HeaderStyle HorizontalAlign="Center" />
                                     </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Effective CST %">
                                        <ItemTemplate>
                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("CST_Tax_Percent","{0:0.00}") %>' />
                                        </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="false"  HorizontalAlign ="Center" />
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

</form>
</body>
</html>

