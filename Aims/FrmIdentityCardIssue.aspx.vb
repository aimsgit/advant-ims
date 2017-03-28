
Partial Class FrmIdentityCardIssue
    Inherits BasePage
    Dim IdCardIssue As New IDCardIssue
    Dim BLIdcardIssue As New BLIdCardIssue
    Dim DLIdcardIssue As New DLIdCardIssue
    Dim dt As New DataTable

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        'Code For Display Grid Button By Nitin 08/06/2012 
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblMsg.Text = ""
        lblErrorMsg.Text = ""

        If btnView.Text = "VIEW" Then
            dt = BLIdcardIssue.GetIdCardIssue(IdCardIssue)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                display()
                GridView1.Visible = True
                GridView1.Enabled = True
            Else
                lblMsg.Text = ""
                lblErrorMsg.Text = "No records to display."
            End If
        End If
        If btnView.Text = "BACK" Then
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            GridView1.PageIndex = ViewState("PageIndex")
            display()
            Clear()
            txtIssuedate.Text = Format(Date.Today, "dd-MMM-yyyy")
        End If

        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
        'lblMsg.Text = ""
        'End If
    End Sub

    'code for display  rows of grid by Nitin 06/06/2012
    Public Sub display()
        LinkButton1.Focus()
        IdCardIssue.PKID = 0
        GridView1.Enabled = True
        dt = BLIdcardIssue.GetIdCardIssue(IdCardIssue)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
        Else
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display."

        End If
        GridView1.Enabled = True
        GridView1.Visible = True
    End Sub

    'code for display  rows of grid by Nitin 06/06/2012
    Public Sub displaySinglerow()
        IdCardIssue.PKID = ViewState("PKID")
        GridView1.Enabled = True
        dt = BLIdcardIssue.GetIdCardIssue(IdCardIssue)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
        Else
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display."

        End If
        GridView1.Enabled = True
        GridView1.Visible = True
    End Sub

    Sub Clear()
        'txtIssuedate.Text = ""
        Image2.ImageUrl = "~\Images\imageupload.gif"
        txtStudentCode.Text = ""
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ddlbatch1.Focus()
            'Code For ADD and UPDATE Button By Nitin 08/06/2012 
            Try
                IdCardIssue.BacthID = ddlbatch1.SelectedValue
                IdCardIssue.StudentID = DDLStudent.SelectedValue
                If IdCardIssue.CardType = "Select" Then
                    IdCardIssue.CardType = ddlCardType.SelectedItem.Text
                Else
                    IdCardIssue.CardType = ddlCardType.SelectedItem.Text
                End If
                If txtIssuedate.Text = "" Then
                    IdCardIssue.IssueDate = "#1/1/3000#"
                Else
                    IdCardIssue.IssueDate = txtIssuedate.Text
                End If

                'If txtIssuedate.Text = Format(Date.Today, "dd-MMM-yyyy") Then
                '    IdCardIssue.IssueDate = Date.Today
                'Else
                '    IdCardIssue.IssueDate = txtIssuedate.Text
                'End If
                If txtIssuedate.Text <> "" Then
                    If CType(txtIssuedate.Text, Date) > Date.Today Then
                        lblErrorMsg.Text = "Issue date cannot be greater than today's date."
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                End If
               
                IdCardIssue.PKID = ViewState("PKID")
                If btnAdd.Text = "ADD" Then
                    IdCardIssue.PKID = 0
                    dt = BLIdcardIssue.GetDuplicate(IdCardIssue)
                    If dt.Rows.Count > 0 Then
                        lblMsg.Text = ""
                        lblErrorMsg.Text = "Data already exists."
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        'display()
                        'Clear()
                    Else
                        BLIdcardIssue.InsertIntoIdCardIssue(IdCardIssue)
                        lblErrorMsg.Text = ""
                        lblMsg.Text = "Data Saved Successfully."
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        display()
                        Clear()
                        txtIssuedate.Text = Format(Date.Today, "dd-MMM-yyyy")
                    End If
                ElseIf btnAdd.Text = "UPDATE" Then
                    IdCardIssue.PKID = ViewState("PKID")
                    dt = BLIdcardIssue.GetDuplicate(IdCardIssue)
                    If dt.Rows.Count > 0 Then
                        lblMsg.Text = ""
                        lblErrorMsg.Text = "Data already exists."
                    Else
                        BLIdcardIssue.UpdateIdCardIssue(IdCardIssue)
                        lblErrorMsg.Text = ""
                        lblMsg.Text = "Data Updated Successfully."
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        GridView1.PageIndex = ViewState("PageIndex")
                        display()
                        Clear()
                        txtIssuedate.Text = Format(Date.Today, "dd-MMM-yyyy")
                    End If
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Issue date is not a valid Date."
            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, cannot add/update data."
            lblMsg.Text = ""
        End If
    End Sub
    'Code for Autofill student code and image By nitin 08/06/2012
    Protected Sub DDLStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLStudent.SelectedIndexChanged
        Try
            IdCardIssue.StudentID = DDLStudent.SelectedValue
            Dim STD_ID As Integer
            STD_ID = DDLStudent.SelectedValue
            dt = BLIdcardIssue.AutoFillStdPhoto(STD_ID)
            If dt.Rows.Count > 0 Then
                txtStudentCode.Text = dt.Rows(0).Item("StdCode")
                Image2.ImageUrl = dt.Rows(0).Item("Std_Photo")
                If Image2.ImageUrl = "" Then
                    Image2.ImageUrl = "~\Images\imageupload.gif"
                End If
            Else
                lblErrorMsg.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        display()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            BLIdcardIssue.DeleteIdCardIssue(CType(GridView1.Rows(e.RowIndex).FindControl("lblpkid"), HiddenField).Value())
            IdCardIssue.PKID = ViewState("PKID")
            GridView1.DataBind()
            lblErrorMsg.Text = ""
            lblMsg.Text = "Data Deleted Successfully."
            ddlbatch1.Focus()
            Clear()
            GridView1.PageIndex = ViewState("PageIndex")
            display()
            GridView1.Visible = True
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblMsg.Text = ""
        End If
    End Sub

    'code For Row Editing By Nitin 09/06/2012
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblErrorMsg.Text = ""
        lblMsg.Text = ""

        ViewState("PKID") = (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblpkid"), HiddenField).Value())
        ddlbatch1.SelectedValue = (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBatchID"), HiddenField).Value())
        If DDLStudent.SelectedValue = "0" Then
            IdCardIssue.StudentID = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStdIDd"), HiddenField).Value
            IdCardIssue.StudentID = ViewState("StudentID")
            ViewState("StudentID") = DDLStudent.SelectedValue
            DDLStudent.Items.Clear()
            DDLStudent.DataSourceID = "ObjStudent"
            DDLStudent.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStdIDd"), HiddenField).Value

        Else
            IdCardIssue.StudentID = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStdIDd"), HiddenField).Value
            IdCardIssue.StudentID = ViewState("StudentID")
            DDLStudent.SelectedValue = ViewState("StudentID")
            DDLStudent.Items.Clear()
            DDLStudent.DataSourceID = "ObjStudent"
            DDLStudent.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStdIDd"), HiddenField).Value

        End If

        ddlCardType.SelectedValue = (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblcardtype"), Label)).Text
        txtStudentCode.Text = (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblstudentcode"), Label)).Text
        txtIssuedate.Text = (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblissuedate"), Label)).Text
        ViewState("ImageTime") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelPhotos"), Label).Text.Trim
        Image2.ImageUrl = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelPhotos"), Label).Text.Trim
        If Image2.ImageUrl = "" Then
            Image2.ImageUrl = "~\Images\imageupload.gif"
        End If
        IdCardIssue.PKID = ViewState("PKID")
        dt = BLIdcardIssue.GetIdCardIssue(IdCardIssue)
        GridView1.DataSource = dt
        GridView1.DataBind()
        displaySinglerow()
        btnAdd.Text = "UPDATE"
        btnView.Text = "BACK"
        GridView1.Enabled = False
        GridView1.Visible = True
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblMsg.Text = ""
        'End If
    End Sub

    Protected Sub ddlbatch1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch1.SelectedIndexChanged
        lblErrorMsg.Text = ""
        txtStudentCode.Text = ""
        Image2.ImageUrl = "~\Images\imageupload.gif"
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading

        If Not Page.IsPostBack Then
            txtIssuedate.Text = Format(Date.Today, "dd-MMM-yyyy")
            ddlbatch1.Focus()
        End If
        If Image2.ImageUrl = "" Then
            Image2.ImageUrl = "~\Images\imageupload.gif"
        End If
    End Sub
    Protected Sub ddlbatch1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch1.TextChanged
        ddlbatch1.Focus()
    End Sub
    Protected Sub ddlCardType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCardType.TextChanged
        ddlCardType.Focus()
    End Sub

    Protected Sub DDLStudent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLStudent.TextChanged
        DDLStudent.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        LinkButton1.Focus()
        IdCardIssue.PKID = 0
        GridView1.Enabled = True
        dt = BLIdcardIssue.GetIdCardIssue(IdCardIssue)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
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
End Class
