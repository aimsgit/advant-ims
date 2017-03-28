'Author-->Anchala Verma
'Date---->17-April-2012
Partial Class frmFeeCollectionReport
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        'Dim AY As String = cmbAcademic.SelectedValue
        Dim Bat As String = cmbBatch.SelectedValue
        Dim Sem As String = 0
        Dim StartDate, EndDate As Date
        Dim Payment As Integer = ddlPaymentMethod.SelectedValue
        Dim StudentCode As Integer = ddlstucode.SelectedValue
        Dim CollectionType As Integer = ddlCollType.SelectedValue
        Dim CollectionTypeName As String = ddlCollType.SelectedItem.Text
        Try
            If txtSDate.Text = "" Then
                StartDate = "1/1/1900"
            Else
                StartDate = txtSDate.Text
            End If
            If txtEDate.Text = "" Then
                EndDate = "1/1/9100"
            Else
                EndDate = txtEDate.Text
            End If

            If StartDate <= EndDate Then
                Dim qrystring As String = "RptFeeCollectionReport.aspx?" & "&Batch=" & Bat & "&Semester=" & Sem & "&Payment=" & Payment & "&StudentCode=" & StudentCode & "&StartDate=" & StartDate & "&EndDate=" & EndDate & "&CollectionType=" & CollectionType & "&CollectionTypeName=" & CollectionTypeName
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                msginfo.Text = "Start Date Should Not be Greater than End Date."
            End If
 Catch ex As Exception
            msginfo.Text = "Please Enter Correct data"
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Session("GStatus") = ""
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    'Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
    '    Dim dt As DataTable
    '    Dim bat, sem As Integer

    '    bat = cmbBatch.SelectedValue
    '    sem = cmbSemester.SelectedValue
    '    dt = stdAttndance.StudentStartEndDate(bat, sem)
    '    cmbSemester.Focus()
    '    If dt.Rows.Count > 0 Then
    '        If dt.Rows(0).Item("StartDate") Is DBNull.Value Then
    '            txtSDate.Text = ""
    '        Else
    '            txtSDate.Text = Format(dt.Rows(0).Item("StartDate"), "dd-MMM-yyyy")
    '        End If
    '        If dt.Rows(0).Item("EndDate") Is DBNull.Value Then
    '            txtEDate.Text = ""
    '        Else
    '            txtEDate.Text = Format(dt.Rows(0).Item("EndDate"), "dd-MMM-yyyy")
    '        End If
    '    Else
    '        txtSDate.Text = ""
    '        txtEDate.Text = ""
    '    End If

    'End Sub

    'Protected Sub cmbAcademic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.SelectedIndexChanged
    '    cmbAcademic.Focus()
    'End Sub

    Protected Sub cmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.SelectedIndexChanged
        cmbBatch.Focus()
        Dim dt As DataTable
        Dim bat, sem As Integer
        sem = 0
        bat = cmbBatch.SelectedValue
        dt = stdAttndance.StudentStartEndDate(bat, sem)
        'If dt.Rows.Count > 0 Then
        '    If dt.Rows(0).Item("StartDate") Is DBNull.Value Then
        '        txtSDate.Text = ""
        '    Else
        '        txtSDate.Text = Format(dt.Rows(0).Item("StartDate"), "dd-MMM-yyyy")
        '    End If

        '    txtEDate.Text = Format(Today(), "dd-MMM-yyyy")
        'Else
        '    txtSDate.Text = ""
        '    txtEDate.Text = ""
        'End If
    End Sub

    Protected Sub ddlPaymentMethod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod.SelectedIndexChanged
        ddlPaymentMethod.Focus()
    End Sub

    Protected Sub ddlstucode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstucode.SelectedIndexChanged
        ddlstucode.Focus()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtSDate.Text = Format(Today, "dd-MMM-yyyy")
            txtEDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
End Class
