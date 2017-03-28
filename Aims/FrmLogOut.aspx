<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmLogOut.aspx.vb" Inherits="FrmLogOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Logged Out</title>
        <link rel="shortcut icon" href="~/Images/favicon.png" type="image/x-icon"/>

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {

        }
    </script>

    <style type="text/css">
        .style1
        {
            height: 200px;
        }
    </style>
</head>
<body style="background-color:White; height: 200px;">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <form id="form1" runat="server">
    <div style="background-color: white;" class="style1">
        <br />
        <br />
        <br />
        <br />
        <br />
        <center>
            <asp:Image ID="Image1" runat="server" ImageUrl="Images/log.gif" Width="100" Height="80" />
            <br />
            <br />
            <h3 align="center" style="font: Arial; color: Black;">
                You have successfully logged out!!</h3>
            <center>
            </center>
            <h2 align="center" style="font: Arial; color: Black;">
                <a href="Login.aspx">Go to Login Page</a></h2>
        </center>
        <br />
    </div>
    </form>
</body>
</html>
