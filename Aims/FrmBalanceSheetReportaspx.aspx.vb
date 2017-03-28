
Partial Class FrmBalanceSheetReportaspx
    Inherits BasePage
    Dim dl As New DLReportsD
    Dim dt As New DataTable
    Dim FromDate As New Date
    Dim ToDate As New Date
    Dim SumLiab, sumAsset As New Double
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then


            Try


                'Dim qrystring As String = ""
                'Dim qry_str As String = "&FinStartDate=" & txtStartDate.Text & "&FinEndDate=" & txtEndDate.Text
                'qrystring = ConfigurationManager.AppSettings("ReportPath") & "BalanceSheetV.aspx?" & QueryStr.Querystring() & qry_str
                'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                Dim qrystring As String = "BalanceSheetV2.aspx?" & QueryStr.Querystring() & "&FinStartDate=" & CDate(txtStartDate.Text) & "&FinEndDate=" & CDate(txtEndDate.Text)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                'GVBalanceSheet.Visible = False
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
            txtEndDate.Text = Format(CDate(Session("FinEndDate")), "dd-MMM-yyyy")
            lblGrandTotal.Visible = False
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
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
        FromDate = txtStartDate.Text
        ToDate = txtEndDate.Text
        dt = dl.BalanceSheetGridview(FromDate, ToDate)
        If dt.Rows.Count > 0 Then
            GVBalanceSheet.DataSource = dt
            GVBalanceSheet.DataBind()
            sumAsset = 0
            SumLiab = 0
            lblGrandTotal.Visible = True
            For Each rows As GridViewRow In GVBalanceSheet.Rows
                If CType(rows.FindControl("hidAccGroupId"), HiddenField).Value = "1" Then
                    CType(rows.FindControl("lblLiabilities"), Label).Text = ""
                    CType(rows.FindControl("LabelAccGroupId1"), Label).Text = ""
                    CType(rows.FindControl("LinkLiaAmt"), LinkButton).Text = ""
                    CType(rows.FindControl("LinkAssAmt"), LinkButton).Text = Format(0 - CType(rows.FindControl("LinkAssAmt"), LinkButton).Text, "n2")
                    sumAsset = sumAsset + CType(rows.FindControl("LinkAssAmt"), LinkButton).Text
                ElseIf CType(rows.FindControl("hidAccGroupId"), HiddenField).Value Then
                    CType(rows.FindControl("lblAsset"), Label).Text = ""
                    CType(rows.FindControl("LabelAccGroupId2"), Label).Text = ""
                    CType(rows.FindControl("LinkAssAmt"), LinkButton).Text = ""
                    SumLiab = SumLiab + CType(rows.FindControl("LinkLiaAmt"), LinkButton).Text
                End If
            Next
            lblSumLia.Text = Format(SumLiab, "n2")
            lblSumAsset.Text = Format(sumAsset, "n2")
            LinkButton.Focus()
        Else
            GVBalanceSheet.DataSource = Nothing
            GVBalanceSheet.DataBind()
            msginfo.Text = "No records to display."
        End If
    End Sub

    Protected Sub GVBalanceSheet_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBalanceSheet.PageIndexChanging
        If GVBalanceSheet.EditIndex <> -1 Then
            msginfo.Text = "First Cancel Edit."

        Else
            GVBalanceSheet.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GVBalanceSheet.PageIndex
            DisplayGridView()
        End If
    End Sub

    Protected Sub GVBalanceSheet_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBalanceSheet.RowEditing
        Dim accgroup As String
        Dim accsubgroup As String
        Dim accgrpId As Integer
        Dim accsubgrpId As Integer
        FromDate = txtStartDate.Text
        ToDate = txtEndDate.Text
        dt = dl.BalanceSheet(FromDate, ToDate)

        If CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("LabelAccGroupId1"), Label).Text = "" Then

            accgroup = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("LabelAccGroupId2"), Label).Text
            accsubgroup = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("lblAsset"), Label).Text

            accgrpId = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("hidAccGroupId"), HiddenField).Value
            accsubgrpId = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("hidAccSubGroupId"), HiddenField).Value

        ElseIf CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("LabelAccGroupId2"), Label).Text = "" Then

            accgroup = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("LabelAccGroupId1"), Label).Text
            accsubgroup = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("lblLiabilities"), Label).Text

            accgrpId = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("hidAccGroupId"), HiddenField).Value
            accsubgrpId = CType(GVBalanceSheet.Rows(e.NewEditIndex).FindControl("hidAccSubGroupId"), HiddenField).Value

        End If
        Dim qrystring As String = "frmBalanceSheetDrillDown.aspx?" & QueryStr.Querystring() & "&FinStartDate=" & txtStartDate.Text & "&FinEndDate=" & txtEndDate.Text & "&AccGroup=" & accgroup & "&AccSubGroup=" & accsubgroup & "&AccGroupId=" & accgrpId & "&AccSubGroupId=" & accsubgrpId
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
    End Sub

End Class
