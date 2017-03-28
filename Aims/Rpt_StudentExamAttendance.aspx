<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_StudentExamAttendance.aspx.vb" Inherits="Rpt_StudentExamAttendance"  Title="Student Examination Attendance"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Examination Attendance</title>
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
                        <br />
                        <h1 class="headingTxt">
                         STUDENT EXAM ATTENDANCE SHEET
                        </h1>
                        <br />
                        <br />
                    </center>
                    <center>
                    <table>
                     <tr>                       
                       <td align="right">
                          <asp:Label ID="lblExamName" runat="server" Text="Examination*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                       </td>
                       <td align="left">
                          <asp:DropDownList ID="ddlExamName" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Exam_Code"
                           DataTextField="Exam_Name" DataSourceID="ObjExam" Width="200px" 
                           AutoPostBack="True">
                       </asp:DropDownList>
                     </td>
                     </tr> 
                     
                     <tr>                       
                       <td align="right">
                          <asp:Label ID="lblSubject" runat="server" Text="Subject*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                       </td>
                       <td align="left">
                          <asp:DropDownList ID="ddlSubjectName" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                           DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="200px" 
                           AutoPostBack="True">
                       </asp:DropDownList>
                     </td>
                     </tr> 
                     
                                   
                     <tr>
                         <td align="right">
                         <asp:Label ID="lblExamDate" runat="server" Text="Exam Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                        Width="170px" meta:resourcekey="Label8Resource1"></asp:Label>
                        </td>
                       <td align="left">
                             <asp:TextBox ID="TxtExamdate" TabIndex="6" runat="server" SkinID="txt" 
                             AutoPostBack="True"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="TxtExamdate"
                                  Format="dd-MMM-yyyy" Enabled="True">
                            </ajaxToolkit:CalendarExtender>
                           <ajaxToolkit:MaskedEditExtender ID="Examdate" runat="server" ClearMaskOnLostFocus="False"
                                ClipboardEnabled="False" Mask="99-LLL-9999"
                                TargetControlID="TxtExamdate" CultureAMPMPlaceholder="" 
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                           </ajaxToolkit:MaskedEditExtender>
                       </td>
                     </tr> 
                     
                     <tr>                       
                       <td align="right" valign="top">
                          <asp:Label ID="lblExamCenter" runat="server" Text="Exam Center&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                       </td>
                       <td align="left">
                          <asp:DropDownList ID="ddlExamCenter" TabIndex="4" runat="server" SkinID="ddlRsz" 
                           DataTextField="Exam_CntName" DataValueField="Exam_CntCode"  DataSourceID="ObjExamCenter" Width="200px" AppendDataBoundItems="true" 
                           AutoPostBack="True">
                          <asp:ListItem Text="Select" Value="0" />   
                       </asp:DropDownList>
                     </td>
                     </tr> 
                     
                     <%--<tr>                       
                       <td align="right" valign="top">
                          <asp:Label ID="lblTime" runat="server" Text="Time of Exam :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                       </td>
                       <td align="left">
                          <asp:DropDownList ID="ddltime" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Time_Code"
                           DataTextField="Time_Name" DataSourceID="ObjTime" Width="200px" 
                           AutoPostBack="True">
                       </asp:DropDownList>
                     </td>
                     </tr> --%>
                      <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                             <tr>
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="9" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnAdd" TabIndex="11" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                        </table>
                        <center>
                            <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                        </center>
                      <asp:ObjectDataSource ID="ObjExam" runat="server" SelectMethod="GetExamination"
                                        TypeName="DLExamAttendance">
                                    </asp:ObjectDataSource>    
                                    
                     <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubComboBatchPlanner"
                                        TypeName="DLExamAttendance">
                                       <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlExamName" PropertyName="SelectedValue" Name="Exam"
                                                DbType="Int16" />
                                        </SelectParameters>                
                     </asp:ObjectDataSource>
                       
                     <asp:ObjectDataSource ID="ObjExamCenter" runat="server" SelectMethod="GetExamCenter"
                                        TypeName="DLExamAttendance">
                                    </asp:ObjectDataSource>                                           
                     <%--<asp:ObjectDataSource ID="ObjTime" runat="server" SelectMethod="GetTime"
                                        TypeName="DLExamAttendance">
                                    </asp:ObjectDataSource>               --%>                      
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>                         

</form>
</body>
</html>