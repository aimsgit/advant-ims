
Partial Class RptFixedAssetsGrantV
    Inherits BasePage
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "RptFixedAssetsGrant.aspx?" & QueryStr.Querystring() & "&FinStartDate=" & HttpContext.Current.Session("FinStartDate")
    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    'End Sub

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Session("FinStartDate") = CDate(Me.txtStartDate.Text)
        Session("FinEndDate") = CDate(Me.txtEndDate.Text)
        Dim qrystring As String = ""
        Dim qry_str As String = "&FinStartDate=" & Session("FinStartDate") & "&FinEndDate=" & Session("FinEndDate")
        qrystring = "RptFixedAssetsGrant.aspx?" & QueryStr.Querystring() & qry_str
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(CDate(Session("FinEndDate")), "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
