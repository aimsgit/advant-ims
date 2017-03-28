<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="RptResourceAllocation.aspx.vb"
    Inherits="RptResourceAllocation" Title="Resource Allocation" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Resource Allocation</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlResType.ClientID%>"), 'Resource Type');
            if (msg != "") {
                document.getElementById("<%=ddlResType.ClientID%>").focus();
                return msg;

            }

            msg = DropDownForZero(document.getElementById("<%=ddlResName.ClientID%>"), 'Resource Name');
            if (msg != "") {
                document.getElementById("<%=ddlResName.ClientID%>").focus();
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
                    document.getElementById("<%=lblmsgifo.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            RESOURCE ALLOCATION
                        </h1>
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblResType" runat="server" Text="Resource Type*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlResType" runat="server" DataSourceID="ObjResType" DataTextField="ResourceType"
                                        DataValueField="Rid" SkinID="ddl" TabIndex="2" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjResType" runat="server" SelectMethod="GetResourceType1"
                                        TypeName="DLExamResources"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblResname" runat="server" Text="Resource Name*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlResName" runat="server" DataSourceID="ObjResName" DataTextField="ResourceName"
                                        DataValueField="AutoID" SkinID="ddl" TabIndex="3" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjResName" runat="server" SelectMethod="GetResourcename1"
                                        TypeName="DLExamResources">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlResType" Name="Rid" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <asp:Button ID="btnview" TabIndex="9" runat="server" Text="VIEW" SkinID="btn" CssClass="ButtonClass"
                                        OnClientClick="return Validate();"></asp:Button>
                                    <div>
                                        <center>
                                            <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                                <ProgressTemplate>
                                                    <div class="PleaseWait">
                                                        Processing your request..Please wait...
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </center>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <center>
                            <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                            <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                        </center>
                        <asp:Panel ID="Panel2" runat="server" Height="250px" Width="770px" ScrollBars="Auto">
                            <asp:GridView ID="GVResourceAllc" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                SkinID="GridView" TabIndex="6" PageSize="10">
                                <Columns>
                                    <asp:TemplateField HeaderText="Day">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDay" runat="server" Text='<%# Bind("Day1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="07:00am-07:30am">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl1" runat="server" Text='<%# Bind("[2]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="07:30am-08:00am">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl2" runat="server" Text='<%# Bind("[3]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="08:00am-08:30am">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl3" runat="server" Text='<%# Bind("[4]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="08:30am-09:00am">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl4" runat="server" Text='<%# Bind("[5]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="9:00am-9:30am">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl5" runat="server" Text='<%# Bind("6") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="9:30am-10:00am">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl6" runat="server" Text='<%# Bind("[7]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="10:00am-10:30am">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl7" runat="server" Text='<%# Bind("8") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="10:30am-11:00am">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl8" runat="server" Text='<%# Bind("[9]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="11:00am-11:30am">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl9" runat="server" Text='<%# Bind("10") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="11:30am-12:00pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl10" runat="server" Text='<%# Bind("[11]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="12:00pm-12:30pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl11" runat="server" Text='<%# Bind("12") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="12:30pm-01:00pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl12" runat="server" Text='<%# Bind("[13]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="01:00pm-01:30pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl13" runat="server" Text='<%# Bind("14") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="01:30pm-02:00pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl14" runat="server" Text='<%# Bind("[15]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="02:00pm-02:30pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl15" runat="server" Text='<%# Bind("16") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="02:30pm-03:00pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl16" runat="server" Text='<%# Bind("[17]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="03:00pm-03:30pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl17" runat="server" Text='<%# Bind("18") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="03:30pm-04:00pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl18" runat="server" Text='<%# Bind("[19]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="04:00pm-04:30pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl19" runat="server" Text='<%# Bind("20") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="04:30pm-05:00pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl20" runat="server" Text='<%# Bind("[21]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="05:00pm-5:30pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl21" runat="server" Text='<%# Bind("[22]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="05:30pm-06:00pm">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl22" runat="server" Text='<%# Bind("[23]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="06:00pm-06:30pm" ControlStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl23" runat="server" Text='<%# Bind("[24]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="06:30pm-07:00pm" ControlStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl24" runat="server" Text='<%# Bind("[25]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="07:00pm-07:30pm" ControlStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl25" runat="server" Text='<%# Bind("[26]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="07:30pm-08:00pm" ControlStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl26" runat="server" Text='<%# Bind("[27]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
