<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Main.aspx.vb" Inherits="Main" %>
<%@ Register Src="~/usercontroles/wuc_Themes_Select.ascx" TagName="wuc_Themes_Select"
    TagPrefix="ucl2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Advant Institute Management System</title>
        <link rel="shortcut icon" href="~/Images/favicon.png" type="image/x-icon"/>
              
        <script type="text/javascript">
            function checkEnter(event) {
                if (event.keyCode == 13) {
                    return false;
                }
            }
         </script>

  <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link href="App_Themes/MSN_Default/facebox.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="App_Themes/MSN_Blue/facebox.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="App_Themes/MSN_Green/facebox.css" media="screen" rel="stylesheet" type="text/css" />
    <script src="js/facebox.js" type="text/javascript"></script>

    <script type="text/javascript">
        jQuery(document).ready(function($) {
            $('a[rel*=facebox]').facebox({
                loadingImage: 'Images/loading.gif',
                closeImage: 'Images/closelabel.png'
            })
        })
     </script>
     
<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
        }
    }
    window.onbeforeunload = RefreshParent;
    </script>

        
     <script type="text/javascript">
         $(document).ready(function() {
             //Make facebox popup window draggable
             $(document).bind('reveal.facebox', function() {
                 $("#facebox").draggable({ cursor: "pointer" });
             });
         }); 
     </script>
    <script src="js/Tvalidate.js" type="text/javascript"></script>
    
    <script language="JavaScript" type="text/javascript">
        function autoResize(id) {
            document.getElementById(id).height = document.getElementById(id).contentDocument.documentElement.scrollHeight + 15; //Chrome
            document.getElementById(id).height = document.getElementById(id).contentWindow.document.body.scrollHeight + 15; //FF, IE
            var str = document.getElementById(id).contentWindow.location.href;
            if (str.match(/LogIn/g) == "LogIn") {
                window.location.href = "LogIn.aspx";
            }
            if (str.match(/Default3/g) == "Default3") {
                window.location.href = "Main.aspx";
            }


        }
</script>

<link type="text/css" rel="Stylesheet" href="Styles/jquery-treeview/jquery.treeview.css" />

    <script type="text/javascript" src="Scripts/jquery.min.js"></script>

    <script type="text/javascript" src="Scripts/jquery-treeview/jquery.treeview.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-treeview/TreeListFilter.js"></script>
    <script type="text/javascript">

        $(document).ready(function() {
            $("#navigation").treeview({
                persist: "location",
                collapsed: true,
                unique: true,
                animated: "fast"
            });

            $("#navarea").css("display", "");
        });        
        
    </script>
    <script type="text/javascript">
        $(function() {
            $('#filter').treeListFilter('#navigation', 200);
            collapsed: false
        });
    </script>
    

    <link id="link1" runat="server" href="StyleSheet.css" rel="Stylesheet" />
    <style id="print" media="print" type="text/css">
        #leftSide, #footerSide
        {
            display: none;
        }
    </style>
    <style type="text/css">
        .search { 
    background: #FFF url(Images/TreeSearch.png) no-repeat 4px 4px; 
    border: 1px solid #999; 
    outline:0; 
    padding-left: 25px;
    height:25px; 
    width: 160px; 
  } 
  </style>
    <style type="text/css">
        .style2
        {
            width: 18px;
        }
        .style3
        {
            width: 12px;
        }
        .style4
        {
            width: 1024px;
        }
    </style>
      
</head>

<body onunload="HandleClose();" class="Body">

<script type="text/javascript">
    function GetChildCode(child, Title, HelpLink, FLink) {
        var str = child;
        var str1 = Title;
        var Helpl = HelpLink;
        var LinkName = FLink;

        test(str, str1, LinkName);
        document.getElementById('help').href = Helpl;

    }
    function test(str1, str, LinkName) {
        PageMethods.MyMethod(str, str1, LinkName);
    }
