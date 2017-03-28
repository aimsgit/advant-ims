
Partial Class frmSalaryScaleGradeMaster
    Inherits BasePage
    
    Dim BL As New BLSalaryScaleGrade
    Dim DT As New DataTable
    Dim DL As New DLSalaryScaleGrade
    Dim EL As New ELSalaryScaleGrade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        ''If Not IsPostBack Then
        ''    Control_Text_Multilingual()
        ''End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Code written by siddharth
        'If Session("Privilages").ToString.Contains("W") Then


        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.SalaryBand = txtsalary.Text
                EL.Grade = txtGrade.Text
                EL.MinScale = txtMinScale.Text
                EL.EmpType = txtemptype.Text
                EL.Inc1 = txtInc1.Text
                EL.Inc2 = txtInc2.Text
                EL.Inc3 = txtInc3.Text
                If txtstep1.Text = "" Then
                    EL.Step1 = 0
                Else
                    EL.Step1 = txtstep1.Text
                End If
                If txtstep2.Text = "" Then
                    EL.Step2 = 0
                Else
                    EL.Step2 = txtstep2.Text
                End If
                If txtstep3.Text = "" Then
                    EL.Step3 = 0
                Else
                    EL.Step3 = txtstep3.Text
                End If

                EL.MaxScale = txtMaxscale.Text
                If CDbl(txtMaxscale.Text) < CDbl(txtMinScale.Text) Then
                    lblerrmsg.Text = "MaxScale should be greater than MinScale."
                    lblmsgifo.Text = ValidationMessage(1014)
                    txtMaxscale.Focus()
                    Exit Sub

                End If
                EL.id = CInt(ViewState("id"))
                Dim dt As New DataTable
                dt = BL.CheckDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    'lblRed.Visible = True
                    lblerrmsg.Text = ValidationMessage(1030)
                    lblmsgifo.Text = ValidationMessage(1014)
                    disp(0)
                    Exit Sub
                End If
                If btnAdd.CommandName = "ADD" Then

                    BL.InsertSalaryScale(EL)
                    lblmsgifo.Text = ValidationMessage(1020)
                    lblerrmsg.Text = ValidationMessage(1014)
                    disp(0)
                    clear()
                Else
                    EL.id = CInt(ViewState("id"))
                    BL.UpdateSalaryScale(EL)
                    lblmsgifo.Text = ValidationMessage(1017)
                    lblerrmsg.Text = ValidationMessage(1014)
                    clear()
                    btnAdd.CommandName = "ADD"
                    btnView.CommandName = "VIEW"
                    btnAdd.Text = "ADD"
                    btnView.Visible = True
                    btnView.Text = "VIEW"

                    disp(0)


                End If

            Catch e1 As Exception
                lblerrmsg.Text = ValidationMessage(1022)
                lblmsgifo.Text = ValidationMessage(1014)
            End Try
        Else
            lblerrmsg.Text = ValidationMessage(1021)
            lblmsgifo.Text = ValidationMessage(1014)
        End If
        'Else
        'lblerrmsg.Text = "You don't have Write Privilages. "
        'End If
    End Sub
    Sub clear()
        txtGrade.Text = ""
        txtMinScale.Text = ""
        txtMaxscale.Text = ""
        txtInc1.Text = ""
        txtInc2.Text = ""
        txtInc3.Text = ""
        txtstep1.Text = ""
        txtstep2.Text = ""
        txtstep3.Text = ""
        txtemptype.Text = ""


    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        lblerrmsg.Text = ValidationMessage(1014)
        lblmsgifo.Text = ValidationMessage(1014)
        If btnView.CommandName <> "BACK" Then
            EL.id = 0
            'dt = BL.DisplayGridview(EL.id)
            disp(EL.id)
            GridView1.Visible = "true"

        Else
            clear()
            btnAdd.CommandName = "ADD"
            btnView.CommandName = "VIEW"

            btnAdd.Text = "ADD"
            btnView.Visible = True
            btnView.Text = "VIEW"
            disp(0)
        End If
    End Sub
    Sub disp(ByVal id As Integer)

        ' Display the data-- by Siddharth(25-4-2013)

        EL.id = 0
        DT = BL.DisplayGridview(id)
        If DT.Rows.Count > 0 Then
            GridView1.DataSource = DT
            GridView1.DataBind()
            
            GridView1.Visible = True
            GridView1.Enabled = True

        Else
            lblmsgifo.Text = ValidationMessage(1014)
            lblerrmsg.Text = ValidationMessage(1023)
            
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        lblerrmsg.Text = ValidationMessage(1014)
        lblmsgifo.Text = ValidationMessage(1014)
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        disp(0)
    End Sub


    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim rowsaffected As Integer
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = (CType(GridView1.Rows(e.RowIndex).FindControl("lblid"), Label).Text)
            rowsaffected = BL.DeleteSalryScale(EL)
            lblmsgifo.Text = ValidationMessage(1028)
            lblerrmsg.Text = ValidationMessage(1014)
            disp(0)
            DT = BL.DisplayGridview(EL.id)
            GridView1.DataSource = DT
            GridView1.DataBind()
            
        End If
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        btnAdd.CommandName = "UPDATE"
        btnView.Visible = True
        btnView.CommandName = "BACK"
        btnAdd.Text = "UPDATE"
        btnView.Visible = True
        btnView.Text = "BACK"
        lblmsgifo.Text = ValidationMessage(1014)
        lblerrmsg.Text = ValidationMessage(1014)
        txtGrade.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblGrade"), Label).Text
        txtemptype.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblemptype"), Label).Text
        txtMinScale.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblminscale"), Label).Text
        txtMaxscale.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblmaxscale"), Label).Text
        txtInc1.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblinc1"), Label).Text
        txtInc2.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblinc2"), Label).Text
        txtInc3.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblinc3"), Label).Text
        txtstep1.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblstp1"), Label).Text
        txtstep2.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblstp2"), Label).Text
        txtstep3.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblstp3"), Label).Text
        txtsalary.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblSalBand"), Label).Text
        ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text
        btnAdd.CommandName = "UPDATE"
        btnView.CommandName = "BACK"
        btnAdd.Text = "UPDATE"
        btnView.Visible = True
        btnView.Text = "BACK"
        EL.id = ViewState("id")
        DT = BL.DisplayGridview(EL.id)
        GridView1.DataSource = DT
        GridView1.DataBind()
       
        GridView1.Enabled = False
        lblmsgifo.Text = ValidationMessage(1014)
        lblerrmsg.Text = ValidationMessage(1014)
    End Sub
    
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
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If Dir() = SortDirection.Ascending Then
            Dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            Dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        dt = BL.DisplayGridview(EL.id)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
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

End Class

