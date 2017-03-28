<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmEmpAttendance.aspx.vb"
    Inherits="frmEmpAttendance" Title="Employee Attendance" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee Attendance</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">



        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
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
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--     <center>
                    <h1 class="headingTxt">
                        EMPLOYEE ATTENDANCE</h1>
                </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Date :&nbsp;&nbsp;" EnableViewState="False"
                                        TabIndex="-1"></asp:Label>
                                </td>
                                <td style="width: 292px">
                                    <asp:TextBox ID="txtAttdDate" runat="server" SkinID="txt" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                                </td>
                                <td align="right" style="width: 21px">
                                    <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="From Date* :&nbsp;&nbsp;"
                                        EnableViewState="False" Width="150px"></asp:Label>
                                </td>
                                <td style="width: 234px">
                                    <asp:TextBox ID="txtAttDate2" runat="server" SkinID="txt" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmpCode" runat="server" Text="Employee Code :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td style="width: 292px">
                                    <asp:TextBox ID="txtEmpCode" runat="server" AutoPostBack="True" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="Employee Name :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpName" runat="server" AutoPostBack="True" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Time  In :&nbsp;&nbsp;"
                                        Width="150px"></asp:Label>
                                </td>
                                <td style="width: 292px">
                                    <asp:TextBox ID="txtTimein" runat="server" SkinID="txt" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 16px">
                                    <asp:Label ID="label17" runat="server" SkinID="lbl" Text="Time Out :&nbsp;&nbsp;"
                                        Width="150px"></asp:Label>
                                </td>
                                <td style="width: 292px; height: 16px;">
                                    <asp:TextBox ID="txtTimeout" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                                <td style="width: 21px; height: 16px;">
                                    <ajaxToolkit:CalendarExtender ID="cltxtAttdDate" runat="server" TargetControlID="txtAttdDate"
                                        Format="dd-MMM-yyyy" SkinID=" ">
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:HiddenField ID="HidEmpId" runat="server" />
                                </td>
                                <td style="width: 21px; height: 16px;">
                                    <ajaxToolkit:CalendarExtender ID="cltxtAttdate1" runat="server" TargetControlID="txtAttDate2"
                                        Format="dd-MMM-yyyy" SkinID=" ">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRemarks" runat="server" SkinID="lbl" Text="Remarks  :&nbsp;&nbsp;"
                                        Width="150px"></asp:Label>
                                </td>
                                <td style="width: 292px">
                                    <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
            </a><a name="bottom">
                <table>
                    <tr>
                        <td colspan="3" class="btnTd">
                            <br />
                            <asp:Button ID="btnTimeIN" runat="server" Text="TIME IN" SkinID="btn" ValidationGroup="Submit"
                                TabIndex="1" OnClientClick="return Validate();" CssClass="ButtonClass" />
                            &nbsp;<asp:Button ID="btnTimeout" runat="server" Text="TIME OUT" SkinID="btn"
                                OnClientClick="return Validate();" ValidationGroup="Submit" TabIndex="2" CssClass="ButtonClass" />
                            &nbsp;<asp:Button ID="btnview" runat="server" Text="VIEW" SkinID="btn" CausesValidation="False"
                                TabIndex="3" EnableViewState="False" CssClass="ButtonClass" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                            SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 23px">
                            <center>
                                <div>
                                    <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                                    <asp:Label ID="lblErrorMsg" SkinID="lblRed" runat="server"></asp:Label>
                                </div>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="false"
                        ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                        TargetControlID="txtAttdDate">
                    </ajaxToolkit:MaskedEditExtender>
                    </td> </tr>
                </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="250px" Width="650px">
                                    <center>
                                        <asp:GridView ID="GVEmpAttd" runat="server" DataKeyName="Attendance_ID" AutoGenerateColumns="False"
                                            SkinID="GridView" TabIndex="-1" AllowPaging="True" PageSize="100" AllowSorting="True"
                                            EnableSortingAndPagingCallbacks="True">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource1">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete"
                                                            OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            TabIndex="10" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance Date" SortExpression="Attendance_Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Attendance_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Attendance_Id") %>' />
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind("Emp_Name") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LogIn Time" SortExpression="LoginTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFrm" runat="server" Text='<%# Bind("LoginTime","{0:hh:mm:ss tt}") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LogOut Time" SortExpression="LogoffTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("LogoffTime","{0:hh:mm:ss tt}") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Hours" SortExpression="WorkingHours">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotHrs" runat="server" Text='<%# Bind("WorkingHours") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRemarks" runat="server" Width="150px" Text='<%# Bind("Remarks") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </center>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <br />
                <br />
                <br />
                <br />
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>