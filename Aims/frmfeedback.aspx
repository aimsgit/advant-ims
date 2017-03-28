<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmfeedback.aspx.vb" Inherits="frmfeedback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FeedBack</title>
</head>
<body bgcolor="#f0e68c" style="width: 800px; height: 800px" >
    <form id="form1" runat="server">
    <center>
    
        <asp:Label ID="Label2" runat="server" Text="Your feedback on this form" ForeColor="#800000"
            Font-Bold="True" Font-Size="15"></asp:Label></br>
             <%--<asp:Label ID="Label3" runat="server" Text="(" Font-Bold="True" ForeColor="#800000"
            Font-Size="15"></asp:Label>
        <asp:Label ID="lblHeading" runat="server" Font-Bold="True" ForeColor="#800000" Font-Size="13"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text=")" Font-Bold="True" ForeColor="#800000"
            Font-Size="15"></asp:Label>--%>
            <center>
        <table>
            <tr>
                <td align="left" >
                    <asp:RadioButtonList ID="RBEmpType" ForeColor="#800000" runat="server"
                        RepeatDirection="Vertical" TabIndex="1">
                        <asp:ListItem Value="E" Selected="True">Excellent</asp:ListItem>
                        <asp:ListItem Value="G">Good</asp:ListItem>
                        <asp:ListItem Value="B">Needs Improvement</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblsuggestion" ForeColor="#800000" runat="server" SkinID="lbl" Text="Suggestion (50 Chars)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:TextBox ID="txtsuggst" runat="server" TextMode="MultiLine" SkinID="txt" MaxLength ="50"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:Button ID="btnsend" ForeColor="Wheat" runat="server" Text="SEND" Font-Bold="true"
                        BackColor="#800000" />
                </td>
            </tr>
        </table>
        </center>
        <asp:Label ID="lblsend" runat="server" ForeColor="Green"></asp:Label>
    </center>
    </form>
</body>
</html>
