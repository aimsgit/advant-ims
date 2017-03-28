<%@ Page Language="VB" AutoEventWireup="false" Inherits="FrmAssetDetails"
    CodeFile="FrmAssetDetails.aspx.vb" Title="Asset Details" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
 
   <script language="JavaScript" type="text/javascript">
        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtreceivedby.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtreceivedby.ClientID%>"));
        }
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlassetType.ClientID %>"), 'Asset Type');
            if (msg != "") { document.getElementById("<%=ddlassetType.ClientID %>").focus(); return msg; }

            msg = NameField100(document.getElementById("<%=txtassetname.ClientID %>"), 'Asset Name');
            if (msg != "") { document.getElementById("<%=txtassetname.ClientID %>").focus(); return msg; }

            msg = CodeField(document.getElementById("<%=txtassetcode.ClientID %>"), 'Asset Code');
            if (msg != "") { document.getElementById("<%=txtassetcode.ClientID %>").focus(); return msg; }

            msg = CodeField(document.getElementById("<%=txtpurDate.ClientID %>"), 'Purchase Date');
            if (msg != "") { document.getElementById("<%=txtpurDate.ClientID %>").focus(); return msg; }

            msg = CodeField(document.getElementById("<%=txtbookvalue.ClientID %>"), 'Book value price');
            if (msg != "") { document.getElementById("<%=txtbookvalue.ClientID %>").focus(); return msg; }

            msg = Field50N(document.getElementById("<%=txtMachineSerialNo.ClientID %>"), 'Machine Serial No');
            if (msg != "") { document.getElementById("<%=txtMachineSerialNo.ClientID %>").focus(); return msg; }

            msg = numeric(document.getElementById("<%=txtqty.ClientID %>"), 'Quantity');
            if (msg != "") { document.getElementById("<%=txtqty.ClientID %>").focus(); return msg; }

            msg = ValidateDateN(document.getElementById("<%=txtpurDate.ClientID %>"), 'Purchase Date');
            if (msg != "") { document.getElementById("<%=txtpurDate.ClientID %>").focus(); return msg; }

            msg = ValidateDateN(document.getElementById("<%=TxtDueDate.ClientID %>"), 'Due Date');
            if (msg != "") { document.getElementById("<%=TxtDueDate.ClientID %>").focus(); return msg; }

            msg = ValidateDateN(document.getElementById("<%=txtStartDate.ClientID %>"), 'AMC Start Date');
            if (msg != "") { document.getElementById("<%=txtStartDate.ClientID %>").focus(); return msg; }

            msg = ValidateDateN(document.getElementById("<%=txtEndDate.ClientID %>"), 'AMC End Date');
            if (msg != "") { document.getElementById("<%=txtEndDate.ClientID %>").focus(); return msg; }

            msg = numeric(document.getElementById("<%=txtAMCAmount.ClientID %>"), 'AMC Amount');
            if (msg != "") { document.getElementById("<%=txtAMCAmount.ClientID %>").focus(); return msg; }

            msg = ValidateDateN(document.getElementById("<%=txtPaid.ClientID %>"), 'Premium Paid Date');
            if (msg != "") { document.getElementById("<%=txtPaid.ClientID %>").focus(); return msg; }
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
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }
        //        function SplitName() {
        //            var text = document.getElementById("<%=txtreceivedby.ClientID%>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=HidsEId.ClientID%>").innerText = split[0];
        //                document.getElementById("<%=HidECode.ClientID%>").innerText = split[1];
        //                document.getElementById("<%=txtreceivedby.ClientID%>").innerText = split[2];
        //            }
        //        } 


        function Valid1() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlDepreciationrate1.ClientID %>"), 'Asset Depreciation Type');
            if (msg != "") {
                document.getElementById("<%=ddlDepreciationrate1.ClientID %>").focus();
                return msg;
            }

            msg = DropDownForZero(document.getElementById("<%=ddlDereciationRate.ClientID %>"), 'Depreciation Rate');
            if (msg != "") {
                document.getElementById("<%=ddlDereciationRate.ClientID %>").focus();
                return msg;
            }
            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";

                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="Upload" />
                <asp:AsyncPostBackTrigger ControlID="Btnadd" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <a name="Top">
                    <div align="right">
                        <a href="#Bottom">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    </div>
                    <center>
                        <h1 class="headingTxt">
                            ASSET DETAILS</h1>
                    </center>
                    <br />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" SkinID="lblRsz" Text="Asset Type*^ :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlassetType" runat="server" DataSourceID="cmbAssetType" DataValueField="AssetType_IDAuto"
                                        AppendDataBoundItems="true" DataTextField="AssetType_Name" SkinID="ddl" TabIndex="1"
                                        AutoPostBack="true">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" rowspan="4">
                                    <asp:Label ID="lblPhoto" runat="server" Text="Photo :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                    <br />
                                    <asp:Button ID="Upload" runat="server" CssClass="ButtonClass" SkinID="btn" Text="UPLOAD"/>
                                </td>
                                <td align="left" rowspan="4">
                                    <asp:Image ID="ImageMap1" runat="server" ImageUrl="~/Images/imageupload.gif" Style="width: 100px;
                                        height: 100px;" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" SkinID="lbl" Text="Asset Code* :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtassetcode" runat="server" SkinID="txt" AutoCompleteType="disabled"
                                        TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:HiddenField ID="HidECode" runat="server" />
                                    <asp:HiddenField ID="HidsEId" runat="server" />
                                    <asp:Label ID="Label2" runat="server" SkinID="lbl" Text="Asset Name*^ :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtassetname" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                        TabIndex="3"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10"
                                            runat="server" FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'"
                                            TargetControlID="txtassetname">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label20" runat="server" Text="Description :&nbsp;&nbsp" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtdescription" runat="server" AutoCompleteType="Disabled" SkinID="txt"
                                        TextMode="MultiLine" TabIndex="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblassetsat" runat="server" Text="Asset Status :&nbsp;&nbsp" SkinID="lblRSz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlassetstat" runat="server" SkinID="ddl" DataTextField="Data"
                                        DataValueField="LookUpAutoID" TabIndex="5" DataSourceID="ObjectDataSource2">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="AssetDetailsDB"
                                        SelectMethod="GetAssetStaus"></asp:ObjectDataSource>
                                </td>
                                <%--</tr>
                            <tr>--%>
                                <td>
                                    <asp:TextBox ID="txtpath" runat="server" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="White" SkinID="btn"
                                        TabIndex="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label10" runat="server" SkinID="lbl" Text="Location :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLDeptType" runat="server" DataSourceID="objDept" SkinID="ddlRsz"
                                        DataValueField="DeptID" DataTextField="DeptName" TabIndex="7" Width="250">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objDept" runat="server" TypeName="AssetDetailsDB" SelectMethod="Getdeptcombo">
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblgrnno" runat="server" SkinID="lbl" Text="GRN No :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtgrnno" runat="server" SkinID="txt" AutoCompleteType="disabled"
                                        TabIndex="8"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label40" runat="server" SkinID="lbl" Text="MRN No :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtmrnno" runat="server" SkinID="txt" AutoCompleteType="disabled"
                                        TabIndex="9"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label33" runat="server" Text="Model No :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtModelNo" runat="server" SkinID="txt" TabIndex="10" AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                            </tr>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" SkinID="lblRsz" Text="Machine/Motor/IME No. :&nbsp;&nbsp"
                                    Width="200"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMachineSerialNo" runat="server" SkinID="txt" TabIndex="11" AutoCompleteType="Disabled"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblpo" runat="server" SkinID="lblRsz" Text="Purchase Order No :&nbsp;&nbsp"
                                    Width="200"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtpo" runat="server" SkinID="txt" TabIndex="12" AutoCompleteType="Disabled"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label14" runat="server" SkinID="lblRsz" Text="Purchase Date*^ :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtpurDate" runat="server" MaxLength="11" AutoCompleteType="Disabled"
                                        SkinID="txt" TabIndex="13"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                            runat="server" FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'"
                                            TargetControlID="txtpurDate">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="False"
                                        Format="dd-MMM-yyyy" TargetControlID="txtpurDate">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" SkinID="lblRsz" Text="Invoice No :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtInvNo" runat="server" SkinID="txt" TabIndex="14" AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblinvoicedate" runat="server" Text="Invoice Date :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtinvoicedate" runat="server" SkinID="txt" TabIndex="15" MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtinvoicedate">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtinvoicedate"
                                        Format="dd-MMM-yyyy" SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Text="Invoice Value :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtinvoiceNo" runat="server" SkinID="txt" TabIndex="16"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label21" runat="server" SkinID="lblRsz" Text="Quantity :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtqty" runat="server" Enabled="false" SkinID="txt" TabIndex="17"
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" SkinID="lblRsz" Text="Book Value Price* :&nbsp;&nbsp"
                                        Width="150px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtbookvalue" runat="server" SkinID="txt" TabIndex="18" AutoCompleteType="Disabled"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterMode="ValidChars" ValidChars="0123456789." TargetControlID="txtbookvalue">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" Text="Amount Paid :&nbsp;&nbsp" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtamtpaid" runat="server" SkinID="txt" AutoCompleteType="Disabled"
                                        TabIndex="19"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                        FilterMode="ValidChars" ValidChars="0123456789." TargetControlID="txtamtpaid">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" Text="Bill Type :&nbsp;&nbsp" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlbilltype" runat="server" SkinID="ddl" TabIndex="20">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Cash</asp:ListItem>
                                        <asp:ListItem Value="2">Credit</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" Text="Payment Method :&nbsp;&nbsp" SkinID="lblRSz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlpaymentmethod" runat="server" SkinID="ddl" DataTextField="Payment_Method"
                                        DataValueField="PaymentMethodID" TabIndex="21" DataSourceID="cmbpaymentmethod">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" SkinID="lblRsz" Text="Brought By :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtbroughtby" runat="server" SkinID="txt" TabIndex="22" AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" SkinID="lblRsz" Text="Received By^ :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtreceivedby" runat="server" SkinID="txt" TabIndex="23"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender
                                        ID="FilteredTextBoxExtender1" runat="server" FilterMode="InvalidChars" FilterType="Numbers"
                                        InvalidChars="'" TargetControlID="txtreceivedby">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" TargetControlID="txtreceivedby"
                                        ServicePath="TextBoxExt.asmx" ServiceMethod="GetBranchName" OnClientPopulating="ShowImage1"
                                        OnClientPopulated="HideImage1" MinimumPrefixLength="3" CompletionInterval="2000"
                                        CompletionListCssClass="completeListStyle" FirstRowSelected="true" EnableCaching="true">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                        WatermarkText="Type first three characters" TargetControlID="txtreceivedby" SkinID="watermark">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label22" runat="server" SkinID="lblRsz" Text="SentBy :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtsentby" runat="server" SkinID="txt" TabIndex="24"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label37" runat="server" SkinID="lblRsz" Text="Asset Depreciation Type :&nbsp;&nbsp"
                                        Width="200"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDepreciationrate1" TabIndex="25" runat="server" SkinID="ddl"
                                        AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="CommodityName"
                                        DataValueField="DepreciationID" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAssetDepreciationTypescombo"
                                        TypeName="AssetDetailsDB"></asp:ObjectDataSource>
                                    <%--<asp:DropDownList ID="ddlDepreciationrate" runat="server" SkinID="ddl" AutoPostBack="true"  
                                        TabIndex="13">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Govt Depreciation Rate</asp:ListItem>
                                        <asp:ListItem Value="2">Comp Depreciation Rate</asp:ListItem>
                                    </asp:DropDownList>--%>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label28" runat="server" SkinID="lblRsz" Text="Depreciation Rate :&nbsp;&nbsp"
                                        Width="150"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDereciationRate" runat="server" SkinID="ddl" AutoPostBack="true"
                                        TabIndex="26">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Govt Depreciation Rate</asp:ListItem>
                                        <asp:ListItem Value="2">Comp Depreciation Rate</asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:TextBox ID="txtDereciationRate" runat="server" SkinID="txt" AutoCompleteType="disabled"
                                        TabIndex="15"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label7" runat="server" SkinID="lblRsz" Text="Supplier :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlsupplier" runat="server" DataSourceID="cmbsupplier" DataValueField="Supp_Id_Auto"
                                        DataTextField="Supp_Name" AppendDataBoundItems="True" SkinID="ddl" TabIndex="27">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Other Details</b>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" SkinID="lbl" Text="Manufacturer :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlmanufacturer" runat="server" DataSourceID="cmbmanufacturer"
                                        DataValueField="ManuFacturerCode" DataTextField="ManuFacturer" AppendDataBoundItems="True"
                                        SkinID="ddl" TabIndex="28">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblVNo" runat="server" Text="Registration Number :&nbsp;&nbsp;" SkinID="lblRSz"
                                        Width="250px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVRegNum" runat="server" SkinID="txt" TabIndex="29" MaxLength="50"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                        FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtVRegNum">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="iblYearRegis" runat="server" Text="Date of Reg :&nbsp;&nbsp;" SkinID="lblRSz"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtYearRegis" runat="server" SkinID="txt" TabIndex="30" MaxLength="11"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtYearRegis"
                                        Format="dd-MMM-yyyy" SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" SkinID="lbl" Text="AMC To :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAMCTo" runat="server" SkinID="txt" AutoCompleteType="disabled"
                                        TabIndex="31"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label34" runat="server" SkinID="lblRsz" Text="AMC Start Date :&nbsp;&nbsp"
                                        Width="150"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtStartDate" runat="server" MaxLength="11" SkinID="txt" TabIndex="32"></asp:TextBox><ajaxToolkit:CalendarExtender
                                        ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" Format="dd-MMM-yyyy"
                                        SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label35" runat="server" SkinID="lbl" Text="AMC End Date :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEndDate" runat="server" MaxLength="11" SkinID="txt" TabIndex="33"></asp:TextBox><ajaxToolkit:CalendarExtender
                                        ID="CalendarExtender4" runat="server" TargetControlID="txtEndDate" Format="dd-MMM-yyyy"
                                        SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" Text="AMC Amount :&nbsp;&nbsp" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAMCAmount" runat="server" SkinID="txt" TabIndex="34" AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label29" runat="server" SkinID="lblRsz" Text="Warranty :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlWarranty" runat="server" SkinID="ddl" TabIndex="35" AutoPostBack="true">
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label30" runat="server" SkinID="lblRsz" Text="Guarantee :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlguaranty" runat="server" SkinID="ddl" TabIndex="36" AutoPostBack="true">
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label31" runat="server" SkinID="lblRsz" Text="Warranty Period :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtWP" runat="server" SkinID="txt" AutoCompleteType="disabled" TabIndex="37"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                        FilterMode="ValidChars" ValidChars="0123456789" TargetControlID="txtWP">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label32" runat="server" SkinID="lblRsz" Text="Guarantee Period :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtGp" runat="server" SkinID="txt" AutoCompleteType="disabled" TabIndex="38"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                        FilterMode="ValidChars" ValidChars="0123456789" TargetControlID="txtGp">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label23" runat="server" SkinID="lbl" Text="Insured To :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtInsuredTo" runat="server" SkinID="txt" TabIndex="39"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label24" runat="server" SkinID="lbl" Text="Insured Amt :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtInsuredAmt" runat="server" SkinID="txt" TabIndex="40" AutoCompleteType="Disabled"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender
                                        ID="FilteredTextBoxExtender5" runat="server" FilterMode="ValidChars" ValidChars="0123456789."
                                        TargetControlID="txtInsuredAmt">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label25" runat="server" SkinID="lbl" Text="Premium Amt :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtPremiumAmt" runat="server" SkinID="txt" TabIndex="41">
                                    </asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                        runat="server" FilterMode="ValidChars" ValidChars="0123456789." TargetControlID="TxtPremiumAmt">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label26" runat="server" SkinID="lbl" Text="Due Date :&nbsp;&nbsp"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtDueDate" runat="server" MaxLength="11" SkinID="txt" TabIndex="42"></asp:TextBox><ajaxToolkit:CalendarExtender
                                        ID="CalendarExtender2" runat="server" TargetControlID="TxtDueDate" Format="dd-MMM-yyyy"
                                        SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label27" runat="server" SkinID="lblRsz" Text="Insurance amount paid :&nbsp;&nbsp"
                                        Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtPaidAmt" runat="server" SkinID="txt" TabIndex="43">
                                    </asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7"
                                        runat="server" FilterMode="ValidChars" ValidChars="0123456789,." TargetControlID="TxtPaidAmt">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label36" runat="server" SkinID="lblRsz" Text="Premium Paid Date :&nbsp;&nbsp"
                                        Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaid" runat="server" MaxLength="11" SkinID="txt" TabIndex="44"></asp:TextBox><ajaxToolkit:CalendarExtender
                                        ID="CalendarExtender5" runat="server" TargetControlID="txtPaid" Format="dd-MMM-yyyy"
                                        SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblYear" runat="server" SkinID="lblRsz" Width="50px" Text="Year* :&nbsp; "
                                        Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                        DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="1" Width="160px" Visible="false">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:Button ID="AssetDep" runat="server" SkinID="btnRsz" Text="ASSET DEPRECIATION"
                                        CssClass="ButtonClass" Width="170" OnClientClick="return Validate1();" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="btnTd">
                                    <br />
                                    <asp:Button ID="btnA" runat="server" CommandName="Update" SkinID="btn" CausesValidation="true"
                                        Text="ADD" ValidationGroup="edit" CssClass="ButtonClass" OnClientClick="return Validate();"
                                        Visible="false" />
                                    <asp:Button ID="btnV" runat="server" Text="VIEW" CausesValidation="false" SkinID="btn"
                                        CssClass="ButtonClass" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="btnTd">
                                    <br />
                                    <asp:Button ID="btnAdd" runat="server" CommandName="Update" SkinID="btn" TabIndex="45"
                                        CausesValidation="true" Text="ADD" ValidationGroup="edit" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" />
                                    &nbsp;<asp:Button ID="btnView" runat="server" Text="VIEW" CausesValidation="false" SkinID="btn"
                                        TabIndex="46" CssClass="ButtonClass" />
                                </td>
                            </tr>
                        </table>
                        <center>
                            <br />
                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                            SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                        </center>
                        <br />
                        <center>
                            <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="True"
                                    Visible="True" AutoGenerateColumns="False" PageSize="100" AllowSorting="True"
                                    EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Asset Photo" ControlStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Image ID="LabelEmp_Photo" ImageUrl='<%# Bind("Asset_Photo") %>' runat="server">
                                                </asp:Image>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Asset Code" SortExpression="AssetCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl5" runat="server" Text='<%# Bind("AssetCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Asset Name" SortExpression="AssetName">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="RAD" runat="server" Value='<%# Bind("AssetDet_Id") %>' />
                                                <asp:Label ID="lbl1" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Asset Type" SortExpression="AssetType_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl2" runat="server" Visible="false" Text='<%# Bind("AssetType_IDAuto") %>'></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("AssetType_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Supplier">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl6" runat="server" Text='<%# Bind("Supp_Id_Auto") %>' Visible="false"> </asp:Label>
                                                <asp:Label ID="Label38" runat="server" Text='<%# Bind("Supp_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount Paid">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl18" runat="server" Text='<%# Bind("AmtPaid","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Asset Depreciation Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDepreciationrate" runat="server" Text='<%# Bind("Depreciation_Rate") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="Label39" runat="server" Text='<%# Bind("CommodityName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Book value price ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl4" runat="server" Text='<%# Bind("Price","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Received by" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl7" runat="server" Text='<%# Bind("Emp_ID") %>'></asp:Label>
                                                <asp:Label ID="LblEmpName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Manufacturer" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl8" runat="server" Text='<%# Bind("ManuFacturerCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl9" runat="server" Text='<%# Bind("DeptID")  %>' Visible="false"></asp:Label>
                                                <asp:Label ID="Label41" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Machine serial no" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl10" runat="server" Text='<%# Bind("MachineSerialNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Payment method" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl11" runat="server" Text='<%# Bind("PaymentMethod_Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Motor sl.no" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl12" runat="server" Text='<%# Bind("MotorNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Purchase Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl13" runat="server" Text='<%# Bind("PurchaseDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Model No" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl14" runat="server" Text='<%# Bind("Model_Number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill Type" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl15" runat="server" Text='<%# Bind("BillType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl16" runat="server" Text='<%# Bind("InvoiceNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Brought by" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl17" runat="server" Text='<%# Bind("Brought_by") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl19" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl20" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SentBy" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl21" runat="server" Text='<%# Bind("SentBy") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Insuredto" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl22" runat="server" Text='<%# Bind("InsuredTo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Insured Amount " Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl23" runat="server" Text='<%# Bind("InsuredAmt","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Premium Amount " Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl24" runat="server" Text='<%# Bind("PremiumAmt","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Due date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl25" runat="server" Text='<%# Bind("InsDueDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Insurance Amount paid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl26" runat="server" Text='<%# Bind("InsuredPaidAmt","{0:0.00}") %>'></asp:Label>
                                                <asp:Label ID="lblwarranty" runat="server" Text='<%# Bind("Warranty") %>'></asp:Label>
                                                <asp:Label ID="lblWarrantyPeriod" runat="server" Text='<%# Bind("Warranty_Period") %>'></asp:Label>
                                                <asp:Label ID="lblGurranty" runat="server" Text='<%# Bind("Guaranty") %>'></asp:Label>
                                                <asp:Label ID="lblGurrantyPeriod" runat="server" Text='<%# Bind("Guaranty_Period") %>'></asp:Label>
                                                <asp:Label ID="lblAmcTo" runat="server" Text='<%# Bind("AMC_To") %>'></asp:Label>
                                                <asp:Label ID="lblAMCStDate" runat="server" Text='<%# Bind("AMC_StartDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("AMC_EndDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                <asp:Label ID="AmcAmount" runat="server" Text='<%# Bind("AMC_Amount","{0:0.00}") %>'></asp:Label>
                                                <asp:Label ID="lblPhoto1" runat="server" Text='<%# Bind("Asset_Photo") %>'></asp:Label>
                                                <asp:Label ID="lblINvValue" runat="server" Text='<%# Bind("Invoice_Value") %>'></asp:Label>
                                                <asp:Label ID="lblDesType" runat="server" Text='<%# Bind("DepreciationType") %>'></asp:Label>
                                                <asp:Label ID="lblPaid" runat="server" Text='<%# Bind("Premium_Paid_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                <asp:Label ID="lblRegDate" runat="server" Text='<%# Bind("RegistrationDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                <asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("RegistrationNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GRN No " Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgrn" runat="server" Text='<%# Bind("GRN_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MRN No " Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmrn" runat="server" Text='<%# Bind("MRN_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Asset Status " Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblasset" runat="server" Text='<%# Bind("Asset_Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Purchase Order " Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpo" runat="server" Text='<%# Bind("Purchase_Order") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice Date " Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinvoicedate" runat="server" Text='<%# Bind("Invoice_Date","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </center>
                        <a name="Bottom">
                            <div align="right">
                                <a href="#Top">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                            </div>
                        </a>
                        <div>
                            &nbsp;<asp:ObjectDataSource ID="cmbAssetType" runat="server" SelectMethod="GetAssetTypescombo"
                                TypeName="AssetDetailsB"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="cmbdepreciation" runat="server" SelectMethod="GetDepreciationTypescombo"
                                TypeName="AssetDetailsB"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="cmbsupplier" runat="server" SelectMethod="GetSuppliercombo"
                                TypeName="AssetDetailsB"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="cmbmanufacturer" runat="server" SelectMethod="GetManufacturercombo"
                                TypeName="AssetDetailsB"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="cmbpaymentmethod" runat="server" SelectMethod="GetPaymentMethodcombo1"
                                TypeName="AssetDetailsDB"></asp:ObjectDataSource>
                        </div>
                    </center>
                    </div>
                    <style type="text/css">
                        .completeListStyle
                        {
                            height: 100px;
                            width: 50px;
                            overflow: auto;
                            list-style-type: disc;
                            padding-left: 17px;
                            background-color: #FFF;
                            border: 1px solid DarkGray;
                            text-align: left;
                            font-size: small;
                            color: black;
                        }
                    </style>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
