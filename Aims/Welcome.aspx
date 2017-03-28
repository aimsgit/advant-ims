<%@ Page Language="VB" AutoEventWireup="false" CodeFile="welcome.aspx.vb" Inherits="welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to CBMIS</title>
    <style type="text/css">
        .button {
   border-top: 1px solid #96d1f8;
   background: #65a9d7;
   background: -webkit-gradient(linear, left top, left bottom, from(#32178c), to(#65a9d7));
   background: -webkit-linear-gradient(top, #32178c, #65a9d7);
   background: -moz-linear-gradient(top, #32178c, #65a9d7);
   background: -ms-linear-gradient(top, #32178c, #65a9d7);
   background: -o-linear-gradient(top, #32178c, #65a9d7);
   padding: 15.5px 31px;
   -webkit-border-radius: 14px;
   -moz-border-radius: 14px;
   border-radius: 14px;
   -webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
   -moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
   box-shadow: rgba(0,0,0,1) 0 1px 0;
   text-shadow: rgba(0,0,0,.4) 0 1px 0;
   color: white;
   font-size: 20px;
   font-family: Georgia, Serif;
   text-decoration: none;
   vertical-align: middle;
   }
.button:hover {
   border-top-color: #b03162;
   background: #b03162;
   color: #ccc;
   }
.button:active {
   border-top-color: #221c4f;
   background: #221c4f;
   }
    </style>
    
</head>
<body style="width: 950px; height: 540px; background: url(Images/HigherEdu1.png);
    background-repeat: no-repeat; padding-top: 40px;">
    <form id="form1" runat="server">
    <div style="float: right; position: absolute; top: 550px; right: 75px;">
        <asp:Button ID="BtnGoLive" runat="server" Text="->Log In" class="button" />
       
    </div>
    </form>
</body>
</html>
