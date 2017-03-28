<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCreateBatch.aspx.vb"
    Inherits="frmCreateBatch" Title="Create Batch" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Create Batch</title>
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

            msg = NameField100Mul(document.getElementById("<%=TextBox1.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TextBox1.ClientID %>").focus();
                a = document.getElementById("<%=lblName.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=DropDownList1.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=DropDownList1.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=DropDownList2.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=DropDownList2.ClientID %>").focus();
                a = document.getElementById("<%=Label2.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMul(document.getElementById("<%=TextBox3.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=TextBox3.ClientID %>").focus();
                a = document.getElementById("<%=Label3.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = FieldNumMul(document.getElementById("<%=txtseat.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtseat.ClientID %>").focus();
                a = document.getElementById("<%=Label4.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div class="Table5">
                    <%--<center>
                        <h1 class="headingTxt">
                            CREATE BATCH</h1>
                    </center>--%>
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
                                    <asp:Label ID="lblName" runat="server" Text="New Batch* :&nbsp;&nbsp;" SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox1" runat="server" SkinID="txtRsz" Width="195" TabIndex="1"></asp:TextBox>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Course*^ :&nbsp;&nbsp;" SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DropDownList1" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="2" AppendDataBoundItems="true" DataValueField="Courseid" DataTextField="CourseName"
                                        DataSourceID="ObjectDataSource1" Width="200">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="Academic Calendar Year*^ :&nbsp;&nbsp;" SkinID="lblRSZ" Width="200"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DropDownList2" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="3" AppendDataBoundItems="true" DataValueField="A_Code" DataTextField="AcademicYear"
                                        DataSourceID="ObjectDataSource2" Width="200">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Start Date* :&nbsp;&nbsp;" SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox3" runat="server" SkinID="txtRsz" TabIndex="4" Width="195"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="txtd_CalendarExtender" runat="server" Format="dd-MMM-yyyy"
                                        TargetControlID="TextBox3">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="No of Seats* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtseat" runat="server" SkinID="txtRsz" TabIndex="5" Width="195"></asp:TextBox>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="Class Teacher/Lecturer :&nbsp;&nbsp;"
                                        SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlClassThr" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="6" AppendDataBoundItems="true" DataValueField="Emp_Code" DataTextField="Emp_Name"
                                        DataSourceID="objLecturer" Width="200">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                               <tr>
                            <td align="right">
                                <asp:Label ID="iblbatchclosed" runat="server" SkinID="lblRsz" Width="200px" Text="Batch Closed :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlbatchclosed" runat="server" SkinID="ddlRsz" TabIndex="8" Width="200">
                                    <asp:ListItem Value="N">N</asp:ListItem>
                                    <asp:ListItem Value="Y">Y</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" Text="Associated Teacher/Lecturer :&nbsp;&nbsp;"
                                        SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DdlAssociatedThr" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="7" AppendDataBoundItems="true" DataValueField="Emp_Code" DataTextField="Emp_Name"
                                        DataSourceID="objLecturer" Width="200">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                            <td align="right">
                                <asp:Label ID="lblForum" runat="server" SkinID="lblRsz" Width="200px" Text="Forum :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlForum" runat="server" SkinID="ddlRsz" TabIndex="8" Width="200">
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnadd" runat="server" Text="ADD" SkinID="btn" TabIndex="8" OnClientClick="return Validate();" CommandName="ADD"
                                            CssClass="ButtonClass " />
                                        <asp:Button ID="btnview" runat="server" Text="VIEW" SkinID="btn" TabIndex="9" CommandName="VIEW" CssClass="ButtonClass " />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
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
                                        <center>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                </div>
            </a><a name="bottom">
                <div>
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                                DataKeyNames="id" Height="60px" SkinID="GridView" Width="600px" PageSize="100"
                                                AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <RowStyle HorizontalAlign="Left" />
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" TabIndex="10" CausesValidation="false"
                                                                CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" TabIndex="11" runat="server" CausesValidation="false"
                                                                CommandName="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete"></asp:LinkButton>
                                                            <br />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Batch" HeaderStyle-HorizontalAlign="Left" SortExpression="Batch_No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Lableid" Visible="false" runat="server" Text='<%# Bind("id") %>' />
                                                            <asp:Label ID="LabelBatchNo" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Course" HeaderStyle-HorizontalAlign="Left" SortExpression="CourseName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LabelID" runat="server" Visible="false" Text='<%# Bind("CourseCode") %>'></asp:Label>
                                                            <asp:Label ID="lblCourse" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Academic Year" SortExpression="AcademicYear">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LabelAYear" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                                            <asp:Label ID="LabelAcademicyear" Visible="false" runat="server" Text='<%# Bind("A_Code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Start Date">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="LabelStartdate" runat="server" Style="text-align: right;" Text='<%# Bind("StartDate","{0:dd-MMM-yyyy}") %>'
                                                                Width="75px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Generate Status">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="LabelGenerate" runat="server" Style="text-align: center;" Text='<%# Bind("Generate") %>'
                                                                Width="75px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No of Seats" HeaderStyle-HorizontalAlign="Right">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="LabelSeat" runat="server" Style="text-align: right;" Text='<%# Bind("NoOfSeats") %>'
                                                                Width="75px"></asp:Label>
                                                        </ItemTemplate>
                                                          <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Batch closed" HeaderStyle-HorizontalAlign="Right">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="iblbatchclosed" runat="server" Style="text-align: right;" Text='<%# Bind("Completon_status")%>'
                                                                Width="75px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Class Teacher/Lecturer" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="lblct" runat="server" Value='<%# Bind("ClassTeacherId") %>' />
                                                            <asp:Label ID="LabelCT" runat="server" Style="text-align: right;" Text='<%# Bind("ClassTeacherName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Associated Teacher/Lecturer" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="Ldlat" runat="server" Visible="false" Value='<%# Bind("AssociateID") %>' />
                                                            <asp:Label ID="LabelAT" runat="server" Style="text-align: right;" Text='<%# Bind("AssociateName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Forum" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblForum" runat="server" Style="text-align: right;" Text='<%# Bind("Forum") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getCreateBatchCourse"
                                            TypeName="BLCreateBatch"></asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="BLCreateBatch"
                                            SelectMethod="GetCreateBatchAcademicYearCombo"></asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="objview" runat="server"></asp:ObjectDataSource>
                                        <asp:ObjectDataSource ID="objLecturer" runat="server" SelectMethod="GetLecturercombo"
                                            TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                                        <br />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
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
