
Partial Class rptTestTracefrm
    Inherits BasePage
    Dim alert As String
    Dim BAL As New CourseManager
    Dim GlobalFunction As New GlobalFunction
    Dim shdtls As Boolean
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Default2.aspx")
    End Sub

    Protected Sub btnSReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSReport.Click
        Dim QS As String
        Dim ModuleType As String = DDLModule.SelectedItem.Text
        Dim dl As New DLTestTrace
        QS = Request.QueryString.Get("QS")

        Dim qrystring As String = "rptTestTrace.aspx?" & QueryStr.Querystring() & "&ModuleType=" & ModuleType
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        shdtls = True
    End Sub
End Class
