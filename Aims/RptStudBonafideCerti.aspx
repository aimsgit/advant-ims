<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStudBonafideCerti.aspx.vb"
    Inherits="RptStudBonafideCerti" Title="Student Bonafide Certificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Bonafide Certificate</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Labelsbc" runat="server" Text="STUDENT BONAFIDE CERTIFICATE" SkinID="lblRepRsz" Width="400" Visible="True"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranch" runat="server" SkinID="lbl" Text="Branch* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLBranch" runat="server" SkinID="ddlL" Width="250" DataSourceID="ObjBranch"
                                        DataTextField="BranchName" DataValueField="BranchCode" AutoPostBack="True" TabIndex="1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblA_Year" runat="server" Text="Academic Calender Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="250px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLA_Year" runat="server" SkinID="ddlRsz" DataSourceID="ObjYear"
                                        DataTextField="AcademicYear" DataValueField="A_Code" AutoPostBack="True" TabIndex="2"
                                        Width="200">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text=" Course* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLCourse" runat="server" SkinID="ddlRsz" DataSourceID="ObjCourse"
                                        DataTextField="CourseName" DataValueField="CourseCode" AutoPostBack="True" TabIndex="3"
                                        Width="200">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLBatch" runat="server" SkinID="ddlRsz" DataSourceID="ObjBatch"
                                        DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="4"
                                        Width="200">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCountry" runat="server" SkinID="lbl" Text="Country :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLCountry" runat="server" SkinID="ddlRsz" DataSourceID="ObjCountry"
                                        DataTextField="Country" AutoPostBack="true" TabIndex="5" Width="200">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStud" runat="server" SkinID="lbl" Text="Student :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStudent" runat="server" SkinID="ddlRsz" DataSourceID="ObjStudent"
                                        DataTextField="StdName" DataValueField="STD_ID" AppendDataBoundItems="False"
                                        AutoPostBack="true" TabIndex="6" Width="200">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblIncludeHeader" runat="server" SkinID="lbl" Text="Include Header :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="ChkBoxHeader" SkinID="chk" TabIndex="7" runat="server" Checked="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="btnTd">
                                    <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT"
                                        CommandName="REPORT" TabIndex="8" />
                                    <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK" CommandName="BACK"
                                        TabIndex="9" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <div>
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label></div>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="SelectBranch" TypeName="DLBranchAccessLevel"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="SelectCourse" TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLBranch" Name="BranchCode" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjYear" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="SelectAcademicYear1" TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="SelectBatch" TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="DDLA_Year" Name="Aid" Type="Int32" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="DDLCourse" Name="CourseID" Type="Int32" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjCountry" runat="server" SelectMethod="SelectCountry"
                                        TypeName="DLReportsR"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo1"
                                        TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLBranch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="DDLBatch" Name="Batch" Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
