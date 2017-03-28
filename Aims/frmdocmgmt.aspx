<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmdocmgmt.aspx.vb"
    Inherits="frmdocmgmt" Title="Document Management" EnableEventValidation="false"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Document Management</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>
<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>
            <script type="text/javascript">
//        function RefreshParent() {
//            if (window.opener != null && !window.opener.closed) {
//            alert("Hello")
//                window.opener.location.reload();
//            }
//        }
//      window.onbeforeunload = RefreshParent;
    </script>
    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;

            //            msg = NameField100(document.getElementById("<%=FileUpload1.ClientID %>"), 'Browse File');
            //            if (msg != "") {
            //                document.getElementById("<%=FileUpload1.ClientID %>").focus();
            //                return msg;
            //            }

            msg = NameField100(document.getElementById("<%=txtdesc.ClientID %>"), 'Description');
            if (msg != "") {
                document.getElementById("<%=txtdesc.ClientID %>").focus();
                return msg;
            }

            msg = NameField100(document.getElementById("<%=txtRev.ClientID %>"), 'Rev No');
            if (msg != "") {
                document.getElementById("<%=txtRev.ClientID %>").focus();
                return msg;
            }

            msg = NameField100(document.getElementById("<%=txtRevDate.ClientID %>"), 'Rev Date');
            if (msg != "") {
                document.getElementById("<%=txtRevDate.ClientID %>").focus();
                return msg;
            }


            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblG.ClientID %>").innerText = "";
                    document.getElementById("<%=lblR.ClientID %>").innerText = msg;
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblG.ClientID %>").innerText = "";
                    document.getElementById("<%=lblR.ClientID %>").textContent = msg;
                    return false;
                }
            }
            return true;
        }
        function openwindow(link) {
            alert("inside link")
            window.open('file:\\' + link, '', 'width=500,height=400,scrollbars=false').focus
        }

    </script>

<form id="Form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnupload" />
            <asp:PostBackTrigger ControlID="btnlink" />
            <%-- <asp:AsyncPostBackTrigger ControlID="btnupload" EventName="Click" />--%>
            <asp:PostBackTrigger ControlID="gvdoc" />
        </Triggers>
        <ContentTemplate>
            <a name="top">
                <div align="right">
                    <a href="#bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton" runat="server"></asp:LinkButton>
                </div>
                <div>
                    <%--<center>
                        <h1 class="headingTxt">
                            FEE STRUCTURE
                        </h1>
                    </center>--%>
                    <center>
                    <h1 class="headingTxt">
                        <asp:Label ID="Lblheading" runat="server"></asp:Label>
                    </h1>
                    </center>
                    <br />
                    <br />
                </div>
                <center>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblbrowse" runat="server" SkinID="lblRsz" Text="Browse File*  :&nbsp;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="White" SkinID="btn"
                                    TabIndex="1" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lbldesc" runat="server" Text="Description*^  :&nbsp;" SkinID="lblRsz"
                                    Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtdesc" runat="server" SkinID="txtRsz" Width="200px" TextMode="MultiLine"
                                    TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;&nbsp;<asp:Label ID="lblrev" runat="server" Text="Review No* :&nbsp;" SkinID="lblRsz"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRev" runat="server" SkinID="txt" TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;&nbsp;<asp:Label ID="lblRevdate" runat="server" Text="Review Date* :&nbsp;" SkinID="lblRsz"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRevDate" runat="server" TabIndex="4" SkinID="txt"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                    TargetControlID="txtRevDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks  :&nbsp;" SkinID="lblRsz"
                                    Width="200px"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtremarks" runat="server" SkinID="txtRsz" Width="200px" TabIndex="5"
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <center>
                    <table>
                        <tr>
                            <td class="btnTd">
                                <asp:Button ID="btnupload" runat="server" CssClass="ButtonClass" SkinID="btn" Text="UPLOAD"
                                    TabIndex="6" ValidationGroup="Validate" OnClientClick="return Validate();" />
                                &nbsp;
                                <asp:Button ID="btnlink" runat="server" CssClass="ButtonClass" SkinID="btn" Text="LINK"
                                    TabIndex="7" ValidationGroup="Validate" OnClientClick="return Validate();" visible="false"/>
                                &nbsp;
                                <asp:Button ID="btnsearch" runat="server" CssClass="ButtonClass" SkinID="btn" Text="VIEW"
                                    TabIndex="8" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
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
                        <tr>
                            <td>
                                <asp:Label ID="lblR" runat="server" SkinID="lblRed"></asp:Label>
                                <asp:Label ID="lblG" runat="server" SkinID="lblGreen"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </a>
            <center>
                <table class="custtable">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Panel ID="panel1" runat="server" ScrollBars="Auto" Width="750px" Height="300px">
                                    <asp:GridView ID="gvdoc" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                        PageSize="100" SkinID="GridView" Style="overflow: auto; width: 760px" Visible="False"
                                        Width="621px" AllowSorting="True" EnableSortingAndPagingCallbacks="True">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="false" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Edit"
                                                        Text="Edit" TabIndex="10"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                                        OnClientClick="return confirm('Do you want to delete the selected record?')"
                                                        Text="Delete" TabIndex="11"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="false" CommandName="Select"
                                                        Text="Assign" TabIndex="12"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description" SortExpression="Description" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsemname" runat="server" Text='<%# Bind("Description") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rev No" SortExpression="RevNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcatname" runat="server" Text='<%# Bind("RevNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rev Date" SortExpression="RevDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfeehead" runat="server" Text='<%# Bind("RevDate", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left" SortExpression="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamt" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="false" />
                                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="true" />
                                                <HeaderStyle HorizontalAlign="left" Wrap="false" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description" SortExpression="Link">
                                                <ItemTemplate>
                                                     <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                              
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Link" SortExpression="Link">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFid" Visible="false" runat="server" Text='<%# Bind("FID") %>' />
                                                     <asp:LinkButton ID="link" runat="server" CommandArgument = '<%# Eval("Link") %>' OnClick="DownloadFile" Text="Download" ForeColor="Blue" />  
                                              
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </center>
            <a name="bottom">
                <div align="right">
                    <a href="#top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                    <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</body>
</html>

