<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_BestPerformance.aspx.vb"
    Inherits="Rpt_BestPerformance" Title="Best Performer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Best Performer</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

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
                        <asp:Label ID="Lblheading" Text="BEST PERFORMERS" runat="server"></asp:Label>
                    </h1>
                </center>
                <br/>
                <hr />
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lbl1" runat="server" Font-Bold="true" Text="SELECT REPORT TYPE"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="SELECT CRITERIA"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="RbType" runat="server" AutoPostBack="true" RepeatDirection="Vertical"
                                    SkinID="Themes" TabIndex="1" Width="300px">
                                    <asp:ListItem Selected="True" Text="Best Students" Value="S"></asp:ListItem>
                                    <asp:ListItem Text="Best Faculties" Value="F"></asp:ListItem>
                                    <asp:ListItem Text="Best Subjects" Value="SB"></asp:ListItem>
                                    <asp:ListItem Text="Best Programs" Value="P"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="RbCriteria" runat="server" AutoPostBack="true" RepeatDirection="Vertical"
                                    SkinID="Themes" TabIndex="2" Width="200px">
                                    <asp:ListItem Selected="True" Text="Marks" Value="M"></asp:ListItem>
                                    <asp:ListItem Text="Attendance" Value="A"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblbatch" runat="server" Text="Batch&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                        DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="3"
                                        Width="240px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchBestPerformerDDL"
                                        TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblfrmdate" runat="server" SkinID="lblRsz" Width="150px" Text="From Date :&nbsp;"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtFrmdate" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                        TargetControlID="txtFrmdate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtFrmdate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Subject&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlsubject" SkinID="ddlRsz" runat="server" DataSourceID="ObjSubject"
                                        DataTextField="Subject_Name" DataValueField="Subject_Code" TabIndex="6" Width="240px"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner5"
                                        TypeName="DLNew_StudentMarks">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                           
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblTodate" runat="server" SkinID="lblRsz" Width="150px" Text="To Date :&nbsp;"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txttodate" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                        TargetControlID="txttodate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txttodate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblassesment" runat="server" Text="Assessment &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                        DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="240px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentComboAll"
                                        TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tr>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnReport" runat="server" Text="REPORT" CausesValidation="true" SkinID="btn"
                                         CssClass="ButtonClass" TabIndex="21"></asp:Button>
                                    &nbsp;<asp:Button ID="Btnview" runat="server" Text="BACK" CausesValidation="true"
                                        SkinID="btn" CssClass="ButtonClass " TabIndex="22"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </center>
                </center>
                <center>
                    <br />
                    <asp:Label ID="lblerror" runat="server" SkinID="lblRed" />
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                </center>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
