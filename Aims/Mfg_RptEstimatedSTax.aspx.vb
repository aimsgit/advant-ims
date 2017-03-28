
Partial Class Mfg_RptEstimatedSTax
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim Fromdate As DateTime
            Dim Todate As DateTime
            If txtstartdate.Text = "" Then
                Fromdate = "1/1/1900"
            Else
                Fromdate = txtstartdate.Text
            End If
            If txtenddate.Text = "" Then
                Todate = Format(Today(), "dd-MMM-yyyy")
            Else
                Todate = txtenddate.Text
            End If
            If Fromdate > Todate Then
                msginfo.Text = "Start date should not be greater than End date."
                txtenddate.Focus()
                Exit Sub
            End If
            Dim qrystring As String = "Mfg_RptEstimatedSTaxV.aspx?" & QueryStr.Querystring() & "&Fromdate=" & Fromdate & "&Todate=" & Todate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)


        Catch ex As Exception
            msginfo.Text = "Please enter the valid date."
            lblmsg.Text = ""
        End Try

    End Sub
End Class
