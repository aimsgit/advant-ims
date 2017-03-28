'Imports Microsoft.VisualBasic
'Imports System.Data
'Imports System.IO
'Imports System.Web
'Imports System.Data.OleDb
'Imports System.Web.Security
'Imports System
'Imports System.Web.UI
'Imports System.Web.UI.WebControls
'Imports System.Web.UI.WebControls.WebParts
'Imports System.Web.UI.HtmlControls

Public Class BasePage : Inherits System.Web.UI.Page
    Public new_dbconn1 As New Data.OleDb.OleDbConnection()
    Protected Overrides Sub OnPreInit(ByVal e As System.EventArgs)
        MyBase.OnPreInit(e)
        Dim Theme As String = ConfigurationDB.GetRandomTheme()
        If Session("MyTheme") = "" Then
            Session.Add("MyTheme", Theme)
            Session("MyTheme") = Theme
            Page.Theme = CStr(Session("MyTheme"))
        Else
            Page.Theme = CStr(Session("MyTheme"))
        End If
    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Session("UserName") = "" Or Session Is Nothing Then
        '    FormsAuthentication.RedirectToLoginPage()
        '    Response.Redirect("LogIn.aspx")
        'Else
        '    Dim RequestedPage As String = New System.IO.FileInfo(Request.Url.AbsolutePath).Name
        '    If RequestedPage <> "Main.aspx" And RequestedPage <> "Login.aspx" Then
        '        If UserDetailsDB.CheckRoleElgibility(Session("Username"), Session("UserRole"), Session("Branchcode"), RequestedPage) = 0 Then
        '            HttpContext.Current.Session.Abandon()
        '            Response.Redirect("LogIn.aspx")
        '        End If
        '    End If
        'End If
    End Sub
    Public Sub ValidateFormView(ByVal frmname As String)
    End Sub
    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    End Sub
End Class
