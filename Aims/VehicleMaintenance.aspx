<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VehicleMaintenance.aspx.vb"
    Inherits="VehicleMaintainence" Title="Asset Maintenance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Maintenance</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlassetType.ClientID %>"), 'Asset Type');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlAssetName.ClientID %>"), 'Asset Name');
            if (msg != "") return msg;
            msg = Field255(document.getElementById("<%=txtServiceDetail.ClientID %>"), 'Service Detail');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtServiceDate.ClientID %>"), 'Service Date');
            if (msg != "") return msg;
            msg = FeesField(document.getElementById("<%=txtAmount.ClientID %>"), 'Amount');
            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txtNextServiceDate.ClientID %>"), 'Next Service Date');
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

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%-- <center>
                        <h1 class="headingTxt">
                            VEHICLE MAINTENANCE
                        </h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
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
                                    <asp:Label ID="LblAssetType" runat="server" SkinID="lblRsz" Text="Asset Type*^ :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp<asp:DropDownList ID="ddlassetType" runat="server" DataSourceID="cmbAssetType"
                                        DataValueField="AssetType_IDAuto" AppendDataBoundItems="true" DataTextField="AssetType_Name"
                                        SkinID="ddl" TabIndex="1" AutoPostBack="true">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="cmbAssetType" runat="server" SelectMethod="GetAssetTypescombo"
                                        TypeName="DLRptAssetAllocation"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblName" runat="server" SkinID="lblRsz" Text="Asset Name*^ :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp<asp:DropDownList ID="ddlAssetName" runat="server" DataSourceID="cmbAssetName"
                                        DataValueField="AssetCode" DataTextField="AssetName" SkinID="ddl" TabIndex="2">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="cmbAssetName" runat="server" SelectMethod="GetAssetNamecombo1"
                                        TypeName="DLRptAssetAllocation">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlassetType" DefaultValue="0" Name="AssetType"
                                                PropertyName="SelectedValue" Type="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <%-- <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="Asset/Vehicle Number*^ :&nbsp;&nbsp;"
                                        Width="200px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbVehicle" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                        DataSourceID="ObjectDataSource2" DataTextField="VehicleRegnNo" DataValueField="VehicleIDAuto"
                                        SkinID="ddl" TabIndex="1">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Service Detail* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtServiceDetail" runat="server" SkinID="txt" TextMode="MultiLine"
                                        TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" Text="Service Date*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtServiceDate" runat="server" TabIndex="3" SkinID="txt" MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtServiceDate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtServiceDate"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="Amount* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtAmount" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAmount">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="Next Service Date :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="175px"></asp:Label>
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtNextServiceDate" runat="server" TabIndex="5" SkinID="txt" MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtNextServiceDate"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td style="width: 3px">
                                    <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" Height="30px" TextMode="MultiLine"
                                        Width="200px" TabIndex="6"></asp:TextBox><br />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td style="width: 3px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnsave" runat="server" Text="ADD" SkinID="btn" OnClientClick="return Validate();"
                                        CssClass="ButtonClass" TabIndex="7" />
                                    &nbsp;<asp:Button ID="btnDetail" runat="server" Text="VIEW" TabIndex="8" SkinID="btn"
                                        CssClass="ButtonClass" />
                                    <br />
                                    <br />
                                    <%--<asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <div>
                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                            SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                            <br />
                        </div>
                        <br />
                    </center>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AutoGenerateColumns="False"
                                AllowPaging="True" PageSize="100" EnableSortingAndPagingCallbacks="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                Text="Delete" Visible="True"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Asset Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssetName" runat="server" Text='<%# Bind("AssetType_Name") %>'> </asp:Label>
                                            <asp:Label ID="lblAssetId" runat="server" Visible="false" Text='<%# Bind("AssetType_IDAuto") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Asset Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssetTypeName" runat="server" Text='<%# Bind("AssetName") %>'> </asp:Label>
                                            <asp:Label ID="lblassetTypeId" runat="server" Visible="false" Text='<%# Bind("AssetDet_ID_Auto") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Registration No">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HFVMID" runat="server" Value='<%# Bind("VMID") %>' />
                                            <asp:Label ID="lbl2" runat="server" Text='<%# Bind("RegistrationNo") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Amount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Service Details" ItemStyle-HorizontalAlign="Left"
                                        SortExpression="ServiceDetail">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl3" runat="server" Text='<%# Bind("ServiceDetail") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Service Date" SortExpression="Service_Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl5" Width="75px" runat="server" Text='<%# Bind("Service_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Next Service Date" SortExpression="NextServiceDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl6" Width="75px" runat="server" Text='<%# Bind("NextServiceDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl7" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetVehicleDetails" TypeName="RouteManager"></asp:ObjectDataSource>
                    </center>
                </div>
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