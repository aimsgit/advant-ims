<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmSourceOfInfo.aspx.vb"
    Inherits="FrmSourceOfInfo" Title="Source Of Information" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Source Of Information</title>
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

            msg = Field50Mul(document.getElementById("<%=txtsorceofinfo.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtsorceofinfo.ClientID %>").focus();
                a = document.getElementById("<%=lblsorcofinfo.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = msg;
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
                <div>
                    <%--<center>
                    <h1 class="headingTxt">
                        SOURCE OF INFORMATION
                    </h1>
                </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblsorcofinfo" runat="server" SkinID="lblRsz" Text="Source Of Information*&nbsp;:&nbsp;&nbsp;"
                                        Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsorceofinfo" runat="server" SkinID="txtRsz" TabIndex="1" Width="200"></asp:TextBox>
                                </td>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="btnTd">
                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="ADD"
                                        SkinID="btn" TabIndex="2" Text="ADD" ValidationGroup="ADD" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" />&nbsp;
                                    <asp:Button ID="btnDetails" runat="server" TabIndex="3" CausesValidation="true" SkinID="btn"
                                        Text="VIEW" CommandName="VIEW" CssClass="ButtonClass" />
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
                                    <center>
                                        <div>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                        </div>
                                        <table>
                                            <tr>
                                                <td style="width: 172px">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                            <asp:GridView ID="Grdsourceofinfo" runat="server" SkinID="GridView" AllowPaging="true"
                                                AutoGenerateColumns="False" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
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
                                                    <asp:TemplateField HeaderText="Source Of Information" Visible="true" SortExpression="SourceofInfo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblsimid" Visible="false" runat="server" Text='<%# Bind("SIMID") %>'></asp:Label>
                                                            <asp:Label ID="lblsorcofinfo" runat="server" Text='<%# Bind("SourceofInfo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
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
    </asp:UpdatePanel>


</form>
</body>
</html>

