Partial Class IncomeTax
    Inherits BasePage
    Private Bll As New IncomeTaxB
    Private Prop As New IncomeTaxE
    Private DAL As New IncomeTaxDA
    Dim IT_id As Int64
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtDescription.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If IsPostBack = False Then
            'GridView1.Visible = False
            'Dim qrystring As String = "IncomeTaxRPT.aspx"

        End If
    End Sub
    Public Sub Dispgrid(ByVal a As Integer)
        LinkButton1.Focus()
        Dim dt As New DataTable
        dt = Bll.grid(a)
        Try
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
                GridView1.Enabled = True
            Else
                GridView1.Visible = False
                lblE.Text = "No Records to Display."
                lblS.Text = ""
            End If
        Catch ex As Exception

        End Try



    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then


            If btnView.Text = "VIEW" Then
                lblS.Text = ""
                lblE.Text = ""
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                Dispgrid(0)
                'GridView1.Visible = True
                'GridView1.Enabled = True
                clear()

            Else
                btnView.Text = "VIEW"
                btnAdd.Text = "ADD"
                clear()
                lblS.Text = ""
                lblE.Text = ""
                GridView1.PageIndex = ViewState("PageIndex")
                Dispgrid(0)
                'GridView1.Visible = True
                'GridView1.Enabled = True
            End If
        Else
            lblE.Text = "You do not have Read Privilage."
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Dispgrid(0)
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim a As Integer

                a = CType(GridView1.Rows(e.RowIndex).FindControl("HidId"), HiddenField).Value
                Bll.delete(a)
                lblE.Text = ""
                lblS.Text = "Data Deleted Successfully."
                txtDescription.Focus()
                GridView1.PageIndex = ViewState("PageIndex")
                Dispgrid(0)

            Else
                lblE.Text = "You do not belong to this branch, Cannot delete data."
                lblS.Text = ""
            End If
        Else
            lblE.Text = "You do not have Write Privilage."
        End If
    End Sub

    Public Sub clear()
        txtDescription.Text = ""
        txtFinancialyear.Text = ""
        txtLowerlimit.Text = ""
        txtPercent.Text = ""
        txtStandarddeduction.Text = ""
        txtUpperlimit.Text = ""
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If Session("Privilages").ToString.Contains("W") Then

            'If (Session("BranchCode") = Session("ParentBranch")) Then
            lblS.Text = ""
            lblE.Text = ""
            Dim a As String
            txtDescription.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label132"), Label).Text
            txtLowerlimit.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label134"), Label).Text
            txtUpperlimit.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label135"), Label).Text
            a = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label136"), Label).Text
            If a = "General" Then
                ddlCategory.SelectedValue = "G"
            ElseIf a = "Women" Then
                ddlCategory.SelectedValue = "W"
            Else
                ddlCategory.SelectedValue = "S"
            End If

            txtStandarddeduction.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label137"), Label).Text
            txtPercent.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label138"), Label).Text
            txtFinancialyear.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label139"), Label).Text
            ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HidId"), HiddenField).Value

            btnAdd.Text = "UPDATE"
            btnView.Text = "BACK"

            Dispgrid(ViewState("id"))
            GridView1.Visible = True
            GridView1.Enabled = False

            'Else
            'lblE.Text = "You do not belong to this branch, Cannot edit data."
            'lblS.Text = ""
            'End If
        Else
            lblE.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Session("Privilages").ToString.Contains("W") Then

            txtDescription.Focus()

            If (Session("BranchCode") = Session("ParentBranch")) Then
                Try


                    Prop.ITDescription = txtDescription.Text
                    Prop.Lowerlimit = txtLowerlimit.Text
                    Prop.Upperlimit = txtUpperlimit.Text
                    If CInt(txtUpperlimit.Text) < CInt(txtLowerlimit.Text) Then
                        lblE.Text = "Lower limit should be less than upper limit."
                        lblS.Text = ""
                        Exit Sub
                    End If
                    Prop.Category = ddlCategory.SelectedItem.Text
                    'If (txtStandarddeduction.Text = "") Then
                    '    Prop.Stddeduction = 0
                    'Else
                    Prop.Stddeduction = txtStandarddeduction.Text
                    'End If
                    Prop.ITPercent = txtPercent.Text
                    Prop.Financialyear = txtFinancialyear.Text

                    If btnAdd.Text = "ADD" Then
                        DAL.send(Prop)
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0

                        Dispgrid(0)
                        lblS.Text = "Data Saved Successfully."
                        lblE.Text = ""
                        clear()
                    Else
                        Prop.IT_id = ViewState("id")
                        DAL.update(Prop)
                        GridView1.PageIndex = ViewState("PageIndex")
                        Dispgrid(0)
                        GridView1.Enabled = True
                        lblS.Text = "Data Updated Successfully."
                        lblE.Text = ""
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        clear()
                    End If
                Catch ex As Exception
                    lblE.Text = "Enter Correct Data."
                End Try
            Else
                lblE.Text = "You do not belong to this branch, Cannot add/update data."
                lblS.Text = ""
            End If
        Else
            lblE.Text = "You do not have Write Privilage."
        End If
    End Sub


    'Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
    '    Dim alt As String = "<script language='javascript'>" + "confirm('Do you want to delete the selected record?');" + "</script>"
    '    ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
    'End Sub

    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    '    ' GridView1.Visible = False
    '    'Me.lblAdded.Text = GridView1.SelectedRow.Cells(1).Text.ToString
    '    'Me.txtDescription.Text = GridView1.SelectedRow.Cells(2).Text.ToString
    '    'Me.txtLowerlimit.Text = GridView1.SelectedRow.Cells(3).Text.ToString
    '    'Me.txtUpperlimit.Text = GridView1.SelectedRow.Cells(4).Text.ToString
    '    'Me.ddlCategory.SelectedItem.Text = GridView1.SelectedRow.Cells(5).Text.ToString
    '    'Me.txtStandarddeduction.Text = GridView1.SelectedRow.Cells(6).Text.ToString
    '    'Me.txtPercent.Text = GridView1.SelectedRow.Cells(7).Text.ToString
    '    'Me.txtFinancialyear.Text = GridView1.SelectedRow.Cells(8).Text.ToString
    '    'GridView1.Visible = False
    '    'lblAdded.Visible = False
    '    'btnAdd.Visible = False
    '    'btnRecover.Visible = False
    '    'btnDetails.Visible = False
    '    'btnReport.Visible = False
    '    'btnUpdate.Visible = True
    '    'btnCancel.Visible = True
    '    'GridView1.Columns(0).Visible = False
    'End Sub
    'Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
    '    'Prop.IT_id = lblAdded.Text.ToString
    '    Prop.ITDescription = txtDescription.Text
    '    Prop.Lowerlimit = txtLowerlimit.Text
    '    Prop.Upperlimit = txtUpperlimit.Text
    '    Prop.Category = ddlCategory.SelectedItem.Text
    '    Prop.Stddeduction = txtStandarddeduction.Text
    '    Prop.ITPercent = txtPercent.Text
    '    Prop.Financialyear = txtFinancialyear.Text
    '    Bll.update(Prop)
    '    Response.Redirect("IncomeTax.aspx")
    'End Sub
    'Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
    '    GridView1.DataBind()
    '    GridView1.Visible = True
    '    'lblAdded.Visible = False
    'End Sub
    'Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    '    Response.Redirect("IncomeTax.aspx")
    'End Sub
    'Protected Sub btnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecover.Click
    '    Session("RecoverForm") = "Incometax"
    '    Response.Redirect("recover.aspx")
    'End Sub
    'Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
    '    Dim Rdt As New DataTable
    '    Dim bl As New IncomeTaxB
    '    Rdt = bl.grid
    '    If Rdt.Rows.Count = 0 Then
    '        'msginfo.Text = "No Records To Display."
    '    Else
    '        'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "IncomeTaxRPT.aspx?" & QueryStr.Querystring()
    '        Dim qrystring As String = "IncomeTaxRPT.aspx?" & QueryStr.Querystring()
    '        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    '    End If
    'End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
   
End Class

