<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBatchSemesterMap.aspx.vb"
    Inherits="frmBatchSemesterMap" Title="Batch Semester Map" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Batch Semester Map</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
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
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID %>").focus();
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
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
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
                <div>
                    <%--    <center>
                    <h1 class="headingTxt">
                        &nbsp;&nbsp;BATCH SEMESTER MAP
                    </h1>
                </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBatch" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Batch_no"
                                        DataValueField="BatchID" AppendDataBoundItems="true" SkinID="ddlRsz" TabIndex="1"
                                        Width="240">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </center>
            </a><a name="bottom">
                <center>
                    <table>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnDetails" TabIndex="2" runat="server" Text="VIEW" CausesValidation="False"
                                    CommandName="VIEW" SkinID="btn" CssClass="ButtonClass"></asp:Button>&nbsp;
                                <asp:Button ID="BtnUpdate" runat="server" CssClass="ButtonClass" SkinID="BtnRsz"
                                    Text="UPDATE ACADEMIC YEAR" CommandName="UPDATE ACADEMIC YEAR" TabIndex="14"
                                    OnClientClick="BtnUpdate_Click" Width="200px" />
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
                                            <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                       <tr>
                            <td align="right">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataKeyNames="PKID" PageSize="100" SkinID="GridView" Visible="True">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Font-Underline="False" Text="Edit" TabIndex="3"></asp:LinkButton>
                                                <%--<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                        Text="Delete" Font-Underline="False"></asp:LinkButton>--%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="Update"
                                                    Text="Update" TabIndex="6"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Cancel"
                                                    Text="Back" TabIndex="7"></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Semester Name" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("PKID") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("BatchID") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SemesterID") %>' Visible="False"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("StartDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtStartDate" runat="server" SkinID="txt" TabIndex="4" Text='<%# Bind("StartDate","{0:dd-MMM-yyyy}") %>'
                                                    Width="50px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                                    Format="dd-MMM-yyyy" TargetControlID="txtStartDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("EndDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEndDate" runat="server" SkinID="txt" TabIndex="5" Text='<%# Bind("EndDate","{0:dd-MMM-yyyy}") %>'
                                                    Width="50px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                                    Format="dd-MMM-yyyy" TargetControlID="txtEndDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </EditItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Academic Year">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAYear" runat="server" Text='<%# Bind("AcademicYear") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                            <%-- <td>--%>
                            <%-- <ajaxToolkit:MaskedEditExtender ID="meeDOB" runat="server" ClearMaskOnLostFocus="false"
                                    ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                    TargetControlID="txtactualyield1">
                                </ajaxToolkit:MaskedEditExtender>--%>
                            <%--<ajaxToolkit:MaskedEditExtender ID="meeDOJ" runat="server" ClearMaskOnLostFocus="false"
                                    ClipboardEnabled="false" Mask="99-LLL-9999" MaskType="none" PromptCharacter="_"
                                    TargetControlID="txtactualyield">
                                </ajaxToolkit:MaskedEditExtender>--%>
                            <%--</td>--%>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    </asp:Panel>
                </center>
                <%--<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetBatchCombo"
                    TypeName="BatchSemesterMapBL"></asp:ObjectDataSource>--%>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getBatchPlannerCombo"
                    TypeName="BLBatchPlanner"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="BLCreateBatch"
                    SelectMethod="GetCreateBatchAcademicYearCombo"></asp:ObjectDataSource>
            </a>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

