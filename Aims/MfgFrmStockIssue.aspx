<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MfgFrmStockIssue.aspx.vb"
    Inherits="MfgFrmStockIssue" Title="Stock Issue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Stock Issue</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=cmbPType.ClientID %>"), 'Party Type');
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=ddlPName.ClientID %>"), 'Party Name');
            if (msg != "") return msg;

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

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLPRODUCT.ClientID %>"), 'Product');
            if (msg != "") return msg;
            msg = FeesField(document.getElementById("<%=txtQtyIssued.ClientID %>"), 'Issued Quantity');
            if (msg != "") return msg;

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
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
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp"
                    BackColor="#E2E3BB">
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="STOCK ISSUE" TabIndex="1">
                        <ContentTemplate>
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                        STOCK ISSUE
                                    </h1>
                                </center>
                                <br />
                                <br />
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDate" runat="server" SkinID="lblRsz" Text="Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDate" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
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
                                    </table>
                                </center>
                                <%--  </asp:Panel>--%>
                                <br />
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td class="btnTd" colspan="2">
                                            <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" OnClientClick="return Validate1();"
                                                SkinID="btn" Text="VIEW" />
                                            <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                OnClientClick="return Validate1();" Text="ADD DETAILS" Width="130px" />
                                                 <asp:Button ID="btnReport" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                    SkinID="btn" Text="REPORT" />
                                                 
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <div>
                                <center>
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress2">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                                Processing your request..please wait...
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </center>
                            </div>
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
                            <center>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="320px">
                                    <asp:GridView ID="GVStockIssue" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkhdr" runat="server" AutoPostBack="true" OnCheckedChanged ="CheckAll"    />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkChild" runat="server" />
                                                </ItemTemplate>
                                                 <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                    <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Issue Date">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="ID1" runat="server" Value='<%# Bind("ID_AutoNo") %>' />
                                                    <asp:Label ID="lblSuppName1" runat="server" Text='<%# Bind("Issue_Date","{0:dd-MMM-yyyy}") %>' />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Party Name">
                                                <ItemTemplate>
                                                    <%-- <asp:Label ID="lblPurchReturnId1" runat="server" Visible="false" Text='<%# Bind("MR_ID") %>'></asp:Label>--%>
                                                    <asp:Label ID="lblPurchReturnNo1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPurchReturnId2" runat="server" Visible="false" Text='<%# Bind("Product_Id") %>'></asp:Label>
                                                    <asp:Label ID="lblPurchReturnNo2" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Issued Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIssuedQty1" runat="server" Text='<%# Bind("Qty_In") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Returned Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReturnedQty1" runat="server" Text='<%# Bind("Qty_Out") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="STOCK ISSUE DETAILS"
                        TabIndex="3">
                        <ContentTemplate>
                            <center>
                                <center>
                                    <h1 class="headingTxt">
                                        STOCK ISSUE DETAILS
                                        <br />
                                        <br />
                                    </h1>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblConvNo" runat="server" SkinID="lblRsz" Text="Conversion Factor&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtConvNo" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblProduct" runat="server" SkinID="lblRsz" Text="Product*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DDLPRODUCT" runat="server" DataSourceID="ObjProduct1" DataTextField="Product_Name"
                                                    Width="200" DataValueField="Product_Id" SkinID="ddlRsz" AutoPostBack="true">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjProduct1" runat="server" SelectMethod="ProductComboD"
                                                    TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblIssuedQty" runat="server" Text="Qty Issued* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtQtyIssued" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server"
                                                    ValidChars="0123456789." TargetControlID="txtReturnedQty" Enabled="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblReturnQty" runat="server" Text="Qty Returned* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtReturnedQty" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender" runat="server"
                                                    ValidChars="0123456789." TargetControlID="txtReturnedQty" Enabled="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblExpiry" runat="server" Text="Expiry Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtExpiryDate" runat="server" Enabled="False" SkinID="txt" ReadOnly="True"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtExpiryDate"
                                                    Format="dd-MMM-yyyy" Animated="False">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td class="btnTd" colspan="4" align="center">
                                                <asp:Button ID="btnAdddet" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                                    SkinID="btn" Text="ADD" />&nbsp;
                                                <asp:Button ID="BtnViewDetails" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                    Text="VIEW" />&nbsp;
                                                <asp:Button ID="BtnClose" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                    SkinID="btn" Text="CLOSE" />&nbsp;
                                                    
                                            </td>
                                        </tr>
                                    </table>
                                    <div>
                                        <center>
                                            <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                                <ProgressTemplate>
                                                    <div class="PleaseWait">
                                                        Processing your request..please wait...
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </center>
                                    </div>
                                    <center>
                                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                                    </center>
                                    <center>
                                        <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="500px" Height="300px">
                                            <asp:GridView ID="GVStockIssueDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                PageSize="100" SkinID="GridView">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="EditProduct" runat="server" CausesValidation="False" CommandName="Edit"
                                                                Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="DeteteProduct" runat="server" CausesValidation="False" CommandName="Delete"
                                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete" Font-Underline="False"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Issue Date">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="ID" runat="server" Value='<%# Bind("ID_AutoNo") %>' />
                                                            <asp:Label ID="lblIssueDate" runat="server" Text='<%# Bind("Issue_Date","{0:dd-MMM-yyyy}") %>' />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Party Name">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="lblPurchReturnId1" runat="server" Visible="false" Text='<%# Bind("MR_ID") %>'></asp:Label>--%>
                                                            <asp:Label ID="lblPurchReturnNo1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Wrap="False" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Product">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPurchReturnId2" runat="server" Visible="false" Text='<%# Bind("Product_Id") %>'></asp:Label>
                                                            <asp:Label ID="lblPurchReturnNo2" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Issued Qty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIssuedQty" runat="server" Text='<%# Bind("Qty_In") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Returned Qty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReturnedQty" runat="server" Text='<%# Bind("Qty_Out") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ConvNo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblConvNo" runat="server" Text='<%# Bind("Conversion_Factor") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
