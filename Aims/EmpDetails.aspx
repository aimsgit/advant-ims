<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EmpDetails.aspx.vb" Inherits="EmpDetails" title="Employee Master" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee Master</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">

<script src="js/Tvalidate.js" type="text/javascript"> </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />


    <div>
<center>
            <h1 class="headingTxt">
                EMPLOYEE DETAILS</h1>
        </center>
       
<center>

            <div>
            <asp:Panel id="Panel1" runat="server" SkinID="Pnl">
                <asp:GridView ID="GVDetails" runat="server" SkinID="GridView" EmptyDataText="There are no records to display."
                    ShowFooter="True" AutoGenerateColumns="False" AllowPaging="True" DataSourceID="ODSEmpDetails"
                    DataKeyNames="Emp_Id">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="Delete" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                <asp:HiddenField ID="EID" runat="server" Value='<%# Bind("Emp_Id") %>'></asp:HiddenField>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Code" DataField="Emp_code" />
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text='<%# GetCategoryName(Convert.ToInt64(Eval("emp_Category"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmploymentType">
                            <ItemTemplate>
                                <asp:Label ID="lblType" runat="server" Text='<%# GetEmpType(Convert.ToInt64(Eval("employment_Type"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch">
                            <ItemTemplate>
                                <asp:Label ID="lblBranch" runat="server" Text='<%# GetBranchName(Eval("Branch_ID")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch Type">
                            <ItemTemplate>
                                <asp:Label ID="Insti" runat="server" Text='<%# GetInstituteName(Convert.ToInt64(Eval("Institute_ID"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department">
                            <ItemTemplate>
                                <asp:Label ID="DeptId" runat="server" Text='<%# GetDepartmentName(Convert.ToInt64(Eval("Dept_ID"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Designation" DataField="Designation" />
                        <asp:BoundField HeaderText="Contact" DataField="Contact_No1" />
                        <asp:BoundField HeaderText="Address" DataField="Emp_Address" />
                        <asp:BoundField HeaderText="City" DataField="Emp_City" />
                        <asp:TemplateField HeaderText="State">
                            <ItemTemplate>
                                <asp:Label ID="State" runat="server" Text='<%# GetStateName(Convert.ToInt64(Eval("State"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="AppointedBy" DataField="Contact_No2" />
                    </Columns>
                </asp:GridView>
                </asp:Panel>
            </div>
        </center>
        
        
  <%-- <cc1:msgBox ID="MsgBox1" runat="server">
   </cc1:msgBox>--%>
   <asp:Label ID="MsgBox1" runat ="server">
   </asp:Label>

<center>
            <table class="custTable">
                <tbody>
                    <tr>
                        <td class="btnTd" colspan="5">
                            <asp:Button ID="btnBack" runat="server" Text="BACK" SkinID="btn" CssClass="btnStyle">
                            </asp:Button>
                            <asp:Button ID="btnPreview" runat="server" Text="REPORT" SkinID="btn" CssClass="btnStyle">
                            </asp:Button>
                            <asp:Button ID="btnRec" runat="server" Text="RECOVER" SkinID="btn" CssClass="btnStyle" Visible="false">
                            </asp:Button></td>
                        <td>
                            <asp:ObjectDataSource ID="ODSEmpDetails" runat="server" DataObjectTypeName="Employee" 
                            DeleteMethod="DeleteRecord" SelectMethod="GetEmpDt" TypeName="EmployeeManager" >
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetEmpDt"
                TypeName="EmployeeManager"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    
                </tbody>
            </table>
        </center>
        
       
        

</div>

</form>
</body>
</html>

