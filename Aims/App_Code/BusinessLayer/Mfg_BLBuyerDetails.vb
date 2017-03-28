Imports Microsoft.VisualBasic

Public Class Mfg_BLBuyerDetails
    Public Function InsertRecord(ByVal SE As Mfg_ELBuyerDetails) As Integer
        Return Mfg_DLBuyerDetails.Insert(SE)
    End Function
    Public Function UpdateRecord(ByVal SE As Mfg_ELBuyerDetails) As Integer
        Return Mfg_DLBuyerDetails.Update(SE)
    End Function
    Public Function DeleteRecord(ByVal id As Long) As Integer
        Return Mfg_DLBuyerDetails.Delete(id)
    End Function
    Public Function GetBuyerDetails(ByVal se As Mfg_ELBuyerDetails) As System.Data.DataTable
        Return Mfg_DLBuyerDetails.GridviewDetails(se)
    End Function
    Public Function GetDuplicateSupplierMaster(ByVal SE As Mfg_ELBuyerDetails) As DataTable
        Return Mfg_DLBuyerDetails.GetSuppDuplicateType(SE)
    End Function
End Class
