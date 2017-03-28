Imports Microsoft.VisualBasic

Public Class Mfg_BLStockAudit
    Dim DL As New Mfg_DLStockAudit
    Public Function GetInvoiceNo() As DataTable
        Return DL.GetInvoiceNo()
    End Function
    Public Function AutoGenerateNo(ByVal EL As Mfg_ELStockAudit) As Data.DataTable
        Return Mfg_DLStockAudit.AutoGenerateNo(EL)
    End Function
    Public Function Qty(ByVal EL As Mfg_ELStockAudit) As Data.DataTable
        Return Mfg_DLStockAudit.Qty(EL)
    End Function
    Public Function InsertSaleInvoiceDetails(ByVal EL As Mfg_ELStockAudit) As Data.DataTable
        Return Mfg_DLStockAudit.InsertSaleInvoiceDetails(EL)
    End Function
End Class
