<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmFacultyDevelopment.aspx.vb"
    Inherits="FrmFacultyDevelopment" Title="Faculty Development and Skill Development" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Faculty Development and Skill Development</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlDept.ClientID%>"), 'Department');

            if (msg != "") {
                document.getElementById("<%=ddlDept.ClientID%>").focus();
                return msg;
            }

            msg = NameField250E(document.getElementById("<%=txtProgram.ClientID%>"), 'Name of the Program');

            if (msg != "") {
                document.getElementById("<%=txtProgram.ClientID%>").focus();
                return msg;
            }

            msg = NameField250E(document.getElementById("<%=txtConduct.ClientID%>"), 'Conducted By');

            if (msg != "") {
                document.getElementById("<%=txtConduct.ClientID%>").focus();
                return msg;
            }

            msg = ValidateDate(document.getElementById("<%=Txtfdate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=Txtfdate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=Txttodate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=Txttodate.ClientID%>").focus();
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
                return true;
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
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="250px" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLFacutlyDevelopment"
                                    SelectMethod="GetDeptType"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblProgram" runat="server" Text="Name of the Program*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtProgram" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblConducted" runat="server" SkinID="lblRsz" Text="Conducted By* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtConduct" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Custom" InvalidChars="0123456789" TargetControlID="txtConduct" />
                            </td>
                        </tr>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblfdate" runat="server" Text="From Date*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtfdate" runat="server" SkinID="txt" MaxLength="11" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txtfdate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lbltdate" runat="server" Text="To Date*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txttodate" runat="server" SkinID="txt" MaxLength="11" TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txttodate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblRemark" runat="server" SkinID="lbl" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="txt" TextMode="MultiLine" AutoPostBack="true"
                                    TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                </center>
                </table>
                <center>
                    <table>
                        <tr>
                            <td colspan="2" class="btnTd" align="center">
                                <br />
                                <br />
                                <asp:Button ID="btnadd" runat="server" SkinID="btn" CausesValidation="True" Text="ADD"
                                    TabIndex="7" CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>&nbsp;
                                <asp:Button ID="btndetails" runat="server" SkinID="btn" CausesValidation="False"
                                    CommandName="Cancel" Text="VIEW" TabIndex="8" CssClass="ButtonClass"></asp:Button>
                            </td>
                        </tr>
                    </table>
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
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
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
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GVfaculty" runat="server" SkinID="gridview" AllowPaging="True"
                                        AutoGenerateColumns="False" Style="margin-right: 0px" PageSize="100" AllowSorting="True"
                                        EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" Font-Underline="False"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" Visible="True" Font-Underline="False">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false"></ItemStyle>
                                                <ItemStyle HorizontalAlign="Left" Font-Underline="False" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ControlStyle Font-Underline="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department" SortExpression="DeptName">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Faculty_Dev_Auto_Id") %>' />
                                                    <asp:Label ID="lbl1" runat="server" Width="150px" Text='<%# Bind("DeptName") %>'></asp:Label>
                                                    <asp:Label ID="LblDeptid" Visible="false" runat="server" Text='<%# Bind("Dept_Id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name of the Program">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl2" runat="server" Width="150px" Text='<%# Bind("Programe_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Conducted By" SortExpression="Conducted_By">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl3" align="left" runat="server" Width="100px" Text='<%# Bind("Conducted_By") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="From Date" SortExpression="From_Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl4" align="center" runat="server" Text='<%# Bind("From_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" Wrap="False" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="To Date" SortExpression="To_Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl5" align="center" runat="server" Text='<%# Bind("To_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl6" align="left" runat="server" Width="150px" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" HorizontalAlign="left" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                </center>
                </table>
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
