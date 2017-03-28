<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBookMaster.aspx.vb"
    Inherits="frmBookMaster" Title="Book Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Book Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>


    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = NameField250E(document.getElementById("<%=BookNameTextBox.ClientID%>"), 'Book Name');
            if (msg != "") {
                document.getElementById("<%=BookNameTextBox.ClientID%>").focus();
                return msg;
            }
            msg = CodeField(document.getElementById("<%=BookCodeTextBox.ClientID%>"), 'Book Code');
            if (msg != "") {
                document.getElementById("<%=BookCodeTextBox.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtrcvdate.ClientID%>"), 'Receive Date');
            if (msg != "") {
                document.getElementById("<%=txtrcvdate.ClientID%>").focus();
                return msg;
            }
            msg = FeesFieldN(document.getElementById("<%=txtPages.ClientID%>"), 'Pages');
            if (msg != "") {
                document.getElementById("<%=txtPages.ClientID%>").focus();
                return msg;
            }
            //            msg = Field30(document.getElementById("<%=txtQuantity.ClientID%>"), 'Quantity');
            //            if (msg != "") {
            //                document.getElementById("<%=txtQuantity.ClientID%>").focus();
            //                return msg;
            //            }
            msg = FeesFieldN(document.getElementById("<%=txtPrice.ClientID%>"), 'Price');
            if (msg != "") {
                document.getElementById("<%=txtPrice.ClientID%>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsginfo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsginfo.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
        
 
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <div>
                <center>
                    <h1 class="headingTxt">
                        BOOK DETAILS
                    </h1>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="ObjDept" DataTextField="DeptName"
                                    DataValueField="DeptID" SkinID="ddlRsz" Width="250px" TabIndex="1">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDept" runat="server" TypeName="BookMasterDB" SelectMethod="GetDeptType">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Book Name*^ :&nbsp;&nbsp;" SkinID="lbl"
                                    Width="123px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="BookNameTextBox" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="BookNameTextBox">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        
                         <tr>
                            <td align="right">
                                <asp:Label ID="lblClass" runat="server" Text="Classification No^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="150px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtClass" runat="server" SkinID="txt" TabIndex="2"></asp:TextBox>
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtClass">
                                </ajaxToolkit:FilteredTextBoxExtender>--%>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label15" runat="server" SkinID="lblRsz" Text="Book Code/Accession No.*^ :&nbsp;&nbsp;"
                                    Width="250"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="BookCodeTextBox" runat="server" SkinID="txt" MaxLength="50" TabIndex="3"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="BookCodeTextBox">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" SkinID="lbl" Text="ISBN No.&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtISBN" runat="server" SkinID="txt" MaxLength="50" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblrcvdate" runat="server" SkinID="lblRSz" Text="Receive Date^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtrcvdate" MaxLength="11" runat="server" SkinID="txt" TabIndex="5"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtrcvdate">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" SkinID="lbl" Text="Author :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAuthor" runat="server" SkinID="txt" TabIndex="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" SkinID="lbl" Text="Publisher^ :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="BookPublisherTextBox" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="BookPublisherTextBox">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" SkinID="lbl" Text="Subject :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cmbSubject" runat="server" DataSourceID="odsSubject" DataTextField="Subject_Name"
                                    DataValueField="Subjectid" SkinID="ddlRsz" TabIndex="8" AppendDataBoundItems="true"
                                    Width="240px">
                                    <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Edition No :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="BookEditionNoTextBox" runat="server" TabIndex="9"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label13" runat="server" SkinID="lbl" Text="No of pages :&nbsp;&nbsp;"></asp:Label>
                                <br />
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPages" runat="server" SkinID="txt" TabIndex="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label14" runat="server" SkinID="lbl" Text="Price :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPrice" runat="server" SkinID="txt" TabIndex="11"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterMode="validChars" ValidChars=".0123456789" TargetControlID="txtPrice" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label10" runat="server" Visible="false" SkinID="lbl" Text="Quantity* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtQuantity" runat="server" Visible="false" SkinID="txt" TabIndex="12"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    FilterMode="ValidChars" ValidChars="0123456789" TargetControlID="txtQuantity">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblIssueRef" runat="server" SkinID="lblRsz" Text="Issue/Reference :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlIssueRef" runat="server" TabIndex="13" SkinID="ddlRsz" Width="150">
                                    <asp:ListItem Text="Issue" Value="I"></asp:ListItem>
                                    <asp:ListItem Text="Reference" Value="R"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRackNo" runat="server" SkinID="lbl" Text="Rack No :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRackNo" runat="server" SkinID="txt" TabIndex="14"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblShelfNo" runat="server" SkinID="lbl" Text="Shelf No :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtShelfNo" runat="server" SkinID="txt" TabIndex="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="btnTd" align="center">
                                <asp:Button ID="btnSave" runat="server" SkinID="btn" TabIndex="16" Text="ADD" OnClientClick="return Validate();"
                                    CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="btnDetails" runat="server" CausesValidation="False" SkinID="btn"
                                    TabIndex="17" Text="VIEW" CssClass="ButtonClass" />
                            </td>
                        </tr>
                    </table>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                    SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsginfo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <center>
                    <%--<asp:Panel ID="Panel1" runat="server" Width="700px" ScrollBars="horizontal" __designer:wfdid="w45">--%>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                        <asp:GridView ID="GVBookMaster" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            SkinID="GridView" Visible="False" Width="595px" ForeColor="Black" PageSize="100"
                            AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField HeaderText=" " ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                            TabIndex="17" Text="Edit" />
                                        <asp:LinkButton ID="Button3" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Do you want to delete this record?')" TabIndex="18"
                                            Text="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department" SortExpression="DeptName">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Dept" runat="server" Value='<%# Bind("Dept_Id") %>' />
                                        <asp:Label ID="Lbldeptname" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Book Name" SortExpression="BookName">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="BID" runat="server" Value='<%# Bind("Book_Id") %>' />
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("BookName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Classification No">
                                    <ItemTemplate>
                                       <%-- <asp:HiddenField ID="BID" runat="server" Value='<%# Bind("Book_Id") %>' />--%>
                                        <asp:Label ID="lblClassno" runat="server" Text='<%# Bind("Classification") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Book Code/Accession No." SortExpression="BookCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("BookCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ISBN No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblISBN" runat="server" Text='<%# Bind("ISBN","{0:0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Receive Date" SortExpression="ReceiveDate">
                                    <ItemTemplate>
                                        <asp:Label ID="Label20" runat="server" Text='<%# Bind("ReceiveDate","{0:dd-MMM-yyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author">
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("Author") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Book Publisher">
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("BookPublisher") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject Name">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="Label6" runat="server" Visible="false" Value='<%# Bind("Subject_ID") %>' />
                                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Book Edition No">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("BookEditionNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No. Of Pages">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Pages") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblqty" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprice" runat="server" Text='<%# Bind("Price","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Issue/Reference">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIssueRef" runat="server" Text='<%# Bind("IssueRef")  %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rack No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRackNo" runat="server" Text='<%# Bind("RackNo")  %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Shelf No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShelfNo" runat="server" Text='<%# Bind("ShelfNo")  %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <%--<PagerStyle HorizontalAlign="Center" />--%>
                        </asp:GridView>
                    </asp:Panel>
                </center>
                <br />
                <asp:ObjectDataSource ID="odsSubject" runat="server" SelectMethod="subjectcombo"
                    TypeName="BookManager"></asp:ObjectDataSource>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtrcvdate"
                    Format="dd-MMM-yyyy" SkinID="Calendar">
                </ajaxToolkit:CalendarExtender>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

