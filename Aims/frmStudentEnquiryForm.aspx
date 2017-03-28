<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStudentEnquiryForm.aspx.vb" 
Inherits="frmStudentEnquiryForm" Title="Student Enquiry Form" ValidateRequest="false" %>

<%@ Reference VirtualPath="Main.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Enquiry Form</title>
     <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
     <link type="text/css" rel="Stylesheet" href="Styles/jquery-treeview/jquery.treeview.css" />

    <script type="text/javascript" src="Scripts/jquery.min.js"></script>

    <script type="text/javascript" src="Scripts/jquery-treeview/jquery.treeview.min.js"></script>
   <script type="text/javascript" src="Scripts/jquery-treeview/jquery-1.11.0.min.js"></script>
       <script type="text/javascript" src="Scripts/jquery-treeview/TreeListFilter.js"></script>
 <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>

</head>

<body style="width: 700px; height: 700px">

<script type ="text/javascript" >
    function ShowImage() {
        GlbShowSImage(document.getElementById("<%=txtStudentCode.ClientID%>"));

    }
    function HideImage() {
        GlbHideSImage(document.getElementById("<%=txtStudentCode.ClientID%>"));
    }
    function ShowImage1() {
        GlbShowSImage(document.getElementById("<%=txtStudentName.ClientID%>"));

    }
    function HideImage1() {
        GlbHideSImage(document.getElementById("<%=txtStudentName.ClientID%>"));
    }
    function openwd() {
        window.open('Main.aspx', '', 'width=565,left=300,top=200,height=440,scrollbars=true').focus
    }
</script>

<%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.js" type="text/javascript"></script>
<script type="text/javascript">
    document = "Main.aspx";
    $(document).load(function() {
        $('LogOut').hide();
    });    
    
  </script>  --%> 

<script type="text/javascript">
    function GetChildCode(child, Title, HelpLink, FLink) {
        var str = child;
        var str1 = Title;
        var Helpl = HelpLink;
        var LinkName = FLink;
        
               test(str, str1, LinkName);
        document.getElementById('help').href = Helpl;

    }
    function test(str1, str, LinkName) {
        PageMethods.MyMethod(str, str1, LinkName);
    }
</script>


