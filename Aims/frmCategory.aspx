<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCategory.aspx.vb"
    Inherits="frmDepreciation_Rates" Title="Category" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Category</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
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
            var msg;
            msg = DropDownForZeroMul(document.getElementById("<%=cmbDept.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=cmbDept.ClientID %>").focus();
                a = document.getElementById("<%=lblDept.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = NameField100Mul(document.getElementById("<%=txtName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtName.ClientID %>").focus();
                a = document.getElementById("<%=lblName.ClientID %>").innerHTML;
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
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <a name="Top">
                    <div align="right">
                        <a href="#Bottom">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    </div>
                    <div>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                        <br />
                        <br />
                        <center>
                            <table class="custTable">
                                <tbody>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblID" runat="server" SkinID="lblRsz" Text=" ID :&nbsp;&nbsp;" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblDept" runat="server" SkinID="lblRsz" Text="Department* :&nbsp;&nbsp;" Width ="150px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="cmbDept" runat="server" DataSourceID="ObjectDataSource2" DataTextField="DeptName"
                                                SkinID="ddlRsz" AutoPostBack="true" AppendDataBoundItems="true" DataValueField="DeptID"
                                                TabIndex="1" Width="200">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblName" runat="server" SkinID="lblRsz" Text="Name* :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" SkinID="txtRsz" TabIndex="2" Width="195"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="btnTd" colspan="2">
                                            <br />
                                            <asp:Button ID="BtnSave" TabIndex="3" runat="server" Text="ADD" CausesValidation="True" CommandName="ADD"
                                                SkinID="btn" OnClientClick="return Validate();" CssClass="ButtonClass"></asp:Button>
                                            &nbsp;<asp:Button ID="BtnDetails" TabIndex="4" runat="server" Text="VIEW" CommandName="VIEW" CausesValidation="False"
                                                SkinID="btn" CssClass="ButtonClass"></asp:Button>
                                            <%--<asp:Button ID="BtnReport" TabIndex="4" runat="server" Text="REPORT" CausesValidation="False"
                                    SkinID="btn" CssClass="btnStyle"></asp:Button>--%>
                                            <!--<asp:Button id="BtnRecover" tabIndex=5 runat="server" Text="RECOVER" CausesValidation="False" SkinID="btn" __designer:wfdid="w19" CssClass="btnStyle"></asp:Button>-->
                            </table>
                        </center>
                        <div>
                            &nbsp;</div>
                        <center>
                            <div>
                                <asp:Label ID="msginfo" runat="server" EnableTheming="True" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" EnableTheming="true" SkinID="lblGreen"></asp:Label>
                            </div>
                        </center>
                        <div>
                            &nbsp;</div>
                        <div>
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="300px" Height="300px">
                                <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                                    AllowPaging="True" PageSize="100" EnableSortingAndPagingCallbacks="True" AllowSorting="True">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" Font-Underline="False"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                    Text="Delete" Font-Underline="False" Visible="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department" SortExpression="DeptName">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Visible="False" Text='<%# Bind("Dept_ID") %>'></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" SortExpression="CategoryName">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Visible="False" Text='<%# Bind("Category_ID") %>'></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Depreciation_Rates"
                            SelectMethod="GetDepreciation_Rates"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetDepartment"
                            TypeName="CategoryManager"></asp:ObjectDataSource>
                    </div>
                    <a name="Bottom">
                        <div align="right">
                            <a href="#Top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                        </div>
                    </a>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

