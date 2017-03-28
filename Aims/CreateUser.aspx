<%@ Page Language="VB" AutoEventWireup="true" CodeFile="CreateUser.aspx.vb" Inherits="CreateUser" Title="Create User" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Create User</title>
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

    <asp:UpdatePanel runat="server" ID="Update">
        <ContentTemplate>
            <div>
                <center>
                    <h1>
                        Create New User</h1>
                </center>
            </div>
            <div>
                <center>
                    <table class="custTable">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Width="131px" Text="Institute Name:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlInstitute" TabIndex="2" runat="server" Width="132px" Visible="False"
                                        DataValueField="Id" DataTextField="Name" DataSourceID="ObjInstitute" SkinID="ddlL"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Branch Name:" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" TabIndex="3" runat="server" Width="132px" Visible="False"
                                        DataValueField="Id" DataTextField="BName" SkinID="ddlL" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Employee Code:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmp" runat="server" AutoPostBack="True"></asp:TextBox><ajaxToolkit:AutoCompleteExtender
                                        ID="AutoCompleteExtender2" runat="Server" TargetControlID="txtEmp" ServicePath="TextBoxExt.asmx"
                                        ServiceMethod="getEmpCodeExtender" OnClientPopulating="ShowImage" OnClientPopulated="HideImage"
                                        MinimumPrefixLength="3" FirstRowSelected="true" EnableCaching="True" CompletionInterval="1000">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Login ID:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUserId" runat="server" Width="295px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 26px">
                                    <asp:Label ID="Label4" runat="server" Text="Password:"></asp:Label>
                                </td>
                                <td style="height: 26px">
                                    <asp:TextBox ID="txtPassword" runat="server" Width="295px" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Expiry Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExpiry" TabIndex="7" runat="server" SkinID="txt" EnableViewState="False"
                                        MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" Width="295px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Password Question:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPasswordQuestion" runat="server" Width="295px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Password Answer:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPasswordAnswer" runat="server" Width="295px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" WatermarkText="Type first 3 characters"
                                        runat="server" SkinID="watermark" TargetControlID="txtEmp">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                    <asp:Button ID="btnCreate" runat="server" Text=" CREATE" SkinID="btn" CssClass="btnStyle">
                                    </asp:Button>
                                </td>
                                <td>
                                    <ajaxToolkit:MaskedEditExtender ID="meeDOB" runat="server" TargetControlID="txtExpiry"
                                        PromptCharacter="_" Mask="99-LLL-9999" MaskType="none" ClearMaskOnLostFocus="false">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" SkinID="Calendar"
                                        TargetControlID="txtExpiry" Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </center>
                <center>
                <asp:Label ID="lblResults" runat="server" Visible="False" BackColor="Green" 
                        ForeColor="White">Results:</asp:Label>&nbsp;<br />
                <br />
                </center>
                <center>
                    <a href="ManageUserRoles.aspx">Click Here To Manage Roles For This User</a></center>
                <asp:ObjectDataSource ID="ObjInstitute" runat="server" TypeName="InstituteManager"
                    SelectMethod="FillAllTypes" OldValuesParameterFormatString="original_{0}">
                    <%-- <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
            </SelectParameters>--%>
                </asp:ObjectDataSource>
                <%-- <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetBranch" TypeName="BranchManager">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="id" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>--%><asp:ObjectDataSource ID="ObjBranch" runat="server" TypeName="BranchManager"
            SelectMethod="GetBranchInstWise" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter DefaultValue="0" Name="id" Type="Int32" ControlID="ddlInstitute"
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>