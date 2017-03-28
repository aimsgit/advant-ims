
Partial Class Error_Error404
    Inherits System.Web.UI.Page

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Try
            Mail()
            Response.Redirect("../Default2.aspx", False)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Sub Mail()
        Try
            'SendMail.MailtoSend("Error on page:" & ViewState("ErrorPage").ToString & Session("UserName").ToString, "Error page link:" & Session("ErrorPageLink") & vbCrLf & "Error Message:" & Session("ErrorMsg"))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    ViewState("myPB") = 1
        'Else
        '    ViewState("myPB") = ViewState("myPB") + 1
        'End If
        'If CInt(ViewState("myPB")) > 1 Then
        '    LinkButton2.Attributes.Remove("onclick")
        'End If
        'LinkButton2.Attributes.Add("onclick", "javascript:history.go(-" & ViewState("myPB") & ");window.location.reload(true);return false;")
        'LinkButton2.Attributes.Add("onclick", "javascript:history.go(-1);window.location.reload(true);return false;")
        ViewState("ErrorPage") = Request.QueryString.Get("aspxerrorpath")
        Server.ClearError()
    End Sub
End Class
