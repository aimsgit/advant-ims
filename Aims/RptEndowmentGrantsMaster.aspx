<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptEndowmentGrantsMaster.aspx.vb"
    Inherits="RptEndowmentGrantsMaster" Title="Endowment Master Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Endowment Master Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        //Function for Multilingual Validations
        //Created By Niraj
        function ErrorMessage(msg) {
            var SesVar = '<%= Session("Validation") %>';
            var ValidationArray = new Array();
            ValidationArray = SesVar.split(":");
            for (var i = 0; i < ValidationArray.length - 1; i++) {
                if (ValidationArray[i] == msg) {
                    return ValidationArray[i + 1];
                }
            }
        }


        function Spliter(a) {
            var str = a;
            var n = str.indexOf("*");
            if (n != 0 && n != -1) {
                a = a.split("*");
                return a[0];
            }
            var n = str.indexOf("^");
            if (n != 0 && n != -1) {
                a = a.split("^");
                return a[0];
            }
            var n = str.indexOf(":");
            if (n != 0 && n != -1) {
                a = a.split(":");
                return a[0];
            }
        }
        function Valid() {
            var msg;
            msg = ValidateDateMulN(document.getElementById("<%=txtfromdate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtfromdate.ClientID%>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMulN(document.getElementById("<%=txttodate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txttodate.ClientID%>").focus();
                a = document.getElementById("<%=Label2.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    return false;
                }
                return true;
            }
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

   <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <table>
                        <tr>
                        <br />
                            <td align="center">
                                <h1 class="headingTxt">
                                    <asp:Label ID="LabelEm" runat="server" Text="ENDOWMENT MASTER" SkinID="lblRepRsz"
                                        Width="250" Visible="True"></asp:Label>
                                </h1>
                            </td>
                        </tr>
                    </table>
                </center>
                <table>
                  
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSponsor" runat="server" SkinID="lblRsz" 
                                    Text="Donor/Sponsor  :"></asp:Label>
                            </td>
                            <td align="left">
                                
                                &nbsp;&nbsp;<asp:DropDownList ID="cmbSponsor" runat="server" DataSourceID="Objsponsor" DataTextField="SponsorName"
                                    SkinID="ddl" AutoPostBack="true" DataValueField="Sponsor_IDAuto"
                                    TabIndex="1">                              
                                   </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Received Date From :" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:TextBox ID="txtfromdate" runat="server" SkinID="txtRsz" TabIndex="2"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="Received Date To : " SkinID="lblRsz"></asp:Label>
                                
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:TextBox ID="txttodate" runat="server" SkinID="txtRsz" TabIndex="3"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="4" runat="server" Text="REPORT" SkinID="btn"
                                    CommandName="REPORT" CssClass="ButtonClass" OnClientClick="return Validate();">
                                </asp:Button>
                                <asp:Button ID="btnBack" TabIndex="5" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass"
                                    CommandName="BACK"></asp:Button>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <asp:ObjectDataSource ID="Objsponsor" runat="server" SelectMethod="GetSponsor" TypeName="DLEndowmentReport">
                                </asp:ObjectDataSource>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtfromdate"
                    Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                    Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
