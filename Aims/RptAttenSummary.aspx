<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptAttenSummary.aspx.vb"
    Inherits="RptAttenSummary" Title="Attendance Summary Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Attendance Summary Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;



            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlBatchName.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=DDLSemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=DDLSemester.ClientID %>").focus();
                return msg;
            }


            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
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
                 <br />
                    <center>
                        <h1 class="headingTxt">
                            ATTENDANCE SUMMARY
                        </h1>
                        <br />
                    </center>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LabelBtch" runat="server" SkinID="lbl" Text="Batch* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                    AppendDataBoundItems="False" Width="200">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchddl" TypeName="DLNewSemesterMarks">
                                </asp:ObjectDataSource>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSemester" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLSemester" SkinID="ddlRsz" DataSourceID="objSemester" DataValueField="SemCode"
                                    DataTextField="SemName" AutoPostBack="true" AppendDataBoundItems="false" runat="server"
                                    Width="200" TabIndex="3">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="GetSemddl" TypeName="DLNewSemesterMarks">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                                <asp:Label ID="lblSub" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbSubject" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                    DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="200" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner"
                                    TypeName="DLAttenSummary">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="DDLSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSort" runat="server" Text="Sort :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSort" SkinID="ddlRsz" runat="server" Width="200" TabIndex="3">
                                    <asp:ListItem Value="0" Text="Std Code" />
                                    <asp:ListItem Value="1" Text="Std Name" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <br />
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="4">
                                <asp:Button ID="btnReport" TabIndex="5" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                &nbsp;
                                <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
