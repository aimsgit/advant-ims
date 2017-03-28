
Partial Class Rpt_AccountHeadLedger
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Code for Bind Date By Nitin 05/07/2012 

        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            txtfromdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txttodate.Text = Format(Date.Today(), "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub btRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btRpt.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then
            Try
                Dim AH, PR As String
                AH = cmbAGOne.SelectedValue
                PR = DDLProjectName.SelectedValue
                'Code for Account Head Ledger Report Link  By Nitin 05/07/2012 
                Dim qrystring As String = "Rpt_AccountHeadLedgerV.aspx?" & QueryStr.Querystring() & "&AH=" & AH & "&PR=" & PR & "&FromDate=" & CDate(txtfromdate.Text) & "&ToDate=" & CDate(txttodate.Text)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            Catch ex As Exception
                lblErrorMsg.Text = "Date is not valid."
            End Try
        Else
            lblErrorMsg.Text = "You do not have Read Privilage."
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
