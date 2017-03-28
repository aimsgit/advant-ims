
Partial Class rptAdhocfeecollectionReport
    Inherits BasePage


    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        'Dim Bat As String = cmbBatch.SelectedValue
        Dim FeeHead As Integer
        Dim StartDate, EndDate As Date
        Dim Payment As Integer = ddlPaymentMethod.SelectedValue
        FeeHead = ddlfee_head.SelectedValue
        'Dim StudentCode As Integer = ddlstucode.SelectedValue
        Try
            If txtSDate.Text = "" Then
                StartDate = "1/1/1900"
            Else
                StartDate = txtSDate.Text
            End If
            If txtEDate.Text = "" Then
                EndDate = "1/1/9100"
            Else
                EndDate = txtEDate.Text
            End If

            If StartDate <= EndDate Then
                Dim qrystring As String = "rptAdhocfeeCollectionReportV.aspx?" & "&Payment=" & Payment & "&FeeHead=" & FeeHead & "&StartDate=" & StartDate & "&EndDate=" & EndDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                msginfo.Text = "Start Date Should Not be Greater than End Date."
            End If
        Catch ex As Exception
            msginfo.Text = "Please Enter Correct data"
        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtSDate.Text = Format(Today, "dd-MMM-yyyy")
            txtEDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Session("GStatus") = ""
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
