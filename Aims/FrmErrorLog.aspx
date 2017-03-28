<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmErrorLog.aspx.vb"
    Inherits="FrmErrorLog" Title="Error Log" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Error Log</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    ERROR LOG</h1>
            </center>
            <center>
                <br />
                <br />
                <table id="table1" class="custTable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date :&nbsp;&nbsp;" SkinID="lblRsz" meta:resourcekey="Label8Resource1"
                                Width="150px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtFromdate" TabIndex="5" runat="server" SkinID="txtRsz" AutoPostBack="true"></asp:TextBox><ajaxToolkit:CalendarExtender
                                ID="CE1" runat="server" TargetControlID="TxtFromdate" Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                       <td align="right">
                            <asp:Label ID="lblTodate" runat="server" Text="To Date :&nbsp;&nbsp;" SkinID="lblRsz" meta:resourcekey="Label8Resource1"
                                Width="150px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTodate" TabIndex="5" runat="server" SkinID="txtRsz" AutoPostBack="true"></asp:TextBox><ajaxToolkit:CalendarExtender
                                ID="CalendarExtender1" runat="server" TargetControlID="txtTodate" Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 248px">
                            <asp:Label ID="Label3" runat="server" Text="Status :&nbsp;&nbsp;" SkinID="lblRsz"
                                Style="margin-left: 0px" Width="200px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbStatus" TabIndex="1" runat="server" SkinID="ddl" AutoPostBack="True">
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
                <table>
                    <tr>
                        <td class="btnTd" align="center">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="10" Text="SHOW LOG" OnClientClick="return Validate();" />
                                </td> 
                           <td align="center" class="btnTd">
                            <asp:Button ID="BtnClose" runat="server" CssClass="ButtonClass" SkinID="btnRsz" 
                                TabIndex="10" Text="CLOSE" />
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
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
            </center>
            <center>
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Height="250px" Width="670px">
                    <asp:GridView ID="GVErrorLog" runat="server" Width="584px" SkinID="GridView" DataKeyNames="LogId"
                        AllowPaging="true" AutoGenerateColumns="False" Visible="true" PageSize="100">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndel" runat="server" CausesValidation="false" CommandName="Delete"
                                        Text="Delete" OnClientClick="return confirm('Do you want to Delete the selected record?')" />
                                </ItemTemplate>
                            </asp:TemplateField><asp:TemplateField HeaderText="">
                               <ItemTemplate>
                                   <asp:CheckBox ID="ChkBx" runat="server"></asp:CheckBox>
                               </ItemTemplate>
                             </asp:TemplateField>
                         <%--   <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" runat="server" CausesValidation="false" CommandName="Update"
                                        Text="Close" SkinID="btn" OnClientClick="return confirm('Do you want to Close the selected record?')" />
                                </ItemTemplate>
                                <ItemStyle Wrap="False"></ItemStyle>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Time" meta:resourcekey="TemplateFieldResource2">
                                <ItemTemplate>
                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("LogId") %>' />
                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("ErrorDate","{0:dd-MMM-yyyy hh:mm:ss tt}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Name">
                                <ItemTemplate>
                                    <asp:Label ID="l2" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User">
                                <ItemTemplate>
                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("UserName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Form Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFrm" runat="server" Text='<%# Bind("FormName") %>' />
                                </ItemTemplate>
                                <ItemStyle Wrap="False"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Error Message">
                                <ItemTemplate>
                                    <%-- <asp:Label ID="l4" runat="server" Text='<%# Bind("ErrorMessage") %>' />--%>
                                    <asp:LinkButton ID="btnerror" runat="server" CausesValidation="false" CommandName="Edit"
                                        Text="Show Error Message" />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("Status") %>' />
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
