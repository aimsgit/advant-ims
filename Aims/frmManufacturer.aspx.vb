Imports System.Data.OleDb
Partial Class frmManufacturer
    Inherits BasePage
    Dim bl As New ManufacturerManager
    Dim mf As New ManufacturerE
    Dim dt As New DataTable
    Dim a As Integer
    
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        TxtManufacturerName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If BtnSave.Text = "ADD" Then
                'If BtnSave.CommandName = "ADD" Then
                ' Adds the data-- by Nakul Bharadwaj(12-3-2012)
                mf.Name = TxtManufacturerName.Text
                dt = bl.GetDuplicateManfMaster(mf)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                Else
                    'Dim mf As New ManufacturerE
                    mf.Name = TxtManufacturerName.Text
                    bl.InsertRecord(mf)
                    lblmsg.Text = ValidationMessage(1020)
                    'TxtManufacturerName.Text = ""
                    BtnSave.Text = "ADD"
                    msginfo.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DisplayGridView()
                    GridView1.Visible = True
                    GridView1.Enabled = True
                End If
            ElseIf BtnSave.text = "UPDATE" Then
                'BtnSave.CommandName = "UPDATE" Then
                ' Updates the data-- by Nakul Bharadwaj(12-3-2012)
                'lblmsg.Text = ValidationMessage(1014)
                'msginfo.Text = ValidationMessage(1014)
                'Dim mf As New ManufacturerE
                mf.id = ViewState("ManuFacturer_ID")
                    mf.Name = TxtManufacturerName.Text

                    dt = bl.GetDuplicateManfMaster(mf)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1030)
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        bl.UpdateRecord(mf)
                        lblmsg.Text = ValidationMessage(1017)
                        TxtManufacturerName.Text = ""
                        msginfo.Text = ValidationMessage(1014)
                        GridView1.PageIndex = ViewState("PageIndex")

                        BtnSave.Text = "ADD"
                        BtnDetails.Text = "VIEW"
                        GridView1.Enabled = True
                    DisplayGridView()
                    GridView1.Visible = True
                End If
                End If


        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()
        ' VIEW- Displays the data in gridview-- by Nakul Bharadwaj(12-3-2012)
        ' BACK- Goes back to VIEW mode from edit mode-- by Nakul Bharadwaj(12-3-2012)
        If BtnDetails.CommandName = "VIEW" Then
            'mf.id = 0
            GridView1.Visible = True
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
            DisplayGridView()
            GridView1.Enabled = True
        Else
            ''mf.id = 0
            GridView1.Visible = True
            GridView1.PageIndex = ViewState("PageIndex")
            msginfo.Text = ValidationMessage(1014)
            'TxtManufacturerName.Text = ""
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
            'BtnSave.CommandName = "ADD"
            'BtnDetails.CommandName = "VIEW"
            GridView1.Enabled = True
            DisplayGridView()
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGridView()
    End Sub
    
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ' Deletes data of the selected row-- by Nakul Bharadwaj(12-3-2012)
            If GridView1.EditIndex <> -1 Then
                msginfo.Text = "First Cancel Edit."
            Else
                a = Convert.ToInt64(GridView1.DataKeys(e.RowIndex).Value)
                bl.Delete(a)
                lblmsg.Text = ValidationMessage(1028)
                TxtManufacturerName.Focus()
                msginfo.Text = ValidationMessage(1014)
                GridView1.PageIndex = ViewState("PageIndex")
                DisplayGridView()
                TxtManufacturerName.Text = ""
            End If
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub DisplayGridView()
        ' Displays the data-- by Nakul Bharadwaj(12-3-2012)
        Dim dt As New DataTable
        dt = bl.GetManufacturer(mf)
        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            msginfo.Text = ValidationMessage(1023)
            lblmsg.Text = ValidationMessage(1014)
        Else
            GridView1.DataSource = dt
            GridView1.DataBind()
            
        End If
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        ' The data of the selected row goes to edit mode-- by Nakul Bharadwaj(12-3-2012)
        TxtManufacturerName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        ViewState("ManuFacturer_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("MID"), HiddenField).Value
        mf.id = ViewState("ManuFacturer_ID")
        BtnSave.Text = "UPDATE"
        BtnDetails.Text = "BACK"
        dt = bl.GetManufacturer(mf)
        GridView1.DataSource = dt
        GridView1.DataBind()
        'lblmsg.Text = ValidationMessage(1014)
        'msginfo.Text = ValidationMessage(1014)

        'BtnSave.CommandName = "UPDATE"
        'BtnDetails.CommandName = "BACK"

        'GridView1.Visible = True
        'GridView1.Enabled = False

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & TxtManufacturerName.ClientID & "').focus();</script>")
        ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")
        TxtManufacturerName.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Manufacturer Details")
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
        Dim dt As New DataTable
        dt = bl.GetManufacturer(mf)
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
