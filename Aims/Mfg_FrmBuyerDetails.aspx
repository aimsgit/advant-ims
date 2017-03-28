<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmBuyerDetails.aspx.vb"
    Inherits="Mfg_FrmBuyerDetails" Title="Buyer Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Buyer Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%=TxtName.ClientID%>"), 'Name');

            if (msg != "") {
                document.getElementById("<%=TxtName.ClientID%>").focus();
                return msg;
            }
            msg = CodeField(document.getElementById("<%=txtcode.ClientID%>"), 'Code');

            if (msg != "") {
                document.getElementById("<%=txtcode.ClientID%>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txttin.ClientID%>"), 'TIN');

            if (msg != "") {
                document.getElementById("<%=txttin.ClientID%>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=Txtcstno.ClientID%>"), 'CST NO');

            if (msg != "") {
                document.getElementById("<%=Txtcstno.ClientID%>").focus();
                return msg;
            }
            msg = Field250N(document.getElementById("<%=txtAddress.ClientID%>"), 'Address');

            if (msg != "") {
                document.getElementById("<%=txtAddress.ClientID%>").focus();
                return msg;
            }
            msg = Field50N(document.getElementById("<%=txtcity.ClientID%>"), 'City');

            if (msg != "") {
                document.getElementById("<%=txtcity.ClientID%>").focus();
                return msg;
            }

            msg = YearPostalN(document.getElementById("<%=txtpostalcode.ClientID%>"), 'Postal Code');

            if (msg != "") {
                document.getElementById("<%=txtpostalcode.ClientID%>").focus();
                return msg;

            }

            msg = valcontactN(document.getElementById("<%=txtcntct.ClientID%>"), 'Contact No');

            if (msg != "") {
                document.getElementById("<%=txtcntct.ClientID%>").focus();
                return msg;

            }

            msg = numeric(document.getElementById("<%=txtfaxno.ClientID%>"), 'Fax No');

            if (msg != "") {
                document.getElementById("<%=txtfaxno.ClientID%>").focus();
                return msg;

            }
            msg = Field50N(document.getElementById("<%=txtfaxno.ClientID%>"), 'Fax No');

            if (msg != "") {
                document.getElementById("<%=txtfaxno.ClientID%>").focus();
                return msg;

            }
            msg = Field50N(document.getElementById("<%=Txtemail.ClientID%>"), 'Email');

            if (msg != "") {
                document.getElementById("<%=Txtemail.ClientID%>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=Txtdiscount.ClientID%>"), 'Discount');

            if (msg != "") {
                document.getElementById("<%=Txtdiscount.ClientID%>").focus();
                return msg;

            }
            msg = numeric(document.getElementById("<%=txtcreditbills.ClientID%>"), 'Credit Bills');

            if (msg != "") {
                document.getElementById("<%=txtcreditbills.ClientID%>").focus();
                return msg;

            }
            msg = numeric(document.getElementById("<%=txtcreditP.ClientID%>"), 'Credit Period');

            if (msg != "") {
                document.getElementById("<%=txtcreditP.ClientID%>").focus();
                return msg;

            }
            //            msg = numeric(document.getElementById("<%=txtcreditlimitpays.ClientID%>"), 'Credit Limit');

            //            if (msg != "") {
            //                document.getElementById("<%=txtcreditlimitpays.ClientID%>").focus();
            //                return msg;

            //            }
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=Txtbuyertorec.ClientID%>"), 'DR');

            if (msg != "") {
                document.getElementById("<%=Txtbuyertorec.ClientID%>").focus();
                return msg;

            }
            msg = FeesFieldAcceptDecimalN(document.getElementById("<%=Txtbuyertopay.ClientID%>"), 'CR');

            if (msg != "") {
                document.getElementById("<%=Txtbuyertopay.ClientID%>").focus();
                return msg;

            }

            msg = NameField100(document.getElementById("<%=txtopeningBal.ClientID%>"), 'Date');

            if (msg != "") {
                document.getElementById("<%=txtopeningBal.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtopeningBal.ClientID%>"), 'Date');

            if (msg != "") {
                document.getElementById("<%=txtopeningBal.ClientID%>").focus();
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
                            BUYER DETAILS</h1>
                    </center>
                    <br />
                    <br />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td>
                                    <b>Buyer Info</b>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Lblname" runat="server" Text="Name*^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtName" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:CheckBox ID="ChkSupplier" runat="server" TabIndex="14" />
                                </td>
                                <td align="left">
                                    <asp:Label ID="Lblbuyer" runat="server" Text="Supplier" SkinID="lblRsz" Width="150"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcode" runat="server" Text="Code*^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcode" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblfaxno" runat="server" Text="Fax No :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfaxno" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="right">
                                <td>
                                    <asp:Label ID="lblarea" runat="server" SkinID="lbl" Text="Area :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlArea" runat="server" DataSourceID="ObjArea" DataTextField="Area"
                                        DataValueField="Area_code" SkinID="ddl" TabIndex="3">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Email :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="Txtemail" runat="server" SkinID="txt" TabIndex="16"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblreg" runat="server" Text="Registered :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="Chkreg" runat="server" TabIndex="4" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblse" runat="server" SkinID="lbl" Text="SE :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DdlSE" runat="server" DataSourceID="ObjSE" DataTextField="MR_Name"
                                        DataValueField="MR_ID" SkinID="ddl" TabIndex="17">
                                        <asp:ListItem Value="0" Text="Select">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbltin" runat="server" Text="TIN :&nbsp;&nbsp;" SkinID="lblRsz" Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttin" runat="server" SkinID="txt" TabIndex="5" MaxLength="50"></asp:TextBox>
                                </td>
                                <td style="height: 18px" align="center">
                                    <b>Account Info</b>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcst" runat="server" Text="CST No :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtcstno" runat="server" SkinID="txt" TabIndex="6" MaxLength="50"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbldislock" runat="server" Text="Discount Lock :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="Chklock" runat="server" TabIndex="18" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbldlno" runat="server" Text="Driving License No :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdlno" runat="server" SkinID="txt" TabIndex="7" MaxLength="15"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbldicount" runat="server" Text="Discount :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtdiscount" runat="server" SkinID="txt" TabIndex="19"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Contact Info</b>
                                </td>
                                <td>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblcreditbills" runat="server" Text="Credit Bills :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcreditbills" runat="server" SkinID="txt" TabIndex="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 18px">
                                    <asp:Label ID="lbladdrs" runat="server" Text="Address :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td style="height: 18px">
                                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txt" TextMode="MultiLine" TabIndex="8"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblcreditP" runat="server" Text="Credit Period(Days) :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="175"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcreditp" runat="server" SkinID="txt" TabIndex="21" MaxLength="15"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcity" runat="server" Text="City :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcity" runat="server" SkinID="txtRsz" TabIndex="9" Width="150"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Llbcreditlimitpays" runat="server" Text="Credit Limit(Amount) :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="175"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcreditlimitpays" runat="server" SkinID="txt" TabIndex="22" MaxLength="15"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtcreditlimitpays" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblpostalcode" runat="server" Text="Postal Code :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpostalcode" runat="server" SkinID="txt" MaxLength="6" TabIndex="10"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblbuyertopay" runat="server" Text="Buyer to Pay(CR) :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="Txtbuyertopay" runat="server" SkinID="txt" TabIndex="23"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="Txtbuyertopay" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblstate" runat="server" Text="State :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlState" TabIndex="11" MaxLength="60" runat="server" SkinID="ddl"
                                        DataSourceID="ObjState" DataTextField="StateName" DataValueField="StateId" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjState" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetState" TypeName="EnquiryManager">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="0" Name="StateId" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblbuyertorec" runat="server" Text="Buyer to Receive(DR) :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbuyertorec" runat="server" SkinID="txt" TabIndex="24"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtbuyertorec" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="Contact Person :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Txtcntctp" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblopeningBal" runat="server" Text="Opening Balance as on* :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtopeningBal" runat="server" SkinID="txt" TabIndex="25"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="EDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtopeningBal">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcntct" runat="server" Text="Contact No :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcntct" runat="server" SkinID="txt" TabIndex="13" MaxLength="15"></asp:TextBox>
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
                        </table>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" SkinID="btn" TabIndex="26" Text="ADD" />
                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="27"
                                        Text="VIEW" Visible="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
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
                        </table>
                    </center>
                    <center>
                        <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GVSupp" runat="server" SkinID="GridView" AllowPaging="true" AutoGenerateColumns="False"
                                PageSize="100">
                                <Columns>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit" />
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" meta:resourcekey="TemplateFieldResource2">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Party_Id") %>' />
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("Party_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code">
                                        <ItemTemplate>
                                            <asp:Label ID="ll1" runat="server" Text='<%# Bind("Party_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Area">
                                        <ItemTemplate>
                                            <asp:Label ID="larea" runat="server" Visible="false" Text='<%# Bind("Area_code") %>' />
                                            <%--<asp:Label ID="larea" runat="server" Text='<%# Bind("Area_code") %>' Visible="false"></asp:Label>--%>
                                            <asp:Label ID="lblarea" runat="server" Text='<%# Bind("Area") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Registered">
                                        <ItemStyle Wrap="true" HorizontalAlign="Center"/>
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("Registered_Party") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TIN">
                                        <ItemTemplate>
                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("TIN_Number") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CST No">
                                        <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("CST_Number") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Driving License No">
                                        <ItemTemplate>
                                            <asp:Label ID="l11" runat="server" Text='<%# Bind("DL_Number") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="l6" runat="server" Width="150" Text='<%# Bind("Party_Address") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="l7" runat="server" Text='<%# Bind("City") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Postal Code">
                                        <ItemTemplate>
                                            <asp:Label ID="l8" runat="server" Text='<%# Bind("Zip") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State">
                                        <ItemStyle Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="l9" runat="server" Text='<%# Bind("StateName") %>' />
                                            <asp:Label ID="stateid" Visible="false" runat="server" Text='<%# Bind("state") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Person">
                                        <ItemTemplate>
                                            <asp:Label ID="l12" runat="server" Text='<%# Bind("Contact_Person") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No">
                                        <ItemTemplate>
                                            <asp:Label ID="l13" runat="server" Text='<%# Bind("Contact_Number") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fax No.">
                                        <ItemTemplate>
                                            <asp:Label ID="l15" runat="server" Text='<%# Bind("Fax") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="l16" runat="server" Text='<%# Bind("Email") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SE">
                                        <ItemTemplate>
                                            <asp:Label ID="lse" runat="server" Text='<%# Bind("MR_ID") %>' Visible="false" />
                                            <asp:Label ID="lblse" runat="server" Text='<%# Bind("MR_Name") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount Lock">
                                        <ItemTemplate>
                                            <asp:Label ID="ldlck" runat="server" Text='<%# Bind("DiscountLock") %>' />
                                            <asp:Label ID="lblGVDiscount" runat="server" Visible="false" Text='<%# Bind("Discount") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign ="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit Bills">
                                        <ItemTemplate>
                                            <asp:Label ID="lbills" runat="server" Text='<%# Bind("NoOfBills") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit Period (Days)">
                                        <ItemTemplate>
                                            <asp:Label ID="l17" runat="server" Text='<%# Bind("Credit_Period") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit Limit(Amount)">
                                        <ItemStyle Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="l18" runat="server" Text='<%# Bind("Credit_Limit","{0:n2}") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Buyer to Pay(CR)">
                                        <ItemTemplate>
                                            <asp:Label ID="l19" runat="server" Text='<%# Bind("Opening_Balance_CR","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Buyer to Receive(DR)">
                                        <ItemTemplate>
                                            <asp:Label ID="l20" runat="server" Text='<%# Bind("Opening_Balance_DR","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opening Balance as on">
                                        <ItemTemplate>
                                            <asp:Label ID="l21" runat="server" Text='<%# Bind("OpBalanceDate","{0:dd-MMM-yyyy}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjArea" runat="server" SelectMethod="GetAreaCobmo" TypeName="SupplierDB">
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjSE" runat="server" SelectMethod="GetSECobmo" TypeName="SupplierDB">
                            </asp:ObjectDataSource>
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
