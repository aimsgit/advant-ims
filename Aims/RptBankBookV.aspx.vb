Partial Class RptBankBookV
    Inherits BasePage
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then
            msginfo.Text = ""
            Dim FromDate As Date
            Dim ToDate As Date
            FromDate = txtStartDate.Text
            Dim PR As String
            Dim RT As Integer
            PR = DDLProjectName.SelectedValue
            RT = ddlRType.SelectedValue
            txtStartDate.Text = Format(FromDate, "dd-MMM-yyyy")
            ToDate = txtEndDate.Text
            If FromDate > ToDate Then
                msginfo.Text = "Start date should not be greater than End date."
                txtEndDate.Focus()
                Exit Sub
            End If
            Dim qrystring As String = "BankBookV.aspx?" & "&PR=" & PR & "&RT=" & RT & "&FinStartDate=" & FromDate & "&FinEndDate=" & ToDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
