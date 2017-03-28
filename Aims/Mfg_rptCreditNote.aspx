<%@ Page Title="" Language="VB" AutoEventWireup="false"
    CodeFile="Mfg_rptCreditNote.aspx.vb" Inherits="Mfg_rptCreditNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Credit Note</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

<script type="text/javascript" language="javascript">

    function Valid() {
        var msg;
        msg = DropDownForZero(document.getElementById("<%=ddlinvoice.ClientID %>"), 'Invoice No.');
        if (msg != "") return msg;

        return true;

    }
    function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";

                    return false;
                }
                return true;
            }
        }
//    function Validate() {
//        var msg = Valid();
//        if (msg != true) {
//            if (navigator.appName == "Microsoft Internet Explorer") {
//                document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
//                return false;
//            }
//            else if (navigator.appName == "Netscape") {
//            document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
//                return false;
//            }
//        }
//        return true;
//    }
  


</script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        CREDIT NOTE
                        <br />
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSupplier" runat="server" SkinID="lbl" Text="Supplier/Buyer :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSupplier" runat="server" Width="240px" DataSourceID="ObjSupplier"
                                    DataTextField="Supplier_Name" SkinID="ddlRsz" AutoPostBack="true" DataValueField="Supplier_Id"
                                    TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSupplier" runat="server" SelectMethod="GetSupplier_BuyerDDL"
                                    TypeName="DLProductDetails"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblInvoice" runat="server" Text="Invoice No.*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlinvoice" SkinID="ddlRsz" runat="server" DataSourceID="ObjInvoiceNo"
                                    DataTextField="Invoice_Num" DataValueField="Invoice_Id" TabIndex="1" Width="240px"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjInvoiceNo" runat="server" SelectMethod="GetInvoiceNo"
                                    TypeName="Mfg_DLCreditNote">
                                    <%--<SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSupplier" PropertyName="SelectedValue" Name="Supplier_Name"
                                            DbType="Int16" />
                                    </SelectParameters>--%>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstartdate" Width="150px" runat="server" Text="Start Date :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtstartdate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtstartdate"
                                    Enabled="True">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtstartdate" Enabled="True">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblenddate" runat="server" SkinID="lblRsz" Text="End Date :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtenddate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtenddate"
                                    Enabled="True">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtenddate" Enabled="True">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="2" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick ="return Validate();" ></asp:Button>&nbsp;
                                <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

