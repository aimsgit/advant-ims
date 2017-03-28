<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptFeeStruct.aspx.vb"
    Inherits="RptFeeStruct" Title="Fee Structure Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Structure Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlacadmeic_year.ClientID%>"), 'Academic Year')
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID%>"), 'Batch')
            if (msg != "") return msg;
            return true;
        }

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID%>").textContent = "";
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
             <br />
                <center>
                    <h1 class="headingTxt">
                        FEE STRUCTURE</h1>
                </center>
                <br />
               <br />
            </div>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Academic Calendar Year*  :&nbsp;"
                                Width="250px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlacadmeic_year" runat="server" AutoPostBack="True" DataSourceID="odsaccyear"
                                DataTextField="AcademicYear" DataValueField="id" SkinID="ddl" TabIndex="1">
                                <%--<asp:ListItem Value="0">AppendDataBoundItems="True" Select</asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsaccyear" runat="server" SelectMethod="GetAcademicCombo"
                                TypeName="BLNew_stdMarks"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblbatch" runat="server" Text="Batch* :&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlbatch" runat="server" TabIndex="2" DataSourceID="odsbatch"
                                SkinID="ddlRsz" DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="true"
                                Width="200">
                                <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsbatch" runat="server" SelectMethod="GetOpenBatchCombo"
                                TypeName="DLNew_StudentMarks">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlacadmeic_year" Name="A_Year" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblsem" runat="server" Text="Semester :&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlsem" runat="server" SkinID="ddl" TabIndex="3" DataSourceID="odssemester"
                                DataTextField="SemName" DataValueField="SemCode" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odssemester" runat="server" SelectMethod="SemesterCombo12"
                                TypeName="FeeCollectionBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblcat" runat="server" Text="Category :&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlcat" runat="server" SkinID="ddl" TabIndex="4" DataSourceID="odsCategory"
                                DataTextField="Std_CategoryName" DataValueField="Std_CategoryID" AppendDataBoundItems="True"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsCategory" runat="server" SelectMethod="Category" TypeName="FeeStructD">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tbody>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd">
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                    TabIndex="5" OnClientClick="return Validate();" />
                                &nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK"
                                    TabIndex="6" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>
