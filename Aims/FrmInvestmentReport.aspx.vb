
Partial Class FrmInvestmentReport
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ValidationMessage(1014)
        Dim QS As String
        Dim fromdate As Date
        Dim todate As Date
        Dim Investment, Bank, BalAmt As String
        Dim ROI As String

        Investment = cmbInvest.SelectedValue
        Bank = ddlBank.SelectedValue
        ROI = DdlRoi.SelectedValue
        BalAmt = DdlbalAmt.SelectedValue
        Try
            Multilingual()
            If txtfromdate.Text <> "" And txttodate.Text <> "" Then

                If CType(txtfromdate.Text, Date) > CType(txttodate.Text, Date) Then
                    msginfo.Text = ValidationMessage(1075)
                    'msginfo.Width = 350
                    Exit Sub
                End If
            End If
            If txtfromdate.Text = "" Then
                fromdate = "04-01-1900"
            Else
                fromdate = txtfromdate.Text
            End If
            If txttodate.Text = "" Then
                todate = Format(Today, "dd-MMM-yyyy")
            Else
                todate = txttodate.Text
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptInvestmentMasterV.aspx?" & QueryStr.Querystring() & "&fromdate=" & fromdate & "&todate=" & todate & "&InvestmentType=" & Investment & "&Bank=" & Bank & "&ROI=" & ROI & "&BalAmt=" & BalAmt
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

            If txtfromdate.Text = "04-01-1900" Then
                txtfromdate.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1055)
        End Try

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim QS, heading As String
        'QS = Request.QueryString.Get("QS")
        'heading = Request.QueryString.Get("heading")
        'Me.Lblheading.Text = heading

        If Not IsPostBack Then
            Dim CloseDate As Date
            Dim cd As String
            Control_Text_Multilingual()
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            txttodate.Text = cd
            txtfromdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
        End If

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Code written fro multilingual by Niraj on 05 Sep 2013
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

                'ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridLabel" Then
                '    j = GrdAcdYear.Columns.Count
                '    While (j <> 0)
                '        If GrdAcdYear.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("ControlCommandName") Then
                '            GrdAcdYear.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("Default_Text")
                '        End If
                '        j = j - 1
                '    End While
                '    i = i - 1
                'ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridButton" Then
                '    k = GrdAcdYear.Rows.Count
                '    If dtl.Rows(i - 1).Item("ControlCommandName") = "Acknowledge" Then
                '        While (k <> 0)
                '            Dim lnkCanc As LinkButton = CType(GrdAcdYear.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                '            lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                '            k = k - 1
                '        End While
                '    ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Edit" Then
                '        k = GrdAcdYear.Rows.Count
                '        While (k <> 0)
                '            Dim lnkCanc As LinkButton = CType(GrdAcdYear.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                '            lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                '            k = k - 1
                '        End While
                '    ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Delete" Then
                '        k = GrdAcdYear.Rows.Count
                '        While (k <> 0)
                '            Dim lnkCanc As LinkButton = CType(GrdAcdYear.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                '            lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                '            k = k - 1
                '        End While
                '    End If
                '    i = i - 1
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
    Public Sub Control_Text_Multilingual()
        Dim dtll As DataTable
        Dim FormName As String = "EndowmentDepositMaster"
        Dim LanguageID As Integer
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        If LanguageID <> 0 Then
            dtll = GlobalFunction.GetChangeLanguage(FormName, LanguageID)
            Session("Control_Text") = dtll
            Multilingual()
        End If
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
