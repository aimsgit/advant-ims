
Partial Class FrmSubjectSubgrpMaster
    Inherits BasePage
    Dim EL As New ELSubjectSubgrp
    Dim dt As New DataTable
    Dim BL As New BLSubjectSubgrp

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            EL.BatchId = ddlBatch.SelectedValue
            EL.Sem_Id = cmbSemester.SelectedValue
            EL.Subjectid = cmbSubject.SelectedValue
            EL.SubGrpId = ddlSubjectSubGrp.SelectedValue
            EL.Emp_Id = DdlLecture1.SelectedValue
            If btnadd.CommandName = "UPDATE" Then
                EL.id = ViewState("SubGrpFMap_Auto_Id")
                dt = BL.CheckDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    lblRed.Text = ValidationMessage(1030)
                    lblGreen.Text = ValidationMessage(1014)
                Else
                    BL.UpdateRecord(EL)
                    btnadd.CommandName = "ADD"
                    GVSubjectSubGrp.Visible = True
                    btnDet.CommandName = "VIEW"
                    lblRed.Text = ValidationMessage(1014)
                    clear()
                    GVSubjectSubGrp.PageIndex = ViewState("PageIndex")
                    EL.BatchId = 0
                    EL.Sem_Id = 0
                    EL.Subjectid = 0
                    EL.Emp_Id = 0
                    EL.id = 0
                    dt = BL.GetGridData(EL)
                    If dt.Rows.Count > 0 Then
                        GVSubjectSubGrp.DataSource = dt
                        GVSubjectSubGrp.DataBind()
                        GVSubjectSubGrp.Visible = True
                        GVSubjectSubGrp.Enabled = True
                        LinkButton.Focus()
                       

                    Else
                        lblRed.Text = ValidationMessage(1023)
                        lblGreen.Text = ValidationMessage(1014)
                        GVSubjectSubGrp.Visible = False
                    End If
                    lblRed.Text = ValidationMessage(1014)
                    lblGreen.Text = ValidationMessage(1017)
                End If
            ElseIf btnadd.CommandName = "ADD" Then
                dt = BL.CheckDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    lblRed.Text = ValidationMessage(1030)
                    lblGreen.Text = ValidationMessage(1014)
                Else
                    BL.InsertRecord(EL)
                    btnadd.CommandName = "ADD"
                    lblRed.Text = ValidationMessage(1014)
                    lblGreen.Text = ValidationMessage(1020)
                    clear()
                    GVSubjectSubGrp.Enabled = True
                    ViewState("PageIndex") = 0
                    GVSubjectSubGrp.PageIndex = 0
                    EL.BatchId = 0
                    EL.Sem_Id = 0
                    EL.Subjectid = 0
                    EL.Emp_Id = 0
                    EL.id = 0
                    dt = BL.GetGridData(EL)
                    If dt.Rows.Count > 0 Then
                        GVSubjectSubGrp.DataSource = dt
                        GVSubjectSubGrp.DataBind()
                        GVSubjectSubGrp.Visible = True
                        GVSubjectSubGrp.Enabled = True
                        LinkButton.Focus()
                       
                    Else
                        lblRed.Text = ValidationMessage(1023)
                        lblGreen.Text = ValidationMessage(1014)
                        GVSubjectSubGrp.Visible = False
                    End If
                End If

            End If
        Else
            lblRed.Text = ValidationMessage(1021)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub clear()

    End Sub
    Sub DispGrid()
        EL.BatchId = ddlBatch.SelectedValue
        EL.Sem_Id = cmbSemester.SelectedValue
        EL.Subjectid = cmbSubject.SelectedValue
        EL.Emp_Id = DdlLecture1.SelectedValue
        EL.id = 0
        dt = BL.GetGridData(EL)
        If dt.Rows.Count > 0 Then
            GVSubjectSubGrp.DataSource = dt
            GVSubjectSubGrp.DataBind()
            GVSubjectSubGrp.Visible = True
            GVSubjectSubGrp.Enabled = True
            LinkButton.Focus()
           
        Else
            lblRed.Text = ValidationMessage(1023)
            lblGreen.Text = ValidationMessage(1014)
            GVSubjectSubGrp.Visible = False
        End If
    End Sub
    Sub DispGrid1()
        EL.BatchId = ddlBatch.SelectedValue
        EL.Sem_Id = cmbSemester.SelectedValue
        EL.Subjectid = cmbSubject.SelectedValue
        EL.Emp_Id = DdlLecture1.SelectedValue
        EL.id = 0
        dt = BL.GetGridData(EL)
        GVSubjectSubGrp.DataSource = dt
        GVSubjectSubGrp.DataBind()
        GVSubjectSubGrp.Visible = True
        GVSubjectSubGrp.Enabled = True
        LinkButton.Focus()
       
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        If btnDet.CommandName <> "BACK" Then
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVSubjectSubGrp.PageIndex = 0
            DispGrid()
        Else
            btnDet.CommandName = "VIEW"
            btnadd.CommandName = "ADD"
            GVSubjectSubGrp.PageIndex = ViewState("PageIndex")
            EL.BatchId = 0
            EL.Sem_Id = 0
            EL.Subjectid = 0
            EL.Emp_Id = 0
            EL.id = 0
            dt = BL.GetGridData(EL)
            If dt.Rows.Count > 0 Then
                GVSubjectSubGrp.DataSource = dt
                GVSubjectSubGrp.DataBind()
                GVSubjectSubGrp.Visible = True
                GVSubjectSubGrp.Enabled = True
                LinkButton.Focus()
               
            Else
                lblRed.Text = ValidationMessage(1023)
                lblGreen.Text = ValidationMessage(1014)
                GVSubjectSubGrp.Visible = False
            End If
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            clear()
        End If
    End Sub

    Protected Sub GVSubjectSubGrp_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSubjectSubGrp.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GVSubjectSubGrp.Rows(e.RowIndex).Cells(1).FindControl("lblSubAutoId"), Label).Text
            BL.ChangeFlag(EL)
            GVSubjectSubGrp.DataBind()

            lblRed.Text = ValidationMessage(1014)
            lblGreen.Text = ValidationMessage(1028)
            GVSubjectSubGrp.PageIndex = ViewState("PageIndex")
            DispGrid1()
            clear()
        Else
            lblRed.Text = ValidationMessage(1029)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GVSubjectSubGrp_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSubjectSubGrp.RowEditing
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        ddlBatch.SelectedValue = CType(GVSubjectSubGrp.Rows(e.NewEditIndex).Cells(1).FindControl("lblBatchID"), Label).Text
        cmbSemester.Items.Clear()
        cmbSemester.DataSourceID = "ObjSemester"
        cmbSemester.DataBind()
        ddlSubjectSubGrp.SelectedValue = CType(GVSubjectSubGrp.Rows(e.NewEditIndex).Cells(1).FindControl("lblSubID"), Label).Text
        cmbSemester.SelectedValue = CType(GVSubjectSubGrp.Rows(e.NewEditIndex).Cells(1).FindControl("lblSemID"), Label).Text
        cmbSubject.Items.Clear()
        cmbSubject.DataSourceID = "ObjSubject"
        cmbSubject.DataBind()
        cmbSubject.SelectedValue = CType(GVSubjectSubGrp.Rows(e.NewEditIndex).Cells(1).FindControl("lblSubjectID"), Label).Text
        DdlLecture1.SelectedValue = CType(GVSubjectSubGrp.Rows(e.NewEditIndex).Cells(1).FindControl("lblEmpID"), Label).Text
        ViewState("SubGrpFMap_Auto_Id") = CType(GVSubjectSubGrp.Rows(e.NewEditIndex).FindControl("lblSubAutoId"), Label).Text
        btnadd.CommandName = "UPDATE"
        btnDet.CommandName = "BACK"
        Dim dt As New DataTable
        EL.id = ViewState("SubGrpFMap_Auto_Id")
        dt = BL.GetGridData(EL)
        GVSubjectSubGrp.DataSource = dt
        GVSubjectSubGrp.DataBind()
        GVSubjectSubGrp.Enabled = False
       
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        
    End Sub
    ''Code Written for Multilingual By Ajit Kumar Singh on 12th Aug
    ''Retriving the text of controls based on Language
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        Try
            dt2 = Session("ValidationTable")
            If dt2 Is Nothing Then
                Response.Redirect("LogIn.aspx")
            End If
            Dim X As Integer = dt2.Rows.Count() - 1
            Dim str As String = " "
            For i As Integer = 0 To X
                If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                    Return dt2.Rows(i).Item("MessageText").ToString()
                End If
            Next
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
        Return 0
    End Function
End Class
