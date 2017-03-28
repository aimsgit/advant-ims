Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class Mfg_frmSaleRegisterSummary
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Fromdate As DateTime
        Dim Todate As DateTime
        Dim overall As String


        If ch1.Checked = "true" Then
            overall = "Y"
        Else
            overall = "N"
        End If
        If txtStartingDate.Text = "" Then
            Fromdate = "1/1/1900"
        Else
            Fromdate = txtStartingDate.Text

        End If

        If txtEndDate.Text = "" Then
            Todate = "1/1/3000"
        Else
            Todate = txtEndDate.Text
        End If

        If Fromdate > Todate Then
            lblerrmsg.Text = "Start date should not be greater than End date."
            txtEndDate.Focus()
        End If

        Dim qrystring As String = "Mfg_Rpt_SaleRegisterSummary.aspx?" & QueryStr.Querystring() & "&Fromdate=" & Fromdate & "&Todate=" & Todate & "&overall=" & overall
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)


    End Sub
End Class
