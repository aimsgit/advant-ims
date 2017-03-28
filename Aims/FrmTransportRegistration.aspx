<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmTransportRegistration.aspx.vb"
    Inherits="FrmTransportRegistration" Title="Transport Registration" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vehicle Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlacadyear.ClientID %>"), 'Academic Year');
            document.getElementById("<%=ddlacadyear.ClientID%>").focus();
            if (msg != "") return msg;
            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtStdCode.ClientID %>"), 'Student Code');
            document.getElementById("<%=txtStdCode.ClientID%>").focus();
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=DdlRouteName.ClientID %>"), 'Route Name');
            document.getElementById("<%=DdlRouteName.ClientID%>").focus();
            if (msg != "") return msg;
            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtEmpCode.ClientID %>"), 'Employee Code');
            document.getElementById("<%=txtEmpCode.ClientID%>").focus();
            if (msg != "") return msg;
            msg = Field255N(document.getElementById("<%=txtRemarks.ClientID %>"), 'Remarks');
            document.getElementById("<%=txtRemarks.ClientID%>").focus();
            if (msg != "") return msg;

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



        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
        }
//        function SplitName1() {
//            var text = document.getElementById("<%=txtStdCode.ClientID%>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=txtStdCode.ClientID%>").innerText = split[0];
//                document.getElementById("<%=txtStdName.ClientID%>").innerText = split[1];
//                document.getElementById("<%=HidstdId.ClientID%>").innerText = split[2];
//            }
//        }
        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtEmpCode.ClientID%>"));
        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtEmpCode.ClientID%>"));
        }
