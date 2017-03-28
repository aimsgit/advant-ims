<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmRouteMaster.aspx.vb"
    Inherits="frmRouteMaster" Title="Route Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Route Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = OneChar(document.getElementById("<%=RouteNumber.ClientID %>"), 'Route Number');
            document.getElementById("<%=RouteNumber.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=RouteName.ClientID %>"), 'Route Name');
            document.getElementById("<%=RouteName.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=DepartureTime.ClientID %>"), 'Departure Time');
            document.getElementById("<%=DepartureTime.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=ArrivalTime.ClientID %>"), 'Arrival Time');
            document.getElementById("<%=ArrivalTime.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlVehicleNo.ClientID %>"), 'Vehicle Number');
            document.getElementById("<%=ddlVehicleNo.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlDriverName.ClientID %>"), 'DriverName');
            document.getElementById("<%=ddlDriverName.ClientID%>").focus();
            if (msg != "") return msg;
            msg = Field255(document.getElementById("<%=PickUpPoint.ClientID %>"), 'Pick Up Points');
            document.getElementById("<%=PickUpPoint.ClientID%>").focus();
            if (msg != "") return msg;
            msg = Field255N(document.getElementById("<%=Remarks.ClientID %>"), 'Remarks');
            document.getElementById("<%=Remarks.ClientID%>").focus();
            if (msg != "") return msg;
            return true;
        }


        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID %>").textContent = "";
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
                            ROUTE MASTER
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
                                <td>
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="RouteID" runat="server" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Route Number*^ :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="RouteNumber" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="RouteNumber">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Text="Route Name* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="RouteName" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label11" runat="server" SkinID="lblRsz" Text="Departure Time(HH:MM)* :&nbsp;&nbsp;"
                                        Width="220px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="DepartureTime" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                                        AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                        Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" TargetControlID="DepartureTime" />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label10" runat="server" SkinID="lblRsz" Text="Arrival Time(HH:MM)* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="ArrivalTime" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender runat="server" AcceptAMPM="true" AcceptNegative="Left"
                                        DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="99:99"
                                        MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" TargetControlID="ArrivalTime" />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" SkinID="lblRsz" Text="Vehicle Number*^ :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlVehicleNo" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                        DataSourceID="ObjectDataSource2" DataTextField="VehicleRegnNo" DataValueField="VehicleIDAuto"
                                        SkinID="ddl" TabIndex="5">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label14" runat="server" SkinID="lblRsz" Text="Driver Name*^ :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDriverName" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                        DataSourceID="ObjectDataSource1" DataTextField="DriverName" DataValueField="DriverIDAuto"
                                        SkinID="ddl" TabIndex="6">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="2">
                                    <asp:Label ID="Label16" runat="server" SkinID="lblRsz" Text="For more than one Pick Up Points enter commas for separation. Ex:___,___"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" SkinID="lblRsz" Text="Pick Up Points*^ :&nbsp;&nbsp;"></asp:Label>
                                    <br />
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="PickUpPoint" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        TargetControlID="PickUpPoint" InvalidChars=".!@#$%^&*()_/+=-{[}]|\':;?><" FilterMode="InvalidChars">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" SkinID="lblRsz" Text="Remarks :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="Remarks" runat="server" SkinID="txt" TabIndex="8" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            </table>
                            <table >
                            <tr>
                                <td colspan="2" style="height: 38px">
                                    <asp:Button ID="BtnSave" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" SkinID="btn" TabIndex="9" Text="ADD" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                        SkinID="btn" TabIndex="10" Text="VIEW" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table>
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
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetDriverDetail_Report" TypeName="RouteManager"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetVehicleDetails" TypeName="RouteManager"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <center>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                DataKeyNames="RouteID" SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                Text="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Route ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("RouteID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Route No" SortExpression="RouteNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("RouteNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Route Name" SortExpression="RouteName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("RouteName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Departure Time">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Departure_Time", "{0:hh:mm tt}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Arrival Time">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Arrival_Time", "{0:hh:mm tt}") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Vehicle No" SortExpression="VehicleRegnNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("VehicleRegnNo") %>'></asp:Label>
                                                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("VehicleIDAuto") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Driver Name" SortExpression="DriverName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("DriverName") %>'></asp:Label>
                                                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("DriverIDAuto") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pick Up Points">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("PickUpPoint") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                </td>
                            </tr>
                        </table>
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
