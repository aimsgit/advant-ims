<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmRptAchievementAndAward.aspx.vb"
    Inherits="frmRptAchievementAndAward" Title="ACHIEVEMENTS AND AWARDS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ACHIEVEMENTS AND AWARDS</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlEmployee.ClientID%>"), 'Employee/Student');
            if (msg != "") {
                document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=Txtfdate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=Txtfdate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=Txttodate.ClientID%>"), 'To Date');
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
                <center>
                    <br />
                    <h1 class="headingTxt">
                        ACHIEVEMENTS AND AWARDS</h1>
                </center>
                <table>
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
                </table>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="250px" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLAchievementAndAward"
                                    SelectMethod="GetDeptTypeAll"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmpStud" runat="server" Width ="200px" Text="Employee/Student* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEmployee" runat="server" SkinID="ddlRsz" Width="250px" TabIndex="2">
                                    <asp:ListItem Value="0" Text=" Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Employee "></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Student"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblfdate" runat="server" Text="From Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtfdate" runat="server" SkinID="txt" MaxLength="11" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txtfdate">
                                </ajaxToolkit:CalendarExtender>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterMode="InvalidChars" FilterType="Custom" InvalidChars="!@#$%^&*()_+=|\}]{[:;'<,>?"
                                    TargetControlID="Txtfdate" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lbltdate" runat="server" Text="To Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txttodate" runat="server" SkinID="txt" MaxLength="11" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txttodate">
                                </ajaxToolkit:CalendarExtender>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Custom" InvalidChars="!@#$%^&*()_+=|\}]{[:;'<,>?"
                                    TargetControlID="Txttodate" />
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
                                    CssClass="ButtonClass"></asp:Button>
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
