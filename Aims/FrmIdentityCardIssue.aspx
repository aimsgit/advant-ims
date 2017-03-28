<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmIdentityCardIssue.aspx.vb"
    Inherits="FrmIdentityCardIssue" Title="Identity Card Issue" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Identity Card Issue</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlbatch1.ClientID %>"), 'Batch ');
            if (msg != "") {
                document.getElementById("<%=ddlbatch1.ClientID %>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLStudent.ClientID %>"), 'Student Name ');
            if (msg != "") {
                document.getElementById("<%=DDLStudent.ClientID %>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
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
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image3" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <%--   <center>
                <h1 class="headingTxt">
                    IDENTITY CARD ISSUE
                </h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBatch1" runat="server" SkinID="lblRsz" Text="Batch* :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlbatch1" runat="server" DataValueField="BatchID" DataTextField="Batch_No"
                                SkinID="ddlRsz" TabIndex="1" DataSourceID="ObjBatch1" AutoPostBack="true" Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch1" runat="server" SelectMethod="BatchComboD" TypeName="feeCollectionDL">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblStudent" runat="server" SkinID="lblRsz" Text="Student Name* :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DDLStudent" runat="server" DataValueField="STD_ID" DataTextField="StdName"
                                SkinID="ddlRsz" TabIndex="2" DataSourceID="ObjStudent" AutoPostBack="true" Width="200">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentDDL"
                                TypeName="DLIdCardIssue">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch1" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/imageupload.gif" Style="width: auto;
                                height: 100px;" />
                        </td>
                        <td align="right">
                            <asp:Label ID="lblStudentCode0" runat="server" SkinID="lblRsz" Text="Student Code  :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStudentCode" runat="server" AutoPostBack="True" SkinID="txt"
                                ReadOnly="True"></asp:TextBox>
                            <br />
                            <asp:HiddenField ID="HidStudentId" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblSemester" runat="server" SkinID="lblRsz" Text="Card Type  :&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCardType" runat="server" SkinID="ddl" TabIndex="3">
                                <asp:ListItem Text="ID" Value="ID"></asp:ListItem>
                                <asp:ListItem Text="Lab" Value="Lab"></asp:ListItem>
                                <asp:ListItem Text="Library" Value="Library"></asp:ListItem>
                            </asp:DropDownList>
                            <td align="right">
                                <asp:Label ID="lblissuedate" runat="server" SkinID="lblRsz" Text="Issue Date :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtIssuedate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="datetxtDateCompletion" runat="server" TargetControlID="txtIssuedate"
                                    Format="dd-MMM-yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="btnTd">
                            <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                Text="ADD" OnClientClick="return Validate();" />
                            <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="6"
                                Text="VIEW" CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="lblRed"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMsg" runat="server" Text="" SkinID="lblGreen"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </td>
                    </tr>
                </table>
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
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                        AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit" SkinID="btn" TabIndex="7"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" SkinID="btn" CausesValidation="False"
                                        CommandName="Delete" TabIndex="8" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                        Text="Delete" Font-Underline="False"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Batch" SortExpression="Batch_No">
                                <ItemTemplate>
                                    <asp:HiddenField ID="lblAuto_P" runat="server" Value='<%# Bind("Auto_PKID") %>' />
                                    <asp:HiddenField ID="lblpkid" runat="server" Value='<%# Bind("PKID") %>' />
                                    <asp:HiddenField ID="lblBatchID" runat="server" Value='<%# Bind("BacthID") %>' />
                                    <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                <ItemTemplate>
                                    <asp:HiddenField ID="lblStdIDd" runat="server" Value='<%# Bind("StudentID") %>' />
                                    <asp:Label ID="lblstudentName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Code" SortExpression="StdCode">
                                <ItemTemplate>
                                    <asp:Label Visible="false" ID="LabelPhotos" runat="server" Text='<%# Bind("Std_Photo") %>'></asp:Label>
                                    <asp:Label ID="lblstudentcode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Card Type" SortExpression="CardType">
                                <ItemTemplate>
                                    <asp:Label ID="lblcardtype" runat="server" Text='<%# Bind("CardType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issue Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblissuedate" runat="server" Text='<%# Bind("IssueDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </center>
            <br />
            <br />
            <br />
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
