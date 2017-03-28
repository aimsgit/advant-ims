<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PasswordRecover.aspx.vb" Inherits="PasswordRecover" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        &nbsp;<table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td style="width: 80px; height: 20px">
                </td>
                <td style="width: 235px; height: 20px">
                </td>
                <td style="width: 319px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 35px">
                </td>
                <td colspan="2" style="height: 35px; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                    Forgot Your Password?</td>
                <td style="width: 319px; height: 35px">
                </td>
                <td style="width: 10px; height: 35px">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td style="height: 20px; text-align: center" colspan="2">
                                                    Enter your User Name to receive your password.&nbsp;</td>
                <td style="width: 319px; height: 20px; text-align: center">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td style="width: 80px; height: 20px; text-align: left">
                </td>
                <td style="width: 235px; height: 20px; text-align: left">
                </td>
                <td style="width: 319px; height: 20px; text-align: center">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td style="width: 80px; height: 20px; text-align: left">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Width="171px">User Name:</asp:Label></td>
                <td style="width: 235px; height: 20px; text-align: left">
                                            <asp:TextBox ID="UserName" runat="server" AutoCompleteType="Disabled"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required."
                                                ToolTip="User Name is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator></td>
                <td style="width: 319px; height: 20px; text-align: center">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td style="width: 80px; height: 20px; text-align: left">
                </td>
                <td style="width: 235px; height: 20px; text-align: left">
                </td>
                <td style="width: 319px; height: 20px; text-align: center">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td style="height: 20px; text-align: left;" colspan="2">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Blue" Text="Label" Visible="False"
                        Width="240px"></asp:Label></td>
                <td style="width: 319px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    <asp:Label ID="FailureText" runat="server" ForeColor="Red" Text="Label" Visible="False"
                        Width="240px"></asp:Label></td>
                <td style="width: 319px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td style="width: 80px; height: 20px">
                </td>
                <td style="width: 235px; height: 20px">
                </td>
                <td style="width: 319px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="height: 20px; text-align: left">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" OnClick="SubmitButton_Click"
                                                Text="Submit" ValidationGroup="PasswordRecovery1" /></td>
                <td style="width: 319px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
