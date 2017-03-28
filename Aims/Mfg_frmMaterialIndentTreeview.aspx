<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="Mfg_frmMaterialIndentTreeview.aspx.vb"
    Inherits="Mfg_frmMaterialIndentTreeview" Title="Material Indent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=cmbPType.ClientID%>"), 'Party Type')
            if (msg != "") {
                document.getElementById("<%=cmbPType.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlPName.ClientID%>"), 'Party Name')
            if (msg != "") {
                document.getElementById("<%=ddlPName.ClientID%>").focus();
                return msg;
            }

            return true;
        }


        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlItemDesc.ClientID%>"), 'Item Decription')
            if (msg != "") {
                document.getElementById("<%=ddlItemDesc.ClientID%>").focus();
                return msg;
            }
            msg = FeesField(document.getElementById("<%=txtQuantity.ClientID%>"), 'Item Quantity')
            if (msg != "") {
                document.getElementById("<%=txtQuantity.ClientID%>").focus();
                return msg;
            }

            return true;
        }


        function Validate1() {

            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        function Valid2() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=cmbPType.ClientID%>"), 'Party Type')
            if (msg != "") {
                document.getElementById("<%=cmbPType.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlPName.ClientID%>"), 'Party Name')
            if (msg != "") {
                document.getElementById("<%=ddlPName.ClientID%>").focus();
                return msg;
            }


            return true;
        }
        function Validate2() {

            var msg = Valid2();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
  
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp"
                    BackColor="#E2E3BB">
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Material Indent Main"
                        TabIndex="1">
                        <ContentTemplate>
                            <center>
                                <div>
                                    <center>
                                        <h1 class="headingTxt">
                                            MATERIAL INDENT MAIN
                                        </h1>
                                    </center>
                                </div>
                                <br />
                                <br />
                                <center>
                                    <table class="custTable">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblMino" runat="server" Text="MI No :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Width="150px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtmino" SkinID="txt" runat="server" TabIndex="1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblMiDate" runat="server" Text="MI Date :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Width="150px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMidate" SkinID="txt" runat="server" TabIndex="2"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtMidate"
                                                    Format="dd-MMM-yyyy" Animated="False" Enabled="True">
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
                                                <asp:Label ID="lblWorkorder" runat="server" Text="Work Order :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlWorkOrder" runat="server" DataTextField="Sale_Order_Number"
                                                    DataSourceID="ObjWorkOrder" DataValueField="Sales_Order_ID" Width="240px" SkinID="ddlRsz"
                                                    TabIndex="4" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjWorkOrder" runat="server" SelectMethod="GetWorkOrderDDL"
                                                    TypeName="MaterialIndentDL"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <center>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="5"
                                                        Text="ADD" Width="80px" OnClientClick="return Validate();" />
                                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="6"
                                                        Text="VIEW" Width="100px" OnClientClick="return Validate2();" />
                                                    <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                        TabIndex="7" Text="VIEW DETAILS" Width="120px" OnClientClick="return Validate();" />
                                                    <asp:Button ID="btnPost" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="8"
                                                        Text="POST" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div>
                                            <center>
                                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                                    <ProgressTemplate>
                                                        <div class="PleaseWait">
                                                            Processing your request..please wait...
                                                        </div>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </center>
                                        </div>
                                    </center>
                                    <br />
                                    <center>
                                        <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                                    </center>
                                    <center>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" PageSize="100"
                                                SkinID="GridView" TabIndex="-1">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                                Text="Post" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" />
                                                            <asp:Label ID="LabelPre" runat="server" Text='<%# Bind("PostToStock") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                cssproperty="Btnclass" Text="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                cssproperty="Btnclass" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete">
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MI No.">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HID" runat="server" Value='<%# Eval("MI_ID") %>' />
                                                            <asp:Label ID="lblMi_No" runat="server" Text='<%# Bind("MI_No") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MI Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMi_Date" runat="server" Text='<%# Bind("MI_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Party Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCustomer_id" runat="server" Text='<%# Bind("Party_Id") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblCustomer_Name" runat="server" Text='<%# Bind("PartyName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Party Type" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPType_id" runat="server" Text='<%# Bind("PartyType_Id") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblPType_Name" runat="server" Text='<%# Bind("PartyName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Work Order">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblWo_Id" runat="server" Text='<%# Bind("SO_Id") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblWorkOrder" runat="server" Text='<%# Bind("Sale_Order_Number") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approval Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPost" runat="server" Text='<%# Bind("PostToStock") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Remarks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAppRemarks" runat="server" Text='<%# Bind("Approver_Remarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Material Indent Details"
                        TabIndex="2">
                        <ContentTemplate>
                            <center>
                                <h1 class="headingTxt">
                                    ADD DETAILS</h1>
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblItemDesc" runat="server" Text="Item Description*:&nbsp;&nbsp;"
                                                SkinID="lblRsz" Width="150px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlItemDesc" runat="server" DataTextField="Product_Name" DataSourceID="ObjItemDesc"
                                                DataValueField="Product_Id" Width="240px" SkinID="ddlRsz" TabIndex="3" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjItemDesc" runat="server" SelectMethod="GetItemDescriptionDDL"
                                                TypeName="MaterialIndentDL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblQty" runat="server" Text="Quantity*:&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="150px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtQuantity" SkinID="txt" runat="server" TabIndex="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <center>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnAddDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                    TabIndex="5" Text="ADD" Width="80px" OnClientClick="return Validate1();" />
                                                <asp:Button ID="btnViewDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                    TabIndex="6" Text="VIEW" Width="100px" />
                                                <asp:Button ID="btnClose" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="7"
                                                    Text="CLOSE" Width="100px" />
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
                                </center>
                                <br />
                                <center>
                                    <asp:Label ID="lblgreen" runat="server" SkinID="lblgreen"></asp:Label>
                                    <asp:Label ID="lblRed" runat="server" SkinID="lblred"></asp:Label>
                                </center>
                                <center>
                                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" PageSize="100"
                                            SkinID="GridView" TabIndex="-1">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            cssproperty="Btnclass" Text="Edit"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                            cssproperty="Btnclass" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Item Description" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="HID" runat="server" Value='<%# Eval("MI_ID") %>' />
                                                        <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("Product_Id") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblItemDesc" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Unit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnit_Id" runat="server" Text='<%# Bind("Unit_ID") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="false" />
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
                            <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="Images/top.png" Width="30px" />
                        </a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
