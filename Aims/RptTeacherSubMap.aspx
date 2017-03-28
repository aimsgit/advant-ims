<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptTeacherSubMap.aspx.vb"
    Inherits="RptTeacherSubMap" Title="TEACHER SUBJECT MAP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TEACHER SUBJECT MAP</title>
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
                 <br />
                    <center>
                        <h1 class="headingTxt">
                            TEACHER SUBJECT MAPPING REPORT
                        </h1>
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTeacher" runat="server" SkinID="lblRsz" Text="Teacher :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:TextBox ID="txtTeacher" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>&nbsp;&nbsp;
                                    <asp:LinkButton ID="LoadTeacher" runat="server" SkinID="lb" TabIndex="2">Load Teacher</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblselectTeacher" runat="server" SkinID="lblRsz" Width="150px" Text="Select Teacher :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:DropDownList ID="ddlTeacher" runat="server" DataTextField="Emp_Name" DataValueField="Emp_Name"
                                        SkinID="ddlRsz" Width="200px" TabIndex="3">
                                    </asp:DropDownList>
                                    <%-- <asp:ObjectDataSource ID="ObjTeacher" runat="server" TypeName="DLRptSubTeacherMAp"
                                        SelectMethod="GetTeacher"></asp:ObjectDataSource>--%>
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
                                <td colspan="7" align="center">
                                    <asp:RadioButtonList ID="RBReport" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                        TabIndex="4">
                                        <asp:ListItem Value="1" Selected="True">Aadhaar/NIC</asp:ListItem>
                                        <asp:ListItem Value="2">PAN</asp:ListItem>
                                        <asp:ListItem Value="3">Passport No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="5" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <center>
                            <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                        </center>
                        <div>
                            <center>
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            Loading Teachers may take few minutes...
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </center>
                        </div>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>


</form>
</body>
</html>

