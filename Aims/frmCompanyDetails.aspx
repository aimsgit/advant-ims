<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCompanyDetails.aspx.vb"
    Inherits="frmCompanyDetails" Title="Company Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Company Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

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


        //Function for Multilingual Validations
        //Created By Ajit Kumar Singh


        function Valid() {

            var msg, a;
            msg = NameField100Mul(document.getElementById("<%=TextCompName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TextCompName.ClientID %>").focus();
                a = document.getElementById("<%=Label5.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = NameField100Mul(document.getElementById("<%=TextContPer.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TextContPer.ClientID %>").focus();
                a = document.getElementById("<%=Label6.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = valcontactMul(document.getElementById("<%=TextContNo.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TextContNo.ClientID %>").focus();
                a = document.getElementById("<%=Label7.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField250Mul(document.getElementById("<%=TextAdd.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TextAdd.ClientID %>").focus();
                a = document.getElementById("<%=Label8.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }

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
        
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <a name="Top">
                        <div align="right">
                            <a href="#Bottom">
                                <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                        </div>
                        <div class="mainBlock">
                            <%--  <center>
                                <h1 class="headingTxt">
                                    COMPANY MASTER</h1>
                            </center>--%>
                            <center>
                                <h1 class="headingTxt">
                                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                                </h1>
                            </center>
                            <table class="custTable">
                                <caption>
                                    <br />
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Text="Company Name*&nbsp;:&nbsp;&nbsp;"
                                                Width="200px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextCompName" runat="server" AutoCompleteType="Disabled" EnableViewState="False"
                                                SkinID="txt" TabIndex="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" SkinID="lblRsz" Text="Contact Person*&nbsp;:&nbsp;&nbsp;"
                                                Width="200px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextContPer" runat="server" AutoCompleteType="Disabled" EnableViewState="False"
                                                SkinID="txt" TabIndex="2"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Contact No*&nbsp;:&nbsp;&nbsp;"
                                                Width="200px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextContNo" runat="server" AutoCompleteType="Disabled" EnableViewState="False"
                                                SkinID="txt" TabIndex="3"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="TextContNo">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Text="Address*&nbsp;:&nbsp;&nbsp;"
                                                Width="200px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextAdd" runat="server" AutoCompleteType="Disabled" EnableViewState="False"
                                                SkinID="txt" TabIndex="4" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                            </table>
                            <center>
                                <table>
                                    <tr>
                                        <td align="center" class="btnTd" colspan="2">
                                            <asp:Button ID="BtnSave" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                              CommandName="ADD"  OnClientClick="return Validate();" SkinID="btn" TabIndex="5" Text="ADD" />
                                            &nbsp;<asp:Button ID="BtnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                              CommandName="VIEW"  SkinID="btn" TabIndex="6" Text="VIEW" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <center>
                                                <div>
                                                    <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                                </div>
                                            </center>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <br />
                            <br />
                            <center>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="550px" Height="300px">
                                    <asp:GridView ID="GridView1" runat="server" Width="480px" SkinID="GridView" DataKeyNames="PCId"
                                        AllowPaging="True" AutoGenerateColumns="False" Visible="True" CellPadding="4"
                                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                                        PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <%-- <RowStyle BackColor="White" ForeColor="#330099" />--%>
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" CommandName="Edit"
                                                        Text="Edit" TabIndex="7"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" TabIndex="8" CausesValidation="False"
                                                        CommandName="Delete" Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False"></ItemStyle>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Name" SortExpression="PCName">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="RID" runat="server" Value='<%# Bind("PCId") %>'></asp:HiddenField>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("PCName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Person" SortExpression="PCCntPerson">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("PCCntPerson") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("PCCntNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address" >
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("PCAdd") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                            <a name="Bottom">
                                <div align="right">
                                    <a href="#Top">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                                </div>
                            </a>
                </ContentTemplate>
                <%-- <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="FormView1" EventName="ItemCommand"></asp:AsyncPostBackTrigger>
                    </Triggers>--%>
            </asp:UpdatePanel>
            &nbsp;
        </div>
    </center>
    <asp:ObjectDataSource ID="Objcompany" runat="server" DataObjectTypeName="Company"
        DeleteMethod="ChangeFlag" InsertMethod="InsertRecord" SelectMethod="GetCompany"
        TypeName="CompanyManager" UpdateMethod="UpdateRecord" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>

</form>
</body>
</html>
