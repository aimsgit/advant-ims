Imports StudentResult
Imports System.SerializableAttribute
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
'Imports Student_ResultrptB

Partial Class frmStudentResultDetails
    Inherits BasePage
    Dim dt As New DataTable
    Dim smarks As String
    Dim alt As String
    Dim Bll As New StdResultB
    Dim Prop As New StudentResultP
    Dim BAL As New CourseManager
    Dim GlobalFunction As New GlobalFunction
    Dim shdtls As Boolean
    Dim BL As New SemesterManager
    Protected Function GetBatchNo(ByVal id As Long) As String
        Dim BN As New BatchB
        Dim B As BatchCombo = BN.BatchComboCourseplanner(id)
        Return B.BatchNo
    End Function
    'Sub FillSubject()
    '    Try
    '        If txtBatch.Text <> "" Then
    '            Dim Subject As New SubjectManager
    '            ddlSubject.DataSource = Subject.GetBatchWiseSubject(GlobalFunction.IdCutter(txtBatch.Text))
    '            ddlSubject.DataBind()
    '        End If
    '    Catch
    '        lblErrorMsg.Text = "Please select Academic Year."
    '    End Try
    'End Sub
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    lblErrorMsg.Text = ""
    '    txtCourse.Focus()
    '    If Not IsPostBack Then
    '        GVStudentResult.Visible = False
    '        ddlSemester.DataSource = BL.GetFullSemester
    '        ddlSemester.DataBind()
    '        ddlAssessment.DataSource = BL.GetAssessmentCombo()
    '        ddlAssessment.DataBind()
    '        'ddlSemester.DataSource = Bll.GetSemesterTyp1
    '        'ddlSemester.DataBind()
    '        'ddlAssessment.DataSource = Bll.GetAssessmentTyp2
    '        'ddlAssessment.DataBind()
    '    End If
    '    shdtls = False
    '    'ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & ddlInstitute.ClientID & "').focus();</script>")
    'End Sub
    'Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
    '    Try
    '        Session("sesInstitute") = Session("InstituteID")
    '        Session("sesbranch") = Session("BranchID")
    '        If txtCourse.Text <> "" Then
    '            Session("sesCourse") = GlobalFunction.IdCutter(txtCourse.Text)
    '        End If
    '    Catch
    '        txtCourse.Text = "Not a valid option.Try again."
    '        txtCourse.ForeColor = Drawing.Color.Red
    '    End Try
    'End Sub
    'Sub DisplayGridValue()
    '    If ddlSubject.SelectedValue.ToString = "" Then
    '        'AlertEnterAllFields("Enter all the correct data.")
    '        lblErrorMsg.Text = "Enter all the correct data."
    '    Else
    '        Prop.InstituteId = Session("InstituteID")
    '        Prop.BranchId = Session("BranchID")
    '        Prop.BatchNo = GlobalFunction.IdCutter(txtBatch.Text)
    '        Prop.Subjectid = ddlSubject.SelectedItem.Value
    '        Prop.SemesterId = ddlSemester.SelectedItem.Value
    '        Prop.CourseId = GlobalFunction.IdCutter(txtCourse.Text)
    '        Prop.AssessmentId = ddlAssessment.SelectedItem.Value
    '        dt = Bll.FillGrid(Prop)
    '        If dt.Rows.Count = 0 Then
    '            GVStudentResult.DataSource = Nothing
    '            GVStudentResult.DataBind()
    '            lblErrorMsg.Text = "No Records Found"
    '        Else
    '            GVStudentResult.DataSource = dt.DefaultView
    '            GVStudentResult.DataBind()
    '        End If
    '    End If
    'End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Session("GStatus") = ""
        Response.Redirect("Report.aspx")
    End Sub
    'Protected Sub ShwStdDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShwStdDetails.Click
    '    shdtls = True
    '    GVStudentResult.Visible = True
    '    DisplayGridValue()
    'End Sub

    'Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
    '    GVStudentResult.Visible = False
    'End Sub
    'Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged
    '    GVStudentResult.Visible = False
    'End Sub
    'Protected Sub GVStudentResult_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GVStudentResult.RowCancelingEdit
    '    shdtls = True
    '    GVStudentResult.EditIndex = -1
    '    DisplayGridValue()
    '    txtCourse.Enabled = True
    '    txtBatch.Enabled = True
    '    ddlSemester.Enabled = True
    '    ddlSubject.Enabled = True
    '    ddlAssessment.Enabled = True
    '    ShwStdDetails.Enabled = True
    '    btnAdd.Enabled = True
    '    btnReport.Enabled = True
    '    btnRecover.Enabled = True
    '    GVStudentResult.Columns(1).Visible = True
    'End Sub
    'Protected Sub GVStudentResult_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVStudentResult.RowDeleting
    '    shdtls = True
    '    If GVStudentResult.EditIndex <> -1 Then
    '        'AlertEnterAllFields("First Cancel Edit.")
    '        lblErrorMsg.Text = "First Cancel Edit."
    '    Else
    '        Dim i As Int64 = CType(GVStudentResult.Rows(e.RowIndex).Cells(2).FindControl("RID"), HiddenField).Value
    '        Bll.UpdateDel(i)
    '        DisplayGridValue()
    '    End If
    'End Sub

    'Protected Sub GVStudentResult_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVStudentResult.RowEditing
    '    shdtls = True
    '    GVStudentResult.EditIndex = e.NewEditIndex
    '    DisplayGridValue()
    '    txtCourse.Enabled = False
    '    txtBatch.Enabled = False
    '    ddlSemester.Enabled = False
    '    ddlSubject.Enabled = False
    '    ddlAssessment.Enabled = False
    '    ShwStdDetails.Enabled = False
    '    btnAdd.Enabled = False
    '    btnReport.Enabled = False
    '    btnRecover.Enabled = False
    '    GVStudentResult.Columns(1).Visible = False
    'End Sub

    'Protected Sub GVStudentResult_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVStudentResult.RowUpdating
    '    Dim i As Integer = CType(GVStudentResult.Rows(e.RowIndex).Cells(2).FindControl("RID"), HiddenField).Value
    '    Dim stdid As Integer = CType(GVStudentResult.Rows(e.RowIndex).Cells(2).FindControl("SID"), HiddenField).Value
    '    Dim txtMarks As TextBox = CType(GVStudentResult.Rows(e.RowIndex).Cells(4).FindControl("txtMarks"), TextBox)
    '    Dim MaxMarks As TextBox = CType(GVStudentResult.Rows(e.RowIndex).Cells(4).FindControl("MaxMarks"), TextBox)
    '    Dim txtskill As TextBox = CType(GVStudentResult.Rows(e.RowIndex).Cells(5).FindControl("txtSkill"), TextBox)
    '    shdtls = True
    '    Prop.ReusltId = i
    '    Prop.StdCode = stdid
    '    Prop.marks = txtMarks.Text
    '    Prop.Skill = txtskill.Text
    '    If (CInt(txtMarks.Text) > CInt(MaxMarks.Text)) Then
    '        lblErrorMsg.Text = "Marks Obtained Should be lesser than Max Marks"
    '        Exit Sub
    '    End If
    '    Bll.Update(Prop)

    '    GVStudentResult.EditIndex = -1
    '    DisplayGridValue()

    '    btnAdd.Enabled = True
    '    btnReport.Enabled = True
    '    btnRecover.Enabled = True
    '    GVStudentResult.Columns(1).Visible = True
    '    Canceldisable()
    'End Sub
    'Sub Canceldisable()
    '    txtCourse.Enabled = True
    '    txtBatch.Enabled = True
    '    ddlSemester.Enabled = True
    '    ddlSubject.Enabled = True
    '    ddlAssessment.Enabled = True
    '    ShwStdDetails.Enabled = True
    '    btnAdd.Enabled = True
    '    btnReport.Enabled = True
    '    btnRecover.Enabled = True
    'End Sub

    'Protected Sub btnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecover.Click
    '    Session("RecoverForm") = "StudentResult"
    '    Response.Redirect("recover.aspx")
    'End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
       
        Dim course As String=txtCourseName.SelectedItem.Text
        Dim Branch As String = txtBranchName.SelectedValue
        Dim CourseId As Integer = txtCourseName.SelectedValue
        'Dim AYear As Integer = ddlA_Year.SelectedValue
        Dim Subjectid As Integer = ddlsubject.SelectedItem.Value
        Dim SemesterId As Integer = ddlSemester.SelectedItem.Value
        Dim BatchNo As Integer = ddlbatch.SelectedValue
        Dim AssessmentId As Integer = ddlassesment.SelectedItem.Value
        Dim ClassType As Integer = ddlclass.SelectedValue
        Dim SortBy As Integer = ddlSort.SelectedValue

        'If txtCourseName.SelectedItem.Text = "Select" Or txtBranchName.SelectedItem.Text = "Select" Or ddlsubject.SelectedItem.Text = "Select" Or ddlSemester.SelectedItem.Value = "Select" Or ddlbatch.SelectedItem.Text = "Select" Or ddlassesment.SelectedItem.Text = "Select" Or ddlclass.SelectedItem.Text = "Select" Then
        '    lblErrorMsg.Text = "Please enter all Mandatory Fields."
        'Else
        lblErrorMsg.Text = " "
        Dim qrystring As String = "rptStudentResult.aspx?" & QueryStr.Querystring() & "&course=" & course & "&Branch=" & Branch & "&CourseId=" & CourseId & "&Subjectid=" & Subjectid & "&SemesterId=" & SemesterId & "&BatchNo=" & BatchNo & "&AssessmentId=" & AssessmentId & "&ClassType=" & ClassType & "&SortBy=" & SortBy
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        'End If




        ''Prop.UserId = HttpContext.Current.Session("UserID")
        ''dt = BLL.GetDataByrptStdResult(Prop)
        ''If dt.Rows.Count <> 0 Then
        'Dim sb As New StringBuilder
        'Dim objData As String = ""
        'Dim bf As New BinaryFormatter
        'Dim m As New MemoryStream
        'bf.Serialize(m, Prop)
        'Dim data() As Byte = m.ToArray
        'Dim str As String = System.Text.Encoding.Default.GetString(data)
        'objData = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(str))
        'sb.AppendFormat("rptStudentResult.aspx?" & QueryStr.Querystring() & "&Prop={0}", Server.UrlEncode(objData))
        ''Response.Redirect(sb.ToString())
        'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & sb.ToString()
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        ''Else
        ' ''AlertEnterAllFields("No Records")
        ''lblErrorMsg.Text = "No Records"
        ''End If
    End Sub
    'Protected Sub AutoCompleteExtender1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender1.PreRender
    '    If shdtls = False Then
    '        FillSubject()
    '    End If
    'End Sub
    Sub AlertEnterAllFields(ByVal Str As String)
        alt = "alert('" & Str & "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alt, True)
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            txtBranchName.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If

    End Sub
End Class
