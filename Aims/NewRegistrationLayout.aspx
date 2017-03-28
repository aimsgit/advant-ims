<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewRegistrationLayout.aspx.vb"
    Inherits="NewRegistrationLayout" Title="ADMISSION REGISTER" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ADMISSION REGISTER</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 1000px; height: 800px">

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
            var msg, a;
            msg = ValidateDateMul(document.getElementById("<%=txtAdate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtAdate.ClientID %>").focus();
                a = document.getElementById("<%=Adate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBranchName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlBranchName.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourse.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID %>").focus();
                a = document.getElementById("<%=Label23.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;

            }


            //            msg = DropDownForZeroMul(document.getElementById("<%=ddlBranchName.ClientID %>"));
            //            if (msg != "") {
            //                document.getElementById("<%=ddlBranchName.ClientID %>").focus();
            //                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
            //                msg = Spliter(a) + " " + ErrorMessage(msg);
            //                return msg;
            //            }

            msg = DropDownForZeroMul(document.getElementById("<%=cmbBatch.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=cmbBatch.ClientID %>").focus();
                a = document.getElementById("<%=LabelBtch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = NameField100Mul(document.getElementById("<%=txtFullName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtFullName.ClientID %>").focus();
                a = document.getElementById("<%=lblFullName.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = NameField100Mul(document.getElementById("<%=txtregno.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtregno.ClientID %>").focus();
                a = document.getElementById("<%=Label27.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlcategry.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlcategry.ClientID %>").focus();
                a = document.getElementById("<%=Label11.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            msg = ValidateDate(document.getElementById("<%=txtdob.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtdob.ClientID %>").focus();
                a = document.getElementById("<%=Label9.ClientID %>").innerHTML;
                alert(a);
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = numericMul(document.getElementById("<%=txtage.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtage.ClientID %>").focus();
                a = document.getElementById("<%=lblage.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = NameField250Mul(document.getElementById("<%=txtPaddr.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtPaddr.ClientID %>").focus();
                a = document.getElementById("<%=Label5.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownMul(document.getElementById("<%=ddlgender.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlgender.ClientID %>").focus();
                a = document.getElementById("<%=Label10.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMulN(document.getElementById("<%=txtPassportIssueDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtPassportIssueDate.ClientID %>").focus();
                a = document.getElementById("<%=lblPassportIssueDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMulN(document.getElementById("<%=txtExpiryDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtExpiryDate.ClientID %>").focus();
                a = document.getElementById("<%=lblExpiryDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = ValidateDateMulN(document.getElementById("<%=txtVisaIssueDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtVisaIssueDate.ClientID %>").focus();
                a = document.getElementById("<%=lblVisaIssueDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMulN(document.getElementById("<%=txtVisaExpDate.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtVisaExpDate.ClientID %>").focus();
                a = document.getElementById("<%=lblVisaExpDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMulN(document.getElementById("<%=cmbBranch.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=cmbBranch.ClientID %>").focus();
                a = document.getElementById("<%=lblfrombranch.ClientID %>").innerHTML;
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
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
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
                <%--            <center>
                    <h1 class="headingTxt">
                        ADMISSION REGISTER
                    </h1>
                </center>--%>
                <%--   <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>--%>
                </center>
                <br />
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp" ActiveTabIndex="1">
                      <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Admission Criteria"
                        TabIndex="1">
                        <ContentTemplate>
                            <center>
                                <h1 class="headingTxt">
                                    ADMISSION CRITERIA
                                </h1>
                            </center>
                            <center>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                    <asp:GridView ID="GVCriteria" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                        AllowPaging="True" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Criteria">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCriteriaName" runat="server" Text='<%# Bind("Criteria_Name") %>'
                                                        Visible="true"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Criteria value">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlCriteriavalue" runat="server" AppendDataBoundItems="true"
                                                        DataTextField="Criteria_Value" DataValueField="Criteria_Value" SkinID="ddlRsz"
                                                        Width="200px">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Button ID="BtnGo" CommandName="ADD" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                    SkinID="btnRsz" Text="GOTO ADMISSION PAGE" Width="175px" />
                                <table>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Admission Register"
                        TabIndex="2">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                </Triggers>
                                <ContentTemplate>
                                    <center>
                                        <h1 class="headingTxt">
                                            ADMISSION REGISTER
                                        </h1>
                                    </center>
                                    <center>
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label17" runat="server" SkinID="lbl" Text="Enquiry No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlenqno" runat="server" DataSourceID="odsEnquiry" DataTextField="Enquiry_No"
                                                        DataValueField="EnqCode" SkinID="ddl" AutoPostBack="True" TabIndex="1">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="odsEnquiry" runat="server" SelectMethod="GetEnqNo" TypeName="EnquiryManager">
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label1" runat="server" Text="Course Branch*^ :&nbsp;" SkinID="lblRsz"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlBranchName" Width="200px" TabIndex="2" runat="server" SkinID="ddlRsz"
                                                        AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" SelectMethod="insertBranchCombo_Adminition"
                                                        TypeName="CourseDB"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="LabelApp" runat="server" SkinID="lbl" Text="Application No^ :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="texApp" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                        FilterMode="InvalidChars" FilterType="Custom" InvalidChars="'" TargetControlID="texApp">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label23" runat="server" Text="Course*^ :&nbsp;" SkinID="lbl"></asp:Label>
                                                </td>
                                                <td colspan="1" align="left">
                                                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                        DataTextField="CourseName" DataValueField="Courseid" SkinID="ddl" TabIndex="4">
                                                        <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDtaCourseAdd"
                                                        TypeName="CourseDB">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="ddlBranchName" PropertyName="SelectedValue" Name="Branchcode"
                                                                DefaultValue="0" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                    <%--DataSourceID="ObjAcademic"<asp:ObjectDataSource ID="ObjAcademic" runat="server" TypeName="BLNew_stdMarks" SelectMethod="GetAcademicCombo">
                                </asp:ObjectDataSource>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Adate" runat="server" SkinID="lblRsz" Width="150px" Text="Admission Date*^ :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtAdate" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                                        TargetControlID="txtAdate">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                                        Format="dd-MMM-yyyy" TargetControlID="txtAdate">
                                                    </ajaxToolkit:CalendarExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="LabelBtch" runat="server" SkinID="lbl" Text="Batch*^ :&nbsp;"></asp:Label>
                                                    <asp:Label ID="Label8" Visible="false" runat="server" Text="Academic Year^ :&nbsp;"
                                                        SkinID="lblRsz"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="cmbAcademic" Visible="false" runat="server" SkinID="ddl" AutoPostBack="True"
                                                        DataValueField="id" DataTextField="AcademicYear">
                                                        <asp:ListItem Value="0" Selected="True"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="cmbBatch" TabIndex="6" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                                        Width="185px" DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" TypeName="BLNew_stdMarks" SelectMethod="GetBatchCombo">
                                                        <SelectParameters>
                                                    <asp:ControlParameter ControlID="cmbAcademic" PropertyName="SelectedValue" Name="A_Year"
                                                        DefaultValue="0" Type="Int16" />
                                                    <asp:ControlParameter ControlID="ddlCourse" PropertyName="SelectedValue" Name="Course"
                                                        DefaultValue="0" Type="Int16" />
                                                </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lbladmissiontype" runat="server" SkinID="lblRsz" Text="Admission Type :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddladmissiontype" runat="server" SkinID="ddl" TabIndex="7">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="1">Normal</asp:ListItem>
                                                        <asp:ListItem Value="2">Lateral</asp:ListItem>
                                                        <asp:ListItem Value="3">Transfer</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label11" runat="server" SkinID="lblRsz" Text="Student Category*^ :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlcategry" runat="server" DataSourceID="ObjCategory" DataTextField="CategoryName"
                                                        DataValueField="Category_Id" SkinID="ddlRsz" Width="185" TabIndex="8">
                                                        <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjCategory" runat="server" SelectMethod="GetCategoryyy"
                                                        TypeName="CategoryDB"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblDDNo" runat="server" SkinID="lblRsz" Text="Paying Voucher :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtddno" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label24" runat="server" SkinID="lblRsz" Text="Allocated Category :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DdlAllocCat" runat="server" DataSourceID="ObjCategory" DataTextField="CategoryName"
                                                        DataValueField="Category_Id" SkinID="ddlRsz" Width="185" TabIndex="9">
                                                        <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetCategoryyy"
                                                        TypeName="CategoryDB"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblProspectusNo" runat="server" SkinID="lbl" Text="Prospectus No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtprospectusno" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblReceiptNo" runat="server" SkinID="lbl" Text="Receipt No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtreceiptno" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblfee" runat="server" SkinID="lbl" Text="Fee Collected :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlfee" runat="server" AppendDataBoundItems="True" SkinID="ddl"
                                                        TabIndex="12">
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblLeavingDate" runat="server" SkinID="lbl" Text="Leaving Date :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtLeavingDate" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Mentor Name^ :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlMentorName" TabIndex="14" runat="server" SkinID="ddlRsz"
                                                        AutoPostBack="True" Width="155px" DataValueField="EmpID" DataTextField="Emp_Name"
                                                        DataSourceID="objMentorName">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="objMentorName" runat="server" TypeName="StudentDB" SelectMethod="GetMentorName">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="ddlMentorCode" PropertyName="SelectedValue" Name="MentorId"
                                                                DefaultValue="0" Type="Int16" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblTCNo" runat="server" SkinID="lblRsz" Width="200px" Text="Transfer Certificate No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtTCNo" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label21" runat="server" SkinID="lbl" Text="Mentor Code^ :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlMentorCode" TabIndex="16" runat="server" SkinID="ddlRsz"
                                                        AutoPostBack="True" Width="185px" DataValueField="EmpID" DataTextField="Emp_Code"
                                                        DataSourceID="ObjMentorCode">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjMentorCode" runat="server" TypeName="StudentDB" SelectMethod="GetMentorCode">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="ddlMentorName" PropertyName="SelectedValue" Name="MentorId"
                                                                DefaultValue="0" Type="Int16" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblSponsor" runat="server" SkinID="lbl" Text="Sponsor Name :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlsponsor" runat="server" DataSourceID="odsSponsor" DataTextField="SponsorName"
                                                        DataValueField="Sponsor_ID" SkinID="ddl" TabIndex="17">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="odsSponsor" runat="server" SelectMethod="GetSponsorCombo"
                                                        TypeName="SponsorManager"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <%-- </table>
                                    </center>
                                   
                                    <table>--%>
                                            <tr>
                                                <td colspan="8">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblFullName" runat="server" Text="First Name*^ :&nbsp;" SkinID="lblRsz"
                                                        Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtFullName" runat="server" SkinID="txt" TabIndex="18"></asp:TextBox>
                                                    <%--   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtFullName">
                                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblmidname" runat="server" Text="Middle Name :&nbsp;" SkinID="lblRsz"
                                                        Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtmidname" runat="server" SkinID="txt" TabIndex="19"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblLName" runat="server" Text="Last Name :&nbsp;" SkinID="lblRsz"
                                                        Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtlblLName" runat="server" SkinID="txt" TabIndex="20"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label4" runat="server" Text="Index No :&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtIndex" runat="server" SkinID="txt" TabIndex="21"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label27" runat="server" Text=" Stud.Code/Reg.No.*^ :&nbsp;" SkinID="lblRsz"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtregno" runat="server" SkinID="txt" TabIndex="22"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtregno">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label22" runat="server" Text=" Second Student Code :&nbsp;" SkinID="lblRsz"
                                                        Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtSecondUSN" runat="server" SkinID="txt" TabIndex="23"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server"
                                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtSecondUSN">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblemailstd" runat="server" SkinID="lblRsz" Width="150px" Text="Student Email ID :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtemailstd" runat="server" SkinID="txt" TabIndex="24"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblstdcontact" runat="server" SkinID="lblRsz" Width="162px" Text="Student Contact No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtperphonestd" runat="server" SkinID="txt" TabIndex="25" axLength="15"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtperphonestd">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblMotherTongue" runat="server" SkinID="lbl" Text="Mother Tongue :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtMotherTongue" runat="server" SkinID="txt" TabIndex="25"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblHouseName" runat="server" SkinID="lbl" Text="House Name^ :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:DropDownList ID="ddlHomeName" runat="server" AppendDataBoundItems="True" DataSourceID="ObjHomeName"
                                                            DataTextField="HouseName" DataValueField="HMID" SkinID="ddl" TabIndex="26">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="ObjHomeName" runat="server" SelectMethod="GetHouseName"
                                                            TypeName="StudentDB"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </tr>
                                            <%--<tr>
                            <td align="right" colspan="3">
                                
                            </td>
                        </tr>--%>
                                            <tr>
                                                <td align="right" colspan="3">
                                                    <asp:Label ID="lblTotal" runat="server" Text="Total Number of Seats :&nbsp;" SkinID="lblRsz"
                                                        Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtTotal" runat="server" SkinID="txt" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="3">
                                                    <asp:Label ID="lblAvailable" runat="server" Text="Number of Seats Available :&nbsp;"
                                                        SkinID="lblRsz" Width="220px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtAvailable" runat="server" SkinID="txt" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <%-- <tr>
                            <td colspan="5">
                                <hr />
                            </td>
                        </tr>--%>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Title :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="cmbTitle" runat="server" SkinID="ddl" TabIndex="27">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>Mr.</asp:ListItem>
                                                        <asp:ListItem>Ms.</asp:ListItem>
                                                        <asp:ListItem>Mrs.</asp:ListItem>
                                                        <asp:ListItem>Dr.</asp:ListItem>
                                                        <asp:ListItem>Prof.</asp:ListItem>
                                                        <asp:ListItem>Master</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" rowspan="4">
                                                    <asp:Label ID="lblPhoto" runat="server" SkinID="lbl" Text="Photo :&nbsp;"></asp:Label>
                                                    <br />
                                                    <asp:Button ID="btnUpload" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="28"
                                                        Text="UPLOAD" CommandName="UPLOAD" />
                                                </td>
                                                <td align="left" rowspan="4">
                                                    <asp:Image ID="ImageMap1" runat="server" ImageUrl="~/Images/imageupload.gif" Style="width: 100px;
                                                        height: 100px;" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="Gender* :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlgender" runat="server" SkinID="ddl" TabIndex="29">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label3" runat="server" Text="Name with Initial* :&nbsp;" SkinID="lblRsz"
                                                        Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtname" runat="server" Enabled="false" SkinID="txt"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtname">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblNicNo" runat="server" Text="Aadhaar/NIC No.^ :&nbsp;" SkinID="lblRsz"
                                                        Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtNicNo" runat="server" SkinID="txt" TabIndex="30"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'~!@#$%^&*()_+,<>.?/:;}]{[|\"
                                                        TargetControlID="txtNicNo">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label9" runat="server" SkinID="lbl" Text="Date of Birth*^ :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtdob" runat="server" AutoPostBack="true" SkinID="txt" TabIndex="31"
                                                        MaxLength="11"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblage" runat="server" SkinID="lbl" Text="Age* :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtage" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td align="left">
                                                    <asp:FileUpload ID="FileUpload2" TabIndex="32" runat="server" BorderColor="White"
                                                        SkinID="btnRsz" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label25" runat="server" SkinID="lbl" Text="Place of Birth :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="Txtbirthplace" runat="server" SkinID="txt" TabIndex="33"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblcitizen" runat="server" SkinID="lbl" Text="  Citizenship :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtcitizen" runat="server" SkinID="txt" TabIndex="34" MaxLength="11"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Text="Permanent Address* :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtPaddr" runat="server" SkinID="txtRsz" Height="50" Width="200px"
                                                        TabIndex="35" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Correspondence Address :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtCaddr" runat="server" SkinID="txtRsz" Height="50" Width="200px"
                                                        TabIndex="36" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label19" runat="server" Text="Country :&nbsp;" SkinID="lbl"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlCountry" runat="server" AppendDataBoundItems="True" DataSourceID="ObjCountry"
                                                        DataTextField="Country" AutoPostBack="true" DataValueField="countryId" SkinID="ddl"
                                                        TabIndex="37">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjCountry" runat="server" SelectMethod="CountryCombo"
                                                        TypeName="StudentDB"></asp:ObjectDataSource>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="LblPeriod" runat="server" SkinID="lbl" Text="Corresp. Period :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="TxtPeriod" runat="server" SkinID="txt" TabIndex="38"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label18" runat="server" SkinID="lbl" Text="State :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlState" runat="server" DataSourceID="ObjState" DataTextField="StateName"
                                                        DataValueField="StateId" SkinID="ddl" TabIndex="39" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjState" runat="server" SelectMethod="GetStateEmpMaster"
                                                        TypeName="StudentDB">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="ddlCountry" PropertyName="SelectedValue" Name="countryId"
                                                                DefaultValue="0" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label13" runat="server" SkinID="lbl" Text="City :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtCity" runat="server" SkinID="txt" TabIndex="40"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lbldistrict" runat="server" SkinID="lbl" Text="District :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlDistric" runat="server" DataSourceID="ObjDistric" DataTextField="DistrictName"
                                                        DataValueField="DistrictId" SkinID="ddl" AutoPostBack="true" TabIndex="41">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="ObjDistric" runat="server" SelectMethod="GetDistricEmpMaster"
                                                        TypeName="StudentDB">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="ddlCountry" PropertyName="SelectedValue" Name="countryId"
                                                                DefaultValue="0" />
                                                            <asp:ControlParameter ControlID="ddlState" PropertyName="SelectedValue" Name="StateId"
                                                                DefaultValue="0" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label14" runat="server" SkinID="lbl" Text="PinCode :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtPC" runat="server" SkinID="txt" TabIndex="42"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                </td>
                                                <td></td>
                                                <td></td> 
                                                <td align="right">
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label40" runat="server" SkinID="lblRsz" Text=" Distance From School :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtdistance" runat="server" SkinID="txt" TabIndex="42"></asp:TextBox>
                                                </td></tr>
                                            <tr>
                                                <td align="left" colspan="1">
                                                    &nbsp;
                                                </td>
                                                <td align="left" colspan="3">
                                                    <asp:CheckBox ID="ChkHostel" runat="server" Text="Hostel" TabIndex="43" />
                                                </td>
                                                <td align="left" colspan="3">
                                                    <asp:CheckBox ID="ChkTransport" runat="server" Text="Transport" TabIndex="44" />
                                                </td>
                                            </tr>
                                            <%--   </table>
                                    <hr />
                                    <table>--%>
                                            </a>
                                            <tr>
                                                <td colspan="8">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label111" runat="server" SkinID="lblRsz" Width="120px" Text="Father Name :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtFname" runat="server" SkinID="txt" TabIndex="45"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblMotherName" runat="server" SkinID="lbl" Text="Mother Name :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMotheName" runat="server" SkinID="txt" TabIndex="46"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblFatherContact" runat="server" SkinID="lblRsz" Width="150px" Text="Father Contact No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <%--<table>
                        <tr>
                            <td>--%>
                                                    <asp:TextBox ID="txtFatherContact" runat="server" SkinID="txt" TabIndex="47"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtFatherContact">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <%--</td>
                            <td>--%>
                                                    <asp:CheckBox ID="CheckFSMS" runat="server" TabIndex="48" />
                                                    <%--</td>
                        </tr>
                    </table>--%>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label6" runat="server" SkinID="lblRsz" Width="150px" Text="Mother Contact No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <%--<table>
                        <tr>
                            <td>--%>
                                                    <asp:TextBox ID="txtperphone" runat="server" SkinID="txt" TabIndex="49"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtperphone">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <%--</td>
                            <td>--%>
                                                    <asp:CheckBox ID="CheckSMS" Checked="true" TabIndex="50" runat="server" />
                                                    <%--</td>
                        </tr>
                    </table>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblFHomeContact" runat="server" SkinID="lblRsz" Width="180px" Text="Father Home Contact :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtFHomeContact" runat="server" SkinID="txt" TabIndex="51"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtFHomeContact">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblMHomeContact" runat="server" SkinID="lblRsz" Width="200px" Text="Mother Home Contact No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMHomeContact" runat="server" SkinID="txt" TabIndex="52"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtMHomeContact">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblFBizContact" runat="server" SkinID="lblRsz" Width="200px" Text="Father Business Contact :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtFBizContact" runat="server" SkinID="txt" TabIndex="53"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtFBizContact">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblMBizContact" runat="server" SkinID="lblRsz" Width="200px" Text="Mother Business Contact :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMBizContact" runat="server" SkinID="txt" TabIndex="54"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtMBizContact">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblFatherQualification" runat="server" SkinID="lblRsz" Width="200px"
                                                        Text="Father Qualification :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtFatherQualification" runat="server" SkinID="txt" TabIndex="54"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblMotherQualification" runat="server" SkinID="lblRsz" Width="200px"
                                                        Text="Mother Qualification :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMotherQualification" runat="server" SkinID="txt" TabIndex="55"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label15" runat="server" SkinID="lblRsz" Width="160px" Text="Father Occupation :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txt_occupt" runat="server" SkinID="txt" TabIndex="56"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblMotherOccupation" runat="server" SkinID="lblRsz" Width="200px"
                                                        Text="Mother Occupation :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtMotherOccupation" runat="server" SkinID="txt" TabIndex="57"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblFatherEmail" runat="server" SkinID="lbl" Text="Father Email ID :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <%--<table>
                        <tr>
                            <td align="left">--%>
                                                    <asp:TextBox ID="txtFatherEmail" runat="server" SkinID="txt" TabIndex="58"></asp:TextBox>
                                                    <%--</td>
                            <td>--%>
                                                    <asp:CheckBox ID="CheckFMail" runat="server" />
                                                    <%--</td>
                        </tr>
                    </table>--%>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblemail" runat="server" SkinID="lblRsz" Text="Mother Email ID :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <%--<table>
                        <tr>
                            <td>--%>
                                                    <asp:TextBox ID="txtemail" runat="server" SkinID="txt" TabIndex="59"></asp:TextBox>
                                                    <%--</td>
                            <td>--%>
                                                    <asp:CheckBox ID="CheckMail" Checked="true" runat="server" />
                                                    <%--</td>
                        </tr>
                    </table>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label28" runat="server" SkinID="lblRsz" Width="180px" Text="Race/Caste/SubCaste :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlcaste" runat="server" AppendDataBoundItems="True" DataSourceID="objcast"
                                                        DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="60">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="objcast" runat="server" SelectMethod="CasteCombo" TypeName="StudentDB">
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblReligion" runat="server" SkinID="lblRsz" Width="200px" Text="Religion :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtReligion" runat="server" SkinID="txt" TabIndex="61"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label16" runat="server" SkinID="lbl" Text="Annual Income :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtIncome" runat="server" SkinID="txt" TabIndex="62" MaxLength="10"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtIncome">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblEthn" runat="server" Text="Ethnicity :&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:DropDownList ID="ddlethnic" runat="server" AppendDataBoundItems="True" DataSourceID="Objethnic"
                                                        DataTextField="Data" AutoPostBack="true" DataValueField="LookUpAutoID" SkinID="ddl"
                                                        TabIndex="63">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="Objethnic" runat="server" SelectMethod="EthnicCombo" TypeName="StudentDB">
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblGDName" runat="server" SkinID="lbl" Text="Guardian Name :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtGDName" runat="server" SkinID="txt" TabIndex="64"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblgrdnrelation" runat="server" SkinID="lblRsz" Text="Relationship of Guardian :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtgrdnRel" runat="server" SkinID="txt" TabIndex="64"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblGDContactNo" runat="server" Text="Guardian Contact No :&nbsp;"
                                                        SkinID="lblRsz" Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtGDContactNo" runat="server" SkinID="txt" TabIndex="65"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtGDContactNo">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblGO" runat="server" SkinID="lblrsz" Text="Guardian Occupation :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtGO" runat="server" SkinID="txt" TabIndex="66"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblGDEmail" runat="server" Text="Guardian Email ID :&nbsp;" SkinID="lblRsz"
                                                        Width="200px"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtGDEmail" runat="server" SkinID="txt" TabIndex="67"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <%--<hr />--%>
                                            <tr>
                                                <td colspan="8">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblNameinpassport" runat="server" SkinID="lblRsz" Width="180px" Text="Name as in Passport :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtNameinpassport" runat="server" SkinID="txt" TabIndex="68"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblVisaNo" runat="server" SkinID="lblRsz" Width="180px" Text="Visa No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtVisaNo" runat="server" SkinID="txt" TabIndex="69"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblPassportNo" runat="server" SkinID="lblRsz" Width="180px" Text="Passport No :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtPassportNo" runat="server" SkinID="txt" TabIndex="70"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblVisaIssueDate" runat="server" SkinID="lblRsz" Width="180px" Text="Visa Issue Date :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtVisaIssueDate" runat="server" SkinID="txt" TabIndex="71"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblPassportIssueDate" runat="server" SkinID="lblRsz" Width="180px"
                                                        Text="Passport Issue Date :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtPassportIssueDate" runat="server" SkinID="txt" TabIndex="72"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblVisaExpDate" runat="server" SkinID="lblRsz" Width="180px" Text="Visa Expiry Date :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtVisaExpDate" runat="server" SkinID="txt" TabIndex="73"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblExpiryDate" runat="server" SkinID="lblRsz" Width="180px" Text="Passport Expiry Date :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtExpiryDate" runat="server" SkinID="txt" TabIndex="74"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblfrombranch" runat="server" SkinID="lblRsz" Width="190px" Text="FRRO Expiry Date :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="cmbBranch" runat="server" SkinID="txt" TabIndex="75"></asp:TextBox>
                                                    <%--<asp:DropDownList ID="cmbBranch" runat="server" DataSourceID="ObjBranch" DataTextField="BranchName"
                                DataValueField="BranchCode" SkinID="ddl" TabIndex="43">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetBranchCombo" TypeName="BranchManager"></asp:ObjectDataSource>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblPlaceofIssue" runat="server" SkinID="lblRsz" Width="280px" Text="Place of Issue&nbsp;(Passport) :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtPlaceofIssue" runat="server" SkinID="txt" TabIndex="76"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblRemarks" runat="server" SkinID="lbl" Text="Remarks :&nbsp;"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" SkinID="txt" TabIndex="77"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    &nbsp;
                                                </td>
                                                <td align="left" colspan="2">
                                                    <asp:TextBox ID="txtcid" runat="server" Visible="False"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtpath" runat="server" Visible="False"></asp:TextBox>
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <hr />
                                        <%--<tr>
                                        <td colspan="6">
                                            <hr />
                                        </td>
                                    </tr>--%>
                                        <center>
                                            <table>
                                                <tr>
                                                    <td align="left" colspan="2" width="200">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" SkinID="CHK" Text=" Birth Certificate"
                                                            TabIndex="78" />
                                                    </td>
                                                    <td align="left" colspan="2" width="200">
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text=" Transfer Certificate" TabIndex="79" />
                                                    </td>
                                                    <td align="left" colspan="2" width="300">
                                                        <asp:CheckBox ID="CheckBox3" runat="server" Text=" Bachelor Degree Certificate" TabIndex="80" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox4" runat="server" Text=" (O/L)/10th Certificate" TabIndex="81" />
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox5" runat="server" Text=" Migration Certificate" TabIndex="82" />
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox6" runat="server" Text=" Master Degree Certificate" TabIndex="83" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox7" runat="server" Text=" (A/L)/12th Certificate" TabIndex="84" />
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox8" runat="server" Text=" Income Certificate" TabIndex="85" />
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox9" runat="server" Text=" School Leaving Certificate" TabIndex="86" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox10" runat="server" Text=" Letter of Selection" TabIndex="87" />
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox11" runat="server" Text=" Application for Registration"
                                                            TabIndex="83" />
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox12" runat="server" Text=" Application for Univ Admission"
                                                            TabIndex="84" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:CheckBox ID="CheckBox13" runat="server" Text=" Color Photo" TabIndex="87" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                        <center>
                                            <table>
                                                <tr>
                                                    <td colspan="6">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnStddet" runat="server" Text="ADD" TabIndex="88" CssClass="ButtonClass"
                                                            CommandName="ADD" OnClientClick="return Validate();" SkinID="btn" />
                                                        <%--</td>
                        <td>--%>
                                                        <asp:Button ID="btnNext" runat="server" Text="VIEW" CommandName="VIEW" CssClass="ButtonClass"
                                                            SkinID="btn" TabIndex="87" />
                                                        <%--</td>
                        <td>--%>
                                                        <asp:Button ID="btnDetails" runat="server" Text="SEARCH" TabIndex="89" CommandName="SEARCH"
                                                            CssClass="ButtonClass" SkinID="btn" />
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
                                                        <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="cmbBranch"
                                                            Format="dd-MMM-yyyy" SkinID="Calendar" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtExpiryDate"
                                                            Format="dd-MMM-yyyy" SkinID="Calendar" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtPassportIssueDate"
                                                            Format="dd-MMM-yyyy" SkinID="Calendar" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtVisaExpDate"
                                                            Format="dd-MMM-yyyy" SkinID="Calendar" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtVisaIssueDate"
                                                            Format="dd-MMM-yyyy" SkinID="Calendar" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdob"
                                                            Format="dd-MMM-yyyy" SkinID="Calendar" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                            FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                                            TargetControlID="txtdob">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtLeavingDate"
                                                            Format="dd-MMM-yyyy" SkinID="Calendar" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                            FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                                            TargetControlID="txtLeavingDate">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <a name="bottom">
                                            </table>
                                        </center>
                                        <center>
                                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="900px" Height="300px">
                                                <asp:GridView ID="GVDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    EmptyDataText="There are no records to display." SkinID="GridView" Style="margin-bottom: 0px"
                                                    Width="650px" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                    Text="Edit" TabIndex="76"></asp:LinkButton>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                    OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                    Text="Delete" TabIndex="77"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Application No" SortExpression="ApplicationNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LabelAPP" runat="server" Text='<%# Bind("ApplicationNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="A_Year" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="labtay" runat="server" Text='<%# Bind("A_Year") %>' Visible="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Academic Year" SortExpression="AcademicYear">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblay" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Batch_no" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="labtbh" runat="server" Text='<%# Bind("BatchID") %>' Visible="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Batch No" SortExpression="Batch_No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="labelbat" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="labtit" runat="server" Value='<%# Bind("Title") %>' />
                                                                <asp:Label ID="lblFullName" Visible="false" runat="server" Text='<%# Bind("STD_FullName") %>'></asp:Label>
                                                                <asp:Label ID="lblNicNo" Visible="false" runat="server" Text='<%# Bind("NicNo") %>'></asp:Label>
                                                                <asp:Label ID="lblName" Visible="false" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                                                <asp:Label ID="lblName1" runat="server" Text='<%#String.Concat(Eval("StdName")," ",Eval("Middle_Name")," ",Eval("Last_Name")) %>'></asp:Label>
                                                                <asp:HiddenField ID="EID" runat="server" Value='<%# Bind("StdId") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LabelAN" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                                                <asp:Label ID="lblSecondUSN" runat="server" Visible="false" Text='<%# Bind("SecondStdCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Birth" SortExpression="DOB">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldob" runat="server" Text='<%# Bind("DOB","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Age">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbAg" runat="server" Text='<%# Bind("StdAge") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sex" SortExpression="StdSex">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbsx" runat="server" Text='<%# Bind("StdSex") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Father Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbfn" runat="server" Text='<%# Bind("FatherName") %>'></asp:Label>
                                                                <asp:HiddenField ID="lba_inc" runat="server" Value='<%# Bind("AnnualIncome","{0:n2}") %>' />
                                                                <asp:HiddenField ID="lbocc" runat="server" Value='<%# Bind("FatherOccupation") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mother Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMotherName" runat="server" Text='<%# Bind("MotherName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Permanent Address">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbpa" runat="server" Text='<%# Bind("Perm_Address") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="City">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbcty" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                                                <asp:HiddenField ID="lbdist" runat="server" Value='<%# Bind("District") %>' />
                                                                <asp:HiddenField ID="lbphoto" runat="server" Value='<%# Bind("Std_Photo") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Pincode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbpin" runat="server" Text='<%# Bind("PinCode") %>'></asp:Label>
                          
                                                                <asp:Label ID="lblTransport" runat="server" Text='<%# Bind("Transport") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblHostel" runat="server" Text='<%# Bind("Hostel") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Distance From School">
                                                            <ItemTemplate>
                                                                 <asp:Label ID="lbdis" runat="server" Text='<%# Bind("Distance") %>'></asp:Label>
                                                            
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="State/Province" SortExpression="StateName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbst" runat="server" Text='<%# Bind("State") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Country" SortExpression="Country">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbctry" runat="server" Visible="false" Text='<%# Bind("Country") %>'></asp:Label>
                                                                <asp:Label ID="Label37" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mother Contact No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbphno" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mother Email-Id">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbem" runat="server" Text='<%# Bind("Std_email") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Middle Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMnam" runat="server"  Text='<%# Bind("Middle_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Last Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLnam" runat="server" visiable ="false" Text='<%# Bind("Last_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Category" SortExpression="Std_CategoryName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbcaty" runat="server" Text='<%# Bind("categoryid") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="Labelcat" runat="server" Text='<%# Bind("Std_CategoryName") %>'></asp:Label>
                                                                <asp:Label ID="lbcatA" runat="server" Text='<%# Bind("AllocatedCatId") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="CADP" runat="server" Text='<%# Bind("AddressPeriod") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="LbBp" runat="server" Text='<%# Bind("BirthPlace") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblMnam" runat="server" Visible="false" Text='<%# Bind("Middle_Name") %>'></asp:Label>
                                                                <asp:Label ID="lblLnam" runat="server" Visible="false" Text='<%# Bind("Last_Name") %>'></asp:Label>
                                                                <asp:Label ID="Label38" runat="server" Visible="false" Text='<%# Bind("Ethnicity") %>'></asp:Label>
                                                                <asp:Label ID="lbcst" runat="server" Visible="false" Text='<%# Bind("CasteID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Caste">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcaste" runat="server" Text='<%# Bind("Caste") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="House Name" SortExpression="HouseName">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("HouseId") %>' />
                                                                <asp:Label ID="lblHouse" runat="server" Text='<%# Bind("HouseName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Branch" Visible="false">
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Course" SortExpression="CourseName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label23" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                                                <asp:Label ID="LabelCs" runat="server" Visible="false" Text='<%# Bind("Courseid") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Branch">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBranchN" runat="server" Visible="false" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                                <asp:Label ID="lblBranchcode" runat="server" Visible="false" Text='<%# Bind("Course_BranchCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sponsor">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSpon" runat="server" Text='<%# Bind("SponsorName") %>'></asp:Label>
                                                                <asp:HiddenField ID="hdnspn" runat="server" Value='<%# Bind("Sponsor_ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Admission Date" SortExpression="AdmissionDate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbladate" runat="server" Text='<%# Bind("AdmissionDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                <asp:Label ID="lblGVMentorId" Visible="false" runat="server" Text='<%# Bind("MentorId") %>'></asp:Label>
                                                                <asp:Label ID="lblGVChkDOB" Visible="false" runat="server" Text='<%# Bind("ChkDOB") %>'></asp:Label>
                                                                <asp:Label ID="lblGVChkIC" Visible="false" runat="server" Text='<%# Bind("ChkIC") %>'></asp:Label>
                                                                <asp:Label ID="lblGVChkMigrationCertificate" Visible="false" runat="server" Text='<%# Bind("ChkMigrationCertificate") %>'></asp:Label>
                                                                <asp:Label ID="lblGVChkTenth" Visible="false" runat="server" Text='<%# Bind("ChkTenth") %>'></asp:Label>
                                                                <asp:Label ID="lblGVChktwelve" Visible="false" runat="server" Text='<%# Bind("Chktwelve") %>'></asp:Label>
                                                                <asp:Label ID="lblGVChkBachelorDegree" Visible="false" runat="server" Text='<%# Bind("ChkBachelorDegree") %>'></asp:Label>
                                                                <asp:Label ID="lblGVChkMasterDegree" Visible="false" runat="server" Text='<%# Bind("ChkMasterDegree") %>'></asp:Label>
                                                                <asp:Label ID="lblGVChkTC" Visible="false" runat="server" Text='<%# Bind("ChkTC") %>'></asp:Label>
                                                                <asp:Label ID="Label26" Visible="false" runat="server" Text='<%# Bind("ChkLOS") %>'></asp:Label>
                                                                <asp:Label ID="Label29" Visible="false" runat="server" Text='<%# Bind("ChkAOR") %>'></asp:Label>
                                                                <asp:Label ID="Label30" Visible="false" runat="server" Text='<%# Bind("ChkAOU") %>'></asp:Label>
                                                                <asp:Label ID="Label31" Visible="false" runat="server" Text='<%# Bind("ChkCPhoto") %>'></asp:Label>
                                                                 <asp:Label ID="LabeGVChkSLC" Visible="false" runat="server" Text='<%# Bind("Chkslc") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="false"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fee Collected">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelfee" runat="server" Text='<%# Bind("FeeCollected") %>'></asp:Label>
                                                                <asp:Label ID="lbddn" runat="server" Visible="false" Text='<%# Bind("DDPayOrderNo") %>'></asp:Label>
                                                                <asp:Label ID="lbrno" runat="server" Visible="false" Text='<%# Bind("Receipt_No") %>'></asp:Label>
                                                                <asp:HiddenField ID="addm_typ" runat="server" Visible="false" Value='<%# Bind("Admission_Type") %>' />
                                                                <asp:Label ID="lbpno" runat="server" Visible="false" Text='<%# Bind("Prospectus_No") %>'></asp:Label>
                                                                <asp:Label ID="lblLeaving" runat="server" Visible="false" Text='<%# Bind("LeavingDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                <asp:Label ID="lblStudentContact" runat="server" Visible="false" Text='<%# Bind("StudentContact") %>'></asp:Label>
                                                                <asp:Label ID="lblStudentEmail" runat="server" Visible="false" Text='<%# Bind("StudentEmail") %>'></asp:Label>
                                                                <asp:Label ID="CADD" runat="server" Text='<%# Bind("Temp_Address") %>' Visible="false" />
                                                                <asp:Label ID="lblFatherEmail" runat="server" Visible="false" Text='<%# Bind("FatherEmail") %>'></asp:Label>
                                                                <asp:Label ID="lblFatherContact" runat="server" Visible="false" Text='<%# Bind("FatherContact") %>'></asp:Label>
                                                                <asp:Label ID="lblNameInPassport" runat="server" Text='<%# Bind("NameInPassport") %>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblPlaceofIssue" runat="server" Visible="false" Text='<%# Bind("PlaceofIssue") %>'></asp:Label>
                                                                <asp:Label ID="lblPassportNo" runat="server" Visible="false" Text='<%# Bind("PassportNo") %>'></asp:Label>
                                                                <asp:Label ID="lblPassportExpiryDate" runat="server" Visible="false" Text='<%# Bind("PassportExpiryDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                <asp:Label ID="lblPassportIssueDate" runat="server" Text='<%# Bind("PassportIssueDate","{0:dd-MMM-yyyy}") %>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblVisaExpDate" runat="server" Visible="false" Text='<%# Bind("VisaExpiryDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                <asp:Label ID="lblVisaIssueDate" runat="server" Visible="false" Text='<%# Bind("VisaIssueDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                <asp:Label ID="lblVisaNo" runat="server" Visible="false" Text='<%# Bind("VisaNo") %>'></asp:Label>
                                                                <asp:Label ID="lblFRROExpDate" runat="server" Visible="false" Text='<%# Bind("FRROExpDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                <asp:Label ID="lblTCNo" runat="server" Text='<%# Bind("TCNo") %>' Visible="false" />
                                                                <asp:Label ID="lblMotherTongue" runat="server" Visible="false" Text='<%# Bind("MotherTongue") %>'></asp:Label>
                                                                <asp:Label ID="lblRemarks" runat="server" Visible="false" Text='<%# Bind("Remark") %>'></asp:Label>
                                                                <asp:Label ID="FatherHomeContact" runat="server" Visible="false" Text='<%# Bind("FatherHomeContact") %>'></asp:Label>
                                                                <asp:Label ID="MontherHomeContact" runat="server" Visible="false" Text='<%# Bind("MontherHomeContact") %>'></asp:Label>
                                                                <asp:Label ID="FatherBizOffice" runat="server" Visible="false" Text='<%# Bind("FatherBizOffice") %>'></asp:Label>
                                                                <asp:Label ID="MotherBizOffice" runat="server" Visible="false" Text='<%# Bind("MotherBizOffice") %>'></asp:Label>
                                                                <asp:Label ID="FatherQualification" runat="server" Visible="false" Text='<%# Bind("FatherQualification") %>'></asp:Label>
                                                                <asp:Label ID="MotherQualification" runat="server" Visible="false" Text='<%# Bind("MotherQualification") %>'></asp:Label>
                                                                <asp:Label ID="Religion" runat="server" Visible="false" Text='<%# Bind("Religion") %>'></asp:Label>
                                                                <asp:Label ID="MotherOccupation" runat="server" Visible="false" Text='<%# Bind("MotherOccupation") %>'></asp:Label>
                                                                <asp:Label ID="SMS" runat="server" Visible="false" Text='<%# Bind("SMS") %>'></asp:Label>
                                                                <asp:Label ID="Mail" runat="server" Visible="false" Text='<%# Bind("Mail") %>'></asp:Label>
                                                                <asp:Label ID="Label32" runat="server" Visible="false" Text='<%# Bind("GDName") %>'></asp:Label>
                                                                <asp:Label ID="Label33" runat="server" Visible="false" Text='<%# Bind("GDContactNo") %>'></asp:Label>
                                                                <asp:Label ID="Label34" runat="server" Visible="false" Text='<%# Bind("Citizenship") %>'></asp:Label>
                                                                <asp:Label ID="Label35" runat="server" Visible="false" Text='<%# Bind("GDEmailID") %>'></asp:Label>
                                                                <asp:Label ID="Label36" runat="server" Visible="false" Text='<%# Bind("GDOccupation") %>'></asp:Label>
                                                                <asp:Label ID="Label39" runat="server" Visible="false" Text='<%# Bind("GDRelation") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <%--s.PassportIssueDate = txtPassportIssueDate.Text
                s.VisaExpDate = txtVisaExpDate.Text
                s.VisaIssueDate = txtVisaIssueDate.Text
                s.VisaNo = txtVisaNo.Text--%>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
