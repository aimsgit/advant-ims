Imports System.Data.SqlClient
Partial Class frmRollTesting
    Inherits BasePage
    Dim EL As New RoleTestingEL
    Dim BL As New RoleTestingBL
    Dim dt As New Data.DataTable
    Dim dt1 As New Data.DataTable

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        'ddlInstitute.Focus()
        lblErrorMsg.Text = ""
        EL.institute = ddlInstitute.SelectedValue
        EL.branch = ddlBranch.SelectedValue
        EL.role = ddlRole.SelectedValue
        dt = BL.View(EL)
        dt1 = BL.View1(EL)

        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
       
        Else
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display as defined in branch."

            GridView1.Visible = False
        End If
        If dt1.Rows.Count > 0 Then
            GridView2.DataSource = dt1
            GridView2.DataBind()
            GridView2.Visible = True

        Else
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display as defined in superadmin."
            GridView2.Visible = False
        End If
        panel2.Visible = True

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        panel2.Visible = False
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        EL.institute = ddlInstitute.SelectedValue
        EL.branch = ddlBranch.SelectedValue
        EL.role = ddlRole.SelectedValue
        dt = BL.View(EL)
        'dt1 = BL.View1(EL)

        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True

        Else
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display as defined in branch."

            GridView1.Visible = False
        End If
       
        panel2.Visible = True

    End Sub

    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView2.PageIndex
        EL.institute = ddlInstitute.SelectedValue
        EL.branch = ddlBranch.SelectedValue
        EL.role = ddlRole.SelectedValue
        'dt = BL.View(EL)
        dt1 = BL.View1(EL)

        
        If dt1.Rows.Count > 0 Then
            GridView2.DataSource = dt1
            GridView2.DataBind()
            GridView2.Visible = True

        Else
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display as defined in superadmin."
            GridView2.Visible = False
        End If
        panel2.Visible = True

    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim rolename, branch1, branch As String
        Dim role As Integer
        lblErrorMsg.Text = ""
        rolename = ddlRole.SelectedItem.Text
        branch1 = ddlBranch.SelectedItem.Text

        branch = ddlBranch.SelectedValue
        role = ddlRole.SelectedValue
        Dim qrystring As String = "RptRoleTestingV.aspx?" & QueryStr.Querystring() & "&rolename=" & rolename & "&branch1=" & branch1 & "&branch=" & branch & "&role=" & role
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    End Sub
End Class
