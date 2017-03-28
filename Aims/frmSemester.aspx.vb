
Partial Class frmSemester
    Inherits BasePage
    Dim bl As New SemesterManager
    Dim dt As New DataTable
    Dim alt, b As String
    Dim a As Integer
    Dim id1 As Integer
    Dim EL As New Semester
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtSemester.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub
    Sub DisplayGridView()
        ' Displays the data-- by Nakul Bharadwaj(12-3-2012)
        Dim dt As New DataTable
        dt = bl.getData2(EL)
        If dt.Rows.Count = 0 Then
            GVAssessment.DataSource = Nothing
            GVAssessment.DataBind()
            msginfo.Text = ValidationMessage(1023)
            lblmsg.Text = ValidationMessage(1014)
        Else
            GVAssessment.DataSource = dt
            GVAssessment.DataBind()
            LinkButton.Focus()
           
        End If
        
    End Sub
    Protected Sub GVAssessment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVAssessment.PageIndexChanging
        If GVAssessment.EditIndex <> -1 Then
            msginfo.Text = ValidationMessage(1063)
            lblmsg.Text = ValidationMessage(1014)
        Else
            GVAssessment.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GVAssessment.PageIndex
            DisplayGridView()
        End If
    End Sub
    Protected Sub GVAssessment_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVAssessment.RowDeleting
        ' Deletes data of the selected row-- by Nakul Bharadwaj(12-3-2012)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If GVAssessment.EditIndex <> -1 Then
                msginfo.Text = ValidationMessage(1063)
                lblmsg.Text = ValidationMessage(1014)
            Else
                a = Convert.ToInt64(GVAssessment.DataKeys(e.RowIndex).Value)
                bl.DeleteAss(a)
                lblmsg.Text = ValidationMessage(1028)
                txtSemester.Focus()
                msginfo.Text = ValidationMessage(1014)
                GVAssessment.PageIndex = ViewState("PageIndex")
                DisplayGridView()
            End If
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
       

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtSemester.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnSave.CommandName = "ADD" Then
                ' Adds the data-- by Nakul Bharadwaj(12-3-2012)
                lblmsg.Text = ValidationMessage(1014)
                EL.Name = txtSemester.Text
                EL.durationDays = txtDuration.Text
                dt = bl.GetDuplicateSemesterMaster(EL)
                lblmsg.Text = ValidationMessage(1014)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                    txtSemester.Text = ""
                    txtDuration.Text = ""
                Else
                    Dim sem As New Semester
                    sem.Name = txtSemester.Text
                    sem.durationDays = txtDuration.Text
                    bl.InsertSemester(sem)
                    ViewState("PageIndex") = 0
                    GVAssessment.PageIndex = 0
                    DisplayGridView()
                    lblmsg.Text = ValidationMessage(1020)
                    msginfo.Text = ValidationMessage(1014)
                    txtSemester.Text = ""
                    txtDuration.Text = ""
                    msginfo.Text = ValidationMessage(1014)
                End If
            ElseIf btnSave.CommandName = "UPDATE" Then
                ' Updates the data-- by Nakul Bharadwaj(12-3-2012)
                Dim sem As New Semester
                sem.Name = txtSemester.Text
                sem.durationDays = txtDuration.Text
                sem.ID = ViewState("id1")
                dt = bl.GetDuplicateSemesterMaster(sem)
                lblmsg.Text = ValidationMessage(1014)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                Else
                    bl.UpdateAsse(sem)
                    msginfo.Visible = True
                    GVAssessment.PageIndex = ViewState("PageIndex")

                    lblmsg.Text = ValidationMessage(1017)
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Visible = True
                    txtSemester.Text = ValidationMessage(1014)
                    txtDuration.Text = ValidationMessage(1014)
                    btnSave.CommandName = "ADD"
                    btnDetails.CommandName = "VIEW"
                    GVAssessment.Enabled = True
                    DisplayGridView()
                End If
            End If
        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        ' VIEW- Displays the data in gridview-- by Nakul Bharadwaj(12-3-2012)
        ' BACK- Goes back to VIEW mode from edit mode-- by Nakul Bharadwaj(12-3-2012)
        If btnDetails.CommandName = "VIEW" Then
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            EL.ID = 0
            GVAssessment.Visible = True
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVAssessment.PageIndex = 0
            DisplayGridView()
            txtSemester.Text = ""
            txtDuration.Text = ""
            GVAssessment.Enabled = True
        Else
            EL.ID = 0
            GVAssessment.Visible = True
            GVAssessment.PageIndex = ViewState("PageIndex")
            DisplayGridView()
            msginfo.Text = ValidationMessage(1014)
            txtSemester.Text = ""
            txtDuration.Text = ""
            btnSave.CommandName = "ADD"
            btnDetails.CommandName = "VIEW"
            GVAssessment.Enabled = True
        End If
     
    End Sub
    Protected Sub GVAssessment_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVAssessment.RowEditing
        ' The data of the selected row goes to edit mode-- by Nakul Bharadwaj(12-3-2012)
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        txtSemester.Text = CType(GVAssessment.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtDuration.Text = CType(GVAssessment.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        ViewState("id1") = CType(GVAssessment.Rows(e.NewEditIndex).FindControl("SID"), HiddenField).Value
        EL.ID = ViewState("id1")
        dt = bl.getData2(EL)
        GVAssessment.DataSource = dt
        GVAssessment.DataBind()
        GVAssessment.Visible = True
        GVAssessment.Enabled = False
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        btnSave.CommandName = "UPDATE"
        btnSave.Text = "UPDATE"
        btnDetails.CommandName = "BACK"
        btnDetails.Text = "BACK"

        DisplayGridView()
        
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If


    End Sub
    Sub Disable()
        btnDetails.Enabled = "False"
        txtSemester.Enabled = "False"
    End Sub
    Sub Enable()
        btnSave.Enabled = "True"
        btnDetails.Enabled = "True"
        txtSemester.Enabled = "True"
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVAssessment_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVAssessment.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        dt = bl.getData2(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVAssessment.DataSource = sortedView
        GVAssessment.DataBind()
        LinkButton.Focus()
        
    End Sub
    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = value
        End Set
    End Property
   
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
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
        Return 0
    End Function
End Class
