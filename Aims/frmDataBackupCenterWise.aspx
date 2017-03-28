<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmDataBackupCenterWise.aspx.vb"
    Inherits="frmDataBackupCenterWise" Title="Data Backup Center Wise" EnableEventValidation="false"
    ValidateRequest="false" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Data Backup Center Wise</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            DATA BACKUP CENTER WISE
                        </h1>
                    </center>
                    <br />
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranchType" runat="server" Text="Branch Name* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBranchName" TabIndex="1" runat="server" SkinID="ddlL" AutoPostBack="True"
                                        DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="insertBranch" TypeName="DLfrmDataBackupCenterWise"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTables" runat="server" Text="Tables* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="RbType" runat="server" AutoPostBack="true" RepeatDirection="Vertical"
                                        SkinID="Themes" TabIndex="1" Width="300px" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Employee" Value="E"></asp:ListItem>
                                        <asp:ListItem Text="Student" Value="S"></asp:ListItem>
                                        <asp:ListItem Text="Student Marks" Value="SM"></asp:ListItem>
                                        <asp:ListItem Text="Student Attendance" Value="SA"></asp:ListItem>
                                        <asp:ListItem Text="Course Plan" Value="CP"></asp:ListItem>
                                        <asp:ListItem Text="Batch Plan" Value="BP"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <%--<asp:Button ID="BtnExport" runat="server"  CausesValidation="true" CssClass="ButtonClass"
                                        SkinID="btnRsz" Text="EXPORT"  />--%>
                                    &nbsp<asp:Button ID="btnView" runat="server" CausesValidation="false" Width="130" CssClass="ButtonClass"
                                        SkinID="btnRsz" Text="VIEW" OnClick="btnView_Click"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <%--<asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblError" runat="server" SkinID="lblRed"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblS" runat="server" SkinID="lblGreen"></asp:Label>
                                </td>
                            </tr>
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
                            <asp:GridView ID="GVDataBackupCenterWise" runat="server" AutoGenerateColumns="false" SkinID="GridView">
                            </asp:GridView>
                            </td>
                            </tr>
                        </table>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </asp:Panel>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br/>
        <br/>
        <asp:Panel ID="Panel2" runat="server">
            <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                SkinID="btnRsz" Text="EXPORT"  Width="130" CommandName="EXPORT" OnClick="BtnExport_Click"/>
        </asp:Panel>
    </center>

</form>
</body>
</html>
