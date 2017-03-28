
Partial Class FrmRptEmpMedicalDetails
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msgin.Text = ""
        Dim QS As String
        Dim EmpID As Integer
        EmpID = DdlEmp.SelectedValue
        Try
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "FrmRptEmpMedicalDetailsV.aspx?" & QueryStr.Querystring() & "&EmpID=" & EmpID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            msgin.Text = "Enter correct data."
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