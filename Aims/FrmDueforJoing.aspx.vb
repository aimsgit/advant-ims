
Partial Class FrmDueforJoing
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Criteria As String
        Dim Based1 As String
        'Dim Cri As String
        If txtcriteria.Text = "" Then
            Criteria = 0
            'Cri = ""
        Else
            Criteria = txtcriteria.Text
            'Cri = txtcriteria.Text
        End If
        Based1 = Ddlbased.SelectedItem.ToString
        'If Ddlbased.SelectedItem.ToString = "I" Then
        '    txtcriteria.Enabled = True
        'Else

        '    txtcriteria.Enabled = False
        'End If
        'If Ddlbased.SelectedItem.ToString = "J" Then
        '    txtcriteria.Enabled = True
        'Else
        '    txtcriteria.Enabled = False
        'End If
        Try
            'Dim BasedType As String
            'BasedType = Ddlbased.SelectedValue()
            Dim qrystring As String = "Rpt_DueForJoing.aspx?" & QueryStr.Querystring() & "&Months=" & Ddlmonth.SelectedValue & "&Year=" & ddlYear.SelectedItem.Text & "&Based=" & Ddlbased.SelectedValue & "&Month=" & Ddlmonth.SelectedItem.Text & "&Criteria=" & Criteria & "&Based1=" & Based1
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            lblRed.Text = "Enter correct Data."
            lblGreen.Text = ""
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        If Ddlbased.SelectedValue = "I" Or Ddlbased.SelectedValue = "J" Then
            txtcriteria.Enabled = True
        Else

            txtcriteria.Enabled = False
        End If
        'If Ddlbased.SelectedItem.ToString = "J" Then
        '    txtcriteria.Enabled = True
        'Else
        '    txtcriteria.Enabled = False
        'End If
        'End If
    End Sub

    Protected Sub Ddlbased_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ddlbased.SelectedIndexChanged
        txtcriteria.Text = ""
        If Ddlbased.SelectedValue = "I" Or Ddlbased.SelectedValue = "J" Then
            txtcriteria.Enabled = True
        Else

            txtcriteria.Enabled = False
        End If
        'If Ddlbased.SelectedItem.ToString = "J" Then
        '    txtcriteria.Enabled = True
        'Else
        '    txtcriteria.Enabled = False
        'End If
    End Sub
End Class

