<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmReceiveAssetReport.aspx.vb" Inherits="frmReceiveAssetReport" title="RECEIVE ASSET REPORT" %>

 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RECEIVE ASSET REPORT</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
 <div>
                <center>
                    <h1 class="headingTxt">
                     RECEIVE ASSET REPORT</h1>
                </center>
  <center>
            &nbsp;&nbsp;&nbsp;
            <table class="custTable">
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" SkinID="lblRsz" Text="Asset Type :&nbsp;&nbsp;"
                            EnableViewState="False" TabIndex="-1" Width="150px"></asp:Label>
                    </td>
                    <td align="left">
                                &nbsp;&nbsp<asp:DropDownList ID="ddlassetType" runat="server" DataSourceID="cmbAssetType"
                                    DataValueField="AssetType_IDAuto" AppendDataBoundItems="true" DataTextField="AssetType_Name"
                                    SkinID="ddl" TabIndex="2">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                    </tr>
                
                     <tr>
                    <td colspan="2" class="btnTd">
                        <br />
                        <asp:Button ID="btnReport" runat="server" Text="REPORT" SkinID="btnRsz" ValidationGroup="Submit"
                            TabIndex="8" OnClientClick="return Validate();" CssClass="ButtonClass" />
                        &nbsp;<asp:Button ID="btnback" runat="server" Text="BACK" SkinID="btnRsz" OnClientClick="return Validate();"
                            ValidationGroup="Submit" TabIndex="9" CssClass="ButtonClass" />
                       
                    </td>
                </tr>
                    </table>
                <tr>
                      <td>
                                &nbsp;
                            </td>
                        </tr>
                        </center>
                        <tr>
                            <td colspan="2" style="height: 23px">
                                <center>
                                    <div>
                                        <asp:Label ID="lblmsg" SkinID="lblGreen" runat="server"></asp:Label>
                                        <asp:Label ID="lblErrorMsg" SkinID="lblRed" runat="server"></asp:Label>
                                         &nbsp;<asp:ObjectDataSource ID="cmbAssetType" runat="server" SelectMethod="GetAssetTypescombo"
                            TypeName="AssetDetailsB"></asp:ObjectDataSource>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        </div>
                     </ContentTemplate>
</asp:UpdatePanel>


</form>
</body>
</html>
