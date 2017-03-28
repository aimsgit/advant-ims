<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="DayBook.aspx.vb"
    Inherits="DayBook" Title="Day Book" Culture="auto" UICulture="auto" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Day Book</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 820px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UP1" runat="server">
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
                    msg = DropDown(document.getElementById("<%=cmbAccHead.ClientID %>"), 'Account Head');
                    if (msg != "") {
                        document.getElementById("<%=cmbAccHead.ClientID %>").focus();
                        return msg;
                    }
                    msg = Field250(document.getElementById("<%=txtItemDesc.ClientID %>"), 'Description');
                    if (msg != "") {
                        document.getElementById("<%=txtItemDesc.ClientID %>").focus();
                        return msg;
                    }
                    msg = ValidateDateN(document.getElementById("<%=txtAcctDate.ClientID %>"), 'Accounting Date');
                    if (msg != "") {
                        document.getElementById("<%=txtAcctDate.ClientID %>").focus();
                        return msg;
                    }
                    return true;
                }
                function Validate() {
                    var msg = Valid();
                    if (msg != true) {
                        if (navigator.appName == "Microsoft Internet Explorer") {
                            document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                            document.getElementById("<%=Lblmsg.ClientID %>").innerText = "";

                            return false;
                        }
                        else if (navigator.appName == "Netscape") {
                            document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                            document.getElementById("<%=Lblmsg.ClientID %>").textContent = "";
                            return false;
                        }
                    }
                    return true;
                }
                //                function SplitName() {
                //                    var text = document.getElementById("<%=txtParty.ClientID%>").value;
                //                    var split = text.split(':');
                //                    if (split.length > 0) {
                //                        document.getElementById("<%=txtParty.ClientID%>").innerText = split[0];
                //                        document.getElementById("<%=HidPartyTypeId.ClientID%>").value = split[1];
                //                    }
                //                }
                //                function SplitBank() {
                //                    var text = document.getElementById("<%=txtBank.ClientID%>").value;
                //                    var split = text.split(':');
                //                    if (split.length > 0) {
                //                        document.getElementById("<%=txtBank.ClientID%>").innerText = split[1];
                //                        document.getElementById("<%=HidBank.ClientID%>").value = split[0];
                //                    }
                //                }
               
            </script>

            <script language="JavaScript" type="text/javascript">
                function RunExe() {
                    var SesVar = '<%= Session("Path") %>';
                    var oShell = new ActiveXObject("WScript.Shell");
                    var prog = SesVar;
                    oShell.Run('"' + prog + '"', 1);
                }  
      
            </script>

            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <%--          <center>
                <h1 class="headingTxt">
                    DAY BOOK
                </h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <center>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label19" runat="server" SkinID="lblRsz"
                                Width="175px" Text="Account Group :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbAGOne" runat="server" SkinID="ddl" AutoPostBack="True" DataTextField="Acct_Group"
                                DataValueField="Acct_Group_ID" TabIndex="4">
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
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label20" runat="server" SkinID="lblRsz"
                                Width="200px" Text="Account Treatment :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbAOT" runat="server" SkinID="ddl" TabIndex="6" AutoPostBack="True">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Credit</asp:ListItem>
                                <asp:ListItem Value="-1">Debit</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblWithCode" runat="server" SkinID="lblRsz" Width="90" Text="With Code :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="ChkWithCode" SkinID="chk" TabIndex="9" runat="server" Checked="false" AutoPostBack="true"/>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Account Head*^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="160px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbAccHead" TabIndex="1" runat="server" SkinID="ddlRsz" Width="300"
                                DataValueField="Account_Code" DataTextField="Head_type" AutoPostBack="true">
                                <asp:ListItem>Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Item Description*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtItemDesc" TabIndex="2" runat="server" TextMode="MultiLine" SkinID="txtRsz"
                                Width="296"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtItemDesc">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblProjectName" runat="server" Text="Project Name^ :&nbsp;&nbsp;"
                                SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DDLProjectName" TabIndex="3" runat="server" SkinID="ddlRsz"
                                DataSourceID="ObjProjectName" DataValueField="ProjectID_Auto" DataTextField="Project_Name"
                                AppendDataBoundItems="true" Width="300">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjProjectName" runat="server" SelectMethod="GetProjectName"
                                TypeName="DayBookManager"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Currency :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbCurrency" TabIndex="4" runat="server" SkinID="ddl" DataSourceID="ObjMC"
                                AutoPostBack="true" DataValueField="Currency_Code" DataTextField="Currency_Name">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjMC" runat="server" SelectMethod="GetMulticurrency" TypeName="MultiCurrencyManager">
                            </asp:ObjectDataSource>
                        </td>
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
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="Party Type^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbPType" TabIndex="6" runat="server" SkinID="ddl" DataSourceID="ObjPartyType"
                                AutoPostBack="True" DataValueField="Id" DataTextField="Name">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjPartyType" runat="server" SelectMethod="GetPartyType"
                                TypeName="DayBookManager"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" Text="Party Name^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtParty" SkinID="txt" runat="server" TabIndex="7"></asp:TextBox>
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
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" Text="Entry Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEDate" TabIndex="8" runat="server" SkinID="txt" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
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
                            <asp:Label ID="Label2" runat="server" Text="Accounting Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAcctDate" TabIndex="9" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion1" runat="server" TargetControlID="txtAcctDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label10" runat="server" Text="Receipt/Voucher No^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBillNo" TabIndex="10" runat="server" SkinID="txt" MaxLength="25"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtBillNo">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblPaymentMethod" runat="server" SkinID="lblRsz" Width="250" Text="Receipt/Payment Method :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataSourceID="ObjPaymentMethod"
                                DataTextField="Payment_Method" DataValueField="PaymentMethodID" AppendDataBoundItems="true"
                                SkinID="ddl" TabIndex="11" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodCombo"
                                TypeName="FeeCollectionBL"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" Text="Amount* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAmt" TabIndex="12" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                MaxLength="10"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                FilterMode="ValidChars" ValidChars="1234567890. " TargetControlID="txtAmt">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label18" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRemarks1" TabIndex="18" runat="server" SkinID="txt" MaxLength="50"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" Text="Bank :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBank" runat="server" TabIndex="13" SkinID="txtRsz" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label15" runat="server" Text="Branch :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBranch" TabIndex="14" runat="server" SkinID="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" Text="Cheque/DD No^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtChk" TabIndex="16" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                MaxLength="25"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" Text="Cheque/DD Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBillDate" TabIndex="17" runat="server" SkinID="txt" AutoCompleteType="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRemarks" TabIndex="18" runat="server" SkinID="txt" MaxLength="50"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label17" runat="server" Text="Cheque/DD Bank :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="200px" Visible="false"></asp:Label>
                        </td>
                        <td align="left">
                            <%--<asp:BoundField DataField="Acc_Sub_Grp" HeaderText="Account SubGroup" SortExpression="Acc_Sub_Grp" />--%>
                            <asp:TextBox ID="txtChequeBank" runat="server" TabIndex="15" Visible="false"></asp:TextBox>
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
                        <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtBillDate"
                            Format="dd-MMM-yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </tr>
                </table>
                <table>
                    <br />
                    <tr>
                        <td class="btnTd" style="height: 9px" align="center" colspan="2">
                            <asp:Button ID="btnSave" TabIndex="19" runat="server" Text="ADD" SkinID="btn" CssClass="ButtonClass "
                                OnClientClick="return Validate();"></asp:Button>
                            <asp:Button ID="btnDetails" TabIndex="20" runat="server" Text="VIEW" SkinID="btn"
                                CssClass="ButtonClass " CausesValidation="False"></asp:Button>
                            <asp:Button ID="BtnShowNotPosted" runat="server" Text="VIEW NOT POSTED " CssClass="ButtonClass "
                                CausesValidation="true" SkinID="btnRsz" Width="130" TabIndex="21" />
                            <asp:Button ID="Btnposttostock" runat="server" Text="POST " CssClass="ButtonClass "
                                CausesValidation="true" SkinID="btn" TabIndex="22" />
                            <asp:Button ID="Btnreceipt" TabIndex="23" runat="server" Text="RECEIPT" SkinID="btn"
                                CssClass="ButtonClass " CausesValidation="False"></asp:Button>
                            <asp:Button ID="BtnVoucher" TabIndex="24" runat="server" Text="VOUCHER" SkinID="btn"
                                CssClass="ButtonClass " CausesValidation="False"></asp:Button>
                            <asp:Button ID="btnCheque" TabIndex="25" runat="server" Text="PRINT CHEQUE" SkinID="btnRsz"
                                Width="120px" CssClass="ButtonClass " CausesValidation="False"></asp:Button>
                        </td>
                    </tr>
                    <br />
                </table>
            </center>
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
            <br />
            <center>
                <asp:Panel ID="GV" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                    <asp:GridView ID="GVDayBook" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        SkinID="GRIDVIEW" Visible="true" PageSize="100">
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                        Text="Delete"></asp:LinkButton>
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
                            <asp:TemplateField HeaderText="Item Description">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" Width="200px" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acc_Sub_Grp">
                                <ItemTemplate>
                                    <asp:Label ID="LblAcctGroup" runat="server" Text='<%# Bind("Acct_Sub_Group") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Credit">
                                <ItemTemplate>
                                    <asp:Label ID="LblCredit" runat="server" Text='<%# Bind("Credit","{0:n2}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Debit">
                                <ItemTemplate>
                                    <asp:Label ID="lblDebit" runat="server" Text='<%# Bind("Debit","{0:n2}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bill Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Bill_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bill No">
                                <ItemTemplate>
                                    <asp:Label ID="lblBillNo" runat="server" Text='<%# Bind("Bill_No") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Entry Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Entry_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cheque/DD No">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Cheque_No") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Currency Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Currency_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Exchange Rate">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("ExchangeRate","{0:n2}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Head" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="LblAccountHead" runat="server" Text='<%# Bind("Head_type") %>'></asp:Label>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Exp_Ref_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
            <%--<asp:ObjectDataSource ID="ObjBank" runat="server" SelectMethod="GetBankComboDB" TypeName="BankManager"
                            DataObjectTypeName="DayBookPartyName">
                            <SelectParameters>
                                <asp:Parameter Name="id" ConvertEmptyStringToNull="true" Type="int32" DefaultValue="0" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjEmp" runat="server" SelectMethod="GetEmpComboDB" TypeName="EmployeeManager"
                            DataObjectTypeName="DayBookPartyName">
                            <SelectParameters>
                                <asp:Parameter Name="id" ConvertEmptyStringToNull="true" Type="int32" DefaultValue="0" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjOtherParty" runat="server" SelectMethod="GetOtherComboDB"
                            TypeName="OtherPartyB" DataObjectTypeName="DayBookPartyName">
                            <SelectParameters>
                                <asp:Parameter Name="id" ConvertEmptyStringToNull="true" Type="int32" DefaultValue="0" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjSupp" runat="server" SelectMethod="GetSuppComboDB" TypeName="SupplierManager"
                            DataObjectTypeName="DayBookPartyName">
                            <SelectParameters>
                                <asp:Parameter Name="id" ConvertEmptyStringToNull="true" Type="int32" DefaultValue="0" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjAccSubGrp" runat="server" TypeName="AccountHeadManager"
                            DataObjectTypeName="AccountSubGroup">
                            <SelectParameters>
                                <asp:Parameter Name="id" ConvertEmptyStringToNull="true" Type="int32" DefaultValue="0" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjExp" runat="server" TypeName="DayBookManager" DataObjectTypeName="DayBookEL">
                        </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjDaybook" runat="server" TypeName="DayBookManager" DataObjectTypeName="DayBookEL">
                <SelectParameters>
                    <asp:Parameter Name="id" ConvertEmptyStringToNull="true" Type="int32" DefaultValue="0" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjStud" runat="server" SelectMethod="GetStudComboDB" TypeName="StudentManager"
                DataObjectTypeName="DayBookPartyName">
                <SelectParameters>
                    <asp:Parameter Name="id" ConvertEmptyStringToNull="true" Type="int32" DefaultValue="0" />
                </SelectParameters>
            </asp:ObjectDataSource>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>
