
Partial Class RptEmployeeAttendanceSummMonthWise
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try

            lblerrormsg.Text = ""
            Dim FromDate As Date
            Dim ToDate As Date
            FromDate = txtStartDate.Text
            ToDate = txtEndDate.Text
            txtStartDate.Text = Format(FromDate, "dd-MMM-yyyy")
            txtEndDate.Text = Format(ToDate, "dd-MMM-yyyy")

            If FromDate > ToDate Then
                lblerrormsg.Text = "Start date should not be greater than End date."
                txtEndDate.Focus()
                Exit Sub
            End If
            Dim qrystring As String = "RptEmployeeAttendanceSummMonthWiseV.aspx?" & "&FinStartDate=" & FromDate & "&FinEndDate=" & ToDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        Catch ex As Exception
            lblerrormsg.Text = "Date is not valid."
        End Try

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(CDate(Session("FinEndDate")), "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
