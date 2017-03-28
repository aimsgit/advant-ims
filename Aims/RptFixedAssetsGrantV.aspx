<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptFixedAssetsGrantV.aspx.vb"
    Inherits="RptFixedAssetsGrantV" Title="Fixed Asset Grant" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Response</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <script language="JavaScript" type="text/javascript">
    function Valid()
    {
        var msg;   
        msg=ValidateDate(document.getElementById("<%=txtStartDate.ClientID%>"),'Start Date');
        if (msg != "") {
            document.getElementById("<%=txtStartDate.ClientID%>").focus();
            return msg;
        }
        msg=ValidateDate(document.getElementById("<%=txtEndDate.ClientID%>"),'End Date');
        if (msg != "") {
            document.getElementById("<%=txtEndDate.ClientID%>").focus();
            return msg;
        }
        return true;
    }
   function Validate(){
          var msg=Valid();
          if(msg!=true)
          { 
                    if(navigator.appName=="Microsoft Internet Explorer")
                    {
                     document.getElementById("<%=msginfo.ClientID %>").innerText=msg;
                     return false;
                    }
                    else  if(navigator.appName == "Netscape")
                    {  
                     document.getElementById("<%=msginfo.ClientID %>").textContent=msg;
                     return false;
                    }   
          }
           return true;
 }
    </script>

    <div class="mainBlock">
        <center>
            <h1>
                <asp:Label ID="LblTitle" runat="server" Text="FIXED ASSET GRANT" CssClass="headingTxt"></asp:Label>
            </h1>
        </center>
        <center>
            <table>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Start Date *  :" SkinID="lblRsz"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="End Date *  :" SkinID="lblRsz"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                    </td>
                    <td>
                        <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtStartDate"
                            Format="dd-MMM-yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="btnTd">
                        <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                            CommandName="Report" OnClick="Btnreport_Click" Text="REPORT" SkinID="btnRsz"
                            TabIndex="3" CssClass="ButtonClass " />
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <div>
        <center>
            <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true" TabIndex="-1"></asp:Label>
        </center>
    </div>
</form>
</body>
</html>
