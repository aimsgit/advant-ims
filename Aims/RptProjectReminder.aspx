﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptProjectReminder.aspx.vb" Inherits="RptProjectReminder" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Program Status </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lblProgramStatus" runat="server" SkinID="lblRsz" Width="450px" Heigh="350px" ></asp:Label>
        <center>
            <asp:Label ID="lblmsg" runat="server" skinid="lblRed"></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>
