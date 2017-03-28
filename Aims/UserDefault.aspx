<%@ Page Language="vb" AutoEventWireup="false" CodeFile="UserDefault.aspx.vb" Inherits="UserDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<%--<meta http-equiv="refresh" content="5">
--%>    <title>AIMS Chat Application</title>
    <style type="text/css">
        .style2
        {
            height: 71px;
        }
        .style3
        {
            height: 8px;
            background-color:Maroon;
        }
        .style4
        {
            height: 80px;
        }
    </style>
    
    
<%--//    function myFunction()
//    {
//     document.cookie="";
//           // PageMethods.Logout();
//    
//    }
--%>
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <script>

function getCookie(c_name)
{
var c_value = document.cookie;
var c_start = c_value.indexOf(" " + c_name + "=");
if (c_start == -1)
  {
  c_start = c_value.indexOf(c_name + "=");
  }
if (c_start == -1)
  {
  c_value = null;
  }
else
  {
  c_start = c_value.indexOf("=", c_start) + 1;
  var c_end = c_value.indexOf(";", c_start);
  if (c_end == -1)
    {
    c_end = c_value.length;
    }
  c_value = unescape(c_value.substring(c_start,c_end));
  }
return c_value;
}

function setCookie(c_name,value,exdays)
{
var exdate=new Date();
exdate.setDate(exdate.getDate() + exdays);
var c_value=escape(value) + ((exdays==null) ? "" : "; expires="+exdate.toUTCString());
document.cookie=c_name + "=" + c_value;
}

function checkCookie()
{
var username=getCookie("userid");

    setCookie("userid","",-1);
    
}

    function Logout()
    {
      PageMethods.Logout();
    
    }
    </script>
    
    <script language="javascript" src="js/Chat.js"></script>
       
</head>
<body onbeforeunload="Logout()">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
    EnablePageMethods="true" />
    <div>
    
        <table border="0" cellpadding="0" cellspacing="0" height="560px"
            style="width: 100%; height: 550px;">
            <tr>
                <td class="style2" height="62px">
                
                     <a href="http://www.advant-tech.com" target="_blank" >
                                <asp:Image ID="Image1" runat="server" Height="80px" Style="
                                 " ImageUrl="~/Images/support.png" Width="900px" />
                            </a>
                            <%--<asp:Label runat="server" ID="lblTest" align="right" Text="Chat Application for AIMS"
                                ForeColor="BurlyWood" Font-Names="monotype corsiva" 
                         Font-Size="40px" Style="text-align:center;" Width="1118px"/>--%>
                  </td>          
            </tr>
            <tr>
                <td class="style3" height="8px">
                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" OnClientClick="checkCookie();">Logout</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td >
                    <table style="width:100%;height:488px" >
                        <tr >
                        <td rowspan="3" style="background-color:#eeeeff" width="150" valign="top">
                                Online Support:<br />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                            <ContentTemplate >
                                <asp:Repeater ID="Repeater1" DataSourceID="dsrcWebChat" runat="server" >
                                 
                                   <ItemTemplate>
                                        <span style="cursor:hand;text-decoration:underline; color:Green;" onclick="OpenChatBox('<%#Container.DataItem("UserID")%>','<%#Container.DataItem("UserID")%>_<%#Session("ID")%>_<%#DateTime.Now.Ticks.ToString()%>')"><%#Container.DataItem("Name")%></span><br />
                                    </ItemTemplate>
                           
                                    
                                </asp:Repeater>
                                <asp:ObjectDataSource ID="dsrcWebChat" 
                                     SelectMethod="GetOnlineTech" TypeName="DLDefault" 
                                    runat="server"></asp:ObjectDataSource>
                                
                                <%--<asp:SqlDataSource ID="dsrcWebChat" 
                                    
                                    runat="server"></asp:SqlDataSource>--%>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                            </td>
                            <td colspan="2" class="style4" style=" background-image:url('Images/chat.gif'); border:1px solid black; height:500px;" valign="top" >
                                Hi&nbsp;&nbsp; <asp:Label ID="lblUser" runat="server"></asp:Label>&nbsp;,<br />
&nbsp;
                                Welcome to AIMS Support Application.<br />
                            </td>
                        </tr>
                       
                        
                       
                    </table>
                </td>
            </tr>
        </table>
        <input type="hidden" id="hidCurrentUser" runat="server" />
        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="3000">
        </asp:Timer>
    </div>
    <script language="javascript" type="text/javascript">
        setTimeout(PingServer, 3000);
        this.onunload = closeChats;
    </script>
    </form>
</body>
</html>
