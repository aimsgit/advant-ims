Partial Class frmDepreciation_Rates
    Inherits BasePage
    Dim Depreciation_Rates As New Depreciation_Rates
    Dim DepreiciationRate As New DepreiciationRate
    Dim dt As New DataTable
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        TxtDepreciationType.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            If BtnSave.CommandName = "UPDATE" Then
                DepreiciationRate.Depreciation_ID = txtDepreciation_ID.Text
                DepreiciationRate.CommodityName = TxtDepreciationType.Text
                DepreiciationRate.CommodityRate = txtCommodityRate.Text
                DepreiciationRate.Comodity_CompanyRates = txtComodity_CompanyRates.Text
                dt = Depreciation_Rates.CheckDuplicate(DepreiciationRate)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                    'clear()
                Else
                    Depreciation_Rates.UpdateRecord(DepreiciationRate)
                    BtnSave.CommandName = "ADD"
                    BtnSave.Text = "ADD"
                    BtnDetails.CommandName = "VIEW"
                    BtnDetails.Text = "VIEW"
                    clear()
                    GridView1.DataBind()
                    Enable()
                    msginfo.Text = ValidationMessage(1014)
                    GridView1.Visible = True
                    DepreiciationRate.Depreciation_ID = 0
                    GridView1.PageIndex = ViewState("PageIndex")
                    dispgrid()
                    lblmsg.Text = ValidationMessage(1017)
                End If
            ElseIf BtnSave.CommandName = "ADD" Then
                DepreiciationRate.CommodityName = TxtDepreciationType.Text
                DepreiciationRate.CommodityRate = txtCommodityRate.Text
                DepreiciationRate.Comodity_CompanyRates = txtComodity_CompanyRates.Text
                dt = Depreciation_Rates.CheckDuplicate(DepreiciationRate)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                    'clear()
                Else
                    Depreciation_Rates.InsertRecord(DepreiciationRate)
                    BtnSave.CommandName = "ADD"
                    GridView1.DataBind()
                    GridView1.Visible = True
                    msginfo.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    dispgrid()
                    lblmsg.Text = ValidationMessage(1020)
                    clear()
                End If
            End If
        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()
        ' GridView1.DataSourceID = "ObjectDataSource1"
        If BtnDetails.CommandName = "VIEW" Then
            DepreiciationRate.Depreciation_ID = 0
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            dispgrid()
            GridView1.Visible = True
            GridView1.Enabled = True
            

        Else
            DepreiciationRate.Depreciation_ID = 0
            GridView1.PageIndex = ViewState("PageIndex")
            dispgrid()
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            BtnDetails.CommandName = "VIEW"
            BtnDetails.Text = "VIEW"
            BtnSave.CommandName = "ADD"
            BtnSave.Text = "ADD"
            clear()
            GridView1.Visible = True
            GridView1.Enabled = True
            
        End If
    End Sub
    Sub dispgrid()
        Dim Depreciation_Rates As New Depreciation_Rates
        Dim dt As New DataTable
        dt = Depreciation_Rates.GetDepreciation_Rates(DepreiciationRate).Tables(0)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            

        Else

            msginfo.Text = ValidationMessage(1023)
            

        End If

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Dim Depreciation_Rates As New Depreciation_Rates
        Dim dt As New DataTable
        dt = Depreciation_Rates.GetDepreciation_Rates(DepreiciationRate).Tables(0)
        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim Depreciation_Rates As New Depreciation_Rates
            Depreciation_Rates.ChangeFlag(CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text)
            GridView1.DataBind()
            Enable()

            msginfo.Text = ValidationMessage(1014)
            GridView1.PageIndex = ViewState("PageIndex")
            dispgrid()
            lblmsg.Text = ValidationMessage(1028)
            TxtDepreciationType.Focus()
            msginfo.Text = ValidationMessage(1014)
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
        
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        txtDepreciation_ID.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        TxtDepreciationType.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtCommodityRate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtComodity_CompanyRates.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        DepreiciationRate.Depreciation_ID = txtDepreciation_ID.Text
        BtnSave.CommandName = "UPDATE"
        BtnSave.Text = "UPDATE"
        BtnSave.Visible = True
        e.Cancel = True
        BtnDetails.CommandName = "BACK"
        BtnDetails.Text = "BACK"
        BtnDetails.Visible = True
        BtnDetails.Enabled = True
        GridView1.DataBind()
        GridView1.Enabled = False
       
        dispgrid()
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

        'Disable()
    End Sub
    Sub Enable()
        GridView1.Enabled = True
        BtnDetails.Visible = True
        'BtnReport.Visible = True
    End Sub
    Sub Disable()
        GridView1.Enabled = False
        BtnDetails.Visible = False
        'BtnReport.Visible = False
    End Sub
    Sub clear()
        TxtDepreciationType.Text = ""
        txtDepreciation_ID.Text = ""
        txtCommodityRate.Text = ""
        txtComodity_CompanyRates.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblmsg.Text = ValidationMessage(1014)
        TxtDepreciationType.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            
        End If
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
        Dim Depreciation_Rates As New Depreciation_Rates
        Dim dt As New DataTable
        dt = Depreciation_Rates.GetDepreciation_Rates(DepreiciationRate).Tables(0)
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
    'Code written fro multilingual by Niraj on 30 aug 2013
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
