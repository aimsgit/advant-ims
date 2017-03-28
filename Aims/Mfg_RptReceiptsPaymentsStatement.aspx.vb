
Partial Class Mfg_RptReceiptsPaymentsStatement
    Inherits BasePage
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Try
            msginfo.Text = ""
            Dim FromDate As Date
            Dim ToDate As Date
            FromDate = txtStartDate.Text
            txtStartDate.Text = Format(FromDate, "dd-MMM-yyyy")
            ToDate = txtEndDate.Text
            If FromDate > ToDate Then
                msginfo.Text = "From date should be greater than To date."
                txtEndDate.Focus()
                Exit Sub
            End If
            Dim qry_str As String = "&FinStartDate=" & FromDate & "&FinEndDate=" & ToDate
            Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "Mfg_RptPaymentsReceiptsStmt.aspx?" & QueryStr.Querystring() & qry_str
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            msginfo.Text = "Date is not valid."
        End Try
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
          If Not IsPostBack Then
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
