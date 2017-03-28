<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmEligiblityStudent.aspx.vb"
    Inherits="FrmEligiblityStudent" Title="Promotion and Eligibility" EnableEventValidation="false"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Promotion and Eligibility</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=DdlBatchPlanner.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=DdlBatchPlanner.ClientID %>").focus();
                return msg;
            }
            //              msg = DropDownForZero(document.getElementById("<%=ddlSem1.ClientID %>"), 'Semester');
            //            if (msg != "") {
            //                document.getElementById("<%=ddlSem1.ClientID %>").focus();
            //                return msg;
            //            }
            msg = DropDownForZero(document.getElementById("<%=ddlassesment.ClientID %>"), 'Assessment Type');
            if (msg != "") {
                document.getElementById("<%=ddlassesment.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbSFailed.ClientID %>"), 'No of Subjects Failed');
            if (msg != "") {
                document.getElementById("<%=cmbSFailed.ClientID %>").focus();
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
        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddltrsfrBatch.ClientID %>"), 'Trf to Batch');
            if (msg != "") {
                document.getElementById("<%=ddltrsfrBatch.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate1() {
            var msg = Valid1();
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
                    <center>
                        <%--<h1 class="headingTxt">
                        PROMOTION AND ELIGIBILITY
                    </h1>--%>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    </br>
                    <asp:Panel ID="ControlsPanel" runat="server">
                        <center>
                            <table>
                                <tr>
                                    <td align="left" colspan="4">
                                        <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Text="Step 1: This is used to identify the students who did not meet eligibility for promotion to next semester. Select Batch and the option for number of subject failed. Select the semesters. If you select one semester, the criteria will be applied to number of fails in one semester. If you select two(e.g. 1st Sem, 2nd Sem), the number of fails will be counted across both the semesters. the fail count is done on the selected Assessment type."></asp:Label>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DdlBatchPlanner" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            TabIndex="1" DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="objBatchPlanner"
                                            Width="200">
                                            <asp:ListItem Value="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="objBatchPlanner" runat="server" SelectMethod="getBatchPlannerCombo"
                                            TypeName="DLEligiblityPromotion"></asp:ObjectDataSource>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="200px" Text="No of Subjects Failed* :&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cmbSFailed" runat="server" SkinID="ddl" TabIndex="2">
                                            <asp:ListItem Value="0"> Select</asp:ListItem>
                                            <asp:ListItem Value="5">5 Or More</asp:ListItem>
                                            <asp:ListItem Value="4">4 Or More</asp:ListItem>
                                            <asp:ListItem Value="3">3 Or More</asp:ListItem>
                                            <asp:ListItem Value="2">2 Or More</asp:ListItem>
                                            <asp:ListItem Value="1">1 Or More</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label8" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <%--<asp:DropDownList ID="cmbSemester" TabIndex="3" Width="57px" runat="server" SkinID="ddl" DataValueField="SemCode"
                                        DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboD1"
                                        TypeName="DLEligiblityPromotion">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DdlBatchPlanner" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>--%>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlSem1" TabIndex="3" runat="server" DataValueField="SemCode"
                                            SkinID="ddlRsz" DataTextField="SemName" Width="97px" DataSourceID="ObjSemester"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                            TypeName="FeeCollectionBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="DdlBatchPlanner" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                        <asp:DropDownList ID="ddlSem2" TabIndex="4" Width="97px" runat="server" DataValueField="SemCode"
                                            DataTextField="SemName" DataSourceID="ObjSem2" AutoPostBack="true" SkinID="ddlRsz">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSem2" runat="server" SelectMethod="SemesterCombo1" TypeName="FeeCollectionBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="DdlBatchPlanner" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td>
                                    </td>
                                    <td colspan="2" class="btnTd" style="height: 9px" align="left">
                                        <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" TabIndex="6" Text="SUBMIT" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblassesment" runat="server" Text="Assessment Type*&nbsp;:&nbsp;&nbsp;"
                                            SkinID="lblRsz" Width="170px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                            DataTextField="AssessmentType" Width="200px" DataValueField="ID" TabIndex="5">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                            TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                    </td>
                                    <td>
                                    </td>
                                    <td colspan="2" class="btnTd" style="height: 9px" align="left">
                                        <asp:Button ID="btnReport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" TabIndex="6" Text="REPORT" />
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <hr />
                        <table>
                            <table>
                                <tr>
                                    <td align="left" colspan="4">
                                        <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Text="Step 2: Step 2 is used to move the ineligible students to another batch (detained batch, or junior batch as the case may be). Select the batch where these students need to be transferred. Click on Transfer button to make this transfer. Undo will restore the previous situation."></asp:Label>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="Transfer To Batch :&nbsp;&nbsp;" Width ="170px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddltrsfrBatch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            TabIndex="5" DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="objBatchPlanner"
                                            Width="200">
                                            <asp:ListItem Value="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btntransfer" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate1();" SkinID="btnRsz" TabIndex="8" Text="TRANSFER"
                                            Width="110px" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUndo" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="9"
                                            Text="UNDO" Width="90px" />
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
                                        <td>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
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
                                <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Auto" Width="600px">
                                    <asp:GridView ID="GElEigiblity" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Batch">
                                                <ItemTemplate>
                                                    <asp:Label ID="BID" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                    <asp:Label ID="lblBatchGV" Visible="false" runat="server" Text='<%# Bind("Batch") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="stdcode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                                    <asp:HiddenField ID="STD_ID" runat="server" Value='<%# Bind("STDID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject Failed" SortExpression="SubjectFailed">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblSubjectFailed" runat="server" Text='<%# Bind("SubjectFailed") %>'
                                                        Width="86px" CommandName="Update"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                    </asp:Panel>
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
    <br />
    <center>
        <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
            SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
    </center>
    </form>
</body>
</html>
