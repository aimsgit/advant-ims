Partial Class frmCertificareIssued
    Inherits BasePage
    'Dim da, da1 As New OleDbDataAdapter
    '  Dim dt, dt1 As New DataTable
    Dim alt As String
    Dim el As New CertificateIssuedE()
    Dim bl As New CertificateIssuedB
    Dim GlobalFunction As New GlobalFunction
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        new_dbconn1.ConnectionString = Application("Strcontent")
        ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")
        If Not IsPostBack Then
            GVCIssue.Visible = False
            'txtIDate.Text = Date.Today.ToString("dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        el.Institute_ID = HttpContext.Current.Session("InstituteID")
        el.Branch_ID = HttpContext.Current.Session("BranchID")
        el.Course_ID = GlobalFunction.IdCutter(txtCourse.Text)
        el.Batch_No = GlobalFunction.IdCutter(txtBatch.Text)
        el.Certificate_ID = cmbCertificate.SelectedValue
        el.StdID = ddlCode.SelectedValue
        el.IssueDate = txtIDate.Text
        el.Certificate_No = txtno.Text
        Dim rowsaffected As Int16 = 0
        rowsaffected = bl.InserCertificateDetails(el)
        'new_dbconn1.Open()
        'sql = "Select StdId,StdCode from StudentMaster where Del_Flag=0 and StdCode='" + ddlCode.SelectedItem.Value + "'"
        'da = New OleDbDataAdapter(sql, new_dbconn1)
        'da.Fill(dt)
        'sql1 = "Insert into CertificateIssued(Institute_Id,Branch_Id,Course_Id,Batch_No,Certificate_Id,StdId,"
        'IssueDate,Certificate_No) values( " + ddlInstitute.SelectedItem.Value + "," + ddlBranch.SelectedItem.Value + "," 
        '+ ddlCourse.SelectedItem.Value + "," + ddlBatch.SelectedItem.Value + "," + cmbCertificate.SelectedItem.Value + "," 
        '+ ddlCode.SelectedItem.Value + ",'" + txtIDate.Text + "','" + txtno.Text + "')"
        'SqlDataSource1.InsertCommand = sql1
        'SqlDataSource1.Insert()
        'alt = "<script language='javascript'>" + "alert('The information is saved successfully.');" + "</script>"
        'ClientScript.RegisterStartupScript(Me.GetType(), "alert", alt)
        If rowsaffected <> 0 Then
            MsgInfo.Text = "Data Saved SuccessFully."
            MsgInfo.Visible = True
        End If
        ddlCode.SelectedItem.Selected = False
        txtIDate.Text = ""
        txtno.Text = ""
        cmbCertificate.SelectedItem.Selected = False
        btnDetails_Click(sender, e)
        'GVCIssue.DataBind()
        FillStdCode()
        'DispGrid()
    End Sub

    Protected Sub GVCIssue_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GVCIssue.RowCancelingEdit
        ' DispGrid()
        btnReport.Enabled = True
        txtCourse.Enabled = True
        txtBatch.Enabled = True
        ddlCode.Enabled = True
        txtIDate.Enabled = True
        txtno.Enabled = True
        cmbCertificate.Enabled = True
        btnSave.Enabled = True
        GVCIssue.Columns(1).Visible = True
        MsgInfo.Visible = False
    End Sub

    Protected Sub GVCIssue_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVCIssue.RowDeleting
        btnDetails_Click(sender, e)
    End Sub

    Protected Sub GVCIssue_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVCIssue.RowEditing
        ' DispGrid()
        GVCIssue.Columns(1).Visible = False
        GVCIssue.EditIndex = e.NewEditIndex
        btnReport.Enabled = True
        btnSave.Enabled = False
        txtCourse.Enabled = False
        txtBatch.Enabled = False
        ddlCode.Enabled = False
        txtIDate.Enabled = False
        txtno.Enabled = False
        cmbCertificate.Enabled = False
        MsgInfo.Text = "Edit data and click on Update button to update."
        MsgInfo.Visible = True
    End Sub

    Protected Sub ObjGrid_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjGrid.Selecting
        e.InputParameters("ins") = HttpContext.Current.Session("InstituteID")
        e.InputParameters("brn") = HttpContext.Current.Session("BranchID")
        If txtCourse.Text <> "" Then
            e.InputParameters("crs") = GlobalFunction.IdCutter(txtCourse.Text)
        Else
            e.InputParameters("crs") = 0
        End If
        If txtBatch.Text <> "" Then
            e.InputParameters("btch") = GlobalFunction.IdCutter(txtBatch.Text)
        Else
            e.InputParameters("btch") = 0
        End If
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        GVCIssue.DataSourceID = "ObjGrid"
        GVCIssue.DataBind()
        GVCIssue.Visible = True
        MsgInfo.Visible = False
    End Sub

    Sub DispGrid()
        'Dim bl As New CertificateIssuedB
        'GVCIssue.Visible = True
        'Dim dt As New DataTable
        'If ddlCourse.Items.Count <> 0 And ddlBatch.Items.Count <> 0 Then
        '    dt = bl.fillGridViewCertificateDetails(ddlInstitute.SelectedItem.Value, ddlBranch.SelectedItem.Value, ddlCourse.SelectedItem.Value, ddlBatch.SelectedItem.Value)
        '    GVCIssue.DataSource = dt
        '    GVCIssue.DataBind()
        'End If
        'GVCIssue.Visible = True
        'If ddlCourse.Items.Count <> 0 And ddlBatch.Items.Count <> 0 Then
        '    SqlDataSource2.SelectCommand = "Select *  from DispGV_CertificateIssued where Del_Flag=0 and 
        ' Course_Id = " + ddlCourse.SelectedItem.Value + " And Branch_Id = " + ddlBranch.SelectedItem.Value + "
        'And Institute_Id = " + ddlInstitute.SelectedItem.Value + " And Batch_No = " + ddlBatch.SelectedItem.Value + """
        '    GVCIssue.DataBind()
        '    GVCIssue.Visible = True
        'End If
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        'If HttpContext.Current.Session("InstituteID") <> Nothing And HttpContext.Current.Session("BranchID") <> Nothing And GlobalFunction.IdCutter(txtCourse.Text) > 0 And GlobalFunction.IdCutter(txtBatch.Text) > 0 Then
        Dim Rdt As New DataTable
        Dim dll As New CertificateIssuedB
        Dim Cour, Brch, Inst, Btch As String
        If txtCourse.Text <> "" Then
            Cour = GlobalFunction.IdCutter(txtCourse.Text)
        Else
            Cour = 0
        End If
        Brch = HttpContext.Current.Session("BranchID")
        Inst = HttpContext.Current.Session("InstituteID")
        If txtBatch.Text <> "" Then
            Btch = GlobalFunction.IdCutter(txtBatch.Text)
        Else
            Btch = 0
        End If
        Rdt = dll.Report(Inst, Brch, Cour, Btch)
        If Rdt.Rows.Count = 0 Then
            msginfo.Text = "No Records Found."
        Else
            'Response.Redirect("frmCertificateIssuedV.aspx?Course=" & Cour & "&Branch=" & Brch & "&Insti=" & Inst & "&Batch=" & Btch)
            Dim qrystring As String = "frmCertificateIssuedV.aspx?" & QueryStr.Querystring() & "&Course=" & Cour & "&Batch=" & Btch
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
        ' Else

        ' End If
    End Sub

    Protected Sub GVCIssue_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GVCIssue.RowUpdated
        GVCIssue.DataBind()
        'DispGrid()
        btnReport.Enabled = True
        btnSave.Enabled = True
        txtCourse.Enabled = True
        txtBatch.Enabled = True
        ddlCode.Enabled = True
        txtIDate.Enabled = True
        txtno.Enabled = True
        cmbCertificate.Enabled = True
        GVCIssue.Columns(1).Visible = True
        txtIDate.Text = Date.Today.ToString("dd-MMM-yyyy")
        MsgInfo.Text = "Data Updated SuccessFully."
        MsgInfo.Visible = True
    End Sub

    'Protected Sub ddlCourse_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.DataBound
    '    ' FillBatchNo()
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
    'Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
    '    ' FillBatchNo()
    '    Session("sesInstitute") = ddlInstitute.SelectedItem.Value
    '    Session("sesbranch") = ddlBranch.SelectedItem.Value
    '    If txtCourse.Text <> "" Then
    '        Session("sesCourse") = Mid(txtCourse.Text, 1, InStr(txtCourse.Text, "COURE:") - 2)
    '    End If
    '    ' DispGrid()
    'End Sub

    'Sub FillBatchNo()
    '    If ddlCourse.Items.Count <> 0 Then
    '        Dim batch As New BatchB
    '        ddlBatch.DataSource = batch.BatchComboDT(ddlBranch.SelectedItem.Value, ddlInstitute.SelectedItem.Value, ddlCourse.SelectedItem.Value)
    '        ddlBatch.DataBind()
    '    End If
    '    FillStdCode()
    'End Sub

    'Protected Sub ddlBatch_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.DataBound
    '    'FillStdCode()
    'End Sub

    Sub FillStdCode()

        If txtCourse.Text <> "" And cmbCertificate.Items.Count > 0 And txtBatch.Text <> "" Then
            Dim Bal As New StdResultB
            Dim Dt As Data.DataTable
            Dt = Bal.GetStdCode(HttpContext.Current.Session("InstituteID"), HttpContext.Current.Session("BranchID"), GlobalFunction.IdCutter(txtCourse.Text), GlobalFunction.IdCutter(txtBatch.Text))
            If Dt.Rows.Count = 0 Then
                ddlCode.DataSource = ""
                ddlCode.DataBind()
            Else
                ddlCode.DataSource = Dt
                ddlCode.DataBind()
            End If
        End If
    End Sub

    'Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
    '    ' FillStdCode()
    '    DispGrid()
    'End Sub

    'Sub course()
    '    If ddlInstitute.Items.Count > 0 And ddlBranch.Items.Count > 0 Then
    '        Dim obj As New CourseManager
    '        Dim dt As New DataTable
    '        ddlCourse.DataSource = obj.CourseCombo(ddlBranch.SelectedValue, ddlInstitute.SelectedValue)
    '            ddlCourse.DataBind()
    '        'FillBatchNo()
    '        End If
    'End Sub

    'Protected Sub ddlBranch_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.DataBound
    '    'course()
    'End Sub

    'Protected Sub ddlBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.SelectedIndexChanged
    '    course()
    'End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

    End Sub
    'proc_fillComboCertificate

    Protected Sub AutoCompleteExtender1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender1.PreRender
        FillStdCode()
    End Sub
    <System.Web.Services.WebMethod()> _
        Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

End Class

