
Partial Class RptStudAttendWitElecSub
    Inherits BasePage
    Dim StdAttndance As New stdAttndance
    Dim fromdate As DateTime
    Dim todate As DateTime

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ValidationMessage(1014)
        Try
            Dim BR As String = ddlBranch.SelectedValue
            'Dim AY As String = cmbAcademic.SelectedValue
            Dim Bat As String = ddlbatch.SelectedValue
            Dim Sem As String = cmbSemester.SelectedValue
            Dim Subj As String = cmbSubject.SelectedValue
            'Dim ES As String = ddlElecSub.SelectedValue
            Dim StdId As String = ddlStudent.SelectedValue
            Dim Min As Integer = ddlMin.SelectedValue
            Dim Max As Integer = ddlMax.SelectedValue
            Dim SortBy As Integer = ddlSort.SelectedValue
            Dim Category As Integer = ddlcategry.SelectedValue
            Dim categoryname As String = ddlcategry.SelectedItem.Text

            Dim dt As New DataTable

            dt = StdAttndance.StudentStartEndDate(Bat, Sem)
            If ddlBranch.SelectedItem.Text = "Select" Or ddlbatch.SelectedItem.Text = "Select" Or Sem = 0 Then
                msginfo.Text = ValidationMessage(1117)

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
                msginfo.Text = ValidationMessage(1117)
            Else

                If fromdate > todate Then
                    msginfo.Text = ValidationMessage(1075)
                Else
                    If CInt(ddlMin.SelectedValue) > CInt(ddlMax.SelectedValue) Then
                        msginfo.Text = ValidationMessage(1222)
                    Else
                        Dim qrystring As String = "RptStudAttendWitElecSubSummaryV.aspx?" & "&BranchCode=" & BR & "&Batch=" & Bat & "&Semester=" & Sem & "&Subject=" & Subj & "&StudentID=" & StdId & "&fromdate=" & fromdate & "&todate=" & todate & "&Min=" & Min & "&Max=" & Max & "&SortBy=" & SortBy & "&Category=" & Category & "&categoryname=" & categoryname
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                        msginfo.Text = ValidationMessage(1014)
                    End If
                End If
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1022)
        End Try

    End Sub

    Protected Sub BtnDetRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetRpt.Click
        msginfo.Text = ValidationMessage(1014)
        Dim BR As String = ddlBranch.SelectedValue
        'Dim AY As String = cmbAcademic.SelectedValue
        Dim Bat As String = ddlbatch.SelectedValue
        Dim Sem As String = cmbSemester.SelectedValue
        Dim Subj As String = cmbSubject.SelectedValue
        'Dim ES As String = ddlElecSub.SelectedValue
        Dim StdId As String = ddlStudent.SelectedValue
        Dim SortBy As Integer = ddlSort.SelectedValue
        Dim Min As Integer = ddlMin.SelectedValue
        Dim Max As Integer = ddlMax.SelectedValue
        Dim Category As Integer = ddlcategry.SelectedValue
        Dim categoryname As String = ddlcategry.SelectedItem.Text
        Try
            If txtFromDateExt.Text <> "" And txtToDateExt.Text <> "" Then

                If CType(txtFromDateExt.Text, Date) > CType(txtToDateExt.Text, Date) Then
                    msginfo.Text = "'From Date' cannot be greater than 'To Date'."
                    Exit Sub
                End If
            End If
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
                msginfo.Text = ValidationMessage(1117)
            Else
                If fromdate > todate Then
                    msginfo.Text = ValidationMessage(1075)
                Else
                    Dim qrystring As String = "RptStudAttendWitElecSubDetailedV.aspx?" & "&BranchCode=" & BR & "&Batch=" & Bat & "&Semester=" & Sem & "&Subject=" & Subj & "&StudentID=" & StdId & "&fromdate=" & fromdate & "&todate=" & todate & "&SortBy=" & SortBy & "&Min=" & Min & "&Max=" & Max & "&Category=" & Category & "&categoryname=" & categoryname
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                    msginfo.Text = ValidationMessage(1014)
                End If
            End If
        Catch ex As Exception
            msginfo.Text = "Enter correct date."
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


    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Code written fro multilingual by Niraj on 30 Dev 2013
    ''Retriving the text of controls based on Language

    Sub Multilingual()
        Dim j As Integer
        Dim k As Integer
        Dim dtl As DataTable

        dtl = Session("Control_Text")
        Dim i As Integer = dtl.Rows.Count
        While (i <> 0)
            If dtl.Rows(i - 1).Item("ControlType") = "Label" Then
                Dim myLabel As Label = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Label)
                myLabel.Text = dtl.Rows(i - 1).Item("Default_Text")
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "Button" Then
                If dtl.Rows(i - 1).Item("ControlCommandName") = btnReport.CommandName Then
                    Dim myButton As Button = CType(Me.Updatepanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = BtnDetRpt.CommandName Then
                    Dim myButton As Button = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = btnUpdate.CommandName Then
                    Dim myButton As Button = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                Else
                    i = i - 1
                End If

            ElseIf dtl.Rows(i - 1).Item("ControlType") = "CheckBox" Then
                Dim myCheckbox As CheckBox = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), CheckBox)
                myCheckbox.Text = dtl.Rows(i - 1).Item("Default_Text")
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "RadioButtonList" Then
                Dim myRadiobutton As RadioButtonList = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), RadioButtonList)
                Dim a As Integer = myRadiobutton.Items.Count
                While (a <> 0)
                    For Each li As ListItem In myRadiobutton.Items
                        If li.Value = dtl.Rows(i - 1).Item("ControlCommandName") Then
                            li.Text = dtl.Rows(i - 1).Item("Default_Text")
                        End If
                    Next
                    a = a - 1
                End While
                i = i - 1
            End If
        End While
        'End If
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
End Class



