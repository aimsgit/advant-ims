<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PerformanceParameter.aspx.vb"
    Inherits="PerformanceParameter" Title="Appraisal Parameter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Appraisal Parameter</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

        function Valid() {

            var msg, a;
            msg = DropDownMul(document.getElementById("<%=ddlAppraisalP.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlAppraisalP.ClientID %>").focus();
                a = document.getElementById("<%=lblPerfCycle.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = Feild250(document.getElementById("<%=txtPerfCycle.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=txtPerfCycle.ClientID %>").focus();
                a = document.getElementById("<%=lblDDNo.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }


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
      
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblPerfCycle" runat="server" Text="Appraisal Cycle*&nbsp;:&nbsp;"
                                SkinID="lblRsz" Width="200px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlAppraisalP" TabIndex="1" runat="server" SkinID="ddl" AutoPostBack="True"
                                DataSourceID="ObjAppraisal" DataTextField="AppraisalCycle" DataValueField="ACID">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjAppraisal" runat="server" SelectMethod="GetAppraisalCyclePara"
                                TypeName="PerformanceAppraisalDL"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDDNo" runat="server" SkinID="lblRsz" Text="No Of Parameters*&nbsp;:&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPerfCycle" runat="server" SkinID="txt" TabIndex="1"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789" TargetControlID="txtPerfCycle">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <br />
            <center>
                <table>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnGenrate" runat="server" Text="GENERATE" CssClass="ButtonClass"
                                CommandName="GENERATE" OnClientClick="return Validate();" CausesValidation="true"
                                SkinID="btnRsz" TabIndex="4" />
                            <asp:Button ID="btnView" runat="server" CausesValidation="false" Text="VIEW" CssClass="ButtonClass"
                                CommandName="VIEW" SkinID="btn" />
                            <asp:Button ID="btnClear" runat="server" CausesValidation="false" Text="CLEAR" CssClass="ButtonClass"
                                CommandName="CLEAR" SkinID="btn" OnClientClick="return confirm('Do you want to Clear the record(s)?')" />
                            <asp:Button ID="BtnUpdate" runat="server" CausesValidation="false" Text="UPDATE"
                                CommandName="UPDATE" CssClass="ButtonClass" SkinID="btn" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed" />
            </center>
            <div>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GVPerformance" runat="server" SkinID="GridView" DataKeyNames=""
                            AllowPaging="true" AutoGenerateColumns="false" PageSize="100" AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField HeaderText="SL. No.">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="lblPId" runat="server" Value='<%# Bind("App_IDAuto") %>' />
                                        <asp:Label ID="lblSlNo" runat="server" Text='<%# Bind("PNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ATTRIBUTES" SortExpression="ParameterName">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtParameterName" TextMode="MultiLine" runat="server" Width="400px"
                                            Text='<%# Bind("ParameterName") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAX">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMax" runat="server" Width="50px" Text='<%# Bind("Max") %>'></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtMax">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MIN">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMin" runat="server" Width="50px" Text='<%# Bind("Min") %>'></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterMode="validChars" ValidChars="0123456789" TargetControlID="txtMin">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </center>
            </div>
            <br />
            <a name="Bottom">
                <div align="right">
                    <a href="#Top">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
