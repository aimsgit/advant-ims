<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmMaintenanceType.aspx.vb"
    Inherits="frmMaintenanceType" Title="Maintenance Type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Maintenance Type</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    &nbsp;<script language="JavaScript" type="text/javascript">

              function Validate() {
                  var msg = Valid();
                  if (msg != true) {
                      if (navigator.appName == "Microsoft Internet Explorer") {
                          document.getElementById("<%=msginfo.ClientID %>").innerText = msg;
                          document.getElementById("<%=lblmsg.ClientID%>").innerText = "";
                          return false;
                      }
                      else if (navigator.appName == "Netscape") {
                          document.getElementById("<%=msginfo.ClientID %>").textContent = msg;
                          document.getElementById("<%=lblmsg.ClientID%>").textContent = "";
                          return false;
                      }
                  }
                  return true;
              }
              //Function for Multilingual Validations
              //Created By Ajit Kumar Singh


              function Valid() {

                  var msg, a;
                  msg = NameField100Mul(document.getElementById("<%=txtType.ClientID %>"));
                  if (msg != "") {
                      document.getElementById("<%=txtType.ClientID %>").focus();
                      a = document.getElementById("<%=lbltype.ClientID %>").innerHTML;
                      msg = Spliter(a) + " " + ErrorMessage(msg);
                      return msg;
                  }

                  msg = Field250MulN(document.getElementById("<%=txtRemarks.ClientID %>"));
                  if (msg != "") {
                      document.getElementById("<%=txtRemarks.ClientID %>").focus();
                      a = document.getElementById("<%=lblremarks.ClientID %>").innerHTML;
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
                <div>
                    <%-- <center>
                        <h1 class="headingTxt">
                            MAINTENANCE TYPE
                        </h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    &nbsp &nbsp
                    <center>
                        <table class="custTable">
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lbltype" runat="server" SkinID="lblRsz" Width="180px" Text="Maintenance Type* :&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtType" runat="server" SkinID="txtRsz" TabIndex="1" Width="200"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblremarks" runat="server" SkinID="lbl" Text="Remarks :&nbsp;"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" SkinID="txtRsz" TabIndex="2" Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <center>
                                        <td class="btnTd" colspan="3">
                                            <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                               CommandName="ADD" TabIndex="3" Text="ADD" CausesValidation="true" SkinID="btn" />&nbsp;
                                            <asp:Button ID="btnview" runat="server" CssClass="ButtonClass" CausesValidation="False"
                                               CommandName="VIEW" SkinID="btn" TabIndex="4" Text="VIEW" />
                                            &nbsp;
                                        </td>
                                    </center>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <center>
                                        <div>
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                                        </div>
                                    </center>
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
                                <td>
                                    <center>
                                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="350px" Height="300px">
                                            <asp:GridView ID="GridView1" runat="server" SkinID="GridView" EmptyDataText=" " AllowPaging="True"
                                                Visible="True" AutoGenerateColumns="False" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                Text="Edit" Font-Underline="False"></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                                Text="Delete" Visible="false" Font-Underline="False"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Maintenance Type" SortExpression="MaintenanceType">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="MID" runat="server" Value='<%# Bind("M_ID") %>'></asp:HiddenField>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("MaintenanceType") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Width="200px" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" Wrap="true" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 20px">
                                    <asp:ObjectDataSource ID="ObjMaintenanceType" runat="server" OldValuesParameterFormatString="original_{0}"
                                        DeleteMethod="ChangeFlag" UpdateMethod="UpdateRecord" SelectMethod="GetMaintenanceType"
                                        InsertMethod="InsertRecord" DataObjectTypeName="MaintenanceType" TypeName="MaintenanceTypeManager">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 20px">
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="FormView1" EventName="ItemCommand"></asp:AsyncPostBackTrigger>
--%>
        </Triggers>
    </asp:UpdatePanel>

</form>
</body>
</html>

