
Partial Class PerformanceCycle
    Inherits BasePage
    Dim EL As New PerformanceCycleEL
    Dim BL As New PerformanceCycleBL
    Dim dt, dt1 As DataTable
    Dim dispId As String

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        lblmsgifo.Text = ValidationMessage(1014)
        txtPerfCycle.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If btnAdd.CommandName = "UPDATE" Then

                    If CType(txtStartDate.Text, Date) > CType(txtEndDate.Text, Date) Then
                        lblmsgifo.Text = ValidationMessage(1014)
                        lblerrmsg.Text = ValidationMessage(1037)
                        Exit Sub
                    End If
                    EL.PerfCycle = txtPerfCycle.Text
                    EL.id = ViewState("id")
                    EL.Startdate = txtStartDate.Text
                    EL.Enddate = txtEndDate.Text
                    EL.CurrentAppraisal = ddlcurrAppraisal.SelectedValue


                    dt1 = BL.GetDuplicateCurrentYear(EL.id)
                    If dt1.Rows.Count > 0 Then
                        For row As Integer = 0 To dt1.Rows.Count - 1
                            If dt1.Rows(row).Item("CurrentAppraisal") = "Y" Then
                                If ddlcurrAppraisal.SelectedValue = "Y" Then
                                    lblerrmsg.Text = ValidationMessage(1038)
                                    lblmsgifo.Text = ValidationMessage(1014)
                                    Exit Sub
                                Else
                                    EL.CurrentAppraisal = ddlcurrAppraisal.SelectedItem.Value
                                End If
                            Else
                                EL.CurrentAppraisal = ddlcurrAppraisal.SelectedItem.Value
                            End If
                        Next
                    Else
                        EL.CurrentAppraisal = ddlcurrAppraisal.SelectedValue
                    End If

                    'dt = BL.GetYear(EL.PerfCycle, EL.id)
                    'If dt.Rows.Count > 0 Then
                    '    'DisplayGrid()
                    '    lblmsgifo.Text = ValidationMessage(1014)
                    '    lblerrmsg.Text = ValidationMessage(1030)
                    'Else
                    '    dt1 = BL.GetDuplicateCurrentYear(EL.id)
                    BL.UpdateRecord(EL)
                    btnAdd.CommandName = "ADD"
                    btnView.CommandName = "VIEW"
                    btnAdd.Text = "ADD"
                    btnView.Text = "VIEW"
                    Clear()
                    GrdPerfCycle.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    txtStartDate.Text = ""
                    lblerrmsg.Text = ValidationMessage(1014)
                    lblmsgifo.Text = ValidationMessage(1017)
                    'End If
                ElseIf btnAdd.CommandName = "ADD" Then
                If CType(txtStartDate.Text, Date) > CType(txtEndDate.Text, Date) Then
                    lblmsgifo.Text = ValidationMessage(1014)
                    lblerrmsg.Text = ValidationMessage(1037)
                    Exit Sub
                End If
                EL.PerfCycle = txtPerfCycle.Text

                    'dt = BL.GetDuplicateYear(EL.PerfCycle, EL.id)


                    'If dt.Rows.Count > 0 Then
                    '    DisplayGrid()
                    '    lblmsgifo.Text = ValidationMessage(1014)
                    '    lblerrmsg.Text = ValidationMessage(1030)
                    'Else
                    EL.PerfCycle = txtPerfCycle.Text
                    EL.Startdate = txtStartDate.Text
                    EL.Enddate = txtEndDate.Text

                   

                    EL.id = 0

                    dt1 = BL.GetDuplicateCurrentYear(EL.id)
                    If dt1.Rows.Count > 0 Then
                        For row As Integer = 0 To dt1.Rows.Count - 1
                            If dt1.Rows(row).Item("CurrentAppraisal") = "Y" Then
                                If ddlcurrAppraisal.SelectedValue = "Y" Then
                                    lblerrmsg.Text = ValidationMessage(1038)
                                    lblmsgifo.Text = ValidationMessage(1014)
                                    Exit Sub
                                Else
                                    EL.CurrentAppraisal = ddlcurrAppraisal.SelectedItem.Value
                                End If
                            Else
                                EL.CurrentAppraisal = ddlcurrAppraisal.SelectedItem.Value
                            End If
                        Next
                    Else
                        EL.CurrentAppraisal = ddlcurrAppraisal.SelectedValue
                    End If
                    Dim i As New Integer
                    i = BL.InsertRecord(EL)
                    ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")
                    lblerrmsg.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GrdPerfCycle.PageIndex = 0
                    ''dt = AcademicYearDB.GetGridDataById(ViewState("dispId "))
                    ''dt = BAL.GetEnquiry(enq)
                    'GrdPerfCycle.Visible = True
                    'GrdPerfCycle.DataSource = dt
                    'GrdPerfCycle.DataBind()
                    DisplayGrid()
                    Clear()
                    lblerrmsg.Text = ValidationMessage(1014)
                    lblmsgifo.Text = ValidationMessage(1020)
                    'End If
                End If
            Catch e1 As Exception
                lblerrmsg.Text = ValidationMessage(1022)
                lblmsgifo.Text = ValidationMessage(1014)
            End Try
        Else
            lblerrmsg.Text = ValidationMessage(1021)
            lblmsgifo.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub DisplayGrid()
        EL.id = 0
        dt = BL.GetGridData(EL.id)
        If dt.Rows.Count = 0 Then
            GrdPerfCycle.DataSource = Nothing
            GrdPerfCycle.DataBind()
            lblmsgifo.Text = ValidationMessage(1014)
            lblerrmsg.Text = ValidationMessage(1023)
           
        Else
            GrdPerfCycle.DataSource = dt
            GrdPerfCycle.DataBind()
            
            GrdPerfCycle.Enabled = True
            GrdPerfCycle.Visible = True
            LinkButton.Focus()
        End If
       
    End Sub
    Sub Clear()
        txtPerfCycle.Text = ""
        'txtStartDate.Text = ""
        'txtEndDate.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub GrdPerfCycle_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GrdPerfCycle.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.id = 0
        dt = BL.GetGridData(EL.id)
        'GrdAcdYear.DataSource = dt

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GrdPerfCycle.DataSource = sortedView
        GrdPerfCycle.DataBind()
        GrdPerfCycle.Enabled = True
        GrdPerfCycle.Visible = True
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
    'Code written fro multilingual by Niraj on 12 aug 2013
    ''Retriving the text of controls based on Language

    'Sub Multilingual()
    '    Dim j As Integer
    '    Dim k As Integer
    '    Dim dtl As DataTable
    '    'Dim FormName As String = Session("Code")
    '    'Dim LanguageID As Integer
    '    'If Session("LanguageID") = "" Then
    '    '    LanguageID = 0
    '    'Else
    '    '    LanguageID = Session("LanguageID")
    '    'End If
    '    'If LanguageID <> 0 Then
    '    'dtl = GlobalFunction.GetChangeLanguage(FormName, LanguageID)
    '    dtl = Session("Control_Text")
    '    Dim i As Integer = dtl.Rows.Count
    '    While (i <> 0)
    '        If dtl.Rows(i - 1).Item("ControlType") = "Label" Then
    '            Dim myLabel As Label = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Label)
    '            myLabel.Text = dtl.Rows(i - 1).Item("Default_Text")
    '            i = i - 1
    '        ElseIf dtl.Rows(i - 1).Item("ControlType") = "Button" Then
    '            If dtl.Rows(i - 1).Item("ControlCommandName") = btnAdd.CommandName Then
    '                Dim myButton As Button = CType(Me.Updatepanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
    '                myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
    '                i = i - 1
    '            ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = btnView.CommandName Then
    '                Dim myButton As Button = CType(Me.Updatepanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
    '                myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
    '                i = i - 1
    '            Else
    '                i = i - 1
    '            End If

    '        ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridLabel" Then
    '            j = GrdPerfCycle.Columns.Count
    '            While (j <> 0)
    '                If GrdPerfCycle.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("ControlCommandName") Then
    '                    GrdPerfCycle.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("Default_Text")
    '                End If
    '                j = j - 1
    '            End While
    '            i = i - 1
    '        ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridButton" Then
    '            k = GrdPerfCycle.Rows.Count
    '            If dtl.Rows(i - 1).Item("ControlCommandName") = "Acknowledge" Then
    '                While (k <> 0)
    '                    Dim lnkCanc As LinkButton = CType(GrdPerfCycle.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
    '                    lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
    '                    k = k - 1
    '                End While
    '            ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Edit" Then
    '                k = GrdPerfCycle.Rows.Count
    '                While (k <> 0)
    '                    Dim lnkCanc As LinkButton = CType(GrdPerfCycle.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
    '                    lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
    '                    k = k - 1
    '                End While
    '            ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Delete" Then
    '                k = GrdPerfCycle.Rows.Count
    '                While (k <> 0)
    '                    Dim lnkCanc As LinkButton = CType(GrdPerfCycle.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
    '                    lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
    '                    k = k - 1
    '                End While
    '            End If
    '            i = i - 1
    '        ElseIf dtl.Rows(i - 1).Item("ControlType") = "CheckBox" Then
    '            Dim myCheckbox As CheckBox = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), CheckBox)
    '            myCheckbox.Text = dtl.Rows(i - 1).Item("Default_Text")
    '            i = i - 1
    '        ElseIf dtl.Rows(i - 1).Item("ControlType") = "RadioButtonList" Then
    '            Dim myRadiobutton As RadioButtonList = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), RadioButtonList)
    '            Dim a As Integer = myRadiobutton.Items.Count
    '            While (a <> 0)
    '                For Each li As ListItem In myRadiobutton.Items
    '                    If li.Value = dtl.Rows(i - 1).Item("ControlCommandName") Then
    '                        li.Text = dtl.Rows(i - 1).Item("Default_Text")
    '                    End If
    '                Next
    '                a = a - 1
    '            End While
    '            i = i - 1
    '        End If
    '    End While
    '    'End If
    'End Sub
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        lblerrmsg.Text = ValidationMessage(1014)
        lblmsgifo.Text = ValidationMessage(1014)
        If btnView.CommandName <> "BACK" Then
            ViewState("PageIndex") = 0
            GrdPerfCycle.PageIndex = 0
            DisplayGrid()
            GrdPerfCycle.Visible = True
        Else
            Clear()
            btnView.CommandName = "VIEW"
            btnAdd.CommandName = "ADD"
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            GrdPerfCycle.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
      
    End Sub
    Protected Sub GrdPerfCycle_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdPerfCycle.RowDeleting

        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GrdPerfCycle.Rows(e.RowIndex).Cells(1).FindControl("lblID"), Label).Text
            If BL.ChangeFlag(EL) Then
                lblerrmsg.Text = ValidationMessage(1014)
                lblmsgifo.Text = ValidationMessage(1028)
                GrdPerfCycle.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                GrdPerfCycle.Enabled = True
            End If
        Else
            lblerrmsg.Text = ValidationMessage(1029)
            lblmsgifo.Text = ValidationMessage(1014)
        End If
       
    End Sub
    Protected Sub GrdPerfCycle_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdPerfCycle.PageIndexChanging
        GrdPerfCycle.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdPerfCycle.PageIndex
        DisplayGrid()
    End Sub
    Protected Sub GrdPerfCycle_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdPerfCycle.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim x As String
        lblerrmsg.Text = ValidationMessage(1014)
        lblmsgifo.Text = ValidationMessage(1014)
        txtPerfCycle.Text = CType(GrdPerfCycle.Rows(e.NewEditIndex).FindControl("lblPerfCycle"), Label).Text
        ViewState("id") = CType(GrdPerfCycle.Rows(e.NewEditIndex).FindControl("lblID"), Label).Text
        txtStartDate.Text = CType(GrdPerfCycle.Rows(e.NewEditIndex).FindControl("lblStartDate"), Label).Text
        txtEndDate.Text = CType(GrdPerfCycle.Rows(e.NewEditIndex).FindControl("lblEndDate"), Label).Text
        'ddlcurrAppraisal.Items.Clear()
        'ddlcurrAppraisal.DataBind()
        x = CType(GrdPerfCycle.Rows(e.NewEditIndex).FindControl("lblCurrentApp"), Label).Text
        ddlcurrAppraisal.SelectedValue = CType(GrdPerfCycle.Rows(e.NewEditIndex).FindControl("lblCurrentApp"), Label).Text
        btnAdd.CommandName = "UPDATE"
        btnView.CommandName = "BACK"
        btnAdd.Text = "UPDATE"
        btnView.Text = "BACK"
        EL.id = ViewState("id")
        dt = BL.GetGridData(EL.id)
        GrdPerfCycle.DataSource = dt
        GrdPerfCycle.DataBind()
        GrdPerfCycle.Enabled = False
        'Else
        'lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsgifo.Text = ""
        'End If
       
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            txtStartDate.Text = Format(Today, "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today, "dd-MMM-yyyy")
            
        End If
    End Sub
End Class
