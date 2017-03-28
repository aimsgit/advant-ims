Imports System.IO
Imports System.Data
Imports System.Collections.Generic

Imports System.Data.SqlClient
Partial Class frmEligibiltyStudentDrillDown
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DL As New DLEligiblityPromotion
        Dim dt As New DataTable
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim BatchId As String = Request.QueryString.Get(("BatchId"))
        Dim StdId As String = Request.QueryString.Get(("StdId"))
        Dim sem1 As String = Request.QueryString.Get(("sem1"))
        Dim assesment As String = Request.QueryString.Get(("assesment"))
        Dim sem As String = Request.QueryString.Get(("sem"))
        QueryStr.GetValue(Page.Request, Prop)
        dt = DL.Drilldown(StdId, BatchId, sem, sem1, assesment)

        If dt.Rows.Count = 0 Then
            GVDrilldownEligibilty.DataSource = Nothing
            GVDrilldownEligibilty.DataBind()
            msginfo.Text = "No records to display."
            msginfo.Focus()
        Else
            GVDrilldownEligibilty.DataSource = dt
            GVDrilldownEligibilty.DataBind()
            GVDrilldownEligibilty.Focus()
        End If
    End Sub

    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()

        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=PromotionEligibility.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        Controls.Add(frm)
        frm.Controls.Add(GVDrilldownEligibilty)
        frm.RenderControl(hw)
        Response.Write(style)
        'Response.Write(sw.ToString())
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()

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

    Protected Sub GVDrilldownEligibilty_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVDrilldownEligibilty.Sorting
        Dim sortingDirection As String = String.Empty
        Dim dt As New DataTable
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim DL As New DLEligiblityPromotion
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim BatchId As String = Request.QueryString.Get(("BatchId"))
        Dim StdId As String = Request.QueryString.Get(("StdId"))
        Dim sem1 As String = Request.QueryString.Get(("sem1"))
        Dim assesment As String = Request.QueryString.Get(("assesment"))
        Dim sem As String = Request.QueryString.Get(("sem"))
        QueryStr.GetValue(Page.Request, Prop)
        dt = DL.Drilldown(StdId, BatchId, sem, sem1, assesment)

        If dt.Rows.Count = 0 Then
            GVDrilldownEligibilty.DataSource = Nothing
            GVDrilldownEligibilty.DataBind()
            msginfo.Text = "No records to display."
            msginfo.Focus()
        Else
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            GVDrilldownEligibilty.DataSource = sortedView
            '  GVDrilldownEligibilty.DataSource = dt
            GVDrilldownEligibilty.DataBind()
            GVDrilldownEligibilty.Focus()
        End If
    End Sub
End Class
