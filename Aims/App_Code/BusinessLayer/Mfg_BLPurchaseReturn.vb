Imports Microsoft.VisualBasic

Public Class Mfg_BLPurchaseReturn
    Dim DLL As New Mfg_DLPurchaseReturn
    Public Function insert(ByVal EL As Mfg_ELPurchaseReturn) As Integer
        Return DLL.Insert(EL)
    End Function

    Public Function Insertrecord(ByVal EL As Mfg_ELPurchaseReturn) As Integer
        Return DLL.Insertrecord(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As Mfg_ELPurchaseReturn) As Integer
        Return DLL.UpdateRecord(EL)
    End Function
    Public Function update(ByVal EL As Mfg_ELPurchaseReturn) As Integer
        Return DLL.Update(EL)
    End Function
    Public Function getPurchaseReturnM(ByVal EL As Mfg_ELPurchaseReturn) As DataTable
        Return DLL.GetPurchaseReturnM(EL)
    End Function
    Public Function SelectProductName(ByVal Supplier, ByVal id) As DataTable
        Return DLL.SelectProductName(Supplier, id)
    End Function
    Public Function DeletePurchasReturn(ByVal EL As Mfg_ELPurchaseReturn) As Integer
        Return DLL.DeletePurchasReturn(EL)
    End Function

    Public Function DeletePurchaseReturnS(ByVal EL As Mfg_ELPurchaseReturn) As Integer
        Return DLL.DeletePurchaseReturnS(EL)
    End Function
    Public Function GetPurchaseReturnIDDetails(ByVal EL As Mfg_ELPurchaseReturn) As DataTable
        Return DLL.GetPurchaseReturnIDDetails(EL)
    End Function
    Public Function PostPurchaseReturn(ByVal i As Mfg_ELPurchaseReturn) As Integer
        Return DLL.PostPurchaseReturn(i)
    End Function
    Public Function GetPurchaserReturnS(ByVal EL As Mfg_ELPurchaseReturn) As DataTable
        Return DLL.GetPurchaseReturnS(EL)
    End Function
    Public Function BatchAutofill(ByVal EL As Mfg_ELPurchaseReturn) As DataTable
        Return DLL.BatchAutofill(EL)
    End Function
End Class
