
Partial Class Mfg_frmSalesExecutive
    Inherits BasePage
    Dim EL As New Mfg_ELSaleExecutive
    Dim BL As New Mfg_BLSaleExecutive
    Dim dt As New DataTable

    'Written by Shailesh on 02/08/2012 
    'Method is for Save and Update
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.SEName = txtName.Text
                EL.Code = txtCode.Text

                If txtAge.Text = "" Then
                    EL.Age = 0
                Else
                    EL.Age = txtAge.Text
                End If

                If txtDOJ.Text = "" Then
                    EL.DOJ = "1/1/1900"
                Else
                    EL.DOJ = txtDOJ.Text
                End If
                If txtDOL.Text = "" Then
                    EL.DOL = "1/1/1900"
                Else
                    EL.DOL = txtDOL.Text
                End If

                If EL.DOJ > EL.DOL And EL.DOL <> "1/1/1900" Then
                    lblerrmsg.Text = "Date of Joining cannot be greater than Date of Leaving."
                    lblmsgifo.Text = ""
                    txtDOJ.Focus()
                Else

                    EL.Grade = txtGrade.Text
                    If txtTarget.Text = "" Then
                        EL.TargetValue = 0.0
                    Else
                        EL.TargetValue = txtTarget.Text

                    End If
                    If txtOpeningBal.Text = "" Then
                        EL.OpenBal = 0.0
                    Else
                        EL.OpenBal = txtOpeningBal.Text
                    End If

                    EL.Address = txtAddress.Text
                    EL.State = txtState.Text
                    EL.Country = txtCountry.Text
                    EL.Email = txtEmail.Text
                    EL.Contact = txtContact.Text
                    If btnSave.Text = "ADD" Then
                        dt = BL.CheckDuplicate(EL)
                        If dt.Rows.Count > 0 Then
                            lblerrmsg.Text = "Data already exists."
                            lblmsgifo.Text = " "
                        Else
                            BL.InsertRecord(EL)
                            Clear()
                            lblerrmsg.Text = ""
                            lblmsgifo.Text = "Data Saved Successfully."
                            btnSave.Text = "ADD"
                            GridSales.Enabled = True
                            ViewState("PageIndex") = 0
                            GridSales.PageIndex = 0
                            DispGrid()
                        End If
                    ElseIf btnSave.Text = "UPDATE" Then
                        EL.id = ViewState("MR_ID")

                        dt = BL.CheckDuplicate(EL)
                        If dt.Rows.Count > 0 Then
                            lblerrmsg.Text = "Data already exists."
                            lblmsgifo.Text = " "
                            'clear()
                        Else
                            BL.UpdateRecord(EL)
                            lblerrmsg.Text = ""
                            lblmsgifo.Text = "Data Updated Successfully."
                            btnSave.Text = "ADD"
                            GridSales.Visible = True
                            btnDetails.Text = "VIEW"
                            Clear()
                            GridSales.PageIndex = ViewState("PageIndex")
                            DispGrid()
                        End If
                    End If
                End If
            Catch ex As Exception
                lblerrmsg.Text = "Enter correct data."
                lblmsgifo.Text = ""
            End Try

        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add data."
            lblmsgifo.Text = ""
        End If
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for view button
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        LinkButton1.Focus()
        If btnDetails.Text = "VIEW" Then
            GridSales.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "

            ViewState("PageIndex") = 0
            GridSales.PageIndex = 0
            DispGrid()

            'Clear()
        ElseIf btnDetails.Text = "BACK" Then
            GridSales.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            Clear()
            GridSales.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is to display in Gridview
    Sub DispGrid()
        EL.id = 0
        If txtName.Text = "" Then
            EL.SEName = 0
        Else
            EL.SEName = txtName.Text
        End If
        If txtCode.Text = "" Then
            EL.Code = 0
        Else
            EL.Code = txtCode.Text
        End If

        If txtDOJ.Text = "" Then
            EL.DOJ = "1/1/1900"
        Else
            EL.DOJ = txtDOJ.Text
        End If

        If txtDOL.Text = "" Then
            EL.DOL = "1/1/1900"
        Else
            EL.DOL = txtDOL.Text
        End If
        dt = BL.getSale(EL)
        If dt.Rows.Count > 0 Then
            GridSales.Enabled = True
            GridSales.Visible = True
            GridSales.DataSource = dt
            GridSales.DataBind()
            For Each rows As GridViewRow In GridSales.Rows
                If CType(rows.FindControl("lbldoj"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lbldoj"), Label).Text = ""
                End If
                If CType(rows.FindControl("lbldol"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lbldol"), Label).Text = ""
                End If
                If CType(rows.FindControl("lblAge"), Label).Text = "0" Then
                    CType(rows.FindControl("lblAge"), Label).Text = ""
                End If
            Next
        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GridSales.Visible = False
        End If
    End Sub
    Sub Clear()
        txtName.Text = ""
        txtCode.Text = ""
        txtAge.Text = ""
        txtDOJ.Text = ""
        txtDOL.Text = ""
        txtGrade.Text = ""
        txtTarget.Text = ""
        txtOpeningBal.Text = ""
        txtAddress.Text = ""
        txtState.Text = ""
        txtCountry.Text = ""
        txtEmail.Text = ""
        txtContact.Text = ""

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        txtName.Focus()
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for Page indexing
    Protected Sub GridSales_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridSales.PageIndexChanging
        GridSales.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridSales.PageIndex
        DispGrid()
        GridSales.Visible = True
        lblmsgifo.Text = " "
        lblerrmsg.Text = " "
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for Row Deleting 
    Protected Sub GridSales_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridSales.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GridSales.Rows(e.RowIndex).FindControl("Label5"), HiddenField).Value
            BL.DeleteSale(EL)

            'GridSales.DataBind()
            ''lblGreen.Visible = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = "Data Deleted Successfully."
            Clear()
            GridSales.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for Row Editing
    Protected Sub GridSales_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridSales.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then

            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            btnSave.Text = "UPDATE"
            btnDetails.Visible = True
            btnDetails.Text = "BACK"
            GridSales.Visible = True
            ViewState("MR_ID") = CType(GridSales.Rows(e.NewEditIndex).FindControl("Label5"), HiddenField).Value
            txtName.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
            txtCode.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblCode"), Label).Text
            txtAge.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblAge"), Label).Text
            txtDOJ.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lbldoj"), Label).Text
            txtDOL.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lbldol"), Label).Text
            txtGrade.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblGrade"), Label).Text
            txtTarget.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblTarget"), Label).Text
            txtOpeningBal.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblopen"), Label).Text
            txtAddress.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblAddress"), Label).Text
            txtState.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblstate"), Label).Text
            txtCountry.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblCountry"), Label).Text
            txtEmail.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblEmail"), Label).Text
            txtContact.Text = CType(GridSales.Rows(e.NewEditIndex).FindControl("lblph"), Label).Text
            EL.id = ViewState("MR_ID")
            EL.SEName = 0
            EL.Code = 0
            EL.DOJ = "1/1/1900"
            EL.DOL = "1/1/1900"
            dt = BL.getSale(EL)
            GridSales.DataSource = dt
            GridSales.DataBind()
            For Each rows As GridViewRow In GridSales.Rows
                If CType(rows.FindControl("lbldoj"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lbldoj"), Label).Text = ""
                End If
                If CType(rows.FindControl("lbldol"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lbldol"), Label).Text = ""
                End If
            Next
            GridSales.Enabled = False
            GridSales.Visible = True

        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
            lblmsgifo.Text = ""
        End If
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for Session exipire 
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