</script>
    
    <script type="text/javascript" language="javascript">

        //window.history.forward(1);style="background-color: #FFEBBF"

        function HandleClose() {
            if (window.event.clientY < 0 && window.event.clientY < -80) {
                //alert("Killing the session on the server!");
                PageMethods.AbandonSession();
            }
        }
        // function changeScreenSize(w,h)
        //     {
        //       window.resizeTo( w,h )
        //     }
        //history.go(1);
        function openwd() {

            window.open('ChatLogin.aspx', '', 'width=565,left=300,top=200,height=440,scrollbars=true').focus


        }
    </script>
<script type="text/javascript" language="javascript">
         function resizeIframe(id, bid) {
             var w = document.getElementById(id).width;
             var but = document.getElementById(bid).value;
             var b = document.getElementById(bid).value;
             var valp = "+";
             var valm = "-";
             if (b == valp) {
                 document.getElementById(id).width = "1000";
                 document.getElementById(bid).value = valm;
             } else {
                 document.getElementById(id).width = "800";
                 document.getElementById(bid).value = valp;
             }
         }
    </script>
<script type="text/javascript" language="javascript">
    function DisableRightClick(event) {
        //For mouse right click
        if (event.button == 2) {
            alert("Right Clicking not allowed!");
        }
    }
