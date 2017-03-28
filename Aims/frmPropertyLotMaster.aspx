<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPropertyLotMaster.aspx.vb"
    Inherits="frmPropertyLotMaster" Title="Property Lot Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";

                    return false;
                }
                return true;
            }
        }
        function Valid() {

            var msg, a;
            msg = Field50Mul(document.getElementById("<%=txtLotNumber.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtLotNumber.ClientID %>").focus();
                a = document.getElementById("<%=lblLotNumber.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            var msg, a;
            msg = ValidateDate(document.getElementById("<%=txtSaleDate.ClientID %>"), 'Sale Date');
            if (msg != "") {
                document.getElementById("<%=txtSaleDate.ClientID %>").focus();

                return msg;
            }
            msg = ValidateDateMulN(document.getElementById("<%=txtSaleDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtSaleDate.ClientID %>").focus();
                a = document.getElementById("<%=lblSaleDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownMul(document.getElementById("<%=ddlProject.ClientID %>"));

            if (msg != "") {
                document.getElementById("<%=ddlProject.ClientID %>").focus();
                a = document.getElementById("<%=lblProject.ClientID %>").innerHTML;
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

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            </br> <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="PROPERTY LOT MASTER">
                    <ContentTemplate>
                        <center>
                            <h1 class="headingTxt">
                                <asp:Label ID="lblHeading" runat="server" Text="PROPERTY LOT MASTER" Font-Bold="True" Font-Italic="True">
                                </asp:Label>
                            </h1>
                        </center>
                        <br />
                        <br />
                        <center>
                            <table class="custtable">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblLotNumber" runat="server" Text="Lot Number*^ :" SkinID="lbl">
                                        </asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;<asp:TextBox ID="txtLotNumber" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" FilterMode="InvalidChars"
                                            FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!" runat="server" TargetControlID="txtLotNumber">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblSaleDate" runat="server" Text="Sales Date* :" SkinID="lbl">
                                        </asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;<asp:TextBox ID="txtSaleDate" runat="server" SkinID="txt" TabIndex="2">
                                        </asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                            TargetControlID="txtSaleDate">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSaleDate"
                                            Format="dd-MMM-yyyy" SkinID="CalendarView">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblProject" runat="server" Text="Project*^ :" SkinID="lbl">
                                        </asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;<asp:DropDownList ID="ddlProject" runat="server" SkinID="ddlrsz" TabIndex="3"
                                            AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="Project_Name" DataValueField="Project_Id"
                                            Width="151">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBranch" runat="server" SelectMethod="DDlData" TypeName="DLPropertyLot">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblLocation" runat="server" Text="Location :" SkinID="lbl">
                                        </asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;<asp:TextBox ID="txtLocation" runat="server" SkinID="txt" TabIndex="4">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblNoOfUnits" runat="server" Text="No.Of Units :" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;<asp:TextBox ID="txtNoOfUnits" runat="server" SkinID="txt" TabIndex="5">
                                        
                                        </asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" ValidChars="1234567890."
                                            runat="server" TargetControlID="txtNoOfUnits">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblAveragePrice" runat="server" Text="Average Price Of Lot :" SkinID="lblRsz">
                                        </asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;<asp:TextBox ID="txtAveragePrice" runat="server" SkinID="txt" TabIndex="6">
                                        </asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" ValidChars="1234567890."
                                            runat="server" TargetControlID="txtAveragePrice">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblLotStatus" runat="server" Text="Lot Status :" SkinID="lbl">
                                        </asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp;&nbsp;<asp:DropDownList ID="ddlLot" runat="server" SkinID="ddlrsz" TabIndex="7"
                                            Width="151">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem>Draft</asp:ListItem>
                                            <asp:ListItem>Approve</asp:ListItem>
                                            <asp:ListItem>Pause</asp:ListItem>
                                            <asp:ListItem>Cancel</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="btntd" align="center">
                                        <br />
                                        <asp:Button ID="btnAdds" runat="server" SkinID="btn" Text="ADD" CommandName="ADD"
                                            TabIndex="7" CausesValidation="True" OnClientClick="return Validate();"></asp:Button>
                                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnviews" runat="server" SkinID="btn" Text="VIEW"
                                            CommandName="VIEW" CausesValidation="True" TabIndex="8"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <br />
                        <center>
                            <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                            <asp:Label ID="lblerrmsg" SkinID="lblRed" runat="server"></asp:Label>
                            <br />
                        </center>
                        <br />
                        <center>
                            <asp:Panel ID="PExp" runat="server" ScrollBars="Auto" Width="750px" Height="300px"
                                Visible="True">
                                <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="true"
                                    Visible="true" AutoGenerateColumns="false" PageSize="10" EnableSortingAndPagingCallbacks="true"
                                    AllowSorting="True">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Edit"
                                                    Text="Edit">
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                                    Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lot_Number" SortExpression="Lot_Number" HeaderStyle-Font-Size="Small"
                                            ItemStyle-Wrap="true" ItemStyle-VerticalAlign="Top" ItemStyle-Width="20">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl1" Visible="false" runat="server" Text='<%#Bind("Lot_IDAuto") %>'></asp:Label>
                                                <asp:Label ID="lbl2" Font-Size="Small" runat="server" Text='<%#Bind("Lot_Number") %>'></asp:Label>
                                            </ItemTemplate>
                                            <%-- <ItemStyle HorizontalAlign="Left" wrap="True"/>--%>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale_Date" SortExpression="Sale_Date" HeaderStyle-Font-Size="Small"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl3" Font-Size="Small" runat="server" Text='<%# Bind("Sale_Date","{0:dd-MMM-yyyy}") %>'
                                                    Width="100"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Project" SortExpression="Project_Name" HeaderStyle-Font-Size="Small"
                                            ItemStyle-HorizontalAlign="Left">
                                            <%--<HeaderStyle-HorizontalAlign="center">--%>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl4" Visible="false" runat="server" Width="150" Text='<%#Bind("Project_ID") %>'></asp:Label>
                                                <asp:Label ID="Label" Font-Size="Small" runat="server" Width="150" Text='<%#Bind("Project_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NumberOf_Unit" HeaderStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right"
                                            ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl5" Font-Size="Small" runat="server" Text='<%#Bind("NumberOf_Unit") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <%--<RowStyle HorizontalAlign="left"/>--%>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lot_Status" HeaderStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl6" Font-Size="Small" runat="server" Text='<%#Bind("Lot_Status") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AvgPrice" HeaderStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl7" Font-Size="Small" runat="server" Text='<%# Bind("Avg_Price","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location" HeaderStyle-Width="100px" SortExpression="Location"
                                            HeaderStyle-Font-Size="Small" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl8" Font-Size="Small" runat="server" Text='<% #Bind("Location") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle />
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            <%--<ItemStyle Wrap="True"></ItemStyle>--%>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </center>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <a name="bottom">
        <div align="right">
            <a href="#top">
                <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
            <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
        </div>
    </a>
    </form>
</body>
</html>
