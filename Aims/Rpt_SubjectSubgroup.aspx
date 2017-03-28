<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Rpt_SubjectSubgroup.aspx.vb" Inherits="Rpt_SubjectSubgroup" Title="Subject Subgroup Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Subject Subgroup Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <script type="text/javascript" language="javascript">
 function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlBatch.ClientID%>"), 'Batch');
//            document.getElementById("<%=ddlBatch.ClientID%>").focus();
            if (msg != "") {
             document.getElementById("<%=ddlBatch.ClientID%>"); 
            return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbSemester.ClientID%>"), 'Semester');
//            document.getElementById("<%=cmbSemester.ClientID%>").focus();
            if (msg != ""){
             document.getElementById("<%=cmbSemester.ClientID%>"); 
            return msg;
        }
        msg = DropDownForZero(document.getElementById("<%=cmbSubject.ClientID%>"), 'Subject');
        //            document.getElementById("<%=cmbSemester.ClientID%>").focus();
        if (msg != "") {
            document.getElementById("<%=cmbSubject.ClientID%>");
            return msg;
        }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").innerText = msg;
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
            
            <div>
                <center>
                   <br />
                    <h1 class="headingTxt">
                      SUBJECT SUBGROUP REPORT
                    </h1>
                </center>

                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="1" AppendDataBoundItems="true" DataValueField="BatchID" DataTextField="Batch_No"
                                        DataSourceID="objBatchPlanner" Width="240px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objBatchPlanner" runat="server" SelectMethod="getBatchPlannerComboSelect"
                                        TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSemester" TabIndex="2" runat="server" SkinID="ddlRsz" DataValueField="SemCode"
                                        DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="true" Width="240">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objsemester" runat="server" SelectMethod="SemesterCombo1"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatch" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >
                                    <asp:Label ID="Label9" runat="server" Text="Subject* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSubject" TabIndex="3" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                        DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="240" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td><td>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner2"
                                    TypeName="DLNew_StudentMarks">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                </td>
                            </tr>
                             <tr>
                                <td align="right" >
                                    <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Width="200" Text="Subject Subgroup :&nbsp;&nbsp;" ></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSubjectSubGrp"  TabIndex="4" runat="server" DataSourceID="ObjSubjectSubGrp"
                                        DataTextField="SubGroup_Name" DataValueField="SubGrp_Auto_Id" SkinID="ddlRsz"
                                        Width="240" >
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubjectSubGrp" runat="server" SelectMethod="RptSubjSubgrpMap"
                                        TypeName="DLSubjectSubGrpMapping">
                                        <SelectParameters>
                                        <asp:ControlParameter ControlID="cmbSubject" DefaultValue="0" Name="SubjectId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        </SelectParameters>
                                        </asp:ObjectDataSource>
                                </td>
                                </tr>
                    <caption>
                    <br />
                    <br />
                    </caption>
                    </table>
                    </center>
                   <center>
                <table>
                    <tr align="center">
                        <td class="btnTd" colspan="3">
                            <br />
                            <asp:Button ID="btnReport"  TabIndex="5" runat="server" CausesValidation="true" CommandName="Report"
                                CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn"
                                Text="REPORT" />
                            &nbsp;<asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                            </asp:Button>
                    </tr>
                </table>
            </center>
            <center>
                <br />
                 <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                <br />
            </center>
            </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>

