<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPlacementDetails.aspx.vb"
    Inherits="frmPlacementDetails" Title="Placement Details" ValidateRequest="false" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Placement Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;
            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtStdCode.ClientID %>"), 'Student Code');
            if (msg != "") {
                document.getElementById("<%=txtStdCode.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlcompname.ClientID %>"), 'Company Name');
            if (msg != "") {
                document.getElementById("<%=ddlcompname.ClientID %>").focus();
                return msg;
            }


            msg = ValidateDateN(document.getElementById("<%=txtSdate.ClientID %>"), 'Start Date');
            if (msg != "") {
                document.getElementById("<%=txtSdate.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtEnddate.ClientID %>"), 'End Date');
            if (msg != "") {
                document.getElementById("<%=txtEnddate.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtplacementdate.ClientID %>"), 'Placement Date');
            if (msg != "") {
                document.getElementById("<%=txtplacementdate.ClientID %>").focus();
                return msg;
            }


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

    <script type="text/javascript" language="javascript">

        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
        }
//        function SplitName() {
//            var text = document.getElementById("<%=txtStdCode.ClientID%>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=txtStdCode.ClientID%>").innerText = split[0];
//                document.getElementById("<%=txtName.ClientID%>").innerText = split[1];
//                document.getElementById("<%=HidstdId.ClientID%>").innerText = split[2];

//            }
//        }
        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtfaculty.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtfaculty.ClientID%>"));
        }
//        function SplitName1() {
//            var text = document.getElementById("<%=txtfaculty.ClientID%>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=txtfaculty.ClientID%>").innerText = split[0];
//                document.getElementById("<%=txtfaculty.ClientID%>").innerText = split[1];
//                document.getElementById("<%=HidFaculty.ClientID%>").innerText = split[2];

