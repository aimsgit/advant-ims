<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmBatchPlanner.aspx.vb"
    Inherits="FrmBatchPlanner" Title="Batch Planner" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Batch Planner</title>
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
            var msg, a;

            msg = DropDownForZeroMul(document.getElementById("<%=DdlBatchPlanner.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=DdlBatchPlanner.ClientID %>").focus();
                a = document.getElementById("<%=LblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;

           
        }

        function Valid1() {
            var msg, a;
            
            msg = DropDownForZeroMul(document.getElementById("<%=DdlBatchPlanner.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=DdlBatchPlanner.ClientID %>").focus();
                a = document.getElementById("<%=LblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSubject.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlSubject.ClientID %>").focus();
                a = document.getElementById("<%=lblSemester.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSemester.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlSemester.ClientID %>").focus();
                a = document.getElementById("<%=lblSemester.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = numericMul(document.getElementById("<%=txtTheory.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=txtTheory.ClientID %>").focus();
                a = document.getElementById("<%=lbltheory.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

           
            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblR.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblG.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblR.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblG.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>
     <script type="text/javascript" language="javascript">
         function Valid3() {
             var msg, a;

             msg = NameField100Mul(document.getElementById("<%=txtPassword.ClientID %>"));
             if (msg != "") {
                 document.getElementById("<%=txtPassword.ClientID %>").focus();
                 a = document.getElementById("<%=Label8.ClientID %>").innerHTML;
                 msg = Spliter(a) + " " + ErrorMessage(msg);
                 return msg;
             }
             return true;
         }
         function Validate3() {
             var msg = Valid3();
             if (msg != true) {
                 if (navigator.appName == "Microsoft Internet Explorer") {
                     document.getElementById("<%=lblpassError.ClientID %>").innerText = msg;
                    
                     return false;
                 }
                 else if (navigator.appName == "Netscape") {
                 document.getElementById("<%=lblpassError.ClientID %>").textContent = msg;
                   
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
                    <%--   <center>
                        <h1 class="headingTxt">
                            BATCH PLANNER</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                  <asp:Panel ID="panel123" runat ="server" >
                  
                    <center>
                        <table>
                            <tr>
                                <td align="Right">
                                    <asp:Label ID="LblBatch" runat="server" Text="Select Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRSZ"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DdlBatchPlanner" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="1" AppendDataBoundItems="true" DataValueField="BatchID" DataTextField="Batch_No"
                                        DataSourceID="objBatchPlanner" Width="254px">
                                        <%--   <asp:ListItem Value="Select"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="Right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lblRSZ" Text="Course&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TxtCourse" runat="server" ReadOnly="True" SkinID="txtRsz" Width="250px"
                                        TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="Right">
                                    <asp:Label ID="Label2" runat="server" SkinID="lblRSZ" Text="Academic Calendar Year&nbsp;:&nbsp;&nbsp;" Width="200px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAcademicYear" runat="server" ReadOnly="True" SkinID="txt" TabIndex="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="Right">
                                    <asp:Label ID="Label3" runat="server" SkinID="lblRSZ" Text="Start Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="Txtstartdate" runat="server" ReadOnly="True" SkinID="txt" TabIndex="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="Right">
                                    <asp:Label ID="Label4" runat="server" SkinID="lblRSZ" Text="Gen Status&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtGenerate" runat="server" ReadOnly="True" SkinID="txt" TabIndex="5"
                                        Text='<%# Bind("Generate") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="Right">
                                    <asp:Label ID="lblcomplete" runat="server" SkinID="lblRSZ" Text="Batch Closed&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtcomplete" runat="server" ReadOnly="True" SkinID="txt" TabIndex="6"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                            </tr>
                            <caption>
                                &nbsp; &nbsp; </tr>
                            </caption>
                        </table>
                    </center>
                    <center>
                        <table>
                            <hr style="width: 520px" />
                            <tr>
                                <td>
                                    <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject* :  "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbltheory" runat="server" SkinID="lbl" Text="Hours :  "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblcredit" runat="server" SkinID="lbl" Text="Credit :  "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*^ : "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSubject" runat="server" SkinID="ddlRsz" DataSourceID="ObjSubject"
                                        DataTextField="Subject_Name" DataValueField="Subject_Code" Width="250px" TabIndex="7">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectCombo"
                                        TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTheory" runat="server" TabIndex="8" ValidationGroup='0123456789.'
                                        SkinID="txtRsz" Width="120"></asp:TextBox>
                                </td>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtTheory">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <td>
                                    <asp:TextBox ID="txtCredit" runat="server" TabIndex="9" ValidationGroup='0123456789.'
                                        SkinID="txtRsz" Width="120"></asp:TextBox>
                                </td>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtCredit">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <td>
                                    <asp:DropDownList ID="ddlSemester" runat="server" DataSourceID="ObjSemester" DataTextField="SemName"
                                        DataValueField="SemCode" SkinID="ddl" TabIndex="10">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemComboBasedonBatch"
                                        TypeName="DLNewCoursePlanner">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DdlBatchPlanner" PropertyName="SelectedValue" Name="BatchID"
                                                DbType="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
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
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnAddDetails" runat="server" CausesValidation="True" SkinID="btn"
                                        Text="ADD" CommandName="ADD" CssClass="ButtonClass" TabIndex="11" OnClientClick="return Validate1();" />
                                    &nbsp;
                                    <asp:Button ID="btnback" runat="server" SkinID="btn" Text="BACK" CssClass="ButtonClass"
                                        CommandName="BACK" TabIndex="12" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp
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
                                <td align="center" >
                                    <asp:Label ID="lblG" runat="server" SkinID="lblGreen"></asp:Label>
                                    <asp:Label ID="lblR" runat="server" SkinID="lblRed"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </center>
                  
                    <center>
                        <table>
                            <tbody>
                                <hr style="width: 550px" />
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnadd" runat="server" Text="GENERATE" SkinID="btnRsz" TabIndex="13"
                                            CommandName="GENERATE" CssClass="ButtonClass " OnClientClick="return Validate();" />&nbsp;
                                        <asp:Button ID="btnview" runat="server" Text="VIEW" SkinID="btn" TabIndex="14"
                                            CommandName="VIEW" CssClass="ButtonClass " OnClientClick="return Validate();" />&nbsp;
                                        <asp:Button ID="btnDelete" runat="server" Text="CLEAR" SkinID="btn" TabIndex="15"
                                            CommandName="CLEAR" CssClass="ButtonClass " OnClientClick="return Validate();" />&nbsp;
                                        <asp:Button ID="btncomplete" runat="server" Text="CLOSE BATCH" SkinID="btnRsz" TabIndex="16"
                                            CommandName="CLOSE BATCH" CssClass="ButtonClass " Width="130px" OnClientClick="return Validate();" />&nbsp;
                                        <asp:Button ID="BtnUpdate" runat="server" Text="UPDATE" SkinID="btn" TabIndex="17"
                                            CommandName="UPDATE" CssClass="ButtonClass " OnClientClick="return Validate();" />&nbsp;
                                            
                                         <asp:Button ID="btnlock" runat="server" Text="LOCK/UNLOCK" OnClientClick="return Validate();" SkinID="btnRsz" CssClass="ButtonClass"
                                                    CommandName="LOCK" Width="150px" TabIndex="17" />
                                                <asp:HiddenField ID="hiddencode" runat="server" />   
                                    </td>
                                </tr>
                                <tr>
                                    <td align ="center" >
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </center>
                    </asp:Panel>
                </div>
            </a><a name="bottom">
                <center>
                    <div>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Height="300px" Width ="750px">
                            <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                                AllowPaging="false" EnableViewState="true" TabIndex="13" PageSize="100" AllowSorting="True"
                                EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                TabIndex="9" Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                TabIndex="10" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject" HeaderStyle-HorizontalAlign="Left" SortExpression="Subject_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" Visible="False" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                            <asp:Label ID="Label7" Visible="False" runat="server" Text='<%# Bind("BatchID") %>'></asp:Label>
                                            <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Subject_Name") %>' Width="175"></asp:Label>
                                            <asp:Label ID="lblsubid" runat="server" Text='<%# Bind("Subject") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sequence">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSequence" runat="server" SkinID="txtRsz" Text='<%# Bind("Sequence") %>'
                                                Width="60px" MaxLength="3" TabIndex="20"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtSequence">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit">
                                        <ItemTemplate>
                                            <asp:Label ID="txtCredit" runat="server" Text='<%# Bind("Credit") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Hours">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbltotalhours" runat="server" Text='<%# Bind("TotalHours") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lecturer/Teacher">
                                        <ItemTemplate>
                                            <asp:Label ID="LabLrecturer" Visible="false" runat="server" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                            <asp:Label ID="Label6" Visible="false" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                            <asp:DropDownList ID="DdlLecture" runat="server" SkinID="ddlRsz" Width="240" TabIndex="25"
                                                AppendDataBoundItems="true" DataValueField="Emp_Code" DataTextField="Emp_Name"
                                                DataSourceID="objLecturer">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Semester" SortExpression="SemName">
                                        <ItemTemplate>
                                            <asp:Label ID="Labelsemester" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>
                                            <asp:Label ID="lblsemid" runat="server" Text='<%# Bind("Semester") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ControlStyle-Width="25px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                Text="Elective" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkElective" runat="server" TabIndex="27" />
                                            <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("id") %>' />
                                            <asp:Label ID="LabelElec" runat="server" Text='<%# Bind("Elective_Status") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <asp:ObjectDataSource ID="objBatchPlanner" runat="server" SelectMethod="getBatchPlannerComboSelect"
                            TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="objLecturer" runat="server" SelectMethod="GetLecturercombo"
                            TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                        <br />
                </center>
                 <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                                <center>
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label8" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" OnTextChanged="btnPassword_click"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center" >
                                                    <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                                                        CommandName="OK" CausesValidation="true"  OnClientClick="return Validate3();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblpassError" runat="server" SkinID="lblRed" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </center>
                            </asp:Panel>
                </div>
                
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" Visible="true" runat="server" SkinID="lblRsz"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </a>
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
