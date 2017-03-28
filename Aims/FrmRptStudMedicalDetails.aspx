<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptStudMedicalDetails.aspx.vb"
    Inherits="FrmRptStudMedicalDetails" Title="Student Medical Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Medical Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

    <script type="text/javascript" language="javascript">

        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
        }

        function SplitName1() {
            var text = document.getElementById("<%=txtStdCode.ClientID%>").value;
            var split = text.split(':');
            if (split.length > 0) {
                document.getElementById("<%=txtStdCode.ClientID%>").innerText = split[0];
                document.getElementById("<%=HidId.ClientID%>").innerText = split[1];
                document.getElementById("<%=HidstdId.ClientID%>").innerText = split[2];
            }
        }
        //        function ValidMed() {
        //            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtStdCode.ClientID %>"), 'Student Code');
        //            if (msg != "") {
        //                document.getElementById("<%=txtStdCode.ClientID %>").focus();
        //                return msg;
        //            }
        //        }
        //        function ValidateMed() {
        //            var msg = ValidMed();
        //            if (msg != true) {
        //                if (navigator.appName == "Microsoft Internet Explorer") {
        //                    document.getElementById("<%=msgin.ClientID %>").innerText = msg;
        //                    document.getElementById("<%=lblSC.ClientID%>").innerText = "";
        //                    return false;
        //                }
        //                else if (navigator.appName == "Netscape") {
        //                    document.getElementById("<%=msgin.ClientID %>").textContent = msg;
        //                    document.getElementById("<%=lblSC.ClientID%>").textContent = "";
        //                    return false;
        //                }
        //            }
        //            return true;
        //        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        
                        <asp:Label ID="Labelsmd" runat="server" Text="STUDENT MEDICAL DETAILS" SkinID="lblRepRsz"
                            Width="290" Visible="True"></asp:Label></h1>
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
                                <asp:Label ID="lblStdid" runat="server" SkinID="lbl" Text="Student Code&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:HiddenField ID="HidstdId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="HidId" runat="server"></asp:HiddenField>
                                <asp:TextBox ID="txtStdCode" runat="server" SkinID="txt" TabIndex="1" AutoPostBack="True"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" CompletionInterval="2000"
                                    EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage1"
                                    OnClientPopulating="ShowImage1" ServiceMethod="getStudentIdName1" ServicePath="TextBoxExt.asmx"
                                    TargetControlID="txtStdCode" CompletionListCssClass="completeListStyle22">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                    SkinID="watermark" TargetControlID="txtStdCode" WatermarkText="Type first 3 characters">
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
                                <asp:Button ID="btnReport" TabIndex="2" runat="server" Text="REPORT" SkinID="btn" CommandName="REPORT"
                                    CssClass="ButtonClass"></asp:Button>
                                <asp:Button ID="btnBack" TabIndex="3" runat="server" Text="BACK" SkinID="btn" CommandName="BACK" CssClass="ButtonClass">
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
                                        <asp:Label ID="msgin" runat="server" SkinID="lblRed"></asp:Label>
                                        <asp:Label ID="lblSC" runat="server" SkinID="lblGreen"></asp:Label>
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
                .completeListStyle22
                {
                    height: 200px;
                    width: 705px;
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
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
