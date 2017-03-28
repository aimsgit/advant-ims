<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmStudentTransfer.aspx.vb"
    Inherits="FrmStudentTransfer" Title="Student Transfer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Transfer</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div>
        <center>
            <h1 class="headingTxt">
                STUDENT TRANSFER
            </h1>
        </center>
        </br>
        <asp:Panel ID="ControlsPanel" runat="server">
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbldate" runat="server" Text="Transfer Date :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="200"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTDate" runat="server" SkinID="txt" TabIndex="25"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="EDate" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtTDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="From Course*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFromCourse" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="ObjCourse1" DataTextField="CourseName" DataValueField="Courseid"
                                SkinID="ddl" TabIndex="1">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="From Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFromBatch" runat="server" AutoPostBack="true" DataSourceID="ObjFromBatch"
                                DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddl" TabIndex="2">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Student Code*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlStdCode" runat="server" DataSourceID="Objstd"
                                DataTextField="StdName" DataValueField="StdId" SkinID="ddl" TabIndex="2">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </center>
            <hr />
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="To Branch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlToBrch" runat="server" AutoPostBack="True" DataSourceID="ObjToBranch"
                                DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddl" TabIndex="3">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Academic Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                Style="margin-left: 0px" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbAcademic" TabIndex="1" runat="server" SkinID="ddl" AutoPostBack="True"
                                DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" SkinID="lblRsz" Text="To Course*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlToCourse" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="ObjCourse1" DataTextField="CourseName" DataValueField="Courseid"
                                SkinID="ddl" TabIndex="3">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Text="To Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlToBatch" runat="server" AutoPostBack="true" DataSourceID="ObjToBatch"
                                DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddl" TabIndex="4">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                     </table>
                    <table>
                        <tr>
                            <td align="center" class="btnTd">
                                <asp:Button ID="BtnSave" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" Text="SUBMIT" TabIndex="5" />
                                &nbsp;<asp:Button ID="BtnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" Text="VIEW" TabIndex="6" />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <center>
                                    <asp:Label ID="msginf" runat="server" SkinID="lblRed"></asp:Label>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                </center>
                            </td>
                        </tr>
                    </table>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Auto" Width="250px">
                                <asp:GridView ID="GVStdTransfer" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Student Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStdCode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                                <asp:HiddenField ID="STD_ID" runat="server" Value='<%# Bind("STD_ID") %>' />
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("StdId") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Batch">
                                            <ItemTemplate>
                                                <asp:Label ID="BID" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To Batch">
                                            <ItemTemplate>
                                                <asp:Label ID="BID" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To Branch">
                                            <ItemTemplate>
                                                <asp:Label ID="BID" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <asp:ObjectDataSource ID="ObjToBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetBranchTypecombo" TypeName="EmpTranferB"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                        TypeName="DLNew_StudentMarks"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="GetDtaCourse"
                        TypeName="CourseDB"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDtaCourse"
                        TypeName="CourseDB"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjToBatch" runat="server" SelectMethod="BatchComboD" TypeName="DLRollOver">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlToCourse" DefaultValue="0" Name="Courseid" PropertyName="SelectedValue"
                                Type="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjFromBatch" runat="server" SelectMethod="BatchComboD"
                TypeName="DLRollOver">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlFromCourse"  Name="Courseid" DefaultValue="0"
                        PropertyName="SelectedValue" Type="Int16" />
                </SelectParameters>
            </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="Objstd" runat="server" SelectMethod="StudentComboD" TypeName="DLRollOver">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlFromBatch" Name="BatchID" PropertyName="SelectedValue"
                                Type="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
             
            </center>
        </asp:Panel>
    </div>

</form>
</body>
</html>
