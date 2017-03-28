<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptCadreMgmt.aspx.vb" Inherits="RptCadreMgmt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cadre Management Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <br />
                <center>
                    <h1 class="headingTxt">
                        Cadre Management</h1>
                </center>
                <br />
                <br />
            </div>
            <center>
                <table>
                    <tr>
                            <td align="right">
                                <asp:Label ID="lblUniversity" runat="server" Text="University :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="4">
                                <asp:DropDownList ID="ddlUniversity"  runat="server" SkinID="ddlRsz" Width="200px"
                                    AutoPostBack="True" DataSourceID="ObjUniv" DataTextField="BranchName" DataValueField="BranchCode">
                                  <%--  <asp:ListItem Selected="true" Value="Select">All</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjUniv" runat="server" TypeName="DLCadreMgmt" SelectMethod="insertBranchCombo_CadreMgmtRpt">
                                </asp:ObjectDataSource>
                            </td>
                            </tr>
                            <tr>
                            <td align="right">
                                <asp:Label ID="lblProgram" runat="server" Text="Program :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="4">
                                <asp:DropDownList ID="ddlProgram" AutoPostBack="true" runat="server" SkinID="ddlRsz"
                                    Width="200px" DataSourceID="ObjPrgm" DataTextField="Data" DataValueField="lookupautoID">
                                    
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjPrgm" runat="server" TypeName="DLCadreMgmt" SelectMethod="DDLPrgmComboRpt">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="2"><hr/></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblProj" runat="server" SkinID="lblRsz" Text="Project :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="4">
                                <asp:DropDownList ID="ddlProj" runat="server"  SkinID="ddlRsz"
                                    Width="200" DataSourceID="ObjProj" DataTextField="Project_Name" DataValueField="ProjectAuto">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjProj" runat="server" TypeName="DLCadreMgmt" SelectMethod="DDLProjComborpt">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlProgram" PropertyName="SelectedValue" Name="Program"
                                            DefaultValue="0" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            </tr>
                </table>
                <table>
                    <caption>
                        <br />
                        <br />
                        <tr>
                            <td align="center" class="btnTd">
                                <center>
                                    <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                        OnClientClick="return Validate();" />
                                    &nbsp;
                                    <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK" />
                                </center>
                                <br />
                                <br />
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                    <br />
                                </center>
                            </td>
                        </tr>
                    </caption>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
