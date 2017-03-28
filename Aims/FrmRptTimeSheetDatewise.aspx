<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptTimeSheetDatewise.aspx.vb"
    Inherits="FrmRptTimeSheetDatewise" Title="Time Sheet Date wise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Time Sheet Date wise</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = ValidateDateN(document.getElementById("<%=Txtfdate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=Txtfdate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=Txttodate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=Txttodate.ClientID%>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
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
            <div>
            </br>
                <center>
                    <h1 class="headingTxt">
                        TIME SHEET DATE WISE</h1>
                </center>
                <table>
                    
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmployee" runat="server" SkinID="lblRsz" width="150px" Text="Employee Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEmployeeName" runat="server" AppendDataBoundItems="true"
                                    AutoPostBack="true" DataSourceID="ObjEmployee" DataTextField="EmpName" DataValueField="EmpID"
                                    SkinID="ddlRsz" width="200px" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmployee" runat="server" SelectMethod="GetEmployeeComboAll"
                                    TypeName="DLTimesheetDatewise"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblfdate" runat="server" Text="From Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtfdate" runat="server" SkinID="txt" MaxLength="11" TabIndex="2"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txtfdate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lbltdate" runat="server" Text="To Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txttodate" runat="server" SkinID="txt" MaxLength="11" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txttodate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="5" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

