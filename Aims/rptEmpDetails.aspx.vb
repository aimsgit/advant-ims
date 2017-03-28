
Partial Class rptEmpDetails
    Inherits BasePage
    Dim bll As New EmpTranferB
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        'Dim Branch As Integer = Request.QueryString.Get("Branch")
        Dim Designation As Integer = Request.QueryString.Get("Designation")
        Dim SalaryGrade As String = Request.QueryString.Get("SalaryGrade")
        Dim DojDob As Integer = Request.QueryString.Get("DojDob")

        Dim FromDate As Date = Request.QueryString.Get("FromDate")
        Dim ToDate As Date = Request.QueryString.Get("ToDate")
        Dim DeptId As Integer = Request.QueryString.Get("DeptId")
        Dim SortBy As Integer = Request.QueryString.Get("SortBy")
        'ToDate = Format(ToDate, ("dd-MMM-yyyy"))



        dt1 = bll.finalExamRpt(Designation, SalaryGrade, DojDob, FromDate, ToDate, DeptId, SortBy)
        If dt1.Rows.Count > 0 Then
            'Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            ReportViewer1.LocalReport.ReportPath = "rptEmpDetailsNEW.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_EmployeeDetails", dt1)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            LblError.Text = "No Records to display."
        End If
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
