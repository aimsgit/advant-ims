
Partial Class Rpt_BatchReportCardCriteria
    Inherits BasePage
    Dim str As String = ""
    Dim str1 As String = ""
    Dim id1 As String = ""
    Dim id2 As String = ""
    Dim dl As New feeCollectionDL
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblErrorMsg.Text = ValidationMessage(1014)
        Dim QS As String
        Dim course As String = txtCourseName.SelectedValue
        Dim Branch As String = txtBranchName.SelectedValue
        Dim CourseId As Integer = txtCourseName.SelectedValue
        'Dim AYear As Integer = ddlA_Year.SelectedValue
        Dim Subjectid As Integer = ddlsubject.SelectedItem.Value
        Dim SemesterId As Integer = ddlSemester.SelectedItem.Value
        Dim BatchNo As Integer = ddlbatch.SelectedValue
        Dim AssessmentId As Integer = ddlassesment.SelectedItem.Value
        Dim ReportType As String = ddlReportType.SelectedValue
        Dim SortBY As Integer = ddlSort.SelectedValue
        'Id is used to distinguish Report and Marks Analysis
        Dim id As Integer = 1
        Dim FrmMarks As String = txtFrmMarks.Text
        Dim Tomarks As String = txtToMarks.Text



        'QS = Request.QueryString.Get("QS")
        'If QS = "Rpt1" Then
        If txtCourseName.SelectedItem.Text = "Select" Or txtBranchName.SelectedItem.Text = "Select" Or ddlbatch.SelectedItem.Text = " Select" Then
            lblErrorMsg.Text = ValidationMessage(1100)
        Else
            Dim qrystring As String = "Rpt_BatchReportCardV.aspx?" & QueryStr.Querystring() & "&course=" & course & "&Branch=" & Branch & "&CourseId=" & CourseId & "&Subjectid=" & Subjectid & "&SemesterId=" & SemesterId & "&BatchNo=" & BatchNo & "&AssessmentId=" & AssessmentId & "&SortBy=" & SortBY & "&ReportType=" & ReportType & "&id=" & id & "&FrmMarks=" & FrmMarks & "&Tomarks=" & Tomarks
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            'txtFrmMarks.Text = ""
            'txtToMarks.Text = ""
        End If
        'End If
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
        End If
        If Not IsPostBack Then
            'Control_Text_Multilingual()
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            txtBranchName.SelectedValue = HttpContext.Current.Session("BranchCode")
            ddlbranch1.SelectedValue = HttpContext.Current.Session("BranchCode")
            ddlSem1.SelectedValue = 0
            ddlSubj1.SelectedValue = 0
            'End If
        End If
        If RBReport.SelectedValue = 1 Then
            markspanel.Visible = False
            btnMarksAnalysis.Visible = False
            btnReport.Visible = True
            Panel1.Visible = True
        Else
            markspanel.Visible = True
            btnMarksAnalysis.Visible = True
            btnReport.Visible = False
            Panel1.Visible = False
        End If

    End Sub
    Sub Invisible()
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

    'Protected Sub ddlbatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.TextChanged
    '    ddlbatch.Focus()
    'End Sub

    'Protected Sub ddlA_Year_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlA_Year.TextChanged
    '    ddlA_Year.Focus()
    'End Sub

    'Protected Sub ddlassesment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassesment.TextChanged
    '    ddlassesment.Focus()
    'End Sub
    'Protected Sub ddlSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.TextChanged
    '    ddlSemester.Focus()
    'End Sub

    'Protected Sub ddlsubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsubject.TextChanged
    '    ddlsubject.Focus()
    'End Sub

    'Protected Sub txtBranchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBranchName.TextChanged
    '    txtBranchName.Focus()
    'End Sub

    'Protected Sub txtCourseName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCourseName.TextChanged
    '    txtCourseName.Focus()
    'End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnMarksAnalysis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMarksAnalysis.Click

        Dim course As String = ddlCourse1.SelectedValue
        Dim Branch As String = ddlbranch1.SelectedValue
        'Dim CourseId As Integer = txtCourseName.SelectedValue
        'Dim AYear As Integer = ddlA_Year.SelectedValue
        Dim Subjectid As Integer = ddlSubj1.SelectedItem.Value
        Dim SemesterId As Integer = ddlSem1.SelectedItem.Value
        GetBatchid()
        Dim BatchNo As String = id1
        Dim BatchName As String = id2
        Dim AssessmentId As Integer = ddlAType1.SelectedItem.Value

        Dim Frm1, Frm2, Frm3, Frm4, To1, To2, To3, To4, RBType As Integer
        If TxtFrm1.Text = "" Then
            Frm1 = 0
        Else
            Frm1 = TxtFrm1.Text
        End If
        If TxtFrm2.Text = "" Then
            Frm2 = 0
        Else
            Frm2 = TxtFrm2.Text
        End If
        If TxtFrm3.Text = "" Then
            Frm3 = 0
        Else
            Frm3 = TxtFrm3.Text
        End If
        If TxtFrm4.Text = "" Then
            Frm4 = 0
        Else
            Frm4 = TxtFrm4.Text
        End If
        If TxtTo1.Text = "" Then
            To1 = 0
        Else
            To1 = TxtTo1.Text
        End If
        If TxtTo2.Text = "" Then
            To2 = 0
        Else
            To2 = TxtTo2.Text
        End If
        If TxtTo3.Text = "" Then
            To3 = 0
        Else
            To3 = TxtTo3.Text
        End If
        If TxtTo4.Text = "" Then
            To4 = 0
        Else
            To4 = TxtTo4.Text
        End If
        'RBType is used to distinguish Marks and Percentage Analysis
        RBType = RBMarks1.SelectedValue

        'Id is used to distinguish Report and Marks Analysis
        Dim id As Integer = 2

        If ddlCourse1.SelectedItem.Text = "Select" Or ddlbranch1.SelectedItem.Text = "Select" Or BatchNo.ToString = " " Or ddlYearTo.SelectedItem.Text = "Select" Then
            lblErrorMsg.Text = ValidationMessage(1100)
        Else
            Dim qrystring As String = "Rpt_BatchReportCardV.aspx?" & QueryStr.Querystring() & "&course=" & course & "&Branch=" & Branch & "&Subjectid=" & Subjectid & "&SemesterId=" & SemesterId & "&BatchNo=" & BatchNo & "&AssessmentId=" & AssessmentId & "&id=" & id & "&Frm1=" & Frm1 & "&Frm2=" & Frm2 & "&Frm3=" & Frm3 & "&Frm4=" & Frm4 & "&To1=" & To1 & "&To2=" & To2 & "&To3=" & To3 & "&To4=" & To4 & "&RBType=" & RBType & "&BatchName=" & BatchName
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        End If



    End Sub
    'Code written fro multilingual by Niraj on 15 jan 2014
    ''Retriving the text of controls based on Language
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function

  

   

    Protected Sub ddlYearTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYearTo.SelectedIndexChanged
        Dim dt As New DataTable
        dt = DLBatchReportCardElect.FillBatch(ddlCourse1.SelectedValue, ddlYearTo.SelectedItem.Text)
        If dt.Rows.Count > 0 Then
            lblErrorMsg.Text = ""
            For i As Integer = 0 To dt.Rows.Count - 1

                ListBox1.DataSource = dt
                ListBox1.DataBind()
                ListBox1.Visible = True
                ListBox1.DataTextField = "Batch_No"
                lblErrorMsg.Text = ""
            Next
        Else

            ListBox1.Items.Clear()
        End If
    End Sub
    Protected Sub Btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn1.Click
        GetBatchid()
        Dim dt1 As New DataTable
        dt1 = dl.SemesterComboBatRptCard(id1)
        ddlSem1.Items.Clear()
        ddlSem1.DataSource = dt1
        ddlSem1.DataBind()


    End Sub
    Sub GetBatchid()

        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ListBox1.Items.Count - 1

        If ListBox1.Items.Count <> 0 Then
            For Each items In ListBox1.Items
                If (ListBox1.Items(i).Selected = True) Then
                    str = ListBox1.Items(i).Value
                    str1 = ListBox1.Items(i).Text
                    id1 = str + "," + id1
                    id2 = str1 + " ,  " + id2
                End If
                i = i + 1
            Next
        End If
    End Sub

   

    Protected Sub ddlSem1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSem1.SelectedIndexChanged
        Dim dt As New DataTable
        GetBatchid()
        dt = DLBatchReportCardElect.GetSubjectComboAllNew(ddlbranch1.SelectedValue, id1, ddlSem1.SelectedValue)
        ddlSubj1.DataSource = dt
        ddlSubj1.DataBind()

    End Sub

    Protected Sub ddlCourse1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse1.SelectedIndexChanged
        ddlYearTo.SelectedValue = 100
        ListBox1.Items.Clear()
    End Sub

    Protected Sub RBReport_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBReport.TextChanged
        txtBranchName.SelectedValue = HttpContext.Current.Session("BranchCode")
        ddlbranch1.SelectedValue = HttpContext.Current.Session("BranchCode")
    End Sub
End Class
