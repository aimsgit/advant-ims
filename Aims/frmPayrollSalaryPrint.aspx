<%@ Page Title="" Language="VB" AutoEventWireup="false"
    CodeFile="frmPayrollSalaryPrint.aspx.vb" Inherits="frmPayrollSalaryPrint" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payroll Salary Cheque Print</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
   
         <script language="JavaScript" type="text/javascript">
         
             function RunExe() {
                 var SesVar = '<%= Session("PayrollChequepath") %>';
                 alert(SesVar);
                 var oShell = new ActiveXObject("WScript.Shell");
                 alert(oShell);
                 var prog = SesVar;
                 alert(prog);
                 oShell.Run('"' + prog + '"', 1);
                 alert(  oShell.Run('"' + prog + '"', 1));
             }  
      
    </script>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        PAYROLL SALARY CHEQUE PRINT
                    </h1>
                </center>
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblStartChqNo" runat="server" Text=" Cheque Details" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblMonth" runat="server" Text="Salary Month* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlMonth" runat="server" DataSourceID="ObjSelectMonth" DataTextField="Data"
                                        DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSelectMonth" runat="server" SelectMethod="ddlMonth"
                                        TypeName="DLPayRollSalaryPrint"></asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblAddChqNo" runat="server" Text="Add Cheque No.* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAddChqNo" runat="server" AutoPostBack="True" TabIndex="1" SkinID="txt"></asp:TextBox>
                                </td>
                                <%--<td align="left">
                                    <asp:TextBox ID="txtstartChqNo" runat="server" AutoPostBack="True" TabIndex="1" SkinID="txt"></asp:TextBox>
                                </td>--%>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblyear" runat="server" Text="Salary Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                        DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="DLPayRollSalaryPrint">
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="Add Bank Code* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlbank" runat="server" DataTextField="Bank_Name" DataSourceID="ObjBank"
                                        DataValueField="Bank_IDAuto" SkinID="ddl" TabIndex="3" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBank" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="ddlBank" TypeName="DLPayRollSalaryPrint"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="left">
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblChequeDate" runat="server" Text="Add Cheque Date* :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="170px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtChequeDate" runat="server" SkinID="txt" MaxLength="11" TabIndex="5"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                        TargetControlID="txtChequeDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td align="left">
                                    &nbsp;<asp:Button ID="btnLoad" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="2" CommandName="LOAD" Text="LOAD DATA" Width="150px" OnClientClick="return Validate();" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnGenerate" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        CommandName="APPROVE" TabIndex="4" Text="GENERATE CHEQUE NO" Width="180px" />
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnClear" runat="server" CssClass="ButtonClass" SkinID="btnRsz" CommandName="APPROVE"
                                        TabIndex="4" Text="CLEAR CHEQUE NO" Width="180px"/>
                                </td>
                                <td align="left">
                                    <asp:Button ID="BtnPrint" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="4"
                                        Text="PRINT CHEQUE" Width="150px" CausesValidation="False" />
                                </td>
                                <asp:Button ID="btnLock" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="12"
                                    Text="LOCK/UNLOCK" Width="120px" />
                            </tr>
                        </table>
                    </center>
                    <br />
                    <center>
                        <div>
                            <center>
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </center>
                        </div>
                    </center>
                    <br />
                    <center>
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                    </center>
                    <br />
                    <center>
                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="100" SkinID="GridView" TabIndex="-1" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                Text="Eligible" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" />
                                            <asp:Label ID="LabelPre" runat="server" Text='<%# Bind("Eligible") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code">
                                        <ItemTemplate>
                                            <%-- <asp:HiddenField ID="lblADId" runat="server" Value='<%# Eval("Std_Id") %>' />--%>
                                            <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Salary Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarks" runat="server" Text='<%# Bind("NetSalary","{0:0.00}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque Number" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCheque" runat="server" Text='<%# Bind("ChequeNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque Date" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Bind("ChequeDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bank Code" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBCode" runat="server" Text='<%# Bind("BankCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </asp:Panel>
                <center>
                    <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPassword" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblpassError" runat="server" SkinID="lblRed" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </center>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="Images/top.png" Width="30px" />
                        </a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>