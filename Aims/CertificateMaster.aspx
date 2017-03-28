<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CertificateMaster.aspx.vb"
    Inherits="CertificateMaster" Title="Certificate Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Certificate Details</title>
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
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = msg;
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
            msg = NameField100Mul(document.getElementById("<%=TxtCertificateName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TxtCertificateName.ClientID %>").focus();
                a = document.getElementById("<%=lblCertificateName.ClientID %>").innerHTML;
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
                <center>
                    <%--  <h1 class="headingTxt">
                        CERTIFICATE DETAILS</h1>--%>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </center>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCertificateName" runat="server" SkinID="lblRsz" Text="Certificate Name*&nbsp;:&nbsp;&nbsp;"
                                    Width="200px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtCertificateName" runat="server" AutoCompleteType="Disabled" EnableViewState="False"
                                    SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2" align="center">
                                <asp:Button ID="BtnSave" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                 commandname="ADD"   OnClientClick="return Validate();" SkinID="btn" TabIndex="2" Text="ADD" />&nbsp;
                                <asp:Button ID="BtnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                  commandname="VIEW"   SkinID="btn" TabIndex="3" Text="VIEW" />&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <center>
                        <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                            <asp:GridView ID="GrdCertificate" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="Certificate_Id" OnRowUpdated="GridviewItemUpdated" SkinID="GridView"
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
                                    <asp:TemplateField HeaderText="Certificate Name" SortExpression="Certificate_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Bind("Certificate_Name") %>'></asp:Label>
                                            <asp:HiddenField ID="Cid" runat="server" Value='<%# Bind("Certificate_Id") %>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
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

