
Partial Class RptDeptWiseConsolidatedFeedback
    Inherits BasePage
    Dim dt As New DataTable
    Dim dl As New RptDeptWiseConsolidatedFeedbackScore
    Dim Batch As String = ""
    Dim id1 As String = ""
    Protected Sub ListBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBatch.SelectedIndexChanged

        Dim str As String = ""
        Dim id As String = ""
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ListBatch.Items.Count - 1
        For Each items In ListBatch.Items
            If (ListBatch.Items(i).Selected = True) Then
                str = ListBatch.Items(i).Value
                Batch = str + "," + Batch
            End If
            i = i + 1
        Next
        dt = dl.SemesterCombo1(Batch)
        ddlSem1.DataSource = dt
        ddlSem1.DataBind()
    End Sub
    Sub GetBatchid()
        Dim str As String = ""
        Dim str1 As String = ""

        Dim id2 As String = ""
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ListBatch.Items.Count - 1

        If ListBatch.Items.Count <> 0 Then
            For Each items In ListBatch.Items
                If (ListBatch.Items(i).Selected = True) Then
                    Str = ListBatch.Items(i).Value
                    'str1 = ListBatch.Items(i).Text
                    id1 = str + "," + id1
                    'id2 = str1 + " ,  " + id2
                End If
                i = i + 1
            Next
        End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim QS As String
            Dim CourseId As Integer
            'Dim BatchId As String
            Dim SemsterId As Integer
            Dim FacultyId As Integer
            Dim id2 As String = ""
            lblmsg.Text = ""

         
            CourseId = ddlcourse.SelectedValue
            GetBatchid()
            Dim BatchId As String = id1
            If (ListBatch.SelectedValue = "" Or "0") Then
                lblErrorMsg.Text = "Batch field is Mandatory."
                Exit Sub
            End If

            'Dim BatchName As String = id2
            'If ListBatch.SelectedValue = "" Then
            '    BatchId = 0
            'Else
            '    BatchId = ListBatch.SelectedValue
            'End If
            SemsterId = ddlSem1.SelectedValue
            If ddlfaculty.SelectedValue = "" Then
                FacultyId = 0
            Else
                FacultyId = ddlfaculty.SelectedValue
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptDeptWiseConsolidatedFeedbackV.aspx?" & QueryStr.Querystring() & "&CourseId=" & CourseId & "&BatchId=" & BatchId & "&SemsterId=" & SemsterId & "&FacultyId=" & FacultyId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct data."
        End Try

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

End Class
