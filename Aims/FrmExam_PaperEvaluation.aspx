<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmExam_PaperEvaluation.aspx.vb"
    Inherits="FrmExam_PaperEvaluation" Title="Paper Evaluation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Paper Evaluation</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlExamBatch.ClientID%>"), 'Exam Batch');
            if (msg != "") {
                document.getElementById("<%=ddlExamBatch.ClientID%>").focus();
                return msg;

            }
            msg = DropDownForZero(document.getElementById("<%=ddlSubject.ClientID%>"), 'Subject');
            if (msg != "") {
                document.getElementById("<%=ddlSubject.ClientID%>").focus();
                return msg;

            }
            msg = DropDownForZero(document.getElementById("<%=ddlFaculty.ClientID%>"), 'Faculty Name');
            if (msg != "") {
                document.getElementById("<%=ddlFaculty.ClientID%>").focus();
                return msg;

            }


            return true;

        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
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
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <br />
        <asp:Panel ID="ControlsPanel" runat="server">
            <center>
                <table class="custTable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblExamBatch" runat="server" Text="Exam Batch*&nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="150px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlExamBatch" runat="server" DataSourceID="ObjExamBatch" DataTextField="ExamBatch"
                                DataValueField="ExamBatch_Autoid" SkinID="ddlRsz" TabIndex="1" Width="250" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjExamBatch" runat="server" SelectMethod="GetExamBatch"
                                TypeName="DLExamResources"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSubject" runat="server" Text="Subject*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubject" runat="server" DataSourceID="ObjExamSubject" DataTextField="Subject_Name"
                                DataValueField="Subject_Id" SkinID="ddlRsz" TabIndex="2" Width="250" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjExamSUbject" runat="server" SelectMethod="GetExamSubjddl"
                                TypeName="DLExamPaperEvaluation">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlExamBatch" Name="Batch" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFaculty" runat="server" Text="Faculty Name*&nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="150px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlFaculty" runat="server" DataSourceID="ObjFaculty" DataTextField="Emp_Name"
                                DataValueField="ResourceNameId" SkinID="ddlRsz" TabIndex="3" Width="250" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjFaculty" runat="server" SelectMethod="GetExamFacultyddl"
                                TypeName="DLExamPaperEvaluation"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFrmSrlNo" runat="server" Text="From Serial No. &nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="180px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFrmSrlNo" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblToSrlNo" runat="server" Text="To Serial No. &nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="150px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtToSrlNo" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </center>
            <br/> <br/>
            <center>
                <table>
                    <tr>
                        <td class="btnTd" colspan="2">
                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="6"
                                Text="ADD" />
                            &nbsp;<asp:Button ID="btnView" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="7" Text="VIEW" />
                            &nbsp;<asp:Button ID="btnLockUnlock" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btnRsz" Width="120" TabIndex="8" Text="LOCK/UNLOCK" Enabled="False" />
                        </td>
                    </tr>
                </table>
            </center>
            <table>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <center>
                <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
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
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="800px" Height="300px">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:GridView ID="GrdExamPaperEvaluation" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" />
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Batch" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExamBatch" runat="server" Text='<%# Bind("ExamBatchId") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("ExamBatch") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject" Visible="true" SortExpression="Subject_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubjName" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                                <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Faculty Name" Visible="true" SortExpression="Emp_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblid" runat="server" Text='<%# Bind("PE_AutoId") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("EmpId") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Serial No." Visible="true" SortExpression="FrmSerialNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFrmSrlNo" runat="server" Text='<%# Bind("FrmSerialNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To Serial No." SortExpression="ToSerialNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblToSrlNo" runat="server" Text='<%# Bind("ToSerialNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lock Status" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLockUnlock" runat="server" Text='<%# Bind("LockUnlock") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
           </center>
        </asp:Panel>
        <center>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false" DefaultButton="btnPassword">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password"></asp:TextBox>
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
                            </tbody>
                        </table>
                    </center>
                </asp:Panel>
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                </asp:Panel>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>