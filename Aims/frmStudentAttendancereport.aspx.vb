'Author-->Anchala Verma
'Date---->26-Mar-2012
Partial Class frmStudentAttendancereport
    Inherits BasePage
    Dim StdAttndance As New stdAttndance
    Dim fromdate As DateTime
    Dim todate As DateTime

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Try
            Dim BR As String = ddlBranch.SelectedValue
            'Dim AY As String = cmbAcademic.SelectedValue
            Dim Bat As String = ddlbatch.SelectedValue
            Dim Sem As String = cmbSemester.SelectedValue
            Dim Subj As String = cmbSubject.SelectedValue
            Dim CT As String = ddlClasstype.SelectedValue
            Dim StdId As String = ddlStudent.SelectedValue
            Dim Min As Integer = ddlMin.SelectedValue
            Dim Max As Integer = ddlMax.SelectedValue
            Dim SortBy As Integer = ddlSort.SelectedValue

            Dim dt As New DataTable

            dt = StdAttndance.StudentStartEndDate(Bat, Sem)
            If ddlBranch.SelectedItem.Text = "Select" Or ddlbatch.SelectedItem.Text = "Select" Or Sem = 0 Then
                msginfo.Text = "Please Enter the Mandatory Fields."

            ElseIf txtFromDateExt.Text = "" Then
                fromdate = "01/01/1800"
            Else
                fromdate = txtFromDateExt.Text
            End If

            If txtToDateExt.Text = "" Then
                todate = "01/01/3000"
            Else
                todate = txtToDateExt.Text
            End If

            If ddlBranch.SelectedItem.Text = "Select" Or ddlbatch.SelectedItem.Text = "Select" Or Sem = 0 Then
                msginfo.Text = "Please Enter the Mandatory Fields."
            Else

                If fromdate > todate Then
                    msginfo.Text = "From Date cannot be greater than To Date."
                Else
                    If CInt(ddlMin.SelectedValue) > CInt(ddlMax.SelectedValue) Then
                        msginfo.Text = "Min Percentage cannot be greater than Max percentage."
                    Else
                        Dim qrystring As String = "RptStudentAttendanceDetails.aspx?" & "&BranchCode=" & BR & "&Batch=" & Bat & "&Semester=" & Sem & "&Subject=" & Subj & "&ClassType=" & CT & "&StudentID=" & StdId & "&fromdate=" & fromdate & "&todate=" & todate & "&Min=" & Min & "&Max=" & Max & "&SortBy=" & SortBy
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                        msginfo.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            msginfo.Text = "Please enter Valid Date."
        End Try

    End Sub

    Protected Sub BtnDetRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetRpt.Click
        Try
            msginfo.Text = ""
            Dim BR As String = ddlBranch.SelectedValue
            'Dim AY As String = cmbAcademic.SelectedValue
            Dim Bat As String = ddlbatch.SelectedValue
            Dim Sem As String = cmbSemester.SelectedValue
            Dim Subj As String = cmbSubject.SelectedValue
            Dim CT As String = ddlClasstype.SelectedValue
            Dim StdId As String = ddlStudent.SelectedValue
            Dim SortBy As Integer = ddlSort.SelectedValue


            If txtFromDateExt.Text = "" Then
                fromdate = "01/01/1800"
            Else
                fromdate = txtFromDateExt.Text
            End If

            If txtToDateExt.Text = "" Then
                todate = "01/01/3000"
            Else
                todate = txtToDateExt.Text
            End If

            If ddlBranch.SelectedItem.Text = "Select" Or ddlbatch.SelectedItem.Text = "Select" Or Sem = 0 Then
                msginfo.Text = "Please Enter the Mandatory Fields."
            Else
                If fromdate > todate Then
                    msginfo.Text = "From Date cannot be greater than To Date."
                Else
                    Dim qrystring As String = "RptStudentAttendanceDetailed.aspx?" & "&BranchCode=" & BR & "&Batch=" & Bat & "&Semester=" & Sem & "&Subject=" & Subj & "&ClassType=" & CT & "&StudentID=" & StdId & "&fromdate=" & fromdate & "&todate=" & todate & "&SortBy=" & SortBy
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                    msginfo.Text = ""
                End If
            End If
        Catch ex As Exception
            msginfo.Text = "Please enter Valid Date."
        End Try
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Session("GStatus") = ""
        Response.Redirect("Report.aspx")
    End Sub




    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        Dim dt As New DataTable
        Dim Bat As String = ddlbatch.SelectedValue
        Dim Sem As String = cmbSemester.SelectedValue
        dt = StdAttndance.StudentStartEndDate(Bat, Sem)

        If dt.Rows.Count = 0 Then
            txtToDateExt.Text = ""
            txtFromDateExt.Text = ""
            fromdate = "01/01/1800"
            todate = "01/01/3000"
        Else
            If Bat = 0 Or Sem = 0 Then
                txtToDateExt.Text = ""
                txtFromDateExt.Text = ""
                fromdate = "01/01/1800"
                todate = "01/01/3000"
            Else
                txtFromDateExt.Text = Format(dt.Rows(0).Item("StartDate"), "dd-MMM-yyyy").ToString
                txtToDateExt.Text = Format(dt.Rows(0).Item("EndDate"), "dd-MMM-yyyy").ToString
            End If
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            ddlBranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If

    End Sub

    'Protected Sub cmbAcademic_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.TextChanged
    '    cmbAcademic.Focus()
    'End Sub

    Protected Sub cmbBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.TextChanged
        ddlbatch.Focus()
    End Sub

    Protected Sub cmbSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.TextChanged
        cmbSemester.Focus()
    End Sub

    Protected Sub cmbSubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubject.TextChanged
        cmbSubject.Focus()
    End Sub

    Protected Sub ddlBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.TextChanged
        ddlBranch.Focus()
    End Sub

    Protected Sub ddlClasstype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlClasstype.TextChanged
        ddlClasstype.Focus()
    End Sub

    Protected Sub ddlMax_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMax.TextChanged
        ddlMax.Focus()
    End Sub

    Protected Sub ddlMin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMin.TextChanged
        ddlMin.Focus()
    End Sub

    Protected Sub ddlStudent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStudent.TextChanged
        ddlStudent.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
