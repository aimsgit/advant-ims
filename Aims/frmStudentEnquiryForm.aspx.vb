Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports System.Web.UI.WebControls.WebParts
Imports System.Data.SqlClient
Imports System.Collections
Imports System.IO.DirectoryInfo
Imports System.Data.DataRowCollection


Partial Class frmStudentEnquiryForm
    Inherits BasePage

    Dim EL As New ELStudentEnquiryForm
    Dim DL As New DLStudentEnquiryForm
    Dim Username, StaffUsername, Password, StaffPassword, LoginType, StaffLoginType As String
    Dim BranchCode, StudentCode As String
    Dim Batch, Semester, Course, Student As Integer
    Dim dt, dt1, dt2, dt4 As New Data.DataTable
    Dim restoreDt As DataTable = New DataTable()
    Dim LinknameList, ChildNodes, ParentList As New DataTable

    Sub Splitter(ByVal s As String)
        Try
            Dim parts As String() = s.Split(New Char() {":"})
            If parts.Length > 1 Then
                Dim Batch As Integer
                ViewState("StdCode") = parts(0).ToString()
                txtStudentCode.Text = parts(0).ToString()
                EL.StudCode = txtStudentCode.Text
                StdId.Value = parts(1).ToString()
                txtStudentName.Text = parts(2).ToString()
                EL.CourseId = parts(4).ToString()
                ddlCourseName.SelectedValue = EL.CourseId
                EL.BatchId = parts(6).ToString()
                ddlBatchName.Items.Clear()
                ddlBatchName.DataSourceID = "ObjBatch"
                ddlBatchName.SelectedValue = EL.BatchId
                'ViewState("StdID") = StdId
                btnGotoDetails()
            Else
                txtStudentCode.AutoPostBack = True
            End If
        Catch ex As Exception
            lblerrormsg.Text = "Enter Correct data."
        End Try
    End Sub
    Sub selection()
        AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
        AutoCompleteExtender1.ServiceMethod = "getStudentEnquiryId"
        AutoCompleteExtender2.ServicePath = "TextBoxExt.asmx"
        AutoCompleteExtender2.ServiceMethod = "getStudentName"
    End Sub
    Sub Splitter1(ByVal s1 As String)
        Try
            Dim parts1 As String() = s1.Split(New Char() {":"})
            If parts1.Length > 1 Then
                Dim Batch As Integer
                ViewState("StdName") = parts1(0).ToString()
                txtStudentName.Text = parts1(0).ToString()
                StdId.Value = parts1(1).ToString()
                txtStudentCode.Text = parts1(2).ToString()
                EL.CourseId = parts1(5).ToString()
                ddlCourseName.SelectedValue = EL.CourseId
                'Batch = parts1(7).ToString()
                ddlBatchName.Items.Clear()
                ddlBatchName.DataSourceID = "ObjBatch"
                EL.BatchId = parts1(7).ToString()
                ddlBatchName.SelectedValue = EL.BatchId
                'ViewState("StdID") = StdId
                btnGotoDetails()
            Else
                txtStudentCode.AutoPostBack = True
            End If
        Catch ex As Exception
            lblerrormsg.Text = "Enter Correct data."
        End Try
    End Sub

    Protected Sub btnGotoDetails()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblmsg.Text = ""
            lblerrormsg.Text = ""
            'If txtStudentCode.Text = "" Or txtStudentName.Text = "" Then
            '    lblerrormsg.Text = "Enter StudentCode Or Enter StudentName."
            '    Exit Sub
            'End If

            Try
                EL.CourseId = ddlCourseName.SelectedValue
                EL.BatchId = EL.BatchId
                EL.StudentId = StdId.Value
                StdDetails.Visible = True

                Dim UserRole As String = "1234"
                Dim LanguageID As Integer = 1
                Dim MNID As Integer = 41
                'Proc_GetCutomizeLinkNameN - For Child Links.
                dt4 = DLStudentEnquiryForm.GetReportData(LanguageID, UserRole, MNID)
                If dt4.Rows.Count > 0 Then
                    GrdReport.DataSource = dt4
                    GrdReport.DataBind()
                    GrdReport.Visible = True
                    GrdReport.Enabled = True
                    StdDetails.Visible = True
                End If
              
            Catch ex As Exception
                lblerrormsg.Text = "Enter Correct data."
                StdDetails.Visible = False
                'Exit Sub
            End Try

        Else
            lblerrormsg.Text = "You do not belong to this Branch,Cannot view the data."

        End If
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If txtStudentCode.Text <> "" Then
            Splitter(txtStudentCode.Text)
        Else
            txtStudentCode.AutoPostBack = True
            Splitter(txtStudentCode.Text)
        End If

        If txtStudentName.Text <> "" Then
            Splitter1(txtStudentName.Text)
        Else
            txtStudentName.AutoPostBack = True
            Splitter1(txtStudentName.Text)
        End If

        Dim UserRole As String = "1234"
        Dim LanguageID As Integer = 1
        Dim MNID As Integer = 41
        'Proc_GetCutomizeLinkNameN - For Child Links.
        dt4 = DLStudentEnquiryForm.GetReportData(LanguageID, UserRole, MNID)
        If dt4.Rows.Count > 0 Then
            GrdReport.DataSource = dt4
            GrdReport.DataBind()
            GrdReport.Visible = True
            GrdReport.Enabled = True
            StdDetails.Visible = True
        End If
        Session("CourseId") = 0
        Session("BatchId") = 0
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

    Protected Sub ddlCourseName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseName.SelectedIndexChanged
        lblmsg.Text = ""
        lblerrormsg.Text = ""
        Session("CourseId") = ddlCourseName.Text
        StdDetails.Visible = False
        txtStudentCode.Text = ""
        txtStudentName.Text = ""
        ddlBatchName.SelectedValue = 0
    End Sub


    Protected Sub ddlBatchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.SelectedIndexChanged
        lblmsg.Text = ""
        lblerrormsg.Text = ""
        Session("CourseId") = ddlCourseName.Text
        Session("BatchId") = ddlBatchName.Text
        StdDetails.Visible = False
        txtStudentCode.Text = ""
        txtStudentName.Text = ""
    End Sub

    Protected Sub GrdReport_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdReport.RowEditing
        Dim ChildName As String = CType(GrdReport.Rows(e.NewEditIndex).FindControl("LinkButton2"), LinkButton).Text
        Dim Subject, CategoryID As Integer
        BranchCode = Session("BranchCode")
        StudentCode = txtStudentCode.Text
        If StudentCode = "" Then
            lblerrormsg.Text = "Enter Correct Data."
            Exit Sub
        End If

        Try
            dt2 = DLStudentEnquiryForm.stddetails(BranchCode, StudentCode)
            If dt2.Rows.Count > 0 Then
                Batch = dt2.Rows(0)("Batch_No").ToString
                Semester = dt2.Rows(0)("SemesterID").ToString
                Student = dt2.Rows(0)("Std_Id").ToString
                Course = dt2.Rows(0)("CourseCode").ToString
                CategoryID = dt2.Rows(0)("categoryid").ToString
            End If
            If ChildName = "Student Report Card" Then
                ' Dim BranchCode = Session("BranchCode")
                Dim BatchId As Integer = ddlBatchName.SelectedValue
                Dim SemId, assesstype, SortBY As Integer
                SemId = 0
                assesstype = 0
                SortBY = 0
                Dim StudentID As Integer = StdId.Value
                Dim ReportType As String = "Marks"
                Dim qrystring As String = "Rpt_StudentReportCardV.aspx?" & "&BranchCode=" & BranchCode & "&Batch=" & BatchId & "&Semester=" & SemId & "&StudentCode=" & StudentID & "&AssessmentType=" & assesstype & "&ReportType=" & ReportType & "&SortBy=" & SortBY
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Student Performance" Then
                dt2 = DLStudentEnquiryForm.stddetails(BranchCode, StudentCode)
                If dt2.Rows.Count > 0 Then
                    Batch = dt2.Rows(0)("Batch_No").ToString
                    Semester = dt2.Rows(0)("SemesterID").ToString
                    Student = dt2.Rows(0)("Std_Id").ToString
                End If
                Subject = 0
                Dim qrystring As String = "Rpt_StudentPerformanceRpt.aspx?" & "&BatchId=" & Batch & "&Semester=" & Semester & "&Student=" & Student & "&Subject=" & Subject
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Semester  Assessment" Then
                Dim Cid, SId, SubId, StudId, ReportType, id, AsstId, id1 As Integer
                Dim BatchId As String
                Dim batchName As String
                BatchId = Batch
                Cid = Course
                SId = Semester
                batchName = ddlBatchName.SelectedItem.Text
                StudId = StdId.Value
                SubId = 0
                id = 0
                id1 = 0
                ReportType = 0
                AsstId = 0
                Dim qrystring As String = "RptSemAssessmentV.aspx?" & "&BatchId=" & BatchId & "&Cid=" & Cid & "&SId=" & SId & "&batchName=" & batchName & "&StudId=" & StudId & "&SubId=" & SubId & "&id=" & id & "&id1=" & id1 & "&ReportType=" & ReportType & "&AsstId=" & AsstId
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Time Table" Then
                Dim Teacher, WeekNo As Integer
                Teacher = 0
                WeekNo = 0
                Dim qrystring As String = "Rpt_TimeTableV.aspx?" & "&Course=" & Course & "&Batch=" & Batch & "&Semester=" & Semester & "&Subject=" & Subject & "&Teacher=" & Teacher & "&WeekNo=" & WeekNo
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Fee Collection" Then
                Dim Payment As Integer
                Dim StudentCode As Integer
                Dim StartDate, EndDate As Date
                Payment = 0
                StudentCode = StdId.Value
                StartDate = "1/1/1900"
                EndDate = "1/1/9100"
                Dim qrystring As String = "RptFeeCollectionReport.aspx?" & "&Batch=" & Batch & "&Semester=" & Semester & "&Payment=" & Payment & "&StudentCode=" & StudentCode & "&StartDate=" & StartDate & "&EndDate=" & EndDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Semester Marks And Attendance List" Then
                Dim batchName As String
                batchName = ddlBatchName.SelectedItem.Text
                Dim qrystring As String = "RptSemMarksnAttenListParentLogin.aspx?" & "&Batch=" & Batch & "&Semester=" & Semester & "&batchName=" & batchName & "&Student=" & Student
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Fee Due Statement" Then
                Dim BatchId, SemID, StdID, CourseCode As Integer
                BatchId = Batch
                SemID = Semester
                StdID = dt2.Rows(0)("Std_Id").ToString
                'CategoryID = Request.QueryString.Get("CategoryID")
                CourseCode = Course
                Dim qrystring As String = "rptFeeDueStatementV.aspx?" & "&BatchId=" & BatchId & "&SemID=" & SemID & "&StdID=" & StdID & "&CategoryID=" & CategoryID & "&CourseCode=" & CourseCode
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Select Elective" Then
                Dim qrystring As String = "frmSelectElective.aspx?" & "&StudentCode=" & StudentCode
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Student Feedback On Teaching Faculty" Then
                Dim qrystring As String = "FrmFeedBackForm.aspx?" & "&StudentCode=" & StudentCode & "&Batch=" & Batch
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Student Exam Subject" Then
                Dim qrystring As String = "frmStudentExamSubject.aspx?" & "&StudentCode=" & StudentCode & "&Batch=" & Batch
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Semester Attendance List" Then
                Dim SubSubgrp, RptType As Integer
                Subject = 0
                SubSubgrp = 0
                RptType = 1
                Dim qrystring As String = "RptStudAttendListV.aspx?" & "&Batch=" & Batch & "&Semester=" & Semester & "&Student=" & Student & "&BranchCode=" & BranchCode & "&Subject=" & Subject & "&SubSubgrp=" & SubSubgrp & "&RptType=" & RptType
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            ElseIf ChildName = "Student Dashboard" Then
                Dim StdID As Integer
                Dim StdCode, StdName As String
                StdID = Student
                StdCode = txtStudentCode.Text
                StdName = txtStudentName.Text
                Dim qrystring As String = "FrmStudentDashboard.aspx?" & "&StdID=" & StdID & "&StdCode=" & StdCode & "&StdName=" & StdName
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            End If
        Catch ex As Exception
            lblerrormsg.Text = "Enter Correct data."
            'StdDetails.Visible = False
            'Exit Sub
        End Try
    End Sub

    Protected Sub txtStudentCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStudentCode.TextChanged
        'ddlBatchName.Items.Clear()
        Splitter(txtStudentCode.Text)
    End Sub

    Protected Sub txtStudentName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStudentName.TextChanged
        ' ddlBatchName.Items.Clear()
        Splitter(txtStudentCode.Text)
    End Sub
End Class

