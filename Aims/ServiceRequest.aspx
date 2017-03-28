<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ServiceRequest.aspx.vb"
    Inherits="ServiceRequest" Title="Service Request / Problem Log" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Service Request / Problem Log</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlprority.ClientID%>"), 'Priority');
            if (msg != "") {
                document.getElementById("<%=ddlprority.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlModule.ClientID%>"), 'Module');
            if (msg != "") {
                document.getElementById("<%=ddlModule.ClientID%>").focus();
                return msg;
            }
            msg = NameField250E(document.getElementById("<%=txtDescription.ClientID%>"), 'Description');
            if (msg != "") {
                document.getElementById("<%=txtDescription.ClientID%>").focus();
                return msg;
            }
             msg = NameField250E(document.getElementById("<%=txtSerReqId.ClientID %>"),'Service Request ID');
            if (msg != "") {
                document.getElementById("<%=txtSerReqId.ClientID %>").focus();
               
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--         <center>
                        <h1 class="headingTxt">
                            SERVICE REQUEST/PROBLEM LOG</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <br />
                </div>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblUserName" runat="server" SkinID="lbl" Text="User Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtuserName" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDate" runat="server" SkinID="lbl" Text="Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmailId" runat="server" SkinID="lbl" Text="Email ID&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmailId" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPhNo" runat="server" SkinID="lbl" Text="Phone No.&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPhNo" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblModule" runat="server" Text="Module*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlModule" runat="server" DataSourceID="ObjModule" DataTextField="ModuleName"
                                    DataValueField="MNIDAuto" SkinID="ddlRsz" TabIndex="5" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjModule" runat="server" SelectMethod="GetModuleName"
                                    TypeName="ServiceRequestD"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPriority" runat="server" SkinID="lbl" Text="Priority*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlprority" runat="server" SkinID="ddl" TabIndex="6">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">High</asp:ListItem>
                                    <asp:ListItem Value="2">Medium</asp:ListItem>
                                    <asp:ListItem Value="3">Low</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDescription" runat="server" SkinID="lbl" Text="Description*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDescription" runat="server" SkinID="txtRsz" TextMode="MultiLine"
                                    TabIndex="7" Height="80px" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSerReqId" runat="server" SkinID="lblRsz" Width="200" Text="Service Request ID*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSerReqId" runat="server" SkinID="txtRsz" TabIndex="8" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSendReq" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    SkinID="btnRsz" Width="150px" OnClientClick="return Validate();" TabIndex="9"
                                    Text="SEND REQUEST" />
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnCheckStatus" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                    Width="150px" TabIndex="10" Text="CHECK STATUS" />
                                &nbsp;
                            </td>
                        </tr>
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
                                        <asp:LinkButton ID="LinkButton3" runat="server" TabIndex="5" CausesValidation="False"
                                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Do you want to Delete the selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Request Date">
                                    <ItemTemplate>
                                        <asp:Label ID="Label0" Visible="false" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("RequestDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Request ID">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("RequestIDAuto") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Request ID">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ServRequestId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Priority">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Priority") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DescOfRequest") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close Date">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("ClosedDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Admin Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
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

