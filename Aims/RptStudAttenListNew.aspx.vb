
Partial Class RptStudAttenListNew
    Inherits BasePage

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Dim BatchID, Semester, id, RptType, Subject, SubSubgrp As Integer

        BatchID = ddlBatchName.SelectedValue
        Semester = DDLSemester.SelectedValue
        Subject = cmbSubject.SelectedValue
        SubSubgrp = ddlSubjectSubGrp.SelectedValue
        id = ddlSort.SelectedValue
        RptType = ddlRptType.SelectedValue
        Dim FrmDate, ToDate As Date

        If ddlBatchName.SelectedValue = "0" Or DDLSemester.SelectedValue = "0" Then
            msginfo.Text = "Enter all Mandatory Fields."

        Else
            Dim Dt As DataTable
            Dt = stdAttndance.StudentStartEndDate(BatchID, Semester)
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
                    msginfo.Text = "FromDate Cannot be greater than ToDate."
                Else
                    'If id = 0 Then
                    msginfo.Text = ""
                    Dim qrystring As String = "RptStudAttenListNewV.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&Semester=" & Semester & "&id=" & id & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate & "&RptType=" & RptType & "&Subject=" & Subject & "&SubSubgrp=" & SubSubgrp
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                    'Else
                    '    msginfo.Text = ""
                    '    Dim qrystring As String = "RptStudAttendListV1.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&Semester=" & Semester
                    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

                End If

            Else
                msginfo.Text = ""
                Dim qrystring As String = "RptStudAttenListNewV.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&Semester=" & Semester & "&id=" & id & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate & "&RptType=" & RptType & "&Subject=" & Subject & "&SubSubgrp=" & SubSubgrp
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

            End If
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    Protected Sub ddlBatchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.SelectedIndexChanged
        ddlBatchName.Focus()
    End Sub
    Protected Sub DDLSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLSemester.SelectedIndexChanged
        DDLSemester.Focus()
        Dim dt As New DataTable
        Dim FrmDate, ToDate As Date
        Dim Bat As String = ddlBatchName.SelectedValue
        Dim Sem As String = DDLSemester.SelectedValue
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
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

End Class
