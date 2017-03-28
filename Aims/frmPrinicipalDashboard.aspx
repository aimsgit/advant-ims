<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPrinicipalDashboard.aspx.vb"
    Inherits="frmPrinicipalDashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Principal Dashboard</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <%--<a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table border="1">
                    <tr align="center">
                        <td align="center">
                            <asp:Label ID="lblAdmission" runat="server" Text="ADMISSION" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblfee" runat="server" Text="FEE" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAttendence" runat="server" Text="ATTENDANCE" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblMarks" runat="server" Text="MARKS" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblPerformance" runat="server" Text="PERFORMANCE" SkinID="lbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:DropDownList ID="ddladmissionAca" TabIndex="1" runat="server" SkinID="ddl" DataValueField="id"
                                DataTextField="AcademicYear" DataSourceID="ObjAcademic">
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddladmissionfee" TabIndex="6" runat="server" SkinID="ddl" DataValueField="id"
                                DataTextField="AcademicYear" DataSourceID="ObjAcademic1">
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddladmissionaatendence" TabIndex="11" runat="server" SkinID="ddl"
                                DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic2">
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddladmissionMarks" TabIndex="17" runat="server" SkinID="ddl"
                                DataValueField="id" DataTextField="AcademicYear" DataSourceID="ObjAcademic3">
                            </asp:DropDownList>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnBestPro" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="25" Text="BEST PERFORMERS" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:DropDownList ID="ddlcouadmision" runat="server" SkinID="ddl" DataSourceID="objCourse"
                                DataTextField="CourseName" DataValueField="CourseCode" TabIndex="2">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseComboAdmission"
                                TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
                            <td align="center">
                                <asp:DropDownList ID="ddlCoufee" runat="server" SkinID="ddl" DataSourceID="objCourse1"
                                    DataTextField="CourseName" DataValueField="CourseCode" TabIndex="7">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objCourse1" runat="server" SelectMethod="GetCourseComboAdmission"
                                    TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
                                <td align="center">
                                    <asp:DropDownList ID="ddlCouattendence" runat="server" SkinID="ddl" DataSourceID="objCourse2"
                                        DataTextField="CourseName" DataValueField="CourseCode" TabIndex="12">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objCourse2" runat="server" SelectMethod="GetCourseComboAdmission"
                                        TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
                                    <td align="center">
                                        <asp:DropDownList ID="ddlCoumarks" runat="server" SkinID="ddl" DataSourceID="objCourse3"
                                            DataTextField="CourseName" DataValueField="CourseCode" TabIndex="18">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="objCourse3" runat="server" SelectMethod="GetCourseComboAdmission1"
                                            TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
                                        <%--                                        <td align="center">
                                            <asp:Button ID="btnBestFac" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                TabIndex="12" Text="BEST FACULTIES" Width="120px" />
                                        </td>

--%>
                                        <td>
                                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:DropDownList ID="ddlcatAdm" runat="server" DataSourceID="ObjCategory" DataTextField="CategoryName"
                                DataValueField="Category_Id" SkinID="ddl" TabIndex="3">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCategory" runat="server" SelectMethod="GetCategoryyyALL1"
                                TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
                            <td align="center">
                                <asp:DropDownList ID="ddlCatFee" runat="server" DataSourceID="ObjCategory1" DataTextField="CategoryName"
                                    DataValueField="Category_Id" SkinID="ddl" TabIndex="8">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjCategory1" runat="server" SelectMethod="GetCategoryyyALL1"
                                    TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
                                <td align="center">
                                    <asp:DropDownList ID="ddlCatAtt" runat="server" DataSourceID="ObjCategory2" DataTextField="CategoryName"
                                        DataValueField="Category_Id" SkinID="ddl" TabIndex="13">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCategory2" runat="server" SelectMethod="GetCategoryyyALL1"
                                        TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
                                    <td align="center">
                                        <asp:DropDownList ID="ddlCatMar" runat="server" DataSourceID="ObjCategory3" DataTextField="CategoryName"
                                            DataValueField="Category_Id" SkinID="ddl" TabIndex="18">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjCategory3" runat="server" SelectMethod="GetCategoryyyALL1"
                                            TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
                                        <%--                                        <td align="center">
                                            <asp:Button ID="btnBestSub" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                TabIndex="12" Text="BEST SUBJECTS" Width="120px" />
                                        </td>--%>
                                        <td>
                                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:DropDownList ID="ddlRace" runat="server" AppendDataBoundItems="True" DataSourceID="ObjRace"
                                DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="19">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjRace" runat="server" SelectMethod="CasteCombo" TypeName="DLPrinicipalDashBoard">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlcasteFee" runat="server" AppendDataBoundItems="True" DataSourceID="objcastFee"
                                DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="60">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objcastFee" runat="server" SelectMethod="CasteCombo" TypeName="DLPrinicipalDashBoard">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlcaste" runat="server" AppendDataBoundItems="True" DataSourceID="objcast"
                                DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="60">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objcast" runat="server" SelectMethod="CasteCombo" TypeName="DLPrinicipalDashBoard">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlsem" runat="server" SkinID="ddl" DataSourceID="objsem" DataTextField="SemName"
                                DataValueField="SemCode" TabIndex="19">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objsem" runat="server" SelectMethod="GetSemComboAdmission1"
                                TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
                        </td>
                        <%--                        <td align="center">
                                    <asp:Button ID="btnbestdep" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="19" Text="BEST DEPARTMENTS" Width="120px" />
                        </td>
                        
