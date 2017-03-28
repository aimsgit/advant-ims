<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmLetterPad.aspx.vb"
    Inherits="FrmLetterPad" Title="Letter Pad" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Letter Pad</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=TxtRef_Date.ClientID %>"), 'Date');
            if (msg != "") {
                document.getElementById("<%=TxtRef_Date.ClientID %>").focus();
                return msg;
            }
            msg = NameField1000(document.getElementById("<%=txtRefNo.ClientID %>"), 'Letter No');
            if (msg != "") {
                document.getElementById("<%=txtRefNo.ClientID %>").focus();
                return msg;
            }
            msg = NameField1000(document.getElementById("<%=txtFrom.ClientID %>"), 'From');
            if (msg != "") {
                document.getElementById("<%=txtFrom.ClientID %>").focus();
                return msg;
            }
            msg = NameField1000(document.getElementById("<%=txtref_Per.ClientID %>"), 'To');
            if (msg != "") {
                document.getElementById("<%=txtref_Per.ClientID %>").focus();
                return msg;
            }
            msg = NameField1000(document.getElementById("<%=txtSalutation.ClientID %>"), 'Salutation');
            if (msg != "") {
                document.getElementById("<%=txtSalutation.ClientID %>").focus();
                return msg;
            }

            msg = NameField250E(document.getElementById("<%=txtSignature.ClientID %>"), 'Signature');
            if (msg != "") {
                document.getElementById("<%=txtSignature.ClientID %>").focus();
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
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image3" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <%--   <center>
                    <h1 class="headingTxt">
                        LETTER PAD
                    </h1>
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblLetterDate" runat="server" SkinID="lblRsz" Text=" Date* &nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:TextBox ID="TxtRef_Date" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                        SkinID="Calendar" TargetControlID="TxtRef_Date">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRefNo" runat="server" SkinID="lblRsz" Text="Letter No* &nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRefNo" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFrom" runat="server" SkinID="lbl" Text="From* &nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFrom" runat="server" SkinID="txt" TextMode="MultiLine" Width="321px"
                                        TabIndex="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTo" runat="server" SkinID="lblRsz" Text="To* &nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtref_Per" runat="server" SkinID="txt" TabIndex="4" TextMode="MultiLine"
                                        Width="327px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Salutation* &nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSalutation" SkinID="txt" runat="server" TextMode="MultiLine"
                                        TabIndex="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSubject" runat="server" SkinID="lblRsz" Text="Subject &nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSub" runat="server" SkinID="txtRsz" TabIndex="6" TextMode="MultiLine"
                                        Width="325px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblContent" runat="server" SkinID="lblRsz" Text="Content &nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtCont" runat="server" SkinID="txtRsz" TabIndex="7" TextMode="MultiLine"
                                        Width="325px" Height="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSignature" SkinID="lbl" runat="server" Text="Signature* &nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSignature" SkinID="txt" runat="server" TextMode="MultiLine" TabIndex="8"
                                        Height="60px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblIncludeHeader" runat="server" SkinID="lbl" Text="Include Header &nbsp;:&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="ChkBoxHeader" SkinID="chk" TabIndex="9" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    &nbsp;
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
                                <td colspan="2" class="btnTd">
                                    <asp:Button ID="btnsave" runat="server" Text="ADD" SkinID="btn" TabIndex="10" CausesValidation="true"
                                        OnClientClick="return Validate();" CssClass="ButtonClass " />
                                    <asp:Button ID="btnDetails" runat="server" Text="VIEW" SkinID="btn" CausesValidation="false"
                                        TabIndex="11" CssClass="ButtonClass " />
                                    <asp:Button ID="btnprntlettr" runat="server" Text="PRINT LETTER" SkinID="btnRsz"
                                        Width="120px" CausesValidation="false" TabIndex="12" CssClass="ButtonClass " />
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <div>
                                        <center>
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        </center>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </center>
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
                <div>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                            <center>
                                <asp:GridView ID="GridView1" runat="server" SkinID="GridView" DataKeyNames="Ref_ID"
                                    AutoGenerateColumns="False" AllowPaging="True" PageSize="100" EnableSortingAndPagingCallbacks="True"
                                    AllowSorting="True">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" TabIndex="8" />
                                                <asp:LinkButton ID="Button3" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="Delete" TabIndex="9" OnClientClick="return confirm('Do you want to delete this record?')" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkBx" runat="server" TabIndex="10"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Letter Date" SortExpression="Ref_Date" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="lblRef_ID" runat="server" Value='<%# Bind("Ref_ID") %>' />
                                                <asp:HiddenField ID="LblRef_ID_A" runat="server" Value='<%# Bind("Ref_ID_Auto") %>' />
                                                <asp:Label ID="lblRef_Date" runat="server" Text='<%# Bind("Ref_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Letter No" SortExpression="Ref_No" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="Ref_No1" runat="server" Text='<%# Bind("Ref_No") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFromm" runat="server" Width="200px" Text='<%# Bind("FromPerson") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="Ref_Person1" runat="server" Width="200px" Text='<%# Bind("Ref_Person") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Salutation" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalutationn" runat="server" Width="200px" Text='<%# Bind("Salutation") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                                            ControlStyle-Width="175px">
                                            <ItemTemplate>
                                                <asp:Label ID="Subject1" Width="190px" runat="server" Text='<%# Bind("Subject") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Content" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"
                                            ControlStyle-Width="375px">
                                            <ItemTemplate>
                                                <asp:Label ID="ContentLP1" Width="290px" runat="server" Text='<%# Bind("ContentLP") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Signature" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSignaturee" runat="server" Width="200px" Text='<%# Bind("Signature") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </center>
                        </asp:Panel>
                    </center>
                </div>
                <asp:ObjectDataSource ID="SqlDataSource1" runat="server" DeleteMethod="ChangeFlag"
                    UpdateMethod="UpdateRecord" SelectMethod="GetLetterPad" OldValuesParameterFormatString="original_{0}"
                    InsertMethod="InsertRecord" DataObjectTypeName="LetterPad" TypeName="LetterPadManager">
                    <DeleteParameters>
                        <asp:Parameter Name="Ref_ID" Type="int32" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:Parameter Name="id" Type="int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
