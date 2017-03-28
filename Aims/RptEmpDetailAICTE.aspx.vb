
Partial Class RptEmpDetailAICTE
    Inherits BasePage
    Dim BL As New EmpTranferB
    Dim DL As New EmpTransD

    Dim GlobalFunction As New GlobalFunction

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        'Code for Employee detail report in AICTE format by Shwetha 2014/12/01
        Dim QS As String
        QS = Request.QueryString.Get("QS")
        Dim id As String = ""
        Dim check As String = ""
        Dim count As New Integer
        Dim Designation As New Integer
        Dim SalaryGrade As Integer
        Dim DeptId As Integer
        Dim SortBy As Integer
        count = GVAdmission.Rows.Count
        Dim i As Integer = 0
        For Each grid As GridViewRow In GVAdmission.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                check = "[" + CType(grid.FindControl("lblModule"), Label).Text.ToString + "]"
                id = id + "," + check
            End If
        Next
        If id <> "" Then
            lblmsg.Text = ""
            id = Right(id, id.Length - 1)
            Designation = ddlDesignation.SelectedValue
            SalaryGrade = ddlGrade.SelectedValue
            DeptId = ddlDept.SelectedValue
            SortBy = ddlSort.SelectedValue
            Dim qrystring As String = "RptEmpDeyailAICTE_V.aspx?" & QueryStr.Querystring() & "&id=" & id & "&Designation=" & Designation & "&SalaryGrade=" & SalaryGrade & "&DeptId=" & DeptId & "&SortBy=" & SortBy
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Else
            lblmsg.Text = " Select atleast one column name."
        End If
    End Sub
    '

    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Sub CheckAll()
        If CType(GVAdmission.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVAdmission.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
                btnReport.Focus()
            Next
        Else
            For Each grid As GridViewRow In GVAdmission.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
         If Not IsPostBack Then
            dt = BL.finalDynEmpRptAICTE()
            GVAdmission.DataSource = dt
            GVAdmission.DataBind()
        End If
    End Sub

    Protected Sub ddlDept_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.TextChanged
        ddlDept.Focus()
    End Sub

    Protected Sub ddlDesignation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDesignation.TextChanged
        ddlDesignation.Focus()
    End Sub

   
    Protected Sub ddlGrade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGrade.TextChanged
        ddlGrade.Focus()
    End Sub
End Class

