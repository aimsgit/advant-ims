<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmFeeCollectionStdWiseRpt.aspx.vb"
    Inherits="frmFeeCollectionStdWiseRpt" Title="Studentwise Fee Collection Report" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Studentwise Fee Collection Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=cmbAcademic.ClientID%>"), 'Academic Year');
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
                        STUDENTWISE FEE COLLECTION REPORT</h1>
                </center>
                <br />
                <br />
                <center>
                    <table id="table1" class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Academic Calendar Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="250px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbAcademic" TabIndex="1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label15" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbBatch" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" SkinID="lbl" runat="server" Text="Student Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:DropDownList ID="ddlstucode" TabIndex="3" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataSourceID="ObjStuCode" DataTextField="StdCode" DataValueField="STD_ID" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjStuCode" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetStudentReportCombo" TypeName="DLReportsR">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cmbBatch" Name="BatchID" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" Text="Semester :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbSemester" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="SemCode"
                                    DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="true" Width="200">
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
                                <asp:Button ID="btnReport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="5" Text="REPORT" />
                                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="6" Text="BACK" Visible="true" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                    TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetOpenBatchComboAll"
                                    TypeName="feeCollectionDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cmbAcademic" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="objsemester" runat="server" SelectMethod="SemesterCombo12"
                                    TypeName="FeeCollectionBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cmbBatch" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>

