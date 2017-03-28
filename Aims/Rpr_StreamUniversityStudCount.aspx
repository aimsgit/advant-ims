<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpr_StreamUniversityStudCount.aspx.vb" Inherits="Rpr_StreamUniversityStudCount" title="UNIVERSITY WISE BREAKUP OF STREAM ADMISSION" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Response</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtFromDate.ClientID %>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFromDate.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtToDate.ClientID %>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;

                    return false;
                }
            }
            return true;
        }
    </script>

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                    <br />
                    <br />
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBranchType" runat="server" Text="Branch&nbsp;:&nbsp;" SkinID="lblRsz"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBranchName" TabIndex="1" runat="server" SkinID="ddlRsz"
                                    AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="SUBranchCombo" TypeName="TotalStudentCount"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStream" runat="server" Text="Stream&nbsp;:&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                               <asp:DropDownList ID="ddlStream" TabIndex="1" runat="server" SkinID="ddlRsz"
                                    AutoPostBack="True" DataSourceID="ObjStream" DataTextField="Data" DataValueField="LookUpAutoID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjStream" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="SUStreamCombo" TypeName="TotalStudentCount"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Width="100px" Text="From Date&nbsp;:&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                               <asp:TextBox ID="txtFromDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Width="100px" Text="To Date&nbsp;:&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <%--<asp:Button ID="btnTReport" TabIndex="4" runat="server" Text="TABULAR REPORT" Width="130px"
                                    SkinID="btnRsz" CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>--%>
                                <asp:Button ID="BtnGReport" TabIndex="5" runat="server" Text="GRAPHICAL REPORT" Width="150px"
                                    SkinID="btnRsz" CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                             <%--   <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CommandName="BACK"
                                    CssClass="ButtonClass"></asp:Button>--%>
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
                                        <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
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
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtfromdate"
                    Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                    Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

