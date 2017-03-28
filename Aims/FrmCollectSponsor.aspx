<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmCollectSponsor.aspx.vb"
    Inherits="FrmCollectSponsor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Collect Sponsor Money</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">


        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtStudentCode.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtStudentCode.ClientID%>"));
        }


        function Validate() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed1.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen1.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed1.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen1.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }

        function Valid1() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlbatch1.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlbatch1.ClientID%>")
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLStudent.ClientID%>"), 'Student Code/Student Name');
            if (msg != "") {
                document.getElementById("<%=DDLStudent.ClientID%>")
                return msg;
            }

            return true;
        }
    </script>

    <script language="javascript" type="text/javascript">
        function Validate1() {
            var msg = Valid2();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblR1.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblG1.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblR1.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblG1.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }


        function Valid2() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlbatch1.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlbatch1.ClientID%>")
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLStudent.ClientID%>"), 'Student Code/Student Name');
            if (msg != "") {
                document.getElementById("<%=DDLStudent.ClientID%>")
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlsponsor.ClientID%>"), 'Sponsor');
            if (msg != "") {
                document.getElementById("<%=ddlsponsor.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlPaymentMethod.ClientID%>"), 'Mode');
            if (msg != "") {
                document.getElementById("<%=ddlPaymentMethod.ClientID%>").focus();
                return msg;
            }


            return true;
        }
    </script>

    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <hr />
                <asp:Label ID="Label10" runat="server" Text="STUDENT DETAILS" SkinID="lblMedium"
                    Width="200" Visible="True"></asp:Label>
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch1" runat="server" SkinID="lbl" Text="Batch* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlbatch1" runat="server" DataValueField="BatchID" DataTextField="Batch_No"
                                    SkinID="ddlRsz" DataSourceID="ObjBatch1" TabIndex="1" AutoPostBack="true" Width="155">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjBatch1" runat="server" SelectMethod="BatchComboD" TypeName="DLFrmCollectSponsor">
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblStudent" runat="server" SkinID="lbl" Text="Student Name* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLStudent" runat="server" DataValueField="STD_ID" DataTextField="StdName"
                                    SkinID="ddlRsz" Width="155px" DataSourceID="ObjStudent" TabIndex="2" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentDDL"
                                    TypeName="DLFrmCollectSponsor">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlbatch1" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudentCode" runat="server" SkinID="lbl" Text="Student Code* :&nbsp;"></asp:Label>
                                <asp:HiddenField ID="HidStudentId" runat="server" />
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStudentCode" runat="server" SkinID="txt" AutoPostBack="True"
                                    TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" CompletionInterval="2000"
                                    EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage1"
                                    OnClientPopulating="ShowImage1" ServiceMethod="getStudentCode" ServicePath="TextBoxExt.asmx"
                                    TargetControlID="txtStudentCode" CompletionListCssClass="completeListStyle22">
                                </ajaxToolkit:AutoCompleteExtender>
                                <style type="text/css">
                                    .completeListStyle22
                                    {
                                        height: 200px;
                                        width: 505px;
                                        overflow: auto;
                                        list-style-type: disc;
                                        padding-left: 17px;
                                        background-color: #FFF;
                                        border: 1px solid DarkGray;
                                        text-align: left;
                                        font-size: small;
                                        color: black;
                                        visibility: hidden;
                                    }
                                </style>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender" runat="server"
                                    SkinID="watermark" TargetControlID="txtStudentCode" WatermarkText=" Type First 3 Characters">
                                </ajaxToolkit:TextBoxWatermarkExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblAcademicYear" runat="server" SkinID="lblRsz" Text="Academic Calendar Year* :&nbsp;"
                                    Width="200"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAYear" runat="server" DataSourceID="ObjAcademicYear" TabIndex="4"
                                    DataTextField="AcademicYear" DataValueField="id" SkinID="ddl">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjAcademicYear" runat="server" SelectMethod="GetAcademicYrFD"
                                    TypeName="feeCollectionDL">
                                    <%--<SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlbatch1" PropertyName="SelectedValue" Name="Batch"
                                                        DbType="Int16" />
                                                </SelectParameters>--%>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStudentName" runat="server" SkinID="lbl" Text="Student Name :&nbsp;"
                                    Visible="false"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStudentName" runat="server" AutoCompleteType="Disabled" Enabled="False"
                                    SkinID="txt" Visible="false"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch :&nbsp;" Visible="false"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBatch" runat="server" SkinID="txt" Enabled="False" Visible="false"></asp:TextBox>
                                <asp:HiddenField ID="Hidbatchid" runat="server" />
                                <asp:HiddenField ID="HidCategory" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCategory" runat="server" SkinID="lblRsz" Text="Student Category :&nbsp;"
                                    Width="200"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCategory" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                <%--   <asp:HiddenField ID="Hidbatchid" runat="server" />
                                            <asp:HiddenField ID="HidCategory" runat="server" />--%>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" TabIndex="5" SkinID="btnRsz"
                                    Width="100" Text="GET DETAILS" OnClientClick="return Validate();" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:UpdateProgress ID="PageUpdateProgress" runat="server">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess1" runat="server" SkinID="lblBlackRsz" Text="Processing your request..Please wait..."
                                                Visible="True" Width="300"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRed1" runat="server" SkinID="lblRed" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblGreen1" runat="server" SkinID="lblGreen" Text=""></asp:Label>
                                </td>
                            </tr>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="800px" Height="400px"
                        Visible="false">
                        <table>
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="GVPayable" runat="server" SkinID="GridView" AllowPaging="true"
                                        AutoGenerateColumns="False" Visible="true" PageSize="100" AllowSorting="True"
                                        EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Fee Head" HeaderStyle-HorizontalAlign="left" SortExpression="Fee_HeadType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeeHeadType" runat="server" HeaderStyle-HorizontalAlign="left"
                                                        Text='<%# Bind("Fee_HeadType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount Payable" HeaderStyle-HorizontalAlign="Right"
                                                SortExpression="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td valign="top">
                                    <asp:GridView ID="GVPaid" runat="server" SkinID="GridView" AllowPaging="true" AutoGenerateColumns="False"
                                        Visible="true" PageSize="150" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Payment Date" SortExpression="Fee_Date" HeaderStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFeeDate" runat="server" Text='<%# Bind("Fee_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" Width="100" Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount Paid" HeaderStyle-HorizontalAlign="Right" SortExpression="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPaidAmount" runat="server" Width="100" Text='<%# Bind("Amount","{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTotalPayable" runat="server" SkinID="lblRsz" Text="Total Payable Amount :&nbsp;"
                                    Width="175"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtTotalPayable" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                <%--   <asp:HiddenField ID="Hidbatchid" runat="server" />
                                            <asp:HiddenField ID="HidCategory" runat="server" />--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblTotalPaid" runat="server" SkinID="lblRsz" Text="Total Paid Amount :&nbsp;"
                                    Width="150"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTotalPaid" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                <%--   <asp:HiddenField ID="Hidbatchid" runat="server" />
                                            <asp:HiddenField ID="HidCategory" runat="server" />--%>
                            </td>
                        </tr>
                        <tr align="center">
                            <td align="right">
                                <asp:Label ID="lblBalance" runat="server" SkinID="lbl" Text="Balance :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBalance" runat="server" SkinID="txt" Enabled="false"></asp:TextBox>
                                <%--   <asp:HiddenField ID="Hidbatchid" runat="server" />
                                            <asp:HiddenField ID="HidCategory" runat="server" />--%>
                            </td>
                        
                        </tr>
                    </table>
                    
                </center>
                <hr />
                <asp:Label ID="Label2" runat="server" Text="SPONSOR DETAILS" SkinID="lblMedium" Width="200"
                    Visible="True"></asp:Label>
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <%-- <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Text="SPONSOR DETAILS" SkinID="lblMedium" Width="200"
                                    Visible="True"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSponser" runat="server" SkinID="lbl" Text="Sponsor* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlsponsor" runat="server" DataSourceID="objsponsor" TabIndex="6"
                                    DataTextField="SponsorName" DataValueField="Sponsor_IDAuto" SkinID="ddl">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objsponsor" runat="server" SelectMethod="sponsorddl" TypeName="DLFrmCollectSponsor">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblamount" runat="server" SkinID="lbl" Text="Amount :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtamount" runat="server" SkinID="txtrsz" Width="155" TabIndex="7"> </asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="filteramount" runat="server" FilterType="Custom"
                                    FilterMode="ValidChars" TargetControlID="txtamount" ValidChars="0123456789.">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMode" runat="server" SkinID="lbl" Text="Mode* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" TabIndex="8" AutoPostBack="True"
                                    DataSourceID="ObjPaymentMethod" DataTextField="Payment_Method" DataValueField="PaymentMethodID"
                                    AppendDataBoundItems="true" SkinID="ddl">
                                    <asp:ListItem Selected="True" Text="Select" Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodComboD"
                                    TypeName="DLFrmCollectSponsor"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <td align="left">
                                    <asp:TextBox ID="txtchequeno" runat="server" SkinID="txtrsz" Width="155" TabIndex="9"></asp:TextBox>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                        SkinID="watermark" TargetControlID="txtchequeno" WatermarkText=" Cheque No">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                    <asp:TextBox ID="txtChequedate" runat="server" SkinID="txtrsz" Width="100" TabIndex="10"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                        Enabled="True" FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters"
                                        ValidChars="-/" TargetControlID="txtChequedate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                        Enabled="True" Format="dd-MMM-yyyy" TargetControlID="txtChequedate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                        SkinID="watermark" TargetControlID="txtChequedate" WatermarkText="Cheque Date">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbldate" runat="server" SkinID="lbl" Text="Date :&nbsp;" TabIndex="11"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtdate" runat="server" SkinID="txtrsz" Width="155"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    Enabled="True" FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters"
                                    ValidChars="-/" TargetControlID="txtdate">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                    Enabled="True" Format="dd-MMM-yyyy" TargetControlID="txtdate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblremarks" runat="server" SkinID="lbl" Text="Remarks :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtremarks" runat="server" SkinID="txtrsz" TextMode="MultiLine"
                                    Width="272" Height="50" TabIndex="12"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <center>
                    <table>
                        <tr>
                            <td class="btnTd" colspan="4">
                                <asp:Button ID="Btnadd" runat="server" Text="ADD" TabIndex="13" CommandName="ADD"
                                    CausesValidation="true" SkinID="btn" CssClass="ButtonClass" OnClientClick="return Validate1();">
                                </asp:Button>&nbsp;
                                <asp:Button ID="btnView1" runat="server" TabIndex="14" Text="VIEW" CommandName="VIEW"
                                    SkinID="btn" CssClass="ButtonClass " OnClientClick="return Validate();"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess12" runat="server" SkinID="lblBlackRsz" Text="Processing your request..Please wait..."
                                                Visible="True" Width="300"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblR1" runat="server" SkinID="lblRed" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblG1" runat="server" SkinID="lblGreen" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
                <hr />
                <asp:Label ID="Label3" runat="server" Text="REFUND DETAILS" SkinID="lblMedium" Width="200"
                    Visible="True"></asp:Label>
                <center>
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr align ="center" >
                            <td align="right">
                                <asp:Label ID="lblexcess" runat="server" SkinID="lblRsz" Width="200" Text="Excess/Shortage Amount :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtexcess" runat="server" SkinID="txtrsz" Width="155" TabIndex="15" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblamt" runat="server" SkinID="lbl" Text="Amount :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtamt" runat="server" SkinID="txtrsz" Width="155" TabIndex="16"> </asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterType="Custom" FilterMode="ValidChars" TargetControlID="txtamount" ValidChars="0123456789.">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblmod" runat="server" SkinID="lbl" Text="Mode* :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLModeRefund" runat="server" TabIndex="8" AutoPostBack="True"
                                    DataSourceID="ObjModeRefund" DataTextField="Payment_Method" DataValueField="PaymentMethodID"
                                    AppendDataBoundItems="true" SkinID="ddl">
                                    <asp:ListItem Selected="True" Text="Select" Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjModeRefund" runat="server" SelectMethod="PaymentMethodComboD"
                                    TypeName="DLFrmCollectSponsor"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <td align="left">
                                    <asp:TextBox ID="chqno" runat="server" SkinID="txtrsz" Width="155" TabIndex="18"></asp:TextBox>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                                        SkinID="watermark" TargetControlID="chqno" WatermarkText=" Cheque No">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="chqdate" runat="server" SkinID="txtrsz" Width="100"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        Enabled="True" FilterType="Custom, Numbers,UppercaseLetters, LowercaseLetters"
                                        ValidChars="-/" TargetControlID="chqdate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                                        Enabled="True" Format="dd-MMM-yyyy" TargetControlID="chqdate">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server"
                                        SkinID="watermark" TargetControlID="chqdate" WatermarkText=" Cheque Date">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="btnTd" colspan="4">
                                <asp:Button ID="btnRTOStu" SkinID="btnRsz" runat="server" TabIndex="19" Text="REFUND TO STUDENT"
                                    Width="150" OnClientClick="return Validate();" CssClass="ButtonClass " />&nbsp;
                                <asp:Button ID="btnTTFee" SkinID="btnRsz" runat="server" TabIndex="20" OnClientClick="return Validate();"
                                    Text="TRANSFER TO FEE" CssClass="ButtonClass " Width="150" />
                            </td>
                        </tr>
                </center>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblR2" runat="server" SkinID="lblRed" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblG2" runat="server" SkinID="lblGreen" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
                <hr />
                <center>
                    <table>
                        <asp:GridView ID="GVsponsor" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                            EmptyDataText="No records to display." AllowPaging="True" AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkbutton1" runat="server" CausesValidation="false" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" SortExpression="SDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldate" runat="server" Text='<%# Bind("SDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        <asp:Label ID="lblid" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblremarks" runat="server" Text='<%# Bind("Remarks") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sponsor" HeaderStyle-HorizontalAlign="Left" SortExpression="SponsorName">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SponsorName") %>'></asp:Label>
                                        <asp:Label ID="lblsponsor" runat="server" Visible="false" Text='<%# Bind("SponsorId") %>'></asp:Label>
                                        <asp:Label ID="lblMode" runat="server" Visible="false" Text='<%# Bind("Mode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="60"
                                    SortExpression="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<%# Bind("Amount","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="false" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cheque Date" SortExpression="ChqDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblchqdate" runat="server" Text='<%# Bind("ChqDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cheque No" HeaderStyle-HorizontalAlign="Left" SortExpression="ChqNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblchqno" runat="server" Text='<%# Bind("ChqNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Refund" HeaderStyle-HorizontalAlign="Left" SortExpression="Refund">
                                    <ItemTemplate>
                                        <asp:Label ID="lblrefund" runat="server" Text='<%# Bind("Refund") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TRANSFER TO FEE" HeaderStyle-HorizontalAlign="Left"
                                    SortExpression="TransferToFee">
                                    <ItemTemplate>
                                        <asp:Label ID="lblttf" runat="server" Text='<%# Bind("TransferToFee") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </table>
                </center>
            </a><a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
