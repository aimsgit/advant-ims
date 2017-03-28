
Partial Class Mfg_RptAreaDetails
    Inherits BasePage
    'Code written By Niraj
    'Date 22-Jan-2013
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim Area As Integer
        Try

            Area = ddlArea.SelectedValue

            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "Mfg_AreaDetailsV.aspx?" & QueryStr.Querystring() & "&Area_code=" & Area
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            msginfo.Text = "Enter correct data."
        End Try

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ddlArea.Focus()

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()

    End Sub
End Class
