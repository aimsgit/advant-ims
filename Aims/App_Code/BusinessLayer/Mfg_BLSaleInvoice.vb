Imports Microsoft.VisualBasic

Public Class Mfg_BLSaleInvoice
    Dim DL As New MfgSaleInvoiceDL
    Public Function InsertSaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Return MfgSaleInvoiceDL.InsertSaleInvoice(EL)
    End Function
    Public Function GetSaleInvoice(ByVal Id As Mfg_ELSaleInvoice) As DataTable
        Return MfgSaleInvoiceDL.GetSaleInvoice(Id)
    End Function
    Public Function DeleteSaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Return DL.DeleteSaleInvoice(EL)
    End Function
    Public Function UpdateSaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Return MfgSaleInvoiceDL.UpdateSaleInvoice(EL)
    End Function
    Public Function CheckDuplicateSaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As DataTable
        Return DL.CheckDuplicateSaleInvoice(EL)
    End Function
    Public Function InsertSaleInvoiceDetails(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Return MfgSaleInvoiceDL.InsertSaleInvoiceDetails(EL)
    End Function
    Public Function PostStatus(ByVal EL As Mfg_ELSaleInvoice) As DataTable
        Return DL.PostStatus(EL)
    End Function
    Public Function GetSaleInvoiceDetails(ByVal Id As Mfg_ELSaleInvoice) As DataTable
        Return MfgSaleInvoiceDL.GetSaleInvoiceDetails(Id)
    End Function
    Public Function DeleteSaleInvoiceDetails(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Return DL.DeleteSaleInvoiceDetails(EL)
    End Function
    Public Function UpdateSaleInvoiceDetails(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Return MfgSaleInvoiceDL.UpdateSaleInvoiceDetails(EL)
    End Function
    Public Function Getmrp() As DataTable
        Return DL.Getmrp()
    End Function
    Public Function GetInvoiceNo() As DataTable
        Return DL.GetInvoiceNo()
    End Function
    Public Function AutoGenerateNo(ByVal EL As Mfg_ELSaleInvoice) As Data.DataTable
        Return MfgSaleInvoiceDL.AutoGenerateNo(EL)
    End Function
    Public Function Credit(ByVal EL As Mfg_ELSaleInvoice) As Data.DataTable
        Return MfgSaleInvoiceDL.Credit(EL)
    End Function
    Public Function PostsaleInvoice(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Return DL.PostsaleInvoice(EL)
    End Function
    Public Function PaymentRecPaidPurchaseInvoice(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Return DL.PaymentRecPaidPurchaseInvoice(EL)
    End Function
    Public Function PaymentRecPaidPurchaseInvoice2(ByVal EL As String) As Integer
        Return DL.PaymentRecPaidPurchaseInvoice2(EL)
    End Function
    Public Function PaymentRecPaidPurchaseInvoice1(ByVal i As Mfg_ELSaleInvoice) As Integer
        Return DL.PaymentRecPaidPurchaseInvoice1(i)
    End Function
    Public Function Pushtostock(ByVal EL As Mfg_ELSaleInvoice) As Integer
        Return DL.Pushtostock(EL)
    End Function
    Public Function GetSaleInvoiceIDDetails(ByVal EL As Mfg_ELSaleInvoice) As DataTable
        Return DL.GetSaleInvoiceIDDetails(EL)
    End Function
End Class
