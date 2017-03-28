<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ByerMasterRealEstate.aspx.vb"
    Inherits="ByerMasterRealEstate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buyer Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=msginfo.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=msginfo.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }
        function Valid() {

            var msg, a;
            msg = Field50Mul(document.getElementById("<%=txtFName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtFName.ClientID %>").focus();
                a = document.getElementById("<%=LblFname.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field50Mul(document.getElementById("<%=txtLName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtLName.ClientID %>").focus();
                a = document.getElementById("<%=LblLname.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = CodeFieldMul(document.getElementById("<%=txtBuyerCode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtBuyerCode.ClientID %>").focus();
                a = document.getElementById("<%=lblBuyerCode.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field50Mul(document.getElementById("<%=txtContactNo1.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtContactNo1.ClientID %>").focus();
                a = document.getElementById("<%=LblContactNo1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = validateEmailMul(document.getElementById("<%=txtEmail1.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtEmail1.ClientID %>").focus();
                a = document.getElementById("<%=lblEmail1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            //            msg = validateEmailMul(document.getElementById("<%=txtEmail2.ClientID %>"));
            //            if (msg != "") {
            //                document.getElementById("<%=txtEmail2.ClientID %>").focus();
            //                a = document.getElementById("<%=lblEmail2.ClientID %>").innerHTML;
            //                msg = Spliter(a) + " " + ErrorMessage(msg);
            //                return msg;
            //            }
            msg = Field250Mul(document.getElementById("<%=txtAddress.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtAddress.ClientID %>").focus();
                a = document.getElementById("<%=lblAddress.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field50Mul(document.getElementById("<%=txtCity.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtCity.ClientID %>").focus();
                a = document.getElementById("<%=lblCity.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Field50Mul(document.getElementById("<%=txtDistrict.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtDistrict.ClientID %>").focus();
                a = document.getElementById("<%=lblDistrict.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlCountry.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlCountry.ClientID %>").focus();
                a = document.getElementById("<%=lblCountry.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlState.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlState.ClientID %>").focus();
                a = document.getElementById("<%=lblState.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }

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
            var n;
            n = str.indexOf("*");
            if (n != 0 && n != -1) {
                a = a.split("*");
                return a[0];
            }
            n = str.indexOf("^");
            if (n != 0 && n != -1) {
                a = a.split("^");
                return a[0];
            }
            n = str.indexOf(":");
            if (n != 0 && n != -1) {
                a = a.split(":");
                return a[0];
            }
        }
    </script>

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
        <ContentTemplate>
            <br />
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="lblheading" runat="server" Text="BUYER MASTER"></asp:Label>
                </h1>
            </center>
            <br />
            <table class="custTable">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblPersonalInfo" runat="server" Text="Personal Info" SkinID="lblBlackRsz"
                            Width="150" Visible="True"></asp:Label>
                    </td>
                </tr>
            </table>
            <center>
                <hr />
                <table class="custTable">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFName" runat="server" Text="First Name*^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="180"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFName" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                        </td>
                        <td align="right" rowspan="3">
                            <asp:Label ID="lblPhoto" runat="server" Text="Photo :&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td rowspan="3" align="right">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/imageupload.gif" Width="90px"
                                Height="90px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblLName" runat="server" Text="Last Name* :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLname" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                            <asp:TextBox ID="txtPath" runat="server" SkinID="txt" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBuyerCode" runat="server" Text="Buyer Code*^:&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="200"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBuyerCode" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTIN" runat="server" Text="TIN :&nbsp;&nbsp;" SkinID="lblRsz" Width="250"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTIN" runat="server" SkinID="txt" TabIndex="6" MaxLength="10"></asp:TextBox>
                        </td>
                        <td align="right" colspan="2" rowspan="3">
                            <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="White" SkinID="btn"
                                TabIndex="4" />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnUpload" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="5"
                                Text="UPLOAD" CommandName="UPLOAD" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblCSTNo" runat="server" Text="CST No :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCSTNo" runat="server" SkinID="txt" TabIndex="7" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblPAN" runat="server" Text="PAN No :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPAN" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblContactNo1" runat="server" Text="Contact No1* :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactNo1" runat="server" SkinID="txt" TabIndex="9"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtContactNo1">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <td align="right">
                                <asp:Label ID="lblContactNo2" runat="server" Text="Contact No2 :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactNo2" runat="server" SkinID="txt" TabIndex="10" MaxLength="10"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtContactNo2">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEmail1" runat="server" Text="Email1* :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail1" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblEmail2" runat="server" Text="Email2 :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail2" runat="server" SkinID="txt" TabIndex="12"></asp:TextBox>
                            <%-- <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtEmail2">
                            </ajaxToolkit:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFaxNo" runat="server" Text="Fax No :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFaxNo" runat="server" SkinID="txt" TabIndex="13"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtFaxNo">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblContactPerson" runat="server" Text="Contact Person :&nbsp;&nbsp;"
                                SkinID="lblRsz" Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactPerson" runat="server" SkinID="txt" TabIndex="14"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblIntro" runat="server" Text="Introducer :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtIntro" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblOffAdd" runat="server" Text="Office Address" SkinID="lblBlackRsz"
                                Width="150" Visible="True"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lblResiAdd" runat="server" Text="Residence Address" SkinID="lblBlackRsz"
                                Width="150" Visible="True"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <hr />
                <table>
                    <tr>
                        <td align="right">
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:Label ID="lblAddress" runat="server" SkinID="lblRsz" Width="130" Text="Address* :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAddress" runat="server" SkinID="txtRsz" Height="50" TabIndex="16"
                                TextMode="MultiLine">
                            </asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblAddr" runat="server" SkinID="lblRsz" Width="130" Text="Address :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAddr" runat="server" SkinID="txtRsz" Height="50" TabIndex="17"
                                TextMode="MultiLine">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblCity" runat="server" SkinID="lbl" Text="City* :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCity" runat="server" SkinID="txt" TabIndex="18">
                            </asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblcity1" runat="server" SkinID="lbl" Text="City :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtcity1" runat="server" SkinID="txt" TabIndex="19">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDistrict" runat="server" SkinID="lbl" Text="District* :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDistrict" runat="server" SkinID="txt" TabIndex="20">
                            </asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblDistrict1" runat="server" SkinID="lbl" Text="District :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDistrict1" runat="server" SkinID="txt" TabIndex="21">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblCountry" runat="server" SkinID="lbl" Text="Country* :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCountry" AutoPostBack="true" runat="server" TabIndex="22"
                                SkinID="ddl" DataSourceID="ObjCountry" DataTextField="country" DataValueField="CountryId">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCountry" runat="server" SelectMethod="GetCountry" TypeName="DL_BuyerMaster">
                            </asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblCountry1" runat="server" SkinID="lbl" Text="Country :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCountry1" AutoPostBack="true" runat="server" TabIndex="23"
                                SkinID="ddl" DataSourceID="ObjCountry1" DataTextField="country" DataValueField="CountryId">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCountry1" runat="server" SelectMethod="GetCountry" TypeName="DL_BuyerMaster">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblState" runat="server" SkinID="lbl" Text="State* :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlState" runat="server" SkinID="ddl" TabIndex="24" DataSourceID="ObjState"
                                DataTextField="StateName" DataValueField="StateId" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjState" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetStateEmpMaster" TypeName="DL_BuyerMaster">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlCountry" PropertyName="SelectedValue" Name="CountryId"
                                        DefaultValue="0" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblState1" runat="server" SkinID="lbl" Text="State :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlState1" runat="server" TabIndex="25" SkinID="ddl" DataSourceID="ObjState1"
                                DataTextField="StateName" DataValueField="StateId" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjState1" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetStateEmpMaster" TypeName="DL_BuyerMaster">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlCountry1" PropertyName="SelectedValue" Name="CountryId"
                                        DefaultValue="0" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <asp:Label ID="lblAccountInfo" runat="server" Text="Account Info" SkinID="lblBlackRsz"
                                Width="150" Visible="True"></asp:Label>
                        </td>
                    </tr>
                </table>
                <hr />
                <table>
                    <tr>
                        <td align="right">
                            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblBankName" runat="server" SkinID="lblRsz" Width="180" Text="Bank Name &nbsp;:&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBankName" runat="server" SkinID="txt" TabIndex="26">
                            </asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblAccountNo" runat="server" SkinID="lblRsz" Width="150" Text="Account Number &nbsp;:&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAccountNo" runat="server" SkinID="txt" TabIndex="27">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBankBranch" runat="server" SkinID="lbl" Text="Bank Branch :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBankBranch" runat="server" SkinID="txt" TabIndex="28">
                            </asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblType" runat="server" SkinID="lblRsz" Width="150" Text="Type Of Account &nbsp;:&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlType" runat="server" SkinID="ddl" DataSourceID="objAccountType"
                                DataTextField="data" DataValueField="LookUPautoid" TabIndex="29">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="objAccountType" runat="server" SelectMethod="GetDDlAccountType"
                                TypeName="DL_BuyerMaster"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblIFSC" runat="server" SkinID="lbl" Text="IFSC Code :&nbsp;&nbsp;">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtIFSC" runat="server" SkinID="txt" TabIndex="30">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="btnTd" colspan="4">
                            <asp:Button ID="Btnadd" TabIndex="83" runat="server" Text="ADD" CommandName="ADD"
                                CausesValidation="true" SkinID="btn" OnClientClick="return Validate();" CssClass="ButtonClass">
                            </asp:Button>
                            <asp:Button ID="Btnview" TabIndex="83" runat="server" Text="VIEW" CommandName="VIEW"
                                CausesValidation="true" SkinID="btn" CssClass="ButtonClass"></asp:Button>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="msginfo" SkinID="lblRed" runat="server"></asp:Label>
                <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                <br />
                <br />
            </center>
            </a> <a name="bottom">
                <center>
                    <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="800px" Height="300px">
                        <asp:GridView ID="GVBuyerMaster" runat="server" SkinID="GridView" AllowPaging="true"
                            AutoGenerateColumns="False" PageSize="10" Visible="true" AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" Font-Size="Small" runat="server" CausesValidation="False"
                                            CommandName="Edit" Text="Edit" />
                                        <asp:LinkButton ID="LinkButton2" Font-Size="Small" runat="server" CausesValidation="False"
                                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Photo" HeaderStyle-Font-Size="Small" ControlStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Image ID="LabelEmp_Photo" ImageUrl='<%# Bind("Photos") %>' runat="server"></asp:Image>
                                        <asp:Label Visible="false" ID="LabelPhotos" runat="server" Text='<%# Bind("Photos") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="First Name" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    SortExpression="Company_Name">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("BuyerID") %>' />
                                        <asp:Label ID="lblFirstName" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Company_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true"></ItemStyle>
                                    <%-- <HeaderStyle HorizontalAlign="Center" />--%>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    SortExpression="LastName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastName" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("LastName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Buyer Code" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    SortExpression="Company_Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBuyerCode" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Company_Code") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TIN" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTin" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("TIN") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CST No" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCst" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("CST_No") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PAN No" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPan" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Pan") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact No.1" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContact1" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Contact_Number1") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact No.2" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContact2" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Contact_Number2") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email 1" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail1" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Email") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email 2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail2" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Email2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fax No." HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFaxNo" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Fax_Number") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Person2" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="ContactPerson2" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Introducer") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Introducer" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntro" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("ContactPerson2") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddress" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Address") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Residence Address" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Font-Size="Small" ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblResAddr" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("ResAddress") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    ControlStyle-Width="150px" SortExpression="City">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCity" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("City") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Residence City" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Font-Size="Small" ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblResCity" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("City2") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" District" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistrict" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("District") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="District1" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblResDistrict" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("District2") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    SortExpression="StateName" ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblState" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("StateName") %>' />
                                        <asp:HiddenField ID="lblStateId" runat="server" Value='<%# Bind("State") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Residence State" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Font-Size="Small" ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblResState" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("StateName2") %>' />
                                        <asp:HiddenField ID="lblStateId2" runat="server" Value='<%# Bind("State2") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    SortExpression="Country" ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCID1" Visible="false" runat="server" Text='<%# Bind("CID1") %>' />
                                        <asp:Label ID="lblCountry" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("Country") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Residence Country" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Font-Size="Small" ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCID2" Visible="false" runat="server" Text='<%# Bind("CID2") %>' />
                                        <asp:Label ID="lblResCountry" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("CName") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBankName" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("BankName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank Branch" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Font-Size="Small" ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBankBranch" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("BankArea") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account No" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccNo" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("AcNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type of Account" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Font-Size="Small" ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTypeOfAccount" Font-Size="Small" runat="server" Visible="false"
                                            Text='<%# Bind("TypeOfAc") %>'></asp:Label>
                                        <asp:Label ID="lblAccttype" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("TypeOfAccount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IFSC Code" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Small"
                                    ControlStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIFSC" Font-Size="Small" runat="server" Width="150" Text='<%# Bind("IFSC") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="true" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <div align="right">
                    <a href="#Top">
                        <asp:Image ID="Image" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
