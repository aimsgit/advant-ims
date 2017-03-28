
Partial Class Home
    Inherits System.Web.UI.MasterPage
    Dim new_dbconn1 As New OleDbConnection
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
         Dim i As Int16 = UserDetailsDB.UpdateUserlog()
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
        FormsAuthentication.SignOut()
        Roles.DeleteCookie()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
    
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
          If Session("UserName") = "" Then
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         Try
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
            Dim i As Int16 = UserDetailsDB.UpdateUserlog()
            FormsAuthentication.SignOut()
            Roles.DeleteCookie()
            FormsAuthentication.RedirectToLoginPage()
        End Try
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        HttpContext.Current.Session.Abandon()
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    End Sub
End Class

