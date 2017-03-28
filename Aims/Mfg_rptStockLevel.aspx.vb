
Partial Class Mfg_rptStockLevel
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim CompanyId As Integer
        Dim fromdateE As DateTime

        If ddlMfg.SelectedValue = "" Then
            CompanyId = 0
        Else
            CompanyId = ddlMfg.SelectedValue
        End If
       
        If txtstartdate.Text = "" Then
            fromdateE = "1/1/1900"
        Else
            fromdateE = txtstartdate.Text
        End If
 
        Dim qrystring As String = "Mfg_rptStockLevelV.aspx?" & QueryStr.Querystring() & "&StartDate=" & fromdateE & "&CompanyId=" & CompanyId
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        'AlertEnterAllFields()

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtstartdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")

        End If
    End Sub
End Class