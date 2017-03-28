
Partial Class frmAcademicYear
    Inherits BasePage
    Dim EL As New AcademicYear
    Dim BL As New AcademicYearB
    Dim dt, dt1 As DataTable
    Dim dispId As String
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtAcdYear.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If btnSave.CommandName = "UPDATE" Then

                    If CType(txtStartDate.Text, Date) > CType(txtEndDate.Text, Date) Then
                        lblmsgifo.Text = ValidationMessage(1014)
                        lblerrmsg.Text = ValidationMessage(1037)
                        Exit Sub
                    End If
                    EL.AcdYear = txtAcdYear.Text
                    EL.id = ViewState("id")
                    EL.Startdate = txtStartDate.Text
                    EL.Enddate = txtEndDate.Text

                    dt = BL.GetDuplicateYear(EL.AcdYear, EL.id)
                    If dt.Rows.Count > 0 Then
                        'DisplayGrid()
                        lblmsgifo.Text = ValidationMessage(1014)
                        lblerrmsg.Text = ValidationMessage(1030)
                    Else
                        dt1 = BL.GetDuplicateCurrentYear(EL.id)
                        For row As Integer = 0 To dt1.Rows.Count - 1
                            If dt1.Rows(row).Item("CurrentYear") = "Y" Then
                                If ddlcurr_Year.SelectedValue = "Y" Then
                                    lblerrmsg.Text = ValidationMessage(1038)
                                    lblmsgifo.Text = ValidationMessage(1014)
                                    Exit Sub
                                Else
                                    EL.curryear = ddlcurr_Year.SelectedItem.Value
                                End If
                            Else
                                EL.curryear = ddlcurr_Year.SelectedItem.Value
                            End If
                        Next
                        BL.UpdateRecord(EL)
                        btnSave.CommandName = "ADD"
                        btnDetails.CommandName = "VIEW"
                        Clear()
                        GrdAcdYear.PageIndex = ViewState("PageIndex")
                        DisplayGrid()
                        'txtStartDate.Text = ValidationMessage(1014)
                        lblerrmsg.Text = ValidationMessage(1014)
                        lblmsgifo.Text = ValidationMessage(1017)
                    End If
                ElseIf btnSave.CommandName = "ADD" Then
                    If CType(txtStartDate.Text, Date) > CType(txtEndDate.Text, Date) Then
                        lblmsgifo.Text = ValidationMessage(1014)
                        lblerrmsg.Text = ValidationMessage(1037)
                        Exit Sub
                    End If
                    EL.AcdYear = txtAcdYear.Text

                    dt = BL.GetDuplicateYear(EL.AcdYear, EL.id)


                    If dt.Rows.Count > 0 Then
                        DisplayGrid()
                        lblmsgifo.Text = ValidationMessage(1014)
                        lblerrmsg.Text = ValidationMessage(1030)
                    Else
                        EL.AcdYear = txtAcdYear.Text
                        EL.Startdate = txtStartDate.Text
                        EL.Enddate = txtEndDate.Text
                        EL.id = 0
                        dt1 = BL.GetDuplicateCurrentYear(EL.id)
                        If dt1.Rows.Count > 0 Then
                            For row As Integer = 0 To dt1.Rows.Count - 1
                                If dt1.Rows(row).Item("CurrentYear") = "Y" Then
                                    If ddlcurr_Year.SelectedValue = "Y" Then
                                        lblerrmsg.Text = ValidationMessage(1038)
                                        lblmsgifo.Text = ValidationMessage(1014)
                                        Exit Sub
                                    Else
                                        EL.curryear = ddlcurr_Year.SelectedItem.Value
                                    End If
                                Else
                                    EL.curryear = ddlcurr_Year.SelectedItem.Value
                                End If
                            Next
                        Else
                            EL.curryear = ddlcurr_Year.SelectedItem.Value
                        End If
                        Dim i As New Integer
                        i = BL.InsertRecord(EL)
                        ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")
                        lblerrmsg.Text = ValidationMessage(1014)
                        ViewState("PageIndex") = 0
                        GrdAcdYear.PageIndex = 0
                        dt = AcademicYearDB.GetGridDataById(ViewState("dispId "))
                        'dt = BAL.GetEnquiry(enq)
                        GrdAcdYear.Visible = True
                        GrdAcdYear.DataSource = dt
                        GrdAcdYear.DataBind()
                        Clear()
                        lblerrmsg.Text = ValidationMessage(1014)
                        lblmsgifo.Text = ValidationMessage(1020)
                    End If
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
            GrdAcdYear.DataSource = Nothing
            GrdAcdYear.DataBind()
            lblmsgifo.Text = ValidationMessage(1014)
            lblerrmsg.Text = ValidationMessage(1023)
            
        Else
            GrdAcdYear.DataSource = dt
            GrdAcdYear.DataBind()
            
            GrdAcdYear.Enabled = True
            GrdAcdYear.Visible = True
            LinkButton.Focus()
        End If
        
    End Sub
    Sub Clear()
        txtAcdYear.Text = ""
        txtStartDate.Text = Format(Today, "dd-MMM-yyyy")
        txtEndDate.Text = Format(Today, "dd-MMM-yyyy")
        ddlcurr_Year.ClearSelection()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        txtAcdYear.Focus()
        lblerrmsg.Text = ValidationMessage(1014)
        lblmsgifo.Text = ValidationMessage(1014)

        If btnDetails.CommandName <> "BACK" Then
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            ViewState("PageIndex") = 0
            GrdAcdYear.PageIndex = 0
            DisplayGrid()
            GrdAcdYear.Visible = True

        ElseIf btnDetails.CommandName = "VIEW" Then
            btnDetails.CommandName = "VIEW"
            btnDetails.Text = "VIEW"
            btnSave.CommandName = "ADD"
            btnSave.Text = "ADD"
            GrdAcdYear.PageIndex = ViewState("PageIndex")
            DisplayGrid()


            'If btnDetails.CommandName <> "BACK" Then
            '    ViewState("PageIndex") = 0
            '    GrdAcdYear.PageIndex = 0
            '    DisplayGrid()
            '    GrdAcdYear.Visible = True
            'End If

            'Clear()
            'btnDetails.CommandName = "VIEW"
            'btnDetails.Text = "VIEW"
            'btnSave.CommandName = "ADD"
            'btnSave.Text = "ADD"
            'GrdAcdYear.PageIndex = ViewState("PageIndex")
            'DisplayGrid()

        End If
        
    End Sub
    Protected Sub GrdAcdYear_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdAcdYear.RowDeleting

        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GrdAcdYear.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text
            If BL.ChangeFlag(EL) Then
                lblerrmsg.Text = ValidationMessage(1014)
                lblmsgifo.Text = ValidationMessage(1028)
                txtAcdYear.Focus()
                GrdAcdYear.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                GrdAcdYear.Enabled = True
            End If
        Else
            lblerrmsg.Text = ValidationMessage(1029)
            lblmsgifo.Text = ValidationMessage(1014)
        End If
        
    End Sub
    Protected Sub GrdAcdYear_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdAcdYear.PageIndexChanging
        GrdAcdYear.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdAcdYear.PageIndex
        DisplayGrid()
    End Sub
    Protected Sub GrdAcdYear_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdAcdYear.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblerrmsg.Text = ValidationMessage(1014)
        lblmsgifo.Text = ValidationMessage(1014)
        txtAcdYear.Text = CType(GrdAcdYear.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        ViewState("id") = CType(GrdAcdYear.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        txtStartDate.Text = CType(GrdAcdYear.Rows(e.NewEditIndex).FindControl("lblstartDate"), Label).Text
        txtEndDate.Text = CType(GrdAcdYear.Rows(e.NewEditIndex).FindControl("lblEnddate"), Label).Text
        ddlcurr_Year.SelectedValue = CType(GrdAcdYear.Rows(e.NewEditIndex).FindControl("lblCurrYear"), Label).Text

        btnSave.CommandName = "UPDATE"
        btnSave.Text = "UPDATE"
        btnDetails.CommandName = "BACK"
        btnDetails.Text = "BACK"
        EL.id = ViewState("id")
        dt = BL.GetGridData(EL.id)
        GrdAcdYear.DataSource = dt
        GrdAcdYear.DataBind()
        GrdAcdYear.Enabled = False
        'Else
        'lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsgifo.Text = ""
        'End If
        
    End Sub

    'Sub Disable()
    '    GrdAcdYear.Enabled = False
    '    btnDetails.Visible = False
    'End Sub
    'Sub Enable()
    '    GrdAcdYear.Enabled = True
    '    btnDetails.Visible = True
    'End Sub


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String

        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading

        If Not Page.IsPostBack Then
            txtStartDate.Text = Format(Today, "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today, "dd-MMM-yyyy")
            txtAcdYear.Focus()
           
        End If
    End Sub

    Protected Sub ddlcurr_Year_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcurr_Year.TextChanged
        ddlcurr_Year.Focus()
        lblerrmsg.Text = ValidationMessage(1014)
    End Sub

    Protected Sub GrdAcdYear_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GrdAcdYear.Sorting
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
        GrdAcdYear.DataSource = sortedView
        GrdAcdYear.DataBind()
        GrdAcdYear.Enabled = True
        GrdAcdYear.Visible = True
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
