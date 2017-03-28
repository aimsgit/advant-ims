<%@ Page Language="vb" AutoEventWireup="false" CodeFile="ChatBox.aspx.vb" Inherits="ChatBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ChatBox</title>
    <style type="text/css">
        .style1
        {
            height: 82px;
        }
        .style2
        {
            height: 12px;
        }
    </style>
 
    <script language=javascript src="js/ChatBox.js"></script>
</head>
<body onbeforeunload="javascript:window.close()">
    <form id="form1" runat="server" defaultbutton="btnSend">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <audio id="sound1" src="js/button-9.mp3" preload="auto"></audio>
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;
                    
                </td>
            </tr>
            <tr>
                <td class="style2" height="8px" style="background-color:Maroon"></td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                    
                            <asp:Panel ID="msgPanel" Font-Names="verdana" Font-Size="8pt" 
                        runat="server" Height="359px" BorderStyle="Solid" BorderWidth="1pt" Width="420px" 
                        BackImageUrl="~/Images/ct.gif">
                            </asp:Panel>
                            <asp:Panel ID="lblUrl" runat="server"></asp:Panel>
                        
                </td>
            </tr>
            <tr>
                <td class="style2" height="8px" style="background-color:Maroon"></td>
            </tr>
            <tr>
                <td width="420px" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                        <ContentTemplate>
                         
                    <asp:TextBox ID="txtMsg" runat="server" Height="72px" Width="338px" 
                        Font-Names="Verdana" Font-Size="8pt" MaxLength="1000" TextMode="MultiLine" ></asp:TextBox>&nbsp;
                            <asp:Button ID="btnSend" runat="server" BackColor="Maroon" Font-Bold="True" 
                                Font-Size="Large" ForeColor="White" Height="72px" style="float:right" 
                                Text="SEND" Width="74px" />
                   
                    </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click" />
                        </Triggers>
       </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        
    </div>
    <input type="hidden" id="hidChatId" runat="server" />
    </form>
</body>
</html>
