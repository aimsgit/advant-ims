<%@ Page Title="Feedback Report" Language="VB" AutoEventWireup="false"
    CodeFile="RptFeedBack.aspx.vb" Inherits="RptFeedBack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Feedback Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                        <br />
                       <h1 class="headingTxt">
                            <asp:Label ID="Lblfeedback" runat="server" Text="STUDENT'S FEEDBACK ON TEACHING FACULTY" SkinID="lblRepRsz"
                                Width="520" Visible="True"></asp:Label>
                        </h1>
                        <br />
                        <br />
                </center>
            </div>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblbatch" runat="server" Text="Batch :&nbsp;" SkinID="lblRsz" Width="100px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlbatch" runat="server" DataSourceID="odsbatch" SkinID="ddlRsz"
                                DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="true" Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsbatch" runat="server" SelectMethod="FeedBackBatchDDL"
                                TypeName="FeedbackReportDL"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSemester" runat="server" Text="Semester&nbsp;:&nbsp;" SkinID="lbl"
                                Width="100px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSemester" runat="server" SkinID="ddlRsz" DataSourceID="ObjSemester"
                                DataTextField="SemName" DataValueField="SemCode"  Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSemester" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FeedBackSemesterDDL" TypeName="FeedbackReportDL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" Name="BatchID" Type="Int32" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        </tr>
                        <tr>
                        <td align="right">
                            <asp:Label ID="lbl" runat="server" Text="Faculty&nbsp;:&nbsp;" SkinID="lbl"
                                Width="100px"></asp:Label>
                        </td>
                         <td align="left">
                            <asp:DropDownList ID="ddlFaculty" runat="server" SkinID="ddlRsz" DataSourceID="ObjFaculty"
                                DataTextField="EmpName" DataValueField="EID"  Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjFaculty" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FeedBackFacultyDDL" TypeName="FeedbackReportDL">
                                <%--<SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" Name="BatchID" Type="Int32" PropertyName="SelectedValue" />
                                </SelectParameters>--%>
                            </asp:ObjectDataSource>
                            </td> 
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align = "center ">
                            <asp:Button ID="btnReport" runat="server" Text="GENERATE REPORT" CssClass="ButtonClass" CommandName="GENERATE"
                                CausesValidation="true" SkinID="btnRsz" TabIndex="4" Width="140px" />
                            &nbsp;<asp:Button ID="BtnBack" runat="server" CausesValidation="false" Text="BACK" CssClass="ButtonClass" CommandName="BACK"
                                SkinID="btn" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <br />
            <center>
                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
