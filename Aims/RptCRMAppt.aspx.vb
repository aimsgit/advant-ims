
Partial Class RptCRMAppt
    Inherits BasePage
    Dim FrmDate As New DateTime
    Dim ToDate As New DateTime
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Try
            If txtFromDate.Text = "" Then
                FrmDate = "01/01/1900"
            Else
                FrmDate = txtFromDate.Text
            End If
            If txtToDate.Text = "" Then
                ToDate = "01/01/1900"
            Else
                ToDate = txtToDate.Text
            End If
            If CType(FrmDate, Date).Date > CType(ToDate, Date).Date Then
                msginfo.Text = "From Date cannot be greater than To Date."
            Else
                msginfo.Text = ""
                Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "RptCRMApptV.aspx?" & QueryStr.Querystring() & "&EmpName=" & ddlApptAssignedto.SelectedValue & "&FromDate=" & FrmDate & "&ToDate=" & ToDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

            End If
        Catch ex As Exception
            msginfo.Text = "Enter Correct Date."
        End Try
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
        Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtFromDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
            txtToDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub

End Class
