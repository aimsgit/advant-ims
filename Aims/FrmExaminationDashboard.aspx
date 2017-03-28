<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmExaminationDashboard.aspx.vb"
    Inherits="FrmExaminationDashboard" Title="EXAMINATION DASHBOARD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>EXAMINATION DASHBOARD</title>
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
                        EXAMINATION DASHBOARD
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                        DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="2"
                                        Width="240px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblsemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlsemester" SkinID="ddlRsz" runat="server" DataSourceID="ObjSemester"
                                        DataTextField="SemName" DataValueField="SemCode" AutoPostBack="True" TabIndex="3"
                                        Width="240px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="lblsubject" runat="server" Text="Subject&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlsubject" SkinID="ddlRsz" runat="server" DataSourceID="ObjSubject"
                                        DataTextField="Subject_Name" DataValueField="Subject_Code" TabIndex="4" Width="240px"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblassesment" runat="server" Text="Assessment Type*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                        DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="240px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:RadioButtonList ID="RBMarks1" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                        TabIndex="11">
                                        <asp:ListItem Value="1" Selected="True">Marks   </asp:ListItem>
                                        <asp:ListItem Value="2">Percentage</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Width="150px" Text="Marks/Percentage Range :"
                                        Visible="false"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblMarksheadingFrm1" runat="server" Text="From" />&nbsp;
                                    <asp:Label ID="lblMarksheadingTo1" runat="server" Text="To" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblMarksheadingFrm2" runat="server" Text="From" />&nbsp;
                                    <asp:Label ID="lblMarksheadingTo2" runat="server" Text="To" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblMarksheadingFrm3" runat="server" Text="From" />&nbsp;
                                    <asp:Label ID="lblMarksheadingTo3" runat="server" Text="To" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblMarksheadingFrm4" runat="server" Text="From" />&nbsp;
                                    <asp:Label ID="lblMarksheadingTo4" runat="server" Text="To" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblMaksAnalysis" runat="server" SkinID="lblRsz" Width="250px" Text="Marks/Percentage Range :&nbsp;&nbsp;"></asp:Label>  
                                </td>
                               
                                <td>
                                    <asp:TextBox ID="TxtFrm1" runat="server" SkinID="txtRsz" Width="20" TabIndex="12"
                                        MaxLength="3" /><
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtFrm1">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:TextBox ID="TxtTo1" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                        TabIndex="13" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtTo1">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:TextBox ID="TxtFrm2" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                        TabIndex="14" /><
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtFrm2">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:TextBox ID="TxtTo2" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                        TabIndex="15" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtTo2">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:TextBox ID="TxtFrm3" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                        TabIndex="16" /><
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtFrm3">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:TextBox ID="TxtTo3" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                        TabIndex="17" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtTo3">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:TextBox ID="TxtFrm4" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                        TabIndex="18" /><
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtFrm4">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:TextBox ID="TxtTo4" runat="server" SkinID="txtRsz" Width="20" MaxLength="3"
                                        TabIndex="19" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="TxtTo4">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerComboSelectAll"
                                TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                TypeName="FeeCollectionBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboAll"
                                TypeName="DLBatchReportCardElect">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="Batchid" PropertyName="SelectedValue"
                                        Type="Int16" />
                                    <asp:ControlParameter ControlID="ddlsemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                        </table>
                    </center>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnGenerate" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        SkinID="btnRsz" TabIndex="3" Text="GENERATE" />
                                    <asp:Button ID="BtnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                        Text="BACK" />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                            <ProgressTemplate>
                                <div class="PleaseWait">
                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                    <asp:Label ID="ErrMsg" runat="server" SkinID="lblRed" />
                                </td>
                            </tr>
                        </table>
                    </center>
                </asp:Panel>
                <br />
                <br />
                <center>
                    <asp:Panel ID="Panel2" runat="server" Height="500px" Width="750px" ScrollBars="Auto">
                        <asp:Chart ID="Chart1" runat="server" Height="350px" Width="400px" EnableViewState="true"
                            ViewStateContent="Data">
                            <%--  <Legends>
                                <asp:Legend Name="Legend1"  BackImageAlignment="TopRight" Docking="Top" LegendStyle="Table"
                                    TitleFont="Microsoft Sans Serif, 6pt, style=Bold">
                                </asp:Legend>
                            </Legends>--%>
                            <%--  <Titles>
                                <asp:Title Text="Student Status" Font="Microsoft Sans Serif, 14.25pt" Alignment="TopCenter">
                                </asp:Title>
                            </Titles>--%>
                            <Series>
                                <asp:Series>
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BackImageAlignment="Top">
                                    <AxisY Title="No. Of Students">
                                    </AxisY>
                                    <AxisX Title="Count Of Students">
                                        <LabelStyle Angle="90" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </asp:Panel>
                </center>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                    </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
