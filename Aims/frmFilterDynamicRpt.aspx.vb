
Partial Class frmFilterDynamicRpt
    Inherits BasePage
    Dim BL As New BLDynamicReport
    Dim dt As New DataTable
    '07-Sep-2012. Kusum C Akki. Dynamic report filter criteria
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dt = BL.AdmissionRegisterDynamic()
            GVAdmission.DataSource = dt
            GVAdmission.DataBind()
            If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            Else
                DDLBranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            End If
        End If

    End Sub
    Sub CheckAll()
        If CType(GVAdmission.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVAdmission.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
                btnAdmission.Focus()
            Next
        Else
            For Each grid As GridViewRow In GVAdmission.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Protected Sub btnAdmission_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdmission.Click
        Dim QS As String
        QS = Request.QueryString.Get("QS")
        Dim id As String = ""
        Dim check As String = ""
        Dim count As New Integer
        count = GVAdmission.Rows.Count
        Dim i As Integer = 0
        For Each grid As GridViewRow In GVAdmission.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                check = "[" + CType(grid.FindControl("lblModule"), Label).Text.ToString + "]"
                id = id + "," + check
            End If
        Next
        If id <> "" Then
            lblError.Text = ""
            id = Right(id, id.Length - 1)
            Dim qrystring As String = "RptDynamicReport.aspx?" & QueryStr.Querystring() & "&id=" & id & "&Branch=" & DDLBranch.SelectedValue & "&Batch=" & DDLBatch.SelectedValue & "&Course=" & DDLCourse.SelectedValue & "&Gender=" & DDLGender.SelectedItem.Text & "&State=" & DDLState.SelectedValue & "&Feecollected=" & ddlFeecollected.SelectedValue & "&CountryId=" & DDLCountry.SelectedValue
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Else
            lblError.Text = " Select atleast one column name."
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Default2.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
