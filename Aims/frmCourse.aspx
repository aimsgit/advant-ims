<%@ Page Language="VB" AutoEventWireup="false"  CodeFile="frmCourse.aspx.vb"
    Inherits="frmCourse" Title="Course Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Course Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
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
            msg = DropDownMul(document.getElementById("<%=cmbcourseType.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=cmbcourseType.ClientID %>").focus();
                a = document.getElementById("<%=Label12.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField100Mul(document.getElementById("<%=txtName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtName.ClientID %>").focus();
                a = document.getElementById("<%=Label4.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = CodeFieldMul(document.getElementById("<%=txtCode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtCode.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            //            msg = Field30(document.getElementById("<%=txtseats.ClientID %>"));
            //            if (msg != "") {
            //                document.getElementById("<%=txtseats.ClientID %>").focus();
            //                a = document.getElementById("<%=lblNoOfSeat.ClientID %>").innerHTML;
            //                msg = Spliter(a) + " " + ErrorMessage(msg);
            //                return msg;
            //            }
            //            

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
    <%-- <center>
        <h1 class="headingTxt">
            COURSE MASTER</h1>
    </center>--%>
    <center>
        <h1 class="headingTxt">
            <asp:Label ID="Lblheading" runat="server"></asp:Label>
        </h1>
    </center>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table class="custtable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Course Type* :"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:DropDownList ID="cmbcourseType" runat="server" AppendDataBoundItems="true"
                                DataValueField="CourseType_ID" DataTextField="CourseType" SkinID="ddlRsz" TabIndex="1"
                                DataSourceID="objCoursesType" Width="250">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Course Name* :"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtName" runat="server" SkinID="txtRsz" TabIndex="2"
                                Width="245"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Code* :" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtCode" runat="server" SkinID="txt" MaxLength="50" TabIndex="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblNoOfSeat" runat="server" Text="No of Seats :" SkinID="lbl"></asp:Label>
                        </td>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtseats">
                        </ajaxToolkit:FilteredTextBoxExtender>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtseats" MaxLength="9" runat="server" SkinID="txt" Width="195"
                                TabIndex="4"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblStream" runat="server" Text="Stream :" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:DropDownList ID="DdlStream" runat="server" AppendDataBoundItems="true"
                                DataValueField="LookUpAutoID" DataTextField="Data" SkinID="ddlRsz" TabIndex="5"
                                DataSourceID="objStreamType" Width="195">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btntd" align="center">
                            <br />
                            <asp:Button ID="btnadd" CausesValidation="true" runat="server" Text="ADD" CommandName="ADD"
                                SkinID="btn" OnClientClick="return Validate()" TabIndex="6" CssClass="ButtonClass">
                            </asp:Button>
                            <asp:Button ID="btnview" runat="server" Text="VIEW" CommandName="VIEW" SkinID="btn"
                                TabIndex="7" CssClass="ButtonClass"></asp:Button>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <br />
                <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                <asp:Label ID="lblerrmsg" SkinID="lblRed" runat="server"></asp:Label>
                <br />
                <br />
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="700px" Height="300px">
                    <asp:GridView ID="GridView1" runat="server" SkinID="GridView" DataKeyNames="Course_ID"
                        AllowPaging="True" Visible="True" AutoGenerateColumns="False" PageSize="100"
                        AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Wrap="False"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Course Type" SortExpression="CourseType">
                                <ItemTemplate>
                                    <asp:Label ID="DDL" Visible="false" runat="server" Text='<%#Bind("DDL") %>'></asp:Label>
                                    <asp:Label ID="lblCourseType" runat="server" Text='<%# Bind("CourseType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Course Name" SortExpression="CourseName">
                                <ItemTemplate>
                                    <asp:Label ID="LblPK" Visible="false" runat="server" Text='<%#Bind("Course_ID") %>'></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%#Bind("CourseCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No Of Seats">
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%#Bind("SeatNo") %>'></asp:Label>
                                </ItemTemplate>
                                  <ItemStyle HorizontalAlign="Center"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stream">
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%#Bind("Data") %>'></asp:Label>
                                    <asp:Label ID="Label14" Visible="false" runat="server" Text='<%#Bind("Stream") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
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
    <asp:ObjectDataSource ID="objCoursesType" runat="server" SelectMethod="GetcourseTypescombo"
        TypeName="CourseManager"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="objStreamType" runat="server" SelectMethod="GetStreamTypescombo"
        TypeName="CourseManager"></asp:ObjectDataSource>


</form>
</body>
</html>