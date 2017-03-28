Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class Mfg_frmSupplierWiseStock
    Inherits BasePage

    Dim DL As New Mfg_DLStockAudit

    Dim DT As New DataTable
    Dim Fromdate As DateTime
    Dim Todate As DateTime
    Dim SupplierId As Integer
    Dim sum As Double
    Dim sum2 As Double
    Dim expired As String
    Sub Display2(ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal SupplierId As Integer)
        lblStockV.Visible = "true"
        lblTotal.Visible = "true"
        txtStocalV.Visible = "true"
        txtvat.Visible = "true"
        lbltotalNo.Visible = "true"
        txtTotalNo.Visible = "true"

        sum = 0
        sum2 = 0


        If txtStartingDate.Text = "" Then
            Fromdate = "1/1/1900"
        Else
            Fromdate = txtStartingDate.Text
            'Fromdate = Format(txtStartingDate.Text, "dd-MM-yyyy")

        End If

        If txtEndDate.Text = "" Then
            Todate = "1/1/3000"
        Else
            Todate = txtEndDate.Text
        End If
        DT = DL.getSupplierWiseStock_Epired(Fromdate, Todate, SupplierId)
        Dim i As Integer = DT.Rows.Count - 1
        Dim t As Integer = DT.Rows.Count
        txtTotalNo.Text = t
        While (i >= 0)
            If (DT.Rows(i)("QtyInStock").ToString <> "") And (DT.Rows(i)("stockValue").ToString <> "") Then
                sum = sum + CInt(DT.Rows(i)("QtyInStock"))
                sum2 = sum2 + CInt(DT.Rows(i)("stockValue"))
            End If
            i = i - 1
        End While

        txtvat.Text = sum
        'txtvat.Text = sum.ToString("###,###,##")
        txtStocalV.Text = sum2
        'txtStocalV.Text = sum2.ToString("###,###,##")

        txtvat.Text = Format("0.00")
        txtStocalV.Text = Format("0.00")
        txtTotalNo.Text = Format("0.00")
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

    Protected Sub btnAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAll.Click
        Try

            ViewState("expired") = "N"

            Dim Fromdate As DateTime
            Dim Todate As DateTime
            Dim SupplierId As Integer
            'Dim total As Integer
            'Dim sum As Integer

            If txtStartingDate.Text = "" Then
                Fromdate = "1/1/1900"
            Else
                Fromdate = txtStartingDate.Text
                'Fromdate = Format(txtStartingDate.Text, "dd-MM-yyyy")

            End If

            If txtEndDate.Text = "" Then
                Todate = "1/1/3000"
            Else
                Todate = txtEndDate.Text
            End If
            SupplierId = ddlSupplire.SelectedValue

            If Fromdate > Todate Then
                lblerrmsg.Text = "Start date should not be greater than End date."
                txtEndDate.Focus()
                Exit Sub
            End If
            lblerrmsg.Text = ""
            lblerrmsg.Text = ""


          

            'sum = 0
            'For Each grid As GridViewRow In g1.Rows

            '    If CType(g1.FindControl("lblQtyIn"), Label).Text <> 0 Then
            '        total = CType(g1.FindControl("lblQtyIn"), Label).Text

            '    End If
            '    sum = sum + total

            'Next

            'txtvat.Text = sum
          







            ViewState("PageIndex") = 0
            g1.PageIndex = 0
            ''**********total calculation************

            Display(Fromdate, Todate, SupplierId)
            g1.Visible = True

        Catch ex As Exception
            lblerrmsg.Text = "Please enter the valid date."

            lblmsgifo.Text = ""
            g1.Visible = "false"
        End Try


    End Sub
    Sub Display(ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal SupplierId As Integer)
        Dim count As New Integer

        lbltotalNo.Visible = "true"
        lblStockV.Visible = "true"
        lblTotal.Visible = "true"
        txtStocalV.Visible = "true"
        txtvat.Visible = "true"
        txtTotalNo.Visible = "true"
        sum = 0
        sum2 = 0

        If txtStartingDate.Text = "" Then
            Fromdate = "1/1/1900"
        Else
            Fromdate = txtStartingDate.Text
            'Fromdate = Format(txtStartingDate.Text, "dd-MM-yyyy")

        End If

        If txtEndDate.Text = "" Then
            Todate = "1/1/3000"
        Else
            Todate = txtEndDate.Text
        End If
        DT = DL.getSupplierWiseStock(Fromdate, Todate, SupplierId, ViewState("expired"))
        Dim i As Integer = DT.Rows.Count - 1
        Dim t As Integer = DT.Rows.Count
        txtTotalNo.Text = t
        While (i >= 0)
            If (DT.Rows(i)("totstk").ToString <> "") And (DT.Rows(i)("stockvalue").ToString <> "") Then
                sum = sum + CInt(DT.Rows(i)("totstk"))
                sum2 = sum2 + CInt(DT.Rows(i)("stockvalue"))
            End If
            i = i - 1
        End While


      


        txtvat.Text = sum
        txtvat.Text = sum.ToString("N2")
        txtStocalV.Text = sum2
        txtStocalV.Text = sum2.ToString("N2")

        'txtvat.Text = Format("0.00")
        'txtStocalV.Text = Format("0.00")
        'txtTotalNo.Text = Format("0.00")



        If DT.Rows.Count = 0 Then

            g1.DataSource = Nothing
            g1.DataBind()
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
        Else
            g1.DataSource = DT
            lblerrmsg.Text = ""
            g1.DataBind()
            For Each grid As GridViewRow In g1.Rows

                Dim Test As String = CType(grid.FindControl("lblExpiry"), Label).Text

                If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-1900" Then
                    CType(grid.FindControl("lblExpiry"), Label).Text = " "
                End If
                If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-3000" Then
                    CType(grid.FindControl("lblExpiry"), Label).Text = " "
                End If
            Next

           
        End If



    End Sub

    Protected Sub btnExpired_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExpired.Click

        Dim Fromdate As DateTime
        Dim Todate As DateTime
        Dim SupplierId As Integer

        ViewState("expired") = "Y"
        If txtStartingDate.Text = "" Then
            Fromdate = "1/1/1900"
        Else
            Fromdate = txtStartingDate.Text
            'Fromdate = Format(txtStartingDate.Text, "dd-MM-yyyy")

        End If

        If txtEndDate.Text = "" Then
            Todate = "1/1/3000"
        Else
            Todate = txtEndDate.Text
        End If
        SupplierId = ddlSupplire.SelectedValue

        If Fromdate > Todate Then
            lblerrmsg.Text = "Start date should not be greater than End date."
            txtEndDate.Focus()
            Exit Sub
        End If
        lblerrmsg.Text = ""
        lblerrmsg.Text = ""



        ViewState("PageIndex") = 0
        g1.PageIndex = 0
        Display(Fromdate, Todate, SupplierId)
        g1.Visible = True
    End Sub

    Protected Sub g1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles g1.PageIndexChanging
        g1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = g1.PageIndex

        Display(Fromdate, Todate, SupplierId)

        g1.Visible = True
        lblmsgifo.Text = " "
        lblerrmsg.Text = " "
    End Sub

    Protected Sub g1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles g1.RowUpdated

    End Sub

    Protected Sub g1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles g1.RowUpdating
        lbltotalNo.Visible = "true"
        lblStockV.Visible = "true"
        lblTotal.Visible = "true"
        txtStocalV.Visible = "true"
        txtvat.Visible = "true"
        txtTotalNo.Visible = "true"
        Dim Product_Id As Integer
        Product_Id = CType(g1.Rows(e.RowIndex).Cells(1).FindControl("lblpid"), Label).Text

        'BatchId = CType(GElEigiblity.Rows(e.RowIndex).Cells(1).FindControl("HidBatchId"), HiddenField).Value

        Dim qrystring As String = "Mfg_frmSuppilerWiseStockDrillDown.aspx?" & QueryStr.Querystring() & "&Product_Id=" & Product_Id
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbltotalNo.Visible = "false"
        lblStockV.Visible = "false"
        lblTotal.Visible = "false"
        txtStocalV.Visible = "false"
        txtvat.Visible = "false"
        txtTotalNo.Visible = "false"


        If Not IsPostBack Then
            txtStartingDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
