
Partial Class RptLeaveApplication
    Inherits BasePage


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub BtnDetailed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetailed.Click
        msginfo.Text = ""
        Dim FrmDate As Date
        Dim ToDate As Date
        Dim Dept As Integer = ddlDept.SelectedValue
        Dim Emp As Integer = ddlEmp.SelectedValue
        Dim LeaveType As Integer = ddlleavetype.SelectedValue
        Dim LeaveStatus As Integer = ddlLeaveStatus.SelectedValue
        Try

       
            If txtFrmDate.Text = "" Then
                FrmDate = "01-01-1900"
            Else
                FrmDate = txtFrmDate.Text
            End If

            If txtTodate.Text = "" Then
                ToDate = "01-01-3000"
            Else
                ToDate = txtTodate.Text

            End If


            If (CDate(FrmDate) > CDate(ToDate)) Then
                msginfo.Text = "From Date cannot be greater than To Date."

            Else
                Dim qrystring As String = "RptLeaveApplicatnV.aspx?" & "&Dept=" & Dept & "&Emp=" & Emp & "&LeaveType=" & LeaveType & "&LeaveStatus=" & LeaveStatus & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                msginfo.Text = ""
            End If

        Catch ex As Exception
            msginfo.Text = "Enter Correct Data"
        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtFrmDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtTodate.Text = Format(Today, "dd-MMM-yyyy")
        End If

    End Sub

    Protected Sub btnSumRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumRpt.Click
        msginfo.Text = ""
        Dim FrmDate As Date
        Dim ToDate As Date
        Dim Dept As Integer = ddlDept.SelectedValue
        Dim Emp As Integer = ddlEmp.SelectedValue
        'Dim LeaveType As Integer = ddlleavetype.SelectedValue
        'Dim LeaveStatus As Integer = ddlLeaveStatus.SelectedValue
        Try




            If txtFrmDate.Text = "" Then
                FrmDate = "01-01-1900"
            Else
                FrmDate = txtFrmDate.Text
            End If

            If txtTodate.Text = "" Then
                ToDate = "01-01-3000"
            Else
                ToDate = txtTodate.Text

            End If


            If (CDate(FrmDate) > CDate(ToDate)) Then
                msginfo.Text = "From Date cannot be greater than To Date."

            Else
                Dim qrystring As String = "RptLeaveApplicatnSummaryV.aspx?" & "&Dept=" & Dept & "&Emp=" & Emp & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                msginfo.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = "Enter Correct Data"
        End Try




    End Sub
End Class
