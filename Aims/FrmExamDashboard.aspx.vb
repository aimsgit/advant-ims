
Partial Class FrmExamDashboard
    Inherits BasePage
    Dim DL As New DLExamDashBoard
    Dim dt As New DataTable


    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        panel2.Visible = True
        Dim ExamBatch As Integer = ddlExamBatch.SelectedValue
        dt = DL.GetExamBatchDetails(ExamBatch)
        If (dt.Rows.Count > 0) Then
            lblexamcal1.Text = dt.Rows(0).Item("ExamCalendar").ToString
            If lblexamcal1.Text = "N" Then
                lblexamcal1.ForeColor = Drawing.Color.Red
            Else
                lblexamcal1.ForeColor = Drawing.Color.Green
            End If

            lblassignResource1.Text = dt.Rows(0).Item("AssignResources").ToString
            If lblassignResource1.Text = "N" Then
                lblassignResource1.ForeColor = Drawing.Color.Red
            Else
                lblassignResource1.ForeColor = Drawing.Color.Green
            End If
            lblRegStu1.Text = dt.Rows(0).Item("RegisterStudent").ToString
            If lblRegStu1.Text = "N" Then
                lblRegStu1.ForeColor = Drawing.Color.Red
            Else
                lblRegStu1.ForeColor = Drawing.Color.Green
            End If
            lblMapStu1.Text = dt.Rows(0).Item("MapStudenttoCenter").ToString
            If lblMapStu1.Text = "N" Then
                lblMapStu1.ForeColor = Drawing.Color.Red
            Else
                lblMapStu1.ForeColor = Drawing.Color.Green
            End If
            lblMapstuHall1.Text = dt.Rows(0).Item("MapStudenttoHall").ToString
            If lblMapstuHall1.Text = "N" Then
                lblMapstuHall1.ForeColor = Drawing.Color.Red
            Else
                lblMapstuHall1.ForeColor = Drawing.Color.Green
            End If
            lblGenHall1.Text = dt.Rows(0).Item("GenerateHallTicket").ToString
            If lblGenHall1.Text = "N" Then
                lblGenHall1.ForeColor = Drawing.Color.Red
            Else
                lblGenHall1.ForeColor = Drawing.Color.Green
            End If
            lblevalpaper1.Text = dt.Rows(0).Item("EvaluationofPaper").ToString
            If lblevalpaper1.Text = "N" Then
                lblevalpaper1.ForeColor = Drawing.Color.Red
            Else
                lblevalpaper1.ForeColor = Drawing.Color.Green
            End If
            lblPubMark1.Text = dt.Rows(0).Item("PublishMarks").ToString
            If lblPubMark1.Text = "N" Then
                lblPubMark1.ForeColor = Drawing.Color.Red
            Else
                lblPubMark1.ForeColor = Drawing.Color.Green
            End If
        Else

            lblerrmsg.Text = "No Records Display."
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        panel2.Visible = False
    End Sub
End Class
