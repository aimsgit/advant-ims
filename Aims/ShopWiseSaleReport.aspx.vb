Imports System.Data.OleDb
Imports System.Data
Imports System.Web.UI.DataVisualization.Charting
Partial Class ShopWiseSaleReport
    Inherits BasePage
    Dim dt As DataTable
    Dim Dl As New DL_ShopWiseSalesReport
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlBranchName.Focus()
        If Not IsPostBack Then
            Txtfdate.Text = Format(Date.Today, "dd-MMM-yyyy")
        End If
        If Not IsPostBack Then
            Txttodate.Text = Format(Date.Today, "dd-MMM-yyyy")
        End If
        Chart1.Visible = False
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        LinkButton.Focus()
        Try
            Dim dt As New DataTable
            ErrMsg.Text = ""
            'Dim BranchCode As String = Request.QueryString.Get("Branch")
            Dim BranchCode As String
            If ddlBranchName.SelectedValue = 0 Then
                ErrMsg.Text = "Select branch."
                Exit Sub
            Else
                BranchCode = ddlBranchName.SelectedValue

            End If

            Dim fromdate As DateTime
            Dim todateE As DateTime
            If Txtfdate.Text = "" Then
                fromdate = "1/1/1900"
            Else
                fromdate = Txtfdate.Text
            End If
            If Txttodate.Text = "" Then
                todateE = "1/1/1900"
            Else
                todateE = Txttodate.Text
            End If
            If fromdate = "1/1/1900" Or todateE = "1/1/1900" Then
                ErrMsg.Text = "Please enter mandatory fields"
            ElseIf fromdate > todateE Then
                ErrMsg.Text = "From Date cannot be greater than To Date"
                Txtfdate.Focus()
            End If
            'If txtBranchName.SelectedValue = 0 Then
            dt = Dl.ShopWiseSaleReport(BranchCode, fromdate, todateE)
            If dt.Rows.Count = 0 Then
                ErrMsg.Text = "No records to display."
            Else

                Dim PurchaseAmt, SalesAmt, Stock As Double
                If dt.Rows(0).Item("PurchaseAmt") Is DBNull.Value Then
                    PurchaseAmt = 0

                Else
                    PurchaseAmt = dt.Rows(0).Item("PurchaseAmt")
                End If
                If dt.Rows(0).Item("SaleAmt") Is DBNull.Value Then
                    SalesAmt = 0
                Else
                    SalesAmt = dt.Rows(0).Item("SaleAmt")
                End If
                If dt.Rows(0).Item("stock") Is DBNull.Value Then
                    Stock = 0
                Else
                    Stock = dt.Rows(0).Item("stock")
                End If

                Chart1.Series("Series1").YValueMembers = "PurchaseAmt"
                'Chart1.Series("Series1").XValueMember = ""
                Chart1.Series("Series2").YValueMembers = "SaleAmt"
                'Chart1.Series("Series2").XValueMember = ""
                Chart1.Series("Series3").YValueMembers = "stock"
                'Chart1.Series("Series3").XValueMember = ""
                Chart1.DataSource = dt
                Chart1.DataBind()

                Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = 90
                Chart1.ChartAreas(0).AxisX.Interval = 1
                Chart1.ChartAreas(0).AxisX.Title = ddlBranchName.SelectedItem.Text

                Chart1.Visible = True

            End If
        Catch ex As Exception
            ErrMsg.Text = "Enter Correct date."
        End Try
    End Sub
End Class
