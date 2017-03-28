<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmSubjectSubgrpMaster.aspx.vb"
    Inherits="FrmSubjectSubgrpMaster" Title="Subject Subgroup" ValidateRequest="false"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Subject Subgroup</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

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

             function Valid() {

            var msg, a;
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID %>").focus();
                a = document.getElementById("<%=LblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=cmbSemester.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSemester.ClientID %>").focus();
                a = document.getElementById("<%=Label8.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=cmbSubject.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=cmbSubject.ClientID %>").focus();
                a = document.getElementById("<%=Label9.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSubjectSubGrp.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlSubjectSubGrp.ClientID %>").focus();
                a = document.getElementById("<%=Label2.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=DdlLecture1.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=DdlLecture1.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            return true;
        }

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
        
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

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
        <br />
        <br />
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="Right">
                                <asp:Label ID="LblBatch" runat="server" Text="Batch*^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                                <asp:Label ID="Label8" runat="server" Text="Semester*^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                                <asp:Label ID="Label9" runat="server" Text="Subject*^ :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Width="170" Text="Subject Subgroup* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSubjectSubGrp" runat="server" DataSourceID="ObjSubjectSubGrp"
                                    DataTextField="SubGroup_Name" DataValueField="SubGrp_Auto_Id" SkinID="ddlRsz"
                                    Width="240" TabIndex="4">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSubjectSubGrp" runat="server" SelectMethod="GetSubjectSubGrpCombo1"
                                    TypeName="DLSubjectSubGrpMapping"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Width="170" Text="Faculty*^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DdlLecture1" runat="server" AppendDataBoundItems="true" DataSourceID="objTeacher"
                                    DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Width="240px">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <asp:ObjectDataSource ID="objTeacher" runat="server" SelectMethod="GetLecturercombo"
                                TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnadd" runat="server" Text="ADD" SkinID="btn" CausesValidation="true"
                                   CommandName="ADD" TabIndex="5" OnClientClick="return Validate();" CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="btnDet" runat="server" Text="VIEW" SkinID="btn" CausesValidation="False"
                                   CommandName="VIEW" TabIndex="6" CssClass="ButtonClass" />
                                    <br />
                                
                            </td>
                        </tr>
                    </table>
                    <br />
                    <center>
                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <asp:GridView ID="GVSubjectSubGrp" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            SkinID="GridView" PageSize="100">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editbutton" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" />
                                        <asp:LinkButton ID="Button2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Batch" SortExpression="Batch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubAutoId" runat="server" Text='<%# Bind("SubGrpFMap_Auto_Id") %>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblBatchID" runat="server" Text='<%# Bind("Batch_Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblBatchname" runat="server" Text='<%# Bind("Batch_No") %>' Width="150"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Semester" SortExpression="Semester">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSemID" runat="server" Text='<%# Bind("Semester_Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblSemname" runat="server" Text='<%# Bind("SemName") %>' Width="100"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubjectID" runat="server" Text='<%# Bind("Subject_Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblSubjectname" runat="server" Text='<%# Bind("Subject_Name") %>'
                                            Width="175"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject Subgroup" SortExpression="Subject Subgroup">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubID" runat="server" Text='<%# Bind("SubGrp_Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblSubgrpname" runat="server" Text='<%# Bind("SubGroup_Name") %>'
                                            Width="100"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Faculty" SortExpression="Faculty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpID" runat="server" Text='<%# Bind("Faculty_Id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblEmpname" runat="server" Text='<%# Bind("Emp_Name") %>' Width="150"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <a name="bottom">
                        <div align="right">
                            <a href="#top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                        </div>
                    </a>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</form>
</body>
</html>
