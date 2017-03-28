
Partial Class rptAdhocfeeCollectionReportV
    Inherits System.Web.UI.Page
    Dim Bl As New FeeCollectionBL
    Dim Dl As New feeCollectionDL
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, Parentdt, Parentdt1 As New DataTable
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource



        Dim Payment As Integer
        Dim FeeHead, StudentCode, Bat As Integer
        Dim StartDate As Date
        Dim EndDate As Date


        Try
            If Session("LoginType") = "Employee" Then
                'AT = Request.QueryString.Get("A_Year")


                Payment = Request.QueryString.Get("Payment")
                FeeHead = Request.QueryString.Get("FeeHead")
                StartDate = Request.QueryString.Get("StartDate")
                EndDate = Request.QueryString.Get("EndDate")
            ElseIf Session("LoginType") = "Others" Then
                Parentdt = Dl.GetStudentDtlsForParent()
                'AT = Parentdt.Rows(0).Item("A_Year").ToString
                Bat = Parentdt.Rows(0).Item("Batch_No").ToString
                StudentCode = Parentdt.Rows(0).Item("STD_ID").ToString()
                Parentdt1 = Dl.GetStdSemester(Bat)
                'Sem = Parentdt1.Rows(0).Item("SemesterID").ToString()
                'Sem = 0
                Payment = 0
                'StartDate = Parentdt1.Rows(0).Item("StartDate")
                'EndDate = Parentdt1.Rows(0).Item("EndDate")
                StartDate = "1/1/1900"
                EndDate = "1/1/9100"
            End If
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = Bl.AdhocFeeCollectionReport(Payment, FeeHead, StartDate, EndDate)
            If dt1.Rows.Count > 0 Then
                ReportViewer1.LocalReport.ReportPath = "Rpt_AdhocfeeCollection.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AdhocFeeCollectionReport", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", StartDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", EndDate, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FeeHead", FeeHead, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                LblError.Text = "No Records to display."
            End If
        Catch ex As Exception
            LblError.Text = "No Records to Display."
        End Try
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
