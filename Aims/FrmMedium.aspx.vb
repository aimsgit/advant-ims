
Partial Class FrmMedium
    Inherits BasePage
    Dim alt, alt1, alt2 As String
    Dim sda, sda1, sda2, sda5 As New OleDbDataAdapter()
    Dim sdt, sdt1, sdt2, sdt5 As New DataTable()
    Private conn As New OleDbConnection
    Dim sql As String
    Dim bal As New MediumManager
    Dim md As New Medium
    Dim dt As New DataTable

    Sub DisplayGrid()
        md.Id = 0
        dt = bal.GetMediumRpt(md)
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ValidationMessage(1023)
            msginfo.Text = ValidationMessage(1014)
            GrdMedium.Visible = False
        Else
            GrdMedium.DataSource = dt
            GrdMedium.DataBind()
            GrdMedium.Enabled = True
            GrdMedium.Visible = True
            LinkButton.Focus()
            
        End If
    End Sub

    Protected Sub BtnSave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        TxtMediumName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If BtnSave.CommandName = "UPDATE" Then
                md.Name = TxtMediumName.Text
                md.Id = ViewState("MID")
                dt = bal.GetDuplicateMediumType(md)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1030)
                    msginfo.Text = ValidationMessage(1014)
                Else
                    bal.UpdateRecord(md)
                    BtnSave.CommandName = "ADD"
                    BtnDetails.CommandName = "VIEW"
                    msginfo.Text = ValidationMessage(1017)
                    TxtMediumName.ReadOnly = False
                    GrdMedium.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    lblmsg.Text = ValidationMessage(1014)
                    clear()
                End If
            ElseIf BtnSave.CommandName = "ADD" Then
                md.Name = TxtMediumName.Text
                dt = bal.GetDuplicateMediumType(md)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1030)
                    DisplayGrid()
                    msginfo.Text = ValidationMessage(1014)
                    clear()
                Else
                    bal.InsertRecord(TxtMediumName.Text)
                    BtnSave.CommandName = "ADD"
                    msginfo.Text = ValidationMessage(1020)
                    TxtMediumName.ReadOnly = False
                    ViewState("PageIndex") = 0
                    GrdMedium.PageIndex = 0
                    DisplayGrid()
                    lblmsg.Text = ValidationMessage(1014)
                    clear()
                End If
            End If
        Else
            lblmsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub GrdMedium_PageIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdMedium.PageIndexChanging
        GrdMedium.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdMedium.PageIndex
        DisplayGrid()
    End Sub
  
    Protected Sub GrdMedium_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdMedium.RowDeleting
        
        If (Session("BranchCode") = Session("ParentBranch")) Then

            md.Id = CType(GrdMedium.Rows(e.RowIndex).Cells(1).FindControl("txtMedium_Id"), Label).Text
            bal.ChangeFlag(md)
            
            msginfo.Text = ValidationMessage(1028)
            TxtMediumName.Focus()
            lblmsg.Text = ValidationMessage(1014)
            GrdMedium.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        Else
            lblmsg.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub GrdMedium_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdMedium.RowEditing
        
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        TxtMediumName.Text = CType(GrdMedium.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        ViewState("MID") = CType(GrdMedium.Rows(e.NewEditIndex).FindControl("txtMedium_Id"), Label).Text
        BtnSave.Text = "UPDATE"
        BtnDetails.Text = "BACK"
        md.Id = ViewState("MID")
        dt = bal.GetMediumRpt(md)
        GrdMedium.DataSource = dt
        GrdMedium.DataBind()
        GrdMedium.Enabled = False
        
    End Sub
   
    Sub clear()
        TxtMediumName.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        If BtnDetails.CommandName <> "BACK" Then
            GrdMedium.Visible = True
            ViewState("PageIndex") = 0
            GrdMedium.PageIndex = 0
            clear()
            msginfo.Text = ValidationMessage(1014)
            DisplayGrid()
            GrdMedium.Enabled = True
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
        Else
            GrdMedium.Visible = True
            GrdMedium.PageIndex = ViewState("PageIndex")
            lblmsg.Text = ValidationMessage(1014)

            clear()
            BtnSave.CommandName = "ADD"
            BtnDetails.CommandName = "VIEW"
            GrdMedium.Enabled = True
            DisplayGrid()
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtMediumName.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
       
    End Sub

    Protected Sub GrdMedium_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GrdMedium.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        md.Id = 0
        dt = bal.GetMediumRpt(md)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GrdMedium.DataSource = sortedView
        GrdMedium.DataBind()
        GrdMedium.Enabled = True
        GrdMedium.Visible = True
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
