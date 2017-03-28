Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Partial Class Mfg_frmSuppilerWiseStockDrillDown
    Inherits BasePage
    Dim DL As New Mfg_DLStockAudit
    Dim DT As New DataTable
   
    Dim Product_ID As Integer
    Dim Prop As New QureyStringP
    


   
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Product_ID As String = Request.QueryString.Get("Product_ID")

        QueryStr.GetValue(Page.Request, Prop)


        DT = DL.GetDrilldownSupplireWiseStock(Product_ID)

        If DT.Rows.Count = 0 Then
            GVDrillDown.DataSource = Nothing
            GVDrillDown.DataBind()
            msginfo.Text = "No records to display."
            msginfo.Focus()
        Else
            GVDrillDown.DataSource = DT
            GVDrillDown.DataBind()
            GVDrillDown.Focus()
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
