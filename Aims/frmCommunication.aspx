<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCommunication.aspx.vb"
    Inherits="frmCommunication" Title="Communication" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Communication</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 850px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = Communication(document.getElementById("<%=txtFrom.ClientID %>"), 'From');
            if (msg != "") {
                document.getElementById("<%=txtFrom.ClientID %>").focus();
                return msg;
            }

            msg = NameField100C(document.getElementById("<%=txtmsg.ClientID %>"), 'Message');
            if (msg != "") {
                document.getElementById("<%=txtmsg.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlGroup.ClientID %>"), 'Group');
            if (msg != "") {
                document.getElementById("<%=ddlGroup.ClientID %>").focus();
                return msg;
            }

            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblcorrect.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblcorrect.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }

        function openwindow() {
            window.open('PopFile.aspx', '', 'width=500,height=400,scrollbars=false').focus
        }
        function setValue(myVal) {
            document.getElementById("<%=txturl.ClientID %>").value = myVal;
        }
    </script>

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <%--     <center>
                <h1 class="headingTxt">
                    COMMUNICATION CENTER
                </h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <center>
                <table class="TimeTable">
                    <tr>
                        <%--<td align="center" style="width: 0">
                            &nbsp;
                        </td>--%>
                        <td align="left" colspan="2">
                            <asp:Label ID="Label1" runat="server" Width="469px">
                                <asp:BulletedList ID="BulletedList1" runat="server">
                                <asp:ListItem>Group means &quot;Batch&quot;, &quot;Employee&quot;, Parents&quot;, &quot;Course&quot;, &quot;Public&quot;.</asp:ListItem>
                                
<asp:ListItem>Select name will allow to pick a single name from the group.</asp:ListItem>
                                
<asp:ListItem>Public notice means anyone can see it. (Students, Teachers, Staff, Parents)</asp:ListItem>

