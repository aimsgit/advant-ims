Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class frmTutorial
    Inherits BasePage
    Dim EL As New TutorialEL
    Dim BL As New TutorialBL
    Dim DL As New TutorialDL
    Dim DT As New DataTable

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ' Add the data-- by Siddharth(25-4-2013)
        EL.Course = ddlCourse.SelectedValue
        EL.Subject = ddlSubject.SelectedValue
        EL.Duration = txtDuration.Text
        If txtmins.Text = "" Then
            EL.Minute = 0
        Else
            EL.Minute = txtmins.Text
        End If
        If txtmins.Text > 60 Then
            lblerrmsg.Text = "minute should not greater than 60."
            EL.Minute = 0

            Exit Sub
        End If
        EL.Link_Name = txtLinkName.Text
        If btnAdd.Text = "ADD" Then

            BL.InsertTutorialEL(EL)
            lblmsgifo.Text = " Data Added Successfully."
            lblerrmsg.Text = ""
            disp(0)
            clear()
        Else
            EL.id = ViewState("id")
            BL.UpdateTutorialEL(EL)
            lblmsgifo.Text = " Data Updated successfully."
            lblerrmsg.Text = ""
            clear()
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"


            disp(0)

        End If


    End Sub
    Sub clear()
        txtDuration.Text = ""
        txtmins.Text = ""
        txtLinkName.Text = ""

    End Sub
   
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        If btnView.Text <> "BACK" Then
            EL.id = 0
            'dt = BL.DisplayGridview(EL.id)
            disp(EL.id)
            GridView1.Visible = "true"

        Else
            clear()
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            disp(0)



        End If


    End Sub
    Sub disp(ByVal id As Integer)

        ' Display the data-- by Siddharth(25-4-2013)

        EL.id = 0
        DT = BL.DisplayGridview(id)
        If DT.Rows.Count > 0 Then
            GridView1.DataSource = DT
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True

        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."

        End If
    End Sub
      

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim rowsaffected As Integer
        EL.id = (CType(GridView1.Rows(e.RowIndex).FindControl("lblid"), Label).Text)
        rowsaffected = BL.DeleteTutorialEL(EL)
        lblmsgifo.Text = "Data deleted sucessfully."
        lblerrmsg.Text = ""
        disp(0)
        DT = BL.DisplayGridview(EL.id)
        GridView1.DataSource = DT
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        ddlCourse.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCourseID"), Label).Text
        ddlSubject.Items.Clear()
        ddlSubject.DataSourceID = "SubjectSelect"
        ddlSubject.DataBind()
        ddlSubject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSubjectID"), Label).Text
        txtDuration.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDuration"), Label).Text
        txtmins.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblMin"), Label).Text
        txtLinkName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLinkName"), Label).Text
        ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text
        btnAdd.Text = "UPDATE"
        btnView.Text = "BACK"
        EL.id = ViewState("id")
        DT = BL.DisplayGridview(EL.id)
        GridView1.DataSource = DT
        GridView1.DataBind()
        lblmsgifo.Text = ""
        lblerrmsg.Text = ""
    End Sub
End Class
