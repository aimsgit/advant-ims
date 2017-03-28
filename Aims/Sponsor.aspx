<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Sponsor.aspx.vb"
    Inherits="frmCourseType" Title="Sponsor Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sponsor Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script src="js/Tvalidate.js" type="text/javascript">
    

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
            msg = NameField250Mul(document.getElementById("<%=txtSprName.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=txtSprName.ClientID%>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            //            msg = valcontact(document.getElementById("<%=txtContactNumber.ClientID%>"), 'Contact Number');
            //            if (msg != "") return msg;
            //            msg = Field255(document.getElementById("<%=txtSprAddress.ClientID%>"), 'Address');
            //            if (msg != "") return msg;
            //         
            //           msg = validateEmail(document.getElementById("<%=txtEmail.ClientID%>"), '');
            //            if (msg != "") return msg;
            msg = Field255NMul(document.getElementById("<%=txtRemarks.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtRemarks.ClientID%>").focus();
                a = document.getElementById("<%=Label3.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Valdate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrormsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrormsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
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
        <%-- <center>
            <h1 class="headingTxt">
                SPONSOR DETAILS
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text=" Name* :"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp<asp:TextBox ID="txtSprName" runat="server" SkinID="txtRsz" Width="250Px"
                                    TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="*~!@$%^&*()+\0123456789"
                                    TargetControlID="txtSprName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" SkinID="lblRsz" Text="Contact Number :  "></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp<asp:TextBox ID="txtContactNumber" runat="server" AutoCompleteType="Disabled"
                                    SkinID="txt" TabIndex="2" Text='<%# Bind("ContactNumber") %>'></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtContactNumber">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Address :  "></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp<asp:TextBox ID="txtSprAddress" runat="server" Font-Underline="False"
                                    SkinID="txt" TabIndex="3" Text='<%# Bind("SponsorAddress") %>' TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" SkinID="lbl" Text="Email :  "></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp<asp:TextBox ID="txtEmail" runat="server" MaxLength="50" SkinID="txt"
                                    TabIndex="4" Text='<%# Bind("Email") %>'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Remarks :  "></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp<asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" AutoCompleteType="Disabled"
                                    MaxLength="50" SkinID="txt" TabIndex="5" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <center>
                                    <asp:Button ID="btnadd" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        CommandName="ADD" OnClientClick="return Valdate();" SkinID="btn" TabIndex="6"
                                        Text="ADD" />
                                    &nbsp;<asp:Button ID="btnview" runat="server" CssClass="ButtonClass" SkinID="btn"
                                        TabIndex="7" Text="VIEW" CommandName="VIEW" />
                                </center>
                            </td>
                        </tr>
                    </table>
                    </center>
                    <div>
                        &nbsp;</div>
                    <center>
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblErrormsg" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    <div>
                        <center>
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                <asp:GridView ID="GVSponsor" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataKeyNames="Sponsor_ID" SkinID="GridView" Visible="True" Width="256px" PageSize="100"
                                    AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit"></asp:LinkButton>
                                                <%--<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                    Text="Delete" Visible="false"></asp:LinkButton>--%>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sponsor" SortExpression="SponsorName">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="SID" runat="server" Value='<%# Bind("Sponsor_ID") %>' />
                                                <asp:Label ID="Label2" runat="server" Width="250px" Text='<%# Bind("SponsorName") %>' />
                                                <itemstyle wrap="True" horizontalalign="left" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact No" SortExpression="ContactNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ContactNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address" SortExpression="SponsorAddress">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Width="150px" Text='<%# Bind("SponsorAddress") %>'></asp:Label>
                                                <itemstyle wrap="True" horizontalalign="left" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </center>
                        <a name="bottom">
                            <div align="right">
                                <a href="#top">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                            </div>
                        </a>
                        <%--   <asp:ObjectDataSource ID="ObjSponsor" runat="server" DeleteMethod="ChangeFlag" UpdateMethod="UpdateRecord"
                SelectMethod="GetSponsor" OldValuesParameterFormatString="original_{0}" InsertMethod="InsertRecord"
                DataObjectTypeName="Sponsor" TypeName="SponsorManager" __designer:wfdid="w104">
                <SelectParameters>
                    <asp:Parameter Name="Name" Type="Int64" DefaultValue="0" />
                </SelectParameters>
            </asp:ObjectDataSource>--%></div>
                    <%--   <asp:ObjectDataSource ID="ObjSponsor" runat="server" DeleteMethod="ChangeFlag" UpdateMethod="UpdateRecord"
                SelectMethod="GetSponsor" OldValuesParameterFormatString="original_{0}" InsertMethod="InsertRecord"
                DataObjectTypeName="Sponsor" TypeName="SponsorManager" __designer:wfdid="w104">
                <SelectParameters>
                    <asp:Parameter Name="Name" Type="Int64" DefaultValue="0" />
                </SelectParameters>
            </asp:ObjectDataSource>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</form>
</body>
</html>
