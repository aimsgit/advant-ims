<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmGradeMaster.aspx.vb"
    Inherits="FrmGradeMaster" Title="Grade Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Grade Master</title>
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

        //Function for Multilingual Validations
        //Created By Ajit Kumar Singh


        function Valid() {

            var msg, a;
            msg = OneCharMul(document.getElementById("<%=Txtmin.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Txtmin.ClientID %>").focus();
                a = document.getElementById("<%=Label12.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = OneCharMul(document.getElementById("<%=Txtmax.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Txtmax.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = OneCharMul(document.getElementById("<%=Txtgrade.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=Txtgrade.ClientID %>").focus();
                a = document.getElementById("<%=Label3.ClientID %>").innerHTML;
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

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <center>
        <div class="mainBlock">
            <%--<center>
                <h1 class="headingTxt">
                    GRADE MASTER</h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
        </div>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblcourse" runat="server" Text="Course :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourse" runat="server" SkinID="ddlRsz" DataSourceID="objCourse"
                                    TabIndex="1" Width="250px" DataTextField="CourseName" DataValueField="CourseCode"
                                    AppendDataBoundItems="true">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="% Min* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txtmin" runat="server" AutoCompleteType="Disabled" TabIndex="2" SkinID="txt"
                                    MaxLength="6"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterMode="validChars" FilterType="Custom" TargetControlID="Txtmin" ValidChars=".0123456789">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="% Max* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txtmax" runat="server" AutoCompleteType="Disabled" TabIndex="3" SkinID="txt"
                                    MaxLength="6"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="validChars" FilterType="Custom" TargetControlID="Txtmax" ValidChars=".0123456789">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Grade* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txtgrade" runat="server" SkinID="txt" AutoCompleteType="Disabled" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Grade Point :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtGradePoint" runat="server" AutoCompleteType="Disabled" TabIndex="5" SkinID="txt"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterMode="validChars" FilterType="Custom" TargetControlID="TxtGradePoint" ValidChars=".0123456789">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Division :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDivision" runat="server" TabIndex="6" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <tr align="center">
                                <td class="btnTd" colspan="3">
                                    <br />
                                    <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CommandName="ADD"
                                        CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="6"
                                        Text="ADD" ValidationGroup="edit" />
                                    &nbsp<asp:Button ID="btnView" runat="server" CausesValidation="false" CssClass="ButtonClass"
                                        CommandName="VIEW" SkinID="btn" TabIndex="7" Text="VIEW" />
                                </td>
                            </tr>
                        </tr>
                    </table>
                </center>
                <center>
                    <br />
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                    <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    <br />
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="600px" Height="300px">
                        <asp:GridView ID="GVGradeMaster" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="100" SkinID="GridView" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" Visible="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Course" SortExpression="CourseName" HeaderStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:HiddenField ID="GID" runat="server" Value='<%# Bind("id") %>' />
                                        <asp:Label ID="Lblcourse" runat="server" Text='<%# Bind("CourseID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="Lblcourse1" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="% Min" HeaderStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Label ID="Lblmin" runat="server" Text='<%#Bind("MinMarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="% Max" HeaderStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Label ID="Lblmax" runat="server" Text='<%#Bind("MaxMarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Grade" SortExpression="Grade" HeaderStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Label ID="Lblgrade" runat="server" Text='<%#Bind("Grade") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Grade Point" SortExpression="GradePoint" HeaderStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Label ID="LblGradePoint" runat="server" Text='<%#Bind("GradePoint") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Division" SortExpression="Division" HeaderStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:Label ID="LblDivision" runat="server" Text='<%#Bind("Division") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </asp:Panel>
                </center>
                <div>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        </asp:Panel>
                    </center>
                    <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseCombo"
                        TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
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
    </center>

</form>
</body>
</html>

