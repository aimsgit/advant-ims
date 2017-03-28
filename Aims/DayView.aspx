<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DayView.aspx.vb"
    Inherits="DayView" Title="Day View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Day View</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

<script type="text/javascript" language="javascript">  
   function Valid(){
   var msg;
   msg=NameField100(document.getElementById("<%=FormView1.FindControl("entryTitleTextBox").ClientID %>"),'Diary Text');
  if(msg!="") return msg; 
  
     return true;
   }
   
   
 function Validate(){
          var msg=Valid();
          if(msg!=true)
          { 
                    if(navigator.appName=="Microsoft Internet Explorer")
                    {
                     document.getElementById("<%=msginfo.ClientID %>").innerText=msg;
                     return false;
                    }
                    else  if(navigator.appName == "Netscape")
                    {  
                     document.getElementById("<%=msginfo.ClientID %>").textContent=msg;
                     return false;
                    }   
          }
           return true;
 }
function TABLE1_onclick() {

}

    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div>
        <center>
            <h1 class="headingTxt">
                ADD ENTRY
            </h1>
        </center>
        <center>
            <asp:HyperLink ID="addEventHyperLink" runat="server" NavigateUrl="~/AddEvent.aspx"
                Width="131px" SkinID="lnkH" TabIndex="5">Add New Event</asp:HyperLink>&nbsp;&nbsp;
            <asp:HyperLink ID="returnToMainHyperLink" runat="server" Font-Bold="True" Font-Size="Larger"
                Height="23px" NavigateUrl="~/DiaryMain.aspx" Width="156px" SkinID="lnkH" TabIndex="4">Main Diary Page</asp:HyperLink>
        </center>
        <center>
            <table>
                <tr>
                    <td>
                        <asp:FormView ID="FormView1" runat="server" DefaultMode="Insert" DataSourceID="odsDiaryEntry"
                            SkinID=" ">
                            <InsertItemTemplate>
                                <center>
                                    <table class="custTable">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" SkinID="lbl" Text="Diary Text" Width="80px"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="entryTitleTextBox" runat="server" MaxLength="50" TabIndex="1" AutoCompleteType="Disabled"
                                                    SkinID="txt" Text='<%# Bind("EntryText") %>'></asp:TextBox></td>
                                            <td>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" SkinID="lbl" Text="Entry Title"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="entryTextTextBox" runat="server" Rows="10" TabIndex="2" AutoCompleteType="Disabled"
                                                    CssClass=" " SkinID="txtML" Text='<%# Bind("EntryTitle") %>'></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="btnTd">
                                                <asp:Button ID="saveDiaryEntryButton" runat="server" TabIndex="3" Text="SAVE" CommandName="Insert"
                                                    CssClass="btnStyle" SkinID="btn" CausesValidation="true" OnClientClick="return Validate()"/></td>
                                        </tr>
                                    </table>
                                </center>
                            </InsertItemTemplate>
                        </asp:FormView>
                        <asp:Label ID="msginfo" runat="server" ForeColor="red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT * FROM DiaryEntry where Del_Flag = 0"
                        InsertCommand="INSERT INTO DiaryEntry(EntryText,EntryTitle) VALUES(@EntryText,@EntryTitle)"
                        UpdateCommand="UPDATE DiaryEntry SET EntryText=?,EntryTitle=? where [DiaryEntryId]=?"
                        DeleteCommand="UPDATE DiaryEntry SET Del_Flag = -1 where [DiaryEntryId]=?">
                        <UpdateParameters>
                            <asp:Parameter Name="EntryText" Type="String" />
                            <asp:Parameter Name="EntryTitle" Type="DateTime" />
                        </UpdateParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="DiaryEntryId" Type="int32" />
                        </DeleteParameters>
                    </asp:SqlDataSource>--%>
                        <asp:ObjectDataSource ID="odsDiaryEntry" runat="server" TypeName="DiaryEntryManager"
                            InsertMethod="InsertRecord" SelectMethod="GetDiaryEntry" UpdateMethod="UpdateRecord"
                            DeleteMethod="DeleteRecord" DataObjectTypeName="DiaryEntry">
                            <SelectParameters>
                                <asp:Parameter Name="id" Type="int16" DefaultValue="0" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </center>
    </div>


</form>
</body>
</html>
