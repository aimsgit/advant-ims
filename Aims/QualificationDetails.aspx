<%@ Page Language="VB" AutoEventWireup="false" CodeFile="QualificationDetails.aspx.vb"
    Inherits="QualificationDetails" Title="Additional Qualification Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Additional Qualification Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        //Function for Multilingual Validations
        //Created By Niraj
       


//        function getElements() {
//    var x = '<%=Session("FilePath") %>';
//       document.getElementById('<%=TextBox4.ClientID%>').value=x;
//}
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

        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtStudentCode.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtStudentCode.ClientID%>"));
        }
        function ValidV2() {
            msg = AutoCompleteExtenderForThreeMul(document.getElementById("<%=txtStudentcode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtStudentcode.ClientID %>").focus();
                a = document.getElementById("<%=lblStdcode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
        }

        function ValidateV2() {
            var msg = ValidV2();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo1.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
                   
                    document.getElementById("<%=lblS.ClientID%>").innerText = "";
                    document.getElementById("<%=lblE.ClientID%>").innerText = "";
                    
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo1.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID%>").textContent = "";
                   
                    document.getElementById("<%=lblS.ClientID%>").textContent = "";
                    document.getElementById("<%=lblE.ClientID%>").textContent = "";
                   
                    return false;
                }
            }
            return true;
        }
        function ValidV3() {
            var msg;
            msg = AutoCompleteExtenderForThreeMul(document.getElementById("<%=txtStudentcode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtStudentcode.ClientID %>").focus();
                a = document.getElementById("<%=lblStdcode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
        }

        function ValidateV3() {
            var msg = ValidV3();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo1.ClientID %>").innerText = "";
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
                  
                    document.getElementById("<%=lblS.ClientID%>").innerText = "";
                    document.getElementById("<%=lblE.ClientID%>").innerText = "";
                   
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo1.ClientID %>").textContent = "";
                    document.getElementById("<%=msginfo.ClientID%>").textContent = "";
                  
                    document.getElementById("<%=lblS.ClientID%>").textContent = "";
                    document.getElementById("<%=lblE.ClientID%>").textContent = "";
                    
                    return false;
                }
            }
            return true;
        }
        function Valid() {
            var msg;
            msg = AutoCompleteExtenderForThreeMul(document.getElementById("<%=txtStudentcode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtStudentcode.ClientID %>").focus();
                a = document.getElementById("<%=lblStdcode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField100Mul(document.getElementById("<%=txtExamination.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtExamination.ClientID %>").focus();
                a = document.getElementById("<%=Label12.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            //            msg = NameField100(document.getElementById("<%=txt_BOU.ClientID %>"), 'Board/University*');
            //            if (msg != "") {
            //                document.getElementById("<%=txt_BOU.ClientID %>").focus();
            //                return msg;
            //            }

            msg = FeesFieldMul(document.getElementById("<%=txtMarks.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtMarks.ClientID %>").focus();
                a = document.getElementById("<%=LblMarks.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }
        function Valid1() {
            var msg;
            msg = AutoCompleteExtenderForThreeMul(document.getElementById("<%=txtStudentcode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtStudentcode.ClientID %>").focus();
                a = document.getElementById("<%=lblStdcode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField100Mul(document.getElementById("<%=txtName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtName.ClientID %>").focus();
                a = document.getElementById("<%=Label26.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = NameField100Mul(document.getElementById("<%=txtNIJ.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtNIJ.ClientID %>").focus();
                a = document.getElementById("<%=Label30.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
          

            return true;
        }
        function Valid2() {
            var msg;
            msg = AutoCompleteExtenderForThreeMul(document.getElementById("<%=txtStudentcode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtStudentcode.ClientID %>").focus();
                a = document.getElementById("<%=lblStdcode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
           
            msg = Field255NMul(document.getElementById("<%=txtremarks.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtremarks.ClientID %>").focus();
                a = document.getElementById("<%=lblremarks.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }


            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
        function Validate1() {
            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo1.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblS.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo1.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblS.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
       
        function TABLE1_onclick() {

        }
        //        function SplitName() {
        //            var text = document.getElementById("<%=txtStudentcode.ClientID%>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=txtStudentCode.ClientID%>").innerText = split[0] + ":" + split[1];
        //                document.getElementById("<%=HidStudentId.ClientID%>").innerText = split[2];
        //            }
        //        }

    </script>

    <script type="text/javascript" language="javascript">

        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtStdCode2.ClientID%>"));

        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtStdCode2.ClientID%>"));
        }

        //        function SplitNameMed() {
        //            var text = document.getElementById("<%=txtStdCode2.ClientID%>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=txtStdCode2.ClientID%>").innerText = split[0];
        //                document.getElementById("<%=HidId.ClientID%>").innerText = split[1];
        //                document.getElementById("<%=HidstdId.ClientID%>").innerText = split[2];
        //            }
        //        }
        function ValidMed() {
            msg = AutoCompleteExtenderForThreeMul(document.getElementById("<%=txtStdCode2.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtStdCode2.ClientID %>").focus();
                a = document.getElementById("<%=lblStdid1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field50Mul(document.getElementById("<%=txtHeight1.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtHeight1.ClientID %>").focus();
                a = document.getElementById("<%=lblHeight1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = Field50Mul(document.getElementById("<%=txtWeight1.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtWeight1.ClientID %>").focus();
                a = document.getElementById("<%=lblWeight1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = Field50Mul(document.getElementById("<%=txtBloodGroup1.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtBloodGroup1.ClientID %>").focus();
                a = document.getElementById("<%=lblBloodGroup1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }
        function ValidateMed() {
            var msg = ValidMed();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
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
                    ActiveTabIndex="0">
                    <ajaxToolkit:TabPanel ID="Qualification" runat="server" HeaderText="QUALIFICATION">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                <ContentTemplate>
                                    <center>
                                        <center>
                                            <table>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblStdcode" runat="server" SkinID="lbl" Text="Student Code* :&nbsp;"></asp:Label>
                                                        <asp:HiddenField ID="HidStudentId" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtStudentcode" runat="server" SkinID="txtRsz" Width="200px" TabIndex="1"
                                                            AutoPostBack="true"></asp:TextBox>
                                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" TargetControlID="txtStudentcode"
                                                            EnableCaching="true" MinimumPrefixLength="3" ServiceMethod="getStudentid" ServicePath="TextBoxExt.asmx"
                                                            FirstRowSelected="true" CompletionInterval="2000" OnClientPopulated="HideImage1"
                                                            OnClientPopulating="ShowImage1" CompletionListCssClass="completeListStyle22">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                                            WatermarkText="Type first 3 characters" TargetControlID="txtStudentcode" SkinID="watermark">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                        <br />
                                        <div>
                                            <%--   <center>
                        <h1 class="headingTxt">
                            QUALIFICATION DETAILS</h1>
                    </center>--%>
                                            <center>
                                                <h1 class="headingTxt">
                                                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                                                </h1>
                                            </center>
                                            <br />
                                            <br />
                                        </div>
                                        <center>
                                            <table>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Examination* :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtExamination" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="Label22" runat="server" SkinID="lblRsz" Text="Board/University :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_BOU" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label23" runat="server" SkinID="lbl" Text="Year* :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <%--<asp:TextBox ID="txt_YOP" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>--%>
                                                        <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="ObjSelectYear" DataTextField="Data"
                                                            DataValueField="LookUpAutoID" SkinID="ddlRsz" TabIndex="4" Width="160px">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="ObjSelectYear" runat="server" SelectMethod="ddlYear" TypeName="BLClientContractMaster">
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="Label24" runat="server" SkinID="lbl" Text="Total Marks :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txt_marks" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblSub" runat="server" SkinID="lbl" Text="Subject 1 :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSub" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="LblMarks" runat="server" SkinID="lbl" Text="Marks%* :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtMarks" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="LblSub2" runat="server" SkinID="lbl" Text="Subject 2 :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSub2" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblRank" runat="server" SkinID="lbl" Text="Rank :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtRank" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblSub3" runat="server" SkinID="lbl" Text="Subject 3 :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSub3" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblMedium" runat="server" SkinID="lbl" Text="Medium :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMedium" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label13" runat="server" Text="Submitted Certificate :&nbsp;" SkinID="lblRsz"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlsubcertificate" runat="server" SkinID="ddl" TabIndex="12">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>Original</asp:ListItem>
                                                            <asp:ListItem>Xerox</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblDistrict" runat="server" SkinID="lbl" Text="Admin. District :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtDistrict" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="LblZindex" runat="server" SkinID="lbl" Text="Z Score :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="TxtZindex" runat="server" SkinID="txt" TabIndex="14"></asp:TextBox>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblstream" runat="server" SkinID="lbl" Text="Stream :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtstream" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblattempt" runat="server" SkinID="lbl" Text="Attempt :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtattempt" runat="server" SkinID="txt" TabIndex="16"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                            FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtattempt">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Button ID="btnInsert" runat="server" Text="ADD" SkinID="btn" CssClass="ButtonClass"
                                                            CommandName="ADD" TabIndex="17" OnClientClick="return Validate()" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Button ID="btnView" runat="server" Text="VIEW" SkinID="btn" CssClass="ButtonClass"
                                                            CommandName="VIEW" TabIndex="18" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <center>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
                                                            <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </center>
                                            </table>
                                        </center>
                                        <center>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="GV" runat="server" ScrollBars="Auto" Width="600px" Height="200px"
                                                            Visible="false">
                                                            <asp:GridView ID="GV_qualific" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                                SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton Text="Edit" CommandName="Edit" CausesValidation="false" runat="server"
                                                                                ID="btEdit" />&nbsp;
                                                                            <asp:LinkButton ID="btDelete" runat="server" CausesValidation="true" CommandName="Delete"
                                                                                Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Examination" SortExpression="Qualification">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="Qualification_ID" runat="server" Value='<%# Bind("Qualification_ID") %>'>
                                                                            </asp:HiddenField>
                                                                            <asp:HiddenField ID="StdCode" runat="server" Value='<%# Bind("StdCode") %>'></asp:HiddenField>
                                                                            <asp:HiddenField ID="Stdcodeid" runat="server" Value='<%# Bind("Std_code") %>'></asp:HiddenField>
                                                                            <asp:Label ID="lblname" runat="server" Text='<%# Bind("Qualification") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Board/University" SortExpression="Board_Univ">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_universe" runat="server" Text='<%# Bind("Board_Univ") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Medium" SortExpression="Medium">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Medium" runat="server" Text='<%# Bind("Medium") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subject1" SortExpression="Subject1">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Subject1" runat="server" Text='<%# Bind("Subject1") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subject2" SortExpression="Subject2">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Subject2" runat="server" Text='<%# Bind("Subject2") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Subject3" SortExpression="Subject3">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Subject3" runat="server" Text='<%# Bind("Subject3") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Marks" SortExpression="Marks">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_marks" runat="server" Text='<%# Bind("Marks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Marks" SortExpression="TotalMarks">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Totmarks" runat="server" Text='<%# Bind("TotalMarks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Rank" SortExpression="Rank">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Rank" runat="server" Text='<%# Bind("Rank") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Admin.District" SortExpression="AdminDistrict">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_AdminDistrict" runat="server" Text='<%# Bind("AdminDistrict") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Z Score" SortExpression="Zindex">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Zindx" runat="server" Text='<%# Bind("Zindex","{0:n3}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Year of Passing" SortExpression="YearofPassing">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_YOP" runat="server" Text='<%# Bind("YearofPassing") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Submitted Certificate" SortExpression="CERT_SBMT">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_Certificate" runat="server" Text='<%# Bind("CERT_SBMT") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Stream">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblstream" runat="server" Text='<%# Bind("Stream") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Attempt">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblattempt" runat="server" Text='<%# Bind("Attempt") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                        <br />
                                        <div>
                                            <center>
                                                <h1 class="headingTxt">
                                                    <asp:Label ID="LabelEmp" runat="server" Text="EXPERIENCE DETAILS" SkinID="lblRepRsz"
                                                        Width="250" Visible="True"></asp:Label></h1>
                                            </center>
                                        </div>
                                        <br />
                                        <br />
                                        <center>
                                            <table>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblExpT" runat="server" SkinID="lblRsz" Width="180px" Text="Experience Type* :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="DDLExperienceType" runat="server" SkinID="ddl" DataSourceID="ObjExp"
                                                            DataTextField="Data" DataValueField="LookUpAutoID">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource runat="server" ID="ObjExp" SelectMethod="GetEmpExperienceType"
                                                            TypeName="DLEmpQualification"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label30" runat="server" SkinID="lbl" Text="Description* :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtNIJ" runat="server" SkinID="txt" TabIndex="21"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label26" runat="server" SkinID="lblRsz" Text="Organisation* :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtName" runat="server" SkinID="txt" TabIndex="19"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblFromDt" runat="server" SkinID="lbl" Text="From Date :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox runat="server" ID="txtFromDt" SkinID="txt"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtFromDt"
                                                            Format="dd-MMM-yyyy" SkinID="Calendar" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                                            FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                                            TargetControlID="txtFromDt">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblToDate" runat="server" SkinID="lbl" Text="To Date :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox runat="server" ID="txtToDate" SkinID="txt"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtToDate"
                                                            Format="dd-MMM-yyyy" SkinID="Calendar" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                            FilterMode="InvalidChars" FilterType="Custom" InvalidChars="',./;:'[]{}_=+)(*&^%$#@!"
                                                            TargetControlID="txtToDate">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblremarks" runat="server" SkinID="lbl" Text="Remarks :&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtremarks" runat="server" SkinID="txt" TabIndex="25" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblCir" runat="server" SkinID="lbl" Text="Certificate :&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left" id ="load">
                                                        <%--<asp:Label ID="lblupload"  runat="server"></asp:Label>--%>
                                                        <asp:TextBox ID="TextBox4" Enabled="false" runat="server"></asp:TextBox>
                                                        <%--  <asp:HyperLink id="HyperLink1" runat="server" Text="Upload" NavigateUrl ="frmdocmgmt.aspx" > </asp:HyperLink>--%>
                                                        <asp:HyperLink ID="Hyperlink2" runat="server" NavigateUrl="frmdocmgmt.aspx" onclick="window.open (this.href, 'popupwindow','width=1024,height=768,left='+((screen.width - 1024) / 2)+',top=' + ((screen.heigth - 80) / 2)+',scrollbars,resizable'); return false;">Upload</asp:HyperLink>
                                                        <%-- window.open('webform1.aspx', '_blank', 'width=530, height=80, left='+((screen.width - 530) / 2)+', top=' + ((screen.heigth - 80) / 2));--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="right">
                                                        <asp:Button ID="btnExper" runat="server" Text="ADD" CommandName="ADD1" TabIndex="22"
                                                            OnClientClick="return Validate1()" SkinID="btn" CssClass="ButtonClass" />
                                                        
                                                    </td>
                                                    <td align="left">
                                                        <asp:Button ID="btnDet" runat="server" Text="VIEW" SkinID="btn" CommandName="VIEW1"
                                                            CssClass="ButtonClass" TabIndex="23" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <center>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="msginfo1" runat="server" SkinID="lblRed"></asp:Label>
                                                            <asp:Label ID="lblS" runat="server" SkinID="lblGreen"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </center>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Panel ID="PExp" runat="server" ScrollBars="Auto" Width="650px" Height="200px"
                                                            >
                                                            <asp:GridView ID="GV_Exp" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                                SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                                <Columns>
                                                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                Text="Edit" />&nbsp;
                                                                            <asp:LinkButton ID="Button2" runat="server" CausesValidation="true" CommandName="Delete"
                                                                                Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Experience Type" Visible="true">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="ExperienceTypeID" Visible="false" runat="server" Text='<%# Bind("ExperienceTypeID") %>'></asp:Label>
                                                                            <asp:Label ID="Data" runat="server" Text='<%# Bind("Data") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Description" SortExpression="Natureofjob">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Natureofjob") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Organization" SortExpression="NameofOrganisation">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="ExpId" runat="server" Value='<%# Bind("Exp_id") %>' />
                                                                            <asp:HiddenField ID="Hidstdcode" runat="server" Value='<%# Bind("StdCode") %>' />
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NameofOrganisation") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remark">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LabelRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Certificate">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LabelCer" runat="server" Text='<%# Bind("Certificate") %>'></asp:Label>
                                                                            <asp:Label ID="lblfromdate" Visible="false" runat="server" Text='<%# Bind("FromDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                            <asp:Label ID="lbltodate" Visible="false" runat="server" Text='<%# Bind("ToDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                        <br />
                                       
                                        <center>
                                            
                                                                                    
                                           
                                         
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnReturn" runat="server" Visible="false" Text="BACK" TabIndex="28"
                                                            SkinID="btn" CssClass="ButtonClass" />
                                                        <asp:Button ID="btnfee" runat="server" Text="Fee Collection" TabIndex="29" SkinID="btnRsz"
                                                            Width="200px" CommandName="FEE" CssClass="ButtonClass" />
                                                        <asp:Button ID="btnplacement" runat="server" Text="Placement Details" TabIndex="30"
                                                            SkinID="btnRsz" Width="200px" CssClass="ButtonClass" Visible="false" />
                                                        <asp:Button ID="btnlateral" runat="server" Text="Lateral Entry Details" TabIndex="31"
                                                            SkinID="btnRsz" Width="200px" CssClass="ButtonClass" Visible="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="label4" runat="server" HeaderText="MEDICAL DETAILS">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                <ContentTemplate>
                                    <center>
                                        <h1 class="headingTxt">
                                            <asp:Label ID="Medical" runat="server" Text="MEDICAL DETAILS" SkinID="lblRepRsz"
                                                Width="200" Visible="True"></asp:Label>
                                        </h1>
                                    </center>
                                    <center>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblStdid1" runat="server" SkinID="lbl" Text="Student Code*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:HiddenField ID="HidstdId" runat="server"></asp:HiddenField>
                                                        <asp:HiddenField ID="HidId" runat="server"></asp:HiddenField>
                                                        <asp:TextBox ID="txtStdCode2" runat="server" SkinID="txt" TabIndex="2" AutoPostBack="True"></asp:TextBox>
                                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" CompletionInterval="2000"
                                                            EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage2"
                                                            OnClientPopulating="ShowImage2" ServiceMethod="getStudentIdName1" ServicePath="TextBoxExt.asmx"
                                                            TargetControlID="txtStdCode2" CompletionListCssClass="completeListStyle1">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                            SkinID="watermark" TargetControlID="txtStdCode2" WatermarkText="Type first 3 characters">
                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblHeight1" runat="server" SkinID="lbl" Text="Height(Cms)*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtHeight1" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblWeight1" runat="server" SkinID="lbl" Text="Weight(Kgs)*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtWeight1" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblIdentificationMark1" runat="server" SkinID="lblRsz" Width="200px"
                                                            Text="Identification Mark&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtIdentificationMark1" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblBloodGroup1" runat="server" SkinID="lblRsz" Width="200px" Text="Blood Group*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtBloodGroup1" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblImmunizationRecord1" runat="server" SkinID="lblRsz" Width="200px"
                                                            Text="Immunization Record&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtImmunizationRecord1" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblDetailsofanyseriousillness1" runat="server" SkinID="lblRsz" Width="230px"
                                                            Text="Details of any serious illness&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtDetailsofanyseriousillness1" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblParticularsofanyallergies1" runat="server" SkinID="lblRsz" Width="230px"
                                                            Text="Particulars of any allergies&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtParticularsofanyallergies1" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblEmergencyContactName1" runat="server" SkinID="lblRsz" Width="230px"
                                                            Text="Emergency Contact Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtEmergencyContactName1" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblEmergencyContactNumber1" runat="server" SkinID="lblRsz" Width="230px"
                                                            Text="Emergency Contact Number&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtEmergencyContactNumber1" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblDisabilitiesifany1" runat="server" SkinID="lblRsz" Width="200px"
                                                            Text="Disabilities if any&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtDisabilitiesifany1" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnadd" runat="server" CommandName="ADD3" CssClass="ButtonClass"
                                                            SkinID="btn" TabIndex="13" Text="ADD" OnClientClick="return ValidateMed();" />
                                                        <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="14"
                                                            CommandName="VIEW3" Text="VIEW" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                                            <ProgressTemplate>
                                                                <div class="PleaseWait">
                                                                    <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                                                </div>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                                                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="GridMedical" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                            PageSize="100" SkinID="GridView" Width="368px">
                                                                            <Columns>
                                                                                <asp:TemplateField ShowHeader="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                            Text="Edit" TabIndex="11"></asp:LinkButton>
                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                            Text="Delete" TabIndex="15" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                                            Visible="True"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="False" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Student Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblStdId" runat="server" Text='<%# Bind("Std_ID") %>' Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName")  %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Student Code">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblcode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Height(Cms)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblHeight" runat="server" Text='<%# Bind("Height") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Weight(Kgs)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblWeight" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Identification Mark">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblIdentificationMark" runat="server" Text='<%# Bind("IdentificationMark") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Blood Group">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblBloodGroup" runat="server" Text='<%# Bind("BloodGroup") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Immunization Record">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblImmunizationRecord" runat="server" Text='<%# Bind("ImmunizationRecord") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Details of any serious illness">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDetailsofanyseriousillness" runat="server" Text='<%# Bind("Detailsofanyseriousillness") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Particulars of any allergies">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblParticularsofanyallergies" runat="server" Text='<%# Bind("Particularsofanyallergies") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Emergency Contact Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEmergencyContactName" runat="server" Text='<%# Bind("EmergencyContactName") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Emergency Contact Number">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEmergencyContactNumber" runat="server" Text='<%# Bind("EmergencyContactNumber") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Disabilities if any">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDisabilitiesifany" runat="server" Text='<%# Bind("Disabilitiesifany") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Wrap="false" />
                                                                                    <HeaderStyle Wrap="false" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <%--<ajaxToolkit:TabPanel ID="MEDICAL" runat="server" HeaderText="MEDICAL DETAILS">
            <ContentTemplate>
                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                    <ContentTemplate>
                        <div>
                            <center>
                                <h1 class="headingTxt">
                                    <asp:Label ID="Label4" runat="server" Text="MEDICAL DETAILS"></asp:Label>
                                </h1>
                            </center>
                            <center>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblStdid" runat="server" SkinID="lbl" Text="Student Code*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:HiddenField ID="HidstdId" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="HidId" runat="server"></asp:HiddenField>
                                                <asp:TextBox ID="txtStdCode" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="Server" CompletionInterval="2000"
                                                    EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImageMed"
                                                    OnClientPopulating="ShowImageMed" ServiceMethod="getStudentIdName1" ServicePath="TextBoxExt.asmx"
                                                    TargetControlID="txtStdCode" CompletionListCssClass="completeListStyle" OnClientItemSelected="SplitNameMed">
                                                </ajaxToolkit:AutoCompleteExtender>
                                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                                    SkinID="watermark" TargetControlID="txtStdCode" WatermarkText="Type first 3 characters">
                                                </ajaxToolkit:TextBoxWatermarkExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblHeight" runat="server" SkinID="lbl" Text="Height*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtHeight" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblWeight" runat="server" SkinID="lbl" Text="Weight*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtWeight" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblIdentificationMark" runat="server" SkinID="lblRsz" Width="200px"
                                                    Text="Identification Mark&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtIdentificationMark" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBloodGroup" runat="server" SkinID="lblRsz" Width="200px" Text="Blood Group*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtBloodGroup" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblImmunizationRecord" runat="server" SkinID="lblRsz" Width="200px"
                                                    Text="Immunization Record&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtImmunizationRecord" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDetailsofanyseriousillness" runat="server" SkinID="lblRsz" Width="230px"
                                                    Text="Details of any serious illness&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDetailsofanyseriousillness" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblParticularsofanyallergies" runat="server" SkinID="lblRsz" Width="230px"
                                                    Text="Particulars of any allergies&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtParticularsofanyallergies" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblEmergencyContactName" runat="server" SkinID="lblRsz" Width="230px"
                                                    Text="Emergency Contact Name&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEmergencyContactName" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblEmergencyContactNumber" runat="server" SkinID="lblRsz" Width="230px"
                                                    Text="Emergency Contact Number&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEmergencyContactNumber" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDisabilitiesifany" runat="server" SkinID="lblRsz" Width="200px"
                                                    Text="Disabilities if any&nbsp;:&nbsp;&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDisabilitiesifany" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="btnadd" runat="server" CommandName="Insert" CssClass="ButtonClass"
                                                    SkinID="btn" TabIndex="7" Text="ADD" OnClientClick="return ValidateMed();" />
                                                <asp:Button ID="btnBack" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="8"
                                                    Text="VIEW" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                                                <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="GridMedical" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                    PageSize="100" SkinID="GridView" Width="368px">
                                                                    <Columns>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                    Text="Edit" TabIndex="11"></asp:LinkButton>
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                    Text="Delete" TabIndex="12" OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                                    Visible="false"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Student Code">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblStd_ID" runat="server" Text='<%# Bind("Std_ID")  %>'></asp:Label>
                                                                                <asp:Label ID="lblStdCode" runat="server" Text='<%# Bind("StdCode")  %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Height">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHeight" runat="server" Text='<%# Bind("Height") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Weight">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblWeight" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Identification Mark">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdentificationMark" runat="server" Text='<%# Bind("IdentificationMark") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Blood Group">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBloodGroup" runat="server" Text='<%# Bind("BloodGroup") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Immunization Record">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblImmunizationRecord" runat="server" Text='<%# Bind("ImmunizationRecord") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Details of any serious illness">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDetailsofanyseriousillness" runat="server" Text='<%# Bind("Detailsofanyseriousillness") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Particulars of any allergies">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblParticularsofanyallergies" runat="server" Text='<%# Bind("Particularsofanyallergies") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Emergency Contact Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEmergencyContactName" runat="server" Text='<%# Bind("EmergencyContactName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Emergency Contact Number">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEmergencyContactNumber" runat="server" Text='<%# Bind("EmergencyContactNumber") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Disabilities if any">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDisabilitiesifany" runat="server" Text='<%# Bind("Disabilitiesifany") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="false" />
                                                                            <HeaderStyle Wrap="false" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </center>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>--%>
                </ajaxToolkit:TabContainer>
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
                <style type="text/css">
                    .completeListStyle1
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
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image5" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
