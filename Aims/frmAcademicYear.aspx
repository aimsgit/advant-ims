<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmAcademicYear.aspx.vb"
    Inherits="frmAcademicYear" Title="Academic year" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Academic year</title>
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
            msg = NameField100Mul(document.getElementById("<%=txtAcdYear.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=txtAcdYear.ClientID%>").focus();
                a = document.getElementById("<%=lblAcdYear.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }
            msg = ValidateDateMul(document.getElementById("<%=txtStartDate.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=txtStartDate.ClientID%>").focus();
                a = document.getElementById("<%=Label4.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }
            msg = ValidateDateMul(document.getElementById("<%=txtEndDate.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=txtEndDate.ClientID%>").focus();
                a = document.getElementById("<%=Label6.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
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
            <%--<center>
                <h1 class="headingTxt">
                    ACADEMIC YEAR
                </h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table>
                    <tr align="center">
                        <td align="right">
                            <asp:Label ID="lblAcdYear" runat="server" Text="Academic Calendar Year* :" SkinID="lblRsz" Width="250"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;<asp:TextBox ID="txtAcdYear"  runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Start Date* :" SkinID="lblRsz" Width="150px"
                                Height="23px"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;<asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="2"
                                MaxLength="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="End Date* :" SkinID="lblRsz" Width="150px"
                                Height="23px"></asp:Label>
                        </td>
                        <td>
                            &nbsp;&nbsp;<asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="3"
                                MaxLength="11"></asp:TextBox>
                        </td>
                        <ajaxToolkit:CalendarExtender ID="SDate" runat="server" CssClass="cal_Theme1" Format="dd-MMM-yyyy"
                            TargetControlID="txtStartDate">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:CalendarExtender ID="EDate" runat="server" CssClass="cal_Theme1" Format="dd-MMM-yyyy"
                            TargetControlID="txtEndDate">
                        </ajaxToolkit:CalendarExtender>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" Text="Current Year* :" SkinID="lblRsz" Width="150px"
                                Height="23px"></asp:Label>
                        </td>
                        <td>
                            &nbsp;&nbsp;<asp:DropDownList ID="ddlcurr_Year" SkinID="ddl" TabIndex="4" runat="server"
                                DataValueField="id" AutoPostBack="True">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="btnTd" colspan="2">
                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="ADD"
                                CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="5"
                                Text="ADD" />
                            &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                CommandName="VIEW" SkinID="btn" TabIndex="6" Text="VIEW" />
                        </td>
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
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:GridView ID="GrdAcdYear" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" />
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                    Text="Delete" Visible="false" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Academic Year" Visible="true" SortExpression="AcademicYear">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstartDate" runat="server" Text='<%# Bind("StartDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEnddate" runat="server" Text='<%# Bind("EndDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Current Year">
                                           <ItemTemplate>
                                                <asp:Label ID="lblCurrYear" runat="server" Text='<%# Bind("CurrentYear") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Center"/>
                                            <HeaderStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                </asp:Panel>
            </center>
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