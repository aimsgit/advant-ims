<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmEnrollmentReg.aspx.vb"
    Inherits="frmEnrollmentReg" Title="Final Examination Result" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Final Examination Result</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
   
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            FINAL EXAMINATION RESULT</h1>
                        <br>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right" style="width: 924px">
                                    <asp:Label ID="lblBranchType" runat="server" Text="Branch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranchName" TabIndex="2" runat="server" SkinID="ddlL" AutoPostBack="True"
                                        DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 924px">
                                    <asp:Label ID="lblCourse" runat="server" Text="Course*&nbsp;:&nbsp;&nbsp;" Width="100px"
                                        SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCourseName" TabIndex="2" runat="server" SkinID="ddl" AutoPostBack="True"
                                        DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="CourseCode">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 924px">
                                    <asp:Label ID="lblYear" runat="server" Text="AcademicYear*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYearName" TabIndex="2" runat="server" SkinID="ddl" AutoPostBack="True"
                                        DataSourceID="ObjYear" DataTextField="AcademicYear" DataValueField="A_Code">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 924px">
                                    <asp:Label ID="lblBatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBatchName" TabIndex="2" runat="server" SkinID="ddl" AutoPostBack="True"
                                        DataSourceID="ObjBatch" DataTextField="Batch_No" DataValueField="BatchID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 924px">
                                    <asp:Label ID="lblSemester" runat="server" Text="Semester&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="100px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSemester" TabIndex="2" runat="server" SkinID="ddl" AutoPostBack="True"
                                        DataSourceID="ObjSemester" DataTextField="SemName" DataValueField="SemCode">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 924px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnReport" OnClick="btnReport_Click" runat="server" Text="REPORT"
                                        SkinID="btn" CssClass="ButtonClass"></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" Text="BACK" SkinID="btn" 
                                        CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 924px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                    <div>
                                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                   </div>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetBranch" TypeName="StudentB"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetCourse" TypeName="StudentB">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranchName" Name="BranchCode"  Type="String" PropertyName="SelectedValue"  />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjYear" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetYear" TypeName="StudentB">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBranchName" Name="BranchCode"  Type="String" PropertyName="SelectedValue"  />
                                            <asp:ControlParameter ControlID="ddlCourseName" Name="CourseID" Type="Int32" PropertyName="SelectedValue"   />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetBatch" TypeName="StudentB">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlYearName" Name="Aid"  Type="Int32" PropertyName="SelectedValue"  />
                                            <asp:ControlParameter ControlID="ddlBranchName" Name="BranchCode"  Type="String" PropertyName="SelectedValue"  />
                                            <asp:ControlParameter ControlID="ddlCourseName" Name="CourseID"  Type="Int32" PropertyName="SelectedValue"  />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetSemester" TypeName="StudentB"></asp:ObjectDataSource>
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

