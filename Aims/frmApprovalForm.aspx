<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmApprovalForm.aspx.vb"
    Inherits="frmApprovalForm" Title="Approval Form" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Approval Form</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
 
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 
  <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg, a;
            msg = DropDownForZero(document.getElementById("<%=ddlform.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlform.ClientID %>").focus();

                return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" /> 
   <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <%--  <center>
                    <h1 class="headingTxt">
                        APPROVAL FORM</h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                             <br/>
                             <br/>
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTitle" runat="server" Text="Form Name* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlform" runat="server" SkinID="ddl" TabIndex="1" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                    <asp:ListItem Value="84">Employee Transfer</asp:ListItem>
                                    <asp:ListItem Value="129">Leave Application</asp:ListItem>
                                    <asp:ListItem Value="131">Asset Transfer</asp:ListItem>
                                    <asp:ListItem Value="32">Student Transfer</asp:ListItem>
                                    <asp:ListItem Value="132">Material Indent</asp:ListItem>
                                </asp:DropDownList>
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
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="btnadd" runat="server" Text="SUBMIT" SkinID="btn" TabIndex="2"
                                        CssClass="ButtonClass " OnClientClick="return Validate();" />
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
                <center>
                    <table>
                            <tr>
                                <td>

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
                            <tr>
                                <td>                                    
                                       <div>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblgreen"></asp:Label>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblred"></asp:Label>
                                        </div>                                  
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                </center>
                <center>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" SkinID="GridView"
                        DataKeyNames="AID" AutoGenerateColumns="false" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Form Name">
                                <ItemTemplate>
                                    <asp:Label ID="LabelTableName" runat="server" Text='<%# Bind("TableName") %>'></asp:Label>
                                    <asp:HiddenField ID="HiddenId" runat="server" Value='<%# Bind("AID") %>' />
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("Row_No") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Approval Requested from" SortExpression="Emp_Name">
                                <ItemTemplate>
                                    <asp:Label ID="LabelContriName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                    <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("Emp_Code") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Entry Date" SortExpression="EntryDate">
                                <ItemTemplate>
                                    <asp:Label ID="LabelEntryDate" runat="server" Text='<%# Bind("EntryDate","{0:dd-MMM-yyyy}") %>'
                                        Width="80"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emp Code/Student Code" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="LabelEnrollNo" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtrem" SkinID="txtRsz" Width="120px" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkView" runat="server" CausesValidation="false" CommandName="Delete"
                                        Style="text-decoration: underline; color: Blue;" Text="View"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkApproval" runat="server" CausesValidation="false" CommandName="Edit"
                                        Style="text-decoration: underline; color: Blue;" Text="Approve"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkReject" runat="server" CausesValidation="false" CommandName="Update"
                                        Style="text-decoration: underline; color: Blue;" Text="Reject"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" HeaderText="Contributor Name">
                                <ItemTemplate>
                                    <asp:Label ID="LabelFormName" runat="server" Text='<%# Bind("FormName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" HeaderText="Row id">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowId" runat="server" Text='<%# Bind("Row_No") %>'></asp:Label>
                                    <asp:Label ID="lblLeaveType" runat="server" Text='<%# Bind("Leave_Type") %>'></asp:Label>
                                    <asp:Label ID="lblReason" runat="server" Text='<%# Bind("Expr1") %>'></asp:Label>
                                    <asp:Label ID="lbldaysApplied" runat="server" Text='<%# Bind("DaysApplied") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="true" SkinID="GridView"
                        DataKeyNames="AID" AutoGenerateColumns="false" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Name" SortExpression="Emp_Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenId" runat="server" Value='<%# Bind("AID") %>' />
                                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("EmpId") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="LabelContriName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                    <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("Emp_Code") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Applied Date" SortExpression="EntryDate">
                                <ItemTemplate>
                                    <asp:Label ID="LabelEntryDate" runat="server" Text='<%# Bind("EntryDate","{0:dd-MMM-yyyy}") %>'
                                        Width="80"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leave From">
                                <ItemTemplate>
                                    <asp:Label ID="lblLeaveFrom" runat="server" Text='<%# Bind("LeaveFrom","{0:dd-MMM-yyyy}") %>'
                                        Width="80"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leave To">
                                <ItemTemplate>
                                    <asp:Label ID="lblLeaveTo" runat="server" Text='<%# Bind("LeaveTo","{0:dd-MMM-yyyy}") %>'
                                        Width="80"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delegate Name" SortExpression="DelegateName">
                                <ItemTemplate>
                                    <asp:Label ID="lblDelgName" runat="server" Text='<%# Bind("DelegateName") %>'></asp:Label>
                                    <asp:Label ID="lblDelgEmail" runat="server" Text='<%# Bind("DelegateEmail") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtrem" SkinID="txtRsz" Width="120px" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkView" runat="server" CausesValidation="false" CommandName="Delete"
                                        Style="text-decoration: underline; color: Blue;" Text="View"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkApproval" runat="server" CausesValidation="false" CommandName="Edit"
                                        Style="text-decoration: underline; color: Blue;" Text="Approve"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkReject" runat="server" CausesValidation="false" CommandName="Update"
                                        Style="text-decoration: underline; color: Blue;" Text="Reject"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" HeaderText="Contributor Name">
                                <ItemTemplate>
                                    <asp:Label ID="LabelFormName" runat="server" Text='<%# Bind("FormName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" HeaderText="Row id">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowId" runat="server" Text='<%# Bind("Row_No") %>'></asp:Label>
                                    <asp:Label ID="lblLeaveType" runat="server" Text='<%# Bind("Leave_Type") %>'></asp:Label>
                                    <asp:Label ID="lblReason" runat="server" Text='<%# Bind("Expr1") %>'></asp:Label>
                                    <asp:Label ID="lbldaysApplied" runat="server" Text='<%# Bind("DaysApplied") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </center>
                <style type="text/css">
                    .completeListStyle
                    {
                        height: 100px;
                        width: 200px;
                        overflow: auto;
                        border: 1px solid DarkGray;
                        list-style-type: none;
                        margin: 0px;
                        background-color: #FFF;
                        text-align: left;
                        font-size: small;
                        vertical-align: middle;
                        color: black;
                    }
                </style>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>
