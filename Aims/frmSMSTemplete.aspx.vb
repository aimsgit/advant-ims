
Partial Class frmSMSTemplete
    Inherits BasePage
    Dim a As Integer
    Dim dt As New DataTable
    Dim EL As New SMSTempleteEL
    Dim BL As New SMSTempleteBL
    Protected Sub GVSMSTemplete_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVSMSTemplete.PageIndexChanging
        If GVSMSTemplete.EditIndex <> -1 Then
            msginfo.Text = "First Cancel Edit."
            lblmsg.Text = ""
        Else
            GVSMSTemplete.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GVSMSTemplete.PageIndex
            DisplayGridView()
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtTempleteName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnSave.Text = "ADD" Then
                If txtMessage.Text = "" Then
                    msginfo.Text = "Message Field is mandatory."
                    lblmsg.Text = ""
                Else
                    ' Adds the data-- by Nakul Bharadwaj(20-08-2012)
                    lblmsg.Text = ""
                    EL.SMSName = txtTempleteName.Text
                    EL.SMSDescription = txtMessage.Text
                    dt = BL.GetDuplicateSMSTemplete(EL)
                    lblmsg.Text = ""
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        EL.SMSName = txtTempleteName.Text
                        EL.SMSDescription = txtMessage.Text
                        BL.InsertSMSTemplete(EL)
                        ViewState("PageIndex") = 0
                        GVSMSTemplete.PageIndex = 0
                        DisplayGridView()
                        lblmsg.Text = "Data Saved Successfully."
                        msginfo.Text = ""
                        txtTempleteName.Text = ""
                        txtMessage.Text = ""
                        msginfo.Text = ""
                    End If
                End If

            ElseIf btnSave.Text = "UPDATE" Then
                ' Updates the data-- by Nakul Bharadwaj(20-08-2012)

                EL.SMSName = txtTempleteName.Text
                EL.SMSDescription = txtMessage.Text
                EL.Id = ViewState("id1")
                dt = BL.GetDuplicateSMSTemplete(EL)
                lblmsg.Text = ""
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    BL.UpdateSMSTemplete(EL)
                    msginfo.Visible = True
                    GVSMSTemplete.PageIndex = ViewState("PageIndex")
                    EL.Id = 0
                    DisplayGridView()
                    lblmsg.Text = "Data Updated Successfully."
                    msginfo.Text = ""
                    lblmsg.Visible = True
                    txtTempleteName.Text = ""
                    txtMessage.Text = ""
                    btnSave.Text = "ADD"
                    btnDetails.Text = "VIEW"
                    GVSMSTemplete.Enabled = True
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If

    End Sub
    Sub DisplayGridView()
        ' Displays the data-- by Nakul Bharadwaj(20-8-2012)
        Dim dt As New DataTable
        dt = BL.GetSMSTemplete(EL)
        If dt.Rows.Count = 0 Then
            GVSMSTemplete.DataSource = Nothing
            GVSMSTemplete.DataBind()
            msginfo.Text = "No records to display."
            lblmsg.Text = ""
        Else
            GVSMSTemplete.DataSource = dt
            GVSMSTemplete.DataBind()
            LinkButton.Focus()
        End If
    End Sub
    Protected Sub GVSMSTemplete_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSMSTemplete.RowDeleting
        ' Deletes data of the selected row-- by Nakul Bharadwaj(20-8-2012)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If GVSMSTemplete.EditIndex <> -1 Then
                msginfo.Text = "First Cancel Edit."
                lblmsg.Text = ""
            Else
                a = CType(GVSMSTemplete.Rows(e.RowIndex).Cells(1).FindControl("SMSID"), HiddenField).Value
                BL.DeleteSMSTemplete(a)
                DisplayGridView()
                lblmsg.Text = "Data Deleted Successfully."
                txtTempleteName.Focus()
                msginfo.Text = ""
                GVSMSTemplete.PageIndex = ViewState("PageIndex")
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        ' VIEW- Displays the data in gridview-- by Nakul Bharadwaj(20-8-2012)
        ' BACK- Goes back to VIEW mode from edit mode-- by Nakul Bharadwaj(20-8-2012)
        If btnDetails.Text = "VIEW" Then
            EL.ID = 0
            GVSMSTemplete.Visible = True
            msginfo.Text = ""
            lblmsg.Text = ""
            ViewState("PageIndex") = 0
            GVSMSTemplete.PageIndex = 0
            DisplayGridView()
            txtTempleteName.Text = ""
            txtMessage.Text = ""
            GVSMSTemplete.Enabled = True
        Else
            EL.ID = 0
            GVSMSTemplete.Visible = True
            GVSMSTemplete.PageIndex = ViewState("PageIndex")
            DisplayGridView()
            msginfo.Text = ""
            txtTempleteName.Text = ""
            txtMessage.Text = ""
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            GVSMSTemplete.Enabled = True
        End If
    End Sub
    Protected Sub GVSMSTemplete_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSMSTemplete.RowEditing
        ' The data of the selected row goes to edit mode-- by Nakul Bharadwaj(20-8-2012)
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        txtTempleteName.Text = CType(GVSMSTemplete.Rows(e.NewEditIndex).FindControl("lblSMSTempName"), Label).Text
        txtMessage.Text = CType(GVSMSTemplete.Rows(e.NewEditIndex).FindControl("lblMessage"), Label).Text
        ViewState("id1") = CType(GVSMSTemplete.Rows(e.NewEditIndex).FindControl("SMSID"), HiddenField).Value
        EL.Id = ViewState("id1")
        dt = BL.GetSMSTemplete(EL)
        GVSMSTemplete.DataSource = dt
        GVSMSTemplete.DataBind()
        GVSMSTemplete.Visible = True
        GVSMSTemplete.Enabled = False
        lblmsg.Text = ""
        msginfo.Text = ""
        btnSave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        DisplayGridView()
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If


    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
End Class
