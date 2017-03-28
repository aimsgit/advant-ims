<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FormFeeCollection.aspx.vb"
    Inherits="FormFeeCollection" Title="Fee Collection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Collection</title>
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


        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtStudentCode2.ClientID%>"));

        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtStudentCode2.ClientID%>"));
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
        function Valid() {
            var msg;



            msg = FeesField(document.getElementById("<%=txtAmountPaid.ClientID%>"), 'Amount Paid');
            if (msg != "") {
                document.getElementById("<%=txtAmountPaid.ClientID%>").focus();
                return msg;
            }

            msg = numeric(document.getElementById("<%=txtDd.ClientID%>"), 'CC/DC/DD/Chq No.');
            if (msg != "") {
                document.getElementById("<%=txtDd.ClientID%>").focus();
                return msg;
            }

            msg = FeesFieldN(document.getElementById("<%=txtDiscount.ClientID%>"), 'Discount');
            if (msg != "") {
                document.getElementById("<%=txtDiscount.ClientID%>").focus();
                return msg;
            }

            msg = DropDown(document.getElementById("<%=ddlPaymentMethod.ClientID%>"), 'Payment Method');
            if (msg != "") {
                document.getElementById("<%=ddlPaymentMethod.ClientID%>").focus();
                return msg;
            }

            msg = FeesFieldN(document.getElementById("<%=txtTotalFee.ClientID%>"), 'Total Fee');
            if (msg != "") {
                document.getElementById("<%=txtTotalFee.ClientID%>").focus();
                return msg;
            }

            msg = ValidateDate(document.getElementById("<%=txtPaymentDate.ClientID%>"), 'Payment Date');
            if (msg != "") {
                document.getElementById("<%=txtPaymentDate.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate1() {
            var msg = Valid1();
            var msg1 = Valid();
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
            if (msg1 != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg1;
                    document.getElementById("<%=lblS.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg1;
                    document.getElementById("<%=lblS.ClientID%>").textContent = "";
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

    <script language="JavaScript" type="text/javascript">



        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtStudentCode2.ClientID%>"));

        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtStudentCode2.ClientID%>"));
        }

        function Valid2() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlbatch2.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlbatch2.ClientID%>")
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlStdName2.ClientID%>"), 'Student Code/Student Name');
            if (msg != "") {
                document.getElementById("<%=ddlStdName2.ClientID%>")
                return msg;
            }



            msg = DropDownForZero(document.getElementById("<%=ddlFee_head.ClientID%>"), 'Fee Head');
            if (msg != "") {
                document.getElementById("<%=ddlFee_head.ClientID%>").focus();
                return msg;
            }
            msg = FeesField(document.getElementById("<%=txtAmountPaid2.ClientID%>"), 'Amount Paid');
            if (msg != "") {
                document.getElementById("<%=txtAmountPaid2.ClientID%>").focus();
                return msg;
            }

            msg = FeesFieldN(document.getElementById("<%=txtDiscount2.ClientID%>"), 'Discount');
            if (msg != "") {
                document.getElementById("<%=txtDiscount2.ClientID%>").focus();
                return msg;
            }


            msg = numeric(document.getElementById("<%=txtDd2.ClientID%>"), 'CC/DC/DD/Chq No.');
            if (msg != "") {
                document.getElementById("<%=txtDd2.ClientID%>").focus();
                return msg;
            }
            msg = DropDown(document.getElementById("<%=ddlPaymentMethod2.ClientID%>"), 'Payment Method');
            if (msg != "") {
                document.getElementById("<%=ddlPaymentMethod2.ClientID%>").focus();
                return msg;
            }


            msg = ValidateDate(document.getElementById("<%=txtPaymentDate2.ClientID%>"), 'Payment Date');
            if (msg != "") {
                document.getElementById("<%=txtPaymentDate2.ClientID%>").focus();
                return msg;
            }
            return true;
        }
        function Validate2() {

            var msg1 = Valid2();
            if (msg1 != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg1;
                    document.getElementById("<%=lblGreen.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg1;
                    document.getElementById("<%=lblGreen.ClientID%>").textContent = "";

                    return false;
                }
            }
            return true;
        }
         
    </script>

    <script language="JavaScript" type="text/javascript">



        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtStudentCode2.ClientID%>"));

        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtStudentCode2.ClientID%>"));
        }

        function Valid3() {
            var msg;

            msg = DropDownForZero(document.getElementById("<%=ddlbatch2.ClientID%>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=ddlbatch2.ClientID%>")
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlStdName2.ClientID%>"), 'Student Code/Student Name');
            if (msg != "") {
                document.getElementById("<%=ddlStdName2.ClientID%>")
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlStdName2.ClientID%>"), 'Student Code/Student Name');
            if (msg != "") {
                document.getElementById("<%=ddlStdName2.ClientID%>")
                return msg;
            }

            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtStudentCode2.ClientID%>"), 'Student Code/Student Name');
            if (msg != "") {
                document.getElementById("<%=txtStudentCode2.ClientID%>")
                return msg;
            }



            return true;
        }
        function Validate3() {

            var msg1 = Valid3();
            if (msg1 != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg1;
                    document.getElementById("<%=lblGreen.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg1;
                    document.getElementById("<%=lblGreen.ClientID%>").textContent = "";

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
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp"
                    BackColor="#E2E3BB">
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Fee Collection">
                        <ContentTemplate>
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
                                            <asp:Label ID="lblBatch1" runat="server" SkinID="lbl" Text="Batch* :&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlbatch1" runat="server" DataValueField="BatchID" DataTextField="Batch_No"
                                                SkinID="ddlRsz" DataSourceID="ObjBatch1" AutoPostBack="True" Width="200px">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjBatch1" runat="server" SelectMethod="BatchComboD" TypeName="feeCollectionDL">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblStudent" runat="server" SkinID="lbl" Text="Student Name* :&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DDLStudent" runat="server" DataValueField="STD_ID" DataTextField="StdName"
                                                SkinID="ddlRsz" Width="200px" DataSourceID="ObjStudent" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentDDL"
                                                TypeName="feeCollectionDL">
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
                                            <asp:TextBox ID="txtStudentCode" runat="server" SkinID="txt" AutoPostBack="True"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="2000" FirstRowSelected="True" OnClientPopulated="HideImage1"
                                                OnClientPopulating="ShowImage1" ServiceMethod="getStudentCode" ServicePath="TextBoxExt.asmx"
                                                TargetControlID="txtStudentCode" CompletionListCssClass="completeListStyle22" BehaviorID="_content_AutoCompleteExtender1" DelimiterCharacters="">
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
                                                SkinID="watermark" TargetControlID="txtStudentCode" WatermarkText=" Type First 3 Characters" BehaviorID="_content_TextBoxWatermarkExtender">
                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblAcademicYear" runat="server" SkinID="lblRsz" Text="Academic Calendar Year* :&nbsp;"
                                                Width="200px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlAYear" runat="server" DataSourceID="ObjAcademicYear" DataTextField="AcademicYear"
                                                DataValueField="id" SkinID="ddl" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjAcademicYear" runat="server" SelectMethod="GetAcademicYr"
                                                TypeName="feeCollectionDL" OldValuesParameterFormatString="original_{0}">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblStudentName" runat="server" SkinID="lbl" Text="Student Name :&nbsp;"
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtStudentName" runat="server" AutoCompleteType="Disabled" Enabled="False"
                                                SkinID="txt" Visible="False"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch :&nbsp;" Visible="False"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBatch" runat="server" SkinID="txt" Enabled="False" Visible="False"></asp:TextBox>
                                            <asp:HiddenField ID="Hidbatchid" runat="server" />
                                            <asp:HiddenField ID="HidCategory" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" Text="VIEW"
                                                OnClientClick="return Validate();" />
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:UpdateProgress ID="PageUpdateProgress" runat="server">
                                                <ProgressTemplate>
                                                    <div class="PleaseWait">
                                                        <asp:Label ID="lblprocess1" runat="server" SkinID="lblBlackRsz" Text="Processing your request..Please wait..." Visible="True" Width="300"></asp:Label>
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRed1" runat="server" SkinID="lblRed"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGreen1" runat="server" SkinID="lblGreen"></asp:Label>
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                            </center>
                            <hr />
                            <center>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                                    EmptyDataText="No records to display." AllowPaging="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("Std_CategoryName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fee Head">
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("Fee_HeadType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("Amount", "{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Due Date">
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("Due_Date", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblTotalFee" runat="server" SkinID="lbl" Text="Total Fee :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalFee" runat="server" Enabled="False" SkinID="txt"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblFeecollected" runat="server" SkinID="lbl" Text="Fee Collected :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFeeCollected" runat="server" Enabled="False" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbltotalDiscount" runat="server" SkinID="lbl" Text="Total Discount :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalDiscount" runat="server" Enabled="False" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtTotalDiscount"
                                                ValidChars="1234567890." BehaviorID="_content_FilteredTextBoxExtender4">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTotalFine" runat="server" SkinID="lbl" Text="Total Fine :&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTotalFine" runat="server" Enabled="False" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtTotalFine" ValidChars="1234567890." BehaviorID="_content_FilteredTextBoxExtender5">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Label ID="lblBalancefee" runat="server" SkinID="lbl" Text="Balance Fee :&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:TextBox ID="txtBalanceFee" runat="server" Enabled="False" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblAmountPaid" runat="server" SkinID="lblRsz" Text="New Amount Paid* :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAmountPaid" runat="server" SkinID="txt" AutoPostBack="True"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="filterAmountPaid" runat="server"
                                                TargetControlID="txtAmountPaid" ValidChars="1234567890." BehaviorID="_content_filterAmountPaid">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblBank" runat="server" SkinID="lbl" Text="Bank :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBank" runat="server" DataSourceID="ObjBank" DataTextField="Bank_Name"
                                                DataValueField="Bank_ID" AppendDataBoundItems="True" SkinID="ddl">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="*">Others</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjBank" runat="server" SelectMethod="BankCombo" TypeName="FeeCollectionBL">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblDiscount" runat="server" SkinID="lblRsz" Text="Discount Allowed :&nbsp;"
                                                Width="200px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDiscount" runat="server" SkinID="txt" AutoPostBack="True"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredDiscount" runat="server"
                                                TargetControlID="txtDiscount" ValidChars="1234567890." BehaviorID="_content_FilteredDiscount">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblPaymentMethod" runat="server" SkinID="lblRsz" Width="150px" Text="Payment Method* :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPaymentMethod" runat="server" DataSourceID="ObjPaymentMethod"
                                                DataTextField="Payment_Method" DataValueField="PaymentMethodID" AutoPostBack="True"
                                                AppendDataBoundItems="True" SkinID="ddl">
                                                <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjPaymentMethod" runat="server" SelectMethod="PaymentMethodCombo"
                                                TypeName="FeeCollectionBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label20" runat="server" SkinID="lblRsz" Text="Fine :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFine" runat="server" SkinID="txt" AutoPostBack="True"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtFine" ValidChars="1234567890." BehaviorID="_content_FilteredTextBoxExtender3">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblDd" runat="server" SkinID="lblRsz" Width="160px" Text="CC/DC/DD/Chq No. :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDd" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblBalance" runat="server" SkinID="lbl" Text="New Balance :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBalance" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                                AutoPostBack="True" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblChequeDate" runat="server" SkinID="lbl" Text="Cheque Date :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtChequeDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtChequeDate_CalendarExtender" runat="server"
                                                Animated="False" Format="dd-MMM-yyyy" TargetControlID="txtChequeDate" BehaviorID="_content_txtChequeDate_CalendarExtender">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Remarks" runat="server" SkinID="lbl" Text="Remarks :&nbsp;"></asp:Label>
                                        </td>
                                        <td rowspan="2">
                                            <asp:TextBox ID="txtRemarks" runat="server" AutoCompleteType="Disabled" AutoPostBack="True"
                                                SkinID="txt" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="PaymentDate" runat="server" SkinID="lbl" Text="Payment Date* :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaymentDate" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtPaymentDate" BehaviorID="_content_CalendarExtender2">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                            </center>
                            </a>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnADD" runat="server" CssClass="ButtonClass" SkinID="btn" OnClientClick="return Validate();"
                                                Text="ADD" />&nbsp;<asp:Button ID="btnView1" runat="server" CssClass="ButtonClass"
                                                    SkinID="btn" Text="VIEW" />
                                            &nbsp;<asp:Button ID="btnPost" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                TabIndex="8" Text="POST" />
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnReceipt" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                                Width="150px" Text="DETAILS FEE RECEIPT" />&nbsp;<asp:Button ID="btnFeeSumrecpt"
                                                    runat="server" CssClass="ButtonClass" SkinID="btnRsz" Width="150px" Text="SUMMARY FEE RECEIPT" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <center>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblS" runat="server" SkinID="lblGreen"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <center>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                                        AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Button21" runat="server" CausesValidation="true" CommandName="Edit"
                                                        Text="Edit" />&nbsp;
                                                    <asp:LinkButton ID="Button22" runat="server" CausesValidation="true" CommandName="Delete"
                                                        Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Print/Post">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBx" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Post">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGVPost" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Fee">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HidId" runat="server" Value='<%# Bind("Fee_Details_ID") %>' />
                                                    <asp:Label ID="Label132" runat="server" Text='<%# Bind("TotalFee", "{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fine/Discount">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label133" runat="server" Text='<%# Bind("Discount", "{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount Paid">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label134" runat="server" Text='<%# Bind("Amount", "{0:n2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bank" SortExpression="Bank_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label135" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:Label>
                                                    <asp:HiddenField ID="HidB" runat="server" Value='<%# Bind("Bank_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Payment Method" SortExpression="Payment_Method">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label136" runat="server" Text='<%# Bind("Payment_Method") %>'></asp:Label>
                                                    <asp:HiddenField ID="HidP" runat="server" Value='<%# Bind("Payment_Method_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CC/DC/DD/Cheque No." SortExpression="ChequeNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label137" runat="server" Text='<%# Bind("ChequeNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Payment Date" SortExpression="Fee_Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label138" runat="server" Text='<%# Bind("Fee_Date", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    <asp:Label ID="lblChequeDate" runat="server" Visible="false" Text='<%# Bind("Cheque_Date", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Width="150px" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Miscellaneous Fee Collection">
                        <ContentTemplate>
                            <center>
                                <h1 class="headingTxt">
                                    MISCELLANEOUS  FEE COLLECTION 
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
                                            <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Batch* :&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlBatch2" runat="server" DataValueField="BatchID" DataTextField="Batch_No"
                                                SkinID="ddlRsz" DataSourceID="ObjBatch2" AutoPostBack="true" Width="200">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjBatch2" runat="server" SelectMethod="BatchComboD" TypeName="feeCollectionDL">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Student Name* :&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlStdName2" runat="server" DataValueField="STD_ID" DataTextField="StdName"
                                                SkinID="ddlRsz" Width="200px" DataSourceID="ObjStudent2" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjStudent2" runat="server" SelectMethod="GetStudentDDL"
                                                TypeName="feeCollectionDL">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlbatch2" PropertyName="SelectedValue" Name="Batch"
                                                        DbType="Int16" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label3" runat="server" SkinID="lbl" Text="Student Code* :&nbsp;"></asp:Label>
                                            <asp:HiddenField ID="HidStudentId2" runat="server" />
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtStudentCode2" runat="server" SkinID="txt" AutoPostBack="True"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" CompletionInterval="2000"
                                                EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage1"
                                                OnClientPopulating="ShowImage2" ServiceMethod="getStudentCode" ServicePath="TextBoxExt.asmx"
                                                TargetControlID="txtStudentCode2" CompletionListCssClass="completeListStyle22">
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
                                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                SkinID="watermark" TargetControlID="txtStudentCode2" WatermarkText=" Type First 3 Characters">
                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Text="Academic Year* :&nbsp;"
                                                Width="180"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlAYear2" runat="server" DataSourceID="ObjAcademicYear2" DataTextField="AcademicYear"
                                                DataValueField="id" SkinID="ddl">
                                                <%--<asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjAcademicYear2" runat="server" SelectMethod="GetAcademicYr"
                                                TypeName="feeCollectionDL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label5" runat="server" SkinID="lbl" Text="Student Name :&nbsp;" Visible="false"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtStudentName2" runat="server" AutoCompleteType="Disabled" Enabled="False"
                                                SkinID="txt" Visible="false"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Batch :&nbsp;" Visible="false"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBatch2" runat="server" SkinID="txt" Enabled="False" Visible="false"></asp:TextBox>
                                            <asp:HiddenField ID="Hidbatchid2" runat="server" />
                                            <asp:HiddenField ID="HidCategory2" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblfeehead" runat="server" Text="Fee Head* :&nbsp;" SkinID="lblRsz"
                                                Width="200px"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlfee_head" runat="server" SkinID="ddl" DataSourceID="odsfeehead"
                                                DataTextField="Fee_HeadType" DataValueField="Fee_Head_IDAuto" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsfeehead" runat="server" SelectMethod="GetFeeHeads" TypeName="feeStructureDL">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="New Amount Paid* :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAmountPaid2" runat="server" SkinID="txt" AutoPostBack="true"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                FilterType="Custom" TargetControlID="txtAmountPaid2" FilterMode="ValidChars"
                                                ValidChars="1234567890.">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="Bank :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBank2" runat="server" DataSourceID="ObjBank2" DataTextField="Bank_Name"
                                                DataValueField="Bank_ID" AppendDataBoundItems="true" SkinID="ddl">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="*">Others</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjBank2" runat="server" SelectMethod="BankCombo" TypeName="FeeCollectionBL">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label9" runat="server" SkinID="lblRsz" Text="Discount Allowed :&nbsp;"
                                                Width="200px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDiscount2" runat="server" SkinID="txt" AutoPostBack="true"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                FilterType="Custom" TargetControlID="txtDiscount2" FilterMode="ValidChars" ValidChars="1234567890.">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label10" runat="server" SkinID="lblRsz" Width="150" Text="Payment Method* :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPaymentMethod2" runat="server" DataSourceID="ObjPaymentMethod2"
                                                DataTextField="Payment_Method" DataValueField="PaymentMethodID" AutoPostBack="true"
                                                AppendDataBoundItems="true" SkinID="ddl">
                                                <asp:ListItem Selected="True" Value="Select">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjPaymentMethod2" runat="server" SelectMethod="PaymentMethodCombo"
                                                TypeName="FeeCollectionBL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label21" runat="server" SkinID="lblRsz" Text="Fine :&nbsp;" Width="200px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFine2" runat="server" SkinID="txt" AutoPostBack="true"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                FilterType="Custom" TargetControlID="txtDiscount2" FilterMode="ValidChars" ValidChars="1234567890.">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label16" runat="server" SkinID="lblRsz" Width="160px" Text="CC/DC/DD/Chq No. :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDd2" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" SkinID="lblRsz" Text="Net Amount Paid :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBalance2" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                                AutoPostBack="true" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label18" runat="server" SkinID="lbl" Text="Cheque Date :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtChequeDate2" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtChequeDate2">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label17" runat="server" SkinID="lbl" Text="Remarks :&nbsp;"></asp:Label>
                                        </td>
                                        <td rowspan="2">
                                            <asp:TextBox ID="txtRemarks2" runat="server" AutoCompleteType="Disabled" AutoPostBack="true"
                                                SkinID="txt" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label19" runat="server" SkinID="lbl" Text="Payment Date* :&nbsp;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaymentDate2" runat="server" AutoCompleteType="Disabled" SkinID="txt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                                                Format="dd-MMM-yyyy" TargetControlID="txtPaymentDate2">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                            </center>
                            </a>
                            <center>
                                <center>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnAdd2" runat="server" CssClass="ButtonClass" SkinID="btn" OnClientClick="return Validate2();"
                                                    Text="ADD" />&nbsp;
                                                <asp:Button ID="btnView2" runat="server" CssClass="ButtonClass" SkinID="btn" OnClientClick="return Validate3();"
                                                    Text="VIEW" />&nbsp;
                                                <asp:Button ID="btnReceipt2" runat="server" CssClass="ButtonClass" SkinID="btn" Text="RECEIPT" />
                                                &nbsp;<asp:Button ID="btnPost2" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                    TabIndex="8" Text="POST" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td colspan="2" align="right">
                                                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                                    <ProgressTemplate>
                                                        <div class="PleaseWait">
                                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                        </div>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRed" runat="server" Text="" SkinID="lblRed"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGreen" runat="server" Text="" SkinID="lblGreen"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <center>
                                    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                        <asp:GridView ID="GridFeecollection" runat="server" AutoGenerateColumns="False" SkinID="GridView"
                                            AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Button21" runat="server" CausesValidation="true" CommandName="Edit"
                                                            Text="Edit" />&nbsp;
                                                        <asp:LinkButton ID="Button22" runat="server" CausesValidation="true" CommandName="Delete"
                                                            Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Print/Post">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBx" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Post">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVPost" runat="server" Text='<%# Bind("Post") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fee Head">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="HidGVId" runat="server" Value='<%# Bind("Fee_Details_ID") %>' />
                                                        <asp:Label ID="lblGVFeehead" runat="server" Text='<%# Bind("Fee_HeadType") %>'></asp:Label>
                                                        <asp:Label ID="lblGVFeeheadId" Visible="false" runat="server" Text='<%# Bind("Fee_Structure_ID") %>'></asp:Label>
                                                        <asp:Label ID="lblGVTotalFee" Visible="false" runat="server" Text='<%# Bind("TotalFee","{0:0.00}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fine/Discount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVDiscount" runat="server" Text='<%# Bind("Discount","{0:n2}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount Paid">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVAmountPaid" runat="server" Text='<%# Bind("Amount","{0:n2}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bank">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVBankName" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:Label>
                                                        <asp:HiddenField ID="lblGVBankId" runat="server" Value='<%# Bind("Bank_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Payment Method">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVPaymentMethod" runat="server" Text='<%# Bind("Payment_Method") %>'></asp:Label>
                                                        <asp:HiddenField ID="lblGVPaymentMethodId" runat="server" Value='<%# Bind("Payment_Method_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CC/DC/DD/Cheque No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVChequeNo" runat="server" Text='<%# Bind("ChequeNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Payment Date" SortExpression="Fee_Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVFee_Date" runat="server" Text='<%# Bind("Fee_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        <asp:Label ID="lblGVChequeDate" runat="server" Visible="false" Text='<%# Bind("Cheque_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGVRemarks" runat="server" Width="150px" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </center>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
                <a name="bottom">
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
