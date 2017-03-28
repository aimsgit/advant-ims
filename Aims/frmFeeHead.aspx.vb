'code written by manish 09-02-2012
Partial Class frmFeeHead
    Inherits BasePage
    Dim alt As String
    Dim Feeheads As New FeeHeadsB
    Dim idd As Integer
    Dim f As New FeeHeads
    Dim dt As New DataTable
    'used for showing data in grid
    Sub DisplayGrid()
        f.id = 0
        dt = Feeheads.GetReportData(f)
        If dt.Rows.Count > 0 Then
            Grdfeehead.DataSource = dt
            Grdfeehead.DataBind()
            Grdfeehead.Visible = True
            Grdfeehead.Enabled = True
            LinkButton.Focus()
        Else
            lblmsg.Text = "No records to display."
            msginfo.Text = ""
        End If
        'clear()
    End Sub
    'description of view event click
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click

        'If lblmsg.Visible = True Or msginfo.Visible = True Then
        'lblmsg.Visible = False
        'msginfo.Visible = False
        'End If
        If btnDetails.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            Grdfeehead.PageIndex = 0
            DisplayGrid()
            ' Grdfeehead.Visible = True
            'clear()
        Else
            btnDetails.Text = "VIEW"
            btnSave.Text = "ADD"
            Grdfeehead.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            lblmsg.Text = ""
            msginfo.Text = ""
            clear()
        End If
    End Sub
    'description of delete event click
    Protected Sub Grdfeehead_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grdfeehead.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            f.id = CType(Grdfeehead.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text
            Feeheads.ChangeFlag(f)
            Grdfeehead.DataBind()
            lblmsg.Text = ""
            msginfo.Text = "Data Deleted Successfully."
            Grdfeehead.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            clear()
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If

    End Sub
    'description of edit event click
    Protected Sub Grdfeehead_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grdfeehead.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        msginfo.Text = ""
        lblmsg.Text = ""
        txtName.Text = CType(Grdfeehead.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        ViewState("FHID") = CType(Grdfeehead.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        btnSave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        Dim dt As New DataTable
        f.id = ViewState("FHID")
        dt = Feeheads.GetReportData(f)
        Grdfeehead.DataSource = dt
        Grdfeehead.DataBind()
        Grdfeehead.Enabled = False
        'Else
        'lblmsg.Text = "You do not belong to this branch, Cannot edit data."
        'msginfo.Text = ""
        'End If

    End Sub
    'description of add event as well as update event click
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnSave.Text = "UPDATE" Then
                f.FeeHead = txtName.Text
                f.id = ViewState("FHID")
                dt = Feeheads.GetDuplicateFeeheadType(f)
                If dt.Rows.Count > 0 Then

                    msginfo.Text = ""
                    lblmsg.Text = "Data already exists."
                    'DisplayGrid() 

                Else
                    Feeheads.UpdateRecord(f)
                    btnSave.Text = "ADD"
                    btnDetails.Text = "VIEW"
                    clear()
                    lblmsg.Text = ""
                    msginfo.Text = "Data Updated Successfully."
                    Grdfeehead.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                End If
            ElseIf btnSave.Text = "ADD" Then
                f.FeeHead = txtName.Text
                dt = Feeheads.GetDuplicateFeeheadType(f)
                If dt.Rows.Count > 0 Then

                    msginfo.Text = ""


                    'If lblmsg.Visible = False Then
                    lblmsg.Text = ""
                    'End If
                    lblmsg.Text = "Data already exists."
                    DisplayGrid()
                    'clear()
            Else
                If txtName.Text = "" Then
                    lblmsg.Text = "Fee head type Field is Mandatory."
                Else
                    Feeheads.InsertRecord(f)
                    btnSave.Text = "ADD"
                    lblmsg.Text = ""
                    msginfo.Text = "Data Saved Successfully."
                    ViewState("PageIndex") = 0
                    Grdfeehead.PageIndex = 0
                    DisplayGrid()
                    clear()
                End If
            End If
            End If
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot add/update data."
            msginfo.Text = ""
        End If


    End Sub
    'for clearing text in textbox
    Sub clear()

        txtName.Text = ""

    End Sub

    'for page indexing one page to another
    Protected Sub Grdfeehead_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Grdfeehead.PageIndexChanging
        Grdfeehead.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = Grdfeehead.PageIndex
        DisplayGrid()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Session("SourceOther") = "SAVED\Fee Head.html"
        If Not IsPostBack Then


            txtName.Focus()
            Dim heading As String
            ViewState("heading") = Session("RptFrmTitleName")
            Me.Lblheading.Text = ViewState("heading")
        End If
    End Sub

    Protected Sub Grdfeehead_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles Grdfeehead.Sorting
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        f.id = 0
        dt = Feeheads.GetReportData(f)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        Grdfeehead.DataSource = sortedView
        Grdfeehead.DataBind()
    End Sub

    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = Value
        End Set
    End Property
End Class

