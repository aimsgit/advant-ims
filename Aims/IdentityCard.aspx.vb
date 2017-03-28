Imports System.Data
Imports System.IO
Partial Class IdentityCard
    Inherits BasePage
    Dim alt As String
    Dim sql, sql1 As String
    Dim Prop As New ICardE
    Dim Bal As New ICardB
    Dim GlobalFunction As New GlobalFunction
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

    Sub comboselect(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim gridv As New GlobalDataSetTableAdapters.IdentityCardTableAdapter
        Try
            Dim stdcount As Integer = 0
            'If txtCourse.Text <> "" And txtBatch.Text <> "" Then
            '    GridView1.DataSource = gridv.gridfill(ddlCourse.SelectedItem.Value, ddlBranch.SelectedItem.Value, ddlInstitute.SelectedItem.Value, ddlBatch.SelectedItem.Value)
            '    GridView1.DataBind()
            If txtCourse.Text <> "" Then
                Prop.Courseid = GlobalFunction.IdCutter(txtCourse.Text)
            Else
                Prop.Courseid = 0
            End If
            Prop.Instituteid = HttpContext.Current.Session("InstituteID")
            Prop.Branchid = HttpContext.Current.Session("BranchID")
            If txtBatch.Text <> "" Then
                Prop.Batchno = GlobalFunction.IdCutter(txtBatch.Text)
            Else
                Prop.Batchno = 0
            End If
            Dim dt As New DataTable
            dt.Clear()
            dt = Bal.FillGrid(Prop)
            stdcount = dt.Rows.Count
            GridView1.DataSource = dt
            GridView1.DataBind()
            'Dim i As Long = 0
            'For Each Row As GridViewRow In GridView1.Rows
            '    Prop.Courseid = Mid(txtCourse.Text, 1, InStr(txtCourse.Text, "COURSE:") - 2)
            '    Prop.Instituteid = ddlInstitute.SelectedItem.Value
            '    Prop.Branchid = ddlBranch.SelectedItem.Value
            '    Prop.Batchno = Mid(txtBatch.Text, 1, InStr(txtBatch.Text, "BN:") - 2)
            '    dt.Clear()
            '    dt = Bal.FillGrid(Prop)
            '    stdcount = dt.Rows.Count
            '    GridView1.DataSource = dt
            '    GridView1.DataBind()

            '    'Dim chkVal As Integer = gridv.gridfill(ddlCourse.SelectedItem.Value, ddlBranch.SelectedItem.Value, ddlInstitute.SelectedItem.Value, ddlBatch.SelectedItem.Value).Rows(i)("IDCard_Issue")
            '    Dim chkVal As Boolean = dt.Rows(i)("IDCard_Issue")
            '    Dim chk As CheckBox = CType(Row.FindControl("ChkIssued"), CheckBox)
            '    If chkVal = False Then
            '        chk.Checked = True
            '    ElseIf chkVal = True Then
            '        chk.Checked = False
            '    End If
            '    i += 1
            'Next
            ' Else
            'AlertEnterAllFields()
            'End If

        Catch ex As Exception
            alt = "<script language='javascript'>" + "alert('Error in process comboselect.');" + "</script>"
        End Try
    End Sub
    Sub gvchanging()
        If btnView.Text = "VIEW" Then
            Me.GridView1.Visible = False
        End If
    End Sub
    Sub FillBatchNo()
        'If ddlCourse.Items.Count <> 0 Then
        '    'Dim BatchVal As New GlobalDataSetTableAdapters.CoursePlannerTableAdapter
        '    ' ddlBatch.DataSource = BatchVal.GetBatchData(ddlCourse.SelectedItem.Value, ddlInstitute.SelectedItem.Value, ddlBranch.SelectedItem.Value)
        '    Dim dt As New Data.DataTable
        '    Prop.Courseid = ddlCourse.SelectedItem.Value
        '    Prop.Instituteid = ddlInstitute.SelectedItem.Value
        '    Prop.Branchid = ddlBranch.SelectedItem.Value
        '    dt = Bal.GetBatchs(Prop)
        '    ddlBatch.DataSource = dt
        '    ddlBatch.DataBind()
        'End If
    End Sub
    Sub disable()
        txtreceiptNo.Visible = False
        txtrecptdate.Visible = False
        txtissdmonth.Visible = False
        txtamount.Visible = False
        lblreceiptNo.Visible = False
        lblrecptdate.Visible = False
        lblissdmonth.Visible = False
        lblamount.Visible = False

    End Sub
    Sub enable()
        Btnsave.Visible = True
        lblreceiptNo.Visible = True
        lblrecptdate.Visible = True
        lblissdmonth.Visible = True
        lblamount.Visible = True
        txtreceiptNo.Visible = True
        txtrecptdate.Visible = True
        txtissdmonth.Visible = True
        txtamount.Visible = True

        Prop.Courseid = GlobalFunction.IdCutter(txtCourse.Text)
        Prop.Instituteid = HttpContext.Current.Session("InstituteID")
        Prop.Branchid = HttpContext.Current.Session("BranchID")
        Prop.Batchno = GlobalFunction.IdCutter(txtBatch.Text)
        Dim dt As New DataTable
        'Dim da As OleDbDataAdapter
        'sql = "Select Receipt_No,Receipt_Date,R_Amount,R_Month from CoursePlanner where Del_Flag=0 and Institute_ID=" + ddlInstitute.SelectedItem.Value + " and Branch_ID=" + ddlBranch.SelectedItem.Value + " and Course_ID=" + ddlCourse.SelectedItem.Value + " and Batch_No='" + ddlBatch.SelectedItem.Value + "'"
        'da = New OleDbDataAdapter(sql, new_dbconn1)
        'dt.Clear()
        'da.Fill(dt)
        dt.Clear()
        dt = Bal.GetRcptDetails(Prop)
        If dt.Rows.Count <> 0 Then
            txtreceiptNo.Text = dt.Rows(0)("Receipt_No").ToString
            If dt.Rows(0)("Receipt_Date").ToString() = "" Then
                txtrecptdate.Text = dt.Rows(0)("Receipt_Date").ToString
            Else
                Dim Rdate As Date
                Rdate = dt.Rows(0)("Receipt_Date").ToString()
                txtrecptdate.Text = Rdate.ToString("dd-MMM-yyyy")
            End If
            'txtrecptdate.Text = dt.Rows(0)("Receipt_Date").ToString
            txtissdmonth.Text = dt.Rows(0)("R_Month").ToString
            txtamount.Text = dt.Rows(0)("R_Amount").ToString
        End If
    End Sub
    Protected Sub BtnDetails_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("IdentityCardIssuedDetails.aspx")
    End Sub
    Protected Sub Btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim rowsAffected As Integer = 0
            ''new_dbconn1.Open()
            ''Dim pmcmd = New OleDbCommand()
            ''pmcmd.Connection = new_dbconn1
            ''sql = "Update CoursePlanner set Receipt_No='" + txtreceiptNo.Text + "',Receipt_Date=#" + txtrecptdate.Text + "#,R_Amount='" + txtamount.Text + "',R_Month='" + txtissdmonth.Text + "'  where Institute_ID=" + ddlInstitute.SelectedItem.Value + " and Branch_ID=" + ddlBranch.SelectedItem.Value + " and Course_ID=" + ddlCourse.SelectedItem.Value + " and ID=" + ddlBatch.SelectedItem.Value + ""
            ''pmcmd.CommandText = sql
            Prop.Receiptno = txtreceiptNo.Text
            Prop.Receiptdate = txtrecptdate.Text
            Prop.amount = txtamount.Text
            Prop.issuedmonth = txtissdmonth.Text
            Prop.Courseid = GlobalFunction.IdCutter(txtCourse.Text)
            Prop.Instituteid = HttpContext.Current.Session("InstituteID")
            Prop.Branchid = HttpContext.Current.Session("BranchID")
            ' ddlBranch.SelectedItem.Value
            Prop.Batchno = GlobalFunction.IdCutter(txtBatch.Text)
            Try
                Dim rows As Integer = Bal.updateStdDetails(Prop)
            Catch ex As Exception
            End Try
            'Try
            '    pmcmd.ExecuteNonQuery()
            'Catch ex As Exception
            '    Response.Write(ex)
            'End Try
            'Dim std As New GlobalDataSetTableAdapters.IdentityCardTableAdapter
            Dim StudentId As String
            'stdcount = std.gridfill(ddlCourse.SelectedItem.Value, ddlBranch.SelectedItem.Value, ddlInstitute.SelectedItem.Value, ddlBatch.SelectedItem.Value).Rows.Count
            Dim stdcount As Int16 = 0
            Dim dt As New DataTable
            dt.Clear()
            dt = Bal.FillGrid(Prop)
            stdcount = dt.Rows.Count
            '' GridView1.DataSource = dt
            '' GridView1.DataBind()
            'Try
            '    If stdcount <> 0 Then
            For Each Row As GridViewRow In GridView1.Rows
                Dim chk As CheckBox = CType(Row.FindControl("ChkIssued"), CheckBox)
                ' StudentId = std.gridfill(Course.SelectedItem.Value, Branch.SelectedItem.Value, Institute.SelectedItem.Value, Batch.SelectedItem.Value).Rows(0)("StdId").ToString
                StudentId = GridView1.DataKeys(Row.RowIndex).Value
                Prop.Stdid = StudentId
                '        Dim cmd As New OleDbCommand
                '        cmd.Connection = new_dbconn1
                rowsAffected = Bal.UpdateICardStatus(Prop, chk.Checked)
                '            sql1 = "Update StudentMaster set IDCard_Issue=-1 where StdId=" & StudentId & " and Institute_ID=" + ddlInstitute.SelectedItem.Value + " and Branch_ID=" + ddlBranch.SelectedItem.Value + " and Course_ID=" + ddlCourse.SelectedItem.Value + " and Batch_No=" + ddlBatch.SelectedItem.Value + ""
                '        Else
                '            sql1 = "Update StudentMaster set IDCard_Issue=0 where StdId=" & StudentId & " and Institute_ID=" + ddlInstitute.SelectedItem.Value + " and Branch_ID=" + ddlBranch.SelectedItem.Value + " and Course_ID=" + ddlCourse.SelectedItem.Value + " and Batch_No=" + ddlBatch.SelectedItem.Value + ""
                '        End If
                '        cmd.CommandText = sql1
                '        cmd.ExecuteNonQuery()
            Next
            alt = "<script language='javascript'>" + "alert('The information is saved successfully.');" + "</script>"
            ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
            ' End If
            ' Catch ex As Exception
            ' End Try
            disable()
            GridView1.Visible = False
            Panel1.Visible = False
            Btnsave.Visible = False
            btnView.Text = "VIEW"
            txtCourse.Enabled = False
            'ddlInstitute.Enabled = True
            'ddlBranch.Enabled = True
            txtCourse.Enabled = True
            txtBatch.Enabled = True
            new_dbconn1.Close()
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
            msginfo.Text = ""
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GridView1.Visible = False
            Panel1.Visible = False
        End If
        ' ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & ddlInstitute.ClientID & "').focus();</script>")

        ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")
        'txtBatch.Attributes.Add("onkeypress", "ShowImage()")
        ' txtBatch.Attributes.Add("onkeypress", "HideImage()")
    End Sub
    Sub course()

        'Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        ' sql = "Select DISTINCT Course_ID,Course from DispCourse_CoursePlanner where Branch_ID=" + ddlBranch.SelectedItem.Value + " and Institute_ID=" + ddlInstitute.SelectedItem.Value + "  Order by Course"
        ' da = New OleDbDataAdapter(sql, new_dbconn1)
        Prop.Instituteid = HttpContext.Current.Session("InstituteID")
        Prop.Branchid = HttpContext.Current.Session("BranchID")
        dt = Bal.GetCourses(Prop)
        'dt.Clear()
        ' da.Fill(dt)
        If dt.Rows.Count = 0 Then
            'ddlCourse.DataSource = ""
            'ddlCourse.DataBind()
            ' ddlBatch.DataSource = ""
            'ddlBatch.DataBind()
        Else
            'ddlCourse.DataSource = dt
            'ddlCourse.DataBind()
            'ddlCourse.DataTextField = dt.Columns("CourseName").ToString
            'ddlCourse.DataValueField = dt.Columns(0)
            'FillBatchNo()
        End If

    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.Text = "CANCEL" Then
            Panel1.Visible = False
            GridView1.Visible = False
            disable()
            btnView.Text = "VIEW"
            Btnsave.Visible = False
            txtCourse.Enabled = True
            txtBatch.Enabled = True
        Else
            ' If txtCourse.Text <> "" And txtBatch.Text <> "" Then
            Panel1.Visible = True
            GridView1.Visible = True
            comboselect(sender, e)
            enable()
            btnView.Text = "CANCEL"
            txtCourse.Enabled = False
            txtBatch.Enabled = False
            ' Else
            'AlertEnterAllFields()
            ' End If
        End If
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        ' If txtBatch.Text <> "" And txtCourse.Text <> "" Then
        Dim BLL As New ICardB
        Dim dt As New DataTable
        Dim Cour, Brch, Inst, Btch As String
        If txtCourse.Text <> "" Then
            Cour = GlobalFunction.IdCutter(txtCourse.Text)
        Else
            Cour = 0
        End If
        Brch = Session("BranchID")
        Inst = Session("InstituteID")
        If txtBatch.Text <> "" Then
            Btch = GlobalFunction.IdCutter(txtBatch.Text)
        Else
            Btch = 0
        End If
        dt = BLL.GetReport(Inst, Brch, Cour, Btch)
        If dt.Rows.Count <> 0 Then
            'Response.Redirect("rptIdentityCard.aspx?Course=" & Cour & "&Branch=" & Brch & "&Insti=" & Inst & "&Batch=" & Btch)
            Dim qrystring As String = "rptIdentityCard.aspx?" & QueryStr.Querystring() & "&Course=" & Cour & "&Batch=" & Btch
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Else
            lblErrorMsg.Text = "No Records Found"
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Identity Card Issue")
    End Sub
    'Protected Sub ddlBranch_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.DataBound
    '    course()
    'End Sub
    'Protected Sub ddlBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.SelectedIndexChanged
    '    course()
    '    GridView1.Visible = False
    'End Sub
    'Protected Sub ddlInstitute_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlInstitute.SelectedIndexChanged
    '    course()
    '    GridView1.Visible = False
    'End Sub

    Sub AlertEnterAllFields()
        alt = "alert('Select all the required fields.');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alt, True)
    End Sub
    Protected Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
        btnView_Click(sender, e)
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        btnView_Click(sender, e)
    End Sub

   
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class





