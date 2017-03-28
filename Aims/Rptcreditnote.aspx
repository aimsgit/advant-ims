<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rptcreditnote.aspx.vb" Inherits="Rptcreditnote" %>




 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Credit Note</title>
   <link href="StyleCR.css" rel="stylesheet" type="text/css" />
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script  src ="JScript.js"  type ="text/javascript" language="javascript"> 
      window.history.forward(1);
        //history.go(1);
   </script>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="499px" Width="929px" AsyncRendering="False">
            </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                 </div>
    </form>
</body>
</html>
