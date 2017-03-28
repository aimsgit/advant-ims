
Partial Class RptFeeDueSum
    Inherits BasePage
    Dim alt As String
    Dim dt As New Data.DataTable
    '    Dim rptDct As New ReportDocument
    Dim BLL As New FeeStructureManager
    'Dim BAL As New AssetTransfer.AssetTransferB
    Dim GlobalFunction As New GlobalFunction
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim AcId As Integer = ddlAYear.SelectedValue
        Dim SemId As Integer = ddlSemester.SelectedValue
        Dim CategoryID As Integer = ddlcategry.SelectedValue
        Dim CourseCode As Integer = ddlcourse.SelectedValue
        Dim AName As String = ddlAYear.SelectedItem.Text
        Dim CName As String = ddlcourse.SelectedItem.Text
        Dim SName As String = ddlSemester.SelectedItem.Text
        Dim CATName As String = ddlcategry.SelectedItem.Text
        Dim qrystring As String = " RptFeeDueSumV.aspx?" & QueryStr.Querystring() & "&AcId=" & AcId & "&SemID=" & SemId & "&CategoryID=" & CategoryID & "&CourseCode=" & CourseCode & "&AName=" & AName & "&CName=" & CName & "&SName=" & SName & "&CATName=" & CATName
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class

