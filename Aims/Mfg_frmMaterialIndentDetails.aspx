<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_frmMaterialIndentDetails.aspx.vb" Inherits="Mfg_frmMaterialIndentDetails" title="Material Indent details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Material Indent details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

<%--<script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DdlBatch.ClientID%>"), 'Batch')
            if (msg != "") {
                document.getElementById("<%=DdlBatch.ClientID%>").focus();
                return msg;
            }
           
            return true;
        }


        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
        
         function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlScholarship.ClientID%>"), 'Scholar')
            if (msg != "") {
                document.getElementById("<%=ddlScholarship.ClientID%>").focus();
                return msg;
            }
           
            return true;
        }


        function Validate1() {

            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    
    
    </script>
    
--%>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        MATERIAL INDENT DETAILS
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblItemDesc" runat="server" Text="Item description:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlItemDesc" runat="server" DataTextField="Batch_No" DataSourceID="ObjItemDescription"
                                        DataValueField="BatchID" Width="240px" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjItemDescription" runat="server" SelectMethod="GetBatchDDL" TypeName="WelfareActivityDL">
                                    </asp:ObjectDataSource>
                                     
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                     
                                         <asp:TextBox ID="txtQuantity" SkinID="txt" runat="server" TabIndex="2"></asp:TextBox>
                              </td>
                            </tr>
                    </table>
                        <br />
                        <center>
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="5"
                                            Text="ADD" Width="80px" OnClientClick="return Validate();" />
                                        <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            TabIndex="6" Text="VIEW" Width="100px" OnClientClick="return Validate1();" />
                                        <asp:Button ID="btnClose" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            TabIndex="7" Text="CLOSE" Width="100px" OnClientClick="return Validate1();" />
                                         
                                    </td>
                                </tr>
                            </table>
                            <div>
                                <center>
                                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                                Processing your request..please wait...
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
                        <center>
                            <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" TabIndex="-1" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                         <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Text="Edit" cssproperty="Btnclass"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                                            cssproperty="Btnclass" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Description">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="lblADId" runat="server" Value='<%# Eval("Std_Id") %>' />
                                                <asp:Label ID="lblStdCode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMarks" runat="server" Text='<%# Bind("Marks") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </center>
                </asp:Panel>
                <%--<center>
                    <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPassword" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" OnTextChanged="btnPassword_click"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                                        OnClientClick="btnPassword_click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblpassError" runat="server" SkinID="lblRed" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </center>--%>
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

