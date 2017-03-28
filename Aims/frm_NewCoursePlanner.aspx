<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frm_NewCoursePlanner.aspx.vb"
    Inherits="frm_NewCoursePlanner" Title="Course Planner" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Course Planner</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        //Function for Multilingual Validations
        //Created By Niraj
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

        function Valid() {
            var msg;
            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourse.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>").focus();
                a = document.getElementById("<%=lblcourse.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSubject.ClientID%>"));
            if (msg != "") {
                document.getElementById("<%=ddlSubject.ClientID%>").focus();
                a = document.getElementById("<%=lblSubject.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlSemester.ClientID%>"));

            if (msg != "") {
                document.getElementById("<%=ddlSemester.ClientID%>").focus();
                a = document.getElementById("<%=lblSemester.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }


        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    return false;
                }
            }
            return true;
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <%--<table></table>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--  <center>
                        <h1 class="headingTxt">
                            COURSE PLANNER</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcourse" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCourse" runat="server" SkinID="ddlRsz" Width="250 px" DataSourceID="objCourse"
                                        TabIndex="1" DataTextField="CourseName" DataValueField="CourseCode" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                             <tr>
                            <td align="right">
                              <asp:Label ID="lblPrinciple" runat="server" Text="Stream/Principal Subject :&nbsp;&nbsp;" SkinID="lblRsz" Width="200px" ></asp:Label>
                            </td>
                            <td align="left">
                                 <asp:DropDownList ID="ddlPrincipalSubject" runat="server" AutoPostBack="true" 
                                 DataSourceID="ObjPrincipalSubject" DataTextField="PrincipalSubjectName" DataValueField="PrincipalSubjectNo" 
                                 SkinID="ddlRsz" TabIndex="2" Width="250" style="margin-left: 0px">
                                 </asp:DropDownList>
                            </td>    
                           <td>
                              <asp:Label ID="Label1" runat="server" Text="(Non-Mandatory)" SkinID="lblRsz"></asp:Label>
                            </td>          
                        </tr>
                         <tr>
                           <td align="right">
                                <asp:Label ID="lblSubCategory" runat="server" Text="Course Unit/Subject Category:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                              <td align="left">
                                   <asp:DropDownList ID="ddlSubCategory" runat="server" AutoPostBack="true" 
                                     DataSourceID="ObjSubCategory" DataTextField="SubCategoryName" DataValueField="SubCategoryNo" 
                                     SkinID="ddlRsz" TabIndex="3" Width="250">
                                        </asp:DropDownList>
                               </td>         
                               <td>
                              <asp:Label ID="Label2" runat="server" Text="(Non-Mandatory)" SkinID="lblRsz"></asp:Label>
                            </td>    
                        </tr>
                            
                        </table>
                        <table>
                            <tr>
                                <td colspan="7">
                                    <hr style="width: 480px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSubject" runat="server" SkinID="lbl" Text="Subject* :  "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbltheory" runat="server" SkinID="lbl" Text="Total Hours :  "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblcredit" runat="server" SkinID="lbl" Text="Credit :  "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSemester" runat="server" SkinID="lbl" Text="Semester*^ : "></asp:Label>
                                </td>
                                <%--<td>
                                <asp:Label ID="lblLab" runat="server" SkinID="lbl" Text="Lab(Hrs) :  "></asp:Label>
                            </td>--%>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSubject" runat="server" SkinID="ddlRsz" DataSourceID="ObjSubject"
                                        DataTextField="Subject_Name" DataValueField="Subject_Code" Width="250px" TabIndex="2">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTheory" runat="server" TabIndex="3" ValidationGroup='0123456789.'
                                        SkinID="txtRsz" Width="120"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCredit" runat="server" TabIndex="3" ValidationGroup='0123456789.'
                                        SkinID="txtRsz" Width="120"></asp:TextBox>
                                </td>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtTheory">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtCredit">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <td>
                                    <asp:DropDownList ID="ddlSemester" runat="server" DataSourceID="ObjSemester" DataTextField="SemName"
                                        DataValueField="SemCode" SkinID="ddl" TabIndex="6">
                                    </asp:DropDownList>
                                </td>
                                <%-- <td>
                                <asp:TextBox ID="txtLab" OnTextChanged="txtProject_TextChanged" runat="server" SkinID="txt" TabIndex ="4"
                                    ></asp:TextBox>
                            </td>--%>
                            </tr>
                            <%-- <tr>--%>
                            <%--<td>
                                <asp:Label ID="lblProject" runat="server" SkinID="lbl" Text="Project(Hrs) : "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTtlHrs" runat="server" SkinID="lbl" Text="Total Hours : "></asp:Label>
                            </td>--%>
                            <%--   </tr>--%>
                            <%--  <tr>--%>
                            <%-- <td>
                                <asp:TextBox ID="txtProject" OnTextChanged="txtProject_TextChanged" runat="server" TabIndex ="5"
                                    SkinID="txt" ></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTtlHrs" runat="server" ReadOnly="True" SkinID="txt"></asp:TextBox>
                            </td>--%>
                            <%-- </tr>--%>
                            <tr>
                                <td colspan="7">
                                    <hr style="width: 480px" />
                                </td>
                            </tr>
                        </table>
                    </center>
            </a><a name="bottom">
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnAddGrid" runat="server" CausesValidation="True" SkinID="btn" Text="ADD" CommandName="ADD"
                                    ToolTip="Add" CssClass="ButtonClass" TabIndex="7" OnClientClick="return Validate();" />&nbsp;
                                    
                                <asp:Button ID="BtnView" runat="server" CausesValidation="False" CssClass="ButtonClass " CommandName="VIEW"
                                    SkinID="btn" TabIndex="8" Text="VIEW" ToolTip="VIEW" />
                                    
                                <asp:ObjectDataSource ID="objCourse" runat="server" SelectMethod="GetCourseCombo"
                                    TypeName="BLNewCoursePlanner"></asp:ObjectDataSource>
                                    
                                <asp:ObjectDataSource ID="ObjPrincipalSubject" runat="server" SelectMethod="GetPrincipalSubject"
                                    TypeName="BLNewCoursePlanner">
                              </asp:ObjectDataSource>
                              
                              <asp:ObjectDataSource ID="ObjSubCategory" runat="server" SelectMethod="GetSubjectCategory"
                                    TypeName="BLNewCoursePlanner">
                              </asp:ObjectDataSource>
                              
                               <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboByPrinci"
                                    TypeName="BLNewCoursePlanner">
                                  <SelectParameters>
                                      <asp:ControlParameter ControlID="ddlPrincipalSubject" DefaultValue="0" Name="PrincipalSubject" PropertyName="SelectedValue"
                                         Type="Int16" />
                                      <asp:ControlParameter ControlID="ddlSubCategory" DefaultValue="0" Name="SubjectCategory" PropertyName="SelectedValue"
                                         Type="Int16" />
                                  </SelectParameters>                   
                               </asp:ObjectDataSource>
                                    
                                <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="GetCoursePlannerSemCombo"
                                    TypeName="SemesterdateDL"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                    <ProgressTemplate>
                                        <div class="PleaseWait">
                                            <asp:Label ID="lblprocess" runat="server" 
                                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="600px" Height="300px">
                            <asp:GridView ID="GVUserMngmnt" runat="server" SkinID="GridView" AllowPaging="True"
                                AutoGenerateColumns="False" AllowSorting="True" PageSize="100">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                TabIndex="9" Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                TabIndex="10" Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject" SortExpression="Subject_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubName" runat="server" Text='<%#Bind("Subject_Name") %>'></asp:Label>
                                            <asp:Label ID="lblSubCode" Visible="false" runat="server" Text='<%# Bind("SubjectCode") %>' />
                                            <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Bind("id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Principal Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrin" runat="server" Text='<%# Bind("PrincipalSubject") %>'></asp:Label>
                                        <asp:Label ID="lblPrinCode" Visible="false" runat="server" Text='<%#Bind("PrincipalSub") %>'></asp:Label>  
                                          </ItemTemplate>
                                    <%--<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Left" />--%>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Subject Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubCat" runat="server" Text='<%# Bind("SubjectCategory") %>'></asp:Label>
                                        <asp:Label ID="lblSubCatCode" Visible="false" runat="server" Text='<%#Bind("SubCat") %>'></asp:Label> 
                                       <%-- <asp:Label ID="lblscid" Visible="false" runat="server" Text='<%# Bind("id") %>' />--%>
                                    </ItemTemplate>
                                    <%--<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Left" />--%>
                                </asp:TemplateField>
                                
                                        
                                    <asp:TemplateField HeaderText="Total Hours">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTheoryHours" runat="server" Text='<%#Bind("TheoryHours") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCredit" runat="server" Text='<%#Bind("Credit") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Lab Hours">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLabHours" runat="server" Text='<%#Bind("LabHours") %>'></asp:Label>
                                        </ItemTemplate>--%>
                                    <%--  </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Project Hours">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectHours" runat="server" Text='<%#Bind("Project") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%-- <asp:TemplateField HeaderText="Total Hours">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalHours" runat="server" Text='<%#Bind("TotalHours") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Semester" SortExpression="SemName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSemester" runat="server" Text='<%#Bind("SemName") %>'></asp:Label>
                                            <asp:Label ID="Lblsemcode" runat="server" Visible="false" Text='<%#Bind("SemCode") %>'></asp:Label>
                                            <asp:Label ID="LblCourseCode" runat="server" Visible="false" Text='<%#Bind("CourseCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <%--<PagerStyle CssClass="TableClass"></PagerStyle>--%>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </center>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </a>
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>