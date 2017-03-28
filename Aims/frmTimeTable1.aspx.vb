Partial Class frmTimeTable1
    Inherits BasePage
    Dim El As New TimeTableEL
    Dim Bl As New TimeTableBl
    Dim Dl As New TimeTableDl
    Dim dt As New DataTable


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ddlCourseName.Focus()


        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ddlCourseName.Enabled = True
                ddlBatchName.Enabled = True
                ddlSemester.Enabled = True
                ddlWeekNo.Enabled = True
                msginfo.Text = ""
                msginfo1.Text = ""
                El.CourseId = ddlCourseName.SelectedValue
                El.BatchId = ddlBatchName.SelectedValue
                El.SemId = ddlSemester.SelectedValue
                El.WeekNo = ddlWeekNo.SelectedValue
                El.Period = txtPeriod.Text
                El.Day1Sub = ddlDay1Subject.SelectedValue
                El.Day2Sub = ddlDay2Subject.SelectedValue
                El.Day3Sub = ddlDay3Subject.SelectedValue
                El.Day4Sub = ddlDay4Subject.SelectedValue
                El.Day5Sub = ddlDay5Subject.SelectedValue
                El.Day6Sub = ddlDay6Subject.SelectedValue
                El.Day7Sub = ddlDay7Subject.SelectedValue

                El.Day1Teacher = ddlDay1Teacher.SelectedValue
                El.Day2Teacher = ddlDay2Teacher.SelectedValue
                El.Day3Teacher = ddlDay3Teacher.SelectedValue
                El.Day4Teacher = ddlDay4Teacher.SelectedValue
                El.Day5Teacher = ddlDay5Teacher.SelectedValue
                El.Day6Teacher = ddlDay6Teacher.SelectedValue
                El.Day7Teacher = ddlDay7Teacher.SelectedValue

                El.RId1 = ddlResrc1.SelectedValue
                El.RId2 = ddlResrc2.SelectedValue
                El.RId3 = ddlResrc3.SelectedValue
                El.RId4 = ddlResrc4.SelectedValue
                El.RId5 = ddlResrc5.SelectedValue
                El.RId6 = ddlResrc6.SelectedValue
                El.RId7 = ddlResrc7.SelectedValue

                El.Remarks1 = txtDay1Remarks.Text
                El.Remarks2 = txtDay2Remarks.Text
                El.Remarks3 = txtDay3Remarks.Text
                El.Remarks4 = txtDay4Remarks.Text
                El.Remarks5 = txtDay5Remarks.Text
                El.Remarks6 = txtDay6Remarks.Text
                El.Remarks7 = txtDay7Remarks.Text

                If txtDay1StartDate.Text <> "" Then
                    El.Day1StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay1StartDate.Text), DateFormat.ShortTime))
                Else
                    El.Day1StartTime = CDate("1/1/1900")
                End If

                If txtDay2StartDate.Text <> "" Then
                    El.Day2StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay2StartDate.Text), DateFormat.ShortTime))
                Else
                    El.Day2StartTime = CDate("1/1/1900")
                End If
                If txtDay3StartDate.Text <> "" Then
                    El.Day3StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay3StartDate.Text), DateFormat.ShortTime))
                Else
                    El.Day3StartTime = CDate("1/1/1900")
                End If
                If txtDay4StartDate.Text <> "" Then
                    El.Day4StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay4StartDate.Text), DateFormat.ShortTime))
                Else
                    El.Day4StartTime = CDate("1/1/1900")
                End If

                If txtDay5StartDate.Text <> "" Then
                    El.Day5StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay5StartDate.Text), DateFormat.ShortTime))
                Else
                    El.Day5StartTime = CDate("1/1/1900")
                End If
                If txtDay6StartDate.Text <> "" Then
                    El.Day6StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay6StartDate.Text), DateFormat.ShortTime))
                Else
                    El.Day6StartTime = CDate("1/1/1900")
                End If
                If txtDay7StartDate.Text <> "" Then
                    El.Day7StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay7StartDate.Text), DateFormat.ShortTime))
                Else
                    El.Day7StartTime = CDate("1/1/1900")
                End If

                If txtDay1EndDate.Text <> "" Then
                    El.Day1EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay1EndDate.Text), DateFormat.ShortTime))
                Else
                    El.Day1EndTime = CDate("1/1/1900")
                End If
                If txtDay2EndDate.Text <> "" Then
                    El.Day2EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay2EndDate.Text), DateFormat.ShortTime))
                Else
                    El.Day2EndTime = CDate("1/1/1900")
                End If
                If txtDay3EndDate.Text <> "" Then
                    El.Day3EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay3EndDate.Text), DateFormat.ShortTime))
                Else
                    El.Day3EndTime = CDate("1/1/1900")
                End If
                If txtDay4EndDate.Text <> "" Then
                    El.Day4EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay4EndDate.Text), DateFormat.ShortTime))
                Else
                    El.Day4EndTime = CDate("1/1/1900")
                End If
                If txtDay5EndDate.Text <> "" Then
                    El.Day5EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay5EndDate.Text), DateFormat.ShortTime))
                Else
                    El.Day5EndTime = CDate("1/1/1900")
                End If
                If txtDay6EndDate.Text <> "" Then
                    El.Day6EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay6EndDate.Text), DateFormat.ShortTime))
                Else
                    El.Day6EndTime = CDate("1/1/1900 ")
                End If
                If txtDay7EndDate.Text <> "" Then
                    El.Day7EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtDay7EndDate.Text), DateFormat.ShortTime))
                Else
                    El.Day7EndTime = CDate("1/1/1900 ")
                End If

                If BtnSave.Text = "UPDATE" Then
                    If txtPeriod.Text = "" Then
                        msginfo.Text = "Period Field is Mandatory."

                        lblmsg.Text = ""
                    Else

                        El.Id = ViewState("id")
                        dt = Bl.GetDuplicatedata(El)
                        Dim COUNT As Integer
                        COUNT = 0
                        If dt.Rows.Count > 0 Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                Dim Batch As String
                                Dim Course As String
                                Dim Semester As String
                                Dim Week As Integer
                                Dim split As String()
                                Batch = dt.Rows(i).Item("Batch_No").ToString
                                Course = dt.Rows(i).Item("CourseName").ToString
                                Semester = dt.Rows(i).Item("SemName").ToString
                                Week = dt.Rows(i).Item("WeekNo").ToString
                                split = dt.Rows(i).Item("Duplicate").ToString.Split(":")
                                If split(1) = 0 Then
                                    COUNT = COUNT + 1
                                    If dt.Rows.Count = COUNT Then
                                        GoTo UPDATE
                                    End If
                                Else
                                    If split(0).Contains("T") Then
                                        If Trim(split(0)) = "T1" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay1Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay1StartDate.Text) + "-" + CStr(txtDay1EndDate.Text) + " Monday </br> Course : " + Course + " , Batch : " + Batch + " ,Semester : " + Semester +  ". </br>"


                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T2" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay2Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay2StartDate.Text) + "-" + CStr(txtDay2EndDate.Text) + " Tuesday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"


                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T3" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay3Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay3StartDate.Text) + "-" + CStr(txtDay3EndDate.Text) + " Wednesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T4" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay4Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay4StartDate.Text) + "-" + CStr(txtDay4EndDate.Text) + " Thursday  </br> Course : " + Batch + " , Batch : " + Course + " ,Semester : " + Semester + ". </br>"

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T5" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay5Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay5StartDate.Text) + "-" + CStr(txtDay5EndDate.Text) + " Friday  </br> Course : " + Batch + " , Batch : " + Course + " ,Semester : " + Semester + ". </br>"

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T6" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay6Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay6StartDate.Text) + "-" + CStr(txtDay6EndDate.Text) + " Saturday  </br> Course : " + Batch + " , Batch : " + Course + " ,Semester : " + Semester + ". </br>"
                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T7" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay7Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay7StartDate.Text) + "-" + CStr(txtDay7EndDate.Text) + " Sunday  </br> Course : " + Batch + " , Batch : " + Course + " ,Semester : " + Semester + ". </br>"

                                            Exit Sub
                                        End If
                                    Else
                                        If Trim(split(0)) = "R1" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlResrc1.SelectedItem.ToString) + " is already allocated for" + CStr(txtDay1StartDate.Text) + "-" + CStr(txtDay1EndDate.Text) + " Monday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R2" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()

                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlResrc2.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay2StartDate.Text) + "-" + CStr(txtDay2EndDate.Text) + " Tuesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R3" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlResrc3.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay3StartDate.Text) + "-" + CStr(txtDay3EndDate.Text) + " Wednesday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"


                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R4" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = " " + CStr(ddlResrc4.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay4StartDate.Text) + "-" + CStr(txtDay4EndDate.Text) + " Thursday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R5" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = " " + CStr(ddlResrc5.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay5StartDate.Text) + "-" + CStr(txtDay5EndDate.Text) + " Friday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R6" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            'DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = " " + CStr(ddlResrc6.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay6StartDate.Text) + "-" + CStr(txtDay6EndDate.Text) + " Saturday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R7" Then
                                            Dim dt As New DataTable
                                            'El.Id = ViewState("id")
                                            El.BatchId = ddlBatchName.SelectedValue
                                            El.SemId = ddlSemester.SelectedValue
                                            El.WeekNo = ddlWeekNo.SelectedValue
                                            dt = Bl.GetData(El)
                                            GridView1.DataSource = dt
                                            GridView1.DataBind()
                                            GridView1.Enabled = False
                                            msginfo1.Text = ""
                                            msginfo.Text = " " + CStr(ddlResrc7.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay7StartDate.Text) + "-" + CStr(txtDay7EndDate.Text) + " Sunday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            Exit Sub
                                        End If
                                    End If
                                End If
                            Next
                        Else
