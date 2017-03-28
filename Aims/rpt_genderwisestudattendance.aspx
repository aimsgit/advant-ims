<%@ Page Language="VB" AutoEventWireup="false"   CodeFile="rpt_genderwisestudattendance.aspx.vb"
    Inherits="rpt_genderwisestudattendance" Title="Student Attendance Gender Wise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Attendance Gender Wise</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
 <script type="text/javascript" language="javascript">

        function Validate() {
            var msg = Valid();
    
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }

        function Valid() {


            var msg, a;

            msg = ValidateDateMul(document.getElementById("<%=txtFromDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtFromDate.ClientID %>").focus();
                a = document.getElementById("<%=lblDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
               return msg;
           }
           return true;
       }

       function ErrorMessage(msg) {
           var SesVar = '<%= Session("Validation") %>';
           var ValidationArray = new Array();
           ValidationArray = SesVar.split(":");
           for (var i = 0; i < ValidationArray.length - 1; i++) {
               if (ValidationArray[i] == msg) {
                   return ValidationArray[i + 1];
               }
           }
       }


       function Spliter(a) {
           var str = a;
           var n = str.indexOf("*");
           if (n != 0 && n != -1) {
               a = a.split("*");
               return a[0];
           }
           var n = str.indexOf("^");
           if (n != 0 && n != -1) {
               a = a.split("^");
               return a[0];
           }
           var n = str.indexOf(":");
           if (n != 0 && n != -1) {
               a = a.split(":");
               return a[0];
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
                        <br />
                        <h1 class="headingTxt">
                            ATTENDANCE REPORT GENDER WISE
                        </h1>
                        <br />
                        <br />
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text="Course&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="Left">
                                    <asp:DropDownList ID="ddlCourseName" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                        DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="Courseid"
                                        SkinID="ddlRsz" TabIndex="1" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetCourseName" TypeName="DL_GenderwiseStudentAttendance">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSubject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                        DataValueField="Subject_Code" SkinID="ddlRsz" TabIndex="2" Width="200">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="SubjectComboAllDDL" TypeName="DL_GenderwiseStudentAttendance">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" PropertyName="SelectedValue"
                                                Type="Int16" />
                                            
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                            <td align="right">
                                <asp:Label ID="lblDate" runat="server" Text="Date*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                             <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtRsz" Width="195" TabIndex="3"></asp:TextBox>
                            </td>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtfromdate"
                             Format="dd-MMM-yyyy" SkinID="Calendar">
                        </ajaxToolkit:CalendarExtender>
                        </tr>
                        </table>
                        </center>
                        <br />
                       
                        <center>
                        <table >
                            <tr>
                                <td class="btnTd">
                                    <asp:Button ID="btnReport" TabIndex="9" OnClientClick="return Validate()" runat="server" Text="REPORT" SkinID="btn"
                                        CssClass="ButtonClass"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnBack" TabIndex="11" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                    </asp:Button>
                                </td>
                            </tr>
                        </table>
                        </center>
                        <center>
                             <br />
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                               <br />
                                 <br />
                        </center>
                    </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>

