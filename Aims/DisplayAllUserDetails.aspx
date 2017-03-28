<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DisplayAllUserDetails.aspx.vb"
    Inherits="DisplayAllUserDetails" Title="All user details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>All user details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="ODSUserDetails"
        ShowFooter="True" SkinID="GridView" EmptyDataText="There are no records to display." AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" />
             <asp:BoundField DataField="Email" HeaderText="Email" />
             <asp:BoundField DataField="PasswordQuestion" HeaderText="PasswordQuestion" />
              <asp:BoundField DataField="IsApproved" HeaderText="IsApproved" />
               <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" />
                <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" />
                </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ODSUserDetails" runat="server" TypeName="UserDetailsDB" 
        SelectMethod="GetAllUsers"></asp:ObjectDataSource>

</form>
</body>
</html>