<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSemester.aspx.vb"
    Inherits="frmSemester" Title="Semester Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Semester Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

 <script src="js/Tvalidate.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">

        //Function for Multilingual Validations
        //Created By Niraj
        function ErrorMessage(msg) {
            var SesVar = '<%= Session("Validation") %>';
            var ValidationArray = new Array();
            ValidationArray = SesVar.split(":");
            for (var i = 0; i < ValidationArray.length - 1; i++) {
                if (ValidationArray[i] == msg) {
                    return ValidationArray[i + 1];
                }
            }
        }


        function Spliter(a) {
            var str = a;
            var n = str.indexOf("*");
            if (n != 0 && n != -1) {
                a = a.split("*");
                return a[0];
            }
            var n = str.indexOf("^");
            if (n != 0 && n != -1) {
                a = a.split("^");
                return a[0];
            }
            var n = str.indexOf(":");
            if (n != 0 && n != -1) {
                a = a.split(":");
                return a[0];
            }
        }


        function Valid() {
            var msg, a;

            msg = NameField100Mul(document.getElementById("<%=txtSemester.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtSemester.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = FeesFieldMul(document.getElementById("<%=txtDuration.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtDuration.ClientID %>").focus();
                a = document.getElementById("<%=Label3.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <div>
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <br />
                    <center>
                        <table class="custTable">
                            <tr align="center">
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Semester*&nbsp;:&nbsp;&nbsp;"
                                        TabIndex="-1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSemester" runat="server" SkinID="txtRsz" TabIndex="1" Width="200"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterMode="InvalidChars" FilterType="numbers" InvalidChars="!#$%^&*()++~`|\}]{[��:;?/><,"
                                        TargetControlID="txtSemester">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Duration(Days)*&nbsp;:&nbsp;&nbsp;"
                                        Width="180" TabIndex="-1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDuration" runat="server" SkinID="txtRsz" TabIndex="2" Width="200"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <caption>
                                <br />
                                <br />
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <asp:Button ID="btnSave" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" CommandName="ADD" TabIndex="3"
                                            Text="ADD" />
                                        &nbsp;
                                        <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btn" CommandName="VIEW"
                                            TabIndex="4" Text="VIEW" />
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <div>
                                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                            </div>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="400px" Height="300px">
                                                <asp:GridView ID="GVAssessment" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    DataKeyNames="ID" PageSize="100" SkinID="GridView" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                    Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                    Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                    Text="Delete" Visible="false"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Underline="False" HorizontalAlign="Left" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ControlStyle Font-Underline="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Semester Type" SortExpression="SemName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>
                                                                <asp:HiddenField ID="SID" runat="server" Value='<%# Bind("ID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Duration(Days)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("durationDays") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </center>
                                    </td>
                                </tr>
                            </caption>
                        </table>
                        <a name="bottom">
                            <div align="right">
                                <a href="#top">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                            </div>
                        </a>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>


</form>
</body>
</html>