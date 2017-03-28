<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmBuyerwiseSale.aspx.vb"
    Inherits="Mfg_FrmBuyerwiseSale" Title="Untitled Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = ValidateDateN(document.getElementById("<%=Txtfdate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=Txtfdate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=Txttodate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=Txttodate.ClientID%>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <center>
                            <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblbuyer" runat="server" SkinID="lbl" Text="Buyer&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DDlBuyer" SkinID="ddlRsz" AutoPostBack="true" DataSourceID="ObjBuyer"
                                            DataTextField="Party_Name" DataValueField="PartyAutoNo" runat="server" TabIndex="1"
                                            Width="300px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="BuyerComboAll" TypeName="Mfg_DLBuyerwiseSale">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Lblfdate" runat="server" Text="From Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Txtfdate" runat="server" SkinID="txt" MaxLength="11" TabIndex="2"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                            TargetControlID="Txtfdate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Lbltdate" runat="server" Text="To Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Txttodate" runat="server" SkinID="txt" MaxLength="11" TabIndex="3"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                                            TargetControlID="Txttodate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                        <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="4" Text="GENERATE" />
                                        <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                        </asp:Button>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <center>
                                <asp:Panel runat="server" ID="pnllabel" Visible="false">
                                    <table>
                                        <tr>
                                            <td align="left" colspan="2">
                                            </td>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="lblTotalQuantity" runat="server" Text="Total Quantity :&nbsp;&nbsp;"
                                                    SkinID="lblRsz" Width="126px" />
                                                <asp:Label ID="lblTotalQuantityAns" runat="server" SkinID="lbl" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="Label2" runat="server" Text="Total Records :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    Width="126px" />
                                                <asp:Label ID="Label3" runat="server" SkinID="lbl" />
                                            </td>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="lblTotalValuation" runat="server" Text="Total Valuation :&nbsp;&nbsp;"
                                                    SkinID="lblRsz" Width="145px" />
                                                <asp:Label ID="lblTotalValuationAns" runat="server" SkinID="lbl" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </center>
                            <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GVStdAttd" runat="server" Width="584px" SkinID="GridView" DataKeyNames="Id"
                                    AllowPaging="true" AutoGenerateColumns="False" Visible="true" PageSize="200"
                                    AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField ControlStyle-Width="25px">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" 
                                                    Text="Present" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkPresent" runat="server" TabIndex="9" />
                                                <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("id") %>' />
                                                <asp:Label ID="LabelPre" runat="server" Text='<%# Bind("Present") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Name" ControlStyle-Width="200px" SortExpression="StdName">
                                            <ItemTemplate>
                                                <asp:Label ID="l9" runat="server" Text='<%# Bind("StdName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                            <ItemTemplate>
                                                <asp:Label ID="l8" runat="server" Text='<%# Bind("StdCode") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="l4" runat="server" Text='<%# Bind("Subject_Name") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ClassType" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="l5" runat="server" Text='<%# Bind("Elective_Sub") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Attendance Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="l6" runat="server" Text='<%# Bind("AttendanceDate","{0:dd-MMM-yyyy}") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Period No">
                                            <ItemTemplate>
                                                <asp:Label ID="l7" runat="server" Text='<%# Bind("PeriodNo") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Elective" SortExpression="Elective_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblElective" runat="server" Text='<%# Bind("Elective_Name") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' MaxLength="10"
                                                    Width="75" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Semester" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="l3" runat="server" Text='<%# Bind("SemName") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Batch" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="l2" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Academic Year" Visible="false" meta:resourcekey="TemplateFieldResource2">
                                            <ItemTemplate>
                                                <asp:Label ID="l1" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLNew_StudentMarks">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmbAcademic" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                        Type="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="objsemester" runat="server" SelectMethod="SemesterCombo1"
                                TypeName="FeeCollectionBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmbBatch" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner"
                                TypeName="DLNew_StudentMarks">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmbBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                    <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </center>
                </asp:Panel>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                                            OnClientClick="btnPassword_click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblpassError" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                </asp:Panel>
            </div>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <center>
        <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
            SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
    </center>

</form>
</body>
</html>
