<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAccountHead.aspx.vb"
    Inherits="frmAccountHead" Title="Account Head Details" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Account Head Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtAccHead.ClientID %>"), 'Account Head ');
            if (msg != "") {
                document.getElementById("<%=txtAccHead.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtUserCod.ClientID %>"), 'User Code ');
            if (msg != "") {
                document.getElementById("<%=txtUserCod.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbAGOne.ClientID %>"), 'Account Group One ');
            if (msg != "") {
                document.getElementById("<%=cmbAGOne.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbAcctOne.ClientID %>"), 'Account One ');
            if (msg != "") {
                document.getElementById("<%=cmbAcctOne.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbAGTwo.ClientID %>"), 'Account Group Two ');
            if (msg != "") {
                document.getElementById("<%=cmbAGTwo.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbAcctTwo.ClientID %>"), 'Account Two ');
            if (msg != "") {
                document.getElementById("<%=cmbAcctTwo.ClientID %>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
           
            return true;
        }
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
        <%-- <center>
            <h1 class="headingTxt">
                ACCOUNT HEAD DETAILS</h1>
        </center>--%>
        <center>
            <h1 class="headingTxt">
                <asp:Label ID="Lblheading" runat="server"></asp:Label>
            </h1>
        </center>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <table class="custTable">
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Width="175px" Text="System Code :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAccCode" runat="server" SkinID="txt" ReadOnly="True" AutoCompleteType="Disabled"
                                    Enabled="False" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Width="175px" Text="Account Head*^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAccHead" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                    MaxLength="100" TabIndex="2"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtAccHead">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" Text="User Defined Code* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="175px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUserCod" runat="server" TabIndex="3" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="175px" Text="Account Group One*^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbAGOne" runat="server" SkinID="ddl" AutoPostBack="True" DataTextField="Acct_Group"
                                    DataValueField="Acct_Group_ID" TabIndex="4">
                                    <asp:ListItem Value="0"> Select</asp:ListItem>
                                    <asp:ListItem Value="1">Assets</asp:ListItem>
                                    <asp:ListItem Value="2">Liabilities</asp:ListItem>
                                    <asp:ListItem Value="3">Income</asp:ListItem>
                                    <asp:ListItem Value="4">Expenses</asp:ListItem>
                                    <asp:ListItem Value="5">Capital Account</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Width="175px" Text="Account One* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbAcctOne" runat="server" SkinID="ddl" DataTextField="Acct_Sub_Group"
                                    DataValueField="Acct_Sub_Group_ID" TabIndex="5">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Width="200px" Text="Account One Treatment* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbAOT" runat="server" SkinID="ddl" TabIndex="6">
                                    <asp:ListItem Value="1">Credit</asp:ListItem>
                                    <asp:ListItem Value="-1">Debit</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" SkinID="lblRsz" Width="175px" Text="Account Group Two*^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbAGTwo" runat="server" SkinID="ddl" AutoPostBack="True" DataTextField="Acct_Group"
                                    DataValueField="Acct_Group_ID" TabIndex="7">
                                    <asp:ListItem Value="0"> Select</asp:ListItem>
                                    <asp:ListItem Value="1">Assets</asp:ListItem>
                                    <asp:ListItem Value="2">Liabilities</asp:ListItem>
                                    <asp:ListItem Value="3">Income</asp:ListItem>
                                    <asp:ListItem Value="4">Expenses</asp:ListItem>
                                    <asp:ListItem Value="5">Capital Account</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Width="175px" Text="Account Two* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbAcctTwo" runat="server" SkinID="ddl" DataTextField="Acct_Sub_Group"
                                    DataValueField="Acct_Sub_Group_ID" TabIndex="8">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Width="200px" Text="Account Two Treatment* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbATT" runat="server" SkinID="ddl" TabIndex="9">
                                    <asp:ListItem Value="1">Credit</asp:ListItem>
                                    <asp:ListItem Value="-1">Debit</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td align="right">
                                <asp:Label ID="Label19" runat="server" Text="Budget Amount :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="175px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBudget" runat="server" TabIndex="9" SkinID="txt"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars"  ValidChars="0123456789." TargetControlID="txtBudget">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        
                        
                        
                        
                        <tr>
                        
                        
                        
                        
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <center>
                                    <asp:Button ID="btnSave" runat="server" SkinID="btn" TabIndex="10" Text="ADD"
                                        CausesValidation="true" CssClass="ButtonClass" OnClientClick="return Validate();" />&nbsp;
                                    <asp:Button ID="btnDetails" runat="server" CausesValidation="False" SkinID="btn"
                                        TabIndex="11" Text="VIEW" CssClass="ButtonClass" />&nbsp;
                                    <asp:Button ID="btnReport" runat="server" CausesValidation="False" SkinID="btn"
                                        TabIndex="12" Text="REPORT" CssClass="btnStyle" Visible="False" />
                                </center>
                            </td>
                        </tr>
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
                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <center>
                    <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                    <asp:Label ID="lblErrorMsg" SkinID="lblRed" runat="server"></asp:Label>
                </center>
                <br />
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <asp:GridView ID="GVGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Account_Head_Id"
                            AllowPaging="True" SkinID="GRIDVIEW" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Visible="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Head" SortExpression="Account_Head">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Account_Head") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Defined Code" SortExpression="User_Defined_Code">
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("User_Defined_Code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="System Code" SortExpression="Account_Code">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="AccID" runat="server" Value='<%#Bind("Account_Head_Id") %>' />
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Account_Code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Group One">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("MainAcct") %>'></asp:Label>
                                        <asp:Label ID="Label15" runat="server" Visible="false" Text='<%# Bind("Acct_Group_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account One">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("[Acc One]") %>'></asp:Label>
                                        <asp:Label ID="Label14" runat="server" Visible="false" Text='<%# Bind("Acct_One") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Treatment One">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Acct1") %>'></asp:Label>
                                        <asp:Label ID="Label13" runat="server" Visible="false" Text='<%# Bind("Acct_One_treatment") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Group Two">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Acct_Group") %>'></asp:Label>
                                        <asp:Label ID="Label12" runat="server" Visible="false" Text='<%# Bind("Account_heads_Acct_Group_Two") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Two">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("[Acc Two]") %>'></asp:Label>
                                        <asp:Label ID="Label11" runat="server" Visible="false" Text='<%# Bind("Acct_two") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Treatment Two">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Acct2") %>'></asp:Label>
                                        <asp:Label ID="Label10" runat="server" Visible="false" Text='<%# Bind("Acct_Two_treatment") %>'></asp:Label>
                                        <asp:Label ID="lblBranchCode" runat="server" Visible="false" Text='<%# Bind("BranchCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Budget Amount" SortExpression="BudgetAmount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBudget" runat="server" Text='<%# Bind("BudgetAmount","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </asp:Panel> 
                </center>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                    </div>
                </a>
            </ContentTemplate>
            <%--<Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnDetails" EventName="Click"></asp:AsyncPostBackTrigger>
            </Triggers>--%>
        </asp:UpdatePanel>
    </div>

</form>
</body>
</html>
