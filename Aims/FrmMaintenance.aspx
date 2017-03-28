<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmMaintenance.aspx.vb"
    Inherits="FrmMaintenance" Title="Machine Maintenance" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Machine Maintenance</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">


        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=ddlCourse.ClientID%>"));

        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=ddlCourse.ClientID%>"));
        }
        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=ddlBatch.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=ddlBatch.ClientID%>"));
        }

        function Valid() {
            var msg;

            msg = ValidateDate(document.getElementById("<%=txtServiceDate.ClientID%>"), 'Service Date');
            if (msg != "") return msg;
            msg = ValidateDate(document.getElementById("<%=txtDueDate.ClientID%>"), 'Due Date');
            if (msg != "") return msg;
            msg = Field255N(document.getElementById("<%=txtRemarks.ClientID %>"), 'Remarks');
            if (msg != "") return msg;
            msg = Field50N(document.getElementById("<%=txtPchanged.ClientID %>"), 'Part Changed');
            if (msg != "") return msg;
            msg = Field50N(document.getElementById("<%=txtTStopped.ClientID %>"), 'Time Stopped');
            if (msg != "") return msg;
            msg = Field50N(document.getElementById("<%=txtTRun.ClientID %>"), 'Time Run');
            if (msg != "") return msg;
            msg = Field50N(document.getElementById("<%=txtOperation.ClientID %>"), 'Operation');
            if (msg != "") return msg;
            msg = Field50N(document.getElementById("<%=txtNeedle.ClientID %>"), 'Needle');
            if (msg != "") return msg;
            msg = Field50N(document.getElementById("<%=txtOName.ClientID %>"), 'Operation Name');
            if (msg != "") return msg;
            msg = Field50N(document.getElementById("<%=txtParts.ClientID %>"), 'Parts');
            if (msg != "") return msg;
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
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
            <div>
                <center>
                    <h1 class="headingTxt">
                        MACHINE MAINTENANCE
                    </h1>
                </center>
                <center>
                    <center>
                        <table class="custTable">
                            <caption>
                                &nbsp;
                                </tr>
                                <caption>
                                    &nbsp;
                                    </tr>
                                    <tr align="center">
                                        <td align="right">
                                            <asp:Label ID="Label1" runat="server" Height="24px" SkinID="lblRsz" Text="Maintenance Type* :
                        &nbsp;" Width="180px"></asp:Label>
                                        </td>
                                        <td colspan="3" style="width: 287px">
                                            <asp:DropDownList ID="ddlMainType" runat="server" AppendDataBoundItems="true" 
                                                AutoPostBack="True" DataSourceID="ObjMaintainType" 
                                                DataTextField="MaintenanceType" DataValueField="M_ID" OnDataBound="MainType" 
                                                OnSelectedIndexChanged="MainType" SkinID="ddl" TabIndex="3">
                                                <asp:ListItem Selected="True" Value="Select">Please Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Machine Make* :
                        &nbsp;"></asp:Label>
                                        </td>
                                        <td style="width: 287px">
                                            <asp:DropDownList ID="ddlManufacture" runat="server" AutoPostBack="True" 
                                                DataTextField="ManuFacturer" DataValueField="ManuFacturer_ID" SkinID="ddl" 
                                                TabIndex="4">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Machine Type* :
                        &nbsp;"></asp:Label>
                                        </td>
                                        <td style="width: 287px">
                                            <asp:DropDownList ID="ddlMachineType" runat="server" AutoPostBack="True" 
                                                DataTextField="AssetName" DataValueField="Asset_ID" SkinID="ddl" TabIndex="5">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td align="right">
                                            <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Text="Machine No* :
                        &nbsp;"></asp:Label>
                                        </td>
                                        <td style="width: 287px">
                                            <asp:DropDownList ID="ddlSerial" runat="server" AutoPostBack="True" 
                                                DataTextField="Serial_No" DataValueField="Serial_No" SkinID="ddl" TabIndex="6">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Text="Machine Model* :
                        &nbsp;"></asp:Label>
                                        </td>
                                        <td style="width: 287px">
                                            <asp:DropDownList ID="ddlModel" runat="server" AutoPostBack="True" 
                                                DataTextField="Model_Number" DataValueField="Model_Number" SkinID="ddl" 
                                                TabIndex="7">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td align="right">
                                            <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="Service Date* :
                        &nbsp;"></asp:Label>
                                        </td>
                                        <td style="width: 287px">
                                            <asp:TextBox ID="txtServiceDate" runat="server" AutoCompleteType="Disabled" 
                                                SkinID="txt" TabIndex="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" SkinID="lbl" Text="Due Date* :
                        &nbsp;"></asp:Label>
                                        </td>
                                        <td style="width: 287px">
                                            <asp:TextBox ID="txtDueDate" runat="server" AutoCompleteType="Disabled" 
                                                SkinID="txt" TabIndex="9"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td align="right">
                                            <asp:Label ID="Remarks" runat="server" SkinID="lbl" Text="Remarks :
                        &nbsp;"></asp:Label>
                                        </td>
                                        <td style="width: 287px">
                                            <asp:TextBox ID="txtRemarks" runat="server" AutoCompleteType="Disabled" 
                                                MaxLength="250" SkinID="txt" TabIndex="10"></asp:TextBox>
                                        </td>
                                    </tr>
                                </caption>
                            </caption>
                        </table>
                    </center>
                    <center>
                        <asp:Panel ID="PnlMachineBroke" runat="server">
                            <table class="custTable">
                                <tr align="center">
                                    <td align="right" style="width: 180px">
                                        <asp:Label ID="Label12" Width="180" runat="server" SkinID="lblRsz" Text="Part Changed :
                        &nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPchanged" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                            TabIndex="11"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="right">
                                        <asp:Label ID="Label13" runat="server" SkinID="lbl" Text="Time Stopped :
                        &nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTStopped" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                            TabIndex="12"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="right">
                                        <asp:Label ID="Label14" runat="server" SkinID="lbl" Text="Time Run :
                        &nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTRun" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                            TabIndex="13"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </center>
                    <center>
                        <asp:Panel ID="PnlNeedle" runat="server">
                            <table class="custTable">
                                <tr align="center">
                                    <td align="right" style="width: 180px">
                                        <asp:Label ID="Label6" runat="server" Width="180" SkinID="lblRsz" Text="Course* :
                        &nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" DataSourceID="ObjCourse"
                                            DataTextField="CourseName" DataValueField="Course_ID" SkinID="ddl" TabIndex="3"
                                            OnDataBound="MainType" OnSelectedIndexChanged="MainType">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="right">
                                        <asp:Label ID="Label8" runat="server" SkinID="lblRsz" width="180" Text="Academic Year* :&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="True" DataSourceID="ObjBatch"
                                            DataTextField="Batch_No" DataValueField="ID" SkinID="ddl" TabIndex="3" OnDataBound="MainType"
                                            OnSelectedIndexChanged="MainType">
                                        </asp:DropDownList>
                                        <%----%>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="right">
                                        <asp:Label ID="Label15" runat="server" SkinID="lbl" Text="Operation :
                        &nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOperation" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                            TabIndex="16"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="right">
                                        <asp:Label ID="Label16" runat="server" SkinID="lbl" Text="Needle :
                        &nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNeedle" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                            TabIndex="18"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="right">
                                        <asp:Label ID="Label17" runat="server" SkinID="lbl" Text="Operator Name :
                        &nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOName" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                            TabIndex="17"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td align="right">
                                        <asp:Label ID="Label20" runat="server" SkinID="lbl" Text="Parts :
                        &nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtParts" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                            TabIndex="19"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <%-- SHFAJDSFNALSKDCFKLASDCFKLASD--%>
                    </center>
                    <table>
                        <caption>
                            &nbsp;
                            </tr>
                            <tr>
                                <td class="btnTd" colspan="2">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btnStyle" 
                                        OnClientClick="return Validate();" SkinID="btn" TabIndex="20" Text="ADD" />
                                    <asp:Button ID="btnDetails" runat="server" CssClass="btnStyle" SkinID="btn" 
                                        TabIndex="21" Text="VIEW" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <div class="errMgs">
                                            <asp:Label ID="msginfo" runat="server" TabIndex="-1" Visible="true"></asp:Label>
                                            <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Format="dd-MMM-yyyy" SkinID="Calendar" TargetControlID="txtServiceDate">
                                    </ajaxToolkit:CalendarExtender>
                                    &nbsp;
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                                        Format="dd-MMM-yyyy" SkinID="Calendar" TargetControlID="txtDueDate">
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:ObjectDataSource ID="ObjMaintainType" runat="server" 
                                        OldValuesParameterFormatString="original_{0}" 
                                        SelectMethod="GetMaintenanceTypeCombo" TypeName="MaintenanceTypeManager">
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="ObjMaintenance" runat="server" 
                                        DataObjectTypeName="MachineMaintenence" DeleteMethod="ChangeFlag" 
                                        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                                        SelectMethod="GetMachineMaintenence" TypeName="MachineMaintenenceBL">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </caption>
                    </table>
                    </center>
                        <center>
                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                                            EmptyDataText="No records to display." AllowPaging="True">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Button1" runat="server" CausesValidation="true" CommandName="Edit"
                                                            Text="Edit" TabIndex="9" />&nbsp;
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Button3" runat="server" CausesValidation="true" CommandName="Delete"
                                                            Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')"
                                                            TabIndex="5" /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Machine Make" SortExpression="ManuFacturer">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="MID" runat="server" Value='<%# Bind("Maintain_ID") %>' />
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ManuFacturer") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Machine Type" SortExpression="AssetName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Entry Date" SortExpression="Entry_Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Entry_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Machine Model" SortExpression="Machine_Model">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Machine_Model") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Machine_Model") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Machine No" SortExpression="Machine_No">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Machine_No") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Machine_No") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cleaned Date" SortExpression="Cleaned_Date">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Cleaned_Date","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Cleaned_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Due Date" SortExpression="Due_Date">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Due_Date","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("Due_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Time Stopped" SortExpression="Time_Stopped">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("Time_Stopped") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("Time_Stopped") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Part Changed" SortExpression="Part_Changed">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("Part_Changed") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("Part_Changed") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Time Run" SortExpression="Time_Run">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("Time_Run") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("Time_Run") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Operation" SortExpression="Operation">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Operation") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("Operation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Operator Name" SortExpression="Operator_Name">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("Operator_Name") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("Operator_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Course Name" SortExpression="CourseName">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox22" runat="server" Text='<%# Bind("CourseName") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label22" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Academic Year" SortExpression="Batch_No">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox19" runat="server" Text='<%# Bind("Batch_No") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label19" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Needle" SortExpression="Needle">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("Needle") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("Needle") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Parts" SortExpression="Parts">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("Parts") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("Parts") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label20" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                        </center>
                                 
                
                <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetDtaCourse" TypeName="CourseDB">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetDtaBatch" TypeName="BatchDB">
                    <SelectParameters>
                        <asp:ControlParameter Name="CourseID" Type="Int64" ControlID="ddlCourse" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

<%--<asp:ObjectDataSource ID="ObjMaintainType" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetMaintenanceType" TypeName="MaintenanceTypeManager">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="id" Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>--%>


</form>
</body>
</html>