<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PerformanceCycle.aspx.vb"
    Inherits="PerformanceCycle" Title="Appraisal Cycle Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Appraisal Cycle Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=txtPerfCycle.ClientID %>"), 'Appraisal Cycle');
            if (msg != "") {
                document.getElementById("<%=txtPerfCycle.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID %>"), 'Start Date');
            if (msg != "") {
                document.getElementById("<%=txtStartDate.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtEndDate.ClientID %>"), 'End Date');
            if (msg != "") {
                document.getElementById("<%=txtEndDate.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").innerText = "";

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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        <br />
                        <br />
                        
                    </h1>
                </center>
               
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPerfCycle" runat="server" Text="Appraisal Cycle*&nbsp;:&nbsp;"
                                    SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td align="Left">
                                <asp:TextBox ID="txtPerfCycle" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Width="100px" Text="Start Date*&nbsp;:&nbsp;"
                                    SkinID="lblRsz" MaxLength="11"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Width="100px" Text="End Date*&nbsp;:&nbsp;"
                                    SkinID="lblRsz" MaxLength="11"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Current Appraisal*&nbsp;:&nbsp;"
                                    Width="200px" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlcurrAppraisal" SkinID="ddl" TabIndex="4" runat="server"
                                    DataValueField="id" AutoPostBack="True">
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnAdd" TabIndex="5" runat="server" Text="ADD"  SkinID="btn"
                                    CommandName="ADD" CssClass="ButtonClass" OnClientClick="return Validate();">
                                </asp:Button>
                               &nbsp; <asp:Button ID="btnView" TabIndex="6" runat="server" Text="VIEW" SkinID="btn"
                                    CommandName="VIEW" CssClass="ButtonClass"></asp:Button>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <div>
                                        <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <center>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                            <asp:GridView ID="GrdPerfCycle" runat="server" SkinID="GridView" AllowPaging="true"
                                                AutoGenerateColumns="False" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <Columns>
                                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                                Text="Edit" />
                                                            <asp:LinkButton ID="LinkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                                Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Appraisal Cycle" Visible="true" SortExpression="AppraisalCycle">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Bind("ACID") %>'></asp:Label>
                                                            <asp:Label ID="lblPerfCycle" runat="server" Text='<%# Bind("AppraisalCycle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Start Date" Visible="true" SortExpression="StartDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("StartDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="End Date" Visible="true" SortExpression="EndDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("EndDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Current Appraisal" Visible="true" SortExpression="CurrentAppraisal">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCurrentApp" runat="server" Text='<%# Bind("CurrentAppraisal") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </center>
                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtStartDate"
                    CssClass="cal_Theme1" Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
                    CssClass="cal_Theme1" Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
            </div>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

