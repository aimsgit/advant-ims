
Partial Class FrmDailyBalanceSheetReport
    Inherits BasePage
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        msginfo.Text = ""
        Dim FromDate As Date
        Dim ReportType As Integer
        FromDate = txtStartDate.Text
        ReportType = ddlReportType.SelectedValue
        txtStartDate.Text = Format(FromDate, "dd-MMM-yyyy")
        Dim qrystring As String = "Rpt_DailyBalance.aspx?" & "&FromDate=" & FromDate & "&ReportType=" & ReportType
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtStartDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
