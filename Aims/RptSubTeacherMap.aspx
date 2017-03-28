<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptSubTeacherMap.aspx.vb"
    Inherits="RptSubTeacherMap" Title="Subject Teacher Map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Subject Teacher Map</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                <br />
                    <center>
                        <h1 class="headingTxt">
                            SUBJECT TEACHER MAPPING REPORT
                        </h1>
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSub" runat="server" SkinID="lblRsz" Text="Subject :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:TextBox ID="txtsub" runat="server" SkinID="txtRsz" Width="250px" TabIndex="1"></asp:TextBox>&nbsp;&nbsp;
                                    <asp:LinkButton ID="Loadsub" runat="server" SkinID="lb" TabIndex="2">Load Subject</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblselectsub" runat="server" SkinID="lblRsz" Width="150px" Text="Select Subject :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:ListBox ID="ListBox1" Height="200px" Width="300px" SelectionMode="Multiple"
                                        DataValueField="Subjectid" runat="server" TabIndex="3"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="4" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnBack" TabIndex="5" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                        </table>
                        <center>
                            <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                        </center>
                        <div>
                            <center>
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            Loading subjects may take few minutes..
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </center>
                        </div>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

