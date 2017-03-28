<%@ Page Title="Map Student to Exam Center" Language="VB" 
    AutoEventWireup="false" CodeFile="FrmMapStdExamCenter.aspx.vb" Inherits="FrmMapStdExamCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Map Student to Exam Center</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        MAP STUDENT TO EXAM CENTER
                        <%--<asp:Label ID="Lblheading" runat="server"></asp:Label>--%>
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblExamBatch" runat="server" Text="Exam Batch*^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlExamBatch" runat="server" DataTextField="ExamBatch" DataSourceID="ObjExamBatch"
                                        DataValueField="ExamBatch_Autoid" SkinID="ddl" TabIndex="1" AppendDataBoundItems="False"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblCountOfStudents" runat="server" Text="Count of Students :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCountofStd" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="right">
                                    <asp:Label ID="lblStudentCenter" runat="server" Text="Student Center*^ :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlStudentCenter" runat="server" DataTextField="BranchName"
                                        DataSourceID="ObjStudentCenter" DataValueField="BranchCode" SkinID="ddl" TabIndex="2"
                                        AppendDataBoundItems="False" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblExamCenter" runat="server" Text="Exam Center*^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlExamCenter" runat="server" DataTextField="BranchName" DataSourceID="ObjExamCenter"
                                        DataValueField="BranchCode" SkinID="ddl" TabIndex="3" AppendDataBoundItems="False"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudentCenter" runat="server" Text="Student Center*^ :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlStudentCenter" runat="server" DataTextField="BranchName"
                                        DataSourceID="ObjStudentCenter" DataValueField="BranchCode" SkinID="ddlRSz" TabIndex="2"
                                        Width="250px" AppendDataBoundItems="False" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblExamCenter" runat="server" Text="Exam Center*^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlExamCenter" runat="server" DataTextField="BranchName" DataSourceID="ObjExamCenter"
                                        DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="3" AppendDataBoundItems="False"
                                        Width="250px" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <center>
                            <hr style="width: 620px" />
                        </center>
                        <center>
                            <table>
                                <tr>
                                    <td align="right">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="blStdName" runat="server" Text="Std Name^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtStdName" TabIndex="4" runat="server" SkinID="txt"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblStdCode" runat="server" Text="Std Code^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtStdCode" TabIndex="5" runat="server" SkinID="txt"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <center>
                            <hr style="width: 620px" />
                        </center>
                        <center>
                            <table>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Width="100px"
                                            TabIndex="10" Text="VIEW" />
                                        &nbsp;
                                        <asp:Button ID="btnGenerate" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            Width="100px" TabIndex="6" Text="GENERATE" Visible="false" />
                                        <asp:Button ID="btnMap" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Width="100px"
                                            TabIndex="7" Text="MAP" />&nbsp;
                                        <asp:Button ID="btnClear" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Width="100px"
                                            TabIndex="8" Text="CLEAR" OnClientClick="return confirm('Do you want to clear all the records?')" />
                                        &nbsp;
                                        <asp:Button ID="btnLock" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Width="120px"
                                            TabIndex="9" Text="LOCK/UNLOCK" />
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </center>
                    <center>
                        <hr style="width: 620px" />
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
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                    </center>
                    <asp:ObjectDataSource ID="ObjExamBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetExamBatchDDL" TypeName="DLExamHallTicket"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjStudentCenter" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetExamBatchCenter" TypeName="DLExamHallTicket">
                        <%--<SelectParameters>
                        <asp:ControlParameter ControlID="ddlExamBatch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                    </SelectParameters>--%>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjExamCenter" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetExamBatchCenter" TypeName="DLExamHallTicket">
                        <%-- <SelectParameters>
                        <asp:ControlParameter ControlID="ddlExamBatch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                    </SelectParameters>--%>
                    </asp:ObjectDataSource>
                    <br />
                    <center>
                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="5000" SkinID="GridView" TabIndex="-1" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <%-- <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit" Visible="false" />
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Do you want to delete this record?')" Text="Delete"
                                                Visible="false" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exam Batch" SortExpression="ExamBatch">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="lblADId" runat="server" Value='<%# Eval("RegStudId") %>' />
                                            <asp:Label ID="lblExamBatch" runat="server" Text='<%# Bind("ExamBatch") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Batch" SortExpression="Batch_No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdCode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" HeaderStyle-HorizontalAlign="Left" SortExpression="StdName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Center" SortExpression="StdCenterName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdCenter" runat="server" Text='<%# Bind("StdCenterName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exam Center" SortExpression="ExamCenterName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExamCenter" runat="server" align="right" Text='<%# Bind("ExamCenterName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </asp:Panel>
                <center>
                    <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPassword" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                        </table>
                    </asp:Panel>
                </center>
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