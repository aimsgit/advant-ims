
Partial Class frm_RptLeaveRegister
    Inherits BasePage

    Protected Sub btnSumRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumRpt.Click
        Try
            Dim Dept, Leave As String
            Dim Year As Integer
            Dept = ddlDept.SelectedValue
            Leave = ddlleavetype.SelectedValue
            Year = ddlYear.SelectedItem.Text
            
            Dim qrystring As String = "RptviewerLeaveRegister.aspx?" & "&Dept=" & Dept & "&Leave=" & Leave & "&Year=" & Year
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
        Catch ex As Exception
            msginfo.Text = "Please Enter Correct Data."
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
