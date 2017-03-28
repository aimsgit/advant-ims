<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAimsUsageAnalytics.aspx.vb"
    Inherits="frmAimsUsageAnalytics" Title="AIMS USAGE ANALYTICS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>AIMS USAGE ANALYTICS</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>


    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlInstitute.ClientID %>"), 'Select Institute');
            if (msg != "") {
                document.getElementById("<%=ddlInstitute.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlBranch.ClientID %>"), 'Select Branch');
            if (msg != "") {
                document.getElementById("<%=ddlBranch.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=DDLTableMaster.ClientID %>"), 'Select Table');
            if (msg != "") {
                document.getElementById("<%=DDLTableMaster.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
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
                        AIMS USAGE ANALYTICS
                    </h1>
                </center>
                
                <br />
                <br />
                <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblInstitute" runat="server" Text="Select Institute* :&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlInstitute" runat="server" DataTextField="BranchName" DataSourceID="ObjInstitute"
                                        DataValueField="BranchCode" Width="200px" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjInstitute" runat="server" SelectMethod="GetInstitute"
                                        TypeName="DLAimsUsageAnalytics"></asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblBranch" runat="server" Text="Select Branch* :&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBranch" runat="server" DataTextField="BranchName" DataSourceID="ObjBranch"
                                        DataValueField="BranchCode" Width="200px" SkinID="ddlRsz" TabIndex="3" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" SelectMethod="GetBranchDDl"
                                        TypeName="DLAimsUsageAnalytics">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlInstitute" Name="BranchCode" Type="String" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Select Table* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLTableMaster" runat="server" DataSourceID="ObjectDataSource1"
                                        DataTextField="TableName" DataValueField="TableCode" Width="200px" SkinID="ddlRsz"
                                        TabIndex="1">
                                    </asp:DropDownList>
                                </td>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetTableNames" TypeName="BLAimsUsageAnalytics">
                                    <SelectParameters>
                                        <asp:Parameter Name="p" Type="Object" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblfromdate" runat="server" SkinID="lbl" Text="From Date  :&nbsp;&amp;nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtfromdate" runat="server" TabIndex="3" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion" runat="server" TargetControlID="txtfromdate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lbltodate" runat="server" SkinID="lbl" Text="To Date  :&nbsp;&amp;nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txttodate" runat="server" TabIndex="4" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td align="left">
                                    &nbsp;<asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="2" Text="VIEW" Width="100px" OnClientClick="return Validate();" />
                                </td>
                                <td align="left">
                                    &nbsp;<asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                        TabIndex="4" Text="REPORT" Width="100px" OnClientClick="return Validate();" />
                                </td>
                            </tr>
                        </table>
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
                        <br />
                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="600px" Height="300px">
                            <asp:GridView ID="GVTableDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="100" SkinID="GridView" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Branch Code">
                                        <ItemTemplate>
                                            <%--<asp:HiddenField ID="GID" runat="server" Value='<%# Bind("id") %>' />--%>
                                            <%--<asp:Label ID="Lblcourse" runat="server" Text='<%# Bind("CourseID") %>' Visible="false"></asp:Label>--%>
                                            <asp:Label ID="lblBranchCode" runat="server" Text='<%# Bind("BranchCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchNmae" runat="server" Text='<%#Bind("BranchName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Count of Records">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCountRecords" runat="server" Text='<%#Bind("CountRecords") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Count of Students">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCountofStudents" runat="server" Text='<%#Bind("Countofstudents") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Records/Students">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrecords" runat="server" Text='<%#Bind("records") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                        </asp:Panel>
                    </center>
                </asp:Panel>
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
