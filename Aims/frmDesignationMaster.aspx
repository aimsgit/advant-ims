<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmDesignationMaster.aspx.vb"
    Inherits="frmDepreciation_Rates" Title="Designation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Designation</title>
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
            msg = NameField100Mul(document.getElementById("<%=txtDesigName.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtDesigName.ClientID%>").focus();
                a = document.getElementById("<%=lblDesigName.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = NameField100Mul(document.getElementById("<%=txtCatgryEmpType.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtCatgryEmpType.ClientID%>").focus();
                a = document.getElementById("<%=lblCatgryEmpType.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
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
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="lblhead" runat="server" Text = "DESIGNATION MASTER"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDesigName" runat="server" Text="Designation* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDesigName" runat="server" SkinID="txtRsz" TabIndex="1" Width="200"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSalCodeGrd" runat="server" Text="Salary Code / Grade :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSalCodeGrd" AutoPostBack ="true"  runat="server" TabIndex="2" SkinID="ddlRsz" DataSourceID="ObjDesigSal"
                                            DataTextField="SalaryBand" DataValueField = "Grade_Auto"  Width="200px">
                                       <%--<asp:ListItem Value = "0" text = "Select" Enabled = "true">Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                       <asp:ObjectDataSource ID="ObjDesigSal" runat="server" SelectMethod="ddlSalryCodeGrdDesig" TypeName="DesignationDB">
                                        </asp:ObjectDataSource>
                                    
                                   <%--  <asp:DropDownList ID="ddlSalaryBand" runat="server" AutoPostBack="True" DataSourceID="ObjCourse"
                                            DataTextField="SalaryBandName" DataValueField="SalaryBandAuto" SkinID="ddl" TabIndex="1">
                                        </asp:DropDownList>--%>
                                     
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCatgryEmpType" runat="server" Text="Category*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCatgryEmpType" runat="server" SkinID="txtRsz" TabIndex="3" Width="200"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                            <td>
                            &nbsp;
                            </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <asp:Button ID="BtnAdd" runat="server" Text="ADD" CausesValidation="True" TabIndex="4"
                                        CommandName="ADD" SkinID="btn" OnClientClick="return Validate();" CssClass="ButtonClass">
                                    </asp:Button>
                                    <asp:Button ID="BtnDetails" TabIndex="5" runat="server" Text="VIEW" CausesValidation="False"
                                        CommandName="VIEW" SkinID="btn" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <center>
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                        <asp:Label ID="msginfo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                    </center>
                    <br />
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="600px" Height="400px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" SkinID="GridView"
                                AutoGenerateColumns="False" DataKeyNames="Designation" PageSize="100" AllowSorting="True"
                                EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                      <ItemStyle Wrap ="false" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit" Font-Underline="False"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                Text="Delete"  Font-Underline="False"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Designation_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation Name" SortExpression="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Salary Code/Grade" SortExpression = "SalaryCodeBand">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGVSalCodeID" Visible ="false"  runat="server" Text='<%# Bind("Designation_ID") %>'></asp:Label>
                                            <asp:Label ID="lblGvSalCodeGrd" runat="server" Text='<%# Bind("SalaryCodeBand") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category" SortExpression="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGvCatgory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </div>
                . <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
