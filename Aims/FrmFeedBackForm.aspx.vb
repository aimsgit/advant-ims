
Partial Class FrmFeedBackForm
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
            GVFeedBack.DataSource = Dt
            GVFeedBack.DataBind()
            GVFeedBack.Visible = True
            BtnUpdate.Visible = True
            Dt1 = FDBackBl.FeedBackParamsGridView(FDBack)
            GVParams.DataSource = Dt1
            GVParams.DataBind()
            GVParams.Visible = True
            lblMsg.Text = ""
            msginfo.Text = ""
        End If
        
    End Sub

    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Dim Max, Min As Integer


        Dt2 = FDBackBl.FeedbackMaxMin(FDBack)
        If Dt2.Rows(0).Item("Max").ToString = "" And Dt2.Rows(0).Item("Min").ToString = "" Then
            msginfo.Text = "Please Generate Feedback Parameters"
            lblMsg.Text = ""
        Else

            Max = Dt2.Rows(0).Item("Max").ToString
            Min = Dt2.Rows(0).Item("Min").ToString

            If GVFeedBack.Rows.Count = 0 Then
                msginfo.Text = "Please Generate before Updating."
                lblMsg.Text = ""
                Exit Sub
            End If

            


            For Each Grid As GridViewRow In GVFeedBack.Rows
                If GVFeedBack.Columns(5).Visible = True Then
                    If CType(Grid.FindControl("txtP1"), TextBox).Text = "" Then
                        msginfo.Text = "P1 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP1"), TextBox).Text < Min Or CType(Grid.FindControl("txtP1"), TextBox).Text > Max Then
                        msginfo.Text = "P1 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If
                If GVFeedBack.Columns(6).Visible = True Then
                    If CType(Grid.FindControl("txtP2"), TextBox).Text = "" Then
                        msginfo.Text = "P2 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP2"), TextBox).Text < Min Or CType(Grid.FindControl("txtP2"), TextBox).Text > Max Then
                        msginfo.Text = "P2 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If

                If GVFeedBack.Columns(7).Visible = True Then
                    If CType(Grid.FindControl("txtP3"), TextBox).Text = "" Then
                        msginfo.Text = "P3 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP3"), TextBox).Text < Min Or CType(Grid.FindControl("txtP3"), TextBox).Text > Max Then
                        msginfo.Text = "P3 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If

                If GVFeedBack.Columns(8).Visible = True Then
                    If CType(Grid.FindControl("txtP4"), TextBox).Text = "" Then
                        msginfo.Text = "P4 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP4"), TextBox).Text < Min Or CType(Grid.FindControl("txtP4"), TextBox).Text > Max Then
                        msginfo.Text = "P4 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If

                If GVFeedBack.Columns(9).Visible = True Then
                    If CType(Grid.FindControl("txtP5"), TextBox).Text = "" Then
                        msginfo.Text = "P5 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP5"), TextBox).Text < Min Or CType(Grid.FindControl("txtP5"), TextBox).Text > Max Then
                        msginfo.Text = "P5 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If
                If GVFeedBack.Columns(10).Visible = True Then
                    If CType(Grid.FindControl("txtP6"), TextBox).Text = "" Then
                        msginfo.Text = "P6 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP6"), TextBox).Text < Min Or CType(Grid.FindControl("txtP6"), TextBox).Text > Max Then
                        msginfo.Text = "P6 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If

                If GVFeedBack.Columns(11).Visible = True Then
                    If CType(Grid.FindControl("txtP7"), TextBox).Text = "" Then
                        msginfo.Text = "P7 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP7"), TextBox).Text < Min Or CType(Grid.FindControl("txtP7"), TextBox).Text > Max Then
                        msginfo.Text = "P7 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If

                If GVFeedBack.Columns(12).Visible = True Then
                    If CType(Grid.FindControl("txtP8"), TextBox).Text = "" Then
                        msginfo.Text = "P8 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP8"), TextBox).Text < Min Or CType(Grid.FindControl("txtP8"), TextBox).Text > Max Then
                        msginfo.Text = "P8 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If

                If GVFeedBack.Columns(13).Visible = True Then
                    If CType(Grid.FindControl("txtP9"), TextBox).Text = "" Then
                        msginfo.Text = "P9 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP9"), TextBox).Text < Min Or CType(Grid.FindControl("txtP9"), TextBox).Text > Max Then
                        msginfo.Text = "P9 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If

                If GVFeedBack.Columns(14).Visible = True Then
                    If CType(Grid.FindControl("txtP10"), TextBox).Text = "" Then
                        msginfo.Text = "P10 Column Textbox cannot be left blank."
                        lblMsg.Text = ""
                        Exit Sub
                    ElseIf CType(Grid.FindControl("txtP10"), TextBox).Text < Min Or CType(Grid.FindControl("txtP10"), TextBox).Text > Max Then
                        msginfo.Text = "P10 Column Textbox cannot be Greater than " & Max & " and " & "Lesser than " & Min
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If
            Next
            For Each Grid1 As GridViewRow In GVFeedBack.Rows
                FDBack.BatchId = CType(Grid1.FindControl("lblBatchId"), Label).Text
                FDBack.SemId = CType(Grid1.FindControl("lblSemId"), Label).Text
                'If Session("LoginType") = "Others" Then
                '    FDBack.BatchId = BatchId
                '    FDBack.SemId = SemId
                'Else
                '    FDBack.BatchId = ddlbatch.SelectedValue
                '    FDBack.SemId = ddlSemester.SelectedValue
                'End If

                FDBack.SubJectId = CType(Grid1.FindControl("lblSubjectId"), HiddenField).Value
                'FDBack.FacultyId = CType(Grid1.FindControl("lblFacultyId"), HiddenField).Value
                If CType(Grid1.FindControl("lblFacultyId"), HiddenField).Value = "" Then
                    FDBack.FacultyId = 0
                Else
                    FDBack.FacultyId = CType(Grid1.FindControl("lblFacultyId"), HiddenField).Value
                End If

                If CType(Grid1.FindControl("txtP1"), TextBox).Text = "" Then
                    FDBack.Score1 = 0
                Else
                    FDBack.Score1 = CType(Grid1.FindControl("txtP1"), TextBox).Text
                End If

                If CType(Grid1.FindControl("txtP2"), TextBox).Text = "" Then
                    FDBack.Score2 = 0
                Else
                    FDBack.Score2 = CType(Grid1.FindControl("txtP2"), TextBox).Text
                End If

                If CType(Grid1.FindControl("txtP3"), TextBox).Text = "" Then
                    FDBack.Score3 = 0
                Else
                    FDBack.Score3 = CType(Grid1.FindControl("txtP3"), TextBox).Text
                End If

                If CType(Grid1.FindControl("txtP4"), TextBox).Text = "" Then
                    FDBack.Score4 = 0
                Else
                    FDBack.Score4 = CType(Grid1.FindControl("txtP4"), TextBox).Text
                End If

                If CType(Grid1.FindControl("txtP5"), TextBox).Text = "" Then
                    FDBack.Score5 = 0
                Else
                    FDBack.Score5 = CType(Grid1.FindControl("txtP5"), TextBox).Text
                End If

                If CType(Grid1.FindControl("txtP6"), TextBox).Text = "" Then
                    FDBack.Score6 = 0
                Else
                    FDBack.Score6 = CType(Grid1.FindControl("txtP6"), TextBox).Text
                End If

                If CType(Grid1.FindControl("txtP7"), TextBox).Text = "" Then
                    FDBack.Score7 = 0
                Else
                    FDBack.Score7 = CType(Grid1.FindControl("txtP7"), TextBox).Text
                End If

                If CType(Grid1.FindControl("txtP8"), TextBox).Text = "" Then
                    FDBack.Score8 = 0
                Else
                    FDBack.Score8 = CType(Grid1.FindControl("txtP8"), TextBox).Text
                End If

                If CType(Grid1.FindControl("txtP9"), TextBox).Text = "" Then
                    FDBack.Score9 = 0
                Else
                    FDBack.Score9 = CType(Grid1.FindControl("txtP9"), TextBox).Text
                End If

                If CType(Grid1.FindControl("txtP10"), TextBox).Text = "" Then
                    FDBack.Score10 = 0
                Else
                    FDBack.Score10 = CType(Grid1.FindControl("txtP10"), TextBox).Text
                End If
                FDBack.Remarks = CType(Grid1.FindControl("txtRemarks"), TextBox).Text
                'FDBack.Remarks = txtRemarks.Text
                FDBackBl.InsertFeedBack(FDBack)
                lblMsg.Text = "Feedback Submitted Successfully."
                msginfo.Text = ""
                GVFeedBack.Visible = False
                GVParams.Visible = False
                BtnUpdate.Visible = False

            Next
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

                dt3 = FeedBackFormDL.StudentCurrentBatch(Session("StudentCode"))
                BatchId = dt3.Rows(0).Item("Batch_No").ToString
                BranchCode = dt3.Rows(0).Item("BranchCode").ToString

                dt4 = FeedBackFormDL.StudentCurrentSem(BatchId, BranchCode)
                SemId = dt4.Rows(0).Item("SemesterID").ToString

                Dt = FeedBackFormDL.FeedbackOpenClose(BatchId, SemId)
                ConfigValue = Dt.Rows(0).Item("Config_Value").ToString
                If ConfigValue = "open" Then
                    Panel3.Visible = True
                    BtnUpdate.Visible = True
                    StdCode = Session("StudentCode")

                    lblSem1.Text = dt4.Rows(0).Item("SemName").ToString
                    LblBatchNo1.Text = dt3.Rows(0).Item("Batch").ToString
                    lblStdCode1.Text = Session("StudentCode").ToString
                    LblCourse1.Text = dt3.Rows(0).Item("CourseName").ToString

                    'FDBack.BatchId = ddlbatch.SelectedValue
                    'FDBack.SemId = ddlSemester.SelectedValue
                    'FDBackBl.InsertFeedBack(FDBack)

                    'To check the Student Feedback status 
                    dt5 = FeedBackFormDL.CheckStudentFeedbackStatusNew(BatchId, SemId)
                    DupCount = dt5.Rows(0).Item("Count").ToString
                    If DupCount > 0 Then
                        lblMsg.Text = "Feedback is already Submitted."
                        msginfo.Text = ""
                        BtnUpdate.Visible = False
                        Exit Sub
                    End If

                    'To Generate the Student Feedback Gridview
                    Dt = FeedBackFormDL.GetFeedBackGVStudent(BranchCode, BatchId, SemId, Session("LoginType"), Session("StudentCode"))
                    GVFeedBack.DataSource = Dt
                    GVFeedBack.DataBind()
                    GVFeedBack.Visible = True
                    BtnUpdate.Visible = True

                    'To Get the Parameters in the Griview
                    Dt1 = FeedBackFormDL.FeedBackParamsGridViewStudent(BranchCode)
                    GVParams.DataSource = Dt1
                    GVParams.DataBind()
                    GVParams.Visible = True
                    lblMsg.Text = ""
                    msginfo.Text = ""

                    'For Hiding the GridView cloumns based on no of Parameters
                    Count = Dt1.Rows.Count
                    If Count = 1 Then
                        GVFeedBack.Columns(6).Visible = False
                        GVFeedBack.Columns(7).Visible = False
                        GVFeedBack.Columns(8).Visible = False
                        GVFeedBack.Columns(9).Visible = False
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 2 Then
                        GVFeedBack.Columns(7).Visible = False
                        GVFeedBack.Columns(8).Visible = False
                        GVFeedBack.Columns(9).Visible = False
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 3 Then
                        GVFeedBack.Columns(8).Visible = False
                        GVFeedBack.Columns(9).Visible = False
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 4 Then
                        GVFeedBack.Columns(9).Visible = False
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 5 Then
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 6 Then
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 7 Then
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 8 Then
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 9 Then
                        GVFeedBack.Columns(14).Visible = False
                    End If
                Else

                    lblMsg.Text = "Student's Feedback on Teaching Faculty is not Scheduled."
                    msginfo.Text = ""
                    BtnUpdate.Visible = False
                End If
            ElseIf Session("Form") = "frmStudentEnquiryForm.aspx" Then
                ddlbatch.Visible = False
                ddlSemester.Visible = False
                lblbatch.Visible = False
                lblSemester.Visible = False
                btnGenrate.Visible = False

                Dim StudentCode As String
                StudentCode = Request.QueryString.Get("StudentCode")
                Session("StudentCode") = StudentCode
                dt3 = FeedBackFormDL.StudentCurrentBatch(StudentCode)
                BatchId = dt3.Rows(0).Item("Batch_No").ToString
                BranchCode = dt3.Rows(0).Item("BranchCode").ToString

                dt4 = FeedBackFormDL.StudentCurrentSem(BatchId, BranchCode)
                SemId = dt4.Rows(0).Item("SemesterID").ToString

                Dt = FeedBackFormDL.FeedbackOpenClose(BatchId, SemId)
                ConfigValue = Dt.Rows(0).Item("Config_Value").ToString
                If ConfigValue = "open" Then
                    Panel3.Visible = True
                    BtnUpdate.Visible = True
                    StdCode = Session("StudentCode")

                    lblSem1.Text = dt4.Rows(0).Item("SemName").ToString
                    LblBatchNo1.Text = dt3.Rows(0).Item("Batch").ToString
                    lblStdCode1.Text = Session("StudentCode").ToString
                    LblCourse1.Text = dt3.Rows(0).Item("CourseName").ToString

                    dt5 = FeedBackFormDL.CheckStudentFeedbackStatusNew(BatchId, SemId)
                    DupCount = dt5.Rows(0).Item("Count").ToString
                    If DupCount > 0 Then
                        lblMsg.Text = "Feedback is already Submitted."
                        msginfo.Text = ""
                        BtnUpdate.Visible = False
                        Exit Sub
                    End If
                    'To Generate the Student Feedback Gridview
                    Dt = FeedBackFormDL.GetFeedBackGVStudent(BranchCode, BatchId, SemId, "Others", Session("StudentCode"))
                    GVFeedBack.DataSource = Dt
                    GVFeedBack.DataBind()
                    GVFeedBack.Visible = True
                    BtnUpdate.Visible = True


                    'To Get the Parameters in the Griview
                    Dt1 = FeedBackFormDL.FeedBackParamsGridViewStudent(BranchCode)
                    GVParams.DataSource = Dt1
                    GVParams.DataBind()
                    GVParams.Visible = True
                    lblMsg.Text = ""
                    msginfo.Text = ""

                    'For Hiding the GridView cloumns based on no of Parameters
                    Count = Dt1.Rows.Count
                    If Count = 1 Then
                        GVFeedBack.Columns(6).Visible = False
                        GVFeedBack.Columns(7).Visible = False
                        GVFeedBack.Columns(8).Visible = False
                        GVFeedBack.Columns(9).Visible = False
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 2 Then
                        GVFeedBack.Columns(7).Visible = False
                        GVFeedBack.Columns(8).Visible = False
                        GVFeedBack.Columns(9).Visible = False
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 3 Then
                        GVFeedBack.Columns(8).Visible = False
                        GVFeedBack.Columns(9).Visible = False
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 4 Then
                        GVFeedBack.Columns(9).Visible = False
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 5 Then
                        GVFeedBack.Columns(10).Visible = False
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 6 Then
                        GVFeedBack.Columns(11).Visible = False
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 7 Then
                        GVFeedBack.Columns(12).Visible = False
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 8 Then
                        GVFeedBack.Columns(13).Visible = False
                        GVFeedBack.Columns(14).Visible = False
                    ElseIf Count = 9 Then
                        GVFeedBack.Columns(14).Visible = False
                    End If
                Else

                    lblMsg.Text = "Student's Feedback on Teaching Faculty is not Scheduled."
                    msginfo.Text = ""
                    BtnUpdate.Visible = False
                End If

            End If
        End If
    End Sub
End Class
