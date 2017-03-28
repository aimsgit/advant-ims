<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmLoanSettlement.aspx.vb" Inherits="FrmLoanSettlement" Title ="Loan Settlement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loan Settlement</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

  <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlEmployeeCode.ClientID %>"), 'Employee Code');
            if (msg != "") {
                document.getElementById("<%=ddlEmployeeCode.ClientID %>").focus();
                return msg;
            }
            
                  msg = DropDownForZero(document.getElementById("<%=ddlLoanTypeCode.ClientID %>"), 'Loan Type Code');
            if (msg != "") {
                document.getElementById("<%=ddlLoanTypeCode.ClientID %>").focus();
                return msg;
            }
            
                  msg = DropDownForZero(document.getElementById("<%=ddlStype.ClientID %>"), 'Type');
            if (msg != "") {
                document.getElementById("<%=ddlStype.ClientID %>").focus();
                return msg;
            }
            
                  msg = DropDownForZero(document.getElementById("<%=ddlSMethod.ClientID %>"), 'Method');
            if (msg != "") {
                document.getElementById("<%=ddlSMethod.ClientID %>").focus();
                return msg;
            }

            msg = NameField100(document.getElementById("<%=txtSettlementDate.ClientID %>"), 'Date');
            if (msg != "") {
                document.getElementById("<%=txtSettlementDate.ClientID %>").focus();
                return msg;
            }


            msg = OneChar(document.getElementById("<%=txtNoOfInstallment.ClientID %>"), 'No.Of Installment');
            if (msg != "") {
                document.getElementById("<%=txtNoOfInstallment.ClientID %>").focus();
                return msg;
            }
            
            msg = NameField100(document.getElementById("<%=txtAmount.ClientID %>"), 'Amount');
            if (msg != "") {
                document.getElementById("<%=txtAmount.ClientID %>").focus();
                return msg;
            }


            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }

    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server" Text="LOAN SETTLEMENT"></asp:Label>
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                         <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmployeeCode" runat="server" Text="Employee Code*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlEmployeeCode" runat="server" AutoPostBack="True" DataSourceID="ObjEmplyeeCode"
                                        DataTextField="emp_code" DataValueField="EmpID" SkinID="ddlRsz" TabIndex="1"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjEmplyeeCode" runat="server" SelectMethod="GetEmployeeCombo"
                                        TypeName="DLLoanTypeMaster">
                                       
                                    </asp:ObjectDataSource>
                                    
                                </td>
                                
                                <td align="right">
                                    <asp:Label ID="lblEmpName" runat="server" Text="Employee Name&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz" ></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtRsz" MaxLength="11" Width="198px" Enabled ="false"
                                        TabIndex="2"></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblLoanTypeCode" runat="server" Text="Loan Type Code*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                     <asp:DropDownList ID="ddlLoanTypeCode" runat="server" AutoPostBack="True" DataSourceID="ObjLoanCode"
                                        DataTextField="LoanCode" DataValueField="LoanMaster_Autoid" SkinID="ddlRsz" TabIndex="3"
                                        Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjLoanCode" runat="server" SelectMethod="GetLoanCode"
                                        TypeName="DLLoanTypeMaster">
                                          <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlEmployeeCode" Name="EmpID" Type ="String"  PropertyName="SelectedValue" />
                                        </SelectParameters>
                                        </asp:ObjectDataSource>
                                       
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblDesription" runat="server" Text="Description &nbsp;:&nbsp;&nbsp;" SkinID="lblRsz" ></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescription" runat="server" SkinID="txtRsz" MaxLength="11" Width="198px"
                                        TabIndex="4" Enabled ="false"></asp:TextBox>
                                   
                                </td>
                            </tr>
                           
                           
                            <tr>
                        
                            <td align="right">
                                    <asp:Label ID="lblLoanGivenDate" runat="server" Text="Loan Given Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLoanGivenDate" runat="server" SkinID="txtRsz" MaxLength="11" Width="198px"
                                        TabIndex="5" Enabled ="false" ></asp:TextBox>
                                    
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblLoanAmount" runat="server" Text="Loan Amount&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLoanAmount" runat="server" SkinID="txtRsz" MaxLength="11" Width="198px"
                                        TabIndex="6" Enabled ="false"></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblPaidAmount" runat="server" Text="Paid Amount&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPaidAmount" runat="server" SkinID="txtRsz" MaxLength="11" Width="198px"
                                        TabIndex="7" Enabled ="false"></asp:TextBox>
                                                                   </td>
                                <td align="right">
                                    <asp:Label ID="lblBalanceAmount" runat="server" SkinID="lblRsz" Text="Balance Amount&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBalanceAmount" runat="server" SkinID="txtRsz" Width="198px" Enabled ="false"

                                      TabIndex="8"></asp:TextBox>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblNoOfInstallments" runat="server" Text="No of Installments&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNoOfInstallments" runat="server" SkinID="txtRsz" MaxLength="11" Width="198px"
                                        TabIndex="9" Enabled ="false"></asp:TextBox>
                                                                   </td>
                                <td align="right">
                                    <asp:Label ID="lblBalanceInstallment" runat="server" SkinID="lblRsz" Text="Balance Installment&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBalanceInstallment" runat="server" SkinID="txtRsz" 
                                      Width="198px" TabIndex="10" Enabled ="false"></asp:TextBox>
                                </td>
                            </tr>
                           </table> 
                            <hr />
                             <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Label1" runat="server" Text="SETTLEMENT/ADJUSTMENT"></asp:Label>
                    </h1>
                </center>
                           <table >                           
                            <tr>
                            
                                                        
                             <td align="right">
                           
                                    
                                    <asp:Label ID="lblSType" runat="server" Text="Type* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlStype" runat="server" 
                                        DataTextField="DeptName" DataValueField="DeptID" SkinID="ddlRsz" TabIndex="11"
                                        AppendDataBoundItems="True" Width="200" AutoPostBack ="true" >
                                         <asp:ListItem Value="0"> Select</asp:ListItem>
                                        <asp:ListItem Text="Full" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Partial" Value="2"></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDepartmentCombo"
                                        TypeName="DLStudentLogBook"></asp:ObjectDataSource>
                                --%></td>
                                
                                <td align="right">
                                    <asp:Label ID="lblSMethod" runat="server" Text="Method* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:DropDownList ID="ddlSMethod" runat="server" 
                                        DataTextField="DeptName" DataValueField="DeptID" SkinID="ddlRsz" TabIndex="12"
                                        AppendDataBoundItems="True" Width="200">
                                          <asp:ListItem Value="0"> Select</asp:ListItem>
                                        <asp:ListItem Text="Cash " Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Deduct from Salary" Value="2"></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                    <%--<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetDepartmentCombo"
                                        TypeName="DLStudentLogBook"></asp:ObjectDataSource>
