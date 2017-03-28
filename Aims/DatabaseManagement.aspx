<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DatabaseManagement.aspx.vb" Inherits="DatabaseManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Database Management</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div>
        &nbsp;<asp:Label ID="Label1" runat="server" Text="Backup Database" Width="192px"></asp:Label>
        <asp:Button ID="btnBackupDatabase" runat="server" Text="Backup" Width="72px" />&nbsp;<br />
        &nbsp;
        <br />
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Restore Database" Width="192px"></asp:Label>
        <asp:Button ID="btnRestoreDatabase" runat="server" Text="Restore" />&nbsp;
    
    </div>

</form>
</body>
</html>