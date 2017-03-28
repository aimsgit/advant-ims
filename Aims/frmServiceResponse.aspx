<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmServiceResponse.aspx.vb"
    Inherits="frmServiceResponse" Title="Service Response" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Service Response</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        
    </script>

<form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        SERVICE RESPONSE</h1>
                </center>
                <br />
                <br />
            </div>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblReqID" runat="server" SkinID="lbl" Text="Request ID :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtReqID" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblUsername" runat="server" SkinID="lbl" Text="User Name :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUsername" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblInsttute" runat="server" SkinID="lbl" Text="Institute Name :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtInstitute" runat="server" SkinID="txtRsz" Width="250" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBranchname" runat="server" SkinID="lbl" Text="Branch Name :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBranchname" runat="server" SkinID="txtRsz" Width="250" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStatus" runat="server" SkinID="lbl" Text="Status :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddl" TabIndex="5">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Open</asp:ListItem>
                                <asp:ListItem Value="2">Close</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblResponsedate" runat="server" SkinID="lbl" Text="Response Date :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtResponsedate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtResponsedate"
                                Format="dd-MMM-yyyy" SkinID="Calendar">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblPriority" runat="server" SkinID="lbl" Text="Priority :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlpriority" runat="server" SkinID="ddl" TabIndex="5">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">High</asp:ListItem>
                                <asp:ListItem Value="2">Medium</asp:ListItem>
                                <asp:ListItem Value="3">Low</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblRequest" runat="server" SkinID="lbl" Text="Request :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtrequest" runat="server" SkinID="txtRsz" Height="80px" Width="200px"
                                TextMode="MultiLine" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblResponse" runat="server" SkinID="lbl" Text="Response :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtResponse" runat="server" SkinID="txtRsz" Height="80px" Width="200px"
                                TextMode="MultiLine" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <center>
                        <tr>
                            <td>
                                <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="2"
                                    Text="UPDATE" />&nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="3"
                                    Text="VIEW" />
                            </td>
                        </tr>
                    </center>
                </table>
                <br />
                <center>
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                </center>
                <br />
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display."
                        SkinID="GridView" AllowPaging="True" PageSize="100">
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Respond"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Request Date">
                                <HeaderStyle Wrap="false" />
                                <ItemTemplate>
                                    <asp:Label ID="Label0" Visible="false" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("RequestDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                            </asp:TemplateField>
                            <%--  <asp:TemplateField HeaderText="Request ID">
                                <HeaderStyle Wrap="false" />
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("RequestIDAuto") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Request ID">
                                <HeaderStyle Wrap="false" />
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ServRequestId") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Message">
                                <ItemTemplate>
                                    <asp:Label ID="lblMessage" runat="server" Text='<%# Bind("DescOfRequest")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ph No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhNo" runat="server" Text='<%# Bind("PhNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Module">
                                <ItemTemplate>
                                    <asp:Label ID="lblModule" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Institute Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("MyCo_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Priority">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Priority") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Close Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("ClosedDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    <asp:Label ID="Label10" Visible="false" runat="server" Text='<%# Bind("DescOfRequest") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Response" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Label11" Visible="true" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Wrap="false" />
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