<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptAdhocfeecollectionReport.aspx.vb" Inherits="rptAdhocfeecollectionReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Miscellaneous Fee collection Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
    <script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
//            msg = DropDownForZero(document.getElementById("<%=ddlfee_head.ClientID %>"), 'Fee Head');
//            if (msg != "") {
//                document.getElementById("<%=ddlfee_head.ClientID%>").focus();
//                a = document.getElementById("<%=lblfeehead.ClientID %>").innerHTML;
//               
//                return msg;
//            }
            
            msg = ValidateDate(document.getElementById("<%=txtSDate.ClientID%>"), 'Start Date');
            if (msg != "") {
                document.getElementById("<%=txtSDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtEDate.ClientID%>"), 'End Date');
            if (msg != "") {
                document.getElementById("<%=txtEDate.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
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
            <div>
                <center>
                    <br />
                    <h1 class="headingTxt">
                        MISCELLANEOUS FEE COLLECTION REPORT</h1>
                        </center>
                    <br />
                    <br />
                    <center>
                    <table >
                     <tr>
                            <td align="right">
                                            <asp:Label ID="lblfeehead" runat="server" Text="Fee Head&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="200px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlfee_head" runat="server" SkinID="ddlRsz" DataSourceID="odsfeehead" Width="200"
                                                DataTextField="Fee_HeadType" DataValueField="Fee_Head_IDAuto" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">All</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsfeehead" runat="server" SelectMethod="GetFeeHeads1" TypeName="feeStructureDL">
                                            </asp:ObjectDataSource>
                                        </td>
                        </tr>
                        <%--<tr>
                            <td align="right">
                                <asp:Label ID="Label15" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lbl" Style="margin-left: 0px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbBatch" TabIndex="1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch" Width="200">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" SkinID="lbl" runat="server" Text="Student Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:DropDownList ID="ddlstucode" TabIndex="2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    DataSourceID="ObjStuCode" DataTextField="StdCode" DataValueField="STD_ID" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjStuCode" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetStudentReportCombo" TypeName="DLReportsR">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cmbBatch" Name="BatchID" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPaymentMethod" runat="server" SkinID="lblRsz" Width="150" Text="Payment Method&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataSourceID="ObjPaymentMethod"
                                    DataTextField="Payment_Method" DataValueField="PaymentMethodID" AppendDataBoundItems="true"
                                    SkinID="ddlRsz" TabIndex="3" Width="200">
                                    <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodCombo"
                                    TypeName="FeeCollectionBL"></asp:ObjectDataSource>
                            </td>
                        </tr>
                     
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSDate" runat="server" Text="Start Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSDate" TabIndex="4" runat="server" SkinID="txt">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="Calendarextender1" runat="server" TargetControlID="txtSDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEDate" runat="server" Text="End Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEDate" TabIndex="5" runat="server" SkinID="txt">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="FromDateExt" runat="server" TargetControlID="txtEDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                <asp:Button ID="btnReport" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="6" Text="REPORT" />
                                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="7" Text="BACK" Visible="true" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetOpenBatchCombo1" TypeName="DLNew_StudentMarks">
                                    
                                </asp:ObjectDataSource>
                   
                            </td>
                        </tr>
                    </table>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
