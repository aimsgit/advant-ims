Imports System.Data
Imports System.IO
Partial Class IndStudentResult
    Inherits BasePage
    Dim alert As String
    Dim BAL As New CourseManager
    Dim GlobalFunction As New GlobalFunction
    Dim shdtls As Boolean
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim BranchCode As String = ddlbranch.SelectedValue
        Dim StudentID As Integer = ddlstucode.SelectedValue
        Dim BatchId As Integer = ddlbatch.SelectedValue
        Dim SemId As Integer = ddlsem.SelectedValue
        Dim assesstype As Integer = ddlass.SelectedValue
        Dim classType As Integer = ddlclass.SelectedValue
        Dim ReportType As String = ddlReportType.SelectedValue
        Dim bl As New StdResultB

        If ddlbranch.SelectedItem.Text = "Select" Or ddlcourse.SelectedItem.Text = "Select" Or ddlbatch.SelectedItem.Text = "Select" Then

            msginfo.Text = "Select all the required fields."
        Else
            Dim qrystring As String = "rptMarksSheet.aspx?" & "&BranchCode=" & BranchCode & "&Batch=" & BatchId & "&Semester=" & SemId & "&StudentCode=" & StudentID & "&AssessmentType=" & assesstype & "&ClassType=" & classType & "&ReportType=" & ReportType
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            msginfo.Text = ""
        End If
        shdtls = True
    End Sub
    Sub AlertEnterAllFields(ByVal str As String)
        alert = "alert('" & str & "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alert, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        shdtls = False
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        If Not IsPostBack Then
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            ddlbranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    'Protected Sub txtStdCode_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode.PreRender
    '    Session("sesInstitute") = Session("InstituteID")
    '    Session("sesbranch") = Session("BranchID")
    '    Session("sesBatch") = 0
    '    Session("sesCourse") = 0
    '    Try
    '        If shdtls = False Then
    '            If txtStdCode.Text <> "" Then
    '                Dim BL As New StudentResult.StdResultB
    '                Dim dt As New DataTable
    '                dt = BL.GetSemesterByStdCode(GlobalFunction.IdCutter(txtStdCode.Text))
    '                ddlSemester.DataSource = dt
    '                ddlSemester.DataTextField = "SemesterType"
    '                ddlSemester.DataValueField = "ID"
    '                ddlSemester.DataBind()
    '                txtBatch.Text = dt.Rows(0).Item(4).ToString & ":" & dt.Rows(0).Item(0).ToString
    '                txtCourse.Text = dt.Rows(0).Item(2).ToString & ":" & dt.Rows(0).Item(1).ToString
    '                'OpenNewWindow.Opennewwindow(btnReport, "rptMarksSheet.aspx?Course=" & txtCourse.Text & "&BatchVal=" & txtBatch.Text & "&StdCode=" & GlobalFunction.NameCutter(txtStdCode.Text) & "&Semester=" & ddlSemester.SelectedItem.Text)
    '                'OpenNewWindow.Opennewwindow(btnReportAll, "rptMarksSheet.aspx?Course=" & txtCourse.Text & "&BatchVal=" & txtBatch.Text & "&StdCode=" & GlobalFunction.NameCutter(txtStdCode.Text) & "&Semester=" & "")
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Protected Sub ddlbranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbranch.SelectedIndexChanged
        ddlbranch.Focus()
    End Sub

    Protected Sub ddlass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlass.SelectedIndexChanged
        ddlass.Focus()
    End Sub

    Protected Sub ddlbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.SelectedIndexChanged
        ddlbatch.Focus()
    End Sub

    Protected Sub ddlclass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlclass.SelectedIndexChanged
        ddlclass.Focus()
    End Sub

    Protected Sub ddlcourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcourse.SelectedIndexChanged
        ddlcourse.Focus()
    End Sub

    'Protected Sub ddlReportType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReportType.SelectedIndexChanged
    '    ddlReportType.Focus()

    'End Sub

    Protected Sub ddlsem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsem.SelectedIndexChanged
        ddlsem.Focus()
    End Sub

    Protected Sub ddlstucode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstucode.SelectedIndexChanged
        ddlstucode.Focus()
    End Sub
End Class