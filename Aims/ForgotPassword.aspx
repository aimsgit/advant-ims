<%@ Page Language="VB" CodeFile="ForgotPassword.aspx.vb" MaintainScrollPositionOnPostback="true"
    Inherits="ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forgot Password</title>

    <script type="text/javascript" src="js/Tvalidate.js"></script>

    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/jquery.vticker-min.js"></script>

    <script language="JavaScript" type="text/javascript">
        //Function for Multilingual Validations
        //Created By Niraj

        function Valid() {
            var msg;

            msg = Field255(document.getElementById('txtemailid'), 'User ID');
            if (msg != "") {
                document.getElementById('txtemailid').focus();
                a = document.getElementById('lblemailid').innerHTML;
                //                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            return true;
        }

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById('lblSResult').innerHTML = msg;
                    document.getElementById('lblgreen').innerHTML = "";
                    return false;
                }
                else if (navigator.appName == 'Netscape') {
                    document.getElementById('lblSResult').innerHTML = msg;
                    document.getElementById('lblgreen').innerHTML = "";
                    return false;
                }
            }
            return true;
        }

        //        document.onkeydown = function() {
        //            if (event.keyCode == 116) {
        //                event.keyCode = 0;
        //                event.returnValue = false;
        //            }
        //        }

        //        //to avoid refresh, using context menu of the browser

        //        document.oncontextmenu = function() { event.returnValue = false; }
       
    </script>

</head>
<body style="width: 565px; height: 300px;">
    <form id="form1" runat="server" method="post">
    <link href="styleSheet.css" rel="stylesheet" type="text/css" />
    <asp:Panel ID="Panel2" runat="server">
        <%--  <table>
                <tr>
                    <td align="left" colspan="2">
                        <a href="http://www.advant-tech.com" target="_blank">
                            <asp:Image ID="Image3" runat="server" Height="80px" Style="position: absolute; z-index: 200;
                                top: 2px;" ImageUrl="~/Images/mainlog.png" Width="900px" />
                        </a>
                        <asp:Image ID="Image4" runat="server" Height="80px" ImageUrl=""
                            DataSourceID="Objimg" Width="900px" DataValueField="image" />
                    </td>
                </tr>
            </table>--%>
        <center>
            <%-- <table>
                <tr>
                    <td align="center">--%>
            <br />
            <br />
            <br />
            <h1>
                <asp:Label ID="lblSB" Text="FORGOT PASSWORD" runat="server" Font-Bold="true" Font-Names="Verdana"
                    unselectable="on" Font-Size="Large" ForeColor="#914800" Font-Italic="true"></asp:Label>
            </h1>
            <br />
            <%-- </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">--%>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">Staff</asp:ListItem>
                <asp:ListItem Value="2">Parent</asp:ListItem>
                <asp:ListItem Value="3">Student</asp:ListItem>
            </asp:RadioButtonList>
            <%--</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>--%>
            <br />
        </center>
        <center>
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblemailid" runat="server" SkinID="lblRsz" Text="User ID* :" />
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtemailid" runat="server" SkinID="txt"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </center>
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <center>
            <table>
                <tr>
                    <td align ="center" >
                        <asp:Button ID="btnok" runat="server" CssClass="ButtonClass" Text="SUBMIT" OnClientClick="return Validate();"
                            SkinID="btn" />
                        <asp:Button ID="BtnBack" runat="server" CssClass="ButtonClass" Text="BACK" Visible="false"
                            SkinID="btn" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblSResult" runat="server" SkinID="lblRed"></asp:Label>
                        <asp:Label ID="lblgreen" runat="server" SkinID="lblGreen"></asp:Label>
                    </td>
                </tr>
            </table>
        </center>
    </asp:Panel>
    </form>
</body>
</html>
