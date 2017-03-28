<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmCRM.aspx.vb"
    Inherits="FrmCRM" Title="CRM" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CRM</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">


        function ValidAppt() {

            msg = DropDownForZero(document.getElementById("<%=ddlLeadAppt.ClientID %>"), 'Lead');
            if (msg != "") {
                document.getElementById("<%=ddlLeadAppt.ClientID %>").focus();
                return msg;
            }

            msg = ValidateDate(document.getElementById("<%=txtApptDate.ClientID %>"), 'Appointment Date');
            if (msg != "") {
                document.getElementById("<%=txtApptDate.ClientID %>").focus();
                return msg;
            }

            msg = minmaxlength(document.getElementById("<%=txtApptTime.ClientID %>"), 8, 8, 'Appointment Time');
            if (msg != "") {
                document.getElementById("<%=txtApptTime.ClientID %>").focus();
                return msg;
            }


            msg = DropDownForZero(document.getElementById("<%=ddlApptAssignedto.ClientID %>"), 'Assigned To');
            if (msg != "") {
                document.getElementById("<%=ddlApptAssignedto.ClientID %>").focus();
                return msg;
            }



            return true;
        }

        function ValidateAppt() {

            var msg = ValidAppt();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblApptErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msgApptinfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblApptErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msgApptinfo.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtlead.ClientID%>"), 'Lead');
            if (msg != "") {
                document.getElementById("<%=txtlead.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlproduct.ClientID%>"), 'Product');
            if (msg != "") {
                document.getElementById("<%=ddlproduct.ClientID%>").focus();
                return msg;
            }
            msg = minlength(document.getElementById("<%=txtcontact.ClientID%>"), 6, 'Contact No');
            if (msg != "") {
                document.getElementById("<%=txtcontact.ClientID%>").focus();
                return msg;
            }
            msg = validateEmail(document.getElementById("<%=txtEmail.ClientID%>"), '');
            document.getElementById("<%=txtEmail.ClientID%>").focus();
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsginfo.ClientID %>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsginfo.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }
        function ValidDemo() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLDemoLead.ClientID%>"), 'Lead');
            if (msg != "") {
                document.getElementById("<%=DDLDemoLead.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtDemoDate.ClientID%>"), 'Demo Date');
            if (msg != "") {
                document.getElementById("<%=txtDemoDate.ClientID%>").focus();
                return msg;
            }
            msg = minmaxlength(document.getElementById("<%=txtDemoTime.ClientID%>"), 8, 8, 'Demo Time');
            if (msg != "") {
                document.getElementById("<%=txtDemoTime.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLAssignedTo.ClientID%>"), 'Assigned To');
            if (msg != "") {
                document.getElementById("<%=DDLAssignedTo.ClientID%>").focus();
                return msg;
            }
            msg = DropDown(document.getElementById("<%=DDLDemoStatus.ClientID%>"), 'Demo Status');
            if (msg != "") {
                document.getElementById("<%=DDLDemoStatus.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function ValidateDemo() {
            var msg = ValidDemo();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblError.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblCorrect.ClientID %>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblError.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblCorrect.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        } function ValidProposal() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLProposalLead.ClientID%>"), 'Lead');
            if (msg != "") {
                document.getElementById("<%=DDLProposalLead.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtProposalDate.ClientID%>"), 'Proposal Date');
            if (msg != "") {
                document.getElementById("<%=txtProposalDate.ClientID%>").focus();
                return msg;
            }
            msg = minmaxlength(document.getElementById("<%=txtProposalTime.ClientID%>"), 1, 15, 'Proposal Value');
            if (msg != "") {
                document.getElementById("<%=txtProposalTime.ClientID%>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txtProposalTime.ClientID%>"), 'Proposal Value');
            if (msg != "") {
                document.getElementById("<%=txtProposalTime.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLProposalAssignedTo.ClientID%>"), 'Assigned To');
            if (msg != "") {
                document.getElementById("<%=DDLProposalAssignedTo.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function ValidateProposal() {
            var msg = ValidProposal();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblProposalError.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblProposalCorrect.ClientID %>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblProposalError.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblProposalCorrect.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }
        function ValidWO() {

            msg = DropDownForZero(document.getElementById("<%=ddlWOLead.ClientID %>"), 'Lead');
            if (msg != "") {
                document.getElementById("<%=ddlWOLead.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function ValidateWO() {

            var msg = ValidWO();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblWOErrosmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblWOmsginfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblWOErrosmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblWOmsginfo.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel runat="server" ID="UpdatePanel">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image3" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp"
                    ActiveTabIndex="0">
                    <ajaxToolkit:TabPanel ID="LEAD" runat="server" HeaderText="LEAD">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="LEADUpdatePanel1">
                                <ContentTemplate>
                                    <center>
                                        <h3 class="headingTxt">
                                            LEAD
                                        </h3>
                                    </center>
                                    <center>
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lbllead" runat="server" SkinID="lbl" Text="Lead*^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="hidLeadid" runat="server" />
                                                    <asp:TextBox ID="txtlead" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblproduct" runat="server" SkinID="lbl" Text="Product*^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlproduct" runat="server" SkinID="ddl" TabIndex="2">
                                                        <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                        <asp:ListItem Value="AIMS" Text="AIMS"></asp:ListItem>
                                                        <asp:ListItem Value="Manufacturing" Text="Manufacturing"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblProspect" runat="server" SkinID="lbl" Text="Prospect ID^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtProspect" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblAddress" runat="server" SkinID="lbl" Text="Address :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txt" TextMode="MultiLine" TabIndex="4"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="LblLeadfrom" runat="server" SkinID="lbl" Text="Lead From^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtLeadfrom" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Lblstate" runat="server" SkinID="lbl" Text="State^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="True" DataSourceID="ObjState"
                                                        DataTextField="StateName" DataValueField="StateId" SkinID="ddl" TabIndex="6">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjState" runat="server" SelectMethod="GetState" TypeName="DLCRMLead">
                                                        <SelectParameters>
                                                            <asp:Parameter DefaultValue="0" Name="StateId" Type="Int32" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="LblProbabilty" runat="server" SkinID="lbl" Text="Probability :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtProbability" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                        FilterMode="validChars" FilterType="Custom" TargetControlID="TxtProbability"
                                                        ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblCountry" runat="server" SkinID="lbl" Text="Country^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtCountry" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblcontact" runat="server" SkinID="lbl" Text="Contact No* :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtcontact" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblEmail" runat="server" SkinID="lbl" Text="Email* :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmail" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblLeadDate" runat="server" SkinID="lbl" Text="Lead Date :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtLeadDate" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="LblSkype" runat="server" SkinID="lbl" Text="Skype ID :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="Txtskype" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblEstimate" runat="server" SkinID="lblRsz" Width="150px" Text="Estimated Value :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEstimate" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                        FilterMode="validChars" FilterType="Custom" TargetControlID="txtEstimate" ValidChars=".0123456789">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Lblremarks1" runat="server" SkinID="lbl" Text="Remarks :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtRemarks" runat="server" SkinID="txt" TextMode="MultiLine" TabIndex="14"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblStatus" runat="server" SkinID="lbl" Text="Status^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddl" TabIndex="15">
                                                        <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                        <asp:ListItem Value="Lead" Text="Lead"></asp:ListItem>
                                                        <asp:ListItem Value="Appointment" Text="Appointment"></asp:ListItem>
                                                        <asp:ListItem Value="Demo" Text="Demo"></asp:ListItem>
                                                        <asp:ListItem Value="Proposal" Text="Proposal"></asp:ListItem>
                                                        <asp:ListItem Value="Work order" Text="Work order"></asp:ListItem>
                                                        <asp:ListItem Value="Rollout" Text="Rollout"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            </table>
                                            <table>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Button ID="btnSave" runat="server" SkinID="btn" TabIndex="16" Text="ADD" OnClientClick="return Validate();"
                                                        CssClass="ButtonClass" />
                                                    &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" SkinID="btn"
                                                        TabIndex="17" Text="VIEW" CssClass="ButtonClass" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    &nbsp
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
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
                                                <td colspan="4">
                                                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                                    <asp:Label ID="lblmsginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtLeadDate">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtLeadDate"
                                                        Format="dd-MMM-yyyy" Animated="False">
                                                    </ajaxToolkit:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                                        <asp:GridView ID="GVCRMLead" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                            SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText=" " ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                            TabIndex="18" Text="Edit" />
                                                                        <asp:LinkButton ID="Button3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                            OnClientClick="return confirm('Do you want to delete this record?')" TabIndex="19"
                                                                            Text="Delete" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Lead" HeaderStyle-HorizontalAlign="Center" SortExpression="LeadName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLead_ID" Visible="false" runat="server" Text='<%# Bind("Lead_ID") %>' />
                                                                        <asp:Label ID="lblLeadName" runat="server" Text='<%# Bind("LeadName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Prospect ID" HeaderStyle-HorizontalAlign="Center" SortExpression="PropectId">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProspect" runat="server" Text='<%# Bind("PropectId") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Product Name" HeaderStyle-HorizontalAlign="Center" SortExpression="Product">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblproduct" runat="server" Text='<%# Bind("Product") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Lead From" HeaderStyle-HorizontalAlign="Center" SortExpression="LeadFrom">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblleadfrm" runat="server" Text='<%# Bind("LeadFrom") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="True" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Lead Date" HeaderStyle-HorizontalAlign="Center" SortExpression="LeadDate">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLdDate" runat="server" Text='<%# Bind("LeadDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Contact No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcontact" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Email ID" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEmailID" runat="server" Text='<%# Bind("EmailID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Skype ID" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSkypeId" runat="server" Text='<%# Bind("SkypeID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-HorizontalAlign ="Center" >
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus1" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAddress" runat="server" Width="150px" Text='<%# Bind("Address") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="True" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="State" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstat" runat="server" Text='<%# Bind("State") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="LblstateName" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="True" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Country">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Estimated Value" HeaderStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEstimatedValue" runat="server" Text='<%# Bind("EstimatedValue","{0:n2}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Probability" HeaderStyle-HorizontalAlign ="Center" >
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProbability" runat="server" Text='<%# Bind("Probability") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign ="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="APPOINTMENT" runat="server" HeaderText="APPOINTMENT">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                <ContentTemplate>
                                    <%-- <a name="top">
                                            <div align="right">
                                                <a href="#bottom">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                                            </div>--%>
                                    <center>
                                        <h3 class="headingTxt">
                                            APPOINTMENT
                                        </h3>
                                    </center>
                                    <center>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblLeadAppt" runat="server" Text="Lead*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlLeadAppt" runat="server" SkinID="ddlRsz" DataSourceID="ObjLead"
                                                            Width="200" DataValueField="LeadAutoID" DataTextField="LeadName" TabIndex="1">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="ObjLead" runat="server" SelectMethod="GetLeadCombo" TypeName="DLAppointmentCRM">
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                    <td>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td align="right" rowspan="5">
                                                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black"
                                                            OnDayRender="Calendar1_DayRender" BorderWidth="1px" FirstDayOfWeek="Monday" Font-Names="Verdana"
                                                            Font-Size="Medium" ForeColor="#663399" Height="100px" ShowGridLines="True" Width="100px"
                                                            BorderStyle="Double" CellSpacing="1">
                                                            <SelectedDayStyle Font-Bold="false" />
                                                            <WeekendDayStyle BackColor="Silver" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                            <DayHeaderStyle Font-Bold="True" Height="1px" BackColor="#FFFF99" />
                                                            <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        </asp:Calendar>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblApptDate" runat="server" Text="Appointment Date* :&nbsp;&nbsp;"
                                                            SkinID="lblRsz"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtApptDate" TabIndex="2" runat="server" SkinID="txt"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                            FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtApptDate">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtApptDate"
                                                            Format="dd-MMM-yyyy" Animated="False">
                                                        </ajaxToolkit:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblApptTime" runat="server" Text="Appointment Time* :&nbsp;&nbsp;"
                                                            SkinID="lblRsz"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtApptTime" runat="server" TabIndex="3"></asp:TextBox>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender14" runat="server" AcceptAMPM="true"
                                                            AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                            Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                            OnInvalidCssClass="MaskedEditError" TargetControlID="txtApptTime" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label2" runat="server" Text="Assigned To*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlApptAssignedto" runat="server" SkinID="ddl" DataSourceID="ObjEmp"
                                                            DataValueField="EmpID" DataTextField="Emp_Name" TabIndex="4">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="ObjEmp" runat="server" SelectMethod="GetEmpCombo" TypeName="DLAppointmentCRM">
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label3" runat="server" Text="Status* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlApptStatus" runat="server" SkinID="ddl" TabIndex="5" Enabled="false">
                                                            <asp:ListItem Text="Appointment" Value="Appointment"></asp:ListItem>
                                                            <asp:ListItem Text="Lead" Value="Lead"></asp:ListItem>
                                                            <asp:ListItem Text="Demo" Value="Demo"></asp:ListItem>
                                                            <asp:ListItem Text="Quote(proposal)" Value="Quote(proposal)"></asp:ListItem>
                                                            <asp:ListItem Text="WO/PO" Value="WO/PO"></asp:ListItem>
                                                            <asp:ListItem Text="Roll Out" Value="Roll Out"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" valign="top">
                                                        <asp:Label ID="lblRemarks" runat="server" SkinID="lblRsz" Width="160px" Text="Remarks :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <FTB:FreeTextBox ID="txtmsgAppt" runat="server" TabIndex="6" AllowHtmlMode="True"
                                                            BreakMode="LineBreak" ButtonSet="OfficeMac" EnableHtmlMode="false" HtmlModeDefaultsToMonoSpaceFont="True"
                                                            ShowTagPath="False" Width="330px" Height="200" EditorBorderColorDark="Black"
                                                            EditorBorderColorLight="Wheat">
                                                        </FTB:FreeTextBox>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td align="center" colspan="4">
                                                        <asp:Button ID="btn_Apptadd" runat="server" CommandName="Insert" CssClass="ButtonClass"
                                                            SkinID="btn" TabIndex="7" Text="ADD" OnClientClick="return ValidateAppt();" />
                                                        &nbsp;
                                                        <asp:Button ID="btn_Apptview" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                            TabIndex="8" Text="VIEW" />
                                                        &nbsp;
                                                        <asp:Button ID="btn_Apptsendmail" runat="server" TabIndex="9" CausesValidation="False"
                                                            Width="100" CssClass="ButtonClass" SkinID="btnRsz" Text="SEND MAIL" OnClientClick="return confirm('Do you want to send mail to client?')" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:UpdateProgress runat="server" ID="UpdateProgress2">
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
                                                    <td colspan="4">
                                                        <asp:Label ID="lblApptErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                                        &nbsp;
                                                        <asp:Label ID="msgApptinfo" runat="server" SkinID="lblGreen"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                 </tbody>
                                                </table>
                                                <%--</a>--%>
                                                
                                                    <center>
                                                        <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="850px" Height="300px">
                                                            <asp:GridView ID="GVApptCrm" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                SkinID="GridView" Visible="False" Width="595px" ForeColor="Black" PageSize="100"
                                                                AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText=" " ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                TabIndex="9" Text="Edit" />
                                                                            <asp:LinkButton ID="Button3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                OnClientClick="return confirm('Do you want to delete this record?')" TabIndex="10"
                                                                                Text="Delete" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Send mail" SortExpression="center" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ChkRL" TabIndex="11" runat="server" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                                        <HeaderStyle HorizontalAlign="center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Lead" SortExpression="LeadName" HeaderStyle-HorizontalAlign ="Center" >
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="CAId" runat="server" Value='<%# Bind("COAutoId") %>' />
                                                                            <asp:HiddenField ID="LeadId" runat="server" Value='<%# Bind("LeadId") %>' />
                                                                            <asp:Label ID="LeadName" runat="server" Text='<%# Bind("LeadName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Appointment Date" SortExpression="AppointmentDate">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAdate" runat="server" Text='<%# Bind("AppointmentDate","{0:dd-MMM-yyy}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Appointment Time ">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAtime" runat="server" Text='<%# Bind("AppointmantTime","{0:hh:mm tt}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                          <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Assigned To" SortExpression="Emp_Name">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="lblempid" runat="server" Value='<%# Bind("EmpID") %>' />
                                                                            <asp:Label ID="lblAssignedTo" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                          <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                          <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                          <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <%--<PagerStyle HorizontalAlign="Center" />--%>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                   </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="DEMO" runat="server" HeaderText="DEMO">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                <ContentTemplate>
                                    <center>
                                        <h2 class="headingTxt">
                                            DEMO
                                        </h2>
                                    </center>
                                    <center>
                                        <table>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblDemoLead" runat="server" SkinID="lbl" Text="Lead*^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:HiddenField ID="HidDemoID" runat="server" />
                                                    <asp:DropDownList ID="DDLDemoLead" runat="server" DataSourceID="ObjDemoLead" DataTextField="LeadName"
                                                        DataValueField="LeadAutoID" SkinID="ddlRsz" Width="200" TabIndex="1">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjDemoLead" runat="server" SelectMethod="GetLeadCombo"
                                                        TypeName="DLAppointmentCRM"></asp:ObjectDataSource>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td rowspan="5">
                                                    <asp:Calendar ID="DemoCalender" runat="server" BackColor="White" BorderColor="Black"
                                                        OnDayRender="DemoCalender_DayRender" BorderWidth="1px" FirstDayOfWeek="Monday"
                                                        Font-Names="Verdana" Font-Size="Medium" ForeColor="#663399" ShowGridLines="True"
                                                        BorderStyle="Double" CellSpacing="1" Width="100px" Height="100px">
                                                        <SelectedDayStyle Font-Bold="False" />
                                                        <WeekendDayStyle BackColor="Silver" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblDemoDate" runat="server" SkinID="lblRsz" Width="180px" Text="Demo Date* :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDemoDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="txtd_CalendarExtender" runat="server" Enabled="True"
                                                        Format="dd-MMM-yyyy" TargetControlID="txtDemoDate">
                                                    </ajaxToolkit:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblDemoTime" runat="server" SkinID="lblRsz" Width="180px" Text="Demo Time* :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDemoTime" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99:99"
                                                        MaskType="Time" TargetControlID="txtDemoTime">
                                                    </ajaxToolkit:MaskedEditExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblAssignedTo" runat="server" SkinID="lbl" Text="Assigned To*^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DDLAssignedTo" runat="server" DataSourceID="ObjAssignedTo"
                                                        DataTextField="Emp_Name" DataValueField="EmpID" SkinID="ddl" TabIndex="1">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjAssignedTo" runat="server" SelectMethod="GetEmpCombo"
                                                        TypeName="DLAppointmentCRM"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblDemoStatus" runat="server" SkinID="lbl" Text="Status :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DDLDemoStatus" Enabled="False" runat="server" SkinID="ddl"
                                                        TabIndex="9">
                                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                        <asp:ListItem Text="Lead" Value="Lead"></asp:ListItem>
                                                        <asp:ListItem Text="Appointment" Value="Appointment"></asp:ListItem>
                                                        <asp:ListItem Text="Demo" Value="Demo"></asp:ListItem>
                                                        <asp:ListItem Text="Proposal" Value="Proposal"></asp:ListItem>
                                                        <asp:ListItem Text="Work order" Value="Work order"></asp:ListItem>
                                                        <asp:ListItem Text="Rollout" Value="Rollout"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                    <asp:Label ID="lblDemoReport" runat="server" SkinID="lbl" Text="Demo Report :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <FTB:FreeTextBox ID="txtDemoReport" Width="350px" Height="200px" runat="server" AllowHtmlMode="True"
                                                        BreakMode="LineBreak" ButtonSet="OfficeMac" EnableHtmlMode="False" HtmlModeDefaultsToMonoSpaceFont="True"
                                                        ShowTagPath="False" EditorBorderColorDark="Black" EditorBorderColorLight="Wheat"
                                                        AssemblyResourceHandlerPath="" AutoConfigure="" AutoGenerateToolbarsFromString="True"
                                                        AutoHideToolbar="True" AutoParseStyles="True" BackColor="158, 190, 245" BaseUrl=""
                                                        ButtonDownImage="False" ButtonFileExtention="gif" ButtonFolder="Images" ButtonHeight="20"
                                                        ButtonImagesLocation="InternalResource" ButtonOverImage="False" ButtonPath=""
                                                        ButtonWidth="21" ClientSideTextChanged="" ConvertHtmlSymbolsToHtmlCodes="False"
                                                        DesignModeBodyTagCssClass="" DesignModeCss="" DisableIEBackButton="False" DownLevelCols="50"
                                                        DownLevelMessage="" DownLevelMode="TextArea" DownLevelRows="10" EnableSsl="False"
                                                        EnableToolbars="True" Focus="False" FormatHtmlTagsToXhtml="True" GutterBackColor="129, 169, 226"
                                                        GutterBorderColorDark="Gray" GutterBorderColorLight="White" HelperFilesParameters=""
                                                        HelperFilesPath="" HtmlModeCss="" ImageGalleryPath="~/images/" ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&amp;cif={0}"
                                                        InstallationErrorMessage="InlineMessage" JavaScriptLocation="InternalResource"
                                                        Language="en-US" PasteMode="Default" ReadOnly="False" RemoveScriptNameFromBookmarks="True"
                                                        RemoveServerNameFromUrls="True" RenderMode="NotSet" ScriptMode="External" SslUrl="/."
                                                        StartMode="DesignMode" StripAllScripting="False" SupportFolder="/aspnet_client/FreeTextBox/"
                                                        TabIndex="-1" TabMode="InsertSpaces" Text="" TextDirection="LeftToRight" ToolbarBackColor="Transparent"
                                                        ToolbarBackgroundImage="True" ToolbarImagesLocation="InternalResource" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                                                        ToolbarStyleConfiguration="OfficeMac" UpdateToolbar="True" UseToolbarBackGroundImage="True">
                                                    </FTB:FreeTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    &nbsp;
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
                                                <td align="center" colspan="4">
                                                    <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" OnClientClick="return ValidateDemo();"
                                                        SkinID="btn" TabIndex="8" Text="ADD" />
                                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="8"
                                                        Text="VIEW" />
                                                    <asp:Button ID="btnSendMail" runat="server" CssClass="ButtonClass" OnClientClick="return confirm('Do you want to mail to the client?')"
                                                        SkinID="btnRsz" Width="120px" TabIndex="8" Text="SEND MAIL" />
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
                                                <td colspan="4">
                                                    <asp:UpdateProgress runat="server" ID="UpdateProgress3">
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
                                                <td align="center" colspan="4">
                                                    <asp:Label ID="lblError" runat="server" SkinID="lblRed"></asp:Label>
                                                    <asp:Label ID="lblcorrect" runat="server" SkinID="lblGreen"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <asp:Panel ID="panel2" runat="server" Height="300px" ScrollBars="Auto" Width="750px">
                                                        <asp:GridView ID="GVDemo" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                            PageSize="100" SkinID="GridView" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText=" " ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                            TabIndex="12" Text="Edit" />
                                                                        <asp:LinkButton ID="Button3" runat="server" CausesValidation="False" CommandName="Delete"
                                                                            OnClientClick="return confirm('Do you want to delete this record?')" TabIndex="13"
                                                                            Text="Delete" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Send Mail">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CAId" runat="server" AutoPostBack="true" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle HorizontalAlign ="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Lead" HeaderStyle-HorizontalAlign="Center" SortExpression="LeadName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCOAutoId" runat="server" Text='<%# Bind("COAutoId") %>' Visible="false" />
                                                                        <asp:Label ID="lblLead_ID" runat="server" Text='<%# Bind("LeadID") %>' Visible="false" />
                                                                        <asp:Label ID="lblLeadName" runat="server" Text='<%# Bind("LeadName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Demo Date" SortExpression="AppointmentDate">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDemoDate" runat="server" Text='<%# Bind("AppointmentDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                     <HeaderStyle HorizontalAlign ="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Demo Time">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDemoTime" runat="server" Text='<%# Bind("AppointmantTime") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Assigned To" HeaderStyle-HorizontalAlign="Left" SortExpression="Emp_Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAssignedToID" runat="server" Visible="false" Text='<%# Bind("AssignedTo") %>'></asp:Label>
                                                                        <asp:Label ID="lblAssignedToName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                     <HeaderStyle HorizontalAlign ="Center" />
                                                                    <ItemStyle Wrap="True" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Demo Remarks" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>' Width="150"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="Proposal" runat="server" HeaderText="PROPOSAL">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="ProposalUPanel" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                </Triggers>
                                <ContentTemplate>
                                    <center>
                                        <h3 class="headingTxt">
                                            PROPOSAL
                                        </h3>
                                    </center>
                                    <center>
                                        <table>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblProposalLead" runat="server" SkinID="lbl" Text="Lead*^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:HiddenField ID="HidProposal" runat="server" />
                                                    <asp:DropDownList ID="ddlProposalLead" runat="server" DataSourceID="ObjProposalLead"
                                                        DataTextField="LeadName" DataValueField="LeadAutoID" SkinID="ddlRsz" Width="200"
                                                        TabIndex="1">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjProposalLead" runat="server" SelectMethod="GetLeadCombo"
                                                        TypeName="DLAppointmentCRM"></asp:ObjectDataSource>
                                                </td>
                                                <td colspan="2" rowspan="5">
                                                    <asp:Calendar ID="ProposalCalendar" runat="server" BackColor="White" BorderColor="Black"
                                                        OnDayRender="ProposalCalendar_DayRender" BorderWidth="1px" FirstDayOfWeek="Monday"
                                                        Font-Names="Verdana" Font-Size="Medium" ForeColor="#663399" Height="100px" ShowGridLines="True"
                                                        Width="100px" BorderStyle="Double" CellSpacing="1">
                                                        <SelectedDayStyle Font-Bold="False" />
                                                        <WeekendDayStyle BackColor="Silver" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblProposalDate" runat="server" SkinID="lblRsz" Width="180px" Text="Proposal Date* :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtProposalDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                        Format="dd-MMM-yyyy" TargetControlID="txtProposalDate">
                                                    </ajaxToolkit:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblProposalTime" runat="server" SkinID="lblRsz" Width="180px" Text="Proposal value* :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtProposalTime" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                                    <%--<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="True"
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                        CultureTimePlaceholder="" Enabled="True" ErrorTooltipEnabled="True" Mask="99:99"
                                                        MaskType="Time" TargetControlID="txtProposalTime">
                                                    </ajaxToolkit:MaskedEditExtender>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblProposalAssignedto" runat="server" SkinID="lbl" Text="Assigned To* :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlProposalAssignedto" runat="server" DataSourceID="ObjProposalAssignedto"
                                                        DataTextField="Emp_Name" DataValueField="EmpID" SkinID="ddl" TabIndex="4">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjProposalAssignedto" runat="server" SelectMethod="GetEmpCombo"
                                                        TypeName="DLAppointmentCRM"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblProposalStatus" runat="server" SkinID="lbl" Text="Status^ :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlProposalStatus" runat="server" Enabled="False" SkinID="ddl"
                                                        TabIndex="5">
                                                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                        <asp:ListItem Text="Lead" Value="Lead"></asp:ListItem>
                                                        <asp:ListItem Text="Appointment" Value="Appointment"></asp:ListItem>
                                                        <asp:ListItem Text="Demo" Value="Demo"></asp:ListItem>
                                                        <asp:ListItem Text="Proposal" Value="Proposal"></asp:ListItem>
                                                        <asp:ListItem Text="Work order" Value="Work order"></asp:ListItem>
                                                        <asp:ListItem Text="Rollout" Value="Rollout"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblProposalRemarks" runat="server" SkinID="lbl" Text="Proposal Mail :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="3">
                                                    <FTB:FreeTextBox ID="FTBProposalRemarks" runat="server" AllowHtmlMode="True" BreakMode="LineBreak"
                                                        ButtonSet="Office2003" EnableHtmlMode="False" HtmlModeDefaultsToMonoSpaceFont="True"
                                                        ShowTagPath="False" Width="350px" Height="300px" EditorBorderColorDark="Black"
                                                        EditorBorderColorLight="Wheat" AssemblyResourceHandlerPath="" AutoConfigure=""
                                                        AutoGenerateToolbarsFromString="True" AutoHideToolbar="True" AutoParseStyles="True"
                                                        BackColor="158, 190, 245" BaseUrl="" ButtonDownImage="False" ButtonFileExtention="gif"
                                                        ButtonFolder="Images" ButtonHeight="20" ButtonImagesLocation="InternalResource"
                                                        ButtonOverImage="False" ButtonPath="" ButtonWidth="21" ClientSideTextChanged=""
                                                        ConvertHtmlSymbolsToHtmlCodes="False" DesignModeBodyTagCssClass="" DesignModeCss=""
                                                        DisableIEBackButton="False" DownLevelCols="50" DownLevelMessage="" DownLevelMode="TextArea"
                                                        DownLevelRows="10" EnableSsl="False" EnableToolbars="True" Focus="False" FormatHtmlTagsToXhtml="True"
                                                        GutterBackColor="129, 169, 226" GutterBorderColorDark="Gray" GutterBorderColorLight="White"
                                                        HelperFilesParameters="" HelperFilesPath="" HtmlModeCss="" ImageGalleryPath="~/images/"
                                                        ImageGalleryUrl="ftb.imagegallery.aspx?rif={0}&amp;cif={0}" InstallationErrorMessage="InlineMessage"
                                                        JavaScriptLocation="InternalResource" Language="en-US" PasteMode="Default" ReadOnly="False"
                                                        RemoveScriptNameFromBookmarks="True" RemoveServerNameFromUrls="True" RenderMode="NotSet"
                                                        ScriptMode="External" SslUrl="/." StartMode="DesignMode" StripAllScripting="False"
                                                        SupportFolder="/aspnet_client/FreeTextBox/" TabIndex="6" TabMode="InsertSpaces"
                                                        Text="" TextDirection="LeftToRight" ToolbarBackColor="Transparent" ToolbarBackgroundImage="True"
                                                        ToolbarImagesLocation="InternalResource" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"
                                                        ToolbarStyleConfiguration="Office2003" UpdateToolbar="True" UseToolbarBackGroundImage="True">
                                                    </FTB:FreeTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblAttachment" runat="server" SkinID="lbl" Text="Attachment :&nbsp;&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="White" SkinID="btn"
                                                        TabIndex="7" />
                                                </td>
                                                <td align="left">
                                                    <%--<asp:UpdatePanel ID="updatepnl1" runat="server">
                                                    <ContentTemplate>--%>
                                                    <asp:Button ID="btnUpload" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="8"
                                                        Text="UPLOAD" />
                                                    <%--</ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btnUpload" />
                                                    </Triggers>
                                                </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtPath" runat="server" Visible="false"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:Button ID="btnProposalAdd" runat="server" CssClass="ButtonClass" OnClientClick="return ValidateProposal();"
                                                        SkinID="btn" TabIndex="9" Text="ADD" />
                                                    <asp:Button ID="btnProposalView" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                        TabIndex="10" Text="VIEW" />
                                                    <asp:Button ID="btnProposalMail" runat="server" CssClass="ButtonClass" OnClientClick="return confirm('Do you want to mail to the client?')"
                                                        SkinID="btnRsz" Width="120px" TabIndex="11" Text="SEND MAIL" />
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
                                                <td colspan="4">
                                                    <asp:UpdateProgress runat="server" ID="UpdateProgress4">
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
                                                <td align="center" colspan="4">
                                                    <asp:Label ID="lblProposalError" runat="server" SkinID="lblRed"></asp:Label>
                                                    <asp:Label ID="lblProposalCorrect" runat="server" SkinID="lblGreen"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <asp:Panel ID="Proposalpanel" runat="server" Height="300px" ScrollBars="Auto" Width="750px">
                                                        <asp:GridView ID="GVProposal" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                            PageSize="100" SkinID="GridView" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText=" " ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnProposalEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                                            TabIndex="12" Text="Edit" />
                                                                        <asp:LinkButton ID="btnProposalDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                                            OnClientClick="return confirm('Do you want to delete this record?')" TabIndex="13"
                                                                            Text="Delete" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Send Mail" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CAId" runat="server" AutoPostBack="true" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Lead" HeaderStyle-HorizontalAlign="Center" SortExpression="LeadName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCOAutoId1" runat="server" Text='<%# Bind("COAutoId") %>' Visible="false" />
                                                                        <asp:Label ID="lblLead_ID" runat="server" Text='<%# Bind("LeadID") %>' Visible="false" />
                                                                        <asp:Label ID="lblLeadName" runat="server" Text='<%# Bind("LeadName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Proposal Date" SortExpression="AppointmentDate" HeaderStyle-HorizontalAlign="Center"> 
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDemoDate" runat="server" Text='<%# Bind("AppointmentDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Proposal Value" HeaderStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDemoTime" runat="server" Text='<%# Bind("ProposalValue","{0:n2}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Assigned To" HeaderStyle-HorizontalAlign="Center" SortExpression="Emp_Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAssignedToID" runat="server" Visible="false" Text='<%# Bind("AssignedTo") %>'></asp:Label>
                                                                        <asp:Label ID="lblAssignedToName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="True" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Proposal Mail" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Attachment" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAttachement" runat="server" Text='<%# Bind("Attachment") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="WORKORDER" runat="server" HeaderText="WORK ORDER/ PURCHASE ORDER">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                <ContentTemplate>
                                    <center>
                                        <h3 class="headingTxt">
                                            WORK ORDER/ PURCHASE ORDER
                                        </h3>
                                    </center>
                                    <center>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblWOLead" runat="server" Text="Lead*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlWOLead" runat="server" SkinID="ddl" DataSourceID="ObjWOLead"
                                                            DataValueField="LeadAutoID" DataTextField="LeadName" TabIndex="1">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="ObjWOLead" runat="server" SelectMethod="GetLeadCombo" TypeName="DLAppointmentCRM">
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblWOStatus" runat="server" Text="Status* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlWOStatus" runat="server" SkinID="ddl" TabIndex="2" Enabled="false">
                                                            <asp:ListItem Value="Work order" Text="Work order"></asp:ListItem>
                                                            <asp:ListItem Text="Appointment" Value="Appointment"></asp:ListItem>
                                                            <asp:ListItem Text="Lead" Value="Lead"></asp:ListItem>
                                                            <asp:ListItem Text="Demo" Value="Demo"></asp:ListItem>
                                                            <asp:ListItem Text="Proposal" Value="Quote(proposal)"></asp:ListItem>
                                                            <asp:ListItem Text="Roll Out" Value="Roll Out"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblWOValue" runat="server" SkinID="lblRsz" Width="150px" Text="Estimated Value :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtWOValue" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                            FilterMode="validChars" FilterType="Custom" TargetControlID="txtWOValue" ValidChars=".0123456789">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblWOProbability" runat="server" SkinID="lbl" Text="Probability :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtWOProbability" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                            FilterMode="validChars" FilterType="Custom" TargetControlID="txtWOProbability"
                                                            ValidChars=".0123456789">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td align="center" colspan="4">
                                                        <asp:Button ID="btnWOupdate" runat="server" CommandName="Insert" CssClass="ButtonClass"
                                                            SkinID="btn" TabIndex="5" Text="UPDATE" OnClientClick="return ValidateWO();" />
                                                        &nbsp;
                                                        <asp:Button ID="btnWOview" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="6"
                                                            Text="VIEW" />
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:UpdateProgress runat="server" ID="UpdateProgress5">
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
                                                    <td colspan="4">
                                                        <asp:Label ID="lblWOErrosmsg" runat="server" SkinID="lblRed"></asp:Label>
                                                        &nbsp;
                                                        <asp:Label ID="lblWOmsginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align ="center" >
                                                        <asp:Panel ID="panel5" runat="server" ScrollBars="Auto" Height="300px" Width ="750">
                                                            <asp:GridView ID="GVWorkOrder" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                SkinID="GridView" ForeColor="Black" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Lead" SortExpression="LeadName" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblWOLeadName" runat="server" Text='<%# Bind("LeadName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblWOStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Work Order Value" SortExpression="EstimatedValue" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("EstimatedValue","{0:n2}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Probability" SortExpression="Probability" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Probability") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <%--<PagerStyle HorizontalAlign="Center" />--%>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="PIPELINE" runat="server" HeaderText="PIPELINE">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                                <ContentTemplate>
                                    <center>
                                        <h3 class="headingTxt">
                                            PIPELINE
                                        </h3>
                                    </center>
                                    <center>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Label ID="lblPLErrormsg" runat="server" SkinID="lblRed"></asp:Label>
                                                        &nbsp;
                                                        <asp:Label ID="lblPLmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <asp:Panel ID="panel6" runat="server" ScrollBars="Auto" Width ="750" Height ="300">
                                                            <asp:GridView ID="GVPipeline" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                SkinID="GridView" ForeColor="Black" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Lead" SortExpression="LeadName" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPLLeadName" runat="server" Text='<%# Bind("LeadName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name" SortExpression="Emp_Name" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPLEmpname" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Work Order Value" HeaderStyle-HorizontalAlign="Center" >
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPLEstimatedvalue" runat="server" Text='<%# Bind("EstimatedValue","{0:n2}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign ="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Probability" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPLProbability" runat="server" Text='<%# Bind("Probability") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign ="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Forecast" HeaderStyle-HorizontalAlign="Center" >
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPLProbability" runat="server" Text='<%# Bind("forecast") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign ="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPLStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPLRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTotEstValue" runat="server" Text='<%# Bind("TotEstValue") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                                <%--<PagerStyle HorizontalAlign="Center" />--%>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </center>
                                    <center>
                                        <table>
                                            <tr align="left">
                                                <td align="left">
                                                    <asp:Label runat="server" ID="lblTotcount" SkinID="lblRsz" Text="Total Count : "
                                                        Width="100"></asp:Label>
                                                    <asp:Label runat="server" ID="lblcount" SkinID="lblRsz" Width="20"></asp:Label>
                                                </td>
                                                <%-- <td align="left">
                                                  
                                                </td>--%>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:UpdateProgress runat="server" ID="UpdateProgress6">
                                                        <ProgressTemplate>
                                                            <div class="PleaseWait">
                                                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td align="left">
                                                    <asp:Label runat="server" ID="lblTotSum" SkinID="lblRsz" Width="100" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sum : "></asp:Label>
                                                    <asp:Label runat="server" ID="lblSum" SkinID="lbl"></asp:Label>
                                                </td>
                                                <%--   <td align="left">
                                                   
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="ALERTS" runat="server" HeaderText="ALERTS">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                <ContentTemplate>
                                    <center>
                                        <h3 class="headingTxt">
                                            ALERTS
                                        </h3>
                                    </center>
                                    <center>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtFromDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True"
                                                            Format="dd-MMM-yyyy" TargetControlID="txtFromDate">
                                                        </ajaxToolkit:CalendarExtender>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblToDate" runat="server" SkinID="lbl" Text="To Date :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True"
                                                            Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                                                        </ajaxToolkit:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:Button ID="btnShow" SkinID="btn" CssClass="ButtonClass" TabIndex="3" Text="SHOW"
                                                            runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:UpdateProgress runat="server" ID="UpdateProgress7">
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
                                                    <td colspan="4" align="center">
                                                        <asp:Label ID="lblAlertError" runat="server" SkinID="lblRed"></asp:Label>
                                                        <asp:Label ID="lblAlertCorrect" runat="server" SkinID="lblGreen"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Panel ID="panel4" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                                            <asp:GridView ID="GVAlerts" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Prospect Id" HeaderStyle-HorizontalAlign="Center" SortExpression="PropectId">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPropectId" runat="server" Text='<%# Bind("PropectId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Lead Name" HeaderStyle-HorizontalAlign="Center" SortExpression="LeadName">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblLeadName" runat="server" Text='<%# Bind("LeadName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Estimated Value" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEstimatedValue" runat="server" Text='<%# Bind("EstimatedValue","{0:n2}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Appointment Date" SortExpression="AppointmentDate">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# Bind("AppointmentDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                        <HeaderStyle HorizontalAlign ="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Appointment Time" HeaderStyle-HorizontalAlign="Center" >
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAppointmantTime" runat="server" Text='<%# Bind("AppointmantTime") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Close" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnClose" TabIndex="4" runat="server" CausesValidation="False"
                                                                                CommandName="Delete" OnClientClick="return confirm('Do you want to close this Alert?')"
                                                                                Text="<u>Close</u>" />
                                                                            <asp:Label ID="lblLead_ID" Visible="false" runat="server" Text='<%# Bind("Lead_ID") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image6" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
