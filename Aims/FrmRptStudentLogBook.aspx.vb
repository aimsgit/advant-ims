
Partial Class FrmRptStudentLogBook
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ValidationMessage(1014)
        Dim QS As String
        Dim BatchID As Integer
        Dim StdID As Integer
        Dim LogID As Integer
        Dim fromdate As Date
        Dim todate As Date
        Try
            If Txtfdate.Text <> "" And Txttodate.Text <> "" Then

                If CType(Txtfdate.Text, Date) > CType(Txttodate.Text, Date) Then
                    msginfo.Text = ValidationMessage(1075)
                    Exit Sub
                End If
            End If
            BatchID = ddlBatch.SelectedValue
            StdID = ddlStudent.SelectedValue
            LogID = ddlLogtype.SelectedValue
            If Txtfdate.Text = "" Then
                fromdate = "01-01-1900"
            Else
                fromdate = Txtfdate.Text
            End If
            If Txttodate.Text = "" Then
                todate = "01-01-4000"
            Else
                todate = Txttodate.Text
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptStudentLogBookV.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&StdID=" & StdID & "&LogID=" & LogID & "&fromdate=" & fromdate & "&todate=" & todate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

            If Txtfdate.Text = "01-01-1900" Then
                Txtfdate.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1055)
        End Try

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
           
            Dim CloseDate As Date
            Dim cd As String
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            Txttodate.Text = cd
        End If

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Code written fro multilingual by Niraj on 23 jan 2014
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
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = btnBack.CommandName Then
                    Dim myButton As Button = CType(Me.Updatepanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1

                Else
                    i = i - 1
                End If

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

