﻿
Partial Class Rpt_ProffessionTax
    Inherits BasePage

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Dim year As Integer
            Dim month As String

            If ddlYear.SelectedValue = 0 Then
                msginfo.Text = "Please select Year."
            Else
                year = ddlYear.SelectedItem.Text
            End If
            If ddlMonth.SelectedItem.Text = "Select" Then
                msginfo.Text = "Please select Month."
            Else
                month = ddlMonth.SelectedItem.Text
            End If
            'If Txttodate.Text = "" Then
            '    TDate = "12/31/3000"
            'Else
            '    TDate = Txttodate.Text
            'End If

            If ddlYear.SelectedValue <> 0 And ddlMonth.SelectedItem.Text = "Select" Then

                msginfo.Text = "Please enter all Mandatory Fields"
            ElseIf ddlYear.SelectedValue = 0 And ddlMonth.SelectedItem.Text <> "Select" Then
                msginfo.Text = "Please enter all Mandatory Fields"
            Else
                Dim qrystring As String = "Rpt_ProffessionTaxV.aspx?" & "&year=" & year & "&month=" & month
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                msginfo.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = "Please enter correct data."
        End Try

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
 
End Class