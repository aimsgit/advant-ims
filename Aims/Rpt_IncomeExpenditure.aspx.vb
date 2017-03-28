
Partial Class Rpt_IncomeExpenditure
    Inherits BasePage
    Dim dt As DataTable
    Dim DL As New DLIncomeAndExpenditure
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            Try
                msginfo.Text = ""
                Dim FromDate As Date
                Dim ToDate As Date

                FromDate = txtStartDate.Text
                txtStartDate.Text = Format(FromDate, "dd-MMM-yyyy")
                ToDate = txtEndDate.Text
                If FromDate > ToDate Then
                    msginfo.Text = "From date should be greater than To date."
                    txtEndDate.Focus()
                    Exit Sub
                End If
                Dim qry_str As String = "&FinStartDate=" & FromDate & "&FinEndDate=" & ToDate
                Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "Rpt_IncomeExpenditureV.aspx?" & QueryStr.Querystring() & qry_str
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Catch ex As Exception
                msginfo.Text = "Date is not valid."
            End Try
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            If btnView.Text = "VIEW" Then
                'EL.ID = 0
                GVBalanceSheet.Visible = True
                msginfo.Text = ""
                ViewState("PageIndex") = 0
                GVBalanceSheet.PageIndex = 0
                DisplayGridView()
                GVBalanceSheet.Enabled = True
            End If
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub
    Sub DisplayGridView()
        Dim FromDate As Date
        Dim ToDate As Date
        FromDate = txtStartDate.Text
        ToDate = txtEndDate.Text

        dt = DL.IncomeAndExpenditureGridView(FromDate, ToDate)
        If dt.Rows.Count > 0 Then
            GVBalanceSheet.DataSource = dt
            GVBalanceSheet.DataBind()
            'sumAsset = 0
            'SumLiab = 0
            'lblGrandTotal.Visible = True
            For Each rows As GridViewRow In GVBalanceSheet.Rows
                If CType(rows.FindControl("hidAccGroupId"), HiddenField).Value = "3" Then
                    CType(rows.FindControl("LabelAccGroupId1"), Label).Text = ""
                    CType(rows.FindControl("LinkLiaAmt"), LinkButton).Text = ""
                    'CType(rows.FindControl("LinkAssAmt"), LinkButton).Text = Format(0 - CType(rows.FindControl("LinkAssAmt"), LinkButton).Text, "n2")
                    'sumAsset = sumAsset + CType(rows.FindControl("LinkAssAmt"), LinkButton).Text
                ElseIf CType(rows.FindControl("hidAccGroupId"), HiddenField).Value Then
                    CType(rows.FindControl("LabelAccGroupId2"), Label).Text = ""
                    CType(rows.FindControl("LinkAssAmt"), LinkButton).Text = ""
                    'SumLiab = SumLiab + CType(rows.FindControl("LinkLiaAmt"), LinkButton).Text
                End If
            Next

        Else

        End If
    End Sub
    Protected Sub GVBalanceSheet_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBalanceSheet.RowEditing
        Dim accgroup As String
        'Dim accsubgroup As String
        Dim accgrpId As String
        'Dim accsubgrpId As String
        Dim FromDate As Date
        Dim ToDate As Date
        FromDate = txtStartDate.Text
        ToDate = txtEndDate.Text
        dt = DL.IncomeAndExpenditure1(FromDate, ToDate)

        If CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("LabelAccGroupId1"), Label).Text = "" Then

            accgroup = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("LabelAccGroupId22"), Label).Text
            'accsubgroup = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("lblAsset"), Label).Text

            accgrpId = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("hidAccGroupId"), HiddenField).Value
            'accsubgrpId = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("hidAccSubGroupId"), HiddenField).Value

        ElseIf CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("LabelAccGroupId2"), Label).Text = "" Then

            accgroup = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("LabelAccGroupId12"), Label).Text
            'accsubgroup = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("lblLiabilities"), Label).Text

            accgrpId = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("hidAccGroupId"), HiddenField).Value
            'accsubgrpId = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("hidAccSubGroupId"), HiddenField).Value

        End If
        Dim qrystring As String = "frmIncmExpen.aspx?" & QueryStr.Querystring() & "&FinStartDate=" & txtStartDate.Text & "&FinEndDate=" & txtEndDate.Text & "&AccGroup=" & accgroup & "&AccGroupId=" & accgrpId
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
    End Sub
End Class
