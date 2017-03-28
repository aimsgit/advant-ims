
Partial Class RptSubjectMasterV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    'Code written by Niraj for Multilingual on 04 Sep 2013
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim DL As New SubjectDB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim id As Integer = Request.QueryString.Get("id")
        Dim dt2 As New Data.DataTable
        Dim LanguageID As Integer
        Dim FormName As String
        If Session("LanguageID") = "" Then
            LanguageID = 0
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "Subject Details"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim SubjectDetails, BranchType, BranchName, SlNo, SubjectCode, SubjectName, DepartmentName As String
        SubjectDetails = dt2.Rows(0).Item("Default_Text").ToString()
        BranchType = dt2.Rows(1).Item("Default_Text").ToString()
        BranchName = dt2.Rows(2).Item("Default_Text").ToString()
        SlNo = dt2.Rows(3).Item("Default_Text").ToString()
        SubjectCode = dt2.Rows(4).Item("Default_Text").ToString()
        SubjectName = dt2.Rows(5).Item("Default_Text").ToString()
        DepartmentName = dt2.Rows(6).Item("Default_Text").ToString()
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.RptSubjectMaster(id)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptSubjectMaster.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_getGVSubjectMaster", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectDetails", SubjectDetails, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectCode", SubjectCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectName", SubjectName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DepartmentName", DepartmentName, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else

                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 03th sep 2013
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
