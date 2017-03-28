
Partial Class Mfg_Rpt_SEPerformance
    Inherits BasePage

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsPostBack Then
        '    If DDlBuyer.SelectedValue = 0 Then
        '      
        '    Else
        '        
        '    End If
        'End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim QS As String
        Dim SE_ID As Integer
        Dim StartDate As Date
        Dim EndDate As Date
        Try
            SE_ID = DdlSE.SelectedValue
            If txtStartDate.Text = "" Then
                StartDate = "1/1/1900"
            Else
                StartDate = txtStartDate.Text
            End If
            If txtEndDate.Text = "" Then
                EndDate = "1/1/3000"
            Else
                EndDate = txtEndDate.Text
            End If
            If (StartDate > EndDate) Then
                lblErrorMsg1.Text = "Start Date Should be less than End Date."
                txtStartDate.Focus()
                Exit Sub
            End If

            QS = Request.QueryString.Get("QS")
            Dim qrystring As String = "Mfg_Rpt_SEPerformanceV.aspx?" & QueryStr.Querystring() & "&SE_ID=" & SE_ID & "&StartDate=" & StartDate & "&EndDate=" & EndDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception

        End Try
    End Sub
End Class
