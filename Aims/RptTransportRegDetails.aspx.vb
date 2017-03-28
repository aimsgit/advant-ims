
Partial Class RptTransportRegDetails
    Inherits BasePage

    Dim alt As String
    Dim dt As New Data.DataTable
    '    Dim rptDct As New ReportDocument
    Dim DL As New DLTransportRegDetails
    'Dim BAL As New AssetTransfer.AssetTransferB
    Dim GlobalFunction As New GlobalFunction
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim A_Year As Integer = cmbAcademic.SelectedValue
        Dim RouteID As Integer = cmbRoute.SelectedValue
        Dim qrystring As String = "Rpt_TransportRegDetailsV.aspx?" & QueryStr.Querystring() & "&A_Year=" & A_Year & "&RouteID=" & RouteID
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    End Sub
    <System.Web.Services.WebMethod()> _
        Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

End Class
