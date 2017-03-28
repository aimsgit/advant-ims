<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmStudentLogBook.aspx.vb"
    Inherits="FrmStudentLogBook" Title="STUDENT LOG BOOK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STUDENT LOG BOOK</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        //Function for Multilingual Validations
        //Created By Niraj
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
        function Valid() {
            var msg;
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>").focus();
                a = document.getElementById("<%=lblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlStudent.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=ddlStudent.ClientID%>").focus();
                a = document.getElementById("<%=lblStudent.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=DdlLecture.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=DdlLecture.ClientID%>").focus();
                a = document.getElementById("<%=LblFaculty.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlLogtype.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=ddlLogtype.ClientID%>").focus();
                a = document.getElementById("<%=LblLogType.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = ValidateDateMul(document.getElementById("<%=Txtdate.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=Txtdate.ClientID%>").focus();
                a = document.getElementById("<%=Lbldate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field250Mul(document.getElementById("<%=TxtFeedback.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=TxtFeedback.ClientID%>").focus();
                a = document.getElementById("<%=Lblfeedback.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }
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
        
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <br />
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" Text="Batch*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" DataSourceID="ObjBatch"
                                    DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="1"
                                    AppendDataBoundItems="True" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLStudentLogBook">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudent" runat="server" Text="Student Name*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" DataSourceID="ObjStudent"
                                    DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="2"
                                    AppendDataBoundItems="False" Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                    TypeName="DLStudentLogBook">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatch" Name="Batch" Type="Int16" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblFaculty" runat="server" Text="Faculty Name*^&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="DdlLecture" runat="server" SkinID="ddlRsz" Width="200px" TabIndex="3"
                                    AppendDataBoundItems="true" DataValueField="Emp_Code" DataTextField="Emp_Name"
                                    DataSourceID="objLecturer">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objLecturer" runat="server" SelectMethod="GetLecturercombo"
                                    TypeName="BLStudentLogBook"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblLogType" runat="server" SkinID="lblRsz" Text="Log Type*^&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlLogtype" runat="server" DataSourceID="ObjDept" DataTextField="LogType"
                                    DataValueField="Log_AutoID" SkinID="ddlRsz" Width="200px" TabIndex="4">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="DLStudentLogBook" SelectMethod="GetLogType">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lbldate" runat="server" Text="Date*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtdate" runat="server" SkinID="txtRsz" MaxLength="11" Width="198px"
                                    TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="Txtdate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblfeedback" runat="server" SkinID="lbl" Text="Feedback*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtFeedback" runat="server" SkinID="txtRsz" TextMode="MultiLine"
                                    Width="198px" Height="50px" TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                </center>
                </table>
                <center>
                    <table>
                        <tr>
                            <td colspan="2"align="center">
                                <br />
                                <br />
                                <asp:Button ID="btnadd" runat="server" SkinID="btn" CausesValidation="True" Text="ADD"
                                    CommandName="ADD" TabIndex="7" CssClass="ButtonClass" OnClientClick="return Validate();">
                                </asp:Button>&nbsp;
                                <asp:Button ID="btndetails" runat="server" SkinID="btn" CausesValidation="False"
                                    CommandName="VIEW" Text="VIEW" TabIndex="8" CssClass="ButtonClass"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                    <asp:GridView ID="GVLogBook" runat="server" SkinID="gridview" AllowPaging="True"
                                        AutoGenerateColumns="False" Style="margin-right: 0px" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" Font-Underline="False"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" Visible="True" Font-Underline="False">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false"></ItemStyle>
                                                <ItemStyle HorizontalAlign="Left" Font-Underline="False" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ControlStyle Font-Underline="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("Std_LogBook_AutoId") %>' />
                                                    <asp:Label ID="lbl1" runat="server" Width="80px" Text='<%# Bind("Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Log Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl2" runat="server" Width="140px" Text='<%# Bind("LogType") %>'></asp:Label>
                                                    <asp:Label ID="LblLog" Visible="false" runat="server" Text='<%# Bind("LogTypeID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Batch" SortExpression="Batch">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="StdBatch" Visible="false" runat="server" Value='<%#Bind("BatchID") %>' />
                                                    <asp:Label ID="LblBatchn" runat="server" Width="80px" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name" SortExpression="Std_Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="StdHidden" Visible="false" runat="server" Value='<%#Bind("Std_Id") %>' />
                                                    <asp:Label ID="lblStuName" runat="server" Width="140px" Text='<%# Bind("StdName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Faculty Name" SortExpression="Faculty_Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="FacultyHidden" Visible="false" runat="server" Value='<%#Bind("FacultyID") %>' />
                                                    <asp:Label ID="lblFacultyName" runat="server" Width="140px" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Wrap="True" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Feedback" SortExpression="Feedback">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbl5" align="left" runat="server" Width="200px" Text='<%# Bind("Feedback") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" HorizontalAlign="left" />
                                                <HeaderStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                </center>
                </table>
            </div>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