<asp:ListItem>Notice Board is for All Groups.</asp:ListItem>                               
                            </asp:BulletedList>
                            
                            </asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnPublish" TabIndex="10" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                SkinID="btn" Text="PUBLISH" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:LinkButton ID="LinkViewStatus" runat="server" Text="View Message Status" cssproperty="Btnclass"
                                Font-Underline="true"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
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
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblError" runat="server" SkinID="lblRed"></asp:Label>
                            <asp:Label ID="lblcorrect" runat="server" SkinID="lblGreen"></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <asp:Panel ID="SuperAdminAccess" runat="server">
                    <table>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="right" valign="top">
                                <asp:Label ID="LblselectClient" runat="server" SkinID="lblRSZ" Width="180px" Text="Select Client*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="DdlSelectClient" runat="server" AutoPostBack="True" DataSourceID="ObjSelectClient"
                                    DataTextField="MyCo_Name" DataValueField="MyCo_Code" SkinID="ddlRsz" Width="260px">
                                    <%--<asp:ListItem Text="Select" Value="0"></asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectClient" runat="server" SelectMethod="GetClientComboALL"
                                    TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td align="right" valign="top">
                                <asp:Label ID="lblSelectBranch" runat="server" SkinID="lblRsz" Width="180px" Text="Select Branch*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="DdlSelectBranch" runat="server" SkinID="ddlRsz" AppendDataBoundItems="False"
                                    DataValueField="BranchCode" DataTextField="BranchName" Width="260px" DataSourceID="ObjSelectBranch">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSelectBranch" runat="server" SelectMethod="GetBranchComboALL"
                                    TypeName="BLClientContractMaster">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlSelectClient" DefaultValue="0" Name="Mycode"
                                            PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </center>
            <table>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblFrom" runat="server" SkinID="lbl" Text="From* :&nbsp;"></asp:Label>
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                    <td align="left" colspan="2">
                        &nbsp;
                    </td>
                    <td align="left" colspan="2">
                        &nbsp;
                    </td>
                    <td align="left" colspan="2">
                        &nbsp;
                    </td>
                    <td align="left" colspan="2">
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="right" valign="top">
                        <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="Date* :&nbsp;&nbsp;"
                            Width="62px"></asp:Label>
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtDate" TabIndex="7" runat="server" SkinID="txt"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                            Format="dd-MMM-yyyy" TargetControlID="txtDate">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top" rowspan="4">
                        <asp:TextBox ID="txtFrom" skinid="txtRsz" TabIndex="1" runat="server" Height="60px" TextMode="MultiLine"
                            Width="240px"></asp:TextBox>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                            SkinID="watermark" TargetControlID="txtFrom" WatermarkText=" Enter publisher Details">
                        </ajaxToolkit:TextBoxWatermarkExtender>
                    </td>
                    <td align="left" rowspan="4" valign="top">
                        <asp:CheckBox ID="CheckSMS" runat="server" TabIndex="2" Text="SMS" Value="1" />
                        <br />
                        <asp:CheckBox ID="CheckEmail" runat="server" TabIndex="3" Text="Email" Value="2" />
                        <br />
                        <asp:CheckBox ID="CheckNotice" runat="server" TabIndex="4" Text="Notice Board" Value="3" />
                        <br />
                    </td>
                    <td align="left" rowspan="4" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" rowspan="4" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" rowspan="4" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" colspan="7" rowspan="4" valign="top">
                        &nbsp;
                    </td>
                    <td align="right" valign="top">
                        <asp:Label ID="lblTo" runat="server" SkinID="lblRsz" Text="To* :&nbsp;&nbsp;" Width="50px"></asp:Label>
                    </td>
                    <td align="left" valign="top">
                        <asp:DropDownList ID="ddlGroup" TabIndex="8" runat="server" AppendDataBoundItems="true"
                            DataValueField="Id" AutoPostBack="true" DataTextField="Name" SkinID="ddl" DataSourceID="objGroup">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="objGroup" runat="server" SelectMethod="GetGroup" TypeName="DLCommunicationModule">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="lblcode" runat="server" SkinID="lblRsz" Text="" Visible="false" Width="95px"></asp:Label>
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtcode" TabIndex="9" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="lblname" runat="server" SkinID="lblRsz" Text="" Visible="false" Width="95px"></asp:Label>
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtname" TabIndex="10" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <%--<td align="left" colspan="2" rowspan="6" valign="top">
                        <asp:Button ID="Button1" TabIndex="10" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                            SkinID="btn" Text="PUBLISH" />
                    </td>--%>
                    <td align="center" colspan="2" rowspan="6" valign="top">
                         <br />
                        <asp:Button ID="btnsrch" TabIndex="10" runat="server" CssClass="ButtonClass"
                            SkinID="btn" Text="SEARCH" visible="false"/>
                        <br />
                        <br />
                        <asp:Panel ID="GVPanel" runat="server" Height="300px" ScrollBars="Auto" Width="410px">
                            <asp:GridView ID="GVName" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                DataKeyNames="ID" PageSize="100" SkinID="GridView" Width="410px" TabIndex="11">
                                <Columns>
                                    <asp:TemplateField ControlStyle-Width="20px" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                Text="ALL" Width="20px" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkIndividual" runat="server" />
                                        </ItemTemplate>
                                        <ControlStyle Width="20px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Select Name" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <HeaderStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                        <HeaderStyle Wrap="false" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <%--<asp:ObjectDataSource ID="ObjName" runat="server" SelectMethod="GetNameCombo" TypeName="BLCommunication">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlGroup" Name="GroupID" PropertyName="SelectedValue"
                                    Type="Int16" />
                            </SelectParameters>
                        </asp:ObjectDataSource>--%>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <asp:Label ID="lblSMSTemplate" runat="server" SkinID="lbl" Text="SMS Template&nbsp;:&nbsp;&nbsp;"></asp:Label>
                    </td>
                    <td align="left" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <asp:DropDownList ID="ddlSMSTemplate" runat="server" SkinID="ddlRsz" DataSourceID="ObjSMSTemplate"
                            DataTextField="TemplateName" DataValueField="STIDAuto" AutoPostBack="true" Width="245px"
                            TabIndex="5">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjSMSTemplate" runat="server" SelectMethod="GetSMSTemplate"
                            TypeName="BLCommunication"></asp:ObjectDataSource>
                    </td>
                    <td align="left" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" colspan="2" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" colspan="2" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" colspan="2" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" valign="top" colspan="2">
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <asp:Label ID="lblMsg" runat="server" SkinID="lbl" Text="Message* :&nbsp;"></asp:Label>
                    </td>
                    <td align="left" colspan="2" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" colspan="3" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" colspan="2" valign="top">
                        &nbsp;
                    </td>
                    <td align="left" valign="top">
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="12">
                        <FTB:FreeTextBox ID="txtmsg" runat="server" AllowHtmlMode="True" BreakMode="LineBreak"
                            ButtonSet="Office2003" EnableHtmlMode="false" HtmlModeDefaultsToMonoSpaceFont="True"
                            ShowTagPath="False" Width="400px" EditorBorderColorDark="Black" EditorBorderColorLight="Wheat"
                            TabIndex="6">
                        </FTB:FreeTextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:TextBox ID="txtUrl" runat="server" SkinID="txtRsz" TabIndex="3" Enabled="False"
                            Width="260px" Visible="true" AutoPostBack="true"></asp:TextBox>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnattach" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                            Text="ATTACHMENT" OnClientClick="javascript:openwindow();" TabIndex="8" Width="130px"
                            Visible="true" />
                    </td>
                </tr>
            </table>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
