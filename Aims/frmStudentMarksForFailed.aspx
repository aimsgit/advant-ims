<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmStudentMarksForFailed.aspx.vb" 
Inherits="frmStudentMarksForFailed" Title="Student Marks For Failed" EnableEventValidation="false"
    ValidateRequest="false" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Marks Entry For Failed Students</title>
 <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

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

            msg = DropDownForZeroMul(document.getElementById("<%=ddlbatch.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlbatch.ClientID %>").focus();
                a = document.getElementById("<%=lblbatch.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlsemester.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlsemester.ClientID %>").focus();
                a = document.getElementById("<%=lblsemester.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlsubject.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlsubject.ClientID %>").focus();
                a = document.getElementById("<%=lblsubject.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            msg = DropDownForZeroMul(document.getElementById("<%=ddlassesment.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%=ddlassesment.ClientID %>").focus();
                a = document.getElementById("<%=lblassesment.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

//            msg = numericMul(document.getElementById("<%=txtMin.ClientID %>"));
//            if (msg != "") {
//                document.getElementById("<%=txtMin.ClientID %>").focus();
//                a = document.getElementById("<%=lblMin.ClientID %>").innerHTML;
//                msg = Spliter(a) + " " + ErrorMessage(msg);
//                return msg;
//            }



//            msg = ValidateDateMul(document.getElementById("<%=TxtAssessmentDate.ClientID %>"));
//            if (msg != "") {
//                document.getElementById("<%=TxtAssessmentDate.ClientID %>").focus();
//                a = document.getElementById("<%=Label5.ClientID %>").innerHTML;
//                msg = Spliter(a) + " " + ErrorMessage(msg);
//                return msg;
//            }
          return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    document.getElementById("<%=lblerror.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerror.ClientID %>").textContent = msg;
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
              <div>
              <center>
              <h1 class="headingTxt">
                 <asp:Label ID="Lblheading" runat="server">
                    MARKS ENTRY FOR FAILED STUDENTS
                 </asp:Label>
             </h1>
           </center>
           <br/><br />
        <asp:Panel ID="ControlsPanel" runat="server">
                <center>
                      <table>
                               <tr>
                                   <td align="right">
                                      <asp:Label ID="lblbatch" runat="server" Text="Batch*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                   </td>
                                   <td align="left">
                                     <asp:DropDownList ID="ddlbatch" SkinID="ddlRsz" runat="server" DataSourceID="ObjBatch"
                                       DataTextField="Batch_No" DataValueField="BatchID" AutoPostBack="True" TabIndex="1"
                                       Width="240px">
                                    </asp:DropDownList>
                                    
                                     <asp:ObjectDataSource ID="ObjBatch" runat="server" SelectMethod="getBatchPlanner"
                                TypeName="DLStudentMarksForFailed"></asp:ObjectDataSource>
                                
                                    </td>
                                        <%--</tr>
                                    <tr>--%>
                                            <td align="right">
                                                <asp:Label ID="lblMinimum" runat="server" Text="Marks*<&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMin" SkinID="txt" runat="server" TabIndex="2" MaxLength="4">
                                                </asp:TextBox>
                                            </td>
                                        </tr>    
                                        
                                        
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblsemester" runat="server" Text="Semester*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlsemester" SkinID="ddlRsz" runat="server" DataSourceID="ObjSemester"
                                                    DataTextField="SemName" DataValueField="SemCode" AutoPostBack="True" TabIndex="3"
                                                    Width="240px">
                                                </asp:DropDownList>
                                                 <asp:ObjectDataSource ID="ObjSemester" runat="server" SelectMethod="SemesterCombo"
                                           TypeName="DLStudentMarksForFailed">
                                      <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" PropertyName="SelectedValue" Name="Batch"
                                        DbType="Int16" />
                                   </SelectParameters>
                            </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        
                                        
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblsubject" runat="server" Text="Subject*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlsubject" SkinID="ddlRsz" runat="server" DataSourceID="ObjSubject"
                                                    DataTextField="Subject_Name" DataValueField="Subject_Code" TabIndex="4" Width="240px"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                             <asp:ObjectDataSource ID="ObjSubject" runat="server" SelectMethod="GetSubjectComboBatchPlanner"
                                TypeName="DLStudentMarksForFailed">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlbatch" DefaultValue="0" Name="BatchId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                    <asp:ControlParameter ControlID="ddlsemester" DefaultValue="0" Name="SemId" PropertyName="SelectedValue"
                                        Type="Int16" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblassesment" runat="server" Text="Assessment Type*&nbsp;:&nbsp;&nbsp;"
                                                    SkinID="lblRsz" Width="190px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlassesment" SkinID="ddlRsz" runat="server" DataSourceID="ObjAssesment"
                                                    DataTextField="AssessmentType" DataValueField="ID" TabIndex="5" Width="240px" AutoPostBack="true" >
                                                </asp:DropDownList>
                                                 <asp:ObjectDataSource ID="ObjAssesment" runat="server" SelectMethod="GetAssesmentCombo"
                                                 TypeName="DLStudentMarksForFailed"></asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label5" runat="server" Text="Current Assessment Date* :&nbsp;&nbsp;" SkinID="lblRsz"
                                                    meta:resourcekey="Label8Resource1"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TxtAssessmentDate" TabIndex="6" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="TxtAssessmentDate"
                                                    Format="dd-MMM-yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                  
                                    <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnview" runat="server" Text="VIEW" CommandName="VIEW" SkinID="btn"
                                                    CausesValidation="true" OnClientClick="return Validate();" CssClass="ButtonClass"
                                                    TabIndex="7" />
                                               &nbsp; <asp:Button ID="BtnUpdate" runat="server" CssClass="ButtonClass" SkinID="Btn" Text="UPDATE"
                                                    CommandName="UPDATE" TabIndex="8" OnClientClick="BtnUpdate_Click" Enabled="false"  />
                                               &nbsp; <asp:Button ID="btnclear" runat="server" Text="CLEAR" SkinID="btn" CssClass="ButtonClass" Enabled="false"
                                                    CommandName="CLEAR" TabIndex="9" OnClientClick="return confirm('Do you want to delete the selected record(s)?')" />
                                                </td>
                                        </tr>
                                         <caption>
                                             <br />
                                             <div>
                                                 <center>
                                                     <asp:UpdateProgress ID="PageUpdateProgress" runat="server">
                                                         <ProgressTemplate>
                                                             <div class="PleaseWait">
                                                                 <asp:Label ID="lblprocess" runat="server" SkinID="lblBlackRsz" Visible="True" 
                                                                     Width="300"></asp:Label>
                                                             </div>
                                                         </ProgressTemplate>
                                                     </asp:UpdateProgress>
                                                 </center>
                                             </div>
                                             </td>
                                        </caption>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                   <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen" />
                                                <asp:Label ID="lblerror" runat="server" SkinID="lblRed" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                
                               <center >
                                <asp:Panel runat="server" ID="pnllabel" Visible="false">
                                 <table >
                                   <tr align ="center">
                                    <td align="right">
                                                        <asp:Label ID="lblAssessmenttype" runat="server" Text="Assessment Type :&nbsp;&nbsp;" Width="200px"
                                                            SkinID="lblRsz" />
                                                   <td align="left"> 
                                                   <asp:Label ID="lblAssessmentAns" runat="server" SkinID="lblRsz" Width="100px"/>
                                                    </td>   
                                    
                                    <td align="right">
                                                        <asp:Label ID="lblSubject1" runat="server" Text="Subject :&nbsp;&nbsp;" Width="75px"
                                                            SkinID="lblRsz" />
                                                   <td align="left"> 
                                                   <asp:Label ID="lblSubjectAns" runat="server" SkinID="lblRsz" Width="250px"/>
                                                    </td>
                                                  
                                   </tr>      
                                                 
                                   <tr>
                                        <td align="right">
                                                        <asp:Label ID="lblMax" runat="server" Text="Max :&nbsp;&nbsp;" Width="100px"
                                                            SkinID="lblRsz" />
                                                   <td align="left"> 
                                                   <asp:Label ID="lblMaxAns" runat="server" SkinID="lblRsz" Width="100px"/>
                                                    </td>
                                    <td align="right">
                                                        <asp:Label ID="lblMin" runat="server" Text="Min :&nbsp;&nbsp;" Width="75px"
                                                            SkinID="lblRsz" />
                                                   <td align="left"> 
                                                   <asp:Label ID="lblMinAns" runat="server" SkinID="lblRsz" Width="130px"/>
                                    </td>             
                                  
                                   </tr>     
                                </table> 
                                <br/>
                               </asp:Panel> 
                              </center>     
                                    
                             <center>                
                             <asp:Panel ID="GVPanel" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="false" 
                                    SkinID="GridView" PageSize="200" AllowSorting="True" EnableSortingAndPagingCallbacks="True" Visible ="false" >
                                    <RowStyle HorizontalAlign="Left" />
                                    <Columns>
                                       <asp:TemplateField HeaderText="Student Code"  SortExpression="StdCode">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelStdCode" runat="server" Text='<%# Bind("StdCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Student Name" SortExpression="StdName">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelStdId" runat ="server" Text='<%# Bind("STDID") %>' Visible ="false" ></asp:Label> 
                                                <asp:Label ID="LabelStdname" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject" Visible="false">
                                            <ItemTemplate>
                                           <asp:Label ID="LabelSubject" runat="server" Visible="false" Text='<%# Bind("Subjectid") %>'></asp:Label>
                                           <asp:Label ID="LabelSubjectName" runat="server" Visible="false" Text='<%# Bind("Subject_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        
                                        
                                        <%-- <asp:TemplateField ControlStyle-Width="25px">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="ChkAll" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll"
                                                            Text="Present" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkPresent" runat="server" TabIndex="9" />
                                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("id") %>' />
                                                        <asp:Label ID="LabelPre" runat="server" Text='<%# Bind("Present") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                       
                                        <asp:TemplateField HeaderText="Previous Marks">
                                        
                                            <ItemTemplate>
                                                <asp:Label ID="LabelActualMarks" runat="server" SkinID="txtRsz" Text='<%# Bind("ActualMarks") %>'
                                                    Width="60px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false"  HorizontalAlign ="Center"  />
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="Current Marks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtactmarks" runat="server" SkinID="txtRsz" 
                                                Width="60px" TabIndex="10"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Max Marks" Visible="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="LabelMax" runat="server" Text='<%# Bind("MaxMarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Min Marks" Visible ="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="LabelMin" runat="server" Text='<%# Bind("MinMarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                                                                                                  
                                         <asp:TemplateField HeaderText="Semester" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelSemester" runat="server" Visible="false" Text='<%# Bind("SemCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Batch" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="Lblbatch" Visible="false" runat="server" Text='<%# Bind("BatchID") %>'></asp:Label>
                                                <asp:Label ID="LabelBatch" runat="server" Visible="false" Text='<%# Bind("Batch_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                      
                                       <asp:TemplateField HeaderText="Assessment" Visible="false">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="LblAssess" Visible="false" runat="server" Text='<%# Bind("AssesmentCode") %>'></asp:Label>--%>
                                                <asp:Label ID="LabelAssessment" runat="server" Visible="false" Text='<%# Bind("AssessmentType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                                                              
                                        </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            </center>
                            
                            
                           </asp:Panel> 
                           </div> 
                           <a name="bottom">
                            <div align="right">
                                <a href="#top">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                            </div>
                   </ContentTemplate>
             </asp:UpdatePanel>
           </form>
        </body>
        </html>