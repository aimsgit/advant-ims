
Partial Class RptStudAttendanceBySub
    Inherits BasePage

    Dim DL As New DLStudAttendBySub
    Dim dt, dt1, dt4, dt5 As New DataTable
    Dim fromdate As DateTime
    Dim todate As DateTime
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ValidationMessage(1014)
        Try
            Dim BR As String = ddlBranch.SelectedValue
            Dim Subj As Integer = cmbSubject.SelectedValue
            Dim Batch, SemesterId As String
            'Dim ES As String = ddlElecSub.SelectedValue
            Dim StdId As String = ddlStudent.SelectedValue
            Dim Min As Integer = ddlMin.SelectedValue
            Dim Max As Integer = ddlMax.SelectedValue
            Dim SortBy As Integer = ddlSort.SelectedValue
            Dim Category As Integer = ddlcategry.SelectedValue
            Dim categoryname As String = ddlcategry.SelectedItem.Text

            If ddlBranch.SelectedItem.Text = " Select" Or cmbSubject.SelectedItem.Text = " Select" Then
                msginfo.Text = ValidationMessage(1117)

            ElseIf txtFromDateExt.Text = "" Then
                msginfo.Text = ValidationMessage(1117)
            Else
                fromdate = txtFromDateExt.Text
            End If

            If txtToDateExt.Text = "" Then
                msginfo.Text = ValidationMessage(1117)
            Else
                todate = txtToDateExt.Text
            End If

            If ddlBranch.SelectedItem.Text = " Select" Or cmbSubject.SelectedItem.Text = " Select" Or txtFromDateExt.Text = "" Or txtToDateExt.Text = "" Then
                msginfo.Text = ValidationMessage(1117)

            ElseIf fromdate > todate Then
                msginfo.Text = ValidationMessage(1075)

            ElseIf CInt(ddlMin.SelectedValue) > CInt(ddlMax.SelectedValue) Then
                msginfo.Text = ValidationMessage(1222)

            Else
                Batch = 0
                SemesterId = 0
                dt4 = DL.BatchAccess(Subj)
                If dt4.Rows.Count > 0 Then
                    '   Subject = dt.Rows(i).Item("Subject").ToString
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
                        dt5 = DL.SemAccess(Subj, Batch, fromdate, todate)
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
                End If
                Dim qrystring As String = "RptStudAttendanceBySubV.aspx?" & "&BranchCode=" & BR & "&Batch=" & Batch & "&Semester=" & SemesterId & "&Subject=" & Subj & "&StudentID=" & StdId & "&fromdate=" & fromdate & "&todate=" & todate & "&Min=" & Min & "&Max=" & Max & "&SortBy=" & SortBy & "&Category=" & Category & "&categoryname=" & categoryname
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                msginfo.Text = ValidationMessage(1014)
            End If


        Catch ex As Exception
            msginfo.Text = ValidationMessage(1055)
        End Try
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
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

    Protected Sub BtnDetRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetRpt.Click
        msginfo.Text = ValidationMessage(1014)
        Try
            Dim BR As String = ddlBranch.SelectedValue
            Dim Subj As String = cmbSubject.SelectedValue
            Dim Batch, SemesterId As String
            'Dim ES As String = ddlElecSub.SelectedValue
            Dim StdId As String = ddlStudent.SelectedValue
            Dim Min As Integer = ddlMin.SelectedValue
            Dim Max As Integer = ddlMax.SelectedValue
            Dim SortBy As Integer = ddlSort.SelectedValue
            Dim Category As Integer = ddlcategry.SelectedValue
            Dim categoryname As String = ddlcategry.SelectedItem.Text

            If ddlBranch.SelectedItem.Text = " Select" Or cmbSubject.SelectedItem.Text = " Select" Then
                msginfo.Text = ValidationMessage(1117)

            ElseIf txtFromDateExt.Text = "" Then
                msginfo.Text = ValidationMessage(1117)
            Else
                fromdate = txtFromDateExt.Text
            End If

            If txtToDateExt.Text = "" Then
                msginfo.Text = ValidationMessage(1117)
            Else
                todate = txtToDateExt.Text
            End If

            If ddlBranch.SelectedItem.Text = " Select" Or cmbSubject.SelectedItem.Text = " Select" Or txtFromDateExt.Text = "" Or txtToDateExt.Text = "" Then
                msginfo.Text = ValidationMessage(1117)

            ElseIf fromdate > todate Then
                msginfo.Text = ValidationMessage(1075)
            Else
                Batch = 0
                SemesterId = 0
                dt4 = DL.BatchAccess(Subj)
                If dt4.Rows.Count > 0 Then
                    '   Subject = dt.Rows(i).Item("Subject").ToString
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
                        dt5 = DL.SemAccess(Subj, Batch, fromdate, todate)
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
                End If
                Dim qrystring As String = "RptStudAttendanceBySubDetailedV.aspx?" & "&BranchCode=" & BR & "&Batch=" & Batch & "&Semester=" & SemesterId & "&Subject=" & Subj & "&StudentID=" & StdId & "&fromdate=" & fromdate & "&todate=" & todate & "&SortBy=" & SortBy & "&Min=" & Min & "&Max=" & Max & "&Category=" & Category & "&categoryname=" & categoryname
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                msginfo.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1055)
        End Try

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Session("GStatus") = ""
        Response.Redirect("Report.aspx")
    End Sub
End Class
