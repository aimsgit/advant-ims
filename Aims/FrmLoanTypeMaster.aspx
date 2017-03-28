<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmLoanTypeMaster.aspx.vb" Inherits="FrmLoanTypeMaster" title="Loan Type Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Loan Type Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

<%-- <script type="text/javascript" language="javascript">
       
        function Validate() {
            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").innerText = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblerrmsg.ClientID%>").textContent = msg;
                    document.getElementById("<%=lblmsgifo.ClientID%>").textContent = "";
                    return false;
                }
                return true;
            }
        }
    </script>
--%>
  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

   <asp:UpdatePanel ID="Updatepanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                </a>
            <center>
                <h1 class="headingTxt">
                    <asp:Label ID="Lblheading"  Text ="LOAN TYPE MASTER" runat="server"></asp:Label>
                </h1>
            </center>
            <br />
            <br />
            <center>                <table >
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblLoancode" runat="server" SkinID="lbl" Text="Loan Code*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLoancode" runat="server" SkinID="txtRsz" Width="150" TabIndex="1">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblLoanType" runat="server" Text="Loan Type* :&nbsp;&nbsp;" SkinID="lblRsz"
                                Width="150px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLoanType" runat="server" SkinID="txtRsz" TabIndex="2" Width="150" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSave" runat="server" CommandName="Insert" CssClass="ButtonClass"
                                 SkinID="btn" TabIndex="4" Text="ADD" />
                            &nbsp;<asp:Button ID="btnView" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                SkinID="btn" TabIndex="4" Text="VIEW" />
                            
                        </td>
                    </tr>
                </table>
            </center>
            <table>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <center>
                <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
            </center>
            <center>
                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                    <ProgressTemplate>
                        <div class="PleaseWait">
                            <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </center>
             <center>
                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    PageSize="100" SkinID="GridView" Width="368px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                    <Columns>
                                        
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="Edit" />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                    Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loan Code" Visible="true" SortExpression="LoanCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("LoanMaster_Autoid") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblLoanCode" runat="server" Text='<%# Bind("LoanCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loan Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLoanType" runat="server" Text='<%# Bind("LoanType") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" Width="150" />
                                            <HeaderStyle Wrap="false" HorizontalAlign="Left" Width="150" />
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
            </center>
            <center>
                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="250px" Height="300px">
                </asp:Panel>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
             </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>


