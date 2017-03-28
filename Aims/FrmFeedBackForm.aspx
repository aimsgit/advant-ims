<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmFeedBackForm.aspx.vb"
    Inherits="FrmFeedBackForm" Title="Feedback Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Feedback Form</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

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
                     STUDENT'S FEEDBACK ON TEACHING FACULTY
                </h1>
            </center>
            <br />
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <center>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblStdCode" runat="server" Text="Std Code :&nbsp;" SkinID="lblRsz"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblStdCode1" runat="server" SkinID="lblRsz" Width="120px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblBatchNo" runat="server" Text="Batch :&nbsp;" SkinID="lblRsz" Width="75px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="LblBatchNo1" runat="server" SkinID="lblRsz" Width="130px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblSem" runat="server" Text="Semester :&nbsp;" SkinID="lblRsz" Width="100px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSem1" runat="server" SkinID="lblRsz" Width="120px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="LblCourse" runat="server" Text="Course :&nbsp;" SkinID="lblRsz" Width="75px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="LblCourse1" runat="server" SkinID="lblRsz" Width="250px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </asp:Panel>
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblbatch" runat="server" Text="Batch* :&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlbatch" runat="server" DataSourceID="odsbatch" SkinID="ddlRsz"
                                DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="true" Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsbatch" runat="server" SelectMethod="FeedBackBatchDDL"
                                TypeName="FeedBackFormDL"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSemester" runat="server" Text="Semester*&nbsp;:&nbsp;" SkinID="lbl"
                                Width="100px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSemester" runat="server" SkinID="ddl" DataSourceID="ObjSemester"
                                DataTextField="SemName" DataValueField="SemCode">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSemester" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="FeedBackSemesterDDL" TypeName="FeedBackFormDL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" Name="BatchID" Type="Int32" PropertyName="SelectedValue" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr align ="center" >
                        <td colspan="2">
                            <asp:Button ID="btnGenrate" runat="server" Text="GENERATE" CssClass="ButtonClass"
                                CausesValidation="true" SkinID="btnRsz" TabIndex="4" />
                            <asp:Button ID="BtnUpdate" runat="server" CausesValidation="false" Text="SUBMIT"
                                CssClass="ButtonClass" SkinID="btn" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
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
            <div>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GVFeedBack" runat="server" SkinID="GridView" DataKeyNames="" AllowPaging="true"
                            AutoGenerateColumns="false" PageSize="100">
                            <Columns>
                                <%--<asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False"></ItemStyle>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="SL. No.">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="lblFeedbackId" runat="server" Value='<%# Bind("FeedBack_IDAuto") %>' />
                                        <asp:Label ID="lblSlNo" runat="server" Text='<%# Bind("PNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Batch No" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBatchId" runat="server" Text='<%# Bind("BatchID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SemID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSemId" runat="server" Text='<%# Bind("Semester") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Semester" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSemester" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SUBJECT">
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
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="PHOTO" ControlStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Image ID="LabelEmp_Photo" ImageUrl='<%# Bind("Photos") %>' runat="server"></asp:Image>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="P1">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP1" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP1">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P2">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP2" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP2">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P3">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP3" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP3">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P4">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP4" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP4">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P5">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP5" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP5">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P6">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP6" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP6">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P7">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP7" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP7">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P8">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP8" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP8">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P9">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP9" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP9">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P10">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP10" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP10">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks" runat="server" Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
            </div>
            <br />
            <div>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GVParams" runat="server" SkinID="GridView" DataKeyNames="" AllowPaging="true"
                            AutoGenerateColumns="false" PageSize="100">
                            <Columns>
                                <asp:TemplateField HeaderText="PNo" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPNo" runat="server" Text='<%# Bind("PNo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ATTRIBUTES">
                                    <ItemTemplate>
                                        <asp:Label ID="lblParameterName" runat="server" Text='<%# Bind("ParameterName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="500px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Max">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMax" runat="server" Text='<%# Bind("Max") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Min">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMin" runat="server" Text='<%# Bind("Min") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblRemarks" runat="server" Text="Remarks" SkinID="lbl"></asp:Label>
                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" SkinID ="txtRsz" 
                    Width="300px" Height="60px" ></asp:TextBox>--%>
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