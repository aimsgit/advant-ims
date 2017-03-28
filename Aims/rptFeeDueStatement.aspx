<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptFeeDueStatement.aspx.vb"
    Inherits="rptFeeDueStatement" Title="Fee Due Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Due Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <%--<script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlbatch1.ClientID%>"), 'Batch')
            if (msg != "") return msg;

            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>--%>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <br />
                <center>
                    <h1 class="headingTxt">
                        FEE DUE STATEMENT
                    </h1>
                    <br />
                    <br />
                </center>
            </div>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblsem" runat="server" Text="Academic Calendar year&nbsp;:&nbsp;"
                                SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlAYear" runat="server" DataSourceID="ObjAcademicYear" DataTextField="AcademicYear" AppendDataBoundItems="true"
                                DataValueField="id" SkinID="ddlRsz" Width="200">
                                 <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>                      
                                  <asp:ObjectDataSource ID="ObjAcademicYear" runat="server" SelectMethod="GetAcademicYr"
                                TypeName="feeCollectionDL"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Width="91px" Text="Course&nbsp;:&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlcourse" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                DataSourceID="ObjCourseRpt" DataTextField="CourseName" DataValueField="CourseCode"
                                Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCourseRpt" runat="server" SelectMethod="CourseRpt" TypeName="feeCollectionDL">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblbatch" runat="server" Text="Batch&nbsp;:&nbsp;" SkinID="lblRsz"
                                Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlbatch1" runat="server" DataValueField="BatchID" DataTextField="Batch_No"
                                SkinID="ddlRsz" DataSourceID="ObjBatch1" AutoPostBack="true" Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch1" runat="server" SelectMethod="BatchComboDDL"
                                TypeName="feeCollectionDL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlcourse" Name="CourseCode" Type="Int32" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblStudent" runat="server" SkinID="lbl" Text="Student Name :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStudent" runat="server" DataValueField="STD_ID" DataTextField="StdName"
                                SkinID="ddlRsz" DataSourceID="ObjStudent" AppendDataBoundItems="false" Width="200">
                                <asp:ListItem Value="0">All</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentDDLALL"
                                TypeName="feeCollectionDL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch1" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblstudent_cat" runat="server" Text="Student Category :&nbsp;" SkinID="lblRsz"
                                Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlcategry" runat="server" SkinID="ddlRsz" DataValueField="Category_Id"
                                DataTextField="CategoryName" DataSourceID="ObjCategory" AppendDataBoundItems="True"
                                Width="200">
                                <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCategory" runat="server" TypeName="CategoryDB" SelectMethod="GetCategoryyyALL">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
                <table>
                    <tbody>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd">
                                <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                    ValidationGroup="Validate" OnClientClick="return Validate();" />
                                &nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK"
                                    TabIndex="0" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
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
