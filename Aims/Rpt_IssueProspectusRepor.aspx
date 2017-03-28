<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_IssueProspectusRepor.aspx.vb"
    Inherits="Rpt_IssueProspectusRepor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rpt_IssueProspectusRepor</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
    </script>
 <script language="JavaScript" type="text/javascript">
     function Valid() {
         var msg;
       
         msg = NameField100(document.getElementById("<%=TxtStartDate.ClientID %>"), 'Start Date');
         if (msg != "") return msg;
         msg = ValidateDate(document.getElementById("<%=TxtStartDate.ClientID%>"), 'Start Date');
         if (msg != "") return msg;
         msg = NameField100(document.getElementById("<%=TxtEndDate.ClientID %>"), 'End Date');
         if (msg != "") return msg;
         msg = ValidateDate(document.getElementById("<%=TxtEndDate.ClientID%>"), 'End Date');
         if (msg != "") return msg;
         return true;
         return true;
     }
     function Validate() {
         var msg = Valid();
         if (msg != true) {
             if (navigator.appName == "Microsoft Internet Explorer") {
                 document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                 return false;
             }
             else if (navigator.appName == "Netscape") {
                 document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                 return false;
             }
         }
         return true;
     }
        
 
    </script>
    <form id="Form2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    ISSUE PROSPECTUS REPORT
                </h1>
                 <tr>
                        <td colspan="2">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Start Date : &nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="TxtStartDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtStartDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                     
                     
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label" runat="server" Text="End Date : &nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align ="left">
                            <asp:TextBox ID="TxtEndDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="EDate" runat="server" TargetControlID="txtEndDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <cente>
                    <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnreport" runat="server" Text="Report" SkinID="btn"  TabIndex ="3" OnClientClick="return Validate();" />&nbsp;
                            <asp:Button ID="btnback" runat="server" Text="Back" SkinID="btn" TabIndex ="4" />
                        </td>
                    </tr>
                    </table>
                
                   </cente>
                   <tr align="center">
                        <td>
                 <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                    </td> 
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
