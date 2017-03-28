<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStudFeedback.aspx.vb"
    Inherits="frmStudFeedback" Title="STUDENT'S FEEDBACK ON TEACHING FACULTY" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>STUDENT'S FEEDBACK ON TEACHING FACULTY</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
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
                                    Width="80px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblStdCode1" runat="server" SkinID="lblRsz" Width="120px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblBatchNo" runat="server" Text="Batch :&nbsp;" SkinID="lblRsz" Width="75px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="LblBatchNo1" runat="server" SkinID="lblRsz" Width="100px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblSem" runat="server" Text="Semester :&nbsp;" SkinID="lblRsz" Width="80px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSem1" runat="server" SkinID="lblRsz" Width="120px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="LblCourse" runat="server" Text="Course :&nbsp;" SkinID="lblRsz" Width="75px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="LblCourse1" runat="server" SkinID="lblRsz" Width="180px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblSubject" runat="server" Text="Subject* :&nbsp;" SkinID="lblRsz"
                                    Width="80px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSubject" runat="server" SkinID="ddl" DataTextField="Subject_Name"
                                    DataValueField="Subject" AutoPostBack="true">
                                    <asp:ListItem Text="Select" Value="0" />
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblFaculty" runat="server" Text="Faculty :&nbsp;" SkinID="lblRsz"
                                    Width="75px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblFaculty1" runat="server" SkinID="lblRsz" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:GridView ID="GRPhoto" runat="server" SkinID="GridView" DataKeyNames="" ShowHeader="false">
                                    <Columns>
                                        <asp:TemplateField ControlStyle-Width="80px" ControlStyle-Height="80">
                                            <ItemTemplate>
                                                <asp:Image ID="LabelEmp_Photo" ImageUrl='<%# Bind("Photos") %>' runat="server"></asp:Image>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnGenrate" runat="server" Text="GENERATE" CssClass="ButtonClass"
                                CausesValidation="true" SkinID="btnRsz" TabIndex="4" />
                            <asp:Button ID="btnGnrt" runat="server" Text="GENERATE" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="4" />
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
            <br />
            <div>
                <center>
                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="400px">
                        <asp:GridView ID="GVParams" runat="server" SkinID="GridView" DataKeyNames="" AllowPaging="true"
                            AutoGenerateColumns="false" PageSize="100">
                            <Columns>
                                <asp:TemplateField HeaderText="ATTRIBUTES">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPNo" runat="server" Text='<%# Bind("PNo") %>' Visible="false" />
                                        <asp:Label ID="lblParameterName" runat="server" Text='<%# Bind("ParameterName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="500px" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtP1" runat="server" Width="30px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtP1">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks : " SkinID="lblRsz" Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRemarks" runat="server" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </center>
                <center>
                    <table>
                        <asp:Button ID="BtnUpdate" runat="server" CausesValidation="false" Text="SUBMIT"
                            CssClass="ButtonClass" SkinID="btn" />
                    </table>
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

