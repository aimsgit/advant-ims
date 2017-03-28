<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmApprovalTableConfig.aspx.vb"
    Inherits="frmApprovalTableConfig" Title="APPROVER TABLE CONFIGURATION" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>APPROVER TABLE CONFIGURATION</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <%--  <script type="text/javascript" language="javascript">
        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtFrstEmpCode.ClientID%>"));
        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtFrstEmpCode.ClientID%>"));
        }
        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtScndEmpCode.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtScndEmpCode.ClientID%>"));
        }
        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtThrdEmpCode.ClientID%>"));

        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtThrdEmpCode.ClientID%>"));
        }

        function ShowImage3() {
            GlbShowSImage(document.getElementById("<%=txtFrthEmpCode.ClientID%>"));

        }
        function HideImage3() {
            GlbHideSImage(document.getElementById("<%=txtFrthEmpCode.ClientID%>"));
        }
        function ShowImage4() {
            GlbShowSImage(document.getElementById("<%=txtFifthEmpCode.ClientID%>"));

        }
        function HideImage4() {
            GlbHideSImage(document.getElementById("<%=txtFifthEmpCode.ClientID%>"));
        }


   
    </script>--%>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%-- <center>
                        <h1 class="headingTxt">
                            APPROVER TABLE CONFIGURATION</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right" style="height: 1px; width: 150px;">
                                    <asp:Label ID="lblTN0" runat="server" SkinID="lblRsz" Text="Form Name* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <%--                                <td align="left" style="height: 1px; width: 16px;">
                                    &nbsp;
                                </td>--%>
                                <td align="left">
                                    <asp:DropDownList ID="DDLTableMaster" runat="server" SkinID="ddl" TabIndex="1" AutoPostBack="true">
                                        <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                        <asp:ListItem Value="84">Employee Transfer</asp:ListItem>
                                        <asp:ListItem Value="129">Leave Application</asp:ListItem>
                                        <asp:ListItem Value="131"> Asset Transfer</asp:ListItem>
                                        <asp:ListItem Value="32"> Student Transfer</asp:ListItem>
                                        <asp:ListItem Value="132">Material Indent</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:DropDownList ID="DDLTableMaster" runat="server" AppendDataBoundItems="true"
                                    DataSourceID="ObjectDataSource1" DataTextField="TableName" DataValueField="TableCode"
                                    SkinID="ddlRsz" TabIndex="1" AutoPostBack="True">
                                    <asp:ListItem Selected="true" Value="">Please Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetTableNamesApprove" TypeName="BLTableMaster">
                                    <SelectParameters>
                                        <asp:Parameter Name="p" Type="Object" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" style="height: 1px;">
                                </td>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td style="width: 148px">
                                    <center>
                                        <asp:Label ID="lblSelect" runat="server" SkinID="lbl" Text="Approve type"></asp:Label>
                                    </center>
                                </td>
                                <td>
                                    <center>
                                        <asp:RadioButtonList ID="RBType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                            SkinID="Rd" TabIndex="2">
                                            <asp:ListItem Selected="False" Value="1">Office</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="2">Employee</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 1px" align="left">
                                    &nbsp;
                                </td>
                                <td style="background-color: #9EBA9F; height: 27px; font-weight: bold;">
                                    <center>
                                        <asp:Label ID="lbl2" runat="server" SkinID="lbl" Text="OFFICE"></asp:Label>
                                    </center>
                                </td>
                                <td style="background-color: #9EBA9F; height: 27px; font-weight: bold">
                                    <center>
                                        <asp:Label ID="lbl3" runat="server" SkinID="lbl" Text="EMPLOYEE CODE"></asp:Label>
                                    </center>
                                </td>
                                <tr>
                                    <td align="left" style="height: 1px">
                                        <center>
                                            <asp:Label ID="lbl1" runat="server" SkinID="lbl" Text="1st Approver"></asp:Label>
                                        </center>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl1st" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                            DataSourceID="ObjectDataSource2" DataTextField="BranchTypeName" DataValueField="BranchTypeCode"
                                            SkinID="ddlRsz" Enabled="false" TabIndex="4">
                                            <asp:ListItem Selected="true" Value="">Please Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFifthEmpCode" runat="server" AutoPostBack="true" DataSourceID="objEmp"
                                            DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Enabled="false"
                                            TabIndex="4">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="objEmp" runat="server" SelectMethod="GetHOEmpForWorkFlow"
                                            TypeName="DLTableConfiguration"></asp:ObjectDataSource>
                                        <%-- <asp:TextBox ID="txtFifthEmpCode" runat="server" AutoPostBack="True" Enabled="false"
                                            SkinID="txtRsz" TabIndex="9"></asp:TextBox>--%>
                                        <%--<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender5" runat="Server" CompletionInterval="2000"
                                            CompletionListCssClass="completeListStyle" EnableCaching="true" FirstRowSelected="true"
                                            MinimumPrefixLength="3" OnClientPopulated="HideImage4" OnClientPopulating="ShowImage4"
                                            ServiceMethod="GetHOEmpExt" ServicePath="TextBoxExt.asmx" TargetControlID="txtFifthEmpCode">
                                        </ajaxToolkit:AutoCompleteExtender>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server"
                                            SkinID="watermark" TargetControlID="txtFifthEmpCode" WatermarkText="Type first three Characters">
                                        </ajaxToolkit:TextBoxWatermarkExtender>--%>
                                    </td>
                                    <tr>
                                        <td align="left" style="height: 1px">
                                            <center>
                                                <asp:Label ID="lblroles" runat="server" SkinID="lbl" Text="2nd Approver"></asp:Label></center>
                                        </td>
                                        <td style="width: 197px">
                                            <asp:DropDownList ID="ddl2" runat="server" AppendDataBoundItems="true" AutoPostBack="True"
                                                DataSourceID="ObjectDataSource3" DataTextField="BranchTypeName" DataValueField="BranchTypeCode"
                                                Enabled="false" SkinID="ddlRsz" TabIndex="5">
                                                <asp:ListItem Selected="true" Value="">Please Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlFrthEmpCode" runat="server" AutoPostBack="true" DataSourceID="objEmp1"
                                                DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Enabled="false"
                                                TabIndex="4">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="objEmp1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="GetHOEmpForWorkFlow" TypeName="DLTableConfiguration"></asp:ObjectDataSource>
                                            <%--  <asp:TextBox ID="txtFrthEmpCode" runat="server" AutoPostBack="True" Enabled="false"
                                                SkinID="txtRsz" TabIndex="10"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender4" runat="Server" CompletionInterval="2000"
                                                CompletionListCssClass="completeListStyle" EnableCaching="true" FirstRowSelected="true"
                                                MinimumPrefixLength="3" OnClientPopulated="HideImage3" OnClientPopulating="ShowImage3"
                                                ServiceMethod="GetHOEmpExt" ServicePath="TextBoxExt.asmx" TargetControlID="txtFrthEmpCode">
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                                                SkinID="watermark" TargetControlID="txtFrthEmpCode" WatermarkText="Type first three Characters">
                                            </ajaxToolkit:TextBoxWatermarkExtender>--%>
                                        </td>
                                        <tr>
                                            <td align="left" style="height: 1px">
                                                <center>
                                                    <asp:Label ID="lblroles0" runat="server" SkinID="lbl" Text="3rd Approver"></asp:Label></center>
                                            </td>
                                            <td style="width: 197px">
                                                <asp:DropDownList ID="ddl3" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                                    DataSourceID="ObjectDataSource4" DataTextField="BranchTypeName" DataValueField="BranchTypeCode"
                                                    Enabled="false" SkinID="ddlRsz" TabIndex="6">
                                                    <asp:ListItem Selected="true" Value="">Please Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlThrdEmpCode" runat="server" AutoPostBack="true" DataSourceID="objEmp2"
                                                    DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Enabled="false"
                                                    TabIndex="4">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="objEmp2" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetHOEmpForWorkFlow" TypeName="DLTableConfiguration"></asp:ObjectDataSource>
                                                <%--  <asp:TextBox ID="txtThrdEmpCode" runat="server" AutoPostBack="True" Enabled="false"
                                                    SkinID="txtRsz" TabIndex="11"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="Server" CompletionInterval="2000"
                                                    EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage2"
                                                    OnClientPopulating="ShowImage2" ServiceMethod="GetHOEmpExt" ServicePath="TextBoxExt.asmx"
                                                    TargetControlID="txtThrdEmpCode" CompletionListCssClass="completeListStyle">
                                                </ajaxToolkit:AutoCompleteExtender>
                                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                                    SkinID="watermark" TargetControlID="txtThrdEmpCode" WatermarkText="Type first three Characters">
                                                </ajaxToolkit:TextBoxWatermarkExtender>--%>
                                            </td>
                                            <tr>
                                                <td align="left" style="height: 1px">
                                                    <center>
                                                        <asp:Label ID="lblroles1" runat="server" SkinID="lbl" Text="4th Approver"></asp:Label></center>
                                                </td>
                                                <td style="width: 197px">
                                                    <asp:DropDownList ID="ddl4" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                                        DataSourceID="ObjectDataSource5" DataTextField="BranchTypeName" DataValueField="BranchTypeCode"
                                                        Enabled="false" SkinID="ddlRsz" TabIndex="6">
                                                        <asp:ListItem Selected="true" Value="">Please Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlScndEmpCode" runat="server" AutoPostBack="true" DataSourceID="objEmp3"
                                                        DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Enabled="false"
                                                        TabIndex="4">
                                                        <asp:ListItem Selected="true" Value="">Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="objEmp3" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="GetHOEmpForWorkFlow" TypeName="DLTableConfiguration"></asp:ObjectDataSource>
                                                    <%-- <asp:TextBox ID="txtScndEmpCode" runat="server" AutoPostBack="True" Enabled="false"
                                                        SkinID="txtRsz" TabIndex="12"></asp:TextBox>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" CompletionInterval="2000"
                                                        CompletionListCssClass="completeListStyle" EnableCaching="true" FirstRowSelected="true"
                                                        MinimumPrefixLength="3" OnClientPopulated="HideImage1" OnClientPopulating="ShowImage1"
                                                        ServiceMethod="GetHOEmpExt" ServicePath="TextBoxExt.asmx" TargetControlID="txtScndEmpCode">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                        SkinID="watermark" TargetControlID="txtScndEmpCode" WatermarkText="Type first three Characters">
                                                    </ajaxToolkit:TextBoxWatermarkExtender>--%>
                                                </td>
                                                <tr>
                                                    <td align="left" style="height: 1px">
                                                        <center>
                                                            <asp:Label ID="lblroles2" runat="server" SkinID="lbl" Text="5th Approver"></asp:Label></center>
                                                    </td>
                                                    <td style="width: 197px">
                                                        <asp:DropDownList ID="ddl5" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                                            DataSourceID="ObjectDataSource6" DataTextField="BranchTypeName" DataValueField="BranchTypeCode"
                                                            Enabled="false" SkinID="ddlRsz" TabIndex="8">
                                                            <asp:ListItem Selected="true" Value="">Please Select</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFrstEmpCode" runat="server" AutoPostBack="true" DataSourceID="objEmp4"
                                                            DataTextField="Emp_Name" DataValueField="Emp_Code" SkinID="ddlRsz" Enabled="false"
                                                            TabIndex="4">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="objEmp4" runat="server" OldValuesParameterFormatString="original_{0}"
                                                            SelectMethod="GetHOEmpForWorkFlow" TypeName="DLTableConfiguration"></asp:ObjectDataSource>
                                                        <%-- <asp:TextBox ID="txtFrstEmpCode" runat="server" AutoPostBack="True" Enabled="false"
                                                            SkinID="txtRsz" TabIndex="13"></asp:TextBox>
                                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" CompletionInterval="2000"
                                                            CompletionListCssClass="completeListStyle" EnableCaching="true" FirstRowSelected="true"
                                                            MinimumPrefixLength="3" OnClientPopulated="HideImage" OnClientPopulating="ShowImage"
                                                            ServiceMethod="GetHOEmpExt" ServicePath="TextBoxExt.asmx" TargetControlID="txtFrstEmpCode">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server"
                                                            SkinID="watermark" TargetControlID="txtFrstEmpCode" WatermarkText="Type first three Characters">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>--%>
                                                    </td>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 197px">
                                                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="GetBranchTypes" TypeName="BLTableConfiguration"></asp:ObjectDataSource>
                                                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="GetBranchTypes" TypeName="BLTableConfiguration"></asp:ObjectDataSource>
                                                        </td>
                                                        <td>
                                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="GetBranchTypes" TypeName="BLTableConfiguration"></asp:ObjectDataSource>
                                                            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="GetBranchTypes" TypeName="BLTableConfiguration"></asp:ObjectDataSource>
                                                            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="GetBranchTypes" TypeName="BLTableConfiguration"></asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </tr>
                                            </tr>
                                        </tr>
                                    </tr>
                                </tr>
                            </tr>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnAddGrid" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                        SkinID="btn" Text="ADD" ToolTip="Add" TabIndex="14" />
                                    <asp:Button ID="BtnView" runat="server" CausesValidation="False" CssClass="ButtonClass "
                                        SkinID="btn" Text="VIEW" ToolTip="VIEW" TabIndex="15" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
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
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
                                    <asp:Label ID="lblmsg" runat="server" SkinID="lblgreen"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <center>
                                <asp:GridView ID="GVTblConfig" runat="server" SkinID="GridView" Visible="true" AllowPaging="true"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" TabIndex="16"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="Delete" TabIndex="17" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Table Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTableName" runat="server" Text='<%#Bind("TableName") %>'></asp:Label>
                                                <asp:Label ID="lblTablecode" Visible="false" runat="server" Text='<%#Bind("TableCode") %>'></asp:Label>
                                                <asp:Label ID="HidUDID" Visible="false" runat="server" Text='<%# Bind("Workflow_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="1st Approver ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl1stAp" runat="server" Text='<%#Bind("FirstApprover") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="2nd Approver">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2ndAp" runat="server" Text='<%#Bind("SecApprover") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="3rd Approver">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl3rdAp" runat="server" Text='<%#Bind("ThirdApprover") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="4th Approver">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl4thAp" runat="server" Text='<%#Bind("FourthApprover") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="5th Approver">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl5thAp" runat="server" Text='<%#Bind("FifthApprover") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="1st Approver">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFiratEmp" runat="server" Text='<%#Bind("FirstEmpCode") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lbl1name" runat="server" Text='<%#Bind("firstempname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="2nd Approver">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSecEmp" runat="server" Text='<%#Bind("SecEmpCode") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lbl2name" runat="server" Text='<%#Bind("secempname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="3rd Approver">
                                            <ItemTemplate>
                                                <asp:Label ID="lblThirdEmp" runat="server" Text='<%#Bind("ThirdEmpCode") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lbl3name" runat="server" Text='<%#Bind("thirdempname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="4th Approver">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFourthEmp" runat="server" Text='<%#Bind("FourthEmpCode") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lbl4name" runat="server" Text='<%#Bind("fourthempname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="5th Approver">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFifthEmp" runat="server" Text='<%#Bind("FifthEmpCode") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lbl5name" runat="server" Text='<%#Bind("fifthempname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </center>
                        </table>
                    </center>
                </div>
                <style type="text/css">
                    .completeListStyle
                    {
                        height: 100px;
                        width: 200px;
                        overflow: auto;
                        border: 1px solid DarkGray;
                        list-style-type: none;
                        margin: 0px;
                        background-color: #FFF;
                        text-align: left;
                        font-size: small;
                        vertical-align: middle;
                        color: black;
                    }
                </style>
                <%-- <div id="autocompleteDropDownPanel" runat="server" class="completeListStyle">
            </div>--%>
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
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
