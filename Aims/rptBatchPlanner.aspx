<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptBatchPlanner.aspx.vb"
    Inherits="rptBatchPlanner" Title="Batch Planner Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Batch Planner Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlacadyear.ClientID%>"), 'Academic Year');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID%>"), 'Batch');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlsem.ClientID%>"), 'Semester');
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Labelbp" runat="server" Text="BATCH PLAN" SkinID="lblRepRsz" Width="250"
                            Visible="True"></asp:Label></h1>
                </center>
                <center>
                    <br />
                    <br />
                    <table id="table1" class="custTable">
                        <tr>
                            <td align="right" style="width: 248px">
                                <asp:Label ID="Label3" runat="server" Text="Academic Calendar Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Style="margin-left: 0px" Width="250px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlacadyear" TabIndex="1" runat="server" SkinID="ddl" AutoPostBack="True"
                                    DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 248px">
                                <asp:Label ID="Label15" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlbatch" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 248px">
                                <asp:Label ID="Label8" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlsem" TabIndex="3" runat="server" SkinID="ddl" DataValueField="SemCode"
                                    DataTextField="SemName" DataSourceID="ObjSemester">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                <asp:Button ID="btnReport" TabIndex="4" runat="server" CssClass="ButtonClass" Text="REPORT" CommandName="REPORT"
                                    SkinID="btn" />
                                <asp:Button ID="btnBack" TabIndex="5" runat="server" Text="BACK" CommandName="BACK"  SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
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
                            &nbsp;
                            <tr>
                                <td>
                                    <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                        TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetOpenBatchCombo"
                                        TypeName="DLNew_StudentMarks">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlacadyear" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                                Type="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="objsemester" runat="server" SelectMethod="SemesterComboBatchPlanner"
                                        TypeName="feeCollectionDL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
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
