<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmNewMonthlyPayDetails.aspx.vb"
    Inherits="FrmNewMonthlyPayDetails" Title="Monthly Pay details" %>

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
                <center>
                    <h1 class="headingTxt">
                        MONTHLY PAY DETAILS
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
                                    <asp:ListItem Value="01">January</asp:ListItem>
                                    <asp:ListItem Value="02">February</asp:ListItem>
                                    <asp:ListItem Value="03">March</asp:ListItem>
                                    <asp:ListItem Value="04">April</asp:ListItem>
                                    <asp:ListItem Value="05">May</asp:ListItem>
                                    <asp:ListItem Value="06">June</asp:ListItem>
                                    <asp:ListItem Value="07">July</asp:ListItem>
                                    <asp:ListItem Value="08">August</asp:ListItem>
                                    <asp:ListItem Value="09">September</asp:ListItem>
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
                                <%--  <asp:Button ID="BtnUpdateLoan" runat="server" Text="UPDATE LOAN" TabIndex="4" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btnRsz" Width="120"/>--%>
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
                        DataKeyNames="MonthId" SkinID="GridView" Width="600px" size="100" PageSize="100"
                        EnableSortingAndPagingCallbacks="True" AllowSorting="True">
                        <RowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="MD_ID" runat="server" Value='<%# Bind("MonthId") %>' />
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
                            <asp:TemplateField HeaderText="Paid Leave">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPLDays" runat="server" TabIndex="5" Style="text-align: left;"
                                        Text='<%# Bind("Paid") %>' Width="75px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LOP">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLOP" runat="server" TabIndex="5" Style="text-align: left;" Text='<%# Bind("NotPaid") %>'
                                        Width="75px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Earnings">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="txtTE" runat="server" TabIndex="5" Style="text-align: left;" Text='<%# Bind("TotalEarnings","{0:n2}") %>'
                                        Width="75px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Deductions">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="txtTD" runat="server" TabIndex="5" Style="text-align: left;" Text='<%# Bind("TotalDeduction","{0:n2}") %>'
                                        Width="75px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Net Salary">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="txtNS" runat="server" TabIndex="5" Style="text-align: left;" Text='<%# Bind("NetSalary","{0:n2}") %>'
                                        Width="75px"></asp:Label>
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

