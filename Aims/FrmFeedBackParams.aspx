<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmFeedBackParams.aspx.vb"
    Inherits="FrmFeedBackParams" Title="FeedBack Parameters" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FeedBack Parameters</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
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

            msg = ValidateDateMul(document.getElementById("<%=TxtStartdate.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=TxtStartdate.ClientID%>").focus();
                a = document.getElementById("<%=lblStartdate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }
            msg = ValidateDateMul(document.getElementById("<%=txtEnddate.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=txtEnddate.ClientID%>").focus();
                a = document.getElementById("<%=lblEnddate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlDepartment.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlDepartment.ClientID %>").focus();
                a = document.getElementById("<%=lblDepartment.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsginfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsginfo.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
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
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnGenrate" runat="server" Text="GENERATE" CssClass="ButtonClass"
                                CommandName="GENERATE" CausesValidation="true" SkinID="btnRsz" TabIndex="4" />
                            <asp:Button ID="btnView" runat="server" CausesValidation="false" Text="VIEW" CssClass="ButtonClass"
                                CommandName="VIEW" SkinID="btn" />
                            <asp:Button ID="btnClear" runat="server" CausesValidation="false" Text="CLEAR" CssClass="ButtonClass"
                                CommandName="CLEAR" SkinID="btn" />
                            <asp:Button ID="BtnUpdate" runat="server" CausesValidation="false" Text="UPDATE"
                                CommandName="UPDATE" CssClass="ButtonClass" SkinID="btn" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                            SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
            </center>
            <div>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="700px" Height="300px"
                        Visible="false">
                        <asp:GridView ID="GVFeedBack" runat="server" SkinID="GridView" DataKeyNames="" AllowPaging="True"
                            Visible="false" AutoGenerateColumns="false" PageSize="100" AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField HeaderText="SL. No.">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="lblFeedbackId" runat="server" Value='<%# Bind("FeedBack_IDAuto") %>' />
                                        <asp:Label ID="lblSlNo" runat="server" Text='<%# Bind("PNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ATTRIBUTES" SortExpression="ParameterName">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtParameterName" TextMode="MultiLine" runat="server" Width="400px"
                                            Text='<%# Bind("ParameterName") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAX">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMax" runat="server" Width="50px" Text='<%# Bind("Max") %>'></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtMax">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MIN">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMin" runat="server" Width="50px" Text='<%# Bind("Min") %>'></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtMin">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WEIGHTAGE">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtweight" runat="server" Width="50px" Text='<%# Bind("Weightage") %>'></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtweight">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
            </div>
            <hr />
            <center>
                <h1 class="headingTxt">
                    FEEDBACK START DATE/END DATE
                </h1>
            </center>
            <%-- <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="700px" Height="300px">--%>
            <div class="mainBlock">
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDepartment" runat="server" Text="Department*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlDepartment" runat="server" TabIndex="1" AutoPostBack="True"
                                    DataSourceID="ObjDepartment" DataTextField="DeptName" DataValueField="DeptID"
                                    SkinID="ddlRsz" AppendDataBoundItems="True" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDepartment" runat="server" SelectMethod="GetDepartmentCombo"
                                    TypeName="FeedBackParamsDL"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStartdate" runat="server" Width="200px" SkinID="lblRsz" Text="Feedback Start date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtStartdate" TabIndex="2" runat="server" SkinID="txtRsz" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEnddate" runat="server" SkinID="lblRsz" Width="200Px" Text="Feedback End date*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEnddate" runat="server" TabIndex="3" SkinID="txtRsz" Width="200px"></asp:TextBox>
                            </td>
                            <ajaxToolkit:CalendarExtender ID="SDate" runat="server" CssClass="cal_Theme1" Format="dd-MMM-yyyy"
                                TargetControlID="TxtStartdate">
                            </ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="EDate" runat="server" CssClass="cal_Theme1" Format="dd-MMM-yyyy"
                                TargetControlID="txtEnddate">
                            </ajaxToolkit:CalendarExtender>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr align="center">
                            <td align="center" colspan="2">
                                <asp:Button ID="btnsave" runat="server" CssClass="ButtonClass" CausesValidation="True"
                                    SkinID="btn" TabIndex="4" OnClientClick="return Validate();" Text="UPDATE" />
                                &nbsp;
                                <asp:Button ID="btndetails" runat="server" TabIndex="5" CausesValidation="False"
                                    CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                            </td>
                        </tr>
                        <center>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                </td>
                            </tr>
                    </table>
                    <br />
                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                    &nbsp;
                    <asp:Label ID="lblmsginfo" runat="server" SkinID="lblGreen"></asp:Label>
                </center>
                <br />
                <center>
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Update"
                                            Text="Publish" Visible="true" OnClientClick="return confirm('Do you want to publish for the selected department?')"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit" Font-Underline="False"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Wrap="false"></ItemStyle>
                                <ItemStyle HorizontalAlign="Left" Font-Underline="False" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <ControlStyle Font-Underline="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeptName" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                    <asp:Label ID="LblDeptId" Visible="false" runat="server" Text='<%# Bind("DeptID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="false" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Feedback start date">
                                <ItemTemplate>
                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("DeptID") %>' />
                                    <asp:Label ID="LblFeedbackStartDate" runat="server" Text='<%# Bind("FeedBackStartdate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Feedback end date">
                                <ItemTemplate>
                                    <asp:Label ID="lblFeedBackEndDate" runat="server" Text='<%# Bind("FeedBackEnddate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Top" Wrap="False" />
                                <HeaderStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                </center>
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
