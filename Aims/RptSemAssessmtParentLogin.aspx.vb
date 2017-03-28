
Partial Class RptSemAssessmtParentLogin
    Inherits BasePage
    Dim Batch As Integer
    Dim Course, RptType, SortType As Integer
    Dim Student, batchName As String
    Dim Semester As Integer
    Dim Subject As Integer
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Cid, BId, SId, SubId, AsstId, StudId, id, id1 As Integer
        Dim ReportType As String

        Dim dt1 As New DataTable

        Cid = Course
        BId = Batch
        SId = Semester
        SubId = cmbSubject.SelectedValue
        AsstId = ddlass.SelectedValue
        StudId = Student
        ReportType = RptType
        batchName = txtBatch.Text
        id = SortType
        'id1 is used to identify whether it is parent or student login 
        id1 = 1
        If ddlSemester.SelectedItem.Text = "Select" Then
            lblErrorMsg.Text = "Select Semester field."
        Else
            Dim qrystring As String = "RptSemAssessmtParentLoginV.aspx?" & "&Cid=" & Cid & "&BId=" & BId & "&SId=" & SId & "&SubId=" & SubId & "&StudId=" & StudId & "&ReportType=" & ReportType & "&id=" & id & "&AsstId=" & AsstId & "&id1=" & id1 & "&batchName=" & batchName
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            lblErrorMsg.Text = ""
        End If

        
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt1, dt2 As New DataTable
        Dim DL As New feeCollectionDL
        dt1 = DLReportsR.GetStudentDtlsforStudlogin()
        txtCrs.Text = dt1.Rows(0).Item("CourseName")
        Course = dt1.Rows(0).Item("CourseCode")
        txtBatch.Text = dt1.Rows(0).Item("Batch_No")
        batchName = txtBatch.Text
        Batch = dt1.Rows(0).Item("BatchID")
        Student = dt1.Rows(0).Item("StdId")
        Session("BatchID") = Batch
        txtStd.Text = dt1.Rows(0).Item("Stud")
        txtStd.Enabled = False

        If Not IsPostBack Then
            Semester = dt1.Rows(0).Item("SemesterID").ToString
            dt2 = DL.SemesterComboD1(Batch)
            ddlSemester.Items.Clear()
            If dt2.Rows.Count > 0 Then
                ddlSemester.DataSource = dt2
                ddlSemester.DataBind()
            End If
            dt1 = DLReportsR.GetSubject(Batch, Semester)
            cmbSubject.Items.Clear()
            If dt1.Rows.Count > 0 Then
                cmbSubject.DataSource = dt1
                cmbSubject.DataBind()
            End If
            ddlRptType.Visible = False
            lblRptType.Visible = False
            ddlSort.Visible = False
            lblSort.Visible = False
            RptType = 0
            SortType = 1
            ddlSemester.SelectedValue = Semester
        Else
            Semester = ddlSemester.SelectedValue
        End If


    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged
        Dim dt1, dt2 As New DataTable
        Semester = ddlSemester.SelectedValue
        dt1 = DLReportsR.GetSubject(Batch, Semester)
        cmbSubject.Items.Clear()
        If dt1.Rows.Count > 0 Then
            cmbSubject.DataSource = dt1
            cmbSubject.DataBind()
        End If
    End Sub
End Class
