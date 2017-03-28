
Partial Class Mfg_rptBatchWiseStock
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim CompanyId As Integer
        Dim Fromdate As DateTime
        Dim Todate As DateTime
        If ddlCompany.SelectedValue = "" Then
            CompanyId = 0
        Else
            CompanyId = ddlCompany.SelectedValue
        End If
        
        If txtstartdate.Text = "" Then
            Fromdate = "1/1/1900"
        Else
            Fromdate = txtstartdate.Text
        End If
        If txtenddate.Text = "" Then
            Todate = "1/1/3000"
        Else
            Todate = txtenddate.Text
        End If
        If Fromdate > Todate Then
            msginfo.Text = "Start date should not be greater than End date."
            txtenddate.Focus()
            Exit Sub
        End If
        Dim qrystring As String = "Mfg_rptBatchWiseStockV.aspx?" & QueryStr.Querystring() & "&Fromdate=" & Fromdate & "&Todate=" & Todate & "&CompanyId=" & CompanyId
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        'AlertEnterAllFields()

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtstartdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtenddate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class