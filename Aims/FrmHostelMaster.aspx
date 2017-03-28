<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmHostelMaster.aspx.vb"
    Inherits="FrmHostelMaster" Title="Hostel Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Hostel Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="javascript" type="text/javascript">
        function Valid() {
            var msg;

            msg = Field50(document.getElementById("<%=txtHostelName.ClientID %>"), 'Hostel Name');
            if (msg != "") {
                document.getElementById("<%=txtHostelName.ClientID%>").focus();
                return msg;
            }
            msg = Field50(document.getElementById("<%=txtHostelCode.ClientID %>"), 'Hostel Code');
            if (msg != "") {
                document.getElementById("<%=txtHostelCode.ClientID%>").focus();
                return msg;
            }
            msg = Field50(document.getElementById("<%=txtHostelType.ClientID %>"), 'Hostel Type');
            if (msg != "") {
                document.getElementById("<%=txtHostelType.ClientID%>").focus();
                return msg;
            }
            msg = Field50N(document.getElementById("<%=txtWarden.ClientID %>"), 'Warden');
            if (msg != "") {
                document.getElementById("<%=txtWarden.ClientID%>").focus();
                return msg;
            }
            msg = Field50N(document.getElementById("<%=txtHouseKeeping.ClientID %>"), 'House Keeping');
            if (msg != "") {
                document.getElementById("<%=txtHouseKeeping.ClientID%>").focus();
                return msg;
            }
            msg = Field250N(document.getElementById("<%=txtRemarks.ClientID %>"), 'Remarks');
            if (msg != "") {
                document.getElementById("<%=txtRemarks.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
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
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        HOSTEL MASTER
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblHostelName" runat="server" Text="Hostel Name*&nbsp:&nbsp&nbsp"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHostelName" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblHostelCode" runat="server" Text="Hostel Code*&nbsp:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHostelCode" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;<asp:Label ID="lblHostelType" runat="server" Text="Hostel Type*&nbsp:&nbsp&nbsp"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHostelType" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<asp:TextBox ID="txtRID" runat="server" Text='<%# Bind("Dept_ID") %>' __designer:wfdid="w15"
                         <                           Visible="False"></asp:TextBox>--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblWarden" runat="server" Text="Warden&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWarden" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblHouseKeeping" runat="server" Text="House Keeping&nbsp:&nbsp&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td style="width: 83px">
                                <asp:TextBox ID="txtHouseKeeping" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                  
            
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="InsertHostelMaster" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                    SkinID="btn" Text="ADD" ValidationGroup="ADD" TabIndex="7" />
                                &nbsp;<asp:Button ID="ViewHostelMaster" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="8" Text="VIEW" />
                                    </td>
                                    </tr>
                                   
                           
                            <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        
                        </table>
                           <table>
                        <center>
                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                        </center>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                
                        <tr>
                            <td>
                                <asp:GridView ID="GvHostelMaster" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                    Visible="False" AllowPaging="True" PageSize="100">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                    Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hostel Name" SortExpression="Name">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("HMID") %>' Visible="false" />
                                                <asp:Label ID="lblHostelName" runat="server" Text='<%# Bind("HostelName") %>' Visible="true"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hostel Code" SortExpression="Hostel Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHostelCode" runat="server" Text='<%# Bind("HostelCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hostel Type" SortExpression="Hostel Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHostelType" runat="server" Text='<%# Bind("HostelType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hostel Warden" SortExpression="Hostel Warden">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWarden" runat="server" Text='<%# Bind("HostelWarden") %>' Visible="true"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="House Keeping" SortExpression="House Keeping">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHouseKeeping" runat="server" Text='<%# Bind("HouseKeeping") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
