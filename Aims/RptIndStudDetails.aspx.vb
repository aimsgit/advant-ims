
Partial Class RptIndStudDetails
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim BrID As String
        Dim AID As Integer = DDLA_Year.SelectedValue
        Dim CID As Integer = DDLCourse.SelectedValue
        Dim BID As Integer = DDLBatch.SelectedValue
        Dim country As String = DDLCountry.SelectedItem.Text
        Dim Student As Integer = ddlStudent.SelectedValue
        BrID = DDLBranch.SelectedValue
        If DDLBranch.SelectedItem.Value = "0" Or DDLA_Year.SelectedItem.Value = "0" Or DDLCourse.SelectedItem.Value = "0" Or DDLBatch.SelectedItem.Value = "0" Then
            msginfo.Visible = True
            msginfo.Text = " Select All Mandatory Fields."
            DDLBranch.Focus()
        Else
            Dim qrystring As String = "RptIndStudDetailsV.aspx?" & QueryStr.Querystring() & "&BrID=" & BrID & "&AID=" & AID & "&CID=" & CID & "&BID=" & BID & "&country=" & country & "&Student=" & Student
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub DDLBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLBranch.TextChanged
        DDLBranch.Focus()
    End Sub

    Protected Sub DDLA_Year_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLA_Year.TextChanged
        DDLA_Year.Focus()
    End Sub

    Protected Sub DDLCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLCourse.TextChanged
        DDLCourse.Focus()
    End Sub

    Protected Sub DDLBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLBatch.TextChanged
        DDLBatch.Focus()
    End Sub

    Protected Sub DDLCountry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLCountry.TextChanged
        DDLCountry.Focus()
    End Sub

    Protected Sub ddlStudent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStudent.TextChanged
        ddlStudent.Focus()
    End Sub
End Class
