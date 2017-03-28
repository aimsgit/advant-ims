<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Result.aspx.vb" Inherits="Result" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Result Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="Images/cbmis.png" style="width: 100%;" />
        <hr />
        <center>
            <h1>
                RESULT</h1>
        </center>
        <center>
            <h3 style="color: red;">
                Please enter your full National Identity Card Number (eg: 000000000V)</h3>
        </center>
        <center>
            <table>
                <tr>
                    <td>
                        <label>
                            <strong>NIC NO:</strong></label>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="search" placeholder="Enter NicNo To Search EG:000000000V"
                            Style="width: 250px;" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btn" runat="server" Width="80px" Height="30px" Text="SUBMIT"></asp:Button>
                    </td>
                </tr>
            </table>
            <div align="left" style="width: 75%;">
                &nbsp;<br />
                <br />
                <strong>Please do not worry, if you are selected to this intake of Leadership programme
                    and you did not receive a letter yet. Since Ministry of Higher Education
                    already sent your details to the relevant centers you will be accepted with printed
                    letter, slip and the NIC. Even if you are not in a position to get a printout from
                    the system you can directly go to the Training Center which you are allocated (Take
                    your NIC), we have sent all the candidate details to each and every training center.
                     </strong>
            </div>
        </center>
        <br />
        <hr />
        <!-- Division to display data-->
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <div id="output">
        </div>
    </form>
</body>
</html>
