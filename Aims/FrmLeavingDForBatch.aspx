<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmLeavingDForBatch.aspx.vb"
    Inherits="FrmLeavingDForBatch" Title="Leaving Date for Batch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Leaving Date for Batch</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="JavaScript" type="text/javascript">
  
        function Valid() {
            var msg, a;
            msg = DropDownForZero(document.getElementById("<%=cmbBatch.ClientID %>"), 'Batch');
            if (msg != "") {
                document.getElementById("<%=cmbBatch.ClientID %>").focus();
               
                return msg;
            }
           
            return true;
        }
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
        function Validate1() {
            var msg = Valid1();
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
        function Valid1() {
            var msg, a;
            msg = ValidateDate(document.getElementById("<%=txtLod.ClientID %>"), 'Leaving Date');
            if (msg != "") {
                document.getElementById("<%=txtLod.ClientID %>").focus();

                return msg;
            }
            return true;
        }
        
          

    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <h1 class="headingTxt">
                    LEAVING DATE FOR BATCH
                </h1>
            </center>
            <br />
            <br />
            <center>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cmbBatch" TabIndex="6" runat="server" SkinID="ddl" AutoPostBack="True"
                                Width="185px" DataValueField="BatchID" DataTextField="Batch_No" DataSourceID="ObjBatch">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBatch" runat="server" TypeName="BLNew_stdMarks" SelectMethod="GetBatchCombo2">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblLOD" runat="server" Text="Leaving Date* :&nbsp;" SkinID="lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtLod" runat="server" TabIndex="10" SkinID="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txtLod"
                                Format="dd-MMM-yyyy" SkinID="CalendarView">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="btntd" align="center">
                            <asp:Button ID="BtnView" TabIndex="69" runat="server" OnClientClick="return Validate();"
                                Text="VIEW" SkinID="btn" CommandName="VIEW" CssClass="ButtonClass"></asp:Button>
                            <asp:Button ID="btnUpdate" Enabled ="false"  runat="server" Text="UPDATE" OnClientClick="return Validate1();"  SkinID="btn" CssClass="ButtonClass ">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <br />
                <asp:Label ID="lblMsg" runat="server" SkinID="lblGreen"></asp:Label>
                <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                <br />
                <br />
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="700px" Height="300px">
                    <asp:GridView ID="G1" runat="server" SkinID="GridView" AllowPaging="True" Visible="True"
                        AutoGenerateColumns="False"  PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                        Width="50px" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkLeavingDate" runat="server" TabIndex="9" />
                                    <asp:Label ID="IID" Visible="false" runat="server" Text='<%# Bind("Std_Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblstdcode"  runat="server" Text='<%# Bind("StdCode") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblstdname" runat="server" Text='<%# Bind("StdName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leaving Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblLvDate" runat="server" Text='<%# Bind("LeavingDate","{0:dd-MMM-yyyy}") %>' />
                                </ItemTemplate>
                                <ItemStyle Wrap="false" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>
