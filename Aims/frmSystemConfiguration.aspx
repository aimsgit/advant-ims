<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSystemConfiguration.aspx.vb"
    Inherits="frmSystemConfiguration" Title="System Configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>System Configuration</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function ValidV() {
            var msg;
            //            msg = DropDownForZero(document.getElementById("<%=DdlSelectClient.ClientID%>"), 'Select Client');
            //            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=DdlSelectBranch.ClientID%>"), 'Select Branch');
            if (msg != "") return msg;
            return true;
        }
        function ValidateV() {
            var msg = ValidV();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DdlSelectClient.ClientID%>"), 'Select Client');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=DdlSelectBranch.ClientID%>"), 'Select Branch');
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtName.ClientID%>"), 'Name');
            if (msg != "") return msg;
            msg = Feild250(document.getElementById("<%=txtValue.ClientID%>"), 'Value');
            if (msg != "") return msg;
            msg = Dateone(document.getElementById("<%=txtDate.ClientID%>"), 'Date');
            if (msg != "") return msg;
            return true;
        }


        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

 
   <asp:UpdatePanel runat="server" ID="UP1">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    SYSTEM CONFIGURATION
                </h1>
            </center>
            <center>
                <table class="custTable">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblselectClient" runat="server" SkinID="lblRSZ" Width="180px" Text="Select Client*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectClient" runat="server" AutoPostBack="True" DataSourceID="ObjSelectClient"
                                DataTextField="MyCo_Name" DataValueField="MyCo_Code" SkinID="ddlRsz" TabIndex="1"
                                Width="260px">
                                <%--<asp:ListItem Text="Select" Value="0"></asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectClient" runat="server" SelectMethod="GetClientCombo"
                                TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSelectBranch" runat="server" SkinID="lblRsz" Width="180px" Text="Select Branch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectBranch" runat="server" SkinID="ddlRsz" TabIndex="2"
                                AppendDataBoundItems="False" DataValueField="BranchCode" DataTextField="BranchName"
                                DataSourceID="ObjSelectBranch" Width="260px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectBranch" runat="server" SelectMethod="GetBranchCombo"
                                TypeName="BLClientContractMaster">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DdlSelectClient" DefaultValue="0" Name="Mycode"
                                        PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="Name*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                        </td>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Value*&nbsp;:&nbsp;&nbsp;"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValue" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Text="Date*&nbsp;:&nbsp;&nbsp;"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                    SkinID="CalendarView" TargetControlID="txtDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Text="Description&nbsp;:&nbsp;&nbsp;"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="180px" Text="Read Only*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlReadOnly" runat="server" AppendDataBoundItems="True" SkinID="ddl">
                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 74px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </tr>
                </table>
            </center>
            <center>
                <table>
                    <tr>
                        <td class="btnTd" colspan="2">
                            <asp:Button ID="BtnSave" TabIndex="7" runat="server" Text="ADD" CausesValidation="True"
                                SkinID="btn" OnClientClick="return Validate();" CssClass="ButtonClass"></asp:Button>&nbsp;
                            <asp:Button ID="BtnView" TabIndex="8" runat="server" Text="VIEW" CausesValidation="False"
                                SkinID="btn" OnClientClick="return ValidateV();" CssClass="ButtonClass"></asp:Button>&nbsp;
                            <asp:Button ID="BtnDefault" TabIndex="8" runat="server" OnClientClick="return ValidateV();"
                                Text="Get Default Settings" CausesValidation="False" SkinID="btnRsz" Width="150px"
                                CssClass="ButtonClass"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        SkinID="GridView" TabIndex="9" PageSize="100">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                        Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="LblConfigID" runat="server" Visible="false" Text='<%# Bind("Config_AutoNo") %>'></asp:Label>
                                    <asp:Label ID="LblName" runat="server" Text='<%# Bind("Config_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Value">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranch" runat="server" Visible="false" Text='<%# Bind("BranchCode") %>'></asp:Label>
                                    <asp:Label ID="LblValue" runat="server" Text='<%# Bind("Config_Value") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="LblDate" runat="server" Text='<%# Bind("Date_Value","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="LblDesc" runat="server" Text='<%# Bind("Config_Description") %>'></asp:Label>
                                    <asp:Label ID="lblReadOnly" runat="server" Visible="false" Text='<%# Bind("ReadOnly") %>'></asp:Label>
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
