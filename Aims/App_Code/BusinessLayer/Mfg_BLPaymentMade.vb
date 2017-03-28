Imports Microsoft.VisualBasic

Public Class Mfg_BLPaymentMade
    Dim DL As New Mfg_DLPaymentMade
    Public Function getDetails(ByVal EL As Mfg_ElPaymentMade) As Data.DataTable
        Return Mfg_DLPaymentMade.GridviewDetails(EL)
    End Function
    Public Function InsertRecord(ByVal EL As Mfg_ElPaymentMade) As Integer
        Return Mfg_DLPaymentMade.Insert(EL)
    End Function
    Public Function UpdateRecord(ByVal EL As Mfg_ElPaymentMade) As Integer
        Return Mfg_DLPaymentMade.Update(EL)
    End Function
    Public Function DeleteRecord(ByVal id As Long) As Integer
        Return Mfg_DLPaymentMade.Delete(id)
    End Function
    'Public Function GetDuplicate(ByVal EL As Mfg_ElPaymentMade) As DataTable
    '    Return Mfg_DLPaymentMade.GetDuplicateType(EL)
    'End Function
    Public Function Getsupplierdetails(ByVal EL As Mfg_ElPaymentMade) As Data.DataTable
        Return Mfg_DLPaymentMade.Getsupplierdetails(EL)
    End Function
    Public Function GetInvoicedetails(ByVal EL As Mfg_ElPaymentMade) As Data.DataTable
        Return Mfg_DLPaymentMade.GetInvoicedetails(EL)
    End Function
    Public Function amtpaid(ByVal EL As Mfg_ElPaymentMade) As Data.DataTable
        Return Mfg_DLPaymentMade.amtpaid(EL)
    End Function
    Public Function amtpaidInvoice(ByVal EL As Mfg_ElPaymentMade) As Data.DataTable
        Return Mfg_DLPaymentMade.amtpaidInvoice(EL)
    End Function
End Class
