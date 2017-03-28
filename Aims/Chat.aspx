<%@ Page Title="Support Application" Language="VB" 
    AutoEventWireup="false" CodeFile="Chat.aspx.vb" Inherits="Chat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Support Application</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div class="mainBlock">

        <script type="text/javascript">

            function openwd() {

                window.open('frmsupportlogin.aspx', '', 'width=565,left=300,top=200,height=440,scrollbars=true').focus

            } 
        </script>

        <div class="mainBlock">
            <center>
                <h1 class="headingTxt">
                    SUPPORT APPLICATION</h1>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" Text="NEW TECHNICAL SUPPORT" SkinID="btn3"
                    Width="200px" Height="30px"  />
                <br />
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" Text="CLEAR USERS" SkinID="btn3"
                    Width="200px" Height="30px"  />
                <br />
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="SUPPORT APPLICATION" SkinID="btn3"
                    Width="200px" Height="30px" OnClientClick="openwd();" />
            </center>
        </div>

</form>
</body>
</html>