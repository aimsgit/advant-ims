<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_RptPurchaseRequisitionReport.aspx.vb"
    Inherits="Mfg_RptPurchaseRequisitionReport" Title="PURCHASE REQUISITION" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PURCHASE REQUISITION</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtfromdate.ClientID%>"), 'Start Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txttodate.ClientID%>"), 'End Date');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    PURCHASE REQUISITION</h1>
            </center>
            <br />
            <br />
            <center>
                <table class="custtable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="200px" Text="Purchase Requisition No :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPurchaseReqNo" runat="server" DataSourceID="ObjPurchaseReqNo"
                                DataTextField="PurchaseRequisitionNo" DataValueField="PurchaseRequisitionNoId"
                                SkinID="ddlRsz" TabIndex="1" Width="205" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjPurchaseReqNo" runat="server" SelectMethod="PuurchaseRequisitionNo"
                                TypeName="DLPurchaseRequisition"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblfromdate" runat="server" SkinID="lbl" Text="Start Date*  :&nbsp;&amp;nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtfromdate" runat="server" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion" runat="server" TargetControlID="txtfromdate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbltodate" runat="server" SkinID="lbl" Text="End Date*  :&nbsp;&amp;nbsp"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txttodate" runat="server" TabIndex="3"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button ID="btRpt" CausesValidation="true" runat="server" Text="REPORT" SkinID="btn"
                                CommandName="Report" TabIndex="4" CssClass="ButtonClass" OnClick="btRpt_Click"
                                OnClientClick="return Validate();" />
                            <asp:Button ID="btnBack" runat="server" Text="BACK" CausesValidation="False" SkinID="btn"
                                CssClass="ButtonClass" TabIndex="5" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
            </center>
            <center>
                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