//        function SplitName2() {
//            var text = document.getElementById("<%=txtEmpCode.ClientID %>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=txtEmpCode.ClientID%>").innerText = split[0];
//                document.getElementById("<%=txtEmpName.ClientID%>").innerText = split[1];
//                document.getElementById("<%=HidEmp.ClientID%>").innerText = split[2];
//            }
//        }

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
                    <%--   <center>
                        <h1 class="headingTxt">
                            TRANSPORT REGISTRATION
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
                        <table>
                            <tr>
                                <td colspan="2" align="Right">
                                    <asp:RadioButtonList ID="RBUsers" runat="server" SkinID="RD" AutoPostBack="True"
                                        RepeatDirection="Horizontal" TabIndex="1">
                                        <asp:ListItem Value="Student" Selected="True">Student</asp:ListItem>
                                        <asp:ListItem Value="Employee">Employee</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Calendar Year*^ :&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlacadyear" TabIndex="2" runat="server" SkinID="ddl" AutoPostBack="True"
                                        DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStdCode" runat="server" SkinID="lblRsz" Text="Student Code*^ :&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStdCode" SkinID="txt" runat="server" TabIndex="3"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtStdCode">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" CompletionInterval="2000"
                                        EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage1"
                                        OnClientPopulating="ShowImage1" ServiceMethod="getStudentIdName1"
                                        CompletionListCssClass="completeListStyle" ServicePath="TextBoxExt.asmx" TargetControlID="txtStdCode">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                        SkinID="watermark" TargetControlID="txtStdCode" WatermarkText="Type first 3 characters">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStdName" runat="server" SkinID="lblRsz" Text="Student Name^ :&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStdName" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                        Enabled="false"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtStdName">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmpCode" Visible="False" runat="server" SkinID="lblRsz" Text="Employee Code*^ :&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpCode" Visible="false" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtEmpCode">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="Server" CompletionInterval="2000"
                                        EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage2"
                                        OnClientPopulating="ShowImage2" ServiceMethod="getEmpCodeExt1"
                                        CompletionListCssClass="completeListStyle" ServicePath="TextBoxExt.asmx" TargetControlID="txtEmpCode">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                                        SkinID="watermark" TargetControlID="txtEmpCode" WatermarkText="Type first 3 characters">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmpName" Visible="False" runat="server" SkinID="lblRsz" Text="Employee Name^ :&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpName" Visible="false" SkinID="txt" runat="server"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtEmpName">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRouteName" runat="server" Text="Route Name*^ :&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DdlRouteName" runat="server" SkinID="ddl" AutoPostBack="true"
                                        DataSourceID="ObjRouteName" DataValueField="RouteIDAuto" DataTextField="RouteName"
                                        TabIndex="5">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblRouteNumber" runat="server" SkinID="lblRsz" Text="Route Number &nbsp;&nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtRouteNumber" runat="server" MaxLength="50" SkinID="txt"></asp:TextBox>
                                </td>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblPickupPoint" runat="server" SkinID="lblRsz" Text="Pick Up Point* :&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlPickupPoint" runat="server" AutoPostBack="True" TabIndex="6"
                                            SkinID="ddl">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblVehicleNumber" runat="server" SkinID="lblRsz" Text="Vehicle Number :&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtVehicleNumber" runat="server" MaxLength="50" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                                </td>
                            </tr>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblpickuptime" runat="server" SkinID="lblRsz" Text="Pick Up time :&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPickuptime" runat="server" MaxLength="50" SkinID="txt" TabIndex="7"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                                        AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                        Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtPickuptime" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRegistration" runat="server" Text="Registration Date :&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtRegistration" runat="server" SkinID="txt" MaxLength="50" TabIndex="8"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtRegistration"
                                        Format="dd-MMM-yyyy" SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks :&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TabIndex="9" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td class="btnTd">
                                    <asp:Button ID="BtnSave" runat="server" TabIndex="10" Text="ADD" SkinID="btn" CausesValidation="True"
                                        OnClientClick="return Validate();" CssClass="ButtonClass" />
                                    <asp:Button ID="BtnDetails" runat="server" Text="VIEW" CausesValidation="False" TabIndex="11"
                                        SkinID="btn" CssClass="ButtonClass" />
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
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        </div>
                                        </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                            <asp:GridView ID="GVTransport" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                DataKeyNames="TRNO" SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                Text="Edit" SkinID="btn"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" SkinID="btn" CausesValidation="False"
                                                                CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete" Font-Underline="False"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Academic Year" SortExpression="AcademicYear">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="lblTranid" Visible="false" runat="server" Value='<%# Bind("TRNO") %>'>
                                                            </asp:HiddenField>
                                                            <asp:Label ID="Label1" runat="server" Visible="false" Text='<%# Bind("TRNO_Auto") %>'></asp:Label>
                                                            <asp:Label ID="lblAyear" Visible="false" runat="server" Text='<%# Bind("A_Code") %>'></asp:Label>
                                                            <asp:Label ID="lblAcademicYear" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                        <ItemTemplate>
                                                            <%--  <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Bind("ID")%>'></asp:Label>--%>
                                                            <asp:HiddenField ID="StdHidden" runat="server" Value='<%#Bind("STD_ID") %>' />
                                                            <asp:Label ID="lblStdcode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                                        <ItemTemplate>
                                                            <%--    <asp:Label ID="lblIDEmp" runat="server" Visible="false" Text='<%# Bind("ID")%>'></asp:Label>--%>
                                                            <asp:HiddenField ID="EmpIdHidden" runat="server" Value='<%#Bind("EmpID") %>' />
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Route Name" SortExpression="RouteName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRoutName" Visible="false" runat="server" Text='<%# Bind("RouteIDAuto") %>'></asp:Label>
                                                            <asp:Label ID="lblRouteName" runat="server" Text='<%# Bind("RouteName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Route Number" SortExpression="RouteNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblroutenumber" runat="server" Text='<%# Bind("RouteNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pickup Point">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPickupPoint" runat="server" Text='<%# Bind("PickUpPoint") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pickup Time">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPickuptime" runat="server" Text='<%# Bind("PickUpTime", "{0:hh:mm tt}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Registration Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRegdate" runat="server" Text='<%# Bind("RegistrationDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRemarks" runat="server" Width="250" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Vehicle NO" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblvehicleNo" runat="server" Text='<%# Bind("VehicleRegnNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="HidEmp" runat="server" />
                                            <asp:HiddenField ID="HidTRN" runat="server" />
                                            <asp:HiddenField ID="HidstdId" runat="server" />
                                        </td>
                                    </tr>
                                    <asp:ObjectDataSource ID="ObjPickupPoint" runat="server" SelectMethod="GetPickuppointcombo"
                                        TypeName="DLTransportReg">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DdlRouteName" Name="RouteIDAuto" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjRouteName" runat="server" SelectMethod="GetRouteNamecombo"
                                        TypeName="DLTransportReg"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                        TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </center>
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
