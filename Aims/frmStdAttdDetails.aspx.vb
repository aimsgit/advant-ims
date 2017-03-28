Imports attendance
Imports System.SerializableAttribute
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Partial Class frmStdAttdDetails
    Inherits BasePage
    Dim sb As New StringBuilder
    Dim BALC As New CoursePlanner
    Dim Dt As New Data.DataTable
    Dim alt As String
    Dim GlobalFunction As New GlobalFunction
    Dim shdtls As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TxtAttdate.Text = Format(Today, "dd-MMM-yyyy")
            cmbMonth.SelectedValue = Today.Month
            txtYear.Text = Today.Year
        End If
        lblmsg.Text = ""
        shdtls = False
        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & ddlCourse.ClientID & "').focus();</script>")
    End Sub
    Sub submit()
        Try
            GVStdAttd.DataSourceID = "objGridView"
            GVStdAttd.DataBind()
            GVStdAttd.Visible = True
        Catch e As exception
        End Try
    End Sub
    'Protected Sub AutoCompleteExtender1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender1.PreRender
    '    Try
    '        If Session("ButtonType") <> "SUBMIT" Then
    '            If Session("ButtonType") = "" Then
    '                If shdtls = False Then
    '                    FillSubject()
    '                    Dim BLL As New SemesterManager
    '                    ddlAssessment.DataSource = BLL.GetAssessmentCombo
    '                    ddlAssessment.DataBind()
    '                End If
    '            End If
    '        End If
    '    Catch
    '        txtBatch.Text = "Not a valid option.Try again."
    '        txtBatch.ForeColor = Drawing.Color.Red
    '    End Try
    'End Sub
    Sub FillSubject()
        Try
            If cmbBatch.Text <> "" Then
                Dim bal As New SubjectManager
                Dim dt As DataTable
                dt = bal.GetBatchWiseSubject(GlobalFunction.IdCutter(cmbBatch.Text))
                cmbSubject.DataSource = dt
                cmbSubject.DataBind()
            End If
        Catch
            lblmsg.Text = "Please select Academic Year."
        End Try
    End Sub
    'Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
    '    Try
    '        Session("sesInstitute") = Session("InstituteID")
    '        Session("sesbranch") = Session("BranchID")
    '        If ddlCourse.Text <> "" Then
    '            Session("sesCourse") = GlobalFunction.IdCutter(ddlCourse.Text)
    '            Session("ButtonType") = ""
    '        End If
    '    Catch
    '        ddlCourse.Text = "Not a valid option.Try again."
    '        ddlCourse.ForeColor = Drawing.Color.Red
    '    End Try
    'End Sub

    Sub disable()
        cmbMonth.Enabled = False
        txtYear.Enabled = False
        TxtAttdate.Enabled = False
        ddlAssessment.Enabled = False
        ddlCourse.Enabled = False
        cmbSubject.Enabled = False
        txtStdCode.Enabled = False
        cmbAssementType.Enabled = False
        cmbBatch.Enabled = False
        RBDateChk.Enabled = False
        RBMonthChk.Enabled = False
        RBSemWiseChk.Enabled = False
        shdtls = True
    End Sub
    Sub enable()
        cmbMonth.Enabled = True
        txtYear.Enabled = True
        TxtAttdate.Enabled = True
        ddlAssessment.Enabled = True
        ddlCourse.Enabled = True
        cmbSubject.Enabled = True
        txtStdCode.Enabled = True
        cmbAssementType.Enabled = True
        cmbBatch.Enabled = True
        RBDateChk.Enabled = True
        RBMonthChk.Enabled = True
        RBSemWiseChk.Enabled = True
        shdtls = True
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Not btnSubmit.Text = "CANCEL" Then
            submit()
            If GVStdAttd.Rows.Count <> 0 Then
                btnSubmit.Text = "CANCEL"
                disable()
            End If
        Else
            btnSubmit.Text = "SUBMIT"
            Session("ButtonType") = "SUBMIT"
            enable()
            GVStdAttd.DataSourceID = ""
            GVStdAttd.DataBind()
        End If
        shdtls = True
        lblmsg.Text = ""
    End Sub
    Protected Sub btnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecover.Click
        If GVStdAttd.EditIndex = -1 Then
            Session("RecoverForm") = "StdAttd"
            Response.Redirect("Recover.aspx")
        End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            If GVStdAttd.EditIndex = -1 Then
                Dim Prop As New StdAttendanceP
                Dim bf As BinaryFormatter
                Dim m As MemoryStream
                Dim objData As String = String.Empty
                Dim data() As Byte
                Dim str As String
                Dim BLL As New StdAttendanceB
                If cmbBatch.Text <> "" And ddlCourse.Text <> "" And cmbSubject.Items.Count > 0 Then
                    Prop.InsId = Session("InstituteID")
                    Prop.BrnId = Session("BranchID")
                    Prop.Batch = GlobalFunction.IdCutter(cmbBatch.Text)

                    If TxtAttdate.Text <> "" Then
                        Prop.Month = Month(TxtAttdate.Text)
                        Prop.Year = Year(TxtAttdate.Text)
                        Prop.AttendanceDate = TxtAttdate.Text
                    Else
                        Prop.Month = cmbMonth.SelectedValue
                        If txtYear.Text = "" Then
                            Prop.Year = 0
                        Else
                            Prop.Year = CInt(txtYear.Text)
                        End If
                        Prop.AttendanceDate = CDate("1/1/0001 12:00:00 AM")
                    End If
                    Prop.UserID = HttpContext.Current.Session("UserID")
                    Prop.Courseid = GlobalFunction.IdCutter(ddlCourse.Text)
                    Prop.SubjectId = cmbSubject.SelectedItem.Value
                    Prop.EmpCode = GlobalFunction.NameCutter(txtStdCode.Text)
                    Prop.SemsterId = cmbAssementType.SelectedItem.Value
                    Prop.Assessment_ID = ddlAssessment.SelectedValue
                    Prop.Id = CInt(RBSemWiseChk.Checked)
                    If BLL.GetStdAttdDetails(Session("InstituteID"), Session("BranchID"), Prop.Courseid, GlobalFunction.IdCutter(cmbBatch.Text), Prop.Month, Prop.SubjectId, Prop.Year, Prop.EmpCode, Prop.SemsterId, Prop.AttendanceDate, Prop.Assessment_ID, RBSemWiseChk.Checked).Rows.Count > 0 Then
                        bf = New BinaryFormatter
                        m = New MemoryStream
                        bf.Serialize(m, Prop)
                        data = m.ToArray
                        str = System.Text.Encoding.Default.GetString(data)
                        objData = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(str))
                        sb.AppendFormat("rptStudentAttendance.aspx?" & QueryStr.Querystring() & "&Prop={0}", Server.UrlEncode(objData))
                        Dim qrystring As String = sb.ToString 'ConfigurationManager.AppSettings("ReportPath") & sb.ToString
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                    End If
                End If
            End If
            shdtls = True
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub objGridView_Deleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles objGridView.Deleted
        lblmsg.Text = "Data Deleted Successfully."
        shdtls = True
    End Sub

    Protected Sub objGridView_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles objGridView.Deleting
        If GVStdAttd.EditIndex <> -1 Then
            lblmsg.Text = "No Records Found."
            e.Cancel = True
        End If
        shdtls = True
    End Sub

    Sub AlertEnterAllFields()
        lblmsg.Text = "Select all the required fields."
    End Sub
    
    Protected Sub objGridView_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles objGridView.Updated
        objGridView.DataObjectTypeName = "Attendance.StdAttendanceP"
        lblmsg.Text = "Data Updated Successfully."
        shdtls = True
    End Sub
    Protected Sub objGridView_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles objGridView.Updating
        e.InputParameters.Item("InsId") = Session("InstituteID")
        e.InputParameters.Item("BrnId") = Session("BranchID")
        e.InputParameters.Item("Courseid") = GlobalFunction.IdCutter(ddlCourse.Text)
        e.InputParameters.Item("SubjectId") = cmbSubject.SelectedValue
        e.InputParameters.Item("Month") = cmbMonth.SelectedValue
        e.InputParameters.Item("Year") = txtYear.Text
        e.InputParameters.Item("Batch") = GlobalFunction.IdCutter(cmbBatch.Text)
        e.InputParameters.Item("SemsterId") = cmbAssementType.SelectedValue
        e.InputParameters.Item("AttendanceDate") = TxtAttdate.Text
        e.InputParameters.Item("Assessment_ID") = ddlAssessment.SelectedValue
        shdtls = True
    End Sub

    Protected Sub GVStdAttd_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVStdAttd.PreRender
        If TxtAttdate.Text <> Nothing Then
            GVStdAttd.Columns(4).Visible = True
            GVStdAttd.Columns(5).Visible = False
            GVStdAttd.Columns(6).Visible = False
        Else
            GVStdAttd.Columns(4).Visible = False
            GVStdAttd.Columns(5).Visible = True
            GVStdAttd.Columns(6).Visible = False
        End If
        shdtls = True
    End Sub

    Protected Sub GVStdAttd_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVStdAttd.RowEditing
        If TxtAttDate.Text = Nothing Then
            lblmsg.Text = "Editing allowed only Date wise..."
        End If
        shdtls = True
    End Sub
    Protected Sub GVStdAttd_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVStdAttd.RowUpdating
        objGridView.DataObjectTypeName = ""
        shdtls = True
    End Sub

    Protected Sub TxtAttDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAttDate.TextChanged
        If TxtAttDate.Text <> Nothing Then
            cmbMonth.SelectedValue = Month(TxtAttDate.Text)
            txtYear.Text = Year(TxtAttDate.Text)
        End If
        shdtls = True
    End Sub

    Protected Sub objGridView_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles objGridView.Selecting
        e.InputParameters.Item("CrsId") = GlobalFunction.IdCutter(ddlCourse.Text)
        e.InputParameters.Item("batchno") = GlobalFunction.IdCutter(cmbBatch.Text)
        e.InputParameters.Item("StdCode") = GlobalFunction.NameCutter(txtStdCode.Text)
        shdtls = True
    End Sub

    Protected Sub RBDateChk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBDateChk.CheckedChanged
        Call filldate()
        shdtls = True
    End Sub

    Protected Sub RBMonthChk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBMonthChk.CheckedChanged
        Call filldate()
        shdtls = True
    End Sub
    Public Sub filldate()
        If RBDateChk.Checked = True Then
            TxtAttdate.Text = Format(Today.Date, "dd-MMM-yyyy")
        Else
            TxtAttdate.Text = ""
        End If
    End Sub

    Protected Sub RBSemWiseChk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBSemWiseChk.CheckedChanged
        Call filldate()
        shdtls = True
    End Sub

    Protected Sub txtStdCode_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode.PreRender
        Session("sesInstitute") = HttpContext.Current.Session("InstituteID")
        Session("sesbranch") = HttpContext.Current.Session("BranchID")
        Session("sesBatch") = 0
        Session("sesCourse") = 0
        Try
            If txtStdCode.Text <> "" Then
                Dim BL As New StdAttendanceB
                Dim dt As New DataTable
                dt = BL.fillCourseBatch(GlobalFunction.IdCutter(txtStdCode.Text))
                ddlCourse.Text = dt.Rows(0)("Course_Id").ToString() & ":" & dt.Rows(0)("CourseName").ToString()
                cmbBatch.Text = dt.Rows(0)("Id").ToString() & ":" & dt.Rows(0)("Batch_No").ToString()
                cmbBatch.Enabled = False
                ddlCourse.Enabled = False
            Else
                If txtStdCode.Text <> "" And ddlCourse.Text = "" Then
                    cmbBatch.Text = ""
                    ddlCourse.Text = ""
                    cmbBatch.Enabled = True
                    ddlCourse.Enabled = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub txtCourse_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.PreRender
        Session("sesInstitute") = HttpContext.Current.Session("InstituteID")
        Session("sesbranch") = HttpContext.Current.Session("BranchID")
        Try
            If ddlCourse.Enabled = True Then
                If ddlCourse.Text <> "" Then
                    txtStdCode.Enabled = False
                Else
                    txtStdCode.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtStdCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode.TextChanged
        If txtStdCode.Text = "" Then
            cmbBatch.Text = ""
            ddlCourse.Text = ""
            cmbBatch.Enabled = True
            ddlCourse.Enabled = True
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
