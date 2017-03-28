<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmGenerateMontSalarySlip.aspx.vb"
    Inherits="frmGenerateMontSalarySlip" Title="Generate Salary Slip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Generate Salary Slip</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtWorkingDays.ClientID %>"), 'Working Days in a Month');
            if (msg != "") {
                document.getElementById("<%=txtWorkingDays.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtTotalDays.ClientID %>"), 'Total Days in a Month');
            if (msg != "") {
                document.getElementById("<%=txtTotalDays.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtPaymentdate.ClientID %>"), 'Payment Date');
            if (msg != "") {
                document.getElementById("<%=txtPaymentdate.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtPaymentrunDate.ClientID %>"), 'Payment Run Date');
            if (msg != "") {
                document.getElementById("<%=txtPaymentrunDate.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
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
                <%-- <center>
        <h1 class="headingTxt">
            GENERATE SALARY SLIP
        </h1>
    </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table class="custTable">
                            <tr>
                                <td style="border: solid 2px #000000;" valign="top">
                                    <div style="width: 650px;">
                                        Steps:<br />
                                        1. Use Payroll Details to edit any changes.<br />
                                        2. Click on Monthly Pay Details to check and edit if any changes in Monthly Pay
                                        Details. Enter &nbsp;&nbsp;&nbsp;&nbsp;No of days worked for every employee.
                                        <br />
                                        3. Enter Working Days in Month.
                                        <br />
                                        4. Enter Total Days in Month.
                                        <br />
                                        5. Select Month and Enter Year.
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDeptName" runat="server" Text="Department Name&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="298"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLDeptType" runat="server" DataSourceID="objDept" SkinID="ddlRsz"
                                    DataValueField="DeptID" DataTextField="DeptName" TabIndex="1" Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objDept" runat="server" TypeName="SubjectDB" SelectMethod="Getdeptcombo1">
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="GENERATE MONTH SALARY" SkinID="btnrsz"
                                    CssClass="ButtonClass" Width="200px" OnClientClick="return Validate();" Visible="false"
                                    TabIndex="9"></asp:Button>
                            </td>
                        </tr>
                    </table>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Working Days in Month*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWorkingDays" TabIndex="2" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        TargetControlID="txtWorkingDays" FilterType="numbers" ValidChars="0123456789"
                                        FilterMode="ValidChars">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="btnEditMonth" TabIndex="12" runat="server" Width="200px" Text="MONTHLY PAY DETAILS"
                                        CausesValidation="False" SkinID="btnrsz" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="Total Days in Month*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblrsz" Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalDays" TabIndex="3" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        TargetControlID="txtTotalDays" FilterType="numbers" ValidChars="0123456789" FilterMode="ValidChars">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnGenerateMonthSalary" TabIndex="10" runat="server" Text="GENERATE MONTH SALARY"
                                        SkinID="btnrsz" CssClass="ButtonClass" Width="200px" OnClientClick="return Validate();">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Payment Date*&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaymentdate" MaxLength="4" TabIndex="3" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPaymentdate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnClearMonthSalary" TabIndex="11" runat="server" Width="200px" Text="CLEAR MONTH SALARY"
                                        CausesValidation="False" SkinID="btnrsz" CssClass="ButtonClass" OnClientClick="return confirm('Do you want to delete the selected record(s)?')">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="Payment Run Date*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblrsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaymentrunDate" MaxLength="5" TabIndex="4" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPaymentrunDate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnLockSalary" TabIndex="13" runat="server" Width="200px" Text="LOCK\UNLOCK"
                                        CausesValidation="False" SkinID="btnrsz" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="Month*&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMonth" TabIndex="6" runat="server" Width="66px" SkinID="ddl">
                                        <asp:ListItem Value="1">January</asp:ListItem>
                                        <asp:ListItem Value="2">February</asp:ListItem>
                                        <asp:ListItem Value="3">March</asp:ListItem>
                                        <asp:ListItem Value="4">April</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">June</asp:ListItem>
                                        <asp:ListItem Value="7">July</asp:ListItem>
                                        <asp:ListItem Value="8">August</asp:ListItem>
                                        <asp:ListItem Value="9">September</asp:ListItem>
                                        <asp:ListItem Value="10">October</asp:ListItem>
                                        <asp:ListItem Value="11">November</asp:ListItem>
                                        <asp:ListItem Value="12">December</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="btnprint" TabIndex="14" runat="server" Width="200px" Text="PRINT SALARY SLIP"
                                        CausesValidation="False" SkinID="btnrsz" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" Text="Year*&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                                </td>
                                <td>
                                    <%--<asp:TextBox ID="txtYear" runat="server" SkinID="txt" MaxLength="22" TabIndex="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                TargetControlID="txtYear" FilterType="numbers" ValidChars="0123456789" FilterMode="ValidChars">
                            </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                        DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="7" Width="160px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:Button ID="btnView" TabIndex="15" runat="server" Width="200px" Text="VIEW" CausesValidation="False"
                                        SkinID="btnrsz" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="Year*&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"
                                        Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjSelectYear"
                                        DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddlRsz" Width="160px"
                                        Visible="false" TabIndex="17">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ddlYear"
                                        TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:Button ID="BtnNegativeSalary" TabIndex="18" runat="server" Width="200px" Text="IDENTIFY NEGATIVE SALARY"
                                        CausesValidation="False" SkinID="btnrsz" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:RadioButtonList ID="RbTYPE" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                        SkinID="Themes1" Height="20px" Width="250px" TabIndex="8" Visible="false">
                                        <asp:ListItem Selected="True" Value="1" Text="On Gross Salary"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="On Net Salary"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:Button ID="btnCalcPF" TabIndex="16" runat="server" Width="200px" Text="CALCULATE PROF. TAX"
                                        CausesValidation="False" SkinID="btnrsz" CssClass="ButtonClass" Visible="false">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <center>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <center>
                                        <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                            <ProgressTemplate>
                                                <div class="PleaseWait">
                                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="750px" Height="250px">
                            <asp:GridView ID="gvGenSalary" runat="server" SkinID="GridView" AllowPaging="true"
                                AutoGenerateColumns="False" PageSize="100" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployee" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("MS_ID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("EmpID") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmp_Code" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gross Salary">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGSalary" runat="server" Text='<%# Bind("GrossSalary","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Net Salary">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNSalary" runat="server" Text='<%# Bind("NetSalary","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Days Worked" SortExpression="DaysWorked">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWorkDays" runat="server" Text='<%# Bind("DaysWorked") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PL Days" ControlStyle-Width="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPLDays" runat="server" Text='<%# Bind("PLDays") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="70px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Work Days In a Month" ControlStyle-Width="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWDinMonth" runat="server" Text='<%# Bind("WorkDaysInMonth") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ControlStyle Width="70px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Basic">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBasicPay" runat="server" Text='<%# Bind("BasicPay","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Locked/ Unlocked">
                                        <ItemTemplate>
                                            <asp:Label ID="Locked" runat="server" Text='<%# Bind("LockStatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Special Allowance">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSplAllowance" runat="server" Text='<%# Bind("SpecialAllw","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HRA">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHRA" runat="server" Text='<%# Bind("HouseRentAllw","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medical Allowance">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMedical" runat="server" Text='<%# Bind("MedicalAllw","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transport Allowance">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTAllowance" runat="server" Text='<%# Bind("TransportAllw","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dearness Allowance">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDearnessAllw" runat="server" Text='<%# Bind("DearnessAllw","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Incentives">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInc" runat="server" Text='<%# Bind("Incentives","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Over Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOT" runat="server" Text='<%# Bind("OT","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Honorary">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHonorary" runat="server" Text='<%# Bind("Honorary","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Miscellaneous">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMisPay" runat="server" Text='<%# Bind("MiscellaneousPay","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bonus">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBonus" runat="server" Text='<%# Bind("Bonus","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reimbursements">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReimbursements" runat="server" Text='<%# Bind("Reimbursements","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Other Monthly Payments">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOtherMonthlyPayments" runat="server" Text='<%# Bind("OtherMonthlyPayments","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Salary Advance">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalaryAdv" runat="server" Text='<%# Bind("SalaryAdv","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Professional Tax Deduction">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProfTaxDed" runat="server" Text='<%# Bind("ProfTaxDed","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IT Deduction">
                                        <ItemTemplate>
                                            <asp:Label ID="lblITTaxDeduction" runat="server" Text='<%# Bind("ITTaxDeduction","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Advance Settlement Deduction">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdvstlDedu" runat="server" Text='<%# Bind("AdvStlDeduction","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Other Deduction">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOdeu" runat="server" Text='<%# Bind("OtherDeduction","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Miscellaneous Deduction">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMiscDeds" runat="server" Text='<%# Bind("MiscDeds","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transport Deduction">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTransportDed" runat="server" Text='<%# Bind("TransportDed","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loan Deduction">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLoadDed" runat="server" Text='<%# Bind("LoadDed","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TDS Refund">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTDSRefund" runat="server" Text='<%# Bind("TDSRefund","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="VPF">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVPF" runat="server" Text='<%# Bind("VPF","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LOP">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLOPay" runat="server" Text='<%# Bind("LOPay","{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </asp:Panel>
            </a><a name="bottom">
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label7" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" OnTextChanged="btnPassword_Click"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                                            OnClientClick="btnPassword_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblpassError" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                </asp:Panel>
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
