<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmErrorMessageDisplay.aspx.vb" Inherits="FrmErrorMessageDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERROR MESSAGE</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="ErrorMessage" runat="server"  Text='<%# Bind("ErrorMessage") %>' ></asp:Label>
    
    </div>
    </form>
</body>
</html>
