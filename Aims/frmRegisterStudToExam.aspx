<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmRegisterStudToExam.aspx.vb"
    Inherits="frmRegisterStudToExam" Title="Register Students to Exam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Register Students to Exam</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlExamBatch.ClientID%>"), 'Exam Batch');
            if (msg != "") {
                document.getElementById("<%=ddlExamBatch.ClientID%>").focus();
                return msg;

            }
            msg = DropDownForZero(document.getElementById("<%=ddlBranch.ClientID%>"), 'Branch');
            if (msg != "") {
                document.getElementById("<%=ddlBranch.ClientID%>").focus();
                return msg;

            }
            msg = DropDownForZero(document.getElementById("<%=ddlBatch.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>").focus();
                return msg;

            }

            //            msg = DropDownForZero(document.getElementById("<%=ddlStudent.ClientID%>"), 'Student');
            //            if (msg != "") {
            //                document.getElementById("<%=ddlStudent.ClientID%>").focus();
            //                return msg;

            //            }
            return true;

        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
//            if (window.event.keyCode == 13) {
//                event.returnValue = false;
//                event.cancel = true;
//            }

        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
            <ContentTemplate>
            <center>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <br />
            <asp:Panel ID="ControlsPanel" runat="server">
                <table class="custTable">
                    <tr>
                        <td align="Left">
                            <asp:Label ID="lblExamBatch" runat="server" Text="Exam Batch*^&nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="150px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlExamBatch" runat="server" DataSourceID="ObjExamBatch" DataTextField="ExamBatch"
                                DataValueField="ExamBatch_Autoid" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true"
                                Width="230">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjExamBatch" runat="server" SelectMethod="GetExamBatch"
                                TypeName="DLExamResources"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="Branch*^&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="ObjExamBranch" DataTextField="BranchName"
                                DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="2" Width="230" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjExamBranch" runat="server" SelectMethod="GetExamBranch"
                                TypeName="DLExamResources">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlExamBatch" Name="BranchCode" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblBatch" runat="server" Text="Batch*^&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblStudent" runat="server" Text="Student*^&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCapacity" runat="server" Text="Eligibility&nbsp;:&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="150px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlBatch" runat="server" DataSourceID="ObjBatch" DataTextField="Batch_No"
                                DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2" AutoPostBack="true" Width="230">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatch" TypeName="DLExamStudRegistration">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStudent" runat="server" DataSourceID="ObjStudent" DataTextField="StdName"
                                DataValueField="STD_ID" SkinID="ddlRsz" TabIndex="3" AutoPostBack="true" Width="230">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudent" TypeName="DLExamStudRegistration">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlBatch" Name="BatchID" />
                                    <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEligibility" runat="server" SkinID="ddlRsz" TabIndex="5"
                                AutoPostBack="true" Width="230">
                                <asp:ListItem Text="Eligible" Value="0" />
                                <asp:ListItem Text="ALL" Value="1" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table>
                        <tr>
                            <td class="btnTd" colspan="2">
                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="4"
                                    Text="ADD" />
                                &nbsp;<asp:Button ID="btnView" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="5" Text="VIEW" />
                                &nbsp;<asp:Button ID="btnClear" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="6" Text="CLEAR" OnClientClick="return confirm('Do you want to delete the selected record(s)?')" />
                                &nbsp;<asp:Button ID="btnLockunlk" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btnRsz" Width="120" TabIndex="7" Text="LOCK/UNLOCK" />
                                &nbsp;<asp:Button ID="btnPublish" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                    SkinID="btn" TabIndex="8" Text="PUBLISH" />
                            </td>
                        </tr>
                    </table>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
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
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:GridView ID="GrdExamStudRegister" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <%-- <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" />--%>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>' Width="200"></asp:Label>
                                                    <asp:Label ID="lblBranchCode" runat="server" Text='<%# Bind("BranchCode") %>' Width="200"
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Exam Batch" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("RegStudId") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblExamBatch" runat="server" Text='<%# Bind("ExamBatch") %>' Width="100"></asp:Label>
                                                    <asp:Label ID="lblExamBatchId" runat="server" Text='<%# Bind("ExamBatchId") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Batch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBatchName" runat="server" Text='<%# Bind("Batch_No") %>' Width="100"></asp:Label>
                                                    <asp:Label ID="lblBatchId" runat="server" Text='<%# Bind("BatchId") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStdCode" runat="server" Text='<%# Bind("StdCode") %>' Width="100"></asp:Label>
                                                    <asp:Label ID="lblStdid" runat="server" Text='<%# Bind("Std_Id") %>' Width="100"
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>' Width="100"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eligibility">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEligibility" runat="server" Text='<%# Bind("Eligibility") %>' Width="100"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Center" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lock Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblloc" runat="server" Text='<%# Bind("LockUnlock") %>' Width="100"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Center" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
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
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

