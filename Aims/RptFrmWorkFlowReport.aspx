<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptFrmWorkFlowReport.aspx.vb"
    Inherits="RptFrmWorkFlowReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Audit Trail</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg, a;
            msg = DropDownForZero(document.getElementById("<%=ddlform.ClientID %>"), 'Form Name');
            if (msg != "") {
                document.getElementById("<%=lblTitle.ClientID %>").focus();

                return msg;
            }

            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
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
                        WORK FLOW
                        <br />
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTitle" runat="server" Text="Form Name* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlform" runat="server" SkinID="ddl" TabIndex="1" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="84">Employee Transfer</asp:ListItem>
                                    <asp:ListItem Value="129">Leave Application</asp:ListItem>
                                    <asp:ListItem Value="131">Asset Transfer</asp:ListItem>
                                    <asp:ListItem Value="32">Student Transfer</asp:ListItem>
                                    <asp:ListItem Value="132">Material Indent</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                        <td align="right">
                                <asp:Label ID="lblAppStatus" runat="server"  Text="Approval Status :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlStatus" SkinID ="ddl" runat="server" Width="200px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="N"></asp:ListItem>
                                    <asp:ListItem Text="Approval" Value="A"></asp:ListItem>
                                     <asp:ListItem Text="Cancel" Value="C"></asp:ListItem>
                                </asp:DropDownList>
                              
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmp" runat="server" Text="Employee :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEmp" TabIndex="2" runat="server" SkinID="ddlRsz" DataValueField="EmpID"
                                    DataTextField="Emp_Name" DataSourceID="ObjEmp" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmp" runat="server" SelectMethod="EmpCombo" TypeName="EmployeeDB">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstartdate" Width="150px" runat="server" Text="Start Date :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtstartdate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtstartdate"
                                    Enabled="True">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtstartdate" Enabled="True">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblenddate" runat="server" SkinID="lblRsz" Text="End Date :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtenddate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtenddate"
                                    Enabled="True">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtenddate" Enabled="True">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" OnClientClick="return Validate();" TabIndex="2" runat="server"
                                    Text="REPORT" SkinID="btn" CssClass="ButtonClass"></asp:Button>&nbsp;
                                <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
