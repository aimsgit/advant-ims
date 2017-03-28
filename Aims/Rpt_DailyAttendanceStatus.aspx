<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_DailyAttendanceStatus.aspx.vb" Inherits="Rpt_DailyAttendanceStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DAILY ATTENDANCE STATUS REPORT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                       <h1 class="headingTxt">
                            <asp:Label ID="LblsemAss" runat="server" Text="DAILY ATTENDANCE STATUS REPORT" SkinID="lblRepRsz"
                                Width="500" Visible="True"></asp:Label>
                        </h1>
                        <br>
                    </center>
                    <center>
                        <table class="custTable">
                            <%-- <tr>
                                <td align="right">
                                    <asp:Label ID="lblYear" runat="server" Text="Academic Year*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="170px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlYearName" TabIndex="3" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        DataSourceID="ObjYear" DataTextField="AcademicYear" DataValueField="A_Code" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjYear" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetYear" TypeName="DLReportsR"></asp:ObjectDataSource>
                                </td>
                            </tr>--%>
                           
                             <tr>
                            <td align="right" >
                                <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td>
                                <asp:ListBox ID="ListBatch" Height="100px" Width="250px" SelectionMode="Multiple"  AutoPostBack ="True"
                                    DataValueField="BatchID" DataTextField="Batch_No" runat="server" DataSourceID="ObjBatch"
                                    TabIndex="3" CssClass="Listbox"></asp:ListBox>
                            </td>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboReport2"
                                TypeName="RptDeptWiseConsolidatedFeedbackScore">
                               
                            </asp:ObjectDataSource>
                        </tr>
                         <tr>
                                <td align="right">
                                    <asp:Label ID="lblSemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" TabIndex="3" runat="server" AutoPostBack="True"
                                        DataSourceID="ObjSemester" DataTextField="SemName" DataValueField="SemCode" Width="200"
                                        SkinID="ddlRsz">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboAss"
                                        TypeName="FeeCollectionBL">
                                       <%-- <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>--%>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                             <tr>
                            <td align="right">
                                <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFromDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="6" MaxLength="11"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtFromDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblToDate" runat="server" SkinID="lbl" Text="To Date :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtToDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                    TabIndex="7" MaxLength="11"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                           
                          
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnReport" runat="server" OnClientClick="return Validate1();" TabIndex="10" Text="REPORT" SkinID="btn" CommandName="REPORT"
                                        CssClass="ButtonClass" ></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" TabIndex="11" Text="BACK" CommandName="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <div>
                                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>


