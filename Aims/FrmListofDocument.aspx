<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmListofDocument.aspx.vb"
    Inherits="FrmListofDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LIST OF DOCUMENT SUBMMITED</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <br />
                        <h1 class="headingTxt">
                            <asp:Label ID="LblLDS" runat="server" Text="LIST OF DOCUMENT SUBMMITED" SkinID="lblRepRsz"
                                Width="500" Visible="True"></asp:Label>
                        </h1>
                        <br/>
                        <br/>
                    </center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl"
                                    Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td>
                                <asp:ListBox ID="ListBatch" Height="250px" Width="250px" SelectionMode="Multiple"
                                    AutoPostBack="True" DataValueField="BatchID" DataTextField="Batch_No" runat="server"
                                    DataSourceID="ObjBatch" TabIndex="3" CssClass="Listbox"></asp:ListBox>
                            </td>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboReport"
                                TypeName="DLListofSubmitted"></asp:ObjectDataSource>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" 
                                    DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="6"
                                    AppendDataBoundItems="False" Width="200">
                                </asp:DropDownList>
                               <%-- <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                    TypeName="DLListofSubmitted">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ListBatch" Name="Batch" Type="string" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnReport" runat="server" OnClientClick="return Validate1();" TabIndex="10"
                                    Text="REPORT" SkinID="btn" CommandName="REPORT" CssClass="ButtonClass"></asp:Button>&nbsp;
                                <asp:Button ID="btnBack" runat="server" TabIndex="11" Text="BACK" CommandName="BACK"
                                    SkinID="btn" CssClass="ButtonClass"></asp:Button>
                            </td>
                        </tr>
                    </table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <center>
                                <div>
                                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                </div>
                            </center>
                        </td>
                    </tr>
                </table> </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>
