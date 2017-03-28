
Partial Class frmBookMaster
    Inherits BasePage
    Dim dt As New DataTable
    Dim BM As New BookMaster
    Dim BookManager As New BookManager
    Dim BAL As New BookManager
    Public Sub btnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'for Response of ADD and UPDATE button Click
        BookNameTextBox.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnSave.Text = "UPDATE" Then
                Try
                    BM.DeptId = ddlDept.SelectedValue
                    BM.Name = BookNameTextBox.Text
                    BM.classno = txtClass.Text
                    BM.Code = BookCodeTextBox.Text
                    BM.IssueRef = ddlIssueRef.SelectedValue
                    If txtrcvdate.Text = "" Then
                        BM.ReceiveDate = "1/1/1900"
                    Else
                        BM.ReceiveDate = CDate(txtrcvdate.Text)
                    End If
                    If txtPages.Text = "" Then
                        BM.Pages = 0
                    Else
                        BM.Pages = txtPages.Text
                    End If
                    BM.Subject = cmbSubject.SelectedValue
                    If BookEditionNoTextBox.Text = "" Then
                        BM.Edition = ""
                    Else
                        BM.Edition = BookEditionNoTextBox.Text
                    End If
                    BM.Publisher = BookPublisherTextBox.Text
                    BM.Author = txtAuthor.Text
                    BM.Quantity = txtQuantity.Text
                    If txtPrice.Text = "" Then
                        BM.Price = 0
                    Else
                        BM.Price = txtPrice.Text
                    End If
                    BM.ISBN = txtISBN.Text
                    If txtRackNo.Text = "" Then
                        BM.RackNo = ""
                    Else
                        BM.RackNo = txtRackNo.Text
                    End If
                    If txtShelfNo.Text = "" Then
                        BM.ShelfNo = ""
                    Else
                        BM.ShelfNo = txtShelfNo.Text
                    End If
                    BM.Id = ViewState("BMID")
                    dt = BookManager.GetDuplicateENTRY(BM)
                    If dt.Rows.Count > 0 Then
                        lblmsginfo.Text = ""
                        lblErrorMsg.Text = "Data already exists."
                        'DisplayGrid()
                        BookNameTextBox.Focus()
                    Else
                        BAL.UpdateRecord(BM)
                        btnSave.Text = "ADD"
                        btnDetails.Text = "VIEW"
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = "Data Updated Successfully."
                        txtQuantity.Text = "1"
                        clear()
                        GVBookMaster.Visible = True
                        GVBookMaster.PageIndex = ViewState("PageIndex")
                        txtrcvdate.Text = ""
                        DisplayGrid()
                        txtrcvdate.Text = Format(Today, "dd-MMM-yyyy")
                    End If
                Catch ex As Exception
                    lblErrorMsg.Text = "Receive Date is not valid."
                    txtrcvdate.Focus()
                    lblmsginfo.Text = ""
                End Try

            ElseIf btnSave.Text = "ADD" Then
                Try
                    BM.Code = BookCodeTextBox.Text
                    dt = BookManager.GetDuplicateENTRY(BM)
                    If dt.Rows.Count > 0 Then
                        DisplayGrid()
                        lblmsginfo.Text = ""
                        lblErrorMsg.Text = "Data already exists."
                        'DisplayGrid()
                        BookNameTextBox.Focus()
                        Exit Sub
                    Else
                        BM.DeptId = ddlDept.SelectedValue
                        BM.Name = BookNameTextBox.Text
                        BM.classno = txtClass.Text
                        BM.Code = BookCodeTextBox.Text
                        BM.IssueRef = ddlIssueRef.SelectedValue
                        If txtrcvdate.Text = "" Then
                            BM.ReceiveDate = "1/1/1900"
                        Else
                            BM.ReceiveDate = CDate(txtrcvdate.Text)
                        End If
                        If txtPages.Text = "" Then
                            BM.Pages = 0
                        Else
                            BM.Pages = txtPages.Text
                        End If
                        If BookEditionNoTextBox.Text = "" Then
                            BM.Edition = ""
                        Else
                            BM.Edition = BookEditionNoTextBox.Text
                        End If
                        BM.Subject = cmbSubject.SelectedValue
                        If BookPublisherTextBox.Text = "" Then
                            BM.Publisher = ""
                        Else
                            BM.Publisher = BookPublisherTextBox.Text
                        End If
                        If txtAuthor.Text = "" Then
                            BM.Author = ""
                        Else
                            BM.Author = txtAuthor.Text
                        End If
                        If txtQuantity.Text = "" Then
                            BM.Quantity = 1
                        Else
                            BM.Quantity = txtQuantity.Text
                        End If
                        If txtPrice.Text = "" Then
                            BM.Price = 0
                        Else
                            BM.Price = txtPrice.Text
                        End If
                        BM.ISBN = txtISBN.Text
                        If txtRackNo.Text = "" Then
                            BM.RackNo = ""
                        Else
                            BM.RackNo = txtRackNo.Text
                        End If
                        If txtShelfNo.Text = "" Then
                            BM.ShelfNo = ""
                        Else
                            BM.ShelfNo = txtShelfNo.Text
                        End If
                        BAL.InsertRecord(BM)
                        btnSave.Text = "ADD"
                        clear()
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = "Data Saved Successfully."
                        txtQuantity.Text = "1"
                        ViewState("PageIndex") = 0
                        GVBookMaster.PageIndex = 0
                        txtrcvdate.Text = ""
                        DisplayGrid()
                        txtrcvdate.Text = Format(Today, "dd-MMM-yyyy")
                    End If
                Catch ex As Exception
                    lblErrorMsg.Text = "Receive Date is not valid."
                    txtrcvdate.Focus()
                    lblmsginfo.Text = ""
                End Try
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsginfo.Text = ""
        End If

    End Sub

    Protected Sub btnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("RecoverForm") = "BookMaster"
        Response.Redirect("Recover.aspx")
    End Sub
    Protected Sub GVBookMaster_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GVBookMaster.RowDeleted

    End Sub
    'for deleting data
    Protected Sub GVBookMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVBookMaster.RowDeleting

        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("BMID") = CType(GVBookMaster.Rows(e.RowIndex).Cells(1).FindControl("BID"), HiddenField).Value
            BM.Id = ViewState("BMID")
            BAL.ChangeFlag(BM)
            'DisplayGrid()
            GVBookMaster.Visible = True
            lblErrorMsg.Text = ""
            lblmsginfo.Text = "Data Deleted Successfully."
            BookNameTextBox.Focus()
            GVBookMaster.PageIndex = ViewState("PageIndex")
            txtrcvdate.Text = ""
            BM.Id = 0
            If BookNameTextBox.Text = "" Then
                BM.Name = 0
            Else
                BM.Name = BookNameTextBox.Text
            End If
            If BookCodeTextBox.Text = "" Then
                BM.Code = 0
            Else
                BM.Code = BookCodeTextBox.Text
            End If
            If txtrcvdate.Text = "" Then
                BM.ReceiveDate = "1/1/1900"
            Else
                BM.ReceiveDate = CDate(txtrcvdate.Text)
            End If

            If BookPublisherTextBox.Text = "" Then
                BM.Publisher = 0
            Else
                BM.Publisher = BookPublisherTextBox.Text
            End If
            dt = BAL.GetBookDetails(BM)
            GVBookMaster.DataSource = dt
            GVBookMaster.DataBind()
            GVBookMaster.Enabled = True
            GVBookMaster.Visible = True
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsginfo.Text = ""
        End If

    End Sub
    'for editing data
    Protected Sub GVBookMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBookMaster.RowEditing
        lblErrorMsg.Text = ""
        lblmsginfo.Text = ""

        ddlDept.SelectedValue = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Dept"), HiddenField).Value
        BookNameTextBox.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtClass.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("lblClassno"), Label).Text
        BookCodeTextBox.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        txtrcvdate.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Label20"), Label).Text
        txtPages.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        BookEditionNoTextBox.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        BookPublisherTextBox.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Label17"), Label).Text
        'cmbSubject.SelectedValue = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Label16"), Label).Text
        txtAuthor.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Label18"), Label).Text
        txtQuantity.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("lblqty"), Label).Text
        txtPrice.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("lblprice"), Label).Text
        cmbSubject.SelectedValue = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("Label6"), HiddenField).Value
        ViewState("BMID") = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("BID"), HiddenField).Value
        txtISBN.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("lblISBN"), Label).Text
        txtRackNo.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("lblRackNo"), Label).Text
        txtShelfNo.Text = CType(GVBookMaster.Rows(e.NewEditIndex).FindControl("lblShelfNo"), Label).Text

        BM.Id = ViewState("BMID")
        BM.Name = 0
        BM.Code = 0
        BM.ReceiveDate = "1/1/1900"
        BM.Publisher = 0
        dt = BAL.GetBookDetails(BM)
        ddlIssueRef.SelectedValue = dt.Rows(0).Item("IssueRef")
        displayEdit()

    End Sub
    Sub displayEdit()
        BM.Name = 0
        BM.Code = 0
        BM.ReceiveDate = "1/1/1900"
        BM.Publisher = 0
        btnSave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        BM.Id = ViewState("BMID")
        dt = BAL.GetBookDetails(BM)
        GVBookMaster.DataSource = dt
        GVBookMaster.DataBind()
        GVBookMaster.Enabled = False
        For Each rows As GridViewRow In GVBookMaster.Rows
            If CType(rows.FindControl("Label20"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("Label20"), Label).Text = ""
            End If

        Next
        For Each rows As GridViewRow In GVBookMaster.Rows
            If CType(rows.FindControl("Label4"), Label).Text = "0" Then
                CType(rows.FindControl("Label4"), Label).Text = ""
            End If
        Next
    End Sub
    'for Displaying GridView
    Sub DisplayGrid()
        Dim dt As New DataTable
        BM.Id = 0
        If BookNameTextBox.Text = "" Then
            BM.Name = 0
        Else
            BM.Name = BookNameTextBox.Text
        End If
        If BookCodeTextBox.Text = "" Then
            BM.Code = 0
        Else
            BM.Code = BookCodeTextBox.Text
        End If
        If txtrcvdate.Text = "" Then
            BM.ReceiveDate = "1/1/1900"
        Else
            BM.ReceiveDate = CDate(txtrcvdate.Text)
        End If

        If BookPublisherTextBox.Text = "" Then
            BM.Publisher = 0
        Else
            BM.Publisher = BookPublisherTextBox.Text
        End If
        dt = BAL.GetBookDetails(BM)
        If dt.Rows.Count = 0 Then
            GVBookMaster.DataSource = Nothing
            GVBookMaster.DataBind()
            lblmsginfo.Text = ""
            lblErrorMsg.Text = "No records to display."
            BookNameTextBox.Focus()
        Else
            GVBookMaster.DataSource = dt
            GVBookMaster.DataBind()
            GVBookMaster.Enabled = True
            GVBookMaster.Visible = True
            For Each rows As GridViewRow In GVBookMaster.Rows
                If CType(rows.FindControl("Label20"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("Label20"), Label).Text = ""
                End If
                If CType(rows.FindControl("lblIssueRef"), Label).Text = "I" Then
                    CType(rows.FindControl("lblIssueRef"), Label).Text = "Issue"
                Else
                    CType(rows.FindControl("lblIssueRef"), Label).Text = "Reference"

                End If
            Next
            For Each rows As GridViewRow In GVBookMaster.Rows
                If CType(rows.FindControl("Label4"), Label).Text = "0" Then
                    CType(rows.FindControl("Label4"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GVBookMaster.Rows
                If CType(rows.FindControl("lblprice"), Label).Text = "0.00" Then
                    CType(rows.FindControl("lblprice"), Label).Text = ""
                End If
            Next
        End If
    End Sub
    'for Response of View Button Click
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        lblErrorMsg.Text = ""
        lblmsginfo.Text = ""
        ViewState("BMID") = 0
        'code for search records By Nitin 28/06/2012
        If btnDetails.Text = "VIEW" Then
            ViewState("PageIndex") = 0
            GVBookMaster.PageIndex = 0
            DisplayGrid()
            GVBookMaster.Visible = True
        ElseIf btnDetails.Text = "BACK" Then
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            clear()
            txtrcvdate.Text = ""
            GVBookMaster.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            txtrcvdate.Text = Format(Today, "dd-MMM-yyyy")
            GVBookMaster.Visible = True
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtQuantity.Text = "1"
        txtQuantity.Enabled = False
        Dim heading As String
        heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            txtrcvdate.Text = Format(Today, "dd-MMM-yyy")

        End If
        ddlDept.Focus()
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
    Protected Sub GVBookMaster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBookMaster.PageIndexChanging
        GVBookMaster.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVBookMaster.PageIndex
        DisplayGrid()
    End Sub
    'for clearing data of all TextBox
    Sub clear()
        BookNameTextBox.Text = ""
        txtClass.Text = ""
        BookCodeTextBox.Text = ""
        txtrcvdate.Text = Format(Today, "dd-MMM-yyyy")
        txtPages.Text = ""
        BookEditionNoTextBox.Text = ""
        BookPublisherTextBox.Text = ""
        txtAuthor.Text = ""
        'txtQuantity.Text = ""
        txtPrice.Text = ""
        txtISBN.Text = ""
        txtRackNo.Text = ""
        txtShelfNo.Text = ""
    End Sub

    Protected Sub GVBookMaster_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVBookMaster.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        Dim dt As New DataTable
        BM.Id = 0
        If BookNameTextBox.Text = "" Then
            BM.Name = 0
        Else
            BM.Name = BookNameTextBox.Text
        End If
        If BookCodeTextBox.Text = "" Then
            BM.Code = 0
        Else
            BM.Code = BookCodeTextBox.Text
        End If
        If txtrcvdate.Text = "" Then
            BM.ReceiveDate = "1/1/1900"
        Else
            BM.ReceiveDate = CDate(txtrcvdate.Text)
        End If

        If BookPublisherTextBox.Text = "" Then
            BM.Publisher = 0
        Else
            BM.Publisher = BookPublisherTextBox.Text
        End If
        dt = BAL.GetBookDetails(BM)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVBookMaster.DataSource = sortedView
        GVBookMaster.DataBind()

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
