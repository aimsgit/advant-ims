<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProjectMaster.aspx.vb"
    Inherits="ProjectMaster" Title="Project Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Project Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;

            msg = Field250(document.getElementById("<%=txtProjNme.ClientID %>"), 'Project Name');
            if (msg != "") {
                document.getElementById("<%=txtProjNme.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlSubmittedBy.ClientID %>"), 'Submitted By');
            if (msg != "") {
                document.getElementById("<%=ddlSubmittedBy.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtSubmittedDate.ClientID %>"), 'Submitted Date');
            if (msg != "") {
                document.getElementById("<%=txtSubmittedDate.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }
       
    </script>

    <script type="text/javascript" language="javascript">

   
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
                    <%--<center>
                        <h1 class="headingTxt">
                            PROJECT MASTER
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblProjNme" runat="server" SkinID="lblRsz" Text="Project Name*^ :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtProjNme" runat="server" SkinID="txtRsz" Width="250px" TabIndex="1"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtProjNme">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDescription" runat="server" SkinID="lblRsz" Text="Description :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescription" runat="server" SkinID="txt" TextMode="MultiLine"
                                        AutoCompleteType="Disabled" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSubmitted" runat="server" SkinID="lblRsz" Text="Submitted By* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSubmittedBy" TabIndex="3" runat="server" SkinID="ddlRsz"
                                        DataSourceID="odsubmittedby" DataTextField="Emp_Name" DataValueField="EmpID"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsubmittedby" runat="server" TypeName="DLProjectMaster"
                                        SelectMethod="GetSubmittedBy"></asp:ObjectDataSource>
                                    <%-- <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" CompletionInterval="1000"
                                        EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage1"
                                        OnClientPopulating="ShowImage1" OnClientItemSelected="SplitName1" ServiceMethod="getEmpCodeExt3"
                                        CompletionListCssClass="completeListStyle" ServicePath="TextBoxExt.asmx" TargetControlID="txtSubmittedBy">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                        SkinID="watermark" TargetControlID="txtSubmittedBy" WatermarkText="Type Employee Code">
                                    </ajaxToolkit:TextBoxWatermarkExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSubmittedDate" runat="server" SkinID="lblRsz" Text="Submitted Date* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSubmittedDate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblApprovedBy" runat="server" SkinID="lblRsz" Text="Approved By :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlApprovedby" TabIndex="3" runat="server" SkinID="ddlRsz"
                                        DataSourceID="odsubmittedby1" DataTextField="Emp_Name" DataValueField="EmpID"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsubmittedby1" runat="server" TypeName="DLProjectMaster"
                                        SelectMethod="GetSubmittedBy"></asp:ObjectDataSource>
                                    <%--<asp:TextBox ID="txtApprovedBy" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" CompletionInterval="1000"
                                        EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage2"
                                        OnClientPopulating="ShowImage2" OnClientItemSelected="SplitName2" ServiceMethod="getEmpCodeExt3"
                                        ServicePath="TextBoxExt.asmx" TargetControlID="txtApprovedBy" CompletionListCssClass="completeListStyle">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                        SkinID="watermark" TargetControlID="txtApprovedBy" WatermarkText="Type first 3 characters">
                                    </ajaxToolkit:TextBoxWatermarkExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblApprovedDate" runat="server" SkinID="lblRsz" Text="Approved Date :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtApprovedDate" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStartDate" runat="server" SkinID="lblRsz" Text="Project Start Date^ :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtStartDate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEndDate" runat="server" SkinID="lblRsz" Text="Project End Date :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSponsor" runat="server" SkinID="lblRsz" Text="Donor/Sponsor :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSponsor" runat="server" Width="250 px" DataSourceID="Objsponsor"
                                        DataTextField="SponsorName" SkinID="ddlRsz" DataValueField="Sponsor_IDAuto" TabIndex="9">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="Objsponsor" runat="server" SelectMethod="GetSponsor" TypeName="DLEndowment">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2" align="center">
                                    <asp:Button ID="btnSave" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                        SkinID="btn" TabIndex="10" Text="ADD" />
                                    <asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                        SkinID="btn" TabIndex="11" Text="VIEW" />
                                    <asp:Button ID="btnStatus" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                        SkinID="btn" TabIndex="12" Text="STATUS" />
                                    <%--<ajaxToolkit:MaskedEditExtender ID="SubmittedDate" runat="server" ClearMaskOnLostFocus="false"
                                        ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                        TargetControlID="txtSubmittedDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="ApprovedDate" runat="server" ClearMaskOnLostFocus="false"
                                        ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                        TargetControlID="txtApprovedDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="StartDate" runat="server" ClearMaskOnLostFocus="false"
                                        ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                        TargetControlID="txtStartDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="EndDate" runat="server" ClearMaskOnLostFocus="false"
                                        ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                        TargetControlID="txtEndDate">
                                    </ajaxToolkit:MaskedEditExtender>--%>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtSubmittedDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtApprovedDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtStartDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtEndDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidSEmpCode" runat="server" />
                                    <asp:HiddenField ID="HidSEmpId" runat="server" />
                                    <asp:HiddenField ID="HidAEmpCode" runat="server" />
                                    <asp:HiddenField ID="HidAEmpId" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <div>
                            &nbsp;
                        </div>
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
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </div>
                        </center>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                        <asp:GridView ID="GVProjectMaster" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                            Visible="False" AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Text="Edit" TabIndex="11"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                            Text="Delete" TabIndex="12" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Visible="false"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Project Name" SortExpression="Project_Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProjID" runat="server" Visible="false" Text='<%#Bind("ProjectID") %>' />
                                                        <asp:Label ID="lblProjName" runat="server" Width="150" Text='<%# Bind("Project_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="True" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Width="150" Text='<%# Bind("Description")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="True" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Project Start Date" SortExpression="Prj_Start_Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("Prj_Start_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Project End Date" SortExpression="Prj_End_Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("Prj_End_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Donor/Sponsor" SortExpression="SponsorName">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("SponsorID") %>' />
                                                        <asp:Label ID="lbl1" runat="server" Width="150" Text='<%# Bind("SponsorName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="True" />
                                                    <ItemStyle HorizontalAlign="left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Submitted By" SortExpression="ProposedEmpName">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="lblSubmit" runat="server" Value='<%#Bind("Proposed_By") %>' />
                                                        <asp:Label ID="lblSubmittedBy" runat="server" Text='<%# Bind("ProposedEmpName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Submitted Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubmittedDate" runat="server" Text='<%# Bind("Proposed_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approved By">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="lblApprdBy" runat="server" Value='<%#Bind("Approved_By") %>' />
                                                        <asp:Label ID="lblApprovedBy" runat="server" Text='<%# Bind("ApprovedEmpName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approved Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApprovedDate" runat="server" Text='<%# Bind("Approved_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
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
