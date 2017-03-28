
Partial Class RptStudAttenListNewV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New stdAttndance
        Dim Bat, Sem, id, RptType, Subject, SubSubgrp, StdId As Integer
        Dim FrmDate, ToDate As Date
        Dim BranchCode As String
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        If Session("LoginType") = "Others" Then
            ds1 = DLReportsR.stddetails()

            StdId = ds1.Rows(0).Item("STD_ID").ToString
            BranchCode = ds1.Rows(0).Item("BranchCode").ToString
            Bat = ds1.Rows(0).Item("Batch_No").ToString
            Sem = ds1.Rows(0).Item("SemesterID").ToString
            Subject = 0
            SubSubgrp = 0
            RptType = 1
            Dim Dt As New DataTable
            Dt = stdAttndance.StudentStartEndDate(Bat, Sem)
            FrmDate = Dt.Rows(0).Item("StartDate")
            ToDate = Dt.Rows(0).Item("EndDate")
            id = 0
            Dim dt1 As New Data.DataTable
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = DL.GetNewSemAttendListParentIndReport(Bat, Sem, id, FrmDate, ToDate, Subject, SubSubgrp, StdId)
            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptStudAttendListNew.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemAttenMapNew", dt1)

                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RptType", RptType, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No records to display."
                End If
            Catch ex As Exception
                lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try

        Else




            Bat = Request.QueryString.Get("BatchID")
            Sem = Request.QueryString.Get("Semester")
            id = Request.QueryString.Get("id")
            FrmDate = Request.QueryString.Get("FrmDate")
            ToDate = Request.QueryString.Get("ToDate")
            RptType = Request.QueryString.Get("RptType")
            Subject = Request.QueryString.Get("Subject")
            SubSubgrp = Request.QueryString.Get("SubSubgrp")
            Dim dt As New Data.DataTable
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = DL.GetNewSemAttendListIndReport(Bat, Sem, id, FrmDate, ToDate, Subject, SubSubgrp)
            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptStudAttenListNew.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemAttenMapNew", dt1)

                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RptType", RptType, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No records to display."
                End If
            Catch ex As Exception
                lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try
            'Dim BAL As New GlobalDataSetTableAdapters.Test_BankReconciliationTableAdapter

        End If



    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
