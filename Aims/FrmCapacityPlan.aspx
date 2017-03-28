<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmCapacityPlan.aspx.vb"
    Inherits="FrmCapacityPlan" Title="Capacity Plan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Capacity Plan</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlDept.ClientID %>"), 'Department');
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlGrade.ClientID %>"), 'Grade');
            if (msg != "") return msg;
            msg = Field1(document.getElementById("<%=txtNoOfReq.ClientID %>"), 'No Of Req');
            if (msg != "") return msg;
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
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div class="mainBlock">
                    <%-- <center>
                        <h1 class="headingTxt">
                            HOLIDAY MASTER
                        </h1>
                      
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDept" runat="server" Text="Department* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept1" DataTextField="DeptName"
                                        DataValueField="DeptID" SkinID="ddlRsz" Width="200px" TabIndex="1">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjDept1" runat="server" TypeName="BLIndividualFormMaster"
                                        SelectMethod="GetddlDept"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblGrade" runat="server" Text="Salary Grade* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlGrade" runat="server" DataSourceID="objGrade" DataValueField="Grade_Auto"
                                        DataTextField="Grade" TabIndex="2" SkinID="ddlRsz" Width="200px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objGrade" runat="server" TypeName="BLIndividualFormMaster"
                                        SelectMethod="GetGrade"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblNoOfReq" runat="server" SkinID="lblRsz" Text="Nos. Required* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNoOfReq" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFinYear" runat="server" SkinID="lblRsz" Text="Year :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                        DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="4">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDateReq" runat="server" Text="Required By Date :&nbsp;&nbsp;" SkinID="lblRsz" Width="170"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDateReq" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdateReq"
                                        Format="dd-MMM-yyyy" SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRemarks" runat="server" SkinID="lblRsz" Text="Remarks :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRemarks" runat="server" SkinID="txt" TabIndex="6" TextMode="multiline"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td class="btnTd">
                                    <center>
                                        <asp:Button ID="InsertButton" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                            SkinID="btn" Text="ADD" CommandName="ADD" ValidationGroup="ADD" TabIndex="7"  CausesValidation="False"/>
                                        &nbsp;<asp:Button ID="btnDet" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            CommandName="VIEW" SkinID="btn" TabIndex="8" Text="VIEW" />
                                        <br />
                                        <br />
                                        <center>
                                            <div>
                                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                            </div>
                                            <br />
                                        </center>
                                        <asp:GridView ID="GvCapacity" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                            Visible="False" AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
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
                                                <asp:TemplateField HeaderText="Department">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("CapacityPlan_AutoId") %>'
                                                            Visible="false" />
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Dept") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblDept" runat="server" Text='<%# Bind("DeptName") %>' Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Salary Grade">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSalaryGrade" runat="server" Text='<%# Bind("SalaryBand") %>'></asp:Label>
                                                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("Grade1") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nos. Required">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNosReq" runat="server" Text='<%# Bind("NosReq") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Year">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblYear" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Req Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReqdate" runat="server" Text='<%# Bind("ReqDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <a name="Bottom">
                        <div align="right">
                            <a href="#Top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                        </div>
                    </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
