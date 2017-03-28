
Partial Class RptLogin
    Inherits BasePage
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Default2.aspx")
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Institute As String = ddlInstitute.SelectedValue
        Dim Branch As String = ddlBranch.SelectedValue
        Dim FrmDate As DateTime = txtFrmDate.Text
        Dim ToDate As DateTime = txtToDate.Text

        'If ddlInstitute.SelectedItem.Value = "0" Then
        '    ddlBranch.Visible = "False"
        '    lblMsg.Visible = False
        '    Dim qrystring As String = "RptLoginV.aspx?" & QueryStr.Querystring() & "&Institute=" & Institute & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate
        '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        'Else
        lblMsg.Visible = False
        Dim qrystring As String = "RptLoginV.aspx?" & QueryStr.Querystring() & "&Institute=" & Institute & "&Branch=" & Branch & "&FrmDate=" & FrmDate & "&ToDate=" & ToDate
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    End Sub



    Protected Sub ddlBranch_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.PreRender
        If ddlBranch.Items.Count > 0 Then
            If ddlBranch.Items(0).Text <> "All" Then
                ddlBranch.Items.Insert(0, "All")
            End If
        Else
            ddlBranch.Items.Insert(0, "All")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BranchCode") <> "000000000000" Then
            Response.Redirect("AccessDenied.aspx")
        Else
            If Not Page.IsPostBack Then
                txtFrmDate.Text = Format(Today, "dd-MMM-yyyy")
                txtToDate.Text = Format(Today, "dd-MMM-yyyy")
            End If
        End If
    End Sub
End Class