UPDATE:                     Bl.UpdateRecord(El)
                            BtnSave.Text = "ADD"
                            BtnDetails.Text = "VIEW"
                            GridView1.PageIndex = ViewState("PageIndex")
                            DisplayGrid()
                            lblmsg.Text = "Data Updated Successfully."
                            msginfo.Text = ""
                            msginfo1.Text = ""
                            clear()
                            clear1()
                        End If
                    End If

                ElseIf BtnSave.Text = "ADD" Then
                    If txtPeriod.Text = "" Then
                        msginfo.Text = "Period Field is Mandatory."
                        msginfo1.Text = ""
                        lblmsg.Text = ""
                    Else
                        dt = Bl.GetDuplicatedata(El)
                        Dim COUNT As Integer
                        COUNT = 0
                        If dt.Rows.Count > 0 Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                Dim Batch As String
                                Dim Course As String
                                Dim Semester As String
                                Dim Week As Integer
                                Dim split As String()
                                Batch = dt.Rows(i).Item("Batch_No").ToString
                                Course = dt.Rows(i).Item("CourseName").ToString
                                Semester = dt.Rows(i).Item("SemName").ToString
                                Week = dt.Rows(i).Item("WeekNo").ToString
                                split = dt.Rows(i).Item("Duplicate").ToString.Split(":")

                                If split(1) = 0 Then
                                    COUNT = COUNT + 1
                                    If dt.Rows.Count = COUNT Then
                                        GoTo INSERT
                                    End If
                                Else
                                    If split(0).Contains("T") Then
                                        If Trim(split(0)) = "T1" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo.Text = "" + CStr(ddlDay1Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay1StartDate.Text) + "-" + CStr(txtDay1EndDate.Text) + " Monday </br> Course : " + Course + " , Batch : " + Batch + " ,Semester : " + Semester + ". </br>"
                                            msginfo1.Text = ""
                                            lblmsg.Text = ""

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T2" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo.Text = "" + CStr(ddlDay2Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay2StartDate.Text) + "-" + CStr(txtDay2EndDate.Text) + " Tuesday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                                            msginfo1.Text = ""
                                            lblmsg.Text = ""

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T3" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo.Text = "" + CStr(ddlDay3Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay3StartDate.Text) + "-" + CStr(txtDay3EndDate.Text) + " Wednesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                                            msginfo1.Text = ""
                                            lblmsg.Text = ""

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T4" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo.Text = "" + CStr(ddlDay4Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay4StartDate.Text) + "-" + CStr(txtDay4EndDate.Text) + " Thursday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                                            msginfo1.Text = ""
                                            lblmsg.Text = ""

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T5" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay5Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay5StartDate.Text) + "-" + CStr(txtDay5EndDate.Text) + " Friday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            lblmsg.Text = ""
                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T6" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay6Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay6StartDate.Text) + "-" + CStr(txtDay6EndDate.Text) + " Saturday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                                            lblmsg.Text = ""

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "T7" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlDay7Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay7StartDate.Text) + "-" + CStr(txtDay7EndDate.Text) + " Sunday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                                            lblmsg.Text = ""

                                            Exit Sub
                                        End If
                                    Else
                                        If Trim(split(0)) = "R1" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlResrc1.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay1StartDate.Text) + "-" + CStr(txtDay1EndDate.Text) + " Monday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            lblmsg.Text = ""
                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R2" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlResrc2.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay2StartDate.Text) + "-" + CStr(txtDay2EndDate.Text) + " Tuesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            lblmsg.Text = ""
                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R3" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = "" + CStr(ddlResrc3.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay3StartDate.Text) + "-" + CStr(txtDay3EndDate.Text) + " Wednesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            lblmsg.Text = ""
                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R4" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = " " + CStr(ddlResrc4.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay4StartDate.Text) + "-" + CStr(txtDay4EndDate.Text) + " Thursday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            lblmsg.Text = ""
                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R5" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = " " + CStr(ddlResrc5.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay5StartDate.Text) + "-" + CStr(txtDay5EndDate.Text) + " Friday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                                            lblmsg.Text = ""

                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R6" Then
                                            DisplayGrid()
                                            'clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = " " + CStr(ddlResrc6.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay6StartDate.Text) + "-" + CStr(txtDay6EndDate.Text) + " Saturday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                                            lblmsg.Text = ""
                                            Exit Sub
                                        End If
                                        If Trim(split(0)) = "R7" Then
                                            DisplayGrid()
                                            ' clear()
                                            msginfo1.Text = ""
                                            msginfo.Text = " " + CStr(ddlResrc7.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay7StartDate.Text) + "-" + CStr(txtDay7EndDate.Text) + " Sunday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                                            lblmsg.Text = ""
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            Next
                        Else

