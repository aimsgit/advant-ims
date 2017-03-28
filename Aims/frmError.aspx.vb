
Partial Class Error_frmError
    Inherits System.Web.UI.Page
    Dim ex As Exception = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the last error from the server
        Dim ex As Exception = Server.GetLastError

        ' Create a safe message
        Dim safeMsg As String = "A problem has occurred in the web site. "

        ' Show Inner Exception fields for local access
        If ex.InnerException IsNot Nothing Then
            innerTrace.Text = ex.InnerException.StackTrace
            InnerErrorPanel.Visible = Request.IsLocal
            innerMessage.Text = ex.InnerException.Message
        End If

        ' Show Trace for local access
        'If Request.IsLocal Then
        exTrace.Visible = True
        ' Else
        ex = New Exception(safeMsg, ex)
        ' End If

        ' Fill the page fields
        exMessage.Text = ex.Message
        exTrace.Text = ex.StackTrace

        ' Log the exception and notify system operators
        ExceptionUtility.LogException(ex, "Generic Error Page")
        ExceptionUtility.NotifySystemOps(ex)

        ' Clear the error from the server
        Server.ClearError()
    End Sub

    <System.Web.Services.WebMethod()> _
        Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
