
Partial Class RptSemMarksnAttenListParentLogin
    Inherits BasePage
    Dim Batch As Integer
    Dim SortType As Integer
    Dim Sem, Stdid As Integer
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Dim BatchID, Semester, Assessmentid, id, Studid As Integer
        Dim Strtdate, EndDate, AssessmentType As String
        BatchID = Batch
        Semester = Sem
        Assessmentid = ddlassessment.SelectedValue
        id = ddlSort.SelectedValue
        Studid = Stdid
        Dim parts As String() = ddlassessment.SelectedItem.Text.Split(New Char() {":"})
        AssessmentType = parts(0).ToString
        Dim dt As DataTable

        dt = DLNew_StudentMarks.GetAssesmentTypeWitDateCombo(BatchID, Semester)
        EndDate = Right(ddlassessment.SelectedItem.Text, 11)
        Strtdate = dt.Rows(0).Item("SrtDate")


        If DDLSemester.SelectedValue = "0" Or ddlassessment.SelectedValue = "0" Then
            msginfo.Text = "Enter all Mandatory Fields."
        Else

            'If id = 0 Then
            msginfo.Text = ""
            Dim qrystring As String = "RptSemMarksnAttenListParentLoginV.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&Semester=" & Semester & "&Assessmentid=" & Assessmentid & "&id=" & id & "&Strtdate=" & Strtdate & "&EndDate=" & EndDate & "&Studid=" & Studid & "&AssessmentType=" & AssessmentType
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)


        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt1, dt2 As New DataTable
        Dim DL As New feeCollectionDL

        If Session("Form") <> "frmStudentEnquiryForm.aspx" Then
            dt1 = DLReportsR.GetStudentDtlsforStudlogin()
            txtBatch.Text = dt1.Rows(0).Item("Batch_No")
            Batch = dt1.Rows(0).Item("BatchID")
            Stdid = dt1.Rows(0).Item("StdId")
        Else
            Dim batchName As String
            Batch = Request.QueryString.Get("Batch")
            batchName = Request.QueryString.Get("batchName")
            txtBatch.Text = batchName
            Stdid = Request.QueryString.Get("Student")
        End If

        If Not IsPostBack Then
            If Session("Form") <> "frmStudentEnquiryForm.aspx" Then
                Sem = dt1.Rows(0).Item("SemesterID").ToString
                Session("BatchID") = Batch
                dt2 = DL.SemesterComboD1(Batch)
                DDLSemester.Items.Clear()
                If dt2.Rows.Count > 0 Then
                    DDLSemester.DataSource = dt2
                    DDLSemester.DataBind()
                End If
                dt1 = DLNew_StudentMarks.GetAssesmentTypeWitDateCombo(Batch, Sem)
                ddlassessment.Items.Clear()
                If dt1.Rows.Count > 0 Then
                    ddlassessment.DataSource = dt1
                    ddlassessment.DataBind()
                End If
                ddlSort.Visible = False
                lblSort.Visible = False
                SortType = 1
                DDLSemester.SelectedValue = Sem
            Else
                Sem = Request.QueryString.Get("Semester")
                dt2 = DL.SemesterComboD1(Batch)
                DDLSemester.Items.Clear()
                If dt2.Rows.Count > 0 Then
                    DDLSemester.DataSource = dt2
                    DDLSemester.DataBind()
                End If
                dt1 = DLNew_StudentMarks.GetAssesmentTypeWitDateCombo(Batch, Sem)
                ddlassessment.Items.Clear()
                If dt1.Rows.Count > 0 Then
                    ddlassessment.DataSource = dt1
                    ddlassessment.DataBind()
                End If
                ddlSort.Visible = False
                lblSort.Visible = False
                SortType = 1
                DDLSemester.SelectedValue = Sem
            End If
        Else
            Sem = DDLSemester.SelectedValue
        End If

    End Sub

    Protected Sub DDLSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLSemester.SelectedIndexChanged
        Dim dt1, dt2 As New DataTable
        If Session("Form") <> "frmStudentEnquiryForm.aspx" Then
            dt1 = DLReportsR.GetStudentDtlsforStudlogin()
            Sem = DDLSemester.SelectedValue
            Batch = dt1.Rows(0).Item("BatchID")
            dt1 = DLNew_StudentMarks.GetAssesmentTypeWitDateCombo(Batch, Sem)
            ddlassessment.Items.Clear()
            If dt1.Rows.Count > 0 Then
                ddlassessment.DataSource = dt1
                ddlassessment.DataBind()
            End If
        Else
            Batch = Request.QueryString.Get("Batch")
            Sem = DDLSemester.SelectedValue
            dt1 = DLNew_StudentMarks.GetAssesmentTypeWitDateCombo(Batch, Sem)
            ddlassessment.Items.Clear()
            If dt1.Rows.Count > 0 Then
                ddlassessment.DataSource = dt1
                ddlassessment.DataBind()
            End If
        End If
    End Sub
End Class
