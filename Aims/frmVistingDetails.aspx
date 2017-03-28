<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmVistingDetails.aspx.vb"
    Inherits="fmVistingDetails" Title="Visiting Details" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Visiting Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtEmp.ClientID%>"));

        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtEmp.ClientID%>"));
        }

        function Valid() {
            var msg;
            msg = AutoCompleteExtender(document.getElementById("<%=txtEmp.ClientID %>"), 'Employee Code');
            if (msg != "") {
                document.getElementById("<%=txtEmp.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtName.ClientID %>"), 'Employee Name');
            if (msg != "") {
                document.getElementById("<%=txtName.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtVisitingDate.ClientID %>"), 'Visiting Date');
            if (msg != "") {
                document.getElementById("<%=txtVisitingDate.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtFrom.ClientID %>"), 'In Time');
            if (msg != "") {
                document.getElementById("<%=txtFrom.ClientID %>").focus();
                return msg;
            }
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
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsginfo.ClientID%>").innerText = "";
                    return false;
                }
                return true;
            }
        }
//        function SplitName() {
//            var text = document.getElementById("<%=txtEmp.ClientID%>").value;
//            var split = text.split(':');
//            if (split.length > 0) {
//                document.getElementById("<%=txtEmp.ClientID%>").innerText = split[0];
//                document.getElementById("<%=txtName.ClientID%>").innerText = split[1];
//                document.getElementById("<%=HidempId.ClientID%>").innerText = split[2];
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
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="TxtVID" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmpId" runat="server" Text="Employee Code* :" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:HiddenField ID="HidempId" runat="server" />
                                &nbsp;&nbsp;<asp:TextBox ID="txtEmp" SkinID="txt" runat="server" TabIndex="1"></asp:TextBox><ajaxToolkit:AutoCompleteExtender
                                    ID="AutoCompleteExtender2" runat="Server" TargetControlID="txtEmp" EnableCaching="True"
                                    MinimumPrefixLength="3" ServiceMethod="getEmpCodeExt1" ServicePath="TextBoxExt.asmx"
                                    OnClientPopulated="HideImage" OnClientPopulating="ShowImage"
                                    CompletionInterval="2000" FirstRowSelected="true" CompletionListCssClass="completeListStyle">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmpName" runat="server" Text="Employee Name* :" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:TextBox ID="txtName" runat="server" SkinID="txt" AutoCompleteType="Disabled"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblVisitingDate" runat="server" Text="Visiting Date* :" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:TextBox ID="txtVisitingDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDiscussion" runat="server" Text="Visitor Name :" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:TextBox ID="txtDiscussion" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFrom" runat="server" Text="In Time* :" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:TextBox ID="txtFrom" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender
                                    ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFrom" InvalidChars="."
                                    FilterMode="InvalidChars">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtFrom" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTo" runat="server" Text="Out Time :" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:TextBox ID="txtTo" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender
                                    ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtTo" InvalidChars="."
                                    FilterMode="InvalidChars">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptAMPM="true"
                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtTo" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblContact" runat="server" Text="Contact Details :" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:TextBox ID="txtContact" runat="server" size="250" TextMode="MultiLine"
                                    SkinID="txtML" TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks :" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;<asp:TextBox ID="txtRemarks" runat="server" SkinID="txtML" TabIndex="7"
                                    size="250" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnsave" runat="server" SkinID="btn" Text="ADD" CausesValidation="true"
                                    OnClientClick="return Validate();" CssClass="ButtonClass" TabIndex="8" />
                                <asp:Button ID="btndetails" runat="server" SkinID="btn" Text="VIEW" CausesValidation="False"
                                    CssClass="ButtonClass" TabIndex="9" />
                                <asp:Button ID="btnprintslip" runat="server" SkinID="btnRSz" Text="PRINT SLIP" CausesValidation="False"
                                    CssClass="ButtonClass" Width="100px" TabIndex="13" />
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
                    <div>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                        <asp:Label ID="lblmsginfo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                    </div>
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
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            DataKeyNames="VID" PageSize="100" SkinID="GridView" Visible="true" Width="504px"
                            EnableSortingAndPagingCallbacks="True" AllowSorting="True">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" TabIndex="10"></asp:LinkButton>
                                        <asp:LinkButton ID="btndelete" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" TabIndex="11"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBx" runat="server" TabIndex="12"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Code and Name" HeaderStyle-HorizontalAlign="Center"
                                    ControlStyle-Width="190px" ItemStyle-HorizontalAlign="Left" SortExpression="Emp_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Width="175px" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Visiting Date" ControlStyle-Width="100px" SortExpression="Visiting_Date" 
                                HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="VID" runat="server" Value='<%# Bind("VID") %>' />
                                        <asp:HiddenField ID="ECODE" runat="server" Value='<%# Bind("Emp_Code") %>' />
                                        <asp:HiddenField ID="EID" runat="server" Value='<%# Bind("EmpID") %>' />
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Visiting_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Visitor Name" HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="100px"
                                    ItemStyle-HorizontalAlign="Left" SortExpression="Discussion">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Discussion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="In Time" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("From_Time", "{0:hh:mm tt}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Out Time" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("To_Time", "{0:hh:mm tt}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Details" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Left" ControlStyle-Width="190px">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Width="250px" Text='<%# Bind("Contact_Details") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                                    ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Width="190px" Text='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <br />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                    Format="dd-MMM-yyyy" TargetControlID="txtVisitingDate">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="false"
                    ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                    TargetControlID="txtVisitingDate">
                </ajaxToolkit:MaskedEditExtender>
                <br />
                <asp:ObjectDataSource ID="ObjVstg" runat="server" TypeName="VisitingManager" DataObjectTypeName="Visiting"
                    InsertMethod="InsertRecord" OldValuesParameterFormatString="original_{0}" SelectMethod="GetVisiting"
                    UpdateMethod="UpdateRecord" DeleteMethod="ChangeFlag">
                    <DeleteParameters>
                        <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjEmp" runat="server" TypeName="EmployeeManager" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetEmpComboUserInsBr">
                    <SelectParameters>
                        <asp:SessionParameter Name="HidInst" SessionField="InstituteID" Type="Int32" />
                        <asp:SessionParameter Name="HidBranch" SessionField="BranchID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" WatermarkText="Type first few characters"
                    runat="server" TargetControlID="txtEmp" SkinID="watermark">
                </ajaxToolkit:TextBoxWatermarkExtender>
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
    </asp:UpdatePanel>

</form>
</body>
</html>