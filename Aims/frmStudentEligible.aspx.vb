Partial Class frmStudentEligible

    Inherits BasePage
    Dim BLL As New StdResultB
    Dim GlobalFunction As New GlobalFunction
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Dt As New Data.DataTable
        Dim Cour, Btch, qrystring As String

        If txtCourse.Text <> "" Then
            Cour = GlobalFunction.IdCutter(txtCourse.Text)
        Else
            Cour = 0
        End If
        If txtBatch.Text <> "" Then
            Btch = GlobalFunction.IdCutter(txtBatch.Text)
        Else
            Btch = 0
        End If
        Dt = BLL.GetStdEligibleRpt(HttpContext.Current.Session("InstituteID"), HttpContext.Current.Session("BranchID"), Cour, Btch)
        qrystring = "rptStudentEligibleV.aspx?" & QueryStr.Querystring() & "&BatchNo=" & Btch & "&crs=" & Cour
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub

    Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
        Try
            Session("sesInstitute") = HttpContext.Current.Session("InstituteID")
            Session("sesbranch") = HttpContext.Current.Session("BranchID")
            If txtCourse.Text <> "" Then
                Session("sesCourse") = GlobalFunction.IdCutter(txtCourse.Text)
            End If
        Catch
            txtCourse.Text = "Not a valid option.Try again."
            txtCourse.ForeColor = Drawing.Color.Red
        End Try
    End Sub


    'Protected Sub FillBatchNo()
    '    Dim value As Long = 0
    '    If txtCourse.Text <> "" Then
    '        If txtCourse.Text = "" Then
    '            value = 0
    '        Else
    '            value = ddlCourse.SelectedItem.Value
    '        End If
    '        Dim batch As New BatchB
    '        ddlBatch.DataSource = batch.BatchComboDT(ddlBranch.SelectedItem.Value, ddlInstitute.SelectedItem.Value, value)
    '        ddlBatch.DataBind()
    '    End If
    'End Sub
    'Protected Sub FillBatchNo()
    '    Dim value As Long = 0
    '    If ddlCourse.Items.Count <> 0 Then
    '        If ddlCourse.SelectedItem.Value = "" Then
    '            value = 0
    '        Else
    '            value = ddlCourse.SelectedItem.Value
    '        End If
    '        Dim BatchVal As New GlobalDataSetTableAdapters.CoursePlannerTableAdapter
    '        ddlBatch.DataSource = BatchVal.GetBatchData(ddlBranch.SelectedItem.Value, ddlInstitute.SelectedItem.Value, value)
    '        ddlBatch.DataBind()
    '    End If
    'End Sub
    'Sub course()
    '    If ddlInstitute.Items.Count > 0 And ddlBranch.Items.Count > 0 Then
    '        Dim dt As DataTable
    '        Dim BAL As New CoursePlanner
    '        dt = BAL.getSelectCourse(ddlBranch.SelectedItem.Value, ddlInstitute.SelectedItem.Value)
    '        If dt.Rows.Count = 0 Then
    '            'ddlCourse.DataSource = ""
    '            'ddlCourse.DataBind()
    '            'ddlBatch.DataSource = ""
    '            'ddlBatch.DataBind()
    '        Else
    '            'ddlCourse.DataSource = dt
    '            'ddlCourse.DataBind()
    '            'FillBatchNo()
    '        End If
    '    End If
    'End Sub
    Sub Alert(ByVal str As String)
        Dim alert As String = "alert('" & str & "');" '
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alert, True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")
    End Sub

    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
