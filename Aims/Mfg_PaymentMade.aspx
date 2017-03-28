<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_PaymentMade.aspx.vb"
    Inherits="Mfg_PaymentMade" Title="Payment Made" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payment Made</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=cmbCurrency.ClientID%>"), 'Currency');

            if (msg != "") {
                document.getElementById("<%=cmbCurrency.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtEntryDate.ClientID%>"), 'Entry Date');

            if (msg != "") {
                document.getElementById("<%=txtEntryDate.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DdlSuplier.ClientID%>"), 'Supplier');

            if (msg != "") {
                document.getElementById("<%=DdlSuplier.ClientID%>").focus();
                return msg;
            }
            
            msg = DropDownForZero(document.getElementById("<%=ddlInvoiceNo.ClientID%>"), 'Invoice No.');

            if (msg != "") {
                document.getElementById("<%=ddlInvoiceNo.ClientID%>").focus();
                return msg;

            }
            msg = Field50(document.getElementById("<%=txtAmntPaid.ClientID%>"), 'Amount Paid');

            if (msg != "") {
                document.getElementById("<%=txtAmntPaid.ClientID%>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txtAmntPaid.ClientID%>"), 'Amount Paid');

            if (msg != "") {
                document.getElementById("<%=txtAmntPaid.ClientID%>").focus();
                return msg;
            }

            msg = ValidateDate(document.getElementById("<%=TxtRdate.ClientID%>"), 'Receive Date');

            if (msg != "") {
                document.getElementById("<%=TxtRdate.ClientID%>").focus();
                return msg;
            }


            msg = DropDownForZero(document.getElementById("<%=ddlPaymentMethod.ClientID%>"), 'Payment Method');

            if (msg != "") {
                document.getElementById("<%=ddlPaymentMethod.ClientID%>").focus();
                return msg;

            }

            msg = numeric(document.getElementById("<%=TxtVno.ClientID%>"), 'Voucher No');

            if (msg != "") {
                document.getElementById("<%=TxtVno.ClientID%>").focus();
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
                <center>
                    <h1 class="headingTxt">
                        PAYMENT MADE</h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcourse" runat="server" Text="Currency*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbCurrency" TabIndex="3" runat="server" SkinID="ddl" DataSourceID="ObjMC"
                                    AutoPostBack="true" DataValueField="Currency_Code" DataTextField="Currency_Name">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjMC" runat="server" SelectMethod="GetMulticurrency" TypeName="MultiCurrencyManager">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Exchange Rate*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txtexchangerate" runat="server" SkinID="txt" AutoPostBack="true"
                                    TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblopeningBal" runat="server" Text="Entry Date&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="200"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEntryDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="EDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtEntryDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Supplier*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlSuplier" runat="server" SkinID="ddl" DataSourceID="objsupplier"
                                    TabIndex="4" DataTextField="Supp_Name" DataValueField="Supp_Id" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objsupplier" runat="server" SelectMethod="GetSupplier"
                                    TypeName="Mfg_DLPaymentMade"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 18px">
                                <asp:Label ID="lbladdrs" runat="server" Text="Address&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150"></asp:Label>
                            </td>
                            <td style="height: 18px">
                                <asp:TextBox ID="txtAddress" runat="server" SkinID="txt" TextMode="MultiLine" TabIndex="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="Invoice No.*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlInvoiceNo" runat="server" SkinID="ddl" DataSourceID="objInvoiceNo"
                                    TabIndex="6" DataTextField="Purchase_Invoice_No" DataValueField="Purchase_Invoice_ID"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objInvoiceNo" runat="server" SelectMethod="GetInvoiceNo"
                                    TypeName="Mfg_DLPaymentMade">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlSuplier" DefaultValue="0" Name="Supp_Id" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcity" runat="server" Text="Amount Paid*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAmntPaid" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                            </td>
                            <td align="right">
                                <b>Payment Details</b>
                            </td>
                            <td align="left">
                                <b>(Default Currency)</b>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Received Date*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="200"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtRdate" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="TxtRdate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td align="right" style="height: 18px">
                                <asp:Label ID="Label11" runat="server" Text="Payable&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150"></asp:Label>
                            </td>
                            <td style="height: 18px">
                                <asp:TextBox ID="Txtpayable1" ReadOnly="true" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPaymentMethod" runat="server" SkinID="lblRsz" Width="150" Text="Payment Method*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataSourceID="ObjPaymentMethod"
                                    DataTextField="Payment_Method" DataValueField="PaymentMethodID" AppendDataBoundItems="true"
                                    SkinID="ddl" TabIndex="9" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodCombo"
                                    TypeName="FeeCollectionBL"></asp:ObjectDataSource>
                            </td>
                            <td align="right" style="height: 18px">
                                <asp:Label ID="Label12" runat="server" Text="Total Paid&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150"></asp:Label>
                            </td>
                            <td style="height: 18px">
                                <asp:TextBox ID="Txttotalpaid1" ReadOnly="true" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" Text="Voucher No.&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtVno" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                            </td>
                            <td align="right" style="height: 18px">
                                <asp:Label ID="Label13" runat="server" Text="Balance&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150"></asp:Label>
                            </td>
                            <td style="height: 18px">
                                <asp:TextBox ID="Txtbalance1" ReadOnly="true" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAmountPaid" runat="server" SkinID="lbl" Text="Cheque No.&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChqno" runat="server" SkinID="txt" AutoPostBack="true" TabIndex="11"></asp:TextBox>
                            </td>
                            <td align="right">
                                <b>Payment Details </b>
                            </td>
                            <td align="left">
                                <b>(Selected Currency)</b>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBank" runat="server" SkinID="lbl" Text="Bank&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBank" runat="server" DataSourceID="ObjBank" DataTextField="Bank_Name"
                                    DataValueField="Bank_IDAuto" AppendDataBoundItems="true" SkinID="ddl" TabIndex="12">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBank" runat="server" SelectMethod="BankComboD1" TypeName="feeCollectionDL">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right" style="height: 18px">
                                <asp:Label ID="Label8" runat="server" Text="Payable&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150"></asp:Label>
                            </td>
                            <td style="height: 18px">
                                <asp:TextBox ID="Txtpayable" ReadOnly="true" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" SkinID="lbl" Text="Branch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txtbranch" runat="server" SkinID="txt" AutoPostBack="true" TabIndex="13"></asp:TextBox>
                            </td>
                            <td align="right" style="height: 18px">
                                <asp:Label ID="Label9" runat="server" Text="Total Paid&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150"></asp:Label>
                            </td>
                            <td style="height: 18px">
                                <asp:TextBox ID="Txttotalpaid" ReadOnly="true" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="txt" AutoPostBack="true" TabIndex="14"></asp:TextBox>
                            </td>
                            <td align="right" style="height: 18px">
                                <asp:Label ID="Label10" runat="server" Text="Balance&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150"></asp:Label>
                            </td>
                            <td style="height: 18px">
                                <asp:TextBox ID="Txtbalance" ReadOnly="true" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <tr align="center">
                                <td colspan="5">
                                    <br />
                                    <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CommandName="Update"
                                        CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="15"
                                        Text="ADD" ValidationGroup="edit" />
                                    &nbsp<asp:Button ID="btnView" runat="server" CausesValidation="false" CssClass="ButtonClass"
                                        SkinID="btn" TabIndex="16" Text="VIEW" />
                                </td>
                            </tr>
                        </tr>
                    </table>
                </center>
                <center>
                    <br />
                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    <br />
                    <br />
                </center>
                <div>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GVPaymentMade" runat="server" SkinID="GridView" AllowPaging="True"
                                AutoGenerateColumns="False" PageSize="100">
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
                                    <asp:TemplateField HeaderText="Currency" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblcurrency" Visible="false" runat="server" Text='<%#Bind("Currency_Code") %>'></asp:Label>
                                            <asp:Label ID="Lblcurrency1" Visible="false" runat="server" Text='<%#Bind("Currency_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Entry Date" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblentrydate" Visible="false" runat="server" Text='<%#Bind("Entry_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbladdress" Visible="false" runat="server" Text='<%#Bind("Field10") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Voucher No." Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblvno" Visible="false" runat="server" Text='<%#Bind("Field2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Supplier" SortExpression="Supplier">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="GID" runat="server" Value='<%# Bind("Payments_Id") %>' />
                                            <asp:Label ID="Lblsupname" runat="server" Visible="false" Text='<%# Bind("Supp_Id_Auto") %>'></asp:Label>
                                            <asp:Label ID="Lblsupname1" runat="server" Text='<%# Bind("Supp_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice No.">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblinvno" runat="server" Visible="false" Text='<%#Bind("Purchase_Invoice_ID") %>'></asp:Label>
                                            <asp:Label ID="Lblinvno1" runat="server" Text='<%#Bind("Purchase_Invoice_No") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Paid">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbldaterec" runat="server" Text='<%#Bind("Date_Received","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amt Paid">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblamtpaid" runat="server" Text='<%#Bind("Amt_Paid","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Payment Method">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblpmethod" runat="server" Visible="false" Text='<%#Bind("PaymentMethodIDAuto") %>'></asp:Label>
                                            <asp:Label ID="Lblpmethod1" runat="server" Text='<%#Bind("Payment_Method") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bank">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblbankname" runat="server" Visible="false" Text='<%#Bind("Bank_IDAuto") %>'></asp:Label>
                                            <asp:Label ID="Lblbankname1" runat="server" Text='<%#Bind("Bank_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblbranch" runat="server" Text='<%#Bind("Branch") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque No.">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblchqno" runat="server" Text='<%#Bind("Cheque_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblremarks" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                    <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="True"
                        AutoGenerateColumns="False" PageSize="100" Visible="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Amt Paid">
                                <ItemTemplate>
                                    <asp:Label ID="Lblamtpaid1" runat="server" Text='<%#Bind("Amt_Paid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseCombo"
                        TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
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
