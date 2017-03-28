
Partial Class FrmErrorMessageDisplay
    Inherits BasePage
    Dim El As New ElErrorLog
    Dim Bl As New BLErrorLog
    Dim dt As New DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ViewState("LogId") = Request.QueryString.Get("LogId")
        dt = Bl.ShowError(ViewState("LogId"))
        ErrorMessage.Text = dt.Rows(0).Item("ErrorMessage").ToString
    End Sub
End Class
