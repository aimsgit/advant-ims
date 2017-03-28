
Partial Class Mfg_frmTransportation
    Inherits BasePage
    Dim EL As New ELTransportaionMfg
    Dim dt As New DataTable
    Dim BLL As New BLTransportationMfg
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'Code Reviewed By Raju 11/08/2012
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ' code for ADD AND UPDATE Button By Nitin 09-08-2012
            EL.Name = TxtTransportaion.Text
            If BtnSave.Text = "ADD" Then
                ' code for duplicate data By Nitin 09-08-2012
                dt = BLL.GetDuplicateCertificateMaster(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    BLL.InsertRecord(EL)
                    lblmsg.Text = "Data Saved Successfully."
                    msginfo.Text = ""
                    Display()
                    Clear()
                    GridView1.Visible = True
                End If
            ElseIf BtnSave.Text = "UPDATE" Then

                EL.ID = ViewState("Shipping_ID")
                dt = BLL.GetDuplicateCertificateMaster(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    EL.Name = TxtTransportaion.Text
                    Dim i As Int64 = BLL.UpdateRecord(EL)
                    If i > 0 Then
                        lblmsg.Text = "Data Updated Successfully."
                        msginfo.Text = ""
                        EL.ID = 0
                        Display()
                        BtnSave.Text = "ADD"
                        BtnDetails.Text = "VIEW"
                        Clear()
                    Else
                        msginfo.Text = "Data Cannot be added."
                    End If
                End If
            End If
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot add data."
            msginfo.Text = ""
        End If

    End Sub
    Sub Display()
        ' code for Bind data By Nitin 09-08-2012
        Dim dt As Data.DataTable
        dt = BLL.getRecords(EL)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
        Else
            msginfo.Text = " No records to display."
            lblmsg.Text = ""
            GridView1.Visible = False
        End If
    End Sub
    ' code for View Button  By Nitin 09-08-2012
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()
        If BtnDetails.Text = "BACK" Then
            EL.ID = 0
            Display()
            Clear()
            lblmsg.Text = ""
            msginfo.Text = ""
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
        ElseIf BtnDetails.Text = "VIEW" Then
            Display()
            lblmsg.Text = ""
        End If
    End Sub
    Sub Clear()
        TxtTransportaion.Text = ""
    End Sub
    ' code for Row Deleting By Nitin 09-08-2012
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As Int64 = Int64.Parse(GridView1.DataKeys(e.RowIndex).Value.ToString)
            BLL.ChangeFlag(id)
            Display()
            lblmsg.Text = "Data Deleted Successfully."
            msginfo.Text = ""
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If
    End Sub
    ' code for Row Editing By Nitin 09-08-2012
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            TxtTransportaion.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("lblTransportaion"), Label).Text
            ViewState("Shipping_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblShippingAutoNO"), Label).Text
            BtnSave.Text = "UPDATE"
            BtnDetails.Text = "BACK"
            EL.ID = ViewState("Shipping_ID")
            Display()
            GridView1.Enabled = False
            lblmsg.Text = ""
            msginfo.Text = ""
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot edit data."
            msginfo.Text = ""
        End If
    End Sub
End Class
