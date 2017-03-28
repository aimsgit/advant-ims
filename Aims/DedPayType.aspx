<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DedPayType.aspx.vb"
    Inherits="DedPayType" Title="PAYABLE DEDUCTION / EARNING" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PAYABLE DEDUCTION / EARNING</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

    <p>
&nbsp;</p>

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlEmployee.ClientID %>"), 'Employee Name');
            if (msg != "") {
                document.getElementById("<%=ddlEmployee.ClientID %>").focus();
                return msg;
            }

            msg = NameField100(document.getElementById("<%=txtAmt.ClientID %>"), 'Amount');
            if (msg != "") {
                document.getElementById("<%=txtAmt.ClientID %>").focus();
                return msg;
            }

            msg = DropDown(document.getElementById("<%=ddlDedtype.ClientID %>"), 'Deduction/Earning Type');
            if (msg != "") {
                document.getElementById("<%=ddlDedtype.ClientID %>").focus();
                return msg;
            }

            msg = ValidateDateN(document.getElementById("<%=txtfrom.ClientID %>"), 'Valid From');
            if (msg != "") {
                document.getElementById("<%=txtfrom.ClientID %>").focus();
                return msg;
            }
            
            msg = ValidateDateN(document.getElementById("<%=txtupto.ClientID %>"), 'Valid Upto');
            if (msg != "") {
                document.getElementById("<%=txtupto.ClientID %>").focus();
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

    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=GVDed.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=500,height=500,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write('<html><body>' + prtGrid.outerHTML + '</body></html>');
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
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
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server" Text="PAYABLE DEDUCTION / EARNING"></asp:Label>
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" Text="Month*&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMonth" TabIndex="1" runat="server" Width="66px" SkinID="ddl">
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
                            <%--</tr>
                        <tr>--%>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" Text="Year*&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                    DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="2" Width="160px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="btnTd" align="center">
                                &nbsp
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="btnTd" align="center">
                                <asp:Button ID="btndeduction" runat="server" SkinID="btnRsz" CausesValidation="False"
                                    Width="250px" CommandName="DEDUCTION" Text="RUN DEDUCTION / EARNING" TabIndex="3"
                                    CssClass="ButtonClass"></asp:Button>
                            </td>
                        </tr>
                       
                    </table>
                    <asp:Label ID="lblmsg1" runat="server" SkinID="lblGreen"></asp:Label>
                    <br />
                    <hr />
                    <br />
               
                                
                          
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmployee" runat="server" Text="Employee Name*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEmployee" runat="server" AutoPostBack="True" DataSourceID="ObjEmplyeeName"
                                    DataTextField="Emp_Name" DataValueField="EmpID" SkinID="ddlRsz" TabIndex="4"
                                    Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjEmplyeeName" runat="server" SelectMethod="GetEmployeeCombo"
                                    TypeName="DLDeduction"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAmount" runat="server" Text="Amount* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAmt" runat="server" TabIndex="5" BorderColor="White" SkinID="txt"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAmt">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblDedPayType" runat="server" SkinID="lblRsz" Text="Deduction/Earning Type*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDedtype" runat="server" DataSourceID="ObjDedType" DataTextField="Data"
                                    DataValueField="DedID" SkinID="ddlRsz" Width="200px" TabIndex="6">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDedType" runat="server" TypeName="DLDeduction" SelectMethod="GetDeductionCombo">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblValidFrom" runat="server" Text="Valid From*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtfrom" runat="server" TabIndex="7" BorderColor="White" SkinID="txt"
                                    CausesValidation="true"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom"
                                    Format="dd-MMM-yyyy" SkinID="CalendarView">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblupto" runat="server" Text="Valid Upto*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtupto" runat="server" TabIndex="8" BorderColor="White" SkinID="txt"
                                    CausesValidation="true"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtupto"
                                    Format="dd-MMM-yyyy" SkinID="CalendarView">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                </center>
                </table>
                <center>
                    <table>
                        <tr>
                            <td class="btnTd" align="center">
                                <br />
                                <br />
                                <asp:Button ID="btnadd" runat="server" SkinID="btn" CausesValidation="True" Text="ADD"
                                    CommandName="ADD" TabIndex="9" CssClass="ButtonClass" OnClientClick="return Validate();">
                                </asp:Button>&nbsp;
                                <asp:Button ID="btnview" runat="server" SkinID="btn" CausesValidation="False"
                                    CommandName="VIEW" Text="VIEW" TabIndex="10" CssClass="ButtonClass"></asp:Button>
                                <asp:Button ID="btnprint" runat="server" SkinID="btn" CausesValidation="False" Enabled="false"
                                    CommandName="PRINT" Text="PRINT" TabIndex="11" CssClass="ButtonClass" OnClientClick="PrintGridData();"></asp:Button>
                            </td>
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
                            <td align="center">
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
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GVDed" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        SkinID="GridView" PageSize="1000" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" Font-Underline="False"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" Visible="True" Font-Underline="False">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false"></ItemStyle>
                                                <ItemStyle HorizontalAlign="Left" Font-Underline="False" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ControlStyle Font-Underline="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee" SortExpression="Emp_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("Did") %>' />
                                                    <asp:Label ID="lblEmpid" Visible="false" runat="server" Text='<%#Bind("EmpID") %>' />
                                                    <asp:Label ID="lblEmpname" runat="server" Width="200px" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmt" runat="server" Width="80px" Text='<%# Bind("Amount","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Deduction/Earning Type" SortExpression="Data">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldedtypeid" Visible="false" runat="server" Text='<%#Bind("LookUpAutoID") %>' />
                                                    <asp:Label ID="lbldedtype" runat="server" Width="230px" Text='<%# Bind("Data") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Valid From" SortExpression="ValidFrom">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValidFrom" runat="server" Width="80px" Text='<%# Bind("ValidFrom","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Valid Upto" SortExpression="Upto">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblupto" runat="server" Width="80px" Text='<%# Bind("Upto","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                </center>
                </table>
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