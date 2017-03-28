Imports System.Data.OleDb
Imports System.Data
Imports System.Web.UI.DataVisualization.Charting
Partial Class frmMonthWiseStockDashboard
    Inherits BasePage
    Dim dt As DataTable
    Dim Dl As New DLMonthWiseDashboard

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim dt As New DataTable
            lblRed.Text = ""
            Dim year, Branch As String
            Branch = Session("BranchName")
            If ddlYear.SelectedValue = 0 Then
                lblRed.Text = "Select year."
                Exit Sub
            Else
                year = ddlYear.SelectedItem.Text

            End If

            dt = Dl.MonthWiseStock(year)
            If dt.Rows.Count = 0 Then
                lblRed.Text = "No records to display."
            Else

                Chart1.Series("Series1").YValueMembers = "Stock"
                Chart1.Series("Series1").XValueMember = "Month"
                Chart1.DataSource = dt
                Chart1.DataBind()

                Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
                Chart1.ChartAreas(0).AxisX.Interval = 1
                Chart1.ChartAreas(0).AxisX.Title = Branch
                Chart1.Series("Series1")("PointWidth") = "0.3"
                'Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
                Chart1.ChartAreas("ChartArea1").Area3DStyle.LightStyle = LightStyle.Realistic
                Chart1.Series("Series1")("DrawingStyle") = "Cylinder"

                Chart1.Visible = True


            End If
        Catch ex As Exception
            lblRed.Text = "Enter Correct date."
        End Try
    End Sub

    Protected Sub Chart1_Customize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart1.Customize
        For Each dp As DataPoint In Chart1.Series("Series1").Points
            dp.Color = Drawing.Color.RosyBrown


        Next
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlYear.Focus()
        Chart1.Visible = False
    End Sub
    <System.Web.Services.WebMethod()> _
   Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
