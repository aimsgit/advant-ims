
Partial Class RptPaid_UnpaidLeaveAppliction
    Inherits BasePage
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
  
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtFrmDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtTodate.Text = Format(Today, "dd-MMM-yyyy")
        End If

    End Sub

    Protected Sub btnSumRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumRpt.Click
        msginfo.Text = ""
        Dim FromDate As Date
        Dim ToDate As Date
        Dim DeptId As Integer = ddlDept.SelectedValue
        Dim EmpId As Integer = ddlEmp.SelectedValue


        If txtFrmDate.Text = "" Then
            FromDate = "01-01-1900"
        Else
            FromDate = txtFrmDate.Text
        End If

        If txtTodate.Text = "" Then
            ToDate = "01-01-3000"
        Else
            ToDate = txtTodate.Text

        End If


        If (CDate(FromDate) > CDate(ToDate)) Then
            msginfo.Text = "From Date cannot be greater than To Date."

        Else
            Dim qrystring As String = "RptPaid_UnpaidLeaveApplictionV.aspx?" & "&DeptId=" & DeptId & "&EmpId=" & EmpId & "&FromDate=" & FromDate & "&ToDate=" & ToDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
        End If


    End Sub
End Class