INSERT:                     Bl.InsertRecord(El)
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            DisplayGrid()
                            lblmsg.Text = "Data Saved Successfully."
                            msginfo1.Text = ""
                            msginfo.Text = ""
                            clear()
                            clear1()
                            GoTo Exit1


INSERT1:                    Bl.InsertRecord(El)
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            DisplayGrid()
                            lblmsg.Text = "Data Saved Successfully."
                            msginfo1.Text = ""
                            msginfo.Text = ""
                            clear()
                            clear1()


Exit1:                  End If
                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Enter Correct Data."
                lblmsg.Text = ""
                msginfo1.Text = ""
            End Try


        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
            msginfo1.Text = ""
        End If
    End Sub
    Protected Sub BtnCopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopyFrom.Click
        ddlCourseName.Focus()


        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ddlCourseName.Enabled = True
                ddlBatchName.Enabled = True
                ddlSemester.Enabled = True
                ddlWeekNo.Enabled = True
                msginfo.Text = ""
                msginfo1.Text = ""
                El.CourseId = ddlCourseName.SelectedValue
                El.BatchId = ddlBatchName.SelectedValue
                El.SemId = ddlSemester.SelectedValue
                El.WeekNo = ddlNewWeekNo.SelectedValue
                dt = Bl.GetData(El)
                Dim COUNT As Integer
                COUNT = 0
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        El.Period = dt.Rows(i).Item("Period").ToString()
                        El.Day1Sub = dt.Rows(i).Item("SubjectID1").ToString()
                        El.Day2Sub = dt.Rows(i).Item("SubjectID2").ToString()
                        El.Day3Sub = dt.Rows(i).Item("SubjectID3").ToString()
                        El.Day4Sub = dt.Rows(i).Item("SubjectID4").ToString()
                        El.Day5Sub = dt.Rows(i).Item("SubjectID5").ToString()
                        El.Day6Sub = dt.Rows(i).Item("SubjectID6").ToString()
                        El.Day7Sub = dt.Rows(i).Item("SubjectID7").ToString()

                        El.Day1Teacher = dt.Rows(i).Item("EmpID1").ToString()
                        El.Day2Teacher = dt.Rows(i).Item("EmpID2").ToString()
                        El.Day3Teacher = dt.Rows(i).Item("EmpID3").ToString()
                        El.Day4Teacher = dt.Rows(i).Item("EmpID4").ToString()
                        El.Day5Teacher = dt.Rows(i).Item("EmpID5").ToString()
                        El.Day6Teacher = dt.Rows(i).Item("EmpID6").ToString()
                        El.Day7Teacher = dt.Rows(i).Item("EmpID7").ToString()

                        El.RId1 = dt.Rows(i).Item("ResourceID1").ToString()
                        El.RId2 = dt.Rows(i).Item("ResourceID2").ToString()
                        El.RId3 = dt.Rows(i).Item("ResourceID3").ToString()
                        El.RId4 = dt.Rows(i).Item("ResourceID4").ToString()
                        El.RId5 = dt.Rows(i).Item("ResourceID5").ToString()
                        El.RId6 = dt.Rows(i).Item("ResourceID6").ToString()
                        El.RId7 = dt.Rows(i).Item("ResourceID7").ToString()

                        El.Remarks1 = dt.Rows(i).Item("Remarks1").ToString()
                        El.Remarks2 = dt.Rows(i).Item("Remarks2").ToString()
                        El.Remarks3 = dt.Rows(i).Item("Remarks3").ToString()
                        El.Remarks4 = dt.Rows(i).Item("Remarks4").ToString()
                        El.Remarks5 = dt.Rows(i).Item("Remarks5").ToString()
                        El.Remarks6 = dt.Rows(i).Item("Remarks6").ToString()
                        El.Remarks7 = dt.Rows(i).Item("Remarks7").ToString()

                        If dt.Rows(i).Item("StartTime1").ToString() <> "" Then
                            'El.Day1StartTime = FormatDateTime(dt.Rows(0).Item("StartTime1").ToString())
                            El.Day1StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("StartTime1").ToString()), DateFormat.ShortTime))
                        Else
                            El.Day1StartTime = CDate("1/1/1900")
                        End If

                        If dt.Rows(i).Item("StartTime2").ToString() <> "" Then
                            'El.Day2StartTime = FormatDateTime(dt.Rows(0).Item("StartTime2").ToString())
                            El.Day2StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("StartTime2").ToString()), DateFormat.ShortTime))
                        Else
                            El.Day2StartTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("StartTime3").ToString() <> "" Then
                            'El.Day3StartTime = FormatDateTime(dt.Rows(0).Item("StartTime3").ToString())
                            El.Day3StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("StartTime3").ToString()), DateFormat.ShortTime))

                        Else
                            El.Day3StartTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("StartTime4").ToString() <> "" Then
                            El.Day4StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("StartTime4").ToString()), DateFormat.ShortTime))
                            'El.Day4StartTime = FormatDateTime(dt.Rows(0).Item("StartTime4").ToString())
                        Else
                            El.Day4StartTime = CDate("1/1/1900")
                        End If

                        If dt.Rows(i).Item("StartTime5").ToString() <> "" Then
                            El.Day5StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("StartTime5").ToString()), DateFormat.ShortTime))
                            'El.Day5StartTime = FormatDateTime(dt.Rows(0).Item("StartTime5").ToString())
                        Else
                            El.Day5StartTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("StartTime6").ToString() <> "" Then
                            'El.Day6StartTime = FormatDateTime(dt.Rows(0).Item("StartTime6").ToString())
                            El.Day6StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("StartTime6").ToString()), DateFormat.ShortTime))
                        Else
                            El.Day6StartTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("StartTime7").ToString() <> "" Then
                            'El.Day7StartTime = FormatDateTime(dt.Rows(0).Item("StartTime7").ToString())
                            El.Day7StartTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("StartTime7").ToString()), DateFormat.ShortTime))
                        Else
                            El.Day7StartTime = CDate("1/1/1900")
                        End If

                        If dt.Rows(i).Item("EndTime1").ToString() <> "" Then
                            'El.Day1EndTime = FormatDateTime(dt.Rows(0).Item("EndTime1").ToString())
                            El.Day1EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("EndTime1").ToString()), DateFormat.ShortTime))

                        Else
                            El.Day1EndTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("EndTime2").ToString() <> "" Then
                            'El.Day2EndTime = FormatDateTime(dt.Rows(0).Item("EndTime2").ToString())
                            El.Day2EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("EndTime2").ToString()), DateFormat.ShortTime))
                        Else
                            El.Day2EndTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("EndTime3").ToString() <> "" Then
                            El.Day3EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("EndTime3").ToString()), DateFormat.ShortTime))
                            'El.Day3EndTime = FormatDateTime(dt.Rows(0).Item("EndTime3").ToString())
                        Else
                            El.Day3EndTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("EndTime4").ToString() <> "" Then
                            'El.Day4EndTime = FormatDateTime(dt.Rows(0).Item("EndTime4").ToString())
                            El.Day4EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("EndTime4").ToString()), DateFormat.ShortTime))
                        Else
                            El.Day4EndTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("EndTime5").ToString() <> "" Then
                            'El.Day5EndTime = FormatDateTime(dt.Rows(0).Item("EndTime5").ToString())
                            El.Day5EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("EndTime5").ToString()), DateFormat.ShortTime))
                        Else
                            El.Day5EndTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("EndTime6").ToString() <> "" Then
                            'El.Day6EndTime = FormatDateTime(dt.Rows(0).Item("EndTime6").ToString())
                            El.Day6EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("EndTime6").ToString()), DateFormat.ShortTime))
                        Else
                            El.Day6EndTime = CDate("1/1/1900")
                        End If
                        If dt.Rows(i).Item("EndTime7").ToString() <> "" Then
                            El.Day7EndTime = FormatDateTime(dt.Rows(0).Item("EndTime7").ToString())
                            El.Day7EndTime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(dt.Rows(i).Item("EndTime7").ToString()), DateFormat.ShortTime))
                        Else
                            El.Day7EndTime = CDate("1/1/1900")
                        End If

                        'If BtnSave.Text = "UPDATE" Then
                        '    If txtPeriod.Text = "" Then
                        '        msginfo.Text = "Period Field is Mandatory."

                        '        lblmsg.Text = ""
                        '    Else

                        '        El.Id = ViewState("id")
                        '        dt = Bl.GetDuplicatedata(El)
                        '                Dim COUNT As Integer
                        '                COUNT = 0
                        '                If dt.Rows.Count > 0 Then
                        '                    For i As Integer = 0 To dt.Rows.Count - 1
                        '                        Dim Batch As String
                        '                        Dim Course As String
                        '                        Dim Semester As String
                        '                        Dim Week As Integer
                        '                        Dim split As String()
                        '                        Batch = dt.Rows(i).Item("Batch_No").ToString
                        '                        Course = dt.Rows(i).Item("CourseName").ToString
                        '                        Semester = dt.Rows(i).Item("SemName").ToString
                        '                        Week = dt.Rows(i).Item("WeekNo").ToString
                        '                        split = dt.Rows(i).Item("Duplicate").ToString.Split(":")
                        '                        If split(1) = 0 Then
                        '                            COUNT = COUNT + 1
                        '                            If dt.Rows.Count = COUNT Then
                        '                                GoTo UPDATE
                        '                            End If
                        '                        Else
                        '                            If split(0).Contains("T") Then
                        '                                If Trim(split(0)) = "T1" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlDay1Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay1StartDate.Text) + "-" + CStr(txtDay1EndDate.Text) + " Monday </br> Course : " + Course + " , Batch : " + Batch + " ,Semester : " + Semester + ". </br>"


                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "T2" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlDay2Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay2StartDate.Text) + "-" + CStr(txtDay2EndDate.Text) + " Tuesday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"


                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "T3" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlDay3Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay3StartDate.Text) + "-" + CStr(txtDay3EndDate.Text) + " Wednesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "T4" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlDay4Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay4StartDate.Text) + "-" + CStr(txtDay4EndDate.Text) + " Thursday  </br> Course : " + Batch + " , Batch : " + Course + " ,Semester : " + Semester + ". </br>"

                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "T5" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlDay5Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay5StartDate.Text) + "-" + CStr(txtDay5EndDate.Text) + " Friday  </br> Course : " + Batch + " , Batch : " + Course + " ,Semester : " + Semester + ". </br>"

                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "T6" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlDay6Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay6StartDate.Text) + "-" + CStr(txtDay6EndDate.Text) + " Saturday  </br> Course : " + Batch + " , Batch : " + Course + " ,Semester : " + Semester + ". </br>"
                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "T7" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlDay7Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay7StartDate.Text) + "-" + CStr(txtDay7EndDate.Text) + " Sunday  </br> Course : " + Batch + " , Batch : " + Course + " ,Semester : " + Semester + ". </br>"

                        '                                    Exit Sub
                        '                                End If
                        '                            Else
                        '                                If Trim(split(0)) = "R1" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlResrc1.SelectedItem.ToString) + " is already allocated for" + CStr(txtDay1StartDate.Text) + "-" + CStr(txtDay1EndDate.Text) + " Monday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "R2" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()

                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlResrc2.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay2StartDate.Text) + "-" + CStr(txtDay2EndDate.Text) + " Tuesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "R3" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = "" + CStr(ddlResrc3.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay3StartDate.Text) + "-" + CStr(txtDay3EndDate.Text) + " Wednesday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"


                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "R4" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = " " + CStr(ddlResrc4.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay4StartDate.Text) + "-" + CStr(txtDay4EndDate.Text) + " Thursday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "R5" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = " " + CStr(ddlResrc5.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay5StartDate.Text) + "-" + CStr(txtDay5EndDate.Text) + " Friday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "R6" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    'DisplayGrid()
                        '                                    'clear()
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = " " + CStr(ddlResrc6.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay6StartDate.Text) + "-" + CStr(txtDay6EndDate.Text) + " Saturday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                                    Exit Sub
                        '                                End If
                        '                                If Trim(split(0)) = "R7" Then
                        '                                    Dim dt As New DataTable
                        '                                    'El.Id = ViewState("id")
                        '                                    El.BatchId = ddlBatchName.SelectedValue
                        '                                    El.SemId = ddlSemester.SelectedValue
                        '                                    El.WeekNo = ddlWeekNo.SelectedValue
                        '                                    dt = Bl.GetData(El)
                        '                                    GridView1.DataSource = dt
                        '                                    GridView1.DataBind()
                        '                                    GridView1.Enabled = False
                        '                                    msginfo1.Text = ""
                        '                                    msginfo.Text = " " + CStr(ddlResrc7.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay7StartDate.Text) + "-" + CStr(txtDay7EndDate.Text) + " Sunday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                                    Exit Sub
                        '                                End If
                        '                            End If
                        '                        End If
                        '                    Next
                        '                Else
                        'UPDATE:             Bl.UpdateRecord(El)
                        '                    BtnSave.Text = "ADD"
                        '                    BtnDetails.Text = "VIEW"
                        '                    GridView1.PageIndex = ViewState("PageIndex")
                        '                    DisplayGrid()
                        '                    lblmsg.Text = "Data Updated Successfully."
                        '                    msginfo.Text = ""
                        '                    msginfo1.Text = ""
                        '                    clear()
                        '                    clear1()
                        '                End If
                        '                    End If

                        'If BtnSave.Text = "ADD" Then
                        '    dt = Bl.GetDuplicatedata(El)
                        '    Dim COUNT As Integer
                        '    COUNT = 0
                        '    If dt.Rows.Count > 0 Then
                        '        For i As Integer = 0 To dt.Rows.Count - 1
                        '            Dim Batch As String
                        '            Dim Course As String
                        '            Dim Semester As String
                        '            Dim Week As Integer
                        '            Dim split As String()
                        '            Batch = dt.Rows(i).Item("Batch_No").ToString
                        '            Course = dt.Rows(i).Item("CourseName").ToString
                        '            Semester = dt.Rows(i).Item("SemName").ToString
                        '            Week = dt.Rows(i).Item("WeekNo").ToString
                        '            split = dt.Rows(i).Item("Duplicate").ToString.Split(":")

                        '            If split(1) = 0 Then
                        '                COUNT = COUNT + 1
                        '                If dt.Rows.Count = COUNT Then
                        '                    GoTo INSERT
                        '                End If
                        '            Else
                        '                If split(0).Contains("T") Then
                        '                    If Trim(split(0)) = "T1" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo.Text = "" + CStr(ddlDay1Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay1StartDate.Text) + "-" + CStr(txtDay1EndDate.Text) + " Monday </br> Course : " + Course + " , Batch : " + Batch + " ,Semester : " + Semester + ". </br>"
                        '                        msginfo1.Text = ""
                        '                        lblmsg.Text = ""

                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "T2" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo.Text = "" + CStr(ddlDay2Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay2StartDate.Text) + "-" + CStr(txtDay2EndDate.Text) + " Tuesday </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                        '                        msginfo1.Text = ""
                        '                        lblmsg.Text = ""

                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "T3" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo.Text = "" + CStr(ddlDay3Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay3StartDate.Text) + "-" + CStr(txtDay3EndDate.Text) + " Wednesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                        '                        msginfo1.Text = ""
                        '                        lblmsg.Text = ""

                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "T4" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo.Text = "" + CStr(ddlDay4Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay4StartDate.Text) + "-" + CStr(txtDay4EndDate.Text) + " Thursday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                        '                        msginfo1.Text = ""
                        '                        lblmsg.Text = ""

                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "T5" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = "" + CStr(ddlDay5Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay5StartDate.Text) + "-" + CStr(txtDay5EndDate.Text) + " Friday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                        lblmsg.Text = ""
                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "T6" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = "" + CStr(ddlDay6Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay6StartDate.Text) + "-" + CStr(txtDay6EndDate.Text) + " Saturday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                        '                        lblmsg.Text = ""

                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "T7" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = "" + CStr(ddlDay7Teacher.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay7StartDate.Text) + "-" + CStr(txtDay7EndDate.Text) + " Sunday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                        '                        lblmsg.Text = ""

                        '                        Exit Sub
                        '                    End If
                        '                Else
                        '                    If Trim(split(0)) = "R1" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = "" + CStr(ddlResrc1.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay1StartDate.Text) + "-" + CStr(txtDay1EndDate.Text) + " Monday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                        lblmsg.Text = ""
                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "R2" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = "" + CStr(ddlResrc2.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay2StartDate.Text) + "-" + CStr(txtDay2EndDate.Text) + " Tuesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                        lblmsg.Text = ""
                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "R3" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = "" + CStr(ddlResrc3.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay3StartDate.Text) + "-" + CStr(txtDay3EndDate.Text) + " Wednesday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                        lblmsg.Text = ""
                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "R4" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = " " + CStr(ddlResrc4.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay4StartDate.Text) + "-" + CStr(txtDay4EndDate.Text) + " Thursday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                        lblmsg.Text = ""
                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "R5" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = " " + CStr(ddlResrc5.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay5StartDate.Text) + "-" + CStr(txtDay5EndDate.Text) + " Friday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                        '                        lblmsg.Text = ""

                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "R6" Then
                        '                        DisplayGrid()
                        '                        'clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = " " + CStr(ddlResrc6.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay6StartDate.Text) + "-" + CStr(txtDay6EndDate.Text) + " Saturday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"

                        '                        lblmsg.Text = ""
                        '                        Exit Sub
                        '                    End If
                        '                    If Trim(split(0)) = "R7" Then
                        '                        DisplayGrid()
                        '                        ' clear()
                        '                        msginfo1.Text = ""
                        '                        msginfo.Text = " " + CStr(ddlResrc7.SelectedItem.ToString) + " is already allocated for " + CStr(txtDay7StartDate.Text) + "-" + CStr(txtDay7EndDate.Text) + " Sunday  </br> Course : " + Batch + " , Batch : " + Semester + " ,Semester : " + Course + ". </br>"
                        '                        lblmsg.Text = ""
                        '                        Exit Sub
                        '                    End If
                        '                End If
                        '            End If
                        '        Next
                        '    Else

                        'INSERT:         Bl.InsertRecord(El)
                        '                ViewState("PageIndex") = 0
                        '                GridView1.PageIndex = 0
                        '                DisplayGrid()
                        '                lblmsg.Text = "Data Saved Successfully."
                        '                msginfo1.Text = ""
                        '                msginfo.Text = ""
                        '                clear()
                        '                clear1()
                        '                GoTo Exit1
                        COUNT = COUNT + 1
                        'COUNT = dt.Rows.Count
                        El.WeekNo = ddlWeekNo.SelectedValue
                        Bl.InsertRecord(El)


                    Next


                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DisplayGrid1()
                    lblmsg.Text = "Data Saved Successfully."
                    msginfo1.Text = ""
                    msginfo.Text = ""
                    clear()
                    clear1()
                End If

                'Exit1:              End If

                'End If
            Catch ex As Exception
                msginfo.Text = "Enter Correct Data."
                lblmsg.Text = ""
                msginfo1.Text = ""
            End Try


        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
            msginfo1.Text = ""
        End If

    End Sub
    'Sub disp()
    '    For Each grid As GridViewRow In GridView1.Rows
    '        Dim a As Date
    '        Dim b As Date
    '        Dim name As String
    '        If CType(grid.FindControl("Label4"), Label).Text <> "" And CType(grid.FindControl("Label5"), Label).Text <> "" Then
    '            a = CType(grid.FindControl("Label4"), Label).Text
    '            b = CType(grid.FindControl("Label5"), Label).Text
    '            name = CType(grid.FindControl("Label3"), Label).Text

    '            If a <> CDate("1/1/1900") And b <> CDate("1/1/1900") Then
    '                If txtDay1StartDate.Text <> "" And txtDay1EndDate.Text <> "" Then
    '                    If txtDay1StartDate.Text <> a And txtDay1EndDate.Text <> b Then
    '                        If txtDay1StartDate.Text > a And txtDay1StartDate.Text < b Then
    '                            msginfo.Text = "" + name + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                        If txtDay1EndDate.Text < b And txtDay1EndDate.Text > a Then
    '                            msginfo.Text = "" + name + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        msginfo.Text = "" + name + "is already allocated for the same time."
    '                        lblmsg.Text = ""
    '                        Exit Sub
    '                    End If
    '                End If
    '            End If
    '        End If


    '        Dim c As Date
    '        Dim d As Date
    '        Dim name2 As String
    '        If CType(grid.FindControl("Label8"), Label).Text <> "" And CType(grid.FindControl("Label9"), Label).Text <> "" Then
    '            c = CType(grid.FindControl("Label8"), Label).Text
    '            d = CType(grid.FindControl("Label9"), Label).Text
    '            name2 = CType(grid.FindControl("Label7"), Label).Text

    '            If c <> CDate("1/1/1900") And d <> CDate("1/1/1900") Then
    '                If txtDay2StartDate.Text <> "" And txtDay2EndDate.Text <> "" Then
    '                    If txtDay2StartDate.Text <> c And txtDay2EndDate.Text <> d Then

    '                        If txtDay2StartDate.Text > c And txtDay2StartDate.Text < d Then
    '                            msginfo.Text = "" + name2 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                        If txtDay2EndDate.Text < b And txtDay2EndDate.Text > c Then
    '                            msginfo.Text = "" + name2 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        msginfo.Text = "" + name2 + "is already allocated for the same time."
    '                        lblmsg.Text = ""
    '                        Exit Sub
    '                    End If
    '                End If
    '            End If
    '        End If


    '        Dim g As Date
    '        Dim f As Date
    '        Dim name3 As String

    '        If CType(grid.FindControl("Label12"), Label).Text <> "" And CType(grid.FindControl("Label13"), Label).Text <> "" Then
    '            g = CType(grid.FindControl("Label12"), Label).Text
    '            f = CType(grid.FindControl("Label13"), Label).Text
    '            name3 = CType(grid.FindControl("Label11"), Label).Text

    '            If g <> CDate("1/1/1900") And f <> CDate("1/1/1900") Then
    '                If txtDay3StartDate.Text <> "" And txtDay3EndDate.Text <> "" Then
    '                    If txtDay3StartDate.Text <> g And txtDay3EndDate.Text <> f Then

    '                        If txtDay3StartDate.Text > g And txtDay3StartDate.Text < f Then
    '                            msginfo.Text = "" + name3 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                        If txtDay3EndDate.Text < f And txtDay3EndDate.Text > g Then
    '                            msginfo.Text = "" + name3 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        msginfo.Text = "" + name3 + "is already allocated for the same time."
    '                        lblmsg.Text = ""
    '                        Exit Sub
    '                    End If
    '                End If
    '            End If
    '        End If




    '        Dim h As Date
    '        Dim i As Date
    '        Dim name4 As String
    '        If CType(grid.FindControl("Label16"), Label).Text <> "" And CType(grid.FindControl("Label17"), Label).Text <> "" Then

    '            h = CType(grid.FindControl("Label16"), Label).Text
    '            i = CType(grid.FindControl("Label17"), Label).Text
    '            name4 = CType(grid.FindControl("Label15"), Label).Text

    '            If h <> CDate("1/1/1900") And i <> CDate("1/1/1900") Then
    '                If txtDay4StartDate.Text <> "" And txtDay4EndDate.Text <> "" Then
    '                    If txtDay4StartDate.Text <> h And txtDay4EndDate.Text <> i Then
    '                        If txtDay4StartDate.Text > h And txtDay4StartDate.Text < i Then
    '                            msginfo.Text = "" + name4 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                        If txtDay4EndDate.Text < i And txtDay4EndDate.Text > h Then
    '                            msginfo.Text = "" + name4 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        msginfo.Text = "" + name4 + "is already allocated for the same time."
    '                        lblmsg.Text = ""
    '                        Exit Sub
    '                    End If
    '                End If
    '            End If
    '        End If


    '        Dim j As Date
    '        Dim k As Date
    '        Dim name5 As String
    '        If CType(grid.FindControl("Label20"), Label).Text <> "" And CType(grid.FindControl("Label21"), Label).Text <> "" Then
    '            j = CType(grid.FindControl("Label20"), Label).Text
    '            k = CType(grid.FindControl("Label21"), Label).Text
    '            name5 = CType(grid.FindControl("Label19"), Label).Text

    '            If j <> CDate("1/1/1900") And k <> CDate("1/1/1900") Then
    '                If txtDay5StartDate.Text <> "" And txtDay5EndDate.Text <> "" Then
    '                    If txtDay5StartDate.Text <> j And txtDay5EndDate.Text <> k Then
    '                        If txtDay5StartDate.Text > j And txtDay5StartDate.Text < k Then
    '                            msginfo.Text = "" + name5 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                        If txtDay5EndDate.Text < k And txtDay5EndDate.Text > j Then
    '                            msginfo.Text = "" + name5 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        msginfo.Text = "" + name5 + "is already allocated for the same time."
    '                        lblmsg.Text = ""
    '                        Exit Sub
    '                    End If
    '                End If
    '            End If
    '        End If

    '        Dim l As Date
    '        Dim m As Date
    '        Dim name6 As String
    '        If CType(grid.FindControl("Label24"), Label).Text <> "" And CType(grid.FindControl("Label25"), Label).Text <> "" Then
    '            l = CType(grid.FindControl("Label24"), Label).Text
    '            m = CType(grid.FindControl("Label25"), Label).Text
    '            name6 = CType(grid.FindControl("Label23"), Label).Text

    '            If l <> CDate("1/1/1900") And m <> CDate("1/1/1900") Then
    '                If txtDay6StartDate.Text <> "" And txtDay6EndDate.Text <> "" Then
    '                    If txtDay6StartDate.Text <> l And txtDay6EndDate.Text <> m Then
    '                        If txtDay6StartDate.Text > l And txtDay6StartDate.Text < m Then
    '                            msginfo.Text = "" + name6 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                        If txtDay6EndDate.Text < m And txtDay6EndDate.Text > l Then
    '                            msginfo.Text = "" + name6 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        msginfo.Text = "" + name6 + "is already allocated for the same time."
    '                        lblmsg.Text = ""
    '                        Exit Sub
    '                    End If
    '                End If
    '            End If
    '        End If


    '        Dim n As Date
    '        Dim o As Date
    '        Dim name7 As String
    '        If CType(grid.FindControl("Label28"), Label).Text <> "" And CType(grid.FindControl("Label29"), Label).Text <> "" Then
    '            n = CType(grid.FindControl("Label28"), Label).Text
    '            o = CType(grid.FindControl("Label29"), Label).Text
    '            name7 = CType(grid.FindControl("Label27"), Label).Text

    '            If n <> CDate("1/1/1900") And o <> CDate("1/1/1900") Then
    '                If txtDay7StartDate.Text <> "" And txtDay7EndDate.Text <> "" Then
    '                    If txtDay7StartDate.Text <> n And txtDay7EndDate.Text <> o Then
    '                        If txtDay7StartDate.Text > n And txtDay7StartDate.Text < o Then
    '                            msginfo.Text = "" + name7 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                        If txtDay7EndDate.Text < o And txtDay7EndDate.Text > n Then
    '                            msginfo.Text = "" + name7 + "is already allocated for the same time."
    '                            lblmsg.Text = ""
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        msginfo.Text = "" + name7 + "is already allocated for the same time."
    '                        lblmsg.Text = ""
    '                        Exit Sub
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next
    'End Sub
    Sub clear()
        txtDay1StartDate.Text = ""
        txtDay2StartDate.Text = ""
        txtDay3StartDate.Text = ""
        txtDay3StartDate.Text = ""
        txtDay4StartDate.Text = ""
        txtDay5StartDate.Text = ""
        txtDay6StartDate.Text = ""
        txtDay7StartDate.Text = ""
        txtDay1EndDate.Text = ""
        txtDay2EndDate.Text = ""
        txtDay3EndDate.Text = ""
        txtDay4EndDate.Text = ""
        txtDay5EndDate.Text = ""
        txtDay6EndDate.Text = ""
        txtDay7EndDate.Text = ""
        txtPeriod.Text = ""
        txtDay1Remarks.Text = ""
        txtDay2Remarks.Text = ""
        txtDay3Remarks.Text = ""
        txtDay4Remarks.Text = ""
        txtDay5Remarks.Text = ""
        txtDay6Remarks.Text = ""
        txtDay7Remarks.Text = ""

    End Sub
    Sub clear1()
        ddlDay1Subject.SelectedValue = 0
        ddlDay2Subject.SelectedValue = 0
        ddlDay3Subject.SelectedValue = 0
        ddlDay4Subject.SelectedValue = 0
        ddlDay5Subject.SelectedValue = 0
        ddlDay6Subject.SelectedValue = 0
        ddlDay7Subject.SelectedValue = 0

        ddlDay1Teacher.SelectedValue = 0
        ddlDay2Teacher.SelectedValue = 0
        ddlDay3Teacher.SelectedValue = 0
        ddlDay4Teacher.SelectedValue = 0
        ddlDay5Teacher.SelectedValue = 0
        ddlDay6Teacher.SelectedValue = 0
        ddlDay7Teacher.SelectedValue = 0
        ddlResrc1.SelectedValue = 0
        ddlResrc2.SelectedValue = 0
        ddlResrc3.SelectedValue = 0
        ddlResrc4.SelectedValue = 0
        ddlResrc5.SelectedValue = 0
        ddlResrc6.SelectedValue = 0
        ddlResrc7.SelectedValue = 0



    End Sub

    Sub DisplayGrid()
        LinkButton1.Focus()
        El.Id = 0
        El.BatchId = ddlBatchName.SelectedValue
        El.SemId = ddlSemester.SelectedValue
        El.WeekNo = ddlWeekNo.SelectedValue
        dt = Bl.GetData(El)

        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            lblmsg.Text = ""
            msginfo.Text = ""
            msginfo1.Text = "No records to display."
        Else
            msginfo1.Text = ""
            msginfo.Text = ""
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
        End If
    End Sub
    Sub DisplayGrid1()
        LinkButton1.Focus()
        El.Id = 0
        'El.CourseId = ddlCourseName.SelectedValue
        El.BatchId = ddlBatchName.SelectedValue
        El.SemId = ddlSemester.SelectedValue
        El.WeekNo = ddlWeekNo.SelectedValue
        dt = Bl.GetData(El)

        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            lblmsg.Text = ""
            msginfo.Text = ""
            msginfo1.Text = "No records to display."
        Else
            msginfo1.Text = ""
            msginfo.Text = ""
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        'clear()
        ddlCourseName.Enabled = True
        ddlBatchName.Enabled = True
        ddlSemester.Enabled = True
        ddlWeekNo.Enabled = True
        'msginfo1.Text = ""
        If (ddlCourseName.SelectedValue = 0 Or ddlBatchName.SelectedValue = 0 Or ddlSemester.SelectedValue = 0) Then
            msginfo.Text = " Please Select All the mandatory fields."
            msginfo1.Text = ""
            lblmsg.Text = ""
        Else

            lblmsg.Text = ""
            msginfo.Text = ""
            If BtnDetails.Text <> "BACK" Then
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                DisplayGrid()
                GridView1.Visible = True
            Else
                clear()
                BtnDetails.Text = "VIEW"
                BtnSave.Text = "ADD"
                GridView1.PageIndex = ViewState("PageIndex")
                DisplayGrid()
            End If
        End If
    End Sub

    Protected Sub GridView1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Load

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGrid()
    End Sub


    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ddlCourseName.Enabled = True
            ddlBatchName.Enabled = True
            ddlSemester.Enabled = True
            ddlWeekNo.Enabled = True
            El.Id = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("TTID"), HiddenField).Value
            If Bl.DeleteRecord(El.Id) Then
                ddlCourseName.Focus()
                GridView1.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                msginfo1.Text = ""
                lblmsg.Text = "Data Deleted Successfully."
                msginfo.Text = ""
                GridView1.Enabled = True
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            msginfo1.Text = ""
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        ddlCourseName.Enabled = False
        ddlBatchName.Enabled = False
        ddlSemester.Enabled = False
        ddlWeekNo.Enabled = False
        lblmsg.Text = ""
        msginfo.Text = ""

        txtPeriod.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        Try
            ddlDay1Subject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("SubId1"), HiddenField).Value
        Catch ex As ArgumentException
            ddlDay1Subject.SelectedValue = 0
        End Try
        Try
            ddlDay2Subject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("SubId2"), HiddenField).Value
        Catch ex As ArgumentException
            ddlDay2Subject.SelectedValue = 0
        End Try
        Try
            ddlDay3Subject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("SubId3"), HiddenField).Value
        Catch ex As ArgumentException
            ddlDay3Subject.SelectedValue = 0
        End Try
        Try
            ddlDay4Subject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("SubId4"), HiddenField).Value
        Catch ex As ArgumentException
            ddlDay4Subject.SelectedValue = 0
        End Try
        Try
            ddlDay5Subject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("SubId5"), HiddenField).Value
        Catch ex As ArgumentException
            ddlDay5Subject.SelectedValue = 0
        End Try
        Try
            ddlDay6Subject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("SubId6"), HiddenField).Value
        Catch ex As ArgumentException
            ddlDay6Subject.SelectedValue = 0
        End Try
        Try
            ddlDay7Subject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("SubId7"), HiddenField).Value
        Catch ex As ArgumentException
            ddlDay7Subject.SelectedValue = 0
        End Try


        Try
            ddlDay1Teacher.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("EmpId1"), HiddenField).Value
        Catch ex As ArgumentException
            ddlDay1Teacher.SelectedValue = 0
        End Try

        Try
            ddlDay2Teacher.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("EmpId2"), HiddenField).Value
        Catch ex As Exception
            ddlDay2Teacher.SelectedValue = 0
        End Try
        Try
            ddlDay3Teacher.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("EmpId3"), HiddenField).Value
        Catch ex As Exception
            ddlDay3Teacher.SelectedValue = 0
        End Try

        Try

            ddlDay4Teacher.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("EmpId4"), HiddenField).Value
        Catch ex As Exception
            ddlDay4Teacher.SelectedValue = 0
        End Try
        Try
            ddlDay5Teacher.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("EmpId5"), HiddenField).Value
        Catch ex As Exception
            ddlDay5Teacher.SelectedValue = 0
        End Try
        Try
            ddlDay6Teacher.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("EmpId6"), HiddenField).Value
        Catch ex As Exception
            ddlDay6Teacher.SelectedValue = 0
        End Try
        Try
            ddlDay7Teacher.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("EmpId7"), HiddenField).Value
        Catch ex As Exception
            ddlDay7Teacher.SelectedValue = 0
        End Try


        Try
            ddlResrc1.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Rid1"), HiddenField).Value
        Catch ex As ArgumentException
            ddlResrc1.SelectedValue = 0
        End Try
        Try
            ddlResrc2.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Rid2"), HiddenField).Value
        Catch ex As ArgumentException

            ddlResrc2.SelectedValue = 0
        End Try
        Try
            ddlResrc3.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Rid3"), HiddenField).Value
        Catch ex As ArgumentException
            ddlResrc3.SelectedValue = 0
        End Try
        Try
            ddlResrc4.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Rid4"), HiddenField).Value
        Catch ex As ArgumentException
            ddlResrc4.SelectedValue = 0
        End Try
        Try
            ddlResrc5.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Rid5"), HiddenField).Value
        Catch ex As ArgumentException
            ddlResrc5.SelectedValue = 0
        End Try
        Try
            ddlResrc6.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Rid6"), HiddenField).Value
        Catch ex As ArgumentException
            ddlResrc6.SelectedValue = 0
        End Try
        Try
            ddlResrc7.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Rid7"), HiddenField).Value
        Catch ex As ArgumentException
            ddlResrc7.SelectedValue = 0
        End Try

        txtDay1Remarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks1"), Label).Text
        txtDay2Remarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks2"), Label).Text
        txtDay3Remarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks3"), Label).Text
        txtDay4Remarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks4"), Label).Text
        txtDay5Remarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks5"), Label).Text
        txtDay6Remarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks6"), Label).Text
        txtDay7Remarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks7"), Label).Text

        txtDay1StartDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        If (txtDay1StartDate.Text = "00:00:00.000") Then
            txtDay1StartDate.Text = ""
        End If
        txtDay2StartDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label8"), Label).Text
        If (txtDay2StartDate.Text = "00:00:00.000") Then
            txtDay2StartDate.Text = ""
        End If
        txtDay3StartDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label12"), Label).Text
        If (txtDay3StartDate.Text = "00:00:00.000") Then
            txtDay3StartDate.Text = ""
        End If
        txtDay4StartDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label16"), Label).Text
        If (txtDay4StartDate.Text = "00:00:00.000") Then
            txtDay4StartDate.Text = ""
        End If
        txtDay5StartDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label20"), Label).Text
        If (txtDay5StartDate.Text = "00:00:00.000") Then
            txtDay5StartDate.Text = ""
        End If
        txtDay6StartDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label24"), Label).Text
        If (txtDay6StartDate.Text = "00:00:00.000") Then
            txtDay6StartDate.Text = ""
        End If
        txtDay7StartDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label28"), Label).Text
        If (txtDay7StartDate.Text = "00:00:00.000") Then
            txtDay7StartDate.Text = ""
        End If

        txtDay1EndDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        If (txtDay1EndDate.Text = "00:00:00.000") Then
            txtDay1EndDate.Text = ""
        End If
        txtDay2EndDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label9"), Label).Text
        If (txtDay2EndDate.Text = "00:00:00.000") Then
            txtDay2EndDate.Text = ""
        End If
        txtDay3EndDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label13"), Label).Text
        If (txtDay3EndDate.Text = "00:00:00.000") Then
            txtDay3EndDate.Text = ""
        End If
        txtDay4EndDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label17"), Label).Text
        If (txtDay4EndDate.Text = "00:00:00.000") Then
            txtDay4EndDate.Text = ""
        End If
        txtDay5EndDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label21"), Label).Text
        If (txtDay5EndDate.Text = "00:00:00.000") Then
            txtDay5EndDate.Text = ""
        End If
        txtDay6EndDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label25"), Label).Text
        If (txtDay6EndDate.Text = "00:00:00.000") Then
            txtDay6EndDate.Text = ""
        End If
        txtDay7EndDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label29"), Label).Text
        If (txtDay7EndDate.Text = "00:00:00.000") Then
            txtDay7EndDate.Text = ""
        End If

        ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("TTID"), HiddenField).Value
        BtnSave.Text = "UPDATE"
        BtnDetails.Text = "BACK"
        Dim dt As New DataTable
        El.Id = ViewState("id")
        El.BatchId = ddlBatchName.SelectedValue
        El.SemId = ddlSemester.SelectedValue
        El.WeekNo = ddlWeekNo.SelectedValue
        dt = Bl.GetData(El)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'msginfo1.Text = ""
        'End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlCourseName.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub ddlCourseName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseName.SelectedIndexChanged
        GridView1.Visible = False
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub

    Protected Sub ddlBatchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.SelectedIndexChanged
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub

    'Protected Sub ddlSemester_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.PreRender
    '    If ddlSemester.Items.Count > 0 Then
    '        If ddlSemester.Items(0).Text <> "Select" Then
    '            ddlSemester.Items.Insert(0, "Select")
    '        End If
    '    Else
    '        ddlSemester.Items.Insert(0, "Select")
    '    End If
    'End Sub


    Protected Sub ddlBatchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.TextChanged
        ddlBatchName.Focus()

    End Sub

    Protected Sub ddlCourseName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseName.TextChanged
        ddlCourseName.Focus()
        lblmsg.Text = ""
        msginfo.Text = ""
        msginfo1.Text = ""

    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged

        lblmsg.Text = ""
        msginfo.Text = ""
        msginfo1.Text = ""
        If ddlSemester.SelectedValue = "0" Then
            txtWeek.Text = ""
        Else

            txtWeek.Enabled = False
            El.CourseId = ddlCourseName.SelectedValue()
            El.SemId = ddlSemester.SelectedValue
            dt = TimeTableDl.GetWeekAutoFill(El)
            If dt.Rows.Count > 0 Then

                If dt.Rows(0).Item("Weeks").ToString = "" Then
                    txtWeek.Text = ""
                Else
                    txtWeek.Text = (dt.Rows(0).Item("Weeks"))
                End If
            End If
        End If

    End Sub

    Protected Sub ddlSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.TextChanged
        ddlSemester.Focus()
        'DisplayGrid()
        'GridView1.Visible = True
    End Sub
    Protected Sub ddlWeekNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWeekNo.SelectedIndexChanged
        lblmsg.Text = ""
        msginfo.Text = ""
        msginfo1.Text = ""
    End Sub
    Protected Sub ddlWeekNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWeekNo.TextChanged
        ddlWeekNo.Focus()
        msginfo1.Text = ""
        'DisplayGrid()
        'GridView1.Visible = True
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting

        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim idd As New Integer
        El.Id = 0
        El.BatchId = ddlBatchName.SelectedValue
        El.SemId = ddlSemester.SelectedValue
        El.WeekNo = ddlWeekNo.SelectedValue
        dt = Bl.GetData(El)



        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        ViewState("SortExpression") = e.SortExpression
        ViewState("sortingDirection") = sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
    End Sub

    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = value
        End Set
    End Property


End Class
