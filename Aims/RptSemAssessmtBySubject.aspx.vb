
Partial Class RptSemAssessmtBySubject
    Inherits BasePage
    Dim RptType, SortType As Integer
    Dim SubId, StudId, AsstId, id, id1 As Integer
    Dim dt, dt4, dt5 As New DataTable
    Dim FromDate, ToDate As Date
    Dim ReportType As String
    Dim Subject As Integer
    Dim Batch, SemesterId As String
    Dim DL As New DLRptSemAssessmtBySubject

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim RepType As String
        Dim ReportType As Integer
        msginfo.Text = ""
        Dim FromDate As Date
        Dim ToDate As Date

        'If Session("LoginType") = "Others" Then
        Dim dt1 As New DataTable


        SubId = cmbSubject.SelectedValue
        AsstId = ddlass.SelectedValue
        RepType = ddlRptType.SelectedItem.ToString
        id = ddlSort.SelectedValue
        ReportType = ddlRptType.SelectedValue
        StudId = ddlStudent.SelectedValue
        If txtFrmDate.Text = "" Then
            msginfo.Text = "Please Select From Date."
            Exit Sub
        Else
            FromDate = txtFrmDate.Text
        End If
        If txtTodate.Text = "" Then
            msginfo.Text = "Please Select To Date."
            Exit Sub
        Else
            ToDate = txtTodate.Text
        End If
        msginfo.Text = ""
        SubId = cmbSubject.SelectedValue
        dt4 = DL.BatchAccess(SubId)
        If dt4.Rows.Count > 0 Then
            '   Subject = dt.Rows(i).Item("Subject").ToString
            Dim str As String = ""
            Dim str1 As String = ""
            Dim id As String = ""
            Dim i, i1 As Integer
            Dim j, j1 As Integer
            i = 0
            j = dt4.Rows.Count
            If j > 0 Then
                While j > 0
                    str = dt4.Rows(i).Item("BatchID").ToString
                    Batch = str + "," + Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                Batch = 0
            End If
            dt5 = DL.SemAccess(Batch, SubId, FromDate, ToDate)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    SemesterId = str1 + "," + SemesterId
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                SemesterId = 0
            End If
        End If

        'id1 is used to identify whether it is parent or student login 
        'id1 = 0
        If txtFrmDate.Text = "" Then
            FromDate = "01-01-1900"
        Else
            FromDate = txtFrmDate.Text
        End If

        If txtTodate.Text = "" Then
            ToDate = "01-01-3000"
        Else
            ToDate = txtTodate.Text

        End If


        If (CDate(FromDate) > CDate(ToDate)) Then
            msginfo.Text = "From Date cannot be greater than To Date."

        Else

            Dim qrystring As String = "RptSemAssessmtBySubjectV.aspx?" & "&SubId=" & SubId & "&AsstId=" & AsstId & "&ReportType=" & ReportType & "&FromDate=" & FromDate & "&id=" & id & "&ToDate=" & ToDate & "&StudId=" & StudId & "&RepType=" & RepType & "&Batch=" & Batch & "&SemesterId=" & SemesterId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            msginfo.Text = ""
        End If

        'End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'txtFrmDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtTodate.Text = Format(Today, "dd-MMM-yyyy")
        End If

    End Sub

    Protected Sub cmbSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubject.SelectedIndexChanged

        If txtFrmDate.Text = "" Then
            msginfo.Text = "Please Select From Date."
            Exit Sub
        Else
            FromDate = txtFrmDate.Text
        End If
        If txtTodate.Text = "" Then
            msginfo.Text = "Please Select To Date."
            Exit Sub
        Else
            ToDate = txtTodate.Text
        End If
        msginfo.Text = ""
        SubId = cmbSubject.SelectedValue
        dt4 = DL.BatchAccess(SubId)
        If dt4.Rows.Count > 0 Then
            '   Subject = dt.Rows(i).Item("Subject").ToString
            Dim str As String = ""
            Dim str1 As String = ""
            Dim id As String = ""
            Dim i, i1 As Integer
            Dim j, j1 As Integer
            i = 0
            j = dt4.Rows.Count
            If j > 0 Then
                While j > 0
                    str = dt4.Rows(i).Item("BatchID").ToString
                    Batch = str + "," + Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                Batch = 0
            End If
            dt5 = DL.SemAccess(Batch, SubId, FromDate, ToDate)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    SemesterId = str1 + "," + SemesterId
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                SemesterId = 0
            End If
        End If
        'Session("SemesterID") = dt4.Rows(0)("SemesterID")
        'Session("BatchID") = dt5.Rows(0)("BatchID")
        dt = DL.GetStudentNameCombo1(Batch, SubId, SemesterId)

        ddlStudent.DataSource = dt
        ddlStudent.DataBind()
    End Sub
End Class
