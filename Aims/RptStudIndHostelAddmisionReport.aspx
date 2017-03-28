<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptStudIndHostelAddmisionReport.aspx.vb" 
Inherits="RptStudIndHostelAddmisionReport" Title ="Student Individual Hostel Addmission Details Report"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Individual Hostel Addmission Details Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />


    &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        STUDENT INDIVIDUAL HOSTEL ADDMISSION DETAILS
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourse" runat="server" DataTextField="Batch_No" DataSourceID="ObjBatch"
                                        DataValueField="BatchID" SkinID="ddl" TabIndex="1" AppendDataBoundItems="True"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetBatchDDL" TypeName="WelfareActivityDL"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatch" runat="server" DataTextField="Data" DataSourceID="ObjScholarship"
                                        DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="2" AppendDataBoundItems="True"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjScholarship" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetScholarshipDDL" TypeName="WelfareActivityDL"></asp:ObjectDataSource>
                                </td>
                            </tr>
                             <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudentName" runat="server" Text="Student Name :&nbsp;&nbsp;" SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlStudentName" runat="server" DataTextField="Data" DataSourceID="ObjScholarship"
                                        DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="2" AppendDataBoundItems="True"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetScholarshipDDL" TypeName="WelfareActivityDL"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <center>
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="4"
                                            Text="REPORT" Width="80px" />
                                        <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            TabIndex="5" Text="BACK" Width="100px" />
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <center>
                            <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                        </center>


                   <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="Images/top.png" Width="30px" />
                        </a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
                </asp:Panel> 
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

 