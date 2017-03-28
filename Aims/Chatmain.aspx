<%@ Page Title="" Language="VB" MasterPageFile="~/Chat.master" AutoEventWireup="false"
    CodeFile="Chatmain.aspx.vb" Inherits="Chatmain" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <asp:Panel ID="Panel2" runat="server" ScrollBars ="None">
        <table>
            <tr>
                <td >
                    <asp:TextBox ID="TextBox1" runat="server" Height="38px" Width="470px" TextMode="MultiLine" ></asp:TextBox>
                    
                    </td>
                    <td>
                    <asp:Button ID="Btnok" runat="server" Height="38px" Text="OK" SkinID="btn" Style="float: right"
                        Width="100px" OnClick="Btnok_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%--<script language="javascript" type="text/javascript">
        setTimeout(PingServer, 3000);
        this.onunload = closeChats;
    </script>--%>
</asp:Content>
