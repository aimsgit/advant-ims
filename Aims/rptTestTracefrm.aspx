<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptTestTracefrm.aspx.vb"
    Inherits="rptTestTracefrm" Title="Test Trace Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Test Trace Form</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        TEST TRACE REPORT
                    </h1>
                </center>
                </br>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblModule" runat="server" SkinID="lbl" Text="Module* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLModule" runat="server" SkinID="ddl" DataSourceID="ObjModule"
                                    AppendDataBoundItems="true" DataTextField="Parent_Name" AutoPostBack="True">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="btnTd">
                                <asp:Button ID="btnSReport" TabIndex="5" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" ValidationGroup="save"></asp:Button>
                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" OnClick="btnBack_Click"
                                    SkinID="btn" Text="BACK" />
                            </td>
                        </tr>
                    </table>
                    <asp:ObjectDataSource ID="ObjModule" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetModuleType" TypeName="DLTestTrace"></asp:ObjectDataSource>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>
