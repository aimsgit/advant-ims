
Partial Class frmMaintenanceType
    Inherits BasePage
    Dim MaintenanceType As New MaintenanceType
    Dim MaintenanceTypeManager As New MaintenanceTypeManager
    Dim m As New MaintenanceType
    Dim a As Integer
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtType.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim m As New MaintenanceType
        Dim dt As New DataTable
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
        m.MaintenanceType = txtType.Text
        m.Remarks = txtRemarks.Text

            If btnAdd.CommandName = "UPDATE" Then
                m.Id = ViewState("id")
                dt = MaintenanceTypeManager.GetDuplicateMaintananceType(m)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1030)
                Else
                    MaintenanceTypeManager.UpdateRecord(m)
                    clear()
                    lblmsg.Text = ValidationMessage(1017)
                    txtType.ReadOnly = False
                    msginfo.Text = ValidationMessage(1014)
                    GridView1.PageIndex = ViewState("PageIndex")
                    DispGrid()
                    GridView1.Enabled = True
                    btnAdd.CommandName = "ADD"
                    btnview.CommandName = "VIEW"
                End If
            ElseIf btnAdd.CommandName = "ADD" Then
                dt = MaintenanceTypeManager.GetDuplicateMaintananceType(m)
                If dt.Rows.Count > 0 Then
                    clear()
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1030)
                    DispGrid()
                Else
                    MaintenanceTypeManager.InsertRecord(m)
                    btnAdd.CommandName = "ADD"
                    GridView1.DataBind()
                    GridView1.Visible = True
                    clear()
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1020)
                    txtType.ReadOnly = False
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DispGrid()
                End If
            End If
            Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
            End If

    End Sub
    Sub clear()
        txtType.Text = ""
        txtRemarks.Text = ""
        btnAdd.CommandName = "ADD"
        btnview.CommandName = "VIEW"
        
    End Sub
 
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        LinkButton1.Focus()
        If btnview.CommandName = "BACK" Then
            btnAdd.CommandName = "ADD"
            btnview.CommandName = "VIEW"
            GridView1.Enabled = True
            GridView1.PageIndex = ViewState("PageIndex")
            msginfo.Text = ValidationMessage(1014)
            DispGrid()
            clear()
            Exit Sub
        End If
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        GridView1.Visible = True
        ViewState("PageIndex") = 0
        GridView1.PageIndex = 0

        DispGrid()
        clear()
    End Sub
    Public Sub DispGrid()
        Dim dt As New DataTable

        dt = MaintenanceTypeDB.GetMaintenanceType(m)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            Multilingual()
        Else
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1023)
            GridView1.Visible = False

        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
        GridView1.DataBind()
        GridView1.Visible = True
        clear()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        If (Session("BranchCode") = Session("ParentBranch")) Then
        MaintenanceTypeDB.ChangeFlag(CType(GridView1.Rows(e.RowIndex).FindControl("MID"), HiddenField).Value)
            lblmsg.Text = ValidationMessage(1028)
            txtType.Focus()
            msginfo.Text = ValidationMessage(1014)
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim m As New MaintenanceType
        Dim dt As New DataTable
        btnAdd.CommandName = "UPDATE"
        btnview.CommandName = "BACK"
        lblmsg.Text = ValidationMessage(1014)
        ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("MID"), HiddenField).Value
        txtType.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Label1"), Label).Text.Trim
        txtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Label2"), Label).Text.Trim
        m.Id = ViewState("id")
        dt = MaintenanceTypeDB.GetMaintenanceType(m)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = False
        Multilingual()

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtType.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            Control_Text_Multilingual()
        End If
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
        Dim dt As New DataTable

        dt = MaintenanceTypeDB.GetMaintenanceType(m)
       
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        Multilingual()

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
    ''Code Written for Multilingual By Ajit Kumar Singh on 12th Aug
    ''Retriving the text of controls based on Language
    Sub Multilingual()
        Dim j As Integer
        Dim k As Integer
        Dim dtl As DataTable
        dtl = Session("Control_Text")
        Dim i As Integer = dtl.Rows.Count
        While (i <> 0)
            If dtl.Rows(i - 1).Item("ControlType") = "Label" Then
                Dim myLabel As Label = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Label)
                myLabel.Text = dtl.Rows(i - 1).Item("Default_Text")
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "Button" Then
                If dtl.Rows(i - 1).Item("ControlCommandName") = btnAdd.CommandName Then
                    Dim myButton As Button = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = btnview.CommandName Then
                    Dim myButton As Button = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                Else
                    i = i - 1
                End If

            ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridLabel" Then
                j = GridView1.Columns.Count
                While (j <> 0)
                    If GridView1.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("ControlCommandName") Then
                        GridView1.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("Default_Text")
                    End If
                    j = j - 1
                End While
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridButton" Then
                k = GridView1.Rows.Count
                If dtl.Rows(i - 1).Item("ControlCommandName") = "Acknowledge" Then
                    While (k <> 0)
                        Dim lnkCanc As LinkButton = CType(GridView1.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                        lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                        k = k - 1
                    End While
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Edit" Then
                    k = GridView1.Rows.Count
                    While (k <> 0)
                        Dim lnkCanc As LinkButton = CType(GridView1.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                        lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                        k = k - 1
                    End While
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Delete" Then
                    k = GridView1.Rows.Count
                    While (k <> 0)
                        Dim lnkCanc As LinkButton = CType(GridView1.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                        lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                        k = k - 1
                    End While
                End If
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "CheckBox" Then
                Dim myCheckbox As CheckBox = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), CheckBox)
                myCheckbox.Text = dtl.Rows(i - 1).Item("Default_Text")
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "RadioButtonList" Then
                Dim myRadiobutton As RadioButtonList = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), RadioButtonList)
                Dim a As Integer = myRadiobutton.Items.Count
                While (a <> 0)
                    For Each li As ListItem In myRadiobutton.Items
                        If li.Value = dtl.Rows(i - 1).Item("ControlCommandName") Then
                            li.Text = dtl.Rows(i - 1).Item("Default_Text")
                        End If
                    Next
                    a = a - 1
                End While
                i = i - 1
            End If
        End While
    End Sub
    Public Sub Control_Text_Multilingual()
        Dim dtll As DataTable
        Dim FormName As String = Session("Code")
        Dim LanguageID As Integer
        If Session("LanguageID") = "" Then
            LanguageID = 0
        Else
            LanguageID = Session("LanguageID")
        End If
        If LanguageID <> 0 Then
            dtll = GlobalFunction.GetChangeLanguage(FormName, LanguageID)
            Session("Control_Text") = dtll
            Multilingual()
        End If
    End Sub
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
