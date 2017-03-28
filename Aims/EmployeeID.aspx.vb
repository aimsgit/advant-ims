
Partial Class EmployeeID
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Ecode As Integer
        Dim Bcode As String
        Dim DeptID As Integer
        Ecode = ddlEmpname.SelectedValue
        Bcode = CmbBranch.SelectedValue
        DeptID = ddlDept.SelectedValue
       
        Try
            msginfo.Text = " "
            Dim qrystring As String = "EmployeeIDV.aspx?" & QueryStr.Querystring() & "&branchcode=" & CmbBranch.SelectedValue & "&Ecode=" & Ecode & "&Bcode=" & Bcode & "&DeptID=" & DeptID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            msginfo.Text = "Please enter all Mandatory Fields."
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            CmbBranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If
    End Sub
End Class
