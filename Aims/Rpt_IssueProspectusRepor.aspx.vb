
Partial Class Rpt_IssueProspectusRepor
    Inherits BasePage

    Protected Sub btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim Sdate As Date
        Dim Edate As Date

        If TxtStartDate.Text = "" Then
            Sdate = "1/1/1900"
        Else
            Sdate = TxtStartDate.Text
        End If

        If TxtEndDate.Text = "" Then
            Edate = "1/1/3000"
        Else
            Edate = TxtEndDate.Text
        End If
        If Sdate > Edate Then
            msginfo.Text = "Start date should not be greater than End date."
            TxtEndDate.Focus()
            Exit Sub
        End If
        QS = Request.QueryString.Get("QS")

        Dim qrystring As String = "Rpt_IssueProspectuswReportView.aspx?" & QueryStr.Querystring() & "&Sdate=" & Sdate & "&Edate=" & Edate
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        'lblMsg.Text = ""

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("Report.aspx")

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TxtStartDate.Text = Format(Today, "dd-MMM-yyyy")
            TxtEndDate.Text = Format(Today, "dd-MMM-yyyy")

        End If


    End Sub
End Class
