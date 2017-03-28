
Partial Class RptMonthlyRunReport
    Inherits BasePage
    Dim dl As New DLAnnualSalaryStatment
    Dim dt As New DataTable
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try

            Dim QS As String
            QS = Request.QueryString.Get("QS")
            Dim id As String = ""
            Dim ColumNName1 As String = ""
            Dim check As String = ""
            Dim count As New Integer
            count = GVDynamic.Rows.Count
            Dim i As Integer = 0
            For Each grid As GridViewRow In GVDynamic.Rows
                If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                    check = "[" + CType(grid.FindControl("Label3"), Label).Text.ToString + "]"
                    id = id + "," + check
                    ColumNName1 = ColumNName1 + "," + CType(grid.FindControl("lblModule"), Label).Text.ToString
                End If
            Next
            'If id > "4" Then
            '    Exit Sub
            'End If
            If id <> "" Then
                lblRed.Text = ""
                id = Right(id, id.Length - 1)
                Dim qrystring As String = "RptMonthlyRunReportV.aspx?" & QueryStr.Querystring() & "&FromYear=" & ddlYear.SelectedItem.Text & "&ToYear=" & ddlYearTo.SelectedItem.Text & "&DeptID=" & ddlDept.SelectedValue & "&EmpId=" & DdlEmpName.SelectedValue & "&FromMonth=" & ddlFrom.SelectedValue & "&ToMonth=" & ddlTo.SelectedValue & "&ColumnName=" & id & "&ColumNName1=" & ColumNName1 & "&FromMonth1=" & ddlFrom.SelectedItem.Text & "&ToMonth1=" & ddlTo.SelectedItem.Text & "&Dept=" & ddlDept.SelectedItem.Text
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            Else
                lblRed.Text = " Select atleast one column name."
            End If
        Catch ex As Exception
            lblRed.Text = "Enter correct Data."
            lblGreen.Text = ""
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GridMonthlySalaryStatement
        If Not IsPostBack Then
            dt = DLAnnualSalaryStatment.GridMonthlycol()
            GVDynamic.DataSource = dt
            GVDynamic.DataBind()
        End If
    End Sub
    Sub CheckAll()
        If CType(GVDynamic.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVDynamic.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
                btnReport.Focus()
            Next
        Else
            For Each grid As GridViewRow In GVDynamic.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = False
            Next
        End If
    End Sub
End Class
