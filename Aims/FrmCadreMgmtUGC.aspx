<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmCadreMgmtUGC.aspx.vb"
    Inherits="FrmCadreMgmtUGC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cadre Management Form for UGC</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
    <style type="text/css">
        .style2
        {
            width: 118px;
        }
    </style>
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
            msg = DropDownForZeroMul(document.getElementById("<%=ddlUniversity.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlUniversity.ClientID %>").focus();
                a = document.getElementById("<%=lblUniversity.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlProgram.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlProgram.ClientID %>").focus();
                a = document.getElementById("<%=lblProgram.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSalCodeGrd.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlSalCodeGrd.ClientID %>").focus();
                a = document.getElementById("<%=lblSalCode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


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
                    return false;
                }
            }
            return true;
        }
    </script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" Text="CADRE MANAGEMENT" runat="server"></asp:Label>
                    </h1>
                    <br />
                    <br />
                </center>
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblUniversity" runat="server" Text="University* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" colspan="4">
                                    <asp:DropDownList ID="ddlUniversity" runat="server" SkinID="ddlRsz" Width="200px"
                                        AutoPostBack="True" DataSourceID="ObjUniv" DataTextField="BranchName" DataValueField="BranchCode" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text="Select" Selected="True" />
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjUniv" runat="server" TypeName="DLCadreMgmt" SelectMethod="insertBranchCombo_CadreMgmt">
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblProgram" runat="server" Text="Program* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" colspan="4">
                                    <asp:DropDownList ID="ddlProgram" AutoPostBack="true" runat="server" SkinID="ddlRsz"
                                        Width="200px" DataSourceID="ObjPrgm" DataTextField="Data" DataValueField="lookupautoID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjPrgm" runat="server" TypeName="DLCadreMgmt" SelectMethod="DDLPrgmCombo">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblProj" runat="server" SkinID="lblRsz" Text="Project :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left" colspan="4">
                                    <asp:DropDownList ID="ddlProj" runat="server" SkinID="ddlRsz" Width="200" DataSourceID="ObjProj"
                                        DataTextField="Project_Name" DataValueField="ProjectAuto">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjProj" runat="server" TypeName="DLCadreMgmt" SelectMethod="DDLProjCombo">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlProgram" PropertyName="SelectedValue" Name="Program"
                                                DefaultValue="0" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblDept" runat="server" SkinID="lblRsz" Text="Department :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left" colspan="4">
                                    <asp:TextBox ID="txtDept" runat="server" SkinID="txtRsz" Width="200px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <table>
                                <tr>
                                    <td colspan="5">
                                        <hr /="" width="700"></hr>
                                    </td>
                                    <%-- <td colspan="5">
                                <hr />
                            </td>--%>
                                </tr>
                            </table>
                            <tr>
                            </tr>
                            <tr>
                                <table>
                                    <tr>
                                        <td align="right" colspan="4">
                                            <asp:Label ID="lblSalCode" runat="server" SkinID="lblRsz" Text="Salary Code/Cadre* :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="right" colspan="4">
                                            <td align="left">
                                                <asp:DropDownList ID="ddlSalCodeGrd" runat="server" AutoPostBack="true" DataSourceID="ObjDesigSal" DataTextField="SalaryBand" SkinID="ddlRsz" TabIndex="2" Width="140px">
                                                    <%--  <asp:ListItem Value = "0" text = "Select" Enabled = "true"> Select </asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjDesigSal" runat="server" SelectMethod="ddlSalryCodeGrd" TypeName="DesignationDB"></asp:ObjectDataSource>
                                            </td>
                                            <%--</tr>
                        <tr>--%>
                                            <td align="right" colspan="5">&nbsp;&nbsp;<asp:Label ID="lblDesig" runat="server" SkinID="lblRsz" Text="Designation :&nbsp;&nbsp;" Width="120"></asp:Label>
                                            </td>
                                            <td align="left" colspan="5">
                                                <asp:DropDownList ID="ddlDesig" runat="server" AutoPostBack="true" DataSourceID="ObjDesignation" DataTextField="Designation" DataValueField="DesignationCode" SkinID="ddlRsz" Width="140px">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjDesignation" runat="server" SelectMethod="DDLDesigCombo" TypeName="DLCadreMgmt">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlSalCodeGrd" DefaultValue="0" Name="SalaryCode" PropertyName="SelectedValue" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </td>
                                    </tr>
                                </table>
                            </tr>
                            <tr>
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td></td>
                                                    <td align="left">
                                                        <asp:Label ID="lblYear1" runat="server" SkinID="lblRsz" Text="Year :">
                                                    </asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblNo1" runat="server" SkinID="lblRsz" Text="No :">
                                                    </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">&nbsp;&nbsp;&nbsp;<asp:Label ID="lblApproved" runat="server" SkinID="lblRsz" Text="Approved Cadre :&nbsp;&nbsp;" Width="160"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtYear1" runat="server" SkinID="txtRsz" Width="65"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:TextBox ID="txtNo1" runat="server" SkinID="txtRsz" Width="65"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td></td>
                                                    <td align="left">
                                                        <asp:Label ID="lblYear2" runat="server" SkinID="lblRsz" Text="Year :">
                                                    </asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblNo2" runat="server" SkinID="lblRsz" Text="No :">
                                                    </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">&nbsp;<asp:Label ID="lblRequired" runat="server" SkinID="lblRsz" Text="New Required :&nbsp;&nbsp;" Width="120"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtYear2" runat="server" SkinID="txtRsz" Width="65"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:TextBox ID="txtNo2" runat="server" SkinID="txtRsz" Width="65"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </tr>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblRemarks" runat="server" SkinID="lblRsz" Text="Remarks :&nbsp;&nbsp;"
                                            Width="160"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRemarks" runat="server" Height="50" SkinID="txtRsz" TextMode="MultiLine"
                                            Width="250"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <caption>
                                    <br />
                                    <br />
                                    <tr>
                                        <td align="center" class="btnTd">
                                            <center>
                                                <asp:Button ID="btnADD" runat="server" CausesValidation="False" CommandName="ADD"
                                                    CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" Text="ADD"
                                                    ValidationGroup="ADD" />
                                                &nbsp;<asp:Button ID="btnView" runat="server" CausesValidation="False" CommandName="VIEW"
                                                    CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                                                &nbsp;<asp:Button ID="btnApprove" runat="server" CausesValidation="False" CommandName="APPROVE"
                                                    CssClass="ButtonClass" SkinID="btn" Text="APPROVE" />
                                                &nbsp;<asp:Button ID="btnLockUnlock" runat="server" CausesValidation="False" CommandName="LOCK/UNLOCK"
                                                    CssClass="ButtonClass" SkinID="btnRsz" Text="LOCK/UNLOCK" />
                                            </center>
                                            <br />
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblNote" runat="server" Text="*Note :&nbsp;&nbsp;" Width="70" Height="70"
                                                        Font-Bold="true" Font-Italic="true" ></asp:Label><asp:Label
                                                            ID="lblNote2" runat="server" Text="Only Approved Records will be locked" Font-Bold="true"
                                                            Font-Italic="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <center>
                                                <table>
                                                    
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                                                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                                <br />
                                            </center>
                                            <center>
                                                <asp:Panel runat="server" ID="pnllabel" Visible="false">
                                                    <table>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="lblUniv2" runat="server" Text="University :&nbsp;&nbsp;" SkinID="lblRsz"
                                                                    Width="95px" />
                                                            </td>
                                                            <%-- <td>
                                        <asp:Label ID="lblUniv2Q" runat="server" ></asp:Label>
                                        </td>--%>
                                                            <td align="left" colspan="2">
                                                                <asp:Label ID="lblUniv2Ans" runat="server" SkinID="lblRsz" Width="250px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="GV" runat="server" ScrollBars="Auto" Width="1000px" Height="500px">
                                                    <asp:GridView ID="GvCadreMgmt" runat="server" AutoGenerateColumns="False" SkinID="Gridview"
                                                        Visible="False" Width="600px" AllowPaging="True" PageSize="100" AllowSorting="True"
                                                        EnableSortingAndPagingCallbacks="True">
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemStyle Wrap="false" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                        Font-Underline="False" Text="Edit"></asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                        Font-Underline="False" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                        Text="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="App">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAS" runat="server" Text='<%# Bind("ApproveStatus") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Locked">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLS" runat="server" Text='<%# Bind("LockStatus") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="center">
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                                        Width="50px" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkRL" runat="server" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CadreMgmtID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCadreMgmtID" Visible="false" runat="server" Text='<%# Bind("CadreMgmtId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Department" SortExpression="Dept">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDepartment" Width="200" runat="server" Text='<%# Bind("Dept") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SalaryCode" SortExpression="SalaryCode">
                                                                <ItemStyle Wrap="false" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSalaryCodeID" runat="server" Text='<%# Bind("SalaryCode") %>'></asp:Label>
                                                                    <%--<asp:Label ID="lblSalaryCodeID" Visible ="false"  runat="server" Text='<%# Bind("Grade_Auto") %>'></asp:Label>--%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesignationID" Visible="false" runat="server" Text='<%# Bind("DesignationIDD") %>'></asp:Label>
                                                                    <asp:Label ID="lblDesignation" Width="200" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Approved Year" SortExpression="AppCadreYear">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApprovedYear" runat="server" Text='<%# Bind("AppCadreYear") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Approved No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApprovedNo" runat="server" Text='<%# Bind("AppCadreNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Required Year" SortExpression="ReqrdCadreYear">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRequiredYear" runat="server" Text='<%# Bind("ReqrdCadreYear") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Required No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRequiredNo" runat="server" Text='<%# Bind("ReqrdCadreNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="University" Visible="false" SortExpression="BranchName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUniversityid" Visible="false" runat="server" Text='<%# Bind("University") %>'></asp:Label>
                                                                    <asp:Label ID="lblUniversity" Visible="false" Width="200" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Program" SortExpression="Data">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProgramID" Visible="false" runat="server" Text='<%# Bind("Program") %>'></asp:Label>
                                                                    <asp:Label ID="lblProgram" Width="200" runat="server" Text='<%# Bind("Data") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Project" SortExpression="Project_Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProjectID" Visible="false" runat="server" Text='<%# Bind("Project") %>'></asp:Label>
                                                                    <asp:Label ID="lblProject" Width="200" runat="server" Text='<%# Bind("Project_Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remark" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRemark" Visible="false" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Bind("CadreMgmtId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </center>
                                        </td>
                                    </tr>
                                </caption>
                            </table>
                    </center>
                </asp:Panel>
                <center>
                    <asp:Panel ID="PasswordPanel" runat="server" Visible="false">
                        <center>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label1" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                <center>
                    <asp:Panel ID="ApprPasswordPanel" runat="server" Visible="false">
                        <center>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblApprPassword" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;"
                                                SkinID="lbl"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApprPassword" SkinID="txt" runat="server" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnApprPassword" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                Text="OK" OnClientClick="btnApprPassword_click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblApprPassError" runat="server" SkinID="lblRed" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </center>
                    </asp:Panel>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
