
Partial Class Rpt_MgmtDashUniv
    Inherits BasePage
    Protected Sub btnTReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTReport.Click
        lblE.Text = ""
        If ddlBranchName.SelectedValue = "" Then
            lblE.Text = "Please Select the BranchName."
            Exit Sub
        End If
        Dim BranchCode As String
        Dim fromdateE As DateTime
        Dim todateE As DateTime
        If ddlBranchName.SelectedValue = "" Then
            BranchCode = 0
        Else
            BranchCode = ddlBranchName.SelectedValue
        End If
        If txtFromDate.Text = "" Then
            fromdateE = "4/1/1900"
        Else
            fromdateE = txtFromDate.Text
        End If
        If txtToDate.Text = "" Then
            todateE = "4/1/9000"
        Else
            todateE = txtToDate.Text
        End If
        If fromdateE > todateE Then
            lblE.Text = "Start date should not be greater than End date."
            txtFromDate.Focus()
            Exit Sub
        End If
        Dim qrystring As String = "Rpt_MgmtDashUnivTabV.aspx?" & QueryStr.Querystring() & "&StartDate=" & fromdateE & "&EndDate=" & todateE & "&BranchCode=" & BranchCode
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)


    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'ddlBranchName.SelectedValue = Session("BranchCode")
            txtFromDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtToDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub BtnGReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGReport.Click
        lblE.Text = ""
        If ddlBranchName.SelectedValue = "" Then
            lblE.Text = "Please Select the BranchName."
            Exit Sub
        End If
        Dim BranchCode As String
        Dim fromdateE As DateTime
        Dim todateE As DateTime
        If ddlBranchName.SelectedValue = "" Then
            BranchCode = 0
        Else
            BranchCode = ddlBranchName.SelectedValue
        End If
        If txtFromDate.Text = "" Then
            fromdateE = "4/1/1900"
        Else
            fromdateE = txtFromDate.Text
        End If
        If txtToDate.Text = "" Then
            todateE = "4/1/9000"
        Else
            todateE = txtToDate.Text
        End If
        If fromdateE > todateE Then
            lblE.Text = "Start date should not be greater than End date."
            txtFromDate.Focus()
            Exit Sub
        End If
        Dim qrystring As String = "Rpt_MgmtDashUnivGraphV.aspx?" & QueryStr.Querystring() & "&StartDate=" & fromdateE & "&EndDate=" & todateE & "&BranchCode=" & BranchCode
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub
End Class