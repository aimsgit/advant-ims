<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptProctorialRecord.aspx.vb"
    Inherits="RptProctorialRecord" Title="Proctorial Record" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Proctorial Record</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlBatch.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlStudent.ClientID %>"), 'Student');
            if (msg != "") {
                document.getElementById("<%=ddlStudent.ClientID %>").focus();
                return msg;
            }
        }
        function Validate() {
            var msg = Valid();
            if (msg == undefined) {
                return true;
            }
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    return false;
                }
            }

        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                 <br>
                    <center>
                        <h1 class="headingTxt">
                            PROCTORIAL RECORD</h1>
                        <br>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" DataSourceID="ObjBatch"
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="1"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLProctorialRecord">
                                        <%--<SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>--%>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudent" runat="server" Text="Student Name*&nbsp;:&nbsp;&nbsp;"
                                        Width="130px" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" DataSourceID="ObjStudent"
                                        DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="2"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                        TypeName="DLProctorialRecord">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatch" Name="BatchID" Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                                                     
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnCreate" runat="server" TabIndex="6" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" TabIndex="7" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <div>
                                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                
                                <td colspan="3" align="Left">
                                <b>Note : </b>Student Details, Student Academic Details, Student Log Book, Student Additional Qualification and Fees Details will be displayed in this Report
                                    <%--<asp:CheckBoxList ID="RBUsers" runat="server" SkinID="RDRsz" AutoPostBack="True"
                                        Width="350px" RepeatDirection="Vertical" TabIndex="3">
                                        <asp:ListItem Value="1" Selected="True">Student Details</asp:ListItem>
                                        <asp:ListItem Value="2">Student Academic Details</asp:ListItem>
                                        <asp:ListItem Value="3">Student Log Book</asp:ListItem>
                                    </asp:CheckBoxList>--%>
                                </td>
                            </tr>
                        </table>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>

</form>
</body>
</html>

