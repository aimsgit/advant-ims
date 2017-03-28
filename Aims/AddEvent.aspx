<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddEvent.aspx.vb"
    Inherits="AddEvent" Title="Add Event" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add Event</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

<script type="text/javascript" language="javascript">  
   function Valid(){
   var msg;
   msg=NameField100(document.getElementById("<%=FormView1.FindControl("txtname").ClientID %>"),'Event Name');
  if(msg!="") return msg; 
   msg=ValidateDate(document.getElementById("<%=FormView1.FindControl("txtstarttime").ClientID %>"),'Event Date');
     if(msg!="") return msg;
       msg=Duration(document.getElementById("<%=FormView1.FindControl("txtduration").ClientID %>"),'Event Duration');
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

    <div class="mainBlock">
    <center>
        <h1 class="headingTxt">
        ADD EVENT
        </h1>
    </center>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<CENTER><asp:FormView id="FormView1" runat="server" Height="100px" meta:resourcekey="FormView1Resource1" DataKeyNames="DiaryId" DataSourceID="odsEvent" DefaultMode="Insert"><EditItemTemplate>
<TABLE class="custTable"><TBODY><TR><TD><asp:Label id="Label4" runat="server" Width="100px" Text="Event Name" SkinID="lbl" meta:resourcekey="Label4Resource1" __designer:wfdid="w49"></asp:Label></TD><TD><asp:TextBox id="txtname" runat="server" Text='<%# Bind("EventName") %>' SkinID="txt" meta:resourcekey="txtnameResource1" __designer:wfdid="w50"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label9" runat="server" Width="109px" Text="Event Description" SkinID="lbl" meta:resourcekey="Label9Resource1" __designer:wfdid="w51"></asp:Label></TD><TD><asp:TextBox id="txtdescr" runat="server" Text='<%# Bind("EventDescription") %>' SkinID="txt" meta:resourcekey="txtdescrResource1" __designer:wfdid="w52"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label10" runat="server" Text="Event Date" SkinID="lbl" meta:resourcekey="Label10Resource1" __designer:wfdid="w53"></asp:Label></TD><TD><asp:TextBox id="txtstarttime" runat="server" Text='<%# Bind("EventDate") %>' SkinID="txt" meta:resourcekey="txtstarttimeResource1" __designer:wfdid="w54"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label11" runat="server" Width="99px" Text="Event Duration" SkinID="lbl" meta:resourcekey="Label11Resource1" __designer:wfdid="w55"></asp:Label></TD><TD><asp:TextBox id="txtduration" runat="server" Text='<%# Bind("EventDuration") %>' SkinID="txt" meta:resourcekey="txtdurationResource1" __designer:wfdid="w56"></asp:TextBox></TD></TR><TR><TD class="btnTd" colSpan=2><asp:Button id="btnsave" runat="server" Width="90px" Text="UPDATE" SkinID="btn" meta:resourcekey="btnsaveResource1" CssClass="btnStyle" OnClientClick="return Validate()" CommandName="Update" __designer:wfdid="w57"></asp:Button> <asp:Button id="Button1" onclick="CancelEdit" runat="server" Width="90px" Text="CANCEL" CausesValidation="true" SkinID="btn" CssClass="btnStyle" CommandName="Cancel" __designer:wfdid="w58"></asp:Button><ajaxToolkit:MaskedEditExtender id="meeSDate" runat="server" TargetControlID="txtstarttime" ClearMaskOnLostFocus="false" MaskType="none" Mask="99-LLL-9999" PromptCharacter="_" __designer:wfdid="w59"></ajaxToolkit:MaskedEditExtender><ajaxToolkit:CalendarExtender id="ceSDate" runat="server" TargetControlID="txtstarttime" __designer:wfdid="w60" Format="dd-MMM-yyyy">
                                            </ajaxToolkit:CalendarExtender></TD></TR></TBODY></TABLE>
</EditItemTemplate>
<InsertItemTemplate>
<TABLE class="custTable"><TBODY><TR><TD><asp:Label id="Label4" runat="server" Width="82px" Text="Event Name" SkinID="lbl" meta:resourcekey="Label4Resource2" __designer:wfdid="w37"></asp:Label></TD><TD><asp:TextBox id="txtname" tabIndex=1 runat="server" Text='<%# Bind("EventName") %>' SkinID="txt" meta:resourcekey="txtnameResource2" CssClass=" " AutoCompleteType="Disabled" __designer:wfdid="w38"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label5" runat="server" Width="115px" Text="Event Description" SkinID="lbl" meta:resourcekey="Label5Resource1" __designer:wfdid="w39"></asp:Label></TD><TD><asp:TextBox id="txtdescr" tabIndex=2 runat="server" Text='<%# Bind("EventDescription") %>' SkinID="txt" meta:resourcekey="txtdescrResource2" CssClass=" " AutoCompleteType="Disabled" __designer:wfdid="w40"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label6" runat="server" Text="Event Date" SkinID="lbl" meta:resourcekey="Label6Resource1" __designer:wfdid="w41"></asp:Label></TD><TD><asp:TextBox id="txtstarttime" tabIndex=3 runat="server" Text='<%# Bind("EventDate") %>' SkinID="txt" __designer:wfdid="w42"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label7" runat="server" Text="Event Duration" SkinID="lbl" meta:resourcekey="Label7Resource1" __designer:wfdid="w43"></asp:Label></TD><TD><asp:TextBox id="txtduration" tabIndex=4 runat="server" Text='<%# Bind("EventDuration") %>' SkinID="txt" meta:resourcekey="txtdurationResource2" CssClass=" " AutoCompleteType="Disabled" __designer:wfdid="w44"></asp:TextBox></TD></TR><TR></TR><TR><TD class="btnTd" colSpan=2><asp:Button id="btnsave" tabIndex=5 runat="server" Text="SAVE" CausesValidation="true" SkinID="btn" meta:resourcekey="btnsaveResource2" CssClass="btnStyle" OnClientClick="return Validate()" CommandName="Insert" __designer:wfdid="w45"></asp:Button> <asp:Button id="btnDetails" tabIndex=13 onclick="ShowDetails" runat="server" Text="DETAILS" CausesValidation="False" SkinID="btn" CssClass="btnStyle" __designer:wfdid="w46"></asp:Button> </TD></TR><TR><TD><ajaxToolkit:MaskedEditExtender id="meeSDate" runat="server" TargetControlID="txtstarttime" ClearMaskOnLostFocus="false" MaskType="none" Mask="99-LLL-9999" PromptCharacter="_" __designer:wfdid="w47"></ajaxToolkit:MaskedEditExtender> <ajaxToolkit:CalendarExtender id="ceSDate" runat="server" TargetControlID="txtstarttime" __designer:wfdid="w48" Format="dd-MMM-yyyy">
                                            </ajaxToolkit:CalendarExtender></TD></TR></TBODY></TABLE>
</InsertItemTemplate>
</asp:FormView> </CENTER><CENTER><asp:Label id="msginfo" runat="server" ForeColor="red"></asp:Label> </CENTER><DIV><CENTER><asp:HyperLink id="returnToMainHyperLink" tabIndex=6 runat="server" Width="152px" Font-Bold="True" SkinID="lnkH" meta:resourcekey="returnToMainHyperLinkResource1" NavigateUrl="~/DiaryMain.aspx" Font-Size="Large">Main Diary Page</asp:HyperLink> <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT * FROM DiaryEvent where Del_Flag = 0"
                        InsertCommand="INSERT INTO DiaryEvent(EventName,EventDescription,EventDate,EventDuration) VALUES(@EventName,@EventDescription,@EventDate,@EventDuration)"
                        UpdateCommand="UPDATE DiaryEvent SET EventName=?,EventDescription=?,EventDate=?,EventDuration=? where [DiaryId]=?"
                        DeleteCommand="UPDATE DiaryEvent SET Del_Flag = -1 where [DiaryId]=?">
                        <UpdateParameters>
                            <asp:Parameter Name="EventName" Type="String" />
                            <asp:Parameter Name="EventDescription" Type="String" />
                            <asp:Parameter Name="EventDate" Type="DateTime" />
                            <asp:Parameter Name="EventDuration" Type="String" />
                        </UpdateParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="DiaryId" Type="Int32" />
                        </DeleteParameters>
                    </asp:SqlDataSource>--%><asp:ObjectDataSource id="odsEvent" runat="server" DataObjectTypeName="DiaryEvent" DeleteMethod="DeleteRecord" UpdateMethod="UpdateRecord" SelectMethod="GetDiaryEvent" InsertMethod="InsertRecord" TypeName="DiaryEventManager">
                        <%--<SelectParameters>
                            <asp:Parameter Name="id" Type="int16" DefaultValue="0" />
                        </SelectParameters>--%>
                    </asp:ObjectDataSource>&nbsp;&nbsp; </CENTER></DIV><DIV><CENTER><asp:GridView id="GridView1" runat="server" SkinID="GridView" meta:resourcekey="GridView1Resource1" DataKeyNames="DiaryId" AutoGenerateColumns="False">
                            <EmptyDataTemplate>
                                <strong>No Records To Display</strong>.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="DID" runat="server" Value='<%# Bind("DiaryId") %>'></asp:HiddenField>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="Edit"
                                            CommandName="Edit" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" meta:resourcekey="LinkButton2Resource1"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Name" meta:resourcekey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("EventName") %>' meta:resourcekey="Label1Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Description" meta:resourcekey="TemplateFieldResource3">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("EventDescription") %>' meta:resourcekey="Label8Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Date" meta:resourcekey="TemplateFieldResource4">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("EventDate","{0:MM/dd/yyyy}") %>' meta:resourcekey="Label2Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Duration" meta:resourcekey="TemplateFieldResource5">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("EventDuration") %>' meta:resourcekey="Label3Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView> </CENTER></DIV>
</contenttemplate>
             <triggers>
<asp:AsyncPostBacktrigger ControlID="FormView1" EventName="ItemCommand"></asp:AsyncPostBacktrigger>
</triggers>
        </asp:UpdatePanel>
          
    </div>

</form>
</body>
</html>
