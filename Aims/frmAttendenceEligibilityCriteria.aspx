<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAttendenceEligibilityCriteria.aspx.vb"
    Inherits="frmAttendenceEligibilityCriteria" Title="Attendance Eligibility"  EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Attendance Eligibility</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=DdlBatch.ClientID%>"), 'Batch')
            if (msg != "") {
                document.getElementById("<%=DdlBatch.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DdlSemester.ClientID%>"), 'Semester')
            if (msg != "") {
                document.getElementById("<%=DdlSemester.ClientID%>").focus();
                return msg;
            }
            msg = NameField100(document.getElementById("<%=txtMin.ClientID %>"), 'Min%');
            if (msg != "") {
                document.getElementById("<%=txtMin.ClientID %>").focus();
                return msg;
            }
            return true;
        }


        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblS.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblS.ClientID%>").textContent = "";
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
                <div>
                    <center>
                        <%--    <h1 class="headingTxt">
                        ATTENDANCE ELIGIBILITY
                    </h1>--%>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LblBatch" runat="server" SkinID="lblRSZ" Text="Batch* :&nbsp;&nbsp;">
                                    </asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DdlBatch" runat="server" AutoPostBack="True" DataSourceID="objBatchPlanner"
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="1"
                                        Width="200">
                                        <asp:ListItem Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objBatchPlanner" runat="server" SelectMethod="getBatchPlannerCombo"
                                        TypeName="DLBatchSemester"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    &nbsp;&nbsp;
                                </td>
                                <td align="right">
                                    <asp:Label ID="LblMin" runat="server" SkinID="lblRsz" Text="Min%* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMin" runat="server" MaxLength="3" SkinID="txt" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtMin">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Semester* :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DdlSemester" runat="server" AutoPostBack="true" DataSourceID="ObjSemester"
                                        DataTextField="SemName" DataValueField="SemCode" SkinID="ddl" TabIndex="3">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo1"
                                        TypeName="FeeCollectionBL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DdlBatch" DbType="Int16" Name="Batch" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                
                                </tr>
                                <tr>
                                    &nbsp;&nbsp;
                                </tr>
                                <%--<td align="right">
                                    <asp:Label ID="lblSubject" runat="server" SkinID="lblRsz" Text="Subject* :&nbsp;&nbsp;" Visible="false"  ></asp:Label>
                                </td>--%>
                                <%--<br /><br />--%>
                                
                                <asp:GridView ID="GVSubjectDetails" runat="server" Width="300px" SkinID="GridView" AllowPaging="true"
                            AutoGenerateColumns="False" Visible="true" PageSize="200" AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True">
                            <Columns>
                               <asp:TemplateField HeaderText="Subject" HeaderStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Subject_Name") %>' Width="175"></asp:Label>
                                            <asp:HiddenField  ID="lblsubid" runat="server" Value='<%# Bind("Subject") %>'/>
                                        </ItemTemplate>
                                       <%-- <ItemStyle HorizontalAlign="Left" />--%>
                                    </asp:TemplateField>
                                     <asp:TemplateField ControlStyle-Width="25px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                Text="Select"  Checked="true"  />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSubject" runat="server" TabIndex="27" Checked="true" />
                                            <%--<asp:HiddenField ID="ID" runat="server" Value='<%# Bind("id") %>' />
                                            <asp:Label ID="lblChkSub" runat="server" Text='<%# Bind("Subject_Status") %>' Visible="false"></asp:Label>   --%>
                                     </ItemTemplate>
                                    </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                                
                            
                        </table>
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="4"
                                            Text="SUBMIT" OnClientClick="return Validate();" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                            Text="UPDATE" Visible="false" />
                                    </td>
                                </tr>
                            </table>
                            <hr />
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" SkinID="lblRsz" Text="Transfer To Batch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddltrsfrBatch" runat="server" SkinID="ddlRsz" AutoPostBack="True"
                                            TabIndex="7" DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="objBatchPlanner"
                                            Width="200">
                                            <asp:ListItem Value="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btntransfer" runat="server" CausesValidation="true" CssClass="ButtonClass"
                                            OnClientClick="return Validate1();" SkinID="btnRsz" TabIndex="8" Text="TRANSFER"
                                            Width="110px" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUndo" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="9"
                                            Text="UNDO" Width="90px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblE" runat="server" SkinID="lblRed" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblS" runat="server" SkinID="lblGreen" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </center>
                    <hr />
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
                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Auto" Width="600px">
                            <asp:GridView ID="GEligiblity" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                PageSize="100" SkinID="GridView" AllowSorting="True">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Batch">
                                        <ItemTemplate>
                                            <asp:Label ID="BID" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                        <ItemTemplate>
                                            <asp:Label ID="stdcode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" SortExpression="StdName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                            <asp:HiddenField ID="STD" runat="server" Value='<%# Bind("STDID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Count of Subjects" SortExpression="CountofSubjects">
                                        <ItemTemplate>
                                        <asp:LinkButton ID="lblSubjectFail" runat="server" Text='<%# Bind("CountofSubjects") %>'
                                                        Width="86px" CommandName="Update"></asp:LinkButton>
                                             </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eligible">
                                        <%--<HeaderTemplate>
                                      <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" TabIndex="3" OnCheckedChanged="CheckAll" />
                                     </HeaderTemplate>--%>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkBx" runat="server" TabIndex="4"></asp:CheckBox>
                                            <asp:Label ID="lblEligible" runat="server" Text='<%# Bind("Eligibility") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
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
    <br />
    <center>
        <asp:Button ID="BtnExport" runat="server" CausesValidation="true" CssClass="ButtonClass"
            SkinID="btnRsz" Text="EXPORT TO EXCEL" Width="170" />
    </center>

</form>
</body>
</html>