Imports System.Data.SqlClient
Imports System.Data
Partial Class Frm_AdmissionCriteriaConfiguration
    Inherits BasePage
    Dim dt As DataTable
    Dim AddCriteria As New AdmissionCriteriaEL
    Dim AddCriteriaBL As New AdmissionCriteriaBL
    Dim DL As New AdmissionCriteriaDL

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        AddCriteria.Criteria = txtCriteria.Text
        AddCriteria.CriteriaValue = txtValue.Text
        AddCriteria.id = ViewState("ID")
        If (Session("BranchCode") = Session("ParentBranch")) Then
            dt = AddCriteriaBL.CheckDuplicate(AddCriteria)
            If dt.Rows.Count > 0 Then
                msginfo.Text = ValidationMessage(1150)
                lblmsg.Text = ValidationMessage(1014)
            Else

                If btnAdd.CommandName = "ADD" Then
                    AddCriteria.id = 0
                    AddCriteriaBL.InsertAdmissionCriteria(AddCriteria)
                    DisplayGridView()
                    lblmsg.Text = ValidationMessage(1151)
                    clear()
                Else
                    btnAdd.CommandName = "ADD"
                    btnView.CommandName = "VIEW"
                    AddCriteria.id = ViewState("ID")
                    AddCriteriaBL.InsertAdmissionCriteria(AddCriteria)
                    DisplayGridView()
                    lblmsg.Text = ValidationMessage(1152)
                    clear()
                End If

            End If
        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub DisplayGridView()
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        Dim ID As Integer = 0
        Dim dt As DataTable = AddCriteriaBL.AdmissionCriteriaMasterGridView(ID)
        GridView1.DataSource = dt
        If dt.Rows.Count > 0 Then
            GridView1.DataBind()

            GridView1.Enabled = True
            GridView1.Visible = True
        Else
           
            msginfo.Text = ValidationMessage(1023)
        End If
    End Sub
    Sub clear()
        txtCriteria.Text = ""
        txtValue.Text = ""
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        If btnView.CommandName = "VIEW" Then
            DisplayGridView()
        Else
            DisplayGridView()
            btnAdd.CommandName = "ADD"
            btnView.CommandName = "VIEW"
            btnActive.CommandName = "ACTIVE/INACTIVE"
            
            clear()

        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim rowsaffected, ID As Integer
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            AddCriteria.id = CType(GridView1.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
            rowsaffected = AddCriteriaBL.DeleteAdmissionCriteria(AddCriteria)

            ID = ViewState("ID")
            Dim dt As DataTable = AddCriteriaBL.AdmissionCriteriaMasterGridView(ID)
            GridView1.DataSource = dt
            GridView1.DataBind()
            
            GridView1.Enabled = True
            GridView1.Visible = True
            lblmsg.Text = ValidationMessage(1028)
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim ID As Integer
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            txtCriteria.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCriteriaName"), Label).Text
            txtValue.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCriteriaValue"), Label).Text

            ViewState("ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
            ID = ViewState("ID")
            Dim dt As DataTable = AddCriteriaBL.AdmissionCriteriaMasterGridView(ID)
            GridView1.DataSource = dt
            GridView1.DataBind()
            
            GridView1.Enabled = False
            GridView1.Visible = True
            btnActive.Enabled = True

            btnAdd.Text = "UPDATE"
            btnView.Text = "BACK"
            btnActive.Text = "ACTIVE/INACTIVE"

        Else
            msginfo.Text = ValidationMessage(1024)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub btnActive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActive.Click
        Dim rowsaffected As Integer
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        AddCriteria.id = ViewState("ID")
        rowsaffected = AddCriteriaBL.UpdateCriteriaStatus(AddCriteria)
        DisplayGridView()
        dt = AddCriteriaBL.getStatus(AddCriteria)
        If dt.Rows(0).Item("Active_status").ToString = "Y" Then
            lblmsg.Text = ValidationMessage(1153)
        Else
            lblmsg.Text = ValidationMessage(1154)
        End If
        btnAdd.CommandName = "ADD"
        btnView.CommandName = "VIEW"
       
        clear()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnActive.Enabled = False
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub
    
    ''Retriving the text of controls based on Language
Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

End Class
