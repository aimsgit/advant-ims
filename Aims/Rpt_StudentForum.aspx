<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_StudentForum.aspx.vb"
    Inherits="Rpt_StudentForum" Title="Student Forum Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Forum Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

   <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <center>
                <br />
                <h1 class="headingTxt">
                    STUDENT FORUM REPORT
                </h1>
                <br />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Forum Batch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="Left">
                            <asp:DropDownList ID="ddlBatchName" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="1"
                                Width="200">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblCourse" runat="server" SkinID="lblRsz" Text="Forum Name :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="Left">
                            <asp:TextBox ID="txtCourse" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                        </td>
                    </tr>
                    <td colspan="5">
                        &nbsp;
                    </td>
                    </tr>
                    <tr align="center">
                        <td colspan="5">
                            <asp:Button ID="btnReport" runat="server" OnClientClick="return ValidateReport();"
                                CssClass="ButtonClass" SkinID="btn" Text="REPORT" TabIndex="3"/>&nbsp;
                            <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="4"
                                Text="BACK" Visible="true" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr align="center">
                        <td>
                            <asp:Label ID="lblRed" runat="server" SkinID="lblRed" />
                            <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                    
                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchComboForum"
                        TypeName="TimeTableDl">
                        
                    </asp:ObjectDataSource>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

