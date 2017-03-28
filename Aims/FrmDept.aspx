<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmDept.aspx.vb"
    Inherits="FrmDept" Title="Department Details" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Department Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    <script language="javascript" type="text/javascript">

   function Validate(){
  
          var msg=Valid();
          if(msg!=true)
          { 
                    if(navigator.appName=="Microsoft Internet Explorer")
                    {
                     document.getElementById("<%=msginfo.ClientID %>").innerText=msg;
                     document.getElementById("<%=lblmsg.ClientID %>").innerText= "";
                     return false;
                    }
                    else  if(navigator.appName == "Netscape")
                    {  
                     document.getElementById("<%=msginfo.ClientID %>").textContent=msg;
                     document.getElementById("<%=lblmsg.ClientID %>").innerText= "";
                     return false;
                    }   
          }
           return true;
 }

 //Function for Multilingual Validations
 //Created By Ajit Kumar Singh


 function Valid() {

     var msg, a;
     msg = NameField100Mul(document.getElementById("<%=txtName.ClientID %>"));
     if (msg != "") {
         document.getElementById("<%=txtName.ClientID %>").focus();
         a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
         msg = Spliter(a) + " " + ErrorMessage(msg);
         return msg;
     }

     msg = NameField100Mul(document.getElementById("<%=txtCode.ClientID %>"));
     if (msg != "") {
         document.getElementById("<%=txtCode.ClientID %>").focus();
         a = document.getElementById("<%=Label4.ClientID %>").innerHTML;
         msg = Spliter(a) + " " + ErrorMessage(msg);
         return msg;
     }


     return true;
 }

 function ErrorMessage(msg) {
     var SesVar = '<%= Session("Validation") %>';
     var ValidationArray = new Array();
     ValidationArray = SesVar.split(":");
     for (var i = 0; i < ValidationArray.length - 1; i++) {
         if (ValidationArray[i] == msg) {
             return ValidationArray[i + 1];
         }
     }
 }


 function Spliter(a) {
     var str = a;
     var n = str.indexOf("*");
     if (n != 0 && n != -1) {
         a = a.split("*");
         return a[0];
     }
     var n = str.indexOf("^");
     if (n != 0 && n != -1) {
         a = a.split("^");
         return a[0];
     }
     var n = str.indexOf(":");
     if (n != 0 && n != -1) {
         a = a.split(":");
         return a[0];
     }
 }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
            </a>
            <div class="mainBlock">
                <%--<center>
                    <h1 class="headingTxt">
                        DEPARTMENT DETAILS
                    </h1>
                    <br />
                </center>--%>
                <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                </center>
                <center>
                    <center>
                        <table class="custTable">
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Department Name* :&nbsp;&nbsp" SkinID="lblRsz"
                                            Width="213px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtname" runat="server" TabIndex="1" Text='<%# Bind("DeptName") %>'
                                            SkinID="txtRsz" Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label4" runat="server" Text="Department Code*&nbsp;:&nbsp;&nbsp" SkinID="lblRsz"
                                            Width="213px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcode" runat="server" TabIndex="2" Text='<%# Bind("DeptCode") %>'
                                            SkinID="txtRsz" Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                              
                            </tbody>
                            <caption>
                                <tr>
                                <td>
                                      &nbsp;
                                </td>
                                </tr>
                                <tr>
                                    <td class="btnTd" colspan="2">
                                        <center>
                                            <asp:Button ID="InsertButton" runat="server" CssClass="ButtonClass" OnClientClick="return Validate();"
                                               CommandName="ADD" SkinID="btn" Text="ADD" TabIndex="3" ValidationGroup="ADD" />
                                            &nbsp;<asp:Button ID="btnDet" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                               CommandName="VIEW" SkinID="btn" TabIndex="4" Text="VIEW" />
                                            </center>
                                    </td>
                                </tr>
                                </tbody>
                            </caption>
                        </table>
                    </center>
                    <center>
                        <div>
                            &nbsp;</div>
                        <%--div >
                                    <asp:Label ID="lblErrMsg" runat="server" __designer:wfdid="w20"></asp:Label>
                                </div>--%>
                        <%-- <div>
                            &nbsp;</div>--%>
                    </center>
                    </InsertItemTemplate>
                    <emptydatatemplate>
                            <%--No Records To Display.--%>
                            <%--<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                                Text="New" meta:resourcekey="NewButtonResource1"></asp:LinkButton>--%>
                        </emptydatatemplate>
                </center>
                <center>
                    <div>
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="msginfo" runat="server" SkinID="lblRed"></asp:Label>
                    </div>
                    <br />
                </center>
                <center>
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="600px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" SkinID="GridView" DataKeyNames="Dept_ID"
                            AutoGenerateColumns="False" AllowPaging="True" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" Font-Underline="False"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick="return confirm('Do you want to delete the selected record?')"
                                            Text="Delete" Font-Underline="False" Visible="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department Name" SortExpression="DeptName">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="DID" Visible="false" runat="server" Value='<%# Bind("Dept_ID") %>' />
                                        <asp:Label ID="Label2" Visible="true" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Code" SortExpression="DeptCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DeptCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="center"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    &nbsp;
                </center>
            </div>
            <div>
                <asp:ObjectDataSource ID="odsDepartment" runat="server" TypeName="DepartmentManager"
                    SelectMethod="GetDepartmentDtls" DataObjectTypeName="Department"></asp:ObjectDataSource>
            </div>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
