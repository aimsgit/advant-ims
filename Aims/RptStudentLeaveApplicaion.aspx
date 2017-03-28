<%@ Page Language="VB" MasterPageFile="~/Home.master" AutoEventWireup="false" CodeFile="RptStudentLeaveApplicaion.aspx.vb"
    Inherits="RptStudentLeaveApplicaion" Title="Student Leave Application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DdlBatchPlanner.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=DdlBatchPlanner.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
        
    </script>

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <div>
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server" Text="STUDENT LEAVE DETAILS"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="LblBatch" runat="server" Text="Select Batch*  :&nbsp;" SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DdlBatchPlanner" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="1" AppendDataBoundItems="true" DataValueField="BatchID" DataTextField="Batch_No"
                                        DataSourceID="objBatchPlanner" Width="254px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objBatchPlanner" runat="server" SelectMethod="getBatchPlannerComboSelect"
                                        TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSemester" runat="server" DataSourceID="ObjSemester" DataTextField="SemName"
                                        DataValueField="SemCode" SkinID="ddl" TabIndex="6">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemComboBasedonBatch"
                                        TypeName="DLNewCoursePlanner">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DdlBatchPlanner" PropertyName="SelectedValue" Name="BatchID"
                                                DbType="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudent" runat="server" Text="Student :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlStudent" runat="server" DataSourceID="ObjStudent" DataTextField="StdName"
                                        DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="2" AppendDataBoundItems="False"
                                        Width="240">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo1"
                                        TypeName="StudentPerformanceDL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DdlBatchPlanner" Name="Batch" Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnDetails" runat="server" CausesValidation="True" SkinID="btn" Text="REPORT"
                                        CssClass="ButtonClass" TabIndex="7" OnClientClick="return Validate();" />
                                    <asp:Button ID="btnback" runat="server" SkinID="btn" Text="BACK" CssClass="ButtonClass"
                                        TabIndex="8" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                                    <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <a name="bottom">
                        <div align="right">
                            <a href="#top">
                                <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                        </div>
                    </a>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
