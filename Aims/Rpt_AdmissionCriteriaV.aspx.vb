
Partial Class Rpt_AdmissionCriteriaV
    Inherits BasePage
    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Dim DL As New AdmissionCriteriaDL
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim CourseType As Integer = Request.QueryString.Get("CourseType")
        Dim Course As String = Request.QueryString.Get("Course")
        QueryStr.GetValue(Page.Request, Prop)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Anchala on 11 Sep 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "AdmissionCriteriaR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim AdmissionCriteriaR, SlNo, EnquiryNo, StdName, StdCategory, Marks, CourseType1, CourseName As String
        AdmissionCriteriaR = dt2.Rows(5).Item("Default_Text").ToString()
        EnquiryNo = dt2.Rows(0).Item("Default_Text").ToString()
        StdName = dt2.Rows(1).Item("Default_Text").ToString()
        StdCategory = dt2.Rows(3).Item("Default_Text").ToString()
        Marks = dt2.Rows(4).Item("Default_Text").ToString()
        SlNo = dt2.Rows(2).Item("Default_Text").ToString()
        CourseType1 = dt2.Rows(6).Item("Default_Text").ToString()
        CourseName = dt2.Rows(7).Item("Default_Text").ToString()
        dt1 = AdmissionCriteriaDL.RptAdmissionCriteria(CourseType, Course)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_AdmissionCriteria.rdlc"

                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AdmissionCriteria", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AdmissionCriteriaR", AdmissionCriteriaR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EnquiryNo", EnquiryNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCategory", StdCategory, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Marks", Marks, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseType1", CourseType1, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseName", CourseName, False))
                
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblErrorMsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
