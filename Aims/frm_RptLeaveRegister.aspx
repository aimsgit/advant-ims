<%@ Page Title="Leave Register" Language="VB" AutoEventWireup="false" CodeFile="frm_RptLeaveRegister.aspx.vb" Inherits="frm_RptLeaveRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Leave Register</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        LEAVE REGISTER</h1>
                </center>
                <center>
                    <br />
                    <br />
                    <table id="table1" class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="200" TabIndex="1" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" SelectMethod="DeptCombo" TypeName="DlLeaveRegisterRpt">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblLeaveType" runat="server" SkinID="lblRsz" Text="Leave Type&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlleavetype" TabIndex="2" runat="server" SkinID="ddl" DataSourceID="odsleave"
                                    DataTextField="Leave_Type" DataValueField="TypeID" AppendDataBoundItems="true">
                                    <%--<asp:ListItem Value="0" Text="All"></asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsleave" runat="server" TypeName="DlLeaveRegisterRpt"
                                    SelectMethod="GetLeave"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblLeaveYear" runat="server" SkinID="lblRsz" Text="Year&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                    <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                        DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="3" Width="160px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="DlLeaveRegisterRpt">
                                    </asp:ObjectDataSource>
                                </td>
                        </tr>
                        
                        <tr>
                            <td>
                                &nbsp;
                                
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td class="btnTd" align="center">
                                <asp:Button ID="btnSumRpt" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="4" Text="REPORT" Visible="true" />
                          &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="5" Text="BACK" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" BackColor="Green" ForeColor="White"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <div>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </div>
                        
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>


