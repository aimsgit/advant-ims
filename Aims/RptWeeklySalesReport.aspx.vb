Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Web.UI.DataVisualization.Charting
Partial Class RptWeeklySalesReport
    Inherits BasePage
    Dim DL As New DL_ShopWiseSalesReport
    Private Sub LoadChartData(ByVal initialDataSource As DataTable)
        For i As Integer = 1 To initialDataSource.Columns.Count - 1
            Dim series As New Series()
            For Each dr As DataRow In initialDataSource.Rows
                Dim y As String = CInt(dr(i))
                series.Points.AddXY(dr("Data").ToString(), y)
            Next
            Chart1.Series.Add(series)
        Next
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Chart1.Visible = False
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Chart1.Visible = True
        GetData()
    End Sub
    Public Sub GetData()
        Dim dt As New DataTable()
        Dim Branch1 As String = ""
        Dim month, year As String
        If ddlMonth.SelectedValue = "" Then
            month = 0
        Else
            month = ddlMonth.SelectedValue
        End If
        If ddlYear.SelectedValue = "" Then
            year = 0
        Else
            year = ddlYear.SelectedItem.Text
        End If
        dt = DL.WeeklySalesReport(month, year)
        If dt.Rows.Count = 0 Then

            lblRed.Text = "No records to display."
        Else
            Chart1.Series("Series1").YValueMembers = "week1"
            Chart1.Series("Series1").XValueMember = "Branch"
            Chart1.Series("Series2").YValueMembers = "week2"
            Chart1.Series("Series2").XValueMember = "Branch"
            Chart1.Series("Series3").YValueMembers = "week3"
            Chart1.Series("Series3").XValueMember = "Branch"
            Chart1.Series("Series4").YValueMembers = "week4"
            Chart1.Series("Series4").XValueMember = "Branch"
            Chart1.DataSource = dt
            Chart1.DataBind()

            Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = 45
            Chart1.ChartAreas(0).AxisX.Interval = 1
        End If
    End Sub
End Class


