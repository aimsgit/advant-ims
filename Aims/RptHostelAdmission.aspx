<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptHostelAdmission.aspx.vb"
    Inherits="RptHostelAdmission" Title="HOSTEL ADMISSION" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HOSTEL ADMISSION</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                <br />
                    <center>
                        <h1 class="headingTxt">
                            HOSTEL ADMISSION
                        </h1>
                        <br />
                        <br />
                    </center>
                    <center>
                        <table>
                             <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBranch" runat="server" Width="91px" Text="Branch*&nbsp:&nbsp&nbsp"
                                            SkinID="lbl"></asp:Label>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:DropDownList ID="ddlbranch" runat="server" SkinID="ddlL" AutoPostBack="True"
                                            DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBranch" runat="server" 
                                            SelectMethod="GetSelectBranch" TypeName="HostelAdmissionBL"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                
                               <tr>
                                <td align="right">
                                    <asp:Label ID="lblHosName" runat="server" Text="Hostel Name :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="120px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbHosName" runat="server" DataTextField="HostelName"
                                        TabIndex="1" SkinID="ddlRsz" Width="230" AutoPostBack="True" AppendDataBoundItems="True"
                                        DataValueField="HMIDAuto">
                                        
                                    </asp:DropDownList>
                                    
                                        
                                        
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRoomType" runat="server" Text="Room Type :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="120px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbRoomType" runat="server" DataSourceID="odsroomtype" DataTextField="RoomType"
                                        SkinID="ddlRsz" Width="160" AutoPostBack="True" DataValueField="RoomTypeAuto"
                                        TabIndex="2">
                                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsroomtype" runat="server" SelectMethod="RoomTypeCombo"
                                        TypeName="DLHostelRpt">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="cmbHosName" PropertyName="SelectedValue" Name="Hid" />
                                             <asp:ControlParameter ControlID="ddlbranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" /> 
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStatus" runat="server" Text="Status :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="120px" TabIndex="3"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlStstus" runat="server" SkinID="ddlRsz" Width="124" AutoPostBack="True"
                                        TabIndex="3">
                                        <asp:ListItem Text="Active" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Vacated" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFrmDate" runat="server" SkinID="lblRsz" Text="From Date :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFrmDate" runat="server" SkinID="txtRsz" Width="120" TabIndex="4"></asp:TextBox>
                                </td>
                                <%-- <ajaxToolkit:MaskedEditExtender ID="meeDOJ" runat="server" ClearMaskOnLostFocus="false"
                                    ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                    TargetControlID="txtFrmDate">
                                </ajaxToolkit:MaskedEditExtender>--%>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtFrmDate">
                                </ajaxToolkit:CalendarExtender>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblToDate" runat="server" SkinID="lblRsz" Text="To Date :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txtRsz" Width="120" TabIndex="5"></asp:TextBox>
                                </td>
                                <%--  <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="false"
                                    ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                    TargetControlID="txtToDate">
                                </ajaxToolkit:MaskedEditExtender>--%>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>
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
                                <td class="btnTd" align ="center " colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="6" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass"></asp:Button>
                                    <asp:Button ID="btnAdd" TabIndex="7" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <center>
                            <asp:Label ID="lblMsg" runat="server" SkinID="lblRed"></asp:Label>
                        </center>
                        <asp:ObjectDataSource ID="objHostelname" runat="server" SelectMethod="GetHosNameCombo"
                            TypeName="HostelAdmissionBL"></asp:ObjectDataSource>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

