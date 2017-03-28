Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports System.SerializableAttribute
Imports System.Runtime.Serialization.Formatters.Binary
'Author:  Ajit kumar singh
'Date:  29/03/2012
Partial Class frmProspectus
    Inherits BasePage
    'Dim alt, sql, sql1, sql3 As String
    'Dim Rda As New OleDbDataAdapter
    Dim flag As Integer
    Dim Rdt As New DataTable
    Dim BLL As New ProspectusB
    Dim Pro As New Prospectus
    Dim BAL As New EnquiryManager
    Dim dt As DataTable

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            ViewState("id") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("PID"), HiddenField).Value
            Pro.Id = ViewState("id")
            BLL.ChangeFlag(Pro)
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
            GridView1.Visible = True
            lblmsgs.Text = ValidationMessage(1028)
            txtname.Focus()
            lblmsge.Text = ValidationMessage(1014)
            'DispGrid()
            Dim dt As New DataTable
            Dim RadioButtonSelection As String
            ViewState("id") = 0
            RadioButtonSelection = RButton.SelectedValue
            GridView1.Enabled = True
            dt = BLL.Getprospdtls(ViewState("id"), RadioButtonSelection)
            'Try
            '    If dt.Rows.Count > 0 Then
            If RButton.SelectedValue = "R" Then
                GridView1.DataSource = dt
                GridView1.Columns(1).HeaderText = ValidationMessage(1147)
                GridView1.Columns(3).HeaderText = ValidationMessage(1148)
                GridView1.DataBind()

                GridView1.Visible = True
                GridView1.Columns(7).Visible = False
                GridView1.Columns(6).Visible = True
                GridView1.Columns(5).Visible = True
                GridView1.Columns(4).Visible = True

            ElseIf RButton.SelectedValue = "C" Then
                GridView1.DataSource = dt
                GridView1.Columns(1).HeaderText = ValidationMessage(1146)
                GridView1.Columns(3).HeaderText = ValidationMessage(1145)
                GridView1.DataBind()

                GridView1.Visible = True
                GridView1.Columns(4).Visible = False
                GridView1.Columns(5).Visible = False
                GridView1.Columns(6).Visible = False
                GridView1.Columns(7).Visible = True
            Else
                GridView1.DataSource = dt
                GridView1.Columns(1).HeaderText = ValidationMessage(1146)
                GridView1.Columns(3).HeaderText = ValidationMessage(1145)
                GridView1.DataBind()

                GridView1.Visible = True
                GridView1.Columns(6).Visible = False
                GridView1.Columns(7).Visible = True
                GridView1.Columns(5).Visible = True
                GridView1.Columns(4).Visible = True
            End If
            '    Else
            '        lblmsge.Text = "No records to display."
            '        lblmsgs.Text = ""
            '        GridView1.Visible = False
            '    End If
            'Catch ex As Exception

            'End Try
        Else
            lblmsge.Text = ValidationMessage(1029)
            lblmsgs.Text = ValidationMessage(1014)
        End If
    End Sub
    

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim dt As New DataTable
        Dim RB As String
        lblmsgs.Text = ValidationMessage(1014)
        lblmsge.Text = ValidationMessage(1014)
        txtname.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        txtserialno.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        txtPrice.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        txtreceiptno.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("txtrecptno"), Label).Text
        txtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text
        RB = CType(GridView1.Rows(e.NewEditIndex).FindControl("PType"), Label).Text
        If RB = "R" Then
            txtquantity.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text
            ViewState("Qty1") = txtquantity.Text

        Else
            txtquantity.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labe37"), Label).Text
            ViewState("Qty1") = txtquantity.Text

        End If
        RButton.SelectedValue = RB

        ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("PID"), HiddenField).Value

        BtnAdd.CommandName = "UPDATE"
        BtnView.CommandName = "BACK"
        dt = BLL.Getprospdtls(ViewState("id"), RB)
        GridView1.DataSource = dt
        GridView1.DataBind()

        GridView1.Enabled = False

    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        Dim RadioButtonSelection As String
        ViewState("id") = 0
        RadioButtonSelection = RButton.SelectedValue
        GridView1.Enabled = True
        dt = BLL.Getprospdtls(ViewState("id"), RadioButtonSelection)
        Try
            If dt.Rows.Count > 0 Then
                If RButton.SelectedValue = "R" Then
                    GridView1.DataSource = dt
                    GridView1.Columns(1).HeaderText = ValidationMessage(1147)
                    GridView1.Columns(3).HeaderText = ValidationMessage(1148)
                    GridView1.DataBind()

                    GridView1.Visible = True
                    GridView1.Columns(7).Visible = False
                    GridView1.Columns(6).Visible = True
                    GridView1.Columns(5).Visible = True
                    GridView1.Columns(4).Visible = True

                ElseIf RButton.SelectedValue = "C" Then
                    GridView1.DataSource = dt
                    GridView1.Columns(1).HeaderText = ValidationMessage(1146)
                    GridView1.Columns(3).HeaderText = ValidationMessage(1145)
                    GridView1.DataBind()

                    GridView1.Visible = True
                    GridView1.Columns(4).Visible = False
                    GridView1.Columns(5).Visible = False
                    GridView1.Columns(6).Visible = False
                    GridView1.Columns(7).Visible = True
                Else
                    GridView1.DataSource = dt
                    GridView1.Columns(1).HeaderText = ValidationMessage(1146)
                    GridView1.Columns(3).HeaderText = ValidationMessage(1145)
                    GridView1.DataBind()

                    GridView1.Visible = True
                    GridView1.Columns(6).Visible = False
                    GridView1.Columns(7).Visible = True
                    GridView1.Columns(5).Visible = True
                    GridView1.Columns(4).Visible = True
                End If
            Else
                lblmsge.Text = ValidationMessage(1023)
                lblmsgs.Text = ValidationMessage(1014)
                GridView1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Balancefill()
        Dim dt As DataTable
        dt = BLL.ProspBalance()
        If dt.Rows(0).Item("BalanceQuantity") IsNot System.DBNull.Value Then
            TxtAvailable.Text = dt.Rows(0).Item("BalanceQuantity")
        Else
            TxtAvailable.Text = 0
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Balancefill()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        txtname.Focus()
        If IsPostBack = False Then
            txtDate.Text = Format(Date.Today, "dd-MMM-yyyy")


        End If
    End Sub
    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        txtname.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                
                    Pro.Name = txtname.Text
                    Pro.SerialNo = txtserialno.Text
                    Pro.Entrydate = txtDate.Text
                    Pro.PreceiptNO = txtreceiptno.Text
                    Pro.Remarks = txtRemarks.Text
                    If txtPrice.Text = "" Then
                        Pro.Price = 0
                    Else
                        Pro.Price = txtPrice.Text
                    End If
                    Pro.Quantity = txtquantity.Text
                    Pro.ProspectusStatus = RButton.SelectedValue
                If BtnAdd.CommandName = "UPDATE" Then
                    If RButton.SelectedValue <> "R" Then
                        Dim Qty As Integer = ViewState("Qty1")
                        Dim Available As Integer = TxtAvailable.Text
                        Qty = Qty + Available
                        If txtquantity.Text <= Qty Then
                        Else
                            lblmsge.Text = ValidationMessage(1140)
                            lblmsgs.Text = ValidationMessage(1014)
                            Exit Sub
                        End If
                    End If
                    Pro.Id = ViewState("id")
                    'Code For Duplicate Value Check By Nitin 30/07/2012
                    dt = ProspectusDB.GetDuplicateProspectus(Pro)
                    If dt.Rows.Count > 0 Then
                        lblmsge.Text = ValidationMessage(1030)
                        lblmsgs.Text = ValidationMessage(1014)
                    Else
                        BLL.UpdateRecord(Pro)
                        GridView1.Visible = True
                        lblmsgs.Text = ValidationMessage(1017)
                        txtDate.Text = Format(Today, "dd-MMM-yyyy")
                        lblmsge.Text = ValidationMessage(1014)
                        BtnAdd.CommandName = "ADD"
                        BtnView.CommandName = "VIEW"
                        Clear()
                        GridView1.PageIndex = ViewState("PageIndex")
                        DispGrid()
                    End If
                ElseIf BtnAdd.CommandName = "ADD" Then
                    If RButton.SelectedValue <> "R" Then
                        If TxtAvailable.Text > 0 And txtquantity.Text <= TxtAvailable.Text Then
                        Else
                            lblmsge.Text = ValidationMessage(1140)
                            lblmsgs.Text = ValidationMessage(1014)
                            Exit Sub
                        End If
                    End If
                    dt = ProspectusDB.GetDuplicateProspectus(Pro)
                    If dt.Rows.Count > 0 Then
                        lblmsge.Text = ValidationMessage(1030)
                        lblmsgs.Text = ValidationMessage(1014)
                    Else
                        BLL.InsertRecord(Pro)
                        GridView1.Visible = True
                        lblmsgs.Text = ValidationMessage(1020)
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        DispGrid()
                        lblmsge.Text = ValidationMessage(1014)
                        Clear()
                    End If
                End If
                

            Catch ex As Exception
                lblmsge.Text = ValidationMessage(1055)
                lblmsgs.Text = ValidationMessage(1014)
            End Try
        Else
            lblmsge.Text = ValidationMessage(1021)
            lblmsgs.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        LinkButton1.Focus()
        lblmsge.Text = ValidationMessage(1014)
        lblmsgs.Text = ValidationMessage(1014)
        ViewState("id") = 0
        If BtnView.CommandName = "VIEW" Then
            txtDate.Text = Format(Today, "dd-MMM-yyyy")
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DispGrid()
        ElseIf BtnView.CommandName = "BACK" Then
            txtDate.Text = Format(Today, "dd-MMM-yyyy")
            BtnAdd.CommandName = "ADD"
            BtnView.CommandName = "VIEW"
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
            Clear()
        End If
    End Sub
    Public Sub Clear()
        txtname.Text = ""
        txtserialno.Text = ""
        txtquantity.Text = ""
        txtreceiptno.Text = ""
        txtRemarks.Text = ""
        txtPrice.Text = ""
        txtDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        Balancefill()
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
        GridView1.Visible = True
        
    End Sub
    
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
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
        ViewState("id") = 0
        Dim RB As String
        RB = RButton.SelectedValue
        GridView1.Enabled = True
        dt = BLL.Getprospdtls(ViewState("id"), RB)
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
            ViewState("dirState") = Value
        End Set
    End Property

    Protected Sub RButton_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RButton.SelectedIndexChanged
        If RButton.SelectedValue = "S" Then
            txtPrice.Visible = True
            txtreceiptno.Visible = True
            lblprice.Visible = True
            lblpreceiptno.Visible = True
            lblname.Text = ValidationMessage(1142)
            lblserialno.Text = ValidationMessage(1141)
            GridView1.Visible = False
            lblmsge.Text = ValidationMessage(1014)
            lblmsgs.Text = ValidationMessage(1014)
            Clear()
        ElseIf RButton.SelectedValue = "C" Then
            txtPrice.Visible = False
            txtreceiptno.Visible = False
            lblprice.Visible = False
            lblpreceiptno.Visible = False
            lblname.Text = ValidationMessage(1142)
            lblserialno.Text = ValidationMessage(1141)
            GridView1.Visible = False
            lblmsge.Text = ValidationMessage(1014)
            lblmsgs.Text = ValidationMessage(1014)
            Clear()
        Else
            lblname.Text = ValidationMessage(1143)
            lblserialno.Text = ValidationMessage(1144)
            txtPrice.Visible = True
            txtreceiptno.Visible = True
            lblprice.Visible = True
            lblpreceiptno.Visible = True
            GridView1.Visible = False
            lblmsge.Text = ValidationMessage(1014)
            lblmsgs.Text = ValidationMessage(1014)
            Clear()
        End If
    End Sub
    'Code written fro multilingual by Niraj on 08 Nov 2013
    ''Retriving the text of controls based on Language

   
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try
            dt2 = Session("ValidationTable")
            Dim X As Integer = dt2.Rows.Count() - 1
            Dim str As String = " "
            For i As Integer = 0 To X
                If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                    Return dt2.Rows(i).Item("MessageText").ToString()
                End If
            Next
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
        Return 0
    End Function
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub
End Class
