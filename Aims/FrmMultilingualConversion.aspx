<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmMultilingualConversion.aspx.vb"
    Inherits="FrmMultilingualConversion" Title="Multilingual Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Multilingual Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            var RB1 = document.getElementById("<%=RBType.ClientID%>");
            var radio = RB1.getElementsByTagName("input");
            var isChecked = false;
           
                if (radio[0].checked) {
                    msg = DropDownForZero(document.getElementById("<%=ddlModuleCustomize.ClientID %>"), 'Module Name');
                    document.getElementById("<%=ddlModuleCustomize.ClientID %>").focus();
                    if (msg != "") return msg;
                    msg = DropDownForZero(document.getElementById("<%=ddlFormName.ClientID %>"), 'Form Name');
                    document.getElementById("<%=ddlFormName.ClientID %>").focus();
                    if (msg != "") return msg;
                    msg = DropDownForZero(document.getElementById("<%=DdlLang.ClientID %>"), 'Language');
                    document.getElementById("<%=DdlLang.ClientID %>").focus();
                    if (msg != "") return msg;
                    msg = DropDownForZero(document.getElementById("<%=DdlControl.ClientID %>"), 'Control Type');
                    document.getElementById("<%=DdlControl.ClientID %>").focus();
                    if (msg != "") return msg;
                    msg = NameField1000(document.getElementById("<%=TxtTrans.ClientID %>"), 'Translation');
                    document.getElementById("<%=TxtTrans.ClientID %>").focus();
                    if (msg != "") return msg;
                }
                if (radio[1].checked) {
                    msg = NameField1000(document.getElementById("<%=TxtReport.ClientID %>"), 'Report Name');
                    document.getElementById("<%=TxtReport.ClientID %>").focus();
                    if (msg != "") return msg;

                    msg = DropDownForZero(document.getElementById("<%=DdlLang.ClientID %>"), 'Language');
                    document.getElementById("<%=DdlLang.ClientID %>").focus();
                    if (msg != "") return msg;
                    msg = DropDownForZero(document.getElementById("<%=DdlControl.ClientID %>"), 'Control Type');
                    document.getElementById("<%=DdlControl.ClientID %>").focus();
                    if (msg != "") return msg;
                    msg = NameField1000(document.getElementById("<%=TxtTrans.ClientID %>"), 'Translation');
                    document.getElementById("<%=TxtTrans.ClientID %>").focus();
                    if (msg != "") return msg;
                }
           

            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:RadioButtonList ID="RBType" runat="server" SkinID="RD" AutoPostBack="True" RepeatDirection="Horizontal"
                                        TabIndex="1">
                                        <asp:ListItem Value="F" Selected="True">Form</asp:ListItem>
                                        <asp:ListItem Value="R">Report</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblModule" runat="server" SkinID="lblRsz" Width="150px" Text="Module Name* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlModuleCustomize" runat="server" SkinID="ddlRsz" TabIndex="2"
                                        Width="250px" DataTextField="ModuleName" AutoPostBack="true" DataValueField="MNIDAuto"
                                        DataSourceID="objModule">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objModule" runat="server" TypeName="DLMultilingual" SelectMethod="GetModuleDdl">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblForm" runat="server" SkinID="lblRsz" Width="150px" Text="Form Name* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFormName" runat="server" SkinID="ddlRsz" Width="250px" TabIndex="3"
                                        DataTextField="ChildName" DataValueField="CNPKID" DataSourceID="ObjFormName"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjFormName" runat="server" SelectMethod="GetFormName"
                                        TypeName="DLMultilingual">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlModuleCustomize" DefaultValue="0" Name="MNIDAuto"
                                                PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblReport" runat="server" SkinID="lblRsz" Width="150px" Text="Report Name* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtReport" runat="server" SkinID="txtRsz" Width="250px" TabIndex="4">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblLang" runat="server" Text="Language* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DdlLang" runat="server" TabIndex="5" DataSourceID="ObjLang"
                                        DataTextField="LangType" AutoPostBack="true" DataValueField="Lang_AutoID" SkinID="ddl">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjLang" runat="server" TypeName="DLMultilingual" SelectMethod="GetLanguageType">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Lblcontrol" runat="server" Text="Control Type* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DdlControl" runat="server" SkinID="ddl" TabIndex="6" AutoPostBack="True">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="Label" Text="Label"></asp:ListItem>
                                        <asp:ListItem Value="Button" Text="Button"></asp:ListItem>
                                        <asp:ListItem Value="GridLabel" Text="GridLabel"></asp:ListItem>
                                        <asp:ListItem Value="GridButton" Text="GridButton"></asp:ListItem>
                                        <asp:ListItem Value="CheckBox" Text="CheckBox"></asp:ListItem>
                                        <asp:ListItem Value="RadioButtonList" Text="RadioButtonList"></asp:ListItem>
                                        <asp:ListItem Value="Heading" Text="Heading"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCCName" runat="server" SkinID="lblRsz" Width="150px" Text="Command Name :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCCName" runat="server" SkinID="txt" TabIndex="7">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblCId" runat="server" SkinID="lblRsz" Width="150px" Text="Control ID :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtCId" runat="server" SkinID="txt" TabIndex="7">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblTrans" runat="server" SkinID="lblRsz" Width="150px" Text="Translation* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtTrans" runat="server" SkinID="txt" TabIndex="8">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2" align="center">
                                    <asp:Button ID="btnSave" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                        SkinID="btn" TabIndex="9" Text="ADD" />
                                    &nbsp;
                                    <asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                        SkinID="btn" TabIndex="10" Text="VIEW" />
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
                                <td colspan="2" align="center">
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
                            <tr>
                                <td align="center" colspan="2">
                                    <center>
                                        <div>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
            </a>
            <center>
                <table>
                    <tr>
                        <td align="center">
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GVMulti" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                                    Visible="False" AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" TabIndex="8"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Module Name" SortExpression="ModuleName">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="ModuleH" runat="server" Value='<%#Bind("Multilingual_Auto_Id") %>' />
                                                <asp:Label ID="lblmn" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                                                <asp:Label ID="lblmodid" Visible="false" runat="server" Text='<%# Bind("MNIDAuto") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Form/Report Name" SortExpression="FormName">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ChildName") %>'></asp:Label>
                                                <asp:Label ID="lblFormid" runat="server"  Visible ="false" Text='<%# Bind("FormName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Language" SortExpression="LangType">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllangid" runat="server"  Visible ="false" Text='<%# Bind("Lang_AutoID") %>'></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("LangType") %>'></asp:Label>
                                                <asp:Label ID="lblgvRb" runat="server"  Visible ="false" Text='<%# Bind("Type") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Control Type" SortExpression="ControlType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCType" runat="server" Text='<%# Bind("ControlType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Command Name" SortExpression="ControlCommandName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCommandName" runat="server" Text='<%# Bind("ControlCommandName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Control ID" SortExpression="ControlId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCId" runat="server" Text='<%# Bind("ControlId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Translation" SortExpression="Default_Text">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrans" runat="server" Text='<%# Bind("Default_Text") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </center>
            </div> <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
