<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmFeedbackSeminar.aspx.vb"
    Inherits="frmFeedbackSeminar" Title="Feedback Seminar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Feedback Seminar</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlDepartment.ClientID%>"), 'Department');
            document.getElementById("<%=ddlDepartment.ClientID%>");
            if (msg != "") return msg;
            msg = DropDownForZero(document.getElementById("<%=ddlEmployee.ClientID%>"), 'Employee Name');
            document.getElementById("<%=ddlEmployee.ClientID%>");
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtProgramTitle.ClientID%>"), 'Program Title');
            document.getElementById("<%=txtProgramTitle.ClientID%>");
            if (msg != "") return msg;
            msg = NameField100NE(document.getElementById("<%=txtLocation.ClientID%>"), 'Location');
            document.getElementById("<%=txtLocation.ClientID%>");
            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txtFromDate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtToDate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID%>").focus();
                return msg;
            }
            msg = NameField100NE(document.getElementById("<%=txtTFaculty.ClientID%>"), 'Training Faculty');
            document.getElementById("<%=txtTFaculty.ClientID%>");
            if (msg != "") return msg;
            msg = NameField250NE(document.getElementById("<%=txtPFE.ClientID%>"), 'Program Feedback by Employee');
            document.getElementById("<%=txtPFE.ClientID%>");
            if (msg != "") return msg;
            msg = NameField250NE(document.getElementById("<%=txtHOD.ClientID%>"), 'Program Effectiveness by HOD');
            document.getElementById("<%=txtHOD.ClientID%>");
            if (msg != "") return msg;
            return true;
        }
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
        <h1 class="headingTxt">
            FEEDBACK ON SEMINAR/WORKSHOP/CONFERENCE
        </h1>
        <h1 class="headingTxt">
            /TRAINING ATTENDED
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
                            <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Department* :"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:DropDownList ID="ddlDepartment" runat="server" AppendDataBoundItems="true"
                                DataValueField="DeptID" AutoPostBack="true" DataTextField="DeptName" SkinID="ddlRsz"
                                Width="250" TabIndex="1" DataSourceID="objDepartment">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objDepartment" runat="server" SelectMethod="GetDepartment"
                                TypeName="ExtraCurricularAchivementsBL"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Width="200" Text="Employee Name* :"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:DropDownList ID="ddlEmployee" runat="server" AppendDataBoundItems="true"
                                DataValueField="EmpID" AutoPostBack="true" DataTextField="EmpName" SkinID="ddlRsz"
                                Width="250" TabIndex="2" DataSourceID="objEmployee">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objEmployee" runat="server" SelectMethod="GetEmployee"
                                TypeName="FeedbackSeminarBL"></asp:ObjectDataSource>
                        </td>
                        </tr>
                        <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Designation :"></asp:Label>
                        </td>
                        <td align="left">
                           
                             &nbsp;&nbsp;<asp:TextBox ID="txtDesignation" TabIndex="3" Enabled="false" runat="server" SkinID="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="Program Title* :"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtProgramTitle" runat="server" SkinID="txt" MaxLength="200"
                                TabIndex="4">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Location :"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtLocation" runat="server" SkinID="txt" MaxLength="200"
                                TabIndex="5">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="From Date :" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtFromDate" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox><ajaxToolkit:CalendarExtender
                                ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate" Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="To Date :" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox><ajaxToolkit:CalendarExtender
                                ID="CalendarExtender2" runat="server" TargetControlID="txtToDate" Format="dd-MMM-yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Training Faculty :" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtTFaculty" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" Text="Program Feedback by Employee :" SkinID="lblRsz"
                                Width="250"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtPFE" runat="server" SkinID="txt" TextMode="MultiLine"
                                TabIndex="9"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label10" runat="server" SkinID="lblRsz" Width="200" Text="Can you Train our Staff :"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:DropDownList ID="ddlCan" runat="server" AppendDataBoundItems="true"
                                DataValueField="DeptID" DataTextField="DeptName" SkinID="ddl" TabIndex="10">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" Text="Program Effectiveness by HOD :" SkinID="lblRsz"
                                Width="250"></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;&nbsp<asp:TextBox ID="txtHOD" runat="server" SkinID="txt" TextMode="MultiLine"
                                TabIndex="11"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                    <table>
                    <tr>
                        <td colspan="4" class="btntd">
                            <br />
                            <asp:Button ID="btnadd" CausesValidation="true" runat="server" Text="ADD" SkinID="btn"
                                OnClientClick="return Validate()" TabIndex="12" CssClass="ButtonClass"></asp:Button>
                            &nbsp;<asp:Button ID="btnview" runat="server" Text="VIEW" CommandName="Cancel" SkinID="btn"
                                TabIndex="13" CssClass="ButtonClass"></asp:Button>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <br />
                <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                <asp:Label ID="lblerrmsg" SkinID="lblRed" runat="server"></asp:Label>
                <br />
            </center>
            <center>
                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="850px" Height="300px">
                    <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="True"
                        AllowSorting="True" Visible="True" AutoGenerateColumns="False" PageSize="100">
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete" Visible="true" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Wrap="False"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department" SortExpression="DeptName">
                                <ItemTemplate>
                                    <asp:Label ID="lblFBAID" Visible="false" runat="server" Text='<%#Bind("FBAID") %>'></asp:Label>
                                    <asp:Label ID="lblDeptID" Visible="false" runat="server" Text='<%#Bind("DeptID") %>'></asp:Label>
                                    <asp:Label ID="lblCan" Visible="false" runat="server" Text='<%#Bind("CanYou") %>'></asp:Label>
                                    <asp:Label ID="lblDesignation" Visible="false" runat="server" Text='<%#Bind("Designation") %>'></asp:Label>
                                    <asp:Label ID="lblLoc" Visible="false" runat="server" Text='<%#Bind("Location") %>'></asp:Label>
                                    <asp:Label ID="lblTF" Visible="false" runat="server" Text='<%#Bind("TrainingFaculty") %>'></asp:Label>
                                    <asp:Label ID="lblPFE" Visible="false" runat="server" Text='<%#Bind("ProgramFeedbackbyCandidate") %>'></asp:Label>
                                    <asp:Label ID="lblHOD" Visible="false" runat="server" Text='<%#Bind("ProgramEffectivenessbyHOD") %>'></asp:Label>
                                    <asp:Label ID="lblDepartment" Width="150" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpName" runat="server" Width="150" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                    <asp:Label ID="lblEmpID" Visible="false" runat="server" Text='<%#Bind("EmployeeID") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpCode" runat="server" Width="150" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Program Title">
                                <ItemTemplate>
                                    <asp:Label ID="lblPTitle" runat="server" Width="150" Text='<%# Bind("ProgramTitle") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location">
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation" runat="server" Width="150" Text='<%# Bind("Location") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From Date" SortExpression="FromDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblFromDate" runat="server" Width="100" Text='<%#Bind("FromDate","{0:dd-MMM-yyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblToDate" runat="server" Width="100" Text='<%#Bind("ToDate","{0:dd-MMM-yyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="center" />
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

</form>
</body>
</html>

