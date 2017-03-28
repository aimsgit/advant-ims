<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ChatLogin.aspx.vb" Inherits="ChatLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

    <title>Login Page</title>
    




    <style type="text/css">
        .style1
        {
            height: 444px;
            width: 461px;
        }
        </style>

</head>
<body >
    
     <center>
    
    <form id="form1" runat="server" defaultbutton="btnLogin" class="style1">
   
   
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    
     
       
        <asp:Image ID="Image1" runat="server" Height="64px" Width="83px" 
                ImageUrl="~/Images/log.gif" />    
    <br />
    <br />
            <b><asp:Label ID="Label2" runat="server" Text="AIMS SUPPORT APPLICATION" Font-Bold="True"  Font-Size="20"></asp:Label></b>  
    
        <br />
        <br />
            <asp:Label ID="Label3" runat="server" Text="&nbsp&nbsp&nbsp&nbsp&nbsp(Enter your name as username to login into the application.)" 
                Font-Names="Monotype Corsiva" Font-Size="15pt" CssClass="label" 
            Width="457px" ForeColor="#009933" ></asp:Label>
          
            <br />
            <br />
            <br />
          <table  cellspacing="1" cellpadding="1" align="center" >
                    
                    <tr>
                        <td align="center">
                            <asp:Label ID="lbluser" runat="server" Text="USERNAME" Font-Bold="True"  Font-Size="20"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        
                        <td align="center">
                            <asp:TextBox ID="txtUserID" runat="server"  Width="250px" 
            Height="30px" Font-Bold="True" Font-Size="15pt" ForeColor="Blue" style="text-align:center"></asp:TextBox>
             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="*~!@$%^&*()+\0123456789"
                                    TargetControlID="txtUserID"></ajaxToolkit:FilteredTextBoxExtender>
            
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <td align="center">
                        <br />
                        <br />
                            <asp:Button ID="btnLogin" Text="LOGIN"  runat="server"  Width="260px" 
                                Height="40px" ForeColor="#009900" SkinID ="big" Font-Bold="True" 
                                Font-Size="Large"/>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="center" class="style3">
                           <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </td>
                    </tr>
                </table>
             
       

             
          
             
    <%--Password: <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" cssclass="placeholder"></asp:TextBox>--%>
    
        
    
         &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        
                      
             
        

   
    </form>
    </center> 
</body>
</html>
