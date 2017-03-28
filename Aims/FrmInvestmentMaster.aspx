<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmInvestmentMaster.aspx.vb"
    Inherits="FrmInvestmentMaster" Title="Endowment Deposit Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Endowment Deposit Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            //Function for Multilingual Validations
            //Created By Niraj
            function ErrorMessage(msg) {
                var SesVar = '<%= Session("Validation") %>';
                var ValidationArray = new Array();
                ValidationArray = SesVar.split(":");
                for (var i = 0; i < ValidationArray.length - 1; i++) {
                    if (ValidationArray[i] == msg) {
                        return ValidationArray[i + 1];
                    }
                }
            }


            function Spliter(a) {
                var str = a;
                var n = str.indexOf("*");
                if (n != 0 && n != -1) {
                    a = a.split("*");
                    return a[0];
                }
                var n = str.indexOf("^");
                if (n != 0 && n != -1) {
                    a = a.split("^");
                    return a[0];
                }
                var n = str.indexOf(":");
                if (n != 0 && n != -1) {
                    a = a.split(":");
                    return a[0];
                }
            }
            var msg;
          
            msg = DropDownForZeroMul(document.getElementById("<%=cmbSponsor.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=cmbSponsor.ClientID%>").focus();
                a = document.getElementById("<%=lblsof.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field50Mul(document.getElementById("<%=TxtInvest.ClientID%>")); 

            if (msg != "") {
                document.getElementById("<%=TxtInvest.ClientID%>").focus();
                a = document.getElementById("<%=lblinvestment.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=cmbCurrency.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=cmbCurrency.ClientID%>").focus();
                a = document.getElementById("<%=lblcurrency.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMul(document.getElementById("<%=Txtstdate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=Txtstdate.ClientID%>").focus();
                a = document.getElementById("<%=Lblstdate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlPaymentMethod.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=ddlPaymentMethod.ClientID%>").focus();
                a = document.getElementById("<%=Lblmop.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblsof" runat="server" SkinID="lblRsz" Text="Source of Fund*^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="cmbSponsor" runat="server" Width="250 px" DataSourceID="Objsponsor"
                                    DataTextField="SponsorName" SkinID="ddlRsz" AutoPostBack="true" DataValueField="Sponsor_IDAuto"
                                    TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="Objsponsor" runat="server" SelectMethod="GetSponsor" TypeName="DLInvestmentMaster">
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblinvestment" runat="server" SkinID="lblRsz" Text="Investment Amt* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtInvest" runat="server" SkinID="txt" TabIndex="2" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="TxtInvest" />
                            </td>
                            <td align="right">
                                <asp:Label ID="Lblmop" runat="server" Text="Payment Mode*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="160px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataSourceID="ObjPaymentMethod"
                                    DataTextField="Payment_Method" DataValueField="PaymentMethodID" AutoPostBack="true"
                                    AppendDataBoundItems="true" SkinID="ddl" TabIndex="8">
                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodCombo"
                                    TypeName="FeeCollectionBL"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcurrency" runat="server" Text="Currency*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbCurrency" TabIndex="3" runat="server" SkinID="ddl" DataSourceID="ObjMC"
                                    AutoPostBack="true" DataValueField="Currency_Code" DataTextField="Currency_Name">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjMC" runat="server" SelectMethod="GetMulticurrency" TypeName="MultiCurrencyManager">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="Lblroi" runat="server" SkinID="lblRsz" Text="Interest Rate %&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtroi" runat="server" SkinID="txt" TabIndex="9" AutoPostBack="True"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="Txtroi" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblinvtype" runat="server" Text="Investment Type&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtinvtype" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Lblint" runat="server" SkinID="lblRsz" Text="Interest Amt :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAmt" runat="server" SkinID="txt" TabIndex="10" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAmt" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblstdate" runat="server" Text="Invst St Date*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtstdate" runat="server" SkinID="txt" MaxLength="11" TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txtstdate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="Lbladmin" runat="server" SkinID="lbl" Text="Admin Cost %&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtadmin" runat="server" SkinID="txt" TabIndex="11" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="Txtadmin" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblmdate" runat="server" Text="Invst Maturity Date&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtmdate" runat="server" SkinID="txt" MaxLength="11" TabIndex="6"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txtmdate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="LblAdminAmt" runat="server" SkinID="lbl" Text="Admin Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtAdAmt" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="TxtAdAmt" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBank" runat="server" SkinID="lbl" Text="Bank&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBank" runat="server" DataSourceID="ObjBank" DataTextField="Bank_Name"
                                    DataValueField="Bank_IDAuto" AppendDataBoundItems="true" SkinID="ddl" TabIndex="7">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBank" runat="server" SelectMethod="BankComboD1" TypeName="feeCollectionDL">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="Lblbal" runat="server" SkinID="lbl" Text="Balance Amt&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtbal" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="Txtbal" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="right">
                                <asp:Label ID="Lblremark" runat="server" SkinID="lblRsz" Text="Remarks :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtremark" runat="server" TextMode="MultiLine" SkinID="txt" TabIndex="14"></asp:TextBox>
                            </td>
                        </tr>
                </center>
                </table>
                <center>
                    <table>
                        <tr>
                            <td colspan="2" class="btnTd" align="center">
                                <br />
                                <br />
                                <asp:Button ID="btnadd" runat="server" SkinID="btn" CausesValidation="True" Text="ADD" CommandName="ADD" 
                                    TabIndex="15" CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>&nbsp;
                                <asp:Button ID="btndetails" runat="server" SkinID="btn" CausesValidation="False"
                                    CommandName="VIEW" Text="VIEW" TabIndex="16" CssClass="ButtonClass"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                            </td>
                        </tr>
                        <tr>
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
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GVInvestment" runat="server" SkinID="gridview" AllowPaging="True"
                                        AutoGenerateColumns="False" Style="margin-right: 0px" PageSize="100" AllowSorting="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" Font-Underline="False"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false"></ItemStyle>
                                                <ItemStyle HorizontalAlign="Left" Font-Underline="False" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ControlStyle Font-Underline="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Source Of Fund" SortExpression="SponsorName">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("IMAutoID") %>' />
                                                    <asp:Label ID="lbl1" runat="server" Width="150px" Text='<%# Bind("SponsorName") %>'></asp:Label>
                                                    <asp:Label ID="Lblsponsorid" Visible="false" runat="server" Text='<%# Bind("Sponsor_ID") %>'></asp:Label>
                                                    <itemstyle wrap="True" horizontalalign="left" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" />
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Investment Amt">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblinvamt" Visible="true" runat="server" Text='<%# Bind("InvestmentAmount","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Currency">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblcurrency" Visible="false" runat="server" Text='<%#Bind("Currency") %>'></asp:Label>
                                                    <asp:Label ID="Lblcurrency1" runat="server" Text='<%#Bind("Currency_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Investment Type" SortExpression="InvestmentType">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblinvtype" Visible="True" runat="server" Text='<%#Bind("InvestmentType") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invst St Date"  SortExpression="InvestmentSTDT">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblst" runat="server" Text='<%# Bind("InvestmentSTDT","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" Wrap="False"></ItemStyle>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invst Maturity Date" SortExpression="InvestmentMaturityDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblm" runat="server" Text='<%# Bind("InvestmentMaturityDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" Wrap="False"></ItemStyle>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bank" SortExpression="Bank_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl7" Visible="false" runat="server" Text='<%#Bind("BankID") %>'></asp:Label>
                                                    <asp:Label ID="Lblbank" runat="server" Text='<%#Bind("Bank_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Payment Mode" SortExpression="Payment_Method">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmop1" runat="server" Text='<%# Bind("Payment_Method") %>'></asp:Label>
                                                    <asp:HiddenField ID="HidP" runat="server" Value='<%# Bind("PaymentMethodIDAuto") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Interest Rate %" SortExpression="Rateofinterest">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblroi1" runat="server" Text='<%# Bind("Rateofinterest") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" Width="50" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Interest Amt" SortExpression="InterestAmt">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbliamt" runat="server" Text='<%# Bind(Format"InterestAmt","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Right" Width="50" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Admin Cost %" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblacost" runat="server" Text='<%# Bind("AdminCost","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Right" Width="50" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Admin Amount" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbladamt" runat="server" Text='<%# Bind("Admin_amt","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Right" Width="50" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Balance Amt" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblbamt" runat="server" Text='<%# Bind("BalanceAmt","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Right" Width="50" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblrm" runat="server" Width="150" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                </center>
                </table>
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

