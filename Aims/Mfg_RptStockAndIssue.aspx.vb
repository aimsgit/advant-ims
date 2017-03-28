
Partial Class Mfg_RptStockAndIssue
    Inherits System.Web.UI.Page

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim CatId As Integer
        Dim fromdateE As DateTime
        Dim todateE As DateTime

        Try
            If txtstartdate.Text <> "" And txtenddate.Text <> "" Then

                If CType(txtstartdate.Text, Date) > CType(txtenddate.Text, Date) Then
                    msginfo.Text = "Start Date Can't be greater than End Date"
                    Exit Sub
                End If
            End If
       
            If DdlCategory.SelectedValue = "" Then
                CatId = 0
            Else
                CatId = DdlCategory.SelectedValue
            End If
            If txtstartdate.Text = "" Then
                fromdateE = "1/1/1900"
            Else
                fromdateE = txtstartdate.Text
            End If

            If txtenddate.Text = "" Then
                todateE = "1/1/3000"
            Else
                todateE = txtenddate.Text
            End If



            Dim qrystring As String = "Mfg_RptStockAndIssueV.aspx?" & QueryStr.Querystring() & "&StartDate=" & fromdateE & "&EndDate=" & todateE & "&CatId=" & CatId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            msginfo.Text = "Enter Correct Date."
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtstartdate.Text = Format(Today.Date(), "dd-MMM-yyyy")
            txtenddate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class