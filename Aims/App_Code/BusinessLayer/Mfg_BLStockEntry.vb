Imports Microsoft.VisualBasic

Public Class Mfg_BLStockEntry
    Dim DLL As New Mfg_DLStockEntry

    Public Function InsertRecord(ByVal i As Mfg_ELStockEntry) As Integer
        Return DLL.Insert(i)
    End Function
    Public Function InsertStockEntry(ByVal i As Mfg_ELStockEntry) As Integer
        Return DLL.InsertStock(i)
    End Function
    Public Function UpdateRecord(ByVal i As Mfg_ELStockEntry) As Integer
        Return DLL.UpdateRecord(i)
    End Function
    Public Function GetStockEntryM(ByVal i As Mfg_ELStockEntry) As DataTable
        Return DLL.getStockEntryM(i)
    End Function
    Public Function UpdateRecordM(ByVal i As Mfg_ELStockEntry) As Integer
        Return DLL.UpdateRecordM(i)
    End Function
    Public Function PostPurchaseOrder(ByVal i As Mfg_ELStockEntry) As Integer
        Return DLL.PostPurchaseOrder(i)
    End Function
    Public Function GetInvoiceNo() As DataTable
        Return DLL.GetInvoiceNo()
    End Function

    Public Function DeleteStockM(ByVal i As Mfg_ELStockEntry) As Integer
        Return DLL.DeteteM(i)
    End Function

    Public Function DeleteStock(ByVal i As Mfg_ELStockEntry) As Integer
        Return DLL.DeteteStockEntry(i)
    End Function
    Public Function PostStatus(ByVal i As Mfg_ELStockEntry) As DataTable
        Return DLL.PostStatus(i)
    End Function
    Public Function GetStockEntryInvoice(ByVal i As Mfg_ELStockEntry) As DataTable
        Return DLL.getStockEntryInvoice(i)
    End Function

    Public Function GetCurrency(ByVal i As Mfg_ELStockEntry) As DataTable
        Return DLL.getCurrency(i)
    End Function
End Class
