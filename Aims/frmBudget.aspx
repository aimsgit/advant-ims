<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBudget.aspx.vb"
    Inherits="frmBudget" Title="Budget" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Budget</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>


    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlacadyear.ClientID %>"), 'Academic Year ');
            if (msg != "") {
                document.getElementById("<%=ddlacadyear.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DdlProjectName.ClientID %>"), 'Project Name ');
            if (msg != "") {
                document.getElementById("<%=DdlProjectName.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=TxtProjecttEstimate.ClientID%>"), 'Project Estimate');
            if (msg != "") {
                document.getElementById("<%=TxtProjecttEstimate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtEstimateDate.ClientID%>"), 'Estimation Date');
            if (msg != "") {
                document.getElementById("<%=txtEstimateDate.ClientID%>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtApprvedBudget.ClientID%>"), 'Approved Budget');
            if (msg != "") {
                document.getElementById("<%=txtApprvedBudget.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtApprvedDate.ClientID%>"), 'Approved Date');
            if (msg != "") {
                document.getElementById("<%=txtApprvedDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtRevisedBudgetDate.ClientID%>"), 'Revised Date');
            if (msg != "") {
                document.getElementById("<%=txtRevisedBudgetDate.ClientID%>").focus();
                return msg;
            }
            //            msg = CodeField (document.getElementById("<%=txtRevisedBudget.ClientID%>"),'Revised Budget');
            //            if (msg != "") return msg;
            msg = FeesFieldN(document.getElementById("<%=txtProjectProgress.ClientID%>"), 'Project Progress');
            if (msg != "") {
                document.getElementById("<%=txtProjectProgress.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";

                    return false;
                }
                return true;
            }
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
                    <%--  <center>
                        <h1 class="headingTxt">
                            BUDGET</h1>
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
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblYear" runat="server" SkinID="lblRsz" Text="Academic Calendar Year*^  :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlacadyear" TabIndex="1" runat="server" SkinID="ddlRsz" Width="300px"
                                            AutoPostBack="True" DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblProjectName" runat="server" SkinID="lblRsz" Text="Project Name*^ :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DdlProjectName" runat="server" DataSourceID="ObjProjectName"
                                            DataTextField="Project_Name" DataValueField="ProjectID_Auto" SkinID="ddlRsz"
                                            Width="300px" TabIndex="2">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblProjectestimate" runat="server" SkinID="lblRsz" Text="Project Estimate* :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TxtProjecttEstimate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="TxtProjecttEstimate">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblEstimateDate" runat="server" SkinID="lblRsz" Text="Estimate Date* :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEstimateDate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEstimateDate"
                                            Format="dd-MMM-yyyy" SkinID="CalendarView">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblApprvedBudget" runat="server" SkinID="lblRsz" Text="Approved Budget* :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtApprvedBudget" runat="server" SkinID="txt" AutoPostBack="true"
                                            TabIndex="5"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtApprvedBudget">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblApprvedDate" runat="server" SkinID="lblRsz" Text="Approved Date* :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtApprvedDate" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtApprvedDate"
                                            Format="dd-MMM-yyyy" SkinID="CalendarView">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblRevisedBudget" runat="server" SkinID="lblRsz" Text="Revised Budget :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRevisedBudget" runat="server" SkinID="txt" AutoPostBack="true"
                                            TabIndex="7"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtRevisedBudget">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblRevisedBudgetDate" runat="server" SkinID="lblRsz" Text="Revised Budget Date :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRevisedBudgetDate" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtRevisedBudgetDate"
                                            Format="dd-MMM-yyyy" SkinID="CalendarView">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblAmountUsed" runat="server" SkinID="lblRsz" Text="Amount Used :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAmountUsed" runat="server" SkinID="txt" AutoPostBack="true" TabIndex="9"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAmountUsed">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblAmountUsedpercnt" runat="server" SkinID="lblRsz" Text="Amount Used(%) :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAmountUsedpercnt" runat="server" SkinID="txt" ReadOnly="True"
                                            TabIndex="10"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblProjectProgress" runat="server" SkinID="lblRsz" Text=" Project Progress(%) :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtProjectProgress" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblStatusDate" runat="server" SkinID="lblRsz" Text=" Status Date :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtStatusDate" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtStatusDate"
                                            Format="dd-MMM-yyyy" SkinID="CalendarView">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblRemarks" runat="server" SkinID="lblRsz" Text=" Remarks :&nbsp"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TextMode="MultiLine" TabIndex="13"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="btnTd" colspan="2" align="center">
                                        <br />
                                        <asp:Button ID="BtnSave" TabIndex="14" runat="server" Text="ADD" CausesValidation="True"
                                            SkinID="btn" OnClientClick="return Validate();" CssClass="ButtonClass"></asp:Button>
                                        <asp:Button ID="BtnDetails" TabIndex="15" runat="server" Text="VIEW" CausesValidation="False"
                                            SkinID="btn" CssClass="ButtonClass"></asp:Button>
                        </table>
                    </center>
                    <div>
                        &nbsp;</div>
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
                            <asp:Label ID="msginfo" runat="server" EnableTheming="True" SkinID="lblRed"></asp:Label>
                            <asp:Label ID="lblmsg" runat="server" EnableTheming="true" SkinID="lblGreen"></asp:Label>
                        </div>
                    </center>
                    <div>
                        &nbsp;</div>
                    <asp:ObjectDataSource ID="ObjProjectName" runat="server" TypeName="DLBudget" SelectMethod="GetProjectNameCombo">
                    </asp:ObjectDataSource>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="100" SkinID="GridView" Visible="True" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Font-Underline="False" Text="Edit" TabIndex="16"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                Font-Underline="False" TabIndex="17" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Year" ItemStyle-HorizontalAlign="Center"
                                        SortExpression="AcademicYear">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="lblBudgetID" runat="server" Value='<%# Bind("BudgetID") %>'
                                                Visible="false" />
                                            <asp:Label ID="LblBranchIDAuto" runat="server" Text='<%# Bind("BudgetID_Auto") %>'
                                                Visible="False"></asp:Label>
                                            <asp:Label ID="lblAcode" runat="server" Text='<%# Bind("A_Code") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="lblYear" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Project Name" ItemStyle-HorizontalAlign="Left"
                                        SortExpression="Project_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprjctMastr" runat="server" Text='<%# Bind("ProjectID_Auto") %>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblProjectName" Width="200px" runat="server" Text='<%# Bind("Project_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Project Estimate"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectestimate" runat="server" Text='<%# Bind("Project_Estimate","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Date Of Estimation"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="DateOfEstimation">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldateofEstimation" runat="server" Text='<%# Bind("DateOfEstimation","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Approved Budget"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApprovedBudget" runat="server" Text='<%# Bind("Approved_Budget","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Approved date"
                                        ItemStyle-HorizontalAlign="Center" SortExpression="DateOfApproval">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApprovedDate" runat="server" Text='<%# Bind("DateOfApproval","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Revised Budget"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRevisedBudget" runat="server" Text='<%# Bind("Revised_Budget","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Revised Budget Date"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrevisedBudgetDate" runat="server" Text='<%# Bind("DateRevBudget","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Amount Used" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmountUsed" runat="server" Text='<%# Bind("Used_Budget","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="% Amount Used"
                                    ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPerAmntUsed" runat="server" Text='<%# Bind("Pernt","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="% Amount Used"
                                    ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPerAmntUseddd" runat="server" Text='<%# Bind("Pernt1","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Project Progress"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectProgress" runat="server" Text='<%# Bind("Progress_Percent") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Status Date"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatusDate" runat="server" Text='<%# Bind("Status_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right" HeaderText="Balance Amount"
                                        ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBalanceAmnt" runat="server" Text='<%# Bind("BalanceAmount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Remarks" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                    <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                        TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
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
