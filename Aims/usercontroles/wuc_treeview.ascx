<%@ Control Language="VB" ClassName="wuc_treeview" %>
<%@ Implements Interface="System.Web.UI.WebControls.WebParts.IWebPart" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="system.Data.sqlclient" %>
<%@ Import Namespace="System.Collections" %>

<script runat="server">
    Private _catalogiconimageurl As String
    Private _description As String
    Private _subtitle As String
    Private _title As String
    Private _titleiconimageurl As String
    Private _titleurl As String
    Public Property CatalogIconImageUrl() As String Implements System.Web.UI.WebControls.WebParts.IWebPart.CatalogIconImageUrl
        Get
            Return Nothing
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property Description() As String Implements System.Web.UI.WebControls.WebParts.IWebPart.Description
        Get
            Return _description
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public ReadOnly Property Subtitle() As String Implements System.Web.UI.WebControls.WebParts.IWebPart.Subtitle
        Get
            Return Nothing
        End Get
    End Property
    Public Property Title() As String Implements System.Web.UI.WebControls.WebParts.IWebPart.Title
        Get
            Return _title
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property TitleIconImageUrl() As String Implements System.Web.UI.WebControls.WebParts.IWebPart.TitleIconImageUrl
        Get
            Return _titleiconimageurl
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Public Property TitleUrl() As String Implements System.Web.UI.WebControls.WebParts.IWebPart.TitleUrl
        Get
            Return Nothing
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    Dim treenode As New TreeNode()
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs)
        'MyTree.CollapseAll()
    End Sub
    Dim ds As New DataTable
    Dim dt As New DataTable
   ' Dim SeeCheck As Boolean=False
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsPostBack Then
            FillTreeView()
            
            Dim treeViewState As New TreeViewState()
            treeViewState.RestoreTreeView(MyTree, Me.GetType.ToString())
        End If
    End Sub
    Private Sub FillTreeView()
        If Not IsPostBack Then
            Try
                If Session("TreeviewSearch") = "" Or Session("TreeviewSearch") = " Search" Then
                    MyTree.Nodes.Clear()
                    ds = Session("ParentList")
                    If ds.Rows.Count > 0 Then
              
                        For i As Int16 = 0 To ds.Rows.Count - 1
                            Dim treenode As New TreeNode()
                            treenode.Text = ds.Rows(i)("Parent_Name").ToString
                            treenode.Value = String.Empty
                            dt = Session("ChildNodes")
                            For j As Int16 = 0 To dt.Rows.Count - 1
                                If ds.Rows(i)("Parent_ID") = dt.Rows(j)("Parent_ID") Then
                                    Dim subNode As New TreeNode
                                    subNode.Text = dt.Rows(j)("Title").ToString()
                                    subNode.Value = "~/" & dt.Rows(j)("LinkName").ToString() & "\" & dt.Rows(j)("Code").ToString()
                                    treenode.ChildNodes.Add(subNode)
                                Else
                                End If
                            Next
                            treenode.SelectAction = TreeNodeSelectAction.Expand
                            MyTree.Nodes.Add(treenode)
                            If i = ds.Rows.Count Then
                                Exit For
                            End If
                            MyTree.CollapseAll()
                        Next
                    End If
                    ds.Dispose()
                    dt.Dispose()
                Else
                    Try
                        txtLinkName.ForeColor = Drawing.Color.Black
                        MyTree.Nodes.Clear()
                        ds.Clear()
                        dt.Clear()
                        ds = UserDetailsDB.SearchParentLinkName(Session("TreeviewSearch"))
                        If ds.Rows.Count > 0 Then
                            For i As Int16 = 0 To ds.Rows.Count - 1
                                Dim treenode As New TreeNode()
                                treenode.Text = ds.Rows(i)("Parent_Name").ToString
                                treenode.Value = String.Empty
                                dt = UserDetailsDB.SearchLinkName(Session("TreeviewSearch"))
                                For j As Int16 = 0 To dt.Rows.Count - 1
                                    If ds.Rows(i)("Parent_ID") = dt.Rows(j)("Parent_ID") Then
                                        Dim subNode As New TreeNode
                                        subNode.Text = dt.Rows(j)("Title").ToString()
                                        subNode.Value = "~/" & dt.Rows(j)("LinkName").ToString() & "\" & dt.Rows(j)("Code").ToString()
                                        treenode.ChildNodes.Add(subNode)
                                    Else
                                    End If
                                Next
                                treenode.SelectAction = TreeNodeSelectAction.Expand
                                MyTree.Nodes.Add(treenode)
                                If i = ds.Rows.Count Then
                                    Exit For
                                End If
                                'MyTree.CollapseAll()
                            Next
                        End If
                        MyTree.FindNode(dt.Rows(0)("Title").ToString())
                        'Response.Redirect(dt.Rows(0)("LinkName").ToString())
                        ds.Dispose()
                        dt.Dispose()
                        Session("TreeviewSearch") = txtLinkName.Text
                    Catch ex As NullReferenceException
                        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
                        FormsAuthentication.SignOut()
                        Roles.DeleteCookie()
                        FormsAuthentication.RedirectToLoginPage()
                    Catch ex As IndexOutOfRangeException
                        txtLinkName.Text = "Search not found."
                        txtLinkName.ForeColor = Drawing.Color.IndianRed
                    End Try
                End If
            Catch ex As NullReferenceException
                Dim i As Int16 = UserDetailsDB.UpdateUserlog()
                FormsAuthentication.SignOut()
                Roles.DeleteCookie()
                FormsAuthentication.RedirectToLoginPage()
            End Try
        End If
    End Sub
   
    Protected Sub Mytree_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyTree.SelectedNodeChanged
        Try
            session("SeeCheck")="True"
            MyTreeViewSelection(MyTree.SelectedNode.Value, MyTree.SelectedNode.Text)
        Catch ex As Exception
            Session("TreeviewSearch") = ""
            txtLinkName.Text = ""
            'MyTreeViewSelection(MyTree.SelectedNode.Value, MyTree.SelectedNode.Text)
        End Try
    End Sub
    Sub MyTreeViewSelection(ByVal SelectedNode As String, ByVal SelectedText As String)
        Try
            'MyTree.SelectedNode.Value=SelectedNode
            If Not SelectedNode = String.Empty Then
                Dim matches As String
                Dim stringItems() As String = SelectedNode.Split("\")
                Dim link As New DataTable
                link = Session("LinknameList")
                matches = "False"
                Dim i As Integer = 0
                For i = 0 To link.Rows.Count - 1
                    If Replace(stringItems(0), "~/", "") = link.Rows(i).Item("LinkName") Then
                        Session("FrmParentName") = link.Rows(i).Item("Parent_Name")
                        Session("Code") = stringItems(1)
                        dt = DLFeedBack.GetSessionValue(stringItems(1))
                        Session("Form") = dt.Rows(0).Item("ChildFileName")
                        matches = "True"
                        Session("HelpLink") = UserDetailsDB.GetHelpLink(link.Rows(i).Item("Code"), "F")
                        Exit For
                    End If
                Next
                If matches = "True" Then
                    Session("RptFrmTitleName") = SelectedText.ToUpper
                    If Session("TestUser") = Session("UserName") Then
                        UserDetailsDB.SaveTestTrace()
                    End If
                    'MyTree.FindNode(Replace(stringItems(0), "~/", "")).Expand()
                    Response.Redirect(Replace(stringItems(0), "~/", ""))
                    Session("FormName") = stringItems(0)
                    MyTree.ExpandAll()
                Else
                    Response.Redirect("AccessDenied.aspx")
                End If
            End If
            MyTree.ExpandAll()
            Session("TreeviewSearch") = Session("TreeviewSearch")
        Catch ex As NullReferenceException
            Response.Redirect("LogIn.aspx")
        End Try
        Session("TreeviewSearch") = Session("TreeviewSearch")
    End Sub
  
    Protected Sub MyTree_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyTree.Unload
        ' Save the state of all nodes.
        Dim treeViewState As New TreeViewState()
        treeViewState.SaveTreeView(MyTree, Me.GetType.ToString())
        'MyTree.CollapseAll()
    End Sub
    Protected Sub txtLinkName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles txtLinkName.TextChanged
        ' Dim SelectedNode As String = "~/"+ HidFileName.Value +"\"+HidCode.Value'~/NewRegistrationLayout.aspx\34
        'MyTreeViewSelection(SelectedNode, txtLinkName.Text)
        
        Session("TreeviewSearch") = txtLinkName.Text
        txtLinkName.ForeColor = Drawing.Color.Black
            MyTree.Nodes.Clear()
            ds.Clear()
            dt.Clear()
             If Session("TreeviewSearch") <> ""  Then
                MyTree.Nodes.Clear()
            
            ds = UserDetailsDB.SearchParentLinkName(Session("TreeviewSearch"))
            Try
            If ds.Rows.Count > 0 Then
                For i As Int16 = 0 To ds.Rows.Count - 1
                    Dim treenode As New TreeNode()
                    treenode.Text = ds.Rows(i)("Parent_Name").ToString
                    treenode.Value = String.Empty
                    dt = UserDetailsDB.SearchLinkName(Session("TreeviewSearch"))
                    For j As Int16 = 0 To dt.Rows.Count - 1
                        If ds.Rows(i)("Parent_ID") = dt.Rows(j)("Parent_ID") Then
                            Dim subNode As New TreeNode
                            subNode.Text = dt.Rows(j)("Title").ToString()
                            subNode.Value = "~/" & dt.Rows(j)("LinkName").ToString() & "\" & dt.Rows(j)("Code").ToString()
                            treenode.ChildNodes.Add(subNode)
                        Else
                        End If
                    Next
                    treenode.SelectAction = TreeNodeSelectAction.Expand
                    MyTree.Nodes.Add(treenode)
                    If i = ds.Rows.Count Then
                        Exit For
                    End If
                    MyTree.ExpandAll()
                Next
            End If
            MyTree.FindNode(dt.Rows(0)("Title").ToString())
                    'Response.Redirect(dt.Rows(0)("LinkName").ToString())
                    ds.Dispose()
                    dt.Dispose()
                    Session("TreeviewSearch") = txtLinkName.Text
            Catch ex As NullReferenceException
            Dim i As Int16 = UserDetailsDB.UpdateUserlog()
            FormsAuthentication.SignOut()
            Roles.DeleteCookie()
            FormsAuthentication.RedirectToLoginPage()
        Catch ex As IndexOutOfRangeException
            txtLinkName.Text = "Search not found.."
            txtLinkName.ForeColor = Drawing.Color.IndianRed
            'MyTree.CollapseAll()
        End Try
        Else
            ds.Clear()
        dt.Clear()
        Session("TreeviewSearch") = ""
        FillTreeView()
        Dim treeViewState1 As New TreeViewState()
        treeViewState1.RestoreTreeView(MyTree, Me.GetType.ToString())
            End If
        
       
        Dim treeViewState As New TreeViewState()
        treeViewState.RestoreTreeView(MyTree, Me.GetType.ToString())
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        ds.Clear()
        dt.Clear()
        Session("TreeviewSearch") = ""
        FillTreeView()
        Dim treeViewState As New TreeViewState()
        treeViewState.RestoreTreeView(MyTree, Me.GetType.ToString())
        'MyTree.CollapseAll()
        Session("Form")="Default.aspx"
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub MyTree_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("LoginType") = "Others" Then
            txtLinkName.Visible = False
            ImageButton1.Visible = False
        End If
    End Sub
</script>

<table>
    <tr>
        <td>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" ImageUrl="~/Images/download.jpg"
                OnClick="ImageButton1_Click" Width="25px" />
        </td>
        <td>
            <asp:TextBox ID="txtLinkName" runat="server" AutoPostBack="true" SkinID="txt" TabIndex="0"
                OnTextChanged="txtLinkName_TextChanged"></asp:TextBox>
            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                SkinID="watermark" TargetControlID="txtLinkName" WatermarkText=" Search">
            </ajaxToolkit:TextBoxWatermarkExtender>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;<asp:HiddenField ID="HidCode" runat="server" />
            <asp:HiddenField ID="HidFileName" runat="server" />
            <asp:TreeView ID="MyTree" runat="server" OnSelectedNodeChanged="MyTree_SelectedNodeChanged"
                OnUnload="MyTree_Unload" SkinID="MSDN" ExpandDepth="0" OnLoad="MyTree_Load">
            </asp:TreeView>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </td>
    </tr>
</table>
