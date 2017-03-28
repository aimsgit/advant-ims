<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAdmissionDetails.aspx.vb"
    Inherits="frmAdmissionDetails" Title="Admission Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admission Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <%--<script type="text/javascript" language="javascript">
        function ValidReport() {
            var msg;
            msg = AutoCompleteExtender(document.getElementById("<%=txtCourse.ClientID %>"), 'Course');
            if (msg != "") return msg;
            msg = AutoCompleteExtender(document.getElementById("<%=txtBatch.ClientID %>"), 'Academic Year');
            if (msg != "") return msg;
            msg = AutoCompleteExtender(document.getElementById("<%=txtStdCode.ClientID %>"), 'Student Code');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtEntryDate.ClientID %>"), 'Entry Date');
            if (msg != "") return msg;
            return true;
        }
        function ValidateReport() {

            var msg = ValidReport();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>--%>
 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

                <center>
                <br />
                    <h1 class="headingTxt">
                        <asp:Label ID="Labelbad" runat="server" Text="ADMISSION REGISTER" SkinID="lblRepRsz"
                            Width="250" Visible="True"></asp:Label></h1>
                            <br />
                </center>
                <center>
                 <br />
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBranch" runat="server" SkinID="lbl" Text="Branch :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLBranch" runat="server" SkinID="ddlRsz" Width="195px" DataSourceID="ObjBranch"
                                    DataTextField="BranchName" DataValueField="BranchCode" AutoPostBack="True" TabIndex="1">
                                </asp:DropDownList>
                                <%--&nbsp;--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblGender" runat="server" SkinID="lbl" Text="Gender :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLGender" runat="server" SkinID="ddl" TabIndex="3">
                                    <asp:ListItem Value="1" Text="All"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Male"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Female"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblA_Year" runat="server" Text="Academic Calendar Year*:&nbsp;&nbsp;"
                                    SkinID="lblRSz" Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLA_Year" TabIndex="2" runat="server" SkinID="ddlRsz" Width="195px" AutoPostBack="True"
                                    DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjAcademic" runat="server" TypeName="BLNew_stdMarks" SelectMethod="GetAcademicCombo">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLBranch" DefaultValue="0" DbType="String" Name="BranchCode" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblCaste" runat="server" SkinID="lblRsz" Width="180px" Text="Race/Caste/SubCaste&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlcaste" runat="server" AppendDataBoundItems="True" DataSourceID="objcast"
                                DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="60">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objcast" runat="server" SelectMethod="CasteCombo" TypeName="DLPrinicipalDashBoard">
                                </asp:ObjectDataSource>
                             </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text=" Course :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCourse" runat="server" SkinID="ddlRsz" Width="195px" DataSourceID="objCourse"
                                    DataTextField="CourseName" DataValueField="CourseCode" AutoPostBack="true" TabIndex="4">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseComboAdmission"
                                    TypeName="BLNewCoursePlanner">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLBranch" DefaultValue="0" DbType="String" Name="BranchCode" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblCountry" runat="server" SkinID="lbl" Text="Country :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLCountry" runat="server" SkinID="ddl" DataSourceID="objCountry"
                                    DataTextField="Country" DataValueField="Country" TabIndex="7" AutoPostBack ="true" AppendDataBoundItems="true" >
                            
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objCountry" runat="server" TypeName="EnquiryManager" SelectMethod="getCountry">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" Text="Batch :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbBatch" TabIndex="6" runat="server" SkinID="ddlRsz" Width="195px" AutoPostBack="True"
                                     DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" TypeName="StudentListDB" SelectMethod="BatchOpen1">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLBranch" PropertyName="SelectedValue" DbType="String"
                                            Name="BranchCode" />
                                        <asp:ControlParameter ControlID="DDLA_Year" PropertyName="SelectedValue" Name="A_Year"
                                            DefaultValue="0" Type="Int16" />
                                        <asp:ControlParameter ControlID="ddlCourse" PropertyName="SelectedValue" Name="Course"
                                            DefaultValue="0" Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblState" runat="server" SkinID="lblrsz" Text="State:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLState" runat="server" SkinID="ddl" DataSourceID="ObjState"
                                    DataTextField="StateName" DataValueField="StateId" TabIndex="5" AutoPostBack ="true" >
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFromAge" runat="server" SkinID="lbl" Text="From Age :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlFromAge" runat="server" SkinID="ddl" TabIndex="8">
                                    <asp:ListItem Text="All" Value="0.0"></asp:ListItem>
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                    <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                    <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                    <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                    <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                    <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                    <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                    <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                    <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                    <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                    <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                    <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                    <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                    <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                    <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                    <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                    <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                    <asp:ListItem Text="61" Value="61"></asp:ListItem>
                                    <asp:ListItem Text="62" Value="62"></asp:ListItem>
                                    <asp:ListItem Text="63" Value="63"></asp:ListItem>
                                    <asp:ListItem Text="64" Value="64"></asp:ListItem>
                                    <asp:ListItem Text="65" Value="65"></asp:ListItem>
                                    <asp:ListItem Text="66" Value="66"></asp:ListItem>
                                    <asp:ListItem Text="67" Value="67"></asp:ListItem>
                                    <asp:ListItem Text="68" Value="68"></asp:ListItem>
                                    <asp:ListItem Text="69" Value="69"></asp:ListItem>
                                    <asp:ListItem Text="70" Value="60"></asp:ListItem>
                                    <asp:ListItem Text="71" Value="71"></asp:ListItem>
                                    <asp:ListItem Text="72" Value="72"></asp:ListItem>
                                    <asp:ListItem Text="73" Value="73"></asp:ListItem>
                                    <asp:ListItem Text="74" Value="74"></asp:ListItem>
                                    <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                    <asp:ListItem Text="76" Value="76"></asp:ListItem>
                                    <asp:ListItem Text="77" Value="77"></asp:ListItem>
                                    <asp:ListItem Text="78" Value="78"></asp:ListItem>
                                    <asp:ListItem Text="79" Value="79"></asp:ListItem>
                                    <asp:ListItem Text="80" Value="80"></asp:ListItem>
                                    <asp:ListItem Text="81" Value="81"></asp:ListItem>
                                    <asp:ListItem Text="82" Value="82"></asp:ListItem>
                                    <asp:ListItem Text="83" Value="83"></asp:ListItem>
                                    <asp:ListItem Text="84" Value="84"></asp:ListItem>
                                    <asp:ListItem Text="85" Value="85"></asp:ListItem>
                                    <asp:ListItem Text="86" Value="86"></asp:ListItem>
                                    <asp:ListItem Text="87" Value="87"></asp:ListItem>
                                    <asp:ListItem Text="88" Value="88"></asp:ListItem>
                                    <asp:ListItem Text="89" Value="89"></asp:ListItem>
                                    <asp:ListItem Text="90" Value="90"></asp:ListItem>
                                    <asp:ListItem Text="91" Value="91"></asp:ListItem>
                                    <asp:ListItem Text="92" Value="92"></asp:ListItem>
                                    <asp:ListItem Text="93" Value="93"></asp:ListItem>
                                    <asp:ListItem Text="94" Value="94"></asp:ListItem>
                                    <asp:ListItem Text="95" Value="95"></asp:ListItem>
                                    <asp:ListItem Text="96" Value="96"></asp:ListItem>
                                    <asp:ListItem Text="97" Value="97"></asp:ListItem>
                                    <asp:ListItem Text="98" Value="98"></asp:ListItem>
                                    <asp:ListItem Text="99" Value="99"></asp:ListItem>
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblDistrict" runat="server" SkinID="lbl" Text="District :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDistrict" runat="server" DataSourceID="objDistrict" DataTextField="District"
                                    DataValueField="District" SkinID="ddl" TabIndex="9" AutoPostBack ="true" >
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDistrict" runat="server" SelectMethod="getDistrict1"
                                    TypeName="EnquiryDB">
                                    <SelectParameters>
                                    
                                         <asp:ControlParameter ControlID="DDLState" PropertyName="SelectedValue" DbType="String"
                                            Name="StateId" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblToAge" runat="server" SkinID="lbl" Text="To Age :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlToAge" runat="server" SkinID="ddl" TabIndex="10">
                                    <asp:ListItem Text="All" Value="1000"></asp:ListItem>
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                    <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                    <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                    <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                    <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                    <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                    <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                    <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                    <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                    <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                    <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                    <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                    <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                    <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                    <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                    <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                    <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                    <asp:ListItem Text="61" Value="61"></asp:ListItem>
                                    <asp:ListItem Text="62" Value="62"></asp:ListItem>
                                    <asp:ListItem Text="63" Value="63"></asp:ListItem>
                                    <asp:ListItem Text="64" Value="64"></asp:ListItem>
                                    <asp:ListItem Text="65" Value="65"></asp:ListItem>
                                    <asp:ListItem Text="66" Value="66"></asp:ListItem>
                                    <asp:ListItem Text="67" Value="67"></asp:ListItem>
                                    <asp:ListItem Text="68" Value="68"></asp:ListItem>
                                    <asp:ListItem Text="69" Value="69"></asp:ListItem>
                                    <asp:ListItem Text="70" Value="60"></asp:ListItem>
                                    <asp:ListItem Text="71" Value="71"></asp:ListItem>
                                    <asp:ListItem Text="72" Value="72"></asp:ListItem>
                                    <asp:ListItem Text="73" Value="73"></asp:ListItem>
                                    <asp:ListItem Text="74" Value="74"></asp:ListItem>
                                    <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                    <asp:ListItem Text="76" Value="76"></asp:ListItem>
                                    <asp:ListItem Text="77" Value="77"></asp:ListItem>
                                    <asp:ListItem Text="78" Value="78"></asp:ListItem>
                                    <asp:ListItem Text="79" Value="79"></asp:ListItem>
                                    <asp:ListItem Text="80" Value="80"></asp:ListItem>
                                    <asp:ListItem Text="81" Value="81"></asp:ListItem>
                                    <asp:ListItem Text="82" Value="82"></asp:ListItem>
                                    <asp:ListItem Text="83" Value="83"></asp:ListItem>
                                    <asp:ListItem Text="84" Value="84"></asp:ListItem>
                                    <asp:ListItem Text="85" Value="85"></asp:ListItem>
                                    <asp:ListItem Text="86" Value="86"></asp:ListItem>
                                    <asp:ListItem Text="87" Value="87"></asp:ListItem>
                                    <asp:ListItem Text="88" Value="88"></asp:ListItem>
                                    <asp:ListItem Text="89" Value="89"></asp:ListItem>
                                    <asp:ListItem Text="90" Value="90"></asp:ListItem>
                                    <asp:ListItem Text="91" Value="91"></asp:ListItem>
                                    <asp:ListItem Text="92" Value="92"></asp:ListItem>
                                    <asp:ListItem Text="93" Value="93"></asp:ListItem>
                                    <asp:ListItem Text="94" Value="94"></asp:ListItem>
                                    <asp:ListItem Text="95" Value="95"></asp:ListItem>
                                    <asp:ListItem Text="96" Value="96"></asp:ListItem>
                                    <asp:ListItem Text="97" Value="97"></asp:ListItem>
                                    <asp:ListItem Text="98" Value="98"></asp:ListItem>
                                    <asp:ListItem Text="99" Value="99"></asp:ListItem>
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                             
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Fee Collected :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFeecollected" runat="server" AppendDataBoundItems="true"
                                    TabIndex="11" AutoPostBack="True" DataTextField="Batch_No" DataValueField="BatchID"
                                    SkinID="ddl">
                                    <asp:ListItem Value="A">All</asp:ListItem>
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Width="150px" Text="Age As On :&nbsp;"></asp:Label>
                            </td>
                            <td align="left" >
                                <asp:TextBox ID="txtFromDateExt" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                             <td align="right">
                                 <ajaxToolkit:CalendarExtender ID="FromDateExt" runat="server" TargetControlID="txtFromDateExt"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                               
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" SkinID="lblRsz" Width="150px" Text="Student Category :&nbsp;"></asp:Label>
                            </td>
                            <td align="left" >
                                <asp:DropDownList ID="ddlcategry" runat="server" DataSourceID="ObjCategory" DataTextField="CategoryName"
                                    DataValueField="Category_Id" SkinID="ddl" TabIndex="12">
                                    <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjCategory" runat="server" SelectMethod="GetCategoryyyALL1"
                                    TypeName="CategoryDB">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DDLBranch" DefaultValue="0" DbType="String" Name="BranchCode" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                             <td align="right">
                                <asp:Label ID="lblHostel" runat="server" SkinID="lbl" Text="Hostel :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHostel" runat="server" AppendDataBoundItems="true"
                                    TabIndex="11"
                                    SkinID="ddl">
                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSort" runat="server" SkinID="lblRsz" Width="200px" Text="Sort By :&nbsp;"></asp:Label>
                            </td>
                            <td align="left" >
                                <asp:DropDownList ID="ddlSort" runat="server" SkinID="ddl" TabIndex="13">
                                    <asp:ListItem Value="0">Student Name</asp:ListItem>
                                    <asp:ListItem Value="1">Student Code</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblTransport" runat="server" SkinID="lbl" Text="Transport :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTransport" runat="server" 
                                    TabIndex="11" 
                                    SkinID="ddl">
                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="btnTd">
                                <asp:Button ID="btnSReport" TabIndex="14" runat="server" Text="SUMMARY REPORT" SkinID="btnRsz"
                                    CssClass="ButtonClass" ValidationGroup="save" Width="165px" Visible="False">
                                </asp:Button>
                                <asp:Button ID="btnPreview" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                    TabIndex="15" Text="DETAILED REPORT" CommandName="REPORT" ValidationGroup="save"
                                    Width="165px" />
                                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" OnClick="btnBack_Click"
                                    SkinID="btn" Text="BACK" CommandName="BACK" />
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
                            <td>
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label></div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="SelectBranch" TypeName="DLBranchAccessLevel"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjState" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetState2" TypeName="EnquiryManager">
                                    <SelectParameters>
                                       <%-- <asp:Parameter DefaultValue="0" Name="StateId" Type="Int16" />--%>
                                    
                                    
                                          <asp:ControlParameter ControlID="DDLCountry" PropertyName="SelectedValue" DbType="String"
                                            Name="Country" />
                                      
                                    </SelectParameters>
                               
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>