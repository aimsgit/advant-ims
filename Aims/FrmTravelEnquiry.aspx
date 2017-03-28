<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmTravelEnquiry.aspx.vb"
    Inherits="FrmTravelEnquiry" Title="Travel Enquiry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Travel Enquiry</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = ValidateDate(document.getElementById("<%=txtenqdate.ClientID %>"), 'Enquiry Date');
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtenqno.ClientID %>"), 'Enquiry No');
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtnamepass.ClientID %>"), 'Name');
            if (msg != "") return msg;

            msg = ValidateDate(document.getElementById("<%=txtdeptdate.ClientID %>"), 'Departure date');
            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txtenqdate.ClientID %>"), 'Enquiry date');
            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txtdeptdate.ClientID %>"), 'Departure date');
            if (msg != "") return msg;
            //            if (document.getElementById("<%=Rbtriptype.ClientID %>").value != "One Way") {
            //                msg = DropDownForZero(document.getElementById("<%=txtreturn.ClientID %>"), 'Return date');
            //                if (msg != "") {
            //                    document.getElementById("<%=txtreturn.ClientID %>").focus();
            //                    return msg;
            //                }
            //     }

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
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            TRAVEL ENQUIRY
                        </h1>
                    </center>
                    &nbsp;
                    <center>
                        <table>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:RadioButtonList ID="Rbtriptype" runat="server" AutoPostBack="true" TabIndex="1"
                                        RepeatDirection="Horizontal" SkinID="Themes1">
                                        <asp:ListItem Selected="True" Value="One Way">One Way</asp:ListItem>
                                        <asp:ListItem Value="Two Way">Two Way</asp:ListItem>
                                        <asp:ListItem Value="Multicity">Multicity</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblenqdate" runat="server" Text="Enquiry Date*^ &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtenqdate" SkinID="txt" runat="server" TabIndex="2" AutoCompleteType="Disabled"
                                        EnableViewState="False" MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                        SkinID="lblRsz" TargetControlID="txtenqdate" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                        TargetControlID="txtenqdate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblenqno" runat="server" Text="Enquiry Number*^ &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtenqno" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblnamepass" runat="server" Text="Name of Passenger*^ &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtnamepass" runat="server" TabIndex="4" SkinID="txt"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtnamepass">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblref" runat="server" Text="Referral &nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtref" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblnumpass" runat="server" Text="Number of Passengers" SkinID="lblRsz"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbladlts" runat="server" SkinID="lblRsz" Text=" Adults&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    <td>
                                        <asp:DropDownList ID="ddladlts"  runat="server" AppendDataBoundItems="true" 
                                            SkinID="ddl" Style="width: 63px" TabIndex="6">
                                            <asp:ListItem Value="0">1</asp:ListItem>
                                            <asp:ListItem Value="1">2</asp:ListItem>
                                            <asp:ListItem Value="2">3</asp:ListItem>
                                            <asp:ListItem Value="3">4</asp:ListItem>
                                            <asp:ListItem Value="4">5</asp:ListItem>
                                            <asp:ListItem Value="5">6</asp:ListItem>
                                            <asp:ListItem Value="6">7</asp:ListItem>
                                            <asp:ListItem Value="7">8</asp:ListItem>
                                            <asp:ListItem Value="8">9</asp:ListItem>
                                            <asp:ListItem Value="9">10</asp:ListItem>
                                            <asp:ListItem Value="10">11</asp:ListItem>
                                            <asp:ListItem Value="11">12</asp:ListItem>
                                            <asp:ListItem Value="12">13</asp:ListItem>
                                            <asp:ListItem Value="13">14</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblchldrn" runat="server" SkinID="lbl" Text=" Children&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlchldrn" SkinID="ddl" runat="server" AppendDataBoundItems="true" 
                                             Style="width: 63px" TabIndex="7">
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="9">9</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                            <asp:ListItem Value="13">13</asp:ListItem>
                                            <asp:ListItem Value="14">14</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblinfants" runat="server" SkinID="lblRsz" Text=" Infants &nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlinfants" SkinID="ddl" runat="server" AppendDataBoundItems="true" 
                                             Style="width: 63px" TabIndex="8">
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="9">9</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Labelayrs" runat="server" SkinID="lblRsz" Text="(12+yrs)"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Labelcyrs" runat="server" SkinID="lblRsz" Text="(2-11yrs) "></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="Labeliyrs" runat="server" SkinID="lblRsz" Text="(0-2yrs)"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblleave" runat="server" Text="Leaving From^ &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtleave" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbldeptdate" runat="server" Text="Departure Date* &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtdeptdate" runat="server"  SkinID="txt" TabIndex="10" AutoCompleteType="Disabled"
                                        MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdeptdate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                        TargetControlID="txtdeptdate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblgoingto" runat="server" Text="Going To^ &nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtgoingto" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblreturn" runat="server" Text="Return Date*  &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtreturn" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                                </td>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MMM-yyyy"
                                    SkinID="lblRsz" PopupButtonID="calImg3" TargetControlID="txtreturn" Animated="False">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                    FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                    TargetControlID="txtreturn">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblclass" runat="server" Text="Travel Class&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlclass" TabIndex="13" runat="server" SkinID="ddl" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Economy</asp:ListItem>
                                        <asp:ListItem Value="2">Premium Economy</asp:ListItem>
                                        <asp:ListItem Value="3">Buisness</asp:ListItem>
                                        <asp:ListItem Value="4">First</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblvisit" runat="server" Text="Purpose of Visit &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtvisit" runat="server" SkinID="txt" TabIndex="14"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblacco" runat="server" Text="Type of Accomodation &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtacco" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcontno" runat="server" Text="Contact Number^ &nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtcontno" runat="server" SkinID="txt" MaxLength="15" TabIndex="16"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789-+" TargetControlID="txtcontno">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbladrs" runat="server" Text="Address &nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtadrs" runat="server" TabIndex="17" Height="38px" MaxLength="60"
                                        SkinID="txt" TextMode="MultiLine" Width="130px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblemail" runat="server" Text="Email^ &nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtemail" runat="server" TabIndex="18" SkinID="txt" AutoCompleteType="Disabled"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                        FilterMode="InValidChars" InvalidChars=" " TargetControlID="txtemail">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblrmrks" runat="server" Text="Remarks &nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left" style="width: 88px">
                                    <asp:TextBox ID="txtrmrks" runat="server" TabIndex="19" MaxLength="60" SkinID="txt"
                                        TextMode="MultiLine"></asp:TextBox>
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
                        <table>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="center" style="width: 345px">
                                    <asp:CheckBox ID="Chkquote" runat="server" TabIndex="20" Text="Quote" SkinID="lblRsz" />
                                    <asp:CheckBox ID="Chkflwup" runat="server" TabIndex="21" Text="Follow Up" SkinID="lblRsz" />
                                    <asp:CheckBox ID="Chkclosed" runat="server" TabIndex="22" Text="Closed" SkinID="lblRsz" />
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
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnadd" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="23"
                                        Text="ADD" OnClientClick="return Validate();" />
                                </td>
                                <td>
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnview" runat="server" Text="VIEW" CssClass="ButtonClass" SkinID="btn"
                                        TabIndex="24" />
                                </td>
                                <td>
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnprint" runat="server" CssClass="ButtonClass" SkinID="btn" Text="PRINT"
                                        TabIndex="25" />
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
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
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
                    <br />
                    <center>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                SkinID="GridView" Width="1550px">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                SkinID="btn" Text="Edit" />&nbsp;
                                            <asp:LinkButton ID="btndel" runat="server" CausesValidation="false" CommandName="Delete"
                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                Text="Delete" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblprint" runat="server" Text="Print" Visible="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chkeach" runat="server" TabIndex="9" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enquiry Date">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HID" runat="server" Value='<%# Bind("TE_Id") %>' Visible="false" />
                                            <asp:Label ID="lblenqdate" runat="server" Text='<%# Bind("Enquiry_Date","{0:dd-MMM-yyyy}") %>'
                                                Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enquiry No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblenqno" runat="server" Text='<%# Bind("Enquiry_No") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Adults" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbladlts" runat="server" Text='<%# Bind("No_Of_Adult") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Children" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblchldrn" runat="server" Text='<%# Bind("No_Of_Children") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Infants" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinfants" runat="server" Text='<%# Bind("No_of_Infant") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Purpose of Visit" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvisit" runat="server" Text='<%# Bind("Purpose") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Travelclass" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblclass" runat="server" Text='<%# Bind("TravelClass") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type of Accomodation" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblacco" runat="server" Text='<%# Bind("Accomodation_Type") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbladrs" runat="server" Text='<%# Bind("Address") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrmrks" runat="server" Text='<%# Bind("Remarks") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quote" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblquote" runat="server" Text='<%# Bind("Quote") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FollowUp" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfollowup" runat="server" Text='<%# Bind("Follow_Up") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Closed" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblclosed" runat="server" Text='<%# Bind("Closed") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name of passenger">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnamepass" runat="server" Text='<%# Bind("Passenger_Name") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Referral">
                                        <ItemTemplate>
                                            <asp:Label ID="lblref" runat="server" Text='<%# Bind("Referral") %>' Visible="true"> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leaving From">
                                        <ItemTemplate>
                                            <asp:Label ID="lblleave" runat="server" Text='<%# Bind("LeavingFrom") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Departure Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldeptdate" runat="server" Text='<%# Bind("Departure_Date","{0:dd-MMM-yyyy}") %>'
                                                Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Going To">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgoing" runat="server" Text='<%# Bind("GoingTo") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Return Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblreturn" runat="server" Text='<%# Bind("ReturnDate","{0:dd-MMM-yyyy}") %>'
                                                Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%# Bind("Email") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcontactno" runat="server" Text='<%# Bind("Contact_No") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
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
