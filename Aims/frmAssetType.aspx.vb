Imports System.Data.OleDb
Partial Class frmAssetType
    Inherits BasePage
    Dim dt As New DataTable
    Dim el As New ELAssetType
    Dim bl As New BLAssetType
    Dim dl As New DLAssetType

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        txtboxAssetType.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            If btnadd.CommandName = "UPDATE" Then
                el.AssetType_Name = txtboxAssetType.Text
                el.AssetType_Code = TxtboxAssestTypeCode.Text
                el.AssetType_Desc = Txtboxdesc.Text
                el.AssetType_ID = ViewState("AssetType_ID")
                dt = bl.CheckDuplicate(el)
                If dt.Rows.Count > 0 Then
                    msginfo.Visible = True
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                Else
                    bl.UpdateRecord(el)
                    btnadd.CommandName = "ADD"
                    btnadd.Text = "ADD"
                    GVAssetType.Visible = True
                    btnview.CommandName = "VIEW"
                    btnview.Text = "VIEW"
                    clear()
                    lblmsg.Text = ValidationMessage(1017)
                    msginfo.Text = ValidationMessage(1014)
                    txtboxAssetType.Focus()
                    txtboxAssetType.ReadOnly = False
                    GVAssetType.PageIndex = ViewState("PageIndex")
                    DispGrid()
                End If
            ElseIf btnadd.CommandName = "ADD" Then
                el.AssetType_Name = txtboxAssetType.Text
                el.AssetType_Code = TxtboxAssestTypeCode.Text
                el.AssetType_Desc = Txtboxdesc.Text
                dt = bl.CheckDuplicate(el)
                If dt.Rows.Count > 0 Then
                    msginfo.Visible = True
                    'clear()
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                    DispGrid()
                Else
                    el.AssetType_Name = txtboxAssetType.Text
                    el.AssetType_Code = TxtboxAssestTypeCode.Text
                    el.AssetType_Desc = Txtboxdesc.Text
                    bl.InsertRecord(el)
                    btnadd.CommandName = "ADD"
                    'lblmsg.Visible = True
                    clear()
                    lblmsg.Text = ValidationMessage(1020)

                    txtboxAssetType.Focus()
                    txtboxAssetType.ReadOnly = False
                    TxtboxAssestTypeCode.ReadOnly = False

                    msginfo.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GVAssetType.PageIndex = 0
                    DispGrid()
                End If
            End If

        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If


    End Sub
    Sub clear()
        txtboxAssetType.Text = ValidationMessage(1014)
        TxtboxAssestTypeCode.Text = ValidationMessage(1014)
        Txtboxdesc.Text = ValidationMessage(1014)
        btnadd.CommandName = "ADD"
        btnview.CommandName = "VIEW"
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        LinkButton1.Focus()
        If btnview.CommandName = "VIEW" Then
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVAssetType.PageIndex = 0
            DispGrid()
            'clear()
        ElseIf btnview.CommandName = "BACK" Then
            btnadd.CommandName = "ADD"
            btnadd.Text = "ADD"
            btnview.CommandName = "VIEW"
            btnview.Text = "VIEW"
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            clear()
            GVAssetType.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        el.AssetType_ID = 0
        GVAssetType.Enabled = True
        dt = bl.GetAssetType(el)
        If dt.Rows.Count > 0 Then
            GVAssetType.DataSource = dt
            GVAssetType.DataBind()
            GVAssetType.Visible = True
            
        Else
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1023)
        End If
    End Sub

    Protected Sub GVAssetType_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVAssetType.PageIndexChanging
        GVAssetType.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVAssetType.PageIndex
        DispGrid()
        GVAssetType.Visible = True
    End Sub
    Protected Sub GVAssetType_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVAssetType.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            bl.ChangeFlag(CType(GVAssetType.Rows(e.RowIndex).Cells(1).FindControl("ATD"), HiddenField).Value)
            'GVAssetType.DataBind()
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1028)
            'msginfo.Text = ""
            GVAssetType.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    Protected Sub GVAssetType_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVAssetType.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        Dim dt As New DataTable
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        btnadd.CommandName = "UPDATE"
        btnadd.Text = "UPDATE"
        btnview.Text = "BACK"
        btnview.CommandName = "BACK"
        GVAssetType.Visible = True
        ViewState("AssetType_ID") = CType(GVAssetType.Rows(e.NewEditIndex).FindControl("ATD"), HiddenField).Value
        txtboxAssetType.Text = CType(GVAssetType.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        TxtboxAssestTypeCode.Text = CType(GVAssetType.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        Txtboxdesc.Text = CType(GVAssetType.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        el.AssetType_ID = ViewState("AssetType_ID")
        dt = bl.GetAssetType(el)
        GVAssetType.DataSource = dt
        GVAssetType.DataBind()
        GVAssetType.Enabled = False
        
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtboxAssetType.Focus()
        txtboxAssetType.ReadOnly = False
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            
        End If
    End Sub

    Protected Sub GVAssetType_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVAssetType.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        el.AssetType_ID = 0
        GVAssetType.Enabled = True
        dt = bl.GetAssetType(el)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVAssetType.DataSource = sortedView
        GVAssetType.DataBind()
        GVAssetType.Visible = True
        LinkButton1.Focus()
        
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

