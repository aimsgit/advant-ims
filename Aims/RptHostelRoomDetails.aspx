<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptHostelRoomDetails.aspx.vb"
    Inherits="RptHostelRoomDetails" Title="Hostel Room Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Hostel Room Details</title>
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
                      HOSTEL ROOM DETAILS
                        </h1>
                        <br />
                        <br />
                    </center>
                    <center>
                        <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBranchType" runat="server" Text="Branch Name* :&nbsp;&nbsp;" SkinID="lblRsz" ></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBranchName" TabIndex="1" runat="server" SkinID="ddlL"
                                    AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="insertBranchCombo" TypeName="DLReportsR"></asp:ObjectDataSource>
                            </td>
                        </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblHosName" runat="server" Text="Hostel Name :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="120px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbHosName" runat="server" DataSourceID="odshosname" DataTextField="HostelName"
                                        TabIndex="1" SkinID="ddl" AutoPostBack="True"  DataValueField="HMIDAuto">
                                       
                                        
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odshosname" runat="server" SelectMethod="GetHosNameCombo"
                                        TypeName="HostelAdmissionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranchName" PropertyName="SelectedValue" Name="BranchCode" />
                                        </SelectParameters>
                                        </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRoomType" runat="server" Text="Room Type :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="120px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbRoomType" runat="server" DataSourceID="odsroomtype" DataTextField="RoomType"
                                        SkinID="ddl" AutoPostBack="True" DataValueField="RoomTypeAuto" TabIndex="2">
                                       
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsroomtype" runat="server" SelectMethod="RoomTypeCombo"
                                        TypeName="DLHostelRpt">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranchName" PropertyName="SelectedValue" Name="BranchCode" />
                                            <asp:ControlParameter ControlID="cmbHosName" PropertyName="SelectedValue" Name="Hid" />
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
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="3" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass"></asp:Button>
                                    <asp:Button ID="btnAdd" TabIndex="4" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
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
