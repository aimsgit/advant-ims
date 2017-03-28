
Partial Class mfg_frmPODetails
    Inherits BasePage
    Dim el As New mfg_PurchaseOrderEL
    Dim bl As New mfg_PurchaseOrderBL
    Dim dt As New DataTable
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        'Page.ClientScript.RegisterStartupScript(Me.GetType(), "close", "window.close();", True)
        
        'Response.Write("<script>closeWindow();</script>")
        'Response.Write("<script>window.close();</script>")
        'Response.Close()

        Response.Write("<script language='javascript'> { window.close() }</script>")

    End Sub
    Protected Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
        Dim MC1 As New MultiCurrencyManager
        Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(ddlCurrency.SelectedValue.ToString = "", 0, ddlCurrency.SelectedValue.ToString)))
        txtExRate.Text = MCD.BuyConversionRate
        Dim rate As Double
        Dim PurchaseRate As Double
        Dim Id As New Integer
        If DDLProduct.SelectedValue = "0" Then
            txtUnitRate.Text = ""
        Else
            rate = txtExRate.Text
            Id = DDLProduct.SelectedValue
            dt = bl.getPurchaseRate(Id)
            PurchaseRate = dt.Rows(0).Item("New_Purchase_Rate")
            txtUnitRate.Text = Format((PurchaseRate / rate), "N")
        End If
    End Sub
    Protected Sub DDLProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLProduct.SelectedIndexChanged
        Dim rate As Double
        Dim PurchaseRate As Double
        Dim Id As New Integer
        If DDLProduct.SelectedValue = "0" Then
            txtUnitRate.Text = ""
        Else
            rate = txtExRate.Text
            Id = DDLProduct.SelectedValue
            dt = bl.getPurchaseRate(Id)
            PurchaseRate = dt.Rows(0).Item("New_Purchase_Rate")
            ViewState("PurchaseRate") = PurchaseRate
            txtUnitRate.Text = Format((PurchaseRate / rate), "N")
        End If

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            txtExRate.Text = "1"
            If Request.QueryString.Get(("CurrencyIdTemp")) = "" And Request.QueryString.Get(("ExchangeRate")) = "" Then
                ddlCurrency.SelectedValue = 0
                txtExRate.Text = ""
                ddlCurrency.Enabled = True
                txtExRate.Enabled = True
            Else
                ddlCurrency.SelectedValue = Request.QueryString.Get(("CurrencyIdTemp"))
                txtExRate.Text = Request.QueryString.Get(("ExchangeRate"))
                ddlCurrency.Enabled = True
                txtExRate.Enabled = True
            End If

        End If
    End Sub
    Protected Sub RbProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbProduct.SelectedIndexChanged
        txtUnitRate.Text = ""
    End Sub
    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            el.SupplierId = Request.QueryString.Get(("SupplierId"))
            el.PONo = Request.QueryString.Get(("PONo"))
            el.CurrencyID = ddlCurrency.SelectedValue
            el.ExchangeRate = txtExRate.Text
            el.ProductID = DDLProduct.SelectedValue
            el.Quantity = txtQuantity.Text
            el.UnitID = ddlUnit.SelectedValue
            el.UnitRate = txtUnitRate.Text
            el.EstimatedPrice = ViewState("PurchaseRate")
            el.EstimatedValue = el.EstimatedPrice * el.Quantity
            el.ProductType = RbProduct.SelectedValue
            bl.AddPODetails(el)
            lblmsg.Text = "Data saved successfully."
            txtExRate.Text = ""
            ddlCurrency.ClearSelection()
            DDLProduct.ClearSelection()
            txtQuantity.Text = ""
            ddlUnit.ClearSelection()
            txtUnitRate.Text = ""

        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
End Class
