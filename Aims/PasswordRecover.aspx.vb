
Partial Class PasswordRecover
    Inherits System.Web.UI.Page
    Public new_dbconn1 As New OleDbConnection()
    Dim Usr_dt As New DataTable
    Dim Usr_da As New OleDbDataAdapter
    Dim sql, UserVal As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        new_dbconn1.ConnectionString = Application("Strcontent")
    End Sub
    Protected Sub SubmitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubmitButton.Click
        new_dbconn1.Open()
        sql = "Select * from UserCreation where Username='" + UserName.Text + "'"
        Usr_da = New OleDbDataAdapter(sql, new_dbconn1)
        Usr_dt.Clear()
        Usr_da.Fill(Usr_dt)
        If Usr_dt.Rows.Count = 0 Then
            FailureText.Text = "Sorry, this username doesnot exists."
        Else
            lblmsg.Visible = True
            lblmsg.Text = "Password:" & " " & Usr_dt.Rows(0)("pwd").ToString
        End If
        new_dbconn1.Close()
    End Sub
    <System.Web.Services.WebMethod()> _
        Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
  
    
End Class
