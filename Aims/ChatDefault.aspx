<%@ Page Language="vb" AutoEventWireup="false" CodeFile="ChatDefault.aspx.vb" Inherits="ChatDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%--<meta http-equiv="refresh" content="5">
--%>
    <title>AIMS Chat Application</title>
    
</head>
<body onbeforeunload="Logout()">
   
    
    
  <iframe src="Chatup.aspx" style="top:0" width="200" height="200" align="top"/>
  <br />
    <iframe src="Chatdown.aspx" style="bottom:0" width="200" height="200" align="bottom" />
 


    <%--<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>--%>
</body>
</html>

