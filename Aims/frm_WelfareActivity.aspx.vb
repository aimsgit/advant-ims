
Partial Class frm_WelfareActivity
    Inherits BasePage
    Dim Dt As DataTable
    Sub CheckAll()
        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            GridView1.Visible = True

            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True
            Next
        Else
            GridView1.Visible = True


            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = False
            Next
        End If

    End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        DisplayGrid()
        lblMsg.Text = ValidationMessage(1171)

    End Sub
    Sub DisplayGrid()
        Dim BatchId As Integer
        If ddlBatch.SelectedValue = "" Then
            lblErrorMsg.Text = ValidationMessage(1079)
        Else
            BatchId = ddlBatch.SelectedValue
        End If
        Dt = WelfareActivityDL.WelfareActivityLoadGridView(BatchId)
        If Dt.Rows.Count > 0 Then
            lblMsg.Text = ValidationMessage(1014)
            lblErrorMsg.Text = ValidationMessage(1014)
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataSource = Dt
            GridView1.DataBind()
            

            
        Else
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = ValidationMessage(1023)
            GridView1.Visible = False
            
        End If
    End Sub
    
    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click

        'Dim DL As New WelfareActivityDL
        ''Dim EL As New WelfareActivityEL
        Dim BatchId As Integer
        Dim Scholar As Integer
        Dim id As String = ""
        Dim check As String = ""

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If ddlBatch.SelectedValue = "" Then
                    'BatchId = 0
                    lblErrorMsg.Text = ValidationMessage(1079)
                Else
                    BatchId = ddlBatch.SelectedValue
                End If
                If ddlScholarship.SelectedValue = "" Then
                    'Scholar = 0
                    lblErrorMsg.Text = ValidationMessage(1172)
                Else
                    Scholar = ddlScholarship.SelectedValue
                End If
                Dim Count1 As Integer = 0
                For Each Grid As GridViewRow In GridView1.Rows

                    If CType(Grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                        check = CType(Grid.FindControl("lblADId"), HiddenField).Value
                        id = check + "," + id
                        Count1 = Count1 + 1
                    End If
                Next

                If id = "" Then
                    id = 0
                Else
                    id = Left(id, id.Length - 1)
                End If


                If Count1 > 0 Then
                    'id = ViewState("ChkSelect")
                    WelfareActivityDL.ApproveWelfareActivity(BatchId, id, Scholar)
                    DisplayGrid()
                    lblMsg.Text = ValidationMessage(1173)
                Else
                    lblErrorMsg.Text = ValidationMessage(1174)
                    lblMsg.Text = ValidationMessage(1014)
                End If

            Catch ex As Exception
                lblErrorMsg.Text = ValidationMessage(1022)
            End Try
        Else
            lblErrorMsg.Text = ValidationMessage(1175)
            lblMsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblErrorMsg.Text = ""
        'lblMsg.Text = ""
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            
            Dim BatchId As Integer
            If ddlBatch.SelectedValue = "" Then
                lblErrorMsg.Text = ValidationMessage(1079)
            Else
                BatchId = 0
            End If
            Dt = WelfareActivityDL.WelfareActivityLoadGridView(BatchId)
            If Dt.Rows.Count > 0 Then
                lblMsg.Text = ValidationMessage(1014)
                lblErrorMsg.Text = ValidationMessage(1014)
                GridView1.Visible = True
                GridView1.Enabled = True
                GridView1.DataSource = Dt
                GridView1.DataBind()
                
            End If
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    

    
   
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try
            dt2 = Session("ValidationTable")
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
    Protected Sub BtnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        Try

            Dim qrystring As String = "Rpt_WelfareActivityV.aspx?" & QueryStr.Querystring() & "&batchId=" & ddlBatch.SelectedValue & "&Scholarship=" & ddlScholarship.SelectedValue
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct Data."
            lblMsg.Text = ""
        End Try
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub
End Class

