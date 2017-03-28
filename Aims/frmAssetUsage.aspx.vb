Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Partial Class frmAssetUsage
    Inherits BasePage
    Dim GlobalFunction As New GlobalFunction
    Dim sql, alt, Inst, Bran As String
    Dim Rda As New OleDbDataAdapter
    Dim Rdt As New DataTable
    Dim prop As New AssetUsage.AssetUsage
    Dim BAL As New AssetUsageB

    'Protected Sub ddlBranch_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.DataBound
    '    CmbAssetfill()
    'End SubHttpContext.Current.Session("InstituteID")
    'Session("sesbranch") = HttpContext.Current.Session("BranchID")

    'Protected Sub ddlBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.SelectedIndexChanged
    '    CmbAssetfill()
    'End Sub
    Sub CmbAssetfill()
        cmbAsset.Items.Clear()
        Dim Course As Int32 = GlobalFunction.IdCutter(txtCourse.Text)
        Dim Batch As Int32 = GlobalFunction.IdCutter(txtBatch.Text)
        Rdt.Clear()
        Rdt = BAL.FillGridDetails(HttpContext.Current.Session("InstituteID"), HttpContext.Current.Session("BranchID"), Course, Batch)
        If Rdt.Rows.Count = 0 Then
            cmbAsset.DataSource = ""
            cmbAsset.DataBind()
        Else
            cmbAsset.DataSource = Rdt
            cmbAsset.DataBind()
        End If

    End Sub
    Sub Qtyfill()
        TxtQuantity.Text = ""
        If cmbAsset.Items.Count <> 0 Then
            Rdt = BAL.QtyFill(cmbAsset.SelectedItem.Value)
            If Rdt.Rows.Count > 0 Then
                txtTotlQty.Text = Rdt.Rows(0)("TotalQty")
                TxtQuantity.Text = Rdt.Rows(0)("AvailableQty")
                txtAsstID.Text = Rdt.Rows(0)("Asset_ID")
            End If
        End If
    End Sub
    Protected Sub cmbAsset_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAsset.DataBound
        Qtyfill()
    End Sub
    Protected Sub cmbAsset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAsset.SelectedIndexChanged
        Qtyfill()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "SAVE" Then
            If CInt(txtusedqty.Text) <= CInt(TxtQuantity.Text) Then
                Dim id As Int64

                prop.Institute = HttpContext.Current.Session("InstituteID")
                prop.Branch = HttpContext.Current.Session("BranchID")
                prop.Course = GlobalFunction.IdCutter(txtCourse.Text)
                prop.Batch = GlobalFunction.IdCutter(txtBatch.Text)
                prop.AssetDet = cmbAsset.SelectedItem.Value
                prop.AssetId = txtAsstID.Text
                prop.UsedQty = txtusedqty.Text
                prop.Remarks = txtRemarks.Text
                prop.UsageDate = txtUsageDate.Text
                id = BAL.Insert(prop)
                clear()
                msginfo.Text = "The record is saved."
            Else
                lblError.Text = "UsedQty is More"
                lblError.Visible = True
                lblError.ForeColor = Drawing.Color.Red
            End If
        ElseIf btnSave.Text = "UPDATE" Then
            If CInt(txtusedqty.Text) <= CInt(txtTotalQTY.Text) Then
                prop.Asset_Usage_id = TxtUsageID.Text
                prop.Institute = HttpContext.Current.Session("InstituteID")
                prop.Branch = HttpContext.Current.Session("BranchID")
                prop.Course = GlobalFunction.IdCutter(txtCourse.Text)
                prop.Batch = GlobalFunction.IdCutter(txtBatch.Text)
                If cmbAsset.SelectedItem.Value = "" Then
                    prop.AssetDet = ""
                Else
                    prop.AssetDet = cmbAsset.SelectedItem.Value
                End If
                prop.AssetId = txtAsstID.Text
                prop.UsedQty = txtusedqty.Text
                prop.Remarks = txtRemarks.Text
                prop.UsageDate = txtUsageDate.Text
                BAL.Update(prop)
                GVAsstUsage.DataBind()
                btnSave.Text = "SAVE"
                btnDetails.Text = "DETAILS"
                btnrecover.Visible = True
                btnreport.Visible = True
                clear()
                msginfo.Text = "The record is updated."
            Else
                lblError.Text = "UsedQty is More"
                lblError.Visible = True
                lblError.ForeColor = Drawing.Color.Red
            End If
        End If
        Qtyfill()
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If Me.btnDetails.Text = "DETAILS" Then
            Dim Course, Batch As String
            If txtCourse.Text <> "" Then
                Course = GlobalFunction.IdCutter(txtCourse.Text)
            Else
                Course = 0
            End If
            If txtBatch.Text <> "" Then
                Batch = GlobalFunction.IdCutter(txtBatch.Text)
            Else
                Batch = 0
            End If
            Dim dt As New DataTable
            dt = BAL.FillGridOnDetails(HttpContext.Current.Session("InstituteID"), HttpContext.Current.Session("BranchID"), Course, Batch)
            If dt.Rows.Count <> 0 Then
                GVAsstUsage.DataSource = dt
                GVAsstUsage.DataBind()
                GVAsstUsage.Visible = True
                clear()
            Else
                lblError.Text = "No Records Found"
                lblError.Visible = True
                lblError.ForeColor = Drawing.Color.Red
            End If
        Else
            btnDetails.Text = "DETAILS"
            btnSave.Text = "SAVE"
            btnrecover.Visible = True
            btnreport.Visible = True
            clear()
        End If
            Qtyfill()
    End Sub
    Protected Sub GVAsstUsage_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVAsstUsage.RowEditing
        GVAsstUsage.Visible = False
        If btnSave.Text = "SAVE" Then
            btnSave.Text = "UPDATE"
            btnSave.CommandName = "UPDATE"
            btnDetails.Text = "CANCEL"
            btnDetails.CommandName = "CANCEL"
            btnrecover.Visible = False
            btnreport.Visible = False
            'ddlInstitute.SelectedValue = CType(GVAsstUsage.Rows(e.NewEditIndex).Cells(1).FindControl("Ins_ID"), HiddenField).Value
            'ddlBranch.SelectedValue = CType(GVAsstUsage.Rows(e.NewEditIndex).Cells(1).FindControl("Brn_ID"), HiddenField).Value

            cmbAsset.SelectedValue = CType(GVAsstUsage.Rows(e.NewEditIndex).Cells(2).FindControl("AssetDet_ID"), HiddenField).Value
            txtusedqty.Text = CType(GVAsstUsage.Rows(e.NewEditIndex).Cells(2).FindControl("Label2"), Label).Text
            txtRemarks.Text = CType(GVAsstUsage.Rows(e.NewEditIndex).Cells(2).FindControl("Label3"), Label).Text
            'TxtQuantity.Text = CType(GVAsstUsage.Rows(e.NewEditIndex).Cells(3).FindControl("DiffQuantity"), HiddenField).Value
            txtUsageDate.Text = CType(GVAsstUsage.Rows(e.NewEditIndex).Cells(2).FindControl("Label5"), Label).Text
            If CStr(TxtQuantity.Text) = "" Then
                txtTotalQTY.Text = CInt(txtusedqty.Text) + 0
            Else
                txtTotalQTY.Text = CInt(txtusedqty.Text) + CInt(TxtQuantity.Text)
            End If
            If CStr(TxtQuantity.Text) = "" Then
                TxtQuantity.Text = CInt(txtusedqty.Text) + 0
            Else
                TxtQuantity.Text = CInt(txtusedqty.Text) + CInt(TxtQuantity.Text)
            End If
            txtAsstID.Text = CType(GVAsstUsage.Rows(e.NewEditIndex).Cells(3).FindControl("Asset_Id"), HiddenField).Value
            TxtUsageID.Text = CType(GVAsstUsage.Rows(e.NewEditIndex).Cells(1).FindControl("AUID"), HiddenField).Value
        End If
    End Sub
    Sub clear()
        TxtQuantity.Text = " "
        txtRemarks.Text = " "
        txtusedqty.Text = " "
        txtUsageDate.Text = " "
        txtTotlQty.Text = " "
        lblError.Visible = False
    End Sub
    Protected Sub GVAsstUsage_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GVAsstUsage.RowUpdated
        GVAsstUsage.DataBind()
        cmbAsset.Enabled = False
        txtusedqty.Enabled = False
        txtRemarks.Enabled = False
    End Sub
    Protected Sub GVAsstUsage_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVAsstUsage.RowDeleting
        Dim id As HiddenField = CType(GVAsstUsage.Rows(e.RowIndex).Cells(1).FindControl("AUID"), HiddenField)
        Dim delid As Integer = CInt(id.Value)
        'Dim Status As Boolean
        'Status = globalcnn.Del_Validation(id.Value, "AssetUsage")
        'If (Status) = True Then
        '    alt = "<script language='javascript'>" + "alert('Record is already used.');" + "</script>"
        '    ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
        'End If
        BAL.UpdateDelFlag(delid)
        Qtyfill()
        btnDetails_Click(sender, e)
        msginfo.Text = "The record is deleted."
    End Sub
    Protected Sub btnrecover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrecover.Click
        Session("RecoverForm") = "AssetUsage"
        Response.Redirect("recover.aspx")
    End Sub

    Protected Sub btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreport.Click
        Inst = HttpContext.Current.Session("InstituteID")
        Bran = HttpContext.Current.Session("BranchID")
        Dim Course, Batch As String
        If txtCourse.Text <> "" Then
            Course = GlobalFunction.IdCutter(txtCourse.Text)
        Else
            Course = 0
        End If
        If txtBatch.Text <> "" Then
            Batch = GlobalFunction.IdCutter(txtBatch.Text)
        Else
            Batch = 0
        End If

        'Dim Rda As New OleDbDataAdapter
        'Dim Rdt As New DataTable
        'Rda = New OleDbDataAdapter("Select *  from AssetUsage where Del_flag=0 and Branch_Id=" + ddlBranch.SelectedItem.Value + " and Institute_Id=" + ddlInstitute.SelectedItem.Value + "", new_dbconn1)
        'Rdt.Clear()
        'Rda.Fill(Rdt)
        'If Rdt.Rows.Count = 0 Then
        '    alt = "<script language='javascript'>" + "alert('No records to display.');" + "</script>"
        '    ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
        'Else
        'Response.Redirect("RptAssetUsage.aspx?Insti=" & Inst & "&Branch=" & Bran & "&Course=" & Course & "&Batch=" & Batch)
        Dim qrystring As String = "RptAssetUsage.aspx?" & QueryStr.Querystring() & "&Course=" & Course & "&Batch=" & Batch
        ClientScript.RegisterStartupScript(Me.GetType, "Startup", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80') </script>")

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'CmbAssetfill()
        End If
    End Sub

    Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
        Try
            Session("sesInstitute") = HttpContext.Current.Session("InstituteID")
            Session("sesbranch") = HttpContext.Current.Session("BranchID")
            If txtCourse.Text <> "" Then
                Session("sesCourse") = GlobalFunction.IdCutter(txtCourse.Text)
            End If
        Catch
            txtCourse.Text = "Not a valid option.Try again."
            txtCourse.ForeColor = Drawing.Color.Red
        End Try
    End Sub

    Protected Sub txtBatch_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBatch.Init

    End Sub

    Protected Sub txtBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBatch.TextChanged
        If txtBatch.Text.Length > 2 Then
            CmbAssetfill()
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
