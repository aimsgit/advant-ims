
Partial Class RptStudAttendanceBySubDetailedV
    Inherits BasePage

    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New DLStudAttendBySub
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Bat, Sem, BR As String
        Dim Subj, ES, StdId, SortBy, Min, Max, Category As Integer
        Dim fromdate, todate As DateTime
        Dim categoryname As String

        BR = Request.QueryString.Get("BranchCode")
        'AT = Request.QueryString.Get("A_Year")
        Bat = Request.QueryString.Get("Batch")
        Sem = Request.QueryString.Get("Semester")
        Subj = Request.QueryString.Get("Subject")
        'ES = Request.QueryString.Get("ElecSub")
        StdId = Request.QueryString.Get("StudentID")
        fromdate = Request.QueryString.Get("fromdate")
        todate = Request.QueryString.Get("todate")
        SortBy = Request.QueryString.Get("SortBy")
        Min = Request.QueryString.Get("Min")
        Max = Request.QueryString.Get("Max")
        Category = Request.QueryString.Get("Category")
        categoryname = Request.QueryString.Get("categoryname")
        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DL.GetStudentDetailedReportWitElecSub(BR, Bat, Sem, Subj, StdId, fromdate, todate, SortBy, Category)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStudAttendanceBySubDetailedV.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentAttendanceDetailedWitSubRpt", dt1)
                categoryname = Request.QueryString.Get("categoryname")
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Min", Min, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Max", Max, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("categoryname", categoryname, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 1st jan 2014
    ''Retriving the text of controls based on Language
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
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
End Class
