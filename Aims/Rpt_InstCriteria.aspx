<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_InstCriteria.aspx.vb"
    Inherits="Rpt_InstCriteria" Title="Employee/Student Count" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee/Student Count</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

 <script src="js/Tvalidate.js" type="text/javascript">  </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            EMPLOYEE/STUDENT COUNT
                        </h1>
                    </center>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblInstitute" runat="server" Text="Institute&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lbl" Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlInstitute" TabIndex="1" runat="server" SkinID="ddlL" AutoPostBack="True"
                                        DataSourceID="ObjInstitute" DataTextField="BranchName" DataValueField="BranchCode">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td align="right">
                                    <asp:Label ID="lblDate" runat="server" SkinID="lbl" Text="Date :&nbsp;&nbsp;"></asp:Label>
                                </td align="Left">
                                <td align="left">
                                    <asp:TextBox ID="txtToDateExt" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                </td>
                            </tr>
                            <ajaxToolkit:CalendarExtender ID="ToDateExt" runat="server" TargetControlID="txtToDateExt"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>--%>
                              <tr>
                                <td align="right">
                                    <asp:Label ID="lblFromdate" runat="server" SkinID="lbl" Text="From Date* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFromDateExt" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                </td>
                            </tr>
                            <ajaxToolkit:CalendarExtender ID="FromDateExt" runat="server" TargetControlID="txtFromDateExt"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblToDate" runat="server" SkinID="lbl" Text="To Date* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtToDateExt" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                </td>
                            </tr>
                            <ajaxToolkit:CalendarExtender ID="ToDateExt" runat="server" TargetControlID="txtToDateExt"
                                Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="4">
                                    <asp:Button ID="btnReport" TabIndex="9" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnBack" TabIndex="11" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <asp:ObjectDataSource ID="ObjInstitute" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetInstituteDDL" TypeName ="DLInstitute"></asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>

