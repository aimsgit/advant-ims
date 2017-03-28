
Partial Class RptNewStudAttendwitDate


    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfored.Text = ValidationMessage(1014)
        Try
            Dim BR As String = ddlBranch.SelectedValue
            'Dim AY As Integer = cmbAcademic.SelectedValue
            Dim Bat As Integer = ddlBatch.SelectedValue
            Dim Sem As Integer = cmbSemester.SelectedValue
            Dim Subj As Integer = cmbSubject.SelectedValue
            Dim SubjectSubgrp As Integer = ddlSubjectSubGrp.SelectedValue
            Dim SortBY As Integer = ddlSort.SelectedValue

            Dim FrmDate, ToDate As Date

            If ddlBranch.SelectedItem.Text = "Select" Or ddlBatch.SelectedItem.Text = "Select" Or Sem = 0 Then
                msginfored.Text = ValidationMessage(1117)
            Else
                Dim Dt As DataTable
                Dt = stdAttndance.StudentStartEndDate(Bat, Sem)

                If txtFromDate.Text = "" Then
                    FrmDate = Format(Dt.Rows(0).Item("StartDate"), "dd-MMM-yyyy").ToString
                Else
                    FrmDate = txtFromDate.Text
                End If

                If txtToDate.Text = "" Then
                    ToDate = Format(Dt.Rows(0).Item("StartDate"), "dd-MMM-yyyy").ToString
                Else
                    ToDate = txtToDate.Text
                End If


                If txtFromDate.Text <> "" And txtToDate.Text <> "" Then
                    If CDate(FrmDate) > CDate(ToDate) Then
                        msginfored.Text = ValidationMessage(1075)
                    Else
                        Dim qrystring As String = "RptNewStudAttendwitDateV.aspx?" & "&BranchCode=" & BR & "&Batch=" & Bat & "&Semester=" & Sem & "&Subj=" & Subj & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate & "&SortBy=" & SortBY & "&SubjectSubgrp=" & SubjectSubgrp
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                        msginfored.Text = ValidationMessage(1014)
                    End If
                Else
                    Dim qrystring As String = "RptNewStudAttendwitDateV.aspx?" & "&BranchCode=" & BR & "&Batch=" & Bat & "&Semester=" & Sem & "&Subj=" & Subj & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate & "&SortBy=" & SortBY & "&SubjectSubgrp=" & SubjectSubgrp
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                    msginfored.Text = ValidationMessage(1014)
                End If
            End If
        Catch ex As Exception
            msginfored.Text = ValidationMessage(1059)
        End Try

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
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

    'Protected Sub cmbBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.TextChanged
    '    ddlBatch.Focus()
    'End Sub

    'Protected Sub cmbSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.TextChanged
    '    cmbSemester.Focus()
    'End Sub


    'Protected Sub ddlBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.TextChanged
    '    ddlBranch.Focus()
    'End Sub



    'Protected Sub cmbSubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubject.TextChanged
    '    cmbSubject.Focus()
    'End Sub

    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        Dim dt As New DataTable
        Dim FrmDate, ToDate As Date
        Dim Bat As String = ddlBatch.SelectedValue
        Dim Sem As String = cmbSemester.SelectedValue
        dt = stdAttndance.StudentStartEndDate(Bat, Sem)

        If dt.Rows.Count = 0 Then
            txtToDate.Text = ""
            txtFromDate.Text = ""
            FrmDate = "01/01/1800"
            ToDate = "01/01/3000"
        Else
            If Bat = 0 Or Sem = 0 Then
                txtToDate.Text = ""
                txtFromDate.Text = ""
                FrmDate = "01/01/1800"
                ToDate = "01/01/3000"
            Else
                txtFromDate.Text = Format(dt.Rows(0).Item("StartDate"), "dd-MMM-yyyy").ToString
                txtToDate.Text = Format(dt.Rows(0).Item("EndDate"), "dd-MMM-yyyy").ToString
            End If
        End If
    End Sub
  
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


