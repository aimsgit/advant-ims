<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_DistrictwiseStudentCount.aspx.vb" Inherits="Rpt_DistrictwiseStudentCount" title="District wise Student Count" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>District wise Student Count</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

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


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
        <br />
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                    <br />
                </center>
                <%--<table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>--%>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBranchType" runat="server" Text="Branch :&nbsp;&nbsp;" SkinID="lblRsz" Width="100px"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp<asp:DropDownList ID="ddlBranchName" TabIndex="1" runat="server" SkinID="ddlRsz" Width="350px"
                                    AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="insertBranchCombo" TypeName="DLRptDistrictwiseStudentCount"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFromDate" runat="server" Width="100px" Text="From Date :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp<asp:TextBox ID="txtFromDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblToDate" runat="server" Width="100px" Text="To Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp<asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
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
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="BtnGReport" TabIndex="5" runat="server" Text="GRAPHICAL REPORT" Width="150px"
                                    SkinID="btnRsz" CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CommandName="BACK"
                                    CssClass="ButtonClass" Visible="false" ></asp:Button>
                        </tr>
                        </table>
                        </center>
                        
                                <center>
                                    <div>
                                        <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
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

