<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmEnquiryDetails.aspx.vb"
    Inherits="EnquiryDetails" Title="Enquiry Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Enquiry Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
        //Function for Multilingual Validations
        //Created By Niraj
        function ErrorMessage(msg) {
            var SesVar = '<%= Session("Validation") %>';
            var ValidationArray = new Array();
            ValidationArray = SesVar.split(":");
            for (var i = 0; i < ValidationArray.length - 1; i++) {
                if (ValidationArray[i] == msg) {
                    return ValidationArray[i + 1];
                }
            }
        }


        function Spliter(a) {
            var str = a;
            var n = str.indexOf("*");
            if (n != 0 && n != -1) {
                a = a.split("*");
                return a[0];
            }
            var n = str.indexOf("^");
            if (n != 0 && n != -1) {
                a = a.split("^");
                return a[0];
            }
            var n = str.indexOf(":");
            if (n != 0 && n != -1) {
                a = a.split(":");
                return a[0];
            }
        }
        function Valid() {
            var msg;
            msg = ValidateDateMul(document.getElementById("<%=txtFromDateExt.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtFromDateExt.ClientID%>").focus();
                a = document.getElementById("<%=lblFromDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = ValidateDateMul(document.getElementById("<%=txtToDateExt.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtToDateExt.ClientID%>").focus();
                a = document.getElementById("<%=lblToDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;

                    return false;
                }
            }
            return true;
        }

        function ShowImage() {
            GlbShowSImage(document.getElementById("<%=txtstdname.ClientID%>"));

        }
        function HideImage() {
            GlbHideSImage(document.getElementById("<%=txtstdname.ClientID%>"));
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                <br />
                    <h1 class="headingTxt">
                        <asp:Label ID="Labeled" runat="server" Text="ENQUIRY DETAILS" SkinID="lblRepRsz"
                            Width="290" Visible="True"></asp:Label></h1>
                    </h1>
                </center>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFromDate" runat="server" SkinID="lbl" Text="From Date* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDateExt" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <ajaxToolkit:CalendarExtender ID="FromDateExt" runat="server" TargetControlID="txtFromDateExt"
                            Format="dd-MMM-yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblToDate" runat="server" SkinID="lbl" Text="To Date* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDateExt" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <ajaxToolkit:CalendarExtender ID="ToDateExt" runat="server" TargetControlID="txtToDateExt"
                            Format="dd-MMM-yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <tr align="right">
                            <td align="right">
                                <asp:Label ID="Label15" runat="server" SkinID="lbl" Text="Branch&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" DataSourceID="ObjBranch"
                                    DataTextField="BranchName" DataValueField="BranchCode" SkinID="ddlL" TabIndex="3">
                                    <%--<asp:ListItem Value="0" Text=" All"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td>
                                <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text="Course :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCourse" runat="server" DataSourceID="ObjCourse" DataTextField="CourseName"
                                    DataValueField="Courseid" SkinID="ddlRsz" TabIndex="4" Width="250px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="right">
                            <td>
                                <asp:Label ID="Label13" runat="server" SkinID="lbl" Text="Student Name  :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtstdname" runat="server" SkinID="txt" AutoPostBack="True" TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" TargetControlID="txtstdname"
                                    ServiceMethod="getEnquiryExt" ServicePath="TextBoxExt.asmx" MinimumPrefixLength="3"
                                    OnClientPopulated="HideImage" OnClientPopulating="ShowImage" CompletionInterval="1000"
                                    FirstRowSelected="true" EnableCaching="True" CompletionListCssClass="completeListStyle">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" WatermarkText="Type first 3 characters"
                                    runat="server" SkinID="watermark" TargetControlID="txtstdname">
                                </ajaxToolkit:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr align="right">
                            <td>
                                <asp:Label ID="lblAdmitted" runat="server" SkinID="lbl" Text="Admitted :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAdmitted" runat="server" SkinID="ddl" TabIndex="6">
                                    <asp:ListItem Text="All" Value="A"></asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" Text="Source of Information :&nbsp;&nbsp;"
                                    SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSource" TabIndex="7" runat="server" SkinID="ddl" DataTextField="SourceofInfo"
                                    DataValueField="SIMIDAuto" DataSourceID="ObjSourceofInfo" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSourceofInfo" runat="server" TypeName="EnquiryDB" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="SourceofInfo"></asp:ObjectDataSource>
                            </td>
                        </tr>
                         <tr>
                            <td align="right">
                                <asp:Label ID="lblERelated" runat="server" Text="Enquiry Related To :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="175px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbERelates" TabIndex="8" runat="server" SkinID="ddl" 
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                    <asp:ListItem>Course</asp:ListItem>
                                    <asp:ListItem>Admission</asp:ListItem>
                                    <asp:ListItem>Fee</asp:ListItem>
                                    <asp:ListItem>Career</asp:ListItem>
                                </asp:DropDownList>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd">
                                <asp:Button ID="btnReport" runat="server" SkinID="btn" TabIndex="9" CausesValidation="true"
                                    OnClientClick="return Validate();" Text="REPORT" CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="btnSave" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="10"
                                    Text="BACK" ValidationGroup="save" />
                            </td>
                        </tr>
                        <caption>
                            <br />
                            <br />
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <asp:Label ID="lblErrorMsg" runat="server" BackColor="Red" ForeColor="White"></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <caption>
                                <br />
                                <tr>
                                    <td>
                                        <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetBranchByUID" TypeName="BLBranchAccessLevel"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ObjectDataSource ID="ObjCourse" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetBranchCourse" TypeName="DLReportsR">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlBranch" Name="BranchCode" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                            </caption>
                        </caption>
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
