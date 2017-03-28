<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAddSubject.aspx.vb"
    Inherits="frmAddSubject" Title="Subject Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Subject Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script type="text/javascript" language="javascript">
        //Function for Multilingual Validations
        //Created By Niraj
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
        function Valid() {
            var msg;
            msg = NameField100Mul(document.getElementById("<%= txtName.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%= txtName.ClientID %>").focus();
                a = document.getElementById("<%=Label1.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = CodeFieldMul(document.getElementById("<%= txtCode.ClientID %>"));
            if (msg != "") {
                document.getElementById("<%= txtCode.ClientID %>").focus();
                a = document.getElementById("<%=Label2.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }
            msg = validateStrMul(document.getElementById("<%= txtCode.ClientID %>"));
            
            if (msg != "") {
                document.getElementById("<%= txtCode.ClientID %>").focus();
                a = document.getElementById("<%=Label2.ClientID %>").innerHTML;
                msg = Spliter(a) + " " + ErrorMessage(msg);
                return msg;
            }

            return true;
        }
       
        function Validate() {

            var msg = Valid();

            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblRed.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblRed.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblGreen.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
    </script>
<%--<script type="text/javascript">
 var GridId = "<%=GridView1.ClientID %>";
 var ScrollHeight = 300;
 function grid() {
     var grid = document.getElementById(GridId);
     var gridWidth = grid.offsetWidth;
     var gridHeight = grid.offsetHeight;
     var headerCellWidths = new Array();
     for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
         headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
     }
     grid.parentNode.appendChild(document.createElement("div"));
     var parentDiv = grid.parentNode;

     var table = document.createElement("table");
     for (i = 0; i < grid.attributes.length; i++) {
         if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
             table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
         }
     }
     table.style.cssText = grid.style.cssText;
     table.style.width = gridWidth + "px";
     table.appendChild(document.createElement("tbody"));
     table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
     var cells = table.getElementsByTagName("TH");

     var gridRow = grid.getElementsByTagName("TR")[0];
     for (var i = 0; i < cells.length; i++) {
         var width;
         if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
             width = headerCellWidths[i];
         }
         else {
             width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
         }
         cells[i].style.width = parseInt(width) + "px";
         gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
     }
     parentDiv.removeChild(grid);

     var dummyHeader = document.createElement("div");
     dummyHeader.appendChild(table);
     parentDiv.appendChild(dummyHeader);
     var scrollableDiv = document.createElement("div");
     if (parseInt(gridHeight) > ScrollHeight) {
         gridWidth = parseInt(gridWidth) + 10;
     }
     scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth +"px";
     scrollableDiv.appendChild(grid);
     parentDiv.appendChild(scrollableDiv);
 }
</script>--%>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <a name="top">
        <div align="right">
            <a href="#bottom">
                <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
        </div>
    </a>
    <div>
        <%-- <center>
            <h1 class="headingTxt">
                SUBJECT DETAILS
            </h1>
        </center>--%>
        <center>
            <h1 class="headingTxt">
                <asp:Label ID="Lblheading" runat="server"></asp:Label>
            </h1>
        </center>
        <br />
        <br />
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text=" Course Unit/Subject Name*^ :&nbsp;&nbsp;" SkinID="lblRsz"
                                    Width="300px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtName" runat="server" SkinID="txtRsz" TabIndex="1" Width="250"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtName">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="Subject Code*^ :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCode" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="2" Width="150px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="'" TargetControlID="txtCode">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        
                        
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPrinciple" runat="server" Text="Stream/Principal Subject :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                           <%-- <td align="left">
                                <asp:TextBox ID="txtPrincipleSubject" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="3" Width="150px"></asp:TextBox>
                                    </td>--%>
                                <td align="left">
                                        <asp:DropDownList ID="ddlPrincipalSubject" runat="server" AutoPostBack="true" 
                                            DataSourceID="ObjPrincipalSubject" DataTextField="PrincipalSubjectName" DataValueField="PrincipalSubjectNo" 
                                            SkinID="ddlRsz" TabIndex="3" Width="200">
                                        </asp:DropDownList>
                             <asp:ObjectDataSource ID="ObjPrincipalSubject" runat="server" SelectMethod="GetPrincipalSubject"
                                    TypeName="SubjectDB">
                              </asp:ObjectDataSource>
                                </td>         
                        </tr>
                        
                         <tr>
                            <td align="right">
                                <asp:Label ID="lblSubCategory" runat="server" Text="Course Unit/Subject Category:&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                              <td align="left">
                                   <asp:DropDownList ID="ddlSubCategory" runat="server" AutoPostBack="true" 
                                     DataSourceID="ObjSubCategory" DataTextField="SubCategoryName" DataValueField="SubCategoryNo" 
                                     SkinID="ddlRsz" TabIndex="4" Width="200">
                                        </asp:DropDownList>
                             <asp:ObjectDataSource ID="ObjSubCategory" runat="server" SelectMethod="GetSubjectCategory"
                                    TypeName="SubjectDB">
                              </asp:ObjectDataSource>
                                </td>         
                        </tr>
                        
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDeptName" runat="server" Text="Department Name^&nbsp;:&nbsp;&nbsp;"
                                    SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLDeptType" runat="server" DataSourceID="objDept" SkinID="ddlRsz"
                                    DataValueField="DeptID" DataTextField="DeptName" TabIndex="5" Width="250">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="objDept" runat="server" TypeName="SubjectDB" SelectMethod="Getdeptcombo">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSubGrp" runat="server" SkinID="lbl" Text="Subgroup* :&nbsp;&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddloSubGrp" runat="server" SkinID="ddl" TabIndex="6">
                                    <asp:ListItem Value="N">N</asp:ListItem>
                                    <asp:ListItem Value="Y">Y</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                                              
                         <tr>
                            <td align="right">
                                <asp:Label ID="lblPre" runat="server" Text="Pre Requisites :&nbsp;&nbsp;" SkinID="lblRsz"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPre" runat="server" AutoCompleteType="Disabled" SkinID="txtRsz"
                                    MaxLength="50" TabIndex="7" Width="150px"></asp:TextBox>
                                    </td>
                                    </tr>
                        
                        
                        
                        
                        
                        
                        
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnadd" runat="server" Text="ADD" SkinID="btn" CausesValidation="true"
                                    CommandName="ADD" TabIndex="8" OnClientClick="return Validate();" CssClass="ButtonClass" />
                                &nbsp;<asp:Button ID="btnDet" runat="server" Text="VIEW" SkinID="btn" CausesValidation="False"
                                    CommandName="VIEW" TabIndex="9" CssClass="ButtonClass" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <center>
                        <asp:Label ID="lblGreen" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblRed" runat="server" SkinID="lblRed"></asp:Label>
                    </center>
                    <br />
                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            SkinID="GridView"  PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editbutton" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit" />
                                        <asp:LinkButton ID="Button2" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="Delete" Visible="false" OnClientClick="return confirm('Do you want to delete this record?')" />
                                    </ItemTemplate>
                                    <ItemStyle wrap="False" />
                                    <ItemStyle VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject Name" SortExpression="Subject_Name" >
                                    <ItemTemplate>
                                        <asp:HiddenField ID="IID" runat="server" Value='<%# Bind("Subject_ID") %>'></asp:HiddenField>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Subject_Name") %>'></asp:Label>
 
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Code" SortExpression="Subject_Code">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Subject_Code") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="Principal Subject" SortExpression="Principle_Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrin" runat="server" Text='<%# Bind("Principle_Subject") %>'></asp:Label>
                                         <asp:Label ID="lblPrinCode" Visible="false"  runat="server" Text='<%# Bind("PrincipalCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"/>
                                </asp:TemplateField>
                                
                                  <asp:TemplateField HeaderText="Subject Category" SortExpression="SubjectCategory">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubCat" runat="server" Text='<%# Bind("SubjectCategory") %>'></asp:Label>
                                         <asp:Label ID="lblSubCatCode" Visible="false"   runat="server" Text='<%# Bind("SubCatCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False"/>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Department" SortExpression="DeptName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeptID" runat="server" Text='<%# Bind("DeptId") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblDEptName" runat="server" Text='<%# Bind("DeptName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Subgroup Status" SortExpression="Subgrp_Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubgrp" runat="server" Text='<%# Bind("Subgrp_Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Pre Requisites" SortExpression="Pre_Requisites">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPreReq" runat="server" Text='<%# Bind("Pre_Requisites") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
                    <a name="bottom">
                        <div align="right">
                            <a href="#top">
                                <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
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