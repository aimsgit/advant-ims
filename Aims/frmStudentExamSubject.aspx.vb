
Partial Class frmStudentExamSubject
    Inherits BasePage
    Dim Dt, Dt1, Dt2, dt3, dt4, dt5 As New DataTable
    Dim BatchId, SemId As Integer
    Dim DL As New StudentExamSubject
    Dim StdCode, ConfigValue, BranchCode, HallTicketNo, ExamBatchId, ExamBatchName As String
    Protected Sub btnhall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnhall.Click
        Try
            dt4 = StudentExamSubject.StudentCurrentSem()
            SemId = dt4.Rows(0).Item("SemesterID").ToString
            Session("SemesterID") = dt4.Rows(0).Item("SemesterID").ToString
            HallTicketNo = dt4.Rows(0).Item("Hallticket").ToString
            ExamBatchId = dt4.Rows(0).Item("ExamBatch").ToString
            ExamBatchName = dt4.Rows(0).Item("EBName").ToString
            If (HallTicketNo <> "") Then
                Dim qrystring As String = "RptGenerateHallTicketReportChecked.aspx?" & "&ExamBatchId=" & ExamBatchId & "&Exam=" & ExamBatchName & "&FromserialNo=" & HallTicketNo & "&ToSerialNo=" & HallTicketNo & "&id=" & 0
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            Else
                lblMsg.Text = ""
                msginfo.Text = "Hall Ticket is not Generated."
            End If
        Catch ex As Exception
            lblMsg.Text = ""
            msginfo.Text = "Please Enter Correct Data."
        End Try
    End Sub

    Protected Sub btnupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim Subject As String = ""
        For Each rows As GridViewRow In GvSubjects.Rows
            If CType(rows.FindControl("ChkBx1"), CheckBox).Checked = True Then
                Subject = Subject + (CType(rows.FindControl("lblsubjectid"), Label).Text) + ","
            End If
        Next
        If (Subject.Length > 0) Then
            Dt = DL.UpdateSubject(Subject.Substring(0, Subject.Length - 1))
        Else
            Dt = DL.UpdateSubject(Subject)
        End If
        lblMsg.Text = "Subject Assigned For Exam Sucessfully."
        msginfo.Text = ""
        display()
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        msginfo.Text = ""
        lblMsg.Text = ""
        display()
    End Sub
    Sub CheckAllGv1()
        Dim S As Double = 0
        If CType(GvSubjects.HeaderRow.FindControl("ChkAll1"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GvSubjects.Rows
                CType(grid.FindControl("ChkSelect1"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GvSubjects.Rows
                CType(grid.FindControl("ChkSelect1"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ViewState("heading") = Session("RptFrmTitleName")
            Me.Lblheading.Text = ViewState("heading")
        End If
        If Not IsPostBack Then
            If Session("LoginType") = "Others" Then
                'Panel3.Visible = True
                StdCode = Session("StudentCode")
                dt3 = DLSelectElective.StudentCurrentBatch(StdCode)
                BatchId = dt3.Rows(0).Item("Batch_No").ToString
                Session("CourseID") = dt3.Rows(0).Item("Courseid").ToString
                BranchCode = dt3.Rows(0).Item("BranchCode").ToString
                'lblbatch1.Text = dt3.Rows(0).Item("Batch").ToString
                lblstdcode1.Text = Session("StudentCode").ToString
                'lblcourse1.Text = dt3.Rows(0).Item("CourseName").ToString
                lblstdname1.Text = Session("StudentName")
                dt4 = StudentExamSubject.StudentCurrentSem()
                SemId = dt4.Rows(0).Item("SemesterID").ToString
                Session("SemesterID") = dt4.Rows(0).Item("SemesterID").ToString
                HallTicketNo = dt4.Rows(0).Item("Hallticket").ToString
                ExamBatchId = dt4.Rows(0).Item("ExamBatch").ToString
                ExamBatchName = dt4.Rows(0).Item("EBName").ToString
                'lblsem1.Text = dt4.Rows(0).Item("SemName").ToString
            ElseIf Session("Form") = "frmStudentEnquiryForm.aspx" Then
                StdCode = Request.QueryString.Get("StudentCode")
                Session("StudentCode") = StdCode
                Dim StdName As String
                dt3 = DLSelectElective.StudentCurrentBatch(StdCode)
                StdName = dt3.Rows(0).Item("StdName").ToString
                BatchId = dt3.Rows(0).Item("Batch_No").ToString
                Session("BatchID") = BatchId
                Session("CourseID") = dt3.Rows(0).Item("Courseid").ToString
                Session("StudentName") = StdName
                BranchCode = dt3.Rows(0).Item("BranchCode").ToString
                'lblbatch1.Text = dt3.Rows(0).Item("Batch").ToString
                lblstdcode1.Text = Session("StudentCode").ToString
                'lblcourse1.Text = dt3.Rows(0).Item("CourseName").ToString
                lblstdname1.Text = Session("StudentName")
                dt4 = StudentExamSubject.StudentCurrentSem()
                SemId = dt4.Rows(0).Item("SemesterID").ToString
                Session("SemesterID") = dt4.Rows(0).Item("SemesterID").ToString
                HallTicketNo = dt4.Rows(0).Item("Hallticket").ToString
                ExamBatchId = dt4.Rows(0).Item("ExamBatch").ToString
                ExamBatchName = dt4.Rows(0).Item("EBName").ToString
                'lblsem1.Text = dt4.Rows(0).Item("SemName").ToString

            End If

            'GridView1.Visible = False
            GvSubjects.Visible = False
        End If
    End Sub
    Sub display()

        Dt = DL.ViewSubject()
        If (Dt Is Nothing) Then
            msginfo.Text = "No records to display."
            lblMsg.Text = ""
            GvSubjects.Visible = False
        Else
            If (Dt.Rows.Count > 0) Then
                GvSubjects.DataSource = Dt
                GvSubjects.DataBind()
                For Each rows As GridViewRow In GvSubjects.Rows
                    If CType(rows.FindControl("lblSelect1"), Label).Text = "Y" Then
                        CType(rows.FindControl("ChkBx1"), CheckBox).Checked = True
                        'Subject = Subject + CDbl(CType(rows.FindControl("lblcredit"), Label).Text) + ","
                    End If
                Next
                GvSubjects.Visible = True
            Else
                msginfo.Text = "No records to display."
                lblMsg.Text = ""
                GvSubjects.Visible = False
            End If
        End If

    End Sub
End Class
