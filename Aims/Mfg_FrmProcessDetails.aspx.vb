Partial Class Mfg_FrmProcessDetails
    Inherits BasePage
    Dim dt As New DataTable
    Dim EL As New Mfg_ELProcessDetails
    Dim BL As New Mfg_BLProcessDetails
    Protected Sub ViewProcessDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewProcessDetails.Click
        If ViewProcessDetails.Text = "VIEW" Then
            GvProcessMaster.Enabled = True
            'Details.Visible = False
            lblmsg.Text = " "
            msginfo.Text = " "
            EL.id = 0
            ViewState("PageIndex") = 0
            GvProcessDetails.PageIndex = 0
            Dispgrid()
            'clear()
        ElseIf ViewProcessDetails.Text = "BACK" Then
            GvProcessDetails.Enabled = True
            lblmsg.Text = " "
            msginfo.Text = " "
            btnAdd.Text = "ADD"
            ViewProcessDetails.Text = "VIEW"
            HidProcess.Text = ""
            Txtprocess.Text = ""
            txtSeq.Text = ""
            'Details.Visible = False
            GvProcessDetails.PageIndex = ViewState("PageIndex")
            Dispgrid()
        End If
    End Sub
    Public Sub Dispgrid()
        
        EL.id = 0
        dt = BL.GetProcessDetails(EL)
        If dt.Rows.Count > 0 Then
            GvProcessDetails.Enabled = True
            GvProcessDetails.Visible = True
            GvProcessDetails.DataSource = dt
            GvProcessDetails.DataBind()
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
            GvProcessDetails.Visible = False

        End If

    End Sub
    Protected Sub InsertProcessMaster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertProcessMaster.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.ItemDesc = DDLRM.SelectedValue
            EL.IO = ddlIO.SelectedValue
            If HidProcess.Text = "" Then
                EL.ProcessID = 0
            Else

                EL.ProcessID = HidProcess.Text
            End If
            If InsertProcessMaster.Text = "ADD" Then
                HidMProcess.Text = HidProcess.Text
                If HidMProcess.Text = "" Then
                    EL.ProcessID = 0
                Else
                    EL.ProcessID = HidMProcess.Text
                End If
                BL.InsertProcessMaster(EL)
                lblRed.Text = ""
                lblGreen.Text = "Data Saved Successfully."
                InsertProcessMaster.Text = "ADD"
                'HidProcess.Text = ""
                'HidMProcess.Text = ""
                DispgridProcessMaster()
                panel2.Visible = True
                BtnClose.Enabled = True

            ElseIf InsertProcessMaster.Text = "UPDATE" Then
                EL.PID = ViewState("ProcessIO_ID")
                lblRed.Text = ""
                BL.UpdateProcessMaster(EL)
                lblGreen.Text = "Data Updated Successfully."
                HidProcess.Text = ""
                InsertProcessMaster.Text = "ADD"
                ViewProcessMaster.Visible = True
                ViewProcessMaster.Text = "VIEW"
                EL.id = 0
                DispgridProcessMaster()
                HidProcess.Text = ""
                panel2.Visible = True
                BtnClose.Enabled = True
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If
    End Sub
    Public Sub DispgridProcessMaster()
        EL.PID = 0
        dt = BL.GetProcessMaster(EL)
        If dt.Rows.Count > 0 Then
            GvProcessMaster.Enabled = True
            GvProcessMaster.Visible = True
            GvProcessMaster.DataSource = dt
            GvProcessMaster.DataBind()
            panel2.Visible = True
            BtnClose.Enabled = True
        Else
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
            GvProcessMaster.Visible = False
            panel2.Visible = True
            BtnClose.Enabled = True
        End If
    End Sub
    Protected Sub ViewProcessMaster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewProcessMaster.Click
        LinkButton1.Focus()
        If ViewProcessMaster.Text = "VIEW" Then
            GvProcessMaster.Enabled = True
            lblGreen.Text = ""
            lblRed.Text = ""
            ViewState("PageIndex") = 0
            GvProcessMaster.PageIndex = 0
            DispgridProcessMaster()
            panel2.Visible = True
            BtnClose.Enabled = True
        ElseIf ViewProcessMaster.Text = "BACK" Then
            GvProcessMaster.Enabled = True
            lblGreen.Text = " "
            lblRed.Text = " "
            BtnClose.Enabled = True
            InsertProcessMaster.Text = "ADD"
            ViewProcessMaster.Text = "VIEW"
            GvProcessMaster.PageIndex = ViewState("PageIndex")
            DispgridProcessMaster()
            panel2.Visible = True
            BtnClose.Enabled = True
        End If
    End Sub
    Protected Sub GvProcessMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvProcessMaster.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.PID = CType(GvProcessMaster.Rows(e.RowIndex).FindControl("HID1"), HiddenField).Value
            BL.DeteteProcessMaster(EL)
            GvProcessMaster.DataBind()
            lblRed.Text = ""
            lblGreen.Text = "Data Deleted Successfully."
            GvProcessMaster.PageIndex = ViewState("PageIndex")
            DispgridProcessMaster()
            panel2.Visible = True
            BtnClose.Enabled = True
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub
    Protected Sub GvProcessMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvProcessMaster.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then

            lblGreen.Text = ""
            lblRed.Text = ""
            lblmsg.Text = ""
            msginfo.Text = ""

            ViewState("ProcessIO_ID") = CType(GvProcessMaster.Rows(e.NewEditIndex).FindControl("HID1"), HiddenField).Value
            DDLRM.SelectedValue = CType(GvProcessMaster.Rows(e.NewEditIndex).FindControl("lblItemID"), Label).Text
            ddlIO.SelectedValue = CType(GvProcessMaster.Rows(e.NewEditIndex).FindControl("lblInputOutput1"), Label).Text
            EL.PID = ViewState("ProcessIO_ID")
            dt = BL.GetProcessMaster(EL)
            GvProcessMaster.DataSource = dt
            GvProcessMaster.DataBind()
            GvProcessMaster.Enabled = False
            GvProcessMaster.Visible = True
            InsertProcessMaster.Text = "UPDATE"
            InsertProcessMaster.Enabled = True
            ViewProcessMaster.Visible = True
            ViewProcessMaster.Text = "BACK"
            'BtnClose.Enabled = False
            GvProcessMaster.Visible = True
            panel2.Visible = True
        Else
            msginfo.Text = "You do not belong to this branch, Cannot edit data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        panel2.Visible = False
        InsertProcessMaster.Enabled = True
        InsertProcessDetails.Enabled = True
        ViewProcessMaster.Enabled = True
        GvProcessMaster.Visible = False
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.ProcessDesc = Txtprocess.Text
                EL.Sequence = txtSeq.Text
                If HidProcess.Text = "" Then
                    EL.ProcessID = 0
                Else

                    EL.ProcessID = HidProcess.Text
                End If
                If btnAdd.Text = "ADD" Then
                    If HidMProcess.Text <> "" Then
                        BL.InsertProcessDetails(EL)
                        msginfo.Text = ""
                        lblmsg.Text = "Data Saved Successfully."
                        btnAdd.Text = "ADD"
                        HidIOProcess.Text = ""
                        HidMProcess.Text = ""
                        HidProcess.Text = ""
                        Dispgrid()
                        Txtprocess.Text = ""
                        txtSeq.Text = ""
                    Else
                        msginfo.Text = "First Add Product Details."
                        lblmsg.Text = ""
                    End If
                ElseIf btnAdd.Text = "UPDATE" Then
                    EL.id = ViewState("Process_ID")

                    BL.UpdateRecord(EL)
                    lblmsg.Text = "Data Updated Successfully."
                    HidProcess.Text = ""
                    HidIOProcess.Text = ""
                    btnAdd.Text = "ADD"
                    InsertProcessDetails.Visible = True
                    ViewProcessDetails.Text = "VIEW"
                    EL.id = 0
                    Dispgrid()

                    HidIOProcess.Text = ""
                    Txtprocess.Text = ""
                    txtSeq.Text = ""

                End If

            Catch ex As Exception
                msginfo.Text = "Enter correct data."
                lblmsg.Text = ""
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub InsertProcessDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertProcessDetails.Click
        panel2.Visible = True
        lblmsg.Text = ""
        msginfo.Text = ""
        BtnClose.Enabled = True
        InsertProcessMaster.Enabled = True
        GvProcessMaster.Visible = False
        If HidProcess.Text = "" Then
            dt = BL.GetProcessID()
            HidProcess.Text = dt.Rows(0).Item("ProcessID").ToString
            'HidIOProcess.Text = dt.Rows(0).Item("InvoiceNo").ToString
        Else
            EL.ProcessID = HidProcess.Text
        End If

        lblRed.Text = ""
        lblGreen.Text = ""

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        panel2.Visible = False
    End Sub

    Protected Sub GvProcessDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvProcessDetails.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GvProcessDetails.Rows(e.RowIndex).FindControl("HIDProcess"), HiddenField).Value
            BL.DeteteProcessDetails(EL)
            GvProcessDetails.DataBind()
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            GvProcessDetails.PageIndex = ViewState("PageIndex")
            Dispgrid()
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If
    End Sub
    Protected Sub GvProcessDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvProcessDetails.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblmsg.Text = ""
            msginfo.Text = ""
            Txtprocess.Text = CType(GvProcessDetails.Rows(e.NewEditIndex).FindControl("lblProcessDescription"), Label).Text
            txtSeq.Text = CType(GvProcessDetails.Rows(e.NewEditIndex).FindControl("lblSequence"), Label).Text
            ViewState("Process_ID") = CType(GvProcessDetails.Rows(e.NewEditIndex).FindControl("HIDProcess"), HiddenField).Value
            EL.id = ViewState("Process_ID")
            dt = BL.GetProcessDetails(EL)
            If dt.Rows.Count > 0 Then
                GvProcessDetails.Enabled = True
                GvProcessDetails.Visible = True
                GvProcessDetails.DataSource = dt
                GvProcessDetails.DataBind()
                GvProcessDetails.Enabled = False
                GvProcessDetails.Visible = True
                btnAdd.Text = "UPDATE"
                InsertProcessDetails.Enabled = True
                ViewProcessDetails.Visible = True
                ViewProcessDetails.Text = "BACK"
                BtnClose.Enabled = False
            Else
                lblmsg.Text = "You do not belong to this branch, Cannot edit data."
                msginfo.Text = ""
            End If
        End If
    End Sub
End Class
