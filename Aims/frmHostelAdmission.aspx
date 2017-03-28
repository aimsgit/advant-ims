<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmHostelAdmission.aspx.vb"
    Inherits="frmHostelAdmission" Title="Hostel Admission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Hostel Admission</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtStudentCode.ClientID%>"));
        }
        
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtStudentCode.ClientID%>"));
        }
        
        function Valid() {
            var msg;
            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtStudentCode.ClientID %>"), 'Student Code');
            if (msg != "") {
                document.getElementById("<%=txtStudentCode.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtAdate.ClientID %>"), 'Admission Date');
            if (msg != "") {
                document.getElementById("<%=txtAdate.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=cmbHosName.ClientID %>"), 'Hostel name');
            if (msg != "") {
                document.getElementById("<%=cmbHosName.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlBranchName.ClientID %>"), 'Branch Name');
            if (msg != "") {
                document.getElementById("<%=ddlBranchName.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=cmbRoomType.ClientID %>"), 'Room Type');
            if (msg != "") {
                document.getElementById("<%=cmbRoomType.ClientID %>").focus();
                return msg;
            }
            msg = CodeField(document.getElementById("<%=Label5.ClientID %>"), 'Hostel Registration No');
            if (msg != "") {
                document.getElementById("<%=Label5.ClientID %>").focus();
                return msg;
            }
            msg = valcontactN(document.getElementById("<%=txtLGPhone.ClientID%>"), 'LG Phone No');
            if (msg != "") {
                document.getElementById("<%=txtLGPhone.ClientID%>").focus();
                return msg;

            }
            msg = Field250N(document.getElementById("<%=txtStudAddr.ClientID%>"), 'Student Address');
            if (msg != "") {
                document.getElementById("<%=txtStudAddr.ClientID%>").focus();
                return msg;

            }
            msg = Field250N(document.getElementById("<%=txtLGAddr.ClientID%>"), 'LG Address');
            if (msg != "") {
                document.getElementById("<%=txtLGAddr.ClientID%>").focus();
                return msg;

            }

            return true;
        }

        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblS.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblS.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }

    </script>

    <script language="javascript" type="text/javascript">
        function Valid1() {
            var msg;

            msg = Field50(document.getElementById("<%=txtHostelName.ClientID %>"), 'Hostel Name');
            if (msg != "") {
                document.getElementById("<%=txtHostelName.ClientID%>").focus();
                return msg;
            }
            msg = Field50(document.getElementById("<%=txtHostelCode.ClientID %>"), 'Hostel Code');
            if (msg != "") {
                document.getElementById("<%=txtHostelCode.ClientID%>").focus();
                return msg;
            }
            msg = Field50(document.getElementById("<%=txtHostelType.ClientID %>"), 'Hostel Type');
            if (msg != "") {
                document.getElementById("<%=txtHostelType.ClientID%>").focus();
                return msg;
            }
            msg = Field50N(document.getElementById("<%=txtWarden.ClientID %>"), 'Warden');
            if (msg != "") {
                document.getElementById("<%=txtWarden.ClientID%>").focus();
                return msg;
            }
            msg = Field50N(document.getElementById("<%=txtHouseKeeping.ClientID %>"), 'House Keeping');
            if (msg != "") {
                document.getElementById("<%=txtHouseKeeping.ClientID%>").focus();
                return msg;
            }
            msg = Field250N(document.getElementById("<%=txtRemarks.ClientID %>"), 'Remarks');
            if (msg != "") {
                document.getElementById("<%=txtRemarks.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate1() {

            var msg = Valid1();
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

    </script>

    <script language="javascript" type="text/javascript">
        function Valid2() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlHostelCode.ClientID %>"), 'Hostel Code');
            if (msg != "") {
                document.getElementById("<%=ddlHostelCode.ClientID%>").focus();
                return msg;
            }
            msg = Field1(document.getElementById("<%=txtRoomNo1.ClientID %>"), 'Room No');
            if (msg != "") {
                document.getElementById("<%=txtRoomNo1.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlRoomType1.ClientID %>"), 'Room Type');
            if (msg != "") {
                document.getElementById("<%=ddlRoomType1.ClientID%>").focus();
                return msg;
            }

            return true;
        }
        function Validate2() {

            var msg = Valid2();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }

    </script>

    <script type="text/javascript" language="javascript">
        function Valid3() {
            var msg;
            msg = Field50(document.getElementById("<%=txtRoomType.ClientID%>"), 'Room Type');
            if (msg != "") {
                document.getElementById("<%=txtRoomType.ClientID%>").focus();
                return msg;
            }
            msg = FeesField(document.getElementById("<%=txtOccupant.ClientID%>"), 'No. of Occupants');
            if (msg != "") {
                document.getElementById("<%= txtOccupant.ClientID %>").focus();
                return msg;
            }
            msg = Field250N(document.getElementById("<%=txtRemarks1.ClientID%>"), 'Remarks');
            if (msg != "") {
                document.getElementById("<%= txtRemarks1.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate3() {
            var msg = Valid3();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID %>").innerText = "";
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
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Hostel Admission"
                    TabIndex="1">
                    <ContentTemplate>
                        <center>
                            <center>
                                <h1 class="headingTxt">
                                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                                </h1>
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" Text="Branch Name*^ :&nbsp;" SkinID="lblRsz"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlBranchName" TabIndex="1" runat="server" SkinID="ddlRsz"
                                                AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode"
                                                Width="350px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjBranch" runat="server" SelectMethod="insertBranchCombo_Hostel"
                                                TypeName="CourseDB"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                                <br>
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblAdate" runat="server" SkinID="lblRsz" Text="Admission Date* :&nbsp;&nbsp;"
                                                Width="150px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAdate" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtAdate" BehaviorID="_content_FilteredTextBoxExtender1">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtAdate" BehaviorID="_content_CalendarExtender2">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblStudentCode" runat="server" SkinID="lbl" Text="Student Code* :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:HiddenField ID="StdId" runat="server" />
                                            <asp:TextBox ID="txtStudentCode" runat="server" AutoPostBack="True" SkinID="txt"
                                                TabIndex="1"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="2000"
                                                OnClientPopulated="HideImage" OnClientPopulating="ShowImage" ServiceMethod="getStudentExt2"
                                                ServicePath="TextBoxExt.asmx" TargetControlID="txtStudentCode" CompletionListCssClass="completeListStyle22"
                                                DelimiterCharacters="" BehaviorID="_content_AutoCompleteExtender1">
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                                SkinID="watermark" TargetControlID="txtStudentCode" WatermarkText="Type first 3 characters" BehaviorID="_content_TextBoxWatermarkExtender2">
                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblAcaYear" runat="server" SkinID="lblRsz" Width="200px" Text="Academic Calendar Year :&nbsp;&nbsp;"></asp:Label>
                                            <asp:HiddenField ID="HAId" runat="server" />
                                        </td>
                                        <td align="left" style="width: 128px">
                                            <asp:TextBox ID="txtAcaYear" runat="server" Enabled="False" SkinID="txt" Width="128px"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblStudName" runat="server" SkinID="lbl" Text="Student Name :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtStudName" runat="server" Enabled="False" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text="Course :&nbsp;&nbsp;"></asp:Label>
                                            <asp:HiddenField ID="HCId" runat="server" />
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCourse" runat="server" Enabled="False" SkinID="txt"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblStudBatch" runat="server" SkinID="lbl" Text="Student Batch :&nbsp;&nbsp;"></asp:Label>
                                            <asp:HiddenField ID="HBId" runat="server" />
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtStudBatch" runat="server" Enabled="False" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblBloodGroup" runat="server" SkinID="lbl" Text="Blood Group :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbBloodGroup" runat="server" SkinID="ddl" TabIndex="2">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="O+" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="A+" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="B+" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="AB+" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="O-" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="A-" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="B-" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="AB-" Value="8"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" colspan="1">
                                            <asp:Label ID="lblStudAddr" runat="server" SkinID="lblRsz" Text="Student Address :&nbsp;&nbsp;"
                                                Width="170px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtStudAddr" runat="server" SkinID="txt" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblLGName" runat="server" SkinID="lbl" Text="LG Name :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 128px">
                                            <asp:TextBox ID="txtLGName" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                        </td>
                                        <td align="right" colspan="1">
                                            <asp:Label ID="lblLGAddr" runat="server" SkinID="lbl" Text="LG Address :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLGAddr" runat="server" SkinID="txt" TabIndex="4" TextMode="MultiLine"
                                                MaxLength="250"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblLGEmail" runat="server" SkinID="lbl" Text="LG EMail :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLGEmail" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblLGPhone" runat="server" SkinID="lbl" Text="LG Phone No :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLGPhone" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                ValidChars="0123456789+,/\-" TargetControlID="txtLGPhone" BehaviorID="_content_FilteredTextBoxExtender8">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="*LG-Local Guardian" Font-Bold="True"
                                                Font-Size="Smaller"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblHosName" runat="server" Text="Hostel Name* :&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="120px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbHosName" runat="server" DataSourceID="odshosname" DataTextField="HostelName"
                                                TabIndex="7" SkinID="ddl" AutoPostBack="True" DataValueField="HMIDAuto">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odshosname" runat="server" SelectMethod="GetHosNameCombo"
                                                TypeName="HostelAdmissionBL">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlBranchName" PropertyName="SelectedValue" Name="Branchcode"
                                                        DefaultValue="0" />
                                                </SelectParameters>
                                                
                                                
                                                </asp:ObjectDataSource>
                                      
                                            <td align="right">
                                                <asp:Label ID="Label5" runat="server" Text="Hostel Reg No*^&amp;nbsp:&nbsp; " SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl" runat="server" AutoPostBack="True" DataSourceID="objhostel"
                                                    DataTextField="HostelCode" DataValueField="HMID" SkinID="ddl" TabIndex="21" Width="129px">
                                                </asp:DropDownList>
                                                 <asp:ObjectDataSource ID="Objhostel" runat="server" TypeName="DLHostelDetails"
                                    SelectMethod="Gethostelcode" DataObjectTypeName="ERoomType"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblRoomType" runat="server" Text="Room Type* :&nbsp;&nbsp;" SkinID="lblRsz"
                                                Width="120px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbRoomType" runat="server" DataSourceID="odsroomtype" DataTextField="RoomType"
                                                SkinID="ddl" AutoPostBack="True" DataValueField="RoomTypeAuto" TabIndex="8">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsroomtype" runat="server" SelectMethod="GetRoomTypeCombo"
                                                TypeName="HostelAdmissionBL">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="cmbHosName" PropertyName="SelectedValue" Name="Hid" />
                                                       
                                                    <asp:ControlParameter ControlID="ddlBranchName" PropertyName="SelectedValue" Name="Branchcode"
                                                        DefaultValue="0" />
                                                </SelectParameters>
                                              
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblDOL" runat="server" SkinID="lbl" Text="Date of Leaving :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDOL" runat="server" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtDOL" BehaviorID="_content_FilteredTextBoxExtender2">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtDOL" BehaviorID="_content_CalendarExtender1">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td class="btnTd">
                                            <asp:Button ID="BtnShow" TabIndex="10" runat="server" Text="SHOW AVAILABILITY" Width="150px" CausesValidation="False"
                                                OnClientClick="return Validate();" SkinID="btnRsz" CssClass="ButtonClass"></asp:Button>
                                        </td>
                                    </tr> 
                                </table>
                            </center>
                            <table>
                                <tr>
                                    <td width="400px" align="right">
                                        <asp:Button ID="BtnUpdate" TabIndex="11" runat="server" Text="SUBMIT" SkinID="btn"
                                            OnClientClick="return Validate();" CssClass="ButtonClass"></asp:Button>
                                        &nbsp;<asp:Button ID="BtnView" TabIndex="12" runat="server" Text="VIEW" CausesValidation="False"
                                            SkinID="btn" CssClass="ButtonClass"></asp:Button>
                                    </td>
                                    <td align="left">
                                        <asp:BulletedList ID="BulletedList1" runat="server" Width="200px">
                                            <asp:ListItem>Note : click on show button to select seat number before clicking on SUBMIT button.</asp:ListItem>
                                        </asp:BulletedList>
                                    </td>
                                </tr>
                            </table>
                            <center>
                                <div>
                                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblE" runat="server" EnableTheming="True" SkinID="lblRed"></asp:Label>
                                    <asp:Label ID="lblS" runat="server" EnableTheming="True" SkinID="lblGreen"></asp:Label>
                                    <br />
                                </div>
                                <br />
                            </center>
                            <center>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="250px">
                                    <asp:GridView ID="GVHostelAdmission" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" Width="568px" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Room No">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HDID" runat="server" Value='<%# Bind("HDIDAuto") %>' />
                                                    <asp:Label ID="lblRoomNo" runat="server" Text='<%# Bind("RoomNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Room Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRoomType" runat="server" Text='<%# Bind("RoomType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Occupants">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOccupant" runat="server" Text='<%# Bind("NoOfOccupants") %>' Visible="true"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Seat No 1">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkSeatNo1" runat="Server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentCode1" runat="server"></asp:Label>
                                                    <asp:HiddenField ID="HStudID1" runat="server" Value='<%# Bind("SeatNo1") %>' />
                                                    <asp:TextBox ID="txtstud1" runat="server" SkinID="txtRsz" Width="140" ReadOnly="true"
                                                        Text='<%# Bind("StdCode") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Seat No 2">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkSeatNo2" runat="Server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentCode2" runat="server"></asp:Label>
                                                    <asp:HiddenField ID="HStudID2" runat="server" Value='<%# Bind("SeatNo2") %>' />
                                                    <asp:TextBox ID="txtstud2" runat="server" SkinID="txtRsz" Width="140" ReadOnly="true"
                                                        Text='<%# Bind("StdCode2") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Seat No 3">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkSeatNo3" runat="Server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentCode3" runat="server"></asp:Label>
                                                    <asp:HiddenField ID="HStudID3" runat="server" Value='<%# Bind("SeatNo3") %>' />
                                                    <asp:TextBox ID="txtstud3" runat="server" SkinID="txtRsz" Width="140" ReadOnly="true"
                                                        Text='<%# Bind("StdCode3") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Seat No 4">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkSeatNo4" runat="Server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentCode4" runat="server"></asp:Label>
                                                    <asp:HiddenField ID="HStudID4" runat="server" Value='<%# Bind("SeatNo4") %>' />
                                                    <asp:TextBox ID="txtstud4" runat="server" SkinID="txtRsz" Width="140" ReadOnly="true"
                                                        Text='<%# Bind("StdCode4") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:LinkButton ID="LinkButton7" runat="server"></asp:LinkButton>
                                </asp:Panel>
                            </center>
                            <center>
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="250px">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        SkinID="GridView" Width="568px" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Font-Underline="true" Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        Font-Underline="true" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" />
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Update"
                                                        Font-Underline="true" Text="Vacate" OnClientClick="return confirm('Do you want to Vacate the selected Student?')" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="Stdid1" runat="server" Value='<%# Bind("Std_Id") %>' />
                                                    <asp:HiddenField ID="HCID" runat="server" Value='<%# Bind("CourseID") %>' />
                                                    <asp:Label ID="lblCrs" runat="server" Text='<%# Bind("CourseName") %>' Visible="false"></asp:Label>
                                                    <asp:HiddenField ID="HBID" runat="server" Value='<%# Bind("BatchID") %>' />
                                                    <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch_No") %>' Visible="false"></asp:Label>
                                                    <asp:HiddenField ID="HAID" runat="server" Value='<%# Bind("A_Year") %>' />
                                                    <asp:Label ID="lblAYear" runat="server" Text='<%# Bind("AcademicYear") %>' Visible="false"></asp:Label>
                                                    <asp:HiddenField ID="HAdmissionDate" runat="server" Value='<%# Bind("AdmissionDate","{0:dd-MMM-yyyy}") %>' />
                                                    <asp:HiddenField ID="HBloodGrp" runat="server" Value='<%# Bind("BloodGroup") %>' />
                                                    <asp:HiddenField ID="HStudAddr" runat="server" Value='<%# Bind("STDAddress") %>' />
                                                    <asp:Label ID="lblStudCode" runat="server" Text='<%# Bind("StdCode") %>' Visible="true"></asp:Label>
                                                    <asp:HiddenField ID="HRoomTypeId" runat="server" Value='<%# Bind("RoomTypeID") %>' />
                                                    <asp:Label ID="lblRoomType1" runat="server" Width="75px" Text='<%# Bind("RoomType") %>'
                                                        Visible="false"></asp:Label>
                                                    <asp:Label ID="lblHosName" runat="server" Width="150px" Text='<%# Bind("HostelName") %>'
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="StudId" runat="server" Value='<%# Bind("Std_Id") %>' />
                                                    <asp:Label ID="lblStudName" runat="server" Text='<%# Bind("StdName") %>' Visible="true"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText ="Branch" >
                                            <ItemTemplate >
                                            <asp:Label ID="lblBranchN" runat="server" Visible="false" Text='<%# Bind("BranchName") %>'></asp:Label>
                                             <asp:Label ID="lblBranchcode" runat="server" Visible="false" Text='<%# Bind("Hostel_BranchCode") %>'></asp:Label>
                                            
                                            </ItemTemplate>
                                            
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hostel Reg No" SortExpression="HostelRegNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHosRegNo" runat="server" Text='<%# Bind("HostelRegNo") %>' Visible="true"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Room No" SortExpression="RoomNo">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HAIDAuto" runat="server" Value='<%# Bind("HAIDAuto") %>' />
                                                    <asp:HiddenField ID="HDIDAuto" runat="server" Value='<%# Bind("HDIDAuto") %>' />
                                                    <asp:Label ID="lblRoomNo1" runat="server" Text='<%# Bind("RoomNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LG Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLGName" runat="server" Width="150" Text='<%# Bind("LGName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LG Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLGAddress" runat="server" Width="150" Text='<%# Bind("LGAddress") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="True" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LG EMail">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLGEmail" runat="server" Text='<%# Bind("LGEmail") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LG Contact No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLGContNo" runat="server" Text='<%# Bind("LGContactNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:LinkButton ID="LinkButton6" runat="server"></asp:LinkButton>
                            </center>
                        </center>
                        <style type="text/css">
                            .completeListStyle22
                            {
                                height: 200px;
                                width: 505px;
                                overflow: auto;
                                list-style-type: disc;
                                padding-left: 17px;
                                background-color: #FFF;
                                border: 1px solid DarkGray;
                                text-align: left;
                                font-size: small;
                                color: black;
                                visibility: hidden;
                            }
                        </style>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Hostel Details" TabIndex="2">
                    <ContentTemplate>
                        <center>
                            <div class="mainBlock">
                                <center>
                                    <h1 class="headingTxt">
                                        HOSTEL MASTER
                                    </h1>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                         <td align="right">
                                                <asp:Label ID="lblHostelName" runat="server" Text="Hostel Name*^&nbsp:&nbsp&nbsp"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHostelName" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblHostelCode" runat="server" Text="Hostel Code*&nbsp:&nbsp;&nbsp;"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHostelCode" runat="server" SkinID="txt" TabIndex="14"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                &nbsp;<asp:Label ID="lblHostelType" runat="server" Text="Hostel Type*&nbsp:&nbsp&nbsp"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHostelType" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--<asp:TextBox ID="txtRID" runat="server" Text='<%# Bind("Dept_ID") %>' __designer:wfdid="w15"
                           <                           Visible="False"></asp:TextBox>--%>
                                        
                                        <tr>
                                        <td align="right" colspan="1">
                                         <asp:Label ID="lblHostelAddress" runat="server" SkinID="lblRsz" Text="Hostel Address :&nbsp;&nbsp;"
                                                Width="170px"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:TextBox ID="txtHostelAddr" runat="server" SkinID="txt" TextMode="MultiLine" MaxLength="450"  Height="50" TabIndex ="16"></asp:TextBox>
                                        </td>
                                        </tr>
                                        
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblWarden" runat="server" Text="Warden&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtWarden" runat="server" SkinID="txt" TabIndex="17"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblHouseKeeping" runat="server" Text="House Keeping&nbsp:&nbsp&nbsp;"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td style="width: 83px">
                                                <asp:TextBox ID="txtHouseKeeping" runat="server" SkinID="txt" TabIndex="18"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks&nbsp:&nbsp&nbsp;" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemarks" runat="server" SkinID="txtRsz" TabIndex="19" Width="250px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="btnTd" colspan="2">
                                                <asp:Button ID="InsertHostelMaster" runat="server" CssClass="ButtonClass" OnClientClick="return Validate1();"
                                                    SkinID="btn" Text="ADD" ValidationGroup="ADD" TabIndex="20" />
                                                &nbsp;<asp:Button ID="ViewHostelMaster" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                    SkinID="btn" TabIndex="21" Text="VIEW" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <center>
                                        <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                            <ProgressTemplate>
                                                <div class="PleaseWait">
                                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </center>
                                    <table>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panel5" runat="server" ScrollBars="Auto" Height="250px">
                                                    <asp:GridView ID="GvHostelMaster" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                                        Visible="False" AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                        Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                        Font-Underline="False" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                        Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Hostel Name" SortExpression="HostelName">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("HMID") %>' Visible="false" />
                                                                    <asp:Label ID="lblHostelName" runat="server" Text='<%# Bind("HostelName") %>' Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Hostel Code" SortExpression="HostelCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblHostelCode" runat="server" Text='<%# Bind("HostelCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Hostel Type">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblHostelType" runat="server" Text='<%# Bind("HostelType") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Hostel Address">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblHostelAddr" runat="server" Text='<%# Bind("HostelAddress") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField> 
                                                            <asp:TemplateField HeaderText="Hostel Warden">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblWarden" runat="server" Text='<%# Bind("HostelWarden") %>' Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="House Keeping">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblHouseKeeping" runat="server" Text='<%# Bind("HouseKeeping") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remarks">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                                <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </div>
                            <hr />
                            <div class="mainBlock">
                                <center>
                                    <h1 class="headingTxt">
                                        HOSTEL ROOM DETAILS
                                    </h1>
                                </center>
                                <center>
                                    <table>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label2" runat="server" Text="Hostel Code*^&nbsp:&nbsp; " SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlHostelCode" runat="server" AutoPostBack="True" DataSourceID="objhostelcode"
                                                    DataTextField="HostelCode" DataValueField="HMID" SkinID="ddl" TabIndex="21" Width="129px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="LblHname" runat="server" Text="Hostel Name*&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtHostelName1" runat="server" SkinID="txt" TabIndex="22" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblRoomNo" runat="server" Text="Room No*&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRoomNo1" runat="server" SkinID="txt" TabIndex="23"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                &nbsp;<asp:Label ID="Label3" runat="server" Text="Room Type*^&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRoomType1" runat="server" AutoPostBack="True" DataSourceID="objroomtype"
                                                    DataTextField="RoomType" DataValueField="RoomType_ID" SkinID="ddl" TabIndex="24"
                                                    Width="128px">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblOccupants" runat="server" Text="Occupants&nbsp:&nbsp" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOccupants11" runat="server" SkinID="txt" Width="128px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <center>
                                            <tr>
                                                <td class="btnTd" colspan="2">
                                                    <asp:Button ID="InsertHostelDetails" runat="server" CssClass="ButtonClass" OnClientClick="return Validate2();"
                                                        SkinID="btn" Text="ADD" ValidationGroup="ADD" TabIndex="25" />
                                                    &nbsp;<asp:Button ID="ViewHostelDetails" runat="server" CausesValidation="False"
                                                        CssClass="ButtonClass" SkinID="btn" TabIndex="26" Text="VIEW" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                    </table>
                                    <center>
                                        <asp:UpdateProgress runat="server" ID="UpdateProgress2">
                                            <ProgressTemplate>
                                                <div class="PleaseWait">
                                                    <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                        SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                                    </center>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panel4" runat="server" ScrollBars="Auto" Height="250px">
                                                    <asp:GridView ID="GvHostelDetails" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                                        Visible="False" AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                        Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                        Font-Underline="False" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                        Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Hostel Code" SortExpression="HostelCode">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("HDID") %>' Visible="false" />
                                                                    <asp:Label ID="lblHostelId" runat="server" Text='<%# Bind("HostelID") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblHostelcode" runat="server" Text='<%# Bind("HostelCode") %>' Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Hostel Name" SortExpression="HostelName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblHName" runat="server" Text='<%# Bind("HostelName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Room No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRoomNo" runat="server" Text='<%# Bind("RoomNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Room Type" SortExpression="RoomType">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRoomTypelId" runat="server" Text='<%# Bind("RoomTypeID") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblRoomType" runat="server" Text='<%# Bind("RoomType") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Occupants">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbloccupants" runat="server" Text='<%# Bind("NoOfOccupants") %>' Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <asp:ObjectDataSource ID="objhostelcode" runat="server" TypeName="DLHostelDetails"
                                    SelectMethod="Gethostelcode" DataObjectTypeName="ERoomType"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="objroomtype" runat="server" TypeName="DLHostelDetails"
                                    SelectMethod="Getroomtype" DataObjectTypeName="ERoomType"></asp:ObjectDataSource>
                            </div>
                        </center>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Room Type" TabIndex="3">
                    <ContentTemplate>
                        <center>
                            <center>
                                <h1 class="headingTxt">
                                    ROOM TYPE
                                    <br />
                                    <br />
                                </h1>
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" ForeColor="#000066" SkinID="lblRsz" Text="Room Type*^ :"></asp:Label>
                                        </td>
                                        <td align="left">
                                            &nbsp;<asp:TextBox ID="txtRoomType" runat="server" MaxLength="50" SkinID="txt" TabIndex="1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblOccupant" runat="server" ForeColor="#000066" SkinID="lblRsz" Text="No. of Occupants* : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            &nbsp;<asp:TextBox ID="txtOccupant" SkinID="txt" runat="server" MaxLength="15" TabIndex="2"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender
                                                ID="FilteredTextBoxExtender3" runat="server" FilterMode="validChars" FilterType="Numbers"
                                                TargetControlID="txtOccupant">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" ForeColor="#000066" SkinID="lblRsz" Text="Remarks : "></asp:Label>
                                        </td>
                                        <td align="left">
                                            &nbsp;<asp:TextBox ID="txtRemarks1" runat="server" SkinID="txt" MaxLength="250" TabIndex="3"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="btnTd" colspan="2" align="center">
                                            <br />
                                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" Text="ADD" TabIndex="4"
                                                CssClass="ButtonClass" OnClientClick="return Validate3();" SkinID="btn" />
                                         &nbsp; <asp:Button ID="btnDetails1" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                                TabIndex="5" Text="VIEW" SkinID="btn" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <div>
                                <center>
                                    <br />
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress3">
                                        <ProgressTemplate>
                                            <div class="PleaseWait">
                                                <asp:Label ID="lblprocess1" runat="server" Text="Processing your request..Please wait..."
                                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblerrmsg" SkinID="lblRed" runat="server" />
                                    <asp:Label ID="lblmsgifo" SkinID="lblGreen" runat="server" />
                                    <br />
                                </center>
                            </div>
                            <br />
                            <center>
                                <asp:Panel ID="panel3" runat="server" ScrollBars="Auto" Width="650px" Height="250px">
                                    <asp:GridView ID="GVRoomType" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                      AllowSorting="True" EnableSortingAndPagingCallbacks="True"
                                        PageSize="100" SkinID="GridView" Width="300px" align="center">
                                        <Columns>
                                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" TabIndex="6" CausesValidation="False"
                                                            CommandName="Edit" Text="Edit" />
                                                        <asp:LinkButton ID="LinkButton2" runat="server" TabIndex="7" CausesValidation="False"
                                                            CommandName="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                            Text="Delete" />
                                                    </center>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Room Type" Visible="true" SortExpression="RoomType">
                                                <ItemTemplate>
                                                    <asp:Label ID="id" runat="server" Text='<%# Bind("RoomTypeAuto") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblRoomType" runat="server" Text='<%# Bind("RoomType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No. of Occupants" SortExpression="NoOfOccupants" ItemStyle-HorizontalAlign="Center"  >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOccupant" runat="server" Text='<%# Bind("NoOfOccupants") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <HeaderStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>' Width="200px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>
                            </center>
                        </center>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image6" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
            </a></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>
