<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmCompareCourseAcrossBranches.aspx.vb"
    Inherits="FrmCompareCourseAcrossBranches" Title="Compare Course Across Branches" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Compare Course Across Branches</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--      <center>
                    <h1 class="headingTxt">
                        COMPARE COURSE ACROSS BRANCHES</h1>
                </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Year* :&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td>
                                     <asp:DropDownList ID="ddlAcademicyear" runat="server"  AutoPostBack="true" AppendDataBoundItems="true"
                                        DataTextField="AcademicYear" DataValueField="A_Code" SkinID="ddlRsz" TabIndex="2"  DataSourceID="objAcademicyear"
                                        Width="250px">
                                        <%--           <asp:ListItem>Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                   <%-- <asp:DropDownList ID="" Enabled="true" runat="server" SkinID="ddl"  AutoPostBack="true"
                                        DataSourceID="objAcademicyear" TabIndex="1" DataTextField="" DataValueField="">
                                    </asp:DropDownList>--%>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td colspan="3">
                                    <hr style="width: 480px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblCourse1" runat="server" SkinID="lbl" Text="Course 1 :  "></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCourse2" runat="server" SkinID="lbl" Text="Course 2 :  "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourse1" runat="server" DataSourceID="ObjCourse1" AutoPostBack="true"
                                        DataTextField="CourseName" DataValueField="CourseCode" SkinID="ddlRsz" TabIndex="2"
                                        Width="250px">
                                        <%--           <asp:ListItem>Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourse2" runat="server" SkinID="ddlRsz" AutoPostBack="true"
                                        DataSourceID="ObjCourse2" DataTextField="CourseName" DataValueField="CourseCode"
                                        Width="250px" TabIndex="2">
                                        <%--  <asp:ListItem>Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblCourse3" runat="server" SkinID="lbl" Text="Course 3 :  "></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCourse4" runat="server" SkinID="lbl" Text="Course 4 :  "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourse3" runat="server" DataSourceID="ObjCourse3" AutoPostBack="true"
                                        DataTextField="CourseName" DataValueField="CourseCode" SkinID="ddlRsz" TabIndex="2"
                                        Width="250px">
                                        <%--<asp:ListItem>Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourse4" runat="server" DataSourceID="ObjCourse4" AutoPostBack="true"
                                        DataTextField="CourseName" DataValueField="CourseCode" SkinID="ddlRsz" TabIndex="2"
                                        Width="250px">
                                        <%--<asp:ListItem>Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <hr style="width: 480px" />
                                </td>
                            </tr>
                        </table>
                    </center>
            </a><a name="bottom">
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="BtnGenerate" runat="server" CausesValidation="False" CssClass="ButtonClass "
                                    SkinID="btnRsz" TabIndex="8" Text="GENERATE" ToolTip="GENERATE" Width="120px" />
                                <asp:ObjectDataSource ID="objAcademicyear" runat="server" SelectMethod="GetAcademicYear"
                                    TypeName="DLCompareCourseAcrossBranches"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="GetCourse1" TypeName="DLCompareCourseAcrossBranches">
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjCourse2" runat="server" SelectMethod="GetCourse1" TypeName="DLCompareCourseAcrossBranches">
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjCourse3" runat="server" SelectMethod="GetCourse1" TypeName="DLCompareCourseAcrossBranches">
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjCourse4" runat="server" SelectMethod="GetCourse1" TypeName="DLCompareCourseAcrossBranches">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            Processing your request..Please wait...
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="600px" Height="300px">
                            <asp:GridView ID="GridView" runat="server" SkinID="GridView" AllowPaging="True" AutoGenerateColumns="False"
                                AllowSorting="True" PageSize="100">
                                <Columns>
                                    <%--<asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                TabIndex="9" Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                TabIndex="10" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Branch Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchCode" Visible="false" runat="server" Text='<%# Bind("BranchCode") %>' />
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C1 Min %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMinPercentage" runat="server" Width="100px" Text='<%# Bind("MinPercentage","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C1 Max %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaxPercentage" runat="server" Width="100px" Text='<%# Bind("MaxPercentage","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C1 Avg %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAvgPercentage" runat="server" Width="100px" Text='<%# Bind("AvgPercentage","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C2 Min %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMinPercentageC2" runat="server" Width="100px" Text='<%# Bind("MinPercentageC2","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C2 Max %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaxPercentageC2" runat="server" Width="100px" Text='<%# Bind("MaxPercentageC2","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C2 Avg %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAvgPercentageC2" runat="server" Width="100px" Text='<%# Bind("AvgPercentageC2","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C3 Min %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMinPercentageC3" runat="server" Width="100px" Text='<%# Bind("MinPercentageC3","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C3 Max %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaxPercentageC3" runat="server" Width="100px" Text='<%# Bind("MaxPercentageC3","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C3 Avg %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAvgPercentageC3" runat="server" Width="100px" Text='<%# Bind("AvgPercentageC3","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C4 Min %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMinPercentageC4" runat="server" Width="100px" Text='<%# Bind("MinPercentageC4","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C4 Max %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMaxPercentageC4" runat="server" Width="100px" Text='<%# Bind("MaxPercentageC4","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="C4 Avg %" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAvgPercentageC4" runat="server" Width="100px" Text='<%# Bind("AvgPercentageC4","{0:n2}") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </center>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>