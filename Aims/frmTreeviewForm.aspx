<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmTreeviewForm.aspx.vb"
    Inherits="frmTreeviewForm" Title="Treeview Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Treeview Form</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtModuleName.ClientID %>"), 'Module Name');
            document.getElementById("<%=txtModuleName.ClientID %>").focus();
            if (msg != "") return msg;
            msg = minmaxlength(document.getElementById("<%=txtSequenceNo.ClientID %>"), 1, 160, 'Sequence No');
            document.getElementById("<%=txtSequenceNo.ClientID %>").focus();
            if (msg != "") return msg;

            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

    <script type="text/javascript" language="javascript">
        function ValidChild() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DDLModule.ClientID %>"), 'Module Name');
            document.getElementById("<%=DDLModule.ClientID %>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtFormName.ClientID %>"), 'Form Name');
            document.getElementById("<%=txtFormName.ClientID %>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtLinkName.ClientID %>"), 'Link/File Name');
            document.getElementById("<%=txtLinkName.ClientID %>").focus();
            if (msg != "") return msg;
            msg = minmaxlength(document.getElementById("<%=txtFormSequence.ClientID %>"), 1, 160, 'Sequence No');
            document.getElementById("<%=txtFormSequence.ClientID %>").focus();
            if (msg != "") return msg;

            return true;
        }
        function ValidateChild() {

            var msg = ValidChild();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRedChild.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreenChild.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRedChild.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreenChild.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

    <script type="text/javascript" language="javascript">
        function ValidCustomizeChild() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=DdlSelectBranch.ClientID %>"), 'Branch');
            document.getElementById("<%=DdlSelectBranch.ClientID %>").focus();
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=ddlModuleCustomize.ClientID %>"), 'Module Name');
            document.getElementById("<%=ddlModuleCustomize.ClientID %>").focus();
            if (msg != "") return msg;

            msg = DropDownForZero(document.getElementById("<%=ddlFormName.ClientID %>"), 'Form Name');
            document.getElementById("<%=ddlFormName.ClientID %>").focus();
            if (msg != "") return msg;

            msg = NameField100(document.getElementById("<%=txtAliasName.ClientID %>"), 'Alias Form Name');
            document.getElementById("<%=txtAliasName.ClientID %>").focus();
            if (msg != "") return msg;

            return true;
        }
        function ValidateCustomizeChild() {

            var msg = ValidCustomizeChild();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed3.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen3.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed3.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen3.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel runat="server" ID="uppanel">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    TREEVIEW FORM
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table class="custTable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblModuleName" runat="server" SkinID="lbl" Text="Module Name* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModuleName" runat="server" SkinID="txt" TabIndex="1">
                            </asp:TextBox>
                            <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterMode="InvalidChars" FilterType="Custom" InvalidChars="~!@#$%^&*()_+=-}{|\][;,./':<>?""""
                                TargetControlID="txtModuleName">
                            </ajaxToolkit:FilteredTextBoxExtender>--%>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblSequenceNo" runat="server" SkinID="lbl" Text="Sequence No* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSequenceNo" runat="server" SkinID="txt" TabIndex="2">
                            </asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="1234567890" TargetControlID="txtSequenceNo">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            &nbsp;
                            <asp:HiddenField ID="HidID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="Btnadd" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                CssClass="ButtonClass" SkinID="btn" TabIndex="3" Text="ADD" />
                            <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="3"
                                Text="VIEW" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                            <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="400px"
                                    Visible="false">
                                    <asp:GridView ID="GVModule" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        DataKeyNames="MNPKID" PageSize="100" SkinID="GridView">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkEdit" runat="server" TabIndex="2" CausesValidation="False"
                                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkDelete" runat="server" TabIndex="4" CausesValidation="False"
                                                        CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Module Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HidMNPKID" runat="server" Value='<%# Eval("MNPKID") %>' />
                                                    <asp:HiddenField ID="HidMNIDAuto" runat="server" Value='<%# Bind("MNIDAuto") %>' />
                                                    <asp:HiddenField ID="HidBranchCode" runat="server" Value='<%# Bind("BranchCode") %>' />
                                                    <asp:Label ID="lblModuleName" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sequence No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSequenceNo" runat="server" Text='<%# Bind("SequenceNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </center>
            <hr />
            <%--</ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="uppanel1">
        <ContentTemplate>--%>
            <center>
                <table class="custTable">
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblModule" runat="server" SkinID="lblRsz" Width="150px" Text="Module Name*^ :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLModule" runat="server" SkinID="ddl" TabIndex="1" DataTextField="ModuleName"
                                DataValueField="MNIDAuto" DataSourceID="objModule">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objModule" runat="server" TypeName="BLTreeviewForm" SelectMethod="GetModuleDdl">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblFormName" runat="server" SkinID="lblRsz" Width="150px" Text="Form Name* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFormName" runat="server" SkinID="txt" TabIndex="2">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblLinkName" runat="server" SkinID="lblRsz" Width="150px" Text="Link/File Name* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLinkName" runat="server" SkinID="txt" TabIndex="2">
                            </asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblFormSequence" runat="server" SkinID="lblRsz" Width="150px" Text="Sequence No* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFormSequence" runat="server" SkinID="txt" TabIndex="2">
                            </asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="1234567890" TargetControlID="txtFormSequence">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            &nbsp;<asp:HiddenField ID="HidChildID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btnChildAdd" runat="server" CausesValidation="True" OnClientClick="return ValidateChild();"
                                CssClass="ButtonClass" SkinID="btn" TabIndex="3" Text="ADD" />
                            <asp:Button ID="btnChildView" runat="server" CssClass="ButtonClass" SkinID="btn"
                                TabIndex="3" Text="VIEW" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblGreenChild" runat="server" SkinID="lblGreen"></asp:Label>
                            <asp:Label ID="lblRedChild" runat="server" SkinID="lblRed"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="400px"
                                    Visible="false">
                                    <asp:GridView ID="GVChild" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        DataKeyNames="CNPKID" PageSize="100" SkinID="GridView">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkEdit" runat="server" TabIndex="2" CausesValidation="False"
                                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkDelete" runat="server" TabIndex="4" CausesValidation="False"
                                                        CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Module Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HidCNPKID" runat="server" Value='<%# Eval("CNPKID") %>' />
                                                    <asp:HiddenField ID="HidCNIDAuto" runat="server" Value='<%# Bind("CNIDAuto") %>' />
                                                    <asp:HiddenField ID="HidCBranchCode" runat="server" Value='<%# Bind("BranchCode") %>' />
                                                    <asp:HiddenField ID="HidMNIDAuto" runat="server" Value='<%# Bind("MNIDAuto") %>' />
                                                    <asp:Label ID="lblModuleName" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Module Sequence No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblModuleSequenceNo" runat="server" Text='<%# Bind("ModuleSequenceNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Form Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblChildName" runat="server" Text='<%# Bind("ChildName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Link/File Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblChildFileName" runat="server" Text='<%# Bind("ChildFileName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Child/Form Sequence No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFormSequenceNo" runat="server" Text='<%# Bind("SequenceNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </center>
            <hr />
            <center>
                <h1 class="headingTxt">
                    TREEVIEW FORM FOR TENANTS
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table class="custTable">
                    <tr>
                        <td align="right">
                            &nbsp;&nbsp;<asp:Label ID="LblselectClient" runat="server" SkinID="lblRSZ" Text="Institute*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectClient" runat="server" AutoPostBack="True" DataSourceID="ObjSelectClient"
                                AppendDataBoundItems="true" DataTextField="MyCo_Name" DataValueField="MyCo_Code"
                                SkinID="ddlRsz" TabIndex="1" Width="260px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectClient" runat="server" SelectMethod="GetClientCombo"
                                TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <td align="right">
                        <asp:Label ID="lblSelectBranch" runat="server" Width="150px" SkinID="lblRsz" Text="Branch Name*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="DdlSelectBranch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                            TabIndex="2" AppendDataBoundItems="False" DataValueField="BranchCode" DataTextField="BranchName"
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
                            <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Width="150px" Text="Module Name*^ :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModuleCustomize" runat="server" SkinID="ddl" TabIndex="1"
                                DataTextField="ModuleName" AutoPostBack="true" DataValueField="MNIDAuto" DataSourceID="objModule">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Width="150px" Text="Form Name* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlFormName" runat="server" SkinID="ddl" DataTextField="ChildName"
                                DataValueField="CNPKID" DataSourceID="ObjFormName" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjFormName" runat="server" SelectMethod="GetFormName"
                                TypeName="DLTreeviewForm">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlModuleCustomize" DefaultValue="0" Name="MNIDAuto"
                                        PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Width="150px" Text="Alias Form Name* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAliasName" runat="server" SkinID="txt" TabIndex="2" />
                            <asp:TextBox ID="txtSequence" runat="server" Visible="false" />
                            <asp:TextBox ID="txtCNIDAuto" runat="server" Visible="false" />
                            <asp:TextBox ID="HidTxtFilename" runat="server" Visible="false" />
                            <asp:HiddenField ID="CustomizeChildId" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="BtnAdd3" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                SkinID="btn" OnClientClick="return ValidateCustomizeChild();" Text="ADD" />
                            <asp:Button ID="BtnView3" runat="server" CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblRed3" runat="server" SkinID="lblRed"></asp:Label>
                            <asp:Label ID="lblGreen3" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="650px" Height="300px" Visible="false">
                                    <asp:GridView ID="Grid3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkEdit" runat="server" TabIndex="2" CausesValidation="False"
                                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkDelete" runat="server" TabIndex="4" CausesValidation="False"
                                                        CommandName="Delete" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Institute">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HidGVCustomizeTreeviewId" runat="server" Value='<%# Eval("CustTreeveiwIDAuto") %>' />
                                                    <asp:Label ID="lblGVInstitute" Visible="false" runat="server" Text='<%# Bind("MyCo_Code") %>'></asp:Label>
                                                    <asp:Label ID="lblGVInstituteName" runat="server" Text='<%# Bind("MyCo_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVBranch_Id" runat="server" Visible="false" Text='<%# Bind("Branch_ID") %>' />
                                                    <asp:Label ID="lblGVBranchName" runat="server" Text='<%# Bind("BranchName") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVBranchCode" runat="server" Text='<%# Bind("BranchCode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Module Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HidGVMNIDAuto" runat="server" Value='<%# Bind("MNIDAutoCust") %>' />
                                                    <asp:Label ID="lblModuleName" runat="server" Text='<%# Bind("ModuleName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Form Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSequenceNo" Visible="false" runat="server" Text='<%# Bind("SequenceNoCust") %>'></asp:Label>
                                                    <asp:Label ID="lblGVFormName" runat="server" Text='<%# Bind("ChildNameCust") %>'></asp:Label>
                                                    <asp:Label ID="lblGVChildFilenameCust" runat="server" Visible="false" Text='<%# Bind("ChildFileNameCust") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Alias Form Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HidGVChildAutoId" runat="server" Value='<%# Bind("CNIDAuto") %>' />
                                                    <asp:Label ID="lblGVAliasName" runat="server" Text='<%# Bind("ChildAliasName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                        </td>
                    </tr>
                    
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

