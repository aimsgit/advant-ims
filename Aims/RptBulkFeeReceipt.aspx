<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptBulkFeeReceipt.aspx.vb"
    Inherits="RptBulkFeeReceipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BULK FEE RECEIPT GENERATION</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
        <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
        <asp:UpdatePanel ID="Updatepanel1" runat="server">
            <ContentTemplate>
                <div>
                 <br />
                    <center>
                        <h1 class="headingTxt">
                            BULK FEE RECEIPT GENERATION
                        </h1>
                        <br />
                    </center>
                   
                    <br />
                    <center>
                        <table>
                         <tr>
                                <%-- <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Book Issued To:" SkinID="lbl"></asp:Label>
                            </td>--%>
                                <td colspan="2" align="center">
                                    <asp:RadioButtonList ID="RBUsers" runat="server" SkinID="RD" AutoPostBack="True"
                                        RepeatDirection="Horizontal" TabIndex="1">
                                        <asp:ListItem Value="1" Selected="True">Date</asp:ListItem>
                                        <asp:ListItem Value="2">Receipt</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                        DataValueField="DeptID" SkinID="ddlRsz" Width="200" TabIndex="1">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjDept" runat="server" SelectMethod="DeptCombo" TypeName="EmployeeDB">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFrmDate" runat="server" SkinID="lblRSZ" Text=" From Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFrmDate" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFrmDate"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblToDate" runat="server" SkinID="lblRSZ" Text=" To Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTodate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTodate"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lblRSZ" Text="From Receipt No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlReceipt1" runat="server" DataSourceID="ObjReceipt1" DataTextField="ReceiptNo"
                                        DataValueField="Fee_Details_ID" SkinID="ddl" Width="200" TabIndex="4">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjReceipt1" runat="server" SelectMethod="RecepitCombo"
                                        TypeName="EmployeeDB"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" SkinID="lblRSZ" Text="To Receipt No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlReceipt2" runat="server" DataSourceID="ObjReceipt2" DataTextField="ReceiptNo"
                                        DataValueField="Fee_Details_ID" SkinID="ddl" Width="200" TabIndex="5">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjReceipt2" runat="server" SelectMethod="RecepitCombo"
                                        TypeName="EmployeeDB"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <center>
                                        <asp:Button ID="btnimport" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Text="DETAILS REPORT"
                                            CommandName="DETAILS REPORT" TabIndex="6" Width ="150px"/>
                                            <asp:Button ID="btnsummary" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Text="SUMMARY REPORT"
                                            CommandName="SUMMARY REPORT" TabIndex="7" Width="150px" />
                                        &nbsp;<asp:Button ID="btnclear" runat="server" SkinID="btn" CssClass="ButtonClass"
                                            TabIndex="8" CommandName="BACK" Text="BACK" />
                                        <br />
                                        <br />
                                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                            <ProgressTemplate>
                                                <div class="PleaseWait">
                                                    <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <br />
                                        <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                                        <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                                    </center>
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
