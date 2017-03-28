<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmStudentDashboard.aspx.vb"
    Inherits="FrmStudentDashboard" Title="Student Dashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vehicle Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

     <script language="JavaScript" type="text/javascript">
                function Valid() {
                    var msg;

         msg = AutoCompleteExtenderN(document.getElementById("<%=txtStdCode.ClientID %>"), 'Student Code');
          if (msg != "") {
          document.getElementById("<%=txtStdCode.ClientID %>").focus();
           return msg;
        }

                    return true;
                }
                function Validate() {
                    var msg = Valid();
                    if (msg != true) {
                       if (navigator.appName == "Microsoft Internet Explorer") {
                            document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                            document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                            return false;
                        }
                        else if (navigator.appName == "Netscape") {
                            document.getElementById("<%=lblerrmsg.ClientID %>").textContent = msg;
                            document.getElementById("<%=lblmsgifo.ClientID %>").textContent = "";

                            return false;
                        }
                    }
                    return true;
                }
    </script>

    <script type="text/javascript" language="javascript">

        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
        }

        function SplitName1() {
            var text = document.getElementById("<%=txtStdCode.ClientID%>").value;
            var split = text.split(':');
            if (split.length > 0) {
                document.getElementById("<%=txtStdCode.ClientID%>").innerText = split[0];
                document.getElementById("<%=lblNames.ClientID%>").innerText = split[1];
                document.getElementById("<%=HidstdId.ClientID%>").innerText = split[2];
            }
        }
    </script>

 
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <br />
                                    <asp:TextBox ID="HidstdId" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <asp:Panel ID="HideTextboxes" runat="server">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblStdCode" runat="server" SkinID="lblRsz" Text="Student Code*&nbsp;:&nbsp;&nbsp;"
                                                Width="150px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtStdCode" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" CompletionInterval="2000"
                                                CompletionListCssClass="completeListStyle" EnableCaching="true" FirstRowSelected="true"
                                                MinimumPrefixLength="3" OnClientPopulated="HideImage1" OnClientPopulating="ShowImage1"
                                                ServiceMethod="getStudentIdName1" ServicePath="TextBoxExt.asmx" TargetControlID="txtStdCode">
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                SkinID="watermark" TargetControlID="txtStdCode" WatermarkText="Type first 3 characters">
                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </asp:Panel>
                        </table>
                        <center>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblname" runat="server" SkinID="lblRsz" Text="Name&nbsp;:&nbsp;&nbsp;"
                                            Width="90px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblNames" runat="server" SkinID="lblRsz"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblcode" runat="server" SkinID="lblRsz" Text="Code&nbsp;:&nbsp;&nbsp;"
                                            Width="90px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblCodes" runat="server" SkinID="lblRsz"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <asp:Panel ID="Hidebutton" runat="server">
                                    <tr>
                                        <td class="btnTd" colspan="4">
                                            <asp:Button ID="btnGenerate" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                                SkinID="btnRsz" TabIndex="4" Text="GENERATE" />
                                            <asp:Button ID="BtnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                                Text="BACK" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                </asp:Panel>
                                </tr>
                            </table>
                        </center>
                        <br />
                    </center>
                    <div>
                        <center>
                            <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        Processing your request..please wait...
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </center>
                    </div>
            </a><a name="bottom">
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridStudentDashBoard" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Width="368px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Academic Year" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblType" runat="server" Text='<%# Bind("CourseName")  %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Batch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Semester">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpacking" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Avg Attendance % ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSuppname" runat="server" Text='<%# Bind("AttdPercentage") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Avg Marks % ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSuppname" runat="server" Text='<%# Bind("average","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp;
                                </td>
                            </tr>
                            <style type="text/css">
                                .completeListStyle
                                {
                                    height: 100px;
                                    width: 50px;
                                    overflow: auto;
                                    list-style-type: disc;
                                    padding-left: 17px;
                                    background-color: #FFF;
                                    border: 1px solid DarkGray;
                                    text-align: left;
                                    font-size: small;
                                    color: black;
                                }
                            </style>
                        </table>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

