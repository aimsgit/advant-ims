
Partial Class frmDepreciation_Rates
    Inherits BasePage
    Dim DesignationManager As New DesignationManager
    Dim DesignationP As New DesignationP
    Shared str As String = ""
    Dim dt As New DataTable
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        txtDesigName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If BtnAdd.CommandName = "UPDATE" Then
                DesignationP.Designation_ID = ViewState("DID")
                DesignationP.Designation = txtDesigName.Text
                DesignationP.SalCodeGrd = ddlSalCodeGrd.SelectedItem.Text
                DesignationP.CategoryEtype = txtCatgryEmpType.Text
                dt = DesignationManager.GetDuplicateNameType(DesignationP)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1030)
                    msginfo.Text = ValidationMessage(1014)
                Else
                    DesignationManager.UpdateRecord(DesignationP)
                    BtnAdd.CommandName() = "ADD"
                    BtnDetails.CommandName() = "VIEW"
                    BtnAdd.Text = "ADD"
                    BtnDetails.Text = "VIEW"

                    GridView1.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    msginfo.Text = ValidationMessage(1017)
                    lblmsg.Text = ValidationMessage(1014)
                End If
            ElseIf BtnAdd.CommandName = "ADD" Then
                DesignationP.Designation = txtDesigName.Text
                DesignationP.SalCodeGrd = ddlSalCodeGrd.SelectedItem.Text
                DesignationP.CategoryEtype = txtCatgryEmpType.Text

                dt = DesignationManager.GetDuplicateNameType(DesignationP)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1030)
                    msginfo.Text = ValidationMessage(1014)
                Else
                    DesignationManager.InsertRecord(DesignationP)
                    msginfo.Text = ValidationMessage(1020)
                    lblmsg.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DisplayGrid()
                    clear()
                End If
            End If
        Else
            lblmsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGrid()
    End Sub
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()
        If BtnDetails.CommandName = "BACK" Then
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            lblmsg.Text = ValidationMessage(1014)
            BtnDetails.CommandName = "VIEW"
            BtnAdd.CommandName = "ADD"
            BtnDetails.Text = "VIEW"
            BtnAdd.Text = "ADD"
            clear()
        Else
            txtDesigName.Text = ""
            clear()
            ' GridView1.Visible = True
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DisplayGrid()
        End If
            End Sub

    Sub DisplayGrid()
        clear()
        Dim dt As New DataTable
        Dim i As Integer = 0
        DesignationP.Designation_ID = 0
        dt = DesignationManager.GetDesiganation(DesignationP)
        If dt.Rows.Count > 0 Then
            For Each row In dt.Rows
                If dt.Rows(i).Item("SalaryCodeBand") = "Select" Then
                    dt.Rows(i).Item("SalaryCodeBand") = ""

                End If
                i = i + 1

            Next
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True

                       'Next
        Else
            lblmsg.Text = ValidationMessage(1023)
            'msginfo.Visible = False
            'lblmsg.Visible = True
            GridView1.Visible = False
            msginfo.Text = ValidationMessage(1014)
           
        End If
    End Sub
    'Protected Sub BtnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReport.Click
    '    Dim DAL As New DesignationManager
    '    Dim dtM As New Data.DataTable
    '    dtM = DAL.GetDesiganation.Tables(0)
    '    If dtM.Rows.Count <> 0 Then
    '        'Response.Redirect("rptDesignationV.aspx")
    '        Dim qrystring As String = "rptDesignationV.aspx?" & QueryStr.Querystring()
    '        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    '    Else
    '        lblmsg.Text = "No Records to Display"
    '    End If
    'End Sub

    'For Deleting, By Ujjawal 22-Feb-2012
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            DesignationManager.ChangeFlag(CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text)
            msginfo.Text = ValidationMessage(1028)
            lblmsg.Text = ValidationMessage(1014)
            txtDesigName.Focus()
            'lblmsg.Visible = False
            'msginfo.Visible = True
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        Else
            lblmsg.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If
        
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        ddlSalCodeGrd.Items.Remove("Select")
        ddlSalCodeGrd.Items.Remove("Select")
        Dim el As New DesignationP
        txtDesigName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        ViewState("DID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        If (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblGvSalCodeGrd"), Label).Text = "") Then

            ddlSalCodeGrd.SelectedItem.Text = "Select"

        Else


            ddlSalCodeGrd.SelectedItem.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblGvSalCodeGrd"), Label).Text
            ddlSalCodeGrd.Items.Add("Select")
        End If

        txtCatgryEmpType.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblGvCatgory"), Label).Text
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        el.Designation_ID = ViewState("DID")
        Dim dt As New DataTable
        dt = DesignationManager.GetDesiganation(el)
     
        Dim i As Integer
        For Each row In dt.Rows
            If dt.Rows(i).Item("SalaryCodeBand") = "Select" Then
                dt.Rows(i).Item("SalaryCodeBand") = ""

            End If
            i = i + 1

        Next
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
        BtnAdd.CommandName = "UPDATE"
        BtnAdd.Text = "UPDATE"
        BtnDetails.CommandName = "BACK"
        BtnDetails.Text = "BACK"
        'Else
        'lblmsg.Text = "You do not belong to this branch, Cannot edit data."
        'msginfo.Text = ""
        'End If
        

    End Sub
    Sub clear()
        txtDesigName.Text = ""
        ddlSalCodeGrd.SelectedIndex = -1
        If (ddlSalCodeGrd.SelectedItem.Text <> "Select") Then
            ddlSalCodeGrd.SelectedItem.Text = "Select"
        End If

        txtCatgryEmpType.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtDesigName.Focus()
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        'If Not IsPostBack Then
        
        'End If
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
        DisplayGrid()
        Dim dt As New DataTable
        DesignationP.Designation_ID = 0
        dt = DesignationManager.GetDesiganation(DesignationP)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
        
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
