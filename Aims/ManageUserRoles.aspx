<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ManageUserRoles.aspx.vb"
    Inherits="ManageUserRoles"  Title="Manage User Roles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manage User Roles</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
function ShowImage()
{
GlbShowSImage(document.getElementById("<%=txtEmp.ClientID%>"));

 }
function HideImage()
{
 GlbHideSImage(document.getElementById("<%=txtEmp.ClientID%>"));
} </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Manage Roles for the Registered Users &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </h1>
                </center>
                <center>
                    <table class="custTable">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Branch Name:" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranch1" runat="server" AutoPostBack="True" DataTextField="BName"
                                    DataValueField="Id" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" SkinID="ddlL"
                                    TabIndex="3" Visible="False" Width="132px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Employee Code:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmp" runat="server" AutoPostBack="True"></asp:TextBox><ajaxToolkit:AutoCompleteExtender
                                    ID="AutoCompleteExtender2" runat="Server" CompletionInterval="1000" EnableCaching="True"
                                    FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage"
                                    OnClientPopulating="ShowImage" ServiceMethod="getEmpCodeExtender" ServicePath="TextBoxExt.asmx"
                                    TargetControlID="txtEmp">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                    SkinID="watermark" TargetControlID="txtEmp" WatermarkText="Type first 3 characters">
                                </ajaxToolkit:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                User ID:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUserIDList" runat="server" AutoPostBack="True" SkinID="ddlL"
                                    TabIndex="3">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Access Level:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="True" DataSourceID="ObjInstitute"
                                    DataTextField="Name" DataValueField="Id" SkinID="ddlL" TabIndex="2" Width="132px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Branch Name:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" DataSourceID="ObjBranch"
                                    DataTextField="Name" DataValueField="Id" SkinID="ddlL" TabIndex="3" Width="132px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Role:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRolesList" runat="server" Width="141px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table class="custTable">
                        <tr>
                            <td class="btnTd">
                                <asp:Button ID="btnAddUserToRole" runat="server" SkinID="btn1" Text="Add Selected User to Selected Role"
                                    CssClass="btnStyle" />
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" SkinID="btn1" Text="Add Access level to Selected User"
                                    CssClass="btnStyle" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblUserRoleInfoText" runat="server" ForeColor="Black"></asp:Label>
                                <asp:ListBox ID="lbxUserRoles" runat="server" Width="100%"></asp:ListBox>
                            </td>
                            <td>
                                <asp:Label ID="lbltype" runat="server" ForeColor="Black"></asp:Label>
                                <asp:ListBox ID="lbxType" runat="server" Width="100%"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnDeleteUserFromRole" runat="server" SkinID="btn1" Text="Delete User from Selected Role"
                                    CssClass="btnStyle" />
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
            <br />
            <asp:Label ID="lblResults" runat="server" ForeColor="Red" Visible="false">Results:</asp:Label>
            <asp:ObjectDataSource ID="ObjInstitute" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="FillAllTypes" TypeName="InstituteManager"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetBranchInstWise" TypeName="BranchManager">
                <SelectParameters>
                    <asp:ControlParameter DefaultValue="0" Name="id" Type="Int32" ControlID="ddlInstitute"
                        PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjUser" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetOnlyUserNames" TypeName="UserDetailsDB">
                <SelectParameters>
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

