<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmFeeCollectionReport.aspx.vb"
    Inherits="frmFeeCollectionReport" Title="Fee Collection Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Collection Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtSDate.ClientID%>"), 'Start Date');
            if (msg != "") {
                document.getElementById("<%=txtSDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtEDate.ClientID%>"), 'End Date');
            if (msg != "") {
                document.getElementById("<%=txtEDate.ClientID%>").focus();
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        FEE COLLECTION REPORT</h1>
                    <br />
                    <br />
                    <table id="table1" class="custTable">
                       <%-- <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Academic Calendar Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Style="margin-left: 0px" Width="250px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbAcademic" TabIndex="1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
--%>                        <tr>
                            <td align="right">
                                <asp:Label ID="Label15" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbBatch" TabIndex="1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" SkinID="lbl" runat="server" Text="Student Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:DropDownList ID="ddlstucode" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
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
                                <asp:Label ID="lblPaymentMethod" runat="server" SkinID="lblRsz" Width="150" Text="Payment Method&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataSourceID="ObjPaymentMethod"
                                    DataTextField="Payment_Method" DataValueField="PaymentMethodID" AppendDataBoundItems="true"
                                    SkinID="ddlRsz" TabIndex="3" Width="200">
                                    <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodCombo"
                                    TypeName="FeeCollectionBL"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCtype" runat="server" Text="Collection Type&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz" Width="150px" ></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCollType" TabIndex="5" runat="server" SkinID="ddlRsz" Width ="200px">
                                <asp:ListItem Value ="0" Text ="All" />
                                <asp:ListItem Value ="1" Text ="Stuctured" />
                                <asp:ListItem Value ="2" Text ="Miscellaneous" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSDate" runat="server" Text="Start Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSDate" TabIndex="4" runat="server" SkinID="txt">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="Calendarextender1" runat="server" TargetControlID="txtSDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEDate" runat="server" Text="End Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEDate" TabIndex="5" runat="server" SkinID="txt">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="FromDateExt" runat="server" TargetControlID="txtEDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
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
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="6" Text="REPORT" />
                                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="7" Text="BACK" Visible="true" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <%--<asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                                    TypeName="DLNew_StudentMarks">
                                    </asp:ObjectDataSource>--%>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetOpenBatchCombo1" TypeName="DLNew_StudentMarks">
                                    <%--<SelectParameters>
                                        <asp:ControlParameter ControlID="cmbAcademic" DefaultValue="0" Name="A_Year" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>--%>
                                </asp:ObjectDataSource>
                                <%--<asp:ObjectDataSource ID="objsemester" runat="server" SelectMethod="SemesterCombo12"
                                TypeName="FeeCollectionBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmbBatch" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                            </td>
                        </tr>
                    </table>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
