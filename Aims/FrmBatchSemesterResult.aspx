<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmBatchSemesterResult.aspx.vb"
    Inherits="FrmBatchSemesterResult" Title="Semester Result" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Semester Result</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch No');
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=cmbSemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=cmbSemester.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlassesment.ClientID %>"), 'Assessment Type');
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
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
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
                        <%--  <h1 class="headingTxt">
                        SEMESTER RESULT</h1>--%>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <hr />
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="This form is used to calculate final semester result by adding the total from individual subject marks. Step 1: Select batch,semester and assessment type which will be used to find the final result.On Selection of these items, the grid shows the subjects for which the assessment was done.You can uncheck the subjects which are not counted for finals results e.g.some elective subjects which do not count in final result."
                                    SkinID="lblRSZ" Width="763"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <center>
                        <table>
                            <tr>
                                <td align="Right">
                                    <asp:Label ID="LblBatch" runat="server" Text="Select Batch* :&nbsp;&nbsp;" SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DdlBatch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="1" DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="objBatchPlanner"
                                        Width="200">
                                        <asp:ListItem Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objBatchPlanner" runat="server" SelectMethod="getBatchPlannerCombo"
                                        TypeName="DLBatchSemester"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSemester" TabIndex="3" runat="server" SkinID="ddl" DataValueField="SemCode"
                                        DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DdlBatch" PropertyName="SelectedValue" Name="Batch"
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
                                    <asp:DropDownList ID="ddlassesment" SkinID="ddl" runat="server" DataSourceID="ObjAssesment"
                                        DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                    TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:GridView ID="Gridsubject" runat="server" Width="500px" SkinID="GridView" AllowPaging="true"
                                        AutoGenerateColumns="False" Visible="false" PageSize="200" AllowSorting="True"
                                        EnableSortingAndPagingCallbacks="True" DataSourceID="ObjSubject">
                                        <Columns>
                                            <asp:TemplateField ControlStyle-Width="25px">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkPresent" Checked="true" runat="server" TabIndex="9" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Include Subject">
                                                <ItemTemplate>
                                                    <asp:Label ID="AssessType" runat="server" Text='<%# Bind("Subject_Name") %>' />
                                                    <asp:HiddenField ID="Label1" runat="server" Value='<%# Bind("Subject_Code") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectGridFinalResult"
                                        TypeName="DLNew_StudentMarks">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DdlBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                            <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table>
                            <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="8" Text="SUBMIT" />
                                <tr>
                                    <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                        <asp:Button ID="Button1" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="8" Text="SUBMIT"
                                            Visible="false" />
                                        <div>
                                            <center>
                                                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                                    <ProgressTemplate>
                                                        <div class="PleaseWait">
                                                          Processing your request..Please wait...
                                                        </div>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </center>
                                        </div>
                                    </td>
                                </tr>
                        </table>
                        <hr />
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" Text="Step 2: You can scroll to the right in the grid below to see Total marks,Grade etc columns are visible.Once you are satisfied that the marks shown in grid are from correct selection,click Fill Total button.This will fill the Total Marks column,percentage,Grade etc.Scroll through to the right and see that the calculations are showing correctly.Once verified,click on Update to finally save this data.  "
                                        SkinID="lblRSZ" Width="763"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td class="btnTd" style="height: 9px" align="right">
                                    <asp:Button ID="btnFillTotal" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="9" Text="FILL TOTAL" Visible="true" />
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btnrsz"
                                        TabIndex="9" Text="UPDATE" Visible="true" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                                </td>
                            </tr>
                            <div>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                        </table>
                        <asp:Panel ID="Panel2" runat="server" Height="250px" Width="750" ScrollBars="Auto">
                            <asp:GridView ID="GVStdAttd" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                SkinID="GridView" TabIndex="6" PageSize="10" OnRowDataBound="GVStdAttd_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Student Code">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HidCount" runat="server" Value='<%# Bind("count1") %>' />
                                            <asp:HiddenField ID="HidStdId" runat="server" Value='<%# Bind("StdId") %>' />
                                            <asp:HiddenField ID="HidBatch" runat="server" Value='<%# Bind("BatchCode") %>' />
                                            <asp:HiddenField ID="HidSEmid" runat="server" Value='<%# Bind("SemId") %>' />
                                            <asp:HiddenField ID="HidAssesmentId" runat="server" Value='<%# Bind("AssesmentId") %>' />
                                            <asp:Label ID="lblstdcode" runat="server" Text='<%# Bind("StudentCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" ControlStyle-Width="100">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstdname" runat="server" Text='<%# Bind("StudentName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                        <HeaderStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls12" runat="server" Text='<%# Bind("s1") %>'></asp:Label>
                                            <asp:Label ID="lblMax12" Visible="false" runat="server" Text='<%# Bind("Max12") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub12" runat="server" Text='<%# Bind("[1]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls1" runat="server" Text='<%# Bind("s2") %>'></asp:Label>
                                            <asp:Label ID="lblMax1" Visible="false" runat="server" Text='<%# Bind("Max1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub" runat="server" Text='<%# Bind("[2]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls23" runat="server" Text='<%# Bind("s3") %>'></asp:Label>
                                            <asp:Label ID="lblMax2" Visible="false" runat="server" Text='<%# Bind("Max2") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub1" runat="server" Text='<%# Bind("[3]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls3" runat="server" Text='<%# Bind("s4") %>'></asp:Label>
                                            <asp:Label ID="lblMax3" Visible="false" runat="server" Text='<%# Bind("Max3") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub2" runat="server" Text='<%# Bind("[4]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls4" runat="server" Text='<%# Bind("s5") %>'></asp:Label>
                                            <asp:Label ID="lblMax4" Visible="false" runat="server" Text='<%# Bind("Max4") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub3" runat="server" Text='<%# Bind("[5]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls5" runat="server" Text='<%# Bind("s6") %>'></asp:Label>
                                            <asp:Label ID="lblMax5" Visible="false" runat="server" Text='<%# Bind("Max5") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub4" runat="server" Text='<%# Bind("[6]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls6" runat="server" Text='<%# Bind("s7") %>'></asp:Label>
                                            <asp:Label ID="lblMax6" Visible="false" runat="server" Text='<%# Bind("Max6") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub5" runat="server" Text='<%# Bind("[7]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls7" runat="server" Text='<%# Bind("s8") %>'></asp:Label>
                                            <asp:Label ID="lblMax7" Visible="false" runat="server" Text='<%# Bind("Max7") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub6" runat="server" Text='<%# Bind("[8]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls8" runat="server" Text='<%# Bind("s9") %>'></asp:Label>
                                            <asp:Label ID="lblMax8" Visible="false" runat="server" Text='<%# Bind("Max8") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub7" runat="server" Text='<%# Bind("[9]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbls9" runat="server" Text='<%# Bind("s10") %>'></asp:Label>
                                            <asp:Label ID="lblMax9" Visible="false" runat="server" Text='<%# Bind("Max9") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsub8" runat="server" Text='<%# Bind("[10]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Max Marks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMaxMarks" runat="server" SkinID="txtRsz" Width="45px" Text='<%# Bind("MaxMarks") %>'></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtMaxMarks">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Marks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTotalMarks" runat="server" SkinID="txtRsz" Width="45px" Text='<%# Bind("TotalMarks") %>'
                                                ReadOnly="true"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtTotalMarks">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Marks with Grace">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMarkswithgrace" runat="server" TabIndex="30" SkinID="txtRsz"
                                                Width="45px" Text='<%# Bind("TotalMarks") %>'></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtMarkswithgrace">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Result">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPercentage" runat="server" SkinID="txtRsz" Width="45px" Text='<%# Bind("Result") %>'></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtPercentage">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Division">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtResult" runat="server" SkinID="txtRsz" Width="45px" Text='<%# Bind("Division") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rank">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRank" runat="server" SkinID="txtRsz" TabIndex="35" Width="45px"
                                                Text='<%# Bind("Rank") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
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
