<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmEarnDed.aspx.vb" Inherits="frmEarnDed" title="Earnings/Deductions Code Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Earnings/Deductions Code Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <script type="text/javascript" language="javascript">
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
            msg = NameField100Mul(document.getElementById("<%= txtDesription.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%= txtDesription.ClientID %>").focus();
                a = document.getElementById("<%=lblDescription.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
           
            msg = CodeFieldMul(document.getElementById("<%= txtEarnDedCode.ClientID %>"));
            
            if (msg != "") {
                document.getElementById("<%= txtEarnDedCode.ClientID %>").focus();
                a = document.getElementById("<%=lblEarnDedCode.ClientID %>").innerHTML;
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
                document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
                document.getElementById("<%=lblmsgifo.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div class="mainBlock">
               
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" Text="EARNINGS/DEDUCTIONS CODE MASTER" runat="server"></asp:Label>
                    </h1>
                      </center>
                       <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                                  
                      <center >
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                    
                          <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDescription" runat="server" SkinID="lblRsz" Text=" Description*&nbsp;:&nbsp;&nbsp;"
                                    Width="150px"></asp:Label>
                            </td>
                        
                                 <td>
                            <asp:TextBox ID="txtDesription" runat="server" SkinID="txtRsz" TabIndex="1" Width="150" ></asp:TextBox>
                      
                            </td>
                        
                            <td align="right">
                                <asp:Label ID="lblSubDescription" runat="server" SkinID="lblRsz" Text=" Sub Description &nbsp;:&nbsp;&nbsp;"
                                    Width="150px"></asp:Label>
                            </td>
                        
                                 <td>
                            <asp:TextBox ID="txtSubDescription" runat="server" SkinID="txtRsz" TabIndex="2" Width="150" ></asp:TextBox>
                      
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEarnDedCode" runat="server" SkinID="lblRsz" Text=" Earn/Ded Code*^&nbsp;:&nbsp;&nbsp;"
                                    Width="150px"></asp:Label>
                            </td>
                        
                                 <td>
                            <asp:TextBox ID="txtEarnDedCode" runat="server" SkinID="txtRsz" TabIndex="3" Width="150" ></asp:TextBox>
                      
                            </td>
                      
                            <td align="right">
                                <asp:Label ID="lblEarnDedType" runat="server" SkinID="lblRsz" Text="Earn/Ded Type*&nbsp;:&nbsp;&nbsp;" Width="150px"></asp:Label>
                            </td>
                           <td align="left">
                                <asp:DropDownList ID="ddlEarnDed" runat="server" SkinID="ddl" TabIndex="4">
                                    <asp:ListItem Value ="E">E</asp:ListItem>
                                    <asp:ListItem value="D">D</asp:ListItem>
                                          <asp:ListItem value="L">L</asp:ListItem>
                                </asp:DropDownList>
                            </td> 
                         
                        </tr
                        <tr>
                        <td align="right">
                                <asp:Label ID="lblTaxable" runat="server" SkinID="lblRsz" Text="Taxable*&nbsp;:&nbsp;&nbsp;" Width="150px"></asp:Label>
                            </td>
                           <td align="left">
                                <asp:DropDownList ID="ddlTaxable" runat="server" SkinID="ddl" TabIndex="5">
                                    <asp:ListItem Value ="Y">Y</asp:ListItem>
                                    <asp:ListItem value="N">N</asp:ListItem>
                                </asp:DropDownList>
                            </td> 
                            <td align="right">
                                <asp:Label ID="lblPFApplicable" runat="server" SkinID="lblRsz" Text="PF Applicable*&nbsp;:&nbsp;&nbsp;" Width="150px"></asp:Label>
                            </td>
                           <td align="left">
                                <asp:DropDownList ID="ddlPFApplicable" runat="server" SkinID="ddl" TabIndex="6">
                                    <asp:ListItem Value ="Y">Y</asp:ListItem>
                                    <asp:ListItem value="N">N</asp:ListItem>
                                </asp:DropDownList>
                            </td> 
                        
                        </tr>
                        <tr>
                            <td></td>
                               <td></td>
                                  <td></td>
                             <td align="left">
                                                <asp:CheckBox ID="ChkBoxHeader" SkinID="chk" TabIndex="7" Text="Stop" runat="server" Checked="false" />
                                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                         </table>
                        </centre>
                        <center >
                        <table>
                       
                    
                        <tr>
                        
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSave" runat="server" Text="ADD" SkinID="btn" CausesValidation="true"
                                    CommandName="ADD" TabIndex="8" OnClientClick="return Validate();" CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="btnView" runat="server" Text="VIEW" SkinID="btn" CausesValidation="False"
                                    CommandName="VIEW" TabIndex="9" CssClass="ButtonClass" />
                           
                        </td>
                        
                        </tr>
                         </table>
                        </center>
                        
                   
                    <br />
                    <center>
                        <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                    </center>
                    <br />
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
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Earning/ Deduction Code" Visible="true" SortExpression="Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("LookUpAutoID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Long Description" Visible="true" SortExpression="Data">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLongDescription" runat="server" Text='<%# Bind("Data") %>' Width="120"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Center" Width="150" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="150" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Short Description" Visible="true" SortExpression="SubDesc">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubDes" runat="server" Text='<%# Bind("SubDesc") %>' Width="110"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Center" Width="150" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="150" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Earn/Ded Type" Visible="true" SortExpression="Type" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%# Bind("Type") %>' Width="100"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Center" Width="150" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="150" />
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="Taxable" Visible="true" SortExpression="Taxable">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaxable" runat="server" Text='<%# Bind("Taxable") %>' Width="70"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Center" Width="150" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="150" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="PF Applicable" Visible="true" SortExpression="PFApplicable">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPF" runat="server" Text='<%# Bind("PFApplicable") %>' Width="90"></asp:Label>
                                             </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Center" Width="150" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="150" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Stop Salary">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsalaryStop" runat="server" Text='<%# Bind("StopSalary") %>' Width="90"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Center" Width="150" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" Width="150" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                   
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>
         </center>
         </div> 
</form>
</body>
</html>


