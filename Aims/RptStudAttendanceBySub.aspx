<%@ Page Language="VB" AutoEventWireup="false" 
CodeFile="RptStudAttendanceBySub.aspx.vb" Inherits="RptStudAttendanceBySub" 
title="Student Attendance By Subject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Attendance By Subject</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <asp:Label ID="LabelStdAt" runat="server" Text="STUDENT ATTENDANCE BY SUBJECT" SkinID="lblRepRsz"
                         Visible="True"></asp:Label>
                </center>
                <center>
                    <br />
                    <br />
                    <table id="table1" class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBranch" runat="server" Text="Branch* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" DataSourceID="ObjBranch"
                                    DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlL" TabIndex="1"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" Text="Subject* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbSubject" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                    DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="250" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td align="right">
                                <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFromDateExt" MaxLength="11" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <ajaxToolkit:CalendarExtender ID="FromDateExt" runat="server" TargetControlID="txtFromDateExt"
                            Format="dd-MMM-yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                            FilterType="Custom" TargetControlID="txtFromDateExt" FilterMode="InvalidChars"
                            InvalidChars="!@#$%^&*()_+={[}]|\;:<>,.">
                        </ajaxToolkit:FilteredTextBoxExtender>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblToDate" runat="server" SkinID="lbl" Text="To Date* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtToDateExt" MaxLength="11" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Custom" TargetControlID="txtToDateExt" FilterMode="InvalidChars"
                                    InvalidChars="!@#$%^&*()_+={[}]|\;:<>,.">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                         
                    <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" DataSourceID="ObjStudent"
                                    DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="5"
                                    AppendDataBoundItems="False" Width="250">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCategory" runat="server" SkinID="lblRsz" Text="Student Category :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlcategry" runat="server" DataSourceID="ObjCategory" DataTextField="CategoryName"
                                    DataValueField="Category_Id" SkinID="ddlRsz" Width="185" TabIndex="6">
                                    <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                                </asp:DropDownList>
                             </td>
                        </tr>
                    <tr>
                            <td align="right">
                                <asp:Label ID="lblMin" runat="server" SkinID="lbl" Text="Min Percentage :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlMin" runat="server" SkinID="ddl" TabIndex="6">
                                    <asp:ListItem Text="0" Value="0.0"></asp:ListItem>
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                    <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                    <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                    <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                    <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                    <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                    <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                    <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                    <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                    <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                    <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                    <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                    <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                    <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                    <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                    <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                    <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                    <asp:ListItem Text="61" Value="61"></asp:ListItem>
                                    <asp:ListItem Text="62" Value="62"></asp:ListItem>
                                    <asp:ListItem Text="63" Value="63"></asp:ListItem>
                                    <asp:ListItem Text="64" Value="64"></asp:ListItem>
                                    <asp:ListItem Text="65" Value="65"></asp:ListItem>
                                    <asp:ListItem Text="66" Value="66"></asp:ListItem>
                                    <asp:ListItem Text="67" Value="67"></asp:ListItem>
                                    <asp:ListItem Text="68" Value="68"></asp:ListItem>
                                    <asp:ListItem Text="69" Value="69"></asp:ListItem>
                                    <asp:ListItem Text="70" Value="70"></asp:ListItem>
                                    <asp:ListItem Text="71" Value="71"></asp:ListItem>
                                    <asp:ListItem Text="72" Value="72"></asp:ListItem>
                                    <asp:ListItem Text="73" Value="73"></asp:ListItem>
                                    <asp:ListItem Text="74" Value="74"></asp:ListItem>
                                    <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                    <asp:ListItem Text="76" Value="76"></asp:ListItem>
                                    <asp:ListItem Text="77" Value="77"></asp:ListItem>
                                    <asp:ListItem Text="78" Value="78"></asp:ListItem>
                                    <asp:ListItem Text="79" Value="79"></asp:ListItem>
                                    <asp:ListItem Text="80" Value="80"></asp:ListItem>
                                    <asp:ListItem Text="81" Value="81"></asp:ListItem>
                                    <asp:ListItem Text="82" Value="82"></asp:ListItem>
                                    <asp:ListItem Text="83" Value="83"></asp:ListItem>
                                    <asp:ListItem Text="84" Value="84"></asp:ListItem>
                                    <asp:ListItem Text="85" Value="85"></asp:ListItem>
                                    <asp:ListItem Text="86" Value="86"></asp:ListItem>
                                    <asp:ListItem Text="87" Value="87"></asp:ListItem>
                                    <asp:ListItem Text="88" Value="88"></asp:ListItem>
                                    <asp:ListItem Text="89" Value="89"></asp:ListItem>
                                    <asp:ListItem Text="90" Value="90"></asp:ListItem>
                                    <asp:ListItem Text="91" Value="91"></asp:ListItem>
                                    <asp:ListItem Text="92" Value="92"></asp:ListItem>
                                    <asp:ListItem Text="93" Value="93"></asp:ListItem>
                                    <asp:ListItem Text="94" Value="94"></asp:ListItem>
                                    <asp:ListItem Text="95" Value="95"></asp:ListItem>
                                    <asp:ListItem Text="96" Value="96"></asp:ListItem>
                                    <asp:ListItem Text="97" Value="97"></asp:ListItem>
                                    <asp:ListItem Text="98" Value="98"></asp:ListItem>
                                    <asp:ListItem Text="99" Value="99"></asp:ListItem>
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMax" runat="server" SkinID="lblRsz" Text="Max Percentage :&nbsp;&nbsp;"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlMax" runat="server" SkinID="ddl" TabIndex="7">
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                    <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                    <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                    <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                    <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                    <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                    <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                    <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                    <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                    <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                    <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                    <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                    <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                    <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                    <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                    <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                    <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                    <asp:ListItem Text="61" Value="61"></asp:ListItem>
                                    <asp:ListItem Text="62" Value="62"></asp:ListItem>
                                    <asp:ListItem Text="63" Value="63"></asp:ListItem>
                                    <asp:ListItem Text="64" Value="64"></asp:ListItem>
                                    <asp:ListItem Text="65" Value="65"></asp:ListItem>
                                    <asp:ListItem Text="66" Value="66"></asp:ListItem>
                                    <asp:ListItem Text="67" Value="67"></asp:ListItem>
                                    <asp:ListItem Text="68" Value="68"></asp:ListItem>
                                    <asp:ListItem Text="69" Value="69"></asp:ListItem>
                                    <asp:ListItem Text="70" Value="70"></asp:ListItem>
                                    <asp:ListItem Text="71" Value="71"></asp:ListItem>
                                    <asp:ListItem Text="72" Value="72"></asp:ListItem>
                                    <asp:ListItem Text="73" Value="73"></asp:ListItem>
                                    <asp:ListItem Text="74" Value="74"></asp:ListItem>
                                    <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                    <asp:ListItem Text="76" Value="76"></asp:ListItem>
                                    <asp:ListItem Text="77" Value="77"></asp:ListItem>
                                    <asp:ListItem Text="78" Value="78"></asp:ListItem>
                                    <asp:ListItem Text="79" Value="79"></asp:ListItem>
                                    <asp:ListItem Text="80" Value="80"></asp:ListItem>
                                    <asp:ListItem Text="81" Value="81"></asp:ListItem>
                                    <asp:ListItem Text="82" Value="82"></asp:ListItem>
                                    <asp:ListItem Text="83" Value="83"></asp:ListItem>
                                    <asp:ListItem Text="84" Value="84"></asp:ListItem>
                                    <asp:ListItem Text="85" Value="85"></asp:ListItem>
                                    <asp:ListItem Text="86" Value="86"></asp:ListItem>
                                    <asp:ListItem Text="87" Value="87"></asp:ListItem>
                                    <asp:ListItem Text="88" Value="88"></asp:ListItem>
                                    <asp:ListItem Text="89" Value="89"></asp:ListItem>
                                    <asp:ListItem Text="90" Value="90"></asp:ListItem>
                                    <asp:ListItem Text="91" Value="91"></asp:ListItem>
                                    <asp:ListItem Text="92" Value="92"></asp:ListItem>
                                    <asp:ListItem Text="93" Value="93"></asp:ListItem>
                                    <asp:ListItem Text="94" Value="94"></asp:ListItem>
                                    <asp:ListItem Text="95" Value="95"></asp:ListItem>
                                    <asp:ListItem Text="96" Value="96"></asp:ListItem>
                                    <asp:ListItem Text="97" Value="97"></asp:ListItem>
                                    <asp:ListItem Text="98" Value="98"></asp:ListItem>
                                    <asp:ListItem Text="99" Value="99"></asp:ListItem>
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                      <tr>
                            <td align="right">
                                <asp:Label ID="lblSort" runat="server" SkinID="lblRsz" Width="200px" Text="Sort By :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" TabIndex="12">
                                    <asp:ListItem Value="0">Student Name</asp:ListItem>
                                    <asp:ListItem Value="1">Student Code</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;<ajaxToolkit:CalendarExtender ID="ToDateExt" runat="server" TargetControlID="txtToDateExt"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                         <tr>
                            <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                    TabIndex="12" Text="SUMMARY REPORT" CommandName="SUMMARY" Width="150px" Visible="true" />
                                <asp:Button ID="BtnDetRpt" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                    TabIndex="13" Text="DETAILED REPORT" CommandName="DETAILED" Visible="true" Width="150px" />
                                &nbsp;<asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                    TabIndex="14" Text="BACK" CommandName="BACK" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" BackColor="Green" ForeColor="White"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <div>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </div>
                        <caption>
                            &nbsp;<%--<asp:RequiredFieldValidator id="RequiredFieldValidator1" tabIndex="1" runat="server" ValidationGroup="Submit" ErrorMessage="Subject Field Null" ControlToValidate="cmbBatch">*</asp:RequiredFieldValidator>--%>
                            <tr>
                            <td>
                                
                        <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                             SelectMethod="SelectBranch" TypeName="DLStudAttendBySub"></asp:ObjectDataSource>
                     
                        <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectAll1"
                                   TypeName="DLStudAttendBySub">
                             <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" PropertyName="SelectedValue"
                                   Type="String" />      
                             </SelectParameters>
                        </asp:ObjectDataSource>      
                            
                        <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo1"
                                    TypeName="DLStudAttendBySub">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                         </asp:ObjectDataSource>
                        
                         <asp:ObjectDataSource ID="ObjCategory" runat="server" SelectMethod="GetCategoryALL"
                                    TypeName="DLStudAttendBySub"></asp:ObjectDataSource>       
                     </td>
                  </tr>
             <tr>
                                <td>
                                    <center>
                                        <div>
                                            <asp:ValidationSummary ID="ValidationSummary4" runat="server" DisplayMode="List"
                                                EnableTheming="false" EnableViewState="false" ShowMessageBox="true" ShowSummary="false"
                                                TabIndex="1" ValidationGroup="Save" />
                                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" EnableViewState="False"
                                                TabIndex="-1" ValidationGroup="Submit" />
                                        </div>
                                    </center>
                                </td>
                            </tr>
                        </caption>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

             

