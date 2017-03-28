<%@ Page Language="VB" AutoEventWireup="true" CodeFile="frmSelfDetailsAdvant.aspx.vb"
    Inherits="frmSelfDetailsAdvant" Title="Self Details" %>

<%@ Register Namespace="BunnyBear" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Self Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>


    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = NameField100(document.getElementById("<%=NameTextBox.ClientID %>"), 'Head Office');
            if (msg != "") return msg;
            msg = Field30N(document.getElementById("<%=txtregNo.ClientID %>"), 'Registration No');
            if (msg != "") return msg;
            msg = Field30N(document.getElementById("<%=txtCity.ClientID %>"), 'City');
            if (msg != "") return msg;
            msg = Field30N(document.getElementById("<%=txtState.ClientID %>"), 'State');
            if (msg != "") return msg;
            msg = Field30N(document.getElementById("<%=txtcountry.ClientID %>"), 'Country');
            if (msg != "") return msg;
            msg = Field250N(document.getElementById("<%=txtaddress.ClientID %>"), 'Address');
            if (msg != "") return msg;
            msg = Field50(document.getElementById("<%=txtPrefix.ClientID %>"), 'Prefix');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload1" />
            <asp:PostBackTrigger ControlID="btnUploadDefault" />
            <asp:PostBackTrigger ControlID="btnUploadHeader" />
            <%--<asp:AsyncPostBackTrigger ControlID="Btnadd" EventName="Click" />--%>
        </Triggers>
        <ContentTemplate>
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        CLIENT MASTER</h1>
                </center>
                <center>
                    <table id="TABLE1">
                        <tr>
                            <td align="right">
                                <asp:Label ID="compname" runat="server" SkinID="lbl" Text="Head Office*^ :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="NameTextBox" runat="server" SkinID="txtRsz" Width="250" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Address :&nbsp"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtaddress" runat="server" SkinID="txt" TabIndex="2" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblHO" Visible="false" runat="server" SkinID="lbl" Text="Head Office :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="cbHO" Visible="false" runat="server" Checked="True" Enabled="False"
                                    SkinID="Chk" />
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Registration No^ :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtregNo" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" SkinID="lbl" Text="City :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcity" runat="server" SkinID="txt" TabIndex="7" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" SkinID="lbl" Text="Contact Person :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactPerson" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" SkinID="lbl" Text="State :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtState" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="ContactNo 1 :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactNo1" runat="server" SkinID="txt" TabIndex="5" Width="152px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="PinCode :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtpinCode" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label20" runat="server" SkinID="lbl" Text="Contact No  2 :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactNo2" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" SkinID="lbl" Text="Country :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCountry" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Fax :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFax" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblStatus" runat="server" SkinID="lbl" Text="Status :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLStatus" runat="server" SkinID="ddl">
                                    <asp:ListItem Selected="True" Value="A">Active</asp:ListItem>
                                    <asp:ListItem Value="S">Suspend</asp:ListItem>
                                    <asp:ListItem Value="R">Resume</asp:ListItem>
                                    <asp:ListItem Value="C">Closed</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Email^ :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblHeaderTextColor" runat="server" SkinID="lbl" Text="Text Colour :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLColor" runat="server" SkinID="ddl">
                                    <asp:ListItem Selected="True">White</asp:ListItem>
                                    <asp:ListItem>Black</asp:ListItem>
                                    <asp:ListItem>Blue</asp:ListItem>
                                    <asp:ListItem>Fuchsia</asp:ListItem>
                                    <asp:ListItem>Gray</asp:ListItem>
                                    <asp:ListItem>Green</asp:ListItem>
                                    <asp:ListItem>Lime</asp:ListItem>
                                    <asp:ListItem>Maroon</asp:ListItem>
                                    <asp:ListItem>Navy</asp:ListItem>
                                    <asp:ListItem>Olive</asp:ListItem>
                                    <asp:ListItem>Purple</asp:ListItem>
                                    <asp:ListItem>Red</asp:ListItem>
                                    <asp:ListItem>Silver</asp:ListItem>
                                    <asp:ListItem>Teal</asp:ListItem>
                                    <asp:ListItem>Aqua</asp:ListItem>
                                    <asp:ListItem>Yellow</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Website^ :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWebsite" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblPrefix" runat="server" SkinID="lbl" Text="Prefix* :&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrefix" MaxLength="4" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblLogo" runat="server" SkinID="lbl" Text="Logo"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDefault" runat="server" SkinID="lbl" Text="Default Image"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblHeaderImage" runat="server" SkinID="lbl" Text="Header Image"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <asp:Image ID="ImageMap1" runat="server" Height="90px" Width="100px" />
                                <br />
                                <br />
                                <asp:Button ID="btnUpload1" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="15"
                                    Text="UPLOAD" Visible="true" Width="85px" />
                                <br />
                                <br />
                                <%--<asp:TextBox ID="txtpath" runat="server" Text='<%# Bind("Logo") %>' Visible="False"></asp:TextBox>--%>
                                <asp:FileUpload ID="FileUpload1" runat="server" SkinID="btn" TabIndex="14" Width="200px" />
                            </td>
                            <td>
                                <br />
                                <asp:Image ID="ImageMapDefault" runat="server" Height="90px" Width="100px" />
                                <br />
                                <br />
                                <asp:Button ID="btnUploadDefault" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="15" Text="UPLOAD" Visible="true" Width="85px" />
                                <br />
                                <br />
                                <%--<asp:TextBox ID="txtPathDefault" runat="server" Text='<%# Bind("LogoDefault") %>' Visible="False"></asp:TextBox>--%>
                                <asp:FileUpload ID="FileUploadDefault" runat="server" SkinID="btn" TabIndex="14"
                                    Width="200px" />
                            </td>
                            <td>
                                <br />
                                <asp:Image ID="ImageMapHeader" runat="server" Height="90px" Width="100px" />
                                <br />
                                <br />
                                <asp:Button ID="btnUploadHeader" runat="server" CssClass="ButtonClass" SkinID="btn"
                                    TabIndex="15" Text="UPLOAD" Visible="true" Width="85px" />
                                <br />
                                <br />
                                <%--<asp:TextBox ID="txtPathHeader" runat="server" Text='<%# Bind("Logo") %>' Visible="False"></asp:TextBox>--%>
                                <asp:FileUpload ID="FileUploadHeader" runat="server" SkinID="btn" TabIndex="14" Width="200px" />
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblAdminName" runat="server" SkinID="lblRsz" Text="Admin Name* :&nbsp;"
                                    Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdminName" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAdminPass" runat="server" SkinID="lblRsz" Text="Admin Password* :&nbsp;"
                                    Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdminPass" runat="server" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblExpiryDate" runat="server" SkinID="lblRsz" Text="ExpiryDate* :&nbsp;"
                                    Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtExpiryDate" runat="server" SkinID="txt"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtExpiryDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCreationdate" runat="server" SkinID="lblRsz" Text="Creation Date :&nbsp;"
                                    Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCreationDate" runat="server" SkinID="txt"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                    Format="dd-MMM-yyyy" TargetControlID="txtCreationDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <br />
                                    <asp:Button ID="btnadd" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" SkinID="btn" TabIndex="16" Text="ADD" />
                                    <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="17"
                                        Text="VIEW" />
                                    <asp:Button ID="btnDeleteJunk" runat="server" CssClass="ButtonClass" OnClientClick="return confirm('Do you want to delete all Junk Data..?')"
                                        SkinID="btnRsz" Text="COMPACT DB" Width="110px" />
                                    <asp:Button ID="BtnReport" runat="server" CssClass="ButtonClass" SkinID="btn" Text="REPORT" />
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="CoIdTextBox" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br>
                    <center>
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                        <asp:Label ID="lblgreen" runat="server" SkinID="lblGreen"></asp:Label>
                    </center>
                    <br>
                    <div>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GVSelfDet" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                DataKeyNames="MyCo_Id" EmptyDataText="There are no records to display." SkinID="GridView"
                                Visible="True" PageSize="100">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                SkinID="btn" Text="Edit" />
                                            &nbsp;
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Delete"
                                                SkinID="btn" Text="AddModules" />
                                            &nbsp;
                                            <asp:LinkButton ID="btnAddModules" runat="server" CausesValidation="false" CommandName="Update"
                                                OnClientClick="return confirm('Do you want to delete all data related to selected Institute..?')"
                                                SkinID="btn" Text="DeleteInst" />
                                            <asp:HiddenField ID="lblId" runat="server" Value='<%# Bind("MyCo_Id") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Head Office">
                                        <ItemTemplate>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("MyCo_Name") %>'></asp:Label>
                                            <asp:Label ID="lblInstCode" runat="server" Text='<%# Bind("MyCo_Code") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Person">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContacPerson1" runat="server" Text='<%# Bind("Contact_Person") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContNo11" runat="server" Text='<%# Bind("Contact_Number1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCity1" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State">
                                        <ItemTemplate>
                                            <asp:Label ID="lblState1" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail1" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Website">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWebsite1" runat="server" Text='<%# Bind("Website") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Creation date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreationdate" runat="server" Text='<%# Bind("Creationdate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
            </div>
        </ContentTemplate>
        <%--    <Triggers>
            <asp:PostBackTrigger ControlID="UpdateButton"/>
             <asp:PostBackTrigger ControlID="btnadd"/>
    </Triggers>--%>
    </asp:UpdatePanel>


</form>
</body>
</html>