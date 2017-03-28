Imports System.Data.SqlClient
Partial Class frmBatchSemesterMap
    Inherits BasePage

    Dim BSM As New BatchSemesterMap
    Dim BSMDB As New BatchSemesterMapDB
    Dim BSMBL As New BatchSemesterMapBL
    Dim GlobalFunction As New GlobalFunction
    Dim dt As New DataTable

    'Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    If e.CommandName = "Back" Then
    '        GridView1.EditIndex = -1
    '        DisplayGrid()
    '        GridView1.Visible = True
    '        lblmsg.Text = ValidationMessage(1014)
    '        msginfo.Text = ValidationMessage(1014)
    '    End If
    'End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        If (Session("BranchCode") = Session("ParentBranch")) Then

            'ViewState("BatchID") = CType(GridView1.Rows(e.RowIndex).FindControl("Label4"), Label).Text
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            ViewState("PKID") = CType(GridView1.Rows(e.RowIndex).FindControl("Label5"), Label).Text
            BSM.PKID = ViewState("PKID")
            Try
                If CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("txtStartDate"), TextBox).Text = "" Or CType(GridView1.Rows(e.RowIndex).Cells(2).FindControl("txtEndDate"), TextBox).Text = "" Then
                    lblmsg.Text = ValidationMessage(1096)
                    msginfo.Text = ValidationMessage(1014)
                Else
                    BSM.StartDate = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("txtStartDate"), TextBox).Text
                    BSM.EndDate = CType(GridView1.Rows(e.RowIndex).Cells(2).FindControl("txtEndDate"), TextBox).Text
                    If BSM.StartDate > BSM.EndDate Then
                        lblmsg.Text = ValidationMessage(1037)
                        msginfo.Text = ValidationMessage(1014)
                    Else
                        BSMBL.UpdateRecord(BSM)
                        msginfo.Text = ValidationMessage(1017)
                        GridView1.EditIndex = -1
                        lblmsg.Text = ValidationMessage(1014)
                        DisplayGrid()
                        GridView1.Visible = True
                    End If
                End If
            Catch ex As Exception
                lblmsg.Text = ValidationMessage(1055)
                msginfo.Text = ValidationMessage(1014)
            End Try
        Else
            lblmsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit

        GridView1.EditIndex = -1
        DisplayGrid()
        GridView1.Visible = True
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        'If (Session("BranchCode") = Session("ParentBranch")) Then
 

        msginfo.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        GridView1.EditIndex = e.NewEditIndex
        DisplayGrid1()
        GridView1.Visible = True

       
        'Else
        'lblmsg.Text = "You do not belong to this branch, Cannot edit data."
        'msginfo.Text = ""
        'End If
    End Sub
    Sub DisplayGrid()
        BSM.BatchID = ddlBatch.SelectedValue
        GridView1.Visible = False
        'BSM.BatchID = ViewState("BatchID")
        dt = BSMBL.GetCategory(BSM)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
        Else
            lblmsg.Text = ValidationMessage(1023)
            msginfo.Text = ValidationMessage(1014)
            GridView1.Visible = False
            GridView1.Enabled = False
           
        End If

    End Sub
    Sub DisplayGrid1()
        BSM.BatchID = ddlBatch.SelectedValue
        GridView1.Visible = False
        'BSM.BatchID = ViewState("BatchID")
        dt = BSMBL.GetCategory(BSM)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
        Else
            lblmsg.Text = ValidationMessage(1023)
            msginfo.Text = ValidationMessage(1014)
            GridView1.Visible = False
            GridView1.Enabled = False
        End If

    End Sub

    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click

        If ddlBatch.SelectedValue = 0 Then
            lblmsg.Text = ValidationMessage(1079)
            msginfo.Text = ValidationMessage(1014)
        Else
            LinkButton1.Focus()
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            DisplayGrid()
            'GridView1.Visible = True
        End If
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub


    Protected Sub ddlBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.TextChanged
        GridView1.Visible = False
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlBatch.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
        End If
    End Sub

    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            BSM.Batch = 0
            BSM.PKID = 0
            dt = BSMBL.GetCategory(BSM)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = False
            GridView1.Enabled = False
            For Each grid As GridViewRow In GridView1.Rows
                ViewState("PKID") = CType(grid.FindControl("Label5"), Label).Text
                BSM.PKID = ViewState("PKID")
                BSM.StartDate = CType(grid.FindControl("Label1"), Label).Text
                BSM.EndDate = CType(grid.FindControl("Label6"), Label).Text
                BSMBL.UpdateRecord(BSM)
                'End If
            Next
            ''Dim count As New Integer
            ''count = dt.Rows.Count
            ''If dt.Rows.Count <> 0 Then
            ''    While (count > 0)
            ''        BSM.StartDate = dt.Rows(0).Item("StartDate")
            ''        BSM.EndDate = dt.Rows(0).Item("EndDate")
            'BSMBL.UpdateRecord(BSM)
            'count = count - 1
            '    End While
            'End If
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1017)
        Catch ex As Exception

        End Try
    End Sub
  
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
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
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
        
    End Sub
End Class
