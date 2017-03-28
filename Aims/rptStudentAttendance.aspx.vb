Imports System.Runtime.Serialization.Formatters.Binary
Imports System.io
Imports Attendance
Partial Class rpt_StudentAttendance
    Inherits System.Web.UI.Page
    Dim ds1 As New DataSet
    Dim dtS As New Data.DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim bl As New StdAttendanceB
        Dim obj As New SelfDetailsB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Inst As String = Request.QueryString.Get("Insti")
        Dim Bran As String = Request.QueryString.Get("Branch")
        Dim bf As New BinaryFormatter
        Dim objData As String
        Dim Prop As New StdAttendanceP
        Dim SemesterWise As Boolean

        SemesterWise = CBool(Prop.Id)
        objData = Server.UrlDecode(Request("Prop").ToString)
        objData = System.Text.Encoding.Default.GetString(Convert.FromBase64String(objData))
        Dim m As New MemoryStream(System.Text.Encoding.Default.GetBytes(objData))
        m.Seek(0, SeekOrigin.Begin)
        Prop = CType(bf.Deserialize(m), StdAttendanceP)
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Dim dt1 As New DataTable
        Dim DLL As New StudentAttendance
        If Prop.AttendanceDate.ToString <> "1/1/0001 12:00:00 AM" Then
            Me.ReportViewer1.LocalReport.ReportPath = "rptStudentAttendance1.rdlc"
        Else
            Me.ReportViewer1.LocalReport.ReportPath = "rptStudentAttendance.rdlc"
        End If
        dt1 = bl.GetStdAttdDetails(Prop.InsId, Prop.BrnId, Prop.Courseid, Prop.Batch, Prop.Month, Prop.SubjectId, Prop.Year, Prop.EmpCode, Prop.SemsterId, Prop.AttendanceDate, Prop.Assessment_ID, SemesterWise)
        '    BLL.GetStdAttdDetails(Prop.InsId, Prop.BrnId, Prop.Courseid, Prop.Batch, Prop.Month, Prop.SubjectId, Prop.Year, Prop.EmpCode, Prop.SemsterId, Prop.AttendanceDate, Prop.Assessment_ID, SemesterWise)
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Qry_StdAttdDetails", dt1)

        ReportViewer1.LocalReport.DataSources.Clear()

        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()
        'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
