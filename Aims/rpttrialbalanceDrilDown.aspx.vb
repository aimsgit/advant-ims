Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing
Partial Class rpttrialbalanceDrilDown
    Inherits BasePage


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DL As New DLTrialBookReport
        Dim dt As New DataTable
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim StartDate As DateTime = Request.QueryString.Get("StartDate")
        Dim EndDate As DateTime = Request.QueryString.Get("EndDate")
        'Dim AccGroup As String = Request.QueryString.Get(("AccGroup"))
        'Dim AccSubGroup As String = Request.QueryString.Get(("AccSubGroup"))
        Dim accsubgrpId As Integer = Request.QueryString.Get("accsubgrpId")
        'Dim AccSubGroupId As Integer = Request.QueryString.Get(("AccSubGroupId"))
        'Dim AccHeadCode As Integer = Request.QueryString.Get(("AccHeadCode"))
        'Dim AccHeadName As String = Request.QueryString.Get(("AccHeadname"))
        'Dim Party_Id_Name As String = Request.QueryString.Get(("Party_Id_Name"))
        QueryStr.GetValue(Page.Request, Prop)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
      
        dt = DL.FirstDrillDown(StartDate, EndDate, accsubgrpId)
        If dt.Rows.Count = 0 Then
            GVTrialBalanceDrillDown.DataSource = Nothing
            GVTrialBalanceDrillDown.DataBind()
            msginfo.Text = "No records to display."
        Else
            GVTrialBalanceDrillDown.DataSource = dt
            GVTrialBalanceDrillDown.DataBind()
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
        frm.Controls.Add(GVTrialBalanceDrillDown)
        frm.RenderControl(hw)
        Response.Write(style)
        'Response.Write(sw.ToString())
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()

    End Sub
End Class
