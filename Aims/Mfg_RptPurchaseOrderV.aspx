<%@ Page Language="VB" AutoEventWireup="false" 
CodeFile="Mfg_RptPurchaseOrderV.aspx.vb" Inherits="Mfg_RptPurchaseOrderV" title="Purchase Order"%>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PURCHASE ORDER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:reportviewer id="ReportViewer1" runat="server" asyncrendering="false" sizetoreportcontent="true">
        </rsweb:ReportViewer>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
        <center>
            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
        </center>
    
    </form>
</body>
</html>
