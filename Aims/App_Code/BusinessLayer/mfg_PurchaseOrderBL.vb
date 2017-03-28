Imports Microsoft.VisualBasic

Public Class mfg_PurchaseOrderBL
    Dim dl As New mfg_PurchaseOrderDL
    Public Function AddPODetails(ByVal el As mfg_PurchaseOrderEL) As Integer
        Dim rowseffected As Integer
        rowseffected = dl.AddPODetails(el)
        Return rowseffected
    End Function
    Public Function UpdateProductPO(ByVal el As mfg_PurchaseOrderEL) As Integer
        Dim rowseffected As Integer
        rowseffected = dl.UpdateProductPO(el)
        Return rowseffected
    End Function
    Public Function AddPurchaseOrder(ByVal el As mfg_PurchaseOrderEL) As Integer
        Dim rowseffected As Integer
        rowseffected = dl.AddPurchaseOrder(el)
        Return rowseffected
    End Function
    Public Function UpdatePurchaseOrder(ByVal el As mfg_PurchaseOrderEL) As Integer
        Dim rowseffected As Integer
        rowseffected = dl.UpdatePurchaseOrder(el)
        Return rowseffected
    End Function
    Public Function GetPODetails(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Return dl.GetPODetails(el)
    End Function
    Public Function getPurchaseRate(ByVal Id As Integer) As DataTable
        Return dl.getPurchaseRate(Id)
    End Function
    Public Function getPurchaseQtyReceived(ByVal Id As Integer, ByVal PId As String) As DataTable
        Return dl.getPurchaseQtyReceived(Id, PId)
    End Function
    Public Function getProductforSupplierId(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Return dl.getProductforSupplierId(el)
    End Function
    Public Function ProductComboD(ByVal Id As Integer) As Data.DataTable
        Return dl.ProductComboD(Id)
    End Function
    Public Function DeletePODetails(ByVal Id As Integer) As Integer
        Dim rowseffected As Integer
        rowseffected = dl.DeletePODetails(Id)
        Return rowseffected
    End Function
    Public Function DeletePurchaseOrder(ByVal Id As Integer) As Integer
        Dim rowseffected As Integer
        rowseffected = dl.DeletePurchaseOrder(Id)
        Return rowseffected
    End Function
    Public Function GetSupplierAutoFill(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Return dl.GetSupplierAutoFill(el)
    End Function
    Public Function GetPONo() As DataTable
        Return dl.GetPONo()
    End Function
    Public Function GetProductforPONo(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Return dl.GetProductforPONo(el)
    End Function
    Public Function getPurchaseOrderforEdit(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Return dl.getPurchaseOrderforEdit(el)
    End Function
    Public Function GetProductforPO(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Return dl.GetProductforPO(el)
    End Function
    Public Function DuplicatePurchaseOrder(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Return dl.DuplicatePurchaseOrder(el)
    End Function
    Public Function DuplicateProductPO(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Return dl.DuplicateProductPO(el)
    End Function
    Public Function PostPurchaseOrder(ByVal el As mfg_PurchaseOrderEL) As Integer
        Dim rowseffected As Integer
        rowseffected = dl.PostPurchaseOrder(el)
        Return rowseffected
    End Function
    Public Function PostStatus(ByVal el As mfg_PurchaseOrderEL) As DataTable
        Return dl.PostStatus(el)
    End Function
End Class
