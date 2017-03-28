<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmAgeStockStatement.aspx.vb" Inherits="Mfg_frmAgeStockStatement" Title ="Age WiseStock Statement Report"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Age WiseStock Statement Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

 <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
           
//            msg = DropDownForZero(document.getElementById("<%=ddlCompany.ClientID%>"), 'Company');

//            if (msg != "") {
//                document.getElementById("<%=ddlCompany.ClientID%>").focus();
//                return msg;
//            }
            msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID%>"), 'Start Date');

            if (msg != "") {
                document.getElementById("<%=txtStartDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtEndDate.ClientID%>"), 'End Date');

            if (msg != "") {
                document.getElementById("<%=txtEndDate.ClientID%>").focus();
                return msg;
            }
            
             function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }
   </script>
            
            
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
          
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
   <a name="Top">
       <div align="right">
         <a href="#Bottom">
           <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" />
          </a>
        </div>
        <center>
               <h1 class="headingTxt">
                   AGE STOCK STATEMENT
              </h1>
       </center>
                <br />
                <br />
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCompanyName" runat="server" Text="Company Name  :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCompany" runat="server" DataTextField="Manufaturer_Name" DataSourceID="ObjCompaney"
                                        DataValueField="Manufacturer_ID" SkinID="ddlRsz" TabIndex="1" AppendDataBoundItems="True"
                                        AutoPostBack="false" Width ="250px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCompaney" runat="server" SelectMethod="Get_CompanyName"
                                     TypeName="Mfg_AgeStockStatementDL">
                                     </asp:ObjectDataSource>
                                </td>
                          </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtStartDate" TabIndex="2" runat="server" SkinID="txt"></asp:TextBox>
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                 FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters" ValidChars="-/" TargetControlID="txtStartDate"
                                Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                             <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtStartDate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                              <td align="right">
                                <asp:Label ID="lblEndDate" runat="server" Text="End Date* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                            <td align="left">
                                    <asp:TextBox ID="txtEndDate" TabIndex="3" runat="server" SkinID="txt"></asp:TextBox>
                                  
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                 FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters" ValidChars="-/" TargetControlID="txtEndDate"
                                Enabled="True">
                            </ajaxToolkit:FilteredTextBoxExtender>
                             <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtEndDate" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                              </td>
                            </tr>
                         </table>
                        </center>
                    </br>
                    <center>
                        <table>
                            <tr>
                            <td>
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="9" Text="REPORT" Width="100px"/>
                                  
                                    <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="11"
                                        Text="BACK" Width="100px"/>
                                    
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                    </center>
                    </ContentTemplate> 
                    </asp:UpdatePanel> 
                  </form>
</body>
</html>

