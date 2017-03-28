<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmProcessDetails.aspx.vb"
    Inherits="Mfg_FrmProcessDetails" Title="Process Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Process Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%=Txtprocess.ClientID %>"), 'Process Description');
            if (msg != "") {
                document.getElementById("<%=Txtprocess.ClientID %>").focus();
                return msg;
            }

            msg = Field1(document.getElementById("<%=txtSeq.ClientID %>"), 'Sequence');
            if (msg != "") {
                document.getElementById("<%=txtSeq.ClientID %>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txtSeq.ClientID %>"), 'Sequence');
            if (msg != "") {
                document.getElementById("<%=txtSeq.ClientID %>").focus();
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

    <script type="text/javascript" language="javascript">
        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLRM.ClientID %>"), 'Item Description');
            if (msg != "") {
                document.getElementById("<%=DDLRM.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlIO.ClientID %>"), 'Sequence');
            if (msg != "") {
                document.getElementById("<%=ddlIO.ClientID %>").focus();
                return msg;
            }

            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
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
                <asp:Panel ID="panel1" runat="server">
                    <div class="mainBlock">
                        <center>
                            <h1 class="headingTxt">
                                PROCESS DETAILS
                            </h1>
                        </center>
                        </br>
                        <center>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Lblprocess" runat="server" SkinID="lblRsz" Text="Process Description* :&nbsp;&nbsp;"
                                            Width="175"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txtprocess" runat="server" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSeq" runat="server" SkinID="lbl" Text="Sequence* :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSeq" runat="server" SkinID="txt"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="HidProcess" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="HidIOProcess" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <asp:Button ID="btnAdd" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" Text="ADD" />
                                        &nbsp;<asp:Button ID="ViewProcessDetails" runat="server" CausesValidation="False"
                                            CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                                        &nbsp;<asp:Button ID="InsertProcessDetails" runat="server" CausesValidation="False"
                                            CssClass="ButtonClass" SkinID="btnRsz" Text="ADD DETAILS" Width="120" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <center>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                            </center>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel5" runat="server" ScrollBars="Auto">
                                            <asp:GridView ID="GvProcessDetails" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                                Visible="False" AllowPaging="True" PageSize="100">
                                                <Columns>
                                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="7"
                                                                CommandName="Edit" Text="Edit" />
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="8"
                                                                CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete" />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Process Description" SortExpression="Process Description">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HIDProcess" runat="server" Value='<%# Bind("Process_ID") %>'
                                                                Visible="false" />
                                                            <asp:Label ID="lblProcessDescription" runat="server" Text='<%# Bind("ProcessDesc") %>'
                                                                Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                         <HeaderStyle HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sequence" SortExpression="Sequence">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSequence" runat="server" Text='<%# Bind("Sequence") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </asp:Panel>
                <asp:Panel ID="panel2" runat="server">
                    <hr />
                    <div class="mainBlock">
                        <center>
                            <h1 class="headingTxt">
                                PROCESS MASTER DETAILS
                            </h1>
                        </center>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblItemDesc" runat="server" SkinID="lblRsz" Text="Item Description* :&nbsp;&nbsp;"
                                            Width="200"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDLRM" runat="server" DataSourceID="ObjProduct1" DataTextField="Product_Name"
                                            Width="200" DataValueField="Product_Id" SkinID="ddlRsz">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <asp:ObjectDataSource ID="ObjProduct1" runat="server" SelectMethod="ProductComboD"
                                    TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblIO" runat="server" SkinID="lblRsz" Text="Input(I)/Output(O)* :&nbsp;&nbsp;"
                                            Width="250"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlIO" runat="server" SkinID="ddl">
                                            <asp:ListItem Value="I">I</asp:ListItem>
                                            <asp:ListItem Value="O">O</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="HidMProcess" SkinID="txt" runat="server" Visible="false"></asp:TextBox>
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
                                <center>
                                    <tr>
                                        <td class="btnTd" colspan="4">
                                            <asp:Button ID="InsertProcessMaster" runat="server" CssClass="ButtonClass" OnClientClick="return Validate1();"
                                                SkinID="btn" Text="ADD" ValidationGroup="ADD" />
                                            &nbsp;<asp:Button ID="ViewProcessMaster" runat="server" CausesValidation="False"
                                                CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                                            &nbsp;<asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btn" Text="CLOSE" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                            </table>
                            <center>
                                <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                            </center>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel4" runat="server" ScrollBars="Auto" Height="250px">
                                            <asp:GridView ID="GvProcessMaster" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                                Visible="False" AllowPaging="True" PageSize="100">
                                                <Columns>
                                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="7"
                                                                CommandName="Edit" Text="Edit" />
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="8"
                                                                CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete" />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item Description" SortExpression="Item Description">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HID1" runat="server" Value='<%# Bind("ProcessIO_ID") %>' Visible="false" />
                                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("Product_Id") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblItemDescription1" runat="server" Text='<%# Bind("Product_Name") %>'
                                                                Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Input/Output" SortExpression="Input/Output">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInputOutput1" runat="server" Text='<%# Bind("IO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </asp:Panel>
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
