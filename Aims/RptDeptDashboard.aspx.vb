
Partial Class RptDeptDashboard
    Inherits BasePage

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Dim DeptID As Integer

        DeptID = ddlDept.SelectedValue
     

        If ddlDept.SelectedValue = "0" Then
            msginfo.Text = "Department field is Mandatory."
        Else
            msginfo.Text = ""
            Dim qrystring As String = "RptDeptDashboardV.aspx?" & QueryStr.Querystring() & "&DeptID=" & DeptID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
           

        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click

        Response.Redirect("Default2.aspx")
    End Sub

End Class
