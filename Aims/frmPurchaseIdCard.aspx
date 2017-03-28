<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPurchaseIdCard.aspx.vb"
    Inherits="frmPurchaseIdCard" Title="ID Card Purchase" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ID Card Purchase</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtDate.ClientID%>"), 'Entry Date');
            if (msg != "") {
                document.getElementById("<%=txtDate.ClientID%>").focus();
                return msg;
            }
            msg = CodeField(document.getElementById("<%=txtreceiptno.ClientID %>"), 'Receipt No');
            if (msg != "") {
                document.getElementById("<%=txtreceiptno.ClientID %>").focus();
                return msg;
            }
            msg = FeesFieldRestrictDecimal(document.getElementById("<%=txtquantity.ClientID%>"), 'Quantity');
            if (msg != "") {
                document.getElementById("<%=txtquantity.ClientID%>").focus();
                return msg;
            }
            msg = FeesFieldAcceptDecimal(document.getElementById("<%=txtPrice.ClientID%>"), 'Price');
            if (msg != "") {
                document.getElementById("<%=txtPrice.ClientID%>").focus();
                return msg;
            }
            msg = Field255N(document.getElementById("<%=txtRemarks.ClientID%>"), 'Remarks');
            if (msg != "") {
                document.getElementById("<%=txtRemarks.ClientID%>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";


                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";

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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <%--   <center>
                    <h1 class="headingTxt">
                        PURCHASE IDENTITY CARDS</h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td align="right">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lbldate" runat="server" SkinID="lblRsz" Text="Entry Date* :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;&nbsp;<asp:TextBox ID="txtDate" runat="server" AutoCompleteType="Disabled"
                                                        CausesValidation="true" Enabled="false" SkinID="txt" TabIndex="1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblpreceiptno" runat="server" SkinID="lblRsz" Text="Receipt No* :"></asp:Label>
                                                    <td align="left">
                                                        &nbsp;&nbsp<asp:TextBox ID="txtreceiptno" runat="server" SkinID="txt" TabIndex="2"
                                                            AutoCompleteType="Disabled" CausesValidation="true"></asp:TextBox>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblquantity" runat="server" Text="Quantity* :" SkinID="lblRsz"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;&nbsp<asp:TextBox ID="txtquantity" runat="server" SkinID="txt" TabIndex="3"
                                                        AutoCompleteType="Disabled"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblprice" runat="server" SkinID="lblRsz" Text="Price* :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;&nbsp<asp:TextBox ID="txtPrice" runat="server" MaxLength="9" SkinID="txt" TabIndex="4"
                                                        AutoCompleteType="Disabled"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtPrice">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblremarks" runat="server" Text="Remarks :" SkinID="lblRsz"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;&nbsp<asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TabIndex="5"
                                                        AutoCompleteType="Disabled" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="btnTd">
                                                    <br />
                                                    <asp:Button ID="btnadd" runat="server" CommandName="Update" SkinID="btn" Text="ADD"
                                                        CausesValidation="true" ValidationGroup="DetailsView" TabIndex="6" CssClass="ButtonClass"
                                                        OnClientClick="return Validate();" />
                                                    <asp:Button ID="btnview" runat="server" CausesValidation="False" CommandName="cancel"
                                                        SkinID="btn" Text="VIEW" ValidationGroup="DetailsView" TabIndex="7" CssClass="ButtonClass" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </center>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <br />
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
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
                    <div>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GVpurchaseidcard" runat="server" SkinID="GridView" DataKeyNames=""
                                AllowPaging="true" AutoGenerateColumns="false" PageSize="100" EnableSortingAndPagingCallbacks="True"
                                AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit" TabIndex="8"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="Delete" TabIndex="9" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Entrydate" SortExpression="Entry_Date">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="PID" runat="server" Value='<%# Bind("IdentCrd_ID") %>'></asp:HiddenField>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Entry_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Receipt No" ItemStyle-HorizontalAlign="Right" SortExpression="PReceipt_No">
                                        <ItemTemplate>
                                            <asp:Label ID="txtrecptno" runat="server" Text='<%# Bind("PReceipt_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblquantity" runat="server" Text='<%# Bind("IdentCrd_Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("IdentCrd_Price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" ControlStyle-Width="175px" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" Width="190px" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <div>
                        <asp:ObjectDataSource ID="ObjPurchaseIdCard" runat="server" UpdateMethod="UpdateRecord"
                            TypeName="PurchaseIDCardB" SelectMethod="GetPurchaseIDCard" InsertMethod="InsertRecord"
                            DeleteMethod="ChangeFlag" DataObjectTypeName="PurchaseIDCard">
                            <SelectParameters>
                                <asp:Parameter Name="id" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjGVPIdCard" runat="server" UpdateMethod="UpdateRecord"
                            TypeName="PurchaseIDCardB" SelectMethod="GetPurchaseIDCard" InsertMethod="InsertRecord"
                            DeleteMethod="ChangeFlag" DataObjectTypeName="PurchaseIDCard" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:SessionParameter Name="Office" SessionField="Office" Type="String" />
                                <asp:SessionParameter Name="BranchCode" SessionField="BranchCode" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </center>
                <br />
                <br />
                <br />
                <br />
                <br />
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </a>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
