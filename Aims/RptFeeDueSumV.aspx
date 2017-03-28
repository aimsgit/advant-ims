<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptFeeDueSumV.aspx.vb" Inherits="RptFeeDueSumV" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Due Summary</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="468px" AsyncRendering="false"
            SizeToReportContent="true" Width="936px">
        </rsweb:ReportViewer>

        <center>
            <center>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..." SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </center>
            <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>
