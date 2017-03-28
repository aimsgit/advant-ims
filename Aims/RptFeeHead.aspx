<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptFeeHead.aspx.vb"
    Inherits="RptFeeHead" Title="Fee Head" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Head</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>	
    <script language="JavaScript" type="text/javascript">
       
    </script>

    <%--<div class="mainBlock">--%>

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        Fee Head Report
                    </h1>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table class="custTable">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Fee Head Type* :" SkinID="lbl" ></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfeeheadtype" runat="server" SkinID="txt"  TabIndex="0"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="Btnreport" runat="server" CausesValidation="True" OnClientClick="return Validate();"
                                    CommandName="Report" OnClick="Btnreport_Click" Text="REPORT" SkinID="btn" CssClass="ButtonClass"
                                    TabIndex="15"></asp:Button>
                                <asp:Button ID="BtnBack" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                            <caption>
                                &nbsp;
                            </caption>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                </center>
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