--%>
                        <td>
                        </td>
                    </tr>                    
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnsumAdm" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="4" Text="SUMMARY" Width="120px" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnsumFee" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="9" Text="SUMMARY" Width="120px" />
                        </td>
                        <td align="center">
                            <asp:Label ID="lblAttenPercent" runat="server" SkinID="lblRsz" Width="30"></asp:Label>
                            <asp:TextBox ID="txtAttendper" runat="server" TabIndex="14" SkinID="txtRsz" Width="100"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtAttendper">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlAType" SkinID="ddl" runat="server" DataSourceID="ObjAssesment"
                                DataTextField="AssessmentType" DataValueField="AssesmentCode" TabIndex="20">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjAssesment" runat="server" TypeName="DLPrinicipalDashBoard"
                                SelectMethod="getassessmentDDL"></asp:ObjectDataSource>
                        </td>
                        <%--                        <td align="center">
                                        <asp:Button ID="btnbeststudent" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                            TabIndex="12" Text="BEST STUDENTS" Width="120px" />
                        </td>
                        
--%>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        <asp:Button ID="btndetailAdm" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="5" Text="DETAILED" Width="120px" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btndetailfee" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="10" Text="DETAILED" Width="120px" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnsummattend" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="15" Text="SUMMARY" Width="120px" />
                        </td>
                          <td align="center">
                            <asp:DropDownList ID="ddlRaceCaste" runat="server" AppendDataBoundItems="True" DataSourceID="objcast1"
                                DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddl" TabIndex="18">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objcast1" runat="server" SelectMethod="CasteCombo" TypeName="DLPrinicipalDashBoard">
                            </asp:ObjectDataSource>
                        </td>
                     
                        <%-- <td align="center">
                            <asp:DropDownList ID="ddlFromPercent" runat="server" SkinID="ddl" TabIndex="21">
                                <asp:ListItem Text="From%" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
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
                        </td>--%>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnFeeDue" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="16" Text="FEE DUE" Width="120px" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnAttenDetail" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="16" Text="DETAILED" Width="120px" />
                        </td>
                           <td align="center">
                            <asp:Button ID="btnDeatlMarks" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="24" Text="DETAILED" Width="120px" />
                        </td>
                        <td></td>
                    </tr>
                    <%--<tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="ddlToPercent" runat="server" SkinID="ddl" TabIndex="22">
                                <asp:ListItem Text="To%" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
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
                        <td>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnSummMArks" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="23" Text="SUMMARY" Width="120px" />
                        </td>
                        <td>
                        </td>
                    </tr>--%>
                    <%-- <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnDeatlMarks" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="24" Text="DETAILED" Width="120px" />
                        </td>
                        <td>
                        </td>
                    </tr>--%>
                </table>
                <table>
                    <tr>
                        <td>
                            <center>
                                <div>
                                    <asp:Label ID="lblmsg" runat="server" BackColor="Green" ForeColor="White"></asp:Label>
                                </div>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <div>
                                    <asp:Label ID="msginfo" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
                                </div>
                            </center>
                        </td>
                    </tr>
                </table>
            </center>
            <asp:ObjectDataSource ID="ObjAcademic" runat="server" SelectMethod="GetAcademicCombo"
                TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjAcademic1" runat="server" SelectMethod="GetAcademicCombo"
                TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjAcademic2" runat="server" SelectMethod="GetAcademicCombo"
                TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjAcademic3" runat="server" SelectMethod="GetAcademicCombo"
                TypeName="DLPrinicipalDashBoard"></asp:ObjectDataSource>
            <%--  <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
