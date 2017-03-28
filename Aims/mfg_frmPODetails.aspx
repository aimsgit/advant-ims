<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="mfg_frmPODetails.aspx.vb"
    Inherits="mfg_frmPODetails" Title="Purchase Order Add Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLProduct.ClientID %>"), 'Product');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlUnit.ClientID %>"), 'Unit');
            if (msg != "") return msg;
           
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
       
    </script>

    <script language="javascript" type="text/javascript">

    function closeWindow()
    {
         window.close();
    } 
    </script>

    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        ADD PURCHASE ORDER DETAILS</h1>
                </center>
                <center>
                    <hr />
                    <table class="custTable">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:RadioButtonList ID="RbProduct" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                    SkinID="Themes" TabIndex="1" Width="398px">
                                    <asp:ListItem Selected="True" Text="Raw Materials" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="ReadyMade" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Finished Goods" Value="3"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCurrency" runat="server" SkinID="lbl" Text="Currency&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCurrency" TabIndex="3" runat="server" SkinID="ddl" DataSourceID="ObjMC"
                                    AutoPostBack="true" DataValueField="Currency_Code" DataTextField="Currency_Name">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjMC" runat="server" SelectMethod="GetMulticurrency" TypeName="MultiCurrencyManager">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblExchRate" SkinID="lbl" runat="server" Text="Exch Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtExRate" SkinID="txt" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblProduct" runat="server" SkinID="lbl" Text="Product*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLProduct" SkinID="ddl" runat="server" DataSourceID="ObjProduct"
                                    DataValueField="Product_Id" DataTextField="Product_Name" AutoPostBack="true">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="ProductComboD"
                                    TypeName="mfg_PurchaseOrderDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="RbProduct" Name="Id" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblUnit" runat="server" SkinID="lbl" Text="Unit*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" SkinID="ddl" runat="server" DataSourceID="ObjUnit"
                                    DataValueField="Unit_ID" DataTextField="Unit">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjUnit" runat="server" SelectMethod="UnitCombo" TypeName="mfg_PurchaseOrderDL">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblQuntity" runat="server" SkinID="lbl" Text="Quantity*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQuantity" SkinID="txt" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblUnitRate" runat="server" SkinID="lblRsz" Text="Unit Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUnitRate" SkinID="txt" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2" align="center">
                                <asp:Button ID="BtnAdd" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="2" Text="ADD" />&nbsp;
                                <asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="3" Text="CLOSE" />&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
