<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmNoticeBoard.aspx.vb"
    Inherits="frmNoticeBoard" Title="Notice Board" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Notice Board</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;


            msg = DropDown(document.getElementById("<%=ddlPublicNotice.ClientID %>"), 'Select Group');
            if (msg != "") {
                document.getElementById("<%=ddlPublicNotice.ClientID %>").focus();
                return msg;
            }

            msg = ValidateDate(document.getElementById("<%=txtFrmDate.ClientID %>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFrmDate.ClientID %>").focus();
                return msg;
            }

            msg = ValidateDate(document.getElementById("<%=txtToDate.ClientID %>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID %>").focus();
                return msg;
            }
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                    return false;
                }
            }
            return true;
        }

    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel runat="server" ID="uppanel">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <%--  <center>
                <h1 class="headingTxt">
                    NOTICE BOARD
                </h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlPublicNotice" TabIndex="1" runat="server" SkinID="ddlRsz"
                                Width="150" AutoPostBack="true" DataValueField="id" DataTextField="PublicNotice">
                                <asp:ListItem Value="0">Select Group</asp:ListItem>
                                <asp:ListItem Value="1">Public Notice</asp:ListItem>
                                <asp:ListItem Value="2">Employee Notice</asp:ListItem>
                                <asp:ListItem Value="3">Parents Notice</asp:ListItem>
                                <asp:ListItem Value="4">Transport Notice</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCourseNotice" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="True" DataSourceID="ObjCourse1" DataTextField="CourseName" DataValueField="Courseid"
                                SkinID="ddl" TabIndex="2" Width="150">
                                <asp:ListItem Value="0">Select Course</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCourse1" runat="server" SelectMethod="GetnoticCourse"
                                TypeName="CourseDB"></asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBatchNotice" runat="server" AutoPostBack="true" DataSourceID="ObjBatch"
                                DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="3"
                                Width="200" AppendDataBoundItems="true">
                                <asp:ListItem Value="0" Selected="True">Select Batch</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="BatchComboD" TypeName="DLNoticeBoard">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblFrom" runat="server" SkinID="lbl" Text="From Date* :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTo" runat="server" SkinID="lbl" Text="To Date* :&nbsp;"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td rowspan="2" valign="bottom">
                            &nbsp;
                            <asp:Button ID="btnShow" runat="server" Text="SHOW" CssClass="ButtonClass" SkinID="btn"
                                CausesValidation="true" OnClientClick="return Validate();" TabIndex="6" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtFrmDate" runat="server" SkinID="txtRsz" Width="140" TabIndex="4"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrmDate"
                                Format="dd-MMM-yyyy" Animated="False">
                            </ajaxToolkit:CalendarExtender>
                            <%--<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                SkinID="watermark" TargetControlID="txtFrmDate" WatermarkText="From Date">
                            </ajaxToolkit:TextBoxWatermarkExtender>--%>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterMode="InvalidChars" FilterType="Custom" InvalidChars="\,.!@#$%^&*()+="
                                TargetControlID="txtFrmDate" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" runat="server" SkinID="txtRsz"  Width="140" TabIndex="5"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                Format="dd-MMM-yyyy" Animated="False">
                            </ajaxToolkit:CalendarExtender>
                            <%--<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                SkinID="watermark" TargetControlID="txtToDate" WatermarkText="To Date">
                            </ajaxToolkit:TextBoxWatermarkExtender>--%>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterMode="InvalidChars" FilterType="Custom" InvalidChars="\,.!@#$%^&*()+="
                                TargetControlID="txtToDate" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="right">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <center>
                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
            </center>
            <br />
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <center>
                        <asp:GridView ID="GVNoticeBoard" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                            SkinID="Gridview" DataKeyNames="" TabIndex="6" PageSize="100" Width="650px">
                            <Columns>
                                <asp:TemplateField HeaderText="Notice Board">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <b>Date: </b>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date","{0:dd-MMM-yyyy}") %>'
                                            Font-Bold="true"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                                        <asp:Label ID="lblFrmMsg" runat="server" Text='<%# Bind("MsgFrom") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </center>
                </asp:Panel>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
