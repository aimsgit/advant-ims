<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="RptElectivesMap.aspx.vb"
    Inherits="RptElectivesMap" Title="Electives Map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Electives Map</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlCourseName.ClientID %>"), 'Course');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID %>"), 'Batch');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlSemester.ClientID%>"), 'Semester');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlElective.ClientID%>"), 'Elective');
            if (msg != "") return msg;
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

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            ELECTIVES MAP
                            <br />
                            <br />
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" Text="Course*&nbsp;:&nbsp;&nbsp;" Width="100px"
                                        SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourseName" runat="server" DataSourceID="ObjCourse" AutoPostBack="true"
                                        DataTextField="CourseName" DataValueField="Courseid" SkinID="ddlRsz" AppendDataBoundItems="true"
                                        TabIndex="1" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourse" TypeName="CourseDB">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true"
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                        AppendDataBoundItems="false" Width="200">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="TimeTableDl">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" DefaultValue="0"
                                                Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblsemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" TabIndex="3" SkinID="ddlRsz" AutoPostBack="true"
                                        runat="server" DataSourceID="ObjSemester" DataTextField="SemName" DataValueField="SemCode"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblElective" runat="server" SkinID="lbl" Text="Elective*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlElective" runat="server" DataSourceID="ObjSubject" AutoPostBack="True"
                                        DataTextField="Subject_Name" DataValueField="Subject_Code" SkinID="ddlRsz" TabIndex="4"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject" TypeName="TimeTableDl">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatchName" Name="Batchid" PropertyName="SelectedValue"
                                                Type="Int16" />
                                            <asp:ControlParameter ControlID="ddlSemester" Name="SemId" PropertyName="SelectedValue"
                                                Type="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSort" runat="server" Text="Sort&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddlRsz" TabIndex="9">
                                        <asp:ListItem Value="0">Student Name</asp:ListItem>
                                        <asp:ListItem Value="1">Student Code</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="btnTd">
                                    <asp:Button ID="btnReport" TabIndex="5" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                    <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>

</form>
</body>
</html>