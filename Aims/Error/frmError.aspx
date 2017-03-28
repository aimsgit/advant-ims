<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmError.aspx.vb" Inherits="Error_frmError" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generic Error Page</title>

    <script type="text/javascript" language="javascript">
        function Valid() {
            //          'var msg; 
            //               'javascript:history.go(-1)   
        }
    </script>

</head>
<body style="background-color: #FFEBBF; height: 504px;">
    <form id="form1" runat="server">
    <%--
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
    <div style="background-color: #FFEBBF; height: 504px;">
        <br />
        <br />
        <br />
        <br />
        <br />
        <center>
            <h2 align="center" style="font: Arial; color: Black;">
                Your request could not be processed. If you continue to see the page, please log-out
                and log-in once again. If it still persists, the reason for this could be:</h2>
            <center>
                <table>
                    <tr align="left">
                        <td>
                            <asp:BulletedList ID="BulletedList2" runat="server" Font-Names="Book Man old" Style="margin-left: 0px;
                                margin-bottom: 0px" Width="439px">
                                <asp:ListItem Value="1" Text="You do not have sufficient rights to access this page."></asp:ListItem>
                                <asp:ListItem Value="2" Text="You may be 'Admin' for the institute. Admin does not have employee functions like attendance, leave application, etc."></asp:ListItem>
                                <asp:ListItem Value="3" Text="You may have deleted Master data."></asp:ListItem>
                            </asp:BulletedList>
                        </td>
                    </tr>
                </table>
            </center>
            <h2 align="center" style="font: Arial; color: Black;">
                                &nbsp;Contact Advant Techservices India Private Limited for further assistance.
                <br />
                (<a href="http://www.advant-tech.com" target="_blank"> <u>www.advant-tech.com</u></a>)</h2>
        </center>
        <%-- <asp:Panel ID="InnerErrorPanel" runat="server" Visible="false">
                <p>
                    Inner Error Message:<br />
                    <asp:Label ID="innerMessage" runat="server" Font-Bold="true" Font-Size="Large" /><br />
                </p>
                <pre>
        <asp:Label ID="innerTrace" runat="server" />
      </pre>
            </asp:Panel>
            <p>
                Error Message:<br />
                <asp:Label ID="exMessage" runat="server" Font-Bold="true" Font-Size="Large" />
            </p>
            <pre>      <asp:Label ID="exTrace" runat="server" Visible="false" />
    </pre>--%>
        <br />
        <div align="center">
            <%-- <a href="javascript:history.go(-1)" style="font-weight: bold"></a>--%>
            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="XX-Large">BACK</asp:LinkButton><%--<input name="btnBack" title="BACK" onMouseOver="window.status='Previous Page'; return true" onMouseOut="window.status=''; return true" onclick="location.href = 'javascript:history.go(-1)'" ; type="button" value="BACK"/>--%></div>
        <br />
        <div align="center">
        </div>
        <br />
        <div align="center">
            <%--<asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" Font-Names="Arial">Show Details</asp:LinkButton>--%><%--  <asp:LinkButton ID="LinkButton1" runat="server">ShowError</asp:LinkButton>--%></div>
        <br />
        <div>
            &nbsp;<asp:Label ID="ErrorMessage" runat="server"></asp:Label></div>
        <%--  <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" TargetControlID="LinkButton1"
                        PopupControlID="Literal1" Position="Bottom" CommitProperty="value" />--%>
    </div>
    <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    &nbsp;
    </form>
</body>
</html>
