<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptAssetAllocation.aspx.vb"
    Inherits="RptAssetAllocation" Title="Asset Allocation Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Asset Allocation Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtIssued.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtIssued.ClientID%>"));
        }
        function Valid() {
            var msg;
            //           msg = AutoCompleteExtender(document.getElementById("<%=txtIssued.ClientID %>"), 'Issued To');
            //            if (msg != "") return msg;
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
        function SplitName() {
            var text = document.getElementById("<%=txtIssued.ClientID%>").value;
            var split = text.split(':');
            if (split.length > 0) {
                document.getElementById("<%=HidECode.ClientID%>").innerText = split[0];
                document.getElementById("<%=txtIssued.ClientID%>").innerText = split[1];

            }
        } 
 
    </script>

 <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        ASSET ALLOCATION
                    </h1>
                </center>
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
                </table>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblAssetType" runat="server" SkinID="lblRsz" Text="Asset Type :&nbsp;&nbsp"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlassetType" runat="server" DataSourceID="cmbAssetType" DataValueField="AssetType_IDAuto"
                                    AppendDataBoundItems="true" DataTextField="AssetType_Name" SkinID="ddl" TabIndex="1"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="cmbAssetType" runat="server" SelectMethod="GetAssetTypescombo"
                                    TypeName="AssetDetailsB"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LblAssetName" runat="server" SkinID="lblRsz" Text="Asset Name :&nbsp;&nbsp"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAssetName" runat="server" DataSourceID="ObjAssetName" DataValueField="Supp_Id_Auto"
                                    DataTextField="Supp_Name" AppendDataBoundItems="True" SkinID="ddl" TabIndex="4">
                                    <asp:ListItem Value="0">ALL</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjAssetName" runat="server" SelectMethod="GetAssetNameAll"
                                    TypeName="DLAssetTransferNew">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlassetType" DefaultValue="0" Name="Assettype"
                                            PropertyName="SelectedValue" Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" SkinID="lbl" Text=" Issued To :"></asp:Label>
                                <asp:HiddenField ID="HidECode" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtIssued" TabIndex="0" runat="server"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" TargetControlID="txtIssued"
                                    EnableCaching="true" MinimumPrefixLength="3" ServiceMethod="getEmpCodeExt1" ServicePath="TextBoxExt.asmx"
                                    FirstRowSelected="true" CompletionInterval="2000" OnClientPopulated="HideImage1"
                                    OnClientItemSelected="SplitName" OnClientPopulating="ShowImage1" CompletionListCssClass="completeListStyle">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                    WatermarkText="Type first few characters" TargetControlID="txtIssued" SkinID="watermark">
                                </ajaxToolkit:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" TabIndex="6" runat="server" Text="REPORT" SkinID="btn"
                                    CssClass="ButtonClass" OnClientClick="return Validate();"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="6" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass">
                                </asp:Button>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <div>
                                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
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

</form>
</body>
</html>
