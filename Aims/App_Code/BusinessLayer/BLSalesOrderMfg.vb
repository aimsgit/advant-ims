Imports Microsoft.VisualBasic

Public Class BLSalesOrderMfg
    Dim DLSalesOrderMfg As New DLSalesOrderMfg
    Public Function UpdateSaleOrder(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Return DLSalesOrderMfg.UpdateSaleOrder(ELSalesOrderMfg)
    End Function
    Public Function InsertSaleOrder(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Return DLSalesOrderMfg.InsertSaleOrder(ELSalesOrderMfg)
    End Function
    Public Function Sale_Invoice_Rev2(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Return DLSalesOrderMfg.Sale_Invoice_Rev2(ELSalesOrderMfg)
    End Function
    Public Function DeleteSaleOrder(ByVal id As Integer) As Integer
        Return DLSalesOrderMfg.DeleteSaleOrder(id)
    End Function
    Public Function GetSaleOrderView(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.GetSaleOrderView(ELSalesOrderMfg)
    End Function
    Public Function getTransportByCombo() As Data.DataTable
        Return DLSalesOrderMfg.getTransportByCombo()
    End Function
    Public Function filltextbox(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.filltextbox(ELSalesOrderMfg)
    End Function
    'Public Function GetBuyercombo() As Data.DataTable
    '    Return DLSalesOrderMfg.GetBuyercombo()
    'End Function
    Public Function PaymentMethodComboD() As Data.DataTable
        Return DLSalesOrderMfg.PaymentMethodComboD()
    End Function
    'Public Function ProductComboD() As Data.DataTable
    '    Return DLSalesOrderMfg.ProductComboD()
    'End Function
    Public Function GetSaleOrderGrid(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.GetSaleOrderGrid(ELSalesOrderMfg)
    End Function
    Public Function AutoGenerateNo(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.AutoGenerateNo(ELSalesOrderMfg)
    End Function
    Public Function CheckDuplicate(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.CheckDuplicate(ELSalesOrderMfg)
    End Function
    Public Function GetSaleOrderId(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.GetSaleOrderId(ELSalesOrderMfg)
    End Function
    Public Function CheckProduct(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.CheckProduct(ELSalesOrderMfg)
    End Function
    'Public Function EditSaleOrder(ByVal Product_ID As Integer) As Data.DataTable
    '    Return DLSalesOrderMfg.EditSaleOrder(Product_ID)
    'End Function
    Public Function EditSaleOrder(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.EditSaleOrder(ELSalesOrderMfg)
    End Function
    'Public Function DeleteSO(ByVal id As Integer) As Integer
    '    Return DLSalesOrderMfg.DeleteSO(id)
    'End Function
    Public Function UpdateSale_Invoice_Rev2(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Return DLSalesOrderMfg.UpdateSale_Invoice_Rev2(ELSalesOrderMfg)
    End Function
    Public Function GetSaleInvoiceNO(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.GetSaleInvoiceNO(ELSalesOrderMfg)
    End Function
    Public Function DeleteSaleOrder1(ByVal id As Integer) As Integer
        Return DLSalesOrderMfg.DeleteSaleOrder1(id)
    End Function
    Public Function checkproductandbuyer(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.checkproductandbuyer(ELSalesOrderMfg)
    End Function
    Public Function getsaleorderidField(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.getsaleorderidField(ELSalesOrderMfg)
    End Function
    Public Function InsertSODetails(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Return DLSalesOrderMfg.InsertSODetails(ELSalesOrderMfg)
    End Function
    Public Function ProductComboD() As Data.DataTable
        Return DLSalesOrderMfg.ProductComboD()
    End Function
    Public Function Getproduct(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.Getproduct(ELSalesOrderMfg)
    End Function
    Public Function GetproductEdit(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.GetproductEdit(ELSalesOrderMfg)
    End Function
    Public Function GetproductEditMorethanOne(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.GetproductEditMorethanOne(ELSalesOrderMfg)
    End Function
    Public Function Update(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Integer
        Return DLSalesOrderMfg.Update(ELSalesOrderMfg)
    End Function
    Public Function UpdatePostFlag(ByVal ElsaleorderMfg As ELSaleorderMfg) As Integer
        Return DLSalesOrderMfg.UpdatePostFlag(ElsaleorderMfg)
    End Function
    Public Function Getproduct1(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.Getproduct1(ELSalesOrderMfg)
    End Function
    Public Function CheckDuplicateforProduct(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.CheckDuplicateforProduct(ELSalesOrderMfg)
    End Function
    Public Function CheckDuplicateforBuyer(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.CheckDuplicateforBuyer(ELSalesOrderMfg)
    End Function
    Public Function GetSOPostStatus(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.GetSOPostStatus(ELSalesOrderMfg)
    End Function
    Public Function EstimatedRate(ByVal ELSalesOrderMfg As ELSaleorderMfg) As Data.DataTable
        Return DLSalesOrderMfg.EstimatedRate(ELSalesOrderMfg)
    End Function
End Class
