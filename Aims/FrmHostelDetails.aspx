<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmHostelDetails.aspx.vb"
    Inherits="FrmHostelDetails" Title="Hostel Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Hostel Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="javascript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlHostelCode.ClientID %>"), 'Hostel Code');
            if (msg != "") {
                document.getElementById("<%=ddlHostelCode.ClientID%>").focus();
                return msg;
            }
            msg = Field1(document.getElementById("<%=txtRoomNo1.ClientID %>"), 'Room No');
            if (msg != "") {
                document.getElementById("<%=txtRoomNo1.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlRoomType1.ClientID %>"), 'Room Type');
            if (msg != "") {
                document.getElementById("<%=ddlRoomType1.ClientID%>").focus();
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
                        HOSTEL ROOM DETAILS
                    </h1>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblHostelCode" runat="server" Text="Hostel Code*&nbsp:&nbsp; " SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHostelCode" runat="server" AutoPostBack="True" DataSourceID="objhostelcode"
                                    DataTextField="HostelCode" DataValueField="HMID" SkinID="ddl" TabIndex="1" Width="129px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblHname" runat="server" Text="Hostel Name*&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtHostelName1" runat="server" SkinID="txt" TabIndex="2" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRoomNo" runat="server" Text="Room No*&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRoomNo1" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;<asp:Label ID="lblRoomType" runat="server" Text="Room Type*&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRoomType1" runat="server" AutoPostBack="True" DataSourceID="objroomtype"
                                    DataTextField="RoomType" DataValueField="RoomType_ID" SkinID="ddl" TabIndex="3"
                                    Width="128px">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblOccupants" runat="server" Text="Occupants&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOccupants11" runat="server" SkinID="txt" Width="128px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
           
                <center>
               
                    <tr>
                        <td class="btnTd" colspan="2">
                       
                                <asp:Button ID="InsertHostelDetails" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                    SkinID="btn" Text="ADD" ValidationGroup="ADD" TabIndex="4" />
                                &nbsp;<asp:Button ID="ViewHostelDetails" runat="server" CausesValidation="False"
                                    CssClass="ButtonClass" SkinID="btn" TabIndex="5" Text="VIEW" />
                                    </td>
                                    </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                 </table>
                                   
                                     <center>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                              
                                     </center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GvHostelDetails" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
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
                                                    <asp:TemplateField HeaderText="Hostel Code" SortExpression="Hostel Code">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("HDID") %>' Visible="false" />
                                                            <asp:Label ID="lblHostelId" runat="server" Text='<%# Bind("HostelID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblHostelcode" runat="server" Text='<%# Bind("HostelCode") %>' Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Hostel Name" SortExpression="Hostel Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHName" runat="server" Text='<%# Bind("HostelName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Room No" SortExpression="Room No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRoomNo" runat="server" Text='<%# Bind("RoomNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Room Type" SortExpression="Room Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRoomTypelId" runat="server" Text='<%# Bind("RoomTypeID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblRoomType" runat="server" Text='<%# Bind("RoomType") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Occupants" SortExpression="Occupants">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbloccupants" runat="server" Text='<%# Bind("NoOfOccupants") %>' Visible="true"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <asp:ObjectDataSource ID="objhostelcode" runat="server" TypeName="DLHostelDetails"
                                SelectMethod="Gethostelcode" DataObjectTypeName="ERoomType"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="objroomtype" runat="server" TypeName="DLHostelDetails"
                                SelectMethod="Getroomtype" DataObjectTypeName="ERoomType"></asp:ObjectDataSource>
                                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

