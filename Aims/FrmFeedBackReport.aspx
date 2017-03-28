<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmFeedBackReport.aspx.vb"
    Inherits="FrmFeedBackReport" Title="Feedback Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vehicle Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        FEEDBACK
                        <br />
                        <br />
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstartdate" Width="150px" runat="server" Text="From Date :&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtstartdate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtstartdate"
                                    Enabled="True">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtstartdate" Enabled="True">
                                </ajaxToolkit:CalendarExtender>
                                &nbsp; &nbsp;
                            </td>
                            <td align="right">
                                <asp:Label ID="lblenddate" runat="server" SkinID="lblRsz" Text="To Date :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtenddate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtenddate"
                                    Enabled="True">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtenddate" Enabled="True">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Status :&nbsp;&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbStatus" TabIndex="3" runat="server" SkinID="ddlRsz" Width="153px" AutoPostBack="True">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                <asp:ListItem Text="Open" Value="Open"></asp:ListItem>
                                <asp:ListItem Text="Close" Value="Close"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                         <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Total Count :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150px"></asp:Label>
                        </td>
                        <td style="width: 3px">
                            <asp:TextBox ID="txttotalcount" runat="server" SkinID="txt"></asp:TextBox>
                        </td>
                    </tr>                        
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <center>
                        <table>
                            <tr>
                                <td colspan="2" class="btnTd">
                                    <asp:Button ID="btnView" TabIndex="4" runat="server" Text="VIEW" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>&nbsp;
                                    <asp:Button ID="BtnClose" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5" Text="CLOSE"> 
                                    </asp:Button>&nbsp;
                                    <asp:Button ID="btnReport" TabIndex="6" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="780px" Height="400px">
                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="True"
                            Visible="True" AutoGenerateColumns="False" PageSize="100" AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True">
                            <Columns>
<%--                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndel" runat="server" CausesValidation="false" CommandName="Delete"
                                        Text="Delete" OnClientClick="return confirm('Do you want to Delete the selected record?')" />
                                </ItemTemplate>
                            </asp:TemplateField>
--%>                         
                            <asp:TemplateField HeaderText="">
                               <ItemTemplate>
                                   <asp:CheckBox ID="ChkBx" runat="server"></asp:CheckBox>
                               </ItemTemplate>
                             </asp:TemplateField>                                                       
                             <asp:TemplateField HeaderText="Feedback Date" SortExpression="DateEntry">
                                    <ItemTemplate>
                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("FB_ID")%>' />
                                    <asp:Label ID="lblFeedDate" runat="server" Text='<%# Bind("DateEntry","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Name" SortExpression="BranchName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>' Width="180px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" Width="170px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%#Bind("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactNo" runat="server" Text='<%#Bind("ContactNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Feature(childLink)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChildLink" runat="server" Text='<%#Bind("ChildName") %>' Width="100"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" Width="90" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Feedback">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFeedback" runat="server" Text='<%#Bind("FeedBack") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Suggestion">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSugeestion" runat="server" Width="250px" Text='<%#Bind("Suggestion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" HorizontalAlign="left"></ItemStyle>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("Status")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
