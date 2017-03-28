
Partial Class Rpt_EmployeeWiseLoan
    Inherits BasePage

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

            Dim EmpId As Integer
            Dim FDate As DateTime
            Dim TDate As DateTime

            'If ddlEmpName.SelectedValue = "" Then
            '    msginfo.Text = "Please select Employee name."
            'Else
            '    EmpId = ddlEmpName.SelectedValue
            'End If

            EmpId = ddlEmpName.SelectedValue
            If Txtfdate.Text = "" Then
                FDate = "01/01/1900"
            Else
                FDate = Txtfdate.Text
            End If
            If Txttodate.Text = "" Then
                TDate = "12/31/3000"
            Else
                TDate = Txttodate.Text
            End If

            If ddlEmpName.SelectedValue = "" Then

                msginfo.Text = "Please enter all Mandatory Fields"
            Else
                Dim qrystring As String = "Rpt_EmpWiseLoanMasterStatementV.aspx?" & "&EmpId=" & EmpId & "&FDate=" & FDate & "&TDate=" & TDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                msginfo.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = "Please enter correct data."
        End Try

    End Sub

    Protected Sub Txttodate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txttodate.Load
        Txttodate.Text = Format(Today.Date(), "dd-MMM-yyyy")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

End Class
