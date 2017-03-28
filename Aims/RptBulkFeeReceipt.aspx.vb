
Partial Class RptBulkFeeReceipt
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtFrmDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
            txtTodate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
        'txtFrmDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        'txtTodate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        If RBUsers.SelectedValue = 1 Then
            txtFrmDate.Enabled = True
            txtTodate.Enabled = True
            ddlReceipt1.Enabled = False
            ddlReceipt2.Enabled = False
        Else
            txtFrmDate.Enabled = False
            txtTodate.Enabled = False
            ddlReceipt1.Enabled = True
            ddlReceipt2.Enabled = True
        End If
    End Sub

    Protected Sub btnimport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnimport.Click
        lblerrmsg.Text = ""
        Dim Department As String
        Dim FromReceipt As Integer
        Dim ToReceipt As Integer
        Dim fromdateE As DateTime
        Dim todateE As DateTime
        Dim Radio As String
        Department = ddlDept.SelectedValue
        FromReceipt = ddlReceipt1.SelectedValue
        ToReceipt = ddlReceipt2.SelectedValue
        Radio = RBUsers.SelectedValue
        If txtFrmDate.Text = "" Then
            fromdateE = "4/1/1900"
        Else
            fromdateE = txtFrmDate.Text
        End If
        If txtTodate.Text = "" Then
            todateE = "4/1/9000"
        Else
            todateE = txtTodate.Text
        End If
        If fromdateE > todateE Then
            lblerrmsg.Text = "Start date should not be greater than End date."
            txtFrmDate.Focus()
            Exit Sub
        End If

        Dim qrystring As String = "RptBulkFeeReceiptV.aspx?" & QueryStr.Querystring() & "&StartDate=" & fromdateE & "&EndDate=" & todateE & "&Department=" & Department & "&FromReceipt=" & FromReceipt & "&ToReceipt=" & ToReceipt & "&Radio=" & Radio
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

    End Sub

    Protected Sub RBUsers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBUsers.SelectedIndexChanged
        If RBUsers.SelectedValue = 1 Then
            txtFrmDate.Enabled = True
            txtTodate.Enabled = True
            ddlReceipt1.Enabled = False
            ddlReceipt2.Enabled = False
        Else
            txtFrmDate.Enabled = False
            txtTodate.Enabled = False
           ddlReceipt1.Enabled = True
            ddlReceipt2.Enabled = True
        End If
    End Sub

    Protected Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub btnsummary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsummary.Click
        lblerrmsg.Text = ""
        Dim Department As String
        Dim FromReceipt As Integer
        Dim ToReceipt As Integer
        Dim fromdateE As DateTime
        Dim todateE As DateTime
        Dim Radio As String
        Department = ddlDept.SelectedValue
        FromReceipt = ddlReceipt1.SelectedValue
        ToReceipt = ddlReceipt2.SelectedValue
        Radio = RBUsers.SelectedValue
        If txtFrmDate.Text = "" Then
            fromdateE = "4/1/1900"
        Else
            fromdateE = txtFrmDate.Text
        End If
        If txtTodate.Text = "" Then
            todateE = "4/1/9000"
        Else
            todateE = txtTodate.Text
        End If




        If fromdateE > todateE Then
            lblerrmsg.Text = "Start date should not be greater than End date."
            txtFrmDate.Focus()
            Exit Sub
        End If

        Dim qrystring As String = "RptBulkFeeReceiptSummary.aspx?" & QueryStr.Querystring() & "&StartDate=" & fromdateE & "&EndDate=" & todateE & "&Department=" & Department & "&FromReceipt=" & FromReceipt & "&ToReceipt=" & ToReceipt & "&Radio=" & Radio
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

    End Sub
End Class
