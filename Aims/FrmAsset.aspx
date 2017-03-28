<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmAsset.aspx.vb"
    Inherits="FrmAsset" Title="Asset Allocation" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Allocation</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

 <script src="js/Tvalidate.js" type="text/javascript">   </script>
    <script language="JavaScript" type="text/javascript">

        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtIssued.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtIssued.ClientID%>"));
        }
        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtCode.ClientID%>"));

        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtCode.ClientID%>"));
        }
        function Valid() {
            var msg;
            msg = CodeField(document.getElementById("<%=txtCode.ClientID %>"), 'Asset Code');
            if (msg != "") {
                document.getElementById("<%=txtCode.ClientID %>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtAssetName.ClientID %>"), 'Asset Name');
            if (msg != "") {
                document.getElementById("<%=txtAssetName.ClientID %>").focus();
                return msg;
            }
            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtIssued.ClientID %>"), 'Issued To');
            if (msg != "") {
                document.getElementById("<%=txtIssued.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtIssueDate.ClientID %>"), 'Issued Date');
            if (msg != "") {
                document.getElementById("<%=txtIssueDate.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }
        //        function SplitName() {
        //            var text = document.getElementById("<%=txtIssued.ClientID%>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=HidECode.ClientID%>").innerText = split[0];
        //                document.getElementById("<%=txtIssued.ClientID%>").innerText = split[1];
        //            }
        //        }
        //        function SplitName1() {
        //            var text = document.getElementById("<%=txtCode.ClientID%>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=txtCode.ClientID%>").innerText = split[0];
        //                document.getElementById("<%=txtAssetName.ClientID%>").innerText = split[1];
        //            }
        //        } 
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <%-- <center>
                    <h1 class="headingTxt">
                        ASSET ALLOCATION</h1>
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
                    <tr>
                        <td colspan="4" align="center">
                            <asp:RadioButtonList ID="RBReport" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                TabIndex="1">
                                <asp:ListItem Value="0" Selected="True">Employee</asp:ListItem>
                                <asp:ListItem Value="1">Department</asp:ListItem>
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
                            <asp:Label ID="Label6" runat="server" Text="Asset Code* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            <asp:HiddenField ID="HidECode" runat="server" />
                        </td>
                        <td colspan="1" align="left">
                            <asp:TextBox ID="txtCode" TabIndex="1" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtCode">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" TargetControlID="txtCode"
                                EnableCaching="true" MinimumPrefixLength="3" ServiceMethod="getAssetName" ServicePath="TextBoxExt.asmx"
                                FirstRowSelected="true" CompletionInterval="2000" OnClientPopulated="HideImage2"
                                CompletionListCssClass="completeListStyle" OnClientPopulating="ShowImage2">
                            </ajaxToolkit:AutoCompleteExtender>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                WatermarkText="Type first 3 characters" TargetControlID="txtCode" SkinID="watermark">
                            </ajaxToolkit:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Asset Name*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAssetName" TabIndex="2" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtAssetName">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblIssue" runat="server" Text="Issued To*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtIssued" TabIndex="3" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtIssued">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" TargetControlID="txtIssued"
                                EnableCaching="true" MinimumPrefixLength="3" ServiceMethod="getIssued" ServicePath="TextBoxExt.asmx"
                                FirstRowSelected="true" CompletionInterval="2000" OnClientPopulated="HideImage1"
                                CompletionListCssClass="completeListStyle" OnClientPopulating="ShowImage1">
                            </ajaxToolkit:AutoCompleteExtender>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                WatermarkText="Type first 3 characters" TargetControlID="txtIssued" SkinID="watermark">
                            </ajaxToolkit:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDept" runat="server" SkinID="lbl" Text="Department* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" AutoPostBack="true"
                                DataTextField="DeptName" DataValueField="DeptID" SkinID="ddlRsz" TabIndex="3"
                                AppendDataBoundItems="False" Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjDept" runat="server" SelectMethod="GetDept" TypeName="BLDeptDashboard">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblIssuedate" runat="server" Text="Issued Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtIssueDate" TabIndex="4" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtIssueDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblReturnDate" runat="server" Text="Return Date :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtReturndate" TabIndex="5" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtReturndate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRemarks" TabIndex="6" runat="server" TextMode="MultiLine" MaxLength="250"
                                SkinID="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr align="center">
                        <td align="center" colspan="2">
                            <asp:Button ID="btnsave" runat="server" CommandName="Insert" CssClass="ButtonClass"
                                OnClientClick="return Validate();" SkinID="btn" TabIndex="7" Text="ADD" />
                            &nbsp;
                            <asp:Button ID="btndetails" runat="server" TabIndex="8" CausesValidation="False"
                                CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                            SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                &nbsp;
                                <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="Asset_Id" SkinID="GridView" Visible="True" Width="568px" PageSize="100"
                        AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                        TabIndex="9" Text="Edit" />
                                    <asp:LinkButton ID="Button3" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick="return confirm('Do you want to delete this record?')" TabIndex="10"
                                        Text="Delete" />
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asset Code" SortExpression="AssetCode">
                                <ItemTemplate>
                                    <asp:Label ID="RRID" Visible="false" runat="server" Text='<%# Bind("Asset_ID") %>' />
                                    <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("Asset_IDAuto") %>' />
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("AssetCode") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asset Name" SortExpression="AssetName">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issued To">
                                <ItemTemplate>
                                    <asp:Label ID="lblCommodityName" runat="server" Text='<%# Bind("Emp_Name") %>' Visible="true"></asp:Label>
                                    <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("IssuedTo") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issue Date" ControlStyle-Width="105px" ItemStyle-HorizontalAlign="Center"
                                SortExpression="IssueDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblIssuedate" runat="server" Width="75px" Text='<%# Bind("IssueDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Return Date" ControlStyle-Width="105px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblReturndate" runat="server" Width="75px" Text='<%# Bind("ReturnDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblCommName" runat="server" Text='<%# Bind("Emp_Name") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblECode" runat="server" Text='<%# Bind("IssuedTo") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks" ControlStyle-Width="198px" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" Width="198px" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <%-- <SelectedRowStyle HorizontalAlign="left" />--%>
                    </asp:GridView>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="Asset_Id" SkinID="GridView" Visible="True" Width="568px" PageSize="100"
                        AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                        TabIndex="9" Text="Edit" />
                                    <asp:LinkButton ID="Button3" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick="return confirm('Do you want to delete this record?')" TabIndex="10"
                                        Text="Delete" />
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asset Code" SortExpression="AssetCode">
                                <ItemTemplate>
                                    <asp:Label ID="RRID" Visible="false" runat="server" Text='<%# Bind("Asset_ID") %>' />
                                    <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("Asset_IDAuto") %>' />
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("AssetCode") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asset Name" SortExpression="AssetName">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issue Date" ControlStyle-Width="105px" ItemStyle-HorizontalAlign="Center"
                                SortExpression="IssueDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblIssuedate" runat="server" Width="75px" Text='<%# Bind("IssueDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Return Date" ControlStyle-Width="105px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblReturndate" runat="server" Width="75px" Text='<%# Bind("ReturnDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeptId" runat="server" Text='<%# Bind("Dept") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblDept" runat="server" Text='<%# Bind("DeptName") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks" ControlStyle-Width="198px" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" Width="198px" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <%-- <SelectedRowStyle HorizontalAlign="left" />--%>
                    </asp:GridView>
                </asp:Panel>
                </centr>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="L1" runat="server"></asp:LinkButton>
                </div>
            </a>
            <style type="text/css">
                .completeListStyle
                {
                    height: 100px;
                    width: 50px;
                    overflow: auto;
                    list-style-type: disc;
                    padding-left: 17px;
                    background-color: #FFF;
                    border: 1px solid DarkGray;
                    text-align: left;
                    font-size: small;
                    color: black;
                }
            </style>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>