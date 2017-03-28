<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frm_RptMaterialIndent.aspx.vb"
    Inherits="Mfg_frmMaterialIndex" Title="Material Indent" %>

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
    <script type="text/javascript" language="javascript">
        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=cmbPType.ClientID %>"), 'Party Type');
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=ddlPName.ClientID %>"), 'Party Name');
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=ddlWorkOrder.ClientID%>"), 'Work Order')
            if (msg != "") {
                document.getElementById("<%=ddlWorkOrder.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblGreenM.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblRedM.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblGreenM.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblRedM.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
       
    </script>

   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                     
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                       Material Indent
                                    </h1>
                                </center>
                                &nbsp;
                               <center>
                                    <table>
                                    <tr>
                                            <td align="right">
                                                <asp:Label ID="lblMino" runat="server" Text="MI No :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Width="150px"></asp:Label>
                                            </td>
                                            <td align="left">
                                               <asp:DropDownList ID="ddlMiNo" runat="server" SkinID="ddl" DataSourceID="ObjectDataSource1"
                                                    AutoPostBack="True" DataValueField="MI_AutoId" DataTextField="MI_NO">
                                                      </asp:DropDownList>
                                                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetMaterialMI_NO"
                                                    TypeName="Mfg_DLStockIssue">
                                                    </asp:ObjectDataSource> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDate" runat="server" SkinID="lblRsz" Text="Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDate" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="Date" runat="server" TargetControlID="txtDate"
                                                    Format="dd-MMM-yyyy" Enabled="True">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label6" runat="server" Text="Party Type* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="cmbPType" TabIndex="6" runat="server" SkinID="ddl" DataSourceID="ObjPartyType"
                                                    AutoPostBack="True" DataValueField="Id" DataTextField="Name">
                                                    <%--<asp:ListItem Text ="Select" Value ="0"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjPartyType" runat="server" SelectMethod="GetPartyTypeddl"
                                                    TypeName="Mfg_DLStockIssue"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label1" runat="server" Text="Party Name* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPName" TabIndex="7" runat="server" SkinID="ddl" DataSourceID="ObjParty_Name"
                                                    AutoPostBack="True" DataValueField="ID" DataTextField="Name">
                                                    <%-- <asp:ListItem Text ="select" Value ="0"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjParty_Name" runat="server" SelectMethod="GetPartyNameddl"
                                                    TypeName="Mfg_DLStockIssue">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="cmbPType" Name="PartyName" Type="String" PropertyName="SelectedValue" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td align="right">
                                                <asp:Label ID="lblWorkorder" runat="server" Text="Work Order* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlWorkOrder" runat="server" DataTextField="Sale_Order_Number"
                                                    DataSourceID="ObjWorkOrder" DataValueField="Sales_Order_ID"  SkinID="ddl"
                                                    TabIndex="4" AutoPostBack="true">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjWorkOrder" runat="server" SelectMethod="GetWorkOrderDDL"
                                                    TypeName="MaterialIndentDL"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <%--  </asp:Panel>--%>
                                <br />
                            </center>
                            <center>
                                <table>
                                    <tr>
                                    <td>
                                              
                                                 <asp:Button ID="btnReport" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                    SkinID="btn" Text="REPORT" />
                                                     <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                OnClientClick="return Validate1();" Text="BACK"  />
                                                 
                                        </td>
                                    </tr>
                                </table>
                            </center>
                                   <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblGreenM" runat="server" SkinID="lblRed"></asp:Label>
                                            <asp:Label ID="lblRedM" runat="server" SkinID="lblGreen"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            </br>
                            
                 </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>