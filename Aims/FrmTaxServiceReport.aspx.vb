Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class FrmTaxServiceReport
    Inherits BasePage


    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim Fromyear As Integer
            Dim Toyear As Integer
            Dim fromMonth As String
            Dim tomonth As String

            Fromyear = ddlfromyear.SelectedItem.Text
            Toyear = ddltoyear.SelectedItem.Text
            fromMonth = ddlMonth.SelectedValue
            tomonth = ddlToMonth.SelectedValue


            If Fromyear > Toyear Then
                lblerrmsg.Text = "Start date should not be greater than End date."
                ddltoyear.Focus()
            End If

            Dim qrystring As String = "Frm_Rpt_Servicetax.aspx?" & QueryStr.Querystring() & "&Fromyear=" & Fromyear & "&Toyear=" & Toyear & "&fromMonth=" & fromMonth & "&tomonth=" & tomonth
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        Catch ex As Exception
            lblerrmsg.Text = "Please enter the valid date."
            lblmsgifo.Text = ""
        End Try

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
