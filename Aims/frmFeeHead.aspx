<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmFeeHead.aspx.vb"
    Inherits="frmFeeHead" Title="Fee Head Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Head Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

            msg = Field50(document.getElementById("<%=txtName.ClientID %>"), 'Fee Head Type');
            if (msg != "") {
                document.getElementById("<%=txtName.ClientID %>").focus();
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <%--     <center>
                    <h1 class="headingTxt">
                        FEE HEADS
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
                            <td>
                                <asp:Label ID="lbltype" runat="server" Text="Fee Head Type* :  " SkinID="lbl" Width="123px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
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
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                    SkinID="btn" TabIndex="2" Text="ADD" ValidationGroup="ADD" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" />&nbsp;
                                <asp:Button ID="btnDetails" runat="server" TabIndex="3" CausesValidation="true" SkinID="btn"
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
                            <td colspan="2" align="center">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..." SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
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
                                        <asp:GridView ID="Grdfeehead" runat="server" SkinID="GridView" AllowPaging="true"
                                            AutoGenerateColumns="False" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Text="Edit" />
                                                        <%--</ItemTemplate>--%>
                                                        <%--<ItemStyle Wrap="False"></ItemStyle>--%>
                                                        <%--</asp:TemplateField>--%>
                                                        <%--<asp:TemplateField>--%>
                                                        <%--<ItemTemplate>--%>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                            Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fee Head Type" Visible="true" SortExpression="Fee_HeadType">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" Visible="false" runat="server" Text='<%# Bind("Fee_Head_ID") %>'></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Fee_HeadType") %>'></asp:Label>
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
