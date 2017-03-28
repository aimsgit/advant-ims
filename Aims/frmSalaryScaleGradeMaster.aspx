<%@ Page Title="Salary Scale Grade Master" Language="VB"
    AutoEventWireup="false" CodeFile="frmSalaryScaleGradeMaster.aspx.vb" Inherits="frmSalaryScaleGradeMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Salary Scale Grade Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

   <script language="JavaScript" type="text/javascript">
        //Function for Multilingual Validations
        //Created By Niraj
        function ErrorMessage(msg) {
            var SesVar = '<%= Session("Validation") %>';
            var ValidationArray = new Array();
            ValidationArray = SesVar.split(":");
            for (var i = 0; i < ValidationArray.length - 1; i++) {
                if (ValidationArray[i] == msg) {
                    return ValidationArray[i + 1];
                }
            }
        }


        function Spliter(a) {
            var str = a;
            var n = str.indexOf("*");
            if (n != 0 && n != -1) {
                a = a.split("*");
                return a[0];
            }
            var n = str.indexOf("^");
            if (n != 0 && n != -1) {
                a = a.split("^");
                return a[0];
            }
            var n = str.indexOf(":");
            if (n != 0 && n != -1) {
                a = a.split(":");
                return a[0];
            }
        }
        function Valid() {
            var msg;
            msg = NameField100Mul(document.getElementById("<%=txtsalary.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtsalary.ClientID %>").focus();
                a = document.getElementById("<%=lblSalaryBand.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
          
          
            msg = Field250Mul(document.getElementById("<%=txtMinScale.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMinScale.ClientID %>").focus();
                a = document.getElementById("<%=lblMinScale.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field250Mul(document.getElementById("<%=txtMaxScale.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMaxScale.ClientID %>").focus();
                a = document.getElementById("<%=lblMaxScale.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
           <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                </a> 
                <center>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" Text ="SALARY CODE/SCALE MASTER" runat="server"></asp:Label>
                        </h1>
                    </center>
                </center>
                &nbsp;
                <center>
                    <table>
                        <center>
                            <tr>
                                <caption>
                                    <td align="right">
                                        <asp:Label ID="lblSalaryBand" runat="server" SkinID="lblRsz" Text="Salary Code*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtsalary" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                    </td>
                                </caption>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblemptype" runat="server" Text="Employee Category&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtemptype" runat="server" SkinID="txtrsz" TabIndex="2" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblGrade" runat="server" Text="Grade&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtGrade" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblMinScale" runat="server" Text="Min Scale*&nbsp;:&nbsp;&nbsp;" Width="180"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMinScale" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblMaxscale" runat="server" Text="Max Scale* :&nbsp;&nbsp;" Width="180"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMaxscale" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                </td>
                            </tr>
                            </table>
                            </center>
                            <center >
                            <table >
                            <tr>
                               
                                    <td colspan="4">
                                        <hr />
                                    </td>
                            </tr>
                            <tr>
                                <center>
                                    <tr>
                                        
                                        <td align="right">
                                            <asp:Label ID="lblstep1" runat="server" Text="Step1 :&nbsp;&nbsp;" Width="100" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtstep1" runat="server" SkinID="txtRsz" Width="120" TabIndex="5"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                FilterMode="validChars" FilterType="Custom" TargetControlID="txtstep1" ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblInc1" runat="server" Text="Increment1 :&nbsp;&nbsp;" Width="120" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtInc1" runat="server" SkinID="txtRsz" Width="120" TabIndex="6"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td align="right">
                                            <asp:Label ID="lblstep2" runat="server" Text="Step2 :&nbsp;&nbsp;" Width="100" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtstep2" runat="server" SkinID="txtRsz" Width="120" TabIndex="8"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                FilterMode="validChars" FilterType="Custom" TargetControlID="txtstep2" ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblInc2" runat="server" Text="Increment2 :&nbsp;&nbsp;" Width="120" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtInc2" runat="server" SkinID="txtRsz" Width="120" TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td align="right">
                                            <asp:Label ID="lblstep3" runat="server" Text="Step3 :&nbsp;&nbsp;" Width="100" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtstep3" runat="server" SkinID="txtRsz" Width="120" TabIndex="8"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                FilterMode="validChars" FilterType="Custom" TargetControlID="txtstep3" ValidChars=".0123456789">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblInc3" runat="server" Text="Increment3 :&nbsp;&nbsp;" Width="120" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtInc3" runat="server" SkinID="txtRsz" Width="120" TabIndex="9"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="4">
                                    <center>
                                        <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" OnClientClick="return Validate()"
                                            SkinID="btn" Text="ADD" CommandName="ADD" TabIndex="11"  />
                                        &nbsp;<asp:Button ID="btnView" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="12" CommandName="VIEW" Text="VIEW" />
                                    </center>
                                </td>
                            </tr>
                        </center>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <%--<td align="left">
                                    &nbsp;
                                </td>--%>
                    </tr>
                    </table>
                 <center>
                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <br />
                <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="300px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Edit"
                                                        Text="Edit"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                                        Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                    <br />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Salary Code" SortExpression ="SalaryBand">
                                                <ItemTemplate>
                                               
                                                    <asp:Label ID="LblSalBand" runat="server" Text='<%# Bind("SalaryBand") %>'> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Type" SortExpression ="EmployeeType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemptype" runat="server" Text='<%# Bind("EmployeeType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade" SortExpression ="Grade">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGrade" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                                                    <asp:Label ID="lblid" runat="server" Visible="false" Text='<%# Bind("Grade_Auto") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MinScale" SortExpression ="Min_Scale">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblminscale" runat="server" Text='<%# Bind("Min_Scale") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inc1XStep1">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstep1" runat="server" Text='<%#Bind("step1")%>'></asp:Label>
                                                    <asp:Label ID="lblinc1" runat="server" Visible="false" Text='<%# Bind("Inc1") %>'></asp:Label>
                                                    <asp:Label ID="lblstp1" runat="server" Visible="false" Text='<%# Bind("Step_1") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inc2XStep2">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstep2" runat="server" Text='<%#Bind("step2")%>'></asp:Label>
                                                    <asp:Label ID="lblinc2" runat="server" Visible="false" Text='<%# Bind("Inc2") %>'></asp:Label>
                                                    <asp:Label ID="lblstp2" runat="server" Visible="false" Text='<%# Bind("Step_2") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inc3XStep3">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstep3" runat="server" Text='<%#Bind("step3")%>'></asp:Label>
                                                    <asp:Label ID="lblinc3" runat="server" Visible="false" Text='<%# Bind("Inc3") %>'></asp:Label>
                                                    <asp:Label ID="lblstp3" runat="server" Visible="false" Text='<%# Bind("Step_3") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MaxScale" SortExpression ="Max_Scale">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmaxscale" runat="server" Text='<%# Bind("Max_Scale") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </center>
               <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