--%>                                </td>
                                </tr>
                             <tr>
                        
                            <td align="right">
                                    <asp:Label ID="lblSettlementDate" runat="server" Text=" Date*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSettlementDate" runat="server" SkinID="txtRsz" MaxLength="11" Width="198px"
                                        TabIndex="13"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                        TargetControlID="txtSettlementDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblNoOfInstallment" runat="server" Text="No.Of Installment*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNoOfInstallment" runat="server" SkinID="txtRsz" MaxLength="11" Width="198px"
                                        TabIndex="14"></asp:TextBox>
                                   
                                </td>
                            </tr>
                            
                            
                           <tr>
                           <td align="right">
                           <asp:Label ID="lblAmount" runat="server" SkinID="lbl" Text="Amount*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAmount" runat="server" SkinID="txtRsz" AutoPostBack ="true" 
                            Width="198px" TabIndex="15"></asp:TextBox>
                             </td>
                             
                             
                              <td align="right">
                           <asp:Label ID="lblLoanBalance" runat="server" SkinID="lbl" Text="Loan Balance&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLoanBalance" runat="server" SkinID="txtRsz" 
                            Width="198px" TabIndex="16" Enabled ="false"></asp:TextBox>
                             </td>
                           </tr> 
                           </table>
                            
                    </center>
                    </table>
                    <center>
                        <table>
                            <tr>
                                <td colspan="2" class="btnTd" align="center">
                                    <br />
                                    <br />
                                    <asp:Button ID="btnadd" runat="server" SkinID="btn" CausesValidation="True" Text="ADD"
                                        CommandName="ADD" TabIndex="17"  CssClass="ButtonClass"  OnClientClick="return Validate();">
                                    </asp:Button>
                                    &nbsp;<asp:Button ID="btndetails" runat="server" SkinID="btn" CausesValidation="False"
                                     Text="VIEW" TabIndex="18" CssClass="ButtonClass" ></asp:Button>
                                   
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                                <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </center>
                 </asp:Panel> 
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
                                                       <%-- <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                            cssproperty="Btnclass" OnClientClick="return confirm('Do you want to delete the selected record?')"--%>
                                                          <%--  Text="Delete">--%>
                                                    <%--    </asp:LinkButton>--%>
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
                                                        <asp:HiddenField ID="HidLoanId" runat="server" Value='<%# Bind("LoanId_Auto") %>'></asp:HiddenField>
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
                                                
                                                  <asp:TemplateField HeaderText="Loan Type" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabeTypeCode" runat="server" Text='<%# Bind("LoanTypeId") %>' Visible ="false" ></asp:Label>
                                                        <asp:Label ID="lblLoanTpeCode" runat="server" Text='<%# Bind("loancode") %>'></asp:Label>
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
                                                
                                                  <asp:TemplateField HeaderText="Balance Installment" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallmentBalance" runat="server" Text='<%# Bind("Balanceinstallment") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Loan Settlement Date" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("LoanSettlementDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Settlement Amount" HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSettlementAmount" runat="server" Text='<%# Bind("SettlementAmount","{0:0.00}") %>'></asp:Label>
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
                                                 <asp:TemplateField HeaderText="Loan Settlement Type"  HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelLoanSType" runat="server" Text='<%# Bind("LoanSettlementType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Loan Settlement Method"  HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabelLoanSettMethod" runat="server" Text='<%# Bind("LoanSettlementMethod") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap ="false"  />
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Balance Loan"  HeaderStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBalanceloan" runat="server" Text='<%# Bind("BalanceLoan","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap ="false"  />
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
            </div>
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
