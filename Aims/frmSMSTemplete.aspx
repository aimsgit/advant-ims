<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSMSTemplete.aspx.vb"
    Inherits="frmSMSTemplete" Title="SMS Template" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SMS Template</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtTempleteName.ClientID %>"), 'SMS Template Name');
            document.getElementById("<%=txtTempleteName.ClientID %>").focus();
            if (msg != "") return msg;
            msg = minmaxlength(document.getElementById("<%=txtMessage.ClientID %>"), 1, 160, 'Message');
            document.getElementById("<%=txtMessage.ClientID %>").focus();
            if (msg != "") return msg;

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
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div>
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <a name="top">
                        <div align="right">
                            <a href="#bottom">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                        </div>
                    </a>
                    <%-- <h1 class="headingTxt">
                        SMS TEMPLATE MASTER
                    </h1>--%>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                    <br />
                    <br />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSMSTemp" runat="server" SkinID="lblRsz" Text="SMS Template Name*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTempleteName" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblMessage" runat="server" SkinID="lblRsz" Text="Message*&nbsp;:&nbsp;&nbsp;"
                                        Width="180"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMessage" runat="server" SkinID="txt" TabIndex="2" TextMode="MultiLine"
                                        Height="50"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <caption>
                                <br />
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <asp:Button ID="btnSave" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" TabIndex="3" Text="ADD" />
                                        &nbsp;
                                        <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="4"
                                            Text="VIEW" />
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                            <ProgressTemplate>
                                                <div class="PleaseWait">
                                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <div>
                                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                            </div>
                                        </center>
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
                                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                                <asp:GridView ID="GVSMSTemplete" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    PageSize="100" SkinID="GridView">
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                    Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                    Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                    Text="Delete"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                            <ItemStyle Font-Underline="False" HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ControlStyle Font-Underline="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SMS Template Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSMSTempName" runat="server" Text='<%# Bind("TemplateName") %>'></asp:Label>
                                                                <asp:HiddenField ID="SMSID" runat="server" Value='<%# Bind("STIDAuto") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Message">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMessage" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <HeaderStyle HorizontalAlign="center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </center>
                                    </td>
                                </tr>
                            </caption>
                        </table>
                        <a name="bottom">
                            <div align="right">
                                <a href="#top">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                            </div>
                        </a>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</form>
</body>
</html>