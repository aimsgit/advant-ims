<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmShiftMaster.aspx.vb"
    Inherits="Mfg_FrmShiftMaster" Title="Shift Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Shift Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%= txtShiftDesc.ClientID %>"), 'Shift Desc');
            document.getElementById("<%= txtShiftDesc.ClientID %>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtStartDate.ClientID %>"), 'Start Time');
            document.getElementById("<%=txtStartDate.ClientID%>").focus();
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtEndDate.ClientID %>"), 'End Time');
            document.getElementById("<%=txtEndDate.ClientID%>").focus();
            if (msg != "") return msg;
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

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <div>
        <center>
            <h1 class="headingTxt">
                <asp:Label ID="Lblheading" Text="SHIFT MASTER" runat="server"></asp:Label>
            </h1>
        </center>
        <br />
        <br />
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblShiftDesc" runat="server" Text="Shift Desc* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtShiftDesc" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStartDate" runat="server" Text="Start Time* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStartDate" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="2" ></asp:TextBox>
                                 <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                                        AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                        Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtStartDate" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEndDate" runat="server" Text="End Time* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEndDate" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="3" ></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                                        AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                        Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtEndDate" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDuration" runat="server" Text="Duration Hrs :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDuration" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" ValidChars="0123456789" TargetControlID="txtDuration">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRemarks" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="5" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnadd" runat="server" Text="ADD" SkinID="btn" CausesValidation="true"
                                    TabIndex="6" OnClientClick="return Validate();" CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="btnDet" runat="server" Text="VIEW" SkinID="btn" CausesValidation="False"
                                    TabIndex="7" CssClass="ButtonClass" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <center>
                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="500px" Height="650px">
                        <asp:GridView ID="GVShiftMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editbutton" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" />
                                        <asp:LinkButton ID="Button2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Shift Desc" SortExpression="Shift Desc">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("Shift_Id") %>'></asp:HiddenField>
                                        <asp:Label ID="lblShiftDesc" runat="server" Text='<%# Bind("Shift_Desc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Time" SortExpression="Start Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("StartTime", "{0:hh:mm tt}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Time" SortExpression="End Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("EndDate", "{0:hh:mm tt}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Duration Hrs" SortExpression="Duration Hrs">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Duration_Hrs") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <a name="bottom">
                        <div align="right">
                            <a href="#top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                        </div>
                    </a>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</form>
</body>
</html>

