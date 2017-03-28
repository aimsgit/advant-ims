<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmManufacturer.aspx.vb "
    Inherits="frmManufacturer" Title="Manufacturer Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manufacturer Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

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
        //Function for Multilingual Validations
        //Created By Ajit Kumar Singh


        function Valid() {

            var msg, a;
            msg = NameField100Mul(document.getElementById("<%=TxtManufacturerName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtManufacturerName.ClientID %>").focus();
                a = document.getElementById("<%=LblManufacturerName.ClientID %>").innerHTML;
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
                    <%--  <center>
                        <h1 class="headingTxt">
                            MANUFACTURER DETAILS
                        </h1>
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
                                <td align="right">
                                    <asp:Label ID="LblManufacturerName" runat="server" Width="200px" Text="Manufacturer Name*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtManufacturerName" runat="server" EnableViewState="False" TabIndex="1"
                                        AutoCompleteType="Disabled" SkinID="txtRsz" Width="200"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <center>
                        <table>
                            <%--<tr>
                <td>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                        TargetControlID="TxtManufacturerName" FilterType="Numbers" FilterMode="InvalidChars"
                        InvalidChars="#+=/*()@[]{}?><&^%$!~`;:\|0123456789">
                    </ajaxToolkit:FilteredTextBoxExtender>
                   </td>
               
            </tr>
            --%>
                            <tr>
                                <td class="btnTd">
                                    <asp:Button ID="BtnSave" runat="server" TabIndex="2" Text="ADD" SkinID="btn" CausesValidation="True"
                                      commandname="ADD"  ValidationGroup="textbox" OnClientClick="return Validate();" CssClass="ButtonClass" />
                                    <asp:Button ID="BtnDetails" runat="server" Text="VIEW" CausesValidation="False" TabIndex="3"
                                      CommandName="VIEW"  SkinID="btn" CssClass="ButtonClass" />
                                    <%--<asp:Button ID="BtnReport" runat="server" TabIndex="4" Text="REPORT" CausesValidation="False" SkinID="btn" CssClass="btnStyle"/>--%>
                                    <!--<asp:Button ID="BtnRecover" runat="server" TabIndex="5" Text="RECOVER" CausesValidation="False" SkinID="btn" CssClass="btnStyle"/>-->
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="400px" Height="300px">
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                DataKeyNames="ManuFacturer_ID" SkinID="GridView" TabIndex="6" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                Text="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete" Visible="false" Font-Underline="False"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Manufacturer Name" SortExpression="Manufacturer">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Manufacturername") %>'></asp:TextBox>
                                                        </EditItemTemplate>--%>
                                                    <asp:TemplateField HeaderText="Manufacturer Name">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="MID" runat="server" Value='<%# Bind("ManuFacturer_ID") %>'>
                                                            </asp:HiddenField>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Manufacturer") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
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

