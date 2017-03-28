Imports System.Data
Imports System.IO
Imports System.Data.OleDb

Partial Class frmNoDuesDetls
    Inherits BasePage
    Dim BAL As New CoursePlanner
    Dim BL As New BLNoDue
    Dim ND As New EntNoDue.EntNoDue
    Dim alt, Inst, Bran As String
    Dim GlobalFunction As New GlobalFunction
    'Protected Sub ddlInstitute_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlInstitute.SelectedIndexChanged
    '    course()
    'End Sub
    'Protected Sub ddlBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.SelectedIndexChanged
    '    course()
    '    FillStdCode()
    'End Sub
    'Protected Sub ddlBranch_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.DataBound
    '    course()
    'End Sub
    'Sub course()
    '    If ddlInstitute.Items.Count > 0 And ddlBranch.Items.Count > 0 Then
    '        Dim dt As DataTable
    '        dt = BAL.getSelectCourse(ddlBranch.SelectedItem.Value, ddlInstitute.SelectedItem.Value)
    '        If dt.Rows.Count = 0 Then
    '            ddlCourse.DataSource = ""
    '            ddlCourse.DataBind()
    '            ddlBatch.DataSource = ""
    '            ddlBatch.DataBind()
    '        Else
    '            ddlCourse.DataSource = dt
    '            ddlCourse.DataBind()
    '            FillBatchNo()
    '        End If
    '    End If
    'End Sub
    'Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
    '    FillBatchNo()
    'End Sub
    'Protected Sub FillBatchNo()
    '    If ddlCourse.Items.Count <> 0 Then
    '        Dim BatchVal As New GlobalDataSetTableAdapters.CoursePlannerTableAdapter
    '        ddlBatch.DataSource = BatchVal.GetBatchData(ddlCourse.SelectedItem.Value, ddlInstitute.SelectedItem.Value, ddlBranch.SelectedItem.Value)
    '        ddlBatch.DataBind()
    '        FillStdCode()
    '    End If
    'End Sub
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

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim id As Int64
        If txtCourse.Text <> "" And txtBatch.Text <> "" And ddldept.Items.Count > 0 And txtStdCode.Text <> "" Then
            If btnsave.Text = "SAVE" Then
                'ND.Institute = ddlInstitute.SelectedItem.Value
                'ND.Branch = ddlBranch.SelectedItem.Value
                ND.Course = GlobalFunction.IdCutter(txtCourse.Text)
                ND.BatchNo = GlobalFunction.IdCutter(txtBatch.Text)
                ND.DeptId = ddldept.SelectedItem.Value
                ND.StdId = GlobalFunction.IdCutter(txtStdCode.Text)
                ND.Performance = ddlPerformance.SelectedItem.Value
                ND.Remarks = txtRemark.Text
                id = BL.InsertRecord(ND)
                clear()
                msginfo.Text = "The information is saved."
            ElseIf btnsave.Text = "UPDATE" Then
                ND.DueId = txtid.Text
                'ND.Institute = ddlInstitute.SelectedItem.Value
                'ND.Branch = ddlBranch.SelectedItem.Value
                ND.Course = GlobalFunction.IdCutter(txtCourse.Text)
                ND.BatchNo = GlobalFunction.IdCutter(txtBatch.Text)
                ND.DeptId = ddldept.SelectedItem.Value
                ND.StdId = GlobalFunction.IdCutter(txtStdCode.Text)
                ND.Performance = ddlPerformance.SelectedItem.Value
                ND.Remarks = txtRemark.Text
                BL.Update(ND)
                GVNoDue.DataBind()
                btnsave.Text = "SAVE"
                btndetails.Text = "DETAILS"
                btnrecover.Visible = True
                btnreport.Visible = True
                clear()
                msginfo.Text = "The record is successfully updated."
            End If
        Else
            alt = "<script language='javascript'>" + "alert('Select all the required fields.');" + "</script>"
            ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
        End If
    End Sub
    'Sub FillStdCode()
    '    Try
    '        
    '        If txtCourse.Text <> "" And txtBatch.Text <> "" Then
    '            Dim Bal As New StudentResult.StdResultB
    '            Dim Dt As Data.DataTable
    '            Dt = Bal.GetStdCode(ddlInstitute.SelectedItem.Value, ddlBranch.SelectedItem.Value, Mid(txtCourse.Text, 1, InStr(txtCourse.Text, "COURE:") - 2), Mid(txtBatch.Text, 1, InStr(txtBatch.Text, "BN:") - 2))
    '            If Dt.Rows.Count = 0 Then
    '                ddlName.DataSource = ""
    '                ddlName.DataBind()
    '            Else
    '                ddlName.DataSource = Dt
    '                ddlName.DataBind()
    '            End If
    '        End If
    '    Catch
    '        txtBatch.Text = "Not a valid option.Try again."
    '        txtBatch.ForeColor = Drawing.Color.Red
    '    End Try

    'End Sub
    'Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
    '    FillStdCode()
    'End Sub
    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        If Me.btndetails.Text = "DETAILS" Then
            Dim std As Integer = 0
            Dim course As Integer = 0
            Dim batch As Integer = 0
            Inst = HttpContext.Current.Session("InstituteID")
            Bran = HttpContext.Current.Session("BranchID")
            If txtStdCode.Text = Nothing Then
                std = 0
            Else
                std = GlobalFunction.IdCutter(txtStdCode.Text)
            End If

            If txtCourse.Text = Nothing Then
                course = 0
            Else
                course = GlobalFunction.IdCutter(txtCourse.Text)
            End If

            If txtBatch.Text = Nothing Then
                batch = 0
            Else
                batch = GlobalFunction.IdCutter(txtBatch.Text)
            End If
            Dim DL As New GlobalDataSetTableAdapters.DLNoDue
            Dim dt As New DataTable
            dt.Clear()
            dt = DL.GetReportNoDueData(Inst, course, batch, std)
            GVNoDue.DataSource = dt
            Dim count As Int16 = dt.Rows.Count
            GVNoDue.DataBind()
            GVNoDue.Visible = True
            clear()
        Else
            btndetails.Text = "DETAILS"
            btnsave.Text = "SAVE"
            btnrecover.Visible = True
            btnreport.Visible = True
            clear()
        End If



        'Try
        '    If Me.btndetails.Text = "DETAILS" Then
        '        Dim dt As New DataTable
        '        Dim batch As String = GlobalFunction.IdCutter(txtBatch.Text)
        '        'Dim inst As Integer = ddlInstitute.SelectedValue
        '        'Dim branch As Integer = ddlBranch.SelectedValue
        '        Dim cource As Integer = GlobalFunction.IdCutter(txtCourse.Text)
        '        dt = BL.GetData(batch, cource)
        '        GVNoDue.DataSource = dt
        '        Dim count As Int16 = dt.Rows.Count
        '        GVNoDue.DataBind()
        '        GVNoDue.Visible = True
        '        clear()
        '    Else
        '        btndetails.Text = "DETAILS"
        '        btnsave.Text = "SAVE"
        '        btnrecover.Visible = True
        '        btnreport.Visible = True
        '        clear()
        '    End If
        '    txtCourse.Enabled = True
        '    txtBatch.Enabled = True
        '    'txtStdCode.Enabled = True
        'Catch
        '    txtBatch.Text = "Not a valid option.Try again."
        '    txtBatch.ForeColor = Drawing.Color.Red
        'End Try

    End Sub
    Protected Function GetDeptName(ByVal id As Long) As String
        Dim Dept As New DepartmentManager
        'Dim d As Department = Dept.GetDepartmentByDepartmentId(id)
        'Return d.Name
    End Function
    'Protected Function GetStdCode(ByVal id As Long) As String
    '    Dim std As New StudentManager
    '    Dim s As Student = std.GetStudentsById(id)
    '    Return s.Code
    'End Function
    Protected Sub GVNoDue_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVNoDue.RowEditing
        GVNoDue.Visible = False
        If btnsave.Text = "SAVE" Then
            btnsave.Text = "UPDATE"
            btnsave.CommandName = "UPDATE"
            btndetails.Text = "CANCEL"
            btndetails.CommandName = "CANCEL"
            btnrecover.Visible = False
            btnreport.Visible = False
            txtid.Text = CType(GVNoDue.Rows(e.NewEditIndex).Cells(1).FindControl("Due_ID"), HiddenField).Value
            'ddlInstitute.SelectedValue = CType(GVNoDue.Rows(e.NewEditIndex).Cells(1).FindControl("Ins_ID"), HiddenField).Value
            'ddlBranch.SelectedValue = CType(GVNoDue.Rows(e.NewEditIndex).Cells(1).FindControl("Br_ID"), HiddenField).Value

            txtCourse.Enabled = False
            txtBatch.Enabled = False
            ddldept.SelectedItem.Value = CType(GVNoDue.Rows(e.NewEditIndex).Cells(1).FindControl("dpt"), HiddenField).Value
            'txtStdCode.Enabled = False
            txtStdCode.Text = CType(GVNoDue.Rows(e.NewEditIndex).Cells(2).FindControl("stdid"), HiddenField).Value + ":" + CType(GVNoDue.Rows(e.NewEditIndex).Cells(2).FindControl("Label5"), Label).Text
            ' ddlName.SelectedItem.Value = CType(GVNoDue.Rows(e.NewEditIndex).Cells(2).FindControl("stdid"), HiddenField).Value
            ddlPerformance.SelectedValue = CType(GVNoDue.Rows(e.NewEditIndex).Cells(3).FindControl("Label2"), Label).Text
            txtRemark.Text = CType(GVNoDue.Rows(e.NewEditIndex).Cells(4).FindControl("Label3"), Label).Text
        End If
    End Sub
    Protected Sub GVNoDue_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GVNoDue.RowUpdated
        GVNoDue.DataBind()
    End Sub
    Sub clear()
        txtRemark.Text = ""
    End Sub
    Protected Sub GVNoDue_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVNoDue.RowDeleting
        Dim id As HiddenField = CType(GVNoDue.Rows(e.RowIndex).Cells(1).FindControl("Due_ID"), HiddenField)
        Dim RowsAffected As Integer = BL.delete(id.Value)
        btndetails_Click(sender, e)
        msginfo.Text = "The record is deleted."
        'Dim Status As BooleanDim 
        'Status = globalcnn.Del_Validation(id.Value, "NoDue")
        'If (Status) = True Then
        '    alt = "<script language='javascript'>" + "alert('Record is already used.');" + "</script>"
        '    ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
        'End If
    End Sub
    Protected Sub btnrecover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrecover.Click
        Session("RecoverForm") = "NoDues"
        Response.Redirect("recover.aspx")
    End Sub
    Protected Sub btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreport.Click
        'If ddlInstitute.Items.Count > 0 And ddlBranch.Items.Count > 0 Then
        Dim std As Integer = 0
        Dim course As Integer = 0
        Dim batch As Integer = 0
        Inst = HttpContext.Current.Session("InstituteID")
        Bran = HttpContext.Current.Session("BranchID")
        If txtStdCode.Text = Nothing Then
            std = 0
        Else
            std = GlobalFunction.IdCutter(txtStdCode.Text)
        End If

        If txtCourse.Text = Nothing Then
            course = 0
        Else
            course = GlobalFunction.IdCutter(txtCourse.Text)
        End If

        If txtBatch.Text = Nothing Then
            batch = 0
        Else
            batch = GlobalFunction.IdCutter(txtBatch.Text)
        End If


        'Response.Redirect("RptNoDue.aspx?Insti=" & Inst & "&Branch=" & Bran & "&std=" & std)
        Dim qrystring As String = "RptNoDue.aspx?" & QueryStr.Querystring() & "&std=" & std & "&course=" & course & "&batch=" & batch
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        'End If
        'arParms(0) = New SqlParameter("@institute", SqlDbType.Int)
        'arParms(0).Value = HttpContext.Current.Session("InstituteID")

        'arParms(1) = New SqlParameter("@branch", SqlDbType.Int)
        'arParms(1).Value = HttpContext.Current.Session("BranchID")

    End Sub

    Protected Sub AutoCompleteExtender1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender1.PreRender
        Try
            If txtBatch.Text <> "" Then
                Session("sesBatch") = GlobalFunction.IdCutter(txtBatch.Text)
            End If
        Catch
            txtBatch.Text = "Not a valid option.Try again."
            txtBatch.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim BLL As New DepartmentManager
            'ddldept.DataSource = BLL.GetDepartment
            ddldept.DataBind()
        End If
    End Sub
End Class