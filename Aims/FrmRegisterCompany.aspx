<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRegisterCompany.aspx.vb"
    Inherits="FrmRegisterCompany" Title="Company Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Company Register</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">


        function Valid() {
            var msg;

            msg = NameField100(document.getElementById("<%=txtCompanyRName.ClientID %>"), 'Company Name');
            if (msg != "") {
                document.getElementById("<%=txtCompanyRName.ClientID %>").focus();
                return msg;
            }

            msg = CodeField(document.getElementById("<%=txtCompanyRCode.ClientID %>"), 'Company Code');
            if (msg != "") {
                document.getElementById("<%=txtCompanyRCode.ClientID %>").focus();
                return msg;
            }
            msg = Field50(document.getElementById("<%=txtRLocation.ClientID %>"), 'Location');
            if (msg != "") {
                document.getElementById("<%=txtRLocation.ClientID %>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txtRPostalCode.ClientID %>"), 'Postal Code');
            if (msg != "") {
                document.getElementById("<%=txtRPostalCode.ClientID %>").focus();
                return msg;
            }
            msg = YearPostalN(document.getElementById("<%=txtRPostalCode.ClientID %>"), 'Postal Code');
            if (msg != "") {
                document.getElementById("<%=txtRPostalCode.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlState.ClientID %>"), 'State');
            if (msg != "") {
                document.getElementById("<%=ddlState.ClientID %>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txtRNOOfEmployee.ClientID%>"), 'No Of Employee');
            if (msg != "") {
                document.getElementById("<%=txtRNOOfEmployee.ClientID%>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txtRNOOfFreshers.ClientID%>"), 'No Of Fresher');
            if (msg != "") {
                document.getElementById("<%=txtRNOOfFreshers.ClientID%>").focus();
                return msg;

            }
            msg = valcontactN(document.getElementById("<%=txtLandline.ClientID%>"), 'Land Line Number');
            if (msg != "") {
                document.getElementById("<%=txtLandline.ClientID%>").focus();
                return msg;

            }
            msg = valcontactN(document.getElementById("<%=txtMobile.ClientID%>"), 'Mobile Number');
            if (msg != "") {
                document.getElementById("<%=txtMobile.ClientID%>").focus();
                return msg;

            }

            return true;
        }

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        

     
    </script>

    <script language="javascript" type="text/javascript">
        function Valid1() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=DdlKDMCName.ClientID %>"), 'Company Name');
            if (msg != "") {
                document.getElementById("<%=DdlKDMCName.ClientID%>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtKDMName.ClientID %>"), 'Name');
            if (msg != "") {
                document.getElementById("<%=txtKDMName.ClientID%>").focus();
                return msg;
            }
            msg = valcontactN(document.getElementById("<%=txtKDMLandline.ClientID%>"), 'Land Line Number');
            if (msg != "") {
                document.getElementById("<%=txtKDMLandline.ClientID%>").focus();
                return msg;

            }
            msg = valcontactN(document.getElementById("<%=txtKDMMobile.ClientID%>"), 'Mobile Number');
            if (msg != "") {
                document.getElementById("<%=txtKDMMobile.ClientID%>").focus();
                return msg;

            }


            return true;
        }
        function Validate1() {

            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=Lblkdmerr.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblkdmmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=Lblkdmerr.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblkdmmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }

    </script>

    <script type="text/javascript" language="javascript">
        function Valid3() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlScompanyName.ClientID%>"), 'Company Name');
            if (msg != "") {
                document.getElementById("<%=ddlScompanyName.ClientID%>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txtSGross.ClientID%>"), 'Gross');
            if (msg != "") {
                document.getElementById("<%= txtSGross.ClientID %>").focus();
                return msg;
            }
            msg = numeric(document.getElementById("<%=txtSCTC.ClientID%>"), 'CTC');
            if (msg != "") {
                document.getElementById("<%= txtSCTC.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate3() {
            var msg = Valid3();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblSerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblSmsgifo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblSerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblSmsgifo.ClientID %>").innerText = "";
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
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp"
                BackColor="#E2E3BB">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="REGISTER COMPANY"
                    TabIndex="1">
                    <ContentTemplate>
                        <center>
                            <center>
                                <%--  <h1 class="headingTxt">
                                    REGISTER COMPANY
                                </h1>--%>
                                <h1 class="headingTxt">
                                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                                </h1>
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCompanyRName" runat="server" Text="Company Name*^&nbsp:&nbsp&nbsp"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCompanyRName" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCompanyRCode" runat="server" Text="Company Code*^&nbsp:&nbsp;&nbsp;"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCompanyRCode" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;<asp:Label ID="lblRAddress" runat="server" Text="Address&nbsp:&nbsp&nbsp" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRAddress" runat="server" SkinID="txt" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRLocation" runat="server" Text="Location*^&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRLocation" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRPostalCode" runat="server" Text="Postal Code&nbsp:&nbsp&nbsp;"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td style="width: 83px">
                                            <asp:TextBox ID="txtRPostalCode" runat="server" SkinID="txt" MaxLength="6"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRDistrict" runat="server" Text="District&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRDistrict" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="LblCompanyState" runat="server" Text="State*&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="True" DataSourceID="ObjState"
                                                DataTextField="StateName" DataValueField="StateId" SkinID="ddl">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjState" runat="server" SelectMethod="GetState" TypeName="EnquiryManager">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="0" Name="StateId" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRwebdetails" runat="server" Text="Web Details&nbsp:&nbsp&nbsp;"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtwebdetails" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRCompanyActivities" runat="server" Text="Company Activities&nbsp:&nbsp&nbsp;"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRCompanyActivities" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRNOOfEmployee" runat="server" Text="No. Of Employee&nbsp:&nbsp&nbsp;"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRNOOfEmployee" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRNOOfFreshers" runat="server" Text="No. Of Freshers&nbsp:&nbsp&nbsp;"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRNOOfFreshers" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <b>CEO Of Org</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblNameofceo" runat="server" Text="Name&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNameofceo" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblceoemail" runat="server" Text="Email&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtceoemail" runat="server" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbllandline" runat="server" Text="Land Line&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLandline" runat="server" SkinID="txt" MaxLength="15"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblmobile" runat="server" Text="Mobile&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtmobile" runat="server" SkinID="txt" MaxLength="15"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <center>
                                    <table>
                                        <tr>
                                            <td class="btnTd" colspan="2">
                                                <asp:Button ID="InsertCompanyRegister" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                                    SkinID="btn" Text="ADD" ValidationGroup="ADD" />
                                                &nbsp;<asp:Button ID="ViewCompanyRegister" runat="server" CausesValidation="False"
                                                    CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                                            </td>
                                        </tr>
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
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GvCompanyRegister" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                        Visible="False" AllowPaging="True" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" Visible="false"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="center" />
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Company Name" SortExpression="Company Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="CompanyRegID" runat="server" Value='<%# Bind("RCID") %>' Visible="false" />
                                                    <asp:Label ID="lblCompanyRegName" runat="server" Text='<%# Bind("CompanyName") %>'
                                                        Visible="true"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Company Code" SortExpression="Company Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegCode" runat="server" Text='<%# Bind("CompanyCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address" SortExpression="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location" SortExpression="Location">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegLocation" runat="server" Text='<%# Bind("Location") %>'
                                                        Visible="true"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Postal Code" SortExpression="Postal Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegPCode" runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="District" SortExpression="District">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbCompanyRegDistrict" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State" SortExpression="State">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegState" Visible="false" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                                    <asp:Label ID="lblCompanyRegState1" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Web Details" SortExpression="Web Details">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWebDetails" runat="server" Text='<%# Bind("WebsiteDetails") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Company Activities" SortExpression="Company Activities">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegActivities" runat="server" Text='<%# Bind("CompanyActivities") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No. Of Employee" SortExpression="No.Of Employee">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegNoOfEmployee" runat="server" Text='<%# Bind("NoofEmployees") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No. Of Fresher/Month" SortExpression="No. Of Fresher/Month">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegNoOfFresher" runat="server" Text='<%# Bind("NoofFresher") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name Of CEO" SortExpression="Name Of CEO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNameOfCEO" runat="server" Text='<%# Bind("CEOName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegEmail" runat="server" Text='<%# Bind("CEOEmail") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Land Line" SortExpression="Land Line">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegLandline" runat="server" Text='<%# Bind("CEOLandLine") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile" SortExpression="Mobile">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRegMobile" runat="server" Text='<%# Bind("CEOMobile") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:LinkButton ID="link23" runat="server"></asp:LinkButton>
                            </center>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="KEY DECISION MAKER"
                    TabIndex="2">
                    <ContentTemplate>
                        <center>
                            <div class="mainBlock">
                                <center>
                                    <h1 class="headingTxt">
                                        KEY DECISION MAKER
                                    </h1>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="LblKDMCompanyName" runat="server" Text="Company Name*&nbsp:&nbsp&nbsp;"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DdlKDMCName" runat="server" AppendDataBoundItems="True" DataSourceID="ObjKDMComapnayName"
                                                    DataTextField="CompanyName" SkinID="ddl">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjKDMComapnayName" runat="server" SelectMethod="GetMKDcompanyName"
                                                    TypeName="DLCompanyRegister"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblKDMName" runat="server" Text="Name*&nbsp:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKDMName" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                &nbsp;<asp:Label ID="lblKDMDeignation" runat="server" Text="Designation&nbsp:&nbsp&nbsp"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKDMDeignation" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblKDMLandline" runat="server" Text="Landline&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKDMLandline" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblKDMMobile" runat="server" Text="Mobile&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td style="width: 83px">
                                                <asp:TextBox ID="txtKDMMobile" runat="server" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblKDMEmail" runat="server" Text="Email&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKDMEmail" runat="server" SkinID="txt"></asp:TextBox>
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
                                            <td width="400px" align="right">
                                                <asp:Button ID="InsertMKD" runat="server" CssClass="ButtonClass" OnClientClick="return Validate1();"
                                                    SkinID="btn" Text="ADD" ValidationGroup="ADD" />
                                                &nbsp;<asp:Button ID="ViewMKD" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                    SkinID="btn" Text="VIEW" />
                                            </td>
                                            <td align="left">
                                                <asp:BulletedList ID="BulletedList1" runat="server" Width="200px">
                                                    <asp:ListItem>Note : To Enter Multiple Details Use Commas in every Field.</asp:ListItem>
                                                </asp:BulletedList>
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
                                            <td colspan="2" align="center">
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
                                            <td>
                                                <asp:Label ID="lblkdmmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                                <asp:Label ID="Lblkdmerr" runat="server" SkinID="lblRed"></asp:Label>
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
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                        <asp:GridView ID="GvKDM" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                            Visible="False" AllowPaging="True" PageSize="100">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="KDMEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                        <asp:LinkButton ID="KDMDELETE" runat="server" CausesValidation="False" CommandName="Delete"
                                                            Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Company Name" SortExpression="Company Name">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="KDMID" runat="server" Value='<%# Bind("RCID") %>' Visible="false" />
                                                        <asp:HiddenField ID="HKDM1" runat="server" Value='<%# Bind("RCIDAuto") %>' Visible="false" />
                                                        <asp:Label ID="lblKDMCName" runat="server" Text='<%# Bind("CompanyName") %>' Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKDMName" runat="server" Text='<%# Bind("KeyDecisionName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKDMDesignation" runat="server" Text='<%# Bind("KeyDecisionDesignation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LandLine" SortExpression="LandLine">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKDMLandLine" runat="server" Text='<%# Bind("KeyDecisionLandLine") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mobile" SortExpression="Mobile">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKDMMobile" runat="server" Text='<%# Bind("KeyDecisionMobile") %>'
                                                            Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblKDMEmail" runat="server" Text='<%# Bind("KeyDecisionEmail") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                    <asp:LinkButton ID="Link22" runat="server"></asp:LinkButton>
                                </center>
                            </div>
                        </center>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="ENTRY LEVEL SALARY STRUCTURE"
                    TabIndex="3">
                    <ContentTemplate>
                        <center>
                            <center>
                                <h1 class="headingTxt">
                                    ENTRY LEVEL SALARY STRUCTURE
                                    <br />
                                    <br />
                                </h1>
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblSCompanyName" runat="server" Text="Company Name*&nbsp:&nbsp&nbsp;"
                                                SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlScompanyName" runat="server" AppendDataBoundItems="True"
                                                DataSourceID="ObjSComapnayName" DataTextField="CompanyName" SkinID="ddl">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjSComapnayName" runat="server" SelectMethod="GetMKDcompanyName"
                                                TypeName="DLCompanyRegister"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblSGross" runat="server" ForeColor="#000066" SkinID="lblRsz" Text="Gross*&nbsp;:&nbsp;&nbsp; "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSGross" SkinID="txt" runat="server" MaxLength="15"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtSGross">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblSCTC" runat="server" ForeColor="#000066" SkinID="lblRsz" Text="CTC&nbsp;:&nbsp;&nbsp; "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSCTC" runat="server" SkinID="txt" MaxLength="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <b>Benefits</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="LblMedical" runat="server" Text="Medical Insurance&nbsp;:&nbsp;&nbsp;"
                                                SkinID="lblRsz" Width="150"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="ChkMedical" runat="server" SkinID="ChkRsz" Width="50" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label1" runat="server" Text="LTA&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="150"></asp:Label>
                                            <%--<asp:Label ID="lblInsurance" runat="server" Text="Insurance&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="150"></asp:Label>--%>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="ChkLTA" runat="server" SkinID="ChkRsz" Width="50" />
                                            <%--<asp:CheckBox ID="ChkInsurance" runat="server" SkinID="ChkRsz" Width="50" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblPF" runat="server" Text="PF&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="150"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="ChkPf" runat="server" SkinID="ChkRsz" Width="50" />
                                        </td>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Other Facilities </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblSubscribedFood" runat="server" Text="Subscribed Food&nbsp;:&nbsp;&nbsp;"
                                                SkinID="lblRsz" Width="150"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="ChkSubscribedFood" runat="server" SkinID="ChkRsz" Width="50" />
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTransport" runat="server" Text="Transport &nbsp;:&nbsp;&nbsp;"
                                                SkinID="lblRsz" Width="150"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="ChkTransport" runat="server" SkinID="ChkRsz" Width="50" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="LblAssistance" runat="server" Text="Assistance in Accomodation&nbsp;:&nbsp;&nbsp;"
                                                SkinID="lblRsz" Width="250"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="ChkAssistance" runat="server" SkinID="ChkRsz" Width="50" />
                                        </td>
                                        <%-- <td align="right">
                                        &nbsp;
                                            <asp:Label ID="lblAccomodation" runat="server" Text="Accomodation &nbsp;:&nbsp;&nbsp;"
                                                SkinID="lblRsz" Width="200"></asp:Label>
                                        </td>
                                        <td align="left">
                                        &nbsp;
                                          <asp:CheckBox ID="ChkAccomodation" runat="server" SkinID="ChkRsz" Width="50" />
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td class="btnTd" colspan="2" align="center">
                                            <asp:Button ID="InsertSalaryStrcure" runat="server" CausesValidation="true" Text="ADD"
                                                CssClass="ButtonClass" OnClientClick="return Validate3();" SkinID="btn" />
                                            <asp:Button ID="ViewSalaryStrcure" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                Text="VIEW" SkinID="btn" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td colspan="2" align="center">
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
                                        <td>
                                            <asp:Label ID="lblSerrmsg" SkinID="lblRed" runat="server" />
                                            <asp:Label ID="lblSmsgifo" SkinID="lblGreen" runat="server" />
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
                                <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GVSalaryStructure" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Width="300px" align="center">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:LinkButton ID="LkSalaryStructureEdit" runat="server" TabIndex="6" CausesValidation="False"
                                                            CommandName="Edit" Text="Edit" />
                                                        <asp:LinkButton ID="LkSalaryStructureDelete" runat="server" TabIndex="7" CausesValidation="False"
                                                            CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete" />
                                                    </center>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Company Name" Visible="true">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="SSID" runat="server" Value='<%# Bind("RCID") %>' Visible="false" />
                                                    <asp:Label ID="lblSCompanyName" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gross">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSGross" runat="server" Text='<%# Bind("SalaryStructureGross","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CTC">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSCTC" runat="server" Text='<%# Bind("KeyDecisionCTC","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Medical Insurance">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMedical" runat="server" Text='<%# Bind("Medical") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign ="Center" />
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Insurance">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInsurance" runat="server" Text='<%# Bind("Insurance") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="PF">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPF" runat="server" Text='<%# Bind("PF") %>'></asp:Label>
                                                </ItemTemplate>
                                                 <ItemStyle HorizontalAlign ="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LTA">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLTA" runat="server" Text='<%# Bind("LTA") %>'></asp:Label>
                                                </ItemTemplate>
                                                 <ItemStyle HorizontalAlign ="Center" />
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Subscribed Food">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubscribedFood" runat="server" Text='<%# Bind("SubscribedFood") %>'></asp:Label>
                                                </ItemTemplate>
                                                 <ItemStyle HorizontalAlign ="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transport">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTransport" runat="server" Text='<%# Bind("Transport") %>'></asp:Label>
                                                </ItemTemplate>
                                                 <ItemStyle HorizontalAlign ="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assistance in Accomodation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAssistance" runat="server" Text='<%# Bind("Assistance") %>'></asp:Label>
                                                </ItemTemplate>
                                                 <ItemStyle HorizontalAlign ="Center" />
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Accomodation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAccommodation"  runat="server" Text='<%# Bind("Accomodation") %>' visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:LinkButton ID="Link21" runat="server"></asp:LinkButton>
                            </center>
                        </center>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

