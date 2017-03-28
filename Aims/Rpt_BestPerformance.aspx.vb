
Partial Class Rpt_BestPerformance
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'code by ARUN'
            Dim d As Date = Date.Today

            txttodate.Text = Format(d, "dd-MMM-yyyy")
            txtFrmdate.Text = Format(d, "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try
            Dim Rbid As String
            Dim Rbid2 As String
            Dim batch As Integer
            Dim batch2 As String
            Dim subject As Integer
            Dim fromdate As Date
            Dim todate As Date
            Dim Assmt As Integer
            Dim Batchname As String
            Dim subjectname As String
            Dim Assmtname As String
            batch = ddlbatch.SelectedValue
            subject = ddlsubject.SelectedValue
            Assmt = ddlassesment.SelectedValue
            fromdate = txtFrmdate.Text
            todate = txttodate.Text
            Batchname = ddlbatch.SelectedItem.Text
            subjectname = ddlsubject.SelectedItem.Text
            Assmtname = ddlassesment.SelectedItem.Text
            If txtFrmdate.Text = "" Then

                fromdate = Format(Today, "dd-MMM-yyyy")
            End If
            If txttodate.Text = "" Then
                todate = Format(Today, "dd-MMM-yyyy")
            End If
            If RbType.SelectedValue = "S" Then
                Rbid = "S"
            ElseIf RbType.SelectedValue = "F" Then
                Rbid = "F"
            ElseIf RbType.SelectedValue = "SB" Then
                Rbid = "SB"
            ElseIf RbType.SelectedValue = "P" Then
                Rbid = "P"
            End If
            If RbCriteria.SelectedValue = "A" Then
                Rbid2 = "A"
            ElseIf RbCriteria.SelectedValue = "M" Then
                Rbid2 = "M"
            End If
            batch2 = ddlbatch.SelectedItem.Text


            If fromdate > todate Then
                lblerror.Text = "Start date should not be greater than End date."
                txttodate.Focus()
                Exit Sub
            End If
            Dim qrystring As String = "Rpt_BestPerformanceV.aspx?" & QueryStr.Querystring() & "&batch=" & batch & "&subject=" & subject & "&Assmt=" & Assmt & "&fromdate=" & fromdate & "&todate=" & todate & "&Rbid=" & RbType.SelectedValue & "&Rbid2=" & RbCriteria.SelectedValue & "&Batchname=" & Batchname & "&subjectname=" & subjectname & "&Assmtname=" & Assmtname & "&batch2=" & batch2
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        Catch ex As Exception
            lblerror.Text = "Enter Correct Date."
        End Try

    End Sub

    Protected Sub Btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnview.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
