<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptReceiveBook.aspx.vb"
    Inherits="RptReceiveBook" Title="Receive Book Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Receive Book Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            //            msg = NameField100(document.getElementById("<%=txtfromdate.ClientID %>"), 'From Date');
            //            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txtfromdate.ClientID%>"), 'From Date');
            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txttodate.ClientID %>"), 'To Date');
            if (msg != "") return msg;
            //            msg = ValidateDate(document.getElementById("<%=txttodate.ClientID%>"), 'To Date');
            //            if (msg != "") return msg;
            return true;
            //            return true;
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

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="Subject :"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:DropDownList ID="cmbsubject" runat="server" SkinID="ddl" DataSourceID="odsSubject"
                                    DataTextField="Subject_Name" DataValueField="Subjectid" TabIndex="0" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="From Date :" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:TextBox ID="txtfromdate" runat="server" SkinID="txt" TabIndex="0"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="To Date :" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:TextBox ID="txttodate" runat="server" SkinID="txt" TabIndex="0"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="6" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
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
                <asp:ObjectDataSource ID="odsSubject" runat="server" SelectMethod="subjectcombo"
                    TypeName="BookManager"></asp:ObjectDataSource>
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
