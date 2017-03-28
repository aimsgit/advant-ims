<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmInvestmentSectionMaster.aspx.vb" Inherits="frmInvestmentSectionMaster" title="Investment section master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Investment section master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                 <div>
                  <center>
                        <h2 class="headingTxt">
                            <asp:Label ID="Lblheading" Text="INVESTMENT SECTION MASTER" runat="server"></asp:Label>
                        </h2>
                    </center>
                     <div>
                    <center>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                        <table>
                        
                            
                             <tr>
                            <td align="right">
                                <asp:Label ID="lblSection" runat="server" Text="Section*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:DropDownList ID="ddlSection" runat="server" TabIndex="1" AutoPostBack="True" DataSourceID="ObjSection"
                                    DataTextField="Data" DataValueField="LookUpAutoID" SkinID="ddlRsz"
                                     AppendDataBoundItems="True" Width="200">
                                    
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjSection" runat="server" SelectMethod="GetSectionCombo"
                                    TypeName="DLInvestmentSectionMaster"></asp:ObjectDataSource>
                                </td>
                                </tr>
                                
                                <tr>
                            <td align="right">
                                <asp:Label ID="lblDescription" runat="server" SkinID="lbl" Text="Description*&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtDescription" TabIndex ="2" runat="server" SkinID="txtRsz" TextMode="MultiLine"
                                    Width="198px" Height="50px" ></asp:TextBox>
                            </td>
                        </tr>
                        
                        
                        
                         <tr>
                            <td align="right" >
                                <asp:Label ID="lblSubDescription"  runat="server" SkinID="lblRsz"  Width ="200Px"  Text="Sub Description*&nbsp;:&nbsp;&nbsp;" wr></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSubDescription" runat="server" TabIndex ="3" SkinID="txtRsz" TextMode="MultiLine"
                                    Width="198px" Height="50px" ></asp:TextBox>
                            </td>
                            
                        </tr>
                        
                        
                        <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr align="center">
                        <td align="center" colspan="2">
                            <asp:Button ID="btnsave" runat="server" CommandName="Insert" CssClass="ButtonClass"
                                 SkinID="btn" TabIndex="4" Text="ADD" />
                            &nbsp;
                            <asp:Button ID="btndetails" runat="server" TabIndex="5" CausesValidation="False"
                                CssClass="ButtonClass" SkinID="btn" Text="VIEW" />
                        </td>
                    </tr>
                
                    <center>
             
                        
                        
                        
                        
                        
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                <ProgressTemplate>
                                    <div class="PleaseWait">
                                        <asp:Label ID="lblprocess" runat="server" Text="Processing your request..Please wait..."
                                            SkinID="lblBlackRsz" Width="300" Visible="True"></asp:Label>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    </table>
                <br />
                    
                    
                    <center>
                                <asp:Label ID="lblErrorMsg" runat="server" SkinID="lblRed"></asp:Label>
                                &nbsp;
                                <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                            </center>
                            <br />
                       
                   
                           
                                <asp:Panel ID="panel2" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False"> 
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                        Text="Edit" Font-Underline="False"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" Visible="True" Font-Underline="False">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false"></ItemStyle>
                                                <ItemStyle HorizontalAlign="Left" Font-Underline="False" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ControlStyle Font-Underline="False" />
                                            </asp:TemplateField>
                                            
                                          
                                            
                                         
                                            
                                            
                                           <asp:TemplateField HeaderText="Section">
                                                <ItemTemplate>
                                                
                                                    <asp:Label ID="lblData" runat="server" Text='<%# Bind("Data") %>'></asp:Label>
                                                    <asp:Label ID="LblSection" Visible="false" runat="server" Text='<%# Bind("Section_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"  VerticalAlign="Top" Wrap="false" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            
                                            
                                            
                                     <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                <ItemTemplate>
                                                    
                                                     <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("InvSection_Auto_ID") %>' />
                                                    <asp:Label ID="LblDescription" runat="server"  Text='<%# Bind("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"  VerticalAlign="Top" Wrap="False" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sub Description" SortExpression="SubDescription">
                                                <ItemTemplate>
                                                   
                                                    <asp:Label ID="lblSubDescription" runat="server" Text='<%# Bind("SubDescription") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left"  VerticalAlign="Top" Wrap="False" />
                                                <HeaderStyle HorizontalAlign="left" /> 
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                            </asp:Panel> 
                             <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
               
              
           
            <a name="bottom">
                        <div align="right">
                            <a href="#top">
                                <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                            <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                        </div>
                    </a>
                
                
                </ContentTemplate>
    </asp:UpdatePanel>
     </center>
    </div>
    
</form>
</body>
</html>

                        
                        
                        
                        
                        
                        
                        
                              