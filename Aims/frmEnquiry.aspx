<%@ Page Language="VB" AutoEventWireup="false" Inherits="frmEnquiry" CodeFile="frmEnquiry.aspx.vb"
    Title="General Enquiry" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>General Enquiry</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlBranch.ClientID %>"), 'Branch');
            if (msg != "") {
                document.getElementById("<%=ddlBranch.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtDate.ClientID %>"), 'Date');
            if (msg != "") {
                document.getElementById("<%=txtDate.ClientID %>").focus();
                return msg;
            }
            msg = minlength(document.getElementById("<%=txtEnqno.ClientID %>"), 1, 'Enquiry No');
            if (msg != "") {
                document.getElementById("<%=txtEnqno.ClientID %>").focus();
                return msg;
            }
            msg = DropDown(document.getElementById("<%=cmbTitle.ClientID %>"), 'Title');
            if (msg != "") {
                document.getElementById("<%=cmbTitle.ClientID %>").focus();
                return msg;
            }

            msg = NameField100(document.getElementById("<%=txtFName.ClientID %>"), 'Name');
            if (msg != "") {
                document.getElementById("<%=txtFName.ClientID %>").focus();
                return msg;
            }


            msg = validateName(document.getElementById("<%=txtcity.ClientID %>"), 'City');
            if (msg != "") {
                document.getElementById("<%=txtcity.ClientID %>").focus();
                return msg;
            }
            msg = validateName(document.getElementById("<%=TxtDistrict.ClientID %>"), 'District');
            if (msg != "") {
                document.getElementById("<%=TxtDistrict.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlState.ClientID %>"), 'State');
            if (msg != "") {
                document.getElementById("<%=ddlState.ClientID %>").focus();
                return msg;
            }
            msg = Field30N(document.getElementById("<%=txtCountry.ClientID %>"), 'Country');
            if (msg != "") {
                document.getElementById("<%=txtCountry.ClientID %>").focus();
                return msg;
            }
            msg = MobField(document.getElementById("<%=txtMobile.ClientID %>"), 'Mobile No');
            if (msg != "") {
                document.getElementById("<%=txtMobile.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=txtcaste.ClientID %>"), 'Caste');
            if (msg != "") {
                document.getElementById("<%=txtcaste.ClientID %>").focus();
                return msg;
            }
            msg = NameField100N(document.getElementById("<%=txtfathersname.ClientID %>"), 'Mother Name');
            if (msg != "") {
                document.getElementById("<%=txtfathersname.ClientID %>").focus();
                return msg;
            }
            msg = Field50N(document.getElementById("<%=txtoccupation.ClientID %>"), 'Parent Occupation');
            if (msg != "") {
                document.getElementById("<%=txtoccupation.ClientID %>").focus();
                return msg;
            }
            msg = Field50N(document.getElementById("<%=txtQ.ClientID %>"), 'Qualification');
            if (msg != "") {
                document.getElementById("<%=txtQ.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbERelates.ClientID %>"), 'Enquiry Related to');
            if (msg != "") {
                document.getElementById("<%=cmbERelates.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbCourseType.ClientID %>"), 'Course Type');
            if (msg != "") {
                document.getElementById("<%=cmbCourseType.ClientID %>").focus();
                return msg;
            }
            msg = DropDown(document.getElementById("<%=ddlCourse.ClientID %>"), 'Course Name');
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlSource.ClientID %>"), 'Source of Information');
            if (msg != "") {
                document.getElementById("<%=ddlSource.ClientID %>").focus();
                return msg;
            }


            msg = DropDownForZero(document.getElementById("<%=ddlCourse.ClientID %>"), 'Course Name');
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID %>").focus();
                return msg;
            }
            msg = Field1(document.getElementById("<%=txtmarks.ClientID %>"), 'Marks');
            if (msg != "") {
                document.getElementById("<%=txtmarks.ClientID %>").focus();
                return msg;
            }
            msg = Field255N(document.getElementById("<%=txtEnquiry.ClientID %>"), 'Remarks');
            if (msg != "") {
                document.getElementById("<%=txtEnquiry.ClientID %>").focus();
                return msg;
            }
            msg = Field255N(document.getElementById("<%=txtAddress.ClientID %>"), 'Street Address');
            if (msg != "") {
                document.getElementById("<%=txtAddress.ClientID %>").focus();
                return msg;
            }
            msg = NameField100N(document.getElementById("<%=txtenquirer.ClientID %>"), 'Enquirer');
            if (msg != "") {
                document.getElementById("<%=txtenquirer.ClientID %>").focus();
                return msg;
            }

            //txtMobile
            var value = document.getElementById('<%=txtEmail.ClientId %>').value.replace(/^\s+|\s+$/g, '');
            if (window.value.length > 0) {
                msg = validateEmail(document.getElementById("<%=txtEmail.ClientID %>"), 'Email');

                if (msg != "") {
                    document.getElementById("<%=txtEmail.ClientID %>").focus();
                    return msg;
                }
                msg = FeesField(document.getElementById("<%=txtannualincome.ClientID %>"), 'Annual income');
                if (msg != "") {
                    document.getElementById("<%=txtannualincome.ClientID %>").focus();
                    return msg;
                }
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msgInfo.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msgInfo.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
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
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" />
                </div>
            </a>
            <br />
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <center>
                    <table class="custTable">
                        <tbody>
                            <tr>
                                <asp:HiddenField ID="LanguageID1" runat="server" />
                                <asp:HiddenField ID="HF" runat="server" />
                                <asp:Label ID="Label24" runat="server" Visible="false"></asp:Label>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" Text="Branch*^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="ObjBranch" DataTextField="BranchName"
                                        DataValueField="BranchCode" SkinID="ddlL" TabIndex="1" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <center>
                        <hr />
                    </center>
                    <table class="custTable">
                        <tbody>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEnqno" runat="server" Text="Enquiry No* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEnqno" TabIndex="2" runat="server" SkinID="txt" AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" Text="Date* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDate" TabIndex="14" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                        MaxLength="11"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Title* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbTitle" TabIndex="3" runat="server" SkinID="ddl" CssClass="cmb">
                                        <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                        <asp:ListItem>Mr.</asp:ListItem>
                                        <asp:ListItem>Ms.</asp:ListItem>
                                        <asp:ListItem>Mrs.</asp:ListItem>
                                        <asp:ListItem>Dr.</asp:ListItem>
                                        <asp:ListItem>Prof.</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="Street Address :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAddress" runat="server" SkinID="txt" MaxLength="60" TabIndex="15"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="Name*^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFName" TabIndex="4" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                        ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtFName">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" Text="City :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtCity" TabIndex="16" runat="server" SkinID="txt" MaxLength="60"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblNicNo" runat="server" Text="Aadhaar/NIC No^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNicNo" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'~!@#$%^&*()_+,<>.?/:;}]{[|\"
                                        TargetControlID="txtNicNo">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" Text="PinCode :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtPnCode" TabIndex="17" runat="server" MaxLength="6" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDOB" runat="server" SkinID="lbl" Text="Date of Birth :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDOB" runat="server" AutoCompleteType="Disabled" MaxLength="11"
                                        SkinID="txt" TabIndex="6" AutoPostBack="True"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtDOB">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                        FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                        TargetControlID="txtDOB">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label20" runat="server" Text="District :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtDistrict" TabIndex="18" MaxLength="60" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblage" runat="server" Text="Age :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtage" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label21" runat="server" Text="State* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlState" TabIndex="19" MaxLength="60" runat="server" SkinID="ddl"
                                        DataSourceID="ObjState" DataTextField="StateName" DataValueField="StateId" AppendDataBoundItems="true">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcaste" runat="server" Text="Race/Caste/SubCaste* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <%--  <asp:TextBox ID="txtcaste" TabIndex="8" runat="server" SkinID="txt" MaxLength="50"></asp:TextBox>--%>
                                    <asp:DropDownList ID="txtcaste" runat="server" AppendDataBoundItems="True" DataSourceID="ObjTitle"
                                        DataTextField="Data" AutoPostBack="False" DataValueField="LookUpAutoID" SkinID="ddl"
                                        TabIndex="8">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjTitle" runat="server" SelectMethod="Getcaste" TypeName="EnquiryDB">
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="Country :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left" style="width: 434px; height: 26px" rowspan="1">
                                    <asp:TextBox ID="txtCountry" TabIndex="20" MaxLength="60" runat="server" SkinID="txt"
                                        AutoCompleteType="Disabled" value="India" CssClass=" "></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label23" runat="server" SkinID="lblRsz" Text="Student Category :&nbsp;&nbsp;"
                                        Width="200"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:DropDownList ID="ddlcategry" runat="server" DataSourceID="ObjCategory" DataTextField="CategoryName"
                                        DataValueField="Category_Id" SkinID="ddl" TabIndex="9">
                                        <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCategory" runat="server" SelectMethod="GetCategoryyy"
                                        TypeName="CategoryDB"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Parent's Information</b>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblfathersname" runat="server" Text="Parent's Name :&nbsp;&nbsp;"
                                        SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtfathersname" TabIndex="10" MaxLength="60" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label10" runat="server" Text="Phone No :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPhone" TabIndex="21" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtPhone">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblq" runat="server" Text="Qualification :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtQ" TabIndex="11" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                        MaxLength="50"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Mobile No* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMobile" TabIndex="22" runat="server" SkinID="txt" AutoCompleteType="Disabled"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtMobile">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbloccupation" runat="server" Text="Occupation :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtoccupation" MaxLength="60" TabIndex="12" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" Text="Email :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEmail" TabIndex="23" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                        MaxLength="50"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                        FilterMode="InValidChars" InvalidChars=" " TargetControlID="txtEmail">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAnnualincome" runat="server" Text="Annual Income :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtannualincome" MaxLength="10" TabIndex="13" runat="server" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                        FilterMode="validChars" FilterType="Custom" ValidChars=".0123456789" TargetControlID="txtannualincome">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                    </table>
                    <center>
                        <hr />
                    </center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" Text="Enquiry Related To*^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="175px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbERelates" TabIndex="24" runat="server" SkinID="ddl" AutoPostBack="True"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem>Course</asp:ListItem>
                                    <asp:ListItem>Admission</asp:ListItem>
                                    <asp:ListItem>Fee</asp:ListItem>
                                    <asp:ListItem>Career</asp:ListItem>
                                </asp:DropDownList>
                                <td align="right">
                                    <asp:Label ID="Label7" runat="server" Text="Source Of Info* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSource" TabIndex="28" runat="server" SkinID="ddl" DataTextField="SourceofInfo"
                                        DataValueField="SIMIDAuto" DataSourceID="ObjSourceofInfo" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" Text="Course Type* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbCourseType" TabIndex="25" runat="server" SkinID="ddl" AutoPostBack="True"
                                    DataSourceID="ObjCourseType" DataTextField="CourseType" DataValueField="CourseType_ID"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblEnquirer" runat="server" Text="Counselor :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtenquirer" MaxLength="60" TabIndex="29" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label12" runat="server" Text="Course Name* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCourse" TabIndex="26" runat="server" SkinID="ddlRsz" DataSourceID="ObjCourse"
                                    DataTextField="CourseName" DataValueField="Courseid" Width="200px" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="height: 40px" align="right">
                                <asp:Label ID="Label6" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left" style="height: 40px">
                                <asp:TextBox ID="txtEnquiry" TabIndex="30" runat="server" SkinID="txt" MaxLength="60"
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMarks" runat="server" Text="Marks(%)*  
                                            
                                             :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtmarks" TabIndex="27" runat="server" SkinID="txt" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtMobile">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        </tbody>
                        <tbody>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblenquiryno" runat="server" Width="76px" Text="Enquiry No :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtenquiryno" MaxLength="60" TabIndex="31" runat="server" SkinID="txt"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" Text="Prospectus Given :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="RadioButtonList1" TabIndex="32" runat="server" AutoPostBack="True"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Value="-1" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <%-- </tr>
                                <tr>--%>
                                <%--</tr>
                                <tr>--%>
                                <%--<td align="right">
                                        &nbsp;
                                    </td>--%>
                                <td align="left">
                                    <asp:CheckBox ID="ChkTransport" TabIndex="33" runat="server" Text="Transport" />
                                </td>
                                <%--<td align="right">
                                        &nbsp;
                                    </td>--%>
                                <td align="left">
                                    <asp:CheckBox ID="ChkHostel" TabIndex="34" runat="server" Text="Hostel" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtID" TabIndex="35" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                        MaxLength="20" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <!--ALL THE BUTTONS KEEP IN SINGLE TD AND APPLY THE CssStyle="btnStyle"-->
                            <td class="btnTd">
                                <asp:Button ID="btnSave" CommandName="ADD" runat="server" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="36" Text="ADD" ValidationGroup="save" />
                                &nbsp;<asp:Button ID="btnDetails" CommandName="VIEW" runat="server" CausesValidation="False"
                                    CssClass="ButtonClass" SkinID="btn" TabIndex="37" Text="VIEW" />
                                &nbsp;<%--<asp:Button ID="BtnAcknowledgement" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                        SkinID="btn" TabIndex="34" Text="ACKNOWLEDGEMENT" />--%>
                            </td>
                        </tr>
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
                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="msgInfo" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="1234567890/-" TargetControlID="txtenquirer">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxCountry" runat="server" FilterMode="InvalidChars"
                                    FilterType="Numbers" InvalidChars="1234567890/-" TargetControlID="txtCountry">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxDistict" runat="server" FilterMode="InvalidChars"
                                    FilterType="Numbers" InvalidChars="1234567890/-" TargetControlID="TxtDistrict">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxCity" runat="server" FilterMode="InvalidChars"
                                    FilterType="Numbers" InvalidChars="1234567890/-" TargetControlID="TxtCity">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="1234567890/-" TargetControlID="txtcaste">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="1234567890/-" TargetControlID="txtFName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="1234567890/-" TargetControlID="txtcaste">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="1234567890/-" TargetControlID="txtfathersname">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                    SkinID="Calendar" TargetControlID="txtDate">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                    FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                    TargetControlID="txtDate">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="#+_=/*()'@[]{}?&gt;&lt;&amp;^%$!~`;:\|0123456789"
                                    TargetControlID="txtFName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxPincode" runat="server" FilterMode="validChars"
                                    FilterType="Numbers" TargetControlID="TxtPnCode" ValidChars="0123456789">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetBranchByUID" TypeName="BranchManager"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjState" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetState" TypeName="EnquiryManager">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="0" Name="StateId" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjCourseType" runat="server" TypeName="CourseDB" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetCourseTypeExt"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjCourse" runat="server" TypeName="CourseDB" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetCourseByTypeExt">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cmbCourseType" DefaultValue="0" Name="Course_ID"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjSourceofInfo" runat="server" TypeName="EnquiryDB" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="SourceofInfo"></asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="100" DataKeyNames="EId" SkinID="GridView" TabIndex="-1" AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LkSelect" runat="server" CausesValidation="False" CommandName="Select"
                                            Text="Acknowledge" />
                                        <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" />
                                        <asp:LinkButton ID="Button3" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Do you want to delete this record?')" Text="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enquiry No" SortExpression="EnquiryNo">
                                    <ItemTemplate>
                                        <asp:Label ID="Labelenq" runat="server" Visible="false" Text='<%# Bind("EID") %>'></asp:Label>
                                        <asp:Label ID="Label14" runat="server" Visible="false" Text='<%# Bind("EnqCode") %>'></asp:Label>
                                        <asp:Label ID="Label17" runat="server" Visible="false" Text='<%# Bind("Enquiry_No") %>'></asp:Label>
                                        <asp:Label ID="lblCategory" runat="server" Visible="false" Text='<%# Bind("CategoryId") %>'></asp:Label>
                                        <asp:Label ID="lblMarks" runat="server" Visible="false" Text='<%# Bind("Marks") %>'></asp:Label>
                                        <asp:Label ID="Label22" runat="server" Text='<%# Bind("EnquiryNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Name" SortExpression="Branch_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchCode" runat="server" Text='<%# Bind("BranchCode") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="LabelBid" runat="server" Text='<%# Bind("Branch_Code") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="LabelBranch" runat="server" Text='<%# Bind("Branch_Name") %>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" SortExpression="EDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldate" runat="server" Text='<%# Bind("EDate","{0:dd-MMM-yyyy}") %>'
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("EId") %>' />
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Underline="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression="FName">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("FName") %>'></asp:Label>
                                        <asp:Label ID="lblDOB" runat="server" Visible="false" Text='<%# Bind("DOB") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aadhaar/NIC No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNicNo" runat="server" Text='<%# Bind("NicNo") %>' Width="150px"></asp:Label>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Phone") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile No">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelMob" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Street Address">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City" SortExpression="City">
                                    <ItemTemplate>
                                        <asp:Label ID="Labelcty" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PinCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Labelpc" runat="server" Text='<%# Bind("PinCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="District" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Labeldt" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                        <asp:Label ID="Labelstt" runat="server" Text='<%# Bind("StateId") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State" SortExpression="StateName">
                                    <ItemTemplate>
                                        <asp:Label ID="Labelst" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country" SortExpression="Country">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Counselor">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelCon" runat="server" Text='<%# Bind("Enquirer") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Caste" SortExpression="Caste">
                                    <ItemTemplate>
                                    <asp:Label ID="LabelCst" runat="server" Visible="False" Text='<%# Bind("Caste") %>'></asp:Label>
                                        <asp:Label ID="lblcaste" runat="server" Text='<%# Bind("Data") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enquiry Related To" SortExpression="ERelates">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ERelates") %>'></asp:Label>
                                        <asp:Label ID="LabelCtt" runat="server" Visible="False" Text='<%# Bind("CourseType_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Course Type" SortExpression="CourseType">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelCt" runat="server" Text='<%# Bind("CourseType") %>'></asp:Label>
                                        <asp:Label ID="LabelCc" runat="server" Visible="False" Text='<%# Bind("Course_Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Course Name" SortExpression="CourseName">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelC" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Source of Information" SortExpression="SourceofInfo">
                                    <ItemTemplate>
                                        <asp:Label ID="Labelso" runat="server" Text='<%# Bind("Source") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="LabelSource" runat="server" Text='<%# Bind("SourceofInfo") %>'></asp:Label>
                                        <asp:Label ID="lblTransport" runat="server" Text='<%# Bind("Transport") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblHostel" runat="server" Text='<%# Bind("Hostel") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prospectus">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelPG" runat="server" Text='<%# Bind("Prospectus_Given") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" Width="150px" runat="server" Text='<%# Bind("YEnquiry") %>'></asp:Label>
                                        <asp:Label ID="LabelQual" runat="server" Text='<%# Bind("Qualification") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mother Name" SortExpression="FatherName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfathersname" runat="server" Text='<%# Bind("FatherName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Parent's Occuption" SortExpression="FatherOccupation">
                                    <ItemTemplate>
                                        <asp:Label ID="Labelfat" runat="server" Text='<%# Bind("FatherOccupation") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Annual Income">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelAnn" runat="server" align="right" Text='<%# Bind("AnnualIncome","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <br />
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
