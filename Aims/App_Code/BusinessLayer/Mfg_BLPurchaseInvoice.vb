Imports Microsoft.VisualBasic

Public Class Mfg_BLPurchaseInvoice
    Dim DLL As New Mfg_DLPurchaseInvoice
    Public Function InsertRecord(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.Insert(i)
    End Function
    Public Function DeletePurchaseInvoice(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.DeletePurchaseInvoice(i)
    End Function
    Public Function DeletePurchaseInvoiceS(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.DeletePurchaseInvoiceS(i)
    End Function
    Public Function UpdatePurchase(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.Update(i)
    End Function
    Public Function GetPurchaseInvoiceM(ByVal i As Mfg_ELPurchaseInvoice) As DataTable
        Return DLL.GetPurchaseInvoiceM(i)
    End Function
    Public Function GetPurchaseInvoiceDetails(ByVal i As Mfg_ELPurchaseInvoice) As DataTable
        Return DLL.GetPurchaseInvoiceDetails(i)
    End Function
    Public Function GetPurchaseInvoiceIDDetails(ByVal i As Mfg_ELPurchaseInvoice) As DataTable
        Return DLL.GetPurchaseInvoiceIDDetails(i)
    End Function

    Public Function UpdatePurchaseInvoiceDetails(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.UpdatePurchaseInvoiceDetails(i)
    End Function
    Public Function InsertToPost(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.InsertToPost(i)
    End Function
    Public Function PostPurchaseInvoice(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.PostPurchaseInvoice(i)
    End Function
    Public Function PaymentRecPaidPurchaseInvoice(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.PaymentRecPaidPurchaseInvoice(i)
    End Function
    Public Function PaymentRecPaidPurchaseInvoice1(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.PaymentRecPaidPurchaseInvoice1(i)
    End Function
    'Public Function GetInvoiceNo() As DataTable
    '    Return DLL.GetInvoiceNo()
    'End Function
    Public Function CheckDuplicate(ByVal s As Mfg_ELPurchaseInvoice) As System.Data.DataTable
        Return DLL.CheckDuplicate(s)
    End Function
    Public Function Insert(ByVal i As Mfg_ELPurchaseInvoice) As Integer
        Return DLL.InsertPurchaseInvoice(i)
    End Function
End Class
