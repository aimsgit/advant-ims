<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBankReconciliation.aspx.vb"
    Inherits="frmBankReconciliation" Title="Bank Reconciliation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bank Reconciliation</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtFromDate.ClientID %>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFromDate.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtToDate.ClientID %>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID %>").focus();
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
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" id="TABLE1">
                    <caption>
                        <%--<center>
                            <h1 class="headingTxt">
                                BANK RECONCILIATION</h1>
                        </center>--%>
                        <center>
                            <h1 class="headingTxt">
                                <asp:Label ID="Lblheading" runat="server"></asp:Label>
                            </h1>
                        </center>
                    </caption>
                </table>
                <hr />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBank" runat="server" SkinID="lbl" Text="Bank*&nbsp;:&nbsp;&nbsp;"
                                    Width="50"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBank" runat="server" DataSourceID="ObjBank" DataTextField="Bank_Name"
                                    DataValueField="Bank_ID" AppendDataBoundItems="true" SkinID="ddl" TabIndex="1">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBank" runat="server" SelectMethod="BankCombo" TypeName="FeeCollectionBL">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStartDate" runat="server" Text="From Date&nbsp:&nbsp&nbsp;" SkinID="lbl">
                                </asp:Label><br />
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEndDate" runat="server" Text="To Date&nbsp:&nbsp;&nbsp;" SkinID="lbl">
                                </asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="3">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEndDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass " Text="REPORT" SkinID="btn"
                                    ValidationGroup="r" TabIndex="7" meta:resourcekey="btnSaveResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
                <hr />
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" id="TABLE2">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date*&nbsp:&nbsp;&nbsp;" SkinID="lbl">
                            </asp:Label><br />
                            <br />
                            <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtRsz" TabIndex="4"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date*&nbsp:&nbsp;&nbsp;" SkinID="lbl">
                            </asp:Label>
                            <br />
                            <br />
                            <asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="5">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtToDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblTable" runat="server" Text="Select Table*&nbsp:&nbsp;&nbsp;" SkinID="lbl">
                            </asp:Label>
                            <br />
                            <br />
                            <asp:DropDownList ID="ddlTable" runat="server" SkinID="ddl" TabIndex="6" AppendDataBoundItems="True"
                                AutoPostBack="True">
                                <asp:ListItem Value="0">Day Book</asp:ListItem>
                                <asp:ListItem Value="1">Fee Collection</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="btnTd" colspan="3">
                            <asp:Button ID="btnAll" runat="server" CssClass="ButtonClass " Text="ALL" SkinID="btn"
                                OnClientClick="return Validate();" ValidationGroup="r" TabIndex="7" meta:resourcekey="btnSaveResource1" />
                            <asp:Button ID="BtnClear" runat="server" CssClass="ButtonClass " Text="CLEAR" SkinID="btn"
                                OnClientClick="return Validate();" ValidationGroup="r" TabIndex="8" meta:resourcekey="btnSaveResource1" />
                            <asp:Button ID="BtnUnclear" runat="server" CssClass="ButtonClass " Text="UNCLEAR"
                                OnClientClick="return Validate();" SkinID="btnRsz" ValidationGroup="r" TabIndex="9"
                                meta:resourcekey="btnSaveResource1" />
                                <asp:Button ID="btncancel" runat="server" CssClass="ButtonClass " Text="CANCELLED"
                                OnClientClick="return Validate();" SkinID="btnRsz" ValidationGroup="r" TabIndex="10"
                                meta:resourcekey="btnSaveResource1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="btnTd">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table>
                        <tr>
                            <td class="btnTd">
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="500px">
                                <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="True"
                                    AutoGenerateColumns="False" PageSize="100">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Cheque Date">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HidID" runat="server" Value='<%# Bind("ID") %>' />
                                                <asp:Label ID="ChequeDate" runat="server" Text='<%# Bind("ChequeDate","{0:dd-MMM-yyyy}") %>'
                                                    Enabled="true"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Particulars">
                                            <ItemTemplate>
                                                <asp:Label ID="Particulars" runat="server" Text='<%# Bind("Particulars") %>' Enabled="true"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cheque No">
                                            <ItemTemplate>
                                                <asp:Label ID="ChequeNo" runat="server" Text='<%# Bind("ChequeNo") %>' Enabled="true"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cheque Bank">
                                            <ItemTemplate>
                                                <asp:Label ID="ChequeBank" runat="server" Text='<%# Bind("Bank_Name") %>' Enabled="true"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="Amount" runat="server" Text='<%# Bind("Amount","{0:n2}") %>' Enabled="true"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Clearing Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="10" Text='<%# Bind("Clearing_Date","{0:dd-MMM-yyyy}") %>'
                                                    Width="50px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                                    Format="dd-MMM-yyyy" TargetControlID="txtEndDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="StatusFlag" runat="server" Visible="false" Text='<%# Bind("ChequeStatusFlag") %>'></asp:Label>
                                                <asp:CheckBox ID="ChkStatus" runat="server" Enabled="true" Width="75px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="StatusFlag1" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                <asp:Label ID="Clear" runat="server" Width="75px" Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField >
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkAll1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll1" Text="Cheque Bounce"/>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="ChequeBounceFlag" runat="server" Visible="false" Text='<%# Bind("ChequeBounceFlag") %>'></asp:Label>
                                                <asp:CheckBox ID="ChkStatus1" runat="server" Enabled="true" Width="75px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Cheque Bounce Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtChequeBounceDate" runat="server" SkinID="txt" TabIndex="12" Text='<%# Bind("ChequeBounceDate","{0:dd-MMM-yyyy}") %>'
                                                    Width="40px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender21" runat="server" Animated="False"
                                                    Format="dd-MMM-yyyy" TargetControlID="txtChequeBounceDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </asp:Panel>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass " Text="UPDATE" SkinID="btn"
                                    ValidationGroup="r" TabIndex="9" meta:resourcekey="btnSaveResource1" />
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <asp:ObjectDataSource ID="OdsIdentity" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetBRS" TypeName="BRS" DataObjectTypeName="BRSEntity" UpdateMethod="UpdateRecord">
                </asp:ObjectDataSource>
            </div>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
