<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmDepreciation_Rates.aspx.vb"
    Inherits="frmDepreciation_Rates" Title="Depreciation Rates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Depreciation Rates</title>
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
            msg = NameField100Mul(document.getElementById("<%=TxtDepreciationType.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=TxtDepreciationType.ClientID%>").focus();
                a = document.getElementById("<%=lblCommodityName.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldMul(document.getElementById("<%=txtCommodityRate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtCommodityRate.ClientID%>").focus();
                a = document.getElementById("<%=lblCommodityRate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldMul(document.getElementById("<%=txtComodity_CompanyRates.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtComodity_CompanyRates.ClientID%>").focus();
                a = document.getElementById("<%=lblComodity_CompanyRates.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
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

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <a name="Top">
                    <div align="right">
                        <a href="#Bottom">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    </div>
                    <div>
                        <%--<h1 class="headingTxt">
                            DEPRECIATION RATES
                            <br />
                            <br />
                        </h1>--%>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                            <br />
                            <br />
                        </h1>
                        <center>
                            <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblDepreciation_ID" runat="server" Width="144px" Text="Depreciation ID :&nbsp;&nbsp;"
                                            SkinID="lblRsz" Visible="False" __designer:wfdid="w8"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDepreciation_ID" runat="server" Visible="False" __designer:wfdid="w9" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblCommodityName" runat="server" Width="250px" Text="Depreciation Type* :&nbsp;&nbsp;"
                                            SkinID="lblRsz" __designer:wfdid="w10"></asp:Label>
                                    </td>
                                    <td>
                                    <asp:TextBox ID="TxtDepreciationType" runat="server" TabIndex="1" SkinID="txt"></asp:TextBox>
                                        <%--<asp:DropDownList ID="ddlCommodityName" TabIndex="1" runat="server" SkinID="ddl"
                                            AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="AssetType_Name"
                                            DataValueField="AssetType_IDAuto" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblCommodityRate" runat="server" Width="250px" Text="Govt Depreciation Rate* :&nbsp;&nbsp;"
                                            SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCommodityRate" runat="server" TabIndex="2" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblComodity_CompanyRates" runat="server" Text=" Company Depreciation Rate* :&nbsp;&nbsp;"
                                            Width="250" SkinID="lblRsz" __designer:wfdid="w14"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtComodity_CompanyRates" runat="server" __designer:wfdid="w15"
                                            TabIndex="3" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td class="btnTd" colspan="2">
                                        <asp:Button ID="BtnSave" TabIndex="4" runat="server" Text="ADD" CausesValidation="True" CommandName="ADD"
                                            SkinID="btn" CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                        &nbsp;<asp:Button ID="BtnDetails" TabIndex="5" runat="server" Text="VIEW" CausesValidation="False"
                                            SkinID="btn" CommandName="VIEW" CssClass="ButtonClass"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
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
                                    <td class="btnTd" align="center">
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="550px" Height="300px">
                                            <center>
                                                <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AutoGenerateColumns="False"
                                                    AllowPaging="True" PageSize="100" EnableSortingAndPagingCallbacks="True"  AllowSorting="True">
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                    Text="Edit" Font-Underline="False" TabIndex="6"></asp:LinkButton>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                    TabIndex="7" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                    Text="Delete" Visible="false" Font-Underline="False"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Depreciation_ID1" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("DepreciationID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Asset Depreciation Type" SortExpression="CommodityName">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="Label4" runat="server" Visible="false" Text='<%# Bind("AssetType_IDAuto")%>'></asp:Label>--%>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CommodityName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="GovtDepreciationRate" SortExpression="CommodityRate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CommodityRate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CompanyDepreciationRate" SortExpression="Comodity_CompanyRates">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Comodity_CompanyRates") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </center>
                                        </asp:Panel>
                                       <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAssetTypecombo"
                                            TypeName="Depreciation_Rates"></asp:ObjectDataSource>--%>
                                    </td>
                                </tr>
                            </table>
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
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnDetails" EventName="Click"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
