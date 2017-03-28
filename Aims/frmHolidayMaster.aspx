<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmHolidayMaster.aspx.vb"
    Inherits="FrmHolidayMaster" Title="Holiday Master" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Holiday Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="javascript" type="text/javascript">
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
            msg = NameField100Mul(document.getElementById("<%=txtname.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=txtname.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMul(document.getElementById("<%=txtdate.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=txtdate.ClientID %>").focus();
                a = document.getElementById("<%=Label4.ClientID %>").innerHTML;
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
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
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
                <div class="mainBlock">
                    <%-- <center>
                        <h1 class="headingTxt">
                            HOLIDAY MASTER
                        </h1>
                      
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                        <br />
                    </center>
              
                    <center>
                        <table>
                         <tr>
                            <td colspan="2" align="center">
                                <asp:RadioButtonList ID="RbType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                    SkinID="Themes" TabIndex="1" Width="200px">
                                    <asp:ListItem Selected="True" Text="Holiday" Value="H"></asp:ListItem>
                                    <asp:ListItem Text="Event" Value="E"></asp:ListItem>
                                </asp:RadioButtonList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" SkinID="lblRsz" 
                                    Text="Name* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtname" runat="server" SkinID="txtRsz" TabIndex="2" Width="200"></asp:TextBox>
                            </td>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" SkinID="lblRsz" 
                                        Text="Date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdate" runat="server" SkinID="txtRsz" TabIndex="3" Width="200"></asp:TextBox>
                                </td>
                            </tr>
                              <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" SkinID="lblRsz" 
                                        Text="Abbreviation :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtShortform" runat="server" SkinID="txtRsz" TabIndex="4" Width="200"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                    <%--<asp:TextBox ID="txtRID" runat="server" Text='<%# Bind("Dept_ID") %>' __designer:wfdid="w15"
                                                    Visible="False"></asp:TextBox>--%>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td class="btnTd">
                                    <center>
                                        <asp:Button ID="InsertButton" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                            SkinID="btn" Text="ADD" CommandName="ADD" ValidationGroup="ADD" TabIndex="5" />
                                        &nbsp;<asp:Button ID="btnDet" runat="server" CausesValidation="False" CssClass="ButtonClass" CommandName="VIEW"
                                            SkinID="btn" TabIndex="6" Text="VIEW" />
                                        <br />
                                        <br />
                                        <%--<asp:Button ID="PrevButton" TabIndex="5" OnClick="preview" runat="server" Text="REPORT"
                                                        CausesValidation="False" SkinID="btn" __designer:wfdid="w18" meta:resourcekey="PrevButtonResource1"
                                                        CssClass="btnStyle" CommandName="Preview"></asp:Button>--%>
                                        <center>
                                            <div>
                                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                            </div>
                                            <br />
                                        </center>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                            Format="dd-MMM-yyyy" TargetControlID="txtdate">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="HM_ID"
                                            SkinID="Gridview" Visible="False" AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                            Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                            Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete" Visible="false"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="center" />
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Holiday Name" SortExpression="HolidayName">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("HM_ID") %>' Visible="false" />
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("HolidayName") %>' Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" SortExpression="HolidayDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("HolidayDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Day">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Day") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Abbreviation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("ShortName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <div>
                            &nbsp;</div>
                        <%--div >
                                    <asp:Label ID="lblErrMsg" runat="server" __designer:wfdid="w20"></asp:Label>
                                </div>--%>
                        <%-- <div>
                            &nbsp;</div>--%>
                    </center>
                    </InsertItemTemplate>
                    <emptydatatemplate>
                            <%--No Records To Display.--%>
                            <%--<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                                Text="New" meta:resourcekey="NewButtonResource1"></asp:LinkButton>--%>
                        </emptydatatemplate>
                    </center>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="350px" Height="177px">
                        </asp:Panel>
                        &nbsp;
                    </center>
                </div>
                <div>
                    <asp:ObjectDataSource ID="odsHolidayMaster" runat="server" TypeName="BHolidayMaster"
                        SelectMethod="GetHolidayMasterDtls" DataObjectTypeName="EHolidayMaster"></asp:ObjectDataSource>
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

</form>
</body>
</html>
