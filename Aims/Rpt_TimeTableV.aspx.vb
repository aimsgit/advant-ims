
Partial Class Rpt_TimeTableV
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim El As New TimeTableEL
    Dim bl As New TimeTableBl
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLReportsR
        Dim dt1, dt3, dt4 As New Data.DataTable

        If Session("LoginType") = "Others" Then
            dt3 = DLReportsR.stddetails()
            If dt3.Rows.Count > 0 Then

                Dim Course As Integer = dt3.Rows(0).Item("CourseCode").ToString
                Dim Batch As Integer = dt3.Rows(0).Item("Batch_No").ToString
                Dim Semester As Integer = dt3.Rows(0).Item("SemCode").ToString
                'Dim Week As Integer = dt3.Rows(0).Item("WeekNo").ToString
                Dim Subject As Integer = 0
                Dim Teacher As Integer = 0
                Dim WeekNo As Integer = 0
                dt1 = DL.Rpt_TimeTable(Course, Batch, Semester, WeekNo, Subject, Teacher)
                If dt1.Rows.Count > 0 Then
                    'ReportViewer1.LocalReport.ReportPath = "Rpt_TimeTableV.rdlc"
                    'dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_TimeTable", dt1)
                    'ReportViewer1.LocalReport.DataSources.Clear()
                    'Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    'ReportViewer1.LocalReport.Refresh()
                    'dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    'lblmsg.Text = ""
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "Rpt_TimeTableV.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_TimeTable", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()
                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    ReportViewer1.Visible = True
                    Calender1.Visible = True
                Else
                    lblmsg.Text = "No Records to Display."

                End If
            Else
                lblmsg.Text = "No Records to Display."
            End If
        Else
            Dim Course As Integer = Request.QueryString.Get("Course")
            Dim Batch As Integer = Request.QueryString.Get("Batch")
            Dim Semester As Integer = Request.QueryString.Get("Semester")
            Dim Subject As Integer = Request.QueryString.Get("Subject")
            Dim Teacher As Integer = Request.QueryString.Get("Teacher")
            Dim WeekNo As Integer = Request.QueryString.Get("WeekNo")

            dt1 = DL.Rpt_TimeTable(Course, Batch, Semester, Subject, Teacher, WeekNo)
            If dt1.Rows.Count > 0 Then
                ReportViewer1.LocalReport.ReportPath = "Rpt_TimeTableV.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_TimeTable", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                lblmsg.Text = ""
                ReportViewer2.Visible = True
                Calender1.Visible = True
            Else
                If Session("Form") = "frmStudentEnquiryForm.aspx" Then
                    lblmsg.Text = "No Records to Display."
                    Calender1.Visible = True
                Else
                    lblmsg.Text = "No Records to Display."
                    ReportViewer2.Visible = False
                    Calender1.Visible = False
                End If
            End If
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calender1.DayRender
        Try

            lblmsg.Text = ""
            dt = bl.ViewHolidayRecord(El)
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        e.Cell.BackColor = System.Drawing.Color.Red
                        e.Cell.ForeColor = System.Drawing.Color.White
                        'lb.Text = dt.Rows(i).Item("HolidayName")
                        e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                        'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ReportViewer2_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer2.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLReportsR
        Dim dt1, dt3, dt4 As New Data.DataTable
        dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
        ReportViewer2.LocalReport.ReportPath = "MasterHeading.rdlc"
        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        ReportViewer2.LocalReport.DataSources.Clear()
        Me.ReportViewer2.LocalReport.DataSources.Add(dm)
        ReportViewer2.LocalReport.Refresh()
    End Sub
End Class
