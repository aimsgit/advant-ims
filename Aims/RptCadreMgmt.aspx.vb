
Partial Class RptCadreMgmt
    Inherits BasePage
    Dim BL As New CadreMgmtBL
    Dim DL As New CadreMgmtDL
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim dt As New Data.DataTable
        Dim University As String
        Dim Program As String
        Dim Project As String
        University = ddlUniversity.SelectedValue
        Program = ddlProgram.SelectedValue
        Project = ddlProj.SelectedValue
        If ddlProgram.SelectedValue = "Select" Or ddlUniversity.SelectedValue = "Select" Then
            lblmsg.Text = "Select All the Required Fields."
        Else

            'dt = BL.CadreMgmtRpt(University, Program, Project)

            Dim qrystring As String = "rptCadreMgmt_V.aspx?" & QueryStr.Querystring() & "&University=" & University & "&Program=" & Program & "&Project=" & Project

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    ddlUniversity.SelectedValue = Session("BranchCode")
        'End If
    End Sub
End Class
