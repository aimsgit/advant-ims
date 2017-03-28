
Partial Class RptDistributionOfObtainedGdvsSub
    Inherits BasePage
    Dim alt As String
    Dim dt As New Data.DataTable
    '    Dim rptDct As New ReportDocument
    Dim BLL As New FeeStructureManager
    'Dim BAL As New AssetTransfer.AssetTransferB
    Dim GlobalFunction As New GlobalFunction
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Branch As String = DDLBranch.SelectedValue
        Dim SemId As Integer = ddlSemester.SelectedValue
        Dim AcId As Integer = DDLA_Year.SelectedValue
        Dim CourseCode As Integer = ddlCourse.SelectedValue
        Dim assessment As Integer = ddlassesment.SelectedValue
        Dim SName As String = ddlSemester.SelectedItem.Text
        Dim CName As String = ddlCourse.SelectedItem.Text
        Dim AName As String = ddlassesment.SelectedItem.Text


        Dim qrystring As String = " RptDistributionOfObtainedGdvsSubV.aspx?" & QueryStr.Querystring() & "&AcId=" & AcId & "&SemID=" & SemId & "&CourseCode=" & CourseCode & "&Branch=" & Branch & "&assessment=" & assessment & "&SName=" & SName & "&CName=" & CName & "&AName=" & AName
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

