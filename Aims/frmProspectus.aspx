<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmProspectus.aspx.vb"
    Inherits="frmProspectus" Title="Prospectus Issue Details"  ValidateRequest="false"%>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Prospectus Issue Details</title>
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
            var a = document.getElementById("<%=lblname.ClientID %>").innerText;
            if (a == "Name* : ") {
                msg = NameField100Mul(document.getElementById("<%=txtName.ClientID %>"));
                if (msg != "") {
                    document.getElementById("<%=txtName.ClientID %>").focus();
                    a = document.getElementById("<%=lblname.ClientID %>").innerHTML;
                    msg = Spliter(a) + " " + ErrorMessage(msg);
                    return msg;
                }
                msg = NameField100Mul(document.getElementById("<%=txtserialno.ClientID %>"));
                if (msg != "") {
                    document.getElementById("<%=txtserialno.ClientID %>").focus();
                    a = document.getElementById("<%=lblserialno.ClientID %>").innerHTML;
                    msg = Spliter(a) + " " + ErrorMessage(msg);
                    return msg;
                }
            }
            else {
                msg = NameField100Mul(document.getElementById("<%=txtName.ClientID %>"));
                if (msg != "") {
                    document.getElementById("<%=txtName.ClientID %>").focus();
                    a = document.getElementById("<%=lblname.ClientID %>").innerHTML;
                    msg = Spliter(a) + " " + ErrorMessage(msg);
                    return msg;
                }
                msg = NameField100Mul(document.getElementById("<%=txtserialno.ClientID %>"));
                if (msg != "") {
                    document.getElementById("<%=txtserialno.ClientID %>").focus();
                    a = document.getElementById("<%=lblserialno.ClientID %>").innerHTML;
                    msg = Spliter(a) + " " + ErrorMessage(msg);
                    return msg;
                }
            }

            msg = ValidateDateMul(document.getElementById("<%=txtDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtDate.ClientID %>").focus();
                a = document.getElementById("<%=lbldate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldRestrictDecimalMul(document.getElementById("<%=txtquantity.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtquantity.ClientID %>").focus();
                a = document.getElementById("<%=lblquantity.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField100NMul(document.getElementById("<%=txtreceiptno.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtreceiptno.ClientID %>").focus();
                a = document.getElementById("<%=lblpreceiptno.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FeesFieldMul(document.getElementById("<%=txtprice.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtprice.ClientID %>").focus();
                a = document.getElementById("<%=lblprice.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field255NMul(document.getElementById("<%=txtRemarks.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtRemarks.ClientID %>").focus();
                a = document.getElementById("<%=lblremarks.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsge.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgs.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsge.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsgs.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        function OnRadioSelect1() {
            alert('Working....');
        }
     
 
 
    </script>


  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--       <center>
                        <h1 class="headingTxt">
                            PROSPECTUS ISSUE DETAILS
                        </h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        
                            <table class="custTable">
                            <center>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:RadioButtonList ID="RButton" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                            TabIndex="1" SkinID="RD">
                                            <asp:ListItem Value="S" Selected="True">Sale</asp:ListItem>
                                            <asp:ListItem Value="C">Complementary</asp:ListItem>
                                            <asp:ListItem Value="R">Received</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblname" name="lblname1" runat="server" Text="Name* :  " SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtname" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblserialno" runat="server" Text="Prospectus No* :  " SkinID="lblRsz" Width="150 px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtserialno" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lbldate" runat="server" SkinID="lbl" Text="Entry Date* :  "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" MaxLength="11" SkinID="txt" TabIndex="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblquantity" runat="server" Text="Quantity* :  " SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtquantity" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblpreceiptno" runat="server" SkinID="lbl" Text="Receipt No :  "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtreceiptno" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblprice" runat="server" SkinID="lbl" Text="Price* :  "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPrice" runat="server" SkinID="txtRsz" Width="150" TabIndex="7"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" ValidChars="1234567890."
                                            runat="server" TargetControlID="txtPrice">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblAvailable" runat="server" SkinID="lblRsz" Width="180" Text="Available Quantity :  "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtAvailable" runat="server" SkinID="txt" Enabled="False" TabIndex="8"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblremarks" runat="server" Text="Remarks :  " SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="BtnAdd" runat="server" SkinID="btn" Text="ADD" CommandName="ADD"
                                            OnClientClick="return Validate();" TabIndex="10" CssClass="ButtonClass" />
                                        &nbsp;
                                        <asp:Button ID="BtnView" runat="server" SkinID="btn" Text="VIEW" CommandName="VIEW"
                                            TabIndex="11" CssClass="ButtonClass" />
                                        <table>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right">
                                                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                                        <ProgressTemplate>
                                                            <div class="PleaseWait">
                                                                <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblmsge" runat="server" SkinID="lblRed"> </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblmsgs" runat="server" SkinID="lblGreen"> </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                            <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="True"
                                                AutoGenerateColumns="False" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <Columns>
                                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                TabIndex="12" Text="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                TabIndex="13" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name" SortExpression="Student_Name" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="PID" runat="server" Value='<%# Bind("Prosp_IDAuto") %>'></asp:HiddenField>
                                                            <asp:Label ID="PType" Visible="false" runat="server" Text='<%# Bind("ProspectusType") %>'></asp:Label>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Student_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Entry Date" SortExpression="IssueDate" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Entry_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Prospectus No" SortExpression="SerialNo" HeaderStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Price" SortExpression="Prosp_Price" HeaderStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Prosp_Price","{0:n2}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Receipt No" SortExpression="PReceipt_No" HeaderStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtrecptno" runat="server" Text='<%# Bind("PReceipt_No") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity In" SortExpression="Qty_In" HeaderStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Qty_In") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity Out" SortExpression="Qty_Out" HeaderStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labe37" runat="server" Text='<%# Bind("Qty_Out") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                </center>
                            </table>
                        
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                            Format="dd-MMM-yyyy" TargetControlID="txtDate">
                        </ajaxToolkit:CalendarExtender>
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
