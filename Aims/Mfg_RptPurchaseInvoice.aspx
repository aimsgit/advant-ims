<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_RptPurchaseInvoice.aspx.vb" Inherits="Mfg_RptPurchaseInvoice" title="Purchase Invoice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Purchase Invoice</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

<script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
//            msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID%>"), 'Start Date');
//            if (msg != "") {
//                document.getElementById("<%=txtStartDate.ClientID%>").focus();
//                return msg;
//            }
//            msg = ValidateDate(document.getElementById("<%=txtEndDate.ClientID%>"), 'End Date');
//            if (msg != "") {
//                document.getElementById("<%=txtEndDate.ClientID%>").focus();
//                return msg;
//            }
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
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <center>
        <h1 class="headingTxt">
            PURCHASE INVOICE
        </h1>
        <br />
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Supplier Name :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="cmbSuppName" runat="server" DataSourceID="ObjectDataSource1"
                        DataTextField="Supp_Name" SkinID="ddl" AutoPostBack="true"  AppendDataBoundItems="true"
                        DataValueField="Supp_Id" TabIndex="1">
                       
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSuppName"
                        TypeName="Mfg_RptPurchaseOrderBL"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Purchase Invoice No :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                   <asp:DropDownList ID="cmbPurInv" runat="server" 
                        DataTextField="Purchase_Invoice_No" SkinID="ddl" DataSourceID="ObjectDataSource2" AutoPostBack="true" 
                        DataValueField="PurchMain" TabIndex="2" >                        
                    </asp:DropDownList>
                  <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetPurInv"
                        TypeName="Mfg_RptPurchaseInvoiceBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="cmbSuppName" Name="Supp_Id" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Start Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                        Format="dd-MMM-yyyy">
                    </ajaxToolkit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label4" runat="server" Text="End Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="EDate" runat="server" TargetControlID="txtEndDate"
                        Format="dd-MMM-yyyy">
                    </ajaxToolkit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                         Text="REPORT" SkinID="btn" TabIndex="5"
                        CssClass="ButtonClass " />&nbsp;
                
                    <asp:Button ID="Btnback" runat="server" CausesValidation="True" SkinID="btn" TabIndex="6"
                        Text="BACK" CssClass="ButtonClass " />
                </td>
            </tr>
        </table>
        <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
    </center>
    </ContentTemplate> 
</asp:UpdatePanel> 


</form>
</body>
</html>

