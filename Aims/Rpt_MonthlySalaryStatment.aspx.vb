
Partial Class Rpt_MonthlySalaryStatment
    Inherits BasePage
    Dim bl As New BLDynamicReport
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable
    Dim DL As New DLAnnualSalaryStatment
    'Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
    '    Dim dt1 As DataTable
    '    Dim Prop As New QureyStringP
    '    Dim obj As New SelfDetailsB
    '    Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
    '    Dim FromYear As Integer = Request.QueryString.Get("FromYear")
    '    Dim ToYear As Integer = Request.QueryString.Get("ToYear")
    '    Dim FromMonth As Integer = Request.QueryString.Get("FromMonth")
    '    Dim ToMonth As Integer = Request.QueryString.Get("ToMonth")
    '    Dim Dept As Integer = Request.QueryString.Get("DeptID")
    '    Dim Empid As Integer = Request.QueryString.Get("Empid")
    '    Dim ColumnName As Integer = Request.QueryString.Get("ColumnName")

    '    QueryStr.GetValue(Page.Request, Prop)

    '    dt1 = DLAnnualSalaryStatment.RptMonthlyStatment(FromYear, ToYear, FromMonth, ToMonth, Dept, Empid, ColumnName)
    '    Try
    '        If dt1.Rows.Count > 0 Then
    '            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
    '            Me.ReportViewer1.LocalReport.ReportPath = "Rpt_AnnualSalaryStatment.rdlc"
    '            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_AnnualSalaryStatment", dt1)

    '            'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
    '            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromYear", FromYear, False))
    '            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToYear", ToYear, False))
    '            'ReportViewer1.LocalReport.SetParameters(paramList)

    '            ReportViewer1.LocalReport.DataSources.Clear()
    '            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
    '            ReportViewer1.LocalReport.Refresh()
    '            dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
    '            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    '        Else
    '            lblr.Text = "No records to display."
    '        End If
    '    Catch ex As Exception
    '        lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
    '    End Try
    'End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    ' Rows property to hold the Rows in the ViewState
    Protected Property Rows() As Integer
        Get
            If Not ViewState("Rows") Is Nothing Then
                Return CInt(Fix(ViewState("Rows")))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("Rows") = value
        End Set
    End Property

    ' Columns property to hold the Columns in the ViewState
    Protected Property Columns() As Integer
        Get
            If Not ViewState("Columns") Is Nothing Then
                Return CInt(Fix(ViewState("Columns")))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("Columns") = value
        End Set
    End Property
    Private Sub CreateDynamicTable()
        Try

         PlaceHolder1.Controls.Clear()
            ' Fetch the number of Rows and Columns for the table 
            ' using the properties
            Dim tblRows As Integer = Rows
            Dim tblCols As Integer = Columns
            ' Create a Table and set its properties 
            Dim tbl As Table = New Table()
            ' Add the table to the placeholder control
            PlaceHolder1.Controls.Add(tbl)
            Dim FromYear As Integer = Request.QueryString.Get("FromYear")
            Dim ToYear As Integer = Request.QueryString.Get("ToYear")
            Dim FromMonth As Integer = Request.QueryString.Get("FromMonth")
            Dim ToMonth As Integer = Request.QueryString.Get("ToMonth")
            Dim Dept As Integer = Request.QueryString.Get("DeptID")
            Dim Empid As Integer = Request.QueryString.Get("Empid")
            Dim ID As String = Request.QueryString.Get("ColumnName")
            dt = DLAnnualSalaryStatment.RptMonthlyStatment(FromYear, ToYear, FromMonth, ToMonth, Dept, Empid, ID)
         
            If dt.Rows.Count <> 0 Then
                Dim Str(100) As String
                ID = ID.Replace("[", "")
                ID = ID.Replace("]", "")
                Str = ID.Split(",")
                Dim Row As Integer = dt.Rows.Count
                Dim column As Integer = dt.Columns.Count
                Dim photo As Integer = 0
                ' Now iterate through the table and add your controls 
                For r As Integer = -1 To Row - 1
                    'StrBuild.Append(vbCrLf + "|")
                    Dim tr As TableRow = New TableRow()
                    'tr.BorderColor = Drawing.Color.Black
                    'tr.BorderStyle = BorderStyle.Solid
                    For c As Integer = 0 To column - 1
                        'StrBuild.Append(dt.Rows(r)(c))
                        'StrBuild.Append("|")
                        Dim tc As TableCell = New TableCell()
                        Dim Label As Label = New Label()
                        If r = -1 Then
                            Label.Text = Str(c) '"<u>" ++ "</u>"
                            If Label.Text = "Student Photo" Then
                                photo = c
                            End If
                            Label.ForeColor = Drawing.Color.Navy
                            Label.Font.Bold = True
                            ' Add the control to the TableCell
                            tc.Controls.Add(Label)
                            tc.Wrap = False
                            tc.VerticalAlign = VerticalAlign.Bottom
                            tc.HorizontalAlign = HorizontalAlign.Justify
                            ' Add the TableCell to the TableRow
                            tr.Cells.Add(tc)
                            tc.BorderColor = Drawing.Color.LightGray
                            tc.BorderStyle = BorderStyle.Ridge
                            tc.BorderWidth = 1.5
                        Else
                            If photo <> 0 Then
                                If c = photo Then
                                    Dim image As New Image
                                    image.ImageUrl = dt.Rows(r)(c).ToString
                                    image.Width = 80
                                    image.Height = 80
                                    ' Add the control to the TableCell
                                    tc.Controls.Add(image)
                                    tc.VerticalAlign = VerticalAlign.Bottom
                                    tc.HorizontalAlign = HorizontalAlign.Left
                                    ' Add the TableCell to the TableRow
                                    tr.Cells.Add(tc)
                                    tc.BorderColor = Drawing.Color.LightGray
                                    tc.BorderStyle = BorderStyle.Ridge
                                    tc.BorderWidth = 1
                                Else
                                    Label.Text = dt.Rows(r)(c).ToString
                                    ' Add the control to the TableCell
                                    tc.Controls.Add(Label)
                                    tc.VerticalAlign = VerticalAlign.Bottom
                                    tc.HorizontalAlign = HorizontalAlign.Left
                                    ' Add the TableCell to the TableRow
                                    tr.Cells.Add(tc)
                                    tc.BorderColor = Drawing.Color.LightGray
                                    tc.BorderStyle = BorderStyle.Ridge
                                    tc.BorderWidth = 1
                                End If
                            Else
                                Label.Text = dt.Rows(r)(c).ToString
                                ' Add the control to the TableCell
                                tc.Controls.Add(Label)
                                tc.VerticalAlign = VerticalAlign.Bottom
                                tc.HorizontalAlign = HorizontalAlign.Left
                                ' Add the TableCell to the TableRow
                                tr.Cells.Add(tc)
                                tc.BorderColor = Drawing.Color.LightGray
                                tc.BorderStyle = BorderStyle.Ridge
                                tc.BorderWidth = 1
                            End If
                        End If
                    Next
                    ' Add the TableRow to the Table
                    tbl.Rows.Add(tr)
                Next
                lbldate.Text = Format(Now, "dd-MMM-yyyy hh:mm tt")
            Else
                Image1.Visible = False
                HeaderPanel.Visible = False
                lblerr.Visible = True
                footerpanel.Visible = False
            End If
            ' This parameter helps determine in the LoadViewState event,
            ' whether to recreate the dynamic controls or not
            ViewState("dynamictable") = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Overrides Sub LoadViewState(ByVal earlierState As Object)
        MyBase.LoadViewState(earlierState)
        If ViewState("dynamictable") Is Nothing Then
            CreateDynamicTable()
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Image1.ImageUrl = Session("Logo").ToString
        lblSmallTitle.ForeColor = Drawing.Color.Navy
        lblSmallTitle.Font.Bold = True
        lblTitle.ForeColor = Drawing.Color.Navy
        lblTitle.Font.Bold = True
        lblTitle.Font.Size = 10L
        lblSmallTitle.Text = Session("BranchName")
        lblFormName.ForeColor = Drawing.Color.Navy
        lblFormName.Font.Bold = True
        lblFormName.Font.Size = 10L
        lblTitle.Text = Session("Company_Address") + ", " + Session("City") + "-" + Session("Postal_Code") + ". " + Session("State") + ", " + Session("Country") + " Tel No.: " + Session("Contact_Number1") + " Fax No.: " + Session("Fax_Number")
        lblFormName.Text = "MONTHLY RUN"
        CreateDynamicTable()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dt.Rows.Count > 0 Then
            Dim filename As String = "DownloadMobileNoExcel.xls"
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim dgGrid As New DataGrid()
            dgGrid.DataSource = dt
            dgGrid.DataBind()

            'Get the HTML for the control.
            dgGrid.RenderControl(hw)
            'Write the HTML back to the browser.
            'Response.ContentType = application/vnd.ms-excel;
            Response.ContentType = "application/vnd.ms-excel"
            Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename & "")
            Me.EnableViewState = False
            Response.Write(tw.ToString())
            Response.[End]()
        Else
            lblerr.Visible = False
            Lblexp.Text = "No records to export."
        End If
    End Sub
End Class
