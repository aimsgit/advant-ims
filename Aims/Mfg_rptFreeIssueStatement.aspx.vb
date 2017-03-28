
Partial Class Mfg_rptFreeIssueStatement
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim ProductId As Integer
        Dim fromdate As DateTime
        Dim enddate As DateTime
        Try
            
            If ddlProduct.SelectedValue = "" Then
                ProductId = 0
            Else
                ProductId = ddlProduct.SelectedValue
            End If
            If txtstartdate.Text = "" Then
                fromdate = "1/1/1990"
            Else
                fromdate = txtstartdate.Text
            End If
            If txtenddate.Text = "" Then
                enddate = "1/1/3000"
            Else
                enddate = txtenddate.Text
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "Mfg_rptFreeIssueStatementV.aspx?" & QueryStr.Querystring() & "&ProductId=" & ProductId & "&StartDate=" & fromdate & "&EndDate=" & enddate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtstartdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtenddate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class

 