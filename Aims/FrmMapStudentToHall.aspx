<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmMapStudentToHall.aspx.vb"
    Inherits="FrmMapStudentToHall" Title="Map Student to Exam Hall" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Map Student to Exam Hall</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%= ddlExamBatch.ClientID %>"), 'Exam Batch');
            if (msg != "") {
                document.getElementById("<%= ddlExamBatch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%= ddlSubject.ClientID %>"), 'Subject');
            if (msg != "") {
                document.getElementById("<%= ddlSubject.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%= ddlExamRoom.ClientID %>"), 'Exam Room');
            if (msg != "") {
                document.getElementById("<%= ddlExamRoom.ClientID %>").focus();
                return msg;
            }
            msg = OneChar (document.getElementById("<%= txtFromSerial.ClientID %>"), 'From Serial No.');
            if (msg != "") {
                document.getElementById("<%= txtFromSerial.ClientID %>").focus();
                return msg;
            }
            msg = OneChar(document.getElementById("<%= txtToSerial.ClientID %>"), 'To Serial No.');
            if (msg != "") {
                document.getElementById("<%= txtToSerial.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate() {

            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        function ValidView() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%= ddlExamBatch.ClientID %>"), 'Exam Batch');
            if (msg != "") {
                document.getElementById("<%= ddlExamBatch.ClientID %>").focus();
                return msg;
            }
            return true;
        }



        function ValidateView() {

            var msg = ValidView();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
//            if (window.event.keyCode == 13) {
//                event.returnValue = false;
//                event.cancel = true;
            //            }
//            if (!IsPostBack) {
//                txtboxFirstName.Attributes.Add("onKeyPress",
//                   "doClick('" + btnSearch.ClientID + "',event)");
//            }
//   

        }

    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblExamBatch" runat="server" Text="Exam Batch*^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlExamBatch" runat="server" DataTextField="ExamBatch" DataSourceID="ObjExamBatch"
                                        DataValueField="ExamBatch_Autoid" SkinID="ddlRsz" TabIndex="1" AppendDataBoundItems="False"
                                        Width="250px" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblSub" runat="server" Text="Subject* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSubject" runat="server" SkinID="ddlRsz" DataSourceID="ObjSubject"
                                        DataTextField="Subject_Name" DataValueField="Subjectid" Width="250px" TabIndex="2">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectCombo"
                                        TypeName="DLExamhallAllocation">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlExamBatch" Name="ExamBatch_Autoid" Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblExamRoom" runat="server" Text="Exam Room* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlExamRoom" runat="server" DataTextField="ResourceName" DataSourceID="ObjExamHall"
                                        DataValueField="Rid" SkinID="ddlRsz" TabIndex="3" AppendDataBoundItems="False"
                                        Width="250px" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblCapacity" runat="server" Text="Capacity :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="120px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCapacity" Style="font-weight: bold" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFromSerial" runat="server" Text="From Serial No* :&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFromSerial" TabIndex="4" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="LblToSerial" runat="server" Text="To Serial No* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="120px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtToSerial" TabIndex="5" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <%--<td align="right">
                                    <asp:Label ID="lblCountOfStudents" runat="server" Text="Count of Students :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCountofStd" runat="server" SkinID="txt"></asp:TextBox>
                                </td>
                            </tr>--%>
                        </table>
                        <table>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Width="100px"
                                        TabIndex="6" Text="ADD" OnClientClick="return Validate();" />&nbsp;
                                    <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Width="100px"
                                        TabIndex="7" Text="VIEW" />
                                    <asp:Button ID="btnPublish" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        Width="100" TabIndex="8" Text="PUBLISH" />
                                    <asp:Button ID="btnLock" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Width="120px"
                                        TabIndex="9" Text="LOCK/UNLOCK" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
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
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                    </center>
                    <asp:ObjectDataSource ID="ObjExamBatch" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetExamBatchDDL" TypeName="DLExamHallTicket"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjStudentCenter" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetExamBatchCenter" TypeName="DLExamHallTicket">
                        <%--<SelectParameters>
                        <asp:ControlParameter ControlID="ddlExamBatch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                    </SelectParameters>--%>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjExamHall" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetExamHallDDL" TypeName="DLExamhallAllocation">
                        <%-- <SelectParameters>
                        <asp:ControlParameter ControlID="ddlExamBatch" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                    </SelectParameters>--%>
                    </asp:ObjectDataSource>
                    <br />
                    <center>
                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="5000" SkinID="GridView" TabIndex="-1" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="editbutton" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit" />
                                            <asp:LinkButton ID="deletebutton" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Room" SortExpression="ResourceName">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("RoomAutoId") %>' />
                                            <asp:Label ID="lblRoomno" runat="server" Text='<%# Bind("ResourceName") %>'></asp:Label>
                                            <asp:Label ID="LblRoomid" Visible="false" runat="server" Text='<%# Bind("ExamRoomId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exam Batch" SortExpression="ExamBatch">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExamBatchN" runat="server" Text='<%# Bind("ExamBatch") %>'></asp:Label>
                                            <asp:Label ID="lblExamBatch" Visible="false" runat="server" Text='<%# Bind("ExamBatchId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject" SortExpression="Subject_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubCode" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                            <asp:Label ID="lblsid" Visible="false" runat="server" Text='<%# Bind("SubjectId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exam Date" HeaderStyle-HorizontalAlign="Left" SortExpression="DOE">
                                        <ItemTemplate>
                                            <asp:Label ID="lbleDate" runat="server" Text='<%# Bind("DOE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exam Time" SortExpression="TOE">
                                        <ItemTemplate>
                                            <asp:Label ID="lbleTime" runat="server" Text='<%# Bind("TOE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From Serial No." SortExpression="StdFrom">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFrmsl" runat="server" align="right" Text='<%# Bind("StdFrom") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Serial No." SortExpression="StdTo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTosl" runat="server" align="right" Text='<%# Bind("StdTo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lock Status" SortExpression="LockUnlock">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllock" runat="server" align="right" Text='<%# Bind("LockUnlock") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </asp:Panel>
                <center>
                    <asp:Panel ID="PasswordPanel" runat="server" DefaultButton="btnPassword" Visible="false">
                        <center>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                        </td>
                                        <td>
                                              <asp:TextBox ID="txtPassword" SkinID="txt" runat="server" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        
                                        <asp:TextBox ID="TextBox1" runat="server" Style="display:none; visibility:hidden;"></asp:TextBox>
                                      
                                            <asp:Button ID="btnPassword" runat="server" CssClass="ButtonClass" SkinID="btn" Text="OK"
                                                OnClientClick="btnPassword_click" />
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
                </center>
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

