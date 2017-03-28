
Partial Class RptFeeHead
    Inherits BasePage

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        msginfo.Text = ""
        Dim QS As String
        'Dim feehead As String = txtfeeheadtype.Text

        QS = Request.QueryString.Get("QS")

        If txtfeeheadtype.Text = "Select" Then
            msginfo.Text = ""
        Else
            Dim qrystring As String = "Rpt_FeeHeadV.aspx?" & QueryStr.Querystring()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        End If
       
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QS, heading As String
        QS = Request.QueryString.Get("QS")
        heading = Request.QueryString.Get("heading")

    End Sub
    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
   Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()

    End Sub
End Class
