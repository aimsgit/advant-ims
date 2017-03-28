Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class Mfg_frmSEPerformanse
    Inherits BasePage
    Dim DL As New Mfg_DLStockAudit

    Dim DT As New DataTable
    Dim Fromdate As DateTime
    Dim Todate As DateTime
    Dim Party As Integer

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try

            Dim Fromdate As DateTime
            Dim Todate As DateTime
            Dim Party As Integer

            Party = ddlBuyerName.SelectedValue
            If txtStartingDate.Text = "" Then
                Fromdate = "1/1/1900"
            Else
                Fromdate = txtStartingDate.Text

            End If

            If txtEndDate.Text = "" Then
                Todate = "1/1/3000"
            Else
                Todate = txtEndDate.Text
            End If

            If Fromdate > Todate Then
                lblerrmsg.Text = "Start date should5d not be greater than End date."
                txtEndDate.Focus()
            End If


            ViewState("PageIndex") = 0
            g1.PageIndex = 0


            Display(Fromdate, Todate, Party)
            g1.Visible = True


            
        Catch ex As Exception
            g1.Visible = False
            lblerrmsg.Text = "Please enter the valid date."
            lblmsgifo.Text = ""


        End Try
    End Sub
    Sub Display(ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal Party As Integer)
       
        DT = DL.getSEPerformance(Fromdate, Todate, Party)
        
        If DT.Rows.Count = 0 Then

            g1.DataSource = Nothing
            g1.DataBind()
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
        Else
            g1.DataSource = DT
            lblerrmsg.Text = ""
            g1.DataBind()
        End If




    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
