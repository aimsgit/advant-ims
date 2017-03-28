
Partial Class frmPrinicipalDashboard
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String

        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        lblAttenPercent.text = "<%"
    End Sub

    Protected Sub btnsumAdm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsumAdm.Click
        msginfo.Text = ""
     
        Dim AcademicYear As Integer = ddladmissionAca.SelectedValue
        Dim Course As Integer = ddlcouadmision.SelectedValue
        Dim Category As Integer = ddlcatAdm.SelectedValue
        Dim A_Race = ddlRace.SelectedValue
        Dim Adm_Race = ddlRace.SelectedItem.Text
        Dim qrystring As String = "RptPrincipalDashForAdmSum.aspx?" & "&AcademicYear=" & AcademicYear & "&Course=" & Course & "&Category=" & Category & "&A_Race=" & A_Race & "&Adm_Race=" & Adm_Race
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        msginfo.Text = ""
    End Sub

    Protected Sub btndetailAdm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetailAdm.Click
        msginfo.Text = ""

        Dim AcademicYear As Integer = ddladmissionAca.SelectedValue
        Dim Course As Integer = ddlcouadmision.SelectedValue
        Dim Category As Integer = ddlcatAdm.SelectedValue
        Dim A_Race = ddlRace.SelectedValue
        Dim Adm_Race = ddlRace.SelectedItem.Text
        Dim qrystring As String = "RptPrincipalDashForAdmDetail.aspx?" & "&AcademicYear=" & AcademicYear & "&Course=" & Course & "&Category=" & Category & "&A_Race=" & A_Race & "&Adm_Race=" & Adm_Race
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        msginfo.Text = ""
    End Sub

    'Protected Sub btnSummMArks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSummMArks.Click
    '    msginfo.Text = ""

    '    Dim M_AcademicYear As Integer = ddladmissionMarks.SelectedValue
    '    Dim M_Course As Integer = ddlCoumarks.SelectedValue
    '    Dim M_Category As Integer = ddlCatMar.SelectedValue
    '    Dim M_AssessmentType As Integer = ddlAType.SelectedValue
    '    Dim M_FromPer As Integer = ddlFromPercent.SelectedValue
    '    Dim M_ToPer As Integer = ddlToPercent.SelectedValue

    '    Dim qrystring As String = "RptPrincipalDashforMarksSummaryV.aspx?" & "&AcademicYear=" & M_AcademicYear & "&Course=" & M_Course & "&Category=" & M_Category & "&AssessmentType=" & M_AssessmentType & "&M_FromPer=" & M_FromPer & "&M_ToPer=" & M_ToPer
    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    '    msginfo.Text = ""

    'End Sub

   Protected Sub btnDeatlMarks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeatlMarks.Click
        msginfo.Text = ""

        Dim M_AcademicYear As Integer = ddladmissionMarks.SelectedValue
        Dim M_Course As Integer = ddlCoumarks.SelectedValue
        Dim M_Category As Integer = ddlCatMar.SelectedValue
        Dim M_AssessmentType As Integer = ddlAType.SelectedValue
        Dim M_FromPer As Integer = 0
        Dim M_ToPer As Integer = 0
        Dim M_Caste = ddlRaceCaste.SelectedValue
        Dim RaceCaste = ddlRaceCaste.SelectedItem.Text
        Dim Sem As Integer = ddlsem.SelectedValue
        Dim StudentCategory As String = ddlCatMar.SelectedItem.Text
        Dim qrystring As String = "RptPrincipalDashboardforMarksDetailedV.aspx?" & "&AcademicYear=" & M_AcademicYear & "&Course=" & M_Course & "&Category=" & M_Category & "&AssessmentType=" & M_AssessmentType & "&M_FromPer=" & M_FromPer & "&M_ToPer=" & M_ToPer & "&Sem=" & Sem & "&StudentCategory=" & StudentCategory & "&M_Caste=" & M_Caste & "&RaceCaste=" & RaceCaste
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        msginfo.Text = ""

    End Sub

    Protected Sub btnBestPro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBestPro.Click
        Response.Redirect("Rpt_BestPerformance.aspx")
    End Sub

    Protected Sub btnsumFee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsumFee.Click
        msginfo.Text = ""
        Dim Branch As String = Session("BranchName")
        Dim A_Name As String = ddladmissionfee.SelectedItem.Text
        Dim CategoryName As String = ddlCatFee.SelectedItem.Text
        Dim AcademicYear As Integer = ddladmissionfee.SelectedValue
        Dim Course As Integer = ddlCoufee.SelectedValue
        Dim Category As Integer = ddlCatFee.SelectedValue
        Dim FCaste = ddlcasteFee.SelectedValue
        Dim FCasteText = ddlcasteFee.SelectedItem.Text
        Dim qrystring As String = "Rpt_PrincipaldashFeesumarry.aspx?" & "&AcademicYear=" & AcademicYear & "&Course=" & Course & "&Category=" & Category & "&CategoryName=" & CategoryName & "&Branch=" & Branch & "&A_Name=" & A_Name & "&FCaste=" & FCaste & "&FCasteText=" & FCasteText
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        msginfo.Text = ""
    End Sub
    Protected Sub btndetailfee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetailfee.Click
        msginfo.Text = ""
        Dim Branch As String = Session("BranchName")
        Dim A_Name As String = ddladmissionfee.SelectedItem.Text
        Dim CategoryName As String = ddlCatFee.SelectedItem.Text
        Dim AcademicYear As Integer = ddladmissionfee.SelectedValue
        Dim Course As Integer = ddlCoufee.SelectedValue
        Dim Category As Integer = ddlCatFee.SelectedValue
        Dim FCaste = ddlcasteFee.SelectedValue
        Dim FCasteText = ddlcasteFee.SelectedItem.Text
        Dim qrystring As String = "Rpt_PrincipalDashFeeDetails.aspx?" & "&AcademicYear=" & AcademicYear & "&Course=" & Course & "&Category=" & Category & "&CategoryName=" & CategoryName & "&Branch=" & Branch & "&A_Name=" & A_Name & "&FCaste=" & FCaste & "&FCasteText=" & FCasteText
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        msginfo.Text = ""
    End Sub

    Protected Sub btnAttenDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAttenDetail.Click
        Dim AcademicYear As Integer = ddladmissionaatendence.SelectedValue
        Dim Course As Integer = ddlCouattendence.SelectedValue
        Dim percentage As Integer
        Dim course2 As String = ddlCouattendence.SelectedItem.Text
        Dim Category As Integer = ddlCatAtt.SelectedValue
        Dim Category2 As String = ddlCatAtt.SelectedItem.Text
        Dim AcademicYear2 As String = ddladmissionaatendence.SelectedItem.Text
        Dim caste As Integer = ddlcaste.SelectedValue
        Dim caste2 As String = ddlcaste.SelectedItem.Text
        If txtAttendper.Text = "" Then
            percentage = 0
        Else
            percentage = txtAttendper.Text
        End If
        Dim percentage2 As String = txtAttendper.Text
        Dim R As Integer = 2


        Dim qrystring As String = "RptAttendanceDashV.aspx?" & "&AcademicYear=" & AcademicYear & "&Course=" & Course & "&Category=" & Category & "&course2=" & course2 & "&percentage=" & percentage & "&Category2=" & Category2 & "&percentage2=" & percentage2 & "&R=" & R & "&AcademicYear2=" & AcademicYear2 & "&caste=" & caste & "&caste2=" & caste2
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        msginfo.Text = ""
    End Sub

    Protected Sub btnsummattend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsummattend.Click
        Dim AcademicYear As Integer = ddladmissionaatendence.SelectedValue
        Dim Course As Integer = ddlCouattendence.SelectedValue
        Dim percentage As Integer
        Dim course2 As String = ddlCouattendence.SelectedItem.Text
        Dim Category As Integer = ddlCatAtt.SelectedValue
        Dim Category2 As String = ddlCatAtt.SelectedItem.Text
        Dim AcademicYear2 As String = ddladmissionaatendence.SelectedItem.Text
        Dim caste As Integer = ddlcaste.SelectedValue
        Dim caste2 As String = ddlcaste.SelectedItem.Text
        If txtAttendper.Text = "" Then
            percentage = 0
        Else
            percentage = txtAttendper.Text
        End If

        Dim percentage2 As String = txtAttendper.Text


        Dim qrystring As String = "RptAttendanceDashV.aspx?" & "&AcademicYear=" & AcademicYear & "&Course=" & Course & "&Category=" & Category & "&course2=" & course2 & "&percentage=" & percentage & "&Category2=" & Category2 & "&percentage2=" & percentage2 & "&AcademicYear2=" & AcademicYear2 & "&caste=" & caste & "&caste2=" & caste2
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        msginfo.Text = ""
    End Sub

    Protected Sub btnFeeDue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFeeDue.Click

        Dim BatchId As Integer = 0
        Dim SemID As Integer = ddladmissionfee.SelectedValue
        Dim StdID As Integer = 0
        Dim CategoryID As Integer = ddlCatFee.SelectedValue
        Dim CourseCode As Integer = ddlCoufee.SelectedValue
        'dt = BLL.FeeDueReport(BatchId, SemID, StdID, CategoryID)
        'If dt.Rows.Count > 0 Then
        'Context.Items("State") = "Report"
        'FeeDueRpt.Crs = GlobalFunction.IdCutter(txtCourse.Text)
        'FeeDueRpt.Batch = GlobalFunction.IdCutter(txtBatch.Text)
        Dim qrystring As String = "rptFeeDueStatementV.aspx?" & QueryStr.Querystring() & "&BatchId=" & BatchId & "&SemID=" & SemID & "&StdID=" & StdID & "&CategoryID=" & CategoryID & "&CourseCode=" & CourseCode
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
       
    End Sub
End Class