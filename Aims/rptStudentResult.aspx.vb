Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports StudentResult
Partial Class rptStudentResult
    Inherits BasePage
    Dim dt,dt1 As New DataTable



    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim BLL As New StudentResultrptdb
        Dim obj As New SelfDetailsB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim bachid As Integer = CInt(Request.QueryString.Get("batch"))
        'Dim stdid As String = Request.QueryString.Get("Std")
        'Dim ID As String = Request.QueryString.Get("ID")

        Dim course As String = Request.QueryString.Get("course")
        Dim Branch As String = Request.QueryString.Get("Branch")
        Dim CourseId As Integer = Request.QueryString.Get("CourseId")
        'Dim AYear As Integer = Request.QueryString.Get("AYear")
        Dim Subjectid As Integer = Request.QueryString.Get("Subjectid")
        Dim SemesterId As Integer = Request.QueryString.Get("SemesterId")
        Dim BatchNo As Integer = Request.QueryString.Get("BatchNo")
        Dim AssessmentId As Integer = Request.QueryString.Get("AssessmentId")
        Dim ClassType As Integer = Request.QueryString.Get("ClassType")
        Dim SortBy As Integer = Request.QueryString.Get("SortBy")

        dt1 = BLL.GetDataByrptStdResult(Branch, CourseId, Subjectid, SemesterId, BatchNo, AssessmentId, ClassType, SortBy)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "rptStudentResult.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StdSubjectResult", dt1)

            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("course", course, False))

            ReportViewer1.LocalReport.SetParameters(paramList)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()



            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblmsg.Text = "No Records to display."
        End If










        'Dim BLL As New Student_ResultrptB.StudentResultrptdb
        'Dim Prop1 As New QureyStringP
        'Dim obj As New SelfDetailsB
        'Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim bf As New BinaryFormatter
        'Dim objData As String = Server.UrlDecode(Request("Prop").ToString)

        'objData = System.Text.Encoding.Default.GetString(Convert.FromBase64String(objData))
        'Dim m As New MemoryStream(System.Text.Encoding.Default.GetBytes(objData))
        'm.Seek(0, SeekOrigin.Begin)
        'Dim Prop As StudentResult.StudentResultP = CType(bf.Deserialize(m), StudentResultP)
        'ReportViewer1.LocalReport.ReportPath = "rptStudentResult.rdlc"

        'dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_rpt_StudentResultwithArrear", BLL.GetDataByrptStdResult(Prop))
        'ReportViewer1.LocalReport.DataSources.Clear()
        'Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        'ReportViewer1.LocalReport.Refresh()
        ''dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
