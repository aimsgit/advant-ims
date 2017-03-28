<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStdAttdDetails.aspx.vb"
    Inherits="frmStdAttdDetails" Title="Student Attendance Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Attendance Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">  

function ShowImage2()
{
GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

 }
function HideImage2()
{
 GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
}    
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
    <div>
        <center>
            <h1 class="headingTxt">
                STUDENT ATTENDANCE DETAILS
            </h1>
        </center>
        <center> </center>
        <center>
        <table border="1em" width="70%">
        <tr><td align="left"><asp:Label ID="Label7" runat="server" ForeColor="Green" Text=" * For one Student, enter student code only and select date."></asp:Label></td></tr><tr><td align="left"><asp:Label ID="Label8" runat="server" ForeColor="Green" Text=" * For attendance of all Students in one course select Course, Academic Year, Semester, Subject and Assessment. Then select date."></asp:Label></td></tr></table>
            <table class="custTable">
               <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Student Code :&nbsp;&nbsp;" SkinID="lbl"></asp:Label></td>
                        <td>
                           <%-- <asp:TextBox ID="txtStdCode" TabIndex="8" runat="server" __designer:wfdid="w21" SkinID="txt"
                                MaxLength="13" AutoCompleteType="Disabled"></asp:TextBox>--%>
                           <asp:TextBox id="txtStdCode" runat="server" SkinID="txt" AutoPostBack="True" 
                                Enabled="True"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender id="AutoCompleteExtender3" runat="Server" TargetControlID="txtStdCode" EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="getStudentExt" ServicePath="TextBoxExt.asmx" FirstRowSelected="true" CompletionInterval="2000" onclientpopulated="HideImage2" onclientpopulating="ShowImage2">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender3" watermarkText="Type first 3 characters" runat="server" SkinID="watermark" TargetControlID="txtStdCode">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                   <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td>
                            <%-- <asp:DropDownList ID="CmbCource" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Select1"
                            DataTextField="Name" DataValueField="ID" SkinID="ddlL" TabIndex="3" DataSourceID="ObjCourse">
                        </asp:DropDownList>--%>
                            <asp:DropDownList ID="ddlCourse" runat="server" SkinID="ddl" AutoPostBack="True"
                                    DataTextField="CourseName" DataValueField="Course_ID" DataSourceID="ObjCourse">
                                </asp:DropDownList>
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" Text="Academic Year* :&nbsp;&nbsp;" __designer:wfdid="w8" SkinID="lbl"></asp:Label></td>
                        <td>
                            <%--<asp:DropDownList ID="CmbBatch" runat="server" DataSourceID="odsBatch" AutoPostBack="true"
                            SkinID="ddl" DataTextField="BatchName" DataValueField="BatchID" TabIndex="5">
                        </asp:DropDownList>--%>
                             <asp:DropDownList ID="cmbBatch" TabIndex="1" runat="server" SkinID="ddl" AutoPostBack="True"
                                    DataValueField="ID" DataTextField="Batch_No" DataSourceID="ObjBatch">
                                </asp:DropDownList>
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="Semester* :&nbsp;&nbsp;" __designer:wfdid="w11" SkinID="lbl"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbAssementType" TabIndex="4" runat="server" __designer:wfdid="w12"
                                SkinID="ddl" DataValueField="SemCode" DataTextField="SemName" 
                                DataSourceID="cmbSemster">
                            </asp:DropDownList>
                            <asp:RadioButton ID="RBSemWiseChk" runat="server" GroupName="RDLIST" AutoPostBack="true">
                            </asp:RadioButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Subject* :&nbsp;&nbsp;" __designer:wfdid="w16" SkinID="lbl"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="cmbSubject" TabIndex="6" runat="server" SkinID="ddl"
                                DataValueField="Subject_Code" DataTextField="Subject_Name" 
                                DataSourceID="ObjSubject">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblassessment" runat="server" Text="Assessment* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlAssessment" TabIndex="6" runat="server" SkinID="ddl"
                                DataValueField="ID" DataTextField="AssessmentType" DataSourceID="ObjAsset">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label10" runat="server" Text="Select Attd. Date :&nbsp;&nbsp;" __designer:wfdid="w13"
                                SkinID="lbl" meta:resourcekey="Label8Resource1"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="TxtAttdate" TabIndex="6" runat="server" __designer:wfdid="w14" SkinID="txt"
                                AutoPostBack="true"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CE1" runat="server" __designer:wfdid="w15" TargetControlID="TxtAttdate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                            <asp:RadioButtonList ID="RDLIST" runat="server" AutoPostBack="true">
                            </asp:RadioButtonList>
                            <asp:RadioButton ID="RBDateChk" runat="server" GroupName="RDLIST" AutoPostBack="true"
                                Checked="true"></asp:RadioButton></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Month* :&nbsp;&nbsp;" __designer:wfdid="w18" SkinID="lbl"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="cmbMonth" TabIndex="7" runat="server" __designer:wfdid="w19"
                                SkinID="ddl">
                                <asp:ListItem Value="1" Selected="true">Jan</asp:ListItem>
                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">Jun</asp:ListItem>
                                <asp:ListItem Value="7">Jul</asp:ListItem>
                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RadioButton ID="RBMonthChk" runat="server" GroupName="RDLIST" AutoPostBack="true">
                            </asp:RadioButton></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="Year :&nbsp;&nbsp;" __designer:wfdid="w22" SkinID="lbl"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtYear" TabIndex="9" runat="server" __designer:wfdid="w23" SkinID="txt"></asp:TextBox>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" __designer:wfdid="w25"
                                ValidationGroup="Submit" ErrorMessage="Semester Field Null" ControlToValidate="cmbAssementType">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div>
                                <asp:ValidationSummary ID="ValidationSummary1" TabIndex="-1" runat="server" __designer:wfdid="w28"
                                    ValidationGroup="Submit" EnableViewState="False"></asp:ValidationSummary>
                            </div>
                        </td>
                    </tr>
                
            </table>
            <div>
                <asp:GridView ID="GVStdAttd" runat="server" SkinID="GridView" DataKeyNames="AttendanceID"
                    EmptyDataText="No Rows to Display" PageSize="20" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="true" CommandName="Update"
                                    Text="Update" ValidationGroup="Save"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:LinkButton>
                                <asp:HiddenField ID="StdId" runat="server" Value='<%#Bind("StdId")%>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="Button3" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')"
                                    TabIndex="10" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code">
                            <ItemTemplate>
                                <%#Eval("StdCode")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("StdName")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Class" visible=false>
                            <ItemTemplate>
                                <%#Eval("TotalClass") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <%#Eval("TotalClass") %>
                                <%--<asp:TextBox ID="txtWorkingDays" runat="server" Width="70px" AutoCompleteType="Disabled"
                                    Enabled="false" Text='<%#Bind("TotalClass") %>' TabIndex="-1"></asp:TextBox>--%>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Present">
                            <ItemTemplate>
                                <asp:CheckBox ID="txtPresent" runat="Server" Checked='<%#Bind("TotalAttendance")%>'
                                    Enabled="false"></asp:CheckBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="txtPresent" runat="Server" Checked='<%#Bind("TotalAttendance")%>'
                                    Enabled="true"></asp:CheckBox>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Attendance Count">
                            <ItemTemplate>
                                <%#Eval("TotalAttendance")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <%#Eval("TotalAttendance")%>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Month" Visible="false">
                            <ItemTemplate>
                                <%#Eval("Month1")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <%#Eval("Month1")%>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Year" Visible="false">
                            <ItemTemplate>
                                <%#Eval("Year")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <%#Eval("Year")%>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <table>
                <tbody>
                    <tr>
                        <td class="btnTd" colspan="4">
                            <%--<asp:Button id="btnBack" tabIndex=13 runat="Server" Text="BACK" __designer:wfdid="w30" SkinID="btn" CssClass="btnStyle"></asp:Button>--%>
                            <asp:Button ID="btnSubmit" TabIndex="10" runat="server" Text="SUBMIT" __designer:wfdid="w31"
                                SkinID="btn" ValidationGroup="Submit" CssClass="btnStyle"></asp:Button>
                            <asp:Button ID="btnReport" TabIndex="11" runat="server" Text="REPORT" __designer:wfdid="w32"
                                SkinID="btn" CssClass="btnStyle"></asp:Button>
                            <!--<asp:Button id="btnRecover" tabIndex=12 runat="server" Text="RECOVER" SkinID="btn" CssClass="btnStyle" __designer:wfdid="w33"></asp:Button>-->
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblmsg" runat="server" Width="300px" __designer:wfdid="w34" ForeColor="red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ObjectDataSource ID="objGridView" runat="server" __designer:wfdid="w35" OldValuesParameterFormatString="original_{0}"
                                UpdateMethod="GetByUpdateStdAttd" DeleteMethod="GetByDeleteStd" DataObjectTypeName="Attendance.StdAttendanceP"
                                TypeName="Attendance.StdAttendanceB" SelectMethod="GetStdAttdDetails">
                                <SelectParameters>
                                    <asp:SessionParameter Name="InsId" SessionField="InstituteID" Type="Int64" />
                                    <asp:SessionParameter Name="BrnId" SessionField="BranchID" Type="Int64" />
                                    <asp:Parameter Name="CrsId" />
                                    <asp:Parameter Name="batchno" />
                                    <asp:ControlParameter ControlID="cmbMonth" Name="monthId" PropertyName="SelectedValue"
                                        Type="int32" />
                                    <asp:ControlParameter ControlID="cmbSubject" Name="SubjectId" PropertyName="SelectedValue"
                                        Type="int32" />
                                    <asp:ControlParameter ControlID="txtYear" Name="yeari" Type="int32" />                                    
                                    <asp:Parameter Name="StdCode" />
                                    <asp:ControlParameter ControlID="cmbAssementType" Name="SemsterId" PropertyName="SelectedValue"
                                        Type="int32" />
                                    <asp:ControlParameter ControlID="TxtAttdate" Name="attdate" Type="DateTime" />
                                    <asp:ControlParameter ControlID="ddlAssessment" Name="Assessment_ID" PropertyName="SelectedValue"
                                        Type="int32" />
                                    <asp:ControlParameter ControlID="RBSemWiseChk" Name="SemesterWise" Type="boolean" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="StdId" Type="int64" />
                                    <asp:SessionParameter Name="InsId" SessionField="InstituteID" Type="Int64" />
                                    <asp:SessionParameter Name="BrnId" SessionField="BranchID" Type="Int64" />
                                    <asp:Parameter Name="Courseid" Type="int64" />
                                    <asp:Parameter Name="SubjectId" Type="int64" />
                                    <asp:Parameter Name="Month" Type="int32" />
                                    <asp:Parameter Name="Year" Type="int32" />
                                    <asp:Parameter Name="Batch" Type="int64" />
                                    <asp:Parameter Name="SemsterId" Type="int64" />
                                    <asp:Parameter Name="AttendanceDate" Type="datetime" />
                                    <asp:Parameter Name="Assessment_ID" Type="int32" />
                                    <asp:Parameter Name="Original_AttendanceID" Type="int32" />
                                    <asp:Parameter Name="TotalAttendance" Type="boolean" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="cmbSemster" runat="server" __designer:wfdid="w38" TypeName="SemesterManager"
                                SelectMethod="GetSemesterCombo"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjCourse" runat="server" TypeName="CourseDB" SelectMethod="GetDtaCourse">
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" TypeName="BatchDB" SelectMethod="GetDtaBatch">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCourse" PropertyName="SelectedValue" Name="Course_ID"
                                            DefaultValue="0" Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" TypeName="SubjectManager" SelectMethod="GetSubject">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCourse" PropertyName="SelectedValue" Name="Course_ID"
                                            DefaultValue="0" Type="Int16" />
                                        <asp:ControlParameter ControlID="cmbBatch" PropertyName="SelectedValue" Name="Batch_No"
                                            DefaultValue="0" Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjAsset" runat="server" TypeName="SemesterManager" SelectMethod="getData2">
                                </asp:ObjectDataSource>
                        </td>
                    </tr>
                </tbody>
            </table>
        </center>
        
        
    </div>
    </contenttemplate>
        <triggers>
<asp:AsyncPostBacktrigger ControlID="btnSubmit" EventName="Click"></asp:AsyncPostBacktrigger>
</triggers>
    </asp:UpdatePanel>

</form>
</body>
</html>