<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmLIC.aspx.vb"
    Inherits="FrmLIC" Title="Local Inspection Committee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Local Inspection Committee</title>
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

            msg = NameField250E(document.getElementById("<%=txtLab.ClientID%>"), 'Laboratory Name');

            if (msg != "") {
                document.getElementById("<%=txtLab.ClientID%>").focus();
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
                                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLLIC" SelectMethod="GetDeptType">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblLab" runat="server" Text="Laboratory Name*&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLab" runat="server" SkinID="txt" TextMode="MultiLine" TabIndex="2"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCarpet" runat="server" SkinID="lblRsz" Text="Carpet Area(Sq.Mts) :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCarpet" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="01.23456789" TargetControlID="txtCarpet" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblEquip" runat="server" SkinID="lblRsz" Text="Equipments Available&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtequip" runat="server" SkinID="txt" TextMode="MultiLine" AutoPostBack="true"
                                    TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblRemark" runat="server" SkinID="lbl" Text="Remarks&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="txt" TextMode="MultiLine" AutoPostBack="true"
                                    TabIndex="5"></asp:TextBox>
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
                                    TabIndex="6" CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>&nbsp;
                                <asp:Button ID="btndetails" runat="server" SkinID="btn" CausesValidation="False"
                                    CommandName="Cancel" Text="VIEW" TabIndex="7" CssClass="ButtonClass"></asp:Button>
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
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GVLIC" runat="server" SkinID="gridview" AllowPaging="True" AutoGenerateColumns="False"
                                        Style="margin-right: 0px" PageSize="100" EnableSortingAndPagingCallbacks="True"
                                        AllowSorting="True">
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
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ControlStyle Font-Underline="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department" SortExpression="DeptName">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Inspection_Id_Auto") %>' />
                                                    <asp:Label ID="lbl1" runat="server" Width="150px" Text='<%# Bind("DeptName") %>'></asp:Label>
                                                    <asp:Label ID="LblDeptid" Visible="false" runat="server" Text='<%# Bind("Department_Id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Laboratory Name" SortExpression="LabName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl2" runat="server" Width="150px" Text='<%# Bind("LabName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Carpet Area(Sq. Mts)" SortExpression="CarpetArea">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl3" align="left" runat="server" Text='<%# Bind("CarpetArea") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Equipments Available" SortExpression="Equip_Available">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl4" align="left" runat="server" Width="150px" Text='<%# Bind("Equip_Available") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks" SortExpression="Remark">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl5" align="left" runat="server" Width="150px" Text='<%# Bind("Remarks") %>'></asp:Label>
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

