<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmOpeningBalanceEntry.aspx.vb"
    Inherits="FrmOpeningBalanceEntry" Title="Opening Balance Entry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Opening Balance Entry</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtBank.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtBank.ClientID%>"));
        }
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtItemDesc.ClientID %>"), 'Item Description');

            if (msg != "") {
                document.getElementById("<%=txtItemDesc.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbAccountGroup.ClientID %>"), 'Account Group');

            if (msg != "") {
                document.getElementById("<%=cmbAccountGroup.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbAcctOne.ClientID %>"), 'Account');

            if (msg != "") {
                document.getElementById("<%=cmbAcctOne.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbAOT.ClientID %>"), 'Account Treatment');

            if (msg != "") {
                document.getElementById("<%=cmbAOT.ClientID %>").focus();
                return msg;
            }

            msg = ValidateDateN(document.getElementById("<%=txtDate.ClientID%>"), 'Date');

            if (msg != "") {
                document.getElementById("<%=txtDate.ClientID%>").focus();
                return msg;

            }
            msg = Field50(document.getElementById("<%=txtAmt.ClientID%>"), 'Amount');

            if (msg != "") {
                document.getElementById("<%=txtAmt.ClientID%>").focus();
                return msg;

            }

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
//        function SplitBank() {
//            var text = document.getElementById("<%=txtBank.ClientID%>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=txtBank.ClientID%>").innerText = split[1];
//                document.getElementById("<%=HidBank.ClientID%>").value = split[0];
//            }
//        }
    </script>


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table class="custTable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Item Description* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtItemDesc" TabIndex="1" runat="server" TextMode="MultiLine" SkinID="txtRsz"
                                Width="296"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtItemDesc">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblAccountGroup" runat="server" Text="Account Group* :&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="150px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbAccountGroup" runat="server" SkinID="ddl" AutoPostBack="True"
                                DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="2">
                                <asp:ListItem Value="0"> Select</asp:ListItem>
                                <asp:ListItem Value="1">Assets</asp:ListItem>
                                <asp:ListItem Value="2">Liabilities</asp:ListItem>
                                <asp:ListItem Value="3">Income</asp:ListItem>
                                <asp:ListItem Value="4">Expenses</asp:ListItem>
                                <asp:ListItem Value="5">Capital Account</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Account* :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbAcctOne" runat="server" SkinID="ddl" DataTextField="Acct_Sub_Group"
                                DataValueField="Acct_Sub_Group_ID" TabIndex="3">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="Account Treatment* :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="170px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbAOT" runat="server" SkinID="ddl" TabIndex="4">
                                <asp:ListItem Value="1">Credit</asp:ListItem>
                                <asp:ListItem Value="-1">Debit</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" Text="Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDate" runat="server" MaxLength="11" AutoCompleteType="Disabled"
                                SkinID="txt" TabIndex="5"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" Text="Amount* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAmt" TabIndex="6" runat="server" SkinID="txt" AutoCompleteType="Disabled" MaxLength="15"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAmt">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" Text="Bank :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBank" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" OnClientPopulated="HideImage1"
                                OnClientPopulating="ShowImage1" TargetControlID="txtBank" MinimumPrefixLength="3"
                                CompletionInterval="1000" FirstRowSelected="true" EnableCaching="true" ServiceMethod="getBankExt"
                                ServicePath="TextBoxExt.asmx">
                            </ajaxToolkit:AutoCompleteExtender>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                SkinID="watermark" TargetControlID="txtBank" WatermarkText="Type first 3 characters">
                            </ajaxToolkit:TextBoxWatermarkExtender>
                            <asp:HiddenField ID="HidBank" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblRemarks" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" TabIndex="18" runat="server" SkinID="txt" MaxLength="50"
                                TextMode="MultiLine"></asp:TextBox>
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
                                CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="7"
                                Text="ADD" />
                            &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="8" Text="VIEW" />
                        </td>
                    </tr>
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
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:GridView ID="GrdOpeningEntry" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px">
                                    <Columns>
                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" />
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                    Text="Delete" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("DayBook_ID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account Group">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAcctGrp" runat="server" Text='<%# Bind("Acct_Group") %>'></asp:Label>
                                                <asp:Label ID="Label15" runat="server" Visible="false" Text='<%# Bind("Acct_Group_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActSubGrp" runat="server" Text='<%# Bind("Acct_Sub_Group") %>'></asp:Label>
                                                <asp:Label ID="lblAcctSubGrpId" runat="server" Visible="false" Text='<%# Bind("Acct_Sub_Group_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblBillDate" runat="server" Text='<%# Bind("Bill_Date","{0:dd-MMM-yyyy}") %>' ></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Credit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCredit" runat="server" Text='<%# Bind("Credit","{0:n2}") %>'></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("AcctT") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblAmt" runat="server" Text='<%# Bind("Amount","{0:n2}") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Debit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDebit" runat="server" Text='<%# Bind("Debit","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank Name">
                                            <ItemTemplate>
                                               <asp:Label ID="LabelBankId" runat="server" Text='<%# Bind("Bank_ID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblBank" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
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
                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                </asp:Panel>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
