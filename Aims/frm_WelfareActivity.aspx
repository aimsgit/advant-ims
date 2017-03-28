<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frm_WelfareActivity.aspx.vb"
    Inherits="frm_WelfareActivity" Title="Welfare Activity" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Welfare Activity</title>
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
            msg = DropDownForZeroMul(document.getElementById("<%=DdlBatch.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=DdlBatch.ClientID%>").focus();
                a = document.getElementById("<%=lblBatch.ClientID %>").innerHTML;
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
                    document.getElementById("<%=lblMsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        function Valid1() {
            var msg;
            
            msg = DropDownForZeroMul(document.getElementById("<%=DdlBatch.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=DdlBatch.ClientID%>").focus();
                a = document.getElementById("<%=lblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlScholarship.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=ddlScholarship.ClientID%>").focus();
                a = document.getElementById("<%=lblScholarship.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }


        function Validate1() {

            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").textContent = "";
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
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatch" runat="server" DataTextField="Batch_No" DataSourceID="ObjBatch"
                                        DataValueField="BatchID" Width="240px" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchDDL" TypeName="WelfareActivityDL">
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" Text="Step 1 :Select Batch & Scholarship" SkinID="lblRsz"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label2" runat="server" Text="Step 2 :Click LOAD to get student List"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblScholarship" runat="server" Text="Scholarship :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlScholarship" runat="server" DataTextField="Data" DataSourceID="ObjScholarship"
                                        DataValueField="LookUpAutoID" Width="240px" SkinID="ddlRsz" TabIndex="3" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjScholarship" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetScholarshipDDL" TypeName="WelfareActivityDL"></asp:ObjectDataSource>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" Text="Step 3 :Select Student Eligible for Scholarship "
                                        SkinID="lblRsz"></asp:Label>
                                        <br />
                                    <asp:Label ID="Label5" runat="server" Text="Step 4 :Click APPROVE for Approval" SkinID="lblRsz"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label4" runat="server" Text="Step 5 :Click Report to Generate list of Students with Scholarship."
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td align="left">
                                    &nbsp;<asp:Button ID="btnLoad" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="2" CommandName="LOAD" Text="LOAD" Width="100px" OnClientClick="return Validate();" />
                                </td>
                                <td align="left">
                                    &nbsp;<asp:Button ID="btnApprove" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        CommandName="APPROVE" TabIndex="4" Text="APPROVE" Width="100px" OnClientClick="return Validate1();" />
                                </td>
                                <td align="left">
                                    &nbsp;<asp:Button ID="BtnReport" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="4" Text="REPORT" Width="100px" CommandName="REPORT" />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
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
                    </center>
                    <br />
                    <center>
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                    </center>
                    <br />
                    <center>
                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="100" SkinID="GridView" TabIndex="-1" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Eligible">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                Text="Eligible" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" />
                                            <asp:Label ID="LabelPre" runat="server" Text='<%# Bind("Eligible") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Code">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="lblADId" runat="server" Value='<%# Eval("Std_Id") %>' />
                                            <asp:Label ID="lblStdCode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marks(%)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarks" runat="server" Text='<%# Bind("Marks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Parent Income" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAnnualIncome" runat="server" Text='<%# Bind("AnnualIncome","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Scholarship Name" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblScholarship" runat="server" Text='<%# Bind("Scholarship") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lbldata" runat="server" Text='<%# Bind("Data") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </asp:Panel>
                <%--<center>
                    <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPassword" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                        </table>
                    </asp:Panel>
                </center>--%>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="Images/top.png" Width="30px" />
                        </a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
