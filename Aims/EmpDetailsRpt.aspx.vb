
Partial Class EmpDetailsRpt
    Inherits BasePage
    Dim BL As New EmpTranferB
    Dim DL As New EmpTransD

    Dim GlobalFunction As New GlobalFunction

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try


            Dim dt As New Data.DataTable
            'Dim Branch As New Integer
            Dim Designation As New Integer
            Dim SalaryGrade As String
            Dim DojDob As Integer
            Dim FromDate As Date
            Dim ToDate As Date
            Dim DeptId As Integer
            Dim SortBy As Integer
            If cmbdojdob.SelectedValue = "0" Then


                'Branch = ddlBranch.SelectedValue
                Designation = ddlDesignation.SelectedValue
                SalaryGrade = ddlGrade.SelectedItem.Text
                DojDob = cmbdojdob.SelectedValue
                If txtFromDate.Text = "" Then
                    FromDate = "01/01/1900"

                Else
                    FromDate = txtFromDate.Text
                    txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
                End If

                ToDate = txtToDate.Text
                txtToDate.Text = ToDate.ToString("dd-MMM-yyyy")
                DeptId = ddlDept.SelectedValue
                SortBy = ddlSort.SelectedValue



                'dt = BL.finalExamRpt(Designation, DojDob, FromDate, ToDate)

                Dim qrystring As String = "rptEmpDetails.aspx?" & QueryStr.Querystring() & "&Designation=" & Designation & "&SalaryGrade=" & SalaryGrade & "&DojDob=" & DojDob & "&FromDate=" & FromDate & "&ToDate=" & ToDate.ToString("dd-MMM-yyyy") & "&DeptId=" & DeptId & "&SortBy=" & SortBy

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                lblmsg.Text = ""
            ElseIf txtFromDate.Text = "" Then

                lblmsg.Text = "From Date is mandatory."
                txtFromDate.Focus()
            ElseIf txtToDate.Text = "" Then
                lblmsg.Text = "To Date is mandatory."
                txtToDate.Focus()
            Else
                If CType(txtFromDate.Text, Date) > CType(txtToDate.Text, Date) Then

                    lblmsg.Text = "From date should be lesser than To date."
                    txtFromDate.Focus()
                    Exit Sub
                End If
                Designation = ddlDesignation.SelectedValue
                SalaryGrade = ddlGrade.SelectedItem.Text
                DojDob = cmbdojdob.SelectedValue
                DeptId = ddlDept.SelectedValue
                SortBy = ddlSort.SelectedValue
                If txtFromDate.Text = "" Then
                    FromDate = "01/01/1900"
                    txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
                Else
                    FromDate = txtFromDate.Text
                    txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
                End If

                ToDate = txtToDate.Text
                txtToDate.Text = Format(ToDate, "dd-MMM-yyyy")


                If CType(txtFromDate.Text, Date) > CType(txtToDate.Text, Date) Then

                    lblmsg.Text = "From date should be lesser than To date."
                    txtFromDate.Focus()
                    Exit Sub
                End If


                'dt = BL.finalExamRpt(Designation, DojDob, FromDate, ToDate)

                Dim qrystring As String = "rptEmpDetails.aspx?" & QueryStr.Querystring() & "&Designation=" & Designation & "&SalaryGrade=" & SalaryGrade & "&DojDob=" & DojDob & "&FromDate=" & FromDate & "&ToDate=" & ToDate & "&DeptId=" & DeptId & "&SortBy=" & SortBy

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                lblmsg.Text = ""
            End If
        Catch ex As Exception
            lblmsg.Text = "Enter Correct Data."
        End Try
    End Sub

    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub cmbdojdob_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdojdob.SelectedIndexChanged
        If cmbdojdob.SelectedValue = "0" Then
            txtFromDate.Enabled = False
            txtToDate.Enabled = False
            txtFromDate.Text = ""
        Else
            txtFromDate.Enabled = True
            txtToDate.Enabled = True
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If cmbdojdob.SelectedValue = "0" Then
            txtFromDate.Enabled = False
            txtToDate.Enabled = True
            txtToDate.Text = Format(Today, "dd-MMM-yyyy")
        Else
            txtFromDate.Enabled = True
            txtToDate.Enabled = True
        End If
       

    End Sub

    Protected Sub ddlDept_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.TextChanged
        ddlDept.Focus()
    End Sub

    Protected Sub ddlDesignation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDesignation.TextChanged
        ddlDesignation.Focus()
    End Sub

    Protected Sub cmbdojdob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdojdob.TextChanged
        cmbdojdob.Focus()
    End Sub
    Protected Sub ddlGrade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGrade.TextChanged
        ddlGrade.Focus()
    End Sub
End Class
