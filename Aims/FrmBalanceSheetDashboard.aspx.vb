Imports System.Data.OleDb
Imports System.Data
Imports System.Web.UI.DataVisualization.Charting
Partial Class FrmBalanceSheetDashboard
    Inherits BasePage
    Dim dl As New DLReportsD
    Dim dt As New DataTable
    Dim FromDate As New Date
    Dim ToDate As New Date
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Txtfdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            Txttodate.Text = Format(CDate(Session("FinEndDate")), "dd-MMM-yyyy")
        End If
        
        Chart1.Visible = False
    End Sub
    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            Dim dt As New DataTable
            Dim fromdateE As DateTime
            Dim todateE As DateTime
            If Txtfdate.Text = "" Then
                fromdateE = "1/1/1900"
            Else
                fromdateE = Txtfdate.Text
            End If
            If Txttodate.Text = "" Then
                todateE = "1/1/1900"
            Else
                todateE = Txttodate.Text
            End If
            If fromdateE = "1/1/1900" Or todateE = "1/1/1900" Then
                ErrMsg.Text = "Please enter mandatory fields"
            ElseIf fromdateE > todateE Then
                ErrMsg.Text = "From Date cannot be greater than To Date"
                Txtfdate.Focus()
            Else
                dt = dl.BalanceSheetDashboard(fromdateE, todateE)
                If dt.Rows.Count = 0 Then
                Else
                    lblmsg.Text = ""
                    Chart1.Series("Series1").YValueMembers = "Amount"
                    Chart1.Series("Series1").XValueMember = "Acct_Sub_Group"
                    'Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
                    'Chart1.Series("Series1")("DrawingStyle") = "Cylinder"
                    Chart1.DataSource = dt
                    Chart1.DataBind()
                    Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
                    Chart1.ChartAreas(0).AxisX.Interval = 1
                    Chart1.Visible = True
                End If
            End If
        Catch ex As Exception
            'lblE.Text = "Enter Correct date."
        End Try
    End Sub
    Private Sub Chart1_Customize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart1.Customize
        For Each dp As DataPoint In Chart1.Series("Series1").Points
            dp.Color = Drawing.Color.Orange
        Next

    End Sub
    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Default2.aspx")
    End Sub
    Protected Sub Chart1_FormatNumber(ByVal sender As Object, ByVal e As System.Web.UI.DataVisualization.Charting.FormatNumberEventArgs) Handles Chart1.FormatNumber
        If (e.ElementType = DataVisualization.Charting.ChartElementType.AxisLabels) Then
            e.LocalizedValue = e.Value & "k"
        End If
    End Sub
End Class
