<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mfg_FrmBatchLot.aspx.vb"
    Inherits="Mfg_FrmBatchLot" Title="Batch Details/Lot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Batch Details/Lot</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = Field50(document.getElementById("<%=txtBatch.ClientID%>"), 'Batch');

            if (msg != "") {
                document.getElementById("<%=txtBatch.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=DDLProduct.ClientID%>"), 'Product');

            if (msg != "") {
                document.getElementById("<%=DDLProduct.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtMfgDate.ClientID%>"), 'Mfg Date');

            if (msg != "") {
                document.getElementById("<%=txtMfgDate.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlProcess.ClientID%>"), 'Process');

            if (msg != "") {
                document.getElementById("<%=ddlProcess.ClientID%>").focus();
                return msg;
            }
         
            return true;
        }
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                document.getElementById("<%=lblRed.ClientID%>").textContent = msg;
                document.getElementById("<%=lblGreen.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <div>
        <center>
            <h1 class="headingTxt">
                <asp:Label ID="Lblheading" Text="BATCH LOT" runat="server"></asp:Label>
            </h1>
        </center>
        <br />
        <br />
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBatch" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Lblprodct" runat="server" SkinID="lbl" Text="Product* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLProduct" runat="server" DataSourceID="ObjProduct" DataTextField="Product_Name"
                                    DataValueField="Product_Id" SkinID="ddl" AutoPostBack="true" TabIndex="2">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMfgDate" runat="server" Text="Mfg Date* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMfgDate" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="3"></asp:TextBox>
                               <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                            TargetControlID="txtMfgDate">
                                        </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblProcess" runat="server" Text="Process* :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProcess" runat="server" DataSourceID="ObjProesss" DataTextField="Process"
                                    DataValueField="ProcessId" SkinID="ddl" AutoPostBack="true" TabIndex="2">
                                </asp:DropDownList>
                            </td>
                            <asp:ObjectDataSource ID="ObjProesss" runat="server" SelectMethod="ProcessComboD"
                                TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblIssueNo" runat="server" SkinID="lblRsz" Text="Issue No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DdlIssueNo" TabIndex="6" runat="server" SkinID="ddl" DataSourceID="ObjIssue"
                                    AutoPostBack="True" DataValueField="Id" DataTextField="StockIssueNo">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjIssue" runat="server" SelectMethod="GetIssueNoDDL" TypeName="Mfg_DLStockReturn">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRemarks" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnadd" runat="server" Text="ADD" SkinID="btn" CausesValidation="true"
                                    TabIndex="6" OnClientClick="return Validate();" CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="btnDet" runat="server" Text="VIEW" SkinID="btn" CausesValidation="False"
                                    TabIndex="7" CssClass="ButtonClass" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <center>
                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="500px" Height="650px">
                        <asp:GridView ID="GVShiftMaster" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editbutton" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" />
                                        <asp:LinkButton ID="Button2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete this record?')" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Batch" SortExpression="Batch">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("Batch_ID") %>'></asp:HiddenField>
                                        <asp:Label ID="lblBatch" runat="server" Text='<%# Bind("Batch") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product" SortExpression="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProduct" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                        <asp:Label ID="lblPID" runat="server" Text='<%# Bind("Product_ID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mfg Date" SortExpression="Mfg Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMfgDate" runat="server" Text='<%# Bind("Mfg_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Process" SortExpression="Process">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProcess" runat="server" Text='<%# Bind("ProcessDesc") %>'></asp:Label>
                                        <asp:Label ID="lblProcessId" runat="server" Text='<%# Bind("Process_Id") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Stock Issue No" SortExpression="Stock Issue No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockIssueNo" runat="server" Text='<%# Bind("StockIssueNo") %>'></asp:Label>
                                         <asp:Label ID="lblStockIssueId" runat="server" Text='<%# Bind("StockIssue_Id") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjProduct" runat="server" SelectMethod="ProductComboD"
                            TypeName="Mfg_DLBatchDetails"></asp:ObjectDataSource>
                    </asp:Panel>
                    <a name="bottom">
                        <div align="right">
                            <a href="#top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                        </div>
                    </a>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</form>
</body>
</html>