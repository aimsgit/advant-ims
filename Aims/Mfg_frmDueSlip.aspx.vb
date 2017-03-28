Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class frmDueSlip
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try

            Dim Fromdate As DateTime
            Dim Todate As DateTime
            Dim Party_Id As Integer
            Dim Sale_Invoice_No As Integer

            Sale_Invoice_No = ddlSaleInvNo.SelectedValue
            Party_Id = ddlBuyerName.SelectedValue
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

            Dim qrystring As String = "Mfg_RptDueSlip.aspx?" & QueryStr.Querystring() & "&Fromdate=" & Fromdate & "&Todate=" & Todate & "&Party_Id=" & Party_Id & "&Sale_Invoice_No=" & Sale_Invoice_No
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            lblerrmsg.Text = "Please enter the valid date."
            lblmsgifo.Text = ""
        End Try

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
