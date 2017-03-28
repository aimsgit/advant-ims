
Partial Class RptBatchSemesterMapV
    Inherits System.Web.UI.Page
    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Dim dt1, dt3, dt As DataTable
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        'Code for to get Batch Semester Map Details by Nitin 08/05/2012 
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim BatchId As Integer = Request.QueryString.Get("Batch")
        Dim Aid As Integer = Request.QueryString.Get("Aid")
        Session("BatchId") = BatchId
        dt1 = BatchSemesterMapDB.RptBatchSemesterMap(BatchId, Aid)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 26 Nov 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "BatchSemMapR"
        dt3 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim BatchSemMapR, BranchName, BranchType, SlNo, SemName, Batch, StartDate, EndDate As String

        BatchSemMapR = dt3.Rows(0).Item("Default_Text").ToString()
        BranchName = dt3.Rows(1).Item("Default_Text").ToString()
        BranchType = dt3.Rows(2).Item("Default_Text").ToString()
        SlNo = dt3.Rows(3).Item("Default_Text").ToString()
        SemName = dt3.Rows(4).Item("Default_Text").ToString()
        StartDate = dt3.Rows(5).Item("Default_Text").ToString()
        EndDate = dt3.Rows(6).Item("Default_Text").ToString()
        Batch = dt3.Rows(7).Item("Default_Text").ToString()
        
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptBatchSemesterMap.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RptBatchSemesterMap", dt1)
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchSemMapR", BatchSemMapR, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemName", SemName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", StartDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", EndDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))

            ReportViewer1.LocalReport.SetParameters(paramList)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblMsg.Text = ValidationMessage(1023)
        End If
    End Sub
    
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 27th Nov 2013
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
