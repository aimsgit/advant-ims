Partial Class RptGeneralPartyLedgerV
    Inherits BasePage
    'Dim GlobalFunction As New GlobalFunction
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            Try
                Dim StartDate As Date = CDate(Me.txtStartDate.Text)
                Dim EndDate As Date = CDate(Me.txtEndDate.Text)
                Dim PartyName As String = Me.txtParty.Text
                Dim PartyType As String = Me.cmbPType.SelectedItem.Text
                Dim PR As String
                PR = DDLProjectName.SelectedValue
                If cmbPType.Text = "None" Then
                    Session("sesPartyType") = ""
                Else
                    Session("sesPartyType") = cmbPType.SelectedItem
                End If

                If txtParty.Text = "" Or txtParty.Text = Nothing Then
                    Session("sesPartyId") = 0
                Else
                    Session("sesPartyId") = HidPartyTypeId.Value
                    'Session("sesPartyId") = GlobalFunction.IdCutter(txtParty.Text)
                End If

                Dim qrystring As String = ""
                Dim qry_str As String = "&FinStartDate=" & StartDate & "&FinEndDate=" & EndDate & "&PartyName=" & PartyName & "&PartyType=" & PartyType & "&PR=" & PR
                qrystring = "RptGeneralCustomerLedgerV.aspx?" & qry_str

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Catch ex As Exception

            End Try
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub
    Sub SplitName(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("Party") = parts(0).ToString()
            txtParty.Text = parts(0).ToString()
            HidPartyTypeId.Value = parts(1).ToString()
            
        Else
            txtParty.AutoPostBack = True
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
            cmbPType.Focus()
        End If

        If txtParty.Text <> "" Then
            SplitName(txtParty.Text)
        Else
            txtParty.AutoPostBack = True

            SplitName(txtParty.Text)
        End If
        'AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
        'AutoCompleteExtender1.ServiceMethod = "getBankExt"
    End Sub

    'Sub FillAutoExtender()

    '    If cmbPType.SelectedValue.ToString = 1 Then

    '        AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
    '        AutoCompleteExtender1.ServiceMethod = "getStudentNameExt"

    '    ElseIf cmbPType.SelectedValue.ToString = 2 Then

    '        AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
    '        AutoCompleteExtender1.ServiceMethod = "getSupExt"

    '    ElseIf cmbPType.SelectedValue.ToString = 3 Then

    '        AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
    '        AutoCompleteExtender1.ServiceMethod = "getBankExt"

    '    ElseIf cmbPType.SelectedValue.ToString = 4 Then

    '        AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
    '        AutoCompleteExtender1.ServiceMethod = "getEmpExt"

    '    ElseIf cmbPType.SelectedValue.ToString = 5 Then

    '        AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
    '        AutoCompleteExtender1.ServiceMethod = "getOthPrtyExt"

    '    End If
    'End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub cmbPType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPType.SelectedIndexChanged
        Session("DayBkPType") = cmbPType.SelectedValue
        txtParty.Text = ""
    End Sub

    Protected Sub cmbPType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPType.TextChanged
        cmbPType.Focus()
    End Sub
End Class
