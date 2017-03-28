<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FrmExamResources.aspx.vb"
    Inherits="FrmExamResources" Title="Assign Resources To Exam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Assign Resources To Exam</title>
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
            msg = DropDownForZero(document.getElementById("<%=ddlResType.ClientID%>"), 'Resource Type');
            if (msg != "") {
                document.getElementById("<%=ddlResType.ClientID%>").focus();
                return msg;

            }

            msg = DropDownForZero(document.getElementById("<%=ddlResName.ClientID%>"), 'Resource Name');
            if (msg != "") {
                document.getElementById("<%=ddlResName.ClientID%>").focus();
                return msg;

            }
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
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
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
            <center >
              <table class="custTable">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblExamBatch" runat="server" Text="Exam Batch*^&nbsp;:&nbsp;&nbsp;"
                            SkinID="lblRsz" Width="150px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlExamBatch" runat="server" DataSourceID="ObjExamBatch" DataTextField="ExamBatch"
                            DataValueField="ExamBatch_Autoid" SkinID="ddlRsz" TabIndex="1" Width="250" AutoPostBack="true">
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
                            DataValueField="BranchCode" SkinID="ddlRsz" TabIndex="2" Width="250" AutoPostBack="true">
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
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblResType" runat="server" Text="Resource Type*^&nbsp;:&nbsp;&nbsp;"
                            SkinID="lblRsz" Width="150px"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblResname" runat="server" Text="Resource Name*^&nbsp;:&nbsp;&nbsp;"
                            SkinID="lblRsz" Width="150px"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCapacity" runat="server" Text="Allocate Capacity&nbsp;:&nbsp;&nbsp;"
                            SkinID="lblRsz" Width="200px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlResType" runat="server" DataSourceID="ObjResType" DataTextField="ResourceType"
                            DataValueField="Rid" SkinID="ddlRsz" TabIndex="2" Width="250" AppendDataBoundItems="false"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjResType" runat="server" SelectMethod="GetResourceType"
                            TypeName="DLExamResources">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlResName" runat="server" SkinID="ddlRsz" TabIndex="3" AutoPostBack="true"
                            Width="250">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            
                        </asp:DropDownList>
                    <%--  <asp:ObjectDataSource ID="ObjResName" runat="server" SelectMethod="GetResourcename"
                            TypeName="DLExamResources">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlResType" Name="Rid" />
                                <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="objEmpName" runat="server" TypeName="LeaveApplicationDL"
                            SelectMethod="GetEmpcombo">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" />
                            </SelectParameters>
                        </asp:ObjectDataSource>--%>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCapacity" runat="server" SkinID="txt" TabIndex="4" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
           <br />
            <center>
                <table>
                    <tr>
                        <td class="btnTd" colspan="2">
                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" CommandName="Insert"
                                CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="3"
                                Text="ADD" />
                            &nbsp;<asp:Button ID="btnView" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="4" Text="VIEW" />
                            &nbsp;<asp:Button ID="btnPublish" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="5" Text="PUBLISH" />
                             &nbsp;<asp:Button ID="btnLock" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="12"
                                                    Text="LOCK/UNLOCK" CommandName="LOCK" Width="120px" />
                                               
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
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:GridView ID="GrdExamResources" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" />
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch Name" Visible="true" SortExpression="BranchName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("FrmBranch") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam Batch" Visible="true" SortExpression="ExamBatch">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("RAuto_Id") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblExamBatch" runat="server" Text='<%# Bind("ExamBatch") %>'></asp:Label>
                                                <asp:Label ID="lblBatchId" runat="server" Text='<%# Bind("ExamBatchId") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Resource Type" SortExpression="ResourceTypeId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResType" runat="server" Text='<%# Bind("ResourceTypeId") %>' Width="100"></asp:Label>
                                                <asp:Label ID="lblRID" runat="server" Text='<%# Bind("RID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Resource Name" SortExpression="ResourceName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResName" runat="server" Text='<%# Bind("ResourceName") %>' Width="100"></asp:Label>
                                                <asp:Label ID="lblResNameId" runat="server" Text='<%# Bind("ResourceNameId") %>'
                                                    Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Allocate Capacity" SortExpression="capacity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCalpacity" runat="server" Text='<%# Bind("capacity") %>' Width="100"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="center" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Lock Status" SortExpression="LockFlag">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLockFlag" runat="server" Text='<%# Bind("LockFlag") %>' Width="100"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="center" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    
                </asp:Panel>
                </center> 
                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                
            </center>
            </asp:Panel> 
            <asp:Panel ID="PasswordPanel" runat="server" Visible="false" DefaultButton="btnPassword" >
                            <center>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label2" runat="server" Text="Password*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
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
                                                    CommandName="OK" OnClientClick="btnPassword_click" />
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
            <%--<center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                </asp:Panel>
            </center>--%>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>


</form>
</body>
</html>