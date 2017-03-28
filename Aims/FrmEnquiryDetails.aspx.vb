
Partial Class EnquiryDetails
    Inherits BasePage
    Dim alt As String
    Dim sql As String
    Dim Inst, Bran As String
    Dim BAL As New EnquiryManager
    Dim BAL1 As New ProspectusB

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim fromdateE As DateTime
        Dim todateE As DateTime
        If txtFromDateExt.Text = "" Then
            fromdateE = "1/1/1900"
        Else
            fromdateE = txtFromDateExt.Text
        End If
        If txtToDateExt.Text = "" Then
            todateE = "1/1/1900"
        Else
            todateE = txtToDateExt.Text
        End If
        If fromdateE = "1/1/1900" Or todateE = "1/1/1900" Then
            lblErrorMsg.Text = ValidationMessage(1117)
        ElseIf fromdateE > todateE Then
            lblErrorMsg.Text = ValidationMessage(1075)
        Else
            If ddlBranch.Items.Count > 0 Then
                Dim name As String = txtstdname.Text
                Dim BranchCode As String = ddlBranch.SelectedValue
                Dim admitted As String = ddlAdmitted.SelectedValue
                Dim Course As Integer = ddlCourse.SelectedValue
                Dim Source As String = ddlSource.SelectedValue
                Dim ERealatedTo As String = cmbERelates.SelectedItem.Text
                If txtFromDateExt.Text = "" Or txtToDateExt.Text = "" Then
                    lblErrorMsg.Text = ValidationMessage(1117)
                Else
                    lblErrorMsg.Text = ValidationMessage(1014)
                    Dim qrystring As String = "rptEnquiry.aspx?" & QueryStr.Querystring() & "&FromDate=" & fromdateE & "&ToDate=" & todateE & "&BCode=" & BranchCode & "&CourseId=" & Course & "&Name=" & name & "&admitted=" & admitted & "&Source=" & Source & "&ERealatedTo=" & ERealatedTo
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                End If
            Else
                'AlertEnterAllFields()
            End If
        End If
    End Sub

    'Sub DisplayGridValue(ByVal sender As Object, ByVal e As System.EventArgs)

    '    If ddlBranch.Items.Count > 0 Then
    '        Dim name As String = txtstdname.Text
    '        Dim BranchCode As String = ddlBranch.SelectedValue
    '        Dim dt As New DataTable
    '        dt = BAL.Display(name, BranchCode)
    '    End If
    'End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim CloseDate As Date
            Dim cd As String

            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            txtToDateExt.Text = cd
            txtFromDateExt.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            ddlBranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If
    End Sub

    'Protected Sub ddlBranch_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.PreRender
    '    If ddlBranch.Items.Count > 0 Then
    '        If ddlBranch.Items(0).Text <> " All" Then
    '            ddlBranch.Items.Insert(0, " All")
    '        End If
    '    Else
    '        ddlBranch.Items.Insert(0, " All")
    '    End If
    'End Sub

    'Protected Sub ddlBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.SelectedIndexChanged
    '    ddlBranch.Focus()
    'End Sub

    'Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
    '    ddlCourse.Focus()
    'End Sub

    'Protected Sub ddlAdmitted_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAdmitted.SelectedIndexChanged
    '    ddlAdmitted.Focus()
    'End Sub

    'Protected Sub ddlSource_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSource.SelectedIndexChanged
    '    ddlSource.Focus()
    'End Sub

    'Protected Sub txtstdname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstdname.TextChanged
    '    txtstdname.Focus()
    'End Sub
    'Code written fro multilingual by Niraj on 29 Nov 2013
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
  
End Class
