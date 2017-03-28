<%@ Page Language="VB" AutoEventWireup="false"
    CodeFile="DiaryMain.aspx.vb" Inherits="DiaryMain"  Title="Diary Details"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Diary Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <div>
        &nbsp; &nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 600px">
            <caption ><h1 unselectable="on" tabindex="-1" class="headingTxt">DIARY DETAILS</h1>
                </caption>
            <tr>
                <td colspan="1" rowspan="1" style="width: 200px; height: 20px" valign="top">
                </td>
                <td style="width: 100px; height: 20px">
                    
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="1" rowspan="7" style="width: 200px;" valign="top">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black"
                        BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                        NextPrevFormat="ShortMonth" Width="325px" SkinID="CalendarView">
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <DayStyle BackColor="#CCCCCC" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt"
                            ForeColor="White" Height="12pt" />
                    </asp:Calendar>
                </td>
                <td style="width: 100px; height: 20px"></td>
                <td style="width: 300px; height: 20px">
                    </td>
                <td style="width: 300px; height: 20px">           
                    <asp:HyperLink ID="manageContactsHyperLink" runat="server" Font-Bold="True" NavigateUrl="~/AddContact.aspx" Font-Italic="False" Font-Underline="True" Width="266px" SkinID="lnkH" TabIndex="1">Manage Your Accounts</asp:HyperLink></td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                    </td>
                <td style="width: 300px; height: 20px">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" NavigateUrl="~/AddEvent.aspx" Font-Underline="True" Width="170px" SkinID="lnkH" TabIndex="2">Add New Event</asp:HyperLink></td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                    </td>
                <td style="width: 300px; height: 20px">
                    <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" NavigateUrl="~/DayView.aspx" Font-Underline="True" Width="166px" SkinID="lnkH" TabIndex="3">Add New Entry</asp:HyperLink></td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px">
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="1" rowspan="1" style="width: 200px; height: 20px" valign="top">
                    <%--<asp:GridView ID="eventsGridView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                        Caption="Upcoming Events" CaptionAlign="Left" Font-Bold="False" Height="1px"
                        PageSize="3" AllowPaging="True" SkinID="GridView">
                        <RowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="EventDate" DataFormatString="{0:D}" HeaderText="Event Date" />
                            <asp:BoundField DataField="EventName" HeaderText="Event" />
                            <asp:BoundField DataField="EventDescription" HeaderText="Description" />
                        </Columns>
                    </asp:GridView>--%>
                     <asp:GridView ID="GridView2" runat="server" DataSourceID="odsEvent" DataKeyNames="DiaryId"
                            AutoGenerateColumns="False" SkinID="GridView" meta:resourcekey="GridView1Resource1">
                            <EmptyDataTemplate>
                                <strong>No Records To Display</strong>.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="DID" runat="server" Value='<%# Bind("DiaryId") %>'></asp:HiddenField>
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" meta:resourcekey="LinkButton2Resource1"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Name" meta:resourcekey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("EventName") %>' meta:resourcekey="Label1Resource1" Width="200px"></asp:Label>
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
                        </asp:GridView>
                </td>
                <td style="width: 100px; height: 20px">
                </td>
                <td style="width: 300px; height: 20px" valign="top">
                    <%--<asp:GridView ID="recentEntriesGridView" runat="server" AutoGenerateColumns="False"
                        Caption="Recent Entries" CaptionAlign="Left" DataSourceID="SqlDataSource2" AllowPaging="True" SkinID="Gridview" PageSize="3">
                        <Columns>
                            <asp:BoundField DataField="EntryTitle" HeaderText="EntryTitle" />
                            <asp:BoundField DataField="EntryText" HeaderText="EntryText" />
                        </Columns>
                    </asp:GridView>--%>
                    &nbsp;</td>
                <td style="width: 300px; height: 20px">
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="odsDiaryEntry" DataKeyNames="DiaryEntryId"
                            AutoGenerateColumns="False" SkinID="GridView" meta:resourcekey="GridView1Resource1">
                            <EmptyDataTemplate>
                                <strong>No Records To Display</strong>.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="DID" runat="server" Value='<%# Bind("DiaryEntryId") %>'></asp:HiddenField>
                                       <%-- <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="Edit"
                                            CommandName="Edit" meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>--%>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete"
                                            Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" meta:resourcekey="LinkButton2Resource1"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Entry Text" meta:resourcekey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("EntryText") %>' meta:resourcekey="Label1Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Entry Title" meta:resourcekey="TemplateFieldResource3">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("EntryTitle") %>' meta:resourcekey="Label8Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                </td>
                <td style="width: 10px; height: 20px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 20px; text-align: left" valign="top">
                    &nbsp;</td>
                <td style="height: 20px"  >
                </td>
            </tr>
            <tr>
                <td colspan="4"   valign="top" style="height: 20px">
                    &nbsp;<%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="Select * from DiaryEvent where EventDate>Now()">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand="Select * from DiaryEntry where Del_Flag=0">
                    </asp:SqlDataSource>--%>
                <asp:ObjectDataSource ID="odsDiaryEntry" runat="server" TypeName="DiaryEntryManager"
                        SelectMethod="GetDiaryEntry" DeleteMethod="DeleteRecord" DataObjectTypeName="DiaryEntry">
                        <SelectParameters>
                            <asp:Parameter Name="id" Type="int16" DefaultValue="0" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsEvent" runat="server" TypeName="DiaryEventManager" 
                        SelectMethod="GetDiaryEvent"  DeleteMethod="DeleteRecord" DataObjectTypeName="DiaryEvent">
                        <SelectParameters>
                            <asp:Parameter Name="id" Type="int16" DefaultValue="0" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td style="height: 20px" >
                    &nbsp;
                </td>
            </tr>
            &nbsp;<tr>
                <td style="width: 200px; height: 19px;" >
                    &nbsp;
                </td>
                <td style="width: 100px; height: 19px;">
                </td>
                <td style="width: 300px; height: 19px;" >
                    <strong></strong></td>
                <td style="width: 300px; height: 19px;">
                </td>
                <td style="height: 19px" >
                </td>
            </tr>
            <tr>
                <td style="width: 200px; height: 306px">
                </td>
                <td style="width: 100px; height: 306px">
                </td>
                <td style="width: 300px; height: 306px">
                </td>
                <td style="width: 300px; height: 306px">
                </td>
                <td style="height: 306px">
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;
    </div>

 </form>
</body>
</html>
