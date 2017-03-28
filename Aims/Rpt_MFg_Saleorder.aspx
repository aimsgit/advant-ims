<%@ Page Title="Sale Order Report" Language="VB" AutoEventWireup="false" CodeFile="Rpt_MFg_Saleorder.aspx.vb" Inherits="Rpt_MFg_Saleorder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sale Order Report</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
<script type="text/javascript" language="javascript">


        function Valid() {
            var msg;

            msg = ValidateDate(document.getElementById("<%=txtStartDate.ClientID %>"), 'Start Date');
            if (msg != "") {
                document.getElementById("<%=txtStartDate.ClientID %>").focus();
                return msg;
            }
            msg = ValidateDate(document.getElementById("<%=txtEndDate.ClientID %>"), 'EndDate');
            if (msg != "") {
                document.getElementById("<%=txtEndDate.ClientID %>").focus();
                return msg;
            }
                return true;
            }

            function Validate() {

                var msg = Valid();
                if (msg != true) {
                    if (navigator.appName == "Microsoft Internet Explorer") {
                        document.getElementById("<%=lblErrorMsg1.ClientID %>").innerText = msg;
                        
                        return false;
                    }
                    else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblErrorMsg1.ClientID %>").textContent = msg;
                       
                        return false;
                    }
                }
                return true;
            }
     </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

     <center>
        <h1 class="headingTxt">
            SALE ORDER</h1>
    </center>
    <br />
  
     <asp:UpdatePanel ID="UpdatePanel" runat="server">
      <ContentTemplate>
            <center>


<table>
                    
                   
                    </tr>
                        <tr>
                        <td align="right">
                            <asp:Label ID="lblbuyer" runat="server" SkinID="lbl" Text="Buyer&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DDlBuyer" SkinID="ddlRsz" AutoPostBack="true" DataSourceID="ObjBuyer"
                                DataTextField="Party_Name" DataValueField="PartyAutoNo" runat="server" TabIndex="1"
                                Width="300px">
                                 <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        </tr>
                      
                        
                        <tr>
                        <td align="right">
                            <asp:Label ID="lblSO" runat="server" SkinID="lbl" Text="Sale Order No&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSO" runat="server" SkinID="ddl" AutoPostBack="true" DataSourceID="ObjSO"
                                                DataTextField="Sale_Order_Number" DataValueField="Sales_Order_ID" AppendDataBoundItems="false" TabIndex="2">
                                                <asp:ListItem Value="0" >ALL</asp:ListItem>
                                            </asp:DropDownList>
                        </td>
                        </tr>
                        
                        <tr>
                        <td align="right">
                            <asp:Label ID="lblStartDate" runat="server" SkinID="lbl" Text="Start Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStartDate" runat="server" TabIndex="3"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartDate"
                                        Format="dd-MMM-yyyy" SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                        </td>
                        </tr>
                        
                        <tr>
                        <td align="right">
                            <asp:Label ID="lblEndDate" runat="server" SkinID="lbl" Text="End Date&nbsp;:&nbsp;&nbsp;"></asp:Label>
                            
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" TabIndex="4"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
                                        Format="dd-MMM-yyyy" SkinID="CalendarView">
                                    </ajaxToolkit:CalendarExtender>
                        </td>
                        </tr>
                         <tr>
                    <td> &nbsp;</td>
                    <td> &nbsp;</td>
                    </tr>
                    
                         <tr>
                        <td colspan="5" class="btnTd">
                            <asp:Button ID="btnReport" runat="server" Text="REPORT" CssClass="ButtonClass " CausesValidation="true"
                                SkinID="btn" OnClientClick="return Validate();" TabIndex="12" />
                            <asp:Button ID="btnBack" runat="server" Text="BACK" CausesValidation="False" SkinID="btn"
                                CssClass="ButtonClass" TabIndex="13" />
                        </td>
                    </tr>
                    
                        </table>
                        </center> 
                         <center>
                                            <div>
                                                <asp:Label ID="lblErrorMsg1" runat="server" SkinID="lblRed"></asp:Label>
                                            </div>
                                        </center>
                        <asp:ObjectDataSource ID="ObjBuyer" runat="server" SelectMethod="BuyerComboD" TypeName="MfgSORpt">
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjSO" runat="server" TypeName="MfgSORpt" SelectMethod="GetSalesID">
                                 <SelectParameters>
                            <asp:ControlParameter ControlID="DDlBuyer" Name="PartyAutoNo" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                       </asp:ObjectDataSource>
                        </center>
        </ContentTemplate>
                         </asp:UpdatePanel>


</form>
</body>
</html>


