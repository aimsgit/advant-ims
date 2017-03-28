<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmTaxServiceReport.aspx.vb" Inherits="FrmTaxServiceReport" title="Service Tax Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Service Tax Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate >
  <center>
                <h1 class="headingTxt">
                   SERVICE TAX REPORT
                </h1>
            </center>
            <center>
           
                <table>
                 <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                <tr>
                <td align="right">
                                        <asp:HiddenField ID="Hidyear" runat="server" />
                                        <asp:Label ID="lblLoanType" SkinID="lblRsz"  runat="server" Text="From Year*&nbsp;:&nbsp;&nbsp;"
                                            ></asp:Label>
                                    </td>
                                    <td align="left" >
                                        <asp:DropDownList ID="ddlfromyear" runat="server" DataTextField="Data" DataSourceID="ObjLoanType"
                              
                                            DataValueField="LookUpAutoID" Width="150px" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjLoanType" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetYearDDL" TypeName="DLProffessionTax">
                                            </asp:ObjectDataSource>
                       </td> 
                 <td align="right">
                                        <asp:HiddenField ID="Hidyear2" runat="server" />
                                        <asp:Label ID="lbltoyear" SkinID="lblRsz" runat="server" Width ="100px" Text="To Year*&nbsp;:&nbsp;&nbsp;"
                                            ></asp:Label>
                                    </td>
                                    <td align="left" >
                                        <asp:DropDownList ID="ddltoyear" runat="server" DataTextField="Data" DataSourceID="ObjLoanType"
                              
                                            DataValueField="LookUpAutoID" Width="150px" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetYearDDL" TypeName="DLProffessionTax">
                                            </asp:ObjectDataSource>
                       </td> 
                       
                
                                
                </tr>
                           
                 <tr>
                                    <td align="right">
                                        <asp:Label ID="lblfrmMonth" runat="server" Text="From Month*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                         <asp:DropDownList ID="ddlMonth" runat="server" Width="150px" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                         <asp:ListItem Text ="Select" Value ="0"></asp:ListItem>
                                         <asp:ListItem Text ="January" Value ="1"></asp:ListItem>
                                          <asp:ListItem Text ="February" Value ="2"></asp:ListItem>
                                           <asp:ListItem Text ="March" Value ="3"></asp:ListItem>
                                            <asp:ListItem Text ="April" Value ="4"></asp:ListItem>
                                             <asp:ListItem Text ="May" Value ="5"></asp:ListItem>
                                              <asp:ListItem Text ="June" Value ="6"></asp:ListItem>
                                               <asp:ListItem Text ="July" Value ="7"></asp:ListItem>
                                                <asp:ListItem Text ="August" Value ="8"></asp:ListItem>
                                                 <asp:ListItem Text ="September" Value ="9"></asp:ListItem>
                                                  <asp:ListItem Text ="October" Value ="10"></asp:ListItem>
                                                   <asp:ListItem Text ="November" Value ="11"></asp:ListItem>
                                                    <asp:ListItem Text ="December" Value ="12"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                     <td align="right">
                                        <asp:Label ID="lblToMonth" runat="server" Text="To Month*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                                    </td>
                                    <td align="left">
                                         <asp:DropDownList ID="ddlToMonth" runat="server" Width="150px" SkinID="ddlRsz" TabIndex="1" AutoPostBack="true">
                                         <asp:ListItem Text ="Select" Value ="0"></asp:ListItem>
                                         <asp:ListItem Text ="January" Value ="1"></asp:ListItem>
                                          <asp:ListItem Text ="February" Value ="2"></asp:ListItem>
                                           <asp:ListItem Text ="March" Value ="3"></asp:ListItem>
                                            <asp:ListItem Text ="April" Value ="4"></asp:ListItem>
                                             <asp:ListItem Text ="May" Value ="5"></asp:ListItem>
                                              <asp:ListItem Text ="June" Value ="6"></asp:ListItem>
                                               <asp:ListItem Text ="July" Value ="7"></asp:ListItem>
                                                <asp:ListItem Text ="August" Value ="8"></asp:ListItem>
                                                 <asp:ListItem Text ="September" Value ="9"></asp:ListItem>
                                                  <asp:ListItem Text ="October" Value ="10"></asp:ListItem>
                                                   <asp:ListItem Text ="November" Value ="11"></asp:ListItem>
                                                    <asp:ListItem Text ="December" Value ="12"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                             
                
                </table>
                </center>
                <center >
                <table >
                <tr>
                &nbsp;
                </tr>
                 <tr>
                                    <td colspan="2"> 
                                        <asp:Button ID="btnReport" runat="server" CausesValidation="False" CommandName="Insert"
                                            CssClass="ButtonClass" SkinID="btn" TabIndex="14" Text="REPORT" />
                                        &nbsp;<asp:Button ID="btnBack" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                            SkinID="btn" TabIndex="15" Text="BACK" />
                                    </td>
                                </tr>
                
                
                </table>
                 <center>
                    <asp:Label ID="lblerrmsg" runat="server" SkinID="lblRed" Visible="true"></asp:Label>
                    <asp:Label ID="lblmsgifo" runat="server" SkinID="lblGreen" Visible="true"></asp:Label>
                </center>
                
                
                </center>
</ContentTemplate>
</asp:UpdatePanel> 

</form>
</body>
</html>

