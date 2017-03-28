
Partial Class frmbranchconfig
    Inherits BasePage
    Dim config As New SystemConfiguration
    Dim dt As DataTable
    Dim blconfig As New BLSystemConfiguration
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim heading As String
            heading = Session("RptFrmTitleName")
            Me.Lblheading.Text = heading
            config.BranchCode = Session("Branchcode")
            dt = blconfig.DisplayBranchRecord(config)
            GridView2.DataSource = dt
            If dt.Rows.Count = 0 Then
                GridView2.Visible = False
                'lblErrorMsg.Text = "No Records to display."
            Else
                GridView2.Visible = True
                GridView2.Enabled = True
                GridView2.DataBind()
                For Each rows As GridViewRow In GridView2.Rows
                    If CType(rows.FindControl("LblDate"), Label).Text = "01-Jan-1900" Then
                        CType(rows.FindControl("LblDate"), Label).Text = ""
                    End If
                Next
            End If
        End If
    End Sub

    Protected Sub GridView2_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView2.RowCancelingEdit
        GridView2.EditIndex = -1
        DisplayGrid()
        GridView2.Visible = True
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub

    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        GridView2.EditIndex = e.NewEditIndex
        DisplayGrid()
        GridView2.Visible = True
    End Sub
    Public Sub DisplayGrid()
        config.BranchCode = Session("Branchcode")
        dt = blconfig.DisplayBranchRecord(config)
        GridView2.DataSource = dt
        If dt.Rows.Count = 0 Then
            GridView2.Visible = False
            'lblErrorMsg.Text = "No Records to display."
        Else
            GridView2.Visible = True
            GridView2.Enabled = True
            GridView2.DataBind()
            For Each rows As GridViewRow In GridView2.Rows
                If CType(rows.FindControl("LblDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("LblDate"), Label).Text = ""
                End If
            Next
        End If
    End Sub

    Protected Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView2.RowUpdating
        If (Session("BranchCode") = Session("ParentBranch")) Then

            'ViewState("BatchID") = CType(GridView1.Rows(e.RowIndex).FindControl("Label4"), Label).Text
            msginfo.Text = ""
            lblmsg.Text = ""
            ViewState("Config_AutoNo") = CType(GridView2.Rows(e.RowIndex).FindControl("LblConfigID"), Label).Text
            config.configID = ViewState("Config_AutoNo")
            Try
                If CType(GridView2.Rows(e.RowIndex).Cells(1).FindControl("txtvalue"), TextBox).Text = "" Then
                    msginfo.Text = "Data Updated Successfully."
                    lblmsg.Text = ""
                    Exit Sub
                Else
                    config.Value = CType(GridView2.Rows(e.RowIndex).Cells(1).FindControl("txtvalue"), TextBox).Text
                End If
                ' BSM.EndDate = CType(GridView2.Rows(e.RowIndex).Cells(2).FindControl("txtEndDate"), TextBox).Text
                
                blconfig.UpdateBranchRecord(config)
                msginfo.Text = "Data Updated Successfully."
                GridView2.EditIndex = -1
                lblmsg.Text = ""
                DisplayGrid()
                GridView2.Visible = True
                
            Catch ex As Exception
                lblmsg.Text = " Please enter correct Date."
                msginfo.Text = ""
            End Try
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot update data."
            msginfo.Text = ""
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
