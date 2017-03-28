<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmCourseType.aspx.vb"
    Inherits="frmCourseType" Title="Course Type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Course Type</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">

        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=msginfo.ClientID%>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=msginfo.ClientID%>").textContent = "";

                    return false;
                }
                return true;
            }
        }
        //Function for Multilingual Validations
        //Created By Ajit Kumar Singh


        function Valid() {

            var msg, a;
            msg = NameField100Mul(document.getElementById("<%=CourseTypeTextBox.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=CourseTypeTextBox.ClientID %>").focus();
                a = document.getElementById("<%=Label12.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            return true;
        }
//        msg = NameField100Mul(document.getElementById("<%=ddlDuration.ClientID %>"));
//            if (msg != "") {
//                document.getElementById("<%=ddlDuration.ClientID %>").focus();
//                a = document.getElementById("<%=lblDuration.ClientID %>").innerHTML;
//                msg = Spliter(a) + " " + ErrorMessage(msg);
//                return msg;
//            }
//            return true;
//        }

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

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <center>
        <div class="mainBlock">
            <%-- <center>
                <h1 class="headingTxt">
                    COURSE TYPE</h1>
            </center>--%>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
        </div>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <center>
                    <table>
                        <tr align="center">
                            <td align="right">
                                <asp:Label ID="Label12" runat="server" SkinID="lblRsz" Width="200" Text="Course Type* :"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:TextBox ID="CourseTypeTextBox" runat="server" Text='<%# Bind("CourseType") %>'
                                    AutoCompleteType="Disabled" TabIndex="1" SkinID="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="center">
                            <td align="right">
                                <asp:Label ID="lblCourseLevel" runat="server" Width="200" SkinID="lblRsz" Text="Course Level :"></asp:Label>
                            </td>
                            <td align="left">
                              &nbsp;&nbsp;<asp:TextBox ID="TxtCourseLevel" runat="server" TabIndex="2" SkinID ="txt"
                                    Width="200"></asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr align="center">
                            <td align="right">
                                <asp:Label ID="lblDuration" runat="server" Width="200" SkinID="lblRsz" Text="Duration(yrs)* :"></asp:Label>
                            </td>
                            <td align="left">
                              &nbsp;&nbsp;<asp:DropDownList ID="ddlDuration" TabIndex="3" runat="server" SkinID="ddlRsz" DataTextField="data"
                                    DataValueField="LookUpAutoID" DataSourceID="ObjDuration" AppendDataBoundItems="true" Width ="152px">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDuration" runat="server" TypeName="CourseTypeDB" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetDurationDDL"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                            </td>
                            <tr align="center">
                                <td class="btnTd" colspan="2">
                                    <br />
                                    <asp:Button ID="btnAdd" runat="server" CausesValidation="true" CommandName="ADD"
                                        CssClass="ButtonClass" OnClientClick="return Validate();" SkinID="btn" TabIndex="4"
                                        Text="ADD" ValidationGroup="edit" />
                                    &nbsp<asp:Button ID="btnView" runat="server" CausesValidation="false" CssClass="ButtonClass"
                                        CommandName="VIEW" SkinID="btn" TabIndex="5" Text="VIEW" />
                                </td>
                            </tr>
                        </tr>
                    </table>
                </center>
                <center>
                    <br />
                    <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                    <br />
                    <br />
                </center>
                <div>
                    <center>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="400px" Height="300px">
                            <asp:GridView ID="GVCourseType" runat="server" SkinID="GridView" DataKeyNames="CourseType_ID"
                                AllowPaging="True" AutoGenerateColumns="False" PageSize="100" AllowSorting="True"
                                EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                Visible="false" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CourseType" SortExpression="CourseType">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="CID" runat="server" Value='<%# Bind("CourseType_ID") %>' />
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("CourseType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Course Level">
                                        <ItemTemplate>
                                           <asp:Label ID="lblCL" runat="server" Text='<%# Bind("CourseLevel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Duration">
                                        <ItemTemplate>
                                             <asp:Label ID="Label1" runat="server" Text='<%# Bind("DurationID") %>' Visible ="false" ></asp:Label>
                                            <asp:Label ID="lblDUR" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                    <asp:ObjectDataSource ID="ObjCourseType" runat="server" DeleteMethod="ChangeFlag"
                        UpdateMethod="UpdateMethod" SelectMethod="GetcourseTypes" OldValuesParameterFormatString="original_{0}"
                        InsertMethod="InsertMethod" DataObjectTypeName="CourseType" TypeName="CourseTypeB">
                        <SelectParameters>
                            <asp:Parameter Name="id" Type="Int64" DefaultValue="0" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <a name="bottom">
                    <div align="right">
                        <a href="#top">
                            <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                    </div>
                </a>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>

</form>
</body>
</html>
