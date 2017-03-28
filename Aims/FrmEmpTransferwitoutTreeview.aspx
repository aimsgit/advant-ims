<%@ Page Language="VB" MasterPageFile="~/PopUp.master" AutoEventWireup="false" 
CodeFile="FrmEmpTransferwitoutTreeview.aspx.vb" Inherits="FrmEmpTransferwitoutTreeview" title="EmployeeTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
    &nbsp;<script type="text/javascript" language="javascript">
              function Valid() {
                  var msg;
                  msg = AutoCompleteExtenderForThree(document.getElementById("<%=txtEmp.ClientID %>"), 'Employee Code');
                  document.getElementById("<%=txtEmp.ClientID %>").focus();
                  if (msg != "") return msg;
                  msg = ValidateDate(document.getElementById("<%=txtDOL.ClientID %>"), 'Date Of Leaving');
                  if (msg != "") {
                      document.getElementById("<%=txtDOL.ClientID %>").focus();
                      return msg;
                  }
                  msg = DropDownForZero(document.getElementById("<%=ddlToBrch.ClientID %>"), 'To Branch');
                  document.getElementById("<%=ddlToBrch.ClientID %>").focus();
                  if (msg != "") return msg;
                  msg = ValidateDate(document.getElementById("<%=txtDOJ.ClientID %>"), 'Date Of Joining');
                  if (msg != "") {
                      document.getElementById("<%=txtDOJ.ClientID %>").focus();
                      return msg;
                  }
                  return true;
              }
              function Validate() {
                  var msg = Valid();
                  if (msg != true) {
                      if (navigator.appName == "Microsoft Internet Explorer") {
                          document.getElementById("<%=lblmsg.ClientID %>").innerText = msg;
                          document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                          return false;
                      }
                      else if (navigator.appName == "Netscape") {
                          document.getElementById("<%=lblmsg.ClientID %>").textContent = msg;
                          document.getElementById("<%=msginfo.ClientID %>").innerText = "";
                          return false;
                      }
                  }
                  return true;
              }


              function ShowImage() {
                  GlbShowSImage(document.getElementById("<%=txtEmp.ClientID%>"));

              }
              function HideImage() {
                  GlbHideSImage(document.getElementById("<%=txtEmp.ClientID%>"));
              }
              function SplitName() {
                  var text = document.getElementById("<%=txtEmp.ClientID%>").value;
                  var split = text.split(':');
                  if (split.length > 0) {
                      document.getElementById("<%=txtEmp.ClientID%>").innerText = split[0];
                      document.getElementById("<%=txtEmpName.ClientID%>").innerText = split[1];
                      document.getElementById("<%=HidempId.ClientID%>").innerText = split[2];
                      document.getElementById("<%=txtEmpBranch.ClientID%>").innerText = split[3];
                  }
              } 
       
       
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--  <center>
                        <h1 class="headingTxt">
                            EMPLOYEE TRANSFER
                        </h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:HiddenField ID="HidempId" runat="server" />
                                    <asp:Label ID="Label1" runat="server" Text=" Employee Code*&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmp" runat="server" SkinID="Rsztxt" Width="150px" TabIndex="1"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="Server" TargetControlID="txtEmp"
                                        ServicePath="TextBoxExt.asmx" ServiceMethod="getEmpCodeExt2" OnClientPopulating="ShowImage"
                                        OnClientPopulated="HideImage" MinimumPrefixLength="3" CompletionInterval="2000"
                                        CompletionListCssClass="completeListStyle" FirstRowSelected="true" OnClientItemSelected="SplitName"
                                        EnableCaching="true">
                                    </ajaxToolkit:AutoCompleteExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" WatermarkText="Type first 3 characters"
                                        runat="server" TargetControlID="txtEmp" SkinID="watermark">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" Text="Employee Name&nbsp;:&nbsp;&nbsp;" SkinID="lblRsz"
                                        Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpName" runat="server" Width="150px" SkinID="Rsztxt" AutoPostBack="true"
                                        DataSourceID="ObjEmpName" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Date of Leaving*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDOL" runat="server" SkinID="Rszxtxt" Width="150px" MaxLength="11"
                                        TabIndex="2"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDOL"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text=" From Branch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"
                                        Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpBranch" runat="server" Width="295px" SkinID="txtRsz" DataSourceID="ObjFromBranch"
                                        Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text="To Branch*&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlToBrch" runat="server" DataSourceID="ObjToBranch" DataTextField="BranchName"
                                        DataValueField="BranchCode" SkinID="ddlL" Width="250px" TabIndex="3">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbldate" runat="server" Text="Date of Joining*&nbsp;:&nbsp;&nbsp;"
                                        SkinID="lblRsz" Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDOJ" runat="server" Width="150px" SkinID="txt" TabIndex="4"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOJ"
                                        Format="dd-MMM-yyyy" Animated="False">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks&nbsp;:&nbsp;&nbsp;" SkinID="lbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" Height="100px" Width="150px" runat="server"
                                        SkinID="txtRsz" TabIndex="4"></asp:TextBox>
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
                                <td align="center" class="btnTd">
                                    <asp:Button ID="BtnSave" runat="server" CausesValidation="True" CssClass="ButtonClass"
                                        OnClientClick="return Validate();" SkinID="btn" Text="SUBMIT" TabIndex="5" />
                                    &nbsp;<asp:Button ID="BtnDetails" runat="server" CausesValidation="False" CssClass="ButtonClass"
                                        SkinID="btn" Text="VIEW" TabIndex="6" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <div>
                                            <asp:Label ID="msginfo" runat="server" SkinID="lblGreen"></asp:Label>
                                            <asp:Label ID="lblmsg" runat="server" SkinID="lblRed"></asp:Label>
                                            <br />
                                        </div>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
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
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="650px" Height="300px">
                                        <center>
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                SkinID="GridView" PageSize="100" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code" SortExpression="Emp_Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Emp_Code")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name" SortExpression="Emp_Name">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="HidEmpId" runat="server" Value='<%# Bind("EmpID") %>' />
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Emp_Name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DOJ" SortExpression="DOJ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("DOJ","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="New Branch" SortExpression="BranchName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("BranchName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DOL" SortExpression="DOL">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("DOL","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="false" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Duration(Days)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Duration","{0:0}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approval Status" SortExpression="AppStatus">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("AppStatus") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Applicant Remarks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("TranferRemarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Remarks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Approver_Remarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </center>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <asp:ObjectDataSource ID="ObjToBranch" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetBranchTypecombo" TypeName="EmpTranferB"></asp:ObjectDataSource>
                        </table>
                    </center>
                </div>
                <style type="text/css">
                    .completeListStyle
                    {
                        height: 100px;
                        width: 50px;
                        overflow: auto;
                        list-style-type: disc;
                        padding-left: 17px;
                        background-color: #FFF;
                        border: 1px solid DarkGray;
                        text-align: left;
                        font-size: small;
                        color: black;
                    }
                </style>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnDetails" EventName="Click"></asp:AsyncPostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

