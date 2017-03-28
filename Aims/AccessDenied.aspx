<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AccessDenied.aspx.vb" Inherits="AccessDenied" title="Untitled Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Access Denied</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

 <div>
 <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
 <h2 align="center" style="font: Arial; color: Red;">
                       <%-- Page cannot be accessed for the current User. --%>
                                            </h2>
    </div>
    <br />
     <div align="center">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/access_denied.jpg" /></div>
                        <br />
                         <div align="center">
                      
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="XX-Large">BACK</asp:LinkButton></div>
                        <br />


</form>
</body>
</html>
