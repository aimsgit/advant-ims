Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql

Partial Class FrmExamSubjective
    Inherits BasePage
    Dim EL As New AdminExamEL
    Dim BL As New AdminExamBL
    Dim DL As New AdminExamDL
    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertButton.Click
        EL.Course = ddlCourse.SelectedValue
        EL.Subject = ddlSubject.SelectedValue
        EL.Duration = txtDuration.Text
        EL.Minute = txtmins.Text
        EL.AnswerLength = txtAnswerLength.Text
        EL.QuestionsName = txtQName.Text
        EL.Answer = txtAnswer.Text
        If InsertButton.Text = "ADD" Then
            BL.InsertAdminExamEL(EL)
            lblmsgifo.Text = " Inserted Successfully."
            lblerrmsg.Text = ""
            disp()
            clear()
        Else
            EL.id = ViewState("id")
            BL.UpdateAdminExamEL(EL)
            lblmsgifo.Text = " Updated successfully."
            lblerrmsg.Text = ""
            disp()
        End If



    End Sub
    Sub clear()

       
        txtDuration.Text = ""

        txtmins.Text = ""
        txtAnswerLength.Text = ""

        txtQName.Text = ""
        txtAnswer.Text = ""

    End Sub

    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        If btnDet.Text = "VIEW" Then
            EL.id = 0
            'dt = BL.DisplayGridview(EL.id)
            disp()
        Else
            InsertButton.Text = "ADD"
            btnDet.Text = "VIEW"
            disp()
            clear()
        End If

    End Sub


    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim rowsaffected As Integer
        EL.id = (CType(GridView1.Rows(e.RowIndex).FindControl("lblid"), Label).Text)
        rowsaffected = BL.DeleteAdminExam(EL)
        disp()
        lblmsgifo.Text = "Data deleted sucessfully."
        lblerrmsg.Text = ""
        dt = BL.DisplayGridview(EL)

        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
    End Sub
    Sub disp()
        'EL.id = 0
        'dt = BL.DisplayGridview(EL)
        'GridView1.DataSource = dt
        'GridView1.DataBind()


        EL.id = 0
        dt = BL.DisplayGridview(EL)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True

        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."

        End If
    End Sub


    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        ddlCourse.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCourseID"), Label).Text
        ddlSubject.Items.Clear()
        ddlSubject.DataSourceID = "SubjectSelect"
        ddlSubject.DataBind()
        ddlSubject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSubjectID"), Label).Text
        txtDuration.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDuration"), Label).Text
        txtmins.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblMin"), Label).Text
        txtAnswerLength.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAnswerLength"), Label).Text
        txtQName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblQName"), Label).Text
        txtAnswer.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAnswer"), Label).Text
        ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text
        InsertButton.Text = "UPDATE"
        btnDet.Text = "BACK"
        EL.id = ViewState("id")
        dt = BL.DisplayGridview(EL)
        GridView1.DataSource = dt
        GridView1.DataBind()
        lblmsgifo.Text = ""
        lblerrmsg.Text = ""
    End Sub
End Class


