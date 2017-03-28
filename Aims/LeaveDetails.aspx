<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LeaveDetails.aspx.vb" Inherits="LeaveDetails"
    Title="Leave Register" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Leave Register</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = AutoCompleteExtender(document.getElementById("<%=txtEmp.ClientID %>"), 'Employee Name');
            if (msg != "") {
                document.getElementById("<%=txtEmp.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlleav.ClientID %>"), 'Leave Type');
            if (msg != "") {
                document.getElementById("<%=ddlleav.ClientID %>").focus();
                return msg;
            }
            msg = Field1(document.getElementById("<%=textblanceleav.ClientID %>"), 'No of Days');
            if (msg != "") {
                document.getElementById("<%=textblanceleav.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtEmp.ClientID%>"));

        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtEmp.ClientID%>"));
        }
        //        function SplitName() {
        //            var text = document.getElementById("<%=txtEmp.ClientID%>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=HidempId.ClientID%>").innerText = split[0];
        //                document.getElementById("<%=txtEmp.ClientID%>").innerText = split[1] + ":" + split[2];
        //            }
        //        }
        function AlertMsg() {

            alert("Do you want to credit all employees...?");
        }
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
                <div>
                    <%--  <center>
                    <h1 class="headingTxt">
                        LEAVE REGISTER
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
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:HiddenField ID="HidempId" runat="server" />
                                    <asp:Label ID="Label1" runat="server" Width="200px" Text="Employee Code*^&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmp" runat="server" AutoPostBack="true" SkinID="txtRsz" Width ="200px" TabIndex="1"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" TargetControlID="txtEmp"
                                        ServicePath="TextBoxExt.asmx" ServiceMethod="getEmpExt" OnClientPopulating="ShowImage"
                                        OnClientPopulated="HideImage" MinimumPrefixLength="3" CompletionInterval="2000"
                                        CompletionListCssClass="completeListStyle" FirstRowSelected="true" EnableCaching="true">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" WatermarkText="Type first few characters"
                                        runat="server" TargetControlID="txtEmp" SkinID="watermark">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDept" runat="server" Text="Department^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept1" DataTextField="DeptName"
                                        DataValueField="DeptID" SkinID="ddlRsz" Width="200px" TabIndex="9">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjDept1" runat="server" TypeName="BLIndividualFormMaster"
                                        SelectMethod="GetddlDept"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Width="84px" Text="Leave Type*^&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlleav" TabIndex="2" runat="server" SkinID="ddlrsz" width="200px" AutoPostBack="True"
                                        DataSourceID="odsleave" DataTextField="Leave_Type" DataValueField="TypeID" AppendDataBoundItems="true">
                                        <%--<asp:ListItem Value="0" Text="Select"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsleave" runat="server" TypeName="LeaveDB" SelectMethod="GetLeaveType">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Width="103px" Text="No of Days*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="textblanceleav" TabIndex="3" runat="server" SkinID="txtRsz" Width ="200px"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="textblanceleav">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" SkinID="lblRSZ" Text="Year :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                        DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="200px" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="Remarks&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtremark" TabIndex="4" runat="server" SkinID="txtRsz" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <asp:Button ID="BtnSave" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btn" TabIndex="5" Text="CREDIT" />
                                        <asp:Button ID="BtnSaveAll" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return AlertMsg();" SkinID="btnRsz" TabIndex="6" Text="CREDIT ALL" />
                                        <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="7"
                                            Text="VIEW" />
                                        <asp:Button ID="BtnSearch" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="8"
                                            Text="SEARCH" />
                                    </td>
                                </tr>
                        </table>
                    </center>
            </a><a name="bottom">
                <br />
                <center>
                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                </center>
                <br />
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AutoGenerateColumns="False"
                            AllowPaging="true" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            TabIndex="8" Text="Edit"></asp:LinkButton>
                                        <%--<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>--%>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            TabIndex="9" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" Font-Underline="False"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="lid" runat="server" Value='<%# Bind("LM_ID") %>' />
                                        <asp:HiddenField ID="HidEmpId" runat="server" Value='<%# Bind("Emp_ID") %>' />
                                        <asp:Label ID="Label01" runat="server" Text='<%# Bind("Emp_Code") %>' />:
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Emp_Name") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave Type" SortExpression="Leave_Type">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HidLvTpe" runat="server" Value='<%# Bind("LeaveType") %>' />
                                        <asp:Label ID="Label201" runat="server" Text='<%# Bind("Leave_Type") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No of Days" SortExpression="NoOfLeave" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label301" runat="server" Text='<%# Bind("NoOfLeave") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Balance Leave in Days" SortExpression="BalanceLeave"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label302" runat="server" Text='<%# Bind("BalanceLeave") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label402" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("LookUpAutoID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="Label401" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                </div>
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