</script>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" EnablePageMethods="true" />
    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="MyTree" EventName="SelectedNodeChanged" />
        </Triggers>
        <ContentTemplate>--%>
    <%--<table cellspacing="0" cellpadding="0" border="0" class="header">
        <tr>
            <td style="width: 945px; height: 70px;">
                <asp:Panel ID="HeaderPanel" Height="70px" runat="server" Width="945px">
                    <table>
                        <tr>
                            <td style="width: 100px; height: 70px;" align="left" valign="top">
                                <asp:Image ID="InstituteLogo" runat="server" Height="70px" Style="position: absolute;
                                    top: 0px; left: 0px;" />
                            </td>
                            <td class="style4" align="center">
                                <asp:Label ID="lblSmallTitle" SkinID="lblBig" runat="server" Text="ADVANT INSTITUTE MANAGEMENT SYSTEM"></asp:Label>
                                <br />
                                <asp:Label ID="lblTagLine" runat="server" SkinID="lblSB" Text="ADVANT INSTITUTE MANAGEMENT SYSTEM"></asp:Label>
                                <br />
                                <asp:Label ID="lblTitle" runat="server" SkinID="lblSB" Text="ADVANT INSTITUTE MANAGEMENT SYSTEM"></asp:Label>
                            </td>
                            <td style="width: 100px; height: 70px;" align="right" valign="top">
                                <asp:Image ID="BranchLogo" runat="server" Height="70px" Style="position: absolute;
                                    top: 0px; right: 60px;" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>--%>
    <table cellspacing="0" cellpadding="0" border="0" class="header">
        <tr>
            <td>
                <asp:Panel ID="HeaderPanel" Height="65px" runat="server" BorderStyle="None">
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tr>
                            <td style="width: 100px; height: 65px;" align="left">
                                <asp:Image ID="InstituteLogo" runat="server" Height="65px" BorderStyle="None" />
                            </td>
                            <td class="style4" align="center">
                                <asp:Label ID="lblSmallTitle" SkinID="lblBig" runat="server" Text="ADVANT INSTITUTE MANAGEMENT SYSTEM"></asp:Label>
                                <br />
                                <asp:Label ID="lblTagLine" runat="server" SkinID="lblSB" Text="ADVANT INSTITUTE MANAGEMENT SYSTEM"></asp:Label>
                                <br />
                                <asp:Label ID="lblTitle" runat="server" SkinID="lblSB" Text="ADVANT INSTITUTE MANAGEMENT SYSTEM"></asp:Label>
                            </td>
                            <td style="width: 100px; height: 65px;" align="right">
                                <asp:Image ID="BranchLogo" runat="server" Height="65px" BorderStyle="None" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td colspan="1" class="style2" style="text-align: left; background-color: #ffffff;">
                &nbsp;&nbsp;<a href="FrmLogOut.aspx" style="color: #30502E;
                            position: relative; font-weight: Bold;">LogOut</a>
            </td>
            <td class="headerbar" style="height: 13px; text-align: left">
                <asp:Label ID="lblUserName" runat="server" Style="left: -438px; top: 8px" Text=" lblmsg"
                    Width="576px" Font-Size="8pt"></asp:Label>
                <div style="float: right">
                    <a href="frmfeedback.aspx"  rel="facebox" style="color: Black;position:relative; font-weight: Bold;">Feedback</a>&nbsp;&nbsp;
                    <a href="User Manual.html" id="help" target="_blank" style="color: Black; font-weight: Bold;
                        position: relative;">Help</a>&nbsp;&nbsp; 
                  <%--  <a href="javascript:openwd()" style="color: Black;
                            position: relative; font-weight: Bold;">Live Support</a>--%>
                </div>
            </td>
        </tr>
        <tr>
            <td id="leftSide" class="style3" style="text-align: center; height: 741px; width: 200px;"
                valign="top">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" id="RS" onclick="resizeIframe('IFrame1','RS')" value="+" title="[+] Expand and [-] Contract" style=" border-style: none; font-size: 1.7em; line-height: 0.5em;  color: Black; position:relative;  z-index: auto; background:transparent;">
                <asp:Panel ID="panel" runat="server" SkinID="PNL1">
                 
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="MenuLeft" valign="top">
                                &nbsp;<strong>MENU</strong>
                            </td>
                            <td style="height: 21px">
                            </td>
                        </tr>
                        <tr style="background-color:White;">
                            <td valign="bottom" colspan="2" style="padding-top:.5em;padding-bottom:.5em;">
       
                                 <asp:HiddenField ID="hidChild" runat="server" />
                                <asp:HiddenField ID="hidTitle" runat="server" />
                              <%--<asp:Image ID="Image1" runat="server"  align="left" ImageUrl="~/Images/search-icon.png" Height="23px" width="25px"></asp:Image>--%>
                                <input type="text" autocomplete="off" onkeydown="return checkEnter(event);" class ="search" id="filter" placeholder="Search" title="Enter a Form Name to search" size="18" /><br/>
                                 
                            </td>
                        </tr>
                        <%--<tr style="background-color:White" >
                            <td>
                            &nbsp;
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="width: 185px; height: 20px; text-align: left; background-color: #ffffff;
                                color: #663300" valign="top">
                                <asp:Panel ID="Panelid" runat="server" ScrollBars="Auto" Height="400px">
                                    <%-- <ucl1:wuc_treeview ID="ucrl1theme" runat="server" Title="MENU" />--%>
                                    <div id="navarea" style="width: 200px; height: 100px; float: left;">
        
            <ul id="navigation" class="treeview">
                <asp:Repeater runat="server" ID="Repeater1">
                    <ItemTemplate>
                        <li><div></div>
                        <%--<a href='Default.aspx?name=<%# Eval("Parent_ID") %> disabled="true"' onclick="return false;" style=" text-decoration:None; font-size: 13px;">
                            <%#DataBinder.Eval(Container.DataItem, "Parent_Name")%></a>--%>
                            
                            <span style=" text-decoration:None; font-size: 11px;"><%#DataBinder.Eval(Container.DataItem, "Parent_Name")%></span>
                            <asp:Label id="lblParent" runat="server" Text='<%# Bind("MNIDAuto") %>' Visible="False"></asp:Label>
                            <asp:Repeater runat="server" ID="Repeater2">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                               
                                    <li><a  href='<%# Eval("LinkName") %>'  onclick="GetChildCode('<%#Eval("Code")%>',  '<%#Eval("Title")%>','<%#Eval("HelpLink")%>','<%#Eval("LinkName")%>')" target='iframe_b' onmousedown="DisableRightClick(event)" style=" text-decoration:None; font-size: 11px;">
                                        <%#DataBinder.Eval(Container.DataItem, "Title")%></a>
                                        <%-- <asp:Repeater runat="server" ID="repeatItem" DataSource='<%# Eval("Items")%>'>
                                        <HeaderTemplate><ul></HeaderTemplate>
                                        <ItemTemplate>
                                            <li><a href='Default.aspx?name=<%# Eval("Name") %>'><%# Eval("Name")%></a></li>
                                        </ItemTemplate>
                                        <FooterTemplate></ul></FooterTemplate>
                                    </asp:Repeater>   --%>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul></FooterTemplate>
                            </asp:Repeater>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

    </div>
                                    <table>
                                        <tr>
                                            <td>
                                               <%-- <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" ImageUrl="~/Images/download.jpg"
                                                    OnClick="ImageButton1_Click" Width="25px" />--%>
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="txtLinkName" runat="server" AutoPostBack="true" SkinID="txt" TabIndex="0"
                                                    OnTextChanged="txtLinkName_TextChanged" ></asp:TextBox>
                                                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                    SkinID="watermark" TargetControlID="txtLinkName" WatermarkText=" Search">
                                                </ajaxToolkit:TextBoxWatermarkExtender>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td colspan="2">
                                                &nbsp;<asp:HiddenField ID="HidCode" runat="server" />
                                                <asp:HiddenField ID="HidFileName" runat="server" />
                                                <asp:TreeView ID="MyTree" runat="server" OnSelectedNodeChanged="MyTree_SelectedNodeChanged"
                                                    OnUnload="MyTree_Unload" SkinID="MSDN" ExpandDepth="0" OnLoad="MyTree_Load">
                                                </asp:TreeView>
                                                <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
                                            </td>--%>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td style="height: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 185px; height: 20px;">
                            </td>
                            <td style="height: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" class="MenuLeft">
                                &nbsp;<strong>THEMES</strong>
                            </td>
                            <td style="height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 185px; text-align: left; height: 20px;" valign="top">
                                <%--<ucl2:wuc_Themes_Select ID="ucrlallthem" runat="server" />--%>
                                <asp:RadioButtonList ID="strTheme" runat="server" CssClass="menutextindent" DataTextField="name"
                                    DataValueField="name" OnSelectedIndexChanged="strTheme_SelectedIndexChanged"
                                    OnDataBound="strTheme_DataBound" DataSourceID="ThemeDataSource" AutoPostBack="True"
                                    RepeatDirection="Vertical" SkinID="Themeselect" />
                                <asp:ObjectDataSource ID="ThemeDataSource" runat="server" SelectMethod="GetThemes"
                                    TypeName="nsThemeManager.ThemeManager"></asp:ObjectDataSource>
                                <br />
                            </td>
                            <td style="height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 185px">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <br />
                <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
                <br />
            </td>
            <td colspan="2" valign="top" style="background-color: #ffffff;">
                <div>
                    <%--<blockquote style="text-align: left">--%>
                    <%-- <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">
                        
                        </asp:ContentPlaceHolder>--%>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="MyTree" EventName="SelectedNodeChanged" />
        </Triggers>--%>
                        <ContentTemplate>
                       
                          <iframe id="IFrame1" runat="server" width="100%" height="800" name="iframe_b" src="Default2.aspx"   frameborder="0" style="margin:left;padding-bottom:20px;" ></iframe>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <%-- </blockquote>--%>
                </div>
            </td>
        </tr>
        <tr id="footerSide">
            <td colspan="3" style="background-color: Gray; text-align: center;">
                Software by Advant Techservices India Private Limited (<a href="http://www.advant-tech.com"
                    target="_blank">www.advant-tech.com</a>)<br />
                Phone no.(+91) 080-28605859
            </td>
        </tr>
        <tr id="footerSide">
            <td colspan="2" width="1010px">
                &nbsp;
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
