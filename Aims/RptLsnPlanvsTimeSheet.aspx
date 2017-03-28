<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptLsnPlanvsTimeSheet.aspx.vb"
    Inherits="RptLsnPlanvsTimeSheet" Title="LESSON PLAN V/S TIME SHEET" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LESSON PLAN V/S TIME SHEET</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlBatchName.ClientID%>");
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlSemester.ClientID%>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=ddlSemester.ClientID%>");
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
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
 
   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
            <br />
                <h1 class="headingTxt">
                    LESSON PLAN V/S TIME SHEET
                </h1>
                <br />
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
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
                            <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*&nbsp;:&nbsp;&nbsp;"></asp:Label>
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
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" DataSourceID="ObjSubject"
                                DataTextField="Subject_Name" DataValueField="Subjectid" SkinID="ddlRsz" TabIndex="4"
                                Width="250">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectR" TypeName="LessonPlanDL">
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
                    <tr>
                        <td colspan="2" align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                Text="REPORT" SkinID="btn" TabIndex="5" CssClass="ButtonClass " />&nbsp;
                            <asp:Button ID="Btnback" runat="server" CausesValidation="True" SkinID="btn" TabIndex="6"
                                Text="BACK" CssClass="ButtonClass " />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>