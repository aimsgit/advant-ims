
Partial Class RptLeaveRegister
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        'msginfo.Text = ""
        Dim LT As Integer
        Dim EC As Integer
        Dim QS As String
        LT = cmbLeaveType.SelectedValue
        If txtEmp.Text = "" Then
            EC = 0
        Else
            EC = HidempId.Value
        End If
        QS = Request.QueryString.Get("QS")
        If QS = "Rpt5" Then
            Dim qrystring As String = "RptviewerLeaveRegister.aspx?" & QueryStr.Querystring() & "&LeaveType=" & LT & "&EmployeeCode=" & EC
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QS, heading As String
        QS = Request.QueryString.Get("QS")
        heading = Request.QueryString.Get("heading")
        Me.Lblheading.Text = heading
        Invisible()
        If QS = "Rpt5" Then
            Label1.Visible = True
            cmbLeaveType.Visible = True
            lblEmpId.Visible = True
            txtEmp.Visible = True

        End If
    End Sub
    Sub Invisible()
        Label1.Visible = False
        cmbLeaveType.Visible = False
        lblEmpId.Visible = False
        txtEmp.Visible = False
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
