
Partial Class FrmSourceOfInfo
    Inherits BasePage
    Dim BL As New BLSourceOfInfo
    Dim EL As New ELSourceOfInfo

    Dim dt As New DataTable
    Sub DisplayGrid()
        EL.id = 0
        dt = BL.GetData(EL)
        If dt.Rows.Count > 0 Then
            Grdsourceofinfo.DataSource = dt
            Grdsourceofinfo.DataBind()
            Grdsourceofinfo.Visible = True
            Grdsourceofinfo.Enabled = True
          
        Else
            lblmsg.Text = ValidationMessage(1023)
            msginfo.Text = ValidationMessage(1014)
           
        End If

    End Sub
    'description of view event click
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        LinkButton1.Focus()
        If btnDetails.CommandName <> "BACK" Then
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            Grdsourceofinfo.PageIndex = 0
            DisplayGrid()
            btnDetails.Text = "VIEW"
            btnSave.Text = "ADD"

        Else
            btnDetails.Text = "VIEW"
            btnSave.Text = "ADD"
            Grdsourceofinfo.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            clear()
        End If
    End Sub
    'description of delete event click
    Protected Sub Grdsourceofinfo_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grdsourceofinfo.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(Grdsourceofinfo.Rows(e.RowIndex).Cells(1).FindControl("lblsimid"), Label).Text
            BL.ChangeFlag(EL)
            Grdsourceofinfo.DataBind()
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1028)
            Grdsourceofinfo.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            clear()
        Else
            lblmsg.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If

    End Sub
    'description of edit event click
    Protected Sub Grdsourceofinfo_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grdsourceofinfo.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        txtsorceofinfo.Text = CType(Grdsourceofinfo.Rows(e.NewEditIndex).FindControl("lblsorcofinfo"), Label).Text
        ViewState("SIMID") = CType(Grdsourceofinfo.Rows(e.NewEditIndex).FindControl("lblsimid"), Label).Text
        btnSave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        Dim dt As New DataTable
        EL.id = ViewState("SIMID")
        dt = BL.GetData(EL)
        Grdsourceofinfo.DataSource = dt
        Grdsourceofinfo.DataBind()
        Grdsourceofinfo.Enabled = False
       
        'Else
        'lblmsg.Text = "You do not belong to this branch, Cannot edit data."
        'msginfo.Text = ""
        'End If

    End Sub
    'description of add event as well as update event click
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtsorceofinfo.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            If btnSave.CommandName = "UPDATE" Then
                EL.SourceOfInfo = txtsorceofinfo.Text
                EL.id = ViewState("SIMID")
                dt = BL.GetDuplicatedata(EL)
                If dt.Rows.Count > 0 Then

                    'If lblmsg.Visible = False Then
                    lblmsg.Text = ValidationMessage(1014)
                    'End If
                    lblmsg.Text = ValidationMessage(1030)

                Else

                    BL.UpdateRecord(EL)
                    btnSave.CommandName = "ADD"
                    btnDetails.CommandName = "VIEW"
                    clear()
                    'If lblmsg.Visible = True Then
                    lblmsg.Text = ValidationMessage(1014)
                    'End If
                    msginfo.Text = ValidationMessage(1017)
                    Grdsourceofinfo.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                End If
            ElseIf btnSave.CommandName = "ADD" Then
                EL.SourceOfInfo = txtsorceofinfo.Text
                EL.id = 0
                dt = BL.GetDuplicatedata(EL)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1030)
                    DisplayGrid()

                Else
                    BL.InsertRecord(EL)
                    btnSave.CommandName = "ADD"
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1020)
                    ViewState("PageIndex") = 0
                    Grdsourceofinfo.PageIndex = 0
                    DisplayGrid()
                    clear()

                End If

            End If

        Else
            lblmsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If


    End Sub
    'for clearing text in textbox
    Sub clear()

        txtsorceofinfo.Text = ""

    End Sub

    'for page indexing one page to another
    Protected Sub Grdsourceofinfo_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Grdsourceofinfo.PageIndexChanging
        Grdsourceofinfo.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = Grdsourceofinfo.PageIndex
        DisplayGrid()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        If Not IsPostBack Then
           
        End If
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        txtsorceofinfo.Focus()
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
    End Sub

    Protected Sub Grdsourceofinfo_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles Grdsourceofinfo.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.id = 0
        dt = BL.GetData(EL)

        Grdsourceofinfo.DataSource = dt
      
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        Grdsourceofinfo.DataSource = sortedView
        Grdsourceofinfo.DataBind()
        Grdsourceofinfo.Visible = True
        Grdsourceofinfo.Enabled = True
       
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
