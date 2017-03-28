<%--<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Home.master" CodeFile="frmAssessment.aspx.vb"
    Title="Assessment Details" Inherits="frmAssessment" %>--%>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAssessment.aspx.vb" Inherits="frmAssessment" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Assessment Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
  
  <script type="text/javascript" language="javascript">
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }


        //Function for Multilingual Validations
        //Created By Ajit Kumar Singh


        function Valid() {

            var msg, a;
            msg = NameField100Mul(document.getElementById("<%=TxtAssessmentName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtAssessmentName.ClientID %>").focus();
                a = document.getElementById("<%=lblCertificateName.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = AgeField(document.getElementById("<%=txtSequence.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtSequence.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div class="mainBlock">
                <%-- <center>
                    <h1 class="headingTxt">
                        ASSESSMENT DETAILS &nbsp;&nbsp;&nbsp;&nbsp;</h1>
                    &nbsp;&nbsp;
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCertificateName" runat="server" SkinID="lblRsz" Text=" Name*&nbsp;:&nbsp;&nbsp;"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtAssessmentName" runat="server" AutoCompleteType="Disabled" EnableViewState="False"
                                    SkinID="txtRsz" TabIndex="1" Width="200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Sequence* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSequence" TabIndex="2" runat="server" SkinID="txtRsz" Width="200"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    ValidChars="1234567890" TargetControlID="txtSequence">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2" align="center">
                                <asp:Button ID="BtnSave" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    CommandName="ADD" OnClientClick="return Validate();" SkinID="btn" TabIndex="2"
                                    Text="ADD" />&nbsp;<asp:Button ID="BtnDetails" runat="server" CausesValidation="False"
                                        CssClass="ButtonClass" CommandName="VIEW" SkinID="btn" TabIndex="3" Text="VIEW" />&nbsp;
                            </td>
                        </tr>
                        <br />
                    </table>
                    <table>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="400px" Height="300px">
                        <asp:GridView ID="GrdAssessment" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            DataKeyNames="ID" OnRowUpdated="GridviewItemUpdated" SkinID="GridView" TabIndex="6"
                            PageSize="100">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" cssproperty="Btnclass"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                            cssproperty="Btnclass" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" Visible="false"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assessment Name" SortExpression="Certificate_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("AssessmentType") %>'></asp:Label>
                                        <asp:HiddenField ID="Cid" runat="server" Value='<%# Bind("ID") %>'></asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sequence No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSeqNo" runat="server" Text='<%# Bind("SequenceNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
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
    <%--</asp:Content>--%>
</body>
</html>