<script src="js/Tvalidate.js" type="text/javascript"> </script>
<style type="text/css">
                            .completeListStyle22
                            {
                                height: 200px;
                                width: 505px;
                                overflow: auto;
                                list-style-type: disc;
                                padding-left: 17px;
                                background-color: #FFF;
                                border: 1px solid DarkGray;
                                text-align: left;
                                font-size: small;
                                color: black;
                                visibility: hidden;
                            }
                        </style>
                        
                        
    <script language="JavaScript" type="text/javascript">
        //Function for Multilingual Validations
        //Created By Jina
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
  
      msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtStudentCode.ClientID%>"), 'Student Code/Student Name');
            if (msg != "") {
                document.getElementById("<%=txtStudentCode.ClientID%>")
                return msg;
            }
            
   msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtStudentName.ClientID%>"), 'Student Code/Student Name');
            if (msg != "") {
                document.getElementById("<%=txtStudentName.ClientID%>")
                return msg;
            }
            return true;
     }    
            
                        
        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrormsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";

                    return false;
                }
                else if (navigator.appName == "Netscape") {
                document.getElementById("<%=lblerrormsg.ClientID %>").textContent = msg;
                document.getElementById("<%=lblmsg.ClientID %>").textContent = "";

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
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                </a>
                <%--     <center>
                    <h1 class="headingTxt">
                        STUDENT ENQUIRY FORM
                    </h1>
                </center>--%>
                <br /> <br />
                
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server">
                        STUDENT ENQUIRY FORM
                        </asp:Label>
                    </h1>
                </center>
                 <br />
                      <%--  <hr />--%>
                
                        
                 <asp:Panel ID="ControlsPanel" runat="server">
                    <center>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCourse" runat="server" SkinID="lbl" Text="Course :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCourseName" runat="server" DataSourceID="ObjCourse" AutoPostBack="true"
                                        DataTextField="CourseName" DataValueField="Courseid" SkinID="ddlRsz" Width="250 px"
                                         TabIndex="1">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetCourseData" TypeName="DLStudentEnquiryForm">
                                    </asp:ObjectDataSource>
                                </td>
                           
                             <td align="right">
                                  <asp:Label ID="lblBatch" runat="server" SkinID="lbl" Text="Batch :&nbsp;&nbsp;"></asp:Label>
                                </td>
                                <td align ="left" >
                                
                                    <asp:DropDownList ID="ddlBatchName" runat="server" DataSourceID="ObjBatch" AutoPostBack="true" 
                                        DataTextField="Batch_No" DataValueField="BatchID" SkinID="ddlRsz" TabIndex="2"
                                         Width="180">
                                        <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatchCombo" TypeName="DLStudentEnquiryForm">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCourseName" Name="Courseid" DefaultValue="0"
                                                Type="Int16" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                           <tr>
                           <td align="right">
                                            <asp:Label ID="lblStudentCode" runat="server" SkinID="lbl" Text="Student Code :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:HiddenField ID="StdId" runat="server" />
                                            <asp:TextBox ID="txtStudentCode" runat="server" AutoPostBack="True" SkinID="txt" Width="200px"
                                                TabIndex="3"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="2000"
                                                OnClientPopulated="HideImage" OnClientPopulating="ShowImage" ServiceMethod="getStudentEnquiryId"
                                                ServicePath="TextBoxExt.asmx" TargetControlID="txtStudentCode" CompletionListCssClass="completeListStyle22"
                                                DelimiterCharacters="" Enabled="True">
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                                SkinID="watermark" TargetControlID="txtStudentCode" WatermarkText="Type first 3 characters"
                                                Enabled="True">
                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                        </td>
                                        
                          <td align="right">
                                    <asp:Label ID="lblStudentName" runat="server" SkinID="lbl" Text="Student Name :&nbsp;&nbsp;"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:HiddenField ID="StdId1" runat="server" />
                                            <asp:TextBox ID="txtStudentName" runat="server" AutoPostBack="True" SkinID="txt"
                                                TabIndex="3"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="2000"
                                                OnClientPopulated="HideImage1" OnClientPopulating="ShowImage1" ServiceMethod="getStudentName"
                                                ServicePath="TextBoxExt.asmx" TargetControlID="txtStudentName" CompletionListCssClass="completeListStyle22"
                                                DelimiterCharacters="" Enabled="True">
                                            </ajaxToolkit:AutoCompleteExtender>
                                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                SkinID="watermark" TargetControlID="txtStudentName" WatermarkText="Type first 3 characters"
                                                Enabled="True">
                                            </ajaxToolkit:TextBoxWatermarkExtender>
                                        </td>
                                  </tr>
                          </table>
                      </center> 
                      
                      <%--    <tr>
                          <td >
                       <asp:Label ID="lblStudent" runat="server" Text="Student Name :&nbsp;" SkinID="lblRsz"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStudent" runat="server" DataSourceID="ObjStudent" AutoPostBack="true"
                                DataTextField="StdName" DataValueField="STD_ID" SkinID="ddlRsz" Width="200" TabIndex="3"
                                        AppendDataBoundItems="false">
                               <%-- <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjStudent" runat="server" SelectMethod="GetStudentNameCombo"
                                TypeName="DLStudentEnquiryForm">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlBatchName" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        </tr>--%>
                       
                                   
             <%-- <table>
                    <tr align ="center">
                        <td>
                           <asp:Button ID="btnGetDetails" runat="server" CssClass="ButtonClass" SkinID="btnRsz"
                                TabIndex="5" Text="GET DETAILS" Width ="150px" OnClick="btnGetDetails_Click"  />
                        </td>    
                     </tr> 
                 </table>  --%>
              
               <br />
               <center>
                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <br /> 
                    <asp:Label ID="lblerrormsg" runat="server" SkinID="lblRed"></asp:Label>
                    <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                </center> 
                <br />
            </asp:Panel> 
            
            <center>
            <asp:Panel ID="StdDetails"  runat="server" Visible="true" >
            <%--  <h2 class="headingTxt">STUDENT DETAILS<h2>
                    <hr width="450px">--%>
            <table>
                <tr>
                  <td>
                    &nbsp;
                <asp:GridView ID="GrdReport" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                   PageSize="500" SkinID="GridView" Width="300px" HorizontalAlign ="Center">
                  <Columns>
                     <asp:TemplateField Visible="false">
                        <ItemTemplate>
                       <asp:HiddenField ID="HFChildFileName" runat="server" Value='<%# Bind("LinkName") %>'></asp:HiddenField>
                      <asp:HiddenField ID="HFCNIDAuto" runat="server" Value='<%# Bind("CNIDAuto") %>'></asp:HiddenField>
                     <asp:HiddenField ID="HFMNIDAuto" runat="server" Value='<%# Bind("MNIDAuto") %>'>
                     </asp:HiddenField>
                    </ItemTemplate>          
                  </asp:TemplateField> 
                  
                   <asp:TemplateField ShowHeader="true" HeaderText="Report Name" ItemStyle-HorizontalAlign="left"
                          HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Underline="true" CommandName="Edit"
                         Text='<%# Bind("ChildName") %>' />
                        </ItemTemplate>
                   </asp:TemplateField>
                
                  </Columns>
              </asp:GridView>    
              </td>
           </tr>
    </table>        
    </asp:Panel> 
                  
       </center>         
                      
            <%-- <asp:Repeater runat="server" ID="Repeater1">
                   <ItemTemplate>
                        <div></div>
                        <%--<a href='Default.aspx?name=<%# Eval("Parent_ID") %> disabled="true"' onclick="return false;" style=" text-decoration:None; font-size: 13px;">
                            <%#DataBinder.Eval(Container.DataItem, "Parent_Name")%></a>
                          
                          <%--  <span style=" text-decoration:None; font-size: 11px;" visible ="false" >
                            <%#DataBinder.Eval(Container.DataItem, "Parent_Name")%>
                            </span>
                            <asp:Label id="lblParent" runat="server" Text='<%# Bind("MNIDAuto") %>' Visible="False"></asp:Label>
                            <asp:Repeater runat="server" ID="Repeater2">
                               <%-- <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <a  href='<%# Eval("LinkName") %>'   onclick="GetChildCode('<%#Eval("Code")%>',  '<%#Eval("Title")%>','<%#Eval("HelpLink")%>','<%#Eval("LinkName")%>')" target="_blank"    style=" text-decoration:None; font-size: 11px; text-align:left ">
                                        <%#DataBinder.Eval(Container.DataItem, "Title")%></a>
                                        <br />
                                        <%-- <asp:Repeater runat="server" ID="repeatItem" DataSource='<%# Eval("Items")%>'>
                                        <HeaderTemplate><ul></HeaderTemplate>
                                        <ItemTemplate>
                                            <li><a href='Default.aspx?name=<%# Eval("Name") %>'><%# Eval("Name")%></a></li>
                                        </ItemTemplate>
                                        <FooterTemplate></ul></FooterTemplate>
                                    </asp:Repeater>   
                                   
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul></FooterTemplate>
                            </asp:Repeater>
                     </ItemTemplate>
                </asp:Repeater> --%>
         
                
            <div align="right">
                <a href="#top">
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>

                         
                          
                                
 
