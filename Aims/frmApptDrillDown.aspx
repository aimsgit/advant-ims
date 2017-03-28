<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmApptDrillDown.aspx.vb"
    ValidateRequest="false" EnableEventValidation="false" Inherits="frmApptDrillDown" %>

<%@ Register Src="~/usercontroles/wuc_Themes_Select.ascx" TagName="wuc_Themes_Select"
    TagPrefix="ucl2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script language="javascript" type="text/javascript">

    function openNewWin(url) {

        var x = window.open(url, 'mynewwin', 'width=900,height=700,scrollbars=yes,location=no,resizable =yes');

        x.focus();

    }

</script>

<head id="Head1" runat="server">
    <title>Appoinment Details</title>
</head>
<br />
<br />
<br />
<br />
<body style="background-color: #E2E3BB;">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <form id="form1" runat="server">
    <center>
        <div>
            <h1 class="headingTxt">
                <asp:Label ID="Lblheading" runat="server"></asp:Label>
            </h1>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="msginfo" SkinID="lblRed" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:Panel ID="panel1" runat="server" ScrollBars="Vertical" Height="300px">
                <asp:GridView ID="GVAppt" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="100" SkinID="GridView" TabIndex="6">
                    <Columns>
                        <asp:TemplateField HeaderText="Lead">
                            <ItemTemplate>
                                <asp:HiddenField ID="CAId" runat="server" Value='<%# Bind("COAutoId") %>' />
                                <asp:HiddenField ID="LeadId" runat="server" Value='<%# Bind("LeadId") %>' />
                                <asp:Label ID="LeadName" runat="server" Text='<%# Bind("LeadName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Appointment Date">
                            <ItemTemplate>
                                <asp:Label ID="lblAdate" runat="server" Text='<%# Bind("AppointmentDate","{0:dd-MMM-yyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Appointment Time ">
                            <ItemTemplate>
                                <asp:Label ID="lblAtime" runat="server" Text='<%# Bind("AppointmantTime","{0:hh:mm tt}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Assigned To">
                            <ItemTemplate>
                                <asp:HiddenField ID="lblempid" runat="server" Value='<%# Bind("EmpID") %>' />
                                <asp:Label ID="lblAssignedTo" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <%--      <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblLead" runat="server" Text="Lead* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLead" runat="server" Text='<%# Bind("LeadName") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblApptDate" runat="server" Text="Appointment Date* :&nbsp;&nbsp;"
                            SkinID="lblRsz"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtApptDate" TabIndex="2" runat="server" SkinID="txt" Text='<%# Bind("AppointmentDate","{0:dd-MMM-yyy}") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblApptTime" runat="server" Text="Appointment Time* :&nbsp;&nbsp;"
                            SkinID="lblRsz"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtApptTime" runat="server" TabIndex="3" Text='<%# Bind("AppointmantTime","{0:hh:mm tt}") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblAssignedto" runat="server" Text="Assigned To* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEmpname" runat="server" SkinID="txt" Text='<%# Bind("Emp_Name") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblStatus" runat="server" Text="Status* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtstatus" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblRemarks" runat="server" SkinID="lbl" Text="Remarks :&nbsp;"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox Text='<%# Bind("Remarks") %>' ID="txtRemarks" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>--%>
        </div>
    </center>
    </form>
</body>
</html>
