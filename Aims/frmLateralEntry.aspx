<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="frmLateralEntry.aspx.vb" Inherits="frmLateralEntry" title="Lateral Entry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Lateral Entry</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<div><center><h1 class="headingTxt">LATERAL ENTRY DETAILS</h1></center></div>
<div>
        <center>
        <table class="custTable">
           <tr>
                <td>
                    <asp:Label ID="lblAdmissionyear" runat="server" SkinID="lbl" Text="Admission Year*" Width="150px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtadmissionyear" runat="server" MaxLength="50" SkinID="txt" TabIndex="1"
                        Width="118px" EnableViewState="False"></asp:TextBox></td>   
                 <td>
                    <asp:Label ID="lblfee" runat="server" SkinID="lbl" Text="Fee Paid"></asp:Label></td>         
                 <td>
                    <asp:TextBox ID="txtfee" runat="server" MaxLength="30" SkinID="txt" TabIndex="2"
                        EnableViewState="False"></asp:TextBox></td> 
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblattendedexam" runat="server" SkinID="lbl" Text="Attended Exam*" Width="110px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtattendedexam" runat="server" MaxLength="10" SkinID="txt" TabIndex="3"
                        Width="119px" EnableViewState="False"></asp:TextBox>                  
                </td>
                </tr>             
            <tr><center>
                <td colspan="5" class="btnTd">
                    <asp:Label ID="msginfo" runat="server" ForeColor="red"></asp:Label>
                    <asp:Button ID="btnInsert" runat="server" Text="SAVE" SkinID="btn" TabIndex="6" CausesValidation="true" CssClass="btnStyle"/></td>
                </center>
                </tr>           
        </table>
        </center>
        <div>
        <center>
        <asp:GridView ID="GV_lateralentry" runat="server" EnableViewState="True" AutoGenerateColumns="False"
                        DataSourceID="odsLateralEntry" DataKeyNames="Id" AllowPaging="True"
                        SkinID="GridView">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Edit" CommandName="Edit" CausesValidation="false" runat="server"
                                        ID="btEdit" />&nbsp;
                                    <asp:LinkButton Text="Delete" CommandName="Delete" CausesValidation="false" runat="server"
                                        ID="btDelete" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnUpdate" Text="Update" runat="server" CommandName="Update" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Admission Year">
                                <ItemTemplate>
                                    <asp:HiddenField ID="LID" runat="server" Value='<%# Bind("Id") %>'>
                                    </asp:HiddenField>
                                    <asp:Label ID="lbladmissionyr" runat="server" Text='<%# Bind("AdmissionYear") %>'></asp:Label>
                                    <asp:HiddenField ID="Hcode1" runat="server" Value='<%# Bind("StdCode") %>'></asp:HiddenField>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="LID" runat="server" Value='<%# Bind("Id") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="Hcode" runat="server" Value='<%# Bind("StdCode") %>'></asp:HiddenField>
                                    <asp:TextBox ID="txtadmissionyear" runat="server" Text='<%# Bind("AdmissionYear") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fee Paid">
                                <ItemTemplate>
                                    <asp:Label ID="lblfee" runat="server" Text='<%# Bind("FeePaid") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtfee" runat="server" Text='<%# Bind("FeePaid") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Attended Exam">
                                <ItemTemplate>
                                    <asp:Label ID="lblattendedexam" runat="server" Text='<%# Bind("AttendedExam") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtattendedexam" runat="server" Text='<%# Bind("AttendedExam") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>                
                        </Columns>
                    </asp:GridView>
                    </center>
                    </div>
                <asp:ObjectDataSource ID="odsLateralEntry" runat="server" TypeName="LateralEntryB"
                        SelectMethod="GetLateralEntry" InsertMethod="InsertRecord" DeleteMethod="ChangeFlag"
                        OnInserting="GetInputParameters" OnUpdating="GetUpdateParameters" UpdateMethod="UpdateRecord">
                        <SelectParameters>
                            <asp:SessionParameter Name="stdcode" SessionField="std_code" DefaultValue="0" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="Id" Type="Int32" />                            
                        </DeleteParameters>
                    </asp:ObjectDataSource>
                    </div>
                    
                    <div><center><h1 class="headingTxt">CERTIFICATE ISSUED</h1></center></div>
                 <div>  
                 <center> 
                <table class="custTable">
        <tr>
                <td>
                    <asp:Label ID="lblexam" runat="server" SkinID="lbl" Text="Examination*" Width="150px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtExam" runat="server" MaxLength="50" SkinID="txt" TabIndex="1"
                        Width="118px" EnableViewState="False"></asp:TextBox>&nbsp;
                </td>
                <td>
                    <asp:Label ID="lblboard" runat="server" SkinID="lbl" Text="Board/University*"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtboard" runat="server" MaxLength="30" SkinID="txt" TabIndex="2"
                        Width="120px" EnableViewState="False"></asp:TextBox>&nbsp;</td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID="lblyear" runat="server" SkinID="lbl" Text="Year*" Width="110px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtyear" runat="server" MaxLength="10" SkinID="txt" TabIndex="3"
                        Width="119px" EnableViewState="False"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                        TargetControlID="txtyear" FilterType="Numbers" FilterMode="ValidChars" ValidChars="1234567890-">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </td>
                <td>
                    <asp:Label ID="lblmarks" runat="server" SkinID="lbl" Text="Marks%*" Width="71px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtmarks" runat="server" MaxLength="10" SkinID="txt" TabIndex="4"
                        Width="119px" EnableViewState="False"></asp:TextBox></td>
                <td>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                        TargetControlID="txtmarks" FilterType="Numbers" FilterMode="ValidChars" ValidChars="1234567890-%">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </td>
                </tr>
            <tr>
                <td colspan="5" class="btnTd">                   
                    <asp:Button ID="btnSave" runat="server" Text="SAVE" SkinID="btn" TabIndex="6" CausesValidation="true" CssClass="btnStyle" />
                       </td>
                </tr></table>  
                </center>    
           <div>
           <center>
           <asp:GridView ID="GV_CertiIssued" runat="server" EnableViewState="True" AutoGenerateColumns="False"
                        DataSourceID="odCertiIssued" DataKeyNames="Qualification_ID" AllowPaging="True"
                        SkinID="GridView">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Edit" CommandName="Edit" CausesValidation="false" runat="server"
                                        ID="btEdit" />&nbsp;
                                    <asp:LinkButton Text="Delete" CommandName="Delete" CausesValidation="false" runat="server"
                                        ID="btDelete" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnUpdate" Text="Update" runat="server" CommandName="Update" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qualification">
                                <ItemTemplate>
                                    <asp:HiddenField ID="Qualification_ID" runat="server" Value='<%# Bind("Qualification_ID") %>'>
                                    </asp:HiddenField>
                                    <asp:Label ID="lblname" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    <asp:HiddenField ID="Hcode1" runat="server" Value='<%# Bind("Std_code") %>'></asp:HiddenField>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:HiddenField ID="Qualification_ID" runat="server" Value='<%# Bind("Qualification_ID") %>'>
                                    </asp:HiddenField>
                                    <asp:HiddenField ID="Hcode" runat="server" Value='<%# Bind("Std_code") %>'></asp:HiddenField>
                                    <asp:TextBox ID="txt_QID" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Board Of University">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_universe" runat="server" Text='<%# Bind("Board_Univ") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Board_Univ") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Marks">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_marks" runat="server" Text='<%# Bind("Marks") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Marks") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="YearofPassing">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_YOP" runat="server" Text='<%# Bind("YearofPassing") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("YearofPassing") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>                           
                        </Columns>
                    </asp:GridView>
                    </center>
                    </div>
                    <asp:ObjectDataSource ID="odCertiIssued" runat="server" TypeName="QualificationManager"
                        SelectMethod="GetCertiIssued" OnInserting="GetCertiIssued" InsertMethod="InsertCertiIssued" DeleteMethod="ChangeFlag"
                        OnUpdating="UpdateCertiIssued" UpdateMethod="UpdateCertiIssued">
                        <SelectParameters>
                            <asp:SessionParameter Name="std_code" SessionField="std_code" DefaultValue="0" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="Qualification_ID" Type="Int32" />                            
                        </DeleteParameters>
                    </asp:ObjectDataSource>
               <table>
             <tr>
              <td class="btnTd">
                    <asp:Button ID="btnReturn" runat="server" SkinID="btn" Text="BACK" TabIndex="10" CssClass="btnStyle" />                                       
                </td>
            </tr>
        </table>
    </div>

</form>
</body>
</html>

