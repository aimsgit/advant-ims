<%@ Page Language="VB" MasterPageFile="~/Home.master" AutoEventWireup="false" CodeFile="RptIndStudDetails.aspx.vb"
    Inherits="RptIndStudDetails" Title="Individual Student Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            INDIVIDUAL STUDENT DETAILS
                        </h1>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranch" runat="server" SkinID="lbl" Text="Branch* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLBranch" runat="server" SkinID="ddlRsz" Width="250" DataSourceID="ObjBranch"
                                        DataTextField="BranchName" DataValueField="BranchCode" AutoPostBack="True" TabIndex="1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblA_Year" runat="server" Text="Academic Year* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLA_Year" runat="server" SkinID="ddl" DataSourceID="ObjYear"
                                        DataTextField="AcademicYear" DataValueField="A_Code" AutoPostBack="True" TabIndex="2">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text=" Course* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLCourse" runat="server" SkinID="ddl" DataSourceID="ObjCourse"
                                        DataTextField="CourseName" DataValueField="CourseCode" AutoPostBack="True" TabIndex="3">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLBatch" runat="server" SkinID="ddl" DataSourceID="ObjBatch"
                                        DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="4">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCountry" runat="server" SkinID="lbl" Text="Country :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLCountry" runat="server" SkinID="ddl" DataSourceID="ObjCountry"
                                        DataTextField="Country" AutoPostBack="true" TabIndex="5">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStud" runat="server" SkinID="lbl" Text="Student :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStudent" runat="server" SkinID="ddl" DataSourceID="ObjStudent"
                                        DataTextField="StdName" DataValueField="STD_ID" AppendDataBoundItems="False"
                                        AutoPostBack="true" TabIndex="6">
                                    </asp:DropDownList>
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
                                    <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text=" REPORT"
                                        TabIndex="7" />
                                    <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" Text="BACK"
                                        TabIndex="8" />
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
                                        SelectMethod="SelectBranch" TypeName="DLReportsR"></asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="SelectCourse" TypeName="DLReportsR">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DDLBranch" Name="BranchCode" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjYear" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="SelectAcademicYear" TypeName="DLReportsR"></asp:ObjectDataSource>
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
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                        TypeName="DLReportsR">
                                        <SelectParameters>
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
</asp:Content>
