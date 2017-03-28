'Imports System.Data.SqlClient
'Imports System.Data
'Imports System.Data.Sql
Partial Class FrmFeedBackReport
    Inherits BasePage
    Dim dl As New DLFeedBack
    Dim el As New ELFeedBackDetails
    Dim c As New Course
    Dim dt As New DataTable
    Dim CourseManager As New CourseManager


    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim fromdate As DateTime
            Dim Todate As DateTime
            Dim dt As New DataTable
            Dim LG As Integer
            Dim Status As String

            If txtstartdate.Text = "" Then
                fromdate = "1900-01-01"
            Else
                fromdate = txtstartdate.Text
            End If
            If txtenddate.Text = "" Then
                Todate = "3000-01-01"
            Else
                Todate = txtenddate.Text
            End If
            LG = Session("LanguageID")

            Status = cmbStatus.SelectedValue
            If fromdate > Todate Then
                msginfo.Text = "Start date should not be greater than End date."
                txtenddate.Focus()
            End If

            Dim qrystring As String = "FrmFeedbackReportV.aspx?" & QueryStr.Querystring() & "&Fromdate=" & fromdate & "&Todate=" & Todate & "&LanguageId=" & LG & "&Status=" & Status
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            msginfo.Text = "Please enter the valid date."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        'Dim fromdate As DateTime
        'Dim Todate As DateTime

        'fromdate = txtstartdate.Text
        'Todate = txtenddate.Text
        GridView1.PageIndex = ViewState("PageIndex")
        DispGrid()
    End Sub
    Sub DispGrid()
        Dim fromdate As DateTime
        Dim Todate As DateTime
        Dim dt As New DataTable
        Dim Status As String

        Dim LG As Integer = Session("LanguageID")
        If txtstartdate.Text = "" Then
            fromdate = "1900-01-01"
        Else
            fromdate = txtstartdate.Text
        End If
        If txtenddate.Text = "" Then
            Todate = "3000-01-01"
        Else
            Todate = txtenddate.Text
        End If


        If fromdate > Todate Then
            msginfo.Text = "Start date should not be greater than End date."
            txtenddate.Focus()
        End If
        Status = cmbStatus.SelectedValue
        dt = DLFeedBack.GetFeedbackDetails(fromdate, Todate, LG, Status)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True

            msginfo.Text = ""
            lblmsg.Text = ""
            txttotalcount.Text = dt.Rows.Count

        Else
            txttotalcount.Text = dt.Rows.Count
            msginfo.Text = "No record to display"
            GridView1.Visible = False
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txttotalcount.Enabled = False
        If Not Page.IsPostBack Then
            txtstartdate.Text = Format(Today(), "dd-MMM-yyyy")
            txtenddate.Text = Format(Today(), "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub cmbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbStatus.SelectedItem.Text = "Close" Then
            BtnClose.Enabled = False
        ElseIf cmbStatus.SelectedItem.Text = "Open" Then
            BtnClose.Enabled = True
            BtnClose.Visible = True
        ElseIf cmbStatus.SelectedItem.Text = "All" Then
            BtnClose.Enabled = True
            BtnClose.Visible = True
        End If
        DispGrid()
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Dim id As String = ""
        Dim check As String = ""
        Dim id1 As String = ""
        Dim count As New Integer
        Dim FBId As New Int64
        For Each grid As GridViewRow In GridView1.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = False Then
                lblmsg.Text = ""
                msginfo.Text = "Please select record(s) to close."
            End If
        Next
        For Each grid As GridViewRow In GridView1.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                check = CType(grid.FindControl("l5"), Label).Text
                If check = "Open" Then
                    FBId = CType(grid.FindControl("IID"), HiddenField).Value
                    el.Estatus = CType(grid.FindControl("l5"), Label).Text
                    msginfo.Text = ""
                    DLFeedBack.Close(FBId, el)
                    GridView1.PageIndex = ViewState("PageIndex")
                    DispGrid()
                    msginfo.Text = ""
                    lblmsg.Text = "Feedback(s) closed successfully."
                    BtnClose.Visible = True

                Else
                    lblmsg.Text = ""
                    msginfo.Text = "Feedback(s) is already closed"

                End If
            End If

        Next

    End Sub
    'Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
    '    Dim FBId As New Int64

    '    FBId = CType(GridView1.Rows(e.RowIndex).FindControl("IID"), HiddenField).Value
    '    DLFeedBack.DeleteFeedback(FBId)
    '    lblmsg.Text = "Data Deleted Successfully."
    '    msginfo.Text = ""
    '    GridView1.PageIndex = ViewState("PageIndex")
    '    DispGrid()
    'End Sub
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        Dim fromdate As DateTime
        Dim Todate As DateTime
        Dim dt1 As New DataTable
        Dim Status As String

        Dim LG As Integer = Session("LanguageID")
        fromdate = txtstartdate.Text
        Todate = txtenddate.Text
        If fromdate > Todate Then
            msginfo.Text = "Start date should not be greater than End date."
            txtenddate.Focus()
        End If
        Status = cmbStatus.SelectedValue
        dt1 = DLFeedBack.GetFeedbackDetails(fromdate, Todate, LG, Status)
        Dim sortedView As New DataView(dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True

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
