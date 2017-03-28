<%@ Page Title="Student ID Card" Language="VB" AutoEventWireup="false" CodeFile="frmStudentIDCard.aspx.vb" Inherits="frmStudentIDCard" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student ID Card</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script language="JavaScript" type="text/javascript">

        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlCourseName.ClientID %>"), 'Course');
            if (msg != "") {
                document.getElementById("<%=ddlCourseName.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlBatch.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID %>").focus();
                return msg;
            }
        }
        function Validate() {
            var msg = Valid();
            if (msg == undefined) {
                return true;
            }
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    return false;
                }
            }
            
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            STUDENT ID CARD</h1>
                        <br>
                    </center>
                    <center>
                        <table class="custTable">
                           
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                          
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" Text="Course*&nbsp;:&nbsp;&nbsp;" Width="100px"
                                        SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourseName" TabIndex="4" runat="server" SkinID="ddlRsz"
                                        AutoPostBack="True" DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="Courseid"
                                        Width="200">
                                        
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetCourseCombo" TypeName="DLStudentIDCard">
                                </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" DataSourceID="ObjBatch"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="1"
                                    Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLStudentIDCard">
                                 <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" runat="server" Text="Student Name&nbsp;:&nbsp;&nbsp;" width="120px" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" DataSourceID="ObjStudent"
                                    DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="2"
                                     Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                    TypeName="DLStudentIDCard">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatch" Name="BatchID" Type="Int16" PropertyName="SelectedValue" />
                                         <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                     
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        
                        
                          <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnCreate" runat="server" TabIndex="10" Text="CREATE" SkinID="btn"
                                        CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>&nbsp;
                                    <asp:Button ID="btnBack" runat="server" TabIndex="11" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
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
                     </ContentTemplate>
        </asp:UpdatePanel>


</form>
</body>
</html>

