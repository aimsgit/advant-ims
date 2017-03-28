<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmMedium.aspx.vb"
    Inherits="FrmMedium" Title="Medium Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Medium Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">


        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }

        //Function for Multilingual Validations
        //Created By Ajit Kumar Singh


        function Valid() {

            var msg, a;
            msg = NameField100Mul(document.getElementById("<%=TxtMediumName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtMediumName.ClientID %>").focus();
                a = document.getElementById("<%=LblMediumName.ClientID %>").innerHTML;
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
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
                            <asp:Label ID="LblMediumName" runat="server" Text="Medium Name* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtMediumName" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                    </tr>
                </table>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                            &nbsp
                        </td>
                        <td>
                            &nbsp
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btnTd">
                            <asp:Button ID="BtnSave" runat="server" TabIndex="2" Text="ADD" SkinID="btn" CausesValidation="True"
                               CommandName="ADD" OnClientClick="return Validate();" CssClass="ButtonClass" />&nbsp
                            <asp:Button ID="BtnDetails" runat="server" Text="VIEW" CausesValidation="False" TabIndex="3"
                               CommandName="VIEW" SkinID="btn" CssClass="ButtonClass" />&nbsp
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                            </div>
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
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                    <asp:GridView ID="GrdMedium" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display."
                        SkinID="GridView" AllowPaging="True" PageSize="100" EnableSortingAndPagingCallbacks="True"  AllowSorting="True">
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to Delete the selected record?')"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Medium Name" Visible="true" SortExpression="MediumName">
                                <ItemTemplate>
                                    <asp:Label ID="txtMedium_Id" Visible="false" runat="server" Text='<%# Bind("Medium_ID") %>'></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("MediumName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </center>
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
