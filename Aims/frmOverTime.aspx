<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmOverTime.aspx.vb" Inherits="frmOverTime"  Title ="Over Time Entry "%>
 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Hostel Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="javascript" type="text/javascript">
 </script>
<script language="javascript" type="text/javascript">
    function Mul() {

    }
    
    
    
    function Valid() {
        var msg;

        msg = DropDownForZero(document.getElementById("<%=ddlDept.ClientID %>"), 'Department');
        if (msg != "") {
            document.getElementById("<%=ddlDept.ClientID %>").focus();
            return msg;
        }
        msg = DropDownForZero(document.getElementById("<%=ddlEmpNo.ClientID %>"), 'Employee No');
        if (msg != "") {
            document.getElementById("<%=ddlEmpNo.ClientID %>").focus();
            return msg;
        }
       
        msg = OneChar(document.getElementById("<%= txtOTRate.ClientID %>"), 'OT Rate');
        if (msg != "") {
            document.getElementById("<%= txtOTRate.ClientID %>").focus();
            return msg;
        }
           
        msg = NameField100(document.getElementById("<%=txtVoucherNo.ClientID %>"), 'Voucher No');
        if (msg != "") {
            document.getElementById("<%=txtVoucherNo.ClientID %>").focus();
            return msg;
        }

        return true;
    }

    function Validate() {
        var msg = Valid();
        if (msg != true) {
            if (navigator.appName == "Microsoft Internet Explorer") {
                document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                return false;
            }
            else if (navigator.appName == "Netscape") {
                document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                return false;
            }
        }
        return true;
    }
      

    </script>
   
 

 
