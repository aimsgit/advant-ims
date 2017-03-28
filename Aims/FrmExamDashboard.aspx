<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmExamDashboard.aspx.vb"
    Inherits="FrmExamDashboard" Title="EXAM DASHBOARD " %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>EXAM DASHBOARD</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlExamBatch.ClientID%>"), 'Examination Batch');
            if (msg != "") {
                document.getElementById("<%=ddlExamBatch.ClientID%>").focus();
                return msg;

            }



            return true;

        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    EXAM DASHBOARD</h1>
            </center>
            <%--<center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>--%>
            <br />
            <br />
            <asp:Panel ID="ControlsPanel" runat="server">
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblExamBatch" runat="server" Text="Examination Batch*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="250px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlExamBatch" runat="server" DataSourceID="ObjExamBatch" DataTextField="ExamBatch" AppendDataBoundItems="true"
                                    DataValueField="ExamBatch_Autoid" SkinID="ddlRsz" TabIndex="1" Width="250" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjExamBatch" runat="server" SelectMethod="GetExamBatch"
                                    TypeName="DLExamDashBoard"></asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <asp:Button ID="btnView" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="2" Text="STATUS" OnClientClick="return Validate();" />
                        </tr>
                    </table>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <center>
                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server">
                        <table border="1">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblexamcal" SkinID="lblRsz" runat="server" Text="Exam Calendar &nbsp;"
                                        Width="250px"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblassignResource" SkinID="lblRsz" runat="server" Text="Assign Resources&nbsp;" Width="250px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblexamcal1" runat="server" SkinID="lblrsz" Width="250px"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblassignResource1" runat="server" SkinID="lblrsz" Width="250px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblRegStu" runat="server" Text="Register Student&nbsp;" SkinID="lblRsz"
                                        Width="250px"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblMapStu" runat="server" Text="Map Student to Center&nbsp;" SkinID="lblRsz"
                                        Width="250px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblRegStu1" runat="server" SkinID="lblrsz" Width="250px"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblMapStu1" runat="server" SkinID="lblrsz" Width="250px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblMapstuHall" runat="server" Text="Map Student to Hall&nbsp;" SkinID="lblRsz"
                                        Width="250px"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblGenHall" runat="server" Text="Generate Hall Ticket&nbsp;" SkinID="lblRsz"
                                        Width="250px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblMapstuHall1" runat="server" SkinID="lblrsz" Width="250px"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblGenHall1" runat="server" SkinID="lblrsz" Width="250px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblevalpaper" runat="server" Text="Evaluation of Paper&nbsp;" SkinID="lblrsz"
                                        Width="250px"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblPubMark" runat="server" Text="Publish Marks&nbsp;" SkinID="lblrsz"
                                        Width="250px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblevalpaper1" runat="server" SkinID="lblrsz" Width="250px"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblPubMark1" runat="server" SkinID="lblrsz" Width="250px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </center>
            </asp:Panel>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
