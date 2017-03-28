<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmExtraCurricularAchivements.aspx.vb"
    Inherits="frmExtraCurricularAchivements" Title="Extra Curricular Achievements" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Extra Curricular Achievements</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">

    <script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;

                      
            msg = DropDownForZero(document.getElementById("<%=ddlDepartment.ClientID%>"), 'Department');
            document.getElementById("<%=ddlDepartment.ClientID%>");
            if (msg != "") return msg;
            
            
            
            msg = NameField250E(document.getElementById("<%=txtNameofActivity.ClientID%>"), 'Name Of Activity');
            document.getElementById("<%=txtNameofActivity.ClientID%>");
            if (msg != "") return msg;
            msg = ValidateDateN(document.getElementById("<%=txtFromDate.ClientID%>"), 'From Date');
            if (msg != "") {
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                return msg;
            }
            msg = ValidateDateN(document.getElementById("<%=txtToDate.ClientID%>"), 'To Date');
            if (msg != "") {
                document.getElementById("<%=txtToDate.ClientID%>").focus();
                return msg;
            }
            msg = NameField250NE(document.getElementById("<%=txtRemarks.ClientID%>"), 'Remarks');
            document.getElementById("<%=txtRemarks.ClientID%>");
            if (msg != "") return msg;
            return true;
            
              msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtStdCode.ClientID %>"), 'Student Code');
            if (msg != "") {
                document.getElementById("<%=txtStdCode.ClientID %>").focus();
                return msg;
            }
          
            msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtEmpCode.ClientID %>"), 'Employee Code');
            if (msg != "") {
                document.getElementById("<%=txtEmpCode.ClientID %>").focus();
                return msg;
            }
            msg = NameField100N(document.getElementById("<%=txtStdName.ClientID %>"), 'Student Name');
            if (msg != "") {
                document.getElementById("<%=txtStdName.ClientID %>").focus();
                return msg;
            } 
        }
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID%>").textContent = "";

                    return false;
                }
                return true;
            }
        }
       
    </script>

    <script type="text/javascript" language="javascript">

        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtStdCode.ClientID%>"));

        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtStdCode.ClientID%>"));
        }
        //        function SplitName1() {
        //            var text = document.getElementById("<%=txtStdCode.ClientID%>").value;
        //            var split = text.split(':');
        //            if (split.length > 0) {
        //                document.getElementById("<%=txtStdCode.ClientID%>").innerText = split[0];
        //                document.getElementById("<%=txtStdName.ClientID%>").innerText = split[1];
        //                document.getElementById("<%=HidstdId.ClientID%>").innerText = split[2];
        //            }
        //        }

        function ShowImage2() {
            GlbShowSImage(document.getElementById("<%=txtEmpCode.ClientID%>"));
        }
        function HideImage2() {
            GlbHideSImage(document.getElementById("<%=txtEmpCode.ClientID%>"));
        }
      
   
    </script>

    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnDetails" EventName="Click"></asp:AsyncPostBackTrigger>
        </Triggers>--%>
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <center>
                        <h1 class="headingTxt">
                            EXTRA CURRICULAR ACHIEVEMENTS
                        </h1>
                    </center>
                    <%--<center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>--%>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <%-- <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Book Issued To:" SkinID="lbl"></asp:Label>
                            </td>--%>
                                <td colspan="2" align="center">
                                    <asp:RadioButtonList ID="RBUsers" runat="server" SkinID="RD" AutoPostBack="True"
                                        RepeatDirection="Horizontal" TabIndex="1">
                                        <asp:ListItem Value="Student" Selected="True">Student</asp:ListItem>
                                        <asp:ListItem Value="Employee">Employee</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" SkinID="lbl" Text="Department*^ :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" AppendDataBoundItems="true" DataValueField="DeptID"
                                        DataTextField="DeptName" SkinID="ddlRsz" Width="250" TabIndex="1" DataSourceID="objDepartment">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="objDepartment" runat="server" SelectMethod="GetDepartment"
                                        TypeName="ExtraCurricularAchivementsBL"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmpCode" runat="server" SkinID="lblRsz" Text="Employee Code* :&nbsp;&nbsp;"
                                        Width="164px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpCode" runat="server" TabIndex="4" SkinID="txtRsz" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="Server" CompletionInterval="2000"
                                        EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage2"
                                        OnClientPopulating="ShowImage2" ServiceMethod="getEmpCodeExt1" CompletionListCssClass="completeListStyle"
                                        ServicePath="TextBoxExt.asmx" TargetControlID="txtEmpCode">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                                        SkinID="watermark" TargetControlID="txtEmpCode" WatermarkText="Type first 3 characters">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmpName" runat="server" SkinID="lblRsz" Text="Employee Name :&nbsp;&nbsp;"
                                        Width="164px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtRsz" Width="200px" Enabled="False"></asp:TextBox>
                                    <asp:HiddenField ID="StdID" runat="server" Visible="False" />
                                    <asp:HiddenField ID="EmpId" runat="server" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStdCode" runat="server" SkinID="lblRsz" Text="Student Code* :&nbsp;&nbsp;"
                                        Width="164px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStdCode" runat="server" TabIndex="5" SkinID="txtRsz" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" CompletionInterval="2000"
                                        EnableCaching="true" FirstRowSelected="true" MinimumPrefixLength="3" OnClientPopulated="HideImage1"
                                        OnClientPopulating="ShowImage1" ServiceMethod="getStudentIdName1" CompletionListCssClass="completeListStyle"
                                        ServicePath="TextBoxExt.asmx" TargetControlID="txtStdCode">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                        SkinID="watermark" TargetControlID="txtStdCode" WatermarkText="Type first 3 characters">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStdName" runat="server" SkinID="lblRsz" Text="Student Name :&nbsp;&nbsp;"
                                        Width="164px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStdName" runat="server" Enabled="false" SkinID="txtRsz" Width="200px"
                                        AutoCompleteType="Disabled"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" SkinID="lblRsz" Width="200" Text="Name of Activity*^ :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNameofActivity" TextMode="MultiLine" runat="server" SkinID="txt"
                                        MaxLength="200" TabIndex="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="From Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFromDate" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox><ajaxToolkit:CalendarExtender
                                        ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate" Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="To Date :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtToDate" runat="server" SkinID="txt" TabIndex="4"></asp:TextBox><ajaxToolkit:CalendarExtender
                                        ID="CalendarExtender4" runat="server" TargetControlID="txtToDate" Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Remarks :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" SkinID="txt" TabIndex="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" class="btntd">
                                    <br />
                                    <asp:Button ID="btnadd" CausesValidation="true" runat="server" Text="ADD" CommandName="Update"
                                        SkinID="btn" OnClientClick="return Validate()" TabIndex="6" CssClass="ButtonClass">
                                    </asp:Button>
                                    <asp:Button ID="btnview" runat="server" Text="VIEW" CommandName="Cancel" SkinID="btn"
                                        TabIndex="7" CssClass="ButtonClass"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
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
                                <td align="center" colspan="2">
                                    <center>
                                        <div>
                                            <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                                            <asp:Label ID="lblerrmsg" SkinID="lblRed" runat="server"></asp:Label>
                                        </div>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidEmp" runat="server" />
                                    <asp:HiddenField ID="HidBook" runat="server" />
                                    <asp:HiddenField ID="HidstdId" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </center>
            </a>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                    <asp:GridView ID="GridView1" runat="server" SkinID="GridView" AllowPaging="True"
                        AllowSorting="True" Visible="True" AutoGenerateColumns="False" PageSize="100">
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete" Visible="true" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Wrap="False"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department" SortExpression="DeptName">
                                <ItemTemplate>
                                    <asp:Label ID="lblAID" Visible="false" runat="server" Text='<%#Bind("AID") %>'></asp:Label>
                                    <asp:Label ID="lblDeptId" Visible="false" runat="server" Text='<%#Bind("DeptID") %>'></asp:Label>
                                    <asp:Label ID="lblDepartment" Width="150" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Std Name" SortExpression="StdName">
                                <ItemTemplate>
                                 <asp:HiddenField ID="stdHidden" runat="server" Value='<%#Bind("Std_Id") %>'/>
                                    <asp:Label ID="StdCode" Visible ="false" runat="server" Text='<%#Bind("StdCode") %>' />
                                    <asp:Label ID="lblStuName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Wrap="False" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emp Name" SortExpression="Emp_Name">
                                <ItemTemplate>
                                <asp:HiddenField ID="EmpIDHidden" runat="server" Value='<%#Bind("EmpID") %>'/>
                                    <asp:label ID="EmpIdCode" Visible ="false"  runat="server" text='<%#Bind("Emp_Code") %>' />
                                    <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activity">
                                <ItemTemplate>
                                    <asp:Label ID="lblActivity" runat="server" Width="150" Text='<%# Bind("NameOfActivity") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" Wrap="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From Date" SortExpression="FromDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblFromDate" runat="server" Width="100" Text='<%#Bind("FromDate","{0:dd-MMM-yyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="To Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblToDate" runat="server" Width="100" Text='<%#Bind("ToDate","{0:dd-MMM-yyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemarks" runat="server" Width="150" Text='<%#Bind("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="center" Wrap="true" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </center>
            <a name="bottom">
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
