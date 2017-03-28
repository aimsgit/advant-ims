<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSuppMaster.aspx.vb"
    Inherits="frmSuppMaster" Title="Supplier Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Supplier Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

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

        //Function for Multilingual Validations
        //Created By Ajit Kumar Singh


        function Valid() {

            var msg, a;
            msg = Field50Mul(document.getElementById("<%=TxtName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtName.ClientID %>").focus();
                a = document.getElementById("<%=Lblname.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = CodeFieldMul(document.getElementById("<%=txtcode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtcode.ClientID %>").focus();
                a = document.getElementById("<%=lblcode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = numericMul(document.getElementById("<%=txttin.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txttin.ClientID %>").focus();
                a = document.getElementById("<%=lbltin.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = numericMul(document.getElementById("<%=txtcst.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtcst.ClientID %>").focus();
                a = document.getElementById("<%=lblcst.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field250MulN(document.getElementById("<%=txtAddress.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtAddress.ClientID %>").focus();
                a = document.getElementById("<%=lbladdrs.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }



            msg = PostalCodeNMul(document.getElementById("<%=txtpostalcode.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtpostalcode.ClientID %>").focus();
                a = document.getElementById("<%=lblpostalcode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = numericMul(document.getElementById("<%=txtcreditP.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtcreditP.ClientID %>").focus();
                a = document.getElementById("<%=lblcreditP.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = numericMul(document.getElementById("<%=txtcreditlimit.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtcreditlimit.ClientID %>").focus();
                a = document.getElementById("<%=lblcreditlimit.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtsuptorec.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtsuptorec.ClientID %>").focus();
                a = document.getElementById("<%=lblsuptorec.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            msg = FeesFieldAcceptDecimalNMul(document.getElementById("<%=txtsuptopay.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtsuptopay.ClientID %>").focus();
                a = document.getElementById("<%=lblsuptopay.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = ValidateDateMul(document.getElementById("<%=txtopeningBal.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtopeningBal.ClientID %>").focus();
                a = document.getElementById("<%=lblopeningBal.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }

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
                    <%--<center>
                    <h1 class="headingTxt">
                        SUPPLIER DETAILS</h1>
                </center>--%>
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
                                <td>
                                  <asp:Label ID="LabelSupp" runat="server" Text="Supplier Info" SkinID="lblBlackRsz" Width="150" Visible="True"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td align="right">
                                    <asp:CheckBox ID="ChkBuyer" runat="server" Visible="True" />
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" Text="Buyer" SkinID="lblRsz" Width="150" Visible="True"></asp:Label>
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
                                    <asp:Label ID="LblcontactP" runat="server" Text="Contact Person :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtcntctP" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
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
                                    <asp:Label ID="lblcntct1" runat="server" Text="Contact No1 :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcntct1" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtcntct1">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblreg" runat="server" Text="Registered :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="Chkreg" runat="server" TabIndex="3" />
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblcntct2" runat="server" Text="Contact No2 :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcntct2" runat="server" SkinID="txt" TabIndex="14"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtcntct2">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbltin" runat="server" Text="TIN :&nbsp;&nbsp;" SkinID="lblRsz" Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttin" runat="server" SkinID="txt" TabIndex="4" MaxLength="50"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblfaxno" runat="server" Text="Fax No :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfaxno" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtfaxno">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcst" runat="server" Text="CST No :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcst" runat="server" SkinID="txt" TabIndex="5" MaxLength="50"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblemail" runat="server" Text="Email :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtemail" runat="server" SkinID="txt" TabIndex="16"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelCont" runat="server" Text="Contact Info" SkinID="lblBlackRsz" Width="150" Visible="True"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 18px">
                                    <asp:Label ID="lbladdrs" runat="server" Text="Address :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td style="height: 18px">
                                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txt" TextMode="MultiLine" TabIndex="6"></asp:TextBox>
                                </td>
                                <td style="height: 18px" align="center">
                                      <asp:Label ID="LabelAI" runat="server" Text="Account Info" SkinID="lblBlackRsz" Width="150" Visible="True"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcity" runat="server" Text="City :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcity" runat="server" SkinID="txtRsz" TabIndex="7" Width="150"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblcreditP" runat="server" Text="Credit Period(Days) :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="175"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcreditP" runat="server" SkinID="txt" TabIndex="17" MaxLength="15"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblpostalcode" runat="server" Text="Postal Code :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpostalcode" MaxLength="6" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblcreditlimit" runat="server" Text="Credit Limit(Rs) :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcreditlimit" runat="server" SkinID="txt" TabIndex="18"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblstate" runat="server" Text="State :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlState" TabIndex="9" MaxLength="60" runat="server" SkinID="ddl"
                                        DataSourceID="ObjState" DataTextField="StateName" DataValueField="StateId" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjState" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetState" TypeName="EnquiryManager">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="0" Name="StateId" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <%--<asp:TextBox ID="txtstate" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>--%>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblsuptorec" runat="server" Text="Supplier to Receive(CR) :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsuptorec" runat="server" SkinID="txt" TabIndex="19"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcountry" runat="server" Text="Country :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcountry" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblsuptopay" runat="server" Text="Supplier to Pay(DR) :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsuptopay" runat="server" SkinID="txt" TabIndex="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbldlno" runat="server" Text="Driving Licence No :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdlno" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblopeningBal" runat="server" Text="Opening Balance as on* :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtopeningBal" runat="server" SkinID="txt" TabIndex="21"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="EDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtopeningBal">
                                    </ajaxToolkit:CalendarExtender>
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
                                       CommandName="ADD" OnClientClick="return Validate();" SkinID="btn" TabIndex="22" Text="ADD" />&nbsp;
                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="23"
                                       CommandName="VIEW" Text="VIEW" Visible="true" />
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
                        </table>
                    </center>
                    <center>
                        <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                            <asp:GridView ID="GVSupp" runat="server" SkinID="GridView" AllowPaging="true" AutoGenerateColumns="False"
                                PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
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
                                    <asp:TemplateField HeaderText="Name" meta:resourcekey="TemplateFieldResource2" SortExpression="Supp_Name">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Supp_Id") %>' />
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("Supp_Name") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code" SortExpression="Supp_Code">
                                        <ItemTemplate>
                                            <asp:Label ID="ll1" runat="server" Text='<%# Bind("Supp_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Registered">
                                        <ItemStyle Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("Registered") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TIN">
                                        <ItemTemplate>
                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("TIN") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CST No">
                                        <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("CST_No") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemStyle Wrap="False" />
                                        <ItemTemplate>
                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("Supp_Address") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" Width="120"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="l7" runat="server" Text='<%# Bind("City") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Postal Code">
                                        <ItemTemplate>
                                            <asp:Label ID="l8" runat="server" Text='<%# Bind("Postal_Code") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State" SortExpression="StateName">
                                        <ItemStyle Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="l9" runat="server" Text='<%# Bind("StateName") %>' />
                                            <asp:Label ID="stateid" Visible="false" runat="server" Text='<%# Bind("state") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Country" SortExpression="Country">
                                        <ItemTemplate>
                                            <asp:Label ID="l10" runat="server" Text='<%# Bind("Country") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Driving Licence No">
                                        <ItemTemplate>
                                            <asp:Label ID="l11" runat="server" Text='<%# Bind("Dlno") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Person" SortExpression="Contact_Person">
                                        <ItemTemplate>
                                            <asp:Label ID="l12" runat="server" Text='<%# Bind("Contact_Person") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No.1">
                                        <ItemStyle Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="l13" runat="server" Text='<%# Bind("Contact_Number1") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No.2">
                                        <ItemTemplate>
                                            <asp:Label ID="l14" runat="server" Text='<%# Bind("Contact_Number2") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fax No.">
                                        <ItemTemplate>
                                            <asp:Label ID="l15" runat="server" Text='<%# Bind("Fax_Number") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="l16" runat="server" Text='<%# Bind("Email") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit Period Days">
                                        <ItemTemplate>
                                            <asp:Label ID="l17" runat="server" Text='<%# Bind("Credit_Period") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit Limit(Rs)">
                                        <ItemStyle Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="l18" runat="server" Text='<%# Bind("Credit_Limit","{0:0.00}") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Supplier to Receive(CR)">
                                        <ItemTemplate>
                                            <asp:Label ID="l19" runat="server" Text='<%# Bind("Opening_Balance_CR","{0:0.00}") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Supplier to Pay(DR)">
                                        <ItemTemplate>
                                            <asp:Label ID="l20" runat="server" Text='<%# Bind("Opening_Balance_DR","{0:0.00}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opening Balance as on">
                                        <ItemTemplate>
                                            <asp:Label ID="l21" runat="server" Text='<%# Bind("OpBalanceDate","{0:dd-MMM-yyyy}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
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
