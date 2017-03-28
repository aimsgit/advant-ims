<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="FeeStructure_New.aspx.vb"
    Inherits="FeeStructure_New" Title="FEE STRUCTURE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>FEE STRUCTURE</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        function Valid() {
            var msg;
            msg = DropDownForZero(document.getElementById("<%=ddlacadmeic_year.ClientID%>"), 'Academic Year')
            if (msg != "") {
                document.getElementById("<%=ddlacadmeic_year.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlbatch.ClientID%>"), 'Batch')
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID%>").focus();
                return msg;
            }
            
            msg = DropDownForZero(document.getElementById("<%=ddlcat.ClientID%>"), 'Student Category')
            if (msg != "") {
                document.getElementById("<%=ddlcat.ClientID%>").focus();
                return msg;
            }
            msg = DropDownForZero(document.getElementById("<%=ddlfee_head.ClientID%>"), 'Fee Head')
            if (msg != "") {
                document.getElementById("<%=ddlfee_head.ClientID%>").focus();
                return msg;
            }
            msg = FeesField(document.getElementById("<%=txtamt.ClientID %>"), 'Fee Amount')
            if (msg != "") {
                document.getElementById("<%=txtamt.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtduedate.ClientID%>"), 'Due Date')
            if (msg != "") {
                document.getElementById("<%=txtduedate.ClientID%>").focus();
                return msg;
            }

            return true;
        }
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblE.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblS.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblE.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblS.ClientID%>").textContent = "";
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
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
                <div>
                    <%--<center>
                        <h1 class="headingTxt">
                            FEE STRUCTURE
                        </h1>
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
                                <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Academic Calendar Year*^  :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlacadmeic_year" runat="server" AutoPostBack="True" DataSourceID="odsaccyear"
                                    DataTextField="AcademicYear" DataValueField="id" SkinID="ddl" TabIndex="1" AppendDataBoundItems="true" >
                                      <asp:ListItem Value ="0" Text ="Select" Selected ="True"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsaccyear" runat="server" SelectMethod="GetAcademicCombo"
                                    TypeName="BLNew_stdMarks"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblbatch" runat="server" Text="Batch*^ :&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlbatch" runat="server" TabIndex="2" DataSourceID="odsbatch"
                                    SkinID="ddlRsz" DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="true"
                                    Width="200">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsbatch" runat="server" SelectMethod="getBatchCombo" TypeName="BLNew_stdMarks">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlacadmeic_year" Name="A_Year" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                &nbsp;&nbsp;<asp:Label ID="lblcourse" runat="server" Text="Course :" SkinID="lblRsz"
                                    Width="60px"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;<asp:TextBox ID="txtCourseName" runat="server" Enabled="false" SkinID="txtRsz"
                                    Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblsem" runat="server" Text="Semester :&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlsem" runat="server" SkinID="ddl" TabIndex="3" DataSourceID="odssemester"
                                    DataTextField="SemName" DataValueField="SemCode">
                                </asp:DropDownList>
                                <%--<asp:ObjectDataSource ID="odssemester" runat="server" SelectMethod="GVSemesterComboUser"
                                TypeName="feeStructureDL"></asp:ObjectDataSource>--%>
                                <asp:ObjectDataSource ID="odssemester" runat="server" SelectMethod="SemesterCombo12"
                                    TypeName="feeCollectionDL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                            DbType="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblstudent_cat" runat="server" Text="Student Category*^ :&nbsp;" SkinID="lblRsz"
                                    Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlcat" runat="server" SkinID="ddl" TabIndex="4" DataSourceID="odsCategory"
                                    DataTextField="CategoryName" DataValueField="Category_Id" AppendDataBoundItems="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsCategory" runat="server" SelectMethod="getCategory"
                                    TypeName="feeStructureDL"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblfeehead" runat="server" Text="Fee Head* :&nbsp;" SkinID="lblRsz"
                                    Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlfee_head" runat="server" SkinID="ddl" TabIndex="5" DataSourceID="odsfeehead"
                                    DataTextField="Fee_HeadType" DataValueField="Fee_Head_IDAuto" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsfeehead" runat="server" SelectMethod="GetFeeHeads" TypeName="feeStructureDL">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblamt" runat="server" Text="Fee Amount* :&nbsp;" SkinID="lblRsz"
                                    Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtamt" runat="server" TabIndex="6" MaxLength="9" SkinID="txt"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="filterAmountPaid" runat="server" FilterType="Custom"
                                    TargetControlID="txtamt" FilterMode="ValidChars" ValidChars="1234567890.">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbldate" runat="server" Text="Due Date :&nbsp;" SkinID="lblRsz" Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtduedate" runat="server" SkinID="txt" TabIndex="7"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtduedate_CalendarExtender" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="txtduedate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td class="btnTd">
                                <asp:Button ID="btnadd" runat="server" CssClass="ButtonClass" SkinID="btn" Text="ADD"
                                    TabIndex="8" ValidationGroup="Validate" OnClientClick="return Validate();" />
                                &nbsp;
                                <asp:Button ID="btnview" runat="server" CssClass="ButtonClass" SkinID="btn" Text="VIEW"
                                    TabIndex="9" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                         <tr>
                            <td colspan="2" align="right">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..." SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblE" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblS" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </a>
            <center>
                <table class="custtable">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="gvfee_stuct" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Style="overflow: auto; width: 760px" Visible="False"
                                        Width="621px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Edit"
                                                        Text="Edit" TabIndex="10"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" TabIndex="11"></asp:LinkButton>
                                                    <br />
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Batch" SortExpression="Batch_No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblayrs" Visible="false" runat="server" Text='<%# Bind("AcademicYear_id") %>' />
                                                    <asp:Label ID="Lableid" Visible="false" runat="server" Text='<%# Bind("id") %>' />
                                                    <asp:Label ID="lblbatchid" Visible="false" runat="server" Text='<%# Bind("BatchID") %>' />
                                                    <asp:Label ID="lblBatchNo" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Semester" SortExpression="SemName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsemid" Visible="false" runat="server" Text='<%# Bind("Semester_ID") %>' />
                                                    <asp:Label ID="lblsemname" runat="server" Text='<%# Bind("SemName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category" SortExpression="CategoryName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcatid" Visible="false" runat="server" Text='<%# Bind("Category") %>' />
                                                    <asp:Label ID="lblcatname" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="FeeHead" SortExpression="Fee_HeadType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfeeid" Visible="false" runat="server" Text='<%# Bind("FeeHead_ID") %>' />
                                                    <asp:Label ID="lblfeehead" runat="server" Text='<%# Bind("Fee_HeadType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamt" runat="server" Text='<%# Bind("Amount","{0:0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="Right" Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DueDate" SortExpression="Due_Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblduedate" runat="server" Text='<%# Bind("Due_Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

