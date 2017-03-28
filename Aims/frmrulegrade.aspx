<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmrulegrade.aspx.vb"
    Inherits="frmrulegrade" Title="Rules Engine For Grades and Division" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Rules Engine For Grades and Division</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 850px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlsemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=ddlsemester.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblcorrect.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblcorrect.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlcolumn.ClientID %>"), 'Select Column');
            if (msg != "") {
                document.getElementById("<%=ddlcolumn.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblcorrect.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblcorrect.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="2"
                                Width="240px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerComboSelectAll"
                                TypeName="DLRuleGrade"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblsemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlsemester" SkinID="ddlRsz" runat="server" DataSourceID="ObjSemester"
                                DataTextField="SemName" DataValueField="SemCode" AutoPostBack="True" TabIndex="3"
                                Width="240px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                TypeName="FeeCollectionBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnview" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Text="VIEW"
                                OnClientClick="return Validate();" TabIndex="8" Width="100px" Visible="true" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="center" colspan="2">
                            &nbsp;
                        </td>
                    </tr>--%>
                </table>
            </center>
            <hr />
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="lbloption1" runat="server" Text="Option 1 &nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnrun1" TabIndex="6" runat="server" Text="RUN FORMULA GRP" SkinID="btnRsz"
                            CssClass="ButtonClass" Width="180" OnClientClick="return confirm('Do you want to Run Formula Group ,this will remove previously selected Rules ?');">
                        </asp:Button>
                        <%--<asp:ObjectDataSource ID="ObjFormulaGroup" runat="server" SelectMethod="Formulagroup"
                                TypeName="BLClientContractMaster"></asp:ObjectDataSource>--%>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Formula Group*&nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlformula" runat="server" DataTextField="Data" DataValueField="LookUpAutoID"
                            SkinID="ddlRsz" TabIndex="7" Width="200px" DataSourceID="ObjFormulaGroup">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjFormulaGroup" runat="server" SelectMethod="GetFormulaCombo"
                            TypeName="DLRuleGrade"></asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
            <br />
            <center>
                <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Height="265px" Width="800px">
                    <div id="panel1" runat="server" style="float: left; height: 240px; width: 780px">
                        <asp:GridView ID="GvRule" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="OR" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            
                                            <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check1">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AND">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBx2" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check2">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Assessment">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                            DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="150px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                            TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="151px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options From">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lbloption1" runat="server" Text='<%# Bind("Option1") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="151px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options To">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lbloption2" runat="server" Text='<%# Bind("Option2") %>' Width="150px"></asp:Label>--%>
                                        <asp:DropDownList ID="ddlSubCategory" runat="server" DataSourceID="ObjSubCategory"
                                            DataTextField="SubCategoryName" DataValueField="SubCategoryNo" SkinID="ddlRsz"
                                            TabIndex="4" Width="150px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSubCategory" runat="server" SelectMethod="GetSubjectCategory"
                                            TypeName="DLRuleGrade"></asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="151px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria1" runat="server" Text='<%# Bind("Criteria1") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbGrade" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="GradePoint"
                                            DataTextField="Grade" Width="61px" DataSourceID="ObjGrade">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjGrade" runat="server" SelectMethod="GetGrade" TypeName="DLRuleGrade">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="Batch" PropertyName="SelectedValue"
                                                    Type="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="61px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria2" runat="server" Text='<%# Bind("Criteria2") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue2" runat="server" Width="60px" SkinID="txtRsz"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="10px">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblSelect1" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>--%>
                                        <asp:CheckBox ID="ChkBx3" runat="server" TabIndex="4"></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView2" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100" ShowHeader="false">
                            <Columns>
                                <%-- <asp:TemplateField HeaderText="OR" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                                Visible="false"></asp:Label>
                                            <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check5">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AND">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBx2" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check6">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" Width="26px" HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Assessment">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                            DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="150px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                            TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="151px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options From">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lbloption1" runat="server" Text='<%# Bind("Option1") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="151px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options To">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloption2" runat="server" Text='<%# Bind("Option2") %>' Width="162px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="151px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria1" runat="server" Text='<%# Bind("Criteria1") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbGrade" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="GradePoint"
                                            DataTextField="Grade" Width="61px" DataSourceID="ObjGrade">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjGrade" runat="server" SelectMethod="GetGrade" TypeName="DLRuleGrade">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="Batch" PropertyName="SelectedValue"
                                                    Type="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="61px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlSubCategory" runat="server" DataSourceID="ObjSubCategory"
                                            DataTextField="SubCategoryName" DataValueField="SubCategoryNo" SkinID="ddlRsz"
                                            TabIndex="4" Width="117">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSubCategory" runat="server" SelectMethod="GetSubjectCategory1"
                                            TypeName="DLRuleGrade"></asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="122px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue2" runat="server" Width="60px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="center" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderStyle-Width="10px">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblSelect1" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>--%>
                                        <asp:CheckBox ID="ChkBx3" runat="server" TabIndex="4"></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView3" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100" ShowHeader="false">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="OR" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                                Visible="false"></asp:Label>
                                            <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check7">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AND">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBx2" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check8">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" Width="26px" HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Assessment">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmval1" runat="server" Text='' Width="162px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="162px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options From">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbloption1" runat="server" Text='<%# Bind("Option1") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="150px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options To">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloption2" runat="server" Text='<%# Bind("Option2") %>' Width="162px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="152px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria1" runat="server" Text='<%# Bind("Criteria1") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue1" runat="server" Width="61px" SkinID="txtRsz"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="55px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria2" runat="server" Text='<%# Bind("Criteria2") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue2" runat="server" Width="60px" SkinID="txtRsz"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="10px">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblSelect1" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>--%>
                                        <asp:CheckBox ID="ChkBx3" runat="server" TabIndex="4"></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView4" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100" ShowHeader="false">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="OR" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                                Visible="false"></asp:Label>
                                            <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check9">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AND">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBx2" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check10">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" Width="26px" HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Assessment">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                            DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="150px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                            TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="155px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options From">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbSemester1" TabIndex="3" runat="server" DataValueField="SemCode"
                                            DataTextField="SemName" DataSourceID="ObjSemester1" Width="138px" Wrap="True"
                                            BorderWidth="1px" BorderStyle="Solid" Font-Names="Arial" Font-Size="Small" ForeColor="Black" SkinID="ddlRsz">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSemester1" runat="server" SelectMethod="SemesterCombo1"
                                            TypeName="FeeCollectionBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="148px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options To">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbSemester2" TabIndex="3" runat="server" DataValueField="SemCode"
                                            DataTextField="SemName" DataSourceID="ObjSemester2" Width="150px" Wrap="True"
                                            BorderWidth="1px" BorderStyle="Solid" Font-Names="Arial" Font-Size="Small" ForeColor="Black" SkinID="ddlRsz">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSemester2" runat="server" SelectMethod="SemesterCombo1"
                                            TypeName="FeeCollectionBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="148px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblcriteria1" runat="server" Text='<%# Bind("Criteria1") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbGrade" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="GradePoint"
                                            DataTextField="Grade" Width="61px" DataSourceID="ObjGrade">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjGrade" runat="server" SelectMethod="GetGrade" TypeName="DLRuleGrade">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="Batch" PropertyName="SelectedValue"
                                                    Type="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="55px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria2" runat="server" Text='<%# Bind("Criteria2") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue2" runat="server" Width="60px" SkinID="txtRsz"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="10px">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblSelect1" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>--%>
                                        <asp:CheckBox ID="ChkBx3" runat="server" TabIndex="4"></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView6" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100" ShowHeader="false">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="OR" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                                Visible="false"></asp:Label>
                                            <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check9">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AND">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBx2" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check10">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" Width="26px" HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Assessment">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                            DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="150px">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                            TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="155px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options From">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbSemester1" TabIndex="3" runat="server" DataValueField="SemCode"
                                            DataTextField="SemName" DataSourceID="ObjSemester1" Width="138px" Wrap="True"
                                            BorderWidth="1px" BorderStyle="Solid" Font-Names="Arial" Font-Size="Small" ForeColor="Black" SkinID="ddlRsz">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSemester1" runat="server" SelectMethod="SemesterCombo1"
                                            TypeName="FeeCollectionBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="148px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options To">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbSemester2" TabIndex="3" runat="server" DataValueField="SemCode"
                                            DataTextField="SemName" DataSourceID="ObjSemester2" Width="150px" Wrap="True"
                                            BorderWidth="1px" BorderStyle="Solid" Font-Names="Arial" Font-Size="Small" ForeColor="Black" SkinID="ddlRsz">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjSemester2" runat="server" SelectMethod="SemesterCombo1"
                                            TypeName="FeeCollectionBL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                                    DbType="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="148px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblcriteria1" runat="server" Text='<%# Bind("Criteria1") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbGrade" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="GradePoint"
                                            DataTextField="Grade" Width="61px" DataSourceID="ObjGrade">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjGrade" runat="server" SelectMethod="GetGrade" TypeName="DLRuleGrade">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="Batch" PropertyName="SelectedValue"
                                                    Type="Int16" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="55px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria2" runat="server" Text='<%# Bind("Criteria2") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue2" runat="server" Width="60px" SkinID="txtRsz"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="10px">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblSelect1" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>--%>
                                        <asp:CheckBox ID="ChkBx3" runat="server" TabIndex="4"></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <asp:GridView ID="GridView5" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100" ShowHeader="false">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="OR" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                                Visible="false"></asp:Label>
                                            <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check3" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AND">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBx2" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check4">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" Width="26px" HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Assessment">
                                    <ItemTemplate>
                                    <asp:Label ID="lblmval1" runat="server" Text='' Width="162px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="162px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option From">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lbloptions1" runat="server" Text='<%# Bind("Option1") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="151px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option To">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloptions2" runat="server" Text='<%# Bind("Option2") %>' Width="162px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="151px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria1" runat="server" Text='<%# Bind("Criteria1") %>' Width="50.8px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue1" runat="server" Width="61px" SkinID="txtRsz"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="55px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria2" runat="server" Text='<%# Bind("Criteria2") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue2" runat="server" Width="60px" SkinID="txtRsz"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                            Format="dd/MM/yyyy" TargetControlID="txtvalue2" Enabled="True">
                                        </ajaxToolkit:CalendarExtender>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="10px">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblSelect1" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>--%>
                                        <asp:CheckBox ID="ChkBx3" runat="server" TabIndex="4"></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100" ShowHeader="false">
                            <Columns>
                                <%--<asp:TemplateField HeaderText="OR" HeaderStyle-Width="10px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                                Visible="false"></asp:Label>
                                            <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check3" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AND">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBx2" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check4">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="True" Width="26px" HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Assessment">
                                    <ItemTemplate>
                                    <asp:Label ID="lblmval1" runat="server" Text='' Width="162px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="162px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option From">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmval" runat="server" Text='<%# Bind("value") %>' Width="150px"
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lbloptions1" runat="server" Text='<%# Bind("Option1") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="151px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option To">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloptions2" runat="server" Text='<%# Bind("Option2") %>' Width="162px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="160px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria1" runat="server" Text='<%# Bind("Criteria1") %>' Width="50.8px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue1" runat="server" Width="61px" SkinID="txtRsz"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="55px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Criteria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcriteria2" runat="server" Text='<%# Bind("Criteria2") %>' Width="50px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtvalue2" runat="server" Width="60px" SkinID="txtRsz"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="60px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="10px">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblSelect1" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>--%>
                                        <asp:CheckBox ID="ChkBx3" runat="server" TabIndex="4"></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <%--<br />
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
                    <br />
                    <div id="Div1" runat="server" style="float: left; width: 45px">
                        
                    </div>--%>
                </asp:Panel>
            </center>
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="lbloption2" runat="server" Text="Option 2 &nbsp;:&nbsp;&nbsp;" SkinID="lblrsz"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnRun" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Text="RUN FORMULA TBL"
                            TabIndex="8" Width="180px" Visible="true" OnClientClick="return Validate();" />
                        <%-- <asp:ObjectDataSource ID="ObjFormulaGroup" runat="server" SelectMethod="Formulagroup"
                                TypeName="BLClientContractMaster"></asp:ObjectDataSource>--%>
                    </td>
                </tr>
            </table>
            <hr />
            <center>
                <div id="Div2" runat="server" style="float: left; width: 800px">
                    <asp:Panel ID="panel4" runat="server" ScrollBars="Auto" Height="200px" Width="800px"
                        Visible="false">
                        <asp:GridView ID="GridRun" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                            AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100">
                            <Columns>
                                <asp:TemplateField HeaderText="OR" HeaderStyle-Width="10px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBx1" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check1"
                                            Checked='<%# Bind("Check1") %>'></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AND">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBx2" runat="server" TabIndex="4" AutoPostBack="true" OnCheckedChanged="check2"
                                            Checked='<%# Bind("Check2") %>'></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Run">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRun" runat="server" Text='<%# Bind("Run") %>' Width="30px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="30px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rules">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRules" runat="server" Text='<%# Bind("Rule") %>' Width="30px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="30px" HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assessment" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssessment" runat="server" Text='<%# Bind("Assessment") %>' Width="150px"></asp:Label>
                                        <asp:Label ID="lblAssessmentid" runat="server" Text='<%# Bind("Assessmentid") %>'
                                            Width="150px" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="150px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options From" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloptions1" runat="server" Text='<%# Bind("Options1") %>' Width="145px"></asp:Label>
                                        <asp:Label ID="lbloptions1id" runat="server" Text='<%# Bind("Options1id") %>' Width="150px"
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="145px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Options To" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloptions2" runat="server" Text='<%# Bind("Options2") %>' Width="145px"></asp:Label>
                                        <asp:Label ID="lbloptions2id" runat="server" Text='<%# Bind("Options2id") %>' Width="150px"
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="145px" HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblval1" runat="server" Text='<%# Bind("Value1") %>' Width="70px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" Width="70px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblval2" runat="server" Width="70px" Text='<%# Bind("Value2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" Width="70px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <table>
                    <tr>
                        <td colspan="30" align="right">
                            <asp:Button ID="btnsaveFormula" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                Text="SAVE FORMULA" TabIndex="8" Width="180px" Visible="true" OnClientClick="return confirm('Do you want to Save Rules ,this will replace previously saved Rules ?');" />
                            <%-- <asp:ObjectDataSource ID="ObjFormulaGroup" runat="server" SelectMethod="Formulagroup"
                                TypeName="BLClientContractMaster"></asp:ObjectDataSource>--%>
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Label ID="lblcorrect" runat="server" SkinID="lblGreen"></asp:Label>
                    <asp:Label ID="lblerror" runat="server" SkinID="lblRed" />
                </center>
                <center>
                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </center>
                <%-- <asp:ObjectDataSource ID="objelective" runat="server" SelectMethod="ddlelective"
                            TypeName="DLSelectElective"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="objoption" runat="server" SelectMethod="ddloption" TypeName="DLSelectElective">
                        </asp:ObjectDataSource>--%>
                <%--<br />--%>
                <hr />
                <table>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnLoad" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Text="LOAD"
                                TabIndex="8" Width="100px" Visible="true" OnClientClick="return Validate();" />
                        </td>
                        <td align="center">
                            <asp:TextBox ID="txtDivision" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlcolumn" TabIndex="4" runat="server" SkinID="ddlRsz" DataTextField="COLUMN_NAME"
                                DataValueField="column_id" DataSourceID="ObjColumn" Width="150px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjColumn" runat="server" SelectMethod="GetColumn" TypeName="DLRuleGrade">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                Text="UPDATE" TabIndex="8" Width="100px" Visible="true" OnClientClick="return Validate1();" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSave" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Text="SAVE"
                                TabIndex="8" Width="100px" Visible="true" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnClear" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Text="CLEAR"
                                TabIndex="8" Width="100px" Visible="true" OnClientClick="return Validate();" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnExport" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                Text="EXPORT" TabIndex="8" Width="100px" Visible="true" OnClientClick="return Validate();" />
                        </td>
                    </tr>
                </table>
                <hr />
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Height="200px" Width="700px">
                    <asp:GridView ID="GridStud" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                        AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100">
                        <Columns>
                            <asp:TemplateField HeaderText="Student Code" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblstudcode" runat="server" Text='<%# Bind("StdCode") %>' Width="100px"></asp:Label>
                                    <asp:Label ID="lblStdid" Visible="false" runat="server" Text='<%# Bind("StdID") %>'></asp:Label>
                                    <%--<asp:Label ID="lblBatchid" Visible="false" runat="server" Text='<%# Bind("BatchId") %>'></asp:Label>--%>
                                    <%--<asp:Label ID="lblsemid" Visible="false" runat="server" Text='<%# Bind("SemId") %>'></asp:Label>--%>
                                </ItemTemplate>
                                <ItemStyle Wrap="True" HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Name" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblstudname" runat="server" Text='<%# Bind("StdName") %>' Width="350px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="True" HorizontalAlign="left" />
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Total Marks">
                                <ItemTemplate>
                                    <asp:Label ID="lbltotmarks" runat="server" Text='<%# Bind("TotalMarks") %>' Width="50px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="True" Width="50px" HorizontalAlign="right" />
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Total Credit Point">
                                <ItemTemplate>
                                    <asp:Label ID="lblcredit" runat="server" Text='<%# Bind("CreditTotal") %>' Width="50px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="True" Width="50px" HorizontalAlign="right" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="CGPA">
                                <ItemTemplate>
                                    <asp:Label ID="lblcgpa" runat="server" Text='<%# Bind("CGPA1") %>' Width="50px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Division">
                                <ItemTemplate>
                                    <asp:Label ID="lbldiv" runat="server" Width="50px" Text='<%# Bind("Division") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grade">
                                <ItemTemplate>
                                    <asp:Label ID="lblgrade" runat="server" Width="50px" Text='<%# Bind("Grade") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="True" Width="50px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
