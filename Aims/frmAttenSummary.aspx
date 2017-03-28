<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAttenSummary.aspx.vb"
    Inherits="frmAttenSummary" Title="Attendance Summary" EnableEventValidation="false"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Attendance Summary</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;



            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlBatchName.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=DDLSemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=DDLSemester.ClientID %>").focus();
                return msg;
            }


            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=MsgInfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=MsgInfo.ClientID %>").textContent = msg;
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
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
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
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Adate" runat="server" SkinID="lblRsz" Width="150px" Text="As On Date* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtAdate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                        TargetControlID="txtAdate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtAdate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelBtch" runat="server" SkinID="lbl" Text="Batch* :&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true"
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                        AppendDataBoundItems="False" Width="200">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchddl" TypeName="DLNewSemesterMarks">
                                    </asp:ObjectDataSource>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSemester" runat="server" Text="Semester* :&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLSemester" SkinID="ddlRsz" DataSourceID="objSemester" DataValueField="SemCode"
                                        DataTextField="SemName" AutoPostBack="true" AppendDataBoundItems="false" runat="server"
                                        Width="200" TabIndex="3">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="GetSemddl" TypeName="DLNewSemesterMarks">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSub" runat="server" Text="Subject &nbsp;:&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSubject" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                        DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="200" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner"
                                        TypeName="DLAttenSummary">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                            <asp:ControlParameter ControlID="DDLSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table>
                            <tr>
                                <td colspan="4" class="btnTd">
                                    <asp:Button ID="BtnRunsummary" runat="server" CausesValidation="True" Text="RUN SUMMARY"
                                        SkinID="btnRsz" TabIndex="5" CssClass="ButtonClass " Width="150" OnClientClick="return Validate();" />
                                    &nbsp;<asp:Button ID="btnVeiw" runat="server" CssClass="ButtonClass" SkinID="btn"
                                        TabIndex="6" Text="VIEW" OnClientClick="return Validate();" />
                                    &nbsp;<asp:Button ID="btnClear" runat="server" CssClass="ButtonClass" SkinID="btn"
                                        TabIndex="7" Text="CLEAR" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                    &nbsp;<asp:Button ID="btnLock" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="8" Text="LOCK/UNLOCK" Width="150" OnClientClick="return Validate();" />
                                    &nbsp;<asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btn"
                                        TabIndex="9" Text="UPDATE" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
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
                        <asp:Panel runat="server" ID="pnllabel" Visible="false">
                            <table>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Label ID="lblBatch" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lblRsz"
                                            Width="80" />
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="lblBatchAns" runat="server" SkinID="lblRsz" />
                                    </td>
                                    <td align="left" colspan="2">&nbsp;&nbsp;
                                        <asp:Label ID="lblSem" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lblRsz" Width="90px" />
                                    <%--</td>
                                    <td align="left" colspan="2">--%>
                                        <asp:Label ID="lblSemAns" runat="server" SkinID="lblRsz"/>
                                    </td>
                                    <td align="right" colspan="2">&nbsp;&nbsp;
                                        <asp:Label ID="lblDate" runat="server" Text="Date :&nbsp;&nbsp;" SkinID="lblRsz" />
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="lblDateAns" runat="server" SkinID="lblRsz" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="GridView" runat="server" ScrollBars="Auto" Width="680px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                DataKeyNames="ASID" SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <RowStyle HorizontalAlign="Left" />
                                <Columns>
                                    <%-- <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit"></asp:LinkButton>/
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update"
                                        Text="Update" ></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Wrap="False"></ItemStyle>
                            </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelStdCode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelStdname" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject" SortExpression="Subject_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelSubject" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Attendance">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTotAttend" runat="server" SkinID="txtRsz" Text='<%# Bind("TotAttend") %>'
                                                Width="60px"></asp:TextBox>
                                            <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtTotAttend">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Actual Attendance">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtActAttend" runat="server" SkinID="txtRsz" Text='<%# Bind("ActualAttend") %>'
                                                Width="60px"></asp:TextBox>
                                            <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtActAttend">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Attendance %" SortExpression="ActualPercentage">
                                        <ItemTemplate>
                                            <asp:Label ID="Labelmarks" runat="server" Text='<%# Bind("ActualPercentage","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Semester" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelSemester" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AsOnDate" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelAsOnDate" runat="server" Text='<%# Bind("AsOnDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Batch" Visible="false">
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="Lblbatch" Visible="false" runat="server" Text='<%# Bind("BatchID") %>'></asp:Label>--%>
                                            <asp:Label ID="LabelBatch" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                            <asp:Label ID="lblid" runat="server" Text='<%# Bind("ASID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
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
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" OnTextChanged="btnPassword_click"></asp:TextBox>
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
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
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