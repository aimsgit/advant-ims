<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmNewFeeStructure.aspx.vb"
    Inherits="FrmNewFeeStructure" Title="Fee Structure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Structure</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        FEE STRUCTURE BULK ENTRY</h1>
                </center>
                <br />
                <br />
                <center>
                    <table class="StateTable">
                        <tbody>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblAcademicYear" runat="server" SkinID="lblRsz" Width="140px" Text="Academic Year* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCourseType" runat="server" SkinID="lblRsz" Width="120px" Text="Course Type :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCourseName" runat="server" SkinID="lblRsz" Width="120px" Text="Course Name :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblBatch" runat="server" SkinID="lblRsz" Width="120px" Text="Batch* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ListBox ID="ListAcademic" Height="200px" Width="120px" SelectionMode="Multiple"
                                        DataValueField="id" runat="server" TabIndex="3" DataSourceID="objAcademic" DataTextField="AcademicYear" CssClass="Listbox">
                                    </asp:ListBox>
                                </td>
                                <td>
                                    <asp:ListBox ID="ListCourseType" Height="200px" Width="120px" SelectionMode="Multiple"
                                        DataTextField="CourseType" DataValueField="CourseType_ID" runat="server" TabIndex="3"
                                        DataSourceID="ObjCourseType" CssClass="Listbox"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:ListBox ID="ListCourseName" Height="200px" Width="150px" SelectionMode="Multiple"
                                        DataValueField="Courseid" runat="server" TabIndex="3" DataSourceID="objCourse"
                                        DataTextField="CourseName" CssClass="Listbox"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:ListBox ID="ListBatch" Height="200px" Width="150px" SelectionMode="Multiple"
                                        DataValueField="BatchID" DataTextField="Batch_No" runat="server" TabIndex="3" CssClass="Listbox">
                                    </asp:ListBox>
                                </td>
                            </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDueDate" runat="server" Text="Due Date* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    meta:resourcekey="Label8Resource1"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDueDate" TabIndex="6" runat="server" SkinID="txt" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtDueDate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:MaskedEditExtender ID="Attndate" runat="server" ClearMaskOnLostFocus="false"
                                    ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                    TargetControlID="txtDueDate">
                                </ajaxToolkit:MaskedEditExtender>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <br />
                        <tr>
                            <asp:Button ID="BtnSelectBranch" TabIndex="3" runat="server" Text="SELECT BATCHES"
                                CausesValidation="True" SkinID="btnRsz" OnClientClick="return Validate();" CssClass="ButtonClass"
                                Width="150"></asp:Button>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <br />
                                <asp:Button ID="BtnSave" TabIndex="3" runat="server" Text="ADD" CausesValidation="True"
                                    SkinID="btnRsz" OnClientClick="return Validate();" CssClass="ButtonClass" Width="113">
                                </asp:Button>
                                &nbsp;<asp:Button ID="BtnDetails" TabIndex="4" runat="server" Text="VIEW" CausesValidation="False"
                                    SkinID="btn" CssClass="ButtonClass"></asp:Button>
                                &nbsp;<asp:Button ID="BtnClear" TabIndex="4" runat="server" Text="CLEAR FEE STRUCTURE"
                                    CausesValidation="False" SkinID="btnRsz" CssClass="ButtonClass" Width="170"></asp:Button>
                                &nbsp;<asp:Button ID="BtnClearGrid" TabIndex="4" runat="server" Text="CLEAR" CausesValidation="False"
                                    SkinID="btn" CssClass="ButtonClass"></asp:Button>
                    </table>
                </center>
                <div>
                    &nbsp;</div>
                <center>
                    <div>
                        <asp:Label ID="msginfo" runat="server" EnableTheming="True" SkinID="lblRed"></asp:Label>
                        <asp:Label ID="lblmsg" runat="server" EnableTheming="true" SkinID="lblGreen"></asp:Label>
                    </div>
                    <div>
                        &nbsp;</div>
                    <div>
                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="600px">
                            <asp:GridView ID="GVCategory" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                                AllowPaging="True" PageSize="100">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="t2" runat="server" Text='<%# Bind("A") %>' Width="155" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat1" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsCategory" runat="server" SelectMethod="getCategory"
                                                TypeName="feeStructureDL"></asp:ObjectDataSource>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat2" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat3" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat4" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat5" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat6" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat7" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat8" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat9" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat10" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat11" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat12" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat13" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat14" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlcat15" runat="server" SkinID="ddlRsz" TabIndex="4" DataSourceID="odsCategory"
                                                DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True"
                                                Width="120">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                                AllowPaging="True" PageSize="100">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fee Heads">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeeId" runat="server" Text='<%# Bind("FeeHead") %>' Visible="false" />
                                            <asp:DropDownList ID="ddlfee_head" runat="server" SkinID="ddl" TabIndex="5" DataSourceID="odsfeehead"
                                                DataTextField="Fee_HeadType" DataValueField="Fee_Head_IDAuto" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsfeehead" runat="server" SelectMethod="GetFeeHeads" TypeName="feeStructureDL">
                                            </asp:ObjectDataSource>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee1" runat="server" Text='<%# Bind("[1]") %>' Width="113"  SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee2" runat="server" Text='<%# Bind("[2]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee3" runat="server" Text='<%# Bind("[3]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee4" runat="server" Text='<%# Bind("[4]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee5" runat="server" Text='<%# Bind("[5]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee6" runat="server" Text='<%# Bind("[6]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee7" runat="server" Text='<%# Bind("[7]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee8" runat="server" Text='<%# Bind("[8]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee9" runat="server" Text='<%# Bind("[9]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee10" runat="server" Text='<%# Bind("[10]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee11" runat="server" Text='<%# Bind("[11]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee12" runat="server" Text='<%# Bind("[12]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee13" runat="server" Text='<%# Bind("[13]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee14" runat="server" Text='<%# Bind("[14]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFee15" runat="server" Text='<%# Bind("[15]") %>' Width="113" SkinID="txtRsz"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo1"
                        TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjCourseType" runat="server" TypeName="CourseDB" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetCourseTypeExt"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="objcourse" runat="server" SelectMethod="GetDtaCourseFee" TypeName="CourseDB">
                    </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
