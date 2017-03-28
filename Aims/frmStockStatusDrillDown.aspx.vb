

Imports System.IO
Imports System.Data
Imports System.Collections.Generic

Imports System.Data.SqlClient
Partial Class frmStockStatusDrillDown
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DL As New Mfg_DLSaleReturn
        Dim dt As New DataTable
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim Product_ID As String = Request.QueryString.Get(("Product_ID"))
   
        QueryStr.GetValue(Page.Request, Prop)
        dt = DL.Drilldown(Product_ID)

        If dt.Rows.Count = 0 Then
            GVDrilldownStockStatus.DataSource = Nothing
            GVDrilldownStockStatus.DataBind()
            msginfo.Text = "No records to display."
            msginfo.Focus()
        Else
            GVDrilldownStockStatus.DataSource = dt
            GVDrilldownStockStatus.DataBind()
            GVDrilldownStockStatus.Focus()

        End If
        For Each grid In GVDrilldownStockStatus.Rows
            If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-1900" Then
                CType(grid.FindControl("lblExpiry"), Label).Text = ""
            End If
            If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-3000" Then
                CType(grid.FindControl("lblExpiry"), Label).Text = ""
            End If
        Next

    End Sub

    'Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
    '    Dim sw As New StringWriter()
    '    Dim hw As New System.Web.UI.HtmlTextWriter(sw)
    '    Dim frm As HtmlForm = New HtmlForm()

    '    Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
    '    Page.Response.AddHeader("content-disposition", "attachment;filename=PromotionEligibility.xls")
    '    Page.Response.ContentType = "application/vnd.ms-excel"
    '    Page.Response.Charset = ""
    '    Page.EnableViewState = False
    '    frm.Attributes("runat") = "server"
    '    Controls.Add(frm)
    '    frm.Controls.Add(GVDrilldownStockStatus)
    '    frm.RenderControl(hw)
    '    Response.Write(style)
    '    'Response.Write(sw.ToString())
    '    Response.Output.Write(style & sw.ToString())
    '    Response.Flush()
    '    Response.End()

    'End Sub
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

    Protected Sub GVDrilldownStockStatus_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVDrilldownStockStatus.Sorting
        Dim sortingDirection As String = String.Empty
        Dim dt As New DataTable
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim DL As New Mfg_DLSaleReturn
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim Product_ID As String = Request.QueryString.Get(("Product_ID"))
       
        QueryStr.GetValue(Page.Request, Prop)
        dt = DL.Drilldown(Product_ID)

        If dt.Rows.Count = 0 Then
            GVDrilldownStockStatus.DataSource = Nothing
            GVDrilldownStockStatus.DataBind()
            msginfo.Text = "No records to display."
            msginfo.Focus()
        Else
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            GVDrilldownStockStatus.DataSource = sortedView
            '  GVDrilldownEligibilty.DataSource = dt
            GVDrilldownStockStatus.DataBind()
            GVDrilldownStockStatus.Focus()
        End If
    End Sub
End Class
