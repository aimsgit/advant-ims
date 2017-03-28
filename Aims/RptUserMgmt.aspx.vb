
Partial Class RptUserMgmt
    Inherits BasePage



    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Dim DeptID As Integer

        DeptID = ddlDept.SelectedValue


       
        Dim qrystring As String = "RptUserMgmtV.aspx?" & QueryStr.Querystring() & "&DeptID=" & DeptID
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)



    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

End Class