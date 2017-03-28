<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmVehicleDetails.aspx.vb"
    Inherits="frmVehicleDetails" Title="Vehicle Details" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vehicle Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtVRegNum.ClientID %>"), 'Vehicle Registration Number');
            document.getElementById("<%=txtVRegNum.ClientID%>").focus();
            if (msg != "") return msg;

            msg = NameField100(document.getElementById("<%=txtYearRegis.ClientID %>"), 'Date of Registration ');
            document.getElementById("<%=txtYearRegis.ClientID%>").focus();
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtYearRegis.ClientID %>"), 'Date of Registration ');
            document.getElementById("<%=txtYearRegis.ClientID%>").focus();
            if (msg != "") return msg;

            msg = NameField100(document.getElementById("<%=txtVType.ClientID %>"), 'Vehicle Type');
            document.getElementById("<%=txtVType.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtVMake.ClientID %>"), 'Vehicle Make');
            document.getElementById("<%=txtVMake.ClientID%>").focus();
            if (msg != "") return msg;

            msg = NameField100(document.getElementById("<%=txtModel.ClientID %>"), 'Model Name');
            document.getElementById("<%=txtModel.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtEngineNo.ClientID %>"), 'Engine Number');
            document.getElementById("<%=txtEngineNo.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtCharsyNo.ClientID %>"), 'Chassis Number');
            document.getElementById("<%=txtCharsyNo.ClientID%>").focus();
            if (msg != "") return msg;
            msg = Field50(document.getElementById("<%=txtFuelType.ClientID %>"), 'Fuel Type');
            document.getElementById("<%=txtFuelType.ClientID%>").focus();
            if (msg != "") return msg;

            msg = NameField100(document.getElementById("<%=txtContractName.ClientID %>"), 'Contractor name');
            if (msg != "") return msg;
            msg = valcontact(document.getElementById("<%=txtContactNo.ClientID %>"), 'Contact number');

            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtSDate.ClientID %>"), 'Start date');

            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtEDate.ClientID %>"), 'End date');

            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txtInsuExpiry.ClientID %>"), 'Insurance Expiry Date ');
            if (msg != "") return msg;

            msg = CompareDate(document.getElementById("<%=txtSDate.ClientID %>"), document.getElementById("<%=txtEDate.ClientID %>"), 'Start date', 'End date');

            if (msg != "") return msg;
            msg = CompareDate(document.getElementById("<%=txtYearRegis.ClientID %>"), document.getElementById("<%=txtSDate.ClientID %>"), 'Date of Registration', 'Start date');

            if (msg != "") return msg;
            return true;

        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsginfo.ClientID%>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsginfo.ClientID%>").innerText = "";

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
                <%--<center>
                    <h1 class="headingTxt">
                        VEHICLE DETAILS
                    </h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="TxtVID" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblVNo" runat="server" Text="Vehicle Registration Number*^ :&nbsp;&nbsp;"
                                    SkinID="lblRSz" Width="250px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVRegNum" runat="server" SkinID="txt" TabIndex="1" MaxLength="50"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtVRegNum">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="iblYearRegis" runat="server" Text="Date of Registration* :&nbsp;&nbsp;"
                                    SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtYearRegis" runat="server" SkinID="txt" TabIndex="2" MaxLength="11"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblVType" runat="server" Text="Vehicle Type*^ :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVType" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtVType">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMake" runat="server" Text="Vehicle Make*^ :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVMake" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtVMake">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblVRelease" runat="server" Text="Year of Make* :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <%--<td>
                                <asp:TextBox ID="txtYearRelease" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                            </td>--%>
                            <td>
                                <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                    DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="5" Width="160px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblModel" runat="server" Text="Model Name* :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtModel" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEngineNo" runat="server" Text="Engine Number* :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEngineNo" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCharsyNo" runat="server" Text="Chassis Number* :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCharsyNo" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="iblSeats" runat="server" Text="No of Seats :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNoSeats" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFuelType" runat="server" Text="Fuel Type*^ :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFuelType" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'0123456789" TargetControlID="txtFuelType">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblInsuranceCompanyName" runat="server" Text="Insurance Company Name :&nbsp;&nbsp;"
                                    SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInsuranceCompanyName" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblInsuranceContactNo" runat="server" Text="Insurance Contact No :&nbsp;&nbsp;"
                                    SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInsuranceContactNo" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtInsuranceContactNo">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPolicyNo" runat="server" Text="Policy No :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPolicyNo" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblInsuranceExpiry" runat="server" Text="Insurance Expiry Date :&nbsp;&nbsp;"
                                    SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtInsuExpiry" runat="server" MaxLength="11" SkinID="txt" TabIndex="14"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRenewal" runat="server" Text="Renewal of Permit Date :&nbsp;&nbsp;"
                                    SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRenewal" runat="server" SkinID="txt" MaxLength="11" TabIndex="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPrice" runat="server" Text="Purchase price/Contract price:&nbsp;&nbsp;"
                                    SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrice" runat="server" TabIndex="16" SkinID="txt">0.00</asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtPrice">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="Vehicle Status :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RBUsers" runat="server" TabIndex="17" AutoPostBack="True"
                                    RepeatDirection="Horizontal" SkinID="Rd">
                                    <asp:ListItem Selected="True" Value="Own">Own</asp:ListItem>
                                    <asp:ListItem Value="Contract">Contract</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblContractorName" runat="server" SkinID="lblRSz" Text="Contractor Name* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContractName" runat="server" SkinID="txt" TabIndex="18"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblContactNo" runat="server" SkinID="lblRSz" Text="Contact Number* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactNo" runat="server" MaxLength="15" SkinID="txt" TabIndex="19"
                                    Width="127px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    FilterMode="ValidChars" ValidChars="0123456789" TargetControlID="txtContactNo">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAddr" runat="server" SkinID="lbl" Text="Address :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddr" runat="server" SkinID="txt" TabIndex="20" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSDate" runat="server" SkinID="lblRSz" Text="Contract Start Date* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSDate" runat="server" MaxLength="11" SkinID="txt" TabIndex="21"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEDate" runat="server" SkinID="lblRSz" Text="Contract End Date* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEDate" runat="server" MaxLength="11" SkinID="txt" TabIndex="22"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="BtnSave" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="23" Text="ADD" />
                                &nbsp;<asp:Button ID="BtnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="24" Text="VIEW" />
                            </td>
                        </tr>
                    </table>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsginfo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                            DataKeyNames="VehicleID" PageSize="100" SkinID="GridView" Visible="true" AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="25"
                                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" TabIndex="26"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VehicleID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("VehicleID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle Registration Number" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" SortExpression="VehicleRegnNo">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("VehicleRegnNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Registration " ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" SortExpression="YearofRegistration">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("YearofRegistration","{0:dd-MMM-yyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle Type " ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                    SortExpression="VehicleType">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("VehicleType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle Make" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                    SortExpression="VehicleMake">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("VehicleMake") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year of Make" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Right" SortExpression="MakeYear">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" Width="100px" runat="server" Text='<%# Bind("MakeYear") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Model Name" HeaderStyle-Width="195px" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Width="100px" Text='<%# Bind("ModelNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Engine Number" HeaderStyle-Width="195px" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Labe18" runat="server" Text='<%# Bind("EngineNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chassis Number" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("ChassisNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No of Seats" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("NoOfSeats") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fuel Type" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="Labe111" runat="server" Text='<%# Bind("FuelType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Insurance Company Name" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-HorizontalAlign="Left" SortExpression="InsuranceComp_name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("InsuranceComp_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Insurance Contact Number" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("InsuranceContact_No") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Policy Number" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("PolicyNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Insurance Expiry" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("InsuranceExpiry","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Renewal of Permit" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" SortExpression="RenewalOfPermit">
                                    <ItemTemplate>
                                        <asp:Label ID="Labe1l6" runat="server" Text='<%# Bind("RenewalOfPermit","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="purchase price/Contract price" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="Labe1l7" runat="server" Text='<%# Bind("PurchasePrice","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contractor Name" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("ContractorName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Number" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="Label19" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Labe120" Width="180" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contract Start Date" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Labe121" runat="server" Text='<%# Bind("StartDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contract End Date" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Labe122" runat="server" Text='<%# Bind("EndDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                    SkinID="Calendar" TargetControlID="txtYearRegis">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                    SkinID="Calendar" TargetControlID="txtInsuExpiry">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MMM-yyyy"
                    SkinID="Calendar" TargetControlID="txtRenewal">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MMM-yyyy"
                    SkinID="Calendar" TargetControlID="txtSDate">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MMM-yyyy"
                    SkinID="Calendar" TargetControlID="txtEDate">
                </ajaxToolkit:CalendarExtender>
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
