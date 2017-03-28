<%@ Page Title="Email/SMS Rate" Language="VB" AutoEventWireup="false"
    CodeFile="FrmEmailSMSRate.aspx.vb" Inherits="FrmEmailSMSRate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Email/SMS Rate</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
 <script src="js/Tvalidate.js" type="text/javascript">  </script>
 
   <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;

            msg = ValidateDate(document.getElementById("<%=txtFromDate.ClientID %>"), 'From Date');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").textContent = "";
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
            </a>
            <center>
                <h1 class="headingTxt">
                    EMAIL/SMS RATE MASTER
                </h1>
            </center>
            <br />
            <center>
                <table>
                    <tr>
                        <td align="right">
                            &nbsp;&nbsp;<asp:Label ID="LblselectClient" runat="server" SkinID="lblRSZ" Text="Institute^ :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectClient" runat="server" AutoPostBack="True" DataSourceID="ObjSelectClient"
                                AppendDataBoundItems="true" DataTextField="MyCo_Name" DataValueField="MyCo_Code"
                                SkinID="ddlRsz" TabIndex="1" Width="260px">
                               <%-- <asp:ListItem Text="All" Value="0"></asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectClient" runat="server" SelectMethod="GetClientCombo"
                                TypeName="EmailSMSRateDL"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSelectBranch" runat="server" SkinID="lblRsz" Text="Branch^ :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectBranch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                TabIndex="2" AppendDataBoundItems="False" DataValueField="BranchCode" DataTextField="BranchName"
                                DataSourceID="ObjSelectBranch" Width="260px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSelectBranch" runat="server" SelectMethod="GetBranchCombo"
                                TypeName="EmailSMSRateDL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="DdlSelectClient" DefaultValue="0" Name="Mycode"
                                        PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFromDate" runat="server" TabIndex="3" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtFromDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblToDate" runat="server" SkinID="lbl" Text="To Date :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtToDate" runat="server" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                Format="dd-MMM-yyyy" TargetControlID="txtToDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblSmsRate" runat="server" SkinID="lbl" Text="SMS Rate* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSMSRate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtSMSRate">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="LblEmailRate" runat="server" SkinID="lbl" Text="Email Rate* :&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TxtEmailRate" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="TxtEmailRate">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="2">
                            <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="ButtonClass" CausesValidation="true"
                                SkinID="btn" TabIndex="5" OnClientClick="return Validate();" />
                            <asp:Button ID="BtnView" runat="server" CausesValidation="false" Text="VIEW" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="6" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
            </center>
            <div>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" DataKeyNames="" AllowPaging="true"
                            AutoGenerateColumns="false" PageSize="100">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ESMSID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Institute">
                                    <ItemTemplate>
                                        <asp:Label ID="LblInstituteCode" runat="server" Visible="false" Text='<%# Bind("InstituteId") %>'></asp:Label>
                                        <asp:Label ID="lblInstiuteName" runat="server" Text='<%# Bind("MyCo_Name") %>'></asp:Label>
                                      
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="LblBranchCode" runat="server" Value='<%# Bind("BranchId") %>' />
                                        <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="From Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFromDate" runat="server" Text='<%# Bind("FromDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblToDate" runat="server" Text='<%# Bind("ToDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SMS Rate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSMSRate" runat="server" Text='<%# Bind("SMSRate","{0:0.00}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email Rate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmailRate" runat="server" Text='<%# Bind("EmailRate","{0:0.00}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="SUBJECT">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="lblSubjectId" runat="server" Value='<%# Bind("Subject") %>' />
                                        <asp:Label ID="lblSubjectName" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FACULTY">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="lblfacultyId" runat="server" Value='<%# Bind("Lecturer") %>' />
                                        <asp:Label ID="lblFacultyName" runat="server" Text='<%# Bind("FACULTY") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
            </div>
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