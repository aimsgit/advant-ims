<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmRoomType.aspx.vb"
    Inherits="frmRoomType" Title="Room Type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Room Type</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%=txtRoomType.ClientID%>"), 'Room Type');
            if (msg != "") {
                document.getElementById("<%=txtRoomType.ClientID%>").focus();
                return msg;
            }
            msg = FeesField(document.getElementById("<%=txtOccupant.ClientID%>"), 'No. of Occupants');
            if (msg != "") {
                document.getElementById("<%= txtOccupant.ClientID %>").focus();
                return msg;
            }
            msg = Field250N(document.getElementById("<%=txtRemarks.ClientID%>"), 'Remarks');
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
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <h1 class="headingTxt">
            ROOM TYPE
            <br />
            <br />
        </h1>
    </center>
    <center>
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="lblRoomType" runat="server" ForeColor="#000066" SkinID="lblRsz" Text="Room Type* :"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:TextBox ID="txtRoomType" runat="server" MaxLength="50" SkinID="txt" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblOccupant" runat="server" ForeColor="#000066" SkinID="lblRsz" Text="No. of Occupants* : "></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:TextBox ID="txtOccupant" SkinID="txt" runat="server" MaxLength="15" TabIndex="2"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                        FilterMode="validChars" FilterType="Numbers" TargetControlID="txtOccupant">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblRemarks" runat="server" ForeColor="#000066" SkinID="lblRsz" Text="Remarks : "></asp:Label>
                </td>
                <td align="left">
                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" MaxLength="250" TabIndex="3"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="btnTd" colspan="2" align="center">
                    <br />
                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" Text="ADD" TabIndex="4"
                        CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" />
                    <asp:Button ID="btnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                        TabIndex="5" Text="VIEW" SkinID="btn" />
                    <br />
                </td>
            </tr>
        </table>
    </center>
    <div>
        <center>
            <br />
            <asp:Label ID="lblerrmsg" SkinID="lblRed" runat="server" />
            <asp:Label ID="lblmsgifo" SkinID="lblGreen" runat="server" />
            <br />
        </center>
    </div>
    <br />
    <center>
        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="500px" Height="300px">
            <asp:GridView ID="GVRoomType" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                PageSize="100" SkinID="GridView" Width="300px" align="center">
                <Columns>
                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                        <ItemTemplate>
                            <center>
                                <asp:LinkButton ID="LinkButton1" runat="server" TabIndex="6" CausesValidation="False"
                                    CommandName="Edit" Text="Edit" />
                                <asp:LinkButton ID="LinkButton2" runat="server" TabIndex="7" CausesValidation="False"
                                    CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                    Text="Delete" />
                            </center>
                        </ItemTemplate>
                        <ItemStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Room Type" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="id" runat="server" Text='<%# Bind("RoomTypeAuto") %>' Visible="false"></asp:Label>
                            <asp:Label ID="lblRoomType" runat="server" Text='<%# Bind("RoomType") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <HeaderStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="No. of Occupants">
                        <ItemTemplate>
                            <asp:Label ID="lblOccupant" runat="server" Text='<%# Bind("NoOfOccupants") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="false" />
                        <HeaderStyle Wrap="false" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </center>

</form>
</body>
</html>

