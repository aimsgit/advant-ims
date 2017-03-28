
Partial Class FrmJobOpening
    Inherits BasePage
    Dim EL As New ELJobOpening
    Dim dt As New DataTable
    Dim BL As New BLJobOpening
   
    'Author Anchala Verma
    'Date 17-10-2012
    'Code for Insert and Update
    Protected Sub Insertbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Insertbtn.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try

           
                EL.Copmpanyid = DdlCName.SelectedValue

                EL.JobTitle = txtjobTitle.Text
                EL.Specilization = txtspecilization.Text
                EL.Skill = txtskill.Text
                EL.CloseApplication = txtCloseApplication.Text
                EL.StatusOfJobOpening = ddlJobOpening.SelectedValue
                EL.Eligibility = txtEligiblityCriteria.Text
                EL.SelectionProcess = TxtSelectionProcess.Text
                If Insertbtn.Text = "UPDATE" Then
                    EL.Id = ViewState("JOID")
                    'dt = BL.CheckDuplicateCompanyRegister(EL)
                    If dt.Rows.Count > 0 Then
                        Lblerr.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        BL.UpdateJobOpening(EL)
                        Lblerr.Text = ""
                        Insertbtn.Text = "ADD"
                        Viewbtn.Text = "VIEW"
                        lblmsg.Text = "Data Updated Successfully."
                        clear()
                        GvJobOpening.PageIndex = ViewState("PageIndex")
                        DisplayJobOpening()


                    End If
                ElseIf Insertbtn.Text = "ADD" Then
                    EL.Id = 0
                    'dt = BL.CheckDuplicateCompanyRegister(EL)
                    If dt.Rows.Count > 0 Then
                        Lblerr.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        BL.InsertJobOpening(EL)
                        Lblerr.Text = ""
                        Insertbtn.Text = "ADD"
                        lblmsg.Text = "Data Saved Successfully."
                        clear()
                        ViewState("PageIndex") = 0
                        GvJobOpening.PageIndex = 0
                        DisplayJobOpening()
                    End If
                    ' End If
                End If
            Catch ex As Exception
                Lblerr.Text = "Date is Not Valid."
                lblmsg.Text = ""
            End Try
        Else
            Lblerr.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub
    'Author Anchala Verma
    'Date 17-10-2012
    'Code for Display
    Sub DisplayJobOpening()

        Dim dt As New DataTable
        EL.Id = 0

        dt = BL.GetJobOpening(EL)
        GvJobOpening.DataSource = dt
        GvJobOpening.DataBind()
        Link.Focus()
        GvJobOpening.Visible = True
        GvJobOpening.Enabled = True
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ""

            Lblerr.Text = "No records to display."
            'msginfo.Visible = True
        End If
    End Sub

   
  
    Sub clear()
        txtjobTitle.Text = ""
        txtspecilization.Text = ""
        txtskill.Text = ""
        txtCloseApplication.Text = ""
        txtEligiblityCriteria.Text = ""
        TxtSelectionProcess.Text = ""
    End Sub

    Protected Sub Viewbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Viewbtn.Click
        If Viewbtn.Text <> "BACK" Then
            lblmsg.Text = ""
            Lblerr.Text = ""
            ViewState("PageIndex") = 0
            GvJobOpening.PageIndex = 0
            DisplayJobOpening()
            GvJobOpening.Visible = True
        Else
            lblmsg.Text = ""
            Lblerr.Text = ""
            Viewbtn.Text = "VIEW"
            Insertbtn.Text = "ADD"
            GvJobOpening.Visible = True
            GvJobOpening.PageIndex = ViewState("PageIndex")
            DisplayJobOpening()
            clear()
        End If
    End Sub
    'Author Anchala Verma
    'Date 17-10-2012
    'Code for Delete
    Protected Sub GvJobOpening_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvJobOpening.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Id = CType(GvJobOpening.Rows(e.RowIndex).FindControl("KDMID"), HiddenField).Value
            BL.ChangeFlagJobOpening(EL)
            Lblerr.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            GvJobOpening.PageIndex = ViewState("PageIndex")
            Dim dt As New DataTable
            EL.Id = 0

            dt = BL.GetJobOpening(EL)
            GvJobOpening.DataSource = dt
            GvJobOpening.DataBind()
            Link.Focus()
            GvJobOpening.Visible = True
            GvJobOpening.Enabled = True
        Else
            Lblerr.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
    'Author Anchala Verma
    'Date 17-10-2012
    'Code for Edit
    Protected Sub GvJobOpening_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvJobOpening.RowEditing
        EL.Id = ViewState("RCID")
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        DdlCName.SelectedValue = CType(GvJobOpening.Rows(e.NewEditIndex).FindControl("HD1"), HiddenField).Value
        txtjobTitle.Text = CType(GvJobOpening.Rows(e.NewEditIndex).FindControl("lbljobtitle"), Label).Text
        txtspecilization.Text = CType(GvJobOpening.Rows(e.NewEditIndex).FindControl("lblSpecilization"), Label).Text
        txtskill.Text = CType(GvJobOpening.Rows(e.NewEditIndex).FindControl("lblSkill"), Label).Text
        txtCloseApplication.Text = CType(GvJobOpening.Rows(e.NewEditIndex).FindControl("lblCloseApplication"), Label).Text
        ddlJobOpening.SelectedValue = CType(GvJobOpening.Rows(e.NewEditIndex).FindControl("lblStatus"), Label).Text
        txtEligiblityCriteria.Text = CType(GvJobOpening.Rows(e.NewEditIndex).FindControl("lblEligibility"), Label).Text
        TxtSelectionProcess.Text = CType(GvJobOpening.Rows(e.NewEditIndex).FindControl("lblSelectionProcess"), Label).Text

        ViewState("JOID") = CType(GvJobOpening.Rows(e.NewEditIndex).FindControl("KDMID"), HiddenField).Value

        Insertbtn.Text = "UPDATE"
        Viewbtn.Text = "BACK"
        EL.Id = ViewState("JOID")

        dt = BL.GetJobOpening(EL)
        GvJobOpening.DataSource = dt
        GvJobOpening.DataBind()
        GvJobOpening.Enabled = False
        Lblerr.Text = ""
        lblmsg.Text = ""
        'Else
        'Lblerr.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
