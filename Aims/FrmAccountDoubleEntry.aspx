<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmAccountDoubleEntry.aspx.vb"
    Inherits="FrmAccountDoubleEntry" Title="Double Entry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Double Entry</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>

            <script language="JavaScript" type="text/javascript">

                function ShowImage() {
                    GlbShowSImage(document.getElementById("<%=txtparty.ClientID%>"));

                }
                function HideImage() {
                    GlbHideSImage(document.getElementById("<%=txtparty.ClientID%>"));
                }
                function ShowImage1() {
                    GlbShowSImage(document.getElementById("<%=txtBank.ClientID%>"));

                }
                function HideImage1() {
                    GlbHideSImage(document.getElementById("<%=txtBank.ClientID%>"));
                }
                function Valid() {
                    var msg;
                    msg = DropDownForZero(document.getElementById("<%=cmbAccountGroup.ClientID %>"), 'Account Group');
                    if (msg != "") {
                        document.getElementById("<%=cmbAccountGroup.ClientID %>").focus();
                        return msg;
                    }
                    msg = DropDownForZero(document.getElementById("<%=cmbAcctOne.ClientID %>"), 'Account Sub Group');
                    if (msg != "") {
                        document.getElementById("<%=cmbAcctOne.ClientID %>").focus();
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

            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    DOUBLE ENTRY
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table class="custTable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblAccountGroup" runat="server" Text="Account Group* :&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="140"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbAccountGroup" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="1" Width="200">
                                <asp:ListItem Value="0"> Select</asp:ListItem>
                                <asp:ListItem Value="1">Assets</asp:ListItem>
                                <asp:ListItem Value="2">Liabilities</asp:ListItem>
                                <asp:ListItem Value="3">Income</asp:ListItem>
                                <asp:ListItem Value="4">Expenses</asp:ListItem>
                                <asp:ListItem Value="5">Capital Account</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label16" runat="server" Text="Receipt/Voucher Date :&nbsp;&nbsp;"
                                SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBDate" TabIndex="9" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion" runat="server" TargetControlID="txtBDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Account Sub Group* :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="170"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbAcctOne" runat="server" SkinID="ddlRsz" DataTextField="Acct_Sub_Group"
                                DataValueField="Acct_Sub_Group_ID" TabIndex="2" Width="200">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Accounting Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAcctDate" TabIndex="10" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion1" runat="server" TargetControlID="txtAcctDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblProjectName" runat="server" Text="Project Name :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DDLProjectName" TabIndex="3" runat="server" SkinID="ddl" DataSourceID="ObjProjectName"
                                DataValueField="ProjectID_Auto" DataTextField="Project_Name" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjProjectName" runat="server" SelectMethod="GetProjectName"
                                TypeName="DayBookManager"></asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label10" runat="server" Text="Receipt/Voucher No :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="200"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBillNo" TabIndex="11" runat="server" SkinID="txt" MaxLength="25"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtBillNo">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="Currency :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbCurrency" TabIndex="4" runat="server" SkinID="ddl" DataSourceID="ObjMC"
                                AutoPostBack="true" DataValueField="Currency_Code" DataTextField="Currency_Name">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjMC" runat="server" SelectMethod="GetMulticurrency" TypeName="MultiCurrencyManager">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" Text="Bank :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBank" runat="server" TabIndex="12" SkinID="txt"></asp:TextBox>
                        </td>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" OnClientPopulated="HideImage1"
                            OnClientPopulating="ShowImage1" TargetControlID="txtBank" MinimumPrefixLength="3"
                            CompletionInterval="1000" FirstRowSelected="true" EnableCaching="true" ServiceMethod="getBankExt"
                            ServicePath="TextBoxExt.asmx" CompletionListCssClass="completeListStyle">
                        </ajaxToolkit:AutoCompleteExtender>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                            SkinID="watermark" TargetControlID="txtBank" WatermarkText="Type first 3 characters">
                        </ajaxToolkit:TextBoxWatermarkExtender>
                        <asp:HiddenField ID="HidBank" runat="server" />
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Exchange Rate :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtExRate" TabIndex="5" runat="server" SkinID="txt" AutoCompleteType="Disabled"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                FilterMode="ValidChars" ValidChars="1234567890. " TargetControlID="txtExRate">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label15" runat="server" Text="Branch :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBranch" TabIndex="13" runat="server" SkinID="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="Party Type :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbPType" TabIndex="6" runat="server" SkinID="ddl" DataSourceID="ObjPartyType"
                                AutoPostBack="True" DataValueField="Id" DataTextField="Name">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjPartyType" runat="server" SelectMethod="GetPartyType"
                                TypeName="DayBookManager"></asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" Text="Cheque/DD No^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtChk" TabIndex="14" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                MaxLength="25"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" Text="Party Name :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtParty" runat="server" TabIndex="7" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" OnClientPopulated="HideImage"
                                OnClientPopulating="ShowImage" TargetControlID="txtParty" MinimumPrefixLength="3"
                                CompletionInterval="1000" FirstRowSelected="true" ServiceMethod="GetPartyTypeExt"
                                ServicePath="TextBoxExt.asmx" EnableCaching="true" CompletionListCssClass="completeListStyle">
                            </ajaxToolkit:AutoCompleteExtender>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                                SkinID="watermark" TargetControlID="txtParty" WatermarkText="Type first 3 characters">
                            </ajaxToolkit:TextBoxWatermarkExtender>
                            <asp:HiddenField ID="HidPartyTypeId" runat="server" />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtParty">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" Text="Cheque/DD Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBillDate" TabIndex="15" runat="server" SkinID="txt" AutoCompleteType="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" Text="Entry Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEDate" TabIndex="8" runat="server" SkinID="txt" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label18" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRemarks1" TabIndex="16" runat="server" SkinID="txt" MaxLength="50"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="btnTd" colspan="2">
                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="17"
                                Text="ADD" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="770px">
                                &nbsp;
                                <asp:GridView ID="GV1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px">
                                    <Columns>
                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                    OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                    Text="Delete" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account Sub Group">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAcctGrpName" runat="server" Text='<%# Bind("Account_Group_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                                <asp:TextBox ID="lblItem" runat="server" Text='<%# Bind("Item") %>' Width="250" TextMode="MultiLine"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Credit">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lblCredit" runat="server" Text='<%# Bind("Credit","{0:n2}") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Debit">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lblDebit" runat="server" Text='<%# Bind("Debit","{0:n2}") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Right"/>
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Debit" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyType" runat="server" Text='<%# Bind("Party_Type") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblAccSubGrpId" runat="server" Text='<%# Bind("Acct_SubGroup_ID") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblAccGrp" runat="server" Text='<%# Bind("Account_Group") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblPartyId" runat="server" Text='<%# Bind("Party_Id_Name") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblCurrencyCode" runat="server" Text='<%# Bind("Currency_Code") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblExchangeRate" runat="server" Text='<%# Bind("ExchangeRate") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblChequeDate" runat="server" Text='<%# Bind("ChequeDate") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblBillDate" runat="server" Text='<%# Bind("Bill_Date") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblBillNo" runat="server" Text='<%# Bind("Bill_No") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblEntryDate" runat="server" Text='<%# Bind("Entry_Date") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblAccountingDate" runat="server" Text='<%# Bind("Accounting_Date") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblBankId" runat="server" Text='<%# Bind("Bank_ID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblChequeNo" runat="server" Text='<%# Bind("Cheque_No") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblProjectId" runat="server" Text='<%# Bind("ProjectID_Auto") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <br />

                <table>
                    <tr>
                        <td>
                            <asp:Button ID="BtnSubmit" runat="server" CausesValidation="true" CommandName="Insert"
                                CssClass="ButtonClass" SkinID="btn" TabIndex="7" Text="SUBMIT" />
                            &nbsp;<asp:Button ID="BtnView" runat="server" CausesValidation="true" CommandName="Insert"
                                CssClass="ButtonClass" SkinID="btn" TabIndex="8" Text="VIEW"/>
                            &nbsp;<asp:Button ID="Btnposttostock" runat="server" Text="POST " CssClass="ButtonClass "
                                CausesValidation="true" SkinID="btn" TabIndex="22" />
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="Lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
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
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    &nbsp;
                                    <asp:GridView ID="GV3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView">
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
                                            <asp:TemplateField SortExpression="center">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                        Width="50px" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkRL" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPostStatus" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Account Group" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId1" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lbl11" runat="server" Text='<%# Bind("Account_Group") %>' Width="150"></asp:Label>
                                                    <asp:Label ID="lbl12" runat="server" Text='<%# Bind("Account_Group_Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Account">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl13" runat="server" Text='<%# Bind("Acct_Sub_Group") %>' Width="150"></asp:Label>
                                                    <asp:Label ID="lbl14" runat="server" Visible="false" Text='<%# Bind("AcctOneId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Item">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl15" runat="server" Text='<%# Bind("Item") %>' Width="250"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Credit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl16" runat="server" Text='<%# Bind("Amt_In","{0:n2}") %>' Width="120"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Debit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl17" runat="server" Text='<%# Bind("Amt_Out","{0:n2}") %>' Width="120"></asp:Label>
                                                    <asp:Label ID="lblDayBookId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </center>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>

