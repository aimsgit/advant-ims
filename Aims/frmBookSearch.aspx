<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBookSearch.aspx.vb"
    Inherits="frmBookSearch" Title="Book Search" %>

<%--<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Book Search</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlBranchType.ClientID %>"), 'Branch Name');
            if (msg != "") {
                document.getElementById("<%=ddlBranchType.ClientID %>").focus();
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
                <div>
                    <%--      <center>
                    <h1 class="headingTxt">
                        BOOK SEARCH
                    </h1>
                </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <br />
                    <br />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBranchType" runat="server" Text="Branch Name* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBranchType" TabIndex="1" runat="server" SkinID="ddlRsz"
                                        AutoPostBack="True" DataSourceID="ObjBranch" DataTextField="BranchName" DataValueField="BranchCode">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="insertBranchCombo" TypeName="DLIssueLibrary"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                        DataValueField="DeptID" SkinID="ddlRsz" Width="250px" TabIndex="2">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="BookMasterDB" SelectMethod="GetDeptType">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="Subject :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="cmbSubject" runat="server" DataSourceID="odsSubject" DataTextField="Subject_Name"
                                        DataValueField="Subjectid" SkinID="ddlRsz" TabIndex="3" AppendDataBoundItems="true"
                                        Width="250px">
                                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsSubject" runat="server" SelectMethod="subjectcombo"
                                        TypeName="BookManager"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="Book Name :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBookName" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="Author Name :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAuthor" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Publisher Name :&nbsp;&nbsp;" SkinID="lbl"
                                        Width="104px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPublisher" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblisbn" runat="server" Text="ISBN No :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtisbn" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblclassification" runat="server" Text="Classification No :&nbsp;&nbsp;" SkinID="lblRsz" Width ="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtclassification" runat="server" SkinID="txt" TabIndex="8"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Label ID="Label6" runat="server" ForeColor="Maroon" Text="* please enter any one of the field."></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="btnTd" align="center">
                                    <asp:Button ID="btnSearch" runat="server" Text="SEARCH" SkinID="btn" TabIndex="8"
                                        CssClass="ButtonClass" OnClientClick="return Validate();" />
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
                                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <div>
                                            <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <%-- <td colspan ="2">
                    <cc1:msgBox ID="MsgBox1"  runat="server"></cc1:msgBox>
                </td>--%>
                            </tr>
                        </table>
            </a>
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                            <asp:GridView ID="GVBookSearch" runat="server" AutoGenerateColumns="False" DataKeyNames="Book_ID"
                                SkinID="Gridview" AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                <Columns>
                                    <asp:TemplateField ShowHeader="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Edit"
                                                Text="Issue"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Book_ID" HeaderText="Book_ID" InsertVisible="False" ReadOnly="True"
                                        SortExpression="Book_ID" Visible="False" />
                                    <asp:BoundField DataField="DeptName" HeaderText="Department" SortExpression="DeptName" />
                                    <%--<asp:BoundField DataField="BookName" HeaderText="Book Name" SortExpression="BookName" />--%>
                                    <asp:TemplateField HeaderText="Book Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookName" runat="server" Text='<%# Bind("BookName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Book Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBookCode" runat="server" Text='<%# Bind("BookCode") %>'></asp:Label>
                                            <asp:Label ID="lblBookid" runat="server" Visible="false" Text='<%# Bind("Book_IDAuto") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Classification No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCno" runat="server" Text='<%# Bind("Classification") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="BookCode" HeaderText="Book Code" SortExpression="BookCode" />--%>
                                    <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                                    <asp:BoundField DataField="BookPublisher" HeaderText="BookPublisher" SortExpression="BookPublisher" />
                                    <asp:TemplateField HeaderText="Price" SortExpression="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="LblPrice" runat="server" Text='<%# Bind("Price","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Right" Width="50" />
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="IssueBook" HeaderText="IssueBook" SortExpression="IssueBook" ItemStyle-HorizontalAlign="Center"  />
                                    <asp:BoundField DataField="ReturnBook" HeaderText="ReturnBook" SortExpression="ReturnBook" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Pending" HeaderText="Pending" ReadOnly="True" SortExpression="Pending" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Qty" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Avail" HeaderText="Available Book" ReadOnly="True" SortExpression="Avail" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="RackNo" HeaderText="Rack No" ReadOnly="True" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="ShelfNo" HeaderText="Shelf No" ReadOnly="True" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="ISBN" HeaderText="ISBN No" ReadOnly="True" ItemStyle-HorizontalAlign="Center" />
                                    
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                            MinimumPrefixLength="1" ServiceMethod="GetWordList" ServicePath="AutoComplete.asmx"
                            TargetControlID="txtBookName">
                        </ajaxToolkit:AutoCompleteExtender>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100"
                            MinimumPrefixLength="1" ServiceMethod="GetWordList2" ServicePath="AutoComplete.asmx"
                            TargetControlID="txtAuthor">
                        </ajaxToolkit:AutoCompleteExtender>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="100"
                            MinimumPrefixLength="1" ServiceMethod="GetWordList1" ServicePath="AutoComplete.asmx"
                            TargetControlID="txtPublisher">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                </tr>
            </table>
            </center> </div> <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
