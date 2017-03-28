Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Partial Class frmStudSubjectForExam
    Inherits BasePage
    Dim DL As New DLStudSubjectForExam
    Dim ExamBatchId, exambatch, batch, stdid As Integer
    Dim subject As String
    Dim dt, dt1, dt2, dt3 As New DataTable
    Protected Sub btnGen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGen.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                'Dim ExamBatchId, exambatch, batch, stdid As Integer
                'Dim subject As String

                If ddlExamBatch.SelectedItem.Text = "Select" Then
                    lblMsg.Visible = False
                    lblErrorMsg.Visible = True
                    lblErrorMsg.Text = "Please select the Exam Batch to generate the records."
                    Exit Sub
                Else
                    ExamBatchId = ddlExamBatch.SelectedValue
                End If

                'Dim roweffected As Integer = DLStudSubjectForExam.insertStudSubforExam(ExamBatchId)
                'If roweffected > 0 Then

                'lblErrorMsg.Text = ""
                'lblMsg.Text = roweffected.ToString + " student(s) subject mapped."
                dt = DLStudSubjectForExam.insertStudSubforExam(ExamBatchId)
                Dim Count As Integer

                If dt.Rows.Count > 0 Then
                    Count = dt.Rows.Count
                    For i As Integer = 0 To dt.Rows.Count - 1
                        exambatch = dt.Rows(i).Item("exambatchid")
                        batch = dt.Rows(i).Item("batchid")
                        stdid = dt.Rows(i).Item("std_id")
                        subject = Trim(dt.Rows(i).Item("subject"))
                        dt3 = DLStudSubjectForExam.CheckDuplicate(exambatch, batch, stdid, subject.Substring(0, subject.Length - 1))
                        If dt3.Rows.Count > 0 Then
                            lblErrorMsg.Text = "Record(s) Already Exists."
                            lblMsg.Text = ""
                            Exit Sub
                        End If
                        DLStudSubjectForExam.Insert(exambatch, batch, stdid, subject.Substring(0, subject.Length - 1))
                    Next

                    'Dim roweffected As Integer = DLStudSubjectForExam.Insert(exambatch, batch, stdid, subject)
                    'If Count > 0 Then

                    lblErrorMsg.Text = ""
                    lblMsg.Text = Count.ToString + " student(s) subject mapped."
                    'End If

                Else
                    lblErrorMsg.Text = "No Record(s)to be mapped."

                End If
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
                lblMsg.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct data."
        End Try

    End Sub

    Protected Sub btnLockunlk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockunlk.Click
        Dim Exambatch As Integer
        Exambatch = ddlExamBatch.SelectedValue
        If ddlExamBatch.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select the Exam Batch to Lock/Unlock the records."
        
        Else
            dt2 = DLStudSubjectForExam.CountRecords(Exambatch)

            If dt2.Rows.Count > 0 Then

                ControlsPanel.Visible = False
                PasswordPanel.Visible = True
                txtPassword.Focus()
                lblpassError.Text = ""
                Image1.Visible = False
                Image2.Visible = False
            Else
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "No Records to Lock/Unlock."
                Image1.Visible = True
                Image2.Visible = True

            End If
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            Dim exambatch As Integer
            exambatch = ddlExamBatch.SelectedValue

            '1
            If Trim(DLStudSubjectForExam.RecordsGen(exambatch).Tables(0).Rows(0).Item(0)) = "N" Then
                Dim roweffected As Integer = DLStudSubjectForExam.LockGenerateSubject(exambatch)
                If roweffected > 0 Then
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    lblErrorMsg.Visible = False
                    lblMsg.Visible = True
                    lblMsg.Text = roweffected.ToString + " record(s) Locked."
                    'lblMsg.Text = " record(s) Locked."
                    'GridView1.Enabled = False
                    Image1.Visible = True
                    Image2.Visible = True
                End If
                '1
            Else

                Dim role As String
                role = Session("UserRole")
                'Dim checkUnlock As String
                ' dt1 = DLNew_StudentMarks.CheckUnlockStatus(role)
                '2
                If Session("SecurityCheck") = "Security Check" Then

                    dt = DLStudSubjectForExam.UnlockSubject(role)
                    '3
                    If dt.Rows.Count < 1 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "You don't have Unlock Permission."
                        lblMsg.Visible = False
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        'GridView1.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    Else
                        Check = dt.Rows(0)("Result").ToString.Trim

                        'check = dt.Rows(0)("Result").ToString.Trim
                        '4
                        If Check = "" Then
                            lblErrorMsg.Visible = True
                            lblErrorMsg.Text = "You don't have Unlock Permission."
                            lblMsg.Visible = False
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            'GridView1.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                            '4
                        Else
                            Dim roweffected As Integer = DLStudSubjectForExam.UnLockGenerateSubject(exambatch)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                lblErrorMsg.Visible = False
                                lblMsg.Visible = True
                                'lblMsg.Text = " record(s) Unlocked."
                                lblMsg.Text = roweffected.ToString + " record(s) Unlocked."
                                'GridView1.Enabled = True
                                Image1.Visible = True
                                Image2.Visible = True
                            End If
                            '4
                        End If
                        '3
                    End If
                    '2
                Else
                    Dim roweffected As Integer = DLStudSubjectForExam.UnLockGenerateSubject(exambatch)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblErrorMsg.Visible = False
                        lblMsg.Visible = True
                        lblMsg.Text = roweffected.ToString + " record(s) Unlocked."
                        'lblMsg.Text = " record(s) Unlocked."
                        'GridView1.Enabled = True
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                    '2
                End If
                '1
            End If
        ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
            ControlsPanel.Visible = True
            PasswordPanel.Visible = False
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Enter correct password."
            Image1.Visible = True
            Image2.Visible = True
            lblMsg.Text = ""
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim exambatch As Integer


        If ddlExamBatch.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select the Exam Batch to Clear the records."
            Exit Sub
        Else
            exambatch = ddlExamBatch.SelectedValue
        End If

        dt = DLStudSubjectForExam.CheckSubjectMappedDetails(exambatch)
        If dt.Rows.Count = 0 Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "No records to Clear."
            Exit Sub
        End If

        dt2 = DLStudSubjectForExam.CheckSubjectLockStatus(exambatch)
        If dt2.Rows.Count > 0 Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please unlock the records to Clear."

        Else

            If ddlExamBatch.SelectedItem.Text = "Select" Then
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "Please select the Exam Batch to clear mapped subject."
            Else

                DLStudSubjectForExam.ClearGenerateSubjectMapped(exambatch)
                lblMsg.Visible = True
                lblErrorMsg.Visible = False
                lblMsg.Text = "Mapped subject cleared successfully."
                'GridView1.Visible = False
            End If

        End If
    End Sub
End Class
