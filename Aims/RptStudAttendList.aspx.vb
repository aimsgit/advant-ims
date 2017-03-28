
Partial Class RptStudAttendList
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
            msginfo.Text = ValidationMessage(1212)

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
                    msginfo.Text = ValidationMessage(1075)
                Else
                    'If id = 0 Then
                    msginfo.Text = ValidationMessage(1014)

                    Dim qrystring As String = "RptStudAttendListV.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&Semester=" & Semester & "&id=" & id & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate & "&RptType=" & RptType & "&Subject=" & Subject & "&SubSubgrp=" & SubSubgrp
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                    'Else
                    '    msginfo.Text = ""
                    '    Dim qrystring As String = "RptStudAttendListV1.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&Semester=" & Semester
                    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

                End If

            Else
                msginfo.Text = ValidationMessage(1014)
                Dim qrystring As String = "RptStudAttendListV.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&Semester=" & Semester & "&id=" & id & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate & "&RptType=" & RptType & "&Subject=" & Subject & "&SubSubgrp=" & SubSubgrp
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
    'Code written fro multilingual by Niraj on 10 jan 2014
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
                If dtl.Rows(i - 1).Item("ControlCommandName") = Btnreport.CommandName Then
                    Dim myButton As Button = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = btnBack.CommandName Then
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

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
           
        End If
    End Sub
End Class
