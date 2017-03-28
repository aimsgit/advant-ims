<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptCourseSemMap.aspx.vb"
    Inherits="RptCourseSemMap" Title="Course Semester Mapping" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Course Semester Mapping</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
        
 
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
            </br>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Labelcp" runat="server" Text="COURSE SEMESTER MAPPING" SkinID="lblRepRsz" Width="300"
                            Visible="True"></asp:Label>
                    </h1>
                </center>
                <table>
                    
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
                                <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="Course :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbCourse" runat="server" DataTextField="CourseName" AutoPostBack="True"
                                    DataSourceID="ObjCourse1" DataValueField="Courseid" TabIndex="1" AppendDataBoundItems="true"
                                    SkinID="ddlRsz" Width="250px">
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
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="2" runat="server" Text="REPORT" CommandName="REPORT"
                                    SkinID="btn" CssClass="ButtonClass"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" CommandName="BACK"
                                    SkinID="btn" CssClass="ButtonClass"></asp:Button>
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
                    <tr>
                        <td>
                            <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="courseCombo" TypeName="SemesterdateDL">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

