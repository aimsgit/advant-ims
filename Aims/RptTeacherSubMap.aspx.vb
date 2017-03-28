
Partial Class RptTeacherSubMap
    Inherits BasePage
    Dim DL As New DLRptSubTeacherMAp


    Protected Sub LoadTeacher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoadTeacher.Click
        Dim Teachet1 As String
        Dim NIC, PAN, PASSNo As String
        Teachet1 = txtTeacher.Text
        Dim dt As New DataTable
        dt = DL.GetTeacher(Teachet1)
        ddlTeacher.Items.Clear()
        If dt.Rows.Count > 0 Then
            ddlTeacher.DataSource = dt
            ddlTeacher.DataBind()
            lblMsg.Text = ""
        Else
            lblMsg.Text = "No Records To Display."
        End If

    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim str As String = ""
            Dim id As String = ""
            Dim Teacher1 As String
            Dim NIC, PAN, PASSNo As String
            Teacher1 = ddlTeacher.SelectedItem.Text
            Dim dt As New DataTable
            dt = DL.GetTeacherid(Teacher1)
            id = Trim(ddlTeacher.SelectedValue)
            Dim Rbid As Integer = RBReport.SelectedValue
            If RBReport.SelectedValue = 1 Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(0).Item("NICNO").ToString <> "" Then
                            NIC = dt.Rows(0).Item("NICNO").ToString
                            PAN = ""
                            PASSNo = ""
                        End If
                    Next
                End If


            ElseIf RBReport.SelectedValue = 2 Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(i).Item("PanNo").ToString <> "" Then
                            PAN = dt.Rows(i).Item("PanNo").ToString
                            NIC = ""
                            PASSNo = ""
                        End If
                    Next
                End If

            Else
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(0).Item("PassportNo").ToString <> "" Then
                            PASSNo = dt.Rows(0).Item("PassportNo").ToString
                            NIC = ""
                            PAN = ""
                        End If
                    Next
                End If
            End If

            If id <> "" Then
                Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "RptTeacherSubV.aspx?" & QueryStr.Querystring() & "&id=" & id & "&NIC=" & NIC & "&PAN=" & PAN & "&PASSNo=" & PASSNo & "&Rbid=" & Rbid
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                lblMsg.Text = ""
            Else
                lblMsg.Text = "Select atleast one Teacher."
            End If

        Catch ex As Exception
            lblMsg.Text = "Select atleast one Teacher."
        End Try

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

End Class
