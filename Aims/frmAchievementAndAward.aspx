<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAchievementAndAward.aspx.vb"
    Inherits="frmAchievementAndAward" Title="Achievement & Award" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Achievement & Award</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%= ddlDept.ClientID %>"), 'Department');
            if (msg != "") {
                document.getElementById("<%= ddlDept.ClientID %>").focus();
                return msg;
            }

            msg = Field250(document.getElementById("<%= txtAchievement.ClientID %>"), 'Achievement');
            if (msg != "") {
                document.getElementById("<%= txtAchievement.ClientID %>").focus();
                return msg;
            }

            msg = ValidateDateN(document.getElementById("<%= txtDate.ClientID %>"), 'Date');
            if (msg != "") {
                document.getElementById("<%= txtDate.ClientID %>").focus();
                return msg;
            }

            msg = Field250N(document.getElementById("<%= txtRemarks.ClientID %>"), 'Remarks');
            if (msg != "") {
                document.getElementById("<%= txtRemarks.ClientID %>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {

            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:RadioButtonList ID="RbTYPE" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                    SkinID="Themes1" Height="20px" Width="200px" TabIndex="1">
                                    <asp:ListItem Selected="True" Value="1" Text="Employee "></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Student"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="250px" TabIndex="2">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLAchievementAndAward"
                                    SelectMethod="GetDeptType"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAchievement" runat="server" Text="Achievement*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAchievement" TabIndex="3" MaxLength="250" runat="server" TextMode="MultiLine"
                                    SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDate" runat="server" Text="Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate" runat="server" TabIndex="4" SkinID="txt" MaxLength="11"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion" runat="server" TargetControlID="txtDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterMode="InvalidChars" FilterType="Custom" InvalidChars="!@#$%^&*()_+=|\}]{[:;'<,>?"
                                    TargetControlID="txtDate" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRemarks" runat="server" TabIndex="5" MaxLength="250" TextMode="MultiLine"
                                    SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="6"
                                    Text="ADD" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="7" Text="VIEW" />
                            </td>
                    </table>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
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
                <center>
                    <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:GridView ID="GridAchievementAward" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" TabIndex="8"
                                                        CommandName="Edit" Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" TabIndex="9"
                                                        CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department" Visible="true" SortExpression="DeptName">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="lblID" runat="server" Value='<%# Bind("Achievement_Id_Auto") %>'>
                                                    </asp:HiddenField>
                                                    <asp:Label ID="lblGVDepartmentName" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                                    <asp:Label ID="lblGVDepartmentID" runat="server" Visible="false" Text='<%# Bind("Department") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee/Student" SortExpression="EmpStudName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVStdEmpStatus" runat="server" Text='<%# Bind("EmpStudName") %>'></asp:Label>
                                                    <asp:Label ID="lblGVStdEmpStatusId" runat="server" Visible="false" Text='<%# Bind("EmpStudStatus")  %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Achievement">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVAchievementDetails" Width="200px" runat="server" Text='<%# Bind("Achievement_Details") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" SortExpression="Achievement_Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVAchievementDate" runat="server" Text='<%# Bind("Achievement_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="Center" />
                                                <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVRemarks" Width="200px" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <center>
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
