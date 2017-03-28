<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FormMonthlypaydetails.aspx.vb"
    Inherits="FormMonthlypaydetails" Title="Monthly Pay details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Monthly Pay details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
 
   <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlMonth.ClientID %>"), 'Batch');
            document.getElementById("<%=ddlMonth.ClientID %>").focus();
            if (msg != "") return msg;
            return true;
        }


        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblS.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblS.ClientID%>").textContent = "";
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
                    MONTHLY PAY DETAILS
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
                                <asp:Label ID="lblDeptName" runat="server" Text="Department Name&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLDeptType" runat="server" DataSourceID="objDept" SkinID="ddlRsz"
                                    DataValueField="DeptID" DataTextField="DeptName" TabIndex="3" Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objDept" runat="server" TypeName="SubjectDB" SelectMethod="Getdeptcombo1">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblYear" runat="server" SkinID="lbl" Width="50px" Text="Year* :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <%-- <asp:TextBox ID="txtYear" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    FilterType="Custom" TargetControlID="txtYear" FilterMode="ValidChars" ValidChars="1234567890">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                                <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                    DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:Label ID="lblMonth" runat="server" SkinID="lblRsz" Width="70px"
                                    Text="Month* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" SkinID="ddl" TabIndex="2">
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
                    </table>
                    </br>
                    <table>
                        <tr>
                            <td>
                                &nbsp;<asp:Button ID="btnGenerate" runat="server" Text="GENERATE" TabIndex="3" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btnRsz" Width="100px" />
                                <asp:Button ID="BtnUpdateLoan" runat="server" Text="UPDATE LOAN" TabIndex="4" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btnRsz" Width="120"/>
                                <asp:Button ID="btnView" runat="server" Text="VIEW" TabIndex="4" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" />
                                <asp:Button ID="btnclear" runat="server" Text="CLEAR" SkinID="btn" CssClass="ButtonClass"
                                    TabIndex="5" OnClientClick="return confirm('Do you want to delete the selected record(s)?')" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <center>
                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                            <ProgressTemplate>
                                <div class="PleaseWait">
                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lblS" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
            </a><a name="bottom">
                <br />
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="MD_ID" SkinID="GridView" Width="600px" size="100" PageSize="100"
                        EnableSortingAndPagingCallbacks="True" AllowSorting="True">
                        <RowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="MD_ID" runat="server" Value='<%# Bind("MD_ID") %>' />
                                    <asp:Label ID="lbl1" runat="server" Style="text-align: left;" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                <ItemTemplate>
                                    <asp:Label ID="lbl2" runat="server" Style="text-align: left;" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                    <asp:Label ID="lblEmpId" runat="server" Style="text-align: left;" Text='<%# Bind("EmpID") %>'
                                        Visible="false"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Wrap="false" />
                                <HeaderStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Days Worked">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtdaysworked" runat="server" TabIndex="5" Style="text-align: left;"
                                        Text='<%# Bind("DaysWorked") %>' Width="75px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PL Days">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPLDays" runat="server" TabIndex="5" Style="text-align: left;"
                                        Text='<%# Bind("PLDays") %>' Width="75px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Monthly Incentive">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtmonthins" runat="server" Style="text-align: left;" Text='<%# Bind("MonthlyIncentive","{0:n2}") %>'
                                        Width="75px" TabIndex="6"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bonus">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtbonus" runat="server" Style="text-align: left;" Text='<%# Bind("Bonus","{0:n2}") %>'
                                        Width="75px" TabIndex="7"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reimbursements">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtreimb" runat="server" Style="text-align: left;" Text='<%# Bind("Reimbursements","{0:n2}") %>'
                                        Width="75px" TabIndex="8"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Monthly Payments">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtothrmonthpay" runat="server" Style="text-align: left;" Text='<%# Bind("OthMonthlyPayments","{0:n2}") %>'
                                        Width="75px" TabIndex="9"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IT Deduction">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtITded" runat="server" Style="text-align: left;" Text='<%# Bind("ITTaxDeduction","{0:n2}") %>'
                                        Width="75px" TabIndex="10"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loan Deduction">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtloanded" runat="server" Style="text-align: left;" Text='<%# Bind("LoanDeduction","{0:n2}") %>'
                                        Width="75px" TabIndex="11"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transport Deduction">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txttransded" runat="server" Style="text-align: left;" Text='<%# Bind("TransportDeduction","{0:n2}") %>'
                                        Width="75px" TabIndex="12"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Deduction">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtothrde" runat="server" Style="text-align: left;" Text='<%# Bind("OtherDeduction","{0:n2}") %>'
                                        Width="75px" TabIndex="13"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Salary Advance">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtadvsal" runat="server" Style="text-align: left;" Text='<%# Bind("SaleryAdv","{0:n2}") %>'
                                        Width="75px" TabIndex="14"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Advance Settlement Deduction">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtadvsalded" runat="server" Style="text-align: left;" Text='<%# Bind("AdvStlDeduction","{0:n2}") %>'
                                        Width="75px" TabIndex="15"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtrmrk" runat="server" Style="text-align: left;" Text='<%# Bind("Remarks") %>'
                                        Width="75px" TabIndex="16"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" TabIndex="4" CssClass="ButtonClass"
                                OnClientClick="return Validate();" SkinID="btn" Visible="false" />
                        </td>
                    </tr>
                </table>
                </center>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
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
