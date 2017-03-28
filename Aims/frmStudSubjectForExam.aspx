<%@ Page Title="StudentSubject for Exam" Language="VB" 
    AutoEventWireup="false" CodeFile="frmStudSubjectForExam.aspx.vb" Inherits="frmStudSubjectForExam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>StudentSubject for Exam</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
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
                    STUDENT SUBJECT FOR EXAM
                </h1>
            </center>
            <br />
            <br />
            <asp:Panel ID="ControlsPanel" runat="server">
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblExamBatch" runat="server" Text="Exam Batch*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlExamBatch" runat="server" DataSourceID="ObjExamBatch" DataTextField="ExamBatch"
                                    DataValueField="ExamBatch_Autoid" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true"
                                    Width="230">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjExamBatch" runat="server" SelectMethod="GetExamBatch"
                                    TypeName="DLStudSubjectForExam"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="right">
                                <asp:Label ID="lblBranch" runat="server" Text="Branch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="ObjExamBranch" DataTextField="BranchName"
                                    DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="2" Width="230" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjExamBranch" runat="server" SelectMethod="GetExamBranch"
                                    TypeName="DLStudSubjectForExam">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlExamBatch" Name="BranchCode" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatch" runat="server" DataSourceID="ObjBatch" DataTextField="Batch_No"
                                        DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2" AutoPostBack="true" Width="230">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatch" TypeName="DLStudSubjectForExam">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSem" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px">
                                </asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlsemester" SkinID="ddlRsz" runat="server" DataSourceID="ObjSemester"
                                    DataTextField="SemName" DataValueField="SemCode" AutoPostBack="True" TabIndex="3"
                                    Width="240px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterComboD1"
                                    TypeName="DLStudSubjectForExam">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatch" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>--%>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table>
                        <tr>
                            <td align="left">
                                &nbsp;<asp:Button ID="btnGen" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                    SkinID="btnRsz" Width="210px" TabIndex="4" Text="GENERATE STUDENT SUBJECT" />
                            </td>
                            <td align="left">
                                &nbsp;<asp:Button ID="btnClear" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="6" Text="CLEAR" OnClientClick="return confirm('Do you want to delete the selected record(s)?')" />
                            </td>
                            <td align="left">
                                &nbsp;<asp:Button ID="btnLockunlk" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btnRsz" Width="120" TabIndex="7" Text="LOCK/UNLOCK" />
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <center>
                    <div>
                        <center>
                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </center>
                    </div>
                </center>
                <br />
                <center>
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                </center>
                <br />
                <center>
            </asp:Panel>
            <center>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false" DefaultButton ="btnPassword">
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
            <a name="Bottom">
                <div align="right">
                    <a href="#Top">
                        <asp:Image ID="Image1" runat="server" Height="30px" ImageUrl="Images/top.png" Width="30px" />
                    </a>
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

