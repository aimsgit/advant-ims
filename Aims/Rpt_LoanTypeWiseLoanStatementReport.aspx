 <%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_LoanTypeWiseLoanStatementReport.aspx.vb" Inherits="Rpt_LoanTypeWiseLoanStatementReport" title="Loan Type Statement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Loan Type Statement</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
 <script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        LOAN TYPE WISE LOAN STATEMENT REPORT 
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                        <asp:HiddenField ID="HidempId" runat="server" />
                                        <asp:Label ID="lblLoanType" SkinID="lblRsz" runat="server" Text="Loan Type*&nbsp;:&nbsp;&nbsp;"
                                            Width="150px"></asp:Label>
                                    </td>
                                    <td align="left" >
                                        <asp:DropDownList ID="ddlLoanType" runat="server" DataTextField="Data" DataSourceID="ObjLoanType"
                                            DataValueField="LookUpAutoID" Width="240px" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjLoanType" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetLoanTypeDDL" TypeName="Rpt_EmpWiseLoanMasterStatementDL">
                                            </asp:ObjectDataSource>
                                    </td>
                                    
                                </tr>
                                    <tr>
                                    <td align="right">
                                        <asp:Label ID="Lblfdate" runat="server" Text="From Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Txtfdate" runat="server" SkinID="txt" MaxLength="11" TabIndex="2"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                            TargetControlID="Txtfdate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Lbltdate" runat="server" Text="To Date&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="Txttodate" runat="server" SkinID="txt" MaxLength="11" TabIndex="3"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                                            TargetControlID="Txttodate">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                </table>
                                </center>
                                <br />
                                <center>
                                <table>
                                <tr>
                                    <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                        <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="4" Text="REPORT"/>
                                        <asp:Button ID="btnBack" TabIndex="5" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                        </asp:Button>
                                    </td>
                                </tr>
                            </table>
                            </center> 
                            <center>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                                    </td>
                                </tr>
                               
                            </table>   
                  </center>
    </asp:Panel>               
    </ContentTemplate>               
  </asp:UpdatePanel>  

</form>
</body>
</html>

