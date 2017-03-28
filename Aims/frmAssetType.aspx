<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAssetType.aspx.vb"
    Inherits="frmAssetType" Title="Asset Type Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Type Master</title>
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
            msg = NameField100Mul(document.getElementById("<%=txtboxAssetType.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtboxAssetType.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField100Mul(document.getElementById("<%=TxtboxAssestTypeCode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtboxAssestTypeCode.ClientID %>").focus();
                a = document.getElementById("<%=Label2.ClientID %>").innerHTML;
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
                </a>
                <%-- <center>
                            <h1 class="headingTxt">
                                ASSET TYPE MASTER</h1>
                            </center> --%>
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
                                <asp:Label ID="Label1" runat="server" Text="Asset Type* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtboxAssetType" runat="server" SkinID="txtRsz" TabIndex="1" Width="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="Asset Type Code* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtboxAssestTypeCode" runat="server" SkinID="txtRsz" TabIndex="2" Width="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Asset Type Description :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtboxdesc" runat="server" SkinID="txtRsz" TabIndex="3" Width="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2" class="btnTd">
                                <br />
                                <asp:Button ID="btnadd" runat="server" Text="ADD" CssClass="ButtonClass" CausesValidation="true"
                                  CommandName="ADD"  SkinID="btn" TabIndex="4" OnClientClick="return Validate();" />
                                <asp:Button ID="btnview" runat="server" CausesValidation="false" Text="VIEW" TabIndex="5"
                                   CommandName="VIEW" CssClass="ButtonClass" SkinID="btn" />
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <br />
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                    <br />
                    <br />
                </center>
                <div>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="500px" Height="300px">
                            <asp:GridView ID="GVAssetType" runat="server" SkinID="GridView" DataKeyNames="" AllowPaging="true"
                                AutoGenerateColumns="false" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Asset Type" SortExpression="AssetType_Name">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="ATD" runat="server" Value='<%# Bind("AssetType_ID") %>' />
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("AssetType_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Asset Type Code" SortExpression="AssetTypeCode">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("AssetTypeCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Asset Type Description">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                        </ItemTemplate>
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
