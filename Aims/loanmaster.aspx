<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="loanmaster.aspx.vb"
    Inherits="loanmaster" Title="Loan Master" ValidateRequest="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Loan Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <script type="text/javascript" language="javascript">


         function ShowImage1() {
                    GlbShowSImage(document.getElementById("<%=txtBank.ClientID%>"));

                }
         function HideImage1() {
                    GlbHideSImage(document.getElementById("<%=txtBank.ClientID%>"));
                }
    </script>
   <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <br/>
                <a name="top">
                    <div align="right">
                        <a href="#bottom">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    </div>
                    <div>
                        <center>
                            <h1 class="headingTxt">
                                <asp:Label ID="Lblheading" runat="server"></asp:Label>
                            </h1>
                        </center>
                        
                        <center>
                            <table class="custTable">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="RBType" runat="server" align="center" AutoPostBack="True" RepeatDirection="Horizontal" SkinID="Rd" CellSpacing = "10">
                                        <asp:ListItem Selected="True" Value="L">Loan</asp:ListItem>
                                        <asp:ListItem Value="A">Advances</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        
                         <center>
                            <table class="custTable">
                                <tr>
                                    <td align="right">
                                        <asp:HiddenField ID="HidempId" runat="server" />
                                        <asp:Label ID="lblEmpName" SkinID="lblRsz" runat="server" Text="Employee Name*^&nbsp;:&nbsp;&nbsp;"
                                            Width="240px"></asp:Label>
                                    </td>
                                    <td>
                                        <%--<asp:TextBox ID="txtEmp" runat="server" TabIndex="1"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                            FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtEmp">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" TargetControlID="txtEmp"
                                            ServiceMethod="getEmpCodeExt1" ServicePath="TextBoxExt.asmx" OnClientPopulating="ShowImage"
                                            OnClientPopulated="HideImage" MinimumPrefixLength="3" CompletionInterval="1000"
                                            OnClientItemSelected="SplitName" FirstRowSelected="true" EnableCaching="true"
                                            CompletionListCssClass="completeListStyle">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                            WatermarkText="Type first 3 characters" TargetControlID="txtEmp" SkinID="watermark">
                                        </ajaxToolkit:TextBoxWatermarkExtender>--%>
                                        <asp:DropDownList ID="ddlEmpName" runat="server" DataTextField="Emp_Name" DataSourceID="ObjEmpName"
                                            DataValueField="EmpID" Width="240px" SkinID="ddlRsz" TabIndex="1">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjEmpName" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetEmpNameDDL" TypeName="loanmasterDA"></asp:ObjectDataSource>
                                    </td>
                               <%-- </tr>
                                
                                <tr>--%>
                                    <td align="right">
                                        <asp:Label ID="Label15" SkinID="lblRsz" runat="server" Text="Installments Collected&nbsp:&nbsp;&nbsp;" Width="200"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInstallmentCollected" SkinID="txt" runat="server" TabIndex="13"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FiltTextBoxExten" runat="server" TargetControlID="txtBalanceloan"
                                        FilterType="Numbers" FilterMode="ValidChars" ValidChars="1234567890/-.">
                                    </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td align="right">
                                        <asp:HiddenField ID="HidLoanId" runat="server" />
                                        <asp:Label ID="lblLoanno" SkinID="lblRsz" runat="server" Text="Loan Number*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        <asp:Label ID="lblAdvanceno" SkinID="lblRsz" runat="server" Text="Advance Number*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLoanno" SkinID="txt" runat="server" TabIndex="2"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtLoanno">
                                    </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                                <%--</tr>
                                
                                <tr>--%>
                                     <td align="right">
                                        <asp:Label ID="Label17" SkinID="lblRsz" runat="server" Text="Current Month Deduction&nbsp:&nbsp;&nbsp;" Width="210"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCurrentMonthDedu" SkinID="txt" runat="server" TabIndex="15"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FiltTextBoxExten" runat="server" TargetControlID="txtBalanceloan"
                                        FilterType="Numbers" FilterMode="ValidChars" ValidChars="1234567890/-.">
                                    </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                                </tr>  
                                                                
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblLoanType" SkinID="lblRsz" runat="server" Text="Loan Type*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        <asp:Label ID="lblAdvanceType" SkinID="lblRsz" runat="server" Text="Advance Type*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <%-- <asp:TextBox ID="txtloantype" SkinID="txt" runat="server" TabIndex="3"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtloantype">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                        <asp:DropDownList ID="ddlLoanType" runat="server" DataTextField="LoanType" DataSourceID="ObjLoanType"
                                            DataValueField="LoanMaster_ID" Width="154px" SkinID="ddlRsz" TabIndex="3" >
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjLoanType" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetLoanTypeDDL" TypeName="loanmasterDA"></asp:ObjectDataSource>
                                    </td>
                                <%--</tr>
                                <tr>--%>
                                     <td align="right">
                                        <asp:Label ID="Label16" SkinID="lblRsz" runat="server" Text="Opening Balance&nbsp:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOpeningBal" SkinID="txt" runat="server" TabIndex="16"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FiltTextBoxExten" runat="server" TargetControlID="txtBalanceloan"
                                        FilterType="Numbers" FilterMode="ValidChars" ValidChars="1234567890/-.">
                                    </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                                </tr>  
                                
                                                                                        
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblLoandate" SkinID="lblRsz" runat="server" Text="Loan Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        <asp:Label ID="lblAdvancedate" SkinID="lblRsz" runat="server" Text="Advance Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLoandate" SkinID="txt" runat="server" TabIndex="4"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLoandate"
                                            Format="dd-MMM-yyyy" Animated="False">
                                        </ajaxToolkit:CalendarExtender>
                                        <ajaxToolkit:MaskedEditExtender ID="LoanDate" runat="server" ClearMaskOnLostFocus="false"
                                            ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                            TargetControlID="txtLoandate">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                <%--</tr>
                                <tr>--%>
                                   <td align="right">
                                        <asp:Label ID="lblBalanceloan" SkinID="lblRsz" runat="server" Text="Closing Balance&nbsp:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBalanceloan" SkinID="txt" runat="server" TabIndex="17"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FiltTextBoxExten" runat="server" TargetControlID="txtBalanceloan"
                                        FilterType="Numbers" FilterMode="ValidChars" ValidChars="1234567890/-.">
                                    </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                                </tr>
                                                                
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblLoanamount" SkinID="lblRsz" runat="server" Text="Loan Amount*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                        <asp:Label ID="lblAdvanceAmount" SkinID="lblRsz" runat="server" Text="Advance Amount*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLoanamount" SkinID="txt" runat="server" TabIndex="5"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        TargetControlID="txtLoanamount" FilterType="Numbers" FilterMode="ValidChars"
                                        ValidChars="1234567890/-.">
                                    </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                                <%--</tr>
                                
                                <tr>--%>
                                   <td colspan="1" align="right">
                                        <asp:Label ID="lblStartdate" runat="server" SkinID="lbl" Text="Start Date*&nbsp:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtStartdate" SkinID="txt" runat="server" TabIndex="18"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="StartDate" runat="server" ClearMaskOnLostFocus="false"
                                            ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                            TargetControlID="txtStartdate">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblInterestrate" SkinID="lbl" runat="server" Text="Interest Rate&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInterestrate" SkinID="txt" runat="server" TabIndex="6" ></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtInterestrate" />
                                    </td>
                                <%--</tr>
                                
                                 <tr>--%>
                                    <td align="right">    
                                        <asp:Label ID="lblGuaranteedBy1" SkinID="lblRsz" runat="server" Text="Guaranteed By 1&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGuaranteedBy1" SkinID="txt" runat="server" TabIndex="19"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label14" SkinID="lblRsz" runat="server" Text="Total Installments&nbsp:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInstallments" SkinID="txt" runat="server" TabIndex="12"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FiltTextBoxExten" runat="server" TargetControlID="txtBalanceloan"
                                        FilterType="Numbers" FilterMode="ValidChars" ValidChars="1234567890/-.">
                                    </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                               <%-- </tr>
                                
                                 <tr>--%>
                                     <td align="right">    
                                        <asp:Label ID="lblGuaranteedBy2" SkinID="lblRsz" runat="server" Text="Guaranteed By 2&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGuaranteedBy2" SkinID="txt" runat="server" TabIndex="20"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                <tr>
                                <td align="right">
                                        <asp:Label ID="lblMonthlydeduction" SkinID="lblRsz" runat="server" Text="Monthly Deduction&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMonthlydeduction" SkinID="txt" runat="server" TabIndex="14"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        TargetControlID="txtMonthlydeduction" FilterType="Numbers" FilterMode="ValidChars"
                                        ValidChars="1234567890/-.">
                                    </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </td>
                                <%--</tr>--%>
                                <td align="right">    
                                        <asp:Label ID="lblRemarks" SkinID="lbl" runat="server" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" SkinID="txt" runat="server" TabIndex="21"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblPaymentMethod" SkinID="lblRsz" runat="server" Text="Payment Method&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataTextField="Payment_Method" DataSourceID="ObjPaymentMethod"
                                            DataValueField="PaymentMethodIDAuto" Width="154px" SkinID="ddlRsz" TabIndex="7" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server"   SelectMethod="GetPaymentMethod" TypeName="loanmasterDA">
                                        </asp:ObjectDataSource>
                                    </td>
                                <%--</tr>
                                <tr>--%>
                                   <td align="right">    
                                        <asp:Label ID="lblRecovered" SkinID="lblRsz" runat="server" Text="Recovered Y/N&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkRecovered" runat="server" TabIndex="22" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td align="right">
                                        <asp:HiddenField ID="HidBank" runat="server" />
                                        <asp:Label ID="lblBank" SkinID="lblRsz" runat="server" Text="Bank&nbsp;:&nbsp;&nbsp;"
                                            Width="150px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBank" SkinID="txtRsz" Width="154" runat="server" TabIndex="8"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" OnClientPopulated="HideImage1"
                                            OnClientPopulating="ShowImage1" TargetControlID="txtBank" MinimumPrefixLength="3"
                                            CompletionInterval="1000" FirstRowSelected="true" EnableCaching="true" ServiceMethod="getBankExt"
                                            ServicePath="TextBoxExt.asmx">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                            SkinID="watermark" TargetControlID="txtBank" WatermarkText="Type first 3 characters">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                        <asp:HiddenField ID="HiddenFieldBank" runat="server" />
                                     
                                    </td>
                                    </tr> 
                                <%--</tr>
                                
                                <tr>--%>
                                    
                                <tr>
                                    <td align="right">
                                        <asp:HiddenField ID="HidBranch" runat="server" />
                                        <asp:Label ID="lblBranch" SkinID="lblRsz" runat="server" Text="Branch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBranch" SkinID="txt" runat="server" TabIndex="9"></asp:TextBox>
                                    
                                    </td>
                                    </tr> 
                                <%--</tr>
                                 <tr>--%>
                                    
                                
                                
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblChqno" SkinID="lblRsz" runat="server" Text="Cheque/DD No&nbsp;:&nbsp;&nbsp;"
                                            Width="170px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtchqno" SkinID="txt" runat="server" TabIndex="10"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblChequedate" SkinID="lbl" runat="server" Text="Cheque Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtChequedate" SkinID="txt" runat="server" TabIndex="11"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <center>
                                            <asp:Button ID="BtnAdd" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                                SkinID="btn" TabIndex="23" Text="ADD" />
                                            &nbsp;<asp:Button ID="BtnView" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btn" TabIndex="24" Text="VIEW" />
                                                </center> 
                                    </td>
                                </tr>
                                </table>
                                </center>
                                <center>
                                <table >
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                            <ProgressTemplate>
                                                <div class="PleaseWait">
                                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                            </center>
                            <center>
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                            <br />
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
                </a><a name="bottom">
                    <center>
                        <table>
                            <tr>
                               <td align="center">
                                 <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            DataKeyNames="LoanID" SkinID="GridView" TabIndex="7" PageSize="100" AllowSorting="True"
                                            EnableSortingAndPagingCallbacks="True">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Text="Edit" cssproperty="Btnclass"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                            cssproperty="Btnclass" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-HorizontalAlign="Left" SortExpression="Emp_Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("Emp_Code") %>' Visible ="false" ></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                        <asp:Label ID="Labelempid" runat="server" Text='<%# Bind("EmpID") %>' Visible ="false" ></asp:Label>
                                                        
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Loan Number" HeaderStyle-HorizontalAlign="Center" SortExpression="LoanIDCode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("LoanIDCode") %>'></asp:Label>
                                                        <asp:HiddenField ID="HidLoanId" runat="server" Value='<%# Bind("LoanID") %>'></asp:HiddenField>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Loan Type" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("LoanTypeId") %>' Visible ="false" ></asp:Label>
                                                        <asp:Label ID="lbldata" runat="server" Text='<%# Bind("LoanType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Loan Date" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("LoanDate", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Loan Amount" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("LoanAmt","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Interest Rate" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("InterestRate") %>'></asp:Label>
                                                        <asp:Label ID="LabelPaymentMethod" runat="server" Visible="false" Text='<%# Bind("Payment_Method") %>'></asp:Label>     
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bank" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Visible ="false"  Text='<%# Bind("Bank") %>'></asp:Label>
                                                        <asp:Label ID="lblbnk" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Branch" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBrnch" runat="server" Text='<%# Bind("Branch") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cheque/DD No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("ChequeNoAndBank") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cheque Date" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("ChequeDate", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Installement" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallment" runat="server" Text='<%# Bind("Installment") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Installment Collected" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallmentCollected" runat="server" Text='<%# Bind("InstallmentCollected") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Monthly Deduction" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("MonthlyDed","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Current Monthly Deduction" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCurrentMonthlyDedu" runat="server" Text='<%# Bind("CurrentMonthlyDed","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Opening Balance"  HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOpeningBal" runat="server" Text='<%# Bind("OpeningBal","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Closing Balance"  HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("BalanceLoan","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("StartDate", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        <asp:Label ID="LabelGB1" runat="server" Visible="false" Text='<%# Bind("Guaranteed_By1") %>'></asp:Label>
                                                        <asp:Label ID="LabelGB2" runat="server" Visible="false" Text='<%# Bind("Guaranteed_By2") %>'></asp:Label>
                                                        <asp:Label ID="LabelRemarks" runat="server" Visible="false" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                        <asp:Label ID="LabelRecovered" runat="server" Visible="false" Text='<%# Bind("Recovered") %>'></asp:Label> 
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                         <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            DataKeyNames="LoanID" SkinID="GridView" TabIndex="7" PageSize="100" AllowSorting="True"
                                            EnableSortingAndPagingCallbacks="True">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Text="Edit" cssproperty="Btnclass"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                            cssproperty="Btnclass" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-HorizontalAlign="Left" SortExpression="Emp_Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("Emp_Code") %>' Visible ="false" ></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                        <asp:Label ID="Labelempid" runat="server" Text='<%# Bind("EmpID") %>' Visible ="false" ></asp:Label>
                                                        
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Advance Number" HeaderStyle-HorizontalAlign="Center" SortExpression="LoanIDCode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("LoanIDCode") %>'></asp:Label>
                                                        <asp:HiddenField ID="HidLoanId" runat="server" Value='<%# Bind("LoanID") %>'></asp:HiddenField>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Advance Type" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("LoanTypeId") %>' Visible ="false" ></asp:Label>
                                                        <asp:Label ID="lbldata" runat="server" Text='<%# Bind("LoanType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Advance Date" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("LoanDate", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Advance Amount" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("LoanAmt","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Interest Rate" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("InterestRate") %>'></asp:Label>
                                                        <asp:Label ID="LabelPaymentMethod" runat="server" Visible="false" Text='<%# Bind("Payment_Method") %>'></asp:Label>    
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bank" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Visible ="false"  Text='<%# Bind("Bank") %>'></asp:Label>
                                                        <asp:Label ID="lblbnk" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Branch" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBrnch" runat="server" Text='<%# Bind("Branch") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cheque/DD No" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("ChequeNoAndBank") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cheque Date" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("ChequeDate", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Installement" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallment" runat="server" Text='<%# Bind("Installment") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Installment Collected" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallmentCollected" runat="server" Text='<%# Bind("InstallmentCollected") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Monthly Deduction" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("MonthlyDed","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Current Monthly Deduction" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCurrentMonthlyDedu" runat="server" Text='<%# Bind("CurrentMonthlyDed","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Opening Balance"  HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOpeningBal" runat="server" Text='<%# Bind("OpeningBal","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Closing Balance"  HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("BalanceLoan","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("StartDate", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        <asp:Label ID="LabelGB1" runat="server" Visible="false" Text='<%# Bind("Guaranteed_By1") %>'></asp:Label>
                                                        <asp:Label ID="LabelGB2" runat="server" Visible="false" Text='<%# Bind("Guaranteed_By2") %>'></asp:Label>
                                                        <asp:Label ID="LabelRemarks" runat="server" Visible="false" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                        <asp:Label ID="LabelRecovered" runat="server" Visible="false" Text='<%# Bind("Recovered") %>'></asp:Label> 
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        </asp:Panel> 
                                 <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="grid" TypeName="loanmasterB"  DeleteMethod="delete" OldValuesParameterFormatString="original_{0}"  >--%>
                                    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="delete"
                                        TypeName="loanmasterB" SelectMethod="grid">
                                        <DeleteParameters>
                                            <asp:Parameter Name="LoanId" Type="Int64" />
                                        </DeleteParameters>
                                    </asp:ObjectDataSource>--%>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    &nbsp; &nbsp;&nbsp; </div>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtChequeDate"
                        Format="dd-MMM-yyyy" PopupPosition="TopRight">
                    </ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtStartdate"
                        Format="dd-MMM-yyyy" PopupPosition="TopRight">
                    </ajaxToolkit:CalendarExtender>
                    <style type="text/css">
                        .completeListStyle
                        {
                            height: 100px;
                            width: 50px;
                            overflow: auto;
                            list-style-type: disc;
                            padding-left: 17px;
                            background-color: #FFF;
                            border: 1px solid DarkGray;
                            text-align: left;
                            font-size: small;
                            color: black;
                        }
                    </style>
            </ContentTemplate>
        </asp:UpdatePanel>
        </a>
        <div align="right">
            <a href="#top">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
        </div>
    </center>

</form>
</body>
</html>
