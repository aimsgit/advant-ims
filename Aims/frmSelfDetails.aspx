<%@ Page Language="VB" AutoEventWireup="true" CodeFile="frmSelfDetails.aspx.vb"
    Inherits="frmSelfDetails" Title="Self Details"  ValidateRequest="false"%>

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
            if (msg != "") {
                document.getElementById("<%=NameTextBox.ClientID %>").focus();
                return msg;
            }
            msg = Field30N(document.getElementById("<%=txtregNo.ClientID %>"), 'Registration No');
            if (msg != "") {
                document.getElementById("<%=txtregNo.ClientID %>").focus();
                return msg;
            }
            msg = Field30N(document.getElementById("<%=txtCity.ClientID %>"), 'City');
            if (msg != "") {
                document.getElementById("<%=txtCity.ClientID %>").focus();
                return msg;
            }
            //            msg = DropDownForZero(document.getElementById("<%=ddlState.ClientID %>"), 'State');
            //            if (msg != "") {
            //                document.getElementById("<%=ddlState.ClientID %>").focus();
            //                return msg;
            //            }
            msg = Field30N(document.getElementById("<%=txtcountry.ClientID %>"), 'Country');
            if (msg != "") {
                document.getElementById("<%=txtcountry.ClientID %>").focus();
                return msg;
            }
            msg = Field250N(document.getElementById("<%=txtaddress.ClientID %>"), 'Address');
            if (msg != "") {
                document.getElementById("<%=txtaddress.ClientID %>").focus();
                return msg;
            }

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
            <%--<asp:AsyncPostBackTrigger ControlID="Btnadd" EventName="Click" />--%>
        </Triggers>
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <%--    <center>
                <h1 class="headingTxt">
                    SELF DETAILS</h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            </br>
            <center>
                <%--<asp:Label ID="message" runat="server" ForeColor="Red"></asp:Label>--%>
                <table id="TABLE1" class="custTable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="compname" runat="server" SkinID="lbl" Text="Head Office* :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" SkinID="txtRsz" Width="250" TabIndex="1"></asp:TextBox>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Address :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtaddress" runat="server" SkinID="txtML" TabIndex="2" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblHO" runat="server" SkinID="lbl" Text="Head Office :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbHO" runat="server" Checked="True" Enabled="False" SkinID="Chk"
                                TabIndex="3" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Registration No :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtregNo" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" SkinID="lbl" Text="Contact Person :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactPerson" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="ContactNo 1 :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactNo1" runat="server" SkinID="txt" TabIndex="6" Width="152px"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtContactNo1">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label20" runat="server" SkinID="lbl" Text="Contact No  2 :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactNo2" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtContactNo2">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" SkinID="lbl" Text="City :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtcity" runat="server" SkinID="txt" TabIndex="8" Width="152px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" SkinID="lbl" Text="State :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="ddlState" TabIndex="9" MaxLength="60" runat="server" SkinID="txt">
                                <%--<asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                            </asp:TextBox>
                            <%--<asp:ObjectDataSource ID="ObjState" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetState" TypeName="EnquiryManager">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="0" Name="StateId" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                            <%--<asp:TextBox ID="txtState" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="PinCode :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtpinCode" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" SkinID="lbl" Text="Country :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCountry" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Fax :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFax" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Email :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Website :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWebsite" runat="server" SkinID="txt" TabIndex="14"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblPhoto" runat="server" SkinID="lbl" Text="Photo :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <asp:Image ID="ImageMap1" runat="server" Height="86px" />
                            <asp:Button ID="btnUpload1" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="15"
                                Text="UPLOAD" Visible="true" Width="85px" />
                            <br />
                            <br />
                            <asp:FileUpload ID="FileUpload1" runat="server" SkinID="btn" TabIndex="16" Width="289px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center>
                                <asp:Button ID="btnadd" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                    OnClientClick="return Validate();" SkinID="btn" TabIndex="17" Text="ADD" Visible="false" />
                                <asp:Button ID="btnDetails" runat="server" CssClass="ButtonClass" OnClick="btnDetails_Click"
                                    SkinID="btn" TabIndex="18" Text="VIEW" />
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtpath" runat="server" Text='<%# Bind("Logo") %>' Visible="False"></asp:TextBox>
                            <asp:TextBox ID="CoIdTextBox" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                </br>
                <center>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                    <asp:Label ID="lblgreen" runat="server" SkinID="lblGreen"></asp:Label>
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
                </br>
                <asp:Panel ID="panel1" runat="server" Height="300px" ScrollBars="Auto" Width="650px">
                    <asp:GridView ID="GVSelfDet" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                        DataKeyNames="MyCo_Id" EmptyDataText="There are no records to display." SkinID="GridView"
                        Visible="True">
                        <Columns>
                            <%--<asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" Visible="false" runat="server" CausesValidation="false"
                                        CommandName="Edit" SkinID="btn" Text="Edit" />
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Head Office">
                                <ItemTemplate>
                                    <asp:HiddenField ID="lblId" runat="server" Value='<%# Bind("MyCo_Id") %>' />
                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("MyCo_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
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
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label ID="lblState1" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>
                                    <asp:Label ID="lblState2" runat="server" Visible="false" Text='<%# Bind("State") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail1" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Website">
                                <ItemTemplate>
                                    <asp:Label ID="lblWebsite1" runat="server" Text='<%# Bind("Website") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
        <%--    <Triggers>
            <asp:PostBackTrigger ControlID="UpdateButton"/>
             <asp:PostBackTrigger ControlID="btnadd"/>
    </Triggers>--%>
    </asp:UpdatePanel>

</form>
</body>
</html>
