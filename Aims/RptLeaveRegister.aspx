<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptLeaveRegister.aspx.vb"
    Inherits="RptLeaveRegister" Title="Untitled Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtEmp.ClientID%>"));

        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtEmp.ClientID%>"));
        }

        function SplitName() {
            var text = document.getElementById("<%=txtEmp.ClientID%>").value;
            var split = text.split(':');
            if (split.length > 0) {
                document.getElementById("<%=txtEmp.ClientID%>").innerText = split[0] + " : " + split[1];
                document.getElementById("<%=HidempId.ClientID%>").innerText = split[2];
            }
        }
   
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Width ="150"  Text="Leave Type*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                 &nbsp;&nbsp;<asp:DropDownList ID="cmbLeaveType" TabIndex="1" runat="server" SkinID="ddl" AutoPostBack="True"
                                    DataSourceID="odsleave" DataTextField="Leave_Type" DataValueField="TypeID" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsleave" runat="server" TypeName="LeaveDB" SelectMethod="GetLeaveType">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmpId" runat="server" Text="Employee Code* :" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td>
                                <asp:HiddenField ID="HidempId" runat="server" />
                                &nbsp;&nbsp;<asp:TextBox ID="txtEmp" runat="server" AutoPostBack="True"></asp:TextBox><ajaxToolkit:AutoCompleteExtender
                                    ID="AutoCompleteExtender2" runat="Server" TargetControlID="txtEmp" EnableCaching="True"
                                    MinimumPrefixLength="3" ServiceMethod="getEmpCodeExt1" ServicePath="TextBoxExt.asmx"
                                    OnClientPopulated="HideImage" OnClientPopulating="ShowImage" OnClientItemSelected="SplitName"
                                    CompletionInterval="2000" FirstRowSelected="true">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                    SkinID="watermark" TargetControlID="txtEmp" WatermarkText="Type first 3 characters">
                                </ajaxToolkit:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="6" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
