<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmPrincipalDashboard.aspx.vb"
    Inherits="FrmPrincipalDashboard" Title="Principal Dashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Principal Dashboard</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=cmbAcademic.ClientID %>"), 'Academic Year');
            if (msg != "") {
                document.getElementById("<%=cmbAcademic.ClientID %>").focus();
                return msg;
            }
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
    </script>

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
                    <%--                <center>
                    <h1 class="headingTxt">
                        PRINCIPAL DASHBOARD</h1>
                </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <br />
                                </td>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Style="margin-left: 0px" Text="Academic Calendar Year* :&nbsp;&nbsp;"
                                            Width="250px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="cmbAcademic" runat="server" AutoPostBack="True" DataSourceID="ObjAcademic"
                                            DataTextField="AcademicYear" DataValueField="id" SkinID="ddl" TabIndex="1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="Course&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" DataSourceID="ObjCourse1"
                                            DataTextField="CourseName" DataValueField="CourseCode" SkinID="ddlRsz" TabIndex="2"
                                            Width="250">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label11" runat="server" SkinID="lblRsz" Text="Student Category&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:DropDownList ID="ddlcategry" runat="server" AppendDataBoundItems="True" DataSourceID="ObjCategory"
                                            DataTextField="CategoryName" DataValueField="Category_Id" SkinID="ddl" TabIndex="3">
                                            <asp:ListItem Value="0">All</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="btnTd" colspan="4">
                                        <asp:Button ID="btnGenerate" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="4" Text="GENERATE" />
                                        &nbsp;
                                        <asp:Button ID="BtnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                            Text="BACK" />
                                        &nbsp;
                                    </td>
                                </tr>
                            </tr>
                        </table>
                        <br />
            </a><a name="bottom">
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
                                <asp:Label ID="lblE" runat="server" Text="" SkinID="lblRed"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblApproved" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Approved By &nbsp;:"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Approvedby") %>' SkinID="lblRsz"
                                    Width="200"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblAffiliatedTo" runat="server" Text="&nbsp;&nbsp;Affiliated To &nbsp;:"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("AffiliatedTo") %>' SkinID="lblRsz"
                                    Width="200"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAccredited" runat="server" Text="&nbsp;&nbsp;Accredited By &nbsp;:"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Accredited") %>' SkinID="lblRsz"
                                    Width="250"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <%--  <tr>
             <td colspan="4">
            
             </td>
             </tr>--%>
                <%--<hr />--%>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstaff" runat="server" Text="&nbsp;&nbsp;Total Staff&nbsp;:" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblTotEmpCount" runat="server" Text='<%# Bind("lblTotEmpCount") %>'
                                    SkinID="lbl"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblfultimstaff" runat="server" Text="&nbsp;&nbsp;Full Time Staff&nbsp;:"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbltotfultimstaff" runat="server" Text='<%# Bind("TotFullTimeStaff") %>'
                                    SkinID="lbl"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTeachingstaff" runat="server" SkinID="lblRsz" Text="&nbsp;&nbsp;Teaching Staff :"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbltottechstaff" runat="server" SkinID="lbl" Text='<%# Bind("TotTeachingStaff") %>'></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblparttimstaff" runat="server" Text="&nbsp;&nbsp;Part Time Staff&nbsp;:"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbltotparttimstaff" runat="server" Text='<%# Bind("TotPartTimeStaff") %>'
                                    SkinID="lbl"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblnonteachingstaff" SkinID="lblRsz" runat="server" Text="&nbsp;&nbsp;Non Teaching Staff :"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblTotNonTeachingStaff" runat="server" SkinID="lbl" Text='<%# Bind("TotNonTeachingStaff") %>'></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblvisit" runat="server" Text="&nbsp;&nbsp;Visiting Staff&nbsp;:"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblVisiting" runat="server" Text='<%# Bind("VisitingEmp") %>' SkinID="lbl"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                            </td>
                            <td align="right">
                                <asp:Label ID="lblHonoraryemp" runat="server" Text="&nbsp;&nbsp;Honorary Staff&nbsp;:"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblHonorary" runat="server" Text='<%# Bind("HonoraryEmp") %>' SkinID="lbl"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
               <%-- <hr />--%>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <asp:Panel ID="Panel2" runat="server" Height="250px" Width="650px" ScrollBars="Auto">
                                    <asp:GridView ID="GvGrnadTotal" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                        SkinID="GridView" TabIndex="6" PageSize="10">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" " HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGTotal" runat="server" Text="Grand Total" Width="150px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Male Students">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmale" runat="server" Text='<%# Bind("MaleCount") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Female Students">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfemale" runat="server" Text='<%# Bind("FemaleCount") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltotal" runat="server" Text='<%# Bind("totalcount") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <asp:GridView ID="GVManagementDB" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" TabIndex="6" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Course" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcourse" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                                    <asp:HiddenField ID="SID" runat="server" Value='<%# Bind("CourseName") %>' />
                                                    <%--   <asp:Label ID="HApprovedby" runat="server" Text='<%# Bind("ApprovedBy") %>' Visible="false" />
                                                    <asp:Label ID="HAffiliatedTo" runat="server" Text='<%# Bind("AffiliatedTo") %>' Visible="false" />
                                                    <asp:Label ID="HAccredited" runat="server" Text='<%# Bind("Accredited") %>' Visible="false"/>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="true" Width="200px" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <%--   <asp:TemplateField HeaderText="Student Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("Std_CategoryName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Male Students">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMale" runat="server" Text='<%# Bind("MaleCount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" Width="100px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Female Students">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFemale" runat="server" Text='<%# Bind("FemaleCount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" Width="100px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltotal" runat="server" Text='<%# Bind("totalcount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" Width="100px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotEmpCount" runat="server" Text='<%# Bind("TotEmpCount") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" Width="100px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                        </td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                    TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="GetCoursebyAcademic"
                    TypeName="DLPrincipalDashboard">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmbAcademic" Name="id" PropertyName="SelectedValue"
                            Type="Int16" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjCategory" runat="server" SelectMethod="GetCategory1"
                    TypeName="CategoryDB"></asp:ObjectDataSource>
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