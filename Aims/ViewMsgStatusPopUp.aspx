<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="ViewMsgStatusPopUp.aspx.vb"
    Inherits="ViewMsgStatusPopUp" Title="View Message Status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mainBlock">
                <center>
                    <h1 class="headingTxt">
                        MESSAGE STATUS </h1>
                </center>
<center>
<table> 
<tr>
<td>
<asp:Label ID ="lblMsg" runat ="server" SkinID ="lblGreen" ></asp:Label>
<asp:Label ID ="lblError" runat ="Server" SkinID ="lblRed"></asp:Label>
</td>
</tr>
</table>
</center> 
    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="850px" Height="400px">
        <asp:GridView ID="GvViewStatus" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="CMID" PageSize="100" SkinID="GridView">
            <Columns>
                 <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:HiddenField ID="IID" runat="server" Value='<%# Eval("CMIDAuto") %>' />
                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date","{0:dd-MMM-yyyy}") %>'></asp:Label>
                        <asp:HiddenField ID="hidCMID" runat="server" Value='<%# Bind("CMID") %>' />
                    </ItemTemplate>
                    <ItemStyle Wrap="False" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Message"  ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" >
                    <ItemTemplate>
                        <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("Message") %>' Width="200px"></asp:Label>
                    </ItemTemplate>
                   <%--  <ItemStyle Wrap ="false" />--%>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMsg" runat="server" Text='<%# Bind("Message") %>' Width="200px"></asp:TextBox>
                    </EditItemTemplate>
                    <%--<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />--%>
                   <%-- <HeaderStyle HorizontalAlign="Center" />--%>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' Width="150px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Approval Status">
                    <ItemTemplate>
                        <asp:Label ID="lblAppStatus" runat="server" Text='<%# Bind("AppStatus") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Message From">
                    <ItemTemplate>
                        <asp:Label ID="lblMsgFrm" runat="server" Text='<%# Bind("MsgFrom") %>' Width="150px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <%--<ItemStyle Wrap="false" />--%>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Communication Mode">
                    <ItemTemplate>
                        <asp:Label ID="lblCommMode" runat="server" Text='<%# Bind("CommunicationMode") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="GroupType" ControlStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="lblGroupType" runat="server" Text='<%# Bind("GroupType") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Course Name" ControlStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="lblCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Batch Name" ControlStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="lblBatchNo" runat="server" Text='<%# Bind("BatchNo") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name" ControlStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="lblStdName" runat="server" Text='<%# Bind("StdName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Route No" ControlStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="lblRouteName" runat="server" Text='<%# Bind("RouteName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Name" ControlStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="lblEmp_Name" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                
              
            </Columns>
        </asp:GridView>
    </asp:Panel>
    </div> 
   
    </ContentTemplate> 
     </asp:UpdatePanel> 
</asp:Content>
