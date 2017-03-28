<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStudentCategory.aspx.vb"
    Inherits="frmStudentCategory" Title="Student Category" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Category</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="javascript" type="text/javascript">
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
            var msg;
            msg = NameField100Mul(document.getElementById("<%=txtname.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtname.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
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
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mainBlock">
                <%--<center>
                    <h1 class="headingTxt">
                        STUDENT CATEGORY
                    </h1>
                    <br />
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                    <br />
                </center>
                <center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Category Name*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtname" runat="server" SkinID="txtRsz" TabIndex="1"></asp:TextBox>
                                </td>
                            </tr>
                            </tbody>
                            <caption>
                                <br />
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td class="btnTd" colspan="2">
                                        <center>
                                            <asp:Button ID="InsertButton" runat="server" TabIndex="2" CssClass="ButtonClass"
                                                CommandName="ADD" OnClientClick="return Validate();" SkinID="btn" Text="ADD"
                                                ValidationGroup="ADD" />
                                            &nbsp;<asp:Button ID="btnDet" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                SkinID="btn" TabIndex="3" Text="VIEW" CommandName="VIEW" />
                                        </center>
                                    </td>
                                </tr>
                                </tbody>
                            </caption>
                        </table>
                    </center>
                    <center>
                        <div>
                            &nbsp;</div>
                    </center>
                    </InsertItemTemplate>
                </center>
                <center>
                    <div>
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    </div>
                    <br />
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="200px" Height="300px">
                        <asp:GridView ID="GvStdcategory" runat="server" SkinID="GridView" DataKeyNames="ID"
                            AutoGenerateColumns="False" AllowPaging="True" PageSize="100" EnableSortingAndPagingCallbacks="True"
                            AllowSorting="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" Font-Underline="False"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" Visible="false" Font-Underline="False"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category Name" SortExpression="Std_CategoryName">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="DID" Visible="false" runat="server" Value='<%# Bind("ID") %>' />
                                        <asp:Label ID="Label2" Visible="true" runat="server" Text='<%# Bind("Std_CategoryName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        &nbsp;</asp:Panel>
                </center>
            </div>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>