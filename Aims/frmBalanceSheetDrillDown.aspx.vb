Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing
Partial Class frmBalanceSheetDrillDown
    Inherits BasePage
    Dim dl As New DLReportsD
    Dim dt As New DataTable
    Dim FromDate As New Date
    Dim ToDate As New Date
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

        QueryStr.GetValue(Page.Request, Prop)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        lblAccGrpBind.Text = AccGroup
        lblAccSubBind.Text = AccSubGroup
        dt = DL.FirstDrillDown(fstartdate, fenddate, AccGroupId, AccSubGroupId)
        If dt.Rows.Count = 0 Then
            GVBalanceSheetFirstDD.DataSource = Nothing
            GVBalanceSheetFirstDD.DataBind()
            msginfo.Text = "No records to display."
        Else
            GVBalanceSheetFirstDD.DataSource = dt
            GVBalanceSheetFirstDD.DataBind()
        End If
    End Sub

    Protected Sub GVBalanceSheetFirstDD_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBalanceSheetFirstDD.PageIndexChanging
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

        QueryStr.GetValue(Page.Request, Prop)

        If GVBalanceSheetFirstDD.EditIndex <> -1 Then
            msginfo.Text = "First Cancel Edit."

        Else
            GVBalanceSheetFirstDD.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GVBalanceSheetFirstDD.PageIndex
            lblAccGrpBind.Text = AccGroup
            lblAccSubBind.Text = AccSubGroup
            dt = dl.FirstDrillDown(fstartdate, fenddate, AccGroupId, AccSubGroupId)
            If dt.Rows.Count = 0 Then
                GVBalanceSheetFirstDD.DataSource = Nothing
                GVBalanceSheetFirstDD.DataBind()
                msginfo.Text = "No records to display."
            Else
                GVBalanceSheetFirstDD.DataSource = dt
                GVBalanceSheetFirstDD.DataBind()
            End If
        End If
    End Sub

    Protected Sub GVBalanceSheetFirstDD_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBalanceSheetFirstDD.RowEditing
        Dim accgrpId As Integer
        Dim accsubgrpId As Integer
        Dim accHeadCode As Integer
        Dim AccHeadname As String
        Dim Party_Id_Name As String
        Dim fstartdate As Date = Request.QueryString.Get(("FinStartDate"))
        Dim fenddate As Date = Request.QueryString.Get(("FinEndDate"))
        Dim AccGroupId As Integer = Request.QueryString.Get(("AccGroupId"))
        Dim AccSubGroupId As Integer = Request.QueryString.Get(("AccSubGroupId"))
        Dim accgroup As String = Request.QueryString.Get(("accgroup"))
        Dim accsubgroup As String = Request.QueryString.Get(("accsubgroup"))
        dt = dl.FirstDrillDown(fstartdate, fenddate, AccGroupId, AccSubGroupId)
        If CType(GVBalanceSheetFirstDD.Rows(e.NewEditIndex).FindControl("hidAccHeadCode"), HiddenField).Value = "" Then
            accHeadCode = 0
        Else
            accHeadCode = CType(GVBalanceSheetFirstDD.Rows(e.NewEditIndex).FindControl("hidAccHeadCode"), HiddenField).Value
        End If
        AccHeadname = CType(GVBalanceSheetFirstDD.Rows(e.NewEditIndex).FindControl("lblHeadTyp"), Label).Text
        Party_Id_Name = CType(GVBalanceSheetFirstDD.Rows(e.NewEditIndex).FindControl("lblPartyNameid"), HiddenField).Value
        ' accsubgrpId = CType(GVBalanceSheetFirstDD.Rows(e.NewEditIndex).FindControl("hidAccSubGroupId"), HiddenField).Value

        Dim qrystring As String = "frmBalanceSheetDrillDown2.aspx?" & QueryStr.Querystring() & "&FinStartDate=" & fstartdate & "&FinEndDate=" & fenddate & "&AccGroup=" & accgroup & "&AccSubGroup=" & accsubgroup & "&AccGroupId=" & accgrpId & "&AccSubGroupId=" & AccSubGroupId & "&AccHeadCode=" & accHeadCode & "&AccHeadname=" & AccHeadname & "&Party_Id_Name=" & Party_Id_Name
       
        ClientScript.RegisterStartupScript(Me.GetType(), "OpenWin", "<script>openNewWin('" & qrystring & "')</script>")

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
        frm.Controls.Add(GVBalanceSheetFirstDD)
        frm.RenderControl(hw)
        Response.Write(style)
        'Response.Write(sw.ToString())
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()

    End Sub
End Class
