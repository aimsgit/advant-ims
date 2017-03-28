
Partial Class RptEmpAttenRegister
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim Dept As Integer = ddlDept.SelectedValue
        Dim Emp As Integer = ddlEmp.SelectedValue
        Dim FrmMonth As Integer = ddlFrmMonth.SelectedValue
        Dim ToMonth As Integer = ddlToMonth.SelectedValue
        Dim FrmYear As Integer = ddlFromYear.SelectedItem.Text
        Dim ToYear As Integer = ddlToYear.SelectedItem.Text

        If FrmYear = ToYear Then
            If (FrmMonth > ToMonth) Then
                msginfo.Text = "From Month cannot be greater than To Month."

            ElseIf FrmYear > ToYear Then
                msginfo.Text = "From Year cannot be greater than To Year."

            Else
                Dim qrystring As String = "RptEmpAttenRegisterV.aspx?" & "&Dept=" & Dept & "&Emp=" & Emp & "&FrmMonth=" & FrmMonth & "&ToMonth=" & ToMonth & "&FrmYear=" & FrmYear & "&ToYear=" & ToYear
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                msginfo.Text = ""
                Dim date1 As String
                date1 = Session("CurrentYear")
                Dim dt As DataTable
                dt = QualificationDB.GetYear(date1)
                Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
                ddlToYear.SelectedValue = value
                ddlFromYear.SelectedValue = value
            End If
        Else
            If FrmYear < ToYear Then

                Dim qrystring As String = "RptEmpAttenRegisterV.aspx?" & "&Dept=" & Dept & "&Emp=" & Emp & "&FrmMonth=" & FrmMonth & "&ToMonth=" & ToMonth & "&FrmYear=" & FrmYear & "&ToYear=" & ToYear
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                msginfo.Text = ""
                Dim date1 As String
                date1 = Session("CurrentYear")
                Dim dt As DataTable
                dt = QualificationDB.GetYear(date1)
                Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
                ddlToYear.SelectedValue = value
                ddlFromYear.SelectedValue = value
            Else
                msginfo.Text = "From Year cannot be Greater than To Year."
            End If
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

   
    Protected Sub BtnWorking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnWorking.Click
        msginfo.Text = ""
        Dim Dept As Integer = ddlDept.SelectedValue
        Dim Emp As Integer = ddlEmp.SelectedValue
        Dim FrmMonth As Integer = ddlFrmMonth.SelectedValue
        Dim ToMonth As Integer = ddlToMonth.SelectedValue
        Dim FrmYear As Integer = ddlFromYear.SelectedItem.Text
        Dim ToYear As Integer = ddlToYear.SelectedItem.Text

        If FrmYear = ToYear Then
            If (FrmMonth > ToMonth) Then
                msginfo.Text = "From Month cannot be greater than To Month."

            ElseIf FrmYear > ToYear Then
                msginfo.Text = "From Year cannot be greater than To Year."

            Else
                Dim qrystring As String = "RptEmpAttenRegisterVWorking.aspx?" & "&Dept=" & Dept & "&Emp=" & Emp & "&FrmMonth=" & FrmMonth & "&ToMonth=" & ToMonth & "&FrmYear=" & FrmYear & "&ToYear=" & ToYear
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                msginfo.Text = ""
                Dim date1 As String
                date1 = Session("CurrentYear")
                Dim dt As DataTable
                dt = QualificationDB.GetYear(date1)
                Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
                ddlToYear.SelectedValue = value
                ddlFromYear.SelectedValue = value
            End If
        Else
            If FrmYear < ToYear Then

                Dim qrystring As String = "RptEmpAttenRegisterVWorking.aspx?" & "&Dept=" & Dept & "&Emp=" & Emp & "&FrmMonth=" & FrmMonth & "&ToMonth=" & ToMonth & "&FrmYear=" & FrmYear & "&ToYear=" & ToYear
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                msginfo.Text = ""
                Dim date1 As String
                date1 = Session("CurrentYear")
                Dim dt As DataTable
                dt = QualificationDB.GetYear(date1)
                Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
                ddlToYear.SelectedValue = value
                ddlFromYear.SelectedValue = value
            Else
                msginfo.Text = "From Year cannot be Greater than To Year."
            End If
        End If
    End Sub
End Class
