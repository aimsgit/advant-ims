
Partial Class frmStudentCategory
    Inherits BasePage
    Dim bl As New BLStudentCategory
    Dim dt As New DataTable
    Dim EL As New Category

    Protected Sub InsertButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertButton.Click
        txtname.Focus()

        If (Session("BranchCode") = Session("ParentBranch")) Then
            If InsertButton.CommandName = "ADD" Then
                ' Adds the data-- by Anchala Verma(19-4-2012)
                lblmsg.Text = ValidationMessage(1014)
                EL.CategoryName = txtname.Text
                dt = bl.GetDuplicateStudentCategory(EL)
                lblmsg.Text = ValidationMessage(1014)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                Else
                    bl.InsertStudentCategory(EL)
                    lblmsg.Text = ValidationMessage(1020)
                    ViewState("PageIndex") = 0
                    GvStdcategory.PageIndex = 0
                    DisplayGridView()
                    txtname.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1014)
                End If
            ElseIf InsertButton.CommandName = "UPDATE" Then
                EL.CategoryId = ViewState("ID")
                EL.CategoryName = txtname.Text
                dt = bl.GetDuplicateStudentCategory(EL)
                lblmsg.Text =ValidationMessage(1014)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                Else
                    bl.UpdateStudentCategory(EL)
                    msginfo.Visible = True
                    lblmsg.Text = ValidationMessage(1017)
                    GvStdcategory.PageIndex = ViewState("PageIndex")

                    lblmsg.Visible = True
                    txtname.Text = ""
                    InsertButton.CommandName = "ADD"
                    btnDet.CommandName = "VIEW"
                    GvStdcategory.Enabled = True
                    DisplayGridView()
                End If
            End If
        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        If btnDet.CommandName = "VIEW" Then

            GvStdcategory.Visible = True
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GvStdcategory.PageIndex = 0
            DisplayGridView()
            txtname.Text = ""
            GvStdcategory.Enabled = True
            InsertButton.CommandName = "ADD"
            btnDet.CommandName = "VIEW"
        Else
            GvStdcategory.Visible = True
            GvStdcategory.PageIndex = ViewState("PageIndex")
            DisplayGridView()
            msginfo.Text = ValidationMessage(1014)
            txtname.Text = ValidationMessage(1014)
            InsertButton.Text = "ADD"
            btnDet.Text = "VIEW"
            GvStdcategory.Enabled = True
        End If
        
    End Sub
    Protected Sub GvStdcategory_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvStdcategory.RowEditing
        ' The data of the selected row goes to edit mode-- by Anchala(19-4-2012)
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        txtname.Text = CType(GvStdcategory.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        ViewState("ID") = CType(GvStdcategory.Rows(e.NewEditIndex).FindControl("DID"), HiddenField).Value
        EL.CategoryId = ViewState("ID")
        dt = bl.GetStudentcategory(EL.CategoryId)
        GvStdcategory.DataSource = dt
        GvStdcategory.DataBind()
        GvStdcategory.Visible = True
        GvStdcategory.Enabled = False
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        InsertButton.Text = "UPDATE"
        btnDet.Text = "BACK"
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

    End Sub

    Protected Sub GvStdcategory_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvStdcategory.PageIndexChanging
        GvStdcategory.PageIndex = e.NewPageIndex
        Dim dt As New DataTable
        ViewState("PageIndex") = GvStdcategory.PageIndex
        EL.CategoryId = ViewState("VMID")
        dt = bl.GetStudentcategory(EL.CategoryId)
        GvStdcategory.DataSource = dt
        GvStdcategory.Visible = True
        GvStdcategory.DataBind()
    End Sub
    Protected Sub GvStdcategory_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvStdcategory.RowDeleting
        'EL.CategoryId = ViewState("ID")

        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.CategoryId = CType(GvStdcategory.Rows(e.RowIndex).FindControl("DID"), HiddenField).Value

            bl.DeleteStudentCategory(EL)

            lblmsg.Text = ValidationMessage(1028)
            txtName.Focus()
            dt = bl.GetStudentcategory(0)
            If dt.Rows.Count > 0 Then
                GvStdcategory.DataSource = dt
                GvStdcategory.Visible = True
                GvStdcategory.Enabled = True
                GvStdcategory.PageIndex = ViewState("PageIndex")
                GvStdcategory.DataBind()
                LinkButton.Focus()
            Else
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1023)
                GvStdcategory.Visible = False
            End If
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
        
    End Sub
    Sub DisplayGridView()
        ' Displays the data-- by Anchala Verma(19-4-2012)
        Dim dt As New DataTable
        dt = bl.GetStudentcategory(0)
        If dt.Rows.Count = 0 Then
            GvStdcategory.DataSource = Nothing
            GvStdcategory.DataBind()
            msginfo.Text = ValidationMessage(1023)
            lblmsg.Text = ValidationMessage(1014)
          
        Else
            GvStdcategory.DataSource = dt
            GvStdcategory.DataBind()
           

        End If

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtname.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading

     
    End Sub

    Protected Sub GvStdcategory_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GvStdcategory.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        dt = bl.GetStudentcategory(0)
       

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GvStdcategory.DataSource = sortedView
        GvStdcategory.DataBind()
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
   
    ''Retriving the text of controls based on Language

   
  
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
