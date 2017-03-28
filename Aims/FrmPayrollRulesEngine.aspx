<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmPayrollRulesEngine.aspx.vb"
    Inherits="FrmPayrollRulesEngine" Title="Payroll Rules Engine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payroll Rules Engine</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <center>
                        <h1 class="headingTxt">
                            PAYROLL RULES ENGINE
                        </h1>
                        <br />
                    </center>
                </center>
                <br />
                <asp:Panel ID="Panel3" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="Month*&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMonth" TabIndex="6" runat="server" Width="160px" SkinID="ddlRsz">
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
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" Text="Year*&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                        DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="7" Width="160px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <hr />
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnRunUpdate" TabIndex="5" runat="server" Text="RUN FORMULA" SkinID="btnRsz"
                                        CssClass="ButtonClass" OnClientClick="return Validate();" Width="150"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnClearUpdate" TabIndex="6" runat="server" Text="CLEAR RUN" SkinID="btnRsz"
                                        CssClass="ButtonClass" Width="150"></asp:Button>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" Text="Select Option&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="160"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rbSelect" runat="server" Width="500px" RepeatDirection="Horizontal"
                                        TabIndex="4">
                                        <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                                        <asp:ListItem Value="2"></asp:ListItem>
                                        <asp:ListItem Value="3"></asp:ListItem>
                                        <asp:ListItem Value="4"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" Text="Select Field&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"
                                        Width="120"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label2" runat="server" Text="Fixed&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"
                                        Width="120"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label4" runat="server" Text="% Of Gross&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"
                                        Width="120"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label7" runat="server" Text="% Of Net&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"
                                        Width="90"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label8" runat="server" Text="% Of Field&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"
                                        Width="120"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlItem" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4" Width="130">
                                        <asp:ListItem Value="0"> Select</asp:ListItem>
                                        <asp:ListItem Value="BasicPay">BasicPay</asp:ListItem>
                                        <asp:ListItem Value="SpecialAllw">SpecialAllw</asp:ListItem>
                                        <asp:ListItem Value="HouseRentAllw">HouseRentAllw</asp:ListItem>
                                        <asp:ListItem Value="MedicalAllw">MedicalAllw</asp:ListItem>
                                        <asp:ListItem Value="TransportAllw">TransportAllw</asp:ListItem>
                                        <asp:ListItem Value="DearnessAllw">DearnessAllw</asp:ListItem>
                                        <asp:ListItem Value="Incentives">Incentives</asp:ListItem>
                                        <asp:ListItem Value="MiscellaneousPay">MiscellaneousPay</asp:ListItem>
                                        <asp:ListItem Value="Bonus">Bonus</asp:ListItem>
                                        <asp:ListItem Value="Reimbursements">Reimbursements</asp:ListItem>
                                        <asp:ListItem Value="OtherMonthlyPayments">OtherMonthlyPayments</asp:ListItem>
                                        <asp:ListItem Value="SalaryAdv">SalaryAdv</asp:ListItem>
                                        <asp:ListItem Value="ProfTaxDed">ProfTaxDed</asp:ListItem>
                                        <asp:ListItem Value="ITTaxDeduction">ITTaxDeduction</asp:ListItem>
                                        <asp:ListItem Value="AdvStlDeduction">AdvStlDeduction</asp:ListItem>
                                        <asp:ListItem Value="WelfareDeduction">WelfareDeduction</asp:ListItem>
                                        <asp:ListItem Value="PensionDeduction">PensionDeduction</asp:ListItem>
                                        <asp:ListItem Value="OtherDeduction">OtherDeduction</asp:ListItem>
                                        <asp:ListItem Value="MiscDeds">MiscDeds</asp:ListItem>
                                        <asp:ListItem Value="TransportDed">TransportDed</asp:ListItem>
                                        <asp:ListItem Value="LoadDed">LoadDed</asp:ListItem>
                                        <asp:ListItem Value="TDSRefund">TDSRefund</asp:ListItem>
                                        <asp:ListItem Value="PFDed">PFDed</asp:ListItem>
                                        <asp:ListItem Value="VPF">VPF</asp:ListItem>
                                        <asp:ListItem Value="LOPay">LOPay</asp:ListItem>
                                        <asp:ListItem Value="GrossSalary">GrossSalary</asp:ListItem>
                                        <asp:ListItem Value="NetSalary">NetSalary</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFixed" runat="server" SkinID="txtRsz" TabIndex="11" Width="100"
                                        MaxLength="6"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtGross" runat="server" SkinID="txtRsz" TabIndex="12" Width="100"
                                        MaxLength="6"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNet" runat="server" SkinID="txtRsz" TabIndex="13" Width="100"
                                        MaxLength="6"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOnitem" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4" Width="120">
                                        <asp:ListItem Value="0"> Select</asp:ListItem>
                                        <asp:ListItem Value="BasicPay">BasicPay</asp:ListItem>
                                        <asp:ListItem Value="SpecialAllw">SpecialAllw</asp:ListItem>
                                        <asp:ListItem Value="HouseRentAllw">HouseRentAllw</asp:ListItem>
                                        <asp:ListItem Value="MedicalAllw">MedicalAllw</asp:ListItem>
                                        <asp:ListItem Value="TransportAllw">TransportAllw</asp:ListItem>
                                        <asp:ListItem Value="DearnessAllw">DearnessAllw</asp:ListItem>
                                        <asp:ListItem Value="Incentives">Incentives</asp:ListItem>
                                        <asp:ListItem Value="MiscellaneousPay">MiscellaneousPay</asp:ListItem>
                                        <asp:ListItem Value="Bonus">Bonus</asp:ListItem>
                                        <asp:ListItem Value="Reimbursements">Reimbursements</asp:ListItem>
                                        <asp:ListItem Value="OtherMonthlyPayments">OtherMonthlyPayments</asp:ListItem>
                                        <asp:ListItem Value="SalaryAdv">SalaryAdv</asp:ListItem>
                                        <asp:ListItem Value="ProfTaxDed">ProfTaxDed</asp:ListItem>
                                        <asp:ListItem Value="ITTaxDeduction">ITTaxDeduction</asp:ListItem>
                                        <asp:ListItem Value="AdvStlDeduction">AdvStlDeduction</asp:ListItem>
                                        <asp:ListItem Value="WelfareDeduction">WelfareDeduction</asp:ListItem>
                                        <asp:ListItem Value="PensionDeduction">PensionDeduction</asp:ListItem>
                                        <asp:ListItem Value="OtherDeduction">OtherDeduction</asp:ListItem>
                                        <asp:ListItem Value="MiscDeds">MiscDeds</asp:ListItem>
                                        <asp:ListItem Value="TransportDed">TransportDed</asp:ListItem>
                                        <asp:ListItem Value="LoadDed">LoadDed</asp:ListItem>
                                        <asp:ListItem Value="TDSRefund">TDSRefund</asp:ListItem>
                                        <asp:ListItem Value="PFDed">PFDed</asp:ListItem>
                                        <asp:ListItem Value="VPF">VPF</asp:ListItem>
                                        <asp:ListItem Value="LOPay">LOPay</asp:ListItem>
                                        <asp:ListItem Value="GrossSalary">GrossSalary</asp:ListItem>
                                        <asp:ListItem Value="NetSalary">NetSalary</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtItemValue" runat="server" SkinID="txtRsz" TabIndex="14" Width="100"
                                        MaxLength="6"></asp:TextBox>
                                </td>
                        </table>
                        <hr />
                        <table>
                            <td align="left">
                                &nbsp&nbsp&nbsp&nbsp&nbsp<asp:CheckBox ID="CheckCriteria" runat="server" />
                            </td>
                            <td align="left">
                                <asp:Label ID="Label9" runat="server" Text="Field&nbsp;&nbsp;&nbsp;" SkinID="lblrsz"
                                    Width="120"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label12" runat="server" Text="Value&nbsp;&nbsp;&nbsp;" SkinID="lblrsz"
                                    Width="120" Visible="false"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label10" runat="server" Text="Value&nbsp;&nbsp;&nbsp;" SkinID="lblrsz"
                                    Width="120"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label13" runat="server" Text="Value&nbsp;&nbsp;&nbsp;" SkinID="lblrsz"
                                    Width="120" Visible="false"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label11" runat="server" Text="Value&nbsp;&nbsp;&nbsp;" SkinID="lblrsz"
                                    Width="120"></asp:Label>
                            </td>
                            <td align="left">
                                    <asp:Label ID="lblGrade" runat="server" Text="Salary Grade &nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblCriteria" runat="server" Text="Criteria&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"
                                        Width="65"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlC" runat="server" SkinID="ddlRsz" AutoPostBack="True" DataTextField="Acct_Group"
                                        DataValueField="Acct_Group_ID" TabIndex="4" Width="110">
                                        <asp:ListItem Value="0"> Select</asp:ListItem>
                                        <asp:ListItem Value="BasicPay">BasicPay</asp:ListItem>
                                        <asp:ListItem Value="SpecialAllw">SpecialAllw</asp:ListItem>
                                        <asp:ListItem Value="HouseRentAllw">HouseRentAllw</asp:ListItem>
                                        <asp:ListItem Value="MedicalAllw">MedicalAllw</asp:ListItem>
                                        <asp:ListItem Value="TransportAllw">TransportAllw</asp:ListItem>
                                        <asp:ListItem Value="DearnessAllw">DearnessAllw</asp:ListItem>
                                        <asp:ListItem Value="Incentives">Incentives</asp:ListItem>
                                        <asp:ListItem Value="MiscellaneousPay">MiscellaneousPay</asp:ListItem>
                                        <asp:ListItem Value="Bonus">Bonus</asp:ListItem>
                                        <asp:ListItem Value="Reimbursements">Reimbursements</asp:ListItem>
                                        <asp:ListItem Value="OtherMonthlyPayments">OtherMonthlyPayments</asp:ListItem>
                                        <asp:ListItem Value="SalaryAdv">SalaryAdv</asp:ListItem>
                                        <asp:ListItem Value="ProfTaxDed">ProfTaxDed</asp:ListItem>
                                        <asp:ListItem Value="ITTaxDeduction">ITTaxDeduction</asp:ListItem>
                                        <asp:ListItem Value="AdvStlDeduction">AdvStlDeduction</asp:ListItem>
                                        <asp:ListItem Value="WelfareDeduction">WelfareDeduction</asp:ListItem>
                                        <asp:ListItem Value="PensionDeduction">PensionDeduction</asp:ListItem>
                                        <asp:ListItem Value="OtherDeduction">OtherDeduction</asp:ListItem>
                                        <asp:ListItem Value="MiscDeds">MiscDeds</asp:ListItem>
                                        <asp:ListItem Value="TransportDed">TransportDed</asp:ListItem>
                                        <asp:ListItem Value="LoadDed">LoadDed</asp:ListItem>
                                        <asp:ListItem Value="TDSRefund">TDSRefund</asp:ListItem>
                                        <asp:ListItem Value="PFDed">PFDed</asp:ListItem>
                                        <asp:ListItem Value="VPF">VPF</asp:ListItem>
                                        <asp:ListItem Value="LOPay">LOPay</asp:ListItem>
                                        <asp:ListItem Value="GrossSalary">GrossSalary</asp:ListItem>
                                        <asp:ListItem Value="NetSalary">NetSalary</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlc1" runat="server" Width="76" SkinID="ddlRsz" AutoPostBack="True"
                                        DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4">
                                        <asp:ListItem Value="0"> Select</asp:ListItem>
                                        <asp:ListItem Value="1" Text=">"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="<"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="">="></asp:ListItem>
                                        <asp:ListItem Value="4" Text="<="></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCvalue1" runat="server" SkinID="txtRsz" TabIndex="14" Width="95"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlc2" runat="server" SkinID="ddlRsz" AutoPostBack="True" DataTextField="Acct_Group"
                                        DataValueField="Acct_Group_ID" TabIndex="4" Width="80">
                                        <asp:ListItem Value="0"> Select</asp:ListItem>
                                        <asp:ListItem Value="1" Text=">"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="<"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="">="></asp:ListItem>
                                        <asp:ListItem Value="4" Text="<="></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCvalue2" runat="server" SkinID="txtRsz" TabIndex="14" Width="95"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlGrade" runat="server" DataSourceID="objGrade" DataValueField="Grade_Auto"
                                        DataTextField="Grade" TabIndex="17" SkinID="ddlRsz" Width="125px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objGrade" runat="server" TypeName="BLIndividualFormMaster"
                                        SelectMethod="GetGrade"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <hr />
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFormula" runat="server" Text="Formula Group*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblrsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFormulaGroup" runat="server" DataSourceID="ObjFormulaGroup"
                                        DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="7"
                                        Width="160px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjFormulaGroup" runat="server" SelectMethod="Formulagroup"
                                        TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                                </td>
                                <td class="btnTd" colspan="4">
                                    &nbsp;
                                    <asp:Button ID="btnsaveFormula" TabIndex="6" runat="server" Text="SAVE FORMULA" SkinID="btnRsz"
                                        CssClass="ButtonClass" Width="150"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnviewFormula" TabIndex="6" runat="server" Text="VIEW FORMULA" SkinID="btnRsz"
                                        CssClass="ButtonClass" Width="150"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </center>
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
                    <center>
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                    </center>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnUpdateFormula" TabIndex="6" runat="server" Text="UPDATE FORMULA"
                                        SkinID="btnRsz" CssClass="ButtonClass" Width="150" Visible="false"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="750px">
                        <asp:GridView ID="GvFormula" runat="server" SkinID="GridView" AllowPaging="true"
                            AutoGenerateColumns="False" PageSize="100" AllowSorting="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="25px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkPresent" runat="server" TabIndex="9" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select Option">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSelectOption" runat="server" Text='<%# Bind("SelectOptn") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlOption" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4" Width="80">
                                            <asp:ListItem Value="0"> Select</asp:ListItem>
                                            <asp:ListItem Text="Fixed" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="% Of Gross" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="% Of Net" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="% Of Field" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select Field">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Auto_Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblselectF" runat="server" Text='<%# Bind("SelectField") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlSelectF" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4" Width="120">
                                            <asp:ListItem Value="0"> Select</asp:ListItem>
                                            <asp:ListItem Value="BasicPay">BasicPay</asp:ListItem>
                                            <asp:ListItem Value="Special  Allw">SpecialAllw</asp:ListItem>
                                            <asp:ListItem Value="HouseRentAllw">HouseRentAllw</asp:ListItem>
                                            <asp:ListItem Value="MedicalAllw">MedicalAllw</asp:ListItem>
                                            <asp:ListItem Value="TransportAllw">TransportAllw</asp:ListItem>
                                            <asp:ListItem Value="DearnessAllw">DearnessAllw</asp:ListItem>
                                            <asp:ListItem Value="Incentives">Incentives</asp:ListItem>
                                            <asp:ListItem Value="MiscellaneousPay">MiscellaneousPay</asp:ListItem>
                                            <asp:ListItem Value="Bonus">Bonus</asp:ListItem>
                                            <asp:ListItem Value="Reimbursements">Reimbursements</asp:ListItem>
                                            <asp:ListItem Value="OtherMonthlyPayments">OtherMonthlyPayments</asp:ListItem>
                                            <asp:ListItem Value="SalaryAdv">SalaryAdv</asp:ListItem>
                                            <asp:ListItem Value="ProfTaxDed">ProfTaxDed</asp:ListItem>
                                            <asp:ListItem Value="ITTaxDeduction">ITTaxDeduction</asp:ListItem>
                                            <asp:ListItem Value="AdvStlDeduction">AdvStlDeduction</asp:ListItem>
                                            <asp:ListItem Value="WelfareDeduction">WelfareDeduction</asp:ListItem>
                                            <asp:ListItem Value="PensionDeduction">PensionDeduction</asp:ListItem>
                                            <asp:ListItem Value="OtherDeduction">OtherDeduction</asp:ListItem>
                                            <asp:ListItem Value="MiscDeds">MiscDeds</asp:ListItem>
                                            <asp:ListItem Value="TransportDed">TransportDed</asp:ListItem>
                                            <asp:ListItem Value="LoadDed">LoadDed</asp:ListItem>
                                            <asp:ListItem Value="TDSRefund">TDSRefund</asp:ListItem>
                                            <asp:ListItem Value="PFDed">PFDed</asp:ListItem>
                                            <asp:ListItem Value="VPF">VPF</asp:ListItem>
                                            <asp:ListItem Value="LOPay">LOPay</asp:ListItem>
                                            <asp:ListItem Value="GrossSalary">GrossSalary</asp:ListItem>
                                            <asp:ListItem Value="NetSalary">NetSalary</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fixed">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFixed" SkinID="txtRsz" runat="server" Text='<%# Bind("Fixed","{0:n2}") %>' MaxLength="10"
                                            Width="75" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="% Of Gross">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGross" SkinID="txtRsz" runat="server" Text='<%# Bind("OfGross","{0:n2}") %>'
                                            MaxLength="10" Width="75" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="% Of Net">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtNet" SkinID="txtRsz" runat="server" Text='<%# Bind("OfNet","{0:n2}") %>' MaxLength="10"
                                            Width="75" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="% Of Field">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOfField" runat="server" Text='<%# Bind("OfField") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlOfField" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4" Width="120">
                                            <asp:ListItem Value="0"> Select</asp:ListItem>
                                            <asp:ListItem Value="BasicPay">BasicPay</asp:ListItem>
                                            <asp:ListItem Value="SpecialAllw">SpecialAllw</asp:ListItem>
                                            <asp:ListItem Value="HouseRentAllw">HouseRentAllw</asp:ListItem>
                                            <asp:ListItem Value="MedicalAllw">MedicalAllw</asp:ListItem>
                                            <asp:ListItem Value="TransportAllw">TransportAllw</asp:ListItem>
                                            <asp:ListItem Value="DearnessAllw">DearnessAllw</asp:ListItem>
                                            <asp:ListItem Value="Incentives">Incentives</asp:ListItem>
                                            <asp:ListItem Value="MiscellaneousPay">MiscellaneousPay</asp:ListItem>
                                            <asp:ListItem Value="Bonus">Bonus</asp:ListItem>
                                            <asp:ListItem Value="Reimbursements">Reimbursements</asp:ListItem>
                                            <asp:ListItem Value="OtherMonthlyPayments">OtherMonthlyPayments</asp:ListItem>
                                            <asp:ListItem Value="SalaryAdv">SalaryAdv</asp:ListItem>
                                            <asp:ListItem Value="ProfTaxDed">ProfTaxDed</asp:ListItem>
                                            <asp:ListItem Value="ITTaxDeduction">ITTaxDeduction</asp:ListItem>
                                            <asp:ListItem Value="AdvStlDeduction">AdvStlDeduction</asp:ListItem>
                                            <asp:ListItem Value="WelfareDeduction">WelfareDeduction</asp:ListItem>
                                            <asp:ListItem Value="PensionDeduction">PensionDeduction</asp:ListItem>
                                            <asp:ListItem Value="OtherDeduction">OtherDeduction</asp:ListItem>
                                            <asp:ListItem Value="MiscDeds">MiscDeds</asp:ListItem>
                                            <asp:ListItem Value="TransportDed">TransportDed</asp:ListItem>
                                            <asp:ListItem Value="LoadDed">LoadDed</asp:ListItem>
                                            <asp:ListItem Value="TDSRefund">TDSRefund</asp:ListItem>
                                            <asp:ListItem Value="PFDed">PFDed</asp:ListItem>
                                            <asp:ListItem Value="VPF">VPF</asp:ListItem>
                                            <asp:ListItem Value="LOPay">LOPay</asp:ListItem>
                                            <asp:ListItem Value="GrossSalary">GrossSalary</asp:ListItem>
                                            <asp:ListItem Value="NetSalary">NetSalary</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ControlStyle Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value Of Field">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtValueOfField" SkinID="txtRsz" runat="server" Text='<%# Bind("OfValue","{0:n2}") %>'
                                            MaxLength="10" Width="75" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCriteria" runat="server" Text='<%# Bind("Criteria") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCriteria" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4" Width="80">
                                            <asp:ListItem Value="Y"> Yes</asp:ListItem>
                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Field">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCriteriaField" runat="server" Text='<%# Bind("CriteriaFieild") %>'
                                            Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlField" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4" Width="120">
                                            <asp:ListItem Value="0"> Select</asp:ListItem>
                                            <asp:ListItem Value="BasicPay">BasicPay</asp:ListItem>
                                            <asp:ListItem Value="SpecialAllw">SpecialAllw</asp:ListItem>
                                            <asp:ListItem Value="HouseRentAllw">HouseRentAllw</asp:ListItem>
                                            <asp:ListItem Value="MedicalAllw">MedicalAllw</asp:ListItem>
                                            <asp:ListItem Value="TransportAllw">TransportAllw</asp:ListItem>
                                            <asp:ListItem Value="DearnessAllw">DearnessAllw</asp:ListItem>
                                            <asp:ListItem Value="Incentives">Incentives</asp:ListItem>
                                            <asp:ListItem Value="MiscellaneousPay">MiscellaneousPay</asp:ListItem>
                                            <asp:ListItem Value="Bonus">Bonus</asp:ListItem>
                                            <asp:ListItem Value="Reimbursements">Reimbursements</asp:ListItem>
                                            <asp:ListItem Value="OtherMonthlyPayments">OtherMonthlyPayments</asp:ListItem>
                                            <asp:ListItem Value="SalaryAdv">SalaryAdv</asp:ListItem>
                                            <asp:ListItem Value="ProfTaxDed">ProfTaxDed</asp:ListItem>
                                            <asp:ListItem Value="ITTaxDeduction">ITTaxDeduction</asp:ListItem>
                                            <asp:ListItem Value="AdvStlDeduction">AdvStlDeduction</asp:ListItem>
                                            <asp:ListItem Value="WelfareDeduction">WelfareDeduction</asp:ListItem>
                                            <asp:ListItem Value="PensionDeduction">PensionDeduction</asp:ListItem>
                                            <asp:ListItem Value="OtherDeduction">OtherDeduction</asp:ListItem>
                                            <asp:ListItem Value="MiscDeds">MiscDeds</asp:ListItem>
                                            <asp:ListItem Value="TransportDed">TransportDed</asp:ListItem>
                                            <asp:ListItem Value="LoadDed">LoadDed</asp:ListItem>
                                            <asp:ListItem Value="TDSRefund">TDSRefund</asp:ListItem>
                                            <asp:ListItem Value="PFDed">PFDed</asp:ListItem>
                                            <asp:ListItem Value="VPF">VPF</asp:ListItem>
                                            <asp:ListItem Value="LOPay">LOPay</asp:ListItem>
                                            <asp:ListItem Value="GrossSalary">GrossSalary</asp:ListItem>
                                            <asp:ListItem Value="NetSalary">NetSalary</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria 1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCriteria1" runat="server" Text='<%# Bind("Criteria1") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCriteria1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4" Width="80">
                                            <asp:ListItem Value="0"> Select</asp:ListItem>
                                            <asp:ListItem Value="1" Text=">"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="<"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="">="></asp:ListItem>
                                            <asp:ListItem Value="4" Text="<="></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value 1">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtValue1" SkinID="txtRsz" runat="server" Text='<%# Bind("Value1","{0:n2}") %>'
                                            MaxLength="10" Width="75" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria 2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCriteria2" runat="server" Text='<%# Bind("Criteria2") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCriteria2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataTextField="Acct_Group" DataValueField="Acct_Group_ID" TabIndex="4" Width="80">
                                            <asp:ListItem Value="0"> Select</asp:ListItem>
                                            <asp:ListItem Value="1" Text=">"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="<"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="">="></asp:ListItem>
                                            <asp:ListItem Value="4" Text="<="></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value 2">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtValue2" SkinID="txtRsz" runat="server" Text='<%# Bind("Value2","{0:n2}") %>'
                                            MaxLength="10" Width="75" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Grade">
                                    <ItemTemplate>
                                     <asp:Label ID="lblGrade" runat="server" Text='<%# Bind("GradeId") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlGrade1" runat="server" DataSourceID="objGrade" DataValueField="Grade_Auto"
                                        DataTextField="Grade" TabIndex="17" SkinID="ddl">
                                    </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    </br>
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="750px" Height="250px">
                        <asp:GridView ID="gvGenSalary" runat="server" SkinID="GridView" AllowPaging="true"
                            AutoGenerateColumns="False" PageSize="100" AllowSorting="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Employee Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployee" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("MS_ID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Code">
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
                                <asp:TemplateField HeaderText="Days Worked">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWorkDays" runat="server" Text='<%# Bind("DaysWorked") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PL Days">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPLDays" runat="server" Text='<%# Bind("PLDays") %>'></asp:Label>
                                    </ItemTemplate>
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
                                <asp:TemplateField HeaderText="PF Deuction">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPFDedc" runat="server" Text='<%# Bind("PFDed","{0:F2}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </asp:Panel>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label14" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" OnTextChanged="btnPassword_click"></asp:TextBox>
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
                                            CommandName="OK" OnClientClick="btnPassword_click" />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
