<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmTimeTable1.aspx.vb"
    Inherits="frmTimeTable1" Title="Time Table" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Time Table</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlCourseName.ClientID%>"), 'Course');
            if (msg != "") {
                document.getElementById("<%=ddlCourseName.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlBatchName.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlSemester.ClientID%>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=ddlSemester.ClientID%>").focus();
                return msg;
            }
            //            msg = Field30(document.getElementById("<%=txtPeriod.ClientID%>"), 'Period');
            //            if (msg != "") {
            //                document.getElementById("<%=txtPeriod.ClientID%>").focus();
            //                return msg;
            //            }
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
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }

        //        function Valid1() {
        //            var msg;
        //            msg = DropDownForZero(document.getElementById("<%=ddlCourseName.ClientID%>"), 'Course');
        //            if (msg != "") return msg;
        //            msg = DropDownForZero(document.getElementById("<%=ddlBatchName.ClientID%>"), 'Batch');
        //            if (msg != "") return msg;
        //            msg = DropDownForZero(document.getElementById("<%=ddlSemester.ClientID%>"), 'Semester');
        //            if (msg != "") return msg;
        //            return true;
        //        }
        //        function Validate1() {
        //            var msg = Valid1();
        //            if (msg != true) {
        //                if (navigator.appName == "Microsoft Internet Explorer") {
        //                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
        //                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
        //                    return false;
        //                }
        //                else if (navigator.appName == "Netscape") {
        //                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
        //                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
        //                    return false;
        //                }
        //            }
        //            return true;
        //        }

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
                    <%--  <center>
                        <h1 class="headingTxt">
                            TIME TABLE</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text="Course*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                <asp:Label ID="lblWeek" runat="server" Text="Academic Weeks&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <tr>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlCourseName" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                            DataSourceID="ObjCourse" DataTextField="CourseName" DataValueField="Courseid"
                                            SkinID="ddlRsz" Width="240 px" TabIndex="1">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBatchName" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                            DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                            Width="190">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSemester" runat="server" DataSourceID="ObjSemester" AutoPostBack="true"
                                            DataTextField="SemName" DataValueField="SemCode" SkinID="ddl" TabIndex="3">
                                            <%--<asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    <asp:TextBox ID="txtWeek" Style="font-weight: bold" runat="server" SkinID="txtRsz" Width="128px"></asp:TextBox>
                                    </td>
                                    </tr>
                                    
                                    
                                 </tr>              
                        </table>
                    </center>
                   <center>
                       <table>
                           <tr>
                                    <td align="right">
                                        <asp:Label ID="lblWeeks" runat="server" SkinID="lbl" Text="Week No &nbsp;:&nbsp;&nbsp;"></asp:Label></td>  
                                    <td align="left">
                                        <asp:DropDownList ID="ddlWeekNo" runat="server" 
                                            DataSourceID="ObjWeek" DataTextField="WeekName" DataValueField="WeekNo" 
                                            SkinID="ddlRsz" TabIndex="2" Width="150">
                                        </asp:DropDownList>
                                    
                                    </td>
                                    <td align="center">
                                    <asp:Button ID="BtnCopyFrom" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    SkinID="btnRsz"  Text="COPY FROM" Width="150" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblNewWeekNo" runat="server" SkinID="lbl" Text="Week No &nbsp;:&nbsp;&nbsp;"></asp:Label></td>  
                                    <td align="left">
                                        <asp:DropDownList ID="ddlNewWeekNo" runat="server" 
                                            DataSourceID="ObjWeek" DataTextField="WeekName" DataValueField="WeekNo" 
                                            SkinID="ddlRsz" TabIndex="2" Width="150">
                                        </asp:DropDownList>
                                    
                                   </td>
                           </tr>
                           <tr>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                           </tr>
                       </table>
                   </center>
                    <center>
                        <asp:Panel ID="Panel" runat="server" ScrollBars="Auto" Width="750px" Height="325px">
                            <center>
                                <table class="TimeTable">
                                    <tr>
                                        <td style="font-weight: bold">
                                            Period
                                        </td>
                                        <td valign="middle" style="font-weight: bold">
                                            Day 1 / Mon
                                        </td>
                                        <td style="font-weight: bold">
                                            Day 2 / Tue
                                        </td>
                                        <td style="font-weight: bold">
                                            Day 3 / Wed
                                        </td>
                                        <td style="font-weight: bold">
                                            Day 4 / Thu
                                        </td>
                                        <td style="font-weight: bold">
                                            Day 5 / Fri
                                        </td>
                                        <td style="font-weight: bold">
                                            Day 6 / Sat
                                        </td>
                                        <td style="font-weight: bold">
                                            Day 7 / Sun
                                        </td>
                                        <tr>
                                            <td valign="top" rowspan="6">
                                                <asp:Label ID="Label30" runat="server" Visible="false"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtPeriod" runat="server" SkinID="txtRsz" TabIndex="4" Width="80px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay1Subject" runat="server" SkinID="lbl" Text="Subject : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay1Subject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                                    DataValueField="Subject_Code" SkinID="ddlRsz" Width="200" TabIndex="5">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay2Subject" runat="server" SkinID="lbl" Text="Subject : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay2Subject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                                    DataValueField="Subject_Code" SkinID="ddlRsz" Width="200" TabIndex="11">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay3Subject" runat="server" SkinID="lbl" Text="Subject : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay3Subject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                                    DataValueField="Subject_Code" SkinID="ddlRsz" Width="200" TabIndex="17">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay4Subject" runat="server" SkinID="lbl" Text="Subject : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay4Subject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                                    DataValueField="Subject_Code" SkinID="ddlRsz" Width="200" TabIndex="23">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay5Subject" runat="server" SkinID="lbl" Text="Subject : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay5Subject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                                    DataValueField="Subject_Code" SkinID="ddlRsz" Width="200" TabIndex="29">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay6Subject" runat="server" SkinID="lbl" Text="Subject : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay6Subject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                                    DataValueField="Subject_Code" SkinID="ddlRsz" Width="200" TabIndex="35">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay7Subject" runat="server" SkinID="lbl" Text="Subject : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay7Subject" runat="server" DataSourceID="ObjSubject" DataTextField="Subject_Name"
                                                    DataValueField="Subject_Code" SkinID="ddlRsz" Width="200" TabIndex="41">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDay1Teacher" runat="server" SkinID="lblRsz" Width="120px" Text="Teaching Staff : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay1Teacher" runat="server" AppendDataBoundItems="true"
                                                    DataSourceID="objTeacher" DataTextField="Emp_Name" DataValueField="Emp_Code"
                                                    SkinID="ddlRsz" Width="200" TabIndex="6">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay2Teacher" runat="server" SkinID="lblRsz" Width="120px" Text="Teaching Staff : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay2Teacher" runat="server" AppendDataBoundItems="true"
                                                    DataSourceID="objTeacher" DataTextField="Emp_Name" DataValueField="Emp_Code"
                                                    SkinID="ddlRsz" Width="200" TabIndex="12">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay3Teacher" runat="server" SkinID="lblRsz" Width="120px" Text="Teaching Staff : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay3Teacher" runat="server" AppendDataBoundItems="true"
                                                    DataSourceID="objTeacher" DataTextField="Emp_Name" DataValueField="Emp_Code"
                                                    SkinID="ddlRsz" Width="200" TabIndex="18">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay4Teacher" runat="server" SkinID="lblRsz" Width="120px" Text="Teaching Staff : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay4Teacher" runat="server" AppendDataBoundItems="true"
                                                    DataSourceID="objTeacher" DataTextField="Emp_Name" DataValueField="Emp_Code"
                                                    SkinID="ddlRsz" Width="200" TabIndex="24">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay5Teacher" runat="server" SkinID="lblRsz" Width="120px" Text="Teaching Staff : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay5Teacher" runat="server" AppendDataBoundItems="true"
                                                    DataSourceID="objTeacher" DataTextField="Emp_Name" DataValueField="Emp_Code"
                                                    SkinID="ddlRsz" Width="200" TabIndex="30">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay6Teacher" runat="server" SkinID="lblRsz" Width="120px" Text="Teaching Staff : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay6Teacher" runat="server" AppendDataBoundItems="true"
                                                    DataSourceID="objTeacher" DataTextField="Emp_Name" DataValueField="Emp_Code"
                                                    SkinID="ddlRsz" Width="200" TabIndex="36">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay7Teacher" runat="server" SkinID="lblRsz" Width="120px" Text="Teaching Staff : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlDay7Teacher" runat="server" AppendDataBoundItems="true"
                                                    DataSourceID="objTeacher" DataTextField="Emp_Name" DataValueField="Emp_Code"
                                                    SkinID="ddlRsz" Width="200" TabIndex="42">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRemarks1" runat="server" SkinID="lblRsz" Text="Misc Info :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay1Remarks" runat="server" TabIndex="7" SkinID="txtRsz" Width="150"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRemarks2" runat="server" SkinID="lblRsz" Text="Misc Info :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay2Remarks" runat="server" Width="150px" TabIndex="13" SkinID="txtRsz"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRemarks3" runat="server" SkinID="lblRsz" Text="Misc Info :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay3Remarks" runat="server" Width="150px" TabIndex="19" SkinID="txtRsz"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRemarks4" runat="server" SkinID="lblRsz" Text="Misc Info :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay4Remarks" runat="server" Width="150px" TabIndex="25" SkinID="txtRsz"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRemarks5" runat="server" SkinID="lblRsz" Text="Misc Info :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay5Remarks" runat="server" Width="150px" TabIndex="31" SkinID="txtRsz"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRemarks6" runat="server" SkinID="lblRsz" Text="Misc Info :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay6Remarks" runat="server" Width="150px" TabIndex="37" SkinID="txtRsz"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRemarks7" runat="server" SkinID="lblRsz" Text="Misc Info :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay7Remarks" runat="server" Width="150px" TabIndex="43" SkinID="txtRsz"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblResrc1" runat="server" SkinID="lblRsz" Width="170px" Text="Resource allocation : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlResrc1" runat="server" AppendDataBoundItems="true" DataSourceID="ObjResrcAllocation"
                                                    DataTextField="ResourceName" DataValueField="AutoID" SkinID="ddl" TabIndex="8">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblResrc2" runat="server" SkinID="lblRsz" Width="170px" Text="Resource allocation : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlResrc2" runat="server" AppendDataBoundItems="true" DataSourceID="ObjResrcAllocation"
                                                    DataTextField="ResourceName" DataValueField="AutoID" SkinID="ddl" TabIndex="14">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblResrc3" runat="server" SkinID="lblRsz" Width="170px" Text="Resource allocation : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlResrc3" runat="server" AppendDataBoundItems="true" DataSourceID="ObjResrcAllocation"
                                                    DataTextField="ResourceName" DataValueField="AutoID" SkinID="ddl" TabIndex="20">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblResrc4" runat="server" SkinID="lblRsz" Width="170px" Text="Resource allocation : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlResrc4" runat="server" AppendDataBoundItems="true" DataSourceID="ObjResrcAllocation"
                                                    DataTextField="ResourceName" DataValueField="AutoID" SkinID="ddl" TabIndex="26">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblResrc5" runat="server" SkinID="lblRsz" Width="170px" Text="Resource allocation : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlResrc5" runat="server" AppendDataBoundItems="true" DataSourceID="ObjResrcAllocation"
                                                    DataTextField="ResourceName" DataValueField="AutoID" SkinID="ddl" TabIndex="32">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblResrc6" runat="server" SkinID="lblRsz" Width="170px" Text="Resource allocation : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlResrc6" runat="server" AppendDataBoundItems="true" DataSourceID="ObjResrcAllocation"
                                                    DataTextField="ResourceName" DataValueField="AutoID" SkinID="ddl" TabIndex="38">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblResrc7" runat="server" SkinID="lblRsz" Width="170px" Text="Resource allocation : "></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlResrc7" runat="server" AppendDataBoundItems="true" DataSourceID="ObjResrcAllocation"
                                                    DataTextField="ResourceName" DataValueField="AutoID" SkinID="ddl" TabIndex="44">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDay1StartDate" runat="server" SkinID="lblRsz" Text="Start Time :"
                                                    Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay1StartDate" runat="server" Width="80px" TabIndex="9" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay1StartDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay2StartDate" runat="server" SkinID="lblRsz" Text="Start Time :"
                                                    Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay2StartDate" runat="server" Width="80px" TabIndex="15" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay2StartDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay3StartDate" runat="server" SkinID="lblRsz" Text="Start Time :"
                                                    Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay3StartDate" runat="server" Width="80px" TabIndex="21" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay3StartDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay4StartDate" runat="server" SkinID="lblRsz" Text="Start Time :"
                                                    Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay4StartDate" runat="server" Width="80px" TabIndex="27" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay4StartDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay5StartDate" runat="server" SkinID="lblRsz" Text="Start Time :"
                                                    Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay5StartDate" runat="server" Width="80px" TabIndex="33" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay5StartDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay6StartDate" runat="server" SkinID="lblRsz" Text="Start Time :"
                                                    Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay6StartDate" runat="server" Width="80px" TabIndex="39" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay6StartDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay7StartDate" runat="server" SkinID="lblRsz" Text="Start Time :"
                                                    Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay7StartDate" runat="server" Width="80px" TabIndex="45" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay7StartDate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDay1EndDate" runat="server" SkinID="lblRsz" Text="End Time :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay1EndDate" runat="server" TabIndex="10" Width="80px" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender8" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay1EndDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay2EndDate" runat="server" SkinID="lblRsz" Text="End Time :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay2EndDate" runat="server" TabIndex="16" Width="80px" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender9" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay2EndDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay3EndDate" runat="server" SkinID="lblRsz" Text="End Time :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay3EndDate" runat="server" TabIndex="22" Width="80px" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender10" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay3EndDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay4EndDate" runat="server" SkinID="lblRsz" Text="End Time :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay4EndDate" runat="server" TabIndex="28" Width="80px" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender11" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay4EndDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay5EndDate" runat="server" SkinID="lblRsz" Text="End Time :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay5EndDate" runat="server" TabIndex="34" Width="80px" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender12" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay5EndDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay6EndDate" runat="server" SkinID="lblRsz" Text="End Time :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay6EndDate" runat="server" TabIndex="40" Width="80px" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender13" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay6EndDate" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDay7EndDate" runat="server" SkinID="lblRsz" Text="End Time :" Width="90px"></asp:Label>
                                                <br />
                                                <asp:TextBox ID="txtDay7EndDate" runat="server" TabIndex="46" Width="80px" SkinID="txtRsz"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender14" runat="server" AcceptAMPM="true"
                                                    AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft"
                                                    Mask="99:99" MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtDay7EndDate" />
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                            </center>
                        </asp:Panel>
                    </center>
            </a><a name="bottom">
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="BtnSave" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="47" Text="ADD" OnClientClick="return Validate()" />
                                &nbsp;<asp:Button ID="BtnDetails" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="48" Text="VIEW" />
                            </td>
                        </tr>
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
                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="msginfo1" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject" TypeName="TimeTableDl">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" Name="Batchid" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="ddlSemester" Name="SemId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="objTeacher" runat="server" SelectMethod="GetLecturercombo"
                                    TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourse" TypeName="CourseDB">
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="TimeTableDl">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" Type="Int16" PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                    TypeName="FeeCollectionBL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjResrcAllocation" runat="server" SelectMethod="GetresourceAllocationCombo"
                                    TypeName="TimetableDl"></asp:ObjectDataSource>
                              <asp:ObjectDataSource ID="ObjWeek" runat="server" SelectMethod="GetWeekNo"
                                    TypeName="TimetableDl"></asp:ObjectDataSource>
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
                   <asp:Panel ID="panel1" runat="server" Width="750px" Height="350px" ScrollBars="Vertical">      
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            AllowSorting="True" EnableSortingAndPagingCallbacks="True" BackColor="White"
                            BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" CellPadding="3"
                            Font-Size="0.8em" ForeColor="Black" GridLines="Vertical" PageSize="100" ScrollBars="Vertical">                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle BackColor="#914800" BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px"
                                Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#D1BAAB" BorderColor="#914800" BorderStyle="Groove"
                                BorderWidth="3px" Font-Size="1.0em" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Font-Underline="False" Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Period" SortExpression="Period" ControlStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Period") %>'></asp:Label>
                                        <asp:HiddenField ID="TTID" runat="server" Value='<%# Bind("TTID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 1 / Mon">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="SubId1" runat="server" Value='<%# Bind("Subjectid1") %>' />
                                        <asp:HiddenField ID="EmpId1" runat="server" Value='<%# Bind("EmpID1") %>' />
                                        <asp:HiddenField ID="Rid1" runat="server" Value='<%# Bind("ResourceID1") %>' />
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Subject_Name1") %>'></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Emp_Name1") %>'></asp:Label>
                                        <asp:Label ID="Label31" runat="server" Text='<%# Bind("ResourceName1") %>'></asp:Label>
                                        <asp:Label ID="lblRemarks1" runat="server" Text='<%# Bind("Remarks1") %>'></asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("StartTime1") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("EndTime1") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 2 / Tue">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="SubId2" runat="server" Value='<%# Bind("Subjectid2") %>' />
                                        <asp:HiddenField ID="EmpId2" runat="server" Value='<%# Bind("EmpID2") %>' />
                                        <asp:HiddenField ID="Rid2" runat="server" Value='<%# Bind("ResourceID2") %>' />
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Subject_Name2") %>'></asp:Label>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Emp_Name2") %>'></asp:Label>
                                        <asp:Label ID="Label32" runat="server" Text='<%# Bind("ResourceName2") %>'></asp:Label>
                                        <asp:Label ID="lblRemarks2" runat="server" Text='<%# Bind("Remarks2") %>'></asp:Label>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("StartTime2")%>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("EndTime2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 3 / Wed">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="SubId3" runat="server" Value='<%# Bind("Subjectid3") %>' />
                                        <asp:HiddenField ID="EmpId3" runat="server" Value='<%# Bind("EmpID3") %>' />
                                        <asp:HiddenField ID="Rid3" runat="server" Value='<%# Bind("ResourceID3") %>' />
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Subject_Name3") %>'></asp:Label>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("Emp_Name3") %>'></asp:Label>
                                        <asp:Label ID="Label33" runat="server" Text='<%# Bind("ResourceName3") %>'></asp:Label>
                                        <asp:Label ID="lblRemarks3" runat="server" Text='<%# Bind("Remarks3") %>'></asp:Label>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("StartTime3") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("EndTime3") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 4 / Thu">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="SubId4" runat="server" Value='<%# Bind("Subjectid4") %>' />
                                        <asp:HiddenField ID="EmpId4" runat="server" Value='<%# Bind("EmpID4") %>' />
                                        <asp:HiddenField ID="Rid4" runat="server" Value='<%# Bind("ResourceID4") %>' />
                                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("Subject_Name4") %>'></asp:Label>
                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("Emp_Name4") %>'></asp:Label>
                                        <asp:Label ID="Label34" runat="server" Text='<%# Bind("ResourceName4") %>'></asp:Label>
                                        <asp:Label ID="lblRemarks4" runat="server" Text='<%# Bind("Remarks4") %>'></asp:Label>
                                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("StartTime4") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("EndTime4") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 5 / Fri">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="SubId5" runat="server" Value='<%# Bind("Subjectid5") %>' />
                                        <asp:HiddenField ID="EmpId5" runat="server" Value='<%# Bind("EmpID5") %>' />
                                        <asp:HiddenField ID="Rid5" runat="server" Value='<%# Bind("ResourceID5") %>' />
                                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("Subject_Name5") %>'></asp:Label>
                                        <asp:Label ID="Label19" runat="server" Text='<%# Bind("Emp_Name5") %>'></asp:Label>
                                        <asp:Label ID="Label35" runat="server" Text='<%# Bind("ResourceName5") %>'></asp:Label>
                                        <asp:Label ID="lblRemarks5" runat="server" Text='<%# Bind("Remarks5") %>'></asp:Label>
                                        <asp:Label ID="Label20" runat="server" Text='<%# Bind("StartTime5") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label21" runat="server" Text='<%# Bind("EndTime5") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 6 / Sat">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="SubId6" runat="server" Value='<%# Bind("Subjectid6") %>' />
                                        <asp:HiddenField ID="EmpId6" runat="server" Value='<%# Bind("EmpID6") %>' />
                                        <asp:HiddenField ID="Rid6" runat="server" Value='<%# Bind("ResourceID6") %>' />
                                        <asp:Label ID="Label22" runat="server" Text='<%# Bind("Subject_Name6") %>'></asp:Label>
                                        <asp:Label ID="Label23" runat="server" Text='<%# Bind("Emp_Name6") %>'></asp:Label>
                                        <asp:Label ID="Label36" runat="server" Text='<%# Bind("ResourceName6") %>'></asp:Label>
                                        <asp:Label ID="lblRemarks6" runat="server" Text='<%# Bind("Remarks6") %>'></asp:Label>
                                        <asp:Label ID="Label24" runat="server" Text='<%# Bind("StartTime6") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label25" runat="server" Text='<%# Bind("EndTime6") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="150px" HeaderText="Day 7 / Sun">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="SubId7" runat="server" Value='<%# Bind("Subjectid7") %>' />
                                        <asp:HiddenField ID="EmpId7" runat="server" Value='<%# Bind("EmpID7") %>' />
                                        <asp:HiddenField ID="Rid7" runat="server" Value='<%# Bind("ResourceID7") %>' />
                                        <asp:Label ID="Label26" runat="server" Text='<%# Bind("Subject_Name7") %>'></asp:Label>
                                        <asp:Label ID="Label27" runat="server" Text='<%# Bind("Emp_Name7") %>'></asp:Label>
                                        <asp:Label ID="Label37" runat="server" Text='<%# Bind("ResourceName7") %>'></asp:Label>
                                        <asp:Label ID="lblRemarks7" runat="server" Text='<%# Bind("Remarks7") %>'></asp:Label>
                                        <asp:Label ID="Label28" runat="server" Text='<%# Bind("StartTime7") %>'></asp:Label>
                                        -<br />
                                        <asp:Label ID="Label29" runat="server" Text='<%# Bind("EndTime7") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="150px" />
                                    <ItemStyle BorderColor="#914800" BorderStyle="Groove" BorderWidth="3px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                </div> </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
