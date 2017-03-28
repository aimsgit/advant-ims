<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptCollectSpMoney.aspx.vb"
    Inherits="RptCollectSpMoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admission Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
    <script type ="text/javascript" >
        function openwd() {

            window.location = "Report.aspx";


        }
    </script>
   
</head>

 
<body style="width: 800px; height: 800px">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         </br>
            <center>
                <h1 class="headingTxt">
                    COLLECT SPONSOR MONEY
                </h1>
                </br>
                </br>
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblA_Year" runat="server" Text="Academic Year :&nbsp;&nbsp;" SkinID="lblRSz"
                                Width="150px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DDLA_Year" TabIndex="2" runat="server" SkinID="ddlRsz" Width="195px"
                                AutoPostBack="True" DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjAcademic" runat="server" TypeName="BLNew_stdMarks" SelectMethod="GetAcademicCombo1">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBatch" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbBatch" TabIndex="6" runat="server" SkinID="ddlRsz" Width="195px"
                                AutoPostBack="True" DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" TypeName="StudentListDB" SelectMethod="BatchAcademic">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DDLA_Year" PropertyName="SelectedValue" Name="A_Year"
                                        DefaultValue="0" Type="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Student Name :&nbsp;&nbsp;" SkinID="lblRSz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList1" TabIndex="6" runat="server" SkinID="ddlRsz"
                                    Width="195px" AutoPostBack="True" DataValueField="Std_Id" DataTextField="StdName"
                                    DataSourceID="Objstd">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="Objstd" runat="server" TypeName="StudentListDB" SelectMethod="BatchAcademicStudent">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLA_Year" PropertyName="SelectedValue" Name="A_Year"
                                            DefaultValue="0" Type="Int16" />
                                        <asp:ControlParameter ControlID="cmbBatch" PropertyName="SelectedValue" Name="batch"
                                            DefaultValue="0" Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                         <tr>
                            <td align="right">
                                <asp:Label ID="lblModeofpayment" runat="server" Text="Mode :&nbsp;&nbsp" SkinID="lblRSz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlpaymentmethod" runat="server" SkinID="ddl" DataTextField="Payment_Method"
                                    DataValueField="PaymentMethodID" TabIndex="53" DataSourceID="cmbpaymentmethod">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="cmbpaymentmethod" runat="server" SelectMethod="GetPaymentMethodcombo1"
                                    TypeName="DLcollectSponser"></asp:ObjectDataSource>
                            </td>
                        </tr>
                       
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="4"  runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="5" runat="server" OnClientClick ="openwd();" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
