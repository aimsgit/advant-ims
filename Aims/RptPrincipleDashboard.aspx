<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptPrincipleDashboard.aspx.vb"
    Inherits="RptPrincipleDashboard" Title="Principal Dashboard Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Principal Dashboard Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=cmbAcademic.ClientID %>"), 'Academic Year');
            if (msg != "") {
                document.getElementById("<%=cmbAcademic.ClientID %>").focus();
                return msg;
            }
            return true;
        }


        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;

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
            <div>
                <center>
                    <h1 class="headingTxt">
                        PRINCIPAL DASHBOARD REPORT</h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Style="margin-left: 0px" Text="Academic Calendar Year* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbAcademic" runat="server" AutoPostBack="True" DataSourceID="ObjAcademic"
                                    DataTextField="AcademicYear" DataValueField="id" SkinID="ddl" TabIndex="1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr
                          </table>
                          <table>
                        <tr align="center">
                     <%--   <td></td>--%>
                            <td class="btnTd">
                                <asp:Button ID="btnReport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="2" Text="REPORT" />
                                &nbsp;
                                <asp:Button ID="BtnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="3"
                                    Text="BACK" />
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblE" runat="server" Text="" SkinID="lblRed"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </center>
                </center>
                <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                    TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>
