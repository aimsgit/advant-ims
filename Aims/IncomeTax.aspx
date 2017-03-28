<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="IncomeTax.aspx.vb"
    Inherits="IncomeTax" Title="Income Tax" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Income Tax</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtDescription.ClientID%>"), 'Description');
            document.getElementById("<%=txtDescription.ClientID%>").focus();
            if (msg != "") return msg;
            msg = validateYear(document.getElementById("<%=txtFinancialyear.ClientID%>"), 'Financial Year');
            document.getElementById("<%=txtFinancialyear.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlCategory.ClientID %>"), 'Category');
            document.getElementById("<%=ddlCategory.ClientID%>").focus();
            if (msg != "") return msg;
            msg = FeesField(document.getElementById("<%=txtStandarddeduction.ClientID%>"), 'Standard Deduction');
            document.getElementById("<%=txtStandarddeduction.ClientID%>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimal(document.getElementById("<%=txtLowerlimit.ClientID%>"), 'Lower Limit');
            document.getElementById("<%=txtLowerlimit.ClientID%>").focus();
            if (msg != "") return msg;
            msg = FeesFieldAcceptDecimal(document.getElementById("<%=txtUpperlimit.ClientID%>"), 'Upper Limit');
            document.getElementById("<%=txtUpperlimit.ClientID%>").focus();
            if (msg != "") return msg;
            msg = FeesField(document.getElementById("<%=txtPercent.ClientID%>"), 'Income Tax Percent');
            document.getElementById("<%=txtPercent.ClientID%>").focus();
            if (msg != "") return msg;

            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblS.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblS.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }



        function validateFees(fld) {
            var temp_value = fld.value;
            var Chars = "0123456789.";
            for (var i = 0; i < temp_value.length; i++) {
                if (Chars.indexOf(temp_value.charAt(i)) == -1) {
                    var msg;
                    msg = "Invalid Character(s)\n\nOnly numbers (0-9) and a period are allowed in this field.";
                    return msg;
                }
            }
            return "";
        } 
        
        
        
        
    </script>


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
        <div>
            <%-- <center>
            <h1 class="headingTxt">
                INCOME TAX
            </h1>
          
        </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
                <br />
            </center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDescription" runat="server" Text="Income Tax Description* :&nbsp;"
                                        Width="250px" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescription" SkinID="txt" runat="server" TabIndex="1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFinancialyear" runat="server" Text="Financial Year* :&nbsp;" SkinID="lblRsz" Width="220px">
                                    </asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFinancialyear" SkinID="txt" runat="server" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCategory" runat="server" Text="Category* :&nbsp;" SkinID="lbl">
                                    </asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCategory" runat="server" SkinID="ddl" TabIndex="3">
                                        <asp:ListItem Value="G">General</asp:ListItem>
                                        <asp:ListItem Value="W">Women</asp:ListItem>
                                        <asp:ListItem Value="S">Senior Citizen</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStandarddeduction" runat="server" Text="Standard Deduction* :&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtStandarddeduction" SkinID="txt" runat="server" TabIndex="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblLowerlimit" runat="server" Text="Lower Limit* :&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLowerlimit" SkinID="txt" runat="server" TabIndex="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblUpperlimit" runat="server" Text="Upper Limit* :&nbsp;" SkinID="lbl">
                                    </asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtUpperlimit" SkinID="txt" runat="server" TabIndex="6"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPercent" runat="server" Text="Income Tax Percent* :&nbsp; " SkinID="lblRsz">
                                    </asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPercent" SkinID="txt" runat="server" TabIndex="7"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClientClick="return Validate();"
                                        SkinID="btn" CssClass="ButtonClass" TabIndex="8" />
                                </td>
                                <td>
                                    <asp:Button ID="btnView" runat="server" Text="VIEW" SkinID="btn" CssClass="ButtonClass"
                                        TabIndex="9" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
                        <asp:Label ID="lblS" runat="server" SkinID="lblGreen"></asp:Label>
                    </center>
                    </a> <a name="bottom">
                        <center>
                            <br />
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                                    AllowPaging="True" PageSize="100">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Wrap="false" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Button21" runat="server" CausesValidation="true" CommandName="Edit"
                                                    Text="Edit" TabIndex="9" />&nbsp;
                                                <asp:LinkButton ID="Button22" runat="server" CausesValidation="true" CommandName="Delete"
                                                    Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')"
                                                    TabIndex="10" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IT Description">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HidId" runat="server" Value='<%# Bind("IT_ID") %>' />
                                                <asp:Label ID="Label132" runat="server" Text='<%# Bind("ITDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="IT Description">
                            <ItemTemplate>
                                <asp:Label ID="Label133" runat="server" Text='<%# Bind("Discount","{0:0.00}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Lower Limit">
                                            <ItemTemplate>
                                                <asp:Label ID="Label134" runat="server" Text='<%# Bind("LowerLimit","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" />
                                            <HeaderStyle HorizontalAlign="right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Upper Limit">
                                            <ItemTemplate>
                                                <asp:Label ID="Label135" runat="server" Text='<%# Bind("UpperLimit","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" />
                                            <HeaderStyle HorizontalAlign="right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="Label136" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Standard Deduction">
                                            <ItemTemplate>
                                                <asp:Label ID="Label137" runat="server" Text='<%# Bind("StdDeduction","{0:0.00}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Income Tax Percent">
                                            <ItemTemplate>
                                                <asp:Label ID="Label138" runat="server" Text='<%# Bind("ITPercent") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Financial Year">
                                            <ItemTemplate>
                                                <asp:Label ID="Label139" runat="server" Text='<%# Bind("FinancialYear") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </center>
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
        <br />
    </a>
    <div align="right">
        <a href="#top">
            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
    </div>

</form>
</body>
</html>