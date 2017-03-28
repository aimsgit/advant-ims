<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="RptCalendarOfEvents.aspx.vb"
    Inherits="RptCalendarOfEvents" Title="Calendar Of Events" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Calendar Of Events</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtFrmDate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFrmDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtToDate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID%>").focus();
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <center>
                    <h1 class="headingTxt">
                        CALENDAR OF EVENTS</h1>
                    <br />
                </center>
            </div>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFrmDate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" TargetControlID="txtFrmDate"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEndDate" runat="server" Text=" To Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="EDate" runat="server" TargetControlID="txtToDate"
                                Format="dd-MMM-yyyy">
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
                            <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                Text="GENERATE" SkinID="btnRsz" Width="100" TabIndex="3" CssClass="ButtonClass" />
                        </td>
                    </tr>
                </table>
            </center>
            
            
            
            
            <center>
                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <b>Processing your request..please wait...</b>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <br />
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="GVCal" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        SkinID="GridView" Visible="True" Width="650px" PageSize="100" AllowSorting="True"
                        EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Week No">
                                <ItemTemplate>
                                    <asp:Label ID="lblWeek" runat="server" Text='<%# Bind("WeekNo") %>' />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Month">
                                <ItemTemplate>
                                    <asp:Label ID="lblMonth" runat="server" Text='<%# Bind("MonthNumber") %>' />
                                    <%--<asp:label id="lblStatus" runat="server" text='<%# IIf(Eval("Status").ToString().Equals("Y"), "Active", "Inactive") %>' />--%>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sun" ItemStyle-ForeColor="Red">
                                <ItemTemplate>
                                    <asp:Label ID="lblSun" runat="server" Text='<%# Bind("Sun") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mon">
                                <ItemTemplate>
                                    <asp:Label ID="lblMon" runat="server" Text='<%# Bind("Mon") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tue">
                                <ItemTemplate>
                                    <asp:Label ID="lblTue" runat="server" Text='<%# Bind("Tue") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Wed">
                                <ItemTemplate>
                                    <asp:Label ID="lblWed" runat="server" Text='<%# Bind("Wed") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thu">
                                <ItemTemplate>
                                    <asp:Label ID="lblThur" runat="server" Text='<%# Bind("Thu") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fri">
                                <ItemTemplate>
                                    <asp:Label ID="lblFri" runat="server" Text='<%# Bind("Fri") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sat">
                                <ItemTemplate>
                                    <asp:Label ID="lblSat" runat="server" Text='<%# Bind("Sat") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No. Of working Days">
                                <ItemTemplate>
                                    <asp:Label ID="lblWorkDays" runat="server" Text='<%# Bind("TotWorkingDays") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="true" Width="50" />
                            </asp:TemplateField>
                        </Columns>
                        <%-- <SelectedRowStyle HorizontalAlign="left" />--%>
                    </asp:GridView>
                </asp:Panel>
            </center>
            &nbsp;
            <center>
                <asp:Panel ID="panel2" runat="server">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        SkinID="GridView" Visible="True" Width="550px" PageSize="100" AllowSorting="True"
                        EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Holidays">
                                <ItemTemplate>
                                    <asp:Label ID="lblHolidays" runat="server" Text='<%# Bind("HolidayName") %>' />
                                    <%--<asp:label id="lblStatus" runat="server" text='<%# IIf(Eval("Status").ToString().Equals("Y"), "Active", "Inactive") %>' />--%>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Events">
                                <ItemTemplate>
                                    <asp:Label ID="lblEvents" runat="server" Text='<%# Bind("EventName") %>' />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblHStatus" runat="server" Text='<%# Bind("Status1") %>' />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEStatus" runat="server" Text='<%# Bind("Status2") %>' />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblHDate" runat="server" Text='<%# Bind("HolidayDate","{0:dd-MMM-yyyy}") %>' />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEDate" runat="server" Text='<%# Bind("EventDate","{0:dd-MMM-yyyy}") %>' />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50" />
                            </asp:TemplateField>
                        </Columns>
                        <%-- <SelectedRowStyle HorizontalAlign="left" />--%>
                    </asp:GridView>
                </asp:Panel>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnReport1" runat="server" SkinID="btnRsz" Height="25" Text="REPORT" />
                        </td>
                    </tr>
                </table>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
