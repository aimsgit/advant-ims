<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DayBookDetails.aspx.vb"
    Inherits="DayBookDetails" Title="Day Book Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Day Book Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div>
        <center>
            <h1 class="headingTxt">
                DAY BOOK DETAILS
            </h1>
        </center>
        <center>
            <table class="custTable">
                <tr>
                    <td class="btnTd">
                        <asp:Button ID="Button1" runat="server" TabIndex="-1" Text="BACK" SkinID="btn" CssClass="btnStyle" />
                        <asp:Button ID="btnReport" runat="server" CausesValidation="False" SkinID="btn" TabIndex="15"
                            Text="REPORT" CssClass="btnStyle" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="horizontal" Width="700px">
                            <asp:GridView ID="GVDayBookDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="Expense_ID"
                                Height="100px" DataSourceID="ObjExp" EmptyDataText="No Records to Display." SkinID="GRIDVIEW"
                                AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="Update"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                Text="Delete"></asp:LinkButton></ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Entry Date" SortExpression="Entry_Date">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Entry_Date","{0:dd-MMM-yyyy}") %>'
                                                Width="60px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="EID" runat="server" Value='<%# Bind("Expense_ID") %>' />
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Entry_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transaction Code" SortExpression="Account_Head">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Head_Type") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Head_Type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Description" SortExpression="Item">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Item") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bill No" SortExpression="Bill_No">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Bill_No") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("Bill_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bill Date" SortExpression="Bill_Date">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Bill_Date") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label12" runat="server" Text='<%# Bind("Bill_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Amount In" SortExpression="Amt_In">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAmountIn" runat="server" Text='<%# Bind("Amt_In") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Amt_In") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount Out" SortExpression="Amt_Out">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAmountOut" runat="server" Text='<%# Bind("Amt_Out") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Amt_Out") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="PartyType" SortExpression="PartyType">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TxtPT" runat="server" Text='<%# Bind("Party_Type_N") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Party_Type_N") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PartyName" SortExpression="PartyName">
                                        <EditItemTemplate>
                                            <asp:Label ID="LblParty" runat="server" Text='<%# Eval("party_Name") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("party_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label14" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque/DD No" SortExpression="ChequeNo">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("ChequeNo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("ChequeNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bank Name" SortExpression="Bank Name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label13" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Currency Name" SortExpression="Currency Name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("Currency_Name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Currency_Code") %>'></asp:Label>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Currency_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="ExchangeRate" SortExpression="ExchangeRate">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ExchangeRate") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("ExchangeRate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                            <%--   <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Sahaj_IMS.mdb"
                        DeleteCommand="Update [Expenses] set Del_Flag=-1 WHERE [Expense_ID] = ?" SelectCommand="SELECT DispGV_Expenses.* FROM DispGV_Expenses">
                        <DeleteParameters>
                            <asp:Parameter Name="Expense_ID" Type="int16" />
                        </DeleteParameters>
                    </asp:AccessDataSource>--%>
                            <asp:ObjectDataSource ID="ObjExp" runat="server" TypeName="DayBookManager" SelectMethod="GetDayBookGV"
                                DeleteMethod="ChangeFlag" DataObjectTypeName="DayBookEL">
                                <DeleteParameters>
                                    <asp:Parameter Name="id" ConvertEmptyStringToNull="true" Type="int32" DefaultValue="0" />
                                </DeleteParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblmsg" runat="server" Text="Label" Width="350px" ForeColor="RED"></asp:Label>
                    </td>
                </tr>
            </table>
        </center>
    </div>

</form>
</body>
</html>