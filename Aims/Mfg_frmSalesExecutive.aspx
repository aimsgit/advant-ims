<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmSalesExecutive.aspx.vb"
    Inherits="Mfg_frmSalesExecutive" Title="Sales Executive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sales Executive</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%= txtName.ClientID %>"), 'SE Name');
            if (msg != "") {
                document.getElementById("<%= txtName.ClientID %>").focus();
                return msg;
            }
            msg = OneChar(document.getElementById("<%= txtCode.ClientID %>"), 'Code');
            if (msg != "") {
                document.getElementById("<%= txtCode.ClientID %>").focus();
                return msg;
            }
            msg = AgeFieldN(document.getElementById("<%= txtAge.ClientID %>"), 'Age');
            if (msg != "") {
                document.getElementById("<%= txtAge.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%= txtDOJ.ClientID %>"), 'Date of Joining');
            if (msg != "") {
                document.getElementById("<%= txtDOJ.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%= txtDOL.ClientID %>"), 'Date of Leaving');
            if (msg != "") {
                document.getElementById("<%= txtDOL.ClientID %>").focus();
                return msg;

            }
            msg = FeesFieldN(document.getElementById("<%= txtTarget.ClientID %>"), 'Target Value');
            if (msg != "") {
                document.getElementById("<%= txtTarget.ClientID %>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%= txtTarget.ClientID %>"), 'Target Value');
            if (msg != "") {
                document.getElementById("<%= txtTarget.ClientID %>").focus();
                return msg;
            }
            msg = FeesFieldN(document.getElementById("<%= txtOpeningBal.ClientID %>"), 'Opening Balance');
            if (msg != "") {
                document.getElementById("<%= txtOpeningBal.ClientID %>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%= txtOpeningBal.ClientID %>"), 'Opening Balance');
            if (msg != "") {
                document.getElementById("<%= txtOpeningBal.ClientID %>").focus();
                return msg;
            }

            msg = NameField250NE(document.getElementById("<%= txtAddress.ClientID %>"), 'Address');
            if (msg != "") {
                document.getElementById("<%= txtAddress.ClientID %>").focus();
                return msg;
            }
            msg = Field50N(document.getElementById("<%= txtState.ClientID %>"), 'State');
            if (msg != "") {
                document.getElementById("<%= txtState.ClientID %>").focus();
                return msg;
            }
            msg = Field50N(document.getElementById("<%= txtCountry.ClientID %>"), 'Country');
            if (msg != "") {
                document.getElementById("<%= txtCountry.ClientID %>").focus();
                return msg;
            }
            //           msg = validateEmailN(document.getElementById("<%= txtEmail.ClientID %>"), 'Email');
            //           if (msg != "") {
            //               document.getElementById("<%= txtEmail.ClientID %>").focus();
            //               return msg;
            //           }
            msg = valcontactN(document.getElementById("<%= txtContact.ClientID %>"), 'Contact');
            if (msg != "") {
                document.getElementById("<%= txtContact.ClientID %>").focus();
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
                <center>
                    <h1 class="headingTxt">
                        SALE EXECUTIVE
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" Width="150px" runat="server" Text="SE Name*^ :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtName" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="Code*^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCode" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Age :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAge" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Text="Date of Joining^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDOJ" runat="server" SkinID="txt" MaxLength="15" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion" runat="server" TargetControlID="txtDOJ"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Text="Date of Leaving^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDOL" runat="server" SkinID="txt" MaxLength="15" TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOL"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" SkinID="lblRsz" Text="Grade :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtGrade" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Target Value :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTarget" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtTarget" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Text="Opening Balance :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtOpeningBal" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtOpeningBal" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" SkinID="lblRsz" Text="Address :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label10" runat="server" SkinID="lblRsz" Text="State :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtState" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" SkinID="lblRsz" Text="Country :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCountry" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label12" runat="server" SkinID="lblRsz" Text="Email :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmail" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label13" runat="server" SkinID="lblRsz" Text="Contact No :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtContact" runat="server" SkinID="txt" MaxLength="15" TabIndex="13"></asp:TextBox>
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
                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="14"
                                    Text="ADD" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="15" Text="VIEW" />
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
                        <asp:GridView ID="GridSales" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="100" SkinID="GridView" Width="368px">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="16"
                                            CommandName="Edit" Text="Edit" />
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="17"
                                            Visible="false" CommandName="Delete" Text="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SE Name" Visible="true">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Label5" runat="server" Value='<%# Bind("MR_ID") %>'></asp:HiddenField>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("MR_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" runat="server" Text='<%# Bind("MR_Code") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Age">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAge" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Joining">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldoj" runat="server" Text='<%# Bind("DOJ","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Leaving">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldol" runat="server" Text='<%# Bind("DOL","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Grade">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrade" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Target Value">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTarget" runat="server" Text='<%# Bind("Target_Value","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opening Balance">
                                    <ItemTemplate>
                                        <asp:Label ID="lblopen" runat="server" Text='<%# Bind("OpeningBalance","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddress" runat="server" Width="150px" Text='<%# Bind("MR_Address") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstate" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EMail") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact no">
                                    <ItemTemplate>
                                        <asp:Label ID="lblph" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
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

