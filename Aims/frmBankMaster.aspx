<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBankMaster.aspx.vb"
    Inherits="frmBankMaster" Title="Bank Details" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bank Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }


        //Function for Multilingual Validations
        //Created By Ajit Kumar Singh


        function Valid() {

            var msg, a;
            msg = NameField100Mul(document.getElementById("<%=txtBank.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtBank.ClientID %>").focus();
                a = document.getElementById("<%=BankName.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = NameField100Mul(document.getElementById("<%=txtBankAdd.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtBankAdd.ClientID %>").focus();
                a = document.getElementById("<%=BankAddress.ClientID %>").innerHTML;
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

    <div class="mainBlock">
        <a name="Top">
            <div align="right">
                <a href="#Bottom">
                    <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
            </div>
            <%--<center>
                <h1 class="headingTxt">
                    BANK DETAILS</h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <br />
            <center>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <center>
                            <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="BankName" runat="server" SkinID="lbl" Text="Name*&nbsp:&nbsp&nbsp"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBank" runat="server" Text='<%# Bind("Name")%>' SkinID="txtRsz" TabIndex="1" Width="200">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="BankAddress" runat="server" SkinID="lbl" Text="Address*&nbsp:&nbsp&nbsp"
                                            Width="77px" Height="22px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBankAdd" TextMode="MultiLine" AutoCompleteType="Disabled" runat="server"
                                            Text='<%# Bind("Address") %>' SkinID="txtRsz" TabIndex="2" Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="BankRemarks" runat="server" SkinID="lbl" Text="Remarks&nbsp:&nbsp&nbsp"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" Text='<%# Bind("Remarks") %>' AutoCompleteType="Disabled"
                                            SkinID="txtRsz" TabIndex="3" Width="200"></asp:TextBox>
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
                                    <td colspan="2" class="btnTd" align="center">
                                        <asp:Button ID="btnAdd" runat="server" CommandName="ADD" OnClientClick="return Validate();"
                                            SkinID="btn" Text="ADD" TabIndex="4" CausesValidation="true" CssClass="ButtonClass " />&nbsp
                                        <asp:Button ID="btnDetails" runat="server" CausesValidation="true" CommandName="VIEW"
                                            SkinID="btn" Text="VIEW" TabIndex="5" CssClass="ButtonClass " />
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <cc1:msgBox ID="MsgBox1" runat="server"></cc1:msgBox>
                        <div>
                            &nbsp;</div>
                        <div>
                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblGreen"></asp:Label>
                        </div>
                        <div>
                            &nbsp;</div>
                        <div>
                            <center>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="700px" Height="300px">
                                    <asp:GridView ID="GVBank" runat="server" SkinID="GridView" DataKeyNames="Bank_ID"
                                        AllowPaging="True" PageSize="100" AutoGenerateColumns="false" Visible="True" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" CommandName="Edit"
                                                        Text="Edit" Font-Underline="False" TabIndex="6"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="true" CommandName="Delete"
                                                        Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Font-Underline="False" Visible="false" TabIndex="7"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bank Name" SortExpression="Bank_Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="BId" runat="server" Value='<%# Bind("Bank_ID") %>'></asp:HiddenField>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" ></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bank Address" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Width="100px" Text='<%# Bind("Bank_Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" ></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Width="150px" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" ></ItemStyle>
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
            </center>
    </div>

</form>
</body>
</html>
