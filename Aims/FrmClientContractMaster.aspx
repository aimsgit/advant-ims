<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmClientContractMaster.aspx.vb"
    Inherits="FrmClientContractMaster" Title="Client Contract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Client Contract</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DdlBilltype.ClientID %>"), 'Bill Type');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtstdate.ClientID %>"), 'Start Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtExpdate.ClientID %>"), 'Expiry Date');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID %>").innerText = "";
                    return false;
                }
            }
            return true;
        }
    </script>

    <script language="javascript" type="text/javascript">

        function openNewWin(url) {

            var x = window.open(url, 'mynewwin', 'width=900,height=600,scrollbars=yes,location=no,resizable =yes');

            x.focus();

        }

    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    CLIENT CONTRACT MASTER</h1>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;&nbsp;<asp:Label ID="LblselectClient" runat="server" SkinID="lblRSZ" Text="Select Client&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectClient" runat="server" AutoPostBack="True" DataSourceID="ObjSelectClient"
                                AppendDataBoundItems="true" DataTextField="MyCo_Name" DataValueField="MyCo_Code"
                                SkinID="ddlRsz" TabIndex="1" Width="260px">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnReport" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="20" Text="REPORT" Width="100px" />
                        </td>
                    </tr>
                </table>
                <hr />
            </center>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSelectBranch" runat="server" SkinID="lblRsz" Text="Select Branch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DdlSelectBranch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                TabIndex="2" AppendDataBoundItems="False" DataValueField="BranchCode" DataTextField="BranchName"
                                DataSourceID="ObjSelectBranch" Width="260px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <table>
                    <tbody>
                        <tr>
                            <td align="center">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBilltype" runat="server" SkinID="lblRsz" Text="Bill Type* :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Start Date* :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblExpdt" runat="server" SkinID="lblRsz" Text="Expiry Date* :"></asp:Label>
                                        </td>
                                        <%--<td>
                                            <asp:Label ID="lblFixed" runat="server" SkinID="lblRsz" Text="Fixed Charges :"></asp:Label>
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DdlBilltype" runat="server" SkinID="ddl" AutoPostBack="True"
                                                TabIndex="3" AppendDataBoundItems="False" DataValueField="IDAuto" DataTextField="BillType"
                                                DataSourceID="ObjBillType">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtstdate" runat="server" TabIndex="4" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtstdate">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExpdate" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtExpdate">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <%--<td>
                                            <asp:TextBox ID="txtFixed" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAdvance" runat="server" SkinID="lblRsz" Text="Advance :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAdjusted" runat="server" SkinID="lblRsz" Text="Adjusted :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBalance" runat="server" SkinID="lblRsz" Text="Balance :"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtAdvance" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAdvance">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAdjusted" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAdjusted">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBalance" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtBalance">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--  <asp:Label ID="lblperstudent" runat="server" SkinID="lblRsz" Text="Per Student Charge :"></asp:Label>--%>
                                            <asp:Label ID="lblStdCount" runat="server" SkinID="lblRsz" Text="Avg Student count :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblsmschrge" runat="server" SkinID="lblRsz" Text="SMS Count :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblemailchrge" runat="server" SkinID="lblRsz" Text="Email Count :"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtstdcount" runat="server" TabIndex="9" SkinID="txt"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txttsmschrge" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="Txttsmschrge">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Txtemailchrge" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="Txtemailchrge">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblperstudent" runat="server" SkinID="lblRsz" Text="Per Student Charge :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDiscount" runat="server" SkinID="lblRsz" Text="Discount :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblopenclosedstatus" runat="server" SkinID="lblRsz" Text="Open/Closed Status :"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtPerStudent" runat="server" TabIndex="12" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtPerStudent">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDiscount" runat="server" TabIndex="13" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtDiscount">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlOpenClosedStatus" runat="server" SkinID="ddl" TabIndex="14">
                                                <asp:ListItem Text="Open" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Closed" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblothrcharges" runat="server" SkinID="lblRsz" Text="Other Charges :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSetupChrge" runat="server" SkinID="lblRsz" Text=" One Time Setup Charge :"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtOtherCharges" SkinID="txt" runat="server" TabIndex="15"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtOtherCharges">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtSetupChrge" runat="server" SkinID="txt" TabIndex="16"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="TxtSetupChrge">
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
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnadd" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="17"
                                    Text="ADD" OnClientClick="return Validate();" />
                                <asp:Button ID="btnview" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="18"
                                    Text="VIEW" />
                                <asp:Button ID="btnlockunlock" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                    Width="120px" TabIndex="19" Text="LOCK/UNLOCK" />
                                <asp:Button ID="Btnsaleinvoice" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                    TabIndex="21" Text="TAX INVOICE" Width="130px" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <hr style="width: 620px" />
                            </td>
                            <tr>
                                <td>
                                    <center>
                                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                    </center>
                                </td>
                            </tr>
                        </tr>
                    </tbody>
                </table>
            </center>
            <div>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                    <asp:GridView ID="GridView1" runat="server" SkinID="GridView" Visible="True" AutoGenerateColumns="False"
                                        AllowPaging="True" EnableViewState="true" TabIndex="22" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="135px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select"
                                                        Text="Select" Visible="false"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Client" Visible="false">
                                                <ItemTemplate>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Branch" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPKID" Visible="False" runat="server" Text='<%# Bind("PKIDAuto") %>'></asp:Label>
                                                    <asp:HiddenField ID="lblBranch" runat="server" Value='<%#Bind("Branch_Code") %>' />
                                                    <asp:Label ID="lblBranchName" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                                    <asp:HiddenField ID="lblClient" runat="server" Value='<%#Bind("MyCo_Code") %>' />
                                                    <asp:Label ID="lblselectClient" runat="server" Text='<%# Bind("MyCo_Name") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bill Type" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="lblBillTypeId" runat="server" Value='<%#Bind("BIllTypeID") %>' />
                                                    <asp:Label ID="lblbilltype" runat="server" Text='<%# Bind("BillType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Per Student Charge" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblperstd" runat="server" Text='<%# Bind("PerStudent","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Fixed Charges" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFixed" runat="server" Text='<%# Bind("Fixed","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Student Count" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstdcount" runat="server" Text='<%# Bind("StdCount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SMS Count" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsmsCount" runat="server" Text='<%# Bind("SmsCount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SMS Charge" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsmsCharge" runat="server" Text='<%# Bind("SmsCharge","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Count" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemailCount" runat="server" Text='<%# Bind("EmailCount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Charge" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemailCharge" runat="server" Text='<%# Bind("EmailCharge","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="One Time Setup Charge" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsetupCharge" runat="server" Text='<%# Bind("SetUpCharge","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Other Charges" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblotherCharges" runat="server" Text='<%# Bind("OtherCharges","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDiscount" runat="server" Text='<%# Bind("Discount","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Advance" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdvance" runat="server" Text='<%# Bind("Advance","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Adjusted" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdjusted" runat="server" Text='<%# Bind("Adjusted","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Balance" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBalance" runat="server" Text='<%# Bind("Balance","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstartdate" runat="server" Text='<%# Bind("StartDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Expiry Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexpirydate" runat="server" Text='<%# Bind("ExpiryDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOpenStatus" Visible="false" runat="server" Text='<%# Bind("OpenClosedStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbllockstastus" Visible="false" runat="server" Text='<%# Bind("LockStatus") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Setup Cost">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBx" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ObjectDataSource ID="ObjSelectClient" runat="server" SelectMethod="GetClientCombo"
                                    TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjSelectBranch" runat="server" SelectMethod="GetBranchComboAll1"
                                    TypeName="DLClientContractMaster">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlSelectClient" DefaultValue="0" Name="Mycode"
                                            PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjBillType" runat="server" SelectMethod="GetBillTypeCombo"
                                    TypeName="BLClientContractMaster"></asp:ObjectDataSource>
                                <br />
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

