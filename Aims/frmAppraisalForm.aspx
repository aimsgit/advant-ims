<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAppraisalForm.aspx.vb"
    Inherits="frmAppraisalForm" Title="APPRAISAL FORM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>APPRAISAL FORM</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
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
            msg = DropDownMul(document.getElementById("<%=ddlAppraisaltype.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlAppraisaltype.ClientID%>").focus();
                a = document.getElementById("<%=lblAppraisaltype.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownMul(document.getElementById("<%=ddlempcode.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlempcode.ClientID%>").focus();
                a = document.getElementById("<%=lblempcode.ClientID %>").innerHTML;
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
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
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
            </a>
            <center>
                <h1 class="headingTxt">
                    APPRAISAL FORM
                </h1>
            </center>
            <br />
            <br />
            <asp:Panel ID="Panel3" runat="server" Visible="True">
                <center>
                    <table>
                        <tr>
                            <caption>
                                <td align="right">
                                    <asp:Label ID="lblAppraisaltype" runat="server" SkinID="lblRsz" Text="Appraisal*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAppraisaltype" runat="server" SkinID="ddl" AutoPostBack="true"
                                        TabIndex="1">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Self"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Manager"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Reviewer"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </caption>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblempcode" runat="server" Text="Employee Code* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlempcode" runat="server" DataTextField="Emp_Code" AutoPostBack="true "
                                    DataValueField="EmpID" SkinID="ddl" TabIndex="2">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </center>
            </asp:Panel>
            <br />
            <br />
            <center>
                <table>
                    <tr>
                        <td align="center">
                            <%--<asp:Button ID="btnview" runat="server" Text="VIEW" Visible ="false" CssClass="ButtonClass" CausesValidation="true"
                                SkinID="btn" TabIndex="4" />--%>
                            <asp:Button ID="btnsub" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                SkinID="btn" TabIndex="3" Text="SUBMIT" Visible="true" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
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
            <br />
            <div>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="400px">
                        <asp:GridView ID="GVApprisal" runat="server" SkinID="GridView" DataKeyNames="" AllowPaging="true"
                            AutoGenerateColumns="false" PageSize="100">
                            <Columns>
                                <asp:TemplateField HeaderText="PARAMETER NAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblParameterName" width="350px" runat="server" Text='<%# Bind("ParameterName") %>'></asp:Label>
                                        <asp:Label ID="lblpno" Visible="false" runat="server" Text='<%# Bind("PNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAX">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMax" runat="server" Text='<%# Bind("Max") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MIN">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMin" runat="server" Text='<%# Bind("Min") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Self">
                                    <%--<asp:Label ID="lblSelf" runat="server" Text='<%# Bind("Semester") %>'></asp:Label>--%>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSelf" runat="server" Width="50px" SkinID="txtRsz"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtSelf">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Manager">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblManager" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>--%>
                                        <asp:TextBox ID="txtManager" runat="server" Width="50px" SkinID="txtRsz"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtManager">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reviewer">
                                    <ItemTemplate>
                                        <%--<asp:HiddenField ID="lblReviwer" runat="server" Value='<%# Bind("Subject") %>' />--%>
                                        <%--<asp:Label ID="lblSubjectName" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>--%>
                                        <asp:TextBox ID="txtReviwer" runat="server" Width="50px" SkinID="txtRsz"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtReviwer">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Final Score">
                                    <ItemTemplate>
                                        <%--<asp:HiddenField ID="lblfinalscore" runat="server" Value='<%# Bind("Lecturer") %>' />--%>
                                        <%--<asp:Label ID="lblFacultyName" runat="server" Text='<%# Bind("FACULTY") %>'></asp:Label>--%>
                                        <asp:TextBox ID="txtfinalscore" runat="server" Width="50px" SkinID="txtRsz"></asp:TextBox>
                                        <%--  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP1">
                                        </ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
            </div>
            <br />
            <a name="Bottom">
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
