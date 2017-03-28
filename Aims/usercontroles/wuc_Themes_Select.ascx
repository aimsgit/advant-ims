<%@ Control Language="VB" ClassName="wuc_Themes_Select" %>
<%@ Implements Interface="System.Web.UI.WebControls.WebParts.IWebPart" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="nsThemeManager.ThemeManager" %>

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
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        _title = "  Select Theme"
        _description = ""
        _titleiconimageurl = "~/images/menuicon.jpg"
    End Sub
    Sub strTheme_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        strTheme.SelectedValue = Page.Theme
    End Sub
    Sub strTheme_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Session.Add("MyTheme", strTheme.SelectedValue)
        Server.Transfer(Request.FilePath)
    End Sub
    
</script>
<asp:RadioButtonList ID="strTheme" runat="server" CssClass="menutextindent" DataTextField="name" DataValueField="name" OnSelectedIndexChanged="strTheme_SelectedIndexChanged" OnDataBound="strTheme_DataBound" DataSourceID="ThemeDataSource" AutoPostBack="True" RepeatDirection="Vertical"   SkinID="Themeselect" />
<asp:ObjectDataSource ID="ThemeDataSource" runat="server" SelectMethod="GetThemes" TypeName="nsThemeManager.ThemeManager" ></asp:ObjectDataSource> 