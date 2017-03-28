
Partial Class frmCriteria
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblErrorMsg.Text = ""
        Dim QS As String
        Dim course As String = txtCourseName.SelectedValue
        Dim Branch As String = txtBranchName.SelectedValue
        Dim CourseId As Integer = txtCourseName.SelectedValue
        'Dim AYear As Integer = ddlA_Year.SelectedValue
        Dim Subjectid As Integer = ddlsubject.SelectedItem.Value
        Dim SemesterId As Integer = ddlSemester.SelectedItem.Value
        Dim BatchNo As Integer = ddlbatch.SelectedValue
        Dim AssessmentId As Integer = ddlassesment.SelectedItem.Value
        Dim ClassType As Integer = ddlclass.SelectedValue
        Dim SortBY As Integer = ddlSort.SelectedValue
        Dim ReportType As String = ddlReportType.SelectedValue

        QS = Request.QueryString.Get("QS")
        If QS = "Rpt1" Then
            If txtCourseName.SelectedItem.Text = " Select" Or txtBranchName.SelectedItem.Text = "Select" Or ddlbatch.SelectedItem.Text = " Select" Then
                lblErrorMsg.Text = "Please enter all Mandatory Fields."
            Else
                Dim qrystring As String = "Rpt_BatchReportCard.aspx?" & QueryStr.Querystring() & "&course=" & course & "&Branch=" & Branch & "&CourseId=" & CourseId & "&Subjectid=" & Subjectid & "&SemesterId=" & SemesterId & "&BatchNo=" & BatchNo & "&AssessmentId=" & AssessmentId & "&ClassType=" & ClassType & "&SortBy=" & SortBY & "&ReportType=" & ReportType
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            End If
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        Dim QS As String
        QS = Request.QueryString.Get("QS")
        Invisible()
        If QS = "Rpt1" Then
            lblBranchType.Visible = True
            txtBranchName.Visible = True
            lblCourse.Visible = True
            txtCourseName.Visible = True
            lblbatch.Visible = True
            ddlbatch.Visible = True
            'lblA_Year.Visible = True
            'ddlA_Year.Visible = True
            lblsemester.Visible = True
            ddlSemester.Visible = True
            lblsubject.Visible = True
            ddlsubject.Visible = True
            lblclass.Visible = True
            ddlclass.Visible = True
        End If
        If Not IsPostBack Then
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            txtBranchName.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If

    End Sub
    Sub Invisible()
        lblBranchType.Visible = False
        txtBranchName.Visible = False
        lblCourse.Visible = False
        txtCourseName.Visible = False
        lblbatch.Visible = False
        ddlbatch.Visible = False
        'lblA_Year.Visible = False
        'ddlA_Year.Visible = False
        lblsemester.Visible = False
        ddlSemester.Visible = False
        lblsubject.Visible = False
        ddlsubject.Visible = False
        lblclass.Visible = False
        ddlclass.Visible = False
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Report.aspx")
    End Sub

    'Protected Sub ddlassesment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassesment.SelectedIndexChanged
    '    ddlassesment.Items.Clear()
    '    Me.ddlassesment.Items.Add(New ListItem("All"))
    '    ddlassesment.DataBind()
    'End Sub

    Protected Sub txtBranchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBranchName.SelectedIndexChanged
        txtCourseName.Items.Clear()
        txtCourseName.DataSourceID = "ObjCourse"
    End Sub

    Protected Sub ddlbatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.TextChanged
        ddlbatch.Focus()
    End Sub

    
    Protected Sub ddlassesment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassesment.TextChanged
        ddlassesment.Focus()
    End Sub

    Protected Sub ddlclass_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlclass.TextChanged
        ddlclass.Focus()
    End Sub

    Protected Sub ddlSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.TextChanged
        ddlSemester.Focus()
    End Sub

    Protected Sub ddlsubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsubject.TextChanged
        ddlsubject.Focus()
    End Sub

    Protected Sub txtBranchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBranchName.TextChanged
        txtBranchName.Focus()
    End Sub

    Protected Sub txtCourseName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCourseName.TextChanged
        txtCourseName.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
