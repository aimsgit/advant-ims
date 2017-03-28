<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSemesterResultAnalysis.aspx.vb"
    Inherits="frmSemesterResultAnalysis" Title="Semester Result Analysis" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Semester Result Analysis</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>


    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;



            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlsemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=ddlsemester.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlassesment.ClientID %>"), 'Assessment');
            if (msg != "") {
                document.getElementById("<%=ddlassesment.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }

    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server" Text="SEMESTER RESULT ANALYSIS"></asp:Label>
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table class="custTable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblA_Year" runat="server" Text="Academic Year*&nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz" Visible="false"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlA_Year" SkinID="ddlRsz" runat="server" DataSourceID="ObjAcademic"
                                DataTextField="AcademicYear" DataValueField="id" AutoPostBack="True" TabIndex="1"
                                Width="240px" Visible="false">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="2"
                                Width="240px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerComboSelect"
                                TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                            <%--<asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLNew_StudentMarks">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlA_Year" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                        Type="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
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
                            <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                TypeName="FeeCollectionBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblassesment" runat="server" Text="Assessment Type*&nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                DataTextField="AssessmentType" DataValueField="ID" TabIndex="4" Width="240px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btngenerate" runat="server" Text="GENERATE" SkinID="btnRsz" CssClass="ButtonClass"
                                Width="120px" OnClientClick="return Validate();" TabIndex="5" />
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
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblRed" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                            <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            Processing your request..Please wait...
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" Visible="false">
                    <center>
                        <table>
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblttlappeared" SkinID="lblRsz" Width="128px" runat="server" Text="Total Appeared :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblttlappearedAns" SkinID="lblRsz" Width="50px" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblttlpass" SkinID="lblRsz" Width="110px" runat="server" Text="Total Pass :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblttlpassans" SkinID="lblRsz" Width="50px" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <asp:Label ID="lbloverallpass" SkinID="lblRsz" Width="145px" runat="server" Text="Overall Pass (%) :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lbloverallpassans" SkinID="lblRsz" Width="50px" runat="server" Text=""></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblhighest" SkinID="lblRsz" Width="115px" runat="server" Text="Highest Total :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblhighestttl" SkinID="lblRsz" Width="180px" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </center>
                </asp:Panel>
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GrdSemResAna" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Subject Name" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblA_Code" runat="server" Text='<%# Bind("A_Code") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblCourse" runat="server" Text='<%# Bind("Course") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblSemester" runat="server" Text='<%# Bind("Semester") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblSubID" runat="server" Text='<%# Bind("SubID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblSubName" runat="server" Text='<%# Bind("SubName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject Code" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubName" runat="server" Text='<%# Bind("SubCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No of Students Appeared" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAppearedStudents" runat="server" Text='<%# Bind("AppearedStudents") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No of Students Passed" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPassStudents" runat="server" Text='<%# Bind("PassStudents") %>'></asp:Label>
                                                <asp:Label ID="lblFailStudents" runat="server" Text='<%# Bind("FailStudents") %>'
                                                    Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade1" runat="server" Text='<%# Bind("Grade1","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade2" runat="server" Text='<%# Bind("Grade2","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade3" runat="server" Text='<%# Bind("Grade3","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade4">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade4" runat="server" Text='<%# Bind("Grade4","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade5">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade5" runat="server" Text='<%# Bind("Grade5","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade6">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade6" runat="server" Text='<%# Bind("Grade6","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade7">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade7" runat="server" Text='<%# Bind("Grade7","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade8">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade8" runat="server" Text='<%# Bind("Grade8","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade9">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade9" runat="server" Text='<%# Bind("Grade9","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade10">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade1" runat="server" Text='<%# Bind("Grade10","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade11" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade11" runat="server" Text='<%# Bind("Grade11") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade12" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade12" runat="server" Text='<%# Bind("Grade12") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade13" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade13" runat="server" Text='<%# Bind("Grade13") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade14" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade14" runat="server" Text='<%# Bind("Grade14") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade15" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade15" runat="server" Text='<%# Bind("Grade15") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade16" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade16" runat="server" Text='<%# Bind("Grade16") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade17" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade17" runat="server" Text='<%# Bind("Grade17") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade18" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade18" runat="server" Text='<%# Bind("Grade18") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade19" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade1" runat="server" Text='<%# Bind("Grade19") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade20" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade20" runat="server" Text='<%# Bind("Grade20") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="% of Pass">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPassPercentage" runat="server" Text='<%# Bind("PassPercentage") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pass Count" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFailCount" runat="server" Text='<%# Bind("FailCount") %>'></asp:Label>
                                                <asp:Label ID="lblPassCount" runat="server" Text='<%# Bind("PassCount") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Faculty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPassPercent" runat="server" Text='<%# Bind("PassPercent") %>' Visible="false"></asp:Label></ItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaxTotal" runat="server" Text='<%# Bind("MaxTotal") %>' Visible="false"></asp:Label></ItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaxMarksTotal" runat="server" Text='<%# Bind("MaxMarksTotal") %>'
                                                    Visible="false"></asp:Label></ItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblStdIDTopper" runat="server" Text='<%# Bind("StdIDTopper") %>' Visible="false"></asp:Label></ItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>' Visible="false"></asp:Label></ItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblMaxMarksPercent" runat="server" Text='<%# Bind("MaxMarksPercent") %>'
                                                    Visible="false"></asp:Label></ItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFaculty" runat="server" Text='<%# Bind("Faculty") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    <center>
        <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
            SkinID="btnRsz" TabIndex="6" Text="EXPORT TO EXCEL" Width="170" />
    </center>

</form>
</body>
</html>

