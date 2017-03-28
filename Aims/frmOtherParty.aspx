<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmOtherParty.aspx.vb"
    Inherits="frmOtherParty" Title="Other Party Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Other Party Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
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
        function Valid() {
            var msg;
            msg = NameField100Mul(document.getElementById("<%=NameTextBox.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=NameTextBox.ClientID %>").focus();
                a = document.getElementById("<%=partyname.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField100Mul(document.getElementById("<%=OpidTextBox.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=OpidTextBox.ClientID %>").focus();
                a = document.getElementById("<%=partyid.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field250MulN(document.getElementById("<%=AddressTextBox.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=AddressTextBox.ClientID %>").focus();
                a = document.getElementById("<%=address.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field250MulN(document.getElementById("<%=CityTextBox.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=CityTextBox.ClientID %>").focus();
                a = document.getElementById("<%=city.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = PostalCodeNMul(document.getElementById("<%=PcodeTextBox.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=PcodeTextBox.ClientID%>").focus();
                a = document.getElementById("<%=pincode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }

            //            msg = valcontactN(document.getElementById("<%=ContactnoTextBox.ClientID%>"), 'Contact No');

            //            if (msg != "") {
            //                document.getElementById("<%=ContactnoTextBox.ClientID%>").focus();
            //                return msg;

            //            }

            //            msg = numeric(document.getElementById("<%=Txtfaxno.ClientID%>"), 'Fax No');

            //            if (msg != "") {
            //                document.getElementById("<%=Txtfaxno.ClientID%>").focus();
            //                return msg;

            //            }
            msg = numericMul(document.getElementById("<%=CreditperiodTextBox.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=CreditperiodTextBox.ClientID%>").focus();
                a = document.getElementById("<%=creditperiod.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }
            msg = numericMul(document.getElementById("<%=CreditlimitTextBox.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=CreditlimitTextBox.ClientID%>").focus();
                a = document.getElementById("<%=creditlimit.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtpartytopay.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=txtpartytopay.ClientID%>").focus();
                a = document.getElementById("<%=balancecr.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }
            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtpartytorec.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=txtpartytorec.ClientID%>").focus();
                a = document.getElementById("<%=balancedr.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }

            msg = NameField100Mul(document.getElementById("<%=OpBalanceDateTextBox.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=OpBalanceDateTextBox.ClientID%>").focus();
                a = document.getElementById("<%=balancedate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMul(document.getElementById("<%=OpBalanceDateTextBox.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=OpBalanceDateTextBox.ClientID%>").focus();
                a = document.getElementById("<%=balancedate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID%>").textContent = "";
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
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div class="mainBlock">
                    <center>
                        <%--<h1 class="headingTxt">
                            OTHER PARTY DETAILS</h1>
                    </center>
                    <br />
                    <br />--%>
                    <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                            <br />
                            <br />
                        </h1>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="center">
                                  <asp:Label ID="Labeopi" runat="server" Text="Other Party Info" SkinID="lblBlackRsz" Width="150" Visible="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="partyname" runat="server" Text="Name*^&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="NameTextBox" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Lblfaxno" runat="server" SkinID="lbl" Text="Fax No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtfaxno" runat="server" SkinID="txt" Width="133px" TabIndex="9"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="Txtfaxno">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="partyid" runat="server" Text="Code*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="OpidTextBox" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="email" runat="server" SkinID="lbl" Text="Email ID&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="EmailTextBox" runat="server" SkinID="txt" Width="133px" TabIndex="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="address" runat="server" SkinID="lbl" Text="Address&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="AddressTextBox" runat="server" SkinID="txt" Width="133px" TabIndex="3"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td align="center">
                                  <asp:Label ID="LabelAcc" runat="server" Text="Account Info" SkinID="lblBlackRsz" Width="150" Visible="True"></asp:Label>
                                </td>
                                <%--<td align="center">
                                    <b>Account Info</b>
                                </td>--%>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="city" runat="server" Text="City&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CityTextBox" runat="server" SkinID="txt" Width="133px" TabIndex="4"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="creditperiod" runat="server" SkinID="lblRsz" Width="175" Text="Credit Period(Days)&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CreditperiodTextBox" runat="server" SkinID="txt" Width="133px" TabIndex="11"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="CreditperiodTextBox" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="pincode" runat="server" SkinID="lbl" Text="Postal Code&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="PcodeTextBox" runat="server" SkinID="txt" Width="133px" TabIndex="5">
                                    </asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="creditlimit" runat="server" Text="Credit Limit(Amount) :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="175"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CreditlimitTextBox" runat="server" SkinID="txt" Width="133px" TabIndex="12"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="CreditlimitTextBox" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="state" runat="server" Text="State&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="True" DataSourceID="ObjState"
                                        DataTextField="StateName" DataValueField="StateId" SkinID="ddl" TabIndex="6">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjState" runat="server" SelectMethod="GetState" TypeName="EnquiryManager">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="0" Name="StateId" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="balancecr" runat="server" SkinID="lblRsz" Text="Party To Pay(CR) :&nbsp;&nbsp;"
                                        Width="180px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpartytopay" runat="server" SkinID="txt" TabIndex="13" Width="134px"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtpartytopay" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                  <asp:Label ID="LabeContact" runat="server" Text="Contact Info" SkinID="lblBlackRsz" Width="150" Visible="True"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td align="right">
                                    <asp:Label ID="balancedr" runat="server" Text="Party To Receive(DR) :&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpartytorec" runat="server" SkinID="txt" TabIndex="14" Width="135px"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtpartytorec" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="contactperson" runat="server" Text="Contact Person&nbsp;:&nbsp;&amp;nbsp"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ContactpersonTextBox" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="balancedate" runat="server" Text="Opening Balance Date* :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="OpBalanceDateTextBox" runat="server" SkinID="txt" MaxLength="15"
                                        TabIndex="15"></asp:TextBox>
                                </td>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="OpBalanceDateTextBox">
                                </ajaxToolkit:CalendarExtender>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="contactno" runat="server" Text="Contact No&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ContactnoTextBox" runat="server" SkinID="txt" Width="133px" TabIndex="8"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="ContactnoTextBox">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Remarks" runat="server" Text="Remarks&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="RemarkTextBox" runat="server" SkinID="txt" Width="133px" TabIndex="16"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
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
                        <table>
                            <tr>
                                <td colspan="2" class="btnTd" align="center">
                                    <asp:Button ID="btnadd" runat="server" SkinID="btn" CausesValidation="True" Text="ADD" CommandName="ADD"
                                        TabIndex="17" CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>&nbsp;
                                    <asp:Button ID="btndetails" runat="server" SkinID="btn" CausesValidation="False"
                                        CommandName="VIEW" Text="VIEW" TabIndex="18" CssClass="ButtonClass"></asp:Button>
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
                                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </center>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GridView1" runat="server" SkinID="gridview" DataKeyNames="OPAutoNo"
                                        AllowPaging="True" AutoGenerateColumns="False" Style="margin-right: 0px" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" Font-Underline="False"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" Visible="false" Font-Underline="False">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false"></ItemStyle>
                                                <ItemStyle HorizontalAlign="Left" Font-Underline="False" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ControlStyle Font-Underline="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" SortExpression="OP_Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("OPAutoNo") %>' />
                                                    <asp:Label ID="lbl1" runat="server" Text='<%# Bind("OP_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Code" SortExpression="OP_Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl2" runat="server" Text='<%# Bind("OP_Id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl3" runat="server" Text='<%# Bind("OP_Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" Width="50" />
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl4" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Postal Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl5" runat="server" Text='<%# Bind("Postal_Code") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl6" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>
                                                    <asp:Label ID="lbl16" Visible="false" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Person" SortExpression="Contact_Person">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl7" runat="server" Text='<%# Bind("Contact_Person") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl8" runat="server" Text='<%# Bind("Contact_Number1") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fax Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl9" runat="server" Text='<%# Bind("Fax_Number") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lemail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Credit Period" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl10" runat="server" Text='<%# Bind("Credit_Period") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Credit Limit" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl11" align="right" runat="server" Text='<%# Bind("Credit_Limit","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Opening Balance CR" ItemStyle-Wrap="true" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl12" align="right" runat="server" Text='<%# Bind("Opening_Balance_CR","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px" Wrap="True" HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Opening Balance DR" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl13" align="right" runat="server" Text='<%# Bind("Opening_Balance_DR","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Opening Balance Date" SortExpression="OpBalanceDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl14" runat="server" Text='<%# Bind("OpBalanceDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" Wrap="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl15" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" Width="150" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
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
