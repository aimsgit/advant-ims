
Partial Class RptOverTimeEntry

    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        'Code for account payable report by Shwetha 2014/12/05
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim DeptId As Integer
        Dim EmpId As Integer
        Dim StartDate As DateTime
        Dim EndDate As DateTime
        If ddldepartment.SelectedValue = "" Then
            DeptId = 0
        Else
            DeptId = ddldepartment.SelectedValue
        End If
        If ddlEmpName.SelectedValue = "" Then
            EmpId = 0
        Else
            EmpId = ddlEmpName.SelectedValue
        End If
        If txtstartdate.Text = "" Then
            StartDate = "1/1/1900"
        Else
            StartDate = txtstartdate.Text
        End If
        If txtenddate.Text = "" Then
            EndDate = "1/1/3000"
        Else
            EndDate = txtenddate.Text
        End If
        If StartDate > EndDate Then
            msginfo.Text = "Start date should not be greater than End date."
            txtenddate.Focus()
            Exit Sub
        End If
        Dim qrystring As String = "RptOverTimeEntryV.aspx?" & QueryStr.Querystring() & "&StartDate=" & StartDate & "&EndDate=" & EndDate & "&DeptId=" & DeptId & "&EmpId=" & EmpId
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtstartdate.Text = DateTime.Today.AddDays(-20).ToString("dd-MMM-yyyy")

            txtenddate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class
