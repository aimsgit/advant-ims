<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmSemesterDate.aspx.vb"
    Inherits="frmSemesterDate" Title="COURSE SEMESTER MAPPING" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>COURSE SEMESTER MAPPING</title>
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

            msg = DropDownForZeroMul(document.getElementById("<%=cmbCourse.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbCourse.ClientID%>").focus();
                a = document.getElementById("<%=Label15.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=cmbSemester.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSemester.ClientID%>").focus();
                a = document.getElementById("<%=Label8.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = AgeFieldMul(document.getElementById("<%=txtDuration.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtDuration.ClientID%>").focus();
                a = document.getElementById("<%=Label5.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = AgeFieldMul(document.getElementById("<%=TxtWeeks.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=TxtWeeks.ClientID%>").focus();
                a = document.getElementById("<%=Label4.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = AgeFieldMul(document.getElementById("<%=txtSequence.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtSequence.ClientID%>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--   <center>
                        <h1 class="headingTxt">
                            COURSE SEMESTER MAP</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbCourse" runat="server" DataTextField="CourseName" AutoPostBack="True"
                                        DataSourceID="ObjCourse1" DataValueField="Courseid" TabIndex="1" AppendDataBoundItems="true"
                                        SkinID="ddlRsz" Width="250px">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSemester" TabIndex="2" runat="server" DataValueField="SemCode"
                                        DataTextField="SemName" DataSourceID="ObjSemester" SkinID="ddl">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="Duration(Days)* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtDuration" TabIndex="3" runat="server" SkinID="txt" 
                                        MaxLength="3"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender runat="server" ValidChars="1234567890" TargetControlID="TxtDuration">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="Duration(Weeks)* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtWeeks" TabIndex="4" runat="server" SkinID="txt" 
                                        MaxLength="3"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        ValidChars="1234567890" TargetControlID="TxtWeeks">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Sequence* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSequence" TabIndex="5" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        ValidChars="1234567890" TargetControlID="txtSequence">
                                    </ajaxToolkit:FilteredTextBoxExtender>
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
                                <td colspan="2" class="btnTd" align="center">
                                    <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        CommandName="ADD" OnClientClick="return Validate();" SkinID="btn" TabIndex="6"
                                        Text="ADD" />&nbsp;
                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="7"
                                        Text="VIEW" CommandName="VIEW" Visible="true" />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td colspan="2" align="right">
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
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
                                </td>
                            </tr>
                            <div>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                        </table>
            </a><a name="bottom">
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <asp:GridView ID="GVSemdate" runat="server" Width="584px" SkinID="GridView" DataKeyNames="PKID"
                        AllowPaging="true" AutoGenerateColumns="False" Visible="true" PageSize="100"
                        AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                        Text="Edit" SkinID="btn" />
                                    <asp:LinkButton ID="btndel" runat="server" CausesValidation="false" CommandName="Delete"
                                        Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Course" SortExpression="CourseName">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HFPKID" runat="server" Value='<%# Bind("PKID") %>' />
                                    <asp:Label ID="l2" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CourseID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Semester" SortExpression="SemName">
                                <ItemTemplate>
                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("SemName") %>' />
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("SemesterID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duration(Days)">
                                <ItemTemplate>
                                    <asp:Label ID="l4" runat="server" Text='<%# Bind("Duration") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duration(Weeks)">
                                <ItemTemplate>
                                    <asp:Label ID="l6" runat="server" Text='<%# Bind("Weeks") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sequence" SortExpression="Sequence">
                                <ItemTemplate>
                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("Sequence") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="courseCombo" TypeName="SemesterdateDL">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="GetSemesterCombo"
                    TypeName="SemesterdateDL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cmbCourse" Name="CourseID" PropertyName="SelectedValue"
                            DbType="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                </center>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
