<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmbookIssueReport.aspx.vb"
    Inherits="frmbookIssueReport" Title="Book Issue report" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Book Issue report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            //            msg = DropDownForZero (document.getElementById("<%=cmbBookIssue.ClientID %>"), 'Book Issue To');
            //            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtfromdate.ClientID %>"), 'From Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtfromdate.ClientID%>"), 'From Date');
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txttodate.ClientID %>"), 'To Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txttodate.ClientID%>"), 'To Date');
            if (msg != "") return msg;
            return true;
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
 
   <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <table>
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
                </table>
                <center>
                    <table class="custTable">
                       <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBranch" runat="server" Text="Branch* :&nbsp;&nbsp;"
                                            SkinID="lblRsz" width="250"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlbranch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode" Width="320px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjBranch" runat="server" 
                                            SelectMethod="SelectBranch" TypeName="DLLIC"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="320px" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLLIC" SelectMethod="GetDeptTypeAll">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="Book Issue To :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbBookIssue" runat="server" SkinID="ddl" TabIndex="2">
                                    <asp:ListItem Value="ALL">ALL</asp:ListItem>
                                    <asp:ListItem Value="STUDENT">Student</asp:ListItem>
                                    <asp:ListItem Value="EMPLOYEE">Employee</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="From Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfromdate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="To Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttodate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="5" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                &nbsp;<asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
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
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtfromdate"
                    Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                    Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
