<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DriverDetails.aspx.vb"
    Inherits="DriverDetails" Title="Driver Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Driver Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;

            msg = NameField100(document.getElementById("<%=txtDriverName.ClientID %>"), 'Driver Name');
            document.getElementById("<%=txtDriverName.ClientID%>").focus();
            if (msg != "") return msg;
            msg = Field255(document.getElementById("<%=txtAddress.ClientID %>"), 'Address');
            document.getElementById("<%=txtAddress.ClientID%>").focus();
            if (msg != "") return msg;
            msg = valcontact(document.getElementById("<%=txtContactNo.ClientID %>"), 'Contact No');
            document.getElementById("<%=txtContactNo.ClientID%>").focus();
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtDOB.ClientID %>"), 'Date Of Birth');
            document.getElementById("<%=txtDOB.ClientID%>").focus();
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtDOJ.ClientID %>"), 'Date Of Joining');
            document.getElementById("<%=txtDOJ.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtDrivingLicenseNo.ClientID %>"), 'Driving License No.');
            document.getElementById("<%=txtDrivingLicenseNo.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=cmbBloodGroup.ClientID %>"), 'Blood Group');
            document.getElementById("<%=cmbBloodGroup.ClientID%>").focus();
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtDLExpiryDate.ClientID %>"), 'Driving License expiry date');
            document.getElementById("<%=txtDLExpiryDate.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtrtoname.ClientID %>"), 'RTO Name');
            document.getElementById("<%=txtrtoname.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtcity.ClientID %>"), 'City');
            document.getElementById("<%=txtcity.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlstate.ClientID %>"), 'State');
            document.getElementById("<%=ddlstate.ClientID%>").focus();
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
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
                <%--<center>
                    <h1 class="headingTxt">
                        DRIVER DETAILS
                    </h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <center>
                    <table class="custTable">
                        <tr>
                            <td style="width: 189px">
                                &nbsp;
                            </td>
                            <td style="font-family: 'Monotype Corsiva'">
                                <h1>
                                    &nbsp;</h1>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:HiddenField ID="HiddrivId" runat="server" />
                                <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Driver Name*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDriverName" SkinID="txt" runat="server" TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtDriverName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Address*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" SkinID="txt" runat="server" AutoCompleteType="Disabled" EnableViewState="False"
                                     TextMode="MultiLine" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Contact No.*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactNo" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtContactNo">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Date of Birth*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDOB" MaxLength="11"  SkinID="txt" runat="server" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDOB"
                                    Format="dd-MMM-yyyy" Animated="False">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Text="Date of Joining*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDOJ" runat="server" MaxLength="11" SkinID="txt" TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDOJ"
                                    Format="dd-MMM-yyyy" Animated="False">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Text="Driving License No.*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDrivingLicenseNo"  SkinID="txt" runat="server" TabIndex="6"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtDrivingLicenseNo">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Blood group*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbBloodGroup" runat="server" SkinID="ddl" TabIndex="7">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                                    <asp:ListItem Text="A+" Value="A+"></asp:ListItem>
                                    <asp:ListItem Text="B+" Value="B+"></asp:ListItem>
                                    <asp:ListItem Text="AB+" Value="AB+"></asp:ListItem>
                                    <asp:ListItem Text="O-" Value="O-"></asp:ListItem>
                                    <asp:ListItem Text="A-" Value="A-"></asp:ListItem>
                                    <asp:ListItem Text="B-" Value="B-"></asp:ListItem>
                                    <asp:ListItem Text="AB-" Value="AB-"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Driving License expiry date*&nbsp;:&nbsp;&nbsp;"
                                    Width="250px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDLExpiryDate" MaxLength="11" SkinID="txt" runat="server" TabIndex="8"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDLExpiryDate"
                                    Format="dd-MMM-yyyy" Animated="False">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" SkinID="lbl" Text="RTO Name*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtrtoname" SkinID="txt" runat="server" TabIndex="9"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="City*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcity" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" SkinID="lbl" Text="State*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlstate" runat="server" SkinID="ddl" AutoPostBack="True" TabIndex="11"
                                    DataSourceID="odsstate" DataTextField="StateName" DataValueField="StateId" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsstate" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetState" TypeName="EnquiryManager">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="0" Name="StateId" Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btn_save" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                    SkinID="btn" Text="ADD" Width="80px" TabIndex="12" />
                                &nbsp;<asp:Button ID="btn_details" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    Text="VIEW" Width="80px" TabIndex="13" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
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
                            <td colspan="2" align="center">
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                            SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" Font-Underline="False"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Driver Name" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="DriverName">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HdndrivId" runat="server" Value='<%#Bind("DriverID") %>' />
                                        <asp:Label ID="lblDriverName" runat="server" Text='<%#Bind("DriverName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddress" runat="server" Text='<%#Bind("Address") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactNo" runat="server" Text='<%#Bind("ContactNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date Of Birth" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="DOB">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("DOB","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date Of Joining" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="DOJ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDOJ" runat="server" Text='<%# Bind("DOJ","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Driving License No" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDLNo" runat="server" Text='<%#Bind("DLNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Blood Group" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBloodGroup" runat="server" Text='<%#Bind("BloodGroup") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Driving License Expiry Date" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="DLExpiry">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDLExp" runat="server" Text='<%#Bind("DLExpiry","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RTO Name" HeaderStyle-HorizontalAlign="Center" SortExpression="RTOName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRTOname" runat="server" Text='<%#Bind("RTOName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcity" runat="server" Text='<%#Bind("City") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HidState" runat="server" Value='<%# Bind("State") %>' />
                                        <asp:Label ID="lblstate" runat="server" Text='<%#Bind("StateName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
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
