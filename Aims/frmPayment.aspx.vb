Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Partial Class frmPayment
    Inherits BasePage
    Dim PB As New B_PaymentMethos
    Dim PE As New Entity_PaymentMethod
    Dim dt As New DataTable
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtPaymentMethod.Focus()
        If btnSave.Text = "UPDATE" Then
            PE.Payment_Method = txtPaymentMethod.Text
            PE.PaymentMethodID = ViewState("paymentid")
            dt = PB.GetPayDuplicate(PE)
            If dt.Rows.Count > 0 Then
                lblmsg.Text = ""
                msginfo.Text = "Data already exists"
                'clear()
                'DispGrid()
            Else
                PB.Update(PE)
                btnSave.Text = "ADD"
                btnDetails.Text = "VIEW"
                clear()
                msginfo.Text = ""
                lblmsg.Text = "Data updated successfully."
                DispGrid()
                GridPayment.Enabled = True
            End If
        ElseIf btnSave.Text = "ADD" Then
            PE.Payment_Method = txtPaymentMethod.Text
            dt = PB.GetPayDuplicate(PE)
            If dt.Rows.Count > 0 Then
                lblmsg.Text = ""
                msginfo.Text = "Data already exists"
                clear()
                DispGrid()
            Else
                PE.Payment_Method = txtPaymentMethod.Text
                PB.Insert(PE)
                msginfo.Text = ""
                lblmsg.Text = "Data saved successfully."
                GridPayment.Enabled = True
                clear()
                DispGrid()
            End If
        End If

    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        msginfo.Text = ""
        lblmsg.Text = ""
        If btnDetails.Text <> "BACK" Then
            DispGrid()
            clear()
        Else
            clear()
            btnDetails.Text = "VIEW"
            btnSave.Text = "ADD"
            DispGrid()
        End If
        clear()
    End Sub

    Protected Sub GridPayment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridPayment.PageIndexChanging
        GridPayment.PageIndex = e.NewPageIndex
        DispGrid()
        GridPayment.DataBind()
        GridPayment.Visible = True
    End Sub
    Protected Sub GridPayment_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridPayment.RowDeleting
        ViewState("paymentid") = CType(GridPayment.Rows(e.RowIndex).FindControl("Label5"), Label).Text
        PE.PaymentMethodID = ViewState("paymentid")
        PB.changeFlag(PE.PaymentMethodID)
        GridPayment.DataBind()
        GridPayment.Visible = False
        msginfo.Text = ""
        lblmsg.Text = "Data deleted successfully."
        txtPaymentMethod.Focus()
        DispGrid()
    End Sub
    Sub DispGrid()
        PE.PaymentMethodID = 0
        dt = PB.GetPaymentType(PE)
        If dt.Rows.Count <> 0 Then
            GridPayment.DataSource = dt
            GridPayment.DataBind()
            GridPayment.Visible = True
            GridPayment.Enabled = True
            clear()
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display"
        End If
    End Sub
    Protected Sub GridPayment_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridPayment.RowEditing
        txtPaymentMethod.Text = CType(GridPayment.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        ViewState("paymentid") = CType(GridPayment.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        PE.PaymentMethodID = ViewState("paymentid")
        btnSave.Text = "UPDATE"
        dt = PB.GetPaymentType(PE)
        GridPayment.DataSource = dt
        GridPayment.DataBind()
        e.Cancel = True
        GridPayment.Enabled = False
        btnDetails.Visible = False
        btnDetails.Text = "BACK"
        btnDetails.Visible = True
        btnSave.Text = "UPDATE"
    End Sub

    Sub clear()
        txtPaymentMethod.Text = ""

    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPaymentMethod.Focus()
    End Sub
End Class
