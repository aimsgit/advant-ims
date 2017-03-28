<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" CodeFile="frmSelfDetailsTenantSel.aspx.vb"
    Inherits="frmSelfDetailsTenantSel" Title="Modules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <h1 class="headingTxt">
            MODULES</h1>
    </center>
    <br />
    <center>
        <asp:GridView ID="GVSelfDet" runat="server" AutoGenerateColumns="False" SkinID="GridView"
            Visible="True" EmptyDataText="There are no records to display.">
            <Columns>
                <%-- <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnedit" runat="server" CausesValidation="false" CommandName="Edit"
                        Text="Edit" SkinID="btn" />
                    <asp:HiddenField ID="lblId" runat="server" Value='<%# Bind("MyCo_Id") %>'></asp:HiddenField>
                </ItemTemplate>
                <ItemStyle Wrap="False" />
            </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Module Names">
                    <ItemTemplate>
                        <asp:Label ID="lblParentName" runat="server" Text='<%# Bind("Parent_Name") %>'></asp:Label>
                        <asp:Label ID="lblGVMNIDAuto" Visible="false" runat="server" Text='<%# Bind("MNIDAuto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="ChkAll" Width="50px" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSelect" Visible="false" runat="server" Text='<%# Bind("Allowed") %>'></asp:Label>
                        <asp:CheckBox ID="ChkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </center>
    <br />
    <center>
        <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" SkinID="btn" CssClass="ButtonClass"
            TabIndex="1"></asp:Button>
        &nbsp;<asp:Button ID="btnBack" runat="server" Text="BACK" SkinID="btn" CssClass="ButtonClass"
            TabIndex="2"></asp:Button>
    </center>
    <center>
        <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
        <asp:Label ID="lblgreen" runat="server" SkinID="lblGreen"></asp:Label>
    </center>
</asp:Content>
