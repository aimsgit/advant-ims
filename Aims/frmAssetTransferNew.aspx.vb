
Partial Class frmAssetTransferNew
    Inherits BasePage
    Dim EL As New ELAssetTansferNew
    Dim BL As New BLAssetTransferNew
    Dim dt As New DataTable
    Dim dispId As String


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.AssetType = ddlassetType.SelectedValue
                EL.AssetName = ddlAssetName.SelectedValue
                EL.Remarks = txtRemarks.Text
                If txtDate.Text = "" Then
                    EL.AssetDate = "1/1/1900"
                Else
                    EL.AssetDate = txtDate.Text
                End If
                EL.FromBranch = Session("BranchCode")
                EL.ToBranch = ddlToBrch.SelectedValue
                'EL.Remarks = txtRemarks.Text
                If Session("BranchCode") = ddlToBrch.SelectedValue Then
                    lblRed.Text = "From Branch and To Branch Cannot be same."
                    lblGreen.Text = ""
                Else
                    If btnSave.Text = "UPDATE" Then
                        EL.id = ViewState("AssetTransfer_AutoId")

                        BL.Update(EL)
                        lblRed.Text = ""
                        lblGreen.Text = "Data Updated Successfully."
                        btnSave.Text = "ADD"
                        GridAssetTransfer.Visible = True
                        btnDetails.Text = "VIEW"
                        Clear()
                        GridAssetTransfer.PageIndex = ViewState("PageIndex")
                        DispGrid()

                    Else
                        Dim i As Integer
                        i = BL.Insert(EL)
                        ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")

                        lblRed.Text = ""
                        lblGreen.Text = "Data Saved Successfully."
                        btnSave.Text = "ADD"
                        dt = BL.GetAddAssetTransfer(ViewState("dispId "))

                        GridAssetTransfer.Visible = True
                        GridAssetTransfer.DataSource = dt
                        GridAssetTransfer.DataBind()
                        For Each rows As GridViewRow In GridAssetTransfer.Rows
                            If CType(rows.FindControl("lblGVDateOfTransfer"), Label).Text = "01-Jan-1900" Then
                                CType(rows.FindControl("lblGVDateOfTransfer"), Label).Text = ""
                            End If
                        Next
                        GridAssetTransfer.Enabled = True
                        ViewState("PageIndex") = 0
                        GridAssetTransfer.PageIndex = 0
                        Clear()
                    End If
                End If
            Catch ex As Exception
                lblRed.Text = "Date Field is not Valid."
                lblGreen.Text = ""
            End Try
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add/update data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlassetType.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If IsPostBack = False Then
            txtBranchName.Text = Session("BranchName")
            ' ddlFromBranch.SelectedValue = Session("BranchCode")
            txtDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
        If Session("RowID") <> "" Then
            Dim dt As New DataTable
            EL.id = Session("RowID")
            dt = BL.GetAssetTransfer1(EL)
            If dt.Rows.Count > 0 Then
                ddlassetType.SelectedValue = dt.Rows(0).Item("AssetType")
                ddlassetType.Enabled = False

                ddlAssetName.Items.Clear()
                ddlAssetName.DataSourceID = "ObjAssetName"
                ddlAssetName.DataBind()
                ddlAssetName.SelectedItem.Text = dt.Rows(0).Item("AssetTableName")

                ddlAssetName.Enabled = False
                txtDate.Text = Format(dt.Rows(0).Item("DateOfTransfer"), "dd-MMM-yyyy")
                txtDate.Enabled = False
                txtBranchName.Text = dt.Rows(0).Item("FromBranchName")
                txtBranchName.Enabled = False
                ddlToBrch.SelectedValue = dt.Rows(0).Item("ToBranch")
                ddlToBrch.Enabled = False
                txtRemarks.Text = dt.Rows(0).Item("Remarks")
                txtRemarks.Enabled = False
                btnDetails.Visible = False
                btnSave.Visible = False
            End If

            'Else
            '    btnDetail.Visible = True
            '    btnsave.Visible = True
        End If
        Session("RowID") = ""
    End Sub

    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If btnDetails.Text = "VIEW" Then
            lblRed.Text = " "
            lblGreen.Text = " "
            ViewState("PageIndex") = 0
            GridAssetTransfer.PageIndex = 0
            DispGrid()

        ElseIf btnDetails.Text = "BACK" Then
            GridAssetTransfer.Enabled = True
            lblRed.Text = " "
            lblGreen.Text = " "
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            Clear()
            GridAssetTransfer.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub
    Sub DispGrid()
        EL.id = 0
        dt = BL.GetAssetTransfer(EL)
        If dt.Rows.Count > 0 Then
            GridAssetTransfer.Enabled = True
            GridAssetTransfer.Visible = True
            GridAssetTransfer.DataSource = dt
            GridAssetTransfer.DataBind()
            For Each rows As GridViewRow In GridAssetTransfer.Rows
                If CType(rows.FindControl("lblGVDateOfTransfer"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblGVDateOfTransfer"), Label).Text = ""
                End If
            Next
        Else
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
            GridAssetTransfer.Visible = False
        End If
    End Sub
    Public Sub Clear()
        txtDate.Text = Format(Today, "dd-MMM-yyyy")
        txtRemarks.Text = ""
    End Sub


    Protected Sub GridAssetTransfer_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridAssetTransfer.PageIndexChanging
        GridAssetTransfer.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridAssetTransfer.PageIndex
        DispGrid()
        GridAssetTransfer.Visible = True
        lblRed.Text = " "
        lblGreen.Text = " "
    End Sub

    Protected Sub GridAssetTransfer_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridAssetTransfer.RowDeleting
       If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GridAssetTransfer.Rows(e.RowIndex).FindControl("lblID"), HiddenField).Value
            BL.Delete(EL)

            Clear()
            GridAssetTransfer.PageIndex = ViewState("PageIndex")
            DispGrid()
            lblRed.Text = " "
            lblGreen.Text = "Data Deleted Successfully."
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GridAssetTransfer_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridAssetTransfer.RowEditing

        lblRed.Text = ""
        lblGreen.Text = ""
        btnSave.Text = "UPDATE"
        btnDetails.Visible = True
        btnDetails.Text = "BACK"
        GridAssetTransfer.Visible = True
        ViewState("AssetTransfer_AutoId") = CType(GridAssetTransfer.Rows(e.NewEditIndex).FindControl("lblID"), HiddenField).Value
        ddlassetType.SelectedValue = CType(GridAssetTransfer.Rows(e.NewEditIndex).FindControl("lblGVAssetTypeID"), Label).Text
        ddlAssetName.Items.Clear()
        ddlAssetName.DataSourceID = "ObjAssetName"
        ddlAssetName.DataBind()
        ddlAssetName.SelectedValue = CType(GridAssetTransfer.Rows(e.NewEditIndex).FindControl("lblGVAssetCodeId"), Label).Text
        'ddlFromBranch.Text = CType(GridAssetTransfer.Rows(e.NewEditIndex).FindControl("lblGVFromBranchID"), Label).Text
        txtBranchName.Text = CType(GridAssetTransfer.Rows(e.NewEditIndex).FindControl("lblGVFromBranch"), Label).Text
        ddlToBrch.Text = CType(GridAssetTransfer.Rows(e.NewEditIndex).FindControl("lblGVToBranchID"), Label).Text
        txtDate.Text = CType(GridAssetTransfer.Rows(e.NewEditIndex).FindControl("lblGVDateOfTransfer"), Label).Text
        txtRemarks.Text = CType(GridAssetTransfer.Rows(e.NewEditIndex).FindControl("lblGVRemarks"), Label).Text
        'If EL.EmpStudStatus = 1 Then
        '    RbTYPE.SelectedValue = 1
        'ElseIf EL.EmpStudStatus = 2 Then
        '    RbTYPE.SelectedValue = 2
        'End If
        EL.id = ViewState("AssetTransfer_AutoId")
        dt = BL.GetAssetTransfer(EL)
        GridAssetTransfer.DataSource = dt
        GridAssetTransfer.DataBind()
        GridAssetTransfer.Enabled = False
        GridAssetTransfer.Visible = True
        For Each rows As GridViewRow In GridAssetTransfer.Rows
            If CType(rows.FindControl("lblGVDateOfTransfer"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblGVDateOfTransfer"), Label).Text = ""
            End If
        Next

    End Sub

    Protected Sub ddlassetType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassetType.SelectedIndexChanged
        ddlassetType.Focus()
    End Sub

    Protected Sub ddlAssetName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAssetName.SelectedIndexChanged
        ddlAssetName.Focus()
    End Sub

    'Protected Sub ddlFromBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFromBranch.SelectedIndexChanged
    '    ddlFromBranch.Focus()
    'End Sub

    Protected Sub ddlToBrch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToBrch.SelectedIndexChanged
        ddlToBrch.Focus()
    End Sub

    Protected Sub GridAssetTransfer_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridAssetTransfer.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        EL.id = 0
        dt = BL.GetAssetTransfer(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridAssetTransfer.DataSource = sortedView
        GridAssetTransfer.DataBind()
        GridAssetTransfer.Enabled = True
        GridAssetTransfer.Visible = True
    End Sub
    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = value
        End Set
    End Property
End Class
