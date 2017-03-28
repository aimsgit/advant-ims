
Imports System.Web.UI.WebControls.WebParts 
Imports System.Data.SqlClient
Imports System.Collections
Imports System.IO.DirectoryInfo

Partial Class Main
    Inherits BasePage
    Implements System.Web.UI.WebControls.WebParts.IWebPart
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            
            _title = "  Select Theme"
            _description = ""
            _titleiconimageurl = "~/images/menuicon.jpg"
            If Not IsPostBack Then
                If Session("FrmParentName") <> "" Then
                    Me.lblUserName.Text = "User : " & IIf(Session("StudentName") Is DBNull.Value Or Session("StudentName") = "", Session("EmpName"), Session("StudentName")) & ", Branch : " & Session("BranchName") & ",  >> " & Session("FrmParentName") & " > " & Session("RptFrmTitleName")
                    lblSmallTitle.Text = Session("BranchName")
                    lblTagLine.Text = Session("TagLine")
                    If Session("IncludeInsName") = "Y" Then
                        lblTitle.Text = Session("ReportBranchName")
                    Else
                        lblTitle.Text = ""
                    End If
                    If Session("Logo") = "NULL" Or Session("Logo") = Nothing Then
                        BranchLogo.Visible = False
                    Else
                        BranchLogo.Visible = True
                        Me.BranchLogo.ImageUrl = Session("Logo")
                    End If
                    If Session("InstituteLogo") = "NULL" Or Session("InstituteLogo") = Nothing Then
                        InstituteLogo.Visible = False
                    Else
                        InstituteLogo.Visible = True
                        Me.InstituteLogo.ImageUrl = Session("InstituteLogo")
                    End If
                    lblSmallTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                    lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                    HeaderPanel.BackImageUrl = Session("ImgHeader").ToString
                Else
                    Me.lblUserName.Text = "User : " & IIf(Session("StudentName") Is DBNull.Value Or Session("StudentName") = "", Session("EmpName"), Session("StudentName")) & ", Branch : " & Session("BranchName") '& " , Institute : " & Session("InstituteName") '& ", >> " & Session("FrmParentName") & " > " & Session("RptFrmTitleName")
                    lblSmallTitle.Text = Session("BranchName")
                    lblTagLine.Text = Session("TagLine")
                    If Session("IncludeInsName") = "Y" Then
                        lblTitle.Text = Session("ReportBranchName")
                    Else
                        lblTitle.Text = ""
                    End If
                    If Session("Logo") = "NULL" Or Session("Logo") = Nothing Then
                        BranchLogo.Visible = False
                    Else
                        BranchLogo.Visible = True
                        Me.BranchLogo.ImageUrl = Session("Logo")
                    End If
                    If Session("InstituteLogo") = "NULL" Or Session("InstituteLogo") = Nothing Then
                        InstituteLogo.Visible = False
                    Else
                        InstituteLogo.Visible = True
                        Me.InstituteLogo.ImageUrl = Session("InstituteLogo")
                    End If

                    lblSmallTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                    lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                    HeaderPanel.BackImageUrl = Session("ImgHeader").ToString
                End If
                If Session("UserID") <> "" Then
                    Me.lblUserName.Text = "User : " & IIf(Session("StudentName") Is DBNull.Value Or Session("StudentName") = "", Session("EmpName"), Session("StudentName")) & ", Branch : " & Session("BranchName") '& ", Institute : " & Session("InstituteName") '& ", >> " & Session("FrmParentName") & " > " & Session("RptFrmTitleName")
                    lblSmallTitle.Text = Session("BranchName")
                    lblTagLine.Text = Session("TagLine")
                    If Session("IncludeInsName") = "Y" Then
                        lblTitle.Text = Session("ReportBranchName")
                    Else
                        lblTitle.Text = ""
                    End If
                    If Session("Logo") = "NULL" Or Session("Logo") = Nothing Then
                        BranchLogo.Visible = False
                    Else
                        BranchLogo.Visible = True
                        Me.BranchLogo.ImageUrl = Session("Logo")
                    End If
                    If Session("InstituteLogo") = "NULL" Or Session("InstituteLogo") = Nothing Then
                        InstituteLogo.Visible = False
                    Else
                        InstituteLogo.Visible = True
                        Me.InstituteLogo.ImageUrl = Session("InstituteLogo")
                    End If
                    lblSmallTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                    lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(Session("HeaderTextColor").ToString)
                    HeaderPanel.BackImageUrl = Session("ImgHeader").ToString
                Else
                    Dim i As Int16 = UserDetailsDB.UpdateUserlog()
                    FormsAuthentication.SignOut()
                    Roles.DeleteCookie()
                    FormsAuthentication.RedirectToLoginPage()
                End If
                'If Session("Refresh") = "" Then
                '    FillTreeView()
                '    Dim treeViewState As New TreeViewState()
                '    TreeViewState.RestoreTreeView(MyTree, Me.GetType.ToString())
                'End If


            End If
            Dim dt As DataTable = New DataTable()
            Dim con As SqlConnection = New SqlConnection( _
                    ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
            con.Open()

            Dim comm As SqlCommand = New SqlCommand("Proc_GetParentNameN", con)
            comm.Parameters.Add("@ID", SqlDbType.VarChar)
            comm.Parameters("@ID").Value = Session("UserRole")
            comm.Parameters.Add("@BranchCode", SqlDbType.VarChar)
            'If (Session("ParentBranch") = "000000000000") Then
            comm.Parameters("@BranchCode").Value = Session("ParentBranch")
            'Else
            'comm.Parameters("@BranchCode").Value = Session("BranchCode")
            'End If
            comm.Parameters.Add("@Office", SqlDbType.VarChar)
            comm.Parameters("@Office").Value = Session("Office")
            comm.Parameters.Add("@LanguageID", SqlDbType.Int)
            comm.Parameters("@LanguageID").Value = Session("LanguageID")
            comm.CommandType = CommandType.StoredProcedure
            Dim da As SqlDataAdapter = New SqlDataAdapter(comm)
            da.Fill(dt)

            IFrame1.Attributes("src") = Session("Form")
            IFrame1.Attributes.Add("onload", "autoResize('IFrame1');")

            If Not IsPostBack Then
                Repeater1.DataSource = dt
                Repeater1.DataBind()
            End If
        Catch ex As Exception
            Session.Clear()
            Session("UserName") = ""
            Session.Abandon()
            Response.CacheControl = "no-cache"
            Response.AddHeader("Pragma", "no-cache")
            Response.Expires = -1
            Response.Buffer = True
            Response.ExpiresAbsolute = Now()
            Response.Expires = 0
            Response.CacheControl = "no-cache"
            Response.Redirect("Login.aspx")
            Dim i As Int16 = UserDetailsDB.UpdateUserlog()
            'FormsAuthentication.SignOut()
            'Roles.DeleteCookie()
            'FormsAuthentication.RedirectToLoginPage()
        End Try

    End Sub
    <System.Web.Services.WebMethod()> _
Public Shared Function MyMethod(ByVal name As String, ByVal code As Integer, ByVal Link As String) As String

        Dim t As New TextBoxExt
        t.title(name, code, Link)
        Return Nothing
    End Function
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        HttpContext.Current.Session.Abandon()
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    End Sub

    Private _catalogiconimageurl As String
    Private _description As String
    Private _subtitle As String
    Private _title As String
    Private _titleiconimageurl As String
    Private _titleurl As String
    Private Function ProductData(ByVal MNIDAuto As String) As DataTable

        Dim dt As DataTable = New DataTable()
        Dim con As SqlConnection = New SqlConnection( _
                ConfigurationManager.ConnectionStrings("Advant").ConnectionString)
        con.Open()

        Dim commp As SqlCommand = New SqlCommand("Proc_GetCutomizeLinkNameN", con)

        commp.Parameters.Add("@ID", SqlDbType.VarChar)
        commp.Parameters("@ID").Value = Session("UserRole")
        commp.Parameters.Add("@BranchCode", SqlDbType.VarChar)
        'If (Session("ParentBranch") = "000000000000") Then
        commp.Parameters("@BranchCode").Value = Session("ParentBranch")
        'Else
        'commp.Parameters("@BranchCode").Value = Session("BranchCode")
        'End If
        commp.Parameters.Add("@Office", SqlDbType.VarChar)
        commp.Parameters("@Office").Value = Session("Office")
        commp.Parameters.Add("@LanguageID", SqlDbType.Int)
        commp.Parameters("@LanguageID").Value = Session("LanguageID")
        commp.Parameters.Add("@MNID", SqlDbType.Int)
        commp.Parameters("@MNID").Value = MNIDAuto
        commp.CommandType = CommandType.StoredProcedure



        Dim da As SqlDataAdapter = New SqlDataAdapter(commp)
        da.Fill(dt)


        con.Close()
        Return dt
    End Function

    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim drv As DataRowView = DirectCast(e.Item.DataItem, DataRowView)
            Dim MNIDAuto As String = (drv("MNIDAuto"))
            Dim Repeater2 As Repeater = DirectCast(e.Item.FindControl("Repeater2"), Repeater)
            Repeater2.DataSource = ProductData(MNIDAuto)
            Repeater2.DataBind()
            'Session("RptFrmTitleName") = Request.QueryString.Get("Title")
        End If
    End Sub
    Protected Sub MyTree_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("LoginType") = "Others" Then
            'txtLinkName.Visible = False
            'ImageButton1.Visible = False
        End If
    End Sub

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

    Sub strTheme_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        strTheme.SelectedValue = Page.Theme
    End Sub
    Sub strTheme_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session.Add("MyTheme", strTheme.SelectedValue)
        Server.Transfer(Request.FilePath)
    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    End Sub

End Class
