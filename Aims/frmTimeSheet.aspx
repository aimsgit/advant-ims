<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmTimeSheet.aspx.vb"
    Inherits="frmTimeSheet" Title="Time Sheet" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Time Sheet</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlEmployeeName.ClientID%>"), 'Employee Name');
            if (msg != "") {
                document.getElementById("<%=ddlEmployeeName.ClientID%>");
                return msg;
            }
//            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID%>"), 'Batch');
//            if (msg != "") {
//                document.getElementById("<%=ddlBatchName.ClientID%>");
//                return msg;
//            }
//            msg = DropDownForZero(document.getElementById("<%=ddlSemester.ClientID%>"), 'Semester');
//            if (msg != "") {
//                document.getElementById("<%=ddlSemester.ClientID%>");
//                return msg;
//            }
//            msg = DropDownForZero(document.getElementById("<%=ddlSubject.ClientID%>"), 'Subject');
//            if (msg != "") {
//                document.getElementById("<%=ddlSubject.ClientID%>");
//                return msg;
//            }

            msg = ValidateDateN(document.getElementById("<%=txtDate.ClientID%>"), 'Date');
            if (msg != "") {
                document.getElementById("<%=txtDate.ClientID%>").focus();
                return msg;
            }

            msg = Numeric(document.getElementById("<%=txtDate.ClientID%>"), 'Duration');
            if (msg != "") {
                document.getElementById("<%=txtDuration.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
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
                        TIME SHEET</h1>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmployee" runat="server" SkinID="lblRsz" Text="Employee Name*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEmployeeName" runat="server" AppendDataBoundItems="true"
                                    AutoPostBack="true" DataSourceID="ObjEmployee" DataTextField="EmpName" DataValueField="EmpID"
                                    SkinID="ddlRsz" TabIndex="1" Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmployee" runat="server" SelectMethod="GetEmployeeCombo"
                                    TypeName="LessonPlanDL"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBatchName" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="LessonPlanDL">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" DataSourceID="ObjSemester"
                                    DataTextField="SemName" DataValueField="SemCode" SkinID="ddlRsz" TabIndex="3"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboD1"
                                    TypeName="LessonPlanDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" DataSourceID="ObjSubject"
                                    DataTextField="Subject_Name" DataValueField="Subjectid" SkinID="ddlRsz" TabIndex="4"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject" TypeName="LessonPlanDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSemester" PropertyName="SelectedValue" Name="Sem"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTopic" runat="server" Text="Topic^ :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlTopic" runat="server" AutoPostBack="true" DataSourceID="ObjTopic"
                                    DataTextField="Topic" DataValueField="LPAutoID" SkinID="ddlRsz" TabIndex="5"
                                    Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjTopic" runat="server" SelectMethod="TopicCombo" TypeName="TimeSheetDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSubject" PropertyName="SelectedValue" Name="Subjectid"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblDate" runat="server" Text="Date^ :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTime" runat="server" Text="Time :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTime" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtTime" />
                            </td>
                            <td align="right">
                                <asp:Label ID="lblPeriod" runat="server" Text="Period :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPeriod" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDuration" runat="server" Text="Duration(Hrs) :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDuration" runat="server" SkinID="txt" TabIndex="9" MaxLength="15"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ValidChars="1234567890." runat="server" TargetControlID="txtDuration">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblWorkDescription" runat="server" Text="Work Description :&nbsp;&nbsp"
                                    Width="180" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWorkDescription" runat="server" TextMode="MultiLine" SkinID="txt"
                                    TabIndex="10"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="BtnAdd" runat="server" SkinID="btn" Text="ADD" OnClientClick="return Validate();"
                        TabIndex="11" CssClass="ButtonClass" />
                    <asp:Button ID="BtnView" runat="server" SkinID="btn" Text="VIEW" TabIndex="12" CssClass="ButtonClass" />
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"> </asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"> </asp:Label>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="True"
                            AutoGenerateColumns="False" PageSize="100" AllowSorting="True">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            TabIndex="10" Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            TabIndex="11" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" SortExpression="date" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate1" runat="server" Width="100" Text='<%# Bind("date","{0:dd-MMM-yyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Period" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod1" runat="server" Width="100" Text='<%# Bind("Period") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Duration (Hrs)" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" SortExpression="Subject_Name" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                        <asp:Label ID="lblSubjectID" runat="server" Visible="false" Text='<%# Bind("SubjectID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Topic" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTopic" runat="server" Width="200" Text='<%# Bind("Topic") %>'></asp:Label>
                                        <asp:Label ID="lblTopicID" runat="server" Visible="false" Text='<%# Bind("TopicID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTime" runat="server" Width="100" Text='<%# Bind("Time","{0:hh:mm tt}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="TPID" runat="server" Visible="false" Text='<%# Bind("TSAUTOID") %>'></asp:Label>
                                        <asp:Label ID="lblEmpName" runat="server" Width="175" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        <asp:Label ID="lblEmpID" runat="server" Visible="false" Text='<%# Bind("EmpID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpCode" Width="100" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Work Description" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWorkDescription" runat="server" Width="200" Text='<%# Bind("WorkDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Batch" SortExpression="Batch_No" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="LblBatch" runat="server" Width="100" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                        <asp:Label ID="lblBatchID" runat="server" Visible="false" Text='<%# Bind("BatchID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Semester" SortExpression="SemName" HeaderStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSem" runat="server" Width="100" Text='<%# Bind("SemName") %>'></asp:Label>
                                        <asp:Label ID="lblSemID" runat="server" Visible="false" Text='<%# Bind("SemID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image3" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
