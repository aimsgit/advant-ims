<%@ Page Title="Transport Attendance" Language="VB" AutoEventWireup="false" CodeFile="Rpt_StudentTransport.aspx.vb"
    Inherits="Rpt_StudentTransport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TRANSPORT ATTENDANCE</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            //    msg = DropDownForZero(document.getElementById("<%=ddlRouteName.ClientID%>"), 'Route');
            //     if (msg != "") {
            //        document.getElementById("<%=ddlRouteName.ClientID%>").focus();
            //        return msg;
            //     }
            //    msg = DropDownForZero(document.getElementById("<%=ddlStudent.ClientID%>"), 'Student Name');
            //     if (msg != "") {
            //        document.getElementById("<%=ddlStudent.ClientID%>").focus();
            //        return msg;
            //     }
            msg = ValidateDate(document.getElementById("<%=txtFDate.ClientID %>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtTDate.ClientID %>"), 'To Date ');
            if (msg != "") {
                document.getElementById("<%=txtTDate.ClientID%>").focus();
                return msg;
            }
        }

        function Validate() {
            var msg = Valid();
            if (msg == undefined) {
                return true
            }
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
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
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        TRANSPORT ATTENDANCE</h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRouteName" runat="server" Text="Route &nbsp:&nbsp; " SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlRouteName" runat="server" AutoPostBack="True" DataSourceID="objRouteName"
                                    DataTextField="RouteName" DataValueField="RouteIDAuto" SkinID="ddl" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objRouteName" runat="server" SelectMethod="GetRouteName"
                                    TypeName="DLTransportAndroid"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" runat="server" Text="Passenger Name &nbsp:&nbsp; " SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" DataSourceID="objStudent"
                                    DataTextField="StdName" DataValueField="Std_Id" SkinID="ddlL" TabIndex="2">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objStudent" runat="server" TypeName="DLTransportAndroid"
                                    SelectMethod="GetStudent">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlRouteName" Name="RouteIDAuto" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFDate" runat="server" Text="From Date*&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtFDate" Enabled="True">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTDate" runat="server" Text="To Date*&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTDate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtTDate" Enabled="True">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btnReport" runat="server" Text="REPORT" CssClass="ButtonClass " CausesValidation="true"
                                    SkinID="btn" OnClientClick="return Validate();" TabIndex="5" />&nbsp&nbsp
                                <asp:Button ID="btnBack" runat="server" Text="BACK" CausesValidation="False" SkinID="btn"
                                    CssClass="ButtonClass" TabIndex="6" />
                            </td>
                        </tr>
                </center>
                </table>
                <center>
                    <br />
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    <br />
                    <br />
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
