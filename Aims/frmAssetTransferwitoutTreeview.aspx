<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" 
CodeFile="frmAssetTransferwitoutTreeview.aspx.vb" Inherits="frmAssetTransferwitoutTrwwview" title="Asset Transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%= ddlassetType.ClientID %>"), 'Asset Type');
            if (msg != "") {
                document.getElementById("<%= ddlassetType.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%= ddlAssetName.ClientID %>"), 'Asset Name');
            if (msg != "") {
                document.getElementById("<%= ddlAssetName.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%= txtDate.ClientID %>"), 'Date');
            if (msg != "") {
                document.getElementById("<%= txtDate.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlToBrch.ClientID %>"), 'To Branch');
            if (msg != "") {
                document.getElementById("<%=ddlToBrch.ClientID %>").focus();
                return msg;
            }
            msg = Field250N(document.getElementById("<%= txtRemarks.ClientID %>"), 'Remarks');
            if (msg != "") {
                document.getElementById("<%= txtRemarks.ClientID %>").focus();
                return msg;
            }

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
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Asset Type* :&nbsp;&nbsp"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlassetType" runat="server" DataSourceID="cmbAssetType" DataValueField="AssetType_IDAuto"
                                    AppendDataBoundItems="true" DataTextField="AssetType_Name" SkinID="ddl" TabIndex="1"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="cmbAssetType" runat="server" SelectMethod="GetAssetTypescombo"
                                    TypeName="AssetDetailsB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAssetName" runat="server" SkinID="lblRsz" Text="Asset Name* :&nbsp;&nbsp"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAssetName" runat="server" DataSourceID="ObjAssetName" DataValueField="AssetDet_ID_Auto"
                                    DataTextField="AssetCode" SkinID="ddl" TabIndex="2" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjAssetName" runat="server" SelectMethod="GetAssetname"
                                    TypeName="DLAssetTransferNew">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlassetType" DefaultValue="0" Name="Assettype"
                                            PropertyName="SelectedValue" Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFromBranch" runat="server" SkinID="lblRsz" Text="Date of Transfer*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate" runat="server" AutoCompleteType="Disabled" MaxLength="20"
                                    SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtdate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblToBranch" runat="server" SkinID="lblRsz" Text="From Branch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBranchName" runat="server" Enabled="false" Width="245px" SkinID="txtRsz"
                                    TabIndex="6"></asp:TextBox>
                                <%--                                <asp:DropDownList ID="ddlFromBranch" runat="server" AutoPostBack="True" DataSourceID="ObjFromBranch"
                                    DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="4"
                                    Width="250px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjFromBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetBranchTypecombo" TypeName="EmpTranferB"></asp:ObjectDataSource>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="To Branch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlToBrch" runat="server" AutoPostBack="True" DataSourceID="ObjToBranch"
                                    DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="5"
                                    Width="250px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjToBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetBranchTypecombo" TypeName="EmpTranferB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblremarks" runat="server" SkinID="lblRsz" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="7"
                                    Text="ADD" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="8" Text="VIEW" />
                            </td>
                    </table>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                            SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:GridView ID="GridAssetTransfer" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="9"
                                                        CommandName="Edit" Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="10"
                                                        CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Asset Type" Visible="true" SortExpression="AssetType">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="lblID" runat="server" Value='<%# Bind("AssetTransfer_AutoId") %>'>
                                                    </asp:HiddenField>
                                                    <asp:Label ID="lblGVAsstTypeName" runat="server" Text='<%# Bind("AssetType_Name") %>'></asp:Label>
                                                    <asp:Label ID="lblGVAssetTypeID" runat="server" Visible="false" Text='<%# Bind("AssetType") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Asset Code" SortExpression="AssetCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVAssetCode" runat="server" Text='<%# Bind("AssetCode") %>'></asp:Label>
                                                    <asp:Label ID="lblGVAssetCodeId" runat="server" Visible="false" Text='<%# Bind("AssetName")  %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Asset Name" SortExpression="AssetTableName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVAssetName" Width="200px" runat="server" Text='<%# Bind("AssetTableName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Transfer">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVDateOfTransfer" runat="server" Text='<%# Bind("DateOfTransfer","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="From Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVFromBranch" Width="200px" runat="server" Text='<%# Bind("FromBranchName") %>'></asp:Label>
                                                    <asp:Label ID="lblGVFromBranchID" runat="server" Visible="false" Text='<%# Bind("FromBranch")  %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="To Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVToBranch" Width="200px" runat="server" Text='<%# Bind("ToBranchName") %>'></asp:Label>
                                                    <asp:Label ID="lblGVToBranchID" runat="server" Visible="false" Text='<%# Bind("ToBranch")  %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Applicant Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVRemarks" Width="200px" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approval Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVApprovalStatus" runat="server" Text='<%# Bind("ApprovalStatusName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approver Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppRemarks" runat="server" Text='<%# Bind("Approver_Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <center>
                        <a name="Bottom">
                            <div align="right">
                                <a href="#Top">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                            </div>
                        </a>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

