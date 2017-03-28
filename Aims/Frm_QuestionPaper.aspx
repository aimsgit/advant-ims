<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Frm_QuestionPaper.aspx.vb"
    Inherits="Frm_QuestionPaper" Title="Question paper Form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Question paper Form</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        //Function for Multilingual Validations
        //Created By Om Prakash
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
            var msg, a;

            msg = ValidateDateMul(document.getElementById("<%=txtdate.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=txtdate.ClientID%>").focus();
                a = document.getElementById("<%=lblDate.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourse.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>").focus();
                a = document.getElementById("<%=lblCourse.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>").focus();
                a = document.getElementById("<%=lblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlSubject.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=ddlSubject.ClientID%>").focus();
                a = document.getElementById("<%=lblSubject.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlQuestionNo.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=ddlQuestionNo.ClientID%>").focus();
                a = document.getElementById("<%=lblQuestionNo.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
       
            return true;
        }
        
        function Validate() {

            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").textContent = "";
                    return false;
                }
            }
            return true;
        }
        function Valid1() {
            var msg, a;

//            msg = ValidateDateMul(document.getElementById("<%=txtdate.ClientID%>"))
//            if (msg != "") {
//                document.getElementById("<%=txtdate.ClientID%>").focus();
//                a = document.getElementById("<%=lblDate.ClientID %>").innerHTML;
//                msg = Spliter(a) + " " + ErrorMessage(msg);
//                return msg;
//            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlCourse.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=ddlCourse.ClientID%>").focus();
                a = document.getElementById("<%=lblCourse.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlBatch.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=ddlBatch.ClientID%>").focus();
                a = document.getElementById("<%=lblBatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlSubject.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=ddlSubject.ClientID%>").focus();
                a = document.getElementById("<%=lblSubject.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = DropDownForZeroMul(document.getElementById("<%=ddlQuestionNo.ClientID%>"))
            if (msg != "") {
                document.getElementById("<%=ddlQuestionNo.ClientID%>").focus();
                a = document.getElementById("<%=lblQuestionNo.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }

        function Validate1() {

            var msg = Valid1();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblMsg.ClientID%>").textContent = "";
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
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
              <%--  <contenttemplate>--%>
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp" BackColor="#E2E3BB">
       <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Question Paper" TabIndex="1">
        <ContentTemplate>
   <center>
      <div>
    <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading" runat="server"></asp:Label>
                </h1>
            </center>
     </div>
      <br />
      <br />
    <center>
      <table class="custTable">
       <tr>
             <td align="right">
               <asp:Label ID="lblDate" runat="server" Text="Date* :&nbsp;&nbsp;" SkinID="lblRsz" Width="150px"></asp:Label>
              </td>
   <td align="left">
      <asp:TextBox ID="txtdate" SkinID="txt" runat="server" TabIndex="2"></asp:TextBox>
      <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtdate" Format="dd-MMM-yyyy" Animated="False">
      </ajaxToolkit:CalendarExtender>
     </td>
   </tr>
    <tr>
       <td align="right">
         <asp:Label ID="lblCourse" runat="server" Text="Course* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
      </td>
      <td align="left">
       <asp:DropDownList ID="ddlCourse" runat="server" DataTextField="CourseName"  SkinID="ddlRsz" width="250" 
            DataSourceID="ObjCourse" AutoPostBack="true" DataValueField="Courseid" TabIndex="3">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjCourse" runat="server" SelectMethod="GetCourse" TypeName="DLQuestionPaper">
        </asp:ObjectDataSource>
        </td>
                                           
     </tr>
      <tr>
        <td align="right">
          <asp:Label ID="lblBatch" runat="server" Text="Batch* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
        </td>
       <td align="left">
         <asp:DropDownList ID="ddlBatch" runat="server" DataTextField="Batch_No"  SkinID="ddlRsz" width="250" DataSourceID ="ObjBatch" 
              AutoPostBack="true" DataValueField="BatchID" TabIndex="4">
         </asp:DropDownList>
         <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="GetBatch" TypeName="DLQuestionPaper">
          <SelectParameters>
          <asp:ControlParameter ControlID="ddlCourse" Name="Courseid" PropertyName="SelectedValue" Type="Int32" />
         </SelectParameters>
       </asp:ObjectDataSource>
      </td>
     </tr>
     <tr>
        <td align="right">
           <asp:Label ID="lblSubject" runat="server" Text="Subject* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
        </td>
         <td align="left">
            <asp:DropDownList ID="ddlSubject" runat="server" DataTextField="Subject_Name"
                 DataSourceID="ObjSubject" DataValueField="Subjectid" Width="250" SkinID="ddlRsz"
                 TabIndex="5" AutoPostBack="true">
             </asp:DropDownList>
             <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubject"
                  TypeName="DLQuestionPaper">
            <SelectParameters>
          <asp:ControlParameter ControlID="ddlBatch" Name="Batchid" PropertyName="SelectedValue" Type="Int32" />
         </SelectParameters>
             </asp:ObjectDataSource>
               </td>
             </tr>
        </table>
        </cenetr>
         <br />
         <hr />
         <center>
         <table >
         <tr>
            <td align="right">
           <asp:Label ID="lblQuestionNo" runat="server" Text="Question Type* :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
        </td>
            <td align="left">
               <asp:DropDownList ID ="ddlQuestionNo" runat ="server" TabIndex="6" SkinID="ddlRsz">
               <asp:ListItem Text ="Select" Value ="Select"></asp:ListItem>
               <asp:ListItem Text ="Objective" Value ="Objective"></asp:ListItem>
               <asp:ListItem Text ="Subjective" value="Subjective"></asp:ListItem>
               </asp:DropDownList>
              <td align="center">
        <asp:Button ID="btnEql" runat="server" CssClass="ButtonClass" SkinID="btnRsz" Width ="100" TabIndex="7" Text="Get Question" OnClientClick="return Validate1()"/>
        </td> 
         <td align="right">
               <asp:Label ID="lblSection" runat="server" Text="Section :&nbsp;&nbsp;" SkinID="lblRsz" Width="150px"></asp:Label>
              </td>
   <td align="left">
      <asp:TextBox ID="txtsection" SkinID="txt" runat="server" TabIndex="8"></asp:TextBox>
     </td>
    </tr>
   </table>
   </center>
   <br />
   <br />
  <center>
   <table>
    <tr>
      <td align="center">
        <asp:Button ID="btnAdd" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="9" CommandName="ADD"
             Text="ADD"  OnClientClick="return Validate() "/>
        <asp:Button ID="btnView" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="10"
             Text="VIEW" CommandName="VIEW"  />
        
       </td>
    </tr>
 </table>
    <hr/>     
     <div>
 <center>
     <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
       </asp:UpdateProgress>
 </center>
</div>
 </center>
  <br />
  <center>
     <asp:Label ID="lblMsg" runat="server" SkinID="lblgreen"></asp:Label>
     <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblred"></asp:Label>
  </center>
  <br />
  <center>
    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
             AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" PageSize="100"
             SkinID="GridView" TabIndex="-1">
        <Columns>
         <asp:TemplateField ShowHeader="False">
              <ItemTemplate>
         <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
              cssproperty="Btnclass" Text="Edit" Visible ="false" ></asp:LinkButton>
         <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
              cssproperty="Btnclass" OnClientClick="return confirm('Do you want to delete the selected record?')" Text="Delete" TabIndex="11">
        </asp:LinkButton>
      </ItemTemplate>
       <ItemStyle Wrap="false" />
     </asp:TemplateField>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Course">
        <ItemTemplate>
            <asp:HiddenField ID="HID" runat="server" Value='<%# Eval("Ques_AutoId")%>' />
            <asp:Label ID="lblCourseId" runat="server" Visible ="false"  Text='<%# Bind("Course") %>'></asp:Label>
            <asp:Label ID="lblCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Wrap="false" />
   </asp:TemplateField>
  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Batch">
       <ItemTemplate>
          <asp:Label ID="lblBatchId" runat="server" Visible ="false" Text='<%# Bind("Batch") %>'></asp:Label>
          <asp:Label ID="lblBatchNo" runat="server" Text='<%# Bind("Batch_No") %>'></asp:Label>
       </ItemTemplate>
       <ItemStyle HorizontalAlign="Center" />
       <ItemStyle Wrap="false" />
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Subject" HeaderStyle-HorizontalAlign="Center">
      <ItemTemplate>
        <asp:Label ID="lblSubjectId" runat="server" Text='<%# Bind("Subject") %>' Visible="false"></asp:Label>
         <asp:Label ID="lblSubjectName" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
       </ItemTemplate>
       <ItemStyle HorizontalAlign="Left" Wrap ="false"  />
  </asp:TemplateField>
 <asp:TemplateField HeaderText="Section" HeaderStyle-HorizontalAlign="Center">
      <ItemTemplate>
 <asp:Label ID="lblSection" runat="server" Text='<%# Bind("Section") %>'></asp:Label>
   </ItemTemplate>
<ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Question Type">
    <ItemTemplate>
   <asp:Label ID="lblQuesNo" runat="server" Text='<%# Bind("Ques_No") %>' Visible ="false" ></asp:Label>
   <asp:Label ID="lblQuesType" runat="server" Text='<%# Bind("Ques_Type") %>'></asp:Label>
 </ItemTemplate>
  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
 </asp:TemplateField>
 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Question Date" Visible ="false" >
    <ItemTemplate>
   <asp:Label ID="lblQuesDate" runat="server" Text='<%# Bind("Ques_Date","{0:dd-MMM-yyyy}") %>' Visible="false"></asp:Label>
 </ItemTemplate>
  <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="false" />
 </asp:TemplateField>
 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Question No">
    <ItemTemplate>
   <asp:Label ID="lblQuesNumber" runat="server" Text='<%# Bind("Question_No") %>'></asp:Label>
   <asp:Label ID="lblQuesSubNo" runat="server" Text='<%# Bind("SubQuesNo") %>'></asp:Label>
 </ItemTemplate>
  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
 </asp:TemplateField>
 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Question">
    <ItemTemplate>
   <asp:Label ID="lblQuestion" runat="server" Text='<%# Bind("Question") %>'></asp:Label>
 </ItemTemplate>
  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
 </asp:TemplateField>
 <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Marks">
    <ItemTemplate>
   <asp:TextBox ID="TxtMarks" runat="server" SkinID ="txtRsz" Width ="50px" Text='<%# Bind("Marks") %>' ></asp:TextBox>
 </ItemTemplate>
  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
 </asp:TemplateField>
 </Columns>
 </asp:GridView>
 </asp:Panel>
  </center>    
     <div>
 <center>
     <asp:UpdateProgress runat="server" ID="UpdateProgress2">
                        <ProgressTemplate>
                            <div class="PleaseWait">
                                <asp:Label ID="lblprocess2" runat="server" SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                            </div>
                        </ProgressTemplate>
       </asp:UpdateProgress>
 </center>
</div>
 </center>
 <center>
     <asp:Label ID="lblupmsg" runat="server" SkinID="lblgreen"></asp:Label>
     <asp:Label ID="lbluperrmsg" runat="server" SkinID="lblred"></asp:Label>
  </center>
  <center>
  <br />
   <table>
    <tr>
      <td align="center">
        <asp:Button ID="btnUpdate" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="11" CommandName="ADD"
             Text="UPDATE" Width="80px"/>    
       </td>
    </tr>
 </table>
    </ContentTemplate>
   </ajaxToolkit:TabPanel>
   <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Question Details" TabIndex="1">
        <ContentTemplate>
   <center>
      <div>
    <center>
                 <h1 class="headingTxt">
                    <%--<asp:Label ID="Lblheading1" runat="server"></asp:Label>--%>
                     QUESTION DETAILS
                </h1>
            </center>
     </div>
     <br />
    <center>
    <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
        <div >
        <asp:ListBox ID="ListBox1" Height="300px" Width="400px" SelectionMode="Multiple" DataTextField="QuesBank_AutoId1"
             DataValueField="QuesBank_AutoId" runat="server" TabIndex="3">
       </asp:ListBox>
       </div>
       </asp:Panel>
       <br />
       <center>
       <asp:Label ID="lblErrMsg1" runat="server" SkinID="lblred"></asp:Label>
       </center> 
       <br />
       <center>
       <div>
       <asp:Button ID="btnok" runat="server" CssClass="ButtonClass" SkinID="btnRsz" TabIndex="12" CommandName="OK"
             Text="OK" Width="80px"/>
        </div>
 
  </center>
   </ContentTemplate>
   </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
<%-- </contenttemplate>--%>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="Images/top.png" Width="30px" />
                        </a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
