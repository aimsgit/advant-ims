<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmEnquiryLogin.aspx.vb"
    Inherits="FrmEnquiryLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Enquiry</title>
</head>
<body>
    <form id="form1" runat="server">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <%--<script type="text/javascript">
        function CheckEmpty(sender, args) {
            if (args.Value == "" || args.valueOf == null) {


                args.IsValid = false;


                sender.innerText = " Mandatory ";
            }


        }
 

    </script>--%>
    <div>
        <center>
            <table>
                <tr>
                    <td align="center">
                        <asp:Panel ID="Panel1" runat="server" GroupingText="Login" Width="900px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblUserName" runat="server" Text="Email ID&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPassword" runat="server" Text="&nbsp;&nbsp;Password  :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnLogin" runat="server" Text="LOGIN" CssClass="ButtonClass" SkinID="btn" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </center>
        <center>
            <table>
                <tr>
                    <td width="600px">
                        &nbsp;
                        <asp:Panel ID="Panel2" runat="server" GroupingText="New User">
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblName" runat="server" Text="Name*&nbsp;:&nbsp;&nbsp;" Width="150px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblEmailid" runat="server" Text="Email ID*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="Email ID not in correct format." ForeColor="#990000" SetFocusOnError="True"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblContactNo" runat="server" Text="Contact No*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtContactNo" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactNo"
                                            ErrorMessage="Enter correct contact number." ForeColor="#990000" SetFocusOnError="True"
                                            ValidationExpression="^9\d{9}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblPasswordR" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPasswordR" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" CssClass="ButtonClass" SkinID="btn" />
                                    </td>
                                    <td  colspan="2">
                                        <asp:Label ID="lblError1" runat="server" Text="" ForeColor="#990000"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
