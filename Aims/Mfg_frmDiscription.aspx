﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmDiscription.aspx.vb"
    Inherits="Mfg_frmDiscription" Title="Description Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Description Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = Field250(document.getElementById("<%= txtName.ClientID %>"), 'Description');
            if (msg != "") {
                document.getElementById("<%= txtName.ClientID %>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {

            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        DESCRIPTION DETAILS
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" Width="150px" runat="server" Text="Description* :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtName" runat="server" SkinID="txt" MaxLength="250" TextMode="MultiLine"
                                    TabIndex="1" Height="54px" Width="205px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="2"
                                    Text="ADD" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="3" Text="VIEW" />
                            </td>
                    </table>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridDescription" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="4"
                                                        CommandName="Edit" Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="5"
                                                        Visible="false" CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description" Visible="true">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("Desc_Id") %>' />
                                                    <asp:HiddenField ID="Label5" runat="server" Value='<%# Bind("DescIdAuto") %>' />
                                                    <asp:Label ID="Label1" runat="server" Width="200px" Text='<%# Bind("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"  Width="20" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </center>
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
