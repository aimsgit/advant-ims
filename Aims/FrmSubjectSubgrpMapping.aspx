<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmSubjectSubgrpMapping.aspx.vb"
    Inherits="FrmSubjectSubgrpMapping" Title="Subject Subgroup Mapping" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Subject Subgroup Mapping</title>
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
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>").focus();
                a = document.getElementById("<%=LblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=cmbSemester.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSemester.ClientID%>").focus();
                a = document.getElementById("<%=Label8.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=cmbSubject.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSubject.ClientID%>").focus();
                a = document.getElementById("<%=Label9.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }




            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        function Valid1() {
            var msg;
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>").focus();
                a = document.getElementById("<%=LblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=cmbSemester.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSemester.ClientID%>").focus();
                a = document.getElementById("<%=Label8.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=cmbSubject.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSubject.ClientID%>").focus();
                a = document.getElementById("<%=Label9.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            //            msg = DropDownForZero(document.getElementById("<%=ddlSubjectSubGrp.ClientID%>"), 'Subject Subgroup');
            //            if (msg != "") {
            //                document.getElementById("<%=ddlSubjectSubGrp.ClientID%>").focus();
            //                return msg;
            //            }





            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        function Valid2() {
            var msg;
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>").focus();
                a = document.getElementById("<%=LblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=cmbSemester.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSemester.ClientID%>").focus();
                a = document.getElementById("<%=Label8.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=cmbSubject.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSubject.ClientID%>").focus();
                a = document.getElementById("<%=Label9.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlstudent.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlstudent.ClientID%>").focus();
                a = document.getElementById("<%=lblStudent.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
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
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
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
            </a>
            <div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <asp:Panel ID="ControlsPanel" runat="server">
                    <br />
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td align="Right">
                                    <asp:Label ID="LblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                        TabIndex="1" AppendDataBoundItems="true" DataValueField="BatchID" DataTextField="Batch_No"
                                        DataSourceID="objBatchPlanner" Width="240px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objBatchPlanner" runat="server" SelectMethod="getBatchPlannerComboSelect"
                                        TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" Text="Semester* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSemester" TabIndex="2" runat="server" SkinID="ddlRsz" DataValueField="SemCode"
                                        DataTextField="SemName" DataSourceID="ObjSemester" AutoPostBack="true" Width="240">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objsemester" runat="server" SelectMethod="SemesterCombo1"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatch" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label9" runat="server" Text="Subject* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSubject" TabIndex="3" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                        DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="240">
                                    </asp:DropDownList>
                                </td>
                                <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner2"
                                    TypeName="DLNew_StudentMarks">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                        <asp:ControlParameter ControlID="cmbSemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                            Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <hr />
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td colspan="2" class="btnTd" style="height: 9px" align="center">
                                    <asp:Button ID="btnSubmit" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" SkinID="btnRsz" TabIndex="4" Text="GENERATE" CommandName="GENERATE"/>
                                   &nbsp; <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                        SkinID="BtnRsz" TabIndex="5" Text="VIEW" CommandName="VIEW" Visible="true" />
                                   &nbsp; <asp:Button ID="btnClear" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="6"
                                        Text="CLEAR" CommandName="CLEAR" OnClientClick="return confirm('Do you want to delete the selected record(s)?')"
                                        Width="90px" />
                                  &nbsp; <asp:Button ID="btnLock" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="7"
                                        Text="LOCK/UNLOCK" CommandName="LOCK/UNLOCK" Width="120px" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStudent" runat="server" Text="Student* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlStudent" runat="server" DataSourceID="ObjStudent" AutoPostBack="true"
                                        DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" Width="200">
                                        <%--<asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo1"
                                        TypeName="StudentPerformanceDL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBatch" PropertyName="SelectedValue" Name="Batch"
                                                DbType="Int16" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                &nbsp;<td class="btnTd">
                                    <asp:Button ID="BtnGen" runat="server" CssClass="ButtonClass" SkinID="btn" Text="ADD" CommandName="ADD"
                                        OnClientClick="return Validate2();" />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <hr />
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Width="170" Text="Subject Subgroup* :&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSubjectSubGrp" runat="server" DataSourceID="ObjSubjectSubGrp"
                                        DataTextField="SubGroup_Name" DataValueField="SubGrp_Auto_Id" SkinID="ddlRsz"
                                        Width="250" TabIndex="9">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubjectSubGrp" runat="server" SelectMethod="GetSubjectSubGrpCombo1"
                                        TypeName="DLSubjectSubGrpMapping"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="8" CommandName="UPDATE"
                                        Text="UPDATE" OnClientClick="return Validate1();" />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <div>
                            <center>
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </center>
                        </div>
                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GVSubjectSubGrpMapping" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                Text="Delete" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("SubGrpMap_Id") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblBatchname" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubjectId" runat="server" Text='<%# Bind("Std_Id") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblSubjectName" runat="server" Text='<%# Bind("StdName") %>' Width="170"></asp:Label>
                                            <asp:Label ID="Label14" runat="server" Visible="false" Text='<%# Bind("SubGroup_Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ControlStyle-Width="25px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkElective" runat="server" TabIndex="9" />
                                            <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("SubGrpMap_Id") %>' />
                                            <%--   <asp:Label ID="LabelElec" runat="server" Text='<%# Bind("Elective_Status") %>' Visible="false"></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject Subgroup" HeaderStyle-HorizontalAlign="Left"
                                        SortExpression="Subject_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblElecSub" runat="server" Text='<%# Bind("SubGroup_Name") %>' Width="230"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Subject Subgroup">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlSubjectSubGrp" runat="server" DataSourceID="ObjSubjectSubGrp"
                                                DataTextField="SubGroup_Name" DataValueField="SubGrp_Auto_Id" SkinID="txtRsz"
                                                Width="250" TabIndex="9">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjSubjectSubGrp" runat="server" SelectMethod="GetSubjectSubGrpCombo"
                                                TypeName="DLSubjectSubGrpMapping">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="cmbSubject" DefaultValue="0" Name="Subject" PropertyName="SelectedValue"
                                                        Type="Int16" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </asp:Panel>
                <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                    <center>
                        <table>
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password" OnTextChanged="btnPassword_Click"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK" CommandName="OK"
                                            OnClientClick="btnPassword_Click" />
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
                <br />
                <br />
                <br />
                <br />
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                    </div>
                </a></center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