<%--<asp:TextBox ID="TextBoxValue" runat="server" onkeypress="return IsOneDecimalPoint(event);">
<ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender" runat="server" FilterType="Custom"
  ValidChars="01234567890." TargetControlID="TextBoxValue"></ajax:FilteredTextBoxExtender>--%>
 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
        <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                </a> 
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        OVER TIME ENTRY
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                        <td align="right">
                            <asp:Label ID="lblDept" runat="server" Text="Department*^&nbsp:&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept1" DataTextField="DeptName"
                                DataValueField="DeptID" SkinID="ddl" TabIndex="1" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjDept1" runat="server" TypeName="DLOverTime"
                                SelectMethod="GetDepartmentF"></asp:ObjectDataSource>
                        </td>
                       
                           <td align="right">
                            <asp:Label ID="lblmonth" runat="server" SkinID="lblRSZ" Text="Effective Month&nbsp;:&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlMonth" runat="server" SkinID="ddl" TabIndex="2">
                                <asp:ListItem Text="January" Value="January"></asp:ListItem>
                                <asp:ListItem Text="February" Value="February"></asp:ListItem>
                                <asp:ListItem Text="March" Value="March"></asp:ListItem>
                                <asp:ListItem Text="April" Value="April"></asp:ListItem>
                                <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                <asp:ListItem Text="June" Value="June"></asp:ListItem>
                                <asp:ListItem Text="July" Value="July"></asp:ListItem>
                                <asp:ListItem Text="August" Value="August"></asp:ListItem>
                                <asp:ListItem Text="September" Value="September"></asp:ListItem>
                                <asp:ListItem Text="October" Value="October"></asp:ListItem>
                                <asp:ListItem Text="November" Value="November"></asp:ListItem>
                                <asp:ListItem Text="December" Value="December"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmployeeNo" runat="server" SkinID="lblRsz" 
                                    Text="Employee No.*^&nbsp:&nbsp;"></asp:Label>
                            </td>
                            <td>
                               
                            <asp:DropDownList ID="ddlEmpNo" runat="server" DataSourceID="ObjEmp" DataTextField="Emp_Code"
                                DataValueField="EmpID" SkinID="ddl" TabIndex="3" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjEmp" runat="server" TypeName="DLOverTime"
                                SelectMethod="GetEmpCodeCombo">
                                <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlDept" Name="DeptID" Type="String"  PropertyName="SelectedValue" />
                                        </SelectParameters>
                                        </asp:ObjectDataSource>
                                   
                        </td>
                            
                             <td align="right">
                                <asp:Label ID="lblEmpName" runat="server" SkinID="lblRsz" 
                                    Text="Employee Name  &nbsp;:&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpName" runat="server" ReadOnly="true" SkinID="txt" 
                                    TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                       
                            <%--<td align="right">
                                <asp:Label ID="lblBasicSal" runat="server" SkinID="lblRsz" 
                                    Text="Basic Salary*&nbsp;:&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBasicSal" runat="server" SkinID="txt" TabIndex="5" ></asp:TextBox>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                FilterMode="ValidChars" ValidChars="1234567890. " TargetControlID="txtBasicSal">
                            </ajaxToolkit:FilteredTextBoxExtender>
                       
                            </td>--%>
                             <td align="right">
                                <asp:Label ID="lblOTRate" runat="server" SkinID="lblRsz" 
                                    Text="OT Rate*&nbsp:&nbsp;"></asp:Label>
                                    
                            </td>
                            <td>
                                <asp:TextBox ID="txtOTRate" AutoPostBack="true"   runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                               <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                FilterMode="ValidChars" ValidChars="1234567890. " TargetControlID="txtOTRate">
                            </ajaxToolkit:FilteredTextBoxExtender>
  --%>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblVoucherNo" runat="server" SkinID="lblRsz" 
                                    Text="Voucher No* &nbsp;:&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVoucherNo" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                       
                           
                            </tr>
                        <tr>
                        
                         
                             <td align="right">
                                <asp:Label ID="lblNoOfHours"  runat="server" SkinID="lblRsz" 
                                    Text="No.of hours &nbsp;:&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNoOfHours" AutoPostBack="true"  runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                            </td>
                            
                            
                            <td align="right">
                                <asp:Label ID="lblNoOfMinutes" runat="server" SkinID="lblRsz" 
                                    Text="No.of Minutes &nbsp;:&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNoOfMinutes" AutoPostBack="true"   runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                            </td>
                            </tr>
                            
                            <tr>
                               <td align="right">
                                <asp:Label ID="lblTotalAmount" runat="server" SkinID="lblRsz"  
                                    Text="Total Amount&nbsp:&nbsp;"  ></asp:Label>
                                    
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalAmount"  runat="server" SkinID="txt" TabIndex="9" Enabled ="false"  MaxLength="10" ></asp:TextBox>
                               <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                FilterMode="ValidChars" ValidChars="1234567890. " TargetControlID="txtTotalAmount">
                            </ajaxToolkit:FilteredTextBoxExtender>
                           <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTotalAmount" Display="Dynamic" ValidationExpression="^(([0-9]+)(\.[0-9]{2}))$" ErrorMessage="*"></asp:RegularExpressionValidator>--%>
                            </td>
                            
                        </tr>
                        </table>
                        </br>
                        <table >
                        <center>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" 
                                        OnClientClick="return Validate();" SkinID="btn" TabIndex="10" Text="ADD" 
                                        ValidationGroup="ADD" />
                                    &nbsp;<asp:Button ID="btnView" runat="server" CausesValidation="False" 
                                        CssClass="ButtonClass" SkinID="btn" TabIndex="11" Text="VIEW" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </center>
                   </table>
                    <center>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                        <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
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
                   <table>
                        <tr>
                            <td>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" PageSize="100" SkinID="Gridview" Visible="False" AllowSorting ="true"  >
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                    CommandName="Edit" Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                    CommandName="Delete" Font-Underline="False" 
                                                    OnClientClick="return confirm('Do you want to delete the selected record?')" 
                                                    Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="OTId" runat="server" Value='<%# Bind("OT_Id_Auto") %>' 
                                                    Visible="false" />
                                                <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("EmpId") %>' 
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("Emp_Code") %>' 
                                                    Visible="true"></asp:Label>
                                            </ItemTemplate>
                                                  <ItemStyle  HorizontalAlign ="left"  />
                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                                  <ItemStyle  HorizontalAlign ="left"  />
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Department Name" SortExpression="DeptId">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblDeptId" runat="server" Text='<%# Bind("DeptId") %>' 
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblDeptName" runat="server" Text='<%# Bind("DeptName") %>' 
                                                    Visible="true"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Month" SortExpression="EffectiveMonth">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMonth" runat="server" Text='<%# Bind("EffectiveMonth") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                         <%--<asp:TemplateField HeaderText="Basic Salary" SortExpression="BasicSalary">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBasicSalary" runat="server" Text='<%# Bind("BasicSalary","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>--%>
                                        
                                         <asp:TemplateField HeaderText="Voucher No." SortExpression="VoucherNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVoucherNo" runat="server" Text='<%# Bind("VoucherNo") %>'></asp:Label>
                                            </ItemTemplate>
                                                 <ItemStyle  HorizontalAlign ="Right"  />
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="OT Rate" SortExpression="OTRate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOTRate" runat="server" Text='<%# Bind("OTRate","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="No.Of Hours" SortExpression="NoOfHours">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfHours" runat="server" Text='<%# Bind("NoOfHours") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="No.Of Minutes" SortExpression="NoOfMinutes">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfMinutes" runat="server" Text='<%# Bind("NoOfMinutes") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalAmount">
                                            <ItemTemplate >
                                           <%-- <rowStyle HorizontalAlign="Right" />--%>
                                                <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("TotalAmount","{0:n2}") %>'></asp:Label>
                                                 
                                            </ItemTemplate  >
                                              <ItemStyle  HorizontalAlign ="Right"  />
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        
                                         </Columns>
                                </asp:GridView>
                                </asp:Panel> 
                            </td>
                        </tr>
                    </table>
                </center>
                 <a name="bottom">
                        <div align="right">
                            <a href="#top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                        </div>
                    </a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
