<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptDepreciationRateV.aspx.vb" Inherits="DepreciationRateV"  Title="Depreciation Report"%>




 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Depreciation Rates</title>
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
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="499px" Width="929px" AsyncRendering="False">
            </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:Label ID="lblmsg" runat="server" SkinID ="lbl"></asp:Label>
                 </div>
    </form>
</body>
</html>
