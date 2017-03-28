<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Error404.aspx.vb" Inherits="Error_Error404" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="background-color: #FFEBBF; height: 504px;">
    <form id="form1" runat="server">
        <div>
            <%--<h2>
                Generic Error Page</h2>--%>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <h2 align="center" style="font: Arial; color: Red;">
                This page is not available now. Try later.
            </h2>
            <div align="Center">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/nothing2see-900px.gif" /></div>
            <br />
            <div align="center">
                <%-- <a href="javascript:history.go(-1)" style="font-weight: bold"></a>--%>
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="XX-Large">BACK</asp:LinkButton><%--<input name="btnBack" title="BACK" onMouseOver="window.status='Previous Page'; return true" onMouseOut="window.status=''; return true" onclick="location.href = 'javascript:history.go(-1)'" ; type="button" value="BACK"/>--%></div>
            <%--<input name="btnBack" title="BACK" onMouseOver="window.status='Previous Page'; return true" onMouseOut="window.status=''; return true" onclick="location.href = 'javascript:history.go(-1)'" ; type="button" value="BACK"/>--%>
        </div>
        <br />
    </form>
</body>
</html>
