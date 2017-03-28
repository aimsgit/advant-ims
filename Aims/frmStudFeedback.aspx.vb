
Partial Class frmStudFeedback
    Inherits BasePage
    Dim FDBack As New FeedBackForm
    Dim FDBackBl As New FeedBackFormBL
    Dim FDBackDl As New FeedBackFormDL
    Dim Dt, Dt1, Dt2, dt3, dt4, dt5 As New DataTable
    Dim BatchId, SemId As Integer
    Dim StdCode, ConfigValue, BranchCode As String

    Protected Sub btnGenrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenrate.Click
        If ddlbatch.SelectedValue = 0 And ddlSemester.SelectedValue = 0 Then
            lblMsg.Text = ""
            msginfo.Text = "Please select Batch and Semester."
        ElseIf ddlbatch.SelectedValue <> 0 And ddlSemester.SelectedValue = 0 Then
            lblMsg.Text = ""
            msginfo.Text = "Please select Semester."
        Else
            FDBack.BatchId = ddlbatch.SelectedValue
            FDBack.SemId = ddlSemester.SelectedValue
            'FDBackBl.InsertFeedBack(FDBack)
            Dt = FDBackBl.GetFeedBackGV(FDBack)
            'GVFeedBack.DataSource = Dt
            'GVFeedBack.DataBind()
            'GVFeedBack.Visible = True
            Dt1 = FDBackBl.FeedBackParamsGridView(FDBack)
            GVParams.DataSource = Dt1
            GVParams.DataBind()
            GVParams.Visible = True
            lblMsg.Text = ""
            msginfo.Text = ""

        End If

    End Sub

    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        BtnUpdate.Visible = True
        Dim DupCount, Max, Min, Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, PNo As Integer
        Dt2 = FDBackBl.FeedbackMaxMin(FDBack)
        If Dt2.Rows(0).Item("Max").ToString = "" And Dt2.Rows(0).Item("Min").ToString = "" Then
            msginfo.Text = "Please Generate Feedback Parameters"
            lblMsg.Text = ""
        Else

            dt5 = FeedBackFormDL.CheckStudentFeedbackStatus(ViewState("Batch"), ViewState("SemId"), ddlSubject.SelectedValue)
            DupCount = dt5.Rows(0).Item("Count").ToString
            If DupCount > 0 Then
                msginfo.Text = "Feedback is already Submitted."
                lblMsg.Text = ""
                Exit Sub
            Else

                Max = Dt2.Rows(0).Item("Max").ToString
                Min = Dt2.Rows(0).Item("Min").ToString


                For Each grid As GridViewRow In GVParams.Rows

                    If (CType(grid.FindControl("txtP1"), TextBox).Text = "") Then
                        msginfo.Text = "Rating Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(grid.FindControl("txtP1"), TextBox).Text < Min Or CType(grid.FindControl("txtP1"), TextBox).Text > Max Then
                        msginfo.Text = "Rating Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    Else

                        If (CType(grid.FindControl("lblPNo"), Label).Text) = 1 Then
                            Score1 = CType(grid.FindControl("txtP1"), TextBox).Text
                        ElseIf (CType(grid.FindControl("lblPNo"), Label).Text) = 2 Then
                            Score2 = CType(grid.FindControl("txtP1"), TextBox).Text
                        ElseIf (CType(grid.FindControl("lblPNo"), Label).Text) = 3 Then
                            Score3 = CType(grid.FindControl("txtP1"), TextBox).Text
                        ElseIf (CType(grid.FindControl("lblPNo"), Label).Text) = 4 Then
                            Score4 = CType(grid.FindControl("txtP1"), TextBox).Text
                        ElseIf (CType(grid.FindControl("lblPNo"), Label).Text) = 5 Then
                            Score5 = CType(grid.FindControl("txtP1"), TextBox).Text
                        ElseIf (CType(grid.FindControl("lblPNo"), Label).Text) = 6 Then
                            Score6 = CType(grid.FindControl("txtP1"), TextBox).Text
                        ElseIf (CType(grid.FindControl("lblPNo"), Label).Text) = 7 Then
                            Score7 = CType(grid.FindControl("txtP1"), TextBox).Text
                        ElseIf (CType(grid.FindControl("lblPNo"), Label).Text) = 8 Then
                            Score8 = CType(grid.FindControl("txtP1"), TextBox).Text
                        ElseIf (CType(grid.FindControl("lblPNo"), Label).Text) = 9 Then
                            Score9 = CType(grid.FindControl("txtP1"), TextBox).Text
                        ElseIf (CType(grid.FindControl("lblPNo"), Label).Text) = 10 Then
                            Score10 = CType(grid.FindControl("txtP1"), TextBox).Text
                        End If

                    End If

                Next
                FeedBackFormDL.InsertFeedBackNew(ViewState("Batch"), ViewState("SemId"), ddlSubject.SelectedValue, ViewState("FacultyId"), Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, txtRemarks.Text)
                lblMsg.Text = "Feedback Submitted Successfully."
                msginfo.Text = ""

            End If
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Count, DupCount As Integer
        If Not IsPostBack Then
            If Session("LoginType") = "Others" Then
                ddlbatch.Visible = False
                ddlSemester.Visible = False
                lblbatch.Visible = False
                lblSemester.Visible = False
                btnGenrate.Visible = False
                lblSubject.Visible = True
                ddlSubject.Visible = True
                ddlSubject.SelectedValue = 0
                btnGnrt.Visible = True
                GVParams.Visible = False
                lblRemarks.Visible = False
                txtRemarks.Visible = False

                dt3 = FeedBackFormDL.StudentCurrentBatch(Session("StudentCode"))
                BatchId = dt3.Rows(0).Item("Batch_No").ToString
                ViewState("Batch") = BatchId
                BranchCode = dt3.Rows(0).Item("BranchCode").ToString
                ViewState("BranchCode") = BranchCode
                

                dt4 = FeedBackFormDL.StudentCurrentSem(BatchId, BranchCode)
                SemId = dt4.Rows(0).Item("SemesterID").ToString
                ViewState("SemId") = SemId



                Dt = FeedBackFormDL.FeedbackOpenClose(BatchId, SemId)
                ConfigValue = Dt.Rows(0).Item("Config_Value").ToString
                If ConfigValue = "open" Then
                    Panel3.Visible = True
                    BtnUpdate.Visible = True
                    StdCode = Session("StudentCode")

                    LblBatchNo1.Text = dt3.Rows(0).Item("Batch").ToString
                    lblStdCode1.Text = Session("StudentCode").ToString
                    LblCourse1.Text = dt3.Rows(0).Item("CourseName").ToString
                    lblSem1.Text = dt4.Rows(0).Item("SemName").ToString

                    Dim dt As DataTable
                    dt = FeedBackFormDL.GetSubjectCombo(BranchCode, BatchId, SemId)
                    ddlSubject.Items.Clear()
                    ddlSubject.DataSource = dt
                    ddlSubject.DataBind()


                    'To check the Student Feedback status 

                    'To Generate the Student Feedback Gridview
                    dt = FeedBackFormDL.GetFeedBackGVStudent(BranchCode, BatchId, SemId, Session("LoginType"), Session("StudentCode"))
                    'GVFeedBack.DataSource = Dt
                    'GVFeedBack.DataBind()
                    'GVFeedBack.Visible = True


                    'To Get the Parameters in the Griview
                    'Dt1 = FeedBackFormDL.FeedBackParamsGridViewStudent(BranchCode)
                    'GVParams.DataSource = Dt1
                    'GVParams.DataBind()
                    'GVParams.Visible = True
                    'lblMsg.Text = ""
                    'msginfo.Text = ""

                    'For Hiding the GridView cloumns based on no of Parameters
                    Count = Dt1.Rows.Count


                Else

                    msginfo.Text = "Student's Feedback on Teaching Faculty is not Scheduled."
                    lblMsg.Text = ""


                End If

            End If
        End If
        BtnUpdate.Visible = False
    End Sub

    Protected Sub btnGnrt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGnrt.Click
        If ddlSubject.SelectedValue = 0 Then
            msginfo.Text = "Select Subject Field."
            GVParams.Visible = False
            lblRemarks.Visible = False
            txtRemarks.Visible = False
            lblMsg.Text = ""
        Else
            Dt1 = FeedBackFormDL.FeedBackParamsGridViewStudent(ViewState("BranchCode"))
            GVParams.DataSource = Dt1

            GVParams.Visible = True
            GVParams.Columns(1).HeaderText = ""
            GVParams.Columns(1).HeaderText = "Rating" + "(" + Dt1.Rows(0).Item("Min").ToString + "-" + Dt1.Rows(0).Item("Max").ToString + ")"
            GVParams.Columns(1).Visible = True
            GVParams.DataBind()
            lblMsg.Text = ""
            msginfo.Text = ""
            lblRemarks.Visible = True
            txtRemarks.Visible = True
            BtnUpdate.Visible = True

        End If
    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
        lblFaculty.Visible = True
        lblFaculty1.Visible = True
        GVParams.Visible = False
        lblRemarks.Visible = False
        txtRemarks.Visible = False
        lblFaculty1.Visible = False
        GRPhoto.Visible = False
        'Image3.Visible = True
        Dim dt1 As New DataTable
        dt1 = FeedBackFormDL.GetFaculty(ViewState("BranchCode"), ViewState("Batch"), ViewState("SemId"), ddlSubject.SelectedValue)

        If dt1.Rows.Count > 0 Then
            lblFaculty1.Text = dt1.Rows(0).Item("FACULTY").ToString
            ViewState("FacultyId") = dt1.Rows(0).Item("Lecturer").ToString
            GRPhoto.DataSource = dt1
            GRPhoto.DataBind()
            GRPhoto.Visible = True
            lblFaculty1.Visible = True
            lblMsg.Text = ""
            msginfo.Text = ""

        End If
    End Sub
End Class
