<%@ Page Title="SE Performance Report" Language="VB"
    AutoEventWireup="false" CodeFile="Mfg_Rpt_SEPerformance.aspx.vb" Inherits="Mfg_Rpt_SEPerformance" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SE Performance Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">


        function Valid() {
            var msg;

            msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID %>"), 'Start Date');
            if (msg != "") {
                document.getElementById("<%=txtStartDate.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtEndDate.ClientID %>"), 'EndDate');
            if (msg != "") {
                document.getElementById("<%=txtEndDate.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg1.ClientID %>").innerText = msg;

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg1.ClientID %>").textContent = msg;

                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <h1 class="headingTxt">
            SE PERFORMANCE REPORT</h1>
    </center>
    <br />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSE" runat="server" SkinID="lblRSZ" width="150" Text="Sales Executive*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSE" SkinID="ddlRsz" AutoPostBack="true" DataSourceID="ObjSE"
                                DataTextField="MR_Name" DataValueField="MR_ID" runat="server" TabIndex="1"
                                Width="300px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSE" runat="server" SelectMethod="SECombo" TypeName="Mfg_SEPerformanceDL">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStartDate" runat="server" SkinID="lbl" Text="Start Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartDate" runat="server" TabIndex="3"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartDate"
                                Format="dd-MMM-yyyy" SkinID="CalendarView" Enabled="true" Animated="False">
                            </ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                Enabled="True" FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters"
                                ValidChars="-/" TargetControlID="txtStartDate">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEndDate" runat="server" SkinID="lbl" Text="End Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" TabIndex="4"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
                                Format="dd-MMM-yyyy" SkinID="CalendarView">
                            </ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                Enabled="True" FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters"
                                ValidChars="-/" TargetControlID="txtEndDate">
                            </ajaxToolkit:FilteredTextBoxExtender>
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
                        <td colspan="5" class="btnTd">
                            <asp:Button ID="btnReport" runat="server" Text="REPORT" CssClass="ButtonClass " CausesValidation="true"
                                SkinID="btn" OnClientClick="return Validate();" TabIndex="12" />
                            <asp:Button ID="btnBack" runat="server" Text="BACK" CausesValidation="False" SkinID="btn"
                                CssClass="ButtonClass" TabIndex="13" />
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <div>
                    <asp:Label ID="LblMsg1" runat="server" SkinID="lblGreen"></asp:Label>
                    <asp:Label ID="lblErrorMsg1" runat="server" SkinID="lblRed"></asp:Label>
                </div>
            </center>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

