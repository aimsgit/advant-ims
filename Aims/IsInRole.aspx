<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IsInRole.aspx.vb" Inherits="IsInRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example of Using IsInRole</title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding=0 cellspacing=0 >
        <tr>
            <td style="border-top: black thin solid;border-right: black thin solid;border-left: black thin solid">
                <b>Role Name</b>
            </td>
            <td style="border-top: black thin solid;border-right: black thin solid">
                <b>Is User In Role?</b>
            </td> 
        </tr>
        <tr>
            <td class="lcol">Administrators</td>
            <td class="rcol">
                <asp:Label ID="Label1" runat="server" Text=<%# User.IsInRole("Administrators") %> />
            </td> 
        </tr>
        <tr>
            <td class="lcol">Regular Users</td>
            <td class="rcol">
                <asp:Label ID="Label2" runat="server" Text=<%# Roles.IsUserInRole("Regular Users") %> />
            </td>             
        </tr>
        <tr>
            <td class="lcol" style="border-bottom: black thin solid">Power Users</td>
            <td class="rcol" style="border-bottom: black thin solid">
                <asp:Label ID="Label3" runat="server" Text=<%# (CType(User,RolePrincipal)).IsInRole("Power Users") %> />
            </td>             
        </tr>                         
    </table>
    <br />
    <a href="Add_Delete_UserRoles.aspx">Click here to manage roles for the logged in user.</a>    
   <br />
   <br />
   <small>Note: For this sample page, create roles called "Administrators", "Regular Users", and "Power Users".</small> 
    </form>
</body>
</html>
