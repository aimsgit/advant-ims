<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmBranchDetails.aspx.vb"
    Inherits="FrmBranchDetails" Title="Branch Details" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Branch Details</title>
    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
</head>

<body style="width: 800px; height: 800px">
<script src="js/Tvalidate.js" type="text/javascript"> </script>

    <script language="JavaScript" type="text/javascript">
        function Valid() {
            var msg;
            msg = DropDown(document.getElementById("<%=ddlHO.ClientID %>"), 'Head Office');
            if (msg != "") return msg;
            msg = DropDown(document.getElementById("<%=ddlBrnType.ClientID %>"), 'Branch Type');
            if (msg != "") return msg;
            msg = DropDown(document.getElementById("<%=ddlRptBrn.ClientID %>"), 'Report Branch');
            if (msg != "") return msg;
            msg = NameField100(document.getElementById("<%=txtBrnName.ClientID %>"), 'Branch Name');
            if (msg != "") return msg;
            msg = NameField250E(document.getElementById("<%=txtBrnAddrs.ClientID %>"), 'Address');
            if (msg != "") return msg;
            msg = numeric(document.getElementById("<%=txtBreakTime.ClientID %>"), 'BreakTime');
            if (msg != "") return msg;
            msg = NameField100N(document.getElementById("<%=txtFromEmailID.ClientID %>"), 'From Email-ID');
            if (msg != "") return msg;
            msg = NameField100N(document.getElementById("<%=txtFromPassword.ClientID %>"), 'Password');
            if (msg != "") return msg;
            msg = NameField100N(document.getElementById("<%=txtSMTPHost.ClientID %>"), 'SMTP Host');
            if (msg != "") return msg;
            return true;
        }

        function Validate() {
            var msg = Valid();
            if (msg != true) {
                if (navigator.appName == "Microsoft Internet Explorer") {
                    document.getElementById("<%=lblval.ClientID %>").innerText = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").innerText = "";
                    return false;
                }
                else if (navigator.appName == "Netscape") {
                    document.getElementById("<%=lblval.ClientID %>").textContent = msg;
                    document.getElementById("<%=lblmsg.ClientID %>").textContent = "";
                    return false;
                }
            }
            return true;
        }
        function ShowImage1() {
            GlbShowSImage(document.getElementById("<%=txtAcctBranch.ClientID%>"));
        }
        function HideImage1() {
            GlbHideSImage(document.getElementById("<%=txtAcctBranch.ClientID%>"));
        }
        function SplitBank() {
            var text = document.getElementById("<%=txtAcctBranch.ClientID%>").value;
            var split = text.split(':');
            if (split.length > 0) {
                document.getElementById("<%=txtAcctBranch.ClientID%>").innerText = split[1];
                document.getElementById("<%=HidBankId.ClientID%>").value = split[0];
            }
        }
    </script>

    <script type="text/javascript">
        var GridId = "<%=GrdBranch.ClientID %>";
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
            scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
            scrollableDiv.appendChild(grid);
            parentDiv.appendChild(scrollableDiv);
        }
    </script>

  <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
 
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload1" />
            <asp:PostBackTrigger ControlID="btnBranchImg" />
            <%--<asp:AsyncPostBackTrigger ControlID="Btnadd" EventName="Click" />--%>
        </Triggers>
        <ContentTemplate>
            <a name="Top">
                <div align="right">
                    <a href="#Bottom">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/down.png" Width="30px" Height="30px" /></a>
                </div>
                <div>
                    <%--         <center>
                        <h1 class="headingTxt">
                            BRANCH MASTER</h1>
                    </center>--%>
                    <center>
                        <h1 class="headingTxt">
                            <asp:Label ID="Lblheading" runat="server"></asp:Label>
                        </h1>
                    </center>
                    <table>
                        <tr>
                            <td align="right">
                                <center>
                                    <table class="custTable">
                                        <tr>
                                            <td style="width: 122px">
                                                &nbsp;
                                            </td>
                                            <td style="width: 120px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtId" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblHO" runat="server" Text="Head office* :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlHO" runat="server" DataSourceID="odsHO" DataTextField="BranchName"
                                                    DataValueField="BranchCode" SkinID="ddlRsz" Width="250" TabIndex="1" AppendDataBoundItems="true"
                                                    AutoPostBack="True">
                                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBrnType" runat="server" Text="Branch Type* :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBrnType" runat="server" DataSourceID="ObjBranchType" DataValueField="Code"
                                                    DataTextField="Name" SkinID="ddl" TabIndex="2" Width="175px" AutoPostBack="True"
                                                    AppendDataBoundItems="true">
                                                    <asp:ListItem Selected="true" Value="Select">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblRptBrn" runat="server" Text="Report Branch* :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRptBrn" runat="server" SkinID="ddlRsz" DataValueField="BranchCode"
                                                    DataTextField="BranchName" TabIndex="3" Width="250px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBrnName" runat="server" Text="Branch Name* :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBrnName" runat="server" TabIndex="4" TextMode="MultiLine" SkinID="txtRsz"
                                                    CausesValidation="true" Width="250"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr visible="false">
                                            <td align="right">
                                                <asp:Label ID="lblBrnCode" Visible="false" runat="server" Text="Code* :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBrnCode" Visible="false" runat="server" TabIndex="5" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBrnAddrs" runat="server" Text="Address* :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBrnAddrs" runat="server" TabIndex="6" TextMode="MultiLine" SkinID="txtRsz"
                                                    Width="250"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblContactNo" runat="server" Text="Contact No :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtContactNo" runat="server" TabIndex="7" SkinID="txt" ToolTip="Accept 10 or 12 characters(eg:9812121212)"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                    FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789+,/\-" TargetControlID="txtContactNo">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblSMSService" runat="server" Text="SMS Service :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSMSService" runat="server" TabIndex="8" SkinID="ddl" CausesValidation="true">
                                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblEmailService" runat="server" Text="Email Service :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEmailService" runat="server" TabIndex="9" SkinID="ddl" CausesValidation="true">
                                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblDesignation" runat="server" Text="Designation :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddldesignation" runat="server" DataSourceID="obdesig" SkinID="ddl"
                                                    DataTextField="Designation" DataValueField="DesignationCode" AutoPostBack="True"
                                                    TabIndex="10" CausesValidation="true" AppendDataBoundItems="true">
                                                    <asp:ListItem Selected="true" Value="Select">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </td>
                            <td align="left">
                                <center>
                                    <table class="custTable">
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="TextBox1" runat="server" SkinID="txt" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblemployee" runat="server" Text="Contact Person :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlemp" runat="server" SkinID="ddl" AutoPostBack="True" TabIndex="11">
                                                    <asp:ListItem Selected="true" Value="Select">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblAcctBranch" runat="server" Text="Acct Bank :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAcctBranch" runat="server" TabIndex="12" BorderColor="White"
                                                    SkinID="txt" CausesValidation="true"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" OnClientPopulated="HideImage1"
                                                    OnClientPopulating="ShowImage1" TargetControlID="txtAcctBranch" MinimumPrefixLength="3"
                                                    CompletionInterval="1000" FirstRowSelected="true" EnableCaching="true" ServiceMethod="getBankExt"
                                                    ServicePath="TextBoxExt.asmx" OnClientItemSelected="SplitBank" CompletionListCssClass="completeListStyle">
                                                </ajaxToolkit:AutoCompleteExtender>
                                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                    SkinID="watermark" TargetControlID="txtAcctBranch" WatermarkText="Type first 3 characters">
                                                </ajaxToolkit:TextBoxWatermarkExtender>
                                                <asp:HiddenField ID="HidBankId" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label1" runat="server" Text="AccountNo :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtacc" runat="server" TabIndex="13" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBreakTime" runat="server" Text="BreakTime :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBreakTime" runat="server" TabIndex="14" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                    FilterType="Custom" FilterMode="ValidChars" ValidChars="1234567890" TargetControlID="txtBreakTime">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblFromEmailID" runat="server" Text="From Email-ID :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromEmailID" runat="server" TabIndex="15" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblFromPassword" runat="server" Text="Password :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromPassword" runat="server" TabIndex="16" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblSMTPHost" runat="server" Text="SMTP Host :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSMTPHost" runat="server" TabIndex="17" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblAccredited" runat="server" Text="Accredited :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAccredited" runat="server" TabIndex="18" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblwebsite" runat="server" Text="Website :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtwebsite" runat="server" TabIndex="19" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblPffAcct" runat="server" Text="PF Account No :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpfAcct" runat="server" TabIndex="20" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table class="custTable">
                        <tr>
                            <td align="right">
                                <center>
                                    <table class="custTable">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblAffiliatedTo" runat="server" Text="Affiliated To :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAffiliatedTo" runat="server" TabIndex="21" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblApprovedBy" runat="server" Text="Approved By :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtApprovedBy" runat="server" TabIndex="22" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblTagline" runat="server" SkinID="lbl" Text="TagLine :&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtTagline" runat="server" TextMode="MultiLine" TabIndex="23" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblSPassword" runat="server" SkinID="lbl" Text="<i>s</i>&nbsp;Password :&nbsp;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSPassword" runat="server" TextMode="Password" TabIndex="24" SkinID="txt"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </td>
                            <td align="left">
                                <center>
                                    <table class="custTable">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblBranchRegistationNo" runat="server" Text="Branch Registration No :&nbsp;"
                                                    Width="227px" SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBranchRegistationNo" runat="server" TabIndex="25" SkinID="txt"
                                                    CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblbiometric" runat="server" Width="227px" Text="Biometric Device No :&nbsp;"
                                                    SkinID="lblRsz"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtbiometric" runat="server" TabIndex="26" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblStatus" runat="server" SkinID="lbl" Text="Status :&nbsp;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DDLStatus" runat="server" SkinID="ddl">
                                                    <asp:ListItem Selected="True" Value="A">Active</asp:ListItem>
                                                    <asp:ListItem Value="S">Suspend</asp:ListItem>
                                                    <asp:ListItem Value="R">Resume</asp:ListItem>
                                                    <asp:ListItem Value="C">Closed</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblCreationdate" runat="server" SkinID="lblRsz" Text="Creation Date :&nbsp;"
                                                    Width="150px"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCreationDate" runat="server" SkinID="txt"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Animated="False"
                                                    Format="dd-MMM-yyyy" TargetControlID="txtCreationDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblEmail" runat="server" Text="Email-ID :&nbsp;" SkinID="lbl"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server" TabIndex="29" SkinID="txt" CausesValidation="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <center>
                        <table class="custTable">
                            <tr>
                                <td align="left">
                                    <center>
                                        <table class=" custTable">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblLogo" runat="server" Text="Logo :&nbsp;" SkinID="lbl"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <br />
                                                    <asp:Image ID="ImageMap1" runat="server" Height="90px" Width="100px" />
                                                    <br />
                                                    <br />
                                                    <asp:Button ID="btnUpload1" runat="server" CssClass="ButtonClass" SkinID="btn" TabIndex="26"
                                                        Text="UPLOAD" Visible="true" Width="85px" />
                                                    <br />
                                                    <br />
                                                    <%--<asp:TextBox ID="txtpath" runat="server" Text='<%# Bind("Logo") %>' Visible="False"></asp:TextBox>--%>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" SkinID="btn" TabIndex="14" Width="200px" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="BranchImage" runat="server" Text="Branch Image :&nbsp;" SkinID="lbl"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <br />
                                                    <asp:Image ID="BranchImg" runat="server" Height="90px" Width="100px" />
                                                    <br />
                                                    <br />
                                                    <asp:Button ID="btnBranchImg" runat="server" CssClass="ButtonClass" SkinID="btn"
                                                        TabIndex="27" Text="UPLOAD" Visible="true" Width="85px" />
                                                    <br />
                                                    <br />
                                                    <%--<asp:TextBox ID="txtpath" runat="server" Text='<%# Bind("Logo") %>' Visible="False"></asp:TextBox>--%>
                                                    <asp:FileUpload ID="FileUpload2" runat="server" SkinID="btn" TabIndex="14" Width="200px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </td>
                        </table>
                    </center>
                    <center>
                        <table class="custTable">
                            <tr>
                                <td>
                                    <table class="custTable">
                                        <tr>
                                            <td align="right">
                                                <asp:CheckBox ID="ChkHoName" runat="server" Checked="true" Text="Include HO Name"
                                                    TabIndex="27" SkinID="txt"></asp:CheckBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="custTable">
                                        <tr>
                                            <td align="left">
                                                <asp:CheckBox ID="ChkTeacherSubject" runat="server" Text="Teacher to Subject Mapping"
                                                    TabIndex="28" SkinID="txt"></asp:CheckBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                        </table>
                    </center>
                    <center>
                        <table>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Btnadd" runat="server" Text="ADD" CausesValidation="true" SkinID="btn"
                                        OnClientClick="return Validate();" CssClass="ButtonClass" TabIndex="21"></asp:Button>
                                    &nbsp;<asp:Button ID="Btnview" runat="server" Text="VIEW" CausesValidation="true"
                                        SkinID="btn" CssClass="ButtonClass " TabIndex="22"></asp:Button>
                                    <asp:Button ID="btnsearch" runat="server" Text="SEARCH" Visible="false" SkinID="btn"
                                        CssClass="ButtonClass "></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <div>
                        &nbsp;</div>
                    <center>
                        <asp:Label ID="lblmsg" runat="server" SkinID="lblGreen"></asp:Label>
                        <asp:Label ID="lblval" runat="server" SkinID="lblRed"></asp:Label>
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
                    <div>
                        &nbsp;</div>
                    <center>
                        <asp:Panel ID="panel1" runat="server" Width="750px" Height="350px" ScrollBars="Vertical">
                            <asp:GridView ID="GrdBranch" runat="server" SkinID="GridView" Visible="true" AllowPaging="true"
                                AutoGenerateColumns="False" PageSize="1000" ScrollBars="Vertical">
                                <Columns>
                                    <asp:TemplateField ShowHeader="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Edit"
                                                Text="Edit" TabIndex="23"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Delete"
                                                Text="Delete" TabIndex="24" OnClientClick="return confirm('Do you want to delete the selected record?')"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="Update"
                                                Text="Branch Deletion" TabIndex="23" OnClientClick="return confirm('Do you want to delete the selected Branch Data?')"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Type" SortExpression="BranchTypeName">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelType" runat="server" Text='<%# Bind("BranchTypeName") %>'></asp:Label>
                                            <asp:HiddenField ID="HidTypeID" runat="server" Value='<%# Bind("BranchTypeCode") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name" SortExpression="BranchName">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelName" runat="server" Text='<%# Bind("BranchName") %>'></asp:Label>
                                            <asp:Label ID="LabelId" runat="server" Visible="false" Text='<%# Bind("Branch_ID") %>'></asp:Label>
                                            <asp:Label ID="lblBranchCode" runat="server" Visible="false" Text='<%# Bind("BranchCode") %>'></asp:Label>
                                            <asp:Label ID="lblTagline" runat="server" Visible="false" Text='<%# Bind("TagLine") %>'></asp:Label>
                                            <asp:Label ID="lblSpassword" runat="server" Visible="false" Text='<%# Bind("SPassword") %>'></asp:Label>
                                            <asp:Label ID="lblIncludeHOName" runat="server" Visible="false" Text='<%# Bind("IncludeInsName") %>'></asp:Label>
                                            <asp:Label ID="lblSMSService" runat="server" Visible="false" Text='<%# Bind("SMSService") %>'></asp:Label>
                                            <asp:Label ID="lblEmailService" runat="server" Visible="false" Text='<%# Bind("EmailService") %>'></asp:Label>
                                            <asp:Label ID="lblAffiliatedTo" runat="server" Visible="false" Text='<%# Bind("AffiliatedTo") %>'></asp:Label>
                                            <asp:Label ID="lblApprovedBy" runat="server" Visible="false" Text='<%# Bind("ApprovedBy") %>'></asp:Label>
                                            <asp:Label ID="lblAccredited" runat="server" Visible="false" Text='<%# Bind("Accredited") %>'></asp:Label>
                                            <asp:Label ID="lblBranchRegistationNo" runat="server" Visible="false" Text='<%# Bind("BranchRegistationNo") %>'></asp:Label>
                                            <asp:Label ID="lblPfAcct" runat="server" Visible="false" Text='<%# Bind("PFAcct") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="LabelBankID" runat="server" Text='<%# Bind("BankId") %>'></asp:Label>
                                            <asp:Label Visible="false" ID="LabelBank_Name" runat="server" Text='<%# Bind("Bank_Name") %>'></asp:Label>
                                            <%----%>
                                            <asp:HiddenField ID="HidBID" runat="server" Value='<%# Bind("Branch_ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="Labelcode" runat="server" Text='<%# Bind("SlssbCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="Labeladdrs" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelCt" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Person">
                                        <ItemTemplate>
                                            <asp:Label ID="Label17" runat="server" Visible="false" Text='<%# Bind("Emp_Code") %>'></asp:Label>
                                            <asp:Label ID="Label18" runat="server" Visible="true" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AccountNo">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelAcc" runat="server" Text='<%# Bind("AccountNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Expiry Date" SortExpression="ExpiryDate">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelBkBr" runat="server" Text='<%# Bind("ExpiryDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Creation date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreationdate" runat="server" Text='<%# Bind("Creationdate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                    <asp:ObjectDataSource ID="odsHO" runat="server" SelectMethod="FillHO" TypeName="BranchManager">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjBranchType" runat="server" SelectMethod="FillBranchType"
                        TypeName="BranchManager" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="obdesig" runat="server" TypeName="BLIndividualFormMaster"
                        SelectMethod="GetDesignation" OldValuesParameterFormatString="original_{0}">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjDistrict" runat="server" SelectMethod="GetAllDistrict"
                        TypeName="BranchManager" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                </div>
                <a name="Bottom">
                    <div align="right">
                        <a href="#Top">
                            <asp:Image ID="Image2" runat="server" ImageUrl="Images/top.png" Width="30px" Height="30px" /></a>
                        <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>
                    </div>
                </a>
        </ContentTemplate>
    </asp:UpdatePanel>

</form>
</body>
</html>
