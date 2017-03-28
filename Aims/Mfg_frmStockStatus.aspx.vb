Partial Class Mfg_frmStockStatus
    Inherits BasePage
    Dim BLL As New Mfg_BLStockStatus
    Dim El As New MfgStkstatus
    Dim DLL As New Mfg_DLStockStatus
    Protected Sub RbTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbTYPE.SelectedIndexChanged
        BtnNormal.Text = "Normal"
        Button7.Text = "Consignment"
        BtnShow1.Text = "Show"
        BtnShow2.Text = "Show"
        BtnShow3.Text = "Show"
        Dim id As New Integer
        id = RbTYPE.SelectedValue
        DLL.GetProductName(id)
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Dim prodid, Gno, RNo, Ptype As New Integer
        Dim Sdate, Edate As New Date
        Dim Catgry As Integer
        Ptype = RbTYPE.SelectedValue
        If ddlProdName.SelectedValue = 0 Then
            prodid = 0
        Else
            prodid = ddlProdName.SelectedValue
        End If

        Catgry = DropDownList1.SelectedValue


        If ddlGodownNo.SelectedValue = 0 Then
            Gno = 0
        Else
            Gno = ddlGodownNo.SelectedValue
        End If
        If ddlRackNo.SelectedValue = 0 Then
            RNo = 0
        Else
            RNo = ddlRackNo.SelectedValue
        End If

        If txtStartDate.Text = "" Then
            Sdate = "1/1/1900"
        Else
            Sdate = txtStartDate.Text
        End If

        If txtEndDate.Text = "" Then
            Edate = "1/1/1900"
        Else
            Edate = txtEndDate.Text
        End If

        Dim dt As DataTable
        dt = DLL.GetViewdetails(prodid, Gno, RNo, Sdate, Edate, Ptype, Catgry)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            lblmsg.Text = ""
            msginfo.Text = ""
        End If
    End Sub
    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        panel2.Visible = True
        BtnNormal.Text = "Normal"
        Button7.Text = "Consignment"
        BtnShow1.Text = "Show"
        BtnShow2.Text = "Show"
        BtnShow3.Text = "Show"
        Dim prodid, Gno, RNo, Ptype As New Integer
        Dim Sdate, Edate As New Date
        Dim Catgry As Integer
        Ptype = RbTYPE.SelectedValue
        If ddlProdName.SelectedValue = 0 Then
            prodid = 0
        Else
            prodid = ddlProdName.SelectedValue
        End If

        Catgry = DropDownList1.SelectedValue


        If ddlGodownNo.SelectedValue = 0 Then
            Gno = 0
        Else
            Gno = ddlGodownNo.SelectedValue
        End If
        If ddlRackNo.SelectedValue = 0 Then
            RNo = 0
        Else
            RNo = ddlRackNo.SelectedValue
        End If

        If txtStartDate.Text = "" Then
            Sdate = "1/1/1900"
        Else
            Sdate = txtStartDate.Text
        End If

        If txtEndDate.Text = "" Then
            Edate = "1/1/1900"
        Else
            Edate = txtEndDate.Text
        End If

        Dim dt As DataTable
        dt = DLL.GetViewdetails(prodid, Gno, RNo, Sdate, Edate, Ptype, Catgry)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            lblmsg.Text = ""
            msginfo.Text = ""
            lblTotalpurflatrate.Visible = True
            lblTotalpurrate.Visible = True
            lbltotalqty.Visible = True
            lblTotpurflatrate.Visible = True
            lblTotpurrate.Visible = True
            lblRNo.Visible = True
        Else
            lblmsg.Text = "No records to display."
            msginfo.Text = ""
            GridView1.Visible = False
            lblTotalpurflatrate.Visible = False
            lblTotalpurrate.Visible = False
            lbltotalqty.Visible = False
            lblTotpurflatrate.Visible = False
            lblTotpurrate.Visible = False
            lblRNo.Visible = False

        End If
        Dim TotQty As Double = 0
        Dim Totpurrate As Double = 0
        Dim Totpurflatrate As Double = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                TotQty = dt.Rows(i).Item("QtyInStock").ToString + TotQty
                If dt.Rows(i).Item("Amount").ToString = "" Then
                    dt.Rows(i).Item("Amount") = 0
                End If
                Totpurrate = dt.Rows(i).Item("Amount") + Totpurrate
                If dt.Rows(i).Item("Stock_Value").ToString = "" Then
                    dt.Rows(i).Item("Stock_Value") = 0
                End If
                Totpurflatrate = dt.Rows(i).Item("Stock_Value") + Totpurflatrate
                lbltotalqty.Text = TotQty
                lblTotalpurrate.Text = Totpurrate
                lblTotalpurflatrate.Text = Totpurflatrate
                lblRNo.Visible = True
                lblTotpurflatrate.Visible = True
                lblTotpurrate.Visible = True

            Next
        End If
        If dt.Rows.Count > 0 Then
            For Each grid In GridView1.Rows
                If CType(grid.FindControl("lblExpiry"), Label).Text <> "" Then


                    If (CType(grid.FindControl("lblExpiry"), Label).Text < DateTime.Now.AddMonths(2)) And (CType(grid.FindControl("lblExpiry"), Label).Text > Today()) Then
                        CType(grid.FindControl("lblExpiry"), Label).BackColor = Drawing.Color.Yellow

                    ElseIf (CType(grid.FindControl("lblExpiry"), Label).Text) < Today() And CType(grid.FindControl("lblExpiry"), Label).Text <> "01-Jan-1900" Then
                        CType(grid.FindControl("lblExpiry"), Label).BackColor = Drawing.Color.Red

                    ElseIf (CType(grid.FindControl("lblExpiry"), Label).Text < DateTime.Now.AddMonths(4)) And (CType(grid.FindControl("lblExpiry"), Label).Text > Today()) Then
                        CType(grid.FindControl("lblExpiry"), Label).BackColor = Drawing.Color.Blue
                        CType(grid.FindControl("lblExpiry"), Label).ForeColor = Drawing.Color.White

                    End If

                End If
                If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-1900" Then
                    CType(grid.FindControl("lblExpiry"), Label).Text = ""
                End If
                If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-3000" Then
                    CType(grid.FindControl("lblExpiry"), Label).Text = ""
                End If
            Next
        End If
        'If dt.Rows(0).Item("Expiry").ToString <> "" Then

        '    If (dt.Rows(0).Item("Expiry") < DateTime.Now.AddMonths(2)) And (dt.Rows(0).Item("Expiry") > Today()) Then
        '        GridView1.Columns(3).ControlStyle.BackColor = Drawing.Color.Yellow
        '        GridView1.Columns(3).ControlStyle.ForeColor = Drawing.Color.Black
        '    End If

        'If (dt.Rows(0).Item("Expiry") < Today()) Then
        '    GridView1.Columns(3).ControlStyle.BackColor = Drawing.Color.Red
        '    GridView1.Columns(3).ControlStyle.ForeColor = Drawing.Color.White
        'End If
        'If (dt.Rows(0).Item("Expiry") < DateTime.Now.AddMonths(4)) And (dt.Rows(0).Item("Expiry") > Today()) Then
        '    GridView1.Columns(3).ControlStyle.BackColor = Drawing.Color.Blue
        '    GridView1.Columns(3).ControlStyle.ForeColor = Drawing.Color.White
        'End If
        'End If
        '    Next
        'End If

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'panel2.Visible = False
        If Not IsPostBack Then
            'GridView1.Visible = False
            'GridView1.Enabled = False
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If

    End Sub

    Protected Sub Btnshow1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShow1.Click
        GridView1.Columns(3).ControlStyle.BackColor = Drawing.Color.Yellow
        GridView1.Columns(3).ControlStyle.ForeColor = Drawing.Color.Black
        BtnShow1.Text = "Show On"
        BtnShow2.Text = "Show"
        BtnShow3.Text = "Show"
        BtnNormal.Text = "Normal"
        Button7.Text = "Consignment"
        panel2.Visible = True

        Dim prodid, Gno, RNo, id, Ptype As New Integer
        Dim Sdate, Edate As New Date

        Ptype = RbTYPE.SelectedValue
        prodid = ddlProdName.SelectedValue
        Gno = ddlGodownNo.SelectedValue
        RNo = ddlRackNo.SelectedValue
        If txtStartDate.Text = "" Then
            Sdate = "1/1/1900"
        Else
            Sdate = txtStartDate.Text
        End If


        If txtEndDate.Text = "" Then
            Edate = "1/1/1900"
        Else
            Edate = txtEndDate.Text
        End If

        id = 1
        Dim dt As DataTable
        dt = DLL.GetStkExpirydetails(id, Ptype)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            lblmsg.Text = ""
            msginfo.Text = ""
            lblTotalpurflatrate.Visible = True
            lblTotalpurrate.Visible = True
            lbltotalqty.Visible = True
            lblTotpurflatrate.Visible = True
            lblTotpurrate.Visible = True
            lblRNo.Visible = True
        Else
            lblmsg.Text = "No records to display."
            msginfo.Text = ""
            GridView1.Visible = False
            lblTotalpurflatrate.Visible = False
            lblTotalpurrate.Visible = False
            lbltotalqty.Visible = False
            lblTotpurflatrate.Visible = False
            lblTotpurrate.Visible = False
            lblRNo.Visible = False
        End If
        Dim TotQty As Integer = 0
        Dim Totpurrate As Integer = 0
        Dim Totpurflatrate As Integer = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                TotQty = dt.Rows(i).Item("QtyInStock").ToString + TotQty
                If dt.Rows(i).Item("Amount").ToString = "" Then
                    dt.Rows(i).Item("Amount") = 0
                End If
                Totpurrate = dt.Rows(i).Item("Amount") + Totpurrate
                If dt.Rows(i).Item("Stock_Value").ToString = "" Then
                    dt.Rows(i).Item("Stock_Value") = 0
                End If
                Totpurflatrate = dt.Rows(i).Item("Stock_Value") + Totpurflatrate
                lbltotalqty.Text = TotQty
                lblTotalpurrate.Text = Totpurrate
                lblTotalpurflatrate.Text = Totpurflatrate
            Next
        End If
    End Sub

    Protected Sub BtnShow2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShow2.Click
        GridView1.Columns(3).ControlStyle.BackColor = Drawing.Color.Blue
        GridView1.Columns(3).ControlStyle.ForeColor = Drawing.Color.White
        BtnShow1.Text = "Show"
        BtnShow2.Text = "Show On"
        BtnShow3.Text = "Show"
        BtnNormal.Text = "Normal"
        Button7.Text = "Consignment"
        panel2.Visible = True
        Dim prodid, Gno, RNo, id, Ptype As New Integer
        Dim Sdate, Edate As New Date
        Ptype = RbTYPE.SelectedValue
        prodid = ddlProdName.SelectedValue
        Gno = ddlGodownNo.SelectedValue
        RNo = ddlRackNo.SelectedValue
        If txtStartDate.Text = "" Then
            Sdate = "1/1/1900"
        Else
            Sdate = txtStartDate.Text
        End If


        If txtEndDate.Text = "" Then
            Edate = "1/1/1900"
        Else
            Edate = txtEndDate.Text
        End If

        id = 2
        Dim dt As DataTable
        dt = DLL.GetStkExpirydetails(id, Ptype)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            lblmsg.Text = ""
            msginfo.Text = ""
            lblTotalpurflatrate.Visible = True
            lblTotalpurrate.Visible = True
            lbltotalqty.Visible = True
            lblTotpurflatrate.Visible = True
            lblTotpurrate.Visible = True
            lblRNo.Visible = True
        Else
            lblmsg.Text = "No records to display."
            msginfo.Text = ""
            GridView1.Visible = False
            lblTotalpurflatrate.Visible = False
            lblTotalpurrate.Visible = False
            lbltotalqty.Visible = False
            lblTotpurflatrate.Visible = False
            lblTotpurrate.Visible = False
            lblRNo.Visible = False
        End If
        Dim TotQty As Integer = 0
        Dim Totpurrate As Integer = 0
        Dim Totpurflatrate As Integer = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                TotQty = dt.Rows(i).Item("QtyInStock").ToString + TotQty
                If dt.Rows(i).Item("Amount").ToString = "" Then
                    dt.Rows(i).Item("Amount") = 0
                End If
                Totpurrate = dt.Rows(i).Item("Amount") + Totpurrate
                If dt.Rows(i).Item("Stock_Value").ToString = "" Then
                    dt.Rows(i).Item("Stock_Value") = 0
                End If
                Totpurflatrate = dt.Rows(i).Item("Stock_Value") + Totpurflatrate
                lbltotalqty.Text = TotQty
                lblTotalpurrate.Text = Totpurrate
                lblTotalpurflatrate.Text = Totpurflatrate
            Next
        End If
    End Sub

    Protected Sub BtnShow3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShow3.Click
        GridView1.Columns(3).ControlStyle.BackColor = Drawing.Color.Red
        GridView1.Columns(3).ControlStyle.ForeColor = Drawing.Color.White
        BtnShow1.Text = "Show"
        BtnShow2.Text = "Show"
        BtnShow3.Text = "Show On"
        BtnNormal.Text = "Normal"
        Button7.Text = "Consignment"
        panel2.Visible = True
        Dim prodid, Gno, RNo, id, Ptype As New Integer
        Dim Sdate, Edate As New Date
        Ptype = RbTYPE.SelectedValue
        prodid = ddlProdName.SelectedValue
        Gno = ddlGodownNo.SelectedValue
        RNo = ddlRackNo.SelectedValue
        If txtStartDate.Text = "" Then
            Sdate = "1/1/1900"
        Else
            Sdate = txtStartDate.Text
        End If


        If txtEndDate.Text = "" Then
            Edate = "1/1/1900"
        Else
            Edate = txtEndDate.Text
        End If

        id = 3
        Dim dt As DataTable
        dt = DLL.GetStkExpirydetails(id, Ptype)

        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            lblmsg.Text = ""
            msginfo.Text = ""
            lblTotalpurflatrate.Visible = True
            lblTotalpurrate.Visible = True
            lbltotalqty.Visible = True
            lblTotpurflatrate.Visible = True
            lblTotpurrate.Visible = True
            lblRNo.Visible = True
        Else
            lblmsg.Text = "No records to display."
            lblTotalpurflatrate.Visible = False
            lblTotalpurrate.Visible = False
            lbltotalqty.Visible = False
            lblTotpurflatrate.Visible = False
            lblTotpurrate.Visible = False
            lblRNo.Visible = False
            msginfo.Text = ""
            GridView1.Visible = False
        End If
        Dim TotQty As Integer = 0
        Dim Totpurrate As Integer = 0
        Dim Totpurflatrate As Integer = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                TotQty = dt.Rows(i).Item("QtyInStock").ToString + TotQty
                If dt.Rows(i).Item("Amount").ToString = "" Then
                    dt.Rows(i).Item("Amount") = 0
                End If
                Totpurrate = dt.Rows(i).Item("Amount") + Totpurrate
                If dt.Rows(i).Item("Stock_Value").ToString = "" Then
                    dt.Rows(i).Item("Stock_Value") = 0
                End If
                Totpurflatrate = dt.Rows(i).Item("Stock_Value") + Totpurflatrate
                lbltotalqty.Text = TotQty
                lblTotalpurrate.Text = Totpurrate
                lblTotalpurflatrate.Text = Totpurflatrate
            Next
        End If
    End Sub

    Protected Sub BtnNormal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNormal.Click
        BtnNormal.Text = "Normal On"
        Button7.Text = "Consignment"
        BtnShow1.Text = "Show"
        BtnShow2.Text = "Show"
        BtnShow3.Text = "Show"
        panel2.Visible = True
        Dim prodid, Gno, RNo, id, Ptype As New Integer
        Dim Sdate, Edate As New Date
        Ptype = RbTYPE.SelectedValue
        'prodid = ddlProdName.SelectedValue
        'Gno = ddlGodownNo.SelectedValue
        'RNo = ddlRackNo.SelectedValue
        'Sdate = txtStartDate.Text
        'Edate = txtEndDate.Text
        id = 1
        Dim dt As DataTable
        dt = DLL.GetStkNorMaldetails(id, Ptype)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            lblmsg.Text = ""
            msginfo.Text = ""
            For Each grid In GridView1.Rows
                If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-1900" Then
                    CType(grid.FindControl("lblExpiry"), Label).Text = ""
                End If
                If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-3000" Then
                    CType(grid.FindControl("lblExpiry"), Label).Text = ""
                End If
            Next
            lblTotalpurflatrate.Visible = True
            lblTotalpurrate.Visible = True
            lbltotalqty.Visible = True
            lblTotpurflatrate.Visible = True
            lblTotpurrate.Visible = True
            lblRNo.Visible = True
        Else
            lblmsg.Text = "No records to display."
            lblTotalpurflatrate.Visible = False
            lblTotalpurrate.Visible = False
            lbltotalqty.Visible = False
            lblTotpurflatrate.Visible = False
            lblTotpurrate.Visible = False
            lblRNo.Visible = False
            msginfo.Text = ""
            GridView1.Visible = False
        End If
        Dim TotQty As Double = 0
        Dim Totpurrate As Double = 0
        Dim Totpurflatrate As Double = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                TotQty = dt.Rows(i).Item("QtyInStock").ToString + TotQty
                If dt.Rows(i).Item("Amount").ToString = "" Then
                    dt.Rows(i).Item("Amount") = 0
                End If
                Totpurrate = dt.Rows(i).Item("Amount") + Totpurrate
                If dt.Rows(i).Item("Stock_Value").ToString = "" Then
                    dt.Rows(i).Item("Stock_Value") = 0
                End If
                Totpurflatrate = dt.Rows(i).Item("Stock_Value") + Totpurflatrate
                lbltotalqty.Text = TotQty
                lblTotalpurrate.Text = Totpurrate
                lblTotalpurflatrate.Text = Totpurflatrate
            Next
        End If

    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        BtnNormal.Text = "Normal"
        Button7.Text = "Consignment On"
        BtnShow1.Text = "Show"
        BtnShow2.Text = "Show"
        BtnShow3.Text = "Show"
        panel2.Visible = True
        Dim prodid, Gno, RNo, id, Ptype As New Integer
        Dim Sdate, Edate As New Date
        Ptype = RbTYPE.SelectedValue
        'prodid = ddlProdName.SelectedValue
        'Gno = ddlGodownNo.SelectedValue
        'RNo = ddlRackNo.SelectedValue
        'Sdate = txtStartDate.Text
        'Edate = txtEndDate.Text
        id = 2
        Dim dt As DataTable
        dt = DLL.GetStkNorMaldetails(id, Ptype)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            lblmsg.Text = ""
            msginfo.Text = ""
            lblTotalpurflatrate.Visible = True
            lblTotalpurrate.Visible = True
            lbltotalqty.Visible = True
            lblTotpurflatrate.Visible = True
            lblTotpurrate.Visible = True
            lblRNo.Visible = True
        Else
            lblmsg.Text = "No records to display."
            lblTotalpurflatrate.Visible = False
            lblTotalpurrate.Visible = False
            lbltotalqty.Visible = False
            lblTotpurflatrate.Visible = False
            lblTotpurrate.Visible = False
            lblRNo.Visible = False
            msginfo.Text = ""
            GridView1.Visible = False
        End If
        Dim TotQty As Integer = 0
        Dim Totpurrate As Integer = 0
        Dim Totpurflatrate As Integer = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                TotQty = dt.Rows(i).Item("QtyInStock").ToString + TotQty
                If dt.Rows(i).Item("Amount").ToString = "" Then
                    dt.Rows(i).Item("Amount") = 0
                End If
                Totpurrate = dt.Rows(i).Item("Amount") + Totpurrate
                If dt.Rows(i).Item("Stock_Value").ToString = "" Then
                    dt.Rows(i).Item("Stock_Value") = 0
                End If
                Totpurflatrate = dt.Rows(i).Item("Stock_Value") + Totpurflatrate
                lbltotalqty.Text = TotQty
                lblTotalpurrate.Text = Totpurrate
                lblTotalpurflatrate.Text = Totpurflatrate
            Next
        End If
    End Sub

    'Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
    '    GridView1.PageIndex = e.NewPageIndex
    '    ViewState("PageIndex") = GridProduct.PageIndex
    '    DispGrid()
    '    GridView1.Visible = True
    '    lblmsgifo.Text = " "
    '    lblerrmsg.Text = " "

    'End Sub
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating


        Dim Product_ID As Integer
        Product_ID = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("lblPrdid"), Label).Text

        Dim qrystring As String = "frmStockStatusDrillDown.aspx?" & QueryStr.Querystring() & "&Product_ID=" & Product_ID
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)

    End Sub

    '    void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
    '{
    '    if (e.CellElement.ColumnInfo.Name == "YOUR_COLUMN_NAME")
    '    {
    '        e.CellElement.ForeColor = Color.Blue;
    '        e.CellElement.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
    '        e.CellElement.BackColor = Color.Red;
    '        e.CellElement.Font = new Font(e.CellElement.Font, FontStyle.Underline);
    '        e.CellElement.DrawFill = true;
    '    }
    '    else
    '    {
    '        e.CellElement.DrawFill = false;
    '        e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, Telerik.WinControls.ValueResetFlags.Local);
    '        e.CellElement.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
    '        e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, Telerik.WinControls.ValueResetFlags.Local);
    '        e.CellElement.ResetValue(LightVisualElement.FontProperty, Telerik.WinControls.ValueResetFlags.Local);
    '    }
    '}


    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim productId As Integer
            Dim godownNo As Integer
            Dim rackNo As Integer
            Dim Fromdate As DateTime
            Dim Todate As DateTime
            Dim Ptype As Integer

            productId = ddlProdName.SelectedValue
            godownNo = ddlGodownNo.SelectedValue
            rackNo = ddlRackNo.SelectedValue
            Dim category As Integer = DropDownList1.SelectedValue
            If txtStartDate.Text = "" Then
                Fromdate = "1/1/1900"
            Else
                Fromdate = txtStartDate.Text

            End If

            If txtEndDate.Text = "" Then
                Todate = "1/1/3000"
            Else
                Todate = txtEndDate.Text
            End If

            If Fromdate > Todate Then
                lblmsg.Text = "Start date should not be greater than End date."
                txtEndDate.Focus()
            End If
            Ptype = RbTYPE.SelectedValue
            Dim qrystring As String = "Mfg_Rpt_StockStatus.aspx?" & QueryStr.Querystring() & "&Fromdate=" & Fromdate & "&Todate=" & Todate & "&productId=" & productId & "&godownNo=" & godownNo & "&rackNo=" & rackNo & "&Ptype=" & Ptype & "&category=" & category
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            lblmsg.Text = "Please enter the valid date."
            msginfo.Text = ""
        End Try
        Exit Sub
    End Sub

End Class