
Partial Class FrmRptStudMedicalDetails
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msgin.Text = ValidationMessage(1014)
        Dim QS As String
        Dim StdID As Integer
        Try
            Splitter1(txtStdCode.Text)
            StdID = ViewState("StdID")
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptStudMedicalDetailsV.aspx?" & QueryStr.Querystring() & "&Std_ID=" & StdID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            msgin.Text = ValidationMessage(1022)
        End Try
        txtStdCode.Text = ""
        HidId.Value = 0
    End Sub
    Sub Splitter1(ByVal s As String)
        Dim StdID As Integer
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("StdCode") = parts(0).ToString()
            txtStdCode.Text = parts(0).ToString()
            HidId.Value = parts(1).ToString()
            StdID = parts(2).ToString()
            ViewState("StdID") = StdID
            'lblCodes.Text = txtStdCode.Text
        Else
            txtStdCode.AutoPostBack = True
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub txtStdCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode.TextChanged
        Splitter1(txtStdCode.Text)
    End Sub
   
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class