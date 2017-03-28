<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmPublishResult.aspx.vb"
    Inherits="FrmPublishResult" Title="Publish Result" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Publish Result</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID %>"), 'Batch No');
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlsemester.ClientID %>"), 'Semester');
            if (msg != "") {
                document.getElementById("<%=ddlsemester.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
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
                            <td align="right">
                                <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                    DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="2"
                                    Width="240px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblsemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlsemester" SkinID="ddlRsz" runat="server" DataSourceID="ObjSemester"
                                    DataTextField="SemName" DataValueField="SemCode" AutoPostBack="True" TabIndex="3"
                                    Width="240px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" Text="Subject :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbSubject" TabIndex="4" runat="server" SkinID="ddlRsz" DataValueField="Subject_Code"
                                    DataTextField="Subject_Name" DataSourceID="ObjSubject" Width="240" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                            <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectforPublish" TypeName="DLReportsR">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                    <asp:ControlParameter ControlID="ddlsemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblass" runat="server" Width="150px" Text="Assessment Type&nbsp:&nbsp&nbsp"
                                    SkinID="lblrsz"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:DropDownList ID="ddlass" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                    TabIndex="5" DataSourceID="Objass" DataTextField="AssessmentType" DataValueField="ID"
                                    Width="240">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="Objass" runat="server" SelectMethod="getassessmentAll"
                                    TypeName="DLBatchReportCardElect"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="BtnView" runat="server" Text="VIEW" SkinID="btn" CausesValidation="true"
                                    TabIndex="6" OnClientClick="return Validate();" CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="BtnPublish" runat="server" Text="PUBLISH" SkinID="btn" CausesValidation="False"
                                    TabIndex="7" OnClientClick="return Validate();" CssClass="ButtonClass" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td colspan="2" align="center">
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
                    </table>
                    <center>
                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GVPublishResult" runat="server" Width="584px" SkinID="GridView"
                            AllowPaging="true" AutoGenerateColumns="False" Visible="true" PageSize="200"
                            AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Update"
                                            Font-Underline="False" Text="Update" TabIndex="3"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Subject_Name") %>' />
                                        <asp:Label ID="lblSubjectId" runat="server" Text='<%# Bind("Subject") %>' Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Assessment Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAssessment" runat="server" Text='<%# Bind("AssessmentType") %>' />
                                        <asp:Label ID="lblAssesmentTypeId" runat="server" Text='<%# Bind("AssesmentTypeId") %>'
                                            Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="25px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                            Text="Publish" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkPublish" runat="server" TabIndex="9" />
                                        <asp:Label ID="lblPublishStatus" runat="server" Text='<%# Bind("Publish_Result") %>'
                                            Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Publish Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPublishDate" runat="server" Text='<%# Bind("Publish_Date","{0:dd-MMM-yyyy}") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlannerComboSelectAll"
                        TypeName="DLBatchPlanner"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                        TypeName="FeeCollectionBL">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                DbType="Int16" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
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