Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing
Partial Class frmBalanceSheetDrillDown2
    Inherits BasePage 
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DL As New DLReportsD
        Dim dt As New DataTable
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim fstartdate As Date = Request.QueryString.Get(("FinStartDate"))
        Dim fenddate As Date = Request.QueryString.Get(("FinEndDate"))
        Dim AccGroup As String = Request.QueryString.Get(("AccGroup"))
        Dim AccSubGroup As String = Request.QueryString.Get(("AccSubGroup"))
        Dim AccGroupId As Integer = Request.QueryString.Get(("AccGroupId"))
        Dim AccSubGroupId As Integer = Request.QueryString.Get(("AccSubGroupId"))
        Dim AccHeadCode As Integer = Request.QueryString.Get(("AccHeadCode"))
        Dim AccHeadName As String = Request.QueryString.Get(("AccHeadname"))
        Dim Party_Id_Name As String = Request.QueryString.Get(("Party_Id_Name"))
        QueryStr.GetValue(Page.Request, Prop)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        lblAccGrpBind.Text = AccGroup
        lblAccSubBind.Text = AccSubGroup
        lblAccHeadBind.Text = AccHeadName
        dt = DL.SecondDrillDown(fstartdate, fenddate, AccGroupId, AccSubGroupId, AccHeadCode, Party_Id_Name)
        If dt.Rows.Count = 0 Then
            GVBalanceSheetDD2.DataSource = Nothing
            GVBalanceSheetDD2.DataBind()
            msginfo.Text = "No records to display."
        Else
            GVBalanceSheetDD2.DataSource = dt
            GVBalanceSheetDD2.DataBind()
        End If
    End Sub

    Protected Sub GVBalanceSheetDD2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBalanceSheetDD2.PageIndexChanging
        Dim DL As New DLReportsD
        Dim dt As New DataTable
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim fstartdate As Date = Request.QueryString.Get(("FinStartDate"))
        Dim fenddate As Date = Request.QueryString.Get(("FinEndDate"))
        Dim AccGroup As String = Request.QueryString.Get(("AccGroup"))
        Dim AccSubGroup As String = Request.QueryString.Get(("AccSubGroup"))
        Dim AccGroupId As Integer = Request.QueryString.Get(("AccGroupId"))
        Dim AccSubGroupId As Integer = Request.QueryString.Get(("AccSubGroupId"))
        Dim AccHeadCode As Integer = Request.QueryString.Get(("AccHeadCode"))
        Dim AccHeadName As String = Request.QueryString.Get(("AccHeadname"))
        Dim Party_Id_Name As String = Request.QueryString.Get(("Party_Id_Name"))
        QueryStr.GetValue(Page.Request, Prop)
        If GVBalanceSheetDD2.EditIndex <> -1 Then
            msginfo.Text = "First Cancel Edit."
        Else
            GVBalanceSheetDD2.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GVBalanceSheetDD2.PageIndex
            lblAccGrpBind.Text = AccGroup
            lblAccSubBind.Text = AccSubGroup
            lblAccHeadBind.Text = AccHeadName
            dt = DL.SecondDrillDown(fstartdate, fenddate, AccGroupId, AccSubGroupId, AccHeadCode, Party_Id_Name)
            If dt.Rows.Count = 0 Then
                GVBalanceSheetDD2.DataSource = Nothing
                GVBalanceSheetDD2.DataBind()
                msginfo.Text = "No records to display."
            Else
                GVBalanceSheetDD2.DataSource = dt
                GVBalanceSheetDD2.DataBind()
            End If
        End If
    End Sub

    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()


        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=BalanceSheetDrillDown.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        Controls.Add(frm)
        frm.Controls.Add(GVBalanceSheetDD2)
        frm.RenderControl(hw)
        Response.Write(style)
        'Response.Write(sw.ToString())
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()

    End Sub
End Class
