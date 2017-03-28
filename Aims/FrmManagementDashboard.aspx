<%@ Page Title="Management Dashboard" Language="VB" 
    AutoEventWireup="false" CodeFile="FrmManagementDashboard.aspx.vb" Inherits="FrmManagementDashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Management Dashboard</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 
   <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtFromDateExt.ClientID %>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFromDateExt.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtToDateExt.ClientID %>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDateExt.ClientID %>").focus();
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

    <div>
        <a name="top">
            <div align="right">
                <a href="#bottom">
                    <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
            </div>
            <center>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <%--   <center>
                    <h1 class="headingTxt">
                        MANAGEMENT DASHBOARD
                    </h1>
                    </center>--%>
                        <center>
                            <h1 class="headingTxt">
                                <asp:Label ID="Lblheading" runat="server"></asp:Label>
                            </h1>
                        </center>
                        <br />
                        <br />
                        <center>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBranchType" runat="server" Text="Branch :&nbsp;" SkinID="lbl" Width="100px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="txtBranchName" TabIndex="1" runat="server" SkinID="ddlRsz"
                                            AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode" Width="350">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date* :&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFromDateExt" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <ajaxToolkit:CalendarExtender ID="FromDateExt" runat="server" TargetControlID="txtFromDateExt"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblToDate" runat="server" SkinID="lbl" Text="To Date* :&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtToDateExt" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <ajaxToolkit:CalendarExtender ID="ToDateExt" runat="server" TargetControlID="txtToDateExt"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="btnTd" colspan="4">
                                        <asp:Button ID="btnGenerate" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            OnClientClick="return Validate();" TabIndex="4" Text="GENERATE" />
                                        &nbsp;
                                        <asp:Button ID="BtnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                            Text="BACK" />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2" align="right">
                                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                                <ProgressTemplate>
                                                    <div class="PleaseWait">
                                                        Processing your request..Please wait...
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblE" runat="server" Text="" SkinID="lblRed"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </center>
                        <br />
                        <br />
                        <center>
                            <asp:Panel ID="Panel2" runat="server" Height="600px" Width="750px" ScrollBars="Auto">
                                <asp:Chart ID="Chart1" runat="server" Height="600px" Width="900px" EnableViewState="true" >
                                    <Legends>
                                        <asp:Legend Name="Legend1" BackImageAlignment="left" Docking="Top" LegendStyle="Row" Alignment="Near"
                                            TitleFont="Microsoft Sans Serif, 6pt, style=Bold">
                                        </asp:Legend>
                                    </Legends>
                                    <Titles>
                                        <asp:Title Text="Admission Status" Font="Microsoft Sans Serif, 14.25pt">
                                        </asp:Title>
                                    </Titles>
                                    <Series>
                                        <asp:Series Name="Series1" IsValueShownAsLabel="True" Legend="Legend1" LegendText="Total Seats"
                                            LabelAngle="-90" >
                                            <EmptyPointStyle AxisLabel="Seats" />
                                        </asp:Series>
                                        <asp:Series ChartArea="ChartArea1" Name="Series2" IsValueShownAsLabel="True" Legend="Legend1"
                                            LegendText="Admitted Seats" LabelAngle="-90">
                                             <EmptyPointStyle AxisLabel="Course" />
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BackImageAlignment="Top">
                                            <AxisY Title="Seats" TitleAlignment="center">
                                            </AxisY>
                                            <AxisX Title="Course" TitleAlignment="center">
                                                <LabelStyle Angle="90" />
                                            </AxisX>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                                <asp:Chart ID="Chart2" runat="server" Height="600px" Width="900px" EnableViewState="true">
                                    <Legends>
                                        <asp:Legend Name="Legend1" BackImageAlignment="left" Docking="Top" LegendStyle="Row" Alignment="Near">
                                        </asp:Legend>
                                    </Legends>
                                    <Titles>
                                        <asp:Title Text="Fee Collection Status" Font="Microsoft Sans Serif, 14.25pt">
                                        </asp:Title>
                                    </Titles>
                                    <Series>
                                        <asp:Series Name="Series1" IsValueShownAsLabel="True" Legend="Legend1" LegendText="Total Fees">
                                            <EmptyPointStyle AxisLabel="Fees" />
                                        </asp:Series>
                                        <asp:Series ChartArea="ChartArea1" Name="Series2" IsValueShownAsLabel="True" Legend="Legend1" 
                                            LegendText="Collected Fees">
                                             <EmptyPointStyle AxisLabel="Course" />
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisY Title="Fee" TitleAlignment="Center" >
                                            </AxisY>
                                            <AxisX Title="Course" TitleAlignment="Center">
                                            </AxisX>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </asp:Panel>
                        </center>
                        <table>
                            <tr>
                                <td width="130px" align="left">
                                    <asp:Label ID="lblGrandTotal" runat="server" Text="&nbsp;&nbsp;&nbsp;GrandTotal :"
                                        Visible="false" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td width="100px">
                                    <asp:Label Width="100px" Visible="false" runat="server"></asp:Label>
                                </td>
                                <td width="50px">
                                    <asp:Label Width="50px" Visible="false" runat="server"></asp:Label>
                                </td>
                                <td style="width: 40px;" align="left">
                                    <asp:Label ID="lblTotSeats" runat="server" Text='<%# Bind("LblTotSeat") %>' SkinID="lblRsz"
                                        Width="6px"></asp:Label>
                                </td>
                                <td width="40px" align="Right">
                                    <asp:Label ID="lblTotAdmiss" runat="server" Text='<%# Bind("LblTotAdm") %>' SkinID="lblRsz"
                                        Width="50px"></asp:Label>
                                </td>
                                <td width="50px" align="Right">
                                    <asp:Label ID="lblTotNoofSeatsleft" runat="server" Text='<%# Bind("LblTotNoofSeatsleft") %>'
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td width="50px" align="Right">
                                    <asp:Label ID="lblTotFeeColl" runat="server" Text='<%# Bind("lblTotFee") %>' SkinID="lblRsz"
                                        Width="20px"></asp:Label>
                                </td>
                                <td width="110px" align="Right">
                                    <asp:Label ID="lblTotEmpCount" runat="server" Text='<%# Bind("lblTotEmpCount") %>'
                                        SkinID="lblRsz" Width="50px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        </a> <a name="bottom">
                            <table>
                                <tr>
                                    <td>
                                        <center>
                                            <asp:Panel ID="Panel1" runat="server" Height="250px" Width="750px" ScrollBars="Auto">
                                                <asp:GridView ID="GVTotal" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                                    DataKeyNames="BranchCode" SkinID="GridView" TabIndex="6" PageSize="1">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText=" " HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGTotal" runat="server" Text="Grand Total" Width="372px"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                                                            <HeaderStyle HorizontalAlign="left" Width="1000px" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total No of Seats">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGNoOfSeats" runat="server" Text='<%# Bind("NoOfSeats") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" />
                                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Admitted">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGNoofAdm" runat="server" Text='<%# Bind("NoofAdmission") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="2370px" />
                                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Open Seats">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGNoofSeatsleft" runat="server" Text='<%# Bind("NoofSeatsleft") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" />
                                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Fee">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGTotfee" runat="server" Text='<%# Bind("TotalFee","{0:n2}") %>'
                                                                    Width="96px"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" />
                                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Fee Collected">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGTotfeeColl" runat="server" Text='<%# Bind("TotFeeColl","{0:n2}") %>'
                                                                    Width="95px"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="1250px" />
                                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Balance Fee">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGBalFee" runat="server" Text='<%# Bind("Balance","{0:n2}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="150px" />
                                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total No of Employees">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGEmpCount" runat="server" Text='<%# Bind("EmpCount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="100px" />
                                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                                <asp:GridView ID="GVManagementDB" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    DataKeyNames="BranchCode" SkinID="GridView" TabIndex="6" PageSize="100">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Branch" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                                <asp:HiddenField ID="HidBranchCode" runat="server" Value='<%# Bind("BranchCode") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="true" />
                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="150" Wrap="false" />
                                                            <HeaderStyle HorizontalAlign="left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Course">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HidCourseId" runat="server" Value='<%# Bind("Courseid") %>' />
                                                                <asp:Label ID="lblCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="100" Wrap="false" />
                                                            <HeaderStyle HorizontalAlign="left" />
                                                        </asp:TemplateField>
                                                       <%-- <asp:TemplateField HeaderText="Batch">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HidBatchId" runat="server" Value='<%# Bind("BatchID") %>' />
                                                                <asp:Label ID="lblBatchNo" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="100" Wrap="false" />
                                                            <HeaderStyle HorizontalAlign="left" />
                                                        </asp:TemplateField> --%>
                                                        <asp:TemplateField HeaderText="Seats">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNoOfSeats" runat="server" Text='<%# Bind("NoOfSeats") %>' Width="96px"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="70px" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Admitted">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lblNoofAdm" runat="server" Text='<%# Bind("NoofAdmission") %>'
                                                                    Width="86px" CommandName="Update"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="70px" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Open">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNoofSeatsleft" runat="server" Text='<%# Bind("NoofSeatsleft") %>'
                                                                    Width="96px"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="100px" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Fee">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotfee" runat="server" Text='<%# Bind("TotalFee","{0:n2}") %>'
                                                                    Width="95px"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="150px" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fee Collected">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lblTotfeeColl" runat="server" Text='<%# Bind("TotFeeColl","{0:n2}") %>'
                                                                    CommandName="delete" Width="107px"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="150px" />
                                                            <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Balance Fee">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBalFee" runat="server" Text='<%# Bind("Balance","{0:n2}") %>' Width="101px"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="150px" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No of Employees">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lblEmpCount" runat="server" Text='<%# Bind("EmpCount") %>' Width="125px"
                                                                    CommandName="edit"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" Width="100px" />
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </center>
                                    </td>
                                </tr>
                            </table>
                            <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="insertBranchCombo" TypeName="DLReportsR"></asp:ObjectDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </center>
        </a>
        <div align="right">
            <a href="#top">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
        </div>
    </div>

</form>
</body>
</html>
