
Partial Class frmApptDrillDown
    Inherits BasePage
    Dim dl As New DLReportsD
    Dim DLL As new DLAppointmentCRM
    Dim dt As New DataTable
    Dim FromDate As New Date
    Dim ToDate As New Date
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim DL As New DLReportsD
        'Dim dt As New DataTable
        'Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Lblheading.Text = Request.QueryString.Get("Status").ToString.ToUpper + " DETAILS"

        Dim SelectedDate As Date = Request.QueryString.Get("SelectedDate")
        Dim Status As String = Request.QueryString.Get("Status")
        Dim id As Integer = Request.QueryString.Get("id")
        If id = 0 Then
            GVAppt.Columns(1).HeaderText = "Appointment Date"
            GVAppt.Columns(2).HeaderText = "Appointment Time"
        ElseIf id = 1 Then
            GVAppt.Columns(1).HeaderText = "Demo Date"
            GVAppt.Columns(2).HeaderText = "Demo Time"
        Else
            GVAppt.Columns(1).HeaderText = "Proposal Date"
            'GVAppt.Columns(2).HeaderText = ""
            GVAppt.Columns(2).Visible = False
        End If

        QueryStr.GetValue(Page.Request, Prop)
        'Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        dt = DLL.GetApptDetailsfordrilldown(SelectedDate, Status)
        If dt.Rows.Count = 0 Then
            GVAppt.DataSource = Nothing
            GVAppt.DataBind()
            msginfo.Text = "No records to display."
        Else
            GVAppt.DataSource = dt
            GVAppt.DataBind()
        End If
    End Sub


End Class
