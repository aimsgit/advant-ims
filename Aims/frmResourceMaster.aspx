<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmResourceMaster.aspx.vb"
    Inherits="frmResourceMaster" Title="Resource Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Resource Master</title>
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
            msg = NameField100Mul(document.getElementById("<%=txtresourcetype.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtresourcetype.ClientID %>").focus();
                a = document.getElementById("<%=lblresourcetype.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField100Mul(document.getElementById("<%=txtresourcename.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtresourcename.ClientID %>").focus();
                a = document.getElementById("<%=lblresourcename.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true; 
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblS.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblS.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <%--<center>
                    <h1 class="headingTxt">
                        RESOURCE MASTER
                    </h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblresourcetype" runat="server" Text="Resource Type*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtresourcetype" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblresourcename" runat="server" Text="Resource Name*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtresourcename" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCapacity" runat="server" SkinID="lbl" Text="Capacity&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcapacity" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtcapacity">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd">
                                <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CommandName="ADD"
                                    SkinID="btn" TabIndex="4" Text="ADD" ValidationGroup="ADD" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" />&nbsp;
                                <asp:Button ID="btnView" runat="server" TabIndex="5" CausesValidation="true" SkinID="btn" CommandName="VIEW"
                                    Text="VIEW" CssClass="ButtonClass" />
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
                                        <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblS" runat="server" SkinID="lblGreen"></asp:Label>
                                    </div>
                                    <table>
                                        <tr>
                                            <td style="width: 172px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                        <asp:GridView ID="GridResourceMaster" runat="server" SkinID="GridView" AllowPaging="true"
                                            AutoGenerateColumns="False" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Text="Edit" />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Resource Type" Visible="true" SortExpression="ResourceType">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPK" Visible="false" runat="server" Text='<%# Bind("PKID") %>'></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ResourceType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Resource Name" Visible="true" SortExpression="ResourceName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("ResourceName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Capacity" Visible="true" SortExpression="Capacity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCapacity" runat="server" Text='<%# Bind("Capacity") %>'></asp:Label>
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