//            }
//        }
        
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image3" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <%--   <center>
                    <h1 class="headingTxt">
                        PLACEMENT / TRAINING DETAILS
                    </h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:RadioButtonList ID="RbPlacement" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                    SkinID="Themes1" TabIndex="1">
                                    <asp:ListItem Selected="True" Text="Placement"></asp:ListItem>
                                    <asp:ListItem Text="Training"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:HiddenField ID="HidstdId" runat="server" />
                                <asp:Label ID="lblstdcode" runat="server" EnableTheming="True" SkinID="lbl" Text="Student Code*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStdCode" runat="server" SkinID="txt" AutoPostBack="True" TabIndex="2">
                                </asp:TextBox><ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server"
                                    TargetControlID="txtStdCode" ServicePath="TextBoxExt.asmx" ServiceMethod="getStudentIdName"
                                    OnClientPopulating="ShowImage" OnClientPopulated="HideImage" MinimumPrefixLength="3"
                                    CompletionInterval="2000" FirstRowSelected="true"
                                    CompletionListCssClass="completeListStyle" EnableCaching="true">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" WatermarkText="Type first 3 characters"
                                    runat="server" TargetControlID="txtStdCode" SkinID="watermark">
                                </ajaxToolkit:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblname1" runat="server" SkinID="lbl" Text="Student Name&nbsp;:&nbsp;&nbsp;"> </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" SkinID="txt" AutoCompleteType="Disabled"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcompany" runat="server" SkinID="lblrsz" Width="200px" Text="Company Name*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlcompname" runat="server" AppendDataBoundItems="true" DataSourceID="ObjectDataSource3"
                                    TabIndex="3" DataTextField="PCName" DataValueField="PCId_Auto" SkinID="ddl">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetcompanyCombo"
                                    TypeName="PlacementDB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblsalary" runat="server" SkinID="lbl" Text="Salary(P.A)&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSalary" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="4">0.00</asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterMode="validChars" TargetControlID="txtSalary" ValidChars="0123456789.,">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstipend" runat="server" SkinID="lbl" Text="Stipend(P.A)&nbsp;:&nbsp;&nbsp;"
                                    Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtstipend" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="5" Visible="False">0.00</asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="validChars" TargetControlID="txtstipend" ValidChars="0123456789.,">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbldate" runat="server" SkinID="lblRsz" Text="Placement Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtplacementdate" runat="server" MaxLength="11" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSdate" runat="server" SkinID="lbl" Text="Start Date*&nbsp;:&nbsp;&nbsp;"
                                    Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSdate" runat="server" MaxLength="11" AutoCompleteType="Disabled"
                                    SkinID="txt" TabIndex="7" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblenddate" runat="server" SkinID="lbl" Text="End Date*&nbsp;:&nbsp;&nbsp;"
                                    Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEnddate" runat="server" MaxLength="11" AutoCompleteType="Disabled"
                                    SkinID="txt" TabIndex="8" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbldesignation" runat="server" SkinID="lbl" Text="Designation&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesignation" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="9"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:HiddenField ID="HidFaculty" runat="server" />
                                <asp:Label ID="lblfaculty" runat="server" SkinID="lblRsz" Text="Faculty Incharge&nbsp;:&nbsp;&nbsp;"
                                    Visible="False" Width="180px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfaculty" runat="server" SkinID="txt" Visible="false" TabIndex="10"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" TargetControlID="txtfaculty"
                                    ServicePath="TextBoxExt.asmx" ServiceMethod="getEmpCodeExt1" OnClientPopulating="ShowImage1"
                                    OnClientPopulated="HideImage1" MinimumPrefixLength="3" CompletionInterval="2000"
                                    FirstRowSelected="true" CompletionListCssClass="completeListStyle"
                                    EnableCaching="true">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" WatermarkText="Type first 3 characters"
                                    runat="server" TargetControlID="txtfaculty" SkinID="watermark">
                                </ajaxToolkit:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcontactperson" runat="server" SkinID="lbl" Text="Contact Person&nbsp;:&nbsp;&nbsp;"
                                    Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcontactperson" runat="server" SkinID="txt" Visible="false" TabIndex="11"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblremarks" runat="server" SkinID="lbl" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtremarks" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                    SkinID="btn" TabIndex="13" Text="ADD" Width="100px" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="14" Text="VIEW" />
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
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
                <center>
                    <table>
                        <tr>
                            <td>
                                <br />
                                <center>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" DataKeyNames="Placement_ID" Visible="False" PageSize="100"
                                        AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnedit" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" TabIndex="15"></asp:LinkButton>
                                                    <asp:LinkButton ID="btndelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                        Text="Delete" TabIndex="16" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hidplacement" runat="server" Value='<%# Bind("Placement_ID") %>' />
                                                    <asp:HiddenField ID="HidstdId" runat="server" Value='<%# Bind("STD_ID") %>' />
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Company Name" SortExpression="PCName">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="Hidcomp" runat="server" Value='<%# Bind("PCId_Auto") %>'></asp:HiddenField>
                                                    <asp:Label ID="Lblcomp" runat="server" Text='<%# Bind("PCName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Salary/Stipend(P.A)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsalary" runat="server" Text='<%# Bind("Salary","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Placement Date" SortExpression="Date_Of_Placement">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Date_Of_Placement","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblstartdate" runat="server" Text='<%# Bind("Date_Of_Placement","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblenddate" runat="server" Text='<%# Bind("End_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldesignation" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Faculty Incharge">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFacultyID" runat="server" Visible="false" Text='<%# Bind("Faculty_Incharge") %>'></asp:Label>
                                                    <asp:Label ID="lblfacultyincharge" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Person">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcontactperson" runat="server" Text='<%# Bind("Contact_Person") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 74px">
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtplacementdate">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtSdate">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtEnddate">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    TargetControlID="txtremarks" FilterType="Numbers" FilterMode="InvalidChars" InvalidChars="#+_=/*()'@[]{}?><&^%$!~`;:\|1234567890">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <br />
                            </td>
                        </tr>
                    </table>
                    &nbsp;</center>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </a>
            </div>
            <style type="text/css">
                .completeListStyle
                {
                    height: 100px;
                    width: 50px;
                    overflow: auto;
                    list-style-type: disc;
                    padding-left: 17px;
                    background-color: #FFF;
                    border: 1px solid DarkGray;
                    text-align: left;
                    font-size: small;
                    color: black;
                }
            </style>
        </ContentTemplate>
        <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnDetails" EventName="Click"></asp:AsyncPostBackTrigger>
        </Triggers>--%>
    </asp:UpdatePanel>

</form>
</body>
</html>
