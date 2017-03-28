<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmJobOpening.aspx.vb"
    Inherits="FrmJobOpening" Title="Job Opening" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Job Opening</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">


        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=DdlCName.ClientID %>"), 'Company Name');
            if (msg != "") {
                document.getElementById("<%=DdlCName.ClientID %>").focus();
                return msg;
            }

            msg = NameField100(document.getElementById("<%=txtjobTitle.ClientID %>"), 'Job Title');
            if (msg != "") {
                document.getElementById("<%=txtjobTitle.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtCloseApplication.ClientID %>"), 'Close Application Date');
            if (msg != "") {
                document.getElementById("<%=txtCloseApplication.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=Lblerr.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=Lblerr.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <center>
                    <%--      <h1 class="headingTxt">
                        JOB OPENING
                    </h1>--%>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblCompanyName" runat="server" Text="Company Name*&nbsp:&nbsp&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DdlCName" runat="server" AppendDataBoundItems="True" DataSourceID="ObjKDMComapnayName"
                                    DataTextField="CompanyName" DataValueField="RCIDAuto" SkinID="ddlRsz" Width="200px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjKDMComapnayName" runat="server" SelectMethod="GetCompanyName"
                                    TypeName="DLJobOpening"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbljobTitle" runat="server" Text="Job Title*&nbsp:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtjobTitle" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;<asp:Label ID="lblspecilization" runat="server" Text="Specialization&nbsp:&nbsp&nbsp"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtspecilization" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblskill" runat="server" Text="Skill&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtskill" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblJobOpening" runat="server" Text="Status Of Job Opening&nbsp:&nbsp&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlJobOpening" runat="server" AppendDataBoundItems="True" SkinID="ddl">
                                    <asp:ListItem Value="Open">Open</asp:ListItem>
                                    <asp:ListItem Value="Close">Close</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCloseApplication" runat="server" Text="Close Application*&nbsp:&nbsp&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td style="width: 83px" align="left">
                                <asp:TextBox ID="txtCloseApplication" runat="server" SkinID="txt"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtCloseApplication"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEligiblityCriteria" runat="server" Text="Eligibility Criteria&nbsp:&nbsp&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEligiblityCriteria" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSelectionProcess" runat="server" Text="Selection Process&nbsp:&nbsp&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtSelectionProcess" runat="server" SkinID="txt" TextMode="MultiLine"></asp:TextBox>
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
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="Insertbtn" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                    SkinID="btn" Text="ADD" ValidationGroup="ADD" />
                                &nbsp;<asp:Button ID="Viewbtn" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" Text="VIEW" />
                            </td>
                        </tr>
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
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="Lblerr" runat="server" SkinID="lblRed"></asp:Label>
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
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="780px" Height="300px">
                        <asp:GridView ID="GvJobOpening" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                            Visible="False" AllowPaging="True" PageSize="100">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Edit" runat="server" CausesValidation="False" CommandName="Edit"
                                            Font-Underline="False" Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="DELETE" runat="server" CausesValidation="False" CommandName="Delete"
                                            Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Company Name" SortExpression="Company Name">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="KDMID" runat="server" Value='<%# Bind("JOID") %>' Visible="false" />
                                        <asp:HiddenField ID="HKDM1" runat="server" Value='<%# Bind("JOIDAuto") %>' Visible="false" />
                                        <asp:HiddenField ID="HD1" runat="server" Value='<%# Bind("RCIDAuto") %>' Visible="false" />
                                        <asp:Label ID="lblCName" runat="server" Text='<%# Bind("CompanyName") %>' Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Job Title" SortExpression="Job Title">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljobtitle" runat="server" Text='<%# Bind("JobTitle") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Specialization" SortExpression="Specilization">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSpecilization" runat="server" Text='<%# Bind("Specialization") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Skill" SortExpression="Skill">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSkill" runat="server" Text='<%# Bind("Skill") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CloseApplication" SortExpression="CloseApplication">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCloseApplication" runat="server" Text='<%# Bind("CloseApplication","{0:dd-MMM-yyyy}") %>'
                                            Visible="true"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status Of Job Opening" SortExpression="Status Of Job Opening">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("StatusofJobOpening") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eligibility Criteria" SortExpression="Eligibility Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEligibility" runat="server" Text='<%# Bind("EligibilityCriteria") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Selection Process" SortExpression="Selection Process">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSelectionProcess" runat="server" Text='<%# Bind("SelectionProcess") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="Link" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

