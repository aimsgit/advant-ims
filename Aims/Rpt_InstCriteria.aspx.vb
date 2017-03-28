
Partial Class Rpt_InstCriteria
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim QS As String
        Dim InstCode As String = ddlInstitute.SelectedValue
        Dim FromDate As DateTime
        Dim ToDate As DateTime
        If txtFromDateExt.Text = "" Then
            FromDate = "01/01/1900"
        Else
            FromDate = txtFromDateExt.Text
        End If
        If txtToDateExt.Text = "" Then
            ToDate = "01/01/1900"
        Else
            ToDate = txtToDateExt.Text
        End If
        QS = Request.QueryString.Get("QS")

        If txtFromDateExt.Text = "" Or txtToDateExt.Text = "" Then
            lblErrorMsg.Text = "Please enter all Mandatory Fields."
        ElseIf CDate(txtFromDateExt.Text) > CDate(txtToDateExt.Text) Then
            lblErrorMsg.Text = " From Date should be Greater than To Date."
        Else

            Dim qrystring As String = "Rpt_CenterEmpStdCount.aspx?" & QueryStr.Querystring() & "&Institute=" & InstCode & "&Fromdate=" & FromDate & "&Todate=" & ToDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblErrorMsg.Text = ""
        End If
    End Sub

    'Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'Dim QS, heading As String
    '    'QS = Request.QueryString.Get("QS")
    '    'heading = Request.QueryString.Get("heading")
    '    'Me.Lblheading.Text = heading

    '    If Not IsPostBack Then
    '        Dim CloseDate As Date
    '        Dim cd As String
    '        CloseDate = System.DateTime.Now
    '        cd = CloseDate.ToString("dd-MMM-yyyy")
    '        txtToDateExt.Text = cd
    '    End If
    'End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BranchCode") <> "000000000000" Then
            Response.Redirect("AccessDenied.aspx")
        Else
            If Not IsPostBack Then
                Dim CloseDate As Date
                Dim cd As String
                CloseDate = System.DateTime.Now
                cd = CloseDate.ToString("dd-MMM-yyyy")
                txtToDateExt.Text = cd
                txtFromDateExt.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
                'lblErrorMsg.Text = ""
            End If
        End If

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Default2.aspx")
    End Sub
End Class
