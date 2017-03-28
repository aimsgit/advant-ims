Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Partial Class StudentList
    Inherits BasePage
    Dim estd As StudentE
    Dim off As String
    Dim BCode As String
    Dim BNo As Integer
    Dim CId As Integer
    Dim Ayear As String

    Dim GlobalFunction As New GlobalFunction
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim dt As New Data.DataTable
        Dim qrystring As String
        'Dim dllB As New GlobalDataSetTableAdapters.RPT_BatchWiseTableAdapter

        Dim BatchNo As Integer
        BatchNo = txtBatchName.SelectedValue
        Dim CourseId As Integer = txtCourseName.SelectedValue
        'Dim Ayear As String = txtYearName.SelectedValue
        Dim semid As Integer = ddlSemester.SelectedValue
        Dim DojDob As Integer
        Dim FromDate As Date
        Dim ToDate As Date
        If txtBranchName.SelectedItem.Text = "Select" Then

            lblErrorMsg.Text = ValidationMessage(1176)
        Else

            If RBReport.SelectedValue = 1 Then
                ddlSort.Enabled = False
                DojDob = cmbdojdob.SelectedValue
                If txtFromDate.Text = "" Then
                    FromDate = "01/01/1900"

                Else
                    FromDate = txtFromDate.Text
                    txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
                End If

                'ToDate = txtToDate.Text
                'txtToDate.Text = ToDate.ToString("dd-MMM-yyyy")
                If txtToDate.Text = "" Then
                    ToDate = "01/01/1900"

                Else
                    ToDate = txtToDate.Text
                    txtToDate.Text = Format(ToDate, "dd-MMM-yyyy")
                End If

                If FromDate > ToDate Then
                    lblErrorMsg.Text = "Start date should not be greater than End date."
                    txtToDate.Focus()
                    Exit Sub
                End If

                If cmbdojdob.SelectedValue <> 0 And (txtFromDate.Text = "" Or txtToDate.Text = "") Then
                    lblErrorMsg.Text = ValidationMessage(1180)
                Else
                    lblErrorMsg.Text = ValidationMessage(1014)
                    qrystring = "rptSummary.aspx?" & QueryStr.Querystring() & "&CourseId=" & CourseId & "&BatchNo=" & BatchNo & "&Ayear=" & Ayear & "&DojDob=" & DojDob & "&FromDate=" & FromDate & "&ToDate=" & ToDate.ToString("dd-MMM-yyyy") & "&Semid=" & semid & "&BranchCode=" & txtBranchName.SelectedValue

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

                    'If txtFromDate.Text = "" Then

                    '    lblErrorMsg.Text = "From Date is mandatory."
                    '    txtFromDate.Focus()
                    'ElseIf txtToDate.Text = "" Then
                    '    lblErrorMsg.Text = "To Date is mandatory."
                    '    txtToDate.Focus()
                    'Else
                    '    If CType(txtFromDate.Text, Date) > CType(txtToDate.Text, Date) Then

                    '        lblErrorMsg.Text = "From date should be lesser than To date."
                    '        txtFromDate.Focus()
                    '        Exit Sub
                    '    End If

                    '    DojDob = cmbdojdob.SelectedValue
                    '    If txtFromDate.Text = "" Then
                    '        FromDate = "01/01/1900"
                    '        txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
                    '    Else
                    '        FromDate = txtFromDate.Text
                    '        txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
                    '    End If

                    '    'ToDate = txtToDate.Text
                    '    'txtToDate.Text = Format(ToDate, "dd-MMM-yyyy")
                    '    If txtToDate.Text = "" Then
                    '        ToDate = "01/01/1900"
                    '        txtToDate.Text = Format(ToDate, "dd-MMM-yyyy")
                    '    Else
                    '        ToDate = txtToDate.Text
                    '        txtToDate.Text = Format(ToDate, "dd-MMM-yyyy")
                    '    End If


                    '    If CType(txtFromDate.Text, Date) > CType(txtToDate.Text, Date) Then

                    '        lblErrorMsg.Text = "From date should be lesser than To date."
                    '        txtFromDate.Focus()
                    '        Exit Sub
                    '    End If


                    '    'dt = BL.finalExamRpt(Designation, DojDob, FromDate, ToDate)

                    '    qrystring = "rptSummary.aspx?" & QueryStr.Querystring() & "&CourseId=" & CourseId & "&BatchNo=" & BatchNo & "&Ayear=" & Ayear & "&DojDob=" & DojDob & "&FromDate=" & FromDate & "&ToDate=" & ToDate.ToString("dd-MMM-yyyy")

                    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                    '    lblErrorMsg.Text = ""
                End If


            ElseIf RBReport.SelectedValue = 2 Then

                ddlSort.Enabled = True
                'Branch = ddlBranch.SelectedValue

                DojDob = cmbdojdob.SelectedValue
                If txtFromDate.Text = "" Then
                    FromDate = "01/01/1900"

                Else
                    FromDate = txtFromDate.Text
                    txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
                End If

                'ToDate = txtToDate.Text
                'txtToDate.Text = ToDate.ToString("dd-MMM-yyyy")
                If txtToDate.Text = "" Then
                    ToDate = "01/01/1900"

                Else
                    ToDate = txtToDate.Text
                    txtToDate.Text = Format(ToDate, "dd-MMM-yyyy")
                End If

                If cmbdojdob.SelectedValue <> 0 And (txtFromDate.Text = "" Or txtToDate.Text = "") Then
                    lblErrorMsg.Text = ValidationMessage(1180)
                Else

                    lblErrorMsg.Text = ValidationMessage(1014)
                    qrystring = "rptDetailed.aspx?" & QueryStr.Querystring() & "&CourseId=" & CourseId & "&BatchNo=" & BatchNo & "&DojDob=" & DojDob & "&FromDate=" & FromDate & "&ToDate=" & ToDate.ToString("dd-MMM-yyyy") & "&Sort=" & ddlSort.SelectedValue & "&Semid=" & semid & "&BranchCode=" & txtBranchName.SelectedValue

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

                    'ElseIf txtFromDate.Text = "" Then

                    '    lblErrorMsg.Text = "From Date is mandatory."
                    '    txtFromDate.Focus()
                    'ElseIf txtToDate.Text = "" Then
                    '    lblErrorMsg.Text = "To Date is mandatory."
                    '    txtToDate.Focus()
                    'Else
                    '    If CType(txtFromDate.Text, Date) > CType(txtToDate.Text, Date) Then

                    '        lblErrorMsg.Text = "From date should be lesser than To date."
                    '        txtFromDate.Focus()
                    '        Exit Sub
                    '    End If

                    '    DojDob = cmbdojdob.SelectedValue
                    '    If txtFromDate.Text = "" Then
                    '        FromDate = "01/01/1900"
                    '        txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
                    '    Else
                    '        FromDate = txtFromDate.Text
                    '        txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
                    '    End If

                    '    'ToDate = txtToDate.Text
                    '    'txtToDate.Text = Format(ToDate, "dd-MMM-yyyy")
                    '    If txtToDate.Text = "" Then
                    '        ToDate = "01/01/1900"
                    '        txtToDate.Text = Format(ToDate, "dd-MMM-yyyy")
                    '    Else
                    '        ToDate = txtToDate.Text
                    '        txtToDate.Text = Format(ToDate, "dd-MMM-yyyy")
                    '    End If


                    '    If CType(txtFromDate.Text, Date) > CType(txtToDate.Text, Date) Then

                    '        lblErrorMsg.Text = "From date should be lesser than To date."
                    '        txtFromDate.Focus()
                    '        Exit Sub
                    '    End If


                    '    'dt = BL.finalExamRpt(Designation, DojDob, FromDate, ToDate)

                    '    qrystring = "rptDetailed.aspx?" & QueryStr.Querystring() & "&CourseId=" & CourseId & "&BatchNo=" & BatchNo & "&Ayear=" & Ayear & "&DojDob=" & DojDob & "&FromDate=" & FromDate & "&ToDate=" & ToDate.ToString("dd-MMM-yyyy")

                    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                    '    lblErrorMsg.Text = ""
                End If
            End If
        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If RBReport.SelectedValue = 1 Then
            ddlSort.Enabled = False
        Else
            ddlSort.Enabled = True
        End If
        If Not IsPostBack Then
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            txtBranchName.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If

        'If RBReport.SelectedValue = 1 Then
        '    cmbdojdob.Enabled = False
        '    txtFromDate.Enabled = False
        '    txtToDate.Enabled = False
        'ElseIf RBReport.SelectedValue = 2 Then
        '    cmbdojdob.Enabled = True
        '    txtFromDate.Enabled = True
        '    txtToDate.Enabled = True

        If cmbdojdob.SelectedValue = "0" And cmbdojdob.Enabled = True Then
            txtFromDate.Enabled = False
            txtFromDate.Text = ""
            txtToDate.Enabled = False
            txtToDate.Text = ""
            'txtToDate.Text = Format(Today, "dd-MMM-yyyy")
        Else
            txtFromDate.Enabled = True
            txtToDate.Enabled = True
            'txtToDate.Text = Format(Today, "dd-MMM-yyyy")
        End If



    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Student Details Report")
    End Sub

    'Protected Sub RBReport_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBReport.SelectedIndexChanged
    '    If RBReport.SelectedValue = 1 Then
    '        StudentListDB.summaryRpt(CId, BNo, Ayear)
    '    Else
    '        StudentListDB.detailedRpt(CId, BNo, Ayear)

    '    End If
    'End Sub

    ' Protected Sub txtBranchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBranchName.SelectedIndexChanged
    '     StudentListDB.insertBranch()
    ' End Sub

    ' Protected Sub txtCourseName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCourseName.SelectedIndexChanged
    '     StudentListDB.insertCourse(txtBranchName.SelectedValue)
    ' End Sub

    ' Protected Sub txtYearName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYearName.SelectedIndexChanged
    '     StudentListDB.insertYear(txtCourseName.SelectedValue)
    ' End Sub

    ' Protected Sub txtBatchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBatchName.SelectedIndexChanged
    '     StudentListDB.insertBatch(txtYearName.SelectedValue)
    ' End Sub
    ' <System.Web.Services.WebMethod()> _
    'Public Shared Sub AbandonSession()
    '     Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    ' End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub txtBranchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBranchName.TextChanged
        txtBranchName.Focus()
    End Sub

    'Protected Sub txtYearName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYearName.TextChanged
    '    txtYearName.Focus()
    'End Sub

    Protected Sub txtCourseName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCourseName.TextChanged
        txtCourseName.Focus()
    End Sub

    Protected Sub txtBatchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBatchName.TextChanged
        txtBatchName.Focus()
    End Sub

    Protected Sub cmbdojdob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdojdob.TextChanged
        cmbdojdob.Focus()
    End Sub
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
    Protected Sub RBReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBReport.SelectedIndexChanged

    End Sub
End Class
